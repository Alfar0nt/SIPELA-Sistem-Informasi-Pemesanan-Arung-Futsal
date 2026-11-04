Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmPemesanan
        Inherits System.Windows.Forms.Form

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.btnKembali = New System.Windows.Forms.Button()
            Me.lblSubJudul = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.pnlKiri = New System.Windows.Forms.Panel()
            Me.txtCatatan = New System.Windows.Forms.TextBox()
            Me.lblCatatan = New System.Windows.Forms.Label()
            Me.cmbLapangan = New System.Windows.Forms.ComboBox()
            Me.lblLapangan = New System.Windows.Forms.Label()
            Me.dtpTanggalMain = New System.Windows.Forms.DateTimePicker()
            Me.lblTanggalMain = New System.Windows.Forms.Label()
            Me.txtNoTelepon = New System.Windows.Forms.TextBox()
            Me.lblNoTelepon = New System.Windows.Forms.Label()
            Me.txtNamaPemesan = New System.Windows.Forms.TextBox()
            Me.lblNamaPemesan = New System.Windows.Forms.Label()
            Me.txtKodeBooking = New System.Windows.Forms.TextBox()
            Me.lblKodeBooking = New System.Windows.Forms.Label()
            Me.lblHeaderKiri = New System.Windows.Forms.Label()
            Me.pnlKanan = New System.Windows.Forms.Panel()
            Me.btnBersihkan = New System.Windows.Forms.Button()
            Me.btnSimpan = New System.Windows.Forms.Button()
            Me.pnlSummary = New System.Windows.Forms.Panel()
            Me.lblBatasBayar = New System.Windows.Forms.Label()
            Me.lblMinimalDP = New System.Windows.Forms.Label()
            Me.lblTotalSewa = New System.Windows.Forms.Label()
            Me.lblTotalJam = New System.Windows.Forms.Label()
            Me.flpSlots = New System.Windows.Forms.FlowLayoutPanel()
            Me.pnlLegend = New System.Windows.Forms.Panel()
            Me.lblLegendTerisi = New System.Windows.Forms.Label()
            Me.lblLegendTerpilih = New System.Windows.Forms.Label()
            Me.lblLegendTersedia = New System.Windows.Forms.Label()
            Me.lblHeaderKanan = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            Me.pnlKanan.SuspendLayout()
            Me.pnlSummary.SuspendLayout()
            Me.pnlLegend.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.btnKembali)
            Me.pnlHeader.Controls.Add(Me.lblSubJudul)
            Me.pnlHeader.Controls.Add(Me.lblJudul)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1084, 75)
            Me.pnlHeader.TabIndex = 0
            '
            'btnKembali
            '
            Me.btnKembali.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnKembali.BackColor = System.Drawing.Color.White
            Me.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKembali.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnKembali.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnKembali.Location = New System.Drawing.Point(950, 18)
            Me.btnKembali.Name = "btnKembali"
            Me.btnKembali.Size = New System.Drawing.Size(115, 38)
            Me.btnKembali.TabIndex = 2
            Me.btnKembali.Text = "← Kembali"
            Me.btnKembali.UseVisualStyleBackColor = False
            '
            'lblSubJudul
            '
            Me.lblSubJudul.AutoSize = True
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.lblSubJudul.Location = New System.Drawing.Point(24, 43)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(434, 17)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Pilih tanggal, lapangan, dan alokasikan slot jam bermain (08.00 - 24.00)"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(22, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(374, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "TRANSAKSI PEMESANAN LAPANGAN"
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.White
            Me.pnlKiri.Controls.Add(Me.txtCatatan)
            Me.pnlKiri.Controls.Add(Me.lblCatatan)
            Me.pnlKiri.Controls.Add(Me.cmbLapangan)
            Me.pnlKiri.Controls.Add(Me.lblLapangan)
            Me.pnlKiri.Controls.Add(Me.dtpTanggalMain)
            Me.pnlKiri.Controls.Add(Me.lblTanggalMain)
            Me.pnlKiri.Controls.Add(Me.txtNoTelepon)
            Me.pnlKiri.Controls.Add(Me.lblNoTelepon)
            Me.pnlKiri.Controls.Add(Me.txtNamaPemesan)
            Me.pnlKiri.Controls.Add(Me.lblNamaPemesan)
            Me.pnlKiri.Controls.Add(Me.txtKodeBooking)
            Me.pnlKiri.Controls.Add(Me.lblKodeBooking)
            Me.pnlKiri.Controls.Add(Me.lblHeaderKiri)
            Me.pnlKiri.Location = New System.Drawing.Point(20, 95)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlKiri.Size = New System.Drawing.Size(400, 565)
            Me.pnlKiri.TabIndex = 1
            '
            'txtCatatan
            '
            Me.txtCatatan.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtCatatan.Location = New System.Drawing.Point(21, 465)
            Me.txtCatatan.MaxLength = 255
            Me.txtCatatan.Multiline = True
            Me.txtCatatan.Name = "txtCatatan"
            Me.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtCatatan.Size = New System.Drawing.Size(355, 75)
            Me.txtCatatan.TabIndex = 12
            '
            'lblCatatan
            '
            Me.lblCatatan.AutoSize = True
            Me.lblCatatan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblCatatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblCatatan.Location = New System.Drawing.Point(18, 444)
            Me.lblCatatan.Name = "lblCatatan"
            Me.lblCatatan.Size = New System.Drawing.Size(117, 15)
            Me.lblCatatan.TabIndex = 11
            Me.lblCatatan.Text = "Catatan (Opsional):"
            '
            'cmbLapangan
            '
            Me.cmbLapangan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbLapangan.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cmbLapangan.FormattingEnabled = True
            Me.cmbLapangan.Location = New System.Drawing.Point(21, 385)
            Me.cmbLapangan.Name = "cmbLapangan"
            Me.cmbLapangan.Size = New System.Drawing.Size(355, 25)
            Me.cmbLapangan.TabIndex = 10
            '
            'lblLapangan
            '
            Me.lblLapangan.AutoSize = True
            Me.lblLapangan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblLapangan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblLapangan.Location = New System.Drawing.Point(18, 364)
            Me.lblLapangan.Name = "lblLapangan"
            Me.lblLapangan.Size = New System.Drawing.Size(107, 15)
            Me.lblLapangan.TabIndex = 9
            Me.lblLapangan.Text = "Pilihan Lapangan: *"
            '
            'dtpTanggalMain
            '
            Me.dtpTanggalMain.CustomFormat = "dddd, dd MMMM yyyy"
            Me.dtpTanggalMain.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dtpTanggalMain.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpTanggalMain.Location = New System.Drawing.Point(21, 305)
            Me.dtpTanggalMain.Name = "dtpTanggalMain"
            Me.dtpTanggalMain.Size = New System.Drawing.Size(355, 25)
            Me.dtpTanggalMain.TabIndex = 8
            '
            'lblTanggalMain
            '
            Me.lblTanggalMain.AutoSize = True
            Me.lblTanggalMain.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTanggalMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTanggalMain.Location = New System.Drawing.Point(18, 284)
            Me.lblTanggalMain.Name = "lblTanggalMain"
            Me.lblTanggalMain.Size = New System.Drawing.Size(95, 15)
            Me.lblTanggalMain.TabIndex = 7
            Me.lblTanggalMain.Text = "Tanggal Main: *"
            '
            'txtNoTelepon
            '
            Me.txtNoTelepon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNoTelepon.Location = New System.Drawing.Point(21, 225)
            Me.txtNoTelepon.MaxLength = 15
            Me.txtNoTelepon.Name = "txtNoTelepon"
            Me.txtNoTelepon.PlaceholderText = "Contoh: 08123456789"
            Me.txtNoTelepon.Size = New System.Drawing.Size(355, 25)
            Me.txtNoTelepon.TabIndex = 6
            '
            'lblNoTelepon
            '
            Me.lblNoTelepon.AutoSize = True
            Me.lblNoTelepon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblNoTelepon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblNoTelepon.Location = New System.Drawing.Point(18, 204)
            Me.lblNoTelepon.Name = "lblNoTelepon"
            Me.lblNoTelepon.Size = New System.Drawing.Size(126, 15)
            Me.lblNoTelepon.TabIndex = 5
            Me.lblNoTelepon.Text = "No. Telepon / WA: *"
            '
            'txtNamaPemesan
            '
            Me.txtNamaPemesan.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNamaPemesan.Location = New System.Drawing.Point(21, 145)
            Me.txtNamaPemesan.MaxLength = 100
            Me.txtNamaPemesan.Name = "txtNamaPemesan"
            Me.txtNamaPemesan.PlaceholderText = "Nama lengkap / nama tim pemesan"
            Me.txtNamaPemesan.Size = New System.Drawing.Size(355, 25)
            Me.txtNamaPemesan.TabIndex = 4
            '
            'lblNamaPemesan
            '
            Me.lblNamaPemesan.AutoSize = True
            Me.lblNamaPemesan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblNamaPemesan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblNamaPemesan.Location = New System.Drawing.Point(18, 124)
            Me.lblNamaPemesan.Name = "lblNamaPemesan"
            Me.lblNamaPemesan.Size = New System.Drawing.Size(106, 15)
            Me.lblNamaPemesan.TabIndex = 3
            Me.lblNamaPemesan.Text = "Nama Pemesan: *"
            '
            'txtKodeBooking
            '
            Me.txtKodeBooking.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.txtKodeBooking.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.txtKodeBooking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.txtKodeBooking.Location = New System.Drawing.Point(21, 68)
            Me.txtKodeBooking.Name = "txtKodeBooking"
            Me.txtKodeBooking.ReadOnly = True
            Me.txtKodeBooking.Size = New System.Drawing.Size(355, 26)
            Me.txtKodeBooking.TabIndex = 2
            '
            'lblKodeBooking
            '
            Me.lblKodeBooking.AutoSize = True
            Me.lblKodeBooking.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblKodeBooking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblKodeBooking.Location = New System.Drawing.Point(18, 47)
            Me.lblKodeBooking.Name = "lblKodeBooking"
            Me.lblKodeBooking.Size = New System.Drawing.Size(138, 15)
            Me.lblKodeBooking.TabIndex = 1
            Me.lblKodeBooking.Text = "Kode Booking (Sistem):"
            '
            'lblHeaderKiri
            '
            Me.lblHeaderKiri.AutoSize = True
            Me.lblHeaderKiri.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeaderKiri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblHeaderKiri.Location = New System.Drawing.Point(17, 14)
            Me.lblHeaderKiri.Name = "lblHeaderKiri"
            Me.lblHeaderKiri.Size = New System.Drawing.Size(161, 20)
            Me.lblHeaderKiri.TabIndex = 0
            Me.lblHeaderKiri.Text = "1. IDENTITAS SEWA"
            '
            'pnlKanan
            '
            Me.pnlKanan.BackColor = System.Drawing.Color.White
            Me.pnlKanan.Controls.Add(Me.btnBersihkan)
            Me.pnlKanan.Controls.Add(Me.btnSimpan)
            Me.pnlKanan.Controls.Add(Me.pnlSummary)
            Me.pnlKanan.Controls.Add(Me.flpSlots)
            Me.pnlKanan.Controls.Add(Me.pnlLegend)
            Me.pnlKanan.Controls.Add(Me.lblHeaderKanan)
            Me.pnlKanan.Location = New System.Drawing.Point(440, 95)
            Me.pnlKanan.Name = "pnlKanan"
            Me.pnlKanan.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlKanan.Size = New System.Drawing.Size(624, 565)
            Me.pnlKanan.TabIndex = 2
            '
            'btnBersihkan
            '
            Me.btnBersihkan.BackColor = System.Drawing.Color.White
            Me.btnBersihkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBersihkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBersihkan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBersihkan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnBersihkan.Location = New System.Drawing.Point(22, 505)
            Me.btnBersihkan.Name = "btnBersihkan"
            Me.btnBersihkan.Size = New System.Drawing.Size(150, 42)
            Me.btnBersihkan.TabIndex = 5
            Me.btnBersihkan.Text = "🔄 Bersihkan"
            Me.btnBersihkan.UseVisualStyleBackColor = False
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(185, 505)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.Size = New System.Drawing.Size(418, 42)
            Me.btnSimpan.TabIndex = 4
            Me.btnSimpan.Text = "💾 SIMPAN PEMESANAN"
            Me.btnSimpan.UseVisualStyleBackColor = False
            '
            'pnlSummary
            '
            Me.pnlSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlSummary.Controls.Add(Me.lblBatasBayar)
            Me.pnlSummary.Controls.Add(Me.lblMinimalDP)
            Me.pnlSummary.Controls.Add(Me.lblTotalSewa)
            Me.pnlSummary.Controls.Add(Me.lblTotalJam)
            Me.pnlSummary.Location = New System.Drawing.Point(22, 385)
            Me.pnlSummary.Name = "pnlSummary"
            Me.pnlSummary.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlSummary.Size = New System.Drawing.Size(581, 105)
            Me.pnlSummary.TabIndex = 3
            '
            'lblBatasBayar
            '
            Me.lblBatasBayar.AutoSize = True
            Me.lblBatasBayar.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
            Me.lblBatasBayar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(158, Byte), Integer))
            Me.lblBatasBayar.Location = New System.Drawing.Point(14, 75)
            Me.lblBatasBayar.Name = "lblBatasBayar"
            Me.lblBatasBayar.Size = New System.Drawing.Size(262, 15)
            Me.lblBatasBayar.TabIndex = 3
            Me.lblBatasBayar.Text = "* Batas bayar DP: 15 menit setelah pemesanan disimpan"
            '
            'lblMinimalDP
            '
            Me.lblMinimalDP.AutoSize = True
            Me.lblMinimalDP.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblMinimalDP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblMinimalDP.Location = New System.Drawing.Point(14, 45)
            Me.lblMinimalDP.Name = "lblMinimalDP"
            Me.lblMinimalDP.Size = New System.Drawing.Size(186, 19)
            Me.lblMinimalDP.TabIndex = 2
            Me.lblMinimalDP.Text = "Minimal DP (30%): Rp 0"
            '
            'lblTotalSewa
            '
            Me.lblTotalSewa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTotalSewa.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalSewa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblTotalSewa.Location = New System.Drawing.Point(280, 14)
            Me.lblTotalSewa.Name = "lblTotalSewa"
            Me.lblTotalSewa.Size = New System.Drawing.Size(285, 25)
            Me.lblTotalSewa.TabIndex = 1
            Me.lblTotalSewa.Text = "Total Sewa: Rp 0"
            Me.lblTotalSewa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalJam
            '
            Me.lblTotalJam.AutoSize = True
            Me.lblTotalJam.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblTotalJam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTotalJam.Location = New System.Drawing.Point(14, 15)
            Me.lblTotalJam.Name = "lblTotalJam"
            Me.lblTotalJam.Size = New System.Drawing.Size(126, 19)
            Me.lblTotalJam.TabIndex = 0
            Me.lblTotalJam.Text = "Total Durasi: 0 Jam"
            '
            'flpSlots
            '
            Me.flpSlots.AutoScroll = True
            Me.flpSlots.Location = New System.Drawing.Point(22, 90)
            Me.flpSlots.Name = "flpSlots"
            Me.flpSlots.Size = New System.Drawing.Size(581, 280)
            Me.flpSlots.TabIndex = 2
            '
            'pnlLegend
            '
            Me.pnlLegend.Controls.Add(Me.lblLegendTerisi)
            Me.pnlLegend.Controls.Add(Me.lblLegendTerpilih)
            Me.pnlLegend.Controls.Add(Me.lblLegendTersedia)
            Me.pnlLegend.Location = New System.Drawing.Point(22, 45)
            Me.pnlLegend.Name = "pnlLegend"
            Me.pnlLegend.Size = New System.Drawing.Size(581, 35)
            Me.pnlLegend.TabIndex = 1
            '
            'lblLegendTerisi
            '
            Me.lblLegendTerisi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
            Me.lblLegendTerisi.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendTerisi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblLegendTerisi.Location = New System.Drawing.Point(290, 4)
            Me.lblLegendTerisi.Name = "lblLegendTerisi"
            Me.lblLegendTerisi.Size = New System.Drawing.Size(135, 26)
            Me.lblLegendTerisi.TabIndex = 2
            Me.lblLegendTerisi.Text = "■ Terisi / Booked"
            Me.lblLegendTerisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLegendTerpilih
            '
            Me.lblLegendTerpilih.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.lblLegendTerpilih.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendTerpilih.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblLegendTerpilih.Location = New System.Drawing.Point(145, 4)
            Me.lblLegendTerpilih.Name = "lblLegendTerpilih"
            Me.lblLegendTerpilih.Size = New System.Drawing.Size(130, 26)
            Me.lblLegendTerpilih.TabIndex = 1
            Me.lblLegendTerpilih.Text = "■ Terpilih"
            Me.lblLegendTerpilih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLegendTersedia
            '
            Me.lblLegendTersedia.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblLegendTersedia.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendTersedia.ForeColor = System.Drawing.Color.White
            Me.lblLegendTersedia.Location = New System.Drawing.Point(4, 4)
            Me.lblLegendTersedia.Name = "lblLegendTersedia"
            Me.lblLegendTersedia.Size = New System.Drawing.Size(125, 26)
            Me.lblLegendTersedia.TabIndex = 0
            Me.lblLegendTersedia.Text = "■ Tersedia"
            Me.lblLegendTersedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblHeaderKanan
            '
            Me.lblHeaderKanan.AutoSize = True
            Me.lblHeaderKanan.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeaderKanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblHeaderKanan.Location = New System.Drawing.Point(18, 14)
            Me.lblHeaderKanan.Name = "lblHeaderKanan"
            Me.lblHeaderKanan.Size = New System.Drawing.Size(268, 20)
            Me.lblHeaderKanan.TabIndex = 0
            Me.lblHeaderKanan.Text = "2. ALOKASI SLOT WAKTU BERMAIN"
            '
            'frmPemesanan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1084, 681)
            Me.Controls.Add(Me.pnlKanan)
            Me.Controls.Add(Me.pnlKiri)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmPemesanan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SIPELA - Transaksi Pemesanan Lapangan"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlKiri.ResumeLayout(False)
            Me.pnlKiri.PerformLayout()
            Me.pnlKanan.ResumeLayout(False)
            Me.pnlKanan.PerformLayout()
            Me.pnlSummary.ResumeLayout(False)
            Me.pnlSummary.PerformLayout()
            Me.pnlLegend.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents btnKembali As System.Windows.Forms.Button
        Friend WithEvents pnlKiri As System.Windows.Forms.Panel
        Friend WithEvents lblHeaderKiri As System.Windows.Forms.Label
        Friend WithEvents lblKodeBooking As System.Windows.Forms.Label
        Friend WithEvents txtKodeBooking As System.Windows.Forms.TextBox
        Friend WithEvents lblNamaPemesan As System.Windows.Forms.Label
        Friend WithEvents txtNamaPemesan As System.Windows.Forms.TextBox
        Friend WithEvents lblNoTelepon As System.Windows.Forms.Label
        Friend WithEvents txtNoTelepon As System.Windows.Forms.TextBox
        Friend WithEvents lblTanggalMain As System.Windows.Forms.Label
        Friend WithEvents dtpTanggalMain As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblLapangan As System.Windows.Forms.Label
        Friend WithEvents cmbLapangan As System.Windows.Forms.ComboBox
        Friend WithEvents lblCatatan As System.Windows.Forms.Label
        Friend WithEvents txtCatatan As System.Windows.Forms.TextBox
        Friend WithEvents pnlKanan As System.Windows.Forms.Panel
        Friend WithEvents lblHeaderKanan As System.Windows.Forms.Label
        Friend WithEvents pnlLegend As System.Windows.Forms.Panel
        Friend WithEvents lblLegendTersedia As System.Windows.Forms.Label
        Friend WithEvents lblLegendTerpilih As System.Windows.Forms.Label
        Friend WithEvents lblLegendTerisi As System.Windows.Forms.Label
        Friend WithEvents flpSlots As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnlSummary As System.Windows.Forms.Panel
        Friend WithEvents lblTotalJam As System.Windows.Forms.Label
        Friend WithEvents lblTotalSewa As System.Windows.Forms.Label
        Friend WithEvents lblMinimalDP As System.Windows.Forms.Label
        Friend WithEvents lblBatasBayar As System.Windows.Forms.Label
        Friend WithEvents btnSimpan As System.Windows.Forms.Button
        Friend WithEvents btnBersihkan As System.Windows.Forms.Button

    End Class

End Namespace

