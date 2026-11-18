Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports SIPELA.Modules

Namespace Forms

    Partial Public Class frmPemesanan
        Inherits System.Windows.Forms.Form

        Private _tabelKeranjang As DataTable
        Private _tabelRiwayat As DataTable
        Private _viewRiwayat As DataView
        Private _tabelLapanganRef As DataTable

        Private Sub frmPemesanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                KonfigurasiTampilan()
                InisialisasiSlotJam()
                MuatMasterLapangan()
                MuatKasir()
                InisialisasiTabelKeranjang()
                ResetFormInput()
                MuatRiwayatPemesanan()
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menyiapkan Form Transaksi Pemesanan", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Mengatur styling tombol dengan icon 16x16 px dan konfigurasi DataGridView
        ''' sesuai rubrik penugasan Pemrograman Desktop Week 11.
        ''' </summary>
        Private Sub KonfigurasiTampilan()
            txtKodeBooking.ReadOnly = True
            txtTarif.ReadOnly = True
            txtSubtotal.ReadOnly = True

            cboMetodeBayar.DropDownStyle = ComboBoxStyle.DropDownList
            cboMetodeBayar.SelectedIndex = 0
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList
            cboFilterStatus.SelectedIndex = 0

            dtpTanggalMain.MinDate = DateTime.Today
            dtpTanggalMain.Value = DateTime.Today
            dtpTanggalPesan.Value = DateTime.Today

            ' Styling tombol dengan icon sesuai rubrik penugasan
            ModUIHelper.TerapkanStyleTombol(btnSaveOrder, "insert.png")
            ModUIHelper.TerapkanStyleTombol(btnNewOrder, "clear.png")
            ModUIHelper.TerapkanStyleTombol(btnAddSlot, "insert.png")
            ModUIHelper.TerapkanStyleTombol(btnClearSlot, "clear.png")
            ModUIHelper.TerapkanStyleTombol(btnLihatDetail, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnUbahStatus, "update.png")
            ModUIHelper.TerapkanStyleTombol(btnBatalkanBooking, "delete.png")
            ModUIHelper.TerapkanStyleTombol(btnRefresh, "clear.png")

            ' Konfigurasi Grid Keranjang Slot
            dgvDetail.ReadOnly = True
            dgvDetail.AllowUserToAddRows = False
            dgvDetail.AllowUserToDeleteRows = False
            dgvDetail.MultiSelect = False
            dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvDetail.RowHeadersVisible = False
            dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250)

            ' Konfigurasi Grid Riwayat Pemesanan
            dgvRiwayat.ReadOnly = True
            dgvRiwayat.AllowUserToAddRows = False
            dgvRiwayat.AllowUserToDeleteRows = False
            dgvRiwayat.MultiSelect = False
            dgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvRiwayat.RowHeadersVisible = False
            dgvRiwayat.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250)
        End Sub

        ''' <summary>
        ''' Menginisialisasi ComboBox pilihan jam operasional lapangan futsal (08:00 - 24:00)
        ''' </summary>
        Private Sub InisialisasiSlotJam()
            Dim slotTable As New DataTable()
            slotTable.Columns.Add("Jam", GetType(Byte))
            slotTable.Columns.Add("Label", GetType(String))

            For h As Integer = 8 To 23
                Dim jamEnd As Integer = (h + 1) Mod 24
                Dim label As String = String.Format("{0:D2}:00 - {1:D2}:00", h, jamEnd)
                slotTable.Rows.Add(CByte(h), label)
            Next

            cboJamMulai.DataSource = slotTable
            cboJamMulai.DisplayMember = "Label"
            cboJamMulai.ValueMember = "Jam"
            If cboJamMulai.Items.Count > 0 Then
                cboJamMulai.SelectedIndex = 0
            End If
        End Sub

        ''' <summary>
        ''' Memuat data lapangan aktif dari database untuk ComboBox Lapangan.
        ''' </summary>
        Private Sub MuatMasterLapangan()
            Try
                _tabelLapanganRef = New DataTable()
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT id_lapangan, nama_lapangan, jenis_lantai, harga_per_jam FROM lapangan WHERE is_active = TRUE ORDER BY nama_lapangan ASC"
                    Using da As New MySqlDataAdapter(sql, conn)
                        da.Fill(_tabelLapanganRef)
                    End Using
                End Using

                cboLapangan.DataSource = Nothing
                cboLapangan.DisplayMember = "nama_lapangan"
                cboLapangan.ValueMember = "id_lapangan"
                cboLapangan.DataSource = _tabelLapanganRef

                If cboLapangan.Items.Count > 0 Then
                    cboLapangan.SelectedIndex = 0
                    UpdateTarifLapanganTerpilih()
                End If
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat master lapangan", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Memuat data kasir/petugas dari database untuk ComboBox Kasir.
        ''' Default otomatis dipilih ke kasir yang sedang login di sesi.
        ''' </summary>
        Private Sub MuatKasir()
            Try
                Dim tabelKasir As New DataTable()
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT id_user, nama_lengkap FROM users WHERE is_active = TRUE ORDER BY nama_lengkap ASC"
                    Using da As New MySqlDataAdapter(sql, conn)
                        da.Fill(tabelKasir)
                    End Using
                End Using

                cboKasir.DataSource = Nothing
                cboKasir.DisplayMember = "nama_lengkap"
                cboKasir.ValueMember = "id_user"
                cboKasir.DataSource = tabelKasir

                If ModSesi.IdUser > 0 Then
                    cboKasir.SelectedValue = ModSesi.IdUser
                ElseIf cboKasir.Items.Count > 0 Then
                    cboKasir.SelectedIndex = 0
                End If
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat data petugas kasir", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Menyiapkan struktur tabel keranjang slot pemesanan (Master-Detail Keranjang)
        ''' </summary>
        Private Sub InisialisasiTabelKeranjang()
            _tabelKeranjang = New DataTable()
            _tabelKeranjang.Columns.Add("id_lapangan", GetType(Integer))
            _tabelKeranjang.Columns.Add("nama_lapangan", GetType(String))
            _tabelKeranjang.Columns.Add("tanggal_main", GetType(DateTime))
            _tabelKeranjang.Columns.Add("jam_mulai", GetType(Byte))
            _tabelKeranjang.Columns.Add("jam_display", GetType(String))
            _tabelKeranjang.Columns.Add("harga_slot", GetType(Decimal))

            dgvDetail.Columns.Clear()
            dgvDetail.DataSource = _tabelKeranjang

            ' Format kolom Grid Detail
            If dgvDetail.Columns.Contains("id_lapangan") Then dgvDetail.Columns("id_lapangan").Visible = False
            If dgvDetail.Columns.Contains("jam_mulai") Then dgvDetail.Columns("jam_mulai").Visible = False

            If dgvDetail.Columns.Contains("nama_lapangan") Then
                dgvDetail.Columns("nama_lapangan").HeaderText = "Lapangan"
                dgvDetail.Columns("nama_lapangan").FillWeight = 30
            End If

            If dgvDetail.Columns.Contains("tanggal_main") Then
                dgvDetail.Columns("tanggal_main").HeaderText = "Tgl Main"
                dgvDetail.Columns("tanggal_main").DefaultCellStyle.Format = "yyyy-MM-dd"
                dgvDetail.Columns("tanggal_main").FillWeight = 22
            End If

            If dgvDetail.Columns.Contains("jam_display") Then
                dgvDetail.Columns("jam_display").HeaderText = "Jam Operasional"
                dgvDetail.Columns("jam_display").FillWeight = 25
            End If

            If dgvDetail.Columns.Contains("harga_slot") Then
                dgvDetail.Columns("harga_slot").HeaderText = "Tarif (Rp)"
                dgvDetail.Columns("harga_slot").DefaultCellStyle.Format = "N0"
                dgvDetail.Columns("harga_slot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvDetail.Columns("harga_slot").FillWeight = 23
            End If

            ' Tambahkan tombol Hapus Item di setiap baris
            Dim btnHapusCol As New DataGridViewButtonColumn()
            btnHapusCol.Name = "colAksiHapus"
            btnHapusCol.HeaderText = "Aksi"
            btnHapusCol.Text = "Hapus"
            btnHapusCol.UseColumnTextForButtonValue = True
            btnHapusCol.FillWeight = 15
            dgvDetail.Columns.Add(btnHapusCol)
        End Sub

        Private Sub UpdateTarifLapanganTerpilih()
            If cboLapangan.SelectedValue IsNot Nothing AndAlso _tabelLapanganRef IsNot Nothing Then
                Dim val As Object = cboLapangan.SelectedValue
                Dim id As Integer
                If Integer.TryParse(val.ToString(), id) Then
                    Dim rows As DataRow() = _tabelLapanganRef.Select("id_lapangan = " & id.ToString())
                    If rows.Length > 0 Then
                        Dim tarif As Decimal = Convert.ToDecimal(rows(0)("harga_per_jam"))
                        txtTarif.Text = String.Format("Rp {0:N0}", tarif)
                        txtSubtotal.Text = String.Format("Rp {0:N0}", tarif)
                        Return
                    End If
                End If
            End If

            txtTarif.Text = "Rp 0"
            txtSubtotal.Text = "Rp 0"
        End Sub

        Private Sub cboLapangan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLapangan.SelectedIndexChanged
            UpdateTarifLapanganTerpilih()
        End Sub

        ''' <summary>
        ''' Menghitung Grand Total dan Minimum DP (30%) secara otomatis
        ''' </summary>
        Private Sub HitungGrandTotal()
            Dim total As Decimal = 0D
            If _tabelKeranjang IsNot Nothing Then
                For Each row As DataRow In _tabelKeranjang.Rows
                    total += Convert.ToDecimal(row("harga_slot"))
                Next
            End If

            Dim dp As Decimal = Math.Round(total * 0.3D, 0)

            lblGrandTotal.Text = String.Format("Rp {0:N0}", total)
            lblEstimasiDP.Text = String.Format("Rp {0:N0}", dp)
        End Sub

        ''' <summary>
        ''' Menambahkan 1 slot jadwal lapangan ke keranjang dengan validasi anti double-booking
        ''' </summary>
        Private Sub btnAddSlot_Click(sender As Object, e As EventArgs) Handles btnAddSlot.Click
            Try
                If cboLapangan.SelectedValue Is Nothing Then
                    ModErrorHandler.TampilkanPeringatan("Pilih lapangan terlebih dahulu.", "Validasi Input")
                    cboLapangan.Focus()
                    Return
                End If

                Dim idLap As Integer = Convert.ToInt32(cboLapangan.SelectedValue)
                Dim namaLap As String = cboLapangan.Text
                Dim tglMain As DateTime = dtpTanggalMain.Value.Date
                Dim jamMulai As Byte = Convert.ToByte(cboJamMulai.SelectedValue)
                Dim jamLabel As String = cboJamMulai.Text

                ' Ambil tarif slot
                Dim rows As DataRow() = _tabelLapanganRef.Select("id_lapangan = " & idLap.ToString())
                If rows.Length = 0 Then
                    ModErrorHandler.TampilkanPeringatan("Data lapangan tidak valid.", "Validasi Input")
                    Return
                End If
                Dim tarif As Decimal = Convert.ToDecimal(rows(0)("harga_per_jam"))

                ' 1. Validasi cek duplikasi di keranjang saat ini
                For Each r As DataRow In _tabelKeranjang.Rows
                    If Convert.ToInt32(r("id_lapangan")) = idLap AndAlso
                       Convert.ToDateTime(r("tanggal_main")).Date = tglMain AndAlso
                       Convert.ToByte(r("jam_mulai")) = jamMulai Then
                        ModErrorHandler.TampilkanPeringatan(
                            String.Format("Slot {0} pada {1:dd/MM/yyyy} pukul {2} sudah ada di keranjang!", namaLap, tglMain, jamLabel),
                            "Duplikasi Slot"
                        )
                        Return
                    End If
                Next

                ' 2. Validasi anti double-booking ke database
                If ApakahSlotSudahDipesan(idLap, tglMain, jamMulai) Then
                    ModErrorHandler.TampilkanPeringatan(
                        String.Format("Slot {0} pada {1:dd/MM/yyyy} pukul {2} SUDAH DIPESAN oleh pelanggan lain. Silakan pilih tanggal atau jam yang lain.", namaLap, tglMain, jamLabel),
                        "Slot Tidak Tersedia"
                    )
                    Return
                End If

                ' Tambahkan ke keranjang
                _tabelKeranjang.Rows.Add(idLap, namaLap, tglMain, jamMulai, jamLabel, tarif)
                HitungGrandTotal()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal menambahkan slot lapangan", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Memeriksa apakah slot lapangan sudah dipesan aktif di database
        ''' </summary>
        Private Function ApakahSlotSudahDipesan(idLap As Integer, tglMain As DateTime, jamMulai As Byte) As Boolean
            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Const sql As String =
                    "SELECT COUNT(*) FROM detail_pemesanan dp " &
                    "JOIN pemesanan p ON dp.id_pemesanan = p.id_pemesanan " &
                    "WHERE dp.id_lapangan = @id_lapangan " &
                    "  AND dp.tanggal_main = @tanggal_main " &
                    "  AND dp.jam_mulai = @jam_mulai " &
                    "  AND dp.aktif = TRUE " &
                    "  AND p.status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas')"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_lapangan", idLap)
                    cmd.Parameters.AddWithValue("@tanggal_main", tglMain.Date)
                    cmd.Parameters.AddWithValue("@jam_mulai", jamMulai)

                    Dim count As Long = Convert.ToInt64(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        End Function

        Private Sub btnClearSlot_Click(sender As Object, e As EventArgs) Handles btnClearSlot.Click
            If cboLapangan.Items.Count > 0 Then cboLapangan.SelectedIndex = 0
            dtpTanggalMain.Value = DateTime.Today
            If cboJamMulai.Items.Count > 0 Then cboJamMulai.SelectedIndex = 0
            UpdateTarifLapanganTerpilih()
        End Sub

        Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvDetail.Columns("colAksiHapus").Index Then
                _tabelKeranjang.Rows.RemoveAt(e.RowIndex)
                HitungGrandTotal()
            End If
        End Sub

        Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
            If _tabelKeranjang.Rows.Count > 0 Then
                If Not ModErrorHandler.Konfirmasi("Apakah Anda yakin ingin memulai order baru? Daftar slot di keranjang akan dikosongkan.", "Konfirmasi Order Baru") Then
                    Return
                End If
            End If
            ResetFormInput()
        End Sub

        Private Sub ResetFormInput()
            Try
                txtKodeBooking.Text = ModAutoNumber.BuatKodeOtomatis("BKG", DateTime.Today)
            Catch
                txtKodeBooking.Text = String.Format("BKG-{0:yyyyMMdd}-0001", DateTime.Today)
            End Try

            dtpTanggalPesan.Value = DateTime.Today
            txtNamaPemesan.Clear()
            txtNoTelepon.Clear()
            txtCatatan.Clear()
            chkDpTerbayar.Checked = True
            cboMetodeBayar.SelectedIndex = 0

            If ModSesi.IdUser > 0 Then
                cboKasir.SelectedValue = ModSesi.IdUser
            ElseIf cboKasir.Items.Count > 0 Then
                cboKasir.SelectedIndex = 0
            End If

            If _tabelKeranjang IsNot Nothing Then
                _tabelKeranjang.Clear()
            End If

            HitungGrandTotal()
            txtNamaPemesan.Focus()
        End Sub

        ''' <summary>
        ''' Menyimpan Transaksi Pemesanan (Master-Detail) secara Atomik menggunakan MySqlTransaction
        ''' </summary>
        Private Sub btnSaveOrder_Click(sender As Object, e As EventArgs) Handles btnSaveOrder.Click
            ' Validasi Input
            If String.IsNullOrWhiteSpace(txtNamaPemesan.Text) Then
                ModErrorHandler.TampilkanPeringatan("Nama pemesan wajib diisi.", "Validasi Input")
                txtNamaPemesan.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtNoTelepon.Text) Then
                ModErrorHandler.TampilkanPeringatan("Nomor telepon pemesan wajib diisi.", "Validasi Input")
                txtNoTelepon.Focus()
                Return
            End If

            If cboKasir.SelectedValue Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Pilih petugas kasir penanggung jawab transaksi.", "Validasi Input")
                cboKasir.Focus()
                Return
            End If

            If _tabelKeranjang.Rows.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Keranjang pemesanan masih kosong. Silakan tambahkan minimal 1 slot lapangan.", "Validasi Input")
                Return
            End If

            ' Hitung total sewa dan dp
            Dim totalSewa As Decimal = 0D
            For Each row As DataRow In _tabelKeranjang.Rows
                totalSewa += Convert.ToDecimal(row("harga_slot"))
            Next
            Dim jumlahDp As Decimal = Math.Round(totalSewa * 0.3D, 0)
            Dim isLangsungDp As Boolean = chkDpTerbayar.Checked
            Dim statusAwal As String = If(isLangsungDp, "DP Terbayar", "Menunggu DP")

            Dim pesanKonfirmasi As String = String.Format(
                "Konfirmasi Simpan Transaksi Pemesanan:" & Environment.NewLine &
                "- Pemesan : {0}" & Environment.NewLine &
                "- Telepon : {1}" & Environment.NewLine &
                "- Jumlah Slot : {2} slot" & Environment.NewLine &
                "- Total Sewa : Rp {3:N0}" & Environment.NewLine &
                "- Status Awal : {4}" & Environment.NewLine & Environment.NewLine &
                "Lanjutkan proses penyimpanan?",
                txtNamaPemesan.Text.Trim(),
                txtNoTelepon.Text.Trim(),
                _tabelKeranjang.Rows.Count,
                totalSewa,
                statusAwal
            )

            If Not ModErrorHandler.Konfirmasi(pesanKonfirmasi, "Konfirmasi Simpan") Then
                Return
            End If

            ' Eksekusi transaksi database secara atomik
            Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Cek ulang anti double-booking di dalam transaksi untuk semua slot yang dipilih
                        For Each r As DataRow In _tabelKeranjang.Rows
                            Dim idLap As Integer = Convert.ToInt32(r("id_lapangan"))
                            Dim tglMain As DateTime = Convert.ToDateTime(r("tanggal_main")).Date
                            Dim jamMulai As Byte = Convert.ToByte(r("jam_mulai"))

                            Const sqlCekLock As String =
                                "SELECT COUNT(*) FROM detail_pemesanan dp " &
                                "JOIN pemesanan p ON dp.id_pemesanan = p.id_pemesanan " &
                                "WHERE dp.id_lapangan = @id_lapangan " &
                                "  AND dp.tanggal_main = @tanggal_main " &
                                "  AND dp.jam_mulai = @jam_mulai " &
                                "  AND dp.aktif = TRUE " &
                                "  AND p.status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas')"

                            Using cmdCek As New MySqlCommand(sqlCekLock, conn, trans)
                                cmdCek.Parameters.AddWithValue("@id_lapangan", idLap)
                                cmdCek.Parameters.AddWithValue("@tanggal_main", tglMain)
                                cmdCek.Parameters.AddWithValue("@jam_mulai", jamMulai)

                                Dim count As Long = Convert.ToInt64(cmdCek.ExecuteScalar())
                                If count > 0 Then
                                    Throw New InvalidOperationException(
                                        String.Format("Slot lapangan {0} pada {1:dd/MM/yyyy} pukul {2} telah terisi oleh transaksi lain saat proses penyimpanan.",
                                                      r("nama_lapangan"), tglMain, r("jam_display"))
                                    )
                                End If
                            End Using
                        Next

                        ' 2. Ambil Nomor Kode Booking Atomik Final
                        Dim nomorUrut As Integer = ModAutoNumber.AmbilNomorBerikutnya(conn, "BKG", Date.Today, trans)
                        Dim kodeBookingFinal As String = String.Format("BKG-{0:yyyyMMdd}-{1:D4}", Date.Today, nomorUrut)

                        ' 3. Insert Header Pemesanan
                        Const sqlHeader As String =
                            "INSERT INTO pemesanan (kode_booking, id_user, nama_pemesan, no_telepon, waktu_dibuat, batas_bayar, total_sewa, jumlah_dp, status_pemesanan, catatan) " &
                            "VALUES (@kode, @id_user, @nama, @telepon, @waktu, @batas, @total, @dp, @status, @catatan); " &
                            "SELECT LAST_INSERT_ID();"

                        Dim idPemesanan As Integer
                        Using cmdHeader As New MySqlCommand(sqlHeader, conn, trans)
                            cmdHeader.Parameters.AddWithValue("@kode", kodeBookingFinal)
                            cmdHeader.Parameters.AddWithValue("@id_user", Convert.ToInt32(cboKasir.SelectedValue))
                            cmdHeader.Parameters.AddWithValue("@nama", txtNamaPemesan.Text.Trim())
                            cmdHeader.Parameters.AddWithValue("@telepon", txtNoTelepon.Text.Trim())
                            cmdHeader.Parameters.AddWithValue("@waktu", DateTime.Now)
                            cmdHeader.Parameters.AddWithValue("@batas", DateTime.Now.AddHours(2))
                            cmdHeader.Parameters.AddWithValue("@total", totalSewa)
                            cmdHeader.Parameters.AddWithValue("@dp", jumlahDp)
                            cmdHeader.Parameters.AddWithValue("@status", statusAwal)
                            cmdHeader.Parameters.AddWithValue("@catatan", If(String.IsNullOrWhiteSpace(txtCatatan.Text), DBNull.Value, CObj(txtCatatan.Text.Trim())))

                            idPemesanan = Convert.ToInt32(cmdHeader.ExecuteScalar())
                        End Using

                        ' 4. Insert Setiap Baris Detail Slot ke detail_pemesanan
                        Const sqlDetail As String =
                            "INSERT INTO detail_pemesanan (id_pemesanan, id_lapangan, tanggal_main, jam_mulai, harga_slot, aktif) " &
                            "VALUES (@id_pemesanan, @id_lapangan, @tanggal_main, @jam_mulai, @harga_slot, TRUE);"

                        For Each row As DataRow In _tabelKeranjang.Rows
                            Using cmdDetail As New MySqlCommand(sqlDetail, conn, trans)
                                cmdDetail.Parameters.AddWithValue("@id_pemesanan", idPemesanan)
                                cmdDetail.Parameters.AddWithValue("@id_lapangan", Convert.ToInt32(row("id_lapangan")))
                                cmdDetail.Parameters.AddWithValue("@tanggal_main", Convert.ToDateTime(row("tanggal_main")).Date)
                                cmdDetail.Parameters.AddWithValue("@jam_mulai", Convert.ToByte(row("jam_mulai")))
                                cmdDetail.Parameters.AddWithValue("@harga_slot", Convert.ToDecimal(row("harga_slot")))
                                cmdDetail.ExecuteNonQuery()
                            End Using
                        Next

                        ' 5. Jika opsi "Langsung Catat DP Terbayar" dicentang, rekam transaksi pembayaran DP
                        If isLangsungDp Then
                            Dim nomorPay As Integer = ModAutoNumber.AmbilNomorBerikutnya(conn, "PAY", Date.Today, trans)
                            Dim noTransPay As String = String.Format("PAY-{0:yyyyMMdd}-{1:D4}", Date.Today, nomorPay)
                            Dim metodeBayar As String = If(cboMetodeBayar.SelectedItem IsNot Nothing, cboMetodeBayar.SelectedItem.ToString(), "Tunai")

                            Const sqlBayar As String =
                                "INSERT INTO pembayaran (no_transaksi, id_pemesanan, id_user, jenis_pembayaran, jumlah_bayar, metode_pembayaran, waktu_bayar) " &
                                "VALUES (@no_trans, @id_pemesanan, @id_user, 'DP', @jumlah, @metode, @waktu);"

                            Using cmdBayar As New MySqlCommand(sqlBayar, conn, trans)
                                cmdBayar.Parameters.AddWithValue("@no_trans", noTransPay)
                                cmdBayar.Parameters.AddWithValue("@id_pemesanan", idPemesanan)
                                cmdBayar.Parameters.AddWithValue("@id_user", Convert.ToInt32(cboKasir.SelectedValue))
                                cmdBayar.Parameters.AddWithValue("@jumlah", jumlahDp)
                                cmdBayar.Parameters.AddWithValue("@metode", metodeBayar)
                                cmdBayar.Parameters.AddWithValue("@waktu", DateTime.Now)
                                cmdBayar.ExecuteNonQuery()
                            End Using
                        End If

                        ' Komit seluruh operasi atomik
                        trans.Commit()

                        ModErrorHandler.TampilkanInfo(
                            String.Format("Transaksi Pemesanan berhasil disimpan!" & Environment.NewLine &
                                          "Kode Booking : {0}" & Environment.NewLine &
                                          "Total Sewa   : Rp {1:N0}" & Environment.NewLine &
                                          "Status       : {2}",
                                          kodeBookingFinal, totalSewa, statusAwal),
                            "Transaksi Berhasil"
                        )

                        ResetFormInput()
                        MuatRiwayatPemesanan()

                    Catch ex As Exception
                        trans.Rollback()
                        ModErrorHandler.TampilkanError("Gagal menyimpan transaksi pemesanan. Transaksi telah dibatalkan (Rollback).", ex)
                    End Try
                End Using
            End Using
        End Sub

        ' =========================================================================
        ' TAB 2: DAFTAR & RIWAYAT PEMESANAN (READ, UPDATE, DELETE)
        ' =========================================================================

        ''' <summary>
        ''' Memuat riwayat seluruh pemesanan dari database (Read Operation)
        ''' </summary>
        Private Sub MuatRiwayatPemesanan()
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String =
                        "SELECT p.id_pemesanan, p.kode_booking, p.nama_pemesan, p.no_telepon, " &
                        "       p.waktu_dibuat, p.batas_bayar, p.total_sewa, p.jumlah_dp, " &
                        "       p.status_pemesanan, u.nama_lengkap AS kasir, p.catatan " &
                        "FROM pemesanan p " &
                        "JOIN users u ON p.id_user = u.id_user " &
                        "ORDER BY p.waktu_dibuat DESC"

                    Using da As New MySqlDataAdapter(sql, conn)
                        _tabelRiwayat = New DataTable()
                        da.Fill(_tabelRiwayat)
                        _viewRiwayat = _tabelRiwayat.DefaultView
                        dgvRiwayat.DataSource = _viewRiwayat
                    End Using
                End Using

                AturKolomGridRiwayat()
                TerapkanFilterRiwayat()

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat riwayat pemesanan", ex)
            End Try
        End Sub

        Private Sub AturKolomGridRiwayat()
            If dgvRiwayat.Columns.Contains("id_pemesanan") Then dgvRiwayat.Columns("id_pemesanan").Visible = False
            If dgvRiwayat.Columns.Contains("catatan") Then dgvRiwayat.Columns("catatan").Visible = False

            If dgvRiwayat.Columns.Contains("kode_booking") Then
                dgvRiwayat.Columns("kode_booking").HeaderText = "Kode Booking"
                dgvRiwayat.Columns("kode_booking").FillWeight = 18
            End If

            If dgvRiwayat.Columns.Contains("nama_pemesan") Then
                dgvRiwayat.Columns("nama_pemesan").HeaderText = "Pemesan"
                dgvRiwayat.Columns("nama_pemesan").FillWeight = 20
            End If

            If dgvRiwayat.Columns.Contains("no_telepon") Then
                dgvRiwayat.Columns("no_telepon").HeaderText = "No. Telepon"
                dgvRiwayat.Columns("no_telepon").FillWeight = 15
            End If

            If dgvRiwayat.Columns.Contains("waktu_dibuat") Then
                dgvRiwayat.Columns("waktu_dibuat").HeaderText = "Waktu Pesan"
                dgvRiwayat.Columns("waktu_dibuat").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                dgvRiwayat.Columns("waktu_dibuat").FillWeight = 16
            End If

            If dgvRiwayat.Columns.Contains("total_sewa") Then
                dgvRiwayat.Columns("total_sewa").HeaderText = "Total Sewa (Rp)"
                dgvRiwayat.Columns("total_sewa").DefaultCellStyle.Format = "N0"
                dgvRiwayat.Columns("total_sewa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvRiwayat.Columns("total_sewa").FillWeight = 16
            End If

            If dgvRiwayat.Columns.Contains("jumlah_dp") Then
                dgvRiwayat.Columns("jumlah_dp").HeaderText = "DP (Rp)"
                dgvRiwayat.Columns("jumlah_dp").DefaultCellStyle.Format = "N0"
                dgvRiwayat.Columns("jumlah_dp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvRiwayat.Columns("jumlah_dp").FillWeight = 14
            End If

            If dgvRiwayat.Columns.Contains("status_pemesanan") Then
                dgvRiwayat.Columns("status_pemesanan").HeaderText = "Status"
                dgvRiwayat.Columns("status_pemesanan").FillWeight = 15
            End If

            If dgvRiwayat.Columns.Contains("kasir") Then
                dgvRiwayat.Columns("kasir").HeaderText = "Kasir"
                dgvRiwayat.Columns("kasir").FillWeight = 15
            End If
        End Sub

        Private Sub TerapkanFilterRiwayat()
            If _viewRiwayat Is Nothing Then Return

            Dim keyword As String = txtCariBooking.Text.Trim().Replace("'", "''")
            Dim status As String = If(cboFilterStatus.SelectedItem IsNot Nothing, cboFilterStatus.SelectedItem.ToString(), "Semua Status")

            Dim filterParts As New Collections.Generic.List(Of String)()

            If Not String.IsNullOrEmpty(keyword) Then
                filterParts.Add(String.Format("(kode_booking LIKE '%{0}%' OR nama_pemesan LIKE '%{0}%' OR no_telepon LIKE '%{0}%' OR kasir LIKE '%{0}%')", keyword))
            End If

            If status <> "Semua Status" Then
                filterParts.Add(String.Format("status_pemesanan = '{0}'", status.Replace("'", "''")))
            End If

            _viewRiwayat.RowFilter = String.Join(" AND ", filterParts)
        End Sub

        Private Sub txtCariBooking_TextChanged(sender As Object, e As EventArgs) Handles txtCariBooking.TextChanged
            TerapkanFilterRiwayat()
        End Sub

        Private Sub cboFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterStatus.SelectedIndexChanged
            TerapkanFilterRiwayat()
        End Sub

        Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
            TerapkanFilterRiwayat()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            MuatRiwayatPemesanan()
        End Sub

        ''' <summary>
        ''' Menampilkan rincian detail slot dari transaksi pemesanan yang dipilih (Read Detail)
        ''' </summary>
        Private Sub btnLihatDetail_Click(sender As Object, e As EventArgs) Handles btnLihatDetail.Click
            If dgvRiwayat.CurrentRow Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Pilih salah satu transaksi pemesanan di tabel riwayat terlebih dahulu.", "Peringatan")
                Return
            End If

            Try
                Dim rowView As DataRowView = CType(dgvRiwayat.CurrentRow.DataBoundItem, DataRowView)
                Dim idPemesanan As Integer = Convert.ToInt32(rowView("id_pemesanan"))
                Dim kodeBooking As String = rowView("kode_booking").ToString()
                Dim namaPemesan As String = rowView("nama_pemesan").ToString()
                Dim status As String = rowView("status_pemesanan").ToString()
                Dim totalSewa As Decimal = Convert.ToDecimal(rowView("total_sewa"))
                Dim catatan As String = If(IsDBNull(rowView("catatan")), "-", rowView("catatan").ToString())

                Dim detailTeks As New System.Text.StringBuilder()
                detailTeks.AppendLine("==================================================")
                detailTeks.AppendLine(String.Format("DETAIL PEMESANAN: {0} ({1})", kodeBooking, status))
                detailTeks.AppendLine(String.Format("Nama Pemesan: {0}", namaPemesan))
                detailTeks.AppendLine(String.Format("Total Sewa  : Rp {0:N0}", totalSewa))
                detailTeks.AppendLine(String.Format("Catatan     : {0}", catatan))
                detailTeks.AppendLine("==================================================")
                detailTeks.AppendLine("Daftar Slot Lapangan:")

                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String =
                        "SELECT dp.id_detail, l.nama_lapangan, dp.tanggal_main, dp.jam_mulai, dp.harga_slot, dp.aktif " &
                        "FROM detail_pemesanan dp " &
                        "JOIN lapangan l ON dp.id_lapangan = l.id_lapangan " &
                        "WHERE dp.id_pemesanan = @id " &
                        "ORDER BY dp.tanggal_main ASC, dp.jam_mulai ASC"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id", idPemesanan)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            Dim nomor As Integer = 1
                            While reader.Read()
                                Dim jamMulai As Integer = Convert.ToInt32(reader("jam_mulai"))
                                Dim jamSelesai As Integer = (jamMulai + 1) Mod 24
                                Dim statusAktif As String = If(Convert.ToBoolean(reader("aktif")), "Aktif", "Dibatalkan")

                                detailTeks.AppendLine(String.Format(
                                    "{0}. {1} | Tgl: {2:dd/MM/yyyy} | Jam: {3:D2}:00-{4:D2}:00 | Tarif: Rp {5:N0} | [{6}]",
                                    nomor,
                                    reader("nama_lapangan"),
                                    Convert.ToDateTime(reader("tanggal_main")),
                                    jamMulai,
                                    jamSelesai,
                                    Convert.ToDecimal(reader("harga_slot")),
                                    statusAktif
                                ))
                                nomor += 1
                            End While
                        End Using
                    End Using
                End Using

                detailTeks.AppendLine("==================================================")
                ModErrorHandler.TampilkanInfo(detailTeks.ToString(), "Rincian Transaksi " & kodeBooking)

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Gagal memuat rincian detail pemesanan", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Mengubah status pemesanan atau pelunasan (Update Operation)
        ''' </summary>
        Private Sub btnUbahStatus_Click(sender As Object, e As EventArgs) Handles btnUbahStatus.Click
            If dgvRiwayat.CurrentRow Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Pilih salah satu transaksi pemesanan di tabel riwayat terlebih dahulu.", "Peringatan")
                Return
            End If

            Try
                Dim rowView As DataRowView = CType(dgvRiwayat.CurrentRow.DataBoundItem, DataRowView)
                Dim idPemesanan As Integer = Convert.ToInt32(rowView("id_pemesanan"))
                Dim kodeBooking As String = rowView("kode_booking").ToString()
                Dim statusSaatIni As String = rowView("status_pemesanan").ToString()
                Dim totalSewa As Decimal = Convert.ToDecimal(rowView("total_sewa"))
                Dim dp As Decimal = Convert.ToDecimal(rowView("jumlah_dp"))

                If statusSaatIni = "Lunas" Then
                    ModErrorHandler.TampilkanInfo("Pemesanan ini sudah berstatus LUNAS. Tidak ada perubahan status lebih lanjut.", "Informasi")
                    Return
                ElseIf statusSaatIni = "Kedaluwarsa" Then
                    ModErrorHandler.TampilkanPeringatan("Pemesanan ini sudah KEDALUWARSA / DIBATALKAN. Tidak dapat diubah statusnya.", "Peringatan")
                    Return
                End If

                Dim targetStatus As String = ""
                Dim jenisBayar As String = ""
                Dim sisaBayar As Decimal = 0D

                If statusSaatIni = "Menunggu DP" Then
                    Dim pilihan As DialogResult = MessageBox.Show(
                        String.Format("Pemesanan {0} saat ini 'Menunggu DP'." & Environment.NewLine &
                                      "Pilih aksi perubahan status:" & Environment.NewLine &
                                      "[Yes] Catat DP Terbayar (Rp {1:N0})" & Environment.NewLine &
                                      "[No] Langsung Lunas (Rp {2:N0})" & Environment.NewLine &
                                      "[Cancel] Batal", kodeBooking, dp, totalSewa),
                        "Ubah Status Transaksi",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    )

                    If pilihan = DialogResult.Yes Then
                        targetStatus = "DP Terbayar"
                        jenisBayar = "DP"
                        sisaBayar = dp
                    ElseIf pilihan = DialogResult.No Then
                        targetStatus = "Lunas"
                        jenisBayar = "Pelunasan"
                        sisaBayar = totalSewa
                    Else
                        Return
                    End If

                ElseIf statusSaatIni = "DP Terbayar" Then
                    sisaBayar = totalSewa - dp
                    If Not ModErrorHandler.Konfirmasi(
                        String.Format("Catat Pelunasan untuk pemesanan {0} sebesar Rp {1:N0} (Total Sewa: Rp {2:N0} - DP: Rp {3:N0})?",
                                      kodeBooking, sisaBayar, totalSewa, dp),
                        "Konfirmasi Pelunasan") Then
                        Return
                    End If
                    targetStatus = "Lunas"
                    jenisBayar = "Pelunasan"
                End If

                ' Eksekusi update database secara atomik
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Using trans As MySqlTransaction = conn.BeginTransaction()
                        Try
                            ' 1. Update status pemesanan
                            Const sqlUpdate As String = "UPDATE pemesanan SET status_pemesanan = @status WHERE id_pemesanan = @id;"
                            Using cmdUpd As New MySqlCommand(sqlUpdate, conn, trans)
                                cmdUpd.Parameters.AddWithValue("@status", targetStatus)
                                cmdUpd.Parameters.AddWithValue("@id", idPemesanan)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            ' 2. Catat transaksi pembayaran jika belum ada
                            Dim nomorPay As Integer = ModAutoNumber.AmbilNomorBerikutnya(conn, "PAY", Date.Today, trans)
                            Dim noTransPay As String = String.Format("PAY-{0:yyyyMMdd}-{1:D4}", Date.Today, nomorPay)
                            Dim idKasir As Integer = If(ModSesi.IdUser > 0, ModSesi.IdUser, Convert.ToInt32(rowView("kasir")))

                            Const sqlBayar As String =
                                "INSERT INTO pembayaran (no_transaksi, id_pemesanan, id_user, jenis_pembayaran, jumlah_bayar, metode_pembayaran, waktu_bayar) " &
                                "VALUES (@no_trans, @id_pemesanan, @id_user, @jenis, @jumlah, 'Tunai', @waktu) " &
                                "ON DUPLICATE KEY UPDATE jumlah_bayar = VALUES(jumlah_bayar);"

                            Using cmdBayar As New MySqlCommand(sqlBayar, conn, trans)
                                cmdBayar.Parameters.AddWithValue("@no_trans", noTransPay)
                                cmdBayar.Parameters.AddWithValue("@id_pemesanan", idPemesanan)
                                cmdBayar.Parameters.AddWithValue("@id_user", If(ModSesi.IdUser > 0, ModSesi.IdUser, 1))
                                cmdBayar.Parameters.AddWithValue("@jenis", jenisBayar)
                                cmdBayar.Parameters.AddWithValue("@jumlah", sisaBayar)
                                cmdBayar.Parameters.AddWithValue("@waktu", DateTime.Now)
                                cmdBayar.ExecuteNonQuery()
                            End Using

                            trans.Commit()
                            ModErrorHandler.TampilkanInfo(
                                String.Format("Status pemesanan {0} berhasil diubah menjadi '{1}'.", kodeBooking, targetStatus),
                                "Update Berhasil"
                            )
                            MuatRiwayatPemesanan()

                        Catch ex As Exception
                            trans.Rollback()
                            ModErrorHandler.TampilkanError("Gagal memperbarui status pemesanan", ex)
                        End Try
                    End Using
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Terjadi kesalahan saat memproses update status", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Membatalkan pemesanan atau menghapus data pemesanan (Delete Operation)
        ''' Membebaskan slot aktif sehingga dapat dipesan kembali oleh pengguna lain.
        ''' </summary>
        Private Sub btnBatalkanBooking_Click(sender As Object, e As EventArgs) Handles btnBatalkanBooking.Click
            If dgvRiwayat.CurrentRow Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Pilih salah satu transaksi pemesanan di tabel riwayat terlebih dahulu.", "Peringatan")
                Return
            End If

            Try
                Dim rowView As DataRowView = CType(dgvRiwayat.CurrentRow.DataBoundItem, DataRowView)
                Dim idPemesanan As Integer = Convert.ToInt32(rowView("id_pemesanan"))
                Dim kodeBooking As String = rowView("kode_booking").ToString()
                Dim namaPemesan As String = rowView("nama_pemesan").ToString()
                Dim statusSaatIni As String = rowView("status_pemesanan").ToString()

                Dim pesanPrompt As String = String.Format(
                    "Apakah Anda yakin ingin membatalkan booking {0} atas nama {1}?" & Environment.NewLine &
                    "Slot jadwal lapangan yang telah dipesan akan dibebaskan kembali.",
                    kodeBooking, namaPemesan
                )

                If Not ModErrorHandler.Konfirmasi(pesanPrompt, "Konfirmasi Pembatalan Booking") Then
                    Return
                End If

                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Using trans As MySqlTransaction = conn.BeginTransaction()
                        Try
                            ' Nonaktifkan slot di detail_pemesanan agar jadwal bebas kembali
                            Const sqlNonaktifSlot As String = "UPDATE detail_pemesanan SET aktif = FALSE WHERE id_pemesanan = @id;"
                            Using cmdSlot As New MySqlCommand(sqlNonaktifSlot, conn, trans)
                                cmdSlot.Parameters.AddWithValue("@id", idPemesanan)
                                cmdSlot.ExecuteNonQuery()
                            End Using

                            ' Update status pemesanan menjadi Kedaluwarsa
                            Const sqlUpdateStatus As String = "UPDATE pemesanan SET status_pemesanan = 'Kedaluwarsa' WHERE id_pemesanan = @id;"
                            Using cmdUpd As New MySqlCommand(sqlUpdateStatus, conn, trans)
                                cmdUpd.Parameters.AddWithValue("@id", idPemesanan)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            trans.Commit()
                            ModErrorHandler.TampilkanInfo(
                                String.Format("Pemesanan {0} berhasil dibatalkan dan seluruh slot jadwal telah dibebaskan.", kodeBooking),
                                "Pembatalan Berhasil"
                            )
                            MuatRiwayatPemesanan()

                        Catch ex As Exception
                            trans.Rollback()
                            ModErrorHandler.TampilkanError("Gagal membatalkan pemesanan", ex)
                        End Try
                    End Using
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Terjadi kesalahan saat memproses pembatalan", ex)
            End Try
        End Sub

    End Class

End Namespace

