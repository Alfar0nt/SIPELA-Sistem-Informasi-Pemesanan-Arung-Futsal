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
            Me.btnKembali = New System.Windows.Forms.Button()
            Me.lblSubJudul = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.pnlToolbar = New System.Windows.Forms.Panel()
            Me.btnCetakLaporan = New System.Windows.Forms.Button()
            Me.btnEksporCSV = New System.Windows.Forms.Button()
            Me.btnFilter = New System.Windows.Forms.Button()
            Me.cmbJenisLaporan = New System.Windows.Forms.ComboBox()
            Me.lblJenisLaporan = New System.Windows.Forms.Label()
            Me.cmbBulan = New System.Windows.Forms.ComboBox()
            Me.lblBulan = New System.Windows.Forms.Label()
            Me.cmbTahun = New System.Windows.Forms.ComboBox()
            Me.lblTahun = New System.Windows.Forms.Label()
            Me.pnlCards = New System.Windows.Forms.Panel()
            Me.pnlCardMoM = New System.Windows.Forms.Panel()
            Me.lblValMoM = New System.Windows.Forms.Label()
            Me.lblTitleMoM = New System.Windows.Forms.Label()
            Me.pnlCardOkupansi = New System.Windows.Forms.Panel()
            Me.lblValOkupansi = New System.Windows.Forms.Label()
            Me.lblTitleOkupansi = New System.Windows.Forms.Label()
            Me.pnlCardOmzet = New System.Windows.Forms.Panel()
            Me.lblValOmzet = New System.Windows.Forms.Label()
            Me.lblTitleOmzet = New System.Windows.Forms.Label()
            Me.pnlGridContainer = New System.Windows.Forms.Panel()
            Me.dgvLaporan = New System.Windows.Forms.DataGridView()
            Me.pnlFooter = New System.Windows.Forms.Panel()
            Me.lblInfoStatus = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlToolbar.SuspendLayout()
            Me.pnlCards.SuspendLayout()
            Me.pnlCardMoM.SuspendLayout()
            Me.pnlCardOkupansi.SuspendLayout()
            Me.pnlCardOmzet.SuspendLayout()
            Me.pnlGridContainer.SuspendLayout()
            CType(Me.dgvLaporan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFooter.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(1124, 75)
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
            Me.btnKembali.Location = New System.Drawing.Point(990, 18)
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
            Me.lblSubJudul.Size = New System.Drawing.Size(469, 17)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Rekapitulasi pendapatan bulanan, tingkat okupansi lapangan, dan ekspor spreadsheet"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(22, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(393, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "LAPORAN & ANALITIK PENDAPATAN"
            '
            'pnlToolbar
            '
            Me.pnlToolbar.BackColor = System.Drawing.Color.White
            Me.pnlToolbar.Controls.Add(Me.btnCetakLaporan)
            Me.pnlToolbar.Controls.Add(Me.btnEksporCSV)
            Me.pnlToolbar.Controls.Add(Me.btnFilter)
            Me.pnlToolbar.Controls.Add(Me.cmbJenisLaporan)
            Me.pnlToolbar.Controls.Add(Me.lblJenisLaporan)
            Me.pnlToolbar.Controls.Add(Me.cmbBulan)
            Me.pnlToolbar.Controls.Add(Me.lblBulan)
            Me.pnlToolbar.Controls.Add(Me.cmbTahun)
            Me.pnlToolbar.Controls.Add(Me.lblTahun)
            Me.pnlToolbar.Location = New System.Drawing.Point(20, 90)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlToolbar.Size = New System.Drawing.Size(1084, 60)
            Me.pnlToolbar.TabIndex = 1
            '
            'btnCetakLaporan
            '
            Me.btnCetakLaporan.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.btnCetakLaporan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetakLaporan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnCetakLaporan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnCetakLaporan.Location = New System.Drawing.Point(945, 14)
            Me.btnCetakLaporan.Name = "btnCetakLaporan"
            Me.btnCetakLaporan.Size = New System.Drawing.Size(125, 32)
            Me.btnCetakLaporan.TabIndex = 8
            Me.btnCetakLaporan.Text = "🖨️ Cetak Ringkas"
            Me.btnCetakLaporan.UseVisualStyleBackColor = False
            '
            'btnEksporCSV
            '
            Me.btnEksporCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.btnEksporCSV.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnEksporCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEksporCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnEksporCSV.ForeColor = System.Drawing.Color.White
            Me.btnEksporCSV.Location = New System.Drawing.Point(795, 14)
            Me.btnEksporCSV.Name = "btnEksporCSV"
            Me.btnEksporCSV.Size = New System.Drawing.Size(140, 32)
            Me.btnEksporCSV.TabIndex = 7
            Me.btnEksporCSV.Text = "📥 Ekspor Excel/CSV"
            Me.btnEksporCSV.UseVisualStyleBackColor = False
            '
            'btnFilter
            '
            Me.btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnFilter.Location = New System.Drawing.Point(695, 14)
            Me.btnFilter.Name = "btnFilter"
            Me.btnFilter.Size = New System.Drawing.Size(85, 32)
            Me.btnFilter.TabIndex = 6
            Me.btnFilter.Text = "Tampilkan"
            Me.btnFilter.UseVisualStyleBackColor = False
            '
            'cmbJenisLaporan
            '
            Me.cmbJenisLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbJenisLaporan.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cmbJenisLaporan.FormattingEnabled = True
            Me.cmbJenisLaporan.Items.AddRange(New Object() {"Ringkasan Bulanan (MoM)", "Rincian Transaksi Pembayaran", "Rincian Pemesanan Sewa"})
            Me.cmbJenisLaporan.Location = New System.Drawing.Point(445, 17)
            Me.cmbJenisLaporan.Name = "cmbJenisLaporan"
            Me.cmbJenisLaporan.Size = New System.Drawing.Size(235, 24)
            Me.cmbJenisLaporan.TabIndex = 5
            '
            'lblJenisLaporan
            '
            Me.lblJenisLaporan.AutoSize = True
            Me.lblJenisLaporan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJenisLaporan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblJenisLaporan.Location = New System.Drawing.Point(365, 21)
            Me.lblJenisLaporan.Name = "lblJenisLaporan"
            Me.lblJenisLaporan.Size = New System.Drawing.Size(73, 15)
            Me.lblJenisLaporan.TabIndex = 4
            Me.lblJenisLaporan.Text = "Jenis Rekap:"
            '
            'cmbBulan
            '
            Me.cmbBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBulan.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cmbBulan.FormattingEnabled = True
            Me.cmbBulan.Location = New System.Drawing.Point(215, 17)
            Me.cmbBulan.Name = "cmbBulan"
            Me.cmbBulan.Size = New System.Drawing.Size(135, 24)
            Me.cmbBulan.TabIndex = 3
            '
            'lblBulan
            '
            Me.lblBulan.AutoSize = True
            Me.lblBulan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBulan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblBulan.Location = New System.Drawing.Point(168, 21)
            Me.lblBulan.Name = "lblBulan"
            Me.lblBulan.Size = New System.Drawing.Size(41, 15)
            Me.lblBulan.TabIndex = 2
            Me.lblBulan.Text = "Bulan:"
            '
            'cmbTahun
            '
            Me.cmbTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTahun.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cmbTahun.FormattingEnabled = True
            Me.cmbTahun.Location = New System.Drawing.Point(62, 17)
            Me.cmbTahun.Name = "cmbTahun"
            Me.cmbTahun.Size = New System.Drawing.Size(90, 24)
            Me.cmbTahun.TabIndex = 1
            '
            'lblTahun
            '
            Me.lblTahun.AutoSize = True
            Me.lblTahun.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTahun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTahun.Location = New System.Drawing.Point(12, 21)
            Me.lblTahun.Name = "lblTahun"
            Me.lblTahun.Size = New System.Drawing.Size(44, 15)
            Me.lblTahun.TabIndex = 0
            Me.lblTahun.Text = "Tahun:"
            '
            'pnlCards
            '
            Me.pnlCards.Controls.Add(Me.pnlCardMoM)
            Me.pnlCards.Controls.Add(Me.pnlCardOkupansi)
            Me.pnlCards.Controls.Add(Me.pnlCardOmzet)
            Me.pnlCards.Location = New System.Drawing.Point(20, 160)
            Me.pnlCards.Name = "pnlCards"
            Me.pnlCards.Size = New System.Drawing.Size(1084, 90)
            Me.pnlCards.TabIndex = 2
            '
            'pnlCardMoM
            '
            Me.pnlCardMoM.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.pnlCardMoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardMoM.Controls.Add(Me.lblValMoM)
            Me.pnlCardMoM.Controls.Add(Me.lblTitleMoM)
            Me.pnlCardMoM.Location = New System.Drawing.Point(736, 0)
            Me.pnlCardMoM.Name = "pnlCardMoM"
            Me.pnlCardMoM.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlCardMoM.Size = New System.Drawing.Size(348, 85)
            Me.pnlCardMoM.TabIndex = 2
            '
            'lblValMoM
            '
            Me.lblValMoM.AutoSize = True
            Me.lblValMoM.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblValMoM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValMoM.Location = New System.Drawing.Point(12, 38)
            Me.lblValMoM.Name = "lblValMoM"
            Me.lblValMoM.Size = New System.Drawing.Size(158, 25)
            Me.lblValMoM.TabIndex = 1
            Me.lblValMoM.Text = "0 Trx | +0.0% MoM"
            '
            'lblTitleMoM
            '
            Me.lblTitleMoM.AutoSize = True
            Me.lblTitleMoM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitleMoM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTitleMoM.Location = New System.Drawing.Point(12, 14)
            Me.lblTitleMoM.Name = "lblTitleMoM"
            Me.lblTitleMoM.Size = New System.Drawing.Size(175, 15)
            Me.lblTitleMoM.TabIndex = 0
            Me.lblTitleMoM.Text = "TOTAL TRANSAKSI & TREN MoM"
            '
            'pnlCardOkupansi
            '
            Me.pnlCardOkupansi.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.pnlCardOkupansi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardOkupansi.Controls.Add(Me.lblValOkupansi)
            Me.pnlCardOkupansi.Controls.Add(Me.lblTitleOkupansi)
            Me.pnlCardOkupansi.Location = New System.Drawing.Point(368, 0)
            Me.pnlCardOkupansi.Name = "pnlCardOkupansi"
            Me.pnlCardOkupansi.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlCardOkupansi.Size = New System.Drawing.Size(348, 85)
            Me.pnlCardOkupansi.TabIndex = 1
            '
            'lblValOkupansi
            '
            Me.lblValOkupansi.AutoSize = True
            Me.lblValOkupansi.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblValOkupansi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblValOkupansi.Location = New System.Drawing.Point(12, 38)
            Me.lblValOkupansi.Name = "lblValOkupansi"
            Me.lblValOkupansi.Size = New System.Drawing.Size(61, 25)
            Me.lblValOkupansi.TabIndex = 1
            Me.lblValOkupansi.Text = "0.0 %"
            '
            'lblTitleOkupansi
            '
            Me.lblTitleOkupansi.AutoSize = True
            Me.lblTitleOkupansi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitleOkupansi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTitleOkupansi.Location = New System.Drawing.Point(12, 14)
            Me.lblTitleOkupansi.Name = "lblTitleOkupansi"
            Me.lblTitleOkupansi.Size = New System.Drawing.Size(182, 15)
            Me.lblTitleOkupansi.TabIndex = 0
            Me.lblTitleOkupansi.Text = "TINGKAT OKUPANSI LAPANGAN"
            '
            'pnlCardOmzet
            '
            Me.pnlCardOmzet.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.pnlCardOmzet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardOmzet.Controls.Add(Me.lblValOmzet)
            Me.pnlCardOmzet.Controls.Add(Me.lblTitleOmzet)
            Me.pnlCardOmzet.Location = New System.Drawing.Point(0, 0)
            Me.pnlCardOmzet.Name = "pnlCardOmzet"
            Me.pnlCardOmzet.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlCardOmzet.Size = New System.Drawing.Size(348, 85)
            Me.pnlCardOmzet.TabIndex = 0
            '
            'lblValOmzet
            '
            Me.lblValOmzet.AutoSize = True
            Me.lblValOmzet.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblValOmzet.ForeColor = System.Drawing.Color.White
            Me.lblValOmzet.Location = New System.Drawing.Point(12, 38)
            Me.lblValOmzet.Name = "lblValOmzet"
            Me.lblValOmzet.Size = New System.Drawing.Size(53, 25)
            Me.lblValOmzet.TabIndex = 1
            Me.lblValOmzet.Text = "Rp 0"
            '
            'lblTitleOmzet
            '
            Me.lblTitleOmzet.AutoSize = True
            Me.lblTitleOmzet.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitleOmzet.ForeColor = System.Drawing.Color.White
            Me.lblTitleOmzet.Location = New System.Drawing.Point(12, 14)
            Me.lblTitleOmzet.Name = "lblTitleOmzet"
            Me.lblTitleOmzet.Size = New System.Drawing.Size(193, 15)
            Me.lblTitleOmzet.TabIndex = 0
            Me.lblTitleOmzet.Text = "TOTAL PENDAPATAN OPERASIONAL"
            '
            'pnlGridContainer
            '
            Me.pnlGridContainer.BackColor = System.Drawing.Color.White
            Me.pnlGridContainer.Controls.Add(Me.dgvLaporan)
            Me.pnlGridContainer.Location = New System.Drawing.Point(20, 260)
            Me.pnlGridContainer.Name = "pnlGridContainer"
            Me.pnlGridContainer.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlGridContainer.Size = New System.Drawing.Size(1084, 370)
            Me.pnlGridContainer.TabIndex = 3
            '
            'dgvLaporan
            '
            Me.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLaporan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvLaporan.Location = New System.Drawing.Point(12, 12)
            Me.dgvLaporan.Name = "dgvLaporan"
            Me.dgvLaporan.Size = New System.Drawing.Size(1060, 346)
            Me.dgvLaporan.TabIndex = 0
            '
            'pnlFooter
            '
            Me.pnlFooter.Controls.Add(Me.lblInfoStatus)
            Me.pnlFooter.Location = New System.Drawing.Point(20, 638)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(1084, 35)
            Me.pnlFooter.TabIndex = 4
            '
            'lblInfoStatus
            '
            Me.lblInfoStatus.AutoSize = True
            Me.lblInfoStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
            Me.lblInfoStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(158, Byte), Integer))
            Me.lblInfoStatus.Location = New System.Drawing.Point(8, 10)
            Me.lblInfoStatus.Name = "lblInfoStatus"
            Me.lblInfoStatus.Size = New System.Drawing.Size(193, 15)
            Me.lblInfoStatus.TabIndex = 0
            Me.lblInfoStatus.Text = "Menampilkan data laporan bulanan..."
            '
            'frmLaporan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1124, 685)
            Me.Controls.Add(Me.pnlFooter)
            Me.Controls.Add(Me.pnlGridContainer)
            Me.Controls.Add(Me.pnlCards)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmLaporan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SIPELA - Laporan & Analitik Pendapatan"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlToolbar.ResumeLayout(False)
            Me.pnlToolbar.PerformLayout()
            Me.pnlCards.ResumeLayout(False)
            Me.pnlCardMoM.ResumeLayout(False)
            Me.pnlCardMoM.PerformLayout()
            Me.pnlCardOkupansi.ResumeLayout(False)
            Me.pnlCardOkupansi.PerformLayout()
            Me.pnlCardOmzet.ResumeLayout(False)
            Me.pnlCardOmzet.PerformLayout()
            Me.pnlGridContainer.ResumeLayout(False)
            CType(Me.dgvLaporan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFooter.ResumeLayout(False)
            Me.pnlFooter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents btnKembali As System.Windows.Forms.Button
        Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
        Friend WithEvents lblTahun As System.Windows.Forms.Label
        Friend WithEvents cmbTahun As System.Windows.Forms.ComboBox
        Friend WithEvents lblBulan As System.Windows.Forms.Label
        Friend WithEvents cmbBulan As System.Windows.Forms.ComboBox
        Friend WithEvents lblJenisLaporan As System.Windows.Forms.Label
        Friend WithEvents cmbJenisLaporan As System.Windows.Forms.ComboBox
        Friend WithEvents btnFilter As System.Windows.Forms.Button
        Friend WithEvents btnEksporCSV As System.Windows.Forms.Button
        Friend WithEvents btnCetakLaporan As System.Windows.Forms.Button
        Friend WithEvents pnlCards As System.Windows.Forms.Panel
        Friend WithEvents pnlCardOmzet As System.Windows.Forms.Panel
        Friend WithEvents lblTitleOmzet As System.Windows.Forms.Label
        Friend WithEvents lblValOmzet As System.Windows.Forms.Label
        Friend WithEvents pnlCardOkupansi As System.Windows.Forms.Panel
        Friend WithEvents lblTitleOkupansi As System.Windows.Forms.Label
        Friend WithEvents lblValOkupansi As System.Windows.Forms.Label
        Friend WithEvents pnlCardMoM As System.Windows.Forms.Panel
        Friend WithEvents lblTitleMoM As System.Windows.Forms.Label
        Friend WithEvents lblValMoM As System.Windows.Forms.Label
        Friend WithEvents pnlGridContainer As System.Windows.Forms.Panel
        Friend WithEvents dgvLaporan As System.Windows.Forms.DataGridView
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents lblInfoStatus As System.Windows.Forms.Label

    End Class

End Namespace

