Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Forms

    ''' <summary>
    ''' Form Transaksi Pemesanan Lapangan (SIPELA).
    ''' Menangani pemilihan slot waktu bermain (08.00 - 24.00), pencegahan bentrok jadwal,
    ''' kalkulasi DP otomatis, dan penyimpanan transaksi sewa atomik.
    ''' </summary>
    Public Class frmPemesanan

        ''' <summary>
        ''' Model data pembantu untuk ComboBox Lapangan.
        ''' </summary>
        Private Class ItemLapangan
            Public Property Id As Integer
            Public Property Nama As String
            Public Property JenisLantai As String
            Public Property TarifPerJam As Decimal

            Public Overrides Function ToString() As String
                Return String.Format("{0} ({1}) - Rp {2:N0}/jam", Nama, JenisLantai, TarifPerJam)
            End Function
        End Class

        ' Daftar slot jam yang dipilih kasir pada transaksi saat ini (misal: 8, 9, 10)
        Private ReadOnly _slotTerpilih As New HashSet(Of Integer)()

        ' Cache tombol slot waktu (jam 8 s.d. 23)
        Private ReadOnly _tombolSlotMap As New Dictionary(Of Integer, Button)()

        Private Sub frmPemesanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Terapkan Desain Tactile Neo-Brutalism
            TerapkanTemaDesain()

            ' 2. Inisialisasi kontrol tanggal
            dtpTanggalMain.MinDate = DateTime.Today
            dtpTanggalMain.Value = DateTime.Today

            ' 3. Bangun tombol-tombol slot jam (08.00 s.d. 24.00)
            BangunGridSlot()

            ' 4. Muat daftar lapangan aktif dari database
            MuatDaftarLapangan()

            ' 5. Inisialisasi kode booking baru
            PerbaruiKodeBooking()
        End Sub

        ''' <summary>
        ''' Menerapkan styling terpusat Tactile Claymorphism + Neo-Brutalism dari ModUIHelper.
        ''' </summary>
        Private Sub TerapkanTemaDesain()
            ModUIHelper.TerapkanTemaForm(Me)
            ModUIHelper.TerapkanGayaCard(pnlKiri)
            ModUIHelper.TerapkanGayaCard(pnlKanan)
            ModUIHelper.TerapkanGayaCard(pnlSummary, ModUIHelper.ColorWarmCream)

            ModUIHelper.TerapkanGayaTombol(btnKembali, ModUIHelper.TombolTipe.OutlineWhite)
            ModUIHelper.TerapkanGayaTombol(btnSimpan, ModUIHelper.TombolTipe.PrimaryMint)
            ModUIHelper.TerapkanGayaTombol(btnBersihkan, ModUIHelper.TombolTipe.OutlineWhite)

            ModUIHelper.TerapkanBadgePill(lblLegendTersedia, ModUIHelper.ColorMintGreen, Color.White)
            ModUIHelper.TerapkanBadgePill(lblLegendTerpilih, ModUIHelper.ColorSkyBlue, ModUIHelper.ColorCrispSlate)
            ModUIHelper.TerapkanBadgePill(lblLegendTerisi, ModUIHelper.ColorCoral, ModUIHelper.ColorCrispSlate)
        End Sub

        ''' <summary>
        ''' Membangun 16 tombol slot jam dari jam 08.00 hingga 24.00 pada FlowLayoutPanel.
        ''' </summary>
        Private Sub BangunGridSlot()
            flpSlots.SuspendLayout()
            flpSlots.Controls.Clear()
            _tombolSlotMap.Clear()

            For jam As Integer = 8 To 23
                Dim slotHour As Integer = jam
                Dim labelJam As String = String.Format("{0:D2}.00 - {1:D2}.00", slotHour, slotHour + 1)

                Dim btn As New Button() With {
                    .Width = 132,
                    .Height = 44,
                    .Margin = New Padding(4),
                    .Text = labelJam,
                    .Tag = slotHour,
                    .Cursor = Cursors.Hand,
                    .FlatStyle = FlatStyle.Flat,
                    .Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
                }
                btn.FlatAppearance.BorderSize = 2
                btn.FlatAppearance.BorderColor = ModUIHelper.ColorCrispSlate

                AddHandler btn.Click, AddressOf TombolSlot_Click

                _tombolSlotMap(slotHour) = btn
                flpSlots.Controls.Add(btn)
            Next

            flpSlots.ResumeLayout()
        End Sub

        ''' <summary>
        ''' Mengambil data lapangan aktif dari MySQL dan mengisinya ke ComboBox.
        ''' </summary>
        Private Sub MuatDaftarLapangan()
            cmbLapangan.Items.Clear()

            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT id_lapangan, nama_lapangan, jenis_lantai, harga_per_jam FROM lapangan WHERE is_active = TRUE ORDER BY id_lapangan ASC;"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim item As New ItemLapangan() With {
                                    .Id = reader.GetInt32("id_lapangan"),
                                    .Nama = reader.GetString("nama_lapangan"),
                                    .JenisLantai = reader.GetString("jenis_lantai"),
                                    .TarifPerJam = reader.GetDecimal("harga_per_jam")
                                }
                                cmbLapangan.Items.Add(item)
                            End While
                        End Using
                    End Using
                End Using

                If cmbLapangan.Items.Count > 0 Then
                    cmbLapangan.SelectedIndex = 0
                Else
                    ModErrorHandler.TampilkanPeringatan("Belum ada data lapangan aktif. Harap tambahkan lapangan terlebih dahulu di Master Lapangan.", "Peringatan")
                End If

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memuat daftar lapangan", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Memperbarui kode booking acuan saat tanggal berubah.
        ''' </summary>
        Private Sub PerbaruiKodeBooking()
            Try
                txtKodeBooking.Text = ModAutoNumber.BuatKodeOtomatis("BKG", dtpTanggalMain.Value.Date)
            Catch
                txtKodeBooking.Text = String.Format("BKG-{0:yyyyMMdd}-AUTO", dtpTanggalMain.Value)
            End Try
        End Sub

        ''' <summary>
        ''' Memeriksa status ketersediaan slot dari database dan merender warna tombol slot.
        ''' </summary>
        Private Sub SegarkanStatusSlot()
            Dim lapangan As ItemLapangan = TryCast(cmbLapangan.SelectedItem, ItemLapangan)
            If lapangan Is Nothing Then Return

            Dim tanggal As Date = dtpTanggalMain.Value.Date
            Dim slotTerisi As New HashSet(Of Integer)()

            ' Query slot yang aktif dan belum kedaluwarsa pada tanggal dan lapangan terpilih
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Const sql As String = "SELECT dp.jam_mulai " &
                                          "FROM detail_pemesanan dp " &
                                          "JOIN pemesanan p ON dp.id_pemesanan = p.id_pemesanan " &
                                          "WHERE dp.id_lapangan = @id_lapangan " &
                                          "  AND dp.tanggal_main = @tanggal_main " &
                                          "  AND dp.aktif = TRUE " &
                                          "  AND p.status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas');"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id_lapangan", lapangan.Id)
                        cmd.Parameters.AddWithValue("@tanggal_main", tanggal)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                slotTerisi.Add(reader.GetInt32("jam_mulai"))
                            End While
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Memeriksa slot lapangan", ex)
                Return
            End Try

            ' Render status pada setiap tombol slot
            For Each kvp In _tombolSlotMap
                Dim jam As Integer = kvp.Key
                Dim btn As Button = kvp.Value
                Dim labelJam As String = String.Format("{0:D2}.00 - {1:D2}.00", jam, jam + 1)

                If slotTerisi.Contains(jam) Then
                    ' Slot sudah terisi orang lain
                    btn.Enabled = False
                    btn.BackColor = ModUIHelper.ColorCoral
                    btn.ForeColor = ModUIHelper.ColorCrispSlate
                    btn.Text = labelJam & vbCrLf & "(Terisi)"
                    _slotTerpilih.Remove(jam) ' Bersihkan jika sebelumnya sempat terpilih
                ElseIf _slotTerpilih.Contains(jam) Then
                    ' Slot sedang dipilih oleh kasir
                    btn.Enabled = True
                    btn.BackColor = ModUIHelper.ColorSkyBlue
                    btn.ForeColor = ModUIHelper.ColorCrispSlate
                    btn.Text = labelJam & vbCrLf & "✓ Dipilih"
                Else
                    ' Slot kosong / tersedia
                    btn.Enabled = True
                    btn.BackColor = ModUIHelper.ColorMintGreen
                    btn.ForeColor = Color.White
                    btn.Text = labelJam & vbCrLf & "Tersedia"
                End If
            Next

            HitungRingkasanBiaya()
        End Sub

        ''' <summary>
        ''' Handler klik tombol slot waktu untuk memilih/membatalkan slot sewa.
        ''' </summary>
        Private Sub TombolSlot_Click(sender As Object, e As EventArgs)
            Dim btn As Button = TryCast(sender, Button)
            If btn Is Nothing OrElse btn.Tag Is Nothing Then Return

            Dim jam As Integer = Convert.ToInt32(btn.Tag)

            If _slotTerpilih.Contains(jam) Then
                _slotTerpilih.Remove(jam)
            Else
                _slotTerpilih.Add(jam)
            End If

            SegarkanStatusSlot()
        End Sub

        ''' <summary>
        ''' Menghitung total durasi sewa, total biaya, dan minimal DP 30%.
        ''' </summary>
        Private Sub HitungRingkasanBiaya()
            Dim lapangan As ItemLapangan = TryCast(cmbLapangan.SelectedItem, ItemLapangan)
            Dim tarif As Decimal = If(lapangan IsNot Nothing, lapangan.TarifPerJam, 0D)

            Dim totalJam As Integer = _slotTerpilih.Count
            Dim totalSewa As Decimal = totalJam * tarif
            Dim minimalDP As Decimal = Math.Ceiling(totalSewa * 0.3D)

            lblTotalJam.Text = String.Format("Total Durasi: {0} Jam ({1} slot)", totalJam, totalJam)
            lblTotalSewa.Text = String.Format("Total Sewa: Rp {0:N0}", totalSewa)
            lblMinimalDP.Text = String.Format("Minimal DP (30%): Rp {0:N0}", minimalDP)
        End Sub

        Private Sub dtpTanggalMain_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalMain.ValueChanged
            _slotTerpilih.Clear()
            PerbaruiKodeBooking()
            SegarkanStatusSlot()
        End Sub

        Private Sub cmbLapangan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLapangan.SelectedIndexChanged
            _slotTerpilih.Clear()
            SegarkanStatusSlot()
        End Sub

        Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
            BersihkanForm()
        End Sub

        ''' <summary>
        ''' Mereset input form ke kondisi default.
        ''' </summary>
        Private Sub BersihkanForm()
            txtNamaPemesan.Clear()
            txtNoTelepon.Clear()
            txtCatatan.Clear()
            _slotTerpilih.Clear()
            dtpTanggalMain.Value = DateTime.Today
            If cmbLapangan.Items.Count > 0 Then cmbLapangan.SelectedIndex = 0
            PerbaruiKodeBooking()
            SegarkanStatusSlot()
            txtNamaPemesan.Focus()
        End Sub

        Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' Memproses penyimpanan transaksi pemesanan secara atomik dengan MySQL Transaction.
        ''' </summary>
        Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
            ' 1. Validasi Input
            Dim namaPemesan As String = txtNamaPemesan.Text.Trim()
            If String.IsNullOrWhiteSpace(namaPemesan) Then
                ModErrorHandler.TampilkanPeringatan("Nama Pemesan wajib diisi.", "Validasi Input")
                txtNamaPemesan.Focus()
                Return
            End If

            Dim noTelepon As String = txtNoTelepon.Text.Trim()
            If String.IsNullOrWhiteSpace(noTelepon) OrElse noTelepon.Length < 8 Then
                ModErrorHandler.TampilkanPeringatan("Nomor Telepon/WhatsApp wajib diisi valid (minimal 8 digit).", "Validasi Input")
                txtNoTelepon.Focus()
                Return
            End If

            Dim lapangan As ItemLapangan = TryCast(cmbLapangan.SelectedItem, ItemLapangan)
            If lapangan Is Nothing Then
                ModErrorHandler.TampilkanPeringatan("Silakan pilih lapangan terlebih dahulu.", "Validasi Input")
                cmbLapangan.Focus()
                Return
            End If

            If _slotTerpilih.Count = 0 Then
                ModErrorHandler.TampilkanPeringatan("Silakan pilih minimal 1 slot waktu bermain pada grid sebelah kanan.", "Validasi Input")
                Return
            End If

            ' 2. Perhitungan Nilai Transaksi
            Dim totalJam As Integer = _slotTerpilih.Count
            Dim totalSewa As Decimal = totalJam * lapangan.TarifPerJam
            Dim jumlahDP As Decimal = Math.Ceiling(totalSewa * 0.3D)
            Dim tanggalMain As Date = dtpTanggalMain.Value.Date
            Dim batasBayar As DateTime = DateTime.Now.AddMinutes(15)
            Dim idUser As Integer = If(ModSesi.IdUser > 0, ModSesi.IdUser, 1) ' Fallback ke akun sistem jika testing langsung
            Dim catatan As String = txtCatatan.Text.Trim()

            ' 3. Konfirmasi Transaksi
            Dim pesanKonfirmasi As String = String.Format(
                "Konfirmasi Pemesanan:{0}" &
                "• Pemesan: {1} ({2}){0}" &
                "• Lapangan: {3}{0}" &
                "• Tanggal: {4:dddd, dd MMMM yyyy}{0}" &
                "• Durasi: {5} Jam ({6} slot){0}" &
                "• Total Sewa: Rp {7:N0}{0}" &
                "• Wajib DP (30%): Rp {8:N0}{0}{0}" &
                "Simpan transaksi pemesanan ini?",
                Environment.NewLine, namaPemesan, noTelepon, lapangan.Nama,
                tanggalMain, totalJam, totalJam, totalSewa, jumlahDP
            )

            If Not ModErrorHandler.Konfirmasi(pesanKonfirmasi, "Konfirmasi Pemesanan Lapangan") Then
                Return
            End If

            ' 4. Eksekusi Transaksi Database Atomik
            Try
                Using conn As MySqlConnection = ModKoneksi.BukaKoneksi()
                    Using trans As MySqlTransaction = conn.BeginTransaction()
                        Try
                            ' 4a. Cek ulang bentrok slot (Concurrency Collision Check)
                            For Each slotHour In _slotTerpilih
                                Const sqlCek As String = "SELECT COUNT(*) FROM detail_pemesanan dp " &
                                                         "JOIN pemesanan p ON dp.id_pemesanan = p.id_pemesanan " &
                                                         "WHERE dp.id_lapangan = @id_lapangan " &
                                                         "  AND dp.tanggal_main = @tanggal_main " &
                                                         "  AND dp.jam_mulai = @jam_mulai " &
                                                         "  AND dp.aktif = TRUE " &
                                                         "  AND p.status_pemesanan IN ('Menunggu DP', 'DP Terbayar', 'Lunas');"

                                Using cmdCek As New MySqlCommand(sqlCek, conn, trans)
                                    cmdCek.Parameters.AddWithValue("@id_lapangan", lapangan.Id)
                                    cmdCek.Parameters.AddWithValue("@tanggal_main", tanggalMain)
                                    cmdCek.Parameters.AddWithValue("@jam_mulai", slotHour)

                                    Dim terisiCount As Long = Convert.ToInt64(cmdCek.ExecuteScalar())
                                    If terisiCount > 0 Then
                                        trans.Rollback()
                                        ModErrorHandler.TampilkanPeringatan(
                                            String.Format("Slot jam {0:D2}.00 baru saja dipesan oleh pelanggan lain. Silakan pilih slot lain.", slotHour),
                                            "Jadwal Bentrok"
                                        )
                                        SegarkanStatusSlot()
                                        Return
                                    End If
                                End Using
                            Next

                            ' 4b. Generate kode booking final atomik
                            Dim kodeBookingFinal As String = ModAutoNumber.BuatKodeOtomatis("BKG", tanggalMain)

                            ' 4c. INSERT ke tabel pemesanan
                            Const sqlPemesanan As String = "INSERT INTO pemesanan " &
                                                           "(kode_booking, id_user, nama_pemesan, no_telepon, waktu_dibuat, batas_bayar, total_sewa, jumlah_dp, status_pemesanan, catatan) " &
                                                           "VALUES (@kode_booking, @id_user, @nama_pemesan, @no_telepon, NOW(), @batas_bayar, @total_sewa, @jumlah_dp, 'Menunggu DP', @catatan);"

                            Dim idPemesananBaru As Long = 0
                            Using cmdPemesanan As New MySqlCommand(sqlPemesanan, conn, trans)
                                cmdPemesanan.Parameters.AddWithValue("@kode_booking", kodeBookingFinal)
                                cmdPemesanan.Parameters.AddWithValue("@id_user", idUser)
                                cmdPemesanan.Parameters.AddWithValue("@nama_pemesan", namaPemesan)
                                cmdPemesanan.Parameters.AddWithValue("@no_telepon", noTelepon)
                                cmdPemesanan.Parameters.AddWithValue("@batas_bayar", batasBayar)
                                cmdPemesanan.Parameters.AddWithValue("@total_sewa", totalSewa)
                                cmdPemesanan.Parameters.AddWithValue("@jumlah_dp", jumlahDP)
                                cmdPemesanan.Parameters.AddWithValue("@catatan", If(String.IsNullOrEmpty(catatan), DBNull.Value, CObj(catatan)))

                                cmdPemesanan.ExecuteNonQuery()
                                idPemesananBaru = cmdPemesanan.LastInsertedId
                            End Using

                            ' 4d. INSERT ke tabel detail_pemesanan per slot jam
                            Const sqlDetail As String = "INSERT INTO detail_pemesanan " &
                                                        "(id_pemesanan, id_lapangan, tanggal_main, jam_mulai, harga_slot, aktif) " &
                                                        "VALUES (@id_pemesanan, @id_lapangan, @tanggal_main, @jam_mulai, @harga_slot, TRUE);"

                            For Each slotHour In _slotTerpilih
                                Using cmdDetail As New MySqlCommand(sqlDetail, conn, trans)
                                    cmdDetail.Parameters.AddWithValue("@id_pemesanan", idPemesananBaru)
                                    cmdDetail.Parameters.AddWithValue("@id_lapangan", lapangan.Id)
                                    cmdDetail.Parameters.AddWithValue("@tanggal_main", tanggalMain)
                                    cmdDetail.Parameters.AddWithValue("@jam_mulai", slotHour)
                                    cmdDetail.Parameters.AddWithValue("@harga_slot", lapangan.TarifPerJam)

                                    cmdDetail.ExecuteNonQuery()
                                End Using
                            Next

                            ' 4e. Commit transaksi jika semua langkah berhasil
                            trans.Commit()

                            ModErrorHandler.TampilkanInfo(
                                String.Format(
                                    "Pemesanan berhasil disimpan!{0}{0}" &
                                    "• Kode Booking: {1}{0}" &
                                    "• Status: Menunggu DP (Rp {2:N0}){0}" &
                                    "• Batas Pembayaran DP: {3:HH:mm} WIB (15 Menit){0}{0}" &
                                    "Silakan lanjutkan ke menu Pembayaran / Kasir untuk memproses pembayaran DP.",
                                    Environment.NewLine, kodeBookingFinal, jumlahDP, batasBayar
                                ),
                                "Transaksi Berhasil"
                            )

                            BersihkanForm()

                        Catch exTrans As Exception
                            trans.Rollback()
                            Throw New InvalidOperationException("Gagal menyimpan transaksi pemesanan ke database: " & exTrans.Message, exTrans)
                        End Try
                    End Using
                End Using

            Catch ex As Exception
                ModErrorHandler.TampilkanError("Menyimpan transaksi pemesanan", ex)
            End Try
        End Sub

    End Class

End Namespace

