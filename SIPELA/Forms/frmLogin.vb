Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    Public Class frmLogin

        Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lblStatus.Text = String.Empty
            txtUsername.Clear()
            txtPassword.Clear()
            txtUsername.Focus()
        End Sub

        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            lblStatus.Text = String.Empty

            Dim user As String = txtUsername.Text.Trim()
            Dim pass As String = txtPassword.Text

            If String.IsNullOrEmpty(user) Then
                lblStatus.Text = "Username wajib diisi."
                txtUsername.Focus()
                Return
            End If

            If String.IsNullOrEmpty(pass) Then
                lblStatus.Text = "Password wajib diisi."
                txtPassword.Focus()
                Return
            End If

            Try
                ProsesLogin(user, pass)
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memproses login", ex)
            End Try
        End Sub

        Private Sub ProsesLogin(user As String, pass As String)
            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sqlSelect As String =
                    "SELECT id_user, username, password_hash, nama_lengkap, role, is_active, " &
                    "gagal_login, terkunci_sampai, NOW() AS waktu_server " &
                    "FROM users WHERE username = @user LIMIT 1"

                Using cmd As New MySqlCommand(sqlSelect, conn)
                    cmd.Parameters.AddWithValue("@user", user)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            lblStatus.Text = "Username atau password salah."
                            txtPassword.Clear()
                            txtPassword.Focus()
                            Return
                        End If

                        Dim idUser As Integer = reader.GetInt32("id_user")
                        Dim hashDb As String = reader.GetString("password_hash")
                        Dim nama As String = reader.GetString("nama_lengkap")
                        Dim role As String = reader.GetString("role")
                        Dim isActive As Boolean = reader.GetBoolean("is_active")
                        Dim gagalLogin As Integer = Convert.ToInt32(reader("gagal_login"))

                        Dim terkunciSampai As DateTime? = Nothing
                        If Not reader.IsDBNull(reader.GetOrdinal("terkunci_sampai")) Then
                            terkunciSampai = reader.GetDateTime("terkunci_sampai")
                        End If
                        Dim waktuServer As DateTime = reader.GetDateTime("waktu_server")

                        reader.Close()

                        ' 1. Cek apakah akun aktif
                        If Not isActive Then
                            lblStatus.Text = "Akun Anda dinonaktifkan. Silakan hubungi Owner."
                            Return
                        End If

                        ' 2. Cek apakah akun sedang terkunci
                        If terkunciSampai.HasValue AndAlso terkunciSampai.Value > waktuServer Then
                            Dim sisaMenit As Integer = CInt(Math.Ceiling((terkunciSampai.Value - waktuServer).TotalMinutes))
                            lblStatus.Text = String.Format("Akun terkunci karena 5x gagal login. Coba lagi dalam {0} menit.", sisaMenit)
                            Return
                        End If

                        ' 3. Bandingkan Hash Password
                        Dim hashInput As String = HitungSHA256(pass)
                        If String.Equals(hashDb, hashInput, StringComparison.OrdinalIgnoreCase) Then
                            ' Login Berhasil -> Reset counter gagal_login
                            Const sqlReset As String =
                                "UPDATE users SET gagal_login = 0, terkunci_sampai = NULL WHERE id_user = @id"
                            Using cmdReset As New MySqlCommand(sqlReset, conn)
                                cmdReset.Parameters.AddWithValue("@id", idUser)
                                cmdReset.ExecuteNonQuery()
                            End Using

                            ModSesi.SetSesi(idUser, user, nama, role)

                            ' Buka Menu Utama
                            Dim menuUtama As New frmMenuUtama()
                            AddHandler menuUtama.FormClosed, AddressOf MenuUtama_FormClosed
                            Me.Hide()
                            menuUtama.Show()
                        Else
                            ' Password Salah -> Increment gagal_login
                            Dim gagalBaru As Integer = gagalLogin + 1
                            Dim pesanGagal As String

                            If gagalBaru >= 5 Then
                                Const sqlLock As String =
                                    "UPDATE users SET gagal_login = @gagal, terkunci_sampai = DATE_ADD(NOW(), INTERVAL 15 MINUTE) WHERE id_user = @id"
                                Using cmdLock As New MySqlCommand(sqlLock, conn)
                                    cmdLock.Parameters.AddWithValue("@gagal", gagalBaru)
                                    cmdLock.Parameters.AddWithValue("@id", idUser)
                                    cmdLock.ExecuteNonQuery()
                                End Using
                                pesanGagal = "Password salah 5 kali berturut-turut. Akun dikunci selama 15 menit."
                            Else
                                Const sqlInc As String =
                                    "UPDATE users SET gagal_login = @gagal WHERE id_user = @id"
                                Using cmdInc As New MySqlCommand(sqlInc, conn)
                                    cmdInc.Parameters.AddWithValue("@gagal", gagalBaru)
                                    cmdInc.Parameters.AddWithValue("@id", idUser)
                                    cmdInc.ExecuteNonQuery()
                                End Using
                                pesanGagal = String.Format("Password salah. Percobaan gagal ke-{0} dari 5.", gagalBaru)
                            End If

                            lblStatus.Text = pesanGagal
                            txtPassword.Clear()
                            txtPassword.Focus()
                        End If
                    End Using
                End Using
            End Using
        End Sub

        Private Sub MenuUtama_FormClosed(sender As Object, e As FormClosedEventArgs)
            txtPassword.Clear()
            lblStatus.Text = String.Empty
            Me.Show()
            txtUsername.Focus()
        End Sub

        Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
            Application.Exit()
        End Sub

        Public Shared Function HitungSHA256(input As String) As String
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
                Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
                Dim sb As New StringBuilder()
                For Each b As Byte In hashBytes
                    sb.Append(b.ToString("x2"))
                Next
                Return sb.ToString()
            End Using
        End Function

    End Class

End Namespace

