Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Public Module ModAutoNumber

    ''' <summary>
    ''' Mengambil nomor urut atomik berikutnya menggunakan Stored Procedure sp_nomor_berikutnya.
    ''' Memiliki fallback query jika Stored Procedure belum terinstall di MySQL server.
    ''' </summary>
    Public Function AmbilNomorBerikutnya(koneksi As MySqlConnection,
                                         jenis As String,
                                         tanggal As DateTime,
                                         Optional transaksi As MySqlTransaction = Nothing) As Integer
        Try
            Using cmd As New MySqlCommand("sp_nomor_berikutnya", koneksi, transaksi)
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
            End Using
        Catch
            ' Fallback query langsung jika SP belum terpasang
            Try
                Dim sqlFallback As String = "SELECT COALESCE(MAX(nomor_terakhir), 0) + 1 FROM penomoran WHERE jenis = @jenis AND tanggal = @tanggal"
                Using cmd As New MySqlCommand(sqlFallback, koneksi, transaksi)
                    cmd.Parameters.AddWithValue("@jenis", jenis)
                    cmd.Parameters.AddWithValue("@tanggal", tanggal.Date)
                    Dim res As Object = cmd.ExecuteScalar()
                    If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                        Return Convert.ToInt32(res)
                    End If
                End Using
            Catch
                ' Fallback kedua jika tabel penomoran belum dibuat: estimasi dari tabel pemesanan/pembayaran
                Try
                    Dim tabelTarget As String = If(jenis = "BKG", "pemesanan", "pembayaran")
                    Dim idCol As String = If(jenis = "BKG", "id_pemesanan", "id_pembayaran")
                    Dim sqlEst As String = "SELECT COALESCE(MAX(" & idCol & "), 0) + 1 FROM " & tabelTarget
                    Using cmd As New MySqlCommand(sqlEst, koneksi, transaksi)
                        Dim res As Object = cmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                            Return Convert.ToInt32(res)
                        End If
                    End Using
                Catch
                    Return 1
                End Try
            End Try
        End Try
        Return 1
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

