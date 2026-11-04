Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Windows.Forms

Public Module ModErrorHandler

    Private ReadOnly LogDirectory As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
    Private ReadOnly LogFilePath As String = Path.Combine(LogDirectory, "error.log")

    Public Sub TampilkanError(kegiatan As String, ex As Exception)
        Dim pesan As String = kegiatan & ":" & Environment.NewLine & ex.Message
        MessageBox.Show(pesan, "Kesalahan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        LogError(ex, kegiatan)
    End Sub

    Public Sub TampilkanPeringatan(pesan As String, Optional judul As String = "Validasi")
        MessageBox.Show(pesan, judul, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub TampilkanInfo(pesan As String, Optional judul As String = "Informasi")
        MessageBox.Show(pesan, judul, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function Konfirmasi(pesan As String, Optional judul As String = "Konfirmasi") As Boolean
        Return MessageBox.Show(pesan, judul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Public Sub LogError(ex As Exception, Optional konteks As String = "")
        Try
            If Not Directory.Exists(LogDirectory) Then
                Directory.CreateDirectory(LogDirectory)
            End If

            Dim barisLog As String = String.Format(
                "[{0:yyyy-MM-dd HH:mm:ss}] {1}{2}{3}{4}",
                DateTime.Now,
                If(String.IsNullOrEmpty(konteks), String.Empty, "[" & konteks & "] "),
                ex.Message,
                Environment.NewLine,
                ex.StackTrace & Environment.NewLine & New String("-"c, 80) & Environment.NewLine
            )

            File.AppendAllText(LogFilePath, barisLog)
        Catch
            ' Abaikan jika logging gagal agar tidak mengganggu alur UI
        End Try
    End Sub

End Module

