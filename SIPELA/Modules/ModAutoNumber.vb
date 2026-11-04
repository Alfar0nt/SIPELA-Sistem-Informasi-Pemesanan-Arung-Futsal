Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Public Module ModAutoNumber

    ''' <summary>
    ''' Mengambil nomor urut atomik berikutnya menggunakan Stored Procedure sp_nomor_berikutnya.
    ''' </summary>
    Public Function AmbilNomorBerikutnya(koneksi As MySqlConnection, jenis As String, tanggal As DateTime) As Integer
        Using cmd As New MySqlCommand("sp_nomor_berikutnya", koneksi)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("p_jenis", jenis)
            cmd.Parameters.AddWithValue("p_tanggal", tanggal.Date)

            Dim pNomor As New MySqlParameter("p_nomor", MySqlDbType.Int32)
            pNomor.Direction = ParameterDirection.Output
            cmd.Parameters.Add(pNomor)

            cmd.ExecuteNonQuery()

            If pNomor.Value IsNot Nothing AndAlso Not DBNull.Value.Equals(pNomor.Value) Then
                Return Convert.ToInt32(pNomor.Value)
            End If
            Return 1
        End Using
    End Function

    ''' <summary>
    ''' Membuat kode berformat unik, contoh: BKG-20261104-0001 atau PAY-20261104-0001
    ''' </summary>
    Public Function BuatKodeOtomatis(jenis As String, tanggal As DateTime) As String
        Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
            Dim nomor As Integer = AmbilNomorBerikutnya(conn, jenis, tanggal)
            Return String.Format("{0}-{1:yyyyMMdd}-{2:D4}", jenis, tanggal, nomor)
        End Using
    End Function

End Module

