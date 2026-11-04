Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Kalender Matriks Jadwal Lapangan (SIPELA).
    ''' Menampilkan matriks slot operasional jam 08.00 s.d. 24.00 per lapangan dalam bentuk
    ''' grid taktil dengan indikator status warna tegas (Tersedia, Terisi, Menunggu DP).
    ''' </summary>
    Public Class frmJadwal

        Private Class InfoSlot
            Public Property IdPemesanan As Integer
            Public Property KodeBooking As String
            Public Property NamaPemesan As String
            Public Property NoTelepon As String
            Public Property StatusPemesanan As String
            Public Property NamaLapangan As String
            Public Property JamMulai As Integer
            Public Property TanggalMain As Date
            Public Property HargaSlot As Decimal
        End Class

        Private Class DefinisiLapangan
            Public Property Id As Integer
            Public Property Nama As String
            Public Property JenisLantai As String
            Public Property HargaPerJam As Decimal
        End Class

        Private ReadOnly _daftarLapangan As New List(Of DefinisiLapangan)()
        Private ReadOnly _jadwalMap As New Dictionary(Of String, InfoSlot)()

        Private Sub frmJadwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Terapkan Tema Desain Taktil Neo-Brutalism
            TerapkanTemaDesain()

            ' 2. Atur default tanggal hari ini
            dtpTanggal.Value = DateTime.Today

            ' 3. Muat matriks jadwal
            MuatMatriksJadwal()
        End Sub

        Private Sub TerapkanTemaDesain()
            ModUIHelper.TerapkanTemaForm(Me)
            ModUIHelper.TerapkanGayaCard(pnlToolbar)
            ModUIHelper.TerapkanGayaCard(pnlContainer)
            ModUIHelper.TerapkanGayaCard(pnlStats, ModUIHelper.ColorWarmCream)

            ModUIHelper.TerapkanGayaTombol(btnKembali, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnHariSebelumnya, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnHariIni, ModUIHelper.TombolTipe.SecondarySky)
            ModUIHelper.TerapkanGayaTombol(btnHariBerikutnya, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnBookingBaru, ModUIHelper.TombolTipe.PrimaryMint)

            ModUIHelper.TerapkanBadgePill(lblLegendTersedia, ModUIHelper.ColorMintGreen, Color.White)
            ModUIHelper.TerapkanBadgePill(lblLegendTerisi, ModUIHelper.ColorCoral, ModUIHelper.ColorCrispSlate)
            ModUIHelper.TerapkanBadgePill(lblLegendHolding, Color.FromArgb(254, 243, 199), Color.FromArgb(146, 64, 14))

            ' Konfigurasi dasar DataGridView Matriks
            dgvMatriks.BackgroundColor = ModUIHelper.ColorWarmCream
            dgvMatriks.BorderStyle = BorderStyle.None
            dgvMatriks.GridColor = Color.FromArgb(200, 205, 220)
            dgvMatriks.RowHeadersVisible = False
            dgvMatriks.MultiSelect = False
            dgvMatriks.ReadOnly = True
            dgvMatriks.SelectionMode = DataGridViewSelectionMode.CellSelect
            dgvMatriks.AllowUserToAddRows = False
            dgvMatriks.AllowUserToDeleteRows = False
            dgvMatriks.AllowUserToResizeRows = False
            dgvMatriks.EnableHeadersVisualStyles = False

            dgvMatriks.ColumnHeadersDefaultCellStyle.BackColor = ModUIHelper.ColorCrispSlate
            dgvMatriks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgvMatriks.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            dgvMatriks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvMatriks.ColumnHeadersHeight = 38
            dgvMatriks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgvMatriks.RowTemplate.Height = 36
        End Sub

        ''' <summary>
        ''' Memuat seluruh lapangan aktif dan data slot jadwal untuk tanggal yang dipilih.
        ''' </summary>
        Private Sub MuatMatriksJadwal()
            Dim tgl As Date = dtpTanggal.Value.Date
            _daftarLapangan.Clear()
            _jadwalMap.Clear()

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' 1. Ambil semua lapangan aktif
                    Const sqlLap As String = "SELECT id_lapangan, nama_lapangan, jenis_lantai, harga_per_jam FROM lapangan WHERE is_active = TRUE ORDER BY id_lapangan ASC;"
                    Using cmdLap As New MySqlCommand(sqlLap, conn)
                        Using reader As MySqlDataReader = cmdLap.ExecuteReader()
                            While reader.Read()
                                _daftarLapangan.Add(New DefinisiLapangan() With {
                                    .Id = reader.GetInt32("id_lapangan"),
                                    .Nama = reader.GetString("nama_lapangan"),
                                    .JenisLantai = reader.GetString("jenis_lantai"),
                                    .HargaPerJam = reader.GetDecimal("harga_per_jam")
                                })
                            End While
                        End Using
                    End Using

                    ' 2. Ambil data slot dari view v_jadwal_lapangan
                    Const sqlSlot As String = "SELECT id_detail, tanggal_main, jam_mulai, harga_slot, id_lapangan, " &
                                              "       nama_lapangan, id_pemesanan, kode_booking, nama_pemesan, no_telepon, status_pemesanan " &
                                              "FROM v_jadwal_lapangan " &
                                              "WHERE tanggal_main = @tanggal_main AND status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas');"

                    Using cmdSlot As New MySqlCommand(sqlSlot, conn)
                        cmdSlot.Parameters.AddWithValue("@tanggal_main", tgl)
                        Using reader As MySqlDataReader = cmdSlot.ExecuteReader()
                            While reader.Read()
                                Dim info As New InfoSlot() With {
                                    .IdPemesanan = reader.GetInt32("id_pemesanan"),
                                    .KodeBooking = reader.GetString("kode_booking"),
                                    .NamaPemesan = reader.GetString("nama_pemesan"),
                                    .NoTelepon = reader.GetString("no_telepon"),
                                    .StatusPemesanan = reader.GetString("status_pemesanan"),
                                    .NamaLapangan = reader.GetString("nama_lapangan"),
                                    .JamMulai = reader.GetInt32("jam_mulai"),
                                    .TanggalMain = reader.GetDateTime("tanggal_main"),
                                    .HargaSlot = reader.GetDecimal("harga_slot")
                                }
                                Dim key As String = String.Format("{0}_{1}", reader.GetInt32("id_lapangan"), info.JamMulai)
                                _jadwalMap(key) = info
                            End While
                        End Using
                    End Using
                End Using

                ' 3. Bangun Kolom DataGridView
                BangunKolomDanBarisMatriks()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memuat kalender matriks jadwal", ex)
            End Try
        End Sub

        Private Sub BangunKolomDanBarisMatriks()
            dgvMatriks.SuspendLayout()
            dgvMatriks.Columns.Clear()
            dgvMatriks.Rows.Clear()

            ' Kolom 0: Slot Jam Operasional
            Dim colJam As New DataGridViewTextBoxColumn() With {
                .HeaderText = "WAKTU (WIB)",
                .Name = "colJam",
                .Width = 140,
                .ReadOnly = True,
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }
            colJam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colJam.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            colJam.DefaultCellStyle.BackColor = Color.FromArgb(246, 244, 252)
            colJam.DefaultCellStyle.ForeColor = ModUIHelper.ColorCrispSlate
            dgvMatriks.Columns.Add(colJam)

            ' Kolom 1..N: Setiap Lapangan Aktif
            For Each lap In _daftarLapangan
                Dim colLap As New DataGridViewTextBoxColumn() With {
                    .HeaderText = String.Format("{0} ({1})", lap.Nama, lap.JenisLantai),
                    .Name = "colLap_" & lap.Id.ToString(),
                    .Tag = lap.Id,
                    .MinimumWidth = 200,
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    .ReadOnly = True,
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                }
                colLap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                colLap.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
                dgvMatriks.Columns.Add(colLap)
            Next

            ' Tambahkan 16 Baris (Jam 08.00 s.d. 23.00)
            Dim totalSlot As Integer = _daftarLapangan.Count * 16
            Dim slotTerisiCount As Integer = 0

            For jam As Integer = 8 To 23
                Dim rowIndex As Integer = dgvMatriks.Rows.Add()
                Dim row As DataGridViewRow = dgvMatriks.Rows(rowIndex)

                ' Nilai Kolom Jam
                row.Cells("colJam").Value = String.Format("{0:D2}.00 - {1:D2}.00", jam, jam + 1)

                ' Nilai Setiap Lapangan
                For colIdx As Integer = 1 To dgvMatriks.Columns.Count - 1
                    Dim col As DataGridViewColumn = dgvMatriks.Columns(colIdx)
                    Dim idLap As Integer = Convert.ToInt32(col.Tag)
                    Dim key As String = String.Format("{0}_{1}", idLap, jam)

                    Dim cell As DataGridViewCell = row.Cells(colIdx)

                    If _jadwalMap.ContainsKey(key) Then
                        slotTerisiCount += 1
                        Dim info As InfoSlot = _jadwalMap(key)
                        cell.Tag = info

                        If info.StatusPemesanan = "Menunggu DP" Then
                            cell.Value = "🟡 " & info.NamaPemesan & " (Holding DP)"
                            cell.Style.BackColor = Color.FromArgb(254, 243, 199)
                            cell.Style.ForeColor = Color.FromArgb(146, 64, 14)
                            cell.Style.SelectionBackColor = Color.FromArgb(253, 230, 138)
                            cell.Style.SelectionForeColor = Color.FromArgb(146, 64, 14)
                        Else
                            ' DP Terbayar atau Lunas
                            cell.Value = "🔴 " & info.NamaPemesan & " [" & info.StatusPemesanan & "]"
                            cell.Style.BackColor = Color.FromArgb(254, 226, 226)
                            cell.Style.ForeColor = Color.FromArgb(153, 27, 27)
                            cell.Style.SelectionBackColor = Color.FromArgb(254, 202, 202)
                            cell.Style.SelectionForeColor = Color.FromArgb(153, 27, 27)
                        End If
                    Else
                        ' Kosong / Tersedia
                        cell.Tag = Nothing
                        cell.Value = "🟢 Tersedia"
                        cell.Style.BackColor = Color.FromArgb(232, 248, 238)
                        cell.Style.ForeColor = Color.FromArgb(24, 122, 68)
                        cell.Style.SelectionBackColor = Color.FromArgb(187, 247, 208)
                        cell.Style.SelectionForeColor = Color.FromArgb(24, 122, 68)
                    End If
                Next
            Next

            dgvMatriks.ResumeLayout()

            ' Perbarui kartu statistik bawah
            Dim slotKosongCount As Integer = Math.Max(0, totalSlot - slotTerisiCount)
            Dim persentaseOkupansi As Double = If(totalSlot > 0, (CDbl(slotTerisiCount) / CDbl(totalSlot)) * 100.0, 0.0)

            lblStatTotalSlot.Text = String.Format("Total Slot Harian: {0}", totalSlot)
            lblStatTerisi.Text = String.Format("Slot Terisi: {0}", slotTerisiCount)
            lblStatKosong.Text = String.Format("Slot Tersedia: {0}", slotKosongCount)
            lblStatOkupansi.Text = String.Format("Okupansi Hari Ini: {0:F1}%", persentaseOkupansi)
        End Sub

        Private Sub dtpTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggal.ValueChanged
            MuatMatriksJadwal()
        End Sub

        Private Sub btnHariSebelumnya_Click(sender As Object, e As EventArgs) Handles btnHariSebelumnya.Click
            dtpTanggal.Value = dtpTanggal.Value.AddDays(-1)
        End Sub

        Private Sub btnHariIni_Click(sender As Object, e As EventArgs) Handles btnHariIni.Click
            dtpTanggal.Value = DateTime.Today
        End Sub

        Private Sub btnHariBerikutnya_Click(sender As Object, e As EventArgs) Handles btnHariBerikutnya.Click
            dtpTanggal.Value = dtpTanggal.Value.AddDays(1)
        End Sub

        Private Sub btnBookingBaru_Click(sender As Object, e As EventArgs) Handles btnBookingBaru.Click
            Dim formBkg As New frmPemesanan()
            formBkg.ShowDialog(Me)
            MuatMatriksJadwal()
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' Menangani klik pada sel matriks jadwal.
        ''' </summary>
        Private Sub dgvMatriks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMatriks.CellClick
            If e.RowIndex < 0 OrElse e.ColumnIndex <= 0 Then Return

            Dim cell As DataGridViewCell = dgvMatriks.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim col As DataGridViewColumn = dgvMatriks.Columns(e.ColumnIndex)
            Dim namaLapangan As String = col.HeaderText
            Dim slotJam As String = Convert.ToString(dgvMatriks.Rows(e.RowIndex).Cells("colJam").Value)

            If cell.Tag IsNot Nothing Then
                ' Slot sudah terisi / holding
                Dim info As InfoSlot = TryCast(cell.Tag, InfoSlot)
                If info IsNot Nothing Then
                    Dim pesan As String = String.Format(
                        "Informasi Pemesanan Terisi:{0}{0}" &
                        "• Kode Booking: {1}{0}" &
                        "• Nama Pemesan: {2}{0}" &
                        "• No. Telepon : {3}{0}" &
                        "• Lapangan    : {4}{0}" &
                        "• Slot Waktu  : {5:dddd, dd MMMM yyyy} ({6}){0}" &
                        "• Status Sewa : {7}{0}{0}" &
                        "Apakah Anda ingin membuka menu Kasir Pembayaran untuk transaksi ini?",
                        Environment.NewLine, info.KodeBooking, info.NamaPemesan,
                        info.NoTelepon, info.NamaLapangan, info.TanggalMain, slotJam, info.StatusPemesanan
                    )

                    If ModErrorHandler.Konfirmasi(pesan, "Rincian Slot Terisi") Then
                        Dim formPay As New frmPembayaran()
                        formPay.ShowDialog(Me)
                        MuatMatriksJadwal()
                    End If
                End If
            Else
                ' Slot kosong
                Dim prompt As String = String.Format(
                    "Slot waktu {0} pada {1} masih TERSEDIA.{0}{0}" &
                    "Apakah Anda ingin membuat pemesanan baru untuk jadwal ini sekarang?",
                    slotJam, namaLapangan
                )

                If ModErrorHandler.Konfirmasi(prompt, "Slot Tersedia") Then
                    Dim formBkg As New frmPemesanan()
                    formBkg.ShowDialog(Me)
                    MuatMatriksJadwal()
                End If
            End If
        End Sub

    End Class

End Namespace

