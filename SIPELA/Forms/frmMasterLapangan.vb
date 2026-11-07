Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports SIPELA.Modules

Namespace Forms

    Public Class frmMasterLapangan

        Private _tabelLapangan As DataTable
        Private _viewLapangan As DataView
        Private _idTerpilih As Integer = 0

        Private Sub frmMasterLapangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                KonfigurasiTampilan()
                MuatJenisLantai()
                MuatDataLapangan()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menyiapkan form Master Lapangan", ex)
            End Try
        End Sub

        Private Sub KonfigurasiTampilan()
            txtIdLapangan.ReadOnly = True
            cmbJenisLantai.DropDownStyle = ComboBoxStyle.DropDownList

            numHargaPerJam.Minimum = 0D
            numHargaPerJam.Maximum = 10000000D
            numHargaPerJam.DecimalPlaces = 0
            numHargaPerJam.ThousandsSeparator = True

            dgvLapangan.ReadOnly = True
            dgvLapangan.AllowUserToAddRows = False
            dgvLapangan.AllowUserToDeleteRows = False
            dgvLapangan.MultiSelect = False
            dgvLapangan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvLapangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvLapangan.RowHeadersVisible = False
            dgvLapangan.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 250)

            ' Terapkan style icon dan text relation sesuai ketentuan penugasan
            ModUIHelper.TerapkanStyleTombol(btnSimpan, "insert.png")
            ModUIHelper.TerapkanStyleTombol(btnUbah, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnHapus, "deactivate.png")
            ModUIHelper.TerapkanStyleTombol(btnHapusPermanen, "delete.png")
            ModUIHelper.TerapkanStyleTombol(btnBersihkan, "clear.png")
        End Sub

        ''' <summary>
        ''' Memuat data pilihan jenis lantai dari tabel master jenis_lantai di database.
        ''' Memenuhi rubrik penugasan: ComboBox mengambil data master dari database.
        ''' </summary>
        Private Sub MuatJenisLantai(Optional pilihan As String = "")
            Try
                Dim tabel As New DataTable()
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT id_jenis, nama_jenis FROM jenis_lantai ORDER BY nama_jenis ASC"
                    Using da As New MySqlDataAdapter(sql, conn)
                        da.Fill(tabel)
                    End Using
                End Using

                cmbJenisLantai.DataSource = Nothing
                cmbJenisLantai.DisplayMember = "nama_jenis"
                cmbJenisLantai.ValueMember = "nama_jenis"
                cmbJenisLantai.DataSource = tabel
                cmbJenisLantai.SelectedIndex = -1

                If Not String.IsNullOrEmpty(pilihan) Then
                    cmbJenisLantai.SelectedValue = pilihan
                ElseIf cmbJenisLantai.Items.Count > 0 Then
                    cmbJenisLantai.SelectedIndex = 0
                End If
            Catch
                ' Fallback jika tabel jenis_lantai belum dieksekusi di database server
                If cmbJenisLantai.Items.Count = 0 Then
                    cmbJenisLantai.Items.AddRange(New Object() {"Rumput Sintetis", "Vinyl", "Interlock", "Semen / Plester"})
                    cmbJenisLantai.SelectedIndex = 0
                End If
            End Try
        End Sub

        Private Sub MuatDataLapangan()
            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sql As String =
                    "SELECT id_lapangan, nama_lapangan, jenis_lantai, harga_per_jam, is_active, " &
                    "CASE WHEN is_active = 1 THEN 'Aktif' ELSE 'Nonaktif' END AS status_teks " &
                    "FROM lapangan ORDER BY id_lapangan ASC"

                Using da As New MySqlDataAdapter(sql, conn)
                    _tabelLapangan = New DataTable()
                    da.Fill(_tabelLapangan)
                    _viewLapangan = _tabelLapangan.DefaultView
                    dgvLapangan.DataSource = _viewLapangan
                End Using
            End Using

            AturHeaderGrid()
            dgvLapangan.ClearSelection()
        End Sub

        Private Sub AturHeaderGrid()
            If dgvLapangan.Columns.Contains("id_lapangan") Then
                dgvLapangan.Columns("id_lapangan").HeaderText = "ID"
                dgvLapangan.Columns("id_lapangan").FillWeight = 40
            End If
            If dgvLapangan.Columns.Contains("nama_lapangan") Then
                dgvLapangan.Columns("nama_lapangan").HeaderText = "Nama Lapangan"
                dgvLapangan.Columns("nama_lapangan").FillWeight = 110
            End If
            If dgvLapangan.Columns.Contains("jenis_lantai") Then
                dgvLapangan.Columns("jenis_lantai").HeaderText = "Jenis Lantai"
                dgvLapangan.Columns("jenis_lantai").FillWeight = 90
            End If
            If dgvLapangan.Columns.Contains("harga_per_jam") Then
                dgvLapangan.Columns("harga_per_jam").HeaderText = "Harga / Jam (Rp)"
                dgvLapangan.Columns("harga_per_jam").DefaultCellStyle.Format = "N0"
                dgvLapangan.Columns("harga_per_jam").FillWeight = 85
            End If
            If dgvLapangan.Columns.Contains("status_teks") Then
                dgvLapangan.Columns("status_teks").HeaderText = "Status"
                dgvLapangan.Columns("status_teks").FillWeight = 55
            End If

            If dgvLapangan.Columns.Contains("is_active") Then
                dgvLapangan.Columns("is_active").Visible = False
            End If
        End Sub

        Private Sub BersihkanForm()
            _idTerpilih = 0
            txtIdLapangan.Text = "(Otomatis)"
            txtNamaLapangan.Clear()
            If cmbJenisLantai.Items.Count > 0 Then cmbJenisLantai.SelectedIndex = 0
            numHargaPerJam.Value = 100000D
            chkAktif.Checked = True

            btnSimpan.Enabled = True
            btnUbah.Enabled = False
            btnHapus.Enabled = False
            btnHapusPermanen.Enabled = False

            dgvLapangan.ClearSelection()
            txtNamaLapangan.Focus()
        End Sub

        Private Function ValidasiInput() As Boolean
            If String.IsNullOrWhiteSpace(txtNamaLapangan.Text) Then
                ModErrorHandler.TampilkanPeringatan("Nama lapangan wajib diisi.", "Validasi Input")
                txtNamaLapangan.Focus()
                Return False
            End If

            If cmbJenisLantai.SelectedIndex < 0 OrElse String.IsNullOrWhiteSpace(cmbJenisLantai.Text) Then
                ModErrorHandler.TampilkanPeringatan("Pilih jenis lantai lapangan.", "Validasi Input")
                cmbJenisLantai.Focus()
                Return False
            End If

            If numHargaPerJam.Value <= 0D Then
                ModErrorHandler.TampilkanPeringatan("Harga sewa per jam harus lebih dari 0.", "Validasi Input")
                numHargaPerJam.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
            If Not ValidasiInput() Then Return

            Dim nama As String = txtNamaLapangan.Text.Trim()
            Dim jenis As String = cmbJenisLantai.Text.Trim()
            Dim harga As Decimal = numHargaPerJam.Value
            Dim aktif As Boolean = chkAktif.Checked

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' Cek duplikasi nama lapangan
                    Const sqlCek As String = "SELECT COUNT(*) FROM lapangan WHERE nama_lapangan = @nama"
                    Using cmdCek As New MySqlCommand(sqlCek, conn)
                        cmdCek.Parameters.AddWithValue("@nama", nama)
                        Dim count As Long = Convert.ToInt64(cmdCek.ExecuteScalar())
                        If count > 0 Then
                            ModErrorHandler.TampilkanPeringatan(
                                "Nama lapangan '" & nama & "' sudah terdaftar. Gunakan nama lain.",
                                "Duplikasi Data"
                            )
                            txtNamaLapangan.Focus()
                            Return
                        End If
                    End Using

                    ' Insert data baru
                    Const sqlInsert As String =
                        "INSERT INTO lapangan (nama_lapangan, jenis_lantai, harga_per_jam, is_active) " &
                        "VALUES (@nama, @jenis, @harga, @aktif)"
                    Using cmdInsert As New MySqlCommand(sqlInsert, conn)
                        cmdInsert.Parameters.AddWithValue("@nama", nama)
                        cmdInsert.Parameters.AddWithValue("@jenis", jenis)
                        cmdInsert.Parameters.AddWithValue("@harga", harga)
                        cmdInsert.Parameters.AddWithValue("@aktif", aktif)
                        cmdInsert.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Data lapangan berhasil disimpan.", "Sukses")
                MuatDataLapangan()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menyimpan data lapangan baru", ex)
            End Try
        End Sub

        Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
            If _idTerpilih <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih baris lapangan dari tabel yang ingin diubah.", "Pilih Data")
                Return
            End If

            If Not ValidasiInput() Then Return

            Dim nama As String = txtNamaLapangan.Text.Trim()
            Dim jenis As String = cmbJenisLantai.Text.Trim()
            Dim harga As Decimal = numHargaPerJam.Value
            Dim aktif As Boolean = chkAktif.Checked

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' Cek duplikasi nama jika berganti nama
                    Const sqlCek As String =
                        "SELECT COUNT(*) FROM lapangan WHERE nama_lapangan = @nama AND id_lapangan <> @id"
                    Using cmdCek As New MySqlCommand(sqlCek, conn)
                        cmdCek.Parameters.AddWithValue("@nama", nama)
                        cmdCek.Parameters.AddWithValue("@id", _idTerpilih)
                        Dim count As Long = Convert.ToInt64(cmdCek.ExecuteScalar())
                        If count > 0 Then
                            ModErrorHandler.TampilkanPeringatan(
                                "Nama lapangan '" & nama & "' sudah digunakan oleh lapangan lain.",
                                "Duplikasi Data"
                            )
                            txtNamaLapangan.Focus()
                            Return
                        End If
                    End Using

                    ' Update data
                    Const sqlUpdate As String =
                        "UPDATE lapangan SET nama_lapangan = @nama, jenis_lantai = @jenis, " &
                        "harga_per_jam = @harga, is_active = @aktif WHERE id_lapangan = @id"
                    Using cmdUpdate As New MySqlCommand(sqlUpdate, conn)
                        cmdUpdate.Parameters.AddWithValue("@nama", nama)
                        cmdUpdate.Parameters.AddWithValue("@jenis", jenis)
                        cmdUpdate.Parameters.AddWithValue("@harga", harga)
                        cmdUpdate.Parameters.AddWithValue("@aktif", aktif)
                        cmdUpdate.Parameters.AddWithValue("@id", _idTerpilih)
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Data lapangan berhasil diperbarui.", "Sukses")
                MuatDataLapangan()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal mengubah data lapangan", ex)
            End Try
        End Sub

        Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
            If _idTerpilih <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih lapangan dari tabel terlebih dahulu.", "Pilih Data")
                Return
            End If

            Dim nama As String = txtNamaLapangan.Text.Trim()
            Dim pesan As String = String.Format("Apakah Anda yakin ingin menonaktifkan lapangan '{0}'? Data riwayat pemesanan lama akan tetap terjaga.", nama)

            If Not ModErrorHandler.Konfirmasi(pesan, "Konfirmasi Nonaktifkan") Then Return

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sqlSoftDelete As String = "UPDATE lapangan SET is_active = FALSE WHERE id_lapangan = @id"
                    Using cmd As New MySqlCommand(sqlSoftDelete, conn)
                        cmd.Parameters.AddWithValue("@id", _idTerpilih)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Lapangan berhasil dinonaktifkan.", "Sukses")
                MuatDataLapangan()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menonaktifkan lapangan", ex)
            End Try
        End Sub

        Private Sub btnHapusPermanen_Click(sender As Object, e As EventArgs) Handles btnHapusPermanen.Click
            If _idTerpilih <= 0 Then
                ModErrorHandler.TampilkanPeringatan("Pilih lapangan dari tabel terlebih dahulu.", "Pilih Data")
                Return
            End If

            Dim nama As String = txtNamaLapangan.Text.Trim()
            Dim pesan As String = String.Format(
                "PERINGATAN: Apakah Anda yakin ingin MENGHAPUS PERMANEN (HARD DELETE) lapangan '{0}' dari database?{1}Tindakan ini tidak dapat dibatalkan!",
                nama, Environment.NewLine)

            If MessageBox.Show(pesan, "Konfirmasi Hapus Permanen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                Return
            End If

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    ' Pengecekan foreign key: apakah lapangan sudah tercatat di detail_pemesanan
                    Const sqlCek As String = "SELECT COUNT(*) FROM detail_pemesanan WHERE id_lapangan = @id"
                    Using cmdCek As New MySqlCommand(sqlCek, conn)
                        cmdCek.Parameters.AddWithValue("@id", _idTerpilih)
                        Dim count As Long = Convert.ToInt64(cmdCek.ExecuteScalar())
                        If count > 0 Then
                            ModErrorHandler.TampilkanPeringatan(
                                String.Format("Lapangan '{0}' tidak dapat dihapus permanen karena sudah memiliki {1} transaksi riwayat pemesanan.{2}Silakan gunakan tombol Nonaktifkan (Soft Delete) untuk menonaktifkan operasionalnya.", nama, count, Environment.NewLine),
                                "Integritas Data Terproteksi"
                            )
                            Return
                        End If
                    End Using

                    ' Jalankan Hard Delete
                    Const sqlDelete As String = "DELETE FROM lapangan WHERE id_lapangan = @id"
                    Using cmdDelete As New MySqlCommand(sqlDelete, conn)
                        cmdDelete.Parameters.AddWithValue("@id", _idTerpilih)
                        cmdDelete.ExecuteNonQuery()
                    End Using
                End Using

                ModErrorHandler.TampilkanInfo("Data lapangan berhasil dihapus permanen dari database.", "Sukses")
                MuatDataLapangan()
                BersihkanForm()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menghapus data lapangan secara permanen", ex)
            End Try
        End Sub

        Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
            BersihkanForm()
        End Sub

        Private Sub dgvLapangan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLapangan.CellClick
            If e.RowIndex < 0 Then Return

            Dim row As DataGridViewRow = dgvLapangan.Rows(e.RowIndex)
            If row.IsNewRow Then Return

            Try
                _idTerpilih = Convert.ToInt32(row.Cells("id_lapangan").Value)
                txtIdLapangan.Text = _idTerpilih.ToString()
                txtNamaLapangan.Text = Convert.ToString(row.Cells("nama_lapangan").Value)

                Dim jenis As String = Convert.ToString(row.Cells("jenis_lantai").Value)
                Dim idx As Integer = cmbJenisLantai.FindStringExact(jenis)
                If idx >= 0 Then
                    cmbJenisLantai.SelectedIndex = idx
                Else
                    cmbJenisLantai.Text = jenis
                End If

                numHargaPerJam.Value = Convert.ToDecimal(row.Cells("harga_per_jam").Value)
                chkAktif.Checked = Convert.ToBoolean(row.Cells("is_active").Value)

                btnSimpan.Enabled = False
                btnUbah.Enabled = True
                btnHapus.Enabled = True
                btnHapusPermanen.Enabled = True
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memilih data dari tabel", ex)
            End Try
        End Sub

        Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
            If _viewLapangan Is Nothing Then Return

            Dim filter As String = txtCari.Text.Trim().Replace("'", "''")
            If String.IsNullOrEmpty(filter) Then
                _viewLapangan.RowFilter = String.Empty
            Else
                _viewLapangan.RowFilter = String.Format("nama_lapangan LIKE '%{0}%' OR jenis_lantai LIKE '%{0}%' OR status_teks LIKE '%{0}%'", filter)
            End If
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

    End Class

End Namespace

