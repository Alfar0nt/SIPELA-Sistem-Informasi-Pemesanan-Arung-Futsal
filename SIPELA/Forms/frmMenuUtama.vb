Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Menu Utama & Dasbor Operasional SIPELA (Arung Futsal).
    ''' Menampilkan kartu metrik taktil secara realtime, navigasi operasional lengkap,
    ''' dan background worker pemeliharaan slot otomatis.
    ''' </summary>
    Public Class frmMenuUtama

        ' Timer latar belakang untuk pembatalan booking kedaluwarsa & refresh metrik (30 detik)
        Private WithEvents _tmrAutoExpire As New Timer()

        Private Sub frmMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Pastikan sesi valid
            If Not ModSesi.IsLoggedIn Then
                ModErrorHandler.TampilkanPeringatan("Sesi tidak valid. Silakan login kembali.", "Akses Ditolak")
                Me.Close()
                Return
            End If

            ' 1. Terapkan Tema Visual Neo-Brutalism
            TerapkanTemaDesain()

            ' 2. Atur Info Pengguna Aktif
            lblUserInfo.Text = String.Format("Login sebagai: {0} ({1})", ModSesi.NamaLengkap, ModSesi.Role)

            ' 3. Pembatasan Hak Akses Menu Berdasarkan Role
            AturHakAksesMenu()

            ' 4. Inisialisasi Timer Background Maintenance
            _tmrAutoExpire.Interval = 30000
            _tmrAutoExpire.Start()

            ' 5. Muat metrik statistik dashboard awal
            MuatStatistikRealtime()

            ' 6. Jalankan pembersihan slot kedaluwarsa pertama kali
            EksekusiAutoExpireAsync()
        End Sub

        Private Sub TerapkanTemaDesain()
            ModUIHelper.TerapkanTemaForm(Me)

            ' Styling Card Metrik Atas
            ModUIHelper.TerapkanGayaCard(pnlCardLap, ModUIHelper.ColorSkyBlue)
            ModUIHelper.TerapkanGayaCard(pnlCardBkgHariIni, ModUIHelper.ColorMintGreen)
            ModUIHelper.TerapkanGayaCard(pnlCardPendingDP, ModUIHelper.ColorCoral)
            ModUIHelper.TerapkanGayaCard(pnlCardOmzetBulan, ModUIHelper.ColorLavender)

            ' Styling Tombol Menu Utama
            ModUIHelper.TerapkanGayaTombol(btnPemesanan, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnPembayaran, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnJadwal, ModUIHelper.TombolTipe.OutlineWhite)

            ModUIHelper.TerapkanGayaTombol(btnMasterLapangan, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnMasterUsers, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnLaporan, ModUIHelper.TombolTipe.OutlineWhite)

            ' Styling Tombol Keluar & Badge
            ModUIHelper.TerapkanGayaTombol(btnLogout, ModUIHelper.TombolTipe.DangerCoral)
            ModUIHelper.TerapkanBadgePill(lblBadgeKoneksi, ModUIHelper.ColorMintGreen, Color.White)
        End Sub

        Private Sub AturHakAksesMenu()
            If ModSesi.IsOwner Then
                btnMasterLapangan.Enabled = True
                btnMasterUsers.Enabled = True
                btnLaporan.Enabled = True
            Else
                ' Admin / Kasir
                btnMasterLapangan.Enabled = False
                btnMasterUsers.Enabled = False
                btnLaporan.Enabled = True ' Menampilkan notifikasi hak akses jika diklik
            End If

            ' Menu operasional selalu aktif
            btnPemesanan.Enabled = True
            btnPembayaran.Enabled = True
            btnJadwal.Enabled = True
        End Sub

        ''' <summary>
        ''' Mengambil data metrik dari MySQL secara berkala untuk mengisi 4 kartu statistik utama.
        ''' </summary>
        Private Sub MuatStatistikRealtime()
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' 1. Total Lapangan Aktif
                    Const sqlLap As String = "SELECT COUNT(*) FROM lapangan WHERE is_active = TRUE;"
                    Using cmdLap As New MySqlCommand(sqlLap, conn)
                        Dim totalLap As Long = Convert.ToInt64(cmdLap.ExecuteScalar())
                        lblStatLap.Text = String.Format("{0} Lapangan", totalLap)
                    End Using

                    ' 2. Total Slot Terisi Hari Ini
                    Const sqlBkg As String = "SELECT COUNT(*) FROM detail_pemesanan WHERE tanggal_main = CURDATE() AND aktif = TRUE;"
                    Using cmdBkg As New MySqlCommand(sqlBkg, conn)
                        Dim bkgHariIni As Long = Convert.ToInt64(cmdBkg.ExecuteScalar())
                        lblStatBkgHariIni.Text = String.Format("{0} Slot", bkgHariIni)
                    End Using

                    ' 3. Booking Menunggu DP (15 Menit)
                    Const sqlPending As String = "SELECT COUNT(*) FROM pemesanan WHERE status_pemesanan = 'Menunggu DP';"
                    Using cmdPending As New MySqlCommand(sqlPending, conn)
                        Dim pendingCount As Long = Convert.ToInt64(cmdPending.ExecuteScalar())
                        lblStatPendingDP.Text = String.Format("{0} Booking", pendingCount)
                    End Using

                    ' 4. Omzet Bulan Ini
                    Const sqlOmzet As String = "SELECT COALESCE(SUM(jumlah_bayar), 0) FROM pembayaran " &
                                               "WHERE YEAR(waktu_bayar) = YEAR(CURDATE()) AND MONTH(waktu_bayar) = MONTH(CURDATE());"
                    Using cmdOmzet As New MySqlCommand(sqlOmzet, conn)
                        Dim omzet As Decimal = Convert.ToDecimal(cmdOmzet.ExecuteScalar())
                        lblStatOmzetBulan.Text = String.Format("Rp {0:N0}", omzet)
                    End Using
                End Using

            Catch
                ' Jangan gagalkan antarmuka jika database sesaat sibuk
            End Try
        End Sub

        Private Sub frmMenuUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            _tmrAutoExpire.Stop()
        End Sub

        Private Sub _tmrAutoExpire_Tick(sender As Object, e As EventArgs) Handles _tmrAutoExpire.Tick
            EksekusiAutoExpireAsync()
            MuatStatistikRealtime()
        End Sub

        ''' <summary>
        ''' Memanggil Stored Procedure sp_kedaluwarsakan_pemesanan secara asinkron di thread terpisah.
        ''' </summary>
        Private Async Sub EksekusiAutoExpireAsync()
            Await Task.Run(Sub()
                               Try
                                   Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                                       Using cmd As New MySqlCommand("sp_kedaluwarsakan_pemesanan", conn)
                                           cmd.CommandType = CommandType.StoredProcedure
                                           cmd.ExecuteNonQuery()
                                       End Using
                                   End Using
                               Catch
                                   ' Background worker silen failover
                               End Try
                           End Sub)
        End Sub

        ' =====================================================================
        ' NAVIGASI MENU OPERASIONAL
        ' =====================================================================

        Private Sub btnPemesanan_Click(sender As Object, e As EventArgs) Handles btnPemesanan.Click
            Dim formPemesanan As New frmPemesanan()
            formPemesanan.ShowDialog(Me)
            MuatStatistikRealtime()
        End Sub

        Private Sub btnPembayaran_Click(sender As Object, e As EventArgs) Handles btnPembayaran.Click
            Dim formPembayaran As New frmPembayaran()
            formPembayaran.ShowDialog(Me)
            MuatStatistikRealtime()
        End Sub

        Private Sub btnJadwal_Click(sender As Object, e As EventArgs) Handles btnJadwal.Click
            Dim formJadwal As New frmJadwal()
            formJadwal.ShowDialog(Me)
            MuatStatistikRealtime()
        End Sub

        Private Sub btnMasterLapangan_Click(sender As Object, e As EventArgs) Handles btnMasterLapangan.Click
            Dim formLapangan As New frmMasterLapangan()
            formLapangan.ShowDialog(Me)
            MuatStatistikRealtime()
        End Sub

        Private Sub btnMasterUsers_Click(sender As Object, e As EventArgs) Handles btnMasterUsers.Click
            Dim formUsers As New frmMasterUsers()
            formUsers.ShowDialog(Me)
        End Sub

        Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
            If Not ModSesi.IsOwner Then
                ModErrorHandler.TampilkanPeringatan(
                    "Laporan Keuangan & Analitik Operasional hanya dapat diakses oleh akun Owner.",
                    "Akses Terbatas"
                )
                Return
            End If

            Dim formLaporan As New frmLaporan()
            formLaporan.ShowDialog(Me)
        End Sub

        Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
            If ModErrorHandler.Konfirmasi("Apakah Anda yakin ingin keluar dari sistem?", "Konfirmasi Logout") Then
                _tmrAutoExpire.Stop()
                ModSesi.Logout()
                Me.Close()
            End If
        End Sub

    End Class

End Namespace
