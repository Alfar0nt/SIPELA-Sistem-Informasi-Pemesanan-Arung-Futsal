Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    Public Class frmMasterUsers

        Private _tabelUsers As DataTable
        Private _viewUsers As DataView
        Private _idTerpilih As Integer = 0

        Private Sub frmMasterUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                KonfigurasiTampilan()
                MuatDataUsers()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menyiapkan form Master Users", ex)
            End Try
        End Sub

        Private Sub KonfigurasiTampilan()
            txtIdUser.ReadOnly = True
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
            If cmbRole.Items.Count > 0 Then cmbRole.SelectedIndex = 0

            dgvUsers.ReadOnly = True
            dgvUsers.AllowUserToAddRows = False
            dgvUsers.AllowUserToDeleteRows = False
            dgvUsers.MultiSelect = False
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUsers.RowHeadersVisible = False
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 250)
        End Sub

        Private Sub MuatDataUsers()
            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sql As String =
                    "SELECT id_user, username, password_hash, nama_lengkap, role, is_active, " &
                    "CASE WHEN is_active = 1 THEN 'Aktif' ELSE 'Nonaktif' END AS status_teks, " &
                    "created_at FROM users ORDER BY id_user ASC"

                Using da As New MySqlDataAdapter(sql, conn)
                    _tabelUsers = New DataTable()
                    da.Fill(_tabelUsers)
                    _viewUsers = _tabelUsers.DefaultView
                    dgvUsers.DataSource = _viewUsers
                End Using
            End Using

            AturHeaderGrid()
            dgvUsers.ClearSelection()
        End Sub

        Private Sub AturHeaderGrid()
            If dgvUsers.Columns.Contains("id_user") Then
                dgvUsers.Columns("id_user").HeaderText = "ID"
                dgvUsers.Columns("id_user").FillWeight = 35
            End If
            If dgvUsers.Columns.Contains("username") Then
                dgvUsers.Columns("username").HeaderText = "Username"
                dgvUsers.Columns("username").FillWeight = 85
            End If
            If dgvUsers.Columns.Contains("nama_lengkap") Then
                dgvUsers.Columns("nama_lengkap").HeaderText = "Nama Lengkap"
                dgvUsers.Columns("nama_lengkap").FillWeight = 120
            End If
            If dgvUsers.Columns.Contains("role") Then
                dgvUsers.Columns("role").HeaderText = "Peran"
                dgvUsers.Columns("role").FillWeight = 60
            End If
            If dgvUsers.Columns.Contains("status_teks") Then
                dgvUsers.Columns("status_teks").HeaderText = "Status"
                dgvUsers.Columns("status_teks").FillWeight = 55
            End If

            ' Sembunyikan kolom sensitif dan teknis
            If dgvUsers.Columns.Contains("password_hash") Then
                dgvUsers.Columns("password_hash").Visible = False
            End If
            If dgvUsers.Columns.Contains("is_active") Then
                dgvUsers.Columns("is_active").Visible = False
            End If
            If dgvUsers.Columns.Contains("created_at") Then
                dgvUsers.Columns("created_at").Visible = False
            End If
        End Sub

        Private Sub BersihkanForm()
            _idTerpilih = 0
            txtIdUser.Text = "(Otomatis)"
            txtUsername.Clear()
            txtUsername.Enabled = True
            txtPassword.Clear()
            txtNamaLengkap.Clear()
            If cmbRole.Items.Count > 0 Then cmbRole.SelectedIndex = 0
            chkAktif.Checked = True

            btnSimpan.Enabled = True
            btnUbah.Enabled = False
            btnHapus.Enabled = False

            dgvUsers.ClearSelection()
            txtUsername.Focus()
        End Sub

        Private Function ValidasiInput(isModeTambah As Boolean) As Boolean
            Dim user As String = txtUsername.Text.Trim()
            If String.IsNullOrWhiteSpace(user) Then
                ModErrorHandler.TampilkanPeringatan("Username wajib diisi.", "Validasi Input")
                txtUsername.Focus()
                Return False
            End If

            If user.Length < 4 Then
                ModErrorHandler.TampilkanPeringatan("Username minimal 4 karakter.", "Validasi Input")
                txtUsername.Focus()
                Return False
            End If

            Dim pass As String = txtPassword.Text
            If isModeTambah Then
                If String.IsNullOrWhiteSpace(pass) Then
                    ModErrorHandler.TampilkanPeringatan("Password wajib diisi untuk pengguna baru.", "Validasi Input")
                    txtPassword.Focus()
                    Return False
                End If
                If pass.Length < 6 Then
                    ModErrorHandler.TampilkanPeringatan("Password minimal 6 karakter.", "Validasi Input")
                    txtPassword.Focus()
                    Return False
                End If
            Else
                ' Mode edit: jika password diisi, minimal 6 karakter
                If Not String.IsNullOrEmpty(pass) AndAlso pass.Length < 6 Then
                    ModErrorHandler.TampilkanPeringatan("Jika ingin mengganti password, minimal 6 karakter.", "Validasi Input")
                    txtPassword.Focus()
                    Return False
                End If
            End If

            If String.IsNullOrWhiteSpace(txtNamaLengkap.Text) Then
                ModErrorHandler.TampilkanPeringatan("Nama lengkap wajib diisi.", "Validasi Input")
                txtNamaLengkap.Focus()
                Return False
            End If

            If cmbRole.SelectedIndex < 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih peran (Role) pengguna.", "Validasi Input")
                cmbRole.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
            If Not ValidasiInput(True) Then Return

            Dim user As String = txtUsername.Text.Trim()
            Dim passHash As String = frmLogin.HitungSHA256(txtPassword.Text)
            Dim nama As String = txtNamaLengkap.Text.Trim()
            Dim role As String = cmbRole.Text.Trim()
            Dim aktif As Boolean = chkAktif.Checked

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' Cek duplikasi username
                    Const sqlCek As String = "SELECT COUNT(*) FROM users WHERE username = @user"
                    Using cmdCek As New MySqlCommand(sqlCek, conn)
                        cmdCek.Parameters.AddWithValue("@user", user)
                        If Convert.ToInt64(cmdCek.ExecuteScalar()) > 0 Then
                            ModErrorHandler.TampilkanPeringatan(
                                "Username '" & user & "' sudah digunakan. Pilih username lain.",
                                "Duplikasi Data"
                            )
                            txtUsername.Focus()
                            Return
                        End If
                    End Using

                    ' Insert user baru
                    Const sqlInsert As String =
                        "INSERT INTO users (username, password_hash, nama_lengkap, role, is_active) " &
                        "VALUES (@user, @hash, @nama, @role, @aktif)"
                    Using cmdInsert As New MySqlCommand(sqlInsert, conn)
                        cmdInsert.Parameters.AddWithValue("@user", user)
                        cmdInsert.Parameters.AddWithValue("@hash", passHash)
                        cmdInsert.Parameters.AddWithValue("@nama", nama)
                        cmdInsert.Parameters.AddWithValue("@role", role)
                        cmdInsert.Parameters.AddWithValue("@aktif", aktif)
                        cmdInsert.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Pengguna baru berhasil ditambahkan.", "Sukses")
                MuatDataUsers()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menambahkan pengguna baru", ex)
            End Try
        End Sub

        Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
            If _idTerpilih <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih pengguna dari tabel yang ingin diubah.", "Pilih Data")
                Return
            End If

            If Not ValidasiInput(False) Then Return

            Dim user As String = txtUsername.Text.Trim()
            Dim passBaru As String = txtPassword.Text
            Dim nama As String = txtNamaLengkap.Text.Trim()
            Dim role As String = cmbRole.Text.Trim()
            Dim aktif As Boolean = chkAktif.Checked

            ' Cegah menonaktifkan akun sendiri
            If _idTerpilih = ModSesi.IdUser AndAlso Not aktif Then
                ModErrorHandler.TampilkanPeringatan("Anda tidak dapat menonaktifkan akun Anda sendiri yang sedang aktif login.", "Aksi Ditolak")
                chkAktif.Checked = True
                Return
            End If

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' Cek duplikasi username jika username diganti
                    Const sqlCek As String = "SELECT COUNT(*) FROM users WHERE username = @user AND id_user <> @id"
                    Using cmdCek As New MySqlCommand(sqlCek, conn)
                        cmdCek.Parameters.AddWithValue("@user", user)
                        cmdCek.Parameters.AddWithValue("@id", _idTerpilih)
                        If Convert.ToInt64(cmdCek.ExecuteScalar()) > 0 Then
                            ModErrorHandler.TampilkanPeringatan(
                                "Username '" & user & "' sudah digunakan oleh pengguna lain.",
                                "Duplikasi Data"
                            )
                            txtUsername.Focus()
                            Return
                        End If
                    End Using

                    ' Update data: bedakan jika password diganti atau tidak
                    Dim sqlUpdate As String
                    If Not String.IsNullOrEmpty(passBaru) Then
                        sqlUpdate =
                            "UPDATE users SET username = @user, password_hash = @hash, nama_lengkap = @nama, " &
                            "role = @role, is_active = @aktif WHERE id_user = @id"
                    Else
                        sqlUpdate =
                            "UPDATE users SET username = @user, nama_lengkap = @nama, " &
                            "role = @role, is_active = @aktif WHERE id_user = @id"
                    End If

                    Using cmdUpdate As New MySqlCommand(sqlUpdate, conn)
                        cmdUpdate.Parameters.AddWithValue("@user", user)
                        If Not String.IsNullOrEmpty(passBaru) Then
                            cmdUpdate.Parameters.AddWithValue("@hash", frmLogin.HitungSHA256(passBaru))
                        End If
                        cmdUpdate.Parameters.AddWithValue("@nama", nama)
                        cmdUpdate.Parameters.AddWithValue("@role", role)
                        cmdUpdate.Parameters.AddWithValue("@aktif", aktif)
                        cmdUpdate.Parameters.AddWithValue("@id", _idTerpilih)
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Data pengguna berhasil diperbarui.", "Sukses")
                MuatDataUsers()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memperbarui data pengguna", ex)
            End Try
        End Sub

        Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
            If _idTerpilih <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih pengguna dari tabel terlebih dahulu.", "Pilih Data")
                Return
            End If

            If _idTerpilih = ModSesi.IdUser Then
                ModErrorHandler.TampilkanPeringatan("Anda tidak dapat menonaktifkan akun Anda sendiri yang sedang aktif login.", "Aksi Ditolak")
                Return
            End If

            Dim user As String = txtUsername.Text.Trim()
            Dim pesan As String = String.Format("Apakah Anda yakin ingin menonaktifkan akun '{0}'? Pengguna tidak akan dapat login lagi.", user)

            If Not ModErrorHandler.Konfirmasi(pesan, "Konfirmasi Nonaktifkan Pengguna") Then Return

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sqlSoftDelete As String = "UPDATE users SET is_active = FALSE WHERE id_user = @id"
                    Using cmd As New MySqlCommand(sqlSoftDelete, conn)
                        cmd.Parameters.AddWithValue("@id", _idTerpilih)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Akun pengguna berhasil dinonaktifkan.", "Sukses")
                MuatDataUsers()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menonaktifkan pengguna", ex)
            End Try
        End Sub

        Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
            BersihkanForm()
        End Sub

        Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
            If e.RowIndex < 0 Then Return

            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            If row.IsNewRow Then Return

            Try
                _idTerpilih = Convert.ToInt32(row.Cells("id_user").Value)
                txtIdUser.Text = _idTerpilih.ToString()
                txtUsername.Text = Convert.ToString(row.Cells("username").Value)
                txtPassword.Clear() ' Kosongkan password untuk alasan keamanan
                txtNamaLengkap.Text = Convert.ToString(row.Cells("nama_lengkap").Value)

                Dim role As String = Convert.ToString(row.Cells("role").Value)
                Dim idx As Integer = cmbRole.FindStringExact(role)
                If idx >= 0 Then
                    cmbRole.SelectedIndex = idx
                Else
                    cmbRole.Text = role
                End If

                chkAktif.Checked = Convert.ToBoolean(row.Cells("is_active").Value)

                btnSimpan.Enabled = False
                btnUbah.Enabled = True
                btnHapus.Enabled = True
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memilih data pengguna dari tabel", ex)
            End Try
        End Sub

        Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
            If _viewUsers Is Nothing Then Return

            Dim filter As String = txtCari.Text.Trim().Replace("'", "''")
            If String.IsNullOrEmpty(filter) Then
                _viewUsers.RowFilter = String.Empty
            Else
                _viewUsers.RowFilter = String.Format("username LIKE '%{0}%' OR nama_lengkap LIKE '%{0}%' OR role LIKE '%{0}%' OR status_teks LIKE '%{0}%'", filter)
            End If
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

    End Class

End Namespace

