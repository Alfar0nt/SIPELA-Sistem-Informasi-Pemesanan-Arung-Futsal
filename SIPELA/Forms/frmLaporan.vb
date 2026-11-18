Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports SIPELA.Modules

Namespace Forms

    Partial Public Class frmLaporan
        Inherits System.Windows.Forms.Form

        Private Enum ModeCetak
            LaporanTransaksi
            StrukBooking
            RingkasanBulanan
        End Enum

        Private _tabelLaporan As DataTable
        Private _tabelBulanan As DataTable
        Private _isInitializing As Boolean = True

        ' Ringkasan agregasi Tab 1 (tersimpan agar sinkron saat Export CSV & Cetak)
        Private _sumTotalBooking As Integer = 0
        Private _sumTotalSlot As Integer = 0
        Private _sumGrandTotalSewa As Decimal = 0D
        Private _sumTotalBayarMasuk As Decimal = 0D
        Private _sumSisaBelumLunas As Decimal = 0D

        ' Ringkasan agregasi Tab 2
        Private _sumBlnPendapatan As Decimal = 0D
        Private _sumBlnTransaksi As Integer = 0
        Private _sumBlnSlot As Integer = 0
        Private _sumBlnRataOkupansi As Decimal = 0D

        ' State pencetakan (PrintDocument)
        Private _modeCetakAktif As ModeCetak = ModeCetak.LaporanTransaksi
        Private _indeksBarisCetak As Integer = 0
        Private _nomorHalamanCetak As Integer = 1
        Private _headerStruk As DataRow = Nothing
        Private _detailStruk As DataTable = Nothing
        Private _pembayaranStruk As DataTable = Nothing

        Private Sub frmLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                ' Validasi hak akses: khusus Owner
                If Not ModSesi.IsLoggedIn OrElse Not ModSesi.IsOwner Then
                    ModErrorHandler.TampilkanPeringatan(
                        "Akses ditolak. Menu Laporan Pendapatan & Okupansi hanya dapat diakses oleh Owner.",
                        "Akses Terbatas"
                    )
                    Me.Close()
                    Return
                End If

                _isInitializing = True
                KonfigurasiTampilan()
                MuatFilterLapangan()
                MuatFilterTahun()
                SetFilterDefault()
                _isInitializing = False

                MuatLaporanTransaksi()
                MuatLaporanBulanan()
            Catch ex As Exception
                _isInitializing = False
                ModErrorHandler.TampilkanError("Gagal menyiapkan Form Laporan", ex)
            End Try
        End Sub

        Private Sub KonfigurasiTampilan()
            ' Styling tombol dengan icon 16x16 px sesuai standar proyek
            ModUIHelper.TerapkanStyleTombol(btnTampilkan, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnResetFilter, "clear.png")
            ModUIHelper.TerapkanStyleTombol(btnExportCsv, "insert.png")
            ModUIHelper.TerapkanStyleTombol(btnCetakLaporan, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnCetakStruk, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnTutup, "clear.png")
            ModUIHelper.TerapkanStyleTombol(btnRefreshBulanan, "clear.png")
            ModUIHelper.TerapkanStyleTombol(btnExportBulananCsv, "insert.png")
            ModUIHelper.TerapkanStyleTombol(btnCetakBulanan, "update.png")

            ' Konfigurasi DataGridView Tab 1 & Tab 2
            For Each grid As DataGridView In New DataGridView() {dgvLaporan, dgvBulanan}
                grid.ReadOnly = True
                grid.AllowUserToAddRows = False
                grid.AllowUserToDeleteRows = False
                grid.MultiSelect = False
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                grid.RowHeadersVisible = False
                grid.EnableHeadersVisualStyles = False
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250)
            Next
        End Sub

        Private Sub SetFilterDefault()
            cboJenisTanggal.SelectedIndex = 0 ' Tanggal Main
            Dim awalBulan As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            dtpDari.Value = awalBulan
            dtpSampai.Value = DateTime.Today.AddDays(30)
            If cboLapangan.Items.Count > 0 Then cboLapangan.SelectedIndex = 0
            cboStatus.SelectedIndex = 0 ' Semua Status
            txtCari.Clear()
        End Sub

        ''' <summary>
        ''' Memuat daftar lapangan dari database ke ComboBox filter dengan opsi "Semua Lapangan".
        ''' </summary>
        Private Sub MuatFilterLapangan()
            Dim tabel As New DataTable()
            tabel.Columns.Add("id_lapangan", GetType(Integer))
            tabel.Columns.Add("nama_lapangan", GetType(String))
            tabel.Rows.Add(0, "Semua Lapangan")

            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sql As String = "SELECT id_lapangan, nama_lapangan FROM lapangan ORDER BY nama_lapangan ASC"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            tabel.Rows.Add(SafeInt(reader("id_lapangan")), SafeString(reader("nama_lapangan")))
                        End While
                    End Using
                End Using
            End Using

            cboLapangan.DataSource = Nothing
            cboLapangan.DisplayMember = "nama_lapangan"
            cboLapangan.ValueMember = "id_lapangan"
            cboLapangan.DataSource = tabel
            cboLapangan.SelectedIndex = 0
        End Sub

        ''' <summary>
        ''' Memuat pilihan tahun untuk filter Ringkasan Bulanan & Okupansi.
        ''' </summary>
        Private Sub MuatFilterTahun()
            cboTahun.Items.Clear()
            cboTahun.Items.Add("Semua Tahun")

            Dim daftarTahun As New SortedSet(Of Integer)()
            daftarTahun.Add(DateTime.Today.Year)

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String =
                        "SELECT DISTINCT YEAR(waktu_dibuat) AS thn FROM pemesanan " &
                        "UNION " &
                        "SELECT DISTINCT YEAR(tanggal_main) AS thn FROM detail_pemesanan " &
                        "UNION " &
                        "SELECT DISTINCT YEAR(waktu_bayar) AS thn FROM pembayaran"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim thn As Integer = SafeInt(reader("thn"))
                                If thn > 0 Then daftarTahun.Add(thn)
                            End While
                        End Using
                    End Using
                End Using
            Catch
                ' Tetap gunakan tahun berjalan jika tabel kosong/error minor
            End Try

            Dim listTahun As New List(Of Integer)(daftarTahun)
            listTahun.Sort()
            listTahun.Reverse()
            For Each t As Integer In listTahun
                cboTahun.Items.Add(t.ToString())
            Next

            cboTahun.SelectedIndex = 0
        End Sub

        ' =========================================================================
        ' TAB 1: LAPORAN TRANSAKSI & PENDAPATAN (DATA RELASIONAL + AGREGASI)
        ' =========================================================================

        Private Sub MuatLaporanTransaksi()
            ' Validasi rentang tanggal
            If dtpDari.Value.Date > dtpSampai.Value.Date Then
                ModErrorHandler.TampilkanPeringatan(
                    "Tanggal awal ('Dari') tidak boleh lebih besar daripada tanggal akhir ('s.d.').",
                    "Validasi Rentang Tanggal"
                )
                dtpDari.Focus()
                Return
            End If

            Try
                Dim pakaiTanggalPesan As Boolean = (cboJenisTanggal.SelectedIndex = 1)
                Dim kolomTanggal As String = If(pakaiTanggalPesan, "DATE(p.waktu_dibuat)", "dp.tanggal_main")

                Dim idLapangan As Integer = 0
                If cboLapangan.SelectedValue IsNot Nothing Then
                    Integer.TryParse(cboLapangan.SelectedValue.ToString(), idLapangan)
                End If

                Dim statusDipilih As String = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), "Semua Status")
                Dim kataKunci As String = txtCari.Text.Trim()

                Dim sqlBuilder As New StringBuilder()
                sqlBuilder.AppendLine("SELECT")
                sqlBuilder.AppendLine("    p.id_pemesanan,")
                sqlBuilder.AppendLine("    p.kode_booking,")
                sqlBuilder.AppendLine("    dp.tanggal_main,")
                sqlBuilder.AppendLine("    CONCAT(LPAD(dp.jam_mulai, 2, '0'), ':00 - ', LPAD((dp.jam_mulai + 1) % 24, 2, '0'), ':00') AS jam_main,")
                sqlBuilder.AppendLine("    l.nama_lapangan,")
                sqlBuilder.AppendLine("    p.nama_pemesan,")
                sqlBuilder.AppendLine("    p.no_telepon,")
                sqlBuilder.AppendLine("    u.nama_lengkap AS kasir,")
                sqlBuilder.AppendLine("    dp.harga_slot,")
                sqlBuilder.AppendLine("    p.total_sewa,")
                sqlBuilder.AppendLine("    COALESCE(pb.total_dibayar, 0) AS total_dibayar,")
                sqlBuilder.AppendLine("    p.status_pemesanan,")
                sqlBuilder.AppendLine("    p.waktu_dibuat")
                sqlBuilder.AppendLine("FROM detail_pemesanan dp")
                sqlBuilder.AppendLine("INNER JOIN pemesanan p ON dp.id_pemesanan = p.id_pemesanan")
                sqlBuilder.AppendLine("INNER JOIN lapangan l ON dp.id_lapangan = l.id_lapangan")
                sqlBuilder.AppendLine("INNER JOIN users u ON p.id_user = u.id_user")
                sqlBuilder.AppendLine("LEFT JOIN (")
                sqlBuilder.AppendLine("    SELECT id_pemesanan, SUM(jumlah_bayar) AS total_dibayar")
                sqlBuilder.AppendLine("    FROM pembayaran")
                sqlBuilder.AppendLine("    GROUP BY id_pemesanan")
                sqlBuilder.AppendLine(") pb ON pb.id_pemesanan = p.id_pemesanan")
                sqlBuilder.AppendLine("WHERE " & kolomTanggal & " BETWEEN @tglDari AND @tglSampai")

                If idLapangan > 0 Then
                    sqlBuilder.AppendLine("  AND dp.id_lapangan = @idLapangan")
                End If

                If statusDipilih <> "Semua Status" Then
                    sqlBuilder.AppendLine("  AND p.status_pemesanan = @status")
                End If

                If Not String.IsNullOrWhiteSpace(kataKunci) Then
                    sqlBuilder.AppendLine("  AND (p.kode_booking LIKE @cari OR p.nama_pemesan LIKE @cari OR p.no_telepon LIKE @cari OR u.nama_lengkap LIKE @cari)")
                End If

                sqlBuilder.AppendLine("ORDER BY dp.tanggal_main DESC, dp.jam_mulai ASC, p.kode_booking DESC")

                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Using cmd As New MySqlCommand(sqlBuilder.ToString(), conn)
                        cmd.Parameters.AddWithValue("@tglDari", dtpDari.Value.Date)
                        cmd.Parameters.AddWithValue("@tglSampai", dtpSampai.Value.Date)

                        If idLapangan > 0 Then
                            cmd.Parameters.AddWithValue("@idLapangan", idLapangan)
                        End If

                        If statusDipilih <> "Semua Status" Then
                            cmd.Parameters.AddWithValue("@status", statusDipilih)
                        End If

                        If Not String.IsNullOrWhiteSpace(kataKunci) Then
                            cmd.Parameters.AddWithValue("@cari", "%" & kataKunci & "%")
                        End If

                        Using da As New MySqlDataAdapter(cmd)
                            _tabelLaporan = New DataTable()
                            da.Fill(_tabelLaporan)
                            dgvLaporan.DataSource = _tabelLaporan
                        End Using
                    End Using
                End Using

                AturKolomGridLaporan()
                HitungAgregasiTransaksi()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat data laporan transaksi", ex)
            End Try
        End Sub

        Private Sub AturKolomGridLaporan()
            If dgvLaporan.Columns.Contains("id_pemesanan") Then dgvLaporan.Columns("id_pemesanan").Visible = False
            If dgvLaporan.Columns.Contains("no_telepon") Then dgvLaporan.Columns("no_telepon").Visible = False
            If dgvLaporan.Columns.Contains("total_sewa") Then dgvLaporan.Columns("total_sewa").Visible = False

            If dgvLaporan.Columns.Contains("kode_booking") Then
                dgvLaporan.Columns("kode_booking").HeaderText = "Kode Booking"
                dgvLaporan.Columns("kode_booking").FillWeight = 16
            End If

            If dgvLaporan.Columns.Contains("tanggal_main") Then
                dgvLaporan.Columns("tanggal_main").HeaderText = "Tgl Main"
                dgvLaporan.Columns("tanggal_main").DefaultCellStyle.Format = "yyyy-MM-dd"
                dgvLaporan.Columns("tanggal_main").FillWeight = 11
            End If

            If dgvLaporan.Columns.Contains("jam_main") Then
                dgvLaporan.Columns("jam_main").HeaderText = "Jam Main"
                dgvLaporan.Columns("jam_main").FillWeight = 12
            End If

            If dgvLaporan.Columns.Contains("nama_lapangan") Then
                dgvLaporan.Columns("nama_lapangan").HeaderText = "Lapangan"
                dgvLaporan.Columns("nama_lapangan").FillWeight = 12
            End If

            If dgvLaporan.Columns.Contains("nama_pemesan") Then
                dgvLaporan.Columns("nama_pemesan").HeaderText = "Pemesan"
                dgvLaporan.Columns("nama_pemesan").FillWeight = 15
            End If

            If dgvLaporan.Columns.Contains("kasir") Then
                dgvLaporan.Columns("kasir").HeaderText = "Kasir"
                dgvLaporan.Columns("kasir").FillWeight = 13
            End If

            If dgvLaporan.Columns.Contains("harga_slot") Then
                dgvLaporan.Columns("harga_slot").HeaderText = "Tarif Slot (Rp)"
                dgvLaporan.Columns("harga_slot").DefaultCellStyle.Format = "N0"
                dgvLaporan.Columns("harga_slot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvLaporan.Columns("harga_slot").FillWeight = 12
            End If

            If dgvLaporan.Columns.Contains("total_dibayar") Then
                dgvLaporan.Columns("total_dibayar").HeaderText = "Dibayar (Rp)"
                dgvLaporan.Columns("total_dibayar").DefaultCellStyle.Format = "N0"
                dgvLaporan.Columns("total_dibayar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvLaporan.Columns("total_dibayar").FillWeight = 12
            End If

            If dgvLaporan.Columns.Contains("status_pemesanan") Then
                dgvLaporan.Columns("status_pemesanan").HeaderText = "Status"
                dgvLaporan.Columns("status_pemesanan").FillWeight = 12
            End If

            If dgvLaporan.Columns.Contains("waktu_dibuat") Then
                dgvLaporan.Columns("waktu_dibuat").HeaderText = "Waktu Pesan"
                dgvLaporan.Columns("waktu_dibuat").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                dgvLaporan.Columns("waktu_dibuat").FillWeight = 14
            End If
        End Sub

        ''' <summary>
        ''' Menghitung agregasi summary metrics secara aman (bebas double-counting & bebas DBNull crash).
        ''' </summary>
        Private Sub HitungAgregasiTransaksi()
            _sumTotalBooking = 0
            _sumTotalSlot = 0
            _sumGrandTotalSewa = 0D
            _sumTotalBayarMasuk = 0D
            _sumSisaBelumLunas = 0D

            If _tabelLaporan Is Nothing OrElse _tabelLaporan.Rows.Count = 0 Then
                lblTotalBooking.Text = "0"
                lblTotalSlot.Text = "0 Slot"
                lblGrandTotalSewa.Text = "Rp 0"
                lblTotalBayarMasuk.Text = "Rp 0"
                lblSisaBelumLunas.Text = "Rp 0"
                lblInfoBaris.Text = "Tidak ada data transaksi yang cocok dengan filter."

                btnExportCsv.Enabled = False
                btnCetakLaporan.Enabled = False
                btnCetakStruk.Enabled = False
                Return
            End If

            Dim statusDipilih As String = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), "Semua Status")
            Dim filterKhususKedaluwarsa As Boolean = String.Equals(statusDipilih, "Kedaluwarsa", StringComparison.OrdinalIgnoreCase)

            Dim idBookingUnik As New HashSet(Of Integer)()
            Dim idBookingBayarTerhitung As New HashSet(Of Integer)()

            For Each row As DataRow In _tabelLaporan.Rows
                Dim idPemesanan As Integer = SafeInt(row("id_pemesanan"))
                Dim status As String = SafeString(row("status_pemesanan"))
                Dim hargaSlot As Decimal = SafeDecimal(row("harga_slot"))
                Dim totalSewaBooking As Decimal = SafeDecimal(row("total_sewa"))
                Dim totalDibayarBooking As Decimal = SafeDecimal(row("total_dibayar"))

                idBookingUnik.Add(idPemesanan)
                _sumTotalSlot += 1

                ' Akumulasi nilai sewa per slot: abaikan yang Kedaluwarsa kecuali user memang memfilter Kedaluwarsa
                If filterKhususKedaluwarsa OrElse Not String.Equals(status, "Kedaluwarsa", StringComparison.OrdinalIgnoreCase) Then
                    _sumGrandTotalSewa += hargaSlot
                End If

                ' Pembayaran masuk & sisa piutang dihitung 1x per id_pemesanan agar tidak double-counting pada multi-slot
                If Not idBookingBayarTerhitung.Contains(idPemesanan) Then
                    idBookingBayarTerhitung.Add(idPemesanan)
                    _sumTotalBayarMasuk += totalDibayarBooking

                    If Not String.Equals(status, "Kedaluwarsa", StringComparison.OrdinalIgnoreCase) AndAlso
                       Not String.Equals(status, "Lunas", StringComparison.OrdinalIgnoreCase) Then
                        Dim sisa As Decimal = totalSewaBooking - totalDibayarBooking
                        If sisa > 0D Then
                            _sumSisaBelumLunas += sisa
                        End If
                    End If
                End If
            Next

            _sumTotalBooking = idBookingUnik.Count

            lblTotalBooking.Text = String.Format("{0:N0}", _sumTotalBooking)
            lblTotalSlot.Text = String.Format("{0:N0} Slot", _sumTotalSlot)
            lblGrandTotalSewa.Text = String.Format("Rp {0:N0}", _sumGrandTotalSewa)
            lblTotalBayarMasuk.Text = String.Format("Rp {0:N0}", _sumTotalBayarMasuk)
            lblSisaBelumLunas.Text = String.Format("Rp {0:N0}", _sumSisaBelumLunas)
            lblInfoBaris.Text = String.Format("Menampilkan {0:N0} baris slot dari {1:N0} transaksi booking.", _sumTotalSlot, _sumTotalBooking)

            btnExportCsv.Enabled = True
            btnCetakLaporan.Enabled = True
            btnCetakStruk.Enabled = True
        End Sub

        ' =========================================================================
        ' TAB 2: RINGKASAN BULANAN & OKUPANSI (VIEW v_laporan_bulanan + FALLBACK)
        ' =========================================================================

        Private Sub MuatLaporanBulanan()
            Try
                Dim tahunFilter As String = ""
                If cboTahun.SelectedItem IsNot Nothing AndAlso cboTahun.SelectedItem.ToString() <> "Semua Tahun" Then
                    tahunFilter = cboTahun.SelectedItem.ToString()
                End If

                _tabelBulanan = New DataTable()

                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Try
                        Const sqlView As String =
                            "SELECT periode, total_pendapatan, total_transaksi, slot_terisi, kapasitas_slot, persen_okupansi " &
                            "FROM v_laporan_bulanan " &
                            "WHERE (@tahun = '' OR LEFT(periode, 4) = @tahun) " &
                            "ORDER BY periode DESC"

                        Using cmd As New MySqlCommand(sqlView, conn)
                            cmd.Parameters.AddWithValue("@tahun", tahunFilter)
                            Using da As New MySqlDataAdapter(cmd)
                                da.Fill(_tabelBulanan)
                            End Using
                        End Using
                    Catch
                        ' Fallback query langsung (100% kompatibel MySQL 8 ONLY_FULL_GROUP_BY)
                        _tabelBulanan = New DataTable()
                        Const sqlFallback As String =
                            "SELECT " &
                            "  p.periode, " &
                            "  p.total_pendapatan, " &
                            "  p.total_transaksi, " &
                            "  COALESCE(o.slot_terisi, 0) AS slot_terisi, " &
                            "  COALESCE(o.kapasitas_slot, 0) AS kapasitas_slot, " &
                            "  COALESCE(o.persen_okupansi, 0) AS persen_okupansi " &
                            "FROM ( " &
                            "  SELECT " &
                            "    DATE_FORMAT(pb.waktu_bayar, '%Y-%m') AS periode, " &
                            "    COALESCE(SUM(pb.jumlah_bayar), 0) AS total_pendapatan, " &
                            "    COUNT(DISTINCT pb.id_pembayaran) AS total_transaksi " &
                            "  FROM pembayaran pb " &
                            "  GROUP BY DATE_FORMAT(pb.waktu_bayar, '%Y-%m') " &
                            ") p " &
                            "LEFT JOIN ( " &
                            "  SELECT " &
                            "    DATE_FORMAT(dp.tanggal_main, '%Y-%m') AS periode, " &
                            "    COUNT(dp.id_detail) AS slot_terisi, " &
                            "    ((SELECT COUNT(*) FROM lapangan WHERE is_active = TRUE) * 16 * DAY(LAST_DAY(MAX(dp.tanggal_main)))) AS kapasitas_slot, " &
                            "    ROUND((COUNT(dp.id_detail) / NULLIF(((SELECT COUNT(*) FROM lapangan WHERE is_active = TRUE) * 16 * DAY(LAST_DAY(MAX(dp.tanggal_main)))), 0)) * 100, 2) AS persen_okupansi " &
                            "  FROM detail_pemesanan dp " &
                            "  WHERE dp.aktif = TRUE " &
                            "  GROUP BY DATE_FORMAT(dp.tanggal_main, '%Y-%m') " &
                            ") o ON p.periode = o.periode " &
                            "WHERE (@tahun = '' OR LEFT(p.periode, 4) = @tahun) " &
                            "ORDER BY p.periode DESC"

                        Using cmd As New MySqlCommand(sqlFallback, conn)
                            cmd.Parameters.AddWithValue("@tahun", tahunFilter)
                            Using da As New MySqlDataAdapter(cmd)
                                da.Fill(_tabelBulanan)
                            End Using
                        End Using
                    End Try
                End Using

                dgvBulanan.DataSource = _tabelBulanan
                AturKolomGridBulanan()
                HitungAgregasiBulanan()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat ringkasan laporan bulanan & okupansi", ex)
            End Try
        End Sub

        Private Sub AturKolomGridBulanan()
            If dgvBulanan.Columns.Contains("periode") Then
                dgvBulanan.Columns("periode").HeaderText = "Periode (YYYY-MM)"
                dgvBulanan.Columns("periode").FillWeight = 16
            End If

            If dgvBulanan.Columns.Contains("total_pendapatan") Then
                dgvBulanan.Columns("total_pendapatan").HeaderText = "Total Pendapatan (Rp)"
                dgvBulanan.Columns("total_pendapatan").DefaultCellStyle.Format = "N0"
                dgvBulanan.Columns("total_pendapatan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvBulanan.Columns("total_pendapatan").FillWeight = 22
            End If

            If dgvBulanan.Columns.Contains("total_transaksi") Then
                dgvBulanan.Columns("total_transaksi").HeaderText = "Jumlah Transaksi Bayar"
                dgvBulanan.Columns("total_transaksi").DefaultCellStyle.Format = "N0"
                dgvBulanan.Columns("total_transaksi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvBulanan.Columns("total_transaksi").FillWeight = 16
            End If

            If dgvBulanan.Columns.Contains("slot_terisi") Then
                dgvBulanan.Columns("slot_terisi").HeaderText = "Slot Terisi (Jam)"
                dgvBulanan.Columns("slot_terisi").DefaultCellStyle.Format = "N0"
                dgvBulanan.Columns("slot_terisi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvBulanan.Columns("slot_terisi").FillWeight = 16
            End If

            If dgvBulanan.Columns.Contains("kapasitas_slot") Then
                dgvBulanan.Columns("kapasitas_slot").HeaderText = "Kapasitas Slot"
                dgvBulanan.Columns("kapasitas_slot").DefaultCellStyle.Format = "N0"
                dgvBulanan.Columns("kapasitas_slot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvBulanan.Columns("kapasitas_slot").FillWeight = 15
            End If

            If dgvBulanan.Columns.Contains("persen_okupansi") Then
                dgvBulanan.Columns("persen_okupansi").HeaderText = "Okupansi (%)"
                dgvBulanan.Columns("persen_okupansi").DefaultCellStyle.Format = "N2"
                dgvBulanan.Columns("persen_okupansi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvBulanan.Columns("persen_okupansi").FillWeight = 15
            End If
        End Sub

        Private Sub HitungAgregasiBulanan()
            _sumBlnPendapatan = 0D
            _sumBlnTransaksi = 0
            _sumBlnSlot = 0
            _sumBlnRataOkupansi = 0D

            If _tabelBulanan Is Nothing OrElse _tabelBulanan.Rows.Count = 0 Then
                lblBlnTotalPendapatan.Text = "Rp 0"
                lblBlnTotalTransaksi.Text = "0"
                lblBlnTotalSlot.Text = "0 Slot"
                lblBlnRataOkupansi.Text = "0,00 %"
                lblInfoBulanan.Text = "Belum ada data pembayaran bulanan untuk periode yang dipilih."

                btnExportBulananCsv.Enabled = False
                btnCetakBulanan.Enabled = False
                Return
            End If

            Dim totalPersen As Decimal = 0D
            For Each row As DataRow In _tabelBulanan.Rows
                _sumBlnPendapatan += SafeDecimal(row("total_pendapatan"))
                _sumBlnTransaksi += SafeInt(row("total_transaksi"))
                _sumBlnSlot += SafeInt(row("slot_terisi"))
                totalPersen += SafeDecimal(row("persen_okupansi"))
            Next

            _sumBlnRataOkupansi = totalPersen / _tabelBulanan.Rows.Count

            lblBlnTotalPendapatan.Text = String.Format("Rp {0:N0}", _sumBlnPendapatan)
            lblBlnTotalTransaksi.Text = String.Format("{0:N0}", _sumBlnTransaksi)
            lblBlnTotalSlot.Text = String.Format("{0:N0} Slot", _sumBlnSlot)
            lblBlnRataOkupansi.Text = String.Format("{0:N2} %", _sumBlnRataOkupansi)
            lblInfoBulanan.Text = String.Format("Menampilkan {0:N0} periode bulanan.", _tabelBulanan.Rows.Count)

            btnExportBulananCsv.Enabled = True
            btnCetakBulanan.Enabled = True
        End Sub

        ' =========================================================================
        ' EVENT HANDLER FILTER & NAVIGASI
        ' =========================================================================

        Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
            MuatLaporanTransaksi()
        End Sub

        Private Sub btnResetFilter_Click(sender As Object, e As EventArgs) Handles btnResetFilter.Click
            _isInitializing = True
            SetFilterDefault()
            _isInitializing = False
            MuatLaporanTransaksi()
        End Sub

        Private Sub txtCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                MuatLaporanTransaksi()
            End If
        End Sub

        Private Sub cboTahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTahun.SelectedIndexChanged
            If Not _isInitializing Then
                MuatLaporanBulanan()
            End If
        End Sub

        Private Sub btnRefreshBulanan_Click(sender As Object, e As EventArgs) Handles btnRefreshBulanan.Click
            MuatLaporanBulanan()
        End Sub

        Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
            Me.Close()
        End Sub

        ' =========================================================================
        ' FITUR EXPORT CSV (EXCEL-READY UTF-8 BOM)
        ' =========================================================================

        Private Sub btnExportCsv_Click(sender As Object, e As EventArgs) Handles btnExportCsv.Click
            If _tabelLaporan Is Nothing OrElse _tabelLaporan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data laporan transaksi untuk diekspor.", "Export CSV")
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Title = "Simpan Laporan Transaksi & Pendapatan (CSV / Excel)"
                sfd.Filter = "CSV File (*.csv)|*.csv"
                sfd.FileName = String.Format("Laporan_Transaksi_SIPELA_{0:yyyyMMdd_HHmm}.csv", DateTime.Now)

                If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

                Try
                    Dim sb As New StringBuilder()

                    ' Header metadata laporan
                    sb.AppendLine("LAPORAN TRANSAKSI & PENDAPATAN - ARUNG FUTSAL (SIPELA)")
                    sb.AppendLine(String.Format("Periode ({0}),{1:yyyy-MM-dd} s.d. {2:yyyy-MM-dd}", cboJenisTanggal.Text, dtpDari.Value.Date, dtpSampai.Value.Date))
                    sb.AppendLine(String.Format("Lapangan,{0}", EscapeCsv(cboLapangan.Text)))
                    sb.AppendLine(String.Format("Status,{0}", EscapeCsv(cboStatus.Text)))
                    sb.AppendLine(String.Format("Dicetak Oleh,{0} ({1:yyyy-MM-dd HH:mm})", EscapeCsv(ModSesi.NamaLengkap), DateTime.Now))
                    sb.AppendLine()

                    ' Header kolom
                    sb.AppendLine("Kode Booking,Tanggal Main,Jam Main,Lapangan,Nama Pemesan,No Telepon,Kasir,Tarif Slot (Rp),Total Dibayar Booking (Rp),Status,Waktu Pesan")

                    ' Baris data
                    For Each row As DataRow In _tabelLaporan.Rows
                        Dim tglMain As String = SafeDate(row("tanggal_main")).ToString("yyyy-MM-dd")
                        Dim waktuPesan As String = SafeDate(row("waktu_dibuat")).ToString("yyyy-MM-dd HH:mm")
                        sb.AppendLine(String.Join(",", New String() {
                            EscapeCsv(SafeString(row("kode_booking"))),
                            EscapeCsv(tglMain),
                            EscapeCsv(SafeString(row("jam_main"))),
                            EscapeCsv(SafeString(row("nama_lapangan"))),
                            EscapeCsv(SafeString(row("nama_pemesan"))),
                            EscapeCsv(SafeString(row("no_telepon"))),
                            EscapeCsv(SafeString(row("kasir"))),
                            SafeDecimal(row("harga_slot")).ToString("F0"),
                            SafeDecimal(row("total_dibayar")).ToString("F0"),
                            EscapeCsv(SafeString(row("status_pemesanan"))),
                            EscapeCsv(waktuPesan)
                        }))
                    Next

                    ' Ringkasan agregasi
                    sb.AppendLine()
                    sb.AppendLine("RINGKASAN AGREGASI")
                    sb.AppendLine(String.Format("Total Transaksi Booking,{0}", _sumTotalBooking))
                    sb.AppendLine(String.Format("Total Slot Terjual (Jam),{0}", _sumTotalSlot))
                    sb.AppendLine(String.Format("Grand Total Nilai Sewa (Rp),{0:F0}", _sumGrandTotalSewa))
                    sb.AppendLine(String.Format("Total Pembayaran Masuk (Rp),{0:F0}", _sumTotalBayarMasuk))
                    sb.AppendLine(String.Format("Sisa Belum Lunas (Rp),{0:F0}", _sumSisaBelumLunas))

                    File.WriteAllText(sfd.FileName, sb.ToString(), New UTF8Encoding(True))

                    ModErrorHandler.TampilkanInfo(
                        "Laporan berhasil diekspor ke file CSV:" & Environment.NewLine & sfd.FileName & Environment.NewLine &
                        "File dapat langsung dibuka menggunakan Microsoft Excel.",
                        "Export Berhasil"
                    )
                Catch ex As IOException
                    ModErrorHandler.TampilkanError("Gagal menulis file CSV. Pastikan file tidak sedang dibuka di aplikasi lain (seperti Excel).", ex)
                Catch ex As Exception
                    ModErrorHandler.TampilkanError("Gagal mengekspor laporan transaksi ke CSV", ex)
                End Try
            End Using
        End Sub

        Private Sub btnExportBulananCsv_Click(sender As Object, e As EventArgs) Handles btnExportBulananCsv.Click
            If _tabelBulanan Is Nothing OrElse _tabelBulanan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data ringkasan bulanan untuk diekspor.", "Export CSV")
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Title = "Simpan Laporan Ringkasan Bulanan & Okupansi (CSV / Excel)"
                sfd.Filter = "CSV File (*.csv)|*.csv"
                sfd.FileName = String.Format("Laporan_Bulanan_SIPELA_{0:yyyyMMdd_HHmm}.csv", DateTime.Now)

                If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

                Try
                    Dim sb As New StringBuilder()
                    sb.AppendLine("LAPORAN RINGKASAN PENDAPATAN BULANAN & OKUPANSI - ARUNG FUTSAL (SIPELA)")
                    sb.AppendLine(String.Format("Filter Tahun,{0}", EscapeCsv(cboTahun.Text)))
                    sb.AppendLine(String.Format("Dicetak Oleh,{0} ({1:yyyy-MM-dd HH:mm})", EscapeCsv(ModSesi.NamaLengkap), DateTime.Now))
                    sb.AppendLine()
                    sb.AppendLine("Periode,Total Pendapatan (Rp),Jumlah Transaksi Bayar,Slot Terisi (Jam),Kapasitas Slot,Okupansi (%)")

                    For Each row As DataRow In _tabelBulanan.Rows
                        sb.AppendLine(String.Join(",", New String() {
                            EscapeCsv(SafeString(row("periode"))),
                            SafeDecimal(row("total_pendapatan")).ToString("F0"),
                            SafeInt(row("total_transaksi")).ToString(),
                            SafeInt(row("slot_terisi")).ToString(),
                            SafeInt(row("kapasitas_slot")).ToString(),
                            SafeDecimal(row("persen_okupansi")).ToString("F2", Globalization.CultureInfo.InvariantCulture)
                        }))
                    Next

                    sb.AppendLine()
                    sb.AppendLine("RINGKASAN KESELURUHAN")
                    sb.AppendLine(String.Format("Total Pendapatan Terbayar (Rp),{0:F0}", _sumBlnPendapatan))
                    sb.AppendLine(String.Format("Total Transaksi Pembayaran,{0}", _sumBlnTransaksi))
                    sb.AppendLine(String.Format("Total Slot Terisi (Jam),{0}", _sumBlnSlot))
                    sb.AppendLine(String.Format("Rata-rata Okupansi (%),{0:F2}", _sumBlnRataOkupansi))

                    File.WriteAllText(sfd.FileName, sb.ToString(), New UTF8Encoding(True))

                    ModErrorHandler.TampilkanInfo(
                        "Ringkasan bulanan berhasil diekspor ke file CSV:" & Environment.NewLine & sfd.FileName,
                        "Export Berhasil"
                    )
                Catch ex As IOException
                    ModErrorHandler.TampilkanError("Gagal menulis file CSV. Pastikan file tidak sedang dibuka di aplikasi lain.", ex)
                Catch ex As Exception
                    ModErrorHandler.TampilkanError("Gagal mengekspor ringkasan bulanan ke CSV", ex)
                End Try
            End Using
        End Sub

        Private Shared Function EscapeCsv(nilai As String) As String
            If String.IsNullOrEmpty(nilai) Then Return ""
            If nilai.Contains(",") OrElse nilai.Contains("""") OrElse nilai.Contains(vbCr) OrElse nilai.Contains(vbLf) Then
                Return """" & nilai.Replace("""", """""") & """"
            End If
            Return nilai
        End Function

        ' =========================================================================
        ' FITUR PRINT PREVIEW & CETAK DOKUMEN / SAVE AS PDF (PrintDocument)
        ' =========================================================================

        Private Sub btnCetakLaporan_Click(sender As Object, e As EventArgs) Handles btnCetakLaporan.Click
            If _tabelLaporan Is Nothing OrElse _tabelLaporan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data laporan transaksi untuk dicetak.", "Cetak Laporan")
                Return
            End If

            TampilkanPreviewCetak(ModeCetak.LaporanTransaksi, landscape:=True, judulWindow:="Preview Cetak - Laporan Transaksi & Pendapatan SIPELA")
        End Sub

        Private Sub btnCetakStruk_Click(sender As Object, e As EventArgs) Handles btnCetakStruk.Click
            If dgvLaporan.CurrentRow Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Pilih salah satu baris transaksi di tabel terlebih dahulu untuk mencetak struk/invoice booking.", "Cetak Struk")
                Return
            End If

            Try
                Dim rowView As DataRowView = TryCast(dgvLaporan.CurrentRow.DataBoundItem, DataRowView)
                If rowView Is Nothing Then Return

                Dim idPemesanan As Integer = SafeInt(rowView("id_pemesanan"))
                Dim kodeBooking As String = SafeString(rowView("kode_booking"))

                MuatDataStrukBooking(idPemesanan)

                If _headerStruk Is Nothing Then
                    ModErrorHandler.TampilkanPeringatan("Data transaksi tidak ditemukan di database.", "Cetak Struk")
                    Return
                End If

                TampilkanPreviewCetak(ModeCetak.StrukBooking, landscape:=False, judulWindow:="Preview Struk / Invoice - " & kodeBooking)
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menyiapkan pratinjau struk booking", ex)
            End Try
        End Sub

        Private Sub btnCetakBulanan_Click(sender As Object, e As EventArgs) Handles btnCetakBulanan.Click
            If _tabelBulanan Is Nothing OrElse _tabelBulanan.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Tidak ada data ringkasan bulanan untuk dicetak.", "Cetak Ringkasan")
                Return
            End If

            TampilkanPreviewCetak(ModeCetak.RingkasanBulanan, landscape:=False, judulWindow:="Preview Cetak - Ringkasan Bulanan & Okupansi SIPELA")
        End Sub

        Private Sub MuatDataStrukBooking(idPemesanan As Integer)
            _headerStruk = Nothing
            _detailStruk = New DataTable()
            _pembayaranStruk = New DataTable()

            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sqlHeader As String =
                    "SELECT p.id_pemesanan, p.kode_booking, p.nama_pemesan, p.no_telepon, " &
                    "       p.waktu_dibuat, p.batas_bayar, p.total_sewa, p.jumlah_dp, " &
                    "       p.status_pemesanan, p.catatan, u.nama_lengkap AS kasir " &
                    "FROM pemesanan p " &
                    "INNER JOIN users u ON p.id_user = u.id_user " &
                    "WHERE p.id_pemesanan = @id"

                Dim dtHeader As New DataTable()
                Using cmd As New MySqlCommand(sqlHeader, conn)
                    cmd.Parameters.AddWithValue("@id", idPemesanan)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtHeader)
                    End Using
                End Using

                If dtHeader.Rows.Count > 0 Then
                    _headerStruk = dtHeader.Rows(0)
                End If

                Const sqlDetail As String =
                    "SELECT l.nama_lapangan, l.jenis_lantai, dp.tanggal_main, " &
                    "       CONCAT(LPAD(dp.jam_mulai, 2, '0'), ':00 - ', LPAD((dp.jam_mulai + 1) % 24, 2, '0'), ':00') AS jam_main, " &
                    "       dp.harga_slot, dp.aktif " &
                    "FROM detail_pemesanan dp " &
                    "INNER JOIN lapangan l ON dp.id_lapangan = l.id_lapangan " &
                    "WHERE dp.id_pemesanan = @id " &
                    "ORDER BY dp.tanggal_main ASC, dp.jam_mulai ASC"

                Using cmd As New MySqlCommand(sqlDetail, conn)
                    cmd.Parameters.AddWithValue("@id", idPemesanan)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(_detailStruk)
                    End Using
                End Using

                Const sqlBayar As String =
                    "SELECT no_transaksi, jenis_pembayaran, jumlah_bayar, metode_pembayaran, waktu_bayar " &
                    "FROM pembayaran " &
                    "WHERE id_pemesanan = @id " &
                    "ORDER BY waktu_bayar ASC"

                Using cmd As New MySqlCommand(sqlBayar, conn)
                    cmd.Parameters.AddWithValue("@id", idPemesanan)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(_pembayaranStruk)
                    End Using
                End Using
            End Using
        End Sub

        Private Sub TampilkanPreviewCetak(mode As ModeCetak, landscape As Boolean, judulWindow As String)
            Try
                _modeCetakAktif = mode
                _indeksBarisCetak = 0
                _nomorHalamanCetak = 1

                Using doc As New PrintDocument()
                    doc.DocumentName = judulWindow
                    doc.DefaultPageSettings.Landscape = landscape
                    doc.DefaultPageSettings.Margins = New Margins(45, 45, 45, 45)

                    AddHandler doc.BeginPrint, Sub(s, ev)
                                                   _indeksBarisCetak = 0
                                                   _nomorHalamanCetak = 1
                                               End Sub

                    AddHandler doc.PrintPage, AddressOf PrintDocument_PrintPage

                    Using preview As New PrintPreviewDialog()
                        preview.Document = doc
                        preview.Text = judulWindow
                        preview.WindowState = FormWindowState.Maximized
                        preview.ShowDialog(Me)
                    End Using
                End Using
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal membuka pratinjau cetak dokumen", ex)
            End Try
        End Sub

        Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
            Select Case _modeCetakAktif
                Case ModeCetak.LaporanTransaksi
                    CetakHalamanLaporanTransaksi(e)
                Case ModeCetak.StrukBooking
                    CetakHalamanStrukBooking(e)
                Case ModeCetak.RingkasanBulanan
                    CetakHalamanRingkasanBulanan(e)
            End Select
        End Sub

        Private Sub CetakHalamanLaporanTransaksi(e As PrintPageEventArgs)
            Dim g As Graphics = e.Graphics
            Dim left As Single = e.MarginBounds.Left
            Dim top As Single = e.MarginBounds.Top
            Dim width As Single = e.MarginBounds.Width
            Dim bottom As Single = e.MarginBounds.Bottom
            Dim y As Single = top

            Using fontJudul As New Font("Segoe UI", 14.0F, FontStyle.Bold),
                  fontSub As New Font("Segoe UI", 9.0F, FontStyle.Regular),
                  fontHeader As New Font("Segoe UI", 8.5F, FontStyle.Bold),
                  fontRow As New Font("Segoe UI", 8.5F, FontStyle.Regular),
                  fontBold As New Font("Segoe UI", 9.0F, FontStyle.Bold),
                  brushHeaderBg As New SolidBrush(Color.DarkSlateBlue),
                  brushAltBg As New SolidBrush(Color.FromArgb(245, 245, 250)),
                  brushSummaryBg As New SolidBrush(Color.FromArgb(240, 248, 255)),
                  penGaris As New Pen(Color.LightGray, 0.75F),
                  penTebal As New Pen(Color.DarkSlateBlue, 1.5F)

                ' Kop Laporan
                g.DrawString("ARUNG FUTSAL — LAPORAN TRANSAKSI & PENDAPATAN (SIPELA)", fontJudul, Brushes.DarkSlateBlue, left, y)
                y += 26.0F
                Dim infoFilter As String = String.Format(
                    "Periode ({0}): {1:dd/MM/yyyy} s.d. {2:dd/MM/yyyy}  |  Lapangan: {3}  |  Status: {4}",
                    cboJenisTanggal.Text, dtpDari.Value.Date, dtpSampai.Value.Date, cboLapangan.Text, cboStatus.Text
                )
                g.DrawString(infoFilter, fontSub, Brushes.DimGray, left, y)
                y += 18.0F
                g.DrawString(String.Format("Dicetak oleh: {0} pada {1:dd/MM/yyyy HH:mm}", ModSesi.NamaLengkap, DateTime.Now), fontSub, Brushes.DimGray, left, y)
                y += 20.0F
                g.DrawLine(penTebal, left, y, left + width, y)
                y += 10.0F

                ' Definisi kolom proporsional
                Dim colHeaders As String() = {"No", "Kode Booking", "Tgl Main", "Jam Main", "Lapangan", "Pemesan", "Kasir", "Tarif (Rp)", "Status"}
                Dim colRatios As Single() = {0.04F, 0.15F, 0.1F, 0.11F, 0.11F, 0.16F, 0.13F, 0.1F, 0.1F}
                Dim colWidths(colHeaders.Length - 1) As Single
                For i As Integer = 0 To colHeaders.Length - 1
                    colWidths(i) = width * colRatios(i)
                Next

                ' Header Tabel
                Dim rowHeight As Single = 24.0F
                g.FillRectangle(brushHeaderBg, left, y, width, rowHeight)
                Dim x As Single = left
                For i As Integer = 0 To colHeaders.Length - 1
                    Dim rect As New RectangleF(x + 4, y + 4, colWidths(i) - 8, rowHeight - 6)
                    Dim sf As New StringFormat() With {.Trimming = StringTrimming.EllipsisCharacter}
                    If i = 7 Then sf.Alignment = StringAlignment.Far
                    g.DrawString(colHeaders(i), fontHeader, Brushes.White, rect, sf)
                    x += colWidths(i)
                Next
                y += rowHeight

                ' Isi Baris Tabel (dengan paginasi otomatis)
                While _indeksBarisCetak < _tabelLaporan.Rows.Count
                    If y + rowHeight > bottom - 95.0F Then
                        CetakFooterHalaman(g, fontSub, left, width, bottom)
                        _nomorHalamanCetak += 1
                        e.HasMorePages = True
                        Return
                    End If

                    Dim row As DataRow = _tabelLaporan.Rows(_indeksBarisCetak)
                    If _indeksBarisCetak Mod 2 = 1 Then
                        g.FillRectangle(brushAltBg, left, y, width, rowHeight)
                    End If

                    Dim nilai As String() = {
                        (_indeksBarisCetak + 1).ToString(),
                        SafeString(row("kode_booking")),
                        SafeDate(row("tanggal_main")).ToString("dd/MM/yyyy"),
                        SafeString(row("jam_main")),
                        SafeString(row("nama_lapangan")),
                        SafeString(row("nama_pemesan")),
                        SafeString(row("kasir")),
                        SafeDecimal(row("harga_slot")).ToString("N0"),
                        SafeString(row("status_pemesanan"))
                    }

                    x = left
                    For i As Integer = 0 To nilai.Length - 1
                        Dim rect As New RectangleF(x + 4, y + 4, colWidths(i) - 8, rowHeight - 6)
                        Dim sf As New StringFormat() With {.Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap}
                        If i = 7 Then sf.Alignment = StringAlignment.Far
                        g.DrawString(nilai(i), fontRow, Brushes.Black, rect, sf)
                        x += colWidths(i)
                    Next

                    g.DrawLine(penGaris, left, y + rowHeight, left + width, y + rowHeight)
                    y += rowHeight
                    _indeksBarisCetak += 1
                End While

                ' Kotak Ringkasan Agregasi di akhir laporan
                y += 12.0F
                If y + 66.0F > bottom - 20.0F Then
                    CetakFooterHalaman(g, fontSub, left, width, bottom)
                    _nomorHalamanCetak += 1
                    e.HasMorePages = True
                    Return
                End If

                g.FillRectangle(brushSummaryBg, left, y, width, 62.0F)
                g.DrawRectangle(penTebal, left, y, width, 62.0F)

                g.DrawString("RINGKASAN AGREGASI LAPORAN:", fontBold, Brushes.DarkSlateBlue, left + 10, y + 8)
                Dim summaryLine1 As String = String.Format(
                    "Total Booking: {0:N0}   |   Total Slot Terjual: {1:N0} Jam   |   Grand Total Nilai Sewa: Rp {2:N0}",
                    _sumTotalBooking, _sumTotalSlot, _sumGrandTotalSewa
                )
                Dim summaryLine2 As String = String.Format(
                    "Total Pembayaran Masuk (DP + Pelunasan): Rp {0:N0}   |   Sisa Belum Lunas: Rp {1:N0}",
                    _sumTotalBayarMasuk, _sumSisaBelumLunas
                )
                g.DrawString(summaryLine1, fontRow, Brushes.Black, left + 10, y + 26)
                g.DrawString(summaryLine2, fontBold, Brushes.DarkGreen, left + 10, y + 43)

                CetakFooterHalaman(g, fontSub, left, width, bottom)
                e.HasMorePages = False
            End Using
        End Sub

        Private Sub CetakHalamanStrukBooking(e As PrintPageEventArgs)
            Dim g As Graphics = e.Graphics
            Dim left As Single = e.MarginBounds.Left
            Dim top As Single = e.MarginBounds.Top
            Dim width As Single = e.MarginBounds.Width
            Dim bottom As Single = e.MarginBounds.Bottom
            Dim y As Single = top

            Using fontJudul As New Font("Segoe UI", 16.0F, FontStyle.Bold),
                  fontSub As New Font("Segoe UI", 9.5F, FontStyle.Regular),
                  fontSection As New Font("Segoe UI", 10.0F, FontStyle.Bold),
                  fontRow As New Font("Segoe UI", 9.5F, FontStyle.Regular),
                  fontBold As New Font("Segoe UI", 10.0F, FontStyle.Bold),
                  brushHeaderBg As New SolidBrush(Color.DarkSlateBlue),
                  brushBoxBg As New SolidBrush(Color.FromArgb(245, 245, 250)),
                  penTebal As New Pen(Color.DarkSlateBlue, 1.5F),
                  penGaris As New Pen(Color.LightGray, 0.8F)

                ' Kop Invoice
                g.DrawString("ARUNG FUTSAL — BUKTI PEMESANAN LAPANGAN (INVOICE)", fontJudul, Brushes.DarkSlateBlue, left, y)
                y += 28.0F
                g.DrawString("SIPELA — Sistem Informasi Pemesanan Lapangan Futsal (Operasional 08.00 - 00.00)", fontSub, Brushes.DimGray, left, y)
                y += 22.0F
                g.DrawLine(penTebal, left, y, left + width, y)
                y += 14.0F

                ' Info Header Pemesanan
                Dim kodeBooking As String = SafeString(_headerStruk("kode_booking"))
                Dim namaPemesan As String = SafeString(_headerStruk("nama_pemesan"))
                Dim noTelp As String = SafeString(_headerStruk("no_telepon"))
                Dim kasir As String = SafeString(_headerStruk("kasir"))
                Dim status As String = SafeString(_headerStruk("status_pemesanan"))
                Dim waktuDibuat As String = SafeDate(_headerStruk("waktu_dibuat")).ToString("dd/MM/yyyy HH:mm")
                Dim catatan As String = SafeString(_headerStruk("catatan"))
                If String.IsNullOrWhiteSpace(catatan) Then catatan = "-"

                g.FillRectangle(brushBoxBg, left, y, width, 118.0F)
                g.DrawRectangle(penGaris, left, y, width, 118.0F)

                Dim col2X As Single = left + (width * 0.52F)
                g.DrawString("Kode Booking : " & kodeBooking, fontBold, Brushes.DarkSlateBlue, left + 12, y + 10)
                g.DrawString("Nama Pemesan : " & namaPemesan, fontRow, Brushes.Black, left + 12, y + 32)
                g.DrawString("No. Telepon  : " & noTelp, fontRow, Brushes.Black, left + 12, y + 54)
                g.DrawString("Catatan      : " & catatan, fontRow, Brushes.DimGray, left + 12, y + 76)

                g.DrawString("Status       : " & status, fontBold, Brushes.DarkGreen, col2X, y + 10)
                g.DrawString("Waktu Pesan  : " & waktuDibuat, fontRow, Brushes.Black, col2X, y + 32)
                g.DrawString("Petugas Kasir: " & kasir, fontRow, Brushes.Black, col2X, y + 54)
                g.DrawString("Dicetak      : " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontRow, Brushes.DimGray, col2X, y + 76)

                y += 136.0F

                ' Daftar Slot Lapangan
                g.DrawString("RINCIAN SLOT LAPANGAN DIPESAN", fontSection, Brushes.DarkSlateBlue, left, y)
                y += 22.0F

                Dim headers As String() = {"No", "Lapangan", "Jenis Lantai", "Tanggal Main", "Jam Main", "Tarif (Rp)"}
                Dim ratios As Single() = {0.07F, 0.2F, 0.21F, 0.17F, 0.19F, 0.16F}
                Dim widths(headers.Length - 1) As Single
                For i As Integer = 0 To headers.Length - 1
                    widths(i) = width * ratios(i)
                Next

                Dim rowH As Single = 26.0F
                g.FillRectangle(brushHeaderBg, left, y, width, rowH)
                Dim x As Single = left
                For i As Integer = 0 To headers.Length - 1
                    Dim rect As New RectangleF(x + 4, y + 4, widths(i) - 8, rowH - 6)
                    Dim sf As New StringFormat()
                    If i = 5 Then sf.Alignment = StringAlignment.Far
                    g.DrawString(headers(i), fontSection, Brushes.White, rect, sf)
                    x += widths(i)
                Next
                y += rowH

                Dim noSlot As Integer = 1
                For Each row As DataRow In _detailStruk.Rows
                    Dim vals As String() = {
                        noSlot.ToString(),
                        SafeString(row("nama_lapangan")),
                        SafeString(row("jenis_lantai")),
                        SafeDate(row("tanggal_main")).ToString("dd/MM/yyyy"),
                        SafeString(row("jam_main")),
                        SafeDecimal(row("harga_slot")).ToString("N0")
                    }

                    x = left
                    For i As Integer = 0 To vals.Length - 1
                        Dim rect As New RectangleF(x + 4, y + 4, widths(i) - 8, rowH - 6)
                        Dim sf As New StringFormat()
                        If i = 5 Then sf.Alignment = StringAlignment.Far
                        g.DrawString(vals(i), fontRow, Brushes.Black, rect, sf)
                        x += widths(i)
                    Next
                    g.DrawLine(penGaris, left, y + rowH, left + width, y + rowH)
                    y += rowH
                    noSlot += 1
                Next

                ' Riwayat Pembayaran
                y += 20.0F
                g.DrawString("RIWAYAT PEMBAYARAN", fontSection, Brushes.DarkSlateBlue, left, y)
                y += 22.0F

                Dim totalDibayar As Decimal = 0D
                If _pembayaranStruk.Rows.Count = 0 Then
                    g.DrawString("- Belum ada pembayaran tercatat.", fontRow, Brushes.DimGray, left + 8, y)
                    y += 22.0F
                Else
                    For Each pRow As DataRow In _pembayaranStruk.Rows
                        Dim jml As Decimal = SafeDecimal(pRow("jumlah_bayar"))
                        totalDibayar += jml
                        Dim lineBayar As String = String.Format(
                            "- {0} | {1} ({2}) | Tgl: {3:dd/MM/yyyy HH:mm} | Jumlah: Rp {4:N0}",
                            SafeString(pRow("no_transaksi")),
                            SafeString(pRow("jenis_pembayaran")),
                            SafeString(pRow("metode_pembayaran")),
                            SafeDate(pRow("waktu_bayar")),
                            jml
                        )
                        g.DrawString(lineBayar, fontRow, Brushes.Black, left + 8, y)
                        y += 22.0F
                    Next
                End If

                ' Ringkasan Tagihan
                Dim totalSewa As Decimal = SafeDecimal(_headerStruk("total_sewa"))
                Dim sisaTagihan As Decimal = If(status = "Kedaluwarsa", 0D, Math.Max(0D, totalSewa - totalDibayar))

                y += 14.0F
                g.DrawLine(penTebal, left, y, left + width, y)
                y += 12.0F

                Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far}
                g.DrawString("Total Sewa Lapangan :", fontBold, Brushes.Black, left + width - 310, y)
                g.DrawString(String.Format("Rp {0:N0}", totalSewa), fontBold, Brushes.Black, New RectangleF(left + width - 160, y, 160, 22), sfRight)
                y += 24.0F

                g.DrawString("Total Sudah Dibayar :", fontBold, Brushes.DarkGreen, left + width - 310, y)
                g.DrawString(String.Format("Rp {0:N0}", totalDibayar), fontBold, Brushes.DarkGreen, New RectangleF(left + width - 160, y, 160, 22), sfRight)
                y += 24.0F

                g.DrawString("Sisa Tagihan :", fontBold, Brushes.Crimson, left + width - 310, y)
                g.DrawString(String.Format("Rp {0:N0}", sisaTagihan), fontBold, Brushes.Crimson, New RectangleF(left + width - 160, y, 160, 22), sfRight)

                CetakFooterHalaman(g, fontSub, left, width, bottom)
                e.HasMorePages = False
            End Using
        End Sub

        Private Sub CetakHalamanRingkasanBulanan(e As PrintPageEventArgs)
            Dim g As Graphics = e.Graphics
            Dim left As Single = e.MarginBounds.Left
            Dim top As Single = e.MarginBounds.Top
            Dim width As Single = e.MarginBounds.Width
            Dim bottom As Single = e.MarginBounds.Bottom
            Dim y As Single = top

            Using fontJudul As New Font("Segoe UI", 14.0F, FontStyle.Bold),
                  fontSub As New Font("Segoe UI", 9.0F, FontStyle.Regular),
                  fontHeader As New Font("Segoe UI", 9.0F, FontStyle.Bold),
                  fontRow As New Font("Segoe UI", 9.0F, FontStyle.Regular),
                  fontBold As New Font("Segoe UI", 9.5F, FontStyle.Bold),
                  brushHeaderBg As New SolidBrush(Color.DarkSlateBlue),
                  brushAltBg As New SolidBrush(Color.FromArgb(245, 245, 250)),
                  brushSummaryBg As New SolidBrush(Color.FromArgb(240, 248, 255)),
                  penGaris As New Pen(Color.LightGray, 0.75F),
                  penTebal As New Pen(Color.DarkSlateBlue, 1.5F)

                g.DrawString("ARUNG FUTSAL — LAPORAN RINGKASAN BULANAN & OKUPANSI", fontJudul, Brushes.DarkSlateBlue, left, y)
                y += 26.0F
                g.DrawString(String.Format("Filter Tahun: {0}  |  Dicetak oleh: {1} ({2:dd/MM/yyyy HH:mm})", cboTahun.Text, ModSesi.NamaLengkap, DateTime.Now), fontSub, Brushes.DimGray, left, y)
                y += 20.0F
                g.DrawLine(penTebal, left, y, left + width, y)
                y += 12.0F

                Dim headers As String() = {"Periode", "Pendapatan (Rp)", "Jml Transaksi", "Slot Terisi", "Kapasitas", "Okupansi (%)"}
                Dim ratios As Single() = {0.16F, 0.24F, 0.16F, 0.14F, 0.14F, 0.16F}
                Dim widths(headers.Length - 1) As Single
                For i As Integer = 0 To headers.Length - 1
                    widths(i) = width * ratios(i)
                Next

                Dim rowH As Single = 26.0F
                g.FillRectangle(brushHeaderBg, left, y, width, rowH)
                Dim x As Single = left
                For i As Integer = 0 To headers.Length - 1
                    Dim rect As New RectangleF(x + 4, y + 4, widths(i) - 8, rowH - 6)
                    Dim sf As New StringFormat()
                    If i > 0 Then sf.Alignment = StringAlignment.Far
                    g.DrawString(headers(i), fontHeader, Brushes.White, rect, sf)
                    x += widths(i)
                Next
                y += rowH

                While _indeksBarisCetak < _tabelBulanan.Rows.Count
                    If y + rowH > bottom - 90.0F Then
                        CetakFooterHalaman(g, fontSub, left, width, bottom)
                        _nomorHalamanCetak += 1
                        e.HasMorePages = True
                        Return
                    End If

                    Dim row As DataRow = _tabelBulanan.Rows(_indeksBarisCetak)
                    If _indeksBarisCetak Mod 2 = 1 Then
                        g.FillRectangle(brushAltBg, left, y, width, rowH)
                    End If

                    Dim vals As String() = {
                        SafeString(row("periode")),
                        SafeDecimal(row("total_pendapatan")).ToString("N0"),
                        SafeInt(row("total_transaksi")).ToString("N0"),
                        SafeInt(row("slot_terisi")).ToString("N0"),
                        SafeInt(row("kapasitas_slot")).ToString("N0"),
                        SafeDecimal(row("persen_okupansi")).ToString("N2") & " %"
                    }

                    x = left
                    For i As Integer = 0 To vals.Length - 1
                        Dim rect As New RectangleF(x + 4, y + 4, widths(i) - 8, rowH - 6)
                        Dim sf As New StringFormat()
                        If i > 0 Then sf.Alignment = StringAlignment.Far
                        g.DrawString(vals(i), fontRow, Brushes.Black, rect, sf)
                        x += widths(i)
                    Next
                    g.DrawLine(penGaris, left, y + rowH, left + width, y + rowH)
                    y += rowH
                    _indeksBarisCetak += 1
                End While

                y += 14.0F
                g.FillRectangle(brushSummaryBg, left, y, width, 62.0F)
                g.DrawRectangle(penTebal, left, y, width, 62.0F)

                g.DrawString("RINGKASAN KESELURUHAN:", fontBold, Brushes.DarkSlateBlue, left + 10, y + 8)
                g.DrawString(String.Format("Total Pendapatan Terbayar: Rp {0:N0}   |   Total Transaksi Bayar: {1:N0}", _sumBlnPendapatan, _sumBlnTransaksi), fontRow, Brushes.Black, left + 10, y + 26)
                g.DrawString(String.Format("Total Slot Terisi: {0:N0} Jam   |   Rata-rata Okupansi: {1:N2} %", _sumBlnSlot, _sumBlnRataOkupansi), fontBold, Brushes.DarkGreen, left + 10, y + 43)

                CetakFooterHalaman(g, fontSub, left, width, bottom)
                e.HasMorePages = False
            End Using
        End Sub

        Private Sub CetakFooterHalaman(g As Graphics, fontFooter As Font, left As Single, width As Single, bottom As Single)
            Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far}
            g.DrawString("SIPELA — Sistem Informasi Pemesanan Lapangan Arung Futsal", fontFooter, Brushes.Gray, left, bottom - 12.0F)
            g.DrawString("Halaman " & _nomorHalamanCetak.ToString(), fontFooter, Brushes.Gray, New RectangleF(left, bottom - 12.0F, width, 18.0F), sfRight)
        End Sub

        ' =========================================================================
        ' NULL-SAFE CONVERSION HELPERS (ANTI DBNull CRASH)
        ' =========================================================================

        Private Shared Function SafeString(val As Object) As String
            If val Is Nothing OrElse DBNull.Value.Equals(val) Then Return String.Empty
            Return val.ToString()
        End Function

        Private Shared Function SafeInt(val As Object) As Integer
            If val Is Nothing OrElse DBNull.Value.Equals(val) Then Return 0
            Dim hasil As Integer
            If Integer.TryParse(val.ToString(), hasil) Then Return hasil
            Return Convert.ToInt32(val)
        End Function

        Private Shared Function SafeDecimal(val As Object) As Decimal
            If val Is Nothing OrElse DBNull.Value.Equals(val) Then Return 0D
            Dim hasil As Decimal
            If Decimal.TryParse(val.ToString(), hasil) Then Return hasil
            Return Convert.ToDecimal(val)
        End Function

        Private Shared Function SafeDate(val As Object) As DateTime
            If val Is Nothing OrElse DBNull.Value.Equals(val) Then Return DateTime.MinValue
            Return Convert.ToDateTime(val)
        End Function

    End Class

End Namespace