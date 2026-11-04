Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmPembayaran
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
            Me.pnlInfoBooking = New System.Windows.Forms.Panel()
            Me.lblStatusPemesanan = New System.Windows.Forms.Label()
            Me.lblValSisaTagihan = New System.Windows.Forms.Label()
            Me.lblValTotalSewa = New System.Windows.Forms.Label()
            Me.lblValJadwal = New System.Windows.Forms.Label()
            Me.lblValPemesan = New System.Windows.Forms.Label()
            Me.lblValKodeBooking = New System.Windows.Forms.Label()
            Me.lblHeaderDetail = New System.Windows.Forms.Label()
            Me.dgvBooking = New System.Windows.Forms.DataGridView()
            Me.btnSegarkan = New System.Windows.Forms.Button()
            Me.btnCari = New System.Windows.Forms.Button()
            Me.txtCari = New System.Windows.Forms.TextBox()
            Me.lblCari = New System.Windows.Forms.Label()
            Me.lblHeaderKiri = New System.Windows.Forms.Label()
            Me.pnlKanan = New System.Windows.Forms.Panel()
            Me.btnCetakUlang = New System.Windows.Forms.Button()
            Me.btnBersihkan = New System.Windows.Forms.Button()
            Me.btnProsesBayar = New System.Windows.Forms.Button()
            Me.pnlKembalian = New System.Windows.Forms.Panel()
            Me.lblValKembalian = New System.Windows.Forms.Label()
            Me.lblKembalian = New System.Windows.Forms.Label()
            Me.pnlQuickButtons = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnUangPas = New System.Windows.Forms.Button()
            Me.btn50k = New System.Windows.Forms.Button()
            Me.btn100k = New System.Windows.Forms.Button()
            Me.btn200k = New System.Windows.Forms.Button()
            Me.txtJumlahBayar = New System.Windows.Forms.TextBox()
            Me.lblJumlahBayar = New System.Windows.Forms.Label()
            Me.txtJumlahTagihan = New System.Windows.Forms.TextBox()
            Me.lblJumlahTagihan = New System.Windows.Forms.Label()
            Me.cmbMetodePembayaran = New System.Windows.Forms.ComboBox()
            Me.lblMetodePembayaran = New System.Windows.Forms.Label()
            Me.cmbJenisPembayaran = New System.Windows.Forms.ComboBox()
            Me.lblJenisPembayaran = New System.Windows.Forms.Label()
            Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
            Me.lblNoTransaksi = New System.Windows.Forms.Label()
            Me.lblHeaderKanan = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            Me.pnlInfoBooking.SuspendLayout()
            CType(Me.dgvBooking, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlKanan.SuspendLayout()
            Me.pnlKembalian.SuspendLayout()
            Me.pnlQuickButtons.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(1104, 75)
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
            Me.btnKembali.Location = New System.Drawing.Point(970, 18)
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
            Me.lblSubJudul.Size = New System.Drawing.Size(437, 17)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Pencatatan kasir untuk Uang Muka (DP), pelunasan, dan pencetakan nota"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(22, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(306, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "KASIR & PEMBAYARAN SEWA"
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.White
            Me.pnlKiri.Controls.Add(Me.pnlInfoBooking)
            Me.pnlKiri.Controls.Add(Me.dgvBooking)
            Me.pnlKiri.Controls.Add(Me.btnSegarkan)
            Me.pnlKiri.Controls.Add(Me.btnCari)
            Me.pnlKiri.Controls.Add(Me.txtCari)
            Me.pnlKiri.Controls.Add(Me.lblCari)
            Me.pnlKiri.Controls.Add(Me.lblHeaderKiri)
            Me.pnlKiri.Location = New System.Drawing.Point(20, 95)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlKiri.Size = New System.Drawing.Size(580, 570)
            Me.pnlKiri.TabIndex = 1
            '
            'pnlInfoBooking
            '
            Me.pnlInfoBooking.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.pnlInfoBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlInfoBooking.Controls.Add(Me.lblStatusPemesanan)
            Me.pnlInfoBooking.Controls.Add(Me.lblValSisaTagihan)
            Me.pnlInfoBooking.Controls.Add(Me.lblValTotalSewa)
            Me.pnlInfoBooking.Controls.Add(Me.lblValJadwal)
            Me.pnlInfoBooking.Controls.Add(Me.lblValPemesan)
            Me.pnlInfoBooking.Controls.Add(Me.lblValKodeBooking)
            Me.pnlInfoBooking.Controls.Add(Me.lblHeaderDetail)
            Me.pnlInfoBooking.Location = New System.Drawing.Point(16, 385)
            Me.pnlInfoBooking.Name = "pnlInfoBooking"
            Me.pnlInfoBooking.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlInfoBooking.Size = New System.Drawing.Size(548, 168)
            Me.pnlInfoBooking.TabIndex = 6
            '
            'lblStatusPemesanan
            '
            Me.lblStatusPemesanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.lblStatusPemesanan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatusPemesanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblStatusPemesanan.Location = New System.Drawing.Point(390, 10)
            Me.lblStatusPemesanan.Name = "lblStatusPemesanan"
            Me.lblStatusPemesanan.Size = New System.Drawing.Size(145, 26)
            Me.lblStatusPemesanan.TabIndex = 6
            Me.lblStatusPemesanan.Text = "Status: -"
            Me.lblStatusPemesanan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblValSisaTagihan
            '
            Me.lblValSisaTagihan.AutoSize = True
            Me.lblValSisaTagihan.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblValSisaTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.lblValSisaTagihan.Location = New System.Drawing.Point(290, 133)
            Me.lblValSisaTagihan.Name = "lblValSisaTagihan"
            Me.lblValSisaTagihan.Size = New System.Drawing.Size(126, 19)
            Me.lblValSisaTagihan.TabIndex = 5
            Me.lblValSisaTagihan.Text = "Sisa Tagihan: Rp 0"
            '
            'lblValTotalSewa
            '
            Me.lblValTotalSewa.AutoSize = True
            Me.lblValTotalSewa.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblValTotalSewa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValTotalSewa.Location = New System.Drawing.Point(12, 133)
            Me.lblValTotalSewa.Name = "lblValTotalSewa"
            Me.lblValTotalSewa.Size = New System.Drawing.Size(117, 19)
            Me.lblValTotalSewa.TabIndex = 4
            Me.lblValTotalSewa.Text = "Total Sewa: Rp 0"
            '
            'lblValJadwal
            '
            Me.lblValJadwal.AutoSize = True
            Me.lblValJadwal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblValJadwal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValJadwal.Location = New System.Drawing.Point(12, 102)
            Me.lblValJadwal.Name = "lblValJadwal"
            Me.lblValJadwal.Size = New System.Drawing.Size(91, 15)
            Me.lblValJadwal.TabIndex = 3
            Me.lblValJadwal.Text = "Jadwal Main: - "
            '
            'lblValPemesan
            '
            Me.lblValPemesan.AutoSize = True
            Me.lblValPemesan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblValPemesan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValPemesan.Location = New System.Drawing.Point(12, 73)
            Me.lblValPemesan.Name = "lblValPemesan"
            Me.lblValPemesan.Size = New System.Drawing.Size(96, 15)
            Me.lblValPemesan.TabIndex = 2
            Me.lblValPemesan.Text = "Pemesan: - ( - )"
            '
            'lblValKodeBooking
            '
            Me.lblValKodeBooking.AutoSize = True
            Me.lblValKodeBooking.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblValKodeBooking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValKodeBooking.Location = New System.Drawing.Point(12, 43)
            Me.lblValKodeBooking.Name = "lblValKodeBooking"
            Me.lblValKodeBooking.Size = New System.Drawing.Size(126, 19)
            Me.lblValKodeBooking.TabIndex = 1
            Me.lblValKodeBooking.Text = "Kode Booking: - "
            '
            'lblHeaderDetail
            '
            Me.lblHeaderDetail.AutoSize = True
            Me.lblHeaderDetail.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblHeaderDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblHeaderDetail.Location = New System.Drawing.Point(12, 12)
            Me.lblHeaderDetail.Name = "lblHeaderDetail"
            Me.lblHeaderDetail.Size = New System.Drawing.Size(201, 17)
            Me.lblHeaderDetail.TabIndex = 0
            Me.lblHeaderDetail.Text = "DETAIL TAGIHAN TERPILIH"
            '
            'dgvBooking
            '
            Me.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvBooking.Location = New System.Drawing.Point(16, 85)
            Me.dgvBooking.Name = "dgvBooking"
            Me.dgvBooking.Size = New System.Drawing.Size(548, 285)
            Me.dgvBooking.TabIndex = 5
            '
            'btnSegarkan
            '
            Me.btnSegarkan.BackColor = System.Drawing.Color.White
            Me.btnSegarkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSegarkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSegarkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnSegarkan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnSegarkan.Location = New System.Drawing.Point(479, 43)
            Me.btnSegarkan.Name = "btnSegarkan"
            Me.btnSegarkan.Size = New System.Drawing.Size(85, 30)
            Me.btnSegarkan.TabIndex = 4
            Me.btnSegarkan.Text = "Segarkan"
            Me.btnSegarkan.UseVisualStyleBackColor = False
            '
            'btnCari
            '
            Me.btnCari.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCari.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnCari.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnCari.Location = New System.Drawing.Point(398, 43)
            Me.btnCari.Name = "btnCari"
            Me.btnCari.Size = New System.Drawing.Size(75, 30)
            Me.btnCari.TabIndex = 3
            Me.btnCari.Text = "Cari"
            Me.btnCari.UseVisualStyleBackColor = False
            '
            'txtCari
            '
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtCari.Location = New System.Drawing.Point(16, 46)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Ketik Kode Booking atau Nama Pemesan..."
            Me.txtCari.Size = New System.Drawing.Size(376, 25)
            Me.txtCari.TabIndex = 2
            '
            'lblCari
            '
            Me.lblCari.AutoSize = True
            Me.lblCari.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblCari.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblCari.Location = New System.Drawing.Point(13, 27)
            Me.lblCari.Name = "lblCari"
            Me.lblCari.Size = New System.Drawing.Size(124, 15)
            Me.lblCari.TabIndex = 1
            Me.lblCari.Text = "Cari Data Pemesanan:"
            '
            'lblHeaderKiri
            '
            Me.lblHeaderKiri.AutoSize = True
            Me.lblHeaderKiri.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeaderKiri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblHeaderKiri.Location = New System.Drawing.Point(12, 7)
            Me.lblHeaderKiri.Name = "lblHeaderKiri"
            Me.lblHeaderKiri.Size = New System.Drawing.Size(201, 20)
            Me.lblHeaderKiri.TabIndex = 0
            Me.lblHeaderKiri.Text = "1. DAFTAR TAGIHAN SEWA"
            '
            'pnlKanan
            '
            Me.pnlKanan.BackColor = System.Drawing.Color.White
            Me.pnlKanan.Controls.Add(Me.btnCetakUlang)
            Me.pnlKanan.Controls.Add(Me.btnBersihkan)
            Me.pnlKanan.Controls.Add(Me.btnProsesBayar)
            Me.pnlKanan.Controls.Add(Me.pnlKembalian)
            Me.pnlKanan.Controls.Add(Me.pnlQuickButtons)
            Me.pnlKanan.Controls.Add(Me.txtJumlahBayar)
            Me.pnlKanan.Controls.Add(Me.lblJumlahBayar)
            Me.pnlKanan.Controls.Add(Me.txtJumlahTagihan)
            Me.pnlKanan.Controls.Add(Me.lblJumlahTagihan)
            Me.pnlKanan.Controls.Add(Me.cmbMetodePembayaran)
            Me.pnlKanan.Controls.Add(Me.lblMetodePembayaran)
            Me.pnlKanan.Controls.Add(Me.cmbJenisPembayaran)
            Me.pnlKanan.Controls.Add(Me.lblJenisPembayaran)
            Me.pnlKanan.Controls.Add(Me.txtNoTransaksi)
            Me.pnlKanan.Controls.Add(Me.lblNoTransaksi)
            Me.pnlKanan.Controls.Add(Me.lblHeaderKanan)
            Me.pnlKanan.Location = New System.Drawing.Point(620, 95)
            Me.pnlKanan.Name = "pnlKanan"
            Me.pnlKanan.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlKanan.Size = New System.Drawing.Size(464, 570)
            Me.pnlKanan.TabIndex = 2
            '
            'btnCetakUlang
            '
            Me.btnCetakUlang.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.btnCetakUlang.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakUlang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetakUlang.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnCetakUlang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnCetakUlang.Location = New System.Drawing.Point(180, 518)
            Me.btnCetakUlang.Name = "btnCetakUlang"
            Me.btnCetakUlang.Size = New System.Drawing.Size(263, 36)
            Me.btnCetakUlang.TabIndex = 15
            Me.btnCetakUlang.Text = "🖨️ Cetak Ulang Nota Terakhir"
            Me.btnCetakUlang.UseVisualStyleBackColor = False
            '
            'btnBersihkan
            '
            Me.btnBersihkan.BackColor = System.Drawing.Color.White
            Me.btnBersihkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBersihkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBersihkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnBersihkan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnBersihkan.Location = New System.Drawing.Point(21, 518)
            Me.btnBersihkan.Name = "btnBersihkan"
            Me.btnBersihkan.Size = New System.Drawing.Size(145, 36)
            Me.btnBersihkan.TabIndex = 14
            Me.btnBersihkan.Text = "🔄 Reset"
            Me.btnBersihkan.UseVisualStyleBackColor = False
            '
            'btnProsesBayar
            '
            Me.btnProsesBayar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.btnProsesBayar.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnProsesBayar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnProsesBayar.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnProsesBayar.ForeColor = System.Drawing.Color.White
            Me.btnProsesBayar.Location = New System.Drawing.Point(21, 465)
            Me.btnProsesBayar.Name = "btnProsesBayar"
            Me.btnProsesBayar.Size = New System.Drawing.Size(422, 45)
            Me.btnProsesBayar.TabIndex = 13
            Me.btnProsesBayar.Text = "💰 PROSES BAYAR & CETAK NOTA"
            Me.btnProsesBayar.UseVisualStyleBackColor = False
            '
            'pnlKembalian
            '
            Me.pnlKembalian.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.pnlKembalian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlKembalian.Controls.Add(Me.lblValKembalian)
            Me.pnlKembalian.Controls.Add(Me.lblKembalian)
            Me.pnlKembalian.Location = New System.Drawing.Point(21, 400)
            Me.pnlKembalian.Name = "pnlKembalian"
            Me.pnlKembalian.Padding = New System.Windows.Forms.Padding(8)
            Me.pnlKembalian.Size = New System.Drawing.Size(422, 50)
            Me.pnlKembalian.TabIndex = 12
            '
            'lblValKembalian
            '
            Me.lblValKembalian.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValKembalian.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblValKembalian.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValKembalian.Location = New System.Drawing.Point(165, 12)
            Me.lblValKembalian.Name = "lblValKembalian"
            Me.lblValKembalian.Size = New System.Drawing.Size(245, 25)
            Me.lblValKembalian.TabIndex = 1
            Me.lblValKembalian.Text = "Rp 0"
            Me.lblValKembalian.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblKembalian
            '
            Me.lblKembalian.AutoSize = True
            Me.lblKembalian.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblKembalian.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblKembalian.Location = New System.Drawing.Point(8, 14)
            Me.lblKembalian.Name = "lblKembalian"
            Me.lblKembalian.Size = New System.Drawing.Size(117, 19)
            Me.lblKembalian.TabIndex = 0
            Me.lblKembalian.Text = "Uang Kembalian:"
            '
            'pnlQuickButtons
            '
            Me.pnlQuickButtons.Controls.Add(Me.btnUangPas)
            Me.pnlQuickButtons.Controls.Add(Me.btn50k)
            Me.pnlQuickButtons.Controls.Add(Me.btn100k)
            Me.pnlQuickButtons.Controls.Add(Me.btn200k)
            Me.pnlQuickButtons.Location = New System.Drawing.Point(21, 350)
            Me.pnlQuickButtons.Name = "pnlQuickButtons"
            Me.pnlQuickButtons.Size = New System.Drawing.Size(422, 40)
            Me.pnlQuickButtons.TabIndex = 11
            '
            'btnUangPas
            '
            Me.btnUangPas.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.btnUangPas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUangPas.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btnUangPas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnUangPas.Location = New System.Drawing.Point(3, 3)
            Me.btnUangPas.Name = "btnUangPas"
            Me.btnUangPas.Size = New System.Drawing.Size(95, 32)
            Me.btnUangPas.TabIndex = 0
            Me.btnUangPas.Text = "Uang Pas"
            Me.btnUangPas.UseVisualStyleBackColor = False
            '
            'btn50k
            '
            Me.btn50k.BackColor = System.Drawing.Color.White
            Me.btn50k.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn50k.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btn50k.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btn50k.Location = New System.Drawing.Point(104, 3)
            Me.btn50k.Name = "btn50k"
            Me.btn50k.Size = New System.Drawing.Size(95, 32)
            Me.btn50k.TabIndex = 1
            Me.btn50k.Text = "50.000"
            Me.btn50k.UseVisualStyleBackColor = False
            '
            'btn100k
            '
            Me.btn100k.BackColor = System.Drawing.Color.White
            Me.btn100k.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn100k.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btn100k.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btn100k.Location = New System.Drawing.Point(205, 3)
            Me.btn100k.Name = "btn100k"
            Me.btn100k.Size = New System.Drawing.Size(95, 32)
            Me.btn100k.TabIndex = 2
            Me.btn100k.Text = "100.000"
            Me.btn100k.UseVisualStyleBackColor = False
            '
            'btn200k
            '
            Me.btn200k.BackColor = System.Drawing.Color.White
            Me.btn200k.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn200k.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btn200k.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btn200k.Location = New System.Drawing.Point(306, 3)
            Me.btn200k.Name = "btn200k"
            Me.btn200k.Size = New System.Drawing.Size(95, 32)
            Me.btn200k.TabIndex = 3
            Me.btn200k.Text = "200.000"
            Me.btn200k.UseVisualStyleBackColor = False
            '
            'txtJumlahBayar
            '
            Me.txtJumlahBayar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.txtJumlahBayar.Location = New System.Drawing.Point(21, 312)
            Me.txtJumlahBayar.Name = "txtJumlahBayar"
            Me.txtJumlahBayar.Size = New System.Drawing.Size(422, 29)
            Me.txtJumlahBayar.TabIndex = 10
            '
            'lblJumlahBayar
            '
            Me.lblJumlahBayar.AutoSize = True
            Me.lblJumlahBayar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJumlahBayar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblJumlahBayar.Location = New System.Drawing.Point(18, 293)
            Me.lblJumlahBayar.Name = "lblJumlahBayar"
            Me.lblJumlahBayar.Size = New System.Drawing.Size(188, 15)
            Me.lblJumlahBayar.TabIndex = 9
            Me.lblJumlahBayar.Text = "Jumlah Diterima dari Pelanggan: *"
            '
            'txtJumlahTagihan
            '
            Me.txtJumlahTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.txtJumlahTagihan.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.txtJumlahTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.txtJumlahTagihan.Location = New System.Drawing.Point(21, 245)
            Me.txtJumlahTagihan.Name = "txtJumlahTagihan"
            Me.txtJumlahTagihan.ReadOnly = True
            Me.txtJumlahTagihan.Size = New System.Drawing.Size(422, 29)
            Me.txtJumlahTagihan.TabIndex = 8
            Me.txtJumlahTagihan.Text = "Rp 0"
            '
            'lblJumlahTagihan
            '
            Me.lblJumlahTagihan.AutoSize = True
            Me.lblJumlahTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJumlahTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblJumlahTagihan.Location = New System.Drawing.Point(18, 226)
            Me.lblJumlahTagihan.Name = "lblJumlahTagihan"
            Me.lblJumlahTagihan.Size = New System.Drawing.Size(176, 15)
            Me.lblJumlahTagihan.TabIndex = 7
            Me.lblJumlahTagihan.Text = "Besaran Tagihan yang Diproses:"
            '
            'cmbMetodePembayaran
            '
            Me.cmbMetodePembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMetodePembayaran.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cmbMetodePembayaran.FormattingEnabled = True
            Me.cmbMetodePembayaran.Items.AddRange(New Object() {"Tunai", "QRIS", "Transfer"})
            Me.cmbMetodePembayaran.Location = New System.Drawing.Point(21, 185)
            Me.cmbMetodePembayaran.Name = "cmbMetodePembayaran"
            Me.cmbMetodePembayaran.Size = New System.Drawing.Size(422, 25)
            Me.cmbMetodePembayaran.TabIndex = 6
            '
            'lblMetodePembayaran
            '
            Me.lblMetodePembayaran.AutoSize = True
            Me.lblMetodePembayaran.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblMetodePembayaran.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblMetodePembayaran.Location = New System.Drawing.Point(18, 166)
            Me.lblMetodePembayaran.Name = "lblMetodePembayaran"
            Me.lblMetodePembayaran.Size = New System.Drawing.Size(134, 15)
            Me.lblMetodePembayaran.TabIndex = 5
            Me.lblMetodePembayaran.Text = "Metode Pembayaran: *"
            '
            'cmbJenisPembayaran
            '
            Me.cmbJenisPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbJenisPembayaran.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cmbJenisPembayaran.FormattingEnabled = True
            Me.cmbJenisPembayaran.Items.AddRange(New Object() {"Uang Muka (DP)", "Pelunasan"})
            Me.cmbJenisPembayaran.Location = New System.Drawing.Point(21, 126)
            Me.cmbJenisPembayaran.Name = "cmbJenisPembayaran"
            Me.cmbJenisPembayaran.Size = New System.Drawing.Size(422, 25)
            Me.cmbJenisPembayaran.TabIndex = 4
            '
            'lblJenisPembayaran
            '
            Me.lblJenisPembayaran.AutoSize = True
            Me.lblJenisPembayaran.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJenisPembayaran.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblJenisPembayaran.Location = New System.Drawing.Point(18, 107)
            Me.lblJenisPembayaran.Name = "lblJenisPembayaran"
            Me.lblJenisPembayaran.Size = New System.Drawing.Size(117, 15)
            Me.lblJenisPembayaran.TabIndex = 3
            Me.lblJenisPembayaran.Text = "Jenis Pembayaran: *"
            '
            'txtNoTransaksi
            '
            Me.txtNoTransaksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.txtNoTransaksi.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.txtNoTransaksi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.txtNoTransaksi.Location = New System.Drawing.Point(21, 68)
            Me.txtNoTransaksi.Name = "txtNoTransaksi"
            Me.txtNoTransaksi.ReadOnly = True
            Me.txtNoTransaksi.Size = New System.Drawing.Size(422, 26)
            Me.txtNoTransaksi.TabIndex = 2
            '
            'lblNoTransaksi
            '
            Me.lblNoTransaksi.AutoSize = True
            Me.lblNoTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblNoTransaksi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblNoTransaksi.Location = New System.Drawing.Point(18, 47)
            Me.lblNoTransaksi.Name = "lblNoTransaksi"
            Me.lblNoTransaksi.Size = New System.Drawing.Size(134, 15)
            Me.lblNoTransaksi.TabIndex = 1
            Me.lblNoTransaksi.Text = "No. Transaksi (Sistem):"
            '
            'lblHeaderKanan
            '
            Me.lblHeaderKanan.AutoSize = True
            Me.lblHeaderKanan.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeaderKanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblHeaderKanan.Location = New System.Drawing.Point(17, 14)
            Me.lblHeaderKanan.Name = "lblHeaderKanan"
            Me.lblHeaderKanan.Size = New System.Drawing.Size(217, 20)
            Me.lblHeaderKanan.TabIndex = 0
            Me.lblHeaderKanan.Text = "2. INPUT TRANSAKSI KASIR"
            '
            'frmPembayaran
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1104, 685)
            Me.Controls.Add(Me.pnlKanan)
            Me.Controls.Add(Me.pnlKiri)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmPembayaran"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SIPELA - Kasir & Pembayaran Sewa"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlKiri.ResumeLayout(False)
            Me.pnlKiri.PerformLayout()
            Me.pnlInfoBooking.ResumeLayout(False)
            Me.pnlInfoBooking.PerformLayout()
            CType(Me.dgvBooking, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlKanan.ResumeLayout(False)
            Me.pnlKanan.PerformLayout()
            Me.pnlKembalian.ResumeLayout(False)
            Me.pnlKembalian.PerformLayout()
            Me.pnlQuickButtons.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents btnKembali As System.Windows.Forms.Button
        Friend WithEvents pnlKiri As System.Windows.Forms.Panel
        Friend WithEvents lblHeaderKiri As System.Windows.Forms.Label
        Friend WithEvents lblCari As System.Windows.Forms.Label
        Friend WithEvents txtCari As System.Windows.Forms.TextBox
        Friend WithEvents btnCari As System.Windows.Forms.Button
        Friend WithEvents btnSegarkan As System.Windows.Forms.Button
        Friend WithEvents dgvBooking As System.Windows.Forms.DataGridView
        Friend WithEvents pnlInfoBooking As System.Windows.Forms.Panel
        Friend WithEvents lblHeaderDetail As System.Windows.Forms.Label
        Friend WithEvents lblValKodeBooking As System.Windows.Forms.Label
        Friend WithEvents lblValPemesan As System.Windows.Forms.Label
        Friend WithEvents lblValJadwal As System.Windows.Forms.Label
        Friend WithEvents lblValTotalSewa As System.Windows.Forms.Label
        Friend WithEvents lblValSisaTagihan As System.Windows.Forms.Label
        Friend WithEvents lblStatusPemesanan As System.Windows.Forms.Label
        Friend WithEvents pnlKanan As System.Windows.Forms.Panel
        Friend WithEvents lblHeaderKanan As System.Windows.Forms.Label
        Friend WithEvents lblNoTransaksi As System.Windows.Forms.Label
        Friend WithEvents txtNoTransaksi As System.Windows.Forms.TextBox
        Friend WithEvents lblJenisPembayaran As System.Windows.Forms.Label
        Friend WithEvents cmbJenisPembayaran As System.Windows.Forms.ComboBox
        Friend WithEvents lblMetodePembayaran As System.Windows.Forms.Label
        Friend WithEvents cmbMetodePembayaran As System.Windows.Forms.ComboBox
        Friend WithEvents lblJumlahTagihan As System.Windows.Forms.Label
        Friend WithEvents txtJumlahTagihan As System.Windows.Forms.TextBox
        Friend WithEvents lblJumlahBayar As System.Windows.Forms.Label
        Friend WithEvents txtJumlahBayar As System.Windows.Forms.TextBox
        Friend WithEvents pnlQuickButtons As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnUangPas As System.Windows.Forms.Button
        Friend WithEvents btn50k As System.Windows.Forms.Button
        Friend WithEvents btn100k As System.Windows.Forms.Button
        Friend WithEvents btn200k As System.Windows.Forms.Button
        Friend WithEvents pnlKembalian As System.Windows.Forms.Panel
        Friend WithEvents lblKembalian As System.Windows.Forms.Label
        Friend WithEvents lblValKembalian As System.Windows.Forms.Label
        Friend WithEvents btnProsesBayar As System.Windows.Forms.Button
        Friend WithEvents btnBersihkan As System.Windows.Forms.Button
        Friend WithEvents btnCetakUlang As System.Windows.Forms.Button

    End Class

End Namespace

