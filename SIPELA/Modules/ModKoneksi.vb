Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Public Module ModKoneksi

    Public Property Host As String = "localhost"
    Public Property Port As UInteger = 3306
    Public Property DatabaseName As String = "arung_futsal"
    Public Property Username As String = "root"
    Public Property Password As String = ""

    Public Function DapatkanConnectionString() As String
        Dim builder As New MySqlConnectionStringBuilder() With {
            .Server = Host,
            .Port = Port,
            .Database = DatabaseName,
            .UserID = Username,
            .Password = Password,
            .CharacterSet = "utf8mb4",
            .SslMode = MySqlSslMode.Disabled,
            .ConnectionTimeout = 5
        }
        Return builder.ConnectionString
    End Function

    Public Function BukaKoneksi() As MySqlConnection
        Dim conn As New MySqlConnection(DapatkanConnectionString())
        Try
            conn.Open()
            Return conn
        Catch ex As MySqlException
            Dim pesan As String = "Gagal terhubung ke database MySQL." & Environment.NewLine &
                                  "Pastikan server MySQL berjalan di " & Host & ":" & Port.ToString() &
                                  Environment.NewLine & "Pesan error: " & ex.Message
            Throw New InvalidOperationException(pesan, ex)
        End Try
    End Function

    Public Function TestKoneksi() As Boolean
        Try
            Using conn As MySqlConnection = BukaKoneksi()
                Return conn.State = ConnectionState.Open
            End Using
        Catch
            Return False
        End Try
    End Function

End Module
