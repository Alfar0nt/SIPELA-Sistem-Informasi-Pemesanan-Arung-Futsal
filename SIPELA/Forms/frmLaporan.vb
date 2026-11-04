Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Laporan & Analitik Pendapatan (SIPELA).
    ''' Menampilkan rekapitulasi omzet sewa, okupansi lapangan, analisis pertumbuhan MoM,
    ''' ekspor data tabular ke file CSV/Excel, dan pencetakan ringkasan laporan operasional.
    ''' </summary>
    Public Class frmLaporan

        Private _dtLaporan As New DataTable()

        Private Sub frmLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Terapkan Tema Desain Taktil Neo-Brutalism
            TerapkanTemaDesain()

            ' 2. Inisialisasi Filter
            InisialisasiFilterTahunBulan()

            ' 3. Muat data laporan awal
            MuatDataLaporan()
        End Sub

        Private Sub TerapkanTemaDesain()
            ModUIHelper.TerapkanTemaForm(Me)
            ModUIHelper.TerapkanGayaCard(pnlToolbar)
            ModUIHelper.TerapkanGayaCard(pnlGridContainer)

            ModUIHelper.TerapkanGayaCard(pnlCardOmzet, ModUIHelper.ColorMintGreen)
            ModUIHelper.TerapkanGayaCard(pnlCardOkupansi, ModUIHelper.ColorSkyBlue)
            ModUIHelper.TerapkanGayaCard(pnlCardMoM, ModUIHelper.ColorLavender)

            ModUIHelper.TerapkanGayaTombol(btnKembali, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnFilter, ModUIHelper.TombolTipe.SecondarySky)
            ModUIHelper.TerapkanGayaTombol(btnEksporCSV, ModUIHelper.TombolTipe.PrimaryMint)
            ModUIHelper.TerapkanGayaTombol(btnCetakLaporan, ModUIHelper.TombolTipe.SecondarySky)

            ModUIHelper.TerapkanGayaGrid(dgvLaporan)
        End Sub

        Private Sub InisialisasiFilterTahunBulan()
            ' Tahun (Tahun ini - 2 s.d. Tahun ini + 1)
            cmbTahun.Items.Clear()
            Dim thnSekarang As Integer = DateTime.Today.Year
            For t As Integer = thnSekarang - 2 To thnSekarang + 1
                cmbTahun.Items.Add(t.ToString())
            Next
            cmbTahun.SelectedItem = thnSekarang.ToString()

            ' Bulan
            cmbBulan.Items.Clear()
            cmbBulan.Items.Add("Semua Bulan")
            cmbBulan.Items.Add("01 - Januari")
            cmbBulan.Items.Add("02 - Februari")
            cmbBulan.Items.Add("03 - Maret")
            cmbBulan.Items.Add("04 - April")
            cmbBulan.Items.Add("05 - Mei")
            cmbBulan.Items.Add("06 - Juni")
            cmbBulan.Items.Add("07 - Juli")
            cmbBulan.Items.Add("08 - Agustus")
            cmbBulan.Items.Add("09 - September")
            cmbBulan.Items.Add("10 - Oktober")
            cmbBulan.Items.Add("11 - November")
            cmbBulan.Items.Add("12 - Desember")

            Dim blnSekarang As Integer = DateTime.Today.Month
            cmbBulan.SelectedIndex = blnSekarang ' Index 1 s.d. 12 sesuai bulan

            ' Jenis Laporan
            cmbJenisLaporan.SelectedIndex = 0
        End Sub

        Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
            MuatDataLaporan()
        End Sub

        Private Sub cmbJenisLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisLaporan.SelectedIndexChanged
            MuatDataLaporan()
        End Sub

        ''' <summary>
        ''' Memuat dataset laporan dan menghitung metrik 3 kartu analitik.
        ''' </summary>
        Private Sub MuatDataLaporan()
            Dim tahun As Integer = DateTime.Today.Year
            Integer.TryParse(If(cmbTahun.SelectedItem IsNot Nothing, cmbTahun.SelectedItem.ToString(), ""), tahun)

            Dim bulanDipilih As Nullable(Of Integer) = Nothing
            If cmbBulan.SelectedIndex > 0 Then
                bulanDipilih = cmbBulan.SelectedIndex
            End If

            Dim jenisIndex As Integer = cmbJenisLaporan.SelectedIndex

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Dim sql As String = String.Empty

                    Select Case jenisIndex
                        Case 0
                            ' Ringkasan Bulanan (MoM) via v_laporan_bulanan
                            sql = "SELECT " &
                                  "  periode AS 'Periode', " &
                                  "  total_pendapatan AS 'Pendapatan (Rp)', " &
                                  "  total_transaksi AS 'Total Transaksi', " &
                                  "  slot_terisi AS 'Slot Terisi', " &
                                  "  kapasitas_slot AS 'Kapasitas Slot', " &
                                  "  persen_okupansi AS 'Okupansi (%)' " &
                                  "FROM v_laporan_bulanan " &
                                  "WHERE (@tahun IS NULL OR periode LIKE CONCAT(@tahun, '%')) " &
                                  "ORDER BY periode DESC;"

                        Case 1
                            ' Rincian Transaksi Pembayaran
                            sql = "SELECT " &
                                  "  pb.no_transaksi AS 'No. Transaksi', " &
                                  "  p.kode_booking AS 'Kode Booking', " &
                                  "  p.nama_pemesan AS 'Nama Pemesan', " &
                                  "  pb.jenis_pembayaran AS 'Jenis', " &
                                  "  pb.metode_pembayaran AS 'Metode', " &
                                  "  pb.jumlah_bayar AS 'Jumlah (Rp)', " &
                                  "  DATE_FORMAT(pb.waktu_bayar, '%d/%m/%Y %H:%i') AS 'Waktu Bayar', " &
                                  "  u.nama_lengkap AS 'Kasir' " &
                                  "FROM pembayaran pb " &
                                  "JOIN pemesanan p ON pb.id_pemesanan = p.id_pemesanan " &
                                  "JOIN users u ON pb.id_user = u.id_user " &
                                  "WHERE (@tahun IS NULL OR YEAR(pb.waktu_bayar) = @tahun) " &
                                  "  AND (@bulan IS NULL OR MONTH(pb.waktu_bayar) = @bulan) " &
                                  "ORDER BY pb.waktu_bayar DESC;"

                        Case 2
                            ' Rincian Pemesanan Sewa
                            sql = "SELECT " &
                                  "  p.kode_booking AS 'Kode Booking', " &
                                  "  p.nama_pemesan AS 'Nama Pemesan', " &
                                  "  p.no_telepon AS 'No. Telepon', " &
                                  "  p.total_sewa AS 'Total Sewa (Rp)', " &
                                  "  p.jumlah_dp AS 'Wajib DP (Rp)', " &
                                  "  p.status_pemesanan AS 'Status', " &
                                  "  DATE_FORMAT(p.waktu_dibuat, '%d/%m/%Y %H:%i') AS 'Waktu Dibuat', " &
                                  "  DATE_FORMAT(p.batas_bayar, '%d/%m/%Y %H:%i') AS 'Batas Bayar' " &
                                  "FROM pemesanan p " &
                                  "WHERE (@tahun IS NULL OR YEAR(p.waktu_dibuat) = @tahun) " &
                                  "  AND (@bulan IS NULL OR MONTH(p.waktu_dibuat) = @bulan) " &
                                  "ORDER BY p.id_pemesanan DESC;"
                    End Select

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@tahun", tahun)
                        cmd.Parameters.AddWithValue("@bulan", If(bulanDipilih.HasValue, CObj(bulanDipilih.Value), DBNull.Value))

                        Using da As New MySqlDataAdapter(cmd)
                            _dtLaporan = New DataTable()
                            da.Fill(_dtLaporan)
                            dgvLaporan.DataSource = _dtLaporan

                            ' Format Kolom Angka
                            For Each colName As String In New String() {"Pendapatan (Rp)", "Jumlah (Rp)", "Total Sewa (Rp)", "Wajib DP (Rp)"}
                                If dgvLaporan.Columns.Contains(colName) Then
                                    dgvLaporan.Columns(colName).DefaultCellStyle.Format = "N0"
                                    dgvLaporan.Columns(colName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                End If
                            Next
                        End Using
                    End Using

                    ' Perbarui Kartu Metrik Analitik
                    HitungKartuAnalitik(conn, tahun, bulanDipilih)

                    lblInfoStatus.Text = String.Format(
                        "Ditemukan {0} baris data • Terakhir dimuat: {1:HH:mm:ss} WIB",
                        _dtLaporan.Rows.Count, DateTime.Now
                    )
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memuat data laporan analitik", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Menghitung agregasi omzet total, okupansi rata-rata, dan pertumbuhan Month-over-Month (MoM).
        ''' </summary>
        Private Sub HitungKartuAnalitik(conn As MySqlConnection, tahun As Integer, bulan As Nullable(Of Integer))
            Dim totalOmzet As Decimal = 0D
            Dim totalTrx As Long = 0
            Dim okupansiAvg As Decimal = 0D
            Dim omzetBulanIni As Decimal = 0D
            Dim omzetBulanLalu As Decimal = 0D

            Try
                ' 1. Total omzet & transaksi sesuai filter
                Const sqlOmzet As String = "SELECT COALESCE(SUM(jumlah_bayar), 0) AS omzet, COUNT(*) AS trx " &
                                           "FROM pembayaran " &
                                           "WHERE YEAR(waktu_bayar) = @thn " &
                                           "  AND (@bln IS NULL OR MONTH(waktu_bayar) = @bln);"

                Using cmd As New MySqlCommand(sqlOmzet, conn)
                    cmd.Parameters.AddWithValue("@thn", tahun)
                    cmd.Parameters.AddWithValue("@bln", If(bulan.HasValue, CObj(bulan.Value), DBNull.Value))
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            totalOmzet = reader.GetDecimal("omzet")
                            totalTrx = reader.GetInt64("trx")
                        End If
                    End Using
                End Using

                ' 2. Rata-rata okupansi lapangan
                Const sqlOkupansi As String = "SELECT COALESCE(AVG(persen_okupansi), 0) AS avg_okupansi " &
                                              "FROM v_okupansi_bulanan " &
                                              "WHERE (@blnString IS NULL OR periode = @blnString) " &
                                              "   OR (@blnString IS NULL AND periode LIKE CONCAT(@thn, '%'));"

                Dim periodeStr As String = If(bulan.HasValue, String.Format("{0:D4}-{1:D2}", tahun, bulan.Value), Nothing)

                Using cmd As New MySqlCommand(sqlOkupansi, conn)
                    cmd.Parameters.AddWithValue("@thn", tahun)
                    cmd.Parameters.AddWithValue("@blnString", If(periodeStr IsNot Nothing, CObj(periodeStr), DBNull.Value))
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            okupansiAvg = reader.GetDecimal("avg_okupansi")
                        End If
                    End Using
                End Using

                ' 3. Pertumbuhan MoM (Bandingkan bulan dipilih dengan bulan sebelumnya)
                Dim blnTarget As Integer = If(bulan.HasValue, bulan.Value, DateTime.Today.Month)
                Dim tglBulanIni As New DateTime(tahun, blnTarget, 1)
                Dim tglBulanLalu As DateTime = tglBulanIni.AddMonths(-1)

                Const sqlMoM As String = "SELECT " &
                                         "  COALESCE(SUM(CASE WHEN YEAR(waktu_bayar) = @thnIni AND MONTH(waktu_bayar) = @blnIni THEN jumlah_bayar ELSE 0 END), 0) AS omzet_ini, " &
                                         "  COALESCE(SUM(CASE WHEN YEAR(waktu_bayar) = @thnLalu AND MONTH(waktu_bayar) = @blnLalu THEN jumlah_bayar ELSE 0 END), 0) AS omzet_lalu " &
                                         "FROM pembayaran;"

                Using cmd As New MySqlCommand(sqlMoM, conn)
                    cmd.Parameters.AddWithValue("@thnIni", tglBulanIni.Year)
                    cmd.Parameters.AddWithValue("@blnIni", tglBulanIni.Month)
                    cmd.Parameters.AddWithValue("@thnLalu", tglBulanLalu.Year)
                    cmd.Parameters.AddWithValue("@blnLalu", tglBulanLalu.Month)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            omzetBulanIni = reader.GetDecimal("omzet_ini")
                            omzetBulanLalu = reader.GetDecimal("omzet_lalu")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                ' Jangan crash jika view belum memiliki data
            End Try

            ' Tampilkan nilai pada ketiga kartu
            lblValOmzet.Text = String.Format("Rp {0:N0}", totalOmzet)
            lblValOkupansi.Text = String.Format("{0:F1} %", okupansiAvg)

            Dim momString As String = String.Format("{0} Trx", totalTrx)
            If omzetBulanLalu > 0 Then
                Dim momGrowth As Decimal = ((omzetBulanIni - omzetBulanLalu) / omzetBulanLalu) * 100D
                momString &= String.Format(" | {0}{1:F1}% MoM", If(momGrowth >= 0, "+", ""), momGrowth)
            ElseIf omzetBulanIni > 0 Then
                momString &= " | +100% MoM"
            Else
                momString &= " | 0.0% MoM"
            End If
            lblValMoM.Text = momString
        End Sub

        ''' <summary>
        ''' Mengekspor DataTable saat ini ke format CSV (Excel-Compatible dengan UTF-8 BOM).
        ''' </summary>
        Private Sub btnEksporCSV_Click(sender As Object, e As EventArgs) Handles btnEksporCSV.Click
            If _dtLaporan Is Nothing OrElse _dtLaporan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data laporan untuk diekspor.", "Peringatan")
                Return
            End If

            Using sfd As New SaveFileDialog()
                Dim jenisNama As String = If(cmbJenisLaporan.SelectedItem IsNot Nothing, cmbJenisLaporan.SelectedItem.ToString().Replace(" ", "_"), "Laporan")
                sfd.FileName = String.Format("SIPELA_{0}_{1:yyyyMMdd_HHmm}.csv", jenisNama, DateTime.Now)
                sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*"
                sfd.Title = "Simpan Laporan Spreadsheet"

                If sfd.ShowDialog(Me) = DialogResult.OK Then
                    Try
                        EksporDataTableKeCSV(_dtLaporan, sfd.FileName)
                        ModErrorHandler.TampilkanInfo(
                            "Laporan berhasil diekspor ke file CSV!" & Environment.NewLine & sfd.FileName,
                            "Ekspor Sukses"
                        )
                    Catch ex As Exception
                        ModErrorHandler.TampilkanError("Mengekspor file CSV", ex)
                    End Try
                End If
            End Using
        End Sub

        Private Sub EksporDataTableKeCSV(dt As DataTable, filePath As String)
            Dim sb As New StringBuilder()

            ' 1. Header kolom
            Dim headerParts As New List(Of String)()
            For Each col As DataColumn In dt.Columns
                headerParts.Add(EscapeCsv(col.ColumnName))
            Next
            sb.AppendLine(String.Join(";", headerParts))

            ' 2. Baris data
            For Each row As DataRow In dt.Rows
                Dim rowParts As New List(Of String)()
                For Each col As DataColumn In dt.Columns
                    Dim val As Object = row(col)
                    Dim strVal As String = If(val IsNot Nothing AndAlso Not DBNull.Value.Equals(val), val.ToString(), "")
                    rowParts.Add(EscapeCsv(strVal))
                Next
                sb.AppendLine(String.Join(";", rowParts))
            Next

            ' Tulis dengan encoding UTF-8 with BOM agar Excel langsung membaca dengan benar
            File.WriteAllText(filePath, sb.ToString(), New UTF8Encoding(True))
        End Sub

        Private Function EscapeCsv(field As String) As String
            If field Is Nothing Then Return """"""
            Dim cleaned As String = field.Replace("""", """""")
            Return """" & cleaned & """"
        End Function

        ''' <summary>
        ''' Menampilkan pratinjau teks laporan resmi dan membuka dialog cetak.
        ''' </summary>
        Private Sub btnCetakLaporan_Click(sender As Object, e As EventArgs) Handles btnCetakLaporan.Click
            If _dtLaporan Is Nothing OrElse _dtLaporan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data laporan untuk dicetak.", "Peringatan")
                Return
            End If

            Dim sb As New StringBuilder()
            Dim garis As String = "================================================================================"
            Dim strip As String = "--------------------------------------------------------------------------------"

            sb.AppendLine("                     LAPORAN KEUANGAN OPERASIONAL ARUNG FUTSAL                  ")
            sb.AppendLine("                   Jl. Raya Arung Futsal No. 12 Surabaya | 0812-3456-7890       ")
            sb.AppendLine(garis)
            sb.AppendLine(String.Format("Periode Rekap : {0} - Tahun {1}", cmbBulan.SelectedItem, cmbTahun.SelectedItem))
            sb.AppendLine(String.Format("Jenis Laporan : {0}", cmbJenisLaporan.SelectedItem))
            sb.AppendLine(String.Format("Waktu Cetak   : {0:dd/MM/yyyy HH:mm:ss} WIB", DateTime.Now))
            sb.AppendLine(String.Format("Dicetak Oleh  : {0} ({1})", ModSesi.NamaLengkap, ModSesi.Role))
            sb.AppendLine(strip)
            sb.AppendLine(String.Format("RINGKASAN UTAMA: Total Omzet: {0} | Okupansi: {1} | MoM: {2}", lblValOmzet.Text, lblValOkupansi.Text, lblValMoM.Text))
            sb.AppendLine(strip)

            ' Cetak tabel data ringkas
            Dim count As Integer = 0
            For Each row As DataRow In _dtLaporan.Rows
                count += 1
                If count > 30 Then
                    sb.AppendLine(String.Format("... dan {0} baris lainnya (lihat file CSV lengkap)", _dtLaporan.Rows.Count - 30))
                    Exit For
                End If

                Dim lineItems As New List(Of String)()
                For i As Integer = 0 To Math.Min(3, _dtLaporan.Columns.Count - 1)
                    lineItems.Add(row(i).ToString())
                Next
                sb.AppendLine(String.Join("  |  ", lineItems))
            Next

            sb.AppendLine(garis)
            sb.AppendLine("                 Laporan resmi dikeluarkan untuk arsip manajemen                ")

            Dim preview As New frmNotaPreview(sb.ToString())
            preview.Text = "Pratinjau Laporan Resmi - Arung Futsal"
            preview.ShowDialog(Me)
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

    End Class

End Namespace

