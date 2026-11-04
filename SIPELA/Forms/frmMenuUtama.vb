Option Strict On
Option Explicit On

Imports System
Imports System.Windows.Forms

Namespace Forms

    Public Class frmMenuUtama

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
            Else
                ' Admin
                btnMasterLapangan.Enabled = False
                btnMasterUsers.Enabled = False
            End If
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
            ModErrorHandler.TampilkanInfo(
                "Fitur Transaksi Pemesanan sedang disiapkan untuk tahap berikutnya (Week 11/Final Project).",
                "Fitur Mendatang"
            )
        End Sub

        Private Sub btnPembayaran_Click(sender As Object, e As EventArgs) Handles btnPembayaran.Click
            ModErrorHandler.TampilkanInfo(
                "Fitur Transaksi Pembayaran sedang disiapkan untuk tahap berikutnya (Week 11/Final Project).",
                "Fitur Mendatang"
            )
        End Sub

        Private Sub btnJadwal_Click(sender As Object, e As EventArgs) Handles btnJadwal.Click
            ModErrorHandler.TampilkanInfo(
                "Fitur Kalender Jadwal Lapangan sedang disiapkan untuk tahap berikutnya (Week 11/Final Project).",
                "Fitur Mendatang"
            )
        End Sub

        Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
            ModErrorHandler.TampilkanInfo(
                "Fitur Laporan Pendapatan & Okupansi sedang disiapkan untuk tahap berikutnya (Week 11/Final Project).",
                "Fitur Mendatang"
            )
        End Sub

        Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
            If ModErrorHandler.Konfirmasi("Apakah Anda yakin ingin keluar dari sistem?", "Konfirmasi Logout") Then
                ModSesi.Logout()
                Me.Close()
            End If
        End Sub

    End Class

End Namespace

