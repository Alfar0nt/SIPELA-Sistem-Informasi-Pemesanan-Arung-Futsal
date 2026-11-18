Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmLaporan
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
            Me.tabLaporan = New System.Windows.Forms.TabControl()
            Me.tabTransaksi = New System.Windows.Forms.TabPage()
            Me.dgvLaporan = New System.Windows.Forms.DataGridView()
            Me.pnlSummary = New System.Windows.Forms.Panel()
            Me.pnlCardSisa = New System.Windows.Forms.Panel()
            Me.lblSisaBelumLunas = New System.Windows.Forms.Label()
            Me.lblCardSisaTitle = New System.Windows.Forms.Label()
            Me.pnlCardBayar = New System.Windows.Forms.Panel()
            Me.lblTotalBayarMasuk = New System.Windows.Forms.Label()
            Me.lblCardBayarTitle = New System.Windows.Forms.Label()
            Me.pnlCardSewa = New System.Windows.Forms.Panel()
            Me.lblGrandTotalSewa = New System.Windows.Forms.Label()
            Me.lblCardSewaTitle = New System.Windows.Forms.Label()
            Me.pnlCardSlot = New System.Windows.Forms.Panel()
            Me.lblTotalSlot = New System.Windows.Forms.Label()
            Me.lblCardSlotTitle = New System.Windows.Forms.Label()
            Me.pnlCardBooking = New System.Windows.Forms.Panel()
            Me.lblTotalBooking = New System.Windows.Forms.Label()
            Me.lblCardBookingTitle = New System.Windows.Forms.Label()
            Me.pnlFilter = New System.Windows.Forms.Panel()
            Me.btnResetFilter = New System.Windows.Forms.Button()
            Me.btnTampilkan = New System.Windows.Forms.Button()
            Me.txtCari = New System.Windows.Forms.TextBox()
            Me.lblCari = New System.Windows.Forms.Label()
            Me.cboStatus = New System.Windows.Forms.ComboBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.cboLapangan = New System.Windows.Forms.ComboBox()
            Me.lblLapangan = New System.Windows.Forms.Label()
            Me.dtpSampai = New System.Windows.Forms.DateTimePicker()
            Me.lblSampai = New System.Windows.Forms.Label()
            Me.dtpDari = New System.Windows.Forms.DateTimePicker()
            Me.lblDari = New System.Windows.Forms.Label()
            Me.cboJenisTanggal = New System.Windows.Forms.ComboBox()
            Me.lblJenisTanggal = New System.Windows.Forms.Label()
            Me.pnlAksi = New System.Windows.Forms.Panel()
            Me.btnTutup = New System.Windows.Forms.Button()
            Me.btnCetakStruk = New System.Windows.Forms.Button()
            Me.btnCetakLaporan = New System.Windows.Forms.Button()
            Me.btnExportCsv = New System.Windows.Forms.Button()
            Me.lblInfoBaris = New System.Windows.Forms.Label()
            Me.tabBulanan = New System.Windows.Forms.TabPage()
            Me.dgvBulanan = New System.Windows.Forms.DataGridView()
            Me.pnlSummaryBulanan = New System.Windows.Forms.Panel()
            Me.pnlCardOkupansiBln = New System.Windows.Forms.Panel()
            Me.lblBlnRataOkupansi = New System.Windows.Forms.Label()
            Me.lblCardOkupansiBlnTitle = New System.Windows.Forms.Label()
            Me.pnlCardSlotBln = New System.Windows.Forms.Panel()
            Me.lblBlnTotalSlot = New System.Windows.Forms.Label()
            Me.lblCardSlotBlnTitle = New System.Windows.Forms.Label()
            Me.pnlCardTransBln = New System.Windows.Forms.Panel()
            Me.lblBlnTotalTransaksi = New System.Windows.Forms.Label()
            Me.lblCardTransBlnTitle = New System.Windows.Forms.Label()
            Me.pnlCardPendapatanBln = New System.Windows.Forms.Panel()
            Me.lblBlnTotalPendapatan = New System.Windows.Forms.Label()
            Me.lblCardPendapatanBlnTitle = New System.Windows.Forms.Label()
            Me.pnlFilterBulanan = New System.Windows.Forms.Panel()
            Me.btnRefreshBulanan = New System.Windows.Forms.Button()
            Me.cboTahun = New System.Windows.Forms.ComboBox()
            Me.lblTahun = New System.Windows.Forms.Label()
            Me.pnlAksiBulanan = New System.Windows.Forms.Panel()
            Me.btnCetakBulanan = New System.Windows.Forms.Button()
            Me.btnExportBulananCsv = New System.Windows.Forms.Button()
            Me.lblInfoBulanan = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.tabLaporan.SuspendLayout()
            Me.tabTransaksi.SuspendLayout()
            CType(Me.dgvLaporan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSummary.SuspendLayout()
            Me.pnlCardSisa.SuspendLayout()
            Me.pnlCardBayar.SuspendLayout()
            Me.pnlCardSewa.SuspendLayout()
            Me.pnlCardSlot.SuspendLayout()
            Me.pnlCardBooking.SuspendLayout()
            Me.pnlFilter.SuspendLayout()
            Me.pnlAksi.SuspendLayout()
            Me.tabBulanan.SuspendLayout()
            CType(Me.dgvBulanan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSummaryBulanan.SuspendLayout()
            Me.pnlCardOkupansiBln.SuspendLayout()
            Me.pnlCardSlotBln.SuspendLayout()
            Me.pnlCardTransBln.SuspendLayout()
            Me.pnlCardPendapatanBln.SuspendLayout()
            Me.pnlFilterBulanan.SuspendLayout()
            Me.pnlAksiBulanan.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(1060, 72)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubJudul
            '
            Me.lblSubJudul.AutoSize = True
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.Lavender
            Me.lblSubJudul.Location = New System.Drawing.Point(22, 43)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(492, 15)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Laporan Data Relasional Transaksi, Agregasi Metrik Pendapatan, Ekspor CSV/Excel, & Cetak PDF"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(20, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(470, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "LAPORAN PENDAPATAN, TRANSAKSI, & OKUPANSI"
            '
            'tabLaporan
            '
            Me.tabLaporan.Controls.Add(Me.tabTransaksi)
            Me.tabLaporan.Controls.Add(Me.tabBulanan)
            Me.tabLaporan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabLaporan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.tabLaporan.Location = New System.Drawing.Point(0, 72)
            Me.tabLaporan.Name = "tabLaporan"
            Me.tabLaporan.SelectedIndex = 0
            Me.tabLaporan.Size = New System.Drawing.Size(1060, 608)
            Me.tabLaporan.TabIndex = 1
            '
            'tabTransaksi
            '
            Me.tabTransaksi.BackColor = System.Drawing.Color.White
            Me.tabTransaksi.Controls.Add(Me.dgvLaporan)
            Me.tabTransaksi.Controls.Add(Me.pnlSummary)
            Me.tabTransaksi.Controls.Add(Me.pnlFilter)
            Me.tabTransaksi.Controls.Add(Me.pnlAksi)
            Me.tabTransaksi.Location = New System.Drawing.Point(4, 26)
            Me.tabTransaksi.Name = "tabTransaksi"
            Me.tabTransaksi.Padding = New System.Windows.Forms.Padding(3)
            Me.tabTransaksi.Size = New System.Drawing.Size(1052, 578)
            Me.tabTransaksi.TabIndex = 0
            Me.tabTransaksi.Text = "  Laporan Transaksi & Pendapatan  "
            '
            'dgvLaporan
            '
            Me.dgvLaporan.AllowUserToAddRows = False
            Me.dgvLaporan.AllowUserToDeleteRows = False
            Me.dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvLaporan.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLaporan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvLaporan.Location = New System.Drawing.Point(3, 181)
            Me.dgvLaporan.MultiSelect = False
            Me.dgvLaporan.Name = "dgvLaporan"
            Me.dgvLaporan.ReadOnly = True
            Me.dgvLaporan.RowHeadersVisible = False
            Me.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvLaporan.Size = New System.Drawing.Size(1046, 338)
            Me.dgvLaporan.TabIndex = 2
            '
            'pnlSummary
            '
            Me.pnlSummary.BackColor = System.Drawing.Color.White
            Me.pnlSummary.Controls.Add(Me.pnlCardSisa)
            Me.pnlSummary.Controls.Add(Me.pnlCardBayar)
            Me.pnlSummary.Controls.Add(Me.pnlCardSewa)
            Me.pnlSummary.Controls.Add(Me.pnlCardSlot)
            Me.pnlSummary.Controls.Add(Me.pnlCardBooking)
            Me.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlSummary.Location = New System.Drawing.Point(3, 99)
            Me.pnlSummary.Name = "pnlSummary"
            Me.pnlSummary.Size = New System.Drawing.Size(1046, 82)
            Me.pnlSummary.TabIndex = 1
            '
            'pnlCardBooking
            '
            Me.pnlCardBooking.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlCardBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardBooking.Controls.Add(Me.lblTotalBooking)
            Me.pnlCardBooking.Controls.Add(Me.lblCardBookingTitle)
            Me.pnlCardBooking.Location = New System.Drawing.Point(10, 8)
            Me.pnlCardBooking.Name = "pnlCardBooking"
            Me.pnlCardBooking.Size = New System.Drawing.Size(185, 66)
            Me.pnlCardBooking.TabIndex = 0
            '
            'lblCardBookingTitle
            '
            Me.lblCardBookingTitle.AutoSize = True
            Me.lblCardBookingTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardBookingTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardBookingTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardBookingTitle.Name = "lblCardBookingTitle"
            Me.lblCardBookingTitle.Size = New System.Drawing.Size(81, 15)
            Me.lblCardBookingTitle.TabIndex = 0
            Me.lblCardBookingTitle.Text = "Total Booking"
            '
            'lblTotalBooking
            '
            Me.lblTotalBooking.AutoSize = True
            Me.lblTotalBooking.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTotalBooking.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.lblTotalBooking.Location = New System.Drawing.Point(10, 28)
            Me.lblTotalBooking.Name = "lblTotalBooking"
            Me.lblTotalBooking.Size = New System.Drawing.Size(22, 25)
            Me.lblTotalBooking.TabIndex = 1
            Me.lblTotalBooking.Text = "0"
            '
            'pnlCardSlot
            '
            Me.pnlCardSlot.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlCardSlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardSlot.Controls.Add(Me.lblTotalSlot)
            Me.pnlCardSlot.Controls.Add(Me.lblCardSlotTitle)
            Me.pnlCardSlot.Location = New System.Drawing.Point(205, 8)
            Me.pnlCardSlot.Name = "pnlCardSlot"
            Me.pnlCardSlot.Size = New System.Drawing.Size(185, 66)
            Me.pnlCardSlot.TabIndex = 1
            '
            'lblCardSlotTitle
            '
            Me.lblCardSlotTitle.AutoSize = True
            Me.lblCardSlotTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardSlotTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardSlotTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardSlotTitle.Name = "lblCardSlotTitle"
            Me.lblCardSlotTitle.Size = New System.Drawing.Size(115, 15)
            Me.lblCardSlotTitle.TabIndex = 0
            Me.lblCardSlotTitle.Text = "Total Slot Terjual (Jam)"
            '
            'lblTotalSlot
            '
            Me.lblTotalSlot.AutoSize = True
            Me.lblTotalSlot.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTotalSlot.ForeColor = System.Drawing.Color.SteelBlue
            Me.lblTotalSlot.Location = New System.Drawing.Point(10, 28)
            Me.lblTotalSlot.Name = "lblTotalSlot"
            Me.lblTotalSlot.Size = New System.Drawing.Size(58, 25)
            Me.lblTotalSlot.TabIndex = 1
            Me.lblTotalSlot.Text = "0 Slot"
            '
            'pnlCardSewa
            '
            Me.pnlCardSewa.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(245, Byte), Integer))
            Me.pnlCardSewa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardSewa.Controls.Add(Me.lblGrandTotalSewa)
            Me.pnlCardSewa.Controls.Add(Me.lblCardSewaTitle)
            Me.pnlCardSewa.Location = New System.Drawing.Point(400, 8)
            Me.pnlCardSewa.Name = "pnlCardSewa"
            Me.pnlCardSewa.Size = New System.Drawing.Size(210, 66)
            Me.pnlCardSewa.TabIndex = 2
            '
            'lblCardSewaTitle
            '
            Me.lblCardSewaTitle.AutoSize = True
            Me.lblCardSewaTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardSewaTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardSewaTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardSewaTitle.Name = "lblCardSewaTitle"
            Me.lblCardSewaTitle.Size = New System.Drawing.Size(121, 15)
            Me.lblCardSewaTitle.TabIndex = 0
            Me.lblCardSewaTitle.Text = "Grand Total Nilai Sewa"
            '
            'lblGrandTotalSewa
            '
            Me.lblGrandTotalSewa.AutoSize = True
            Me.lblGrandTotalSewa.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGrandTotalSewa.ForeColor = System.Drawing.Color.SeaGreen
            Me.lblGrandTotalSewa.Location = New System.Drawing.Point(10, 28)
            Me.lblGrandTotalSewa.Name = "lblGrandTotalSewa"
            Me.lblGrandTotalSewa.Size = New System.Drawing.Size(48, 25)
            Me.lblGrandTotalSewa.TabIndex = 1
            Me.lblGrandTotalSewa.Text = "Rp 0"
            '
            'pnlCardBayar
            '
            Me.pnlCardBayar.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.pnlCardBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardBayar.Controls.Add(Me.lblTotalBayarMasuk)
            Me.pnlCardBayar.Controls.Add(Me.lblCardBayarTitle)
            Me.pnlCardBayar.Location = New System.Drawing.Point(620, 8)
            Me.pnlCardBayar.Name = "pnlCardBayar"
            Me.pnlCardBayar.Size = New System.Drawing.Size(210, 66)
            Me.pnlCardBayar.TabIndex = 3
            '
            'lblCardBayarTitle
            '
            Me.lblCardBayarTitle.AutoSize = True
            Me.lblCardBayarTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardBayarTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardBayarTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardBayarTitle.Name = "lblCardBayarTitle"
            Me.lblCardBayarTitle.Size = New System.Drawing.Size(136, 15)
            Me.lblCardBayarTitle.TabIndex = 0
            Me.lblCardBayarTitle.Text = "Total Pembayaran Masuk"
            '
            'lblTotalBayarMasuk
            '
            Me.lblTotalBayarMasuk.AutoSize = True
            Me.lblTotalBayarMasuk.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTotalBayarMasuk.ForeColor = System.Drawing.Color.DarkGreen
            Me.lblTotalBayarMasuk.Location = New System.Drawing.Point(10, 28)
            Me.lblTotalBayarMasuk.Name = "lblTotalBayarMasuk"
            Me.lblTotalBayarMasuk.Size = New System.Drawing.Size(48, 25)
            Me.lblTotalBayarMasuk.TabIndex = 1
            Me.lblTotalBayarMasuk.Text = "Rp 0"
            '
            'pnlCardSisa
            '
            Me.pnlCardSisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
            Me.pnlCardSisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardSisa.Controls.Add(Me.lblSisaBelumLunas)
            Me.pnlCardSisa.Controls.Add(Me.lblCardSisaTitle)
            Me.pnlCardSisa.Location = New System.Drawing.Point(840, 8)
            Me.pnlCardSisa.Name = "pnlCardSisa"
            Me.pnlCardSisa.Size = New System.Drawing.Size(196, 66)
            Me.pnlCardSisa.TabIndex = 4
            '
            'lblCardSisaTitle
            '
            Me.lblCardSisaTitle.AutoSize = True
            Me.lblCardSisaTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardSisaTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardSisaTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardSisaTitle.Name = "lblCardSisaTitle"
            Me.lblCardSisaTitle.Size = New System.Drawing.Size(100, 15)
            Me.lblCardSisaTitle.TabIndex = 0
            Me.lblCardSisaTitle.Text = "Sisa Belum Lunas"
            '
            'lblSisaBelumLunas
            '
            Me.lblSisaBelumLunas.AutoSize = True
            Me.lblSisaBelumLunas.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSisaBelumLunas.ForeColor = System.Drawing.Color.Crimson
            Me.lblSisaBelumLunas.Location = New System.Drawing.Point(10, 28)
            Me.lblSisaBelumLunas.Name = "lblSisaBelumLunas"
            Me.lblSisaBelumLunas.Size = New System.Drawing.Size(48, 25)
            Me.lblSisaBelumLunas.TabIndex = 1
            Me.lblSisaBelumLunas.Text = "Rp 0"
            '
            'pnlFilter
            '
            Me.pnlFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.pnlFilter.Controls.Add(Me.btnResetFilter)
            Me.pnlFilter.Controls.Add(Me.btnTampilkan)
            Me.pnlFilter.Controls.Add(Me.txtCari)
            Me.pnlFilter.Controls.Add(Me.lblCari)
            Me.pnlFilter.Controls.Add(Me.cboStatus)
            Me.pnlFilter.Controls.Add(Me.lblStatus)
            Me.pnlFilter.Controls.Add(Me.cboLapangan)
            Me.pnlFilter.Controls.Add(Me.lblLapangan)
            Me.pnlFilter.Controls.Add(Me.dtpSampai)
            Me.pnlFilter.Controls.Add(Me.lblSampai)
            Me.pnlFilter.Controls.Add(Me.dtpDari)
            Me.pnlFilter.Controls.Add(Me.lblDari)
            Me.pnlFilter.Controls.Add(Me.cboJenisTanggal)
            Me.pnlFilter.Controls.Add(Me.lblJenisTanggal)
            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.pnlFilter.Location = New System.Drawing.Point(3, 3)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Size = New System.Drawing.Size(1046, 96)
            Me.pnlFilter.TabIndex = 0
            '
            'lblJenisTanggal
            '
            Me.lblJenisTanggal.AutoSize = True
            Me.lblJenisTanggal.Location = New System.Drawing.Point(12, 16)
            Me.lblJenisTanggal.Name = "lblJenisTanggal"
            Me.lblJenisTanggal.Size = New System.Drawing.Size(76, 15)
            Me.lblJenisTanggal.TabIndex = 0
            Me.lblJenisTanggal.Text = "Berdasarkan:"
            '
            'cboJenisTanggal
            '
            Me.cboJenisTanggal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboJenisTanggal.FormattingEnabled = True
            Me.cboJenisTanggal.Items.AddRange(New Object() {"Tanggal Main", "Tanggal Pesan"})
            Me.cboJenisTanggal.Location = New System.Drawing.Point(94, 13)
            Me.cboJenisTanggal.Name = "cboJenisTanggal"
            Me.cboJenisTanggal.Size = New System.Drawing.Size(140, 23)
            Me.cboJenisTanggal.TabIndex = 1
            '
            'lblDari
            '
            Me.lblDari.AutoSize = True
            Me.lblDari.Location = New System.Drawing.Point(250, 16)
            Me.lblDari.Name = "lblDari"
            Me.lblDari.Size = New System.Drawing.Size(32, 15)
            Me.lblDari.TabIndex = 2
            Me.lblDari.Text = "Dari:"
            '
            'dtpDari
            '
            Me.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDari.Location = New System.Drawing.Point(288, 13)
            Me.dtpDari.Name = "dtpDari"
            Me.dtpDari.Size = New System.Drawing.Size(125, 23)
            Me.dtpDari.TabIndex = 3
            '
            'lblSampai
            '
            Me.lblSampai.AutoSize = True
            Me.lblSampai.Location = New System.Drawing.Point(423, 16)
            Me.lblSampai.Name = "lblSampai"
            Me.lblSampai.Size = New System.Drawing.Size(27, 15)
            Me.lblSampai.TabIndex = 4
            Me.lblSampai.Text = "s.d.:"
            '
            'dtpSampai
            '
            Me.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSampai.Location = New System.Drawing.Point(456, 13)
            Me.dtpSampai.Name = "dtpSampai"
            Me.dtpSampai.Size = New System.Drawing.Size(125, 23)
            Me.dtpSampai.TabIndex = 5
            '
            'lblLapangan
            '
            Me.lblLapangan.AutoSize = True
            Me.lblLapangan.Location = New System.Drawing.Point(600, 16)
            Me.lblLapangan.Name = "lblLapangan"
            Me.lblLapangan.Size = New System.Drawing.Size(62, 15)
            Me.lblLapangan.TabIndex = 6
            Me.lblLapangan.Text = "Lapangan:"
            '
            'cboLapangan
            '
            Me.cboLapangan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboLapangan.FormattingEnabled = True
            Me.cboLapangan.Location = New System.Drawing.Point(668, 13)
            Me.cboLapangan.Name = "cboLapangan"
            Me.cboLapangan.Size = New System.Drawing.Size(185, 23)
            Me.cboLapangan.TabIndex = 7
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(12, 56)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(42, 15)
            Me.lblStatus.TabIndex = 8
            Me.lblStatus.Text = "Status:"
            '
            'cboStatus
            '
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatus.FormattingEnabled = True
            Me.cboStatus.Items.AddRange(New Object() {"Semua Status", "Menunggu DP", "DP Terbayar", "Lunas", "Kedaluwarsa"})
            Me.cboStatus.Location = New System.Drawing.Point(94, 53)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Size = New System.Drawing.Size(140, 23)
            Me.cboStatus.TabIndex = 9
            '
            'lblCari
            '
            Me.lblCari.AutoSize = True
            Me.lblCari.Location = New System.Drawing.Point(250, 56)
            Me.lblCari.Name = "lblCari"
            Me.lblCari.Size = New System.Drawing.Size(30, 15)
            Me.lblCari.TabIndex = 10
            Me.lblCari.Text = "Cari:"
            '
            'txtCari
            '
            Me.txtCari.Location = New System.Drawing.Point(288, 53)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Kode booking / nama pemesan / no telp / kasir..."
            Me.txtCari.Size = New System.Drawing.Size(293, 23)
            Me.txtCari.TabIndex = 11
            '
            'btnTampilkan
            '
            Me.btnTampilkan.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnTampilkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnTampilkan.ForeColor = System.Drawing.Color.White
            Me.btnTampilkan.Location = New System.Drawing.Point(600, 48)
            Me.btnTampilkan.Name = "btnTampilkan"
            Me.btnTampilkan.Size = New System.Drawing.Size(145, 34)
            Me.btnTampilkan.TabIndex = 12
            Me.btnTampilkan.Text = "Tampilkan Data"
            Me.btnTampilkan.UseVisualStyleBackColor = False
            '
            'btnResetFilter
            '
            Me.btnResetFilter.BackColor = System.Drawing.Color.Gray
            Me.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnResetFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnResetFilter.ForeColor = System.Drawing.Color.White
            Me.btnResetFilter.Location = New System.Drawing.Point(755, 48)
            Me.btnResetFilter.Name = "btnResetFilter"
            Me.btnResetFilter.Size = New System.Drawing.Size(120, 34)
            Me.btnResetFilter.TabIndex = 13
            Me.btnResetFilter.Text = "Reset Filter"
            Me.btnResetFilter.UseVisualStyleBackColor = False
            '
            'pnlAksi
            '
            Me.pnlAksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.pnlAksi.Controls.Add(Me.btnTutup)
            Me.pnlAksi.Controls.Add(Me.btnCetakStruk)
            Me.pnlAksi.Controls.Add(Me.btnCetakLaporan)
            Me.pnlAksi.Controls.Add(Me.btnExportCsv)
            Me.pnlAksi.Controls.Add(Me.lblInfoBaris)
            Me.pnlAksi.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlAksi.Location = New System.Drawing.Point(3, 519)
            Me.pnlAksi.Name = "pnlAksi"
            Me.pnlAksi.Size = New System.Drawing.Size(1046, 56)
            Me.pnlAksi.TabIndex = 3
            '
            'lblInfoBaris
            '
            Me.lblInfoBaris.AutoSize = True
            Me.lblInfoBaris.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblInfoBaris.ForeColor = System.Drawing.Color.DimGray
            Me.lblInfoBaris.Location = New System.Drawing.Point(12, 20)
            Me.lblInfoBaris.Name = "lblInfoBaris"
            Me.lblInfoBaris.Size = New System.Drawing.Size(195, 15)
            Me.lblInfoBaris.TabIndex = 0
            Me.lblInfoBaris.Text = "Menampilkan 0 baris slot transaksi"
            '
            'btnExportCsv
            '
            Me.btnExportCsv.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnExportCsv.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportCsv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnExportCsv.ForeColor = System.Drawing.Color.White
            Me.btnExportCsv.Location = New System.Drawing.Point(375, 10)
            Me.btnExportCsv.Name = "btnExportCsv"
            Me.btnExportCsv.Size = New System.Drawing.Size(170, 36)
            Me.btnExportCsv.TabIndex = 1
            Me.btnExportCsv.Text = "Export CSV / Excel"
            Me.btnExportCsv.UseVisualStyleBackColor = False
            '
            'btnCetakLaporan
            '
            Me.btnCetakLaporan.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnCetakLaporan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetakLaporan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnCetakLaporan.ForeColor = System.Drawing.Color.White
            Me.btnCetakLaporan.Location = New System.Drawing.Point(555, 10)
            Me.btnCetakLaporan.Name = "btnCetakLaporan"
            Me.btnCetakLaporan.Size = New System.Drawing.Size(175, 36)
            Me.btnCetakLaporan.TabIndex = 2
            Me.btnCetakLaporan.Text = "Cetak / PDF Laporan"
            Me.btnCetakLaporan.UseVisualStyleBackColor = False
            '
            'btnCetakStruk
            '
            Me.btnCetakStruk.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCetakStruk.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakStruk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetakStruk.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnCetakStruk.ForeColor = System.Drawing.Color.White
            Me.btnCetakStruk.Location = New System.Drawing.Point(740, 10)
            Me.btnCetakStruk.Name = "btnCetakStruk"
            Me.btnCetakStruk.Size = New System.Drawing.Size(175, 36)
            Me.btnCetakStruk.TabIndex = 3
            Me.btnCetakStruk.Text = "Cetak Struk Booking"
            Me.btnCetakStruk.UseVisualStyleBackColor = False
            '
            'btnTutup
            '
            Me.btnTutup.BackColor = System.Drawing.Color.Gray
            Me.btnTutup.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTutup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTutup.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnTutup.ForeColor = System.Drawing.Color.White
            Me.btnTutup.Location = New System.Drawing.Point(925, 10)
            Me.btnTutup.Name = "btnTutup"
            Me.btnTutup.Size = New System.Drawing.Size(110, 36)
            Me.btnTutup.TabIndex = 4
            Me.btnTutup.Text = "Kembali"
            Me.btnTutup.UseVisualStyleBackColor = False
            '
            'tabBulanan
            '
            Me.tabBulanan.BackColor = System.Drawing.Color.White
            Me.tabBulanan.Controls.Add(Me.dgvBulanan)
            Me.tabBulanan.Controls.Add(Me.pnlSummaryBulanan)
            Me.tabBulanan.Controls.Add(Me.pnlFilterBulanan)
            Me.tabBulanan.Controls.Add(Me.pnlAksiBulanan)
            Me.tabBulanan.Location = New System.Drawing.Point(4, 26)
            Me.tabBulanan.Name = "tabBulanan"
            Me.tabBulanan.Padding = New System.Windows.Forms.Padding(3)
            Me.tabBulanan.Size = New System.Drawing.Size(1052, 578)
            Me.tabBulanan.TabIndex = 1
            Me.tabBulanan.Text = "  Ringkasan Bulanan & Okupansi  "
            '
            'dgvBulanan
            '
            Me.dgvBulanan.AllowUserToAddRows = False
            Me.dgvBulanan.AllowUserToDeleteRows = False
            Me.dgvBulanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvBulanan.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvBulanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvBulanan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvBulanan.Location = New System.Drawing.Point(3, 139)
            Me.dgvBulanan.MultiSelect = False
            Me.dgvBulanan.Name = "dgvBulanan"
            Me.dgvBulanan.ReadOnly = True
            Me.dgvBulanan.RowHeadersVisible = False
            Me.dgvBulanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvBulanan.Size = New System.Drawing.Size(1046, 380)
            Me.dgvBulanan.TabIndex = 2
            '
            'pnlSummaryBulanan
            '
            Me.pnlSummaryBulanan.BackColor = System.Drawing.Color.White
            Me.pnlSummaryBulanan.Controls.Add(Me.pnlCardOkupansiBln)
            Me.pnlSummaryBulanan.Controls.Add(Me.pnlCardSlotBln)
            Me.pnlSummaryBulanan.Controls.Add(Me.pnlCardTransBln)
            Me.pnlSummaryBulanan.Controls.Add(Me.pnlCardPendapatanBln)
            Me.pnlSummaryBulanan.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlSummaryBulanan.Location = New System.Drawing.Point(3, 57)
            Me.pnlSummaryBulanan.Name = "pnlSummaryBulanan"
            Me.pnlSummaryBulanan.Size = New System.Drawing.Size(1046, 82)
            Me.pnlSummaryBulanan.TabIndex = 1
            '
            'pnlCardPendapatanBln
            '
            Me.pnlCardPendapatanBln.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(245, Byte), Integer))
            Me.pnlCardPendapatanBln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardPendapatanBln.Controls.Add(Me.lblBlnTotalPendapatan)
            Me.pnlCardPendapatanBln.Controls.Add(Me.lblCardPendapatanBlnTitle)
            Me.pnlCardPendapatanBln.Location = New System.Drawing.Point(10, 8)
            Me.pnlCardPendapatanBln.Name = "pnlCardPendapatanBln"
            Me.pnlCardPendapatanBln.Size = New System.Drawing.Size(260, 66)
            Me.pnlCardPendapatanBln.TabIndex = 0
            '
            'lblCardPendapatanBlnTitle
            '
            Me.lblCardPendapatanBlnTitle.AutoSize = True
            Me.lblCardPendapatanBlnTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardPendapatanBlnTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardPendapatanBlnTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardPendapatanBlnTitle.Name = "lblCardPendapatanBlnTitle"
            Me.lblCardPendapatanBlnTitle.Size = New System.Drawing.Size(145, 15)
            Me.lblCardPendapatanBlnTitle.TabIndex = 0
            Me.lblCardPendapatanBlnTitle.Text = "Total Pendapatan Terbayar"
            '
            'lblBlnTotalPendapatan
            '
            Me.lblBlnTotalPendapatan.AutoSize = True
            Me.lblBlnTotalPendapatan.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBlnTotalPendapatan.ForeColor = System.Drawing.Color.SeaGreen
            Me.lblBlnTotalPendapatan.Location = New System.Drawing.Point(10, 28)
            Me.lblBlnTotalPendapatan.Name = "lblBlnTotalPendapatan"
            Me.lblBlnTotalPendapatan.Size = New System.Drawing.Size(48, 25)
            Me.lblBlnTotalPendapatan.TabIndex = 1
            Me.lblBlnTotalPendapatan.Text = "Rp 0"
            '
            'pnlCardTransBln
            '
            Me.pnlCardTransBln.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlCardTransBln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardTransBln.Controls.Add(Me.lblBlnTotalTransaksi)
            Me.pnlCardTransBln.Controls.Add(Me.lblCardTransBlnTitle)
            Me.pnlCardTransBln.Location = New System.Drawing.Point(285, 8)
            Me.pnlCardTransBln.Name = "pnlCardTransBln"
            Me.pnlCardTransBln.Size = New System.Drawing.Size(235, 66)
            Me.pnlCardTransBln.TabIndex = 1
            '
            'lblCardTransBlnTitle
            '
            Me.lblCardTransBlnTitle.AutoSize = True
            Me.lblCardTransBlnTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardTransBlnTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardTransBlnTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardTransBlnTitle.Name = "lblCardTransBlnTitle"
            Me.lblCardTransBlnTitle.Size = New System.Drawing.Size(145, 15)
            Me.lblCardTransBlnTitle.TabIndex = 0
            Me.lblCardTransBlnTitle.Text = "Total Transaksi Pembayaran"
            '
            'lblBlnTotalTransaksi
            '
            Me.lblBlnTotalTransaksi.AutoSize = True
            Me.lblBlnTotalTransaksi.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBlnTotalTransaksi.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.lblBlnTotalTransaksi.Location = New System.Drawing.Point(10, 28)
            Me.lblBlnTotalTransaksi.Name = "lblBlnTotalTransaksi"
            Me.lblBlnTotalTransaksi.Size = New System.Drawing.Size(22, 25)
            Me.lblBlnTotalTransaksi.TabIndex = 1
            Me.lblBlnTotalTransaksi.Text = "0"
            '
            'pnlCardSlotBln
            '
            Me.pnlCardSlotBln.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlCardSlotBln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardSlotBln.Controls.Add(Me.lblBlnTotalSlot)
            Me.pnlCardSlotBln.Controls.Add(Me.lblCardSlotBlnTitle)
            Me.pnlCardSlotBln.Location = New System.Drawing.Point(535, 8)
            Me.pnlCardSlotBln.Name = "pnlCardSlotBln"
            Me.pnlCardSlotBln.Size = New System.Drawing.Size(235, 66)
            Me.pnlCardSlotBln.TabIndex = 2
            '
            'lblCardSlotBlnTitle
            '
            Me.lblCardSlotBlnTitle.AutoSize = True
            Me.lblCardSlotBlnTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardSlotBlnTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardSlotBlnTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardSlotBlnTitle.Name = "lblCardSlotBlnTitle"
            Me.lblCardSlotBlnTitle.Size = New System.Drawing.Size(96, 15)
            Me.lblCardSlotBlnTitle.TabIndex = 0
            Me.lblCardSlotBlnTitle.Text = "Total Slot Terisi"
            '
            'lblBlnTotalSlot
            '
            Me.lblBlnTotalSlot.AutoSize = True
            Me.lblBlnTotalSlot.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBlnTotalSlot.ForeColor = System.Drawing.Color.SteelBlue
            Me.lblBlnTotalSlot.Location = New System.Drawing.Point(10, 28)
            Me.lblBlnTotalSlot.Name = "lblBlnTotalSlot"
            Me.lblBlnTotalSlot.Size = New System.Drawing.Size(58, 25)
            Me.lblBlnTotalSlot.TabIndex = 1
            Me.lblBlnTotalSlot.Text = "0 Slot"
            '
            'pnlCardOkupansiBln
            '
            Me.pnlCardOkupansiBln.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.pnlCardOkupansiBln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardOkupansiBln.Controls.Add(Me.lblBlnRataOkupansi)
            Me.pnlCardOkupansiBln.Controls.Add(Me.lblCardOkupansiBlnTitle)
            Me.pnlCardOkupansiBln.Location = New System.Drawing.Point(785, 8)
            Me.pnlCardOkupansiBln.Name = "pnlCardOkupansiBln"
            Me.pnlCardOkupansiBln.Size = New System.Drawing.Size(250, 66)
            Me.pnlCardOkupansiBln.TabIndex = 3
            '
            'lblCardOkupansiBlnTitle
            '
            Me.lblCardOkupansiBlnTitle.AutoSize = True
            Me.lblCardOkupansiBlnTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCardOkupansiBlnTitle.ForeColor = System.Drawing.Color.DimGray
            Me.lblCardOkupansiBlnTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblCardOkupansiBlnTitle.Name = "lblCardOkupansiBlnTitle"
            Me.lblCardOkupansiBlnTitle.Size = New System.Drawing.Size(113, 15)
            Me.lblCardOkupansiBlnTitle.TabIndex = 0
            Me.lblCardOkupansiBlnTitle.Text = "Rata-rata Okupansi"
            '
            'lblBlnRataOkupansi
            '
            Me.lblBlnRataOkupansi.AutoSize = True
            Me.lblBlnRataOkupansi.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBlnRataOkupansi.ForeColor = System.Drawing.Color.DarkOrange
            Me.lblBlnRataOkupansi.Location = New System.Drawing.Point(10, 28)
            Me.lblBlnRataOkupansi.Name = "lblBlnRataOkupansi"
            Me.lblBlnRataOkupansi.Size = New System.Drawing.Size(65, 25)
            Me.lblBlnRataOkupansi.TabIndex = 1
            Me.lblBlnRataOkupansi.Text = "0,00 %"
            '
            'pnlFilterBulanan
            '
            Me.pnlFilterBulanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.pnlFilterBulanan.Controls.Add(Me.btnRefreshBulanan)
            Me.pnlFilterBulanan.Controls.Add(Me.cboTahun)
            Me.pnlFilterBulanan.Controls.Add(Me.lblTahun)
            Me.pnlFilterBulanan.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilterBulanan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.pnlFilterBulanan.Location = New System.Drawing.Point(3, 3)
            Me.pnlFilterBulanan.Name = "pnlFilterBulanan"
            Me.pnlFilterBulanan.Size = New System.Drawing.Size(1046, 54)
            Me.pnlFilterBulanan.TabIndex = 0
            '
            'lblTahun
            '
            Me.lblTahun.AutoSize = True
            Me.lblTahun.Location = New System.Drawing.Point(12, 18)
            Me.lblTahun.Name = "lblTahun"
            Me.lblTahun.Size = New System.Drawing.Size(70, 15)
            Me.lblTahun.TabIndex = 0
            Me.lblTahun.Text = "Pilih Tahun:"
            '
            'cboTahun
            '
            Me.cboTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTahun.FormattingEnabled = True
            Me.cboTahun.Location = New System.Drawing.Point(90, 15)
            Me.cboTahun.Name = "cboTahun"
            Me.cboTahun.Size = New System.Drawing.Size(160, 23)
            Me.cboTahun.TabIndex = 1
            '
            'btnRefreshBulanan
            '
            Me.btnRefreshBulanan.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnRefreshBulanan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefreshBulanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRefreshBulanan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnRefreshBulanan.ForeColor = System.Drawing.Color.White
            Me.btnRefreshBulanan.Location = New System.Drawing.Point(265, 10)
            Me.btnRefreshBulanan.Name = "btnRefreshBulanan"
            Me.btnRefreshBulanan.Size = New System.Drawing.Size(175, 34)
            Me.btnRefreshBulanan.TabIndex = 2
            Me.btnRefreshBulanan.Text = "Muat Ulang Ringkasan"
            Me.btnRefreshBulanan.UseVisualStyleBackColor = False
            '
            'pnlAksiBulanan
            '
            Me.pnlAksiBulanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.pnlAksiBulanan.Controls.Add(Me.btnCetakBulanan)
            Me.pnlAksiBulanan.Controls.Add(Me.btnExportBulananCsv)
            Me.pnlAksiBulanan.Controls.Add(Me.lblInfoBulanan)
            Me.pnlAksiBulanan.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlAksiBulanan.Location = New System.Drawing.Point(3, 519)
            Me.pnlAksiBulanan.Name = "pnlAksiBulanan"
            Me.pnlAksiBulanan.Size = New System.Drawing.Size(1046, 56)
            Me.pnlAksiBulanan.TabIndex = 3
            '
            'lblInfoBulanan
            '
            Me.lblInfoBulanan.AutoSize = True
            Me.lblInfoBulanan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblInfoBulanan.ForeColor = System.Drawing.Color.DimGray
            Me.lblInfoBulanan.Location = New System.Drawing.Point(12, 20)
            Me.lblInfoBulanan.Name = "lblInfoBulanan"
            Me.lblInfoBulanan.Size = New System.Drawing.Size(186, 15)
            Me.lblInfoBulanan.TabIndex = 0
            Me.lblInfoBulanan.Text = "Menampilkan 0 periode bulanan"
            '
            'btnExportBulananCsv
            '
            Me.btnExportBulananCsv.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnExportBulananCsv.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportBulananCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportBulananCsv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnExportBulananCsv.ForeColor = System.Drawing.Color.White
            Me.btnExportBulananCsv.Location = New System.Drawing.Point(650, 10)
            Me.btnExportBulananCsv.Name = "btnExportBulananCsv"
            Me.btnExportBulananCsv.Size = New System.Drawing.Size(185, 36)
            Me.btnExportBulananCsv.TabIndex = 1
            Me.btnExportBulananCsv.Text = "Export CSV Bulanan"
            Me.btnExportBulananCsv.UseVisualStyleBackColor = False
            '
            'btnCetakBulanan
            '
            Me.btnCetakBulanan.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnCetakBulanan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakBulanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetakBulanan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnCetakBulanan.ForeColor = System.Drawing.Color.White
            Me.btnCetakBulanan.Location = New System.Drawing.Point(845, 10)
            Me.btnCetakBulanan.Name = "btnCetakBulanan"
            Me.btnCetakBulanan.Size = New System.Drawing.Size(190, 36)
            Me.btnCetakBulanan.TabIndex = 2
            Me.btnCetakBulanan.Text = "Cetak / PDF Ringkasan"
            Me.btnCetakBulanan.UseVisualStyleBackColor = False
            '
            'frmLaporan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(1060, 680)
            Me.Controls.Add(Me.tabLaporan)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.Name = "frmLaporan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Laporan Pendapatan & Okupansi - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tabLaporan.ResumeLayout(False)
            Me.tabTransaksi.ResumeLayout(False)
            CType(Me.dgvLaporan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSummary.ResumeLayout(False)
            Me.pnlCardSisa.ResumeLayout(False)
            Me.pnlCardSisa.PerformLayout()
            Me.pnlCardBayar.ResumeLayout(False)
            Me.pnlCardBayar.PerformLayout()
            Me.pnlCardSewa.ResumeLayout(False)
            Me.pnlCardSewa.PerformLayout()
            Me.pnlCardSlot.ResumeLayout(False)
            Me.pnlCardSlot.PerformLayout()
            Me.pnlCardBooking.ResumeLayout(False)
            Me.pnlCardBooking.PerformLayout()
            Me.pnlFilter.ResumeLayout(False)
            Me.pnlFilter.PerformLayout()
            Me.pnlAksi.ResumeLayout(False)
            Me.pnlAksi.PerformLayout()
            Me.tabBulanan.ResumeLayout(False)
            CType(Me.dgvBulanan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSummaryBulanan.ResumeLayout(False)
            Me.pnlCardOkupansiBln.ResumeLayout(False)
            Me.pnlCardOkupansiBln.PerformLayout()
            Me.pnlCardSlotBln.ResumeLayout(False)
            Me.pnlCardSlotBln.PerformLayout()
            Me.pnlCardTransBln.ResumeLayout(False)
            Me.pnlCardTransBln.PerformLayout()
            Me.pnlCardPendapatanBln.ResumeLayout(False)
            Me.pnlCardPendapatanBln.PerformLayout()
            Me.pnlFilterBulanan.ResumeLayout(False)
            Me.pnlFilterBulanan.PerformLayout()
            Me.pnlAksiBulanan.ResumeLayout(False)
            Me.pnlAksiBulanan.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents tabLaporan As System.Windows.Forms.TabControl
        Friend WithEvents tabTransaksi As System.Windows.Forms.TabPage
        Friend WithEvents tabBulanan As System.Windows.Forms.TabPage
        Friend WithEvents pnlFilter As System.Windows.Forms.Panel
        Friend WithEvents lblJenisTanggal As System.Windows.Forms.Label
        Friend WithEvents cboJenisTanggal As System.Windows.Forms.ComboBox
        Friend WithEvents lblDari As System.Windows.Forms.Label
        Friend WithEvents dtpDari As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSampai As System.Windows.Forms.Label
        Friend WithEvents dtpSampai As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblLapangan As System.Windows.Forms.Label
        Friend WithEvents cboLapangan As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblCari As System.Windows.Forms.Label
        Friend WithEvents txtCari As System.Windows.Forms.TextBox
        Friend WithEvents btnTampilkan As System.Windows.Forms.Button
        Friend WithEvents btnResetFilter As System.Windows.Forms.Button
        Friend WithEvents pnlSummary As System.Windows.Forms.Panel
        Friend WithEvents pnlCardBooking As System.Windows.Forms.Panel
        Friend WithEvents lblCardBookingTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalBooking As System.Windows.Forms.Label
        Friend WithEvents pnlCardSlot As System.Windows.Forms.Panel
        Friend WithEvents lblCardSlotTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalSlot As System.Windows.Forms.Label
        Friend WithEvents pnlCardSewa As System.Windows.Forms.Panel
        Friend WithEvents lblCardSewaTitle As System.Windows.Forms.Label
        Friend WithEvents lblGrandTotalSewa As System.Windows.Forms.Label
        Friend WithEvents pnlCardBayar As System.Windows.Forms.Panel
        Friend WithEvents lblCardBayarTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalBayarMasuk As System.Windows.Forms.Label
        Friend WithEvents pnlCardSisa As System.Windows.Forms.Panel
        Friend WithEvents lblCardSisaTitle As System.Windows.Forms.Label
        Friend WithEvents lblSisaBelumLunas As System.Windows.Forms.Label
        Friend WithEvents dgvLaporan As System.Windows.Forms.DataGridView
        Friend WithEvents pnlAksi As System.Windows.Forms.Panel
        Friend WithEvents lblInfoBaris As System.Windows.Forms.Label
        Friend WithEvents btnExportCsv As System.Windows.Forms.Button
        Friend WithEvents btnCetakLaporan As System.Windows.Forms.Button
        Friend WithEvents btnCetakStruk As System.Windows.Forms.Button
        Friend WithEvents btnTutup As System.Windows.Forms.Button
        Friend WithEvents pnlFilterBulanan As System.Windows.Forms.Panel
        Friend WithEvents lblTahun As System.Windows.Forms.Label
        Friend WithEvents cboTahun As System.Windows.Forms.ComboBox
        Friend WithEvents btnRefreshBulanan As System.Windows.Forms.Button
        Friend WithEvents pnlSummaryBulanan As System.Windows.Forms.Panel
        Friend WithEvents pnlCardPendapatanBln As System.Windows.Forms.Panel
        Friend WithEvents lblCardPendapatanBlnTitle As System.Windows.Forms.Label
        Friend WithEvents lblBlnTotalPendapatan As System.Windows.Forms.Label
        Friend WithEvents pnlCardTransBln As System.Windows.Forms.Panel
        Friend WithEvents lblCardTransBlnTitle As System.Windows.Forms.Label
        Friend WithEvents lblBlnTotalTransaksi As System.Windows.Forms.Label
        Friend WithEvents pnlCardSlotBln As System.Windows.Forms.Panel
        Friend WithEvents lblCardSlotBlnTitle As System.Windows.Forms.Label
        Friend WithEvents lblBlnTotalSlot As System.Windows.Forms.Label
        Friend WithEvents pnlCardOkupansiBln As System.Windows.Forms.Panel
        Friend WithEvents lblCardOkupansiBlnTitle As System.Windows.Forms.Label
        Friend WithEvents lblBlnRataOkupansi As System.Windows.Forms.Label
        Friend WithEvents dgvBulanan As System.Windows.Forms.DataGridView
        Friend WithEvents pnlAksiBulanan As System.Windows.Forms.Panel
        Friend WithEvents lblInfoBulanan As System.Windows.Forms.Label
        Friend WithEvents btnExportBulananCsv As System.Windows.Forms.Button
        Friend WithEvents btnCetakBulanan As System.Windows.Forms.Button
    End Class

End Namespace