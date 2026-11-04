Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Kasir & Pembayaran Sewa Lapangan (SIPELA).
    ''' Menangani pembayaran Uang Muka (DP), pelunasan sisa sewa, kalkulasi kembalian,
    ''' dan pencetakan bukti struk nota pembayaran resmi.
    ''' </summary>
    Public Class frmPembayaran

        Private _idPemesananTerpilih As Integer = 0
        Private _kodeBookingTerpilih As String = String.Empty
        Private _namaPemesanTerpilih As String = String.Empty
        Private _noTeleponTerpilih As String = String.Empty
        Private _statusTerpilih As String = String.Empty
        Private _totalSewa As Decimal = 0D
        Private _totalTerbayar As Decimal = 0D
        Private _sisaTagihan As Decimal = 0D
        Private _tagihanYangHarusDibayar As Decimal = 0D
        Private _detailJadwalString As String = String.Empty
        Private _lastNotaString As String = String.Empty

        Private Sub frmPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Terapkan Tema Desain Taktil Neo-Brutalism
            TerapkanTemaDesain()

            ' 2. Konfigurasi default ComboBox
            cmbMetodePembayaran.SelectedIndex = 0

            ' 3. Muat daftar tagihan pemesanan aktif
            MuatDaftarPemesanan()

            ' 4. Generate no transaksi acuan
            PerbaruiNoTransaksi()
        End Sub

        Private Sub TerapkanTemaDesain()
            ModUIHelper.TerapkanTemaForm(Me)
            ModUIHelper.TerapkanGayaCard(pnlKiri)
            ModUIHelper.TerapkanGayaCard(pnlKanan)
            ModUIHelper.TerapkanGayaCard(pnlInfoBooking, ModUIHelper.ColorWarmCream)
            ModUIHelper.TerapkanGayaCard(pnlKembalian, ModUIHelper.ColorWarmCream)

            ModUIHelper.TerapkanGayaGrid(dgvBooking)

            ModUIHelper.TerapkanGayaTombol(btnKembali, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnCari, ModUIHelper.TombolTipe.SecondarySky)
            ModUIHelper.TerapkanGayaTombol(btnSegarkan, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnProsesBayar, ModUIHelper.TombolTipe.PrimaryMint)
            ModUIHelper.TerapkanGayaTombol(btnCetakUlang, ModUIHelper.TombolTipe.SecondarySky)
            ModUIHelper.TerapkanGayaTombol(btnBersihkan, ModUIHelper.TombolTipe.OutlineWhite)

            ModUIHelper.TerapkanGayaTombol(btnUangPas, ModUIHelper.TombolTipe.NeutralLavender)
            ModUIHelper.TerapkanGayaTombol(btn50k, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btn100k, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btn200k, ModUIHelper.TombolTipe.OutlineWhite)

            btnCetakUlang.Enabled = False
        End Sub

        ''' <summary>
        ''' Menghasilkan nomor transaksi pembayaran baru via ModAutoNumber.
        ''' </summary>
        Private Sub PerbaruiNoTransaksi()
            Try
                txtNoTransaksi.Text = ModAutoNumber.BuatKodeOtomatis("PAY", DateTime.Today)
            Catch
                txtNoTransaksi.Text = String.Format("PAY-{0:yyyyMMdd}-AUTO", DateTime.Today)
            End Try
        End Sub

        ''' <summary>
        ''' Memuat daftar pemesanan dari database yang membutuhkan pembayaran atau baru selesai.
        ''' </summary>
        Private Sub MuatDaftarPemesanan(Optional keyword As String = "")
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Dim sql As String = "SELECT " &
                                        "  p.id_pemesanan, " &
                                        "  p.kode_booking AS 'Kode Booking', " &
                                        "  p.nama_pemesan AS 'Nama Pemesan', " &
                                        "  p.no_telepon AS 'No. Telepon', " &
                                        "  p.total_sewa AS 'Total Sewa', " &
                                        "  p.jumlah_dp AS 'Wajib DP', " &
                                        "  p.status_pemesanan AS 'Status', " &
                                        "  COALESCE(SUM(b.jumlah_bayar), 0) AS 'Total Bayar', " &
                                        "  (p.total_sewa - COALESCE(SUM(b.jumlah_bayar), 0)) AS 'Sisa' " &
                                        "FROM pemesanan p " &
                                        "LEFT JOIN pembayaran b ON p.id_pemesanan = b.id_pemesanan " &
                                        "WHERE p.status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas') "

                    If Not String.IsNullOrWhiteSpace(keyword) Then
                        sql &= " AND (p.kode_booking LIKE @kw OR p.nama_pemesan LIKE @kw) "
                    End If

                    sql &= "GROUP BY p.id_pemesanan ORDER BY p.id_pemesanan DESC LIMIT 100;"

                    Using cmd As New MySqlCommand(sql, conn)
                        If Not String.IsNullOrWhiteSpace(keyword) Then
                            cmd.Parameters.AddWithValue("@kw", "%" & keyword.Trim() & "%")
                        End If

                        Using da As New MySqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            dgvBooking.DataSource = dt

                            ' Sembunyikan kolom ID internal
                            If dgvBooking.Columns.Contains("id_pemesanan") Then
                                dgvBooking.Columns("id_pemesanan").Visible = False
                            End If

                            ' Format Rupiah
                            If dgvBooking.Columns.Contains("Total Sewa") Then
                                dgvBooking.Columns("Total Sewa").DefaultCellStyle.Format = "N0"
                            End If
                            If dgvBooking.Columns.Contains("Wajib DP") Then
                                dgvBooking.Columns("Wajib DP").DefaultCellStyle.Format = "N0"
                            End If
                            If dgvBooking.Columns.Contains("Total Bayar") Then
                                dgvBooking.Columns("Total Bayar").DefaultCellStyle.Format = "N0"
                            End If
                            If dgvBooking.Columns.Contains("Sisa") Then
                                dgvBooking.Columns("Sisa").DefaultCellStyle.Format = "N0"
                            End If
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memuat daftar tagihan pemesanan", ex)
            End Try
        End Sub

        Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
            MuatDaftarPemesanan(txtCari.Text.Trim())
        End Sub

        Private Sub btnSegarkan_Click(sender As Object, e As EventArgs) Handles btnSegarkan.Click
            txtCari.Clear()
            MuatDaftarPemesanan()
        End Sub

        Private Sub dgvBooking_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBooking.SelectionChanged
            If dgvBooking.CurrentRow Is Nothing OrElse dgvBooking.CurrentRow.Index < 0 Then
                Return
            End If

            Dim row As DataGridViewRow = dgvBooking.CurrentRow
            If row.Cells("id_pemesanan").Value Is Nothing OrElse DBNull.Value.Equals(row.Cells("id_pemesanan").Value) Then
                Return
            End If

            _idPemesananTerpilih = Convert.ToInt32(row.Cells("id_pemesanan").Value)
            _kodeBookingTerpilih = Convert.ToString(row.Cells("Kode Booking").Value)
            _namaPemesanTerpilih = Convert.ToString(row.Cells("Nama Pemesan").Value)
            _noTeleponTerpilih = Convert.ToString(row.Cells("No. Telepon").Value)
            _totalSewa = Convert.ToDecimal(row.Cells("Total Sewa").Value)
            _totalTerbayar = Convert.ToDecimal(row.Cells("Total Bayar").Value)
            _sisaTagihan = Convert.ToDecimal(row.Cells("Sisa").Value)
            _statusTerpilih = Convert.ToString(row.Cells("Status").Value)

            ' Ambil rincian slot jadwal dari database
            MuatDetailSlotJadwal(_idPemesananTerpilih)

            ' Tampilkan informasi detail pada Card Info Kiri
            lblValKodeBooking.Text = "Kode Booking: " & _kodeBookingTerpilih
            lblValPemesan.Text = String.Format("Pemesan: {0} ({1})", _namaPemesanTerpilih, _noTeleponTerpilih)
            lblValJadwal.Text = "Jadwal: " & _detailJadwalString
            lblValTotalSewa.Text = String.Format("Total Sewa: Rp {0:N0}", _totalSewa)
            lblValSisaTagihan.Text = String.Format("Sisa Tagihan: Rp {0:N0}", _sisaTagihan)

            ' Atur Badge Status
            Select Case _statusTerpilih
                Case "Menunggu DP"
                    ModUIHelper.TerapkanBadgePill(lblStatusPemesanan, ModUIHelper.ColorCoral, ModUIHelper.ColorCrispSlate)
                    lblStatusPemesanan.Text = "Status: Menunggu DP"
                Case "DP Terbayar"
                    ModUIHelper.TerapkanBadgePill(lblStatusPemesanan, ModUIHelper.ColorSkyBlue, ModUIHelper.ColorCrispSlate)
                    lblStatusPemesanan.Text = "Status: DP Terbayar"
                Case "Lunas"
                    ModUIHelper.TerapkanBadgePill(lblStatusPemesanan, ModUIHelper.ColorMintGreen, Color.White)
                    lblStatusPemesanan.Text = "Status: Lunas"
            End Select

            ' Sesuaikan pilihan Jenis Pembayaran
            cmbJenisPembayaran.Items.Clear()
            If _statusTerpilih = "Menunggu DP" Then
                cmbJenisPembayaran.Items.Add("Uang Muka (DP)")
                cmbJenisPembayaran.Items.Add("Langsung Lunas (100%)")
                cmbJenisPembayaran.SelectedIndex = 0
                btnProsesBayar.Enabled = True
            ElseIf _statusTerpilih = "DP Terbayar" Then
                cmbJenisPembayaran.Items.Add("Pelunasan Sisa Tagihan")
                cmbJenisPembayaran.SelectedIndex = 0
                btnProsesBayar.Enabled = True
            Else
                ' Lunas
                cmbJenisPembayaran.Items.Add("Sudah Lunas")
                cmbJenisPembayaran.SelectedIndex = 0
                btnProsesBayar.Enabled = False
            End If

            btnCetakUlang.Enabled = True
            HitungTagihanKasir()
        End Sub

        Private Sub MuatDetailSlotJadwal(idPemesanan As Integer)
            _detailJadwalString = String.Empty
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT l.nama_lapangan, dp.tanggal_main, GROUP_CONCAT(CONCAT(LPAD(dp.jam_mulai,2,'0'), '.00') ORDER BY dp.jam_mulai SEPARATOR ', ') AS jam_list " &
                                          "FROM detail_pemesanan dp " &
                                          "JOIN lapangan l ON dp.id_lapangan = l.id_lapangan " &
                                          "WHERE dp.id_pemesanan = @id_pemesanan " &
                                          "GROUP BY l.nama_lapangan, dp.tanggal_main;"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id_pemesanan", idPemesanan)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim tgl As Date = reader.GetDateTime("tanggal_main")
                                Dim lap As String = reader.GetString("nama_lapangan")
                                Dim jam As String = reader.GetString("jam_list")
                                _detailJadwalString = String.Format("{0:dd/MM/yyyy} • {1} • Jam: {2}", tgl, lap, jam)
                            End If
                        End Using
                    End Using
                End Using
            Catch
                _detailJadwalString = "(Detail slot tidak tersedia)"
            End Try
        End Sub

        Private Sub cmbJenisPembayaran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisPembayaran.SelectedIndexChanged
            HitungTagihanKasir()
        End Sub

        ''' <summary>
        ''' Menghitung besaran nominal tagihan yang harus dibayar pada sesi transaksi kasir saat ini.
        ''' </summary>
        Private Sub HitungTagihanKasir()
            If _idPemesananTerpilih = 0 Then
                _tagihanYangHarusDibayar = 0D
                txtJumlahTagihan.Text = "Rp 0"
                Return
            End If

            Dim jenis As String = If(cmbJenisPembayaran.SelectedItem IsNot Nothing, cmbJenisPembayaran.SelectedItem.ToString(), "")

            If jenis = "Uang Muka (DP)" Then
                ' DP 30% dari total sewa
                _tagihanYangHarusDibayar = Math.Ceiling(_totalSewa * 0.3D)
            ElseIf jenis = "Langsung Lunas (100%)" Then
                _tagihanYangHarusDibayar = _totalSewa
            ElseIf jenis = "Pelunasan Sisa Tagihan" Then
                _tagihanYangHarusDibayar = _sisaTagihan
            Else
                _tagihanYangHarusDibayar = 0D
            End If

            txtJumlahTagihan.Text = String.Format("Rp {0:N0}", _tagihanYangHarusDibayar)
            txtJumlahBayar.Text = _tagihanYangHarusDibayar.ToString("F0")
            HitungKembalian()
        End Sub

        Private Sub txtJumlahBayar_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahBayar.TextChanged
            HitungKembalian()
        End Sub

        Private Sub HitungKembalian()
            Dim jumlahBayar As Decimal = 0D
            Decimal.TryParse(txtJumlahBayar.Text.Trim(), jumlahBayar)

            Dim kembalian As Decimal = jumlahBayar - _tagihanYangHarusDibayar
            If kembalian < 0 Then kembalian = 0D

            lblValKembalian.Text = String.Format("Rp {0:N0}", kembalian)
        End Sub

        ' =====================================================================
        ' QUICK AMOUNT BUTTONS
        ' =====================================================================
        Private Sub btnUangPas_Click(sender As Object, e As EventArgs) Handles btnUangPas.Click
            txtJumlahBayar.Text = _tagihanYangHarusDibayar.ToString("F0")
        End Sub

        Private Sub btn50k_Click(sender As Object, e As EventArgs) Handles btn50k.Click
            txtJumlahBayar.Text = "50000"
        End Sub

        Private Sub btn100k_Click(sender As Object, e As EventArgs) Handles btn100k.Click
            txtJumlahBayar.Text = "100000"
        End Sub

        Private Sub btn200k_Click(sender As Object, e As EventArgs) Handles btn200k.Click
            txtJumlahBayar.Text = "200000"
        End Sub

        Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
            _idPemesananTerpilih = 0
            lblValKodeBooking.Text = "Kode Booking: -"
            lblValPemesan.Text = "Pemesan: -"
            lblValJadwal.Text = "Jadwal: -"
            lblValTotalSewa.Text = "Total Sewa: Rp 0"
            lblValSisaTagihan.Text = "Sisa Tagihan: Rp 0"
            lblStatusPemesanan.Text = "Status: -"
            lblStatusPemesanan.BackColor = ModUIHelper.ColorWarmCream
            txtJumlahTagihan.Text = "Rp 0"
            txtJumlahBayar.Clear()
            lblValKembalian.Text = "Rp 0"
            btnProsesBayar.Enabled = False
            btnCetakUlang.Enabled = False
            PerbaruiNoTransaksi()
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' Memproses pembayaran kasir secara atomik dengan MySQL Transaction.
        ''' </summary>
        Private Sub btnProsesBayar_Click(sender As Object, e As EventArgs) Handles btnProsesBayar.Click
            If _idPemesananTerpilih = 0 Then
                ModErrorHandler.TampilkanPeringatan("Silakan pilih tagihan pemesanan terlebih dahulu dari tabel di sebelah kiri.", "Peringatan")
                Return
            End If

            If _tagihanYangHarusDibayar <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Tagihan ini sudah lunas atau tidak membutuhkan pembayaran.", "Peringatan")
                Return
            End If

            Dim jumlahBayarInput As Decimal = 0D
            If Not Decimal.TryParse(txtJumlahBayar.Text.Trim(), jumlahBayarInput) OrElse jumlahBayarInput < _tagihanYangHarusDibayar Then
                ModErrorHandler.TampilkanPeringatan(
                    String.Format("Jumlah pembayaran yang diterima (Rp {0:N0}) kurang dari tagihan wajib (Rp {1:N0}).", jumlahBayarInput, _tagihanYangHarusDibayar),
                    "Uang Kurang"
                )
                txtJumlahBayar.Focus()
                Return
            End If

            Dim jenisPilihan As String = If(cmbJenisPembayaran.SelectedItem IsNot Nothing, cmbJenisPembayaran.SelectedItem.ToString(), "")
            Dim metodeBayar As String = If(cmbMetodePembayaran.SelectedItem IsNot Nothing, cmbMetodePembayaran.SelectedItem.ToString(), "Tunai")
            Dim idUser As Integer = If(ModSesi.IdUser > 0, ModSesi.IdUser, 1)

            Dim dbJenisPembayaran As String = ""
            Dim statusPemesananBaru As String = ""

            If jenisPilihan = "Uang Muka (DP)" Then
                dbJenisPembayaran = "DP"
                statusPemesananBaru = "DP Terbayar"
            ElseIf jenisPilihan = "Langsung Lunas (100%)" OrElse jenisPilihan = "Pelunasan Sisa Tagihan" Then
                dbJenisPembayaran = "Pelunasan"
                statusPemesananBaru = "Lunas"
            Else
                ModErrorHandler.TampilkanPeringatan("Jenis pembayaran tidak valid.", "Peringatan")
                Return
            End If

            Dim kembalian As Decimal = jumlahBayarInput - _tagihanYangHarusDibayar

            ' Konfirmasi Kasir
            Dim promptKonfirmasi As String = String.Format(
                "Konfirmasi Pembayaran Kasir:{0}" &
                "• Kode Booking: {1}{0}" &
                "• Pemesan: {2}{0}" &
                "• Jenis: {3}{0}" &
                "• Metode: {4}{0}" &
                "• Tagihan: Rp {5:N0}{0}" &
                "• Diterima: Rp {6:N0}{0}" &
                "• Kembalian: Rp {7:N0}{0}{0}" &
                "Proses pembayaran dan terbitkan nota?",
                Environment.NewLine, _kodeBookingTerpilih, _namaPemesanTerpilih,
                jenisPilihan, metodeBayar, _tagihanYangHarusDibayar, jumlahBayarInput, kembalian
            )

            If Not ModErrorHandler.Konfirmasi(promptKonfirmasi, "Proses Kasir Pembayaran") Then
                Return
            End If

            ' Eksekusi Transaksi Database Atomik
            Dim noTransaksiFinal As String = String.Empty
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Using trans As MySqlTransaction = conn.BeginTransaction()
                        Try
                            noTransaksiFinal = ModAutoNumber.BuatKodeOtomatis("PAY", DateTime.Today)

                            ' 1. INSERT ke pembayaran
                            Const sqlPay As String = "INSERT INTO pembayaran " &
                                                     "(no_transaksi, id_pemesanan, id_user, jenis_pembayaran, jumlah_bayar, metode_pembayaran, waktu_bayar) " &
                                                     "VALUES (@no_transaksi, @id_pemesanan, @id_user, @jenis, @jumlah_bayar, @metode, NOW());"

                            Using cmdPay As New MySqlCommand(sqlPay, conn, trans)
                                cmdPay.Parameters.AddWithValue("@no_transaksi", noTransaksiFinal)
                                cmdPay.Parameters.AddWithValue("@id_pemesanan", _idPemesananTerpilih)
                                cmdPay.Parameters.AddWithValue("@id_user", idUser)
                                cmdPay.Parameters.AddWithValue("@jenis", dbJenisPembayaran)
                                cmdPay.Parameters.AddWithValue("@jumlah_bayar", _tagihanYangHarusDibayar)
                                cmdPay.Parameters.AddWithValue("@metode", metodeBayar)
                                cmdPay.ExecuteNonQuery()
                            End Using

                            ' 2. UPDATE status pemesanan
                            Const sqlUpd As String = "UPDATE pemesanan SET status_pemesanan = @status WHERE id_pemesanan = @id_pemesanan;"
                            Using cmdUpd As New MySqlCommand(sqlUpd, conn, trans)
                                cmdUpd.Parameters.AddWithValue("@status", statusPemesananBaru)
                                cmdUpd.Parameters.AddWithValue("@id_pemesanan", _idPemesananTerpilih)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            trans.Commit()

                        Catch exTrans As Exception
                            trans.Rollback()
                            Throw New InvalidOperationException("Gagal mencatat pembayaran: " & exTrans.Message, exTrans)
                        End Try
                    End Using
                End Using

                ' Buat format teks nota resmi
                _lastNotaString = FormatTeksNota(
                    noTransaksiFinal, _kodeBookingTerpilih, _namaPemesanTerpilih,
                    _noTeleponTerpilih, _detailJadwalString, _totalSewa,
                    dbJenisPembayaran, metodeBayar, _tagihanYangHarusDibayar,
                    jumlahBayarInput, kembalian, statusPemesananBaru
                )

                ' Tampilkan Pratinjau Struk Nota
                Dim preview As New frmNotaPreview(_lastNotaString)
                preview.ShowDialog(Me)

                ' Refresh daftar pemesanan di grid
                MuatDaftarPemesanan()
                PerbaruiNoTransaksi()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memproses pembayaran kasir", ex)
            End Try
        End Sub

        Private Sub btnCetakUlang_Click(sender As Object, e As EventArgs) Handles btnCetakUlang.Click
            If String.IsNullOrWhiteSpace(_lastNotaString) Then
                ' Jika belum ada riwayat sesi cetak terakhir, bangun nota dari data baris yang dipilih
                If _idPemesananTerpilih > 0 Then
                    _lastNotaString = FormatTeksNota(
                        "PAY-" & DateTime.Today.ToString("yyyyMMdd") & "-REPRINT",
                        _kodeBookingTerpilih, _namaPemesanTerpilih, _noTeleponTerpilih,
                        _detailJadwalString, _totalSewa, "Status Terakhir",
                        "Semua", _totalTerbayar, _totalTerbayar, 0D, _statusTerpilih
                    )
                Else
                    ModErrorHandler.TampilkanPeringatan("Belum ada data nota yang dapat dicetak ulang.", "Peringatan")
                    Return
                End If
            End If

            Dim preview As New frmNotaPreview(_lastNotaString)
            preview.ShowDialog(Me)
        End Sub

        ''' <summary>
        ''' Membangun string teks nota terstruktur berformat layout slip termal kasir (80 mm).
        ''' </summary>
        Private Function FormatTeksNota(noTrx As String, kodeBkg As String, nama As String,
                                        telp As String, jadwal As String, totalSewa As Decimal,
                                        jenisBayar As String, metode As String, dibayar As Decimal,
                                        diterima As Decimal, kembali As Decimal, statusAkhir As String) As String
            Dim sb As New StringBuilder()
            Dim garis As String = "========================================"
            Dim strip As String = "----------------------------------------"

            sb.AppendLine("              ARUNG FUTSAL              ")
            sb.AppendLine("   Sistem Informasi Pemesanan Lapangan   ")
            sb.AppendLine("    Jl. Raya Arung Futsal No. 12 Surabaya ")
            sb.AppendLine("          WhatsApp: 0812-3456-7890      ")
            sb.AppendLine(garis)
            sb.AppendLine(String.Format("No. Transaksi : {0}", noTrx))
            sb.AppendLine(String.Format("Kode Booking  : {0}", kodeBkg))
            sb.AppendLine(String.Format("Tanggal Cetak : {0:dd/MM/yyyy HH:mm:ss} WIB", DateTime.Now))
            sb.AppendLine(String.Format("Kasir/Admin   : {0}", If(String.IsNullOrEmpty(ModSesi.NamaLengkap), "Staf Operasional", ModSesi.NamaLengkap)))
            sb.AppendLine(strip)
            sb.AppendLine(String.Format("Nama Pemesan  : {0}", nama))
            sb.AppendLine(String.Format("No. Telepon   : {0}", telp))
            sb.AppendLine(String.Format("Rincian Sewa  : {0}", jadwal))
            sb.AppendLine(strip)
            sb.AppendLine(String.Format("Total Sewa Lapangan : Rp {0,12:N0}", totalSewa))
            sb.AppendLine(String.Format("Jenis Pembayaran    : {0}", jenisBayar))
            sb.AppendLine(String.Format("Metode Pembayaran   : {0}", metode))
            sb.AppendLine(String.Format("Nominal Bayar       : Rp {0,12:N0}", dibayar))
            sb.AppendLine(String.Format("Uang Diterima       : Rp {0,12:N0}", diterima))
            sb.AppendLine(String.Format("Uang Kembalian      : Rp {0,12:N0}", kembali))
            sb.AppendLine(garis)
            sb.AppendLine(String.Format("STATUS AKHIR SEWA   : [ {0} ]", statusAkhir.ToUpperInvariant()))
            sb.AppendLine(garis)
            sb.AppendLine("  * Harap hadir 15 menit sebelum kickoff")
            sb.AppendLine("  * Bukti sewa ini sah dikeluarkan kasir")
            sb.AppendLine("     Terima kasih atas kunjungan Anda!  ")

            Return sb.ToString()
        End Function

    End Class

End Namespace

