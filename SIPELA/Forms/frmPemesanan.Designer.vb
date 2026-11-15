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
            Me.lblSubJudul = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.tabPemesanan = New System.Windows.Forms.TabControl()
            Me.tabInput = New System.Windows.Forms.TabPage()
            Me.pnlInputContent = New System.Windows.Forms.Panel()
            Me.pnlBottomSummary = New System.Windows.Forms.Panel()
            Me.btnSaveOrder = New System.Windows.Forms.Button()
            Me.btnNewOrder = New System.Windows.Forms.Button()
            Me.lblEstimasiDP = New System.Windows.Forms.Label()
            Me.lblEstimasiDPText = New System.Windows.Forms.Label()
            Me.lblGrandTotal = New System.Windows.Forms.Label()
            Me.lblGrandTotalText = New System.Windows.Forms.Label()
            Me.grpKeranjang = New System.Windows.Forms.GroupBox()
            Me.dgvDetail = New System.Windows.Forms.DataGridView()
            Me.grpDetailSlot = New System.Windows.Forms.GroupBox()
            Me.btnClearSlot = New System.Windows.Forms.Button()
            Me.btnAddSlot = New System.Windows.Forms.Button()
            Me.txtSubtotal = New System.Windows.Forms.TextBox()
            Me.lblSubtotal = New System.Windows.Forms.Label()
            Me.txtTarif = New System.Windows.Forms.TextBox()
            Me.lblTarif = New System.Windows.Forms.Label()
            Me.cboJamMulai = New System.Windows.Forms.ComboBox()
            Me.lblJamMulai = New System.Windows.Forms.Label()
            Me.dtpTanggalMain = New System.Windows.Forms.DateTimePicker()
            Me.lblTanggalMain = New System.Windows.Forms.Label()
            Me.cboLapangan = New System.Windows.Forms.ComboBox()
            Me.lblLapangan = New System.Windows.Forms.Label()
            Me.grpHeader = New System.Windows.Forms.GroupBox()
            Me.cboMetodeBayar = New System.Windows.Forms.ComboBox()
            Me.lblMetodeBayar = New System.Windows.Forms.Label()
            Me.chkDpTerbayar = New System.Windows.Forms.CheckBox()
            Me.txtCatatan = New System.Windows.Forms.TextBox()
            Me.lblCatatan = New System.Windows.Forms.Label()
            Me.txtNoTelepon = New System.Windows.Forms.TextBox()
            Me.lblNoTelepon = New System.Windows.Forms.Label()
            Me.txtNamaPemesan = New System.Windows.Forms.TextBox()
            Me.lblNamaPemesan = New System.Windows.Forms.Label()
            Me.cboKasir = New System.Windows.Forms.ComboBox()
            Me.lblKasir = New System.Windows.Forms.Label()
            Me.dtpTanggalPesan = New System.Windows.Forms.DateTimePicker()
            Me.lblTanggalPesan = New System.Windows.Forms.Label()
            Me.txtKodeBooking = New System.Windows.Forms.TextBox()
            Me.lblKodeBooking = New System.Windows.Forms.Label()
            Me.tabRiwayat = New System.Windows.Forms.TabPage()
            Me.pnlRiwayatBottom = New System.Windows.Forms.Panel()
            Me.btnBatalkanBooking = New System.Windows.Forms.Button()
            Me.btnUbahStatus = New System.Windows.Forms.Button()
            Me.btnLihatDetail = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.dgvRiwayat = New System.Windows.Forms.DataGridView()
            Me.pnlRiwayatFilter = New System.Windows.Forms.Panel()
            Me.btnCari = New System.Windows.Forms.Button()
            Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
            Me.lblFilterStatus = New System.Windows.Forms.Label()
            Me.txtCariBooking = New System.Windows.Forms.TextBox()
            Me.lblCariBooking = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.tabPemesanan.SuspendLayout()
            Me.tabInput.SuspendLayout()
            Me.pnlInputContent.SuspendLayout()
            Me.pnlBottomSummary.SuspendLayout()
            Me.grpKeranjang.SuspendLayout()
            CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpDetailSlot.SuspendLayout()
            Me.grpHeader.SuspendLayout()
            Me.tabRiwayat.SuspendLayout()
            Me.pnlRiwayatBottom.SuspendLayout()
            CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRiwayatFilter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.pnlHeader.Controls.Add(Me.lblSubJudul)
            Me.pnlHeader.Controls.Add(Me.lblJudul)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(984, 75)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubJudul
            '
            Me.lblSubJudul.AutoSize = True
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.Lavender
            Me.lblSubJudul.Location = New System.Drawing.Point(22, 45)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(462, 15)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Form Transaksi Pemesanan Lapangan (Header-Detail), Validasi Jadwal, & Pembayaran DP"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(20, 15)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(425, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "TRANSAKSI PEMESANAN LAPANGAN FUTSAL"
            '
            'tabPemesanan
            '
            Me.tabPemesanan.Controls.Add(Me.tabInput)
            Me.tabPemesanan.Controls.Add(Me.tabRiwayat)
            Me.tabPemesanan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabPemesanan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.tabPemesanan.Location = New System.Drawing.Point(0, 75)
            Me.tabPemesanan.Name = "tabPemesanan"
            Me.tabPemesanan.SelectedIndex = 0
            Me.tabPemesanan.Size = New System.Drawing.Size(984, 586)
            Me.tabPemesanan.TabIndex = 1
            '
            'tabInput
            '
            Me.tabInput.Controls.Add(Me.pnlInputContent)
            Me.tabInput.Location = New System.Drawing.Point(4, 26)
            Me.tabInput.Name = "tabInput"
            Me.tabInput.Padding = New System.Windows.Forms.Padding(3)
            Me.tabInput.Size = New System.Drawing.Size(976, 556)
            Me.tabInput.TabIndex = 0
            Me.tabInput.Text = "  Input Pemesanan Baru (Create)  "
            Me.tabInput.UseVisualStyleBackColor = True
            '
            'pnlInputContent
            '
            Me.pnlInputContent.AutoScroll = True
            Me.pnlInputContent.Controls.Add(Me.pnlBottomSummary)
            Me.pnlInputContent.Controls.Add(Me.grpKeranjang)
            Me.pnlInputContent.Controls.Add(Me.grpDetailSlot)
            Me.pnlInputContent.Controls.Add(Me.grpHeader)
            Me.pnlInputContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlInputContent.Location = New System.Drawing.Point(3, 3)
            Me.pnlInputContent.Name = "pnlInputContent"
            Me.pnlInputContent.Size = New System.Drawing.Size(970, 550)
            Me.pnlInputContent.TabIndex = 0
            '
            'pnlBottomSummary
            '
            Me.pnlBottomSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.pnlBottomSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlBottomSummary.Controls.Add(Me.btnSaveOrder)
            Me.pnlBottomSummary.Controls.Add(Me.btnNewOrder)
            Me.pnlBottomSummary.Controls.Add(Me.lblEstimasiDP)
            Me.pnlBottomSummary.Controls.Add(Me.lblEstimasiDPText)
            Me.pnlBottomSummary.Controls.Add(Me.lblGrandTotal)
            Me.pnlBottomSummary.Controls.Add(Me.lblGrandTotalText)
            Me.pnlBottomSummary.Location = New System.Drawing.Point(365, 475)
            Me.pnlBottomSummary.Name = "pnlBottomSummary"
            Me.pnlBottomSummary.Size = New System.Drawing.Size(590, 68)
            Me.pnlBottomSummary.TabIndex = 3
            '
            'btnSaveOrder
            '
            Me.btnSaveOrder.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnSaveOrder.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveOrder.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnSaveOrder.ForeColor = System.Drawing.Color.White
            Me.btnSaveOrder.Location = New System.Drawing.Point(420, 15)
            Me.btnSaveOrder.Name = "btnSaveOrder"
            Me.btnSaveOrder.Size = New System.Drawing.Size(155, 38)
            Me.btnSaveOrder.TabIndex = 5
            Me.btnSaveOrder.Text = "Simpan Order"
            Me.btnSaveOrder.UseVisualStyleBackColor = False
            '
            'btnNewOrder
            '
            Me.btnNewOrder.BackColor = System.Drawing.Color.SteelBlue
            Me.btnNewOrder.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNewOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNewOrder.ForeColor = System.Drawing.Color.White
            Me.btnNewOrder.Location = New System.Drawing.Point(295, 15)
            Me.btnNewOrder.Name = "btnNewOrder"
            Me.btnNewOrder.Size = New System.Drawing.Size(115, 38)
            Me.btnNewOrder.TabIndex = 4
            Me.btnNewOrder.Text = "Order Baru"
            Me.btnNewOrder.UseVisualStyleBackColor = False
            '
            'lblEstimasiDP
            '
            Me.lblEstimasiDP.AutoSize = True
            Me.lblEstimasiDP.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblEstimasiDP.ForeColor = System.Drawing.Color.Crimson
            Me.lblEstimasiDP.Location = New System.Drawing.Point(125, 38)
            Me.lblEstimasiDP.Name = "lblEstimasiDP"
            Me.lblEstimasiDP.Size = New System.Drawing.Size(40, 19)
            Me.lblEstimasiDP.TabIndex = 3
            Me.lblEstimasiDP.Text = "Rp 0"
            '
            'lblEstimasiDPText
            '
            Me.lblEstimasiDPText.AutoSize = True
            Me.lblEstimasiDPText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblEstimasiDPText.ForeColor = System.Drawing.Color.DimGray
            Me.lblEstimasiDPText.Location = New System.Drawing.Point(10, 40)
            Me.lblEstimasiDPText.Name = "lblEstimasiDPText"
            Me.lblEstimasiDPText.Size = New System.Drawing.Size(110, 15)
            Me.lblEstimasiDPText.TabIndex = 2
            Me.lblEstimasiDPText.Text = "Min. DP (30% sewa):"
            '
            'lblGrandTotal
            '
            Me.lblGrandTotal.AutoSize = True
            Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGrandTotal.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.lblGrandTotal.Location = New System.Drawing.Point(125, 8)
            Me.lblGrandTotal.Name = "lblGrandTotal"
            Me.lblGrandTotal.Size = New System.Drawing.Size(51, 25)
            Me.lblGrandTotal.TabIndex = 1
            Me.lblGrandTotal.Text = "Rp 0"
            '
            'lblGrandTotalText
            '
            Me.lblGrandTotalText.AutoSize = True
            Me.lblGrandTotalText.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGrandTotalText.Location = New System.Drawing.Point(10, 12)
            Me.lblGrandTotalText.Name = "lblGrandTotalText"
            Me.lblGrandTotalText.Size = New System.Drawing.Size(96, 17)
            Me.lblGrandTotalText.TabIndex = 0
            Me.lblGrandTotalText.Text = "GRAND TOTAL:"
            '
            'grpKeranjang
            '
            Me.grpKeranjang.Controls.Add(Me.dgvDetail)
            Me.grpKeranjang.Location = New System.Drawing.Point(365, 175)
            Me.grpKeranjang.Name = "grpKeranjang"
            Me.grpKeranjang.Size = New System.Drawing.Size(590, 290)
            Me.grpKeranjang.TabIndex = 2
            Me.grpKeranjang.TabStop = False
            Me.grpKeranjang.Text = " Daftar Slot Lapangan Dipesan (Multi-Slot Grid) "
            '
            'dgvDetail
            '
            Me.dgvDetail.AllowUserToAddRows = False
            Me.dgvDetail.AllowUserToDeleteRows = False
            Me.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvDetail.Location = New System.Drawing.Point(3, 21)
            Me.dgvDetail.MultiSelect = False
            Me.dgvDetail.Name = "dgvDetail"
            Me.dgvDetail.ReadOnly = True
            Me.dgvDetail.RowHeadersVisible = False
            Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDetail.Size = New System.Drawing.Size(584, 266)
            Me.dgvDetail.TabIndex = 0
            '
            'grpDetailSlot
            '
            Me.grpDetailSlot.Controls.Add(Me.btnClearSlot)
            Me.grpDetailSlot.Controls.Add(Me.btnAddSlot)
            Me.grpDetailSlot.Controls.Add(Me.txtSubtotal)
            Me.grpDetailSlot.Controls.Add(Me.lblSubtotal)
            Me.grpDetailSlot.Controls.Add(Me.txtTarif)
            Me.grpDetailSlot.Controls.Add(Me.lblTarif)
            Me.grpDetailSlot.Controls.Add(Me.cboJamMulai)
            Me.grpDetailSlot.Controls.Add(Me.lblJamMulai)
            Me.grpDetailSlot.Controls.Add(Me.dtpTanggalMain)
            Me.grpDetailSlot.Controls.Add(Me.lblTanggalMain)
            Me.grpDetailSlot.Controls.Add(Me.cboLapangan)
            Me.grpDetailSlot.Controls.Add(Me.lblLapangan)
            Me.grpDetailSlot.Location = New System.Drawing.Point(365, 10)
            Me.grpDetailSlot.Name = "grpDetailSlot"
            Me.grpDetailSlot.Size = New System.Drawing.Size(590, 155)
            Me.grpDetailSlot.TabIndex = 1
            Me.grpDetailSlot.TabStop = False
            Me.grpDetailSlot.Text = " Input Detail Slot Lapangan "
            '
            'btnClearSlot
            '
            Me.btnClearSlot.BackColor = System.Drawing.Color.Gray
            Me.btnClearSlot.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClearSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClearSlot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnClearSlot.ForeColor = System.Drawing.Color.White
            Me.btnClearSlot.Location = New System.Drawing.Point(440, 108)
            Me.btnClearSlot.Name = "btnClearSlot"
            Me.btnClearSlot.Size = New System.Drawing.Size(135, 34)
            Me.btnClearSlot.TabIndex = 11
            Me.btnClearSlot.Text = "Clear Slot"
            Me.btnClearSlot.UseVisualStyleBackColor = False
            '
            'btnAddSlot
            '
            Me.btnAddSlot.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnAddSlot.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddSlot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnAddSlot.ForeColor = System.Drawing.Color.White
            Me.btnAddSlot.Location = New System.Drawing.Point(295, 108)
            Me.btnAddSlot.Name = "btnAddSlot"
            Me.btnAddSlot.Size = New System.Drawing.Size(135, 34)
            Me.btnAddSlot.TabIndex = 10
            Me.btnAddSlot.Text = "+ Tambah Slot"
            Me.btnAddSlot.UseVisualStyleBackColor = False
            '
            'txtSubtotal
            '
            Me.txtSubtotal.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtSubtotal.Location = New System.Drawing.Point(440, 75)
            Me.txtSubtotal.Name = "txtSubtotal"
            Me.txtSubtotal.ReadOnly = True
            Me.txtSubtotal.Size = New System.Drawing.Size(135, 24)
            Me.txtSubtotal.TabIndex = 9
            '
            'lblSubtotal
            '
            Me.lblSubtotal.AutoSize = True
            Me.lblSubtotal.Location = New System.Drawing.Point(440, 55)
            Me.lblSubtotal.Name = "lblSubtotal"
            Me.lblSubtotal.Size = New System.Drawing.Size(63, 17)
            Me.lblSubtotal.TabIndex = 8
            Me.lblSubtotal.Text = "Subtotal:"
            '
            'txtTarif
            '
            Me.txtTarif.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtTarif.Location = New System.Drawing.Point(295, 75)
            Me.txtTarif.Name = "txtTarif"
            Me.txtTarif.ReadOnly = True
            Me.txtTarif.Size = New System.Drawing.Size(135, 24)
            Me.txtTarif.TabIndex = 7
            '
            'lblTarif
            '
            Me.lblTarif.AutoSize = True
            Me.lblTarif.Location = New System.Drawing.Point(295, 55)
            Me.lblTarif.Name = "lblTarif"
            Me.lblTarif.Size = New System.Drawing.Size(73, 17)
            Me.lblTarif.TabIndex = 6
            Me.lblTarif.Text = "Tarif / Jam:"
            '
            'cboJamMulai
            '
            Me.cboJamMulai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboJamMulai.FormattingEnabled = True
            Me.cboJamMulai.Location = New System.Drawing.Point(295, 25)
            Me.cboJamMulai.Name = "cboJamMulai"
            Me.cboJamMulai.Size = New System.Drawing.Size(280, 25)
            Me.cboJamMulai.TabIndex = 5
            '
            'lblJamMulai
            '
            Me.lblJamMulai.AutoSize = True
            Me.lblJamMulai.Location = New System.Drawing.Point(220, 28)
            Me.lblJamMulai.Name = "lblJamMulai"
            Me.lblJamMulai.Size = New System.Drawing.Size(67, 17)
            Me.lblJamMulai.TabIndex = 4
            Me.lblJamMulai.Text = "Jam Main:"
            '
            'dtpTanggalMain
            '
            Me.dtpTanggalMain.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpTanggalMain.Location = New System.Drawing.Point(15, 115)
            Me.dtpTanggalMain.Name = "dtpTanggalMain"
            Me.dtpTanggalMain.Size = New System.Drawing.Size(185, 24)
            Me.dtpTanggalMain.TabIndex = 3
            '
            'lblTanggalMain
            '
            Me.lblTanggalMain.AutoSize = True
            Me.lblTanggalMain.Location = New System.Drawing.Point(15, 95)
            Me.lblTanggalMain.Name = "lblTanggalMain"
            Me.lblTanggalMain.Size = New System.Drawing.Size(89, 17)
            Me.lblTanggalMain.TabIndex = 2
            Me.lblTanggalMain.Text = "Tanggal Main:"
            '
            'cboLapangan
            '
            Me.cboLapangan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboLapangan.FormattingEnabled = True
            Me.cboLapangan.Location = New System.Drawing.Point(15, 55)
            Me.cboLapangan.Name = "cboLapangan"
            Me.cboLapangan.Size = New System.Drawing.Size(185, 25)
            Me.cboLapangan.TabIndex = 1
            '
            'lblLapangan
            '
            Me.lblLapangan.AutoSize = True
            Me.lblLapangan.Location = New System.Drawing.Point(15, 30)
            Me.lblLapangan.Name = "lblLapangan"
            Me.lblLapangan.Size = New System.Drawing.Size(100, 17)
            Me.lblLapangan.TabIndex = 0
            Me.lblLapangan.Text = "Pilih Lapangan:"
            '
            'grpHeader
            '
            Me.grpHeader.Controls.Add(Me.cboMetodeBayar)
            Me.grpHeader.Controls.Add(Me.lblMetodeBayar)
            Me.grpHeader.Controls.Add(Me.chkDpTerbayar)
            Me.grpHeader.Controls.Add(Me.txtCatatan)
            Me.grpHeader.Controls.Add(Me.lblCatatan)
            Me.grpHeader.Controls.Add(Me.txtNoTelepon)
            Me.grpHeader.Controls.Add(Me.lblNoTelepon)
            Me.grpHeader.Controls.Add(Me.txtNamaPemesan)
            Me.grpHeader.Controls.Add(Me.lblNamaPemesan)
            Me.grpHeader.Controls.Add(Me.cboKasir)
            Me.grpHeader.Controls.Add(Me.lblKasir)
            Me.grpHeader.Controls.Add(Me.dtpTanggalPesan)
            Me.grpHeader.Controls.Add(Me.lblTanggalPesan)
            Me.grpHeader.Controls.Add(Me.txtKodeBooking)
            Me.grpHeader.Controls.Add(Me.lblKodeBooking)
            Me.grpHeader.Location = New System.Drawing.Point(15, 10)
            Me.grpHeader.Name = "grpHeader"
            Me.grpHeader.Size = New System.Drawing.Size(335, 533)
            Me.grpHeader.TabIndex = 0
            Me.grpHeader.TabStop = False
            Me.grpHeader.Text = " Data Header Pemesanan "
            '
            'cboMetodeBayar
            '
            Me.cboMetodeBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMetodeBayar.FormattingEnabled = True
            Me.cboMetodeBayar.Items.AddRange(New Object() {"Tunai", "QRIS", "Transfer"})
            Me.cboMetodeBayar.Location = New System.Drawing.Point(15, 490)
            Me.cboMetodeBayar.Name = "cboMetodeBayar"
            Me.cboMetodeBayar.Size = New System.Drawing.Size(300, 25)
            Me.cboMetodeBayar.TabIndex = 14
            '
            'lblMetodeBayar
            '
            Me.lblMetodeBayar.AutoSize = True
            Me.lblMetodeBayar.Location = New System.Drawing.Point(15, 470)
            Me.lblMetodeBayar.Name = "lblMetodeBayar"
            Me.lblMetodeBayar.Size = New System.Drawing.Size(117, 17)
            Me.lblMetodeBayar.TabIndex = 13
            Me.lblMetodeBayar.Text = "Metode Bayar DP:"
            '
            'chkDpTerbayar
            '
            Me.chkDpTerbayar.AutoSize = True
            Me.chkDpTerbayar.Checked = True
            Me.chkDpTerbayar.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkDpTerbayar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.chkDpTerbayar.ForeColor = System.Drawing.Color.MediumSeaGreen
            Me.chkDpTerbayar.Location = New System.Drawing.Point(15, 440)
            Me.chkDpTerbayar.Name = "chkDpTerbayar"
            Me.chkDpTerbayar.Size = New System.Drawing.Size(193, 21)
            Me.chkDpTerbayar.TabIndex = 12
            Me.chkDpTerbayar.Text = "Langsung Catat DP Terbayar"
            Me.chkDpTerbayar.UseVisualStyleBackColor = True
            '
            'txtCatatan
            '
            Me.txtCatatan.Location = New System.Drawing.Point(15, 370)
            Me.txtCatatan.MaxLength = 255
            Me.txtCatatan.Multiline = True
            Me.txtCatatan.Name = "txtCatatan"
            Me.txtCatatan.Size = New System.Drawing.Size(300, 55)
            Me.txtCatatan.TabIndex = 11
            '
            'lblCatatan
            '
            Me.lblCatatan.AutoSize = True
            Me.lblCatatan.Location = New System.Drawing.Point(15, 350)
            Me.lblCatatan.Name = "lblCatatan"
            Me.lblCatatan.Size = New System.Drawing.Size(113, 17)
            Me.lblCatatan.TabIndex = 10
            Me.lblCatatan.Text = "Catatan Tambahan:"
            '
            'txtNoTelepon
            '
            Me.txtNoTelepon.Location = New System.Drawing.Point(15, 310)
            Me.txtNoTelepon.MaxLength = 15
            Me.txtNoTelepon.Name = "txtNoTelepon"
            Me.txtNoTelepon.Size = New System.Drawing.Size(300, 24)
            Me.txtNoTelepon.TabIndex = 9
            '
            'lblNoTelepon
            '
            Me.lblNoTelepon.AutoSize = True
            Me.lblNoTelepon.Location = New System.Drawing.Point(15, 290)
            Me.lblNoTelepon.Name = "lblNoTelepon"
            Me.lblNoTelepon.Size = New System.Drawing.Size(152, 17)
            Me.lblNoTelepon.TabIndex = 8
            Me.lblNoTelepon.Text = "No. Telepon / WhatsApp:"
            '
            'txtNamaPemesan
            '
            Me.txtNamaPemesan.Location = New System.Drawing.Point(15, 250)
            Me.txtNamaPemesan.MaxLength = 100
            Me.txtNamaPemesan.Name = "txtNamaPemesan"
            Me.txtNamaPemesan.Size = New System.Drawing.Size(300, 24)
            Me.txtNamaPemesan.TabIndex = 7
            '
            'lblNamaPemesan
            '
            Me.lblNamaPemesan.AutoSize = True
            Me.lblNamaPemesan.Location = New System.Drawing.Point(15, 230)
            Me.lblNamaPemesan.Name = "lblNamaPemesan"
            Me.lblNamaPemesan.Size = New System.Drawing.Size(104, 17)
            Me.lblNamaPemesan.TabIndex = 6
            Me.lblNamaPemesan.Text = "Nama Pemesan:"
            '
            'cboKasir
            '
            Me.cboKasir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboKasir.FormattingEnabled = True
            Me.cboKasir.Location = New System.Drawing.Point(15, 185)
            Me.cboKasir.Name = "cboKasir"
            Me.cboKasir.Size = New System.Drawing.Size(300, 25)
            Me.cboKasir.TabIndex = 5
            '
            'lblKasir
            '
            Me.lblKasir.AutoSize = True
            Me.lblKasir.Location = New System.Drawing.Point(15, 165)
            Me.lblKasir.Name = "lblKasir"
            Me.lblKasir.Size = New System.Drawing.Size(95, 17)
            Me.lblKasir.TabIndex = 4
            Me.lblKasir.Text = "Petugas Kasir:"
            '
            'dtpTanggalPesan
            '
            Me.dtpTanggalPesan.Enabled = False
            Me.dtpTanggalPesan.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpTanggalPesan.Location = New System.Drawing.Point(15, 125)
            Me.dtpTanggalPesan.Name = "dtpTanggalPesan"
            Me.dtpTanggalPesan.Size = New System.Drawing.Size(300, 24)
            Me.dtpTanggalPesan.TabIndex = 3
            '
            'lblTanggalPesan
            '
            Me.lblTanggalPesan.AutoSize = True
            Me.lblTanggalPesan.Location = New System.Drawing.Point(15, 105)
            Me.lblTanggalPesan.Name = "lblTanggalPesan"
            Me.lblTanggalPesan.Size = New System.Drawing.Size(126, 17)
            Me.lblTanggalPesan.TabIndex = 2
            Me.lblTanggalPesan.Text = "Tanggal Pemesanan:"
            '
            'txtKodeBooking
            '
            Me.txtKodeBooking.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtKodeBooking.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.txtKodeBooking.Location = New System.Drawing.Point(15, 65)
            Me.txtKodeBooking.Name = "txtKodeBooking"
            Me.txtKodeBooking.ReadOnly = True
            Me.txtKodeBooking.Size = New System.Drawing.Size(300, 24)
            Me.txtKodeBooking.TabIndex = 1
            '
            'lblKodeBooking
            '
            Me.lblKodeBooking.AutoSize = True
            Me.lblKodeBooking.Location = New System.Drawing.Point(15, 45)
            Me.lblKodeBooking.Name = "lblKodeBooking"
            Me.lblKodeBooking.Size = New System.Drawing.Size(155, 17)
            Me.lblKodeBooking.TabIndex = 0
            Me.lblKodeBooking.Text = "Kode Booking (Otomatis):"
            '
            'tabRiwayat
            '
            Me.tabRiwayat.Controls.Add(Me.pnlRiwayatBottom)
            Me.tabRiwayat.Controls.Add(Me.dgvRiwayat)
            Me.tabRiwayat.Controls.Add(Me.pnlRiwayatFilter)
            Me.tabRiwayat.Location = New System.Drawing.Point(4, 26)
            Me.tabRiwayat.Name = "tabRiwayat"
            Me.tabRiwayat.Padding = New System.Windows.Forms.Padding(3)
            Me.tabRiwayat.Size = New System.Drawing.Size(976, 556)
            Me.tabRiwayat.TabIndex = 1
            Me.tabRiwayat.Text = "  Daftar & Riwayat Pemesanan (Read, Update, Delete)  "
            Me.tabRiwayat.UseVisualStyleBackColor = True
            '
            'pnlRiwayatBottom
            '
            Me.pnlRiwayatBottom.Controls.Add(Me.btnBatalkanBooking)
            Me.pnlRiwayatBottom.Controls.Add(Me.btnUbahStatus)
            Me.pnlRiwayatBottom.Controls.Add(Me.btnLihatDetail)
            Me.pnlRiwayatBottom.Controls.Add(Me.btnRefresh)
            Me.pnlRiwayatBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlRiwayatBottom.Location = New System.Drawing.Point(3, 498)
            Me.pnlRiwayatBottom.Name = "pnlRiwayatBottom"
            Me.pnlRiwayatBottom.Size = New System.Drawing.Size(970, 55)
            Me.pnlRiwayatBottom.TabIndex = 2
            '
            'btnBatalkanBooking
            '
            Me.btnBatalkanBooking.BackColor = System.Drawing.Color.Crimson
            Me.btnBatalkanBooking.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBatalkanBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBatalkanBooking.ForeColor = System.Drawing.Color.White
            Me.btnBatalkanBooking.Location = New System.Drawing.Point(770, 10)
            Me.btnBatalkanBooking.Name = "btnBatalkanBooking"
            Me.btnBatalkanBooking.Size = New System.Drawing.Size(185, 35)
            Me.btnBatalkanBooking.TabIndex = 3
            Me.btnBatalkanBooking.Text = "Batalkan / Hapus Booking"
            Me.btnBatalkanBooking.UseVisualStyleBackColor = False
            '
            'btnUbahStatus
            '
            Me.btnUbahStatus.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUbahStatus.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnUbahStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUbahStatus.ForeColor = System.Drawing.Color.White
            Me.btnUbahStatus.Location = New System.Drawing.Point(585, 10)
            Me.btnUbahStatus.Name = "btnUbahStatus"
            Me.btnUbahStatus.Size = New System.Drawing.Size(175, 35)
            Me.btnUbahStatus.TabIndex = 2
            Me.btnUbahStatus.Text = "Ubah Status / Pelunasan"
            Me.btnUbahStatus.UseVisualStyleBackColor = False
            '
            'btnLihatDetail
            '
            Me.btnLihatDetail.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnLihatDetail.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLihatDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLihatDetail.ForeColor = System.Drawing.Color.White
            Me.btnLihatDetail.Location = New System.Drawing.Point(420, 10)
            Me.btnLihatDetail.Name = "btnLihatDetail"
            Me.btnLihatDetail.Size = New System.Drawing.Size(155, 35)
            Me.btnLihatDetail.TabIndex = 1
            Me.btnLihatDetail.Text = "Lihat Detail Slot"
            Me.btnLihatDetail.UseVisualStyleBackColor = False
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.Gray
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(15, 10)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(130, 35)
            Me.btnRefresh.TabIndex = 0
            Me.btnRefresh.Text = "Segarkan Data"
            Me.btnRefresh.UseVisualStyleBackColor = False
            '
            'dgvRiwayat
            '
            Me.dgvRiwayat.AllowUserToAddRows = False
            Me.dgvRiwayat.AllowUserToDeleteRows = False
            Me.dgvRiwayat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvRiwayat.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvRiwayat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvRiwayat.Location = New System.Drawing.Point(3, 53)
            Me.dgvRiwayat.MultiSelect = False
            Me.dgvRiwayat.Name = "dgvRiwayat"
            Me.dgvRiwayat.ReadOnly = True
            Me.dgvRiwayat.RowHeadersVisible = False
            Me.dgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvRiwayat.Size = New System.Drawing.Size(970, 500)
            Me.dgvRiwayat.TabIndex = 1
            '
            'pnlRiwayatFilter
            '
            Me.pnlRiwayatFilter.Controls.Add(Me.btnCari)
            Me.pnlRiwayatFilter.Controls.Add(Me.cboFilterStatus)
            Me.pnlRiwayatFilter.Controls.Add(Me.lblFilterStatus)
            Me.pnlRiwayatFilter.Controls.Add(Me.txtCariBooking)
            Me.pnlRiwayatFilter.Controls.Add(Me.lblCariBooking)
            Me.pnlRiwayatFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlRiwayatFilter.Location = New System.Drawing.Point(3, 3)
            Me.pnlRiwayatFilter.Name = "pnlRiwayatFilter"
            Me.pnlRiwayatFilter.Size = New System.Drawing.Size(970, 50)
            Me.pnlRiwayatFilter.TabIndex = 0
            '
            'btnCari
            '
            Me.btnCari.BackColor = System.Drawing.Color.SlateGray
            Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCari.ForeColor = System.Drawing.Color.White
            Me.btnCari.Location = New System.Drawing.Point(405, 10)
            Me.btnCari.Name = "btnCari"
            Me.btnCari.Size = New System.Drawing.Size(80, 30)
            Me.btnCari.TabIndex = 4
            Me.btnCari.Text = "Cari"
            Me.btnCari.UseVisualStyleBackColor = False
            '
            'cboFilterStatus
            '
            Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFilterStatus.FormattingEnabled = True
            Me.cboFilterStatus.Items.AddRange(New Object() {"Semua Status", "Menunggu DP", "DP Terbayar", "Lunas", "Kedaluwarsa"})
            Me.cboFilterStatus.Location = New System.Drawing.Point(755, 12)
            Me.cboFilterStatus.Name = "cboFilterStatus"
            Me.cboFilterStatus.Size = New System.Drawing.Size(200, 25)
            Me.cboFilterStatus.TabIndex = 3
            '
            'lblFilterStatus
            '
            Me.lblFilterStatus.AutoSize = True
            Me.lblFilterStatus.Location = New System.Drawing.Point(665, 16)
            Me.lblFilterStatus.Name = "lblFilterStatus"
            Me.lblFilterStatus.Size = New System.Drawing.Size(83, 17)
            Me.lblFilterStatus.TabIndex = 2
            Me.lblFilterStatus.Text = "Filter Status:"
            '
            'txtCariBooking
            '
            Me.txtCariBooking.Location = New System.Drawing.Point(105, 13)
            Me.txtCariBooking.Name = "txtCariBooking"
            Me.txtCariBooking.PlaceholderText = "Ketik kode booking / pemesan / telepon..."
            Me.txtCariBooking.Size = New System.Drawing.Size(290, 24)
            Me.txtCariBooking.TabIndex = 1
            '
            'lblCariBooking
            '
            Me.lblCariBooking.AutoSize = True
            Me.lblCariBooking.Location = New System.Drawing.Point(15, 16)
            Me.lblCariBooking.Name = "lblCariBooking"
            Me.lblCariBooking.Size = New System.Drawing.Size(87, 17)
            Me.lblCariBooking.TabIndex = 0
            Me.lblCariBooking.Text = "Cari Booking:"
            '
            'frmPemesanan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(984, 661)
            Me.Controls.Add(Me.tabPemesanan)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.Name = "frmPemesanan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Transaksi Pemesanan Lapangan - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tabPemesanan.ResumeLayout(False)
            Me.tabInput.ResumeLayout(False)
            Me.pnlInputContent.ResumeLayout(False)
            Me.pnlBottomSummary.ResumeLayout(False)
            Me.pnlBottomSummary.PerformLayout()
            Me.grpKeranjang.ResumeLayout(False)
            CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpDetailSlot.ResumeLayout(False)
            Me.grpDetailSlot.PerformLayout()
            Me.grpHeader.ResumeLayout(False)
            Me.grpHeader.PerformLayout()
            Me.tabRiwayat.ResumeLayout(False)
            Me.pnlRiwayatBottom.ResumeLayout(False)
            CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRiwayatFilter.ResumeLayout(False)
            Me.pnlRiwayatFilter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents tabPemesanan As System.Windows.Forms.TabControl
        Friend WithEvents tabInput As System.Windows.Forms.TabPage
        Friend WithEvents tabRiwayat As System.Windows.Forms.TabPage
        Friend WithEvents pnlInputContent As System.Windows.Forms.Panel
        Friend WithEvents grpHeader As System.Windows.Forms.GroupBox
        Friend WithEvents lblKodeBooking As System.Windows.Forms.Label
        Friend WithEvents txtKodeBooking As System.Windows.Forms.TextBox
        Friend WithEvents lblTanggalPesan As System.Windows.Forms.Label
        Friend WithEvents dtpTanggalPesan As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblKasir As System.Windows.Forms.Label
        Friend WithEvents cboKasir As System.Windows.Forms.ComboBox
        Friend WithEvents lblNamaPemesan As System.Windows.Forms.Label
        Friend WithEvents txtNamaPemesan As System.Windows.Forms.TextBox
        Friend WithEvents lblNoTelepon As System.Windows.Forms.Label
        Friend WithEvents txtNoTelepon As System.Windows.Forms.TextBox
        Friend WithEvents lblCatatan As System.Windows.Forms.Label
        Friend WithEvents txtCatatan As System.Windows.Forms.TextBox
        Friend WithEvents chkDpTerbayar As System.Windows.Forms.CheckBox
        Friend WithEvents lblMetodeBayar As System.Windows.Forms.Label
        Friend WithEvents cboMetodeBayar As System.Windows.Forms.ComboBox
        Friend WithEvents grpDetailSlot As System.Windows.Forms.GroupBox
        Friend WithEvents lblLapangan As System.Windows.Forms.Label
        Friend WithEvents cboLapangan As System.Windows.Forms.ComboBox
        Friend WithEvents lblTanggalMain As System.Windows.Forms.Label
        Friend WithEvents dtpTanggalMain As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblJamMulai As System.Windows.Forms.Label
        Friend WithEvents cboJamMulai As System.Windows.Forms.ComboBox
        Friend WithEvents lblTarif As System.Windows.Forms.Label
        Friend WithEvents txtTarif As System.Windows.Forms.TextBox
        Friend WithEvents lblSubtotal As System.Windows.Forms.Label
        Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
        Friend WithEvents btnAddSlot As System.Windows.Forms.Button
        Friend WithEvents btnClearSlot As System.Windows.Forms.Button
        Friend WithEvents grpKeranjang As System.Windows.Forms.GroupBox
        Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
        Friend WithEvents pnlBottomSummary As System.Windows.Forms.Panel
        Friend WithEvents lblGrandTotalText As System.Windows.Forms.Label
        Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
        Friend WithEvents lblEstimasiDPText As System.Windows.Forms.Label
        Friend WithEvents lblEstimasiDP As System.Windows.Forms.Label
        Friend WithEvents btnNewOrder As System.Windows.Forms.Button
        Friend WithEvents btnSaveOrder As System.Windows.Forms.Button
        Friend WithEvents pnlRiwayatFilter As System.Windows.Forms.Panel
        Friend WithEvents lblCariBooking As System.Windows.Forms.Label
        Friend WithEvents txtCariBooking As System.Windows.Forms.TextBox
        Friend WithEvents lblFilterStatus As System.Windows.Forms.Label
        Friend WithEvents cboFilterStatus As System.Windows.Forms.ComboBox
        Friend WithEvents btnCari As System.Windows.Forms.Button
        Friend WithEvents dgvRiwayat As System.Windows.Forms.DataGridView
        Friend WithEvents pnlRiwayatBottom As System.Windows.Forms.Panel
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents btnLihatDetail As System.Windows.Forms.Button
        Friend WithEvents btnUbahStatus As System.Windows.Forms.Button
        Friend WithEvents btnBatalkanBooking As System.Windows.Forms.Button
    End Class

End Namespace

