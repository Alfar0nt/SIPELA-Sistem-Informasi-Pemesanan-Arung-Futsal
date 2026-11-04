Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Menu Utama & Dasbor Operasional SIPELA (Arung Futsal).
    ''' Menangani navigasi antar form berdasarkan peran (Admin/Owner) serta
    ''' menjalankan background worker berkala untuk pembatalan otomatis booking kedaluwarsa.
    ''' </summary>
    Public Class frmMenuUtama

        ' Timer latar belakang untuk mengeksekusi sp_kedaluwarsakan_pemesanan setiap 30 detik
        Private WithEvents _tmrAutoExpire As New Timer()

        Private Sub frmMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Pastikan sesi valid
            If Not ModSesi.IsLoggedIn Then
                ModErrorHandler.TampilkanPeringatan("Sesi tidak valid. Silakan login kembali.", "Akses Ditolak")
                Me.Close()
                Return
            End If

            lblUserInfo.Text = String.Format("Login sebagai: {0} ({1})", ModSesi.NamaLengkap, ModSesi.Role)

            ' Pembatasan hak akses menu berdasarkan Role
            If ModSesi.IsOwner Then
                btnMasterLapangan.Enabled = True
                btnMasterUsers.Enabled = True
                btnLaporan.Enabled = True
            Else
                ' Admin / Kasir
                btnMasterLapangan.Enabled = False
                btnMasterUsers.Enabled = False
                ' Tombol laporan tetap aktif tetapi akan menampilkan notifikasi hak akses jika diklik
                btnLaporan.Enabled = True
            End If

            ' Menu transaksi operasional aktif untuk semua peran
            btnPemesanan.Enabled = True
            btnPembayaran.Enabled = True
            btnJadwal.Enabled = True

            ' Inisialisasi background maintenance timer (berjalan setiap 30 detik)
            _tmrAutoExpire.Interval = 30000
            _tmrAutoExpire.Start()

            ' Jalankan pemeriksaan kedaluwarsa pertama kali saat dasbor dibuka
            EksekusiAutoExpireAsync()
        End Sub

        Private Sub frmMenuUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            ' Hentikan timer background saat form ditutup
            _tmrAutoExpire.Stop()
        End Sub

        Private Sub _tmrAutoExpire_Tick(sender As Object, e As EventArgs) Handles _tmrAutoExpire.Tick
            EksekusiAutoExpireAsync()
        End Sub

        ''' <summary>
        ''' Memanggil Stored Procedure sp_kedaluwarsakan_pemesanan secara asinkron di thread terpisah
        ''' agar antarmuka kasir tetap responsif tanpa jeda/freeze.
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
                                   ' Abaikan jika database sesaat tidak merespons agar tidak mengganggu kasir
                               End Try
                           End Sub)
        End Sub

        Private Sub btnMasterLapangan_Click(sender As Object, e As EventArgs) Handles btnMasterLapangan.Click
            Dim formLapangan As New frmMasterLapangan()
            formLapangan.ShowDialog(Me)
        End Sub

        Private Sub btnMasterUsers_Click(sender As Object, e As EventArgs) Handles btnMasterUsers.Click
            Dim formUsers As New frmMasterUsers()
            formUsers.ShowDialog(Me)
        End Sub

        Private Sub btnPemesanan_Click(sender As Object, e As EventArgs) Handles btnPemesanan.Click
            Dim formPemesanan As New frmPemesanan()
            formPemesanan.ShowDialog(Me)
        End Sub

        Private Sub btnPembayaran_Click(sender As Object, e As EventArgs) Handles btnPembayaran.Click
            Dim formPembayaran As New frmPembayaran()
            formPembayaran.ShowDialog(Me)
        End Sub

        Private Sub btnJadwal_Click(sender As Object, e As EventArgs) Handles btnJadwal.Click
            Dim formJadwal As New frmJadwal()
            formJadwal.ShowDialog(Me)
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
