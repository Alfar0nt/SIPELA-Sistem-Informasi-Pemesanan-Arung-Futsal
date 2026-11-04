Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmJadwal
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
            Me.lblLegendHolding = New System.Windows.Forms.Label()
            Me.lblLegendTerisi = New System.Windows.Forms.Label()
            Me.lblLegendTersedia = New System.Windows.Forms.Label()
            Me.btnHariBerikutnya = New System.Windows.Forms.Button()
            Me.btnHariIni = New System.Windows.Forms.Button()
            Me.btnHariSebelumnya = New System.Windows.Forms.Button()
            Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
            Me.lblPilihTanggal = New System.Windows.Forms.Label()
            Me.pnlContainer = New System.Windows.Forms.Panel()
            Me.dgvMatriks = New System.Windows.Forms.DataGridView()
            Me.pnlStats = New System.Windows.Forms.Panel()
            Me.btnBookingBaru = New System.Windows.Forms.Button()
            Me.lblStatOkupansi = New System.Windows.Forms.Label()
            Me.lblStatKosong = New System.Windows.Forms.Label()
            Me.lblStatTerisi = New System.Windows.Forms.Label()
            Me.lblStatTotalSlot = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlToolbar.SuspendLayout()
            Me.pnlContainer.SuspendLayout()
            CType(Me.dgvMatriks, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlStats.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(1164, 75)
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
            Me.btnKembali.Location = New System.Drawing.Point(1030, 18)
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
            Me.lblSubJudul.Size = New System.Drawing.Size(462, 17)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Visibilitas matriks ketersediaan seluruh lapangan per jam (08.00 s.d. 24.00 WIB)"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(22, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(376, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "KALENDER MATRIKS JADWAL SEWA"
            '
            'pnlToolbar
            '
            Me.pnlToolbar.BackColor = System.Drawing.Color.White
            Me.pnlToolbar.Controls.Add(Me.lblLegendHolding)
            Me.pnlToolbar.Controls.Add(Me.lblLegendTerisi)
            Me.pnlToolbar.Controls.Add(Me.lblLegendTersedia)
            Me.pnlToolbar.Controls.Add(Me.btnHariBerikutnya)
            Me.pnlToolbar.Controls.Add(Me.btnHariIni)
            Me.pnlToolbar.Controls.Add(Me.btnHariSebelumnya)
            Me.pnlToolbar.Controls.Add(Me.dtpTanggal)
            Me.pnlToolbar.Controls.Add(Me.lblPilihTanggal)
            Me.pnlToolbar.Location = New System.Drawing.Point(20, 90)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlToolbar.Size = New System.Drawing.Size(1124, 60)
            Me.pnlToolbar.TabIndex = 1
            '
            'lblLegendHolding
            '
            Me.lblLegendHolding.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.lblLegendHolding.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendHolding.ForeColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(14, Byte), Integer))
            Me.lblLegendHolding.Location = New System.Drawing.Point(970, 15)
            Me.lblLegendHolding.Name = "lblLegendHolding"
            Me.lblLegendHolding.Size = New System.Drawing.Size(140, 28)
            Me.lblLegendHolding.TabIndex = 7
            Me.lblLegendHolding.Text = "🟡 Menunggu DP"
            Me.lblLegendHolding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLegendTerisi
            '
            Me.lblLegendTerisi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
            Me.lblLegendTerisi.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendTerisi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblLegendTerisi.Location = New System.Drawing.Point(835, 15)
            Me.lblLegendTerisi.Name = "lblLegendTerisi"
            Me.lblLegendTerisi.Size = New System.Drawing.Size(125, 28)
            Me.lblLegendTerisi.TabIndex = 6
            Me.lblLegendTerisi.Text = "🔴 Terisi (DP/Lunas)"
            Me.lblLegendTerisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLegendTersedia
            '
            Me.lblLegendTersedia.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblLegendTersedia.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblLegendTersedia.ForeColor = System.Drawing.Color.White
            Me.lblLegendTersedia.Location = New System.Drawing.Point(715, 15)
            Me.lblLegendTersedia.Name = "lblLegendTersedia"
            Me.lblLegendTersedia.Size = New System.Drawing.Size(110, 28)
            Me.lblLegendTersedia.TabIndex = 5
            Me.lblLegendTersedia.Text = "🟢 Tersedia"
            Me.lblLegendTersedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnHariBerikutnya
            '
            Me.btnHariBerikutnya.BackColor = System.Drawing.Color.White
            Me.btnHariBerikutnya.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHariBerikutnya.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHariBerikutnya.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnHariBerikutnya.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnHariBerikutnya.Location = New System.Drawing.Point(545, 14)
            Me.btnHariBerikutnya.Name = "btnHariBerikutnya"
            Me.btnHariBerikutnya.Size = New System.Drawing.Size(120, 30)
            Me.btnHariBerikutnya.TabIndex = 4
            Me.btnHariBerikutnya.Text = "Besok ▶"
            Me.btnHariBerikutnya.UseVisualStyleBackColor = False
            '
            'btnHariIni
            '
            Me.btnHariIni.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.btnHariIni.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHariIni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHariIni.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnHariIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnHariIni.Location = New System.Drawing.Point(445, 14)
            Me.btnHariIni.Name = "btnHariIni"
            Me.btnHariIni.Size = New System.Drawing.Size(90, 30)
            Me.btnHariIni.TabIndex = 3
            Me.btnHariIni.Text = "Hari Ini"
            Me.btnHariIni.UseVisualStyleBackColor = False
            '
            'btnHariSebelumnya
            '
            Me.btnHariSebelumnya.BackColor = System.Drawing.Color.White
            Me.btnHariSebelumnya.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHariSebelumnya.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHariSebelumnya.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnHariSebelumnya.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnHariSebelumnya.Location = New System.Drawing.Point(315, 14)
            Me.btnHariSebelumnya.Name = "btnHariSebelumnya"
            Me.btnHariSebelumnya.Size = New System.Drawing.Size(120, 30)
            Me.btnHariSebelumnya.TabIndex = 2
            Me.btnHariSebelumnya.Text = "◀ Kemarin"
            Me.btnHariSebelumnya.UseVisualStyleBackColor = False
            '
            'dtpTanggal
            '
            Me.dtpTanggal.CustomFormat = "dddd, dd MMMM yyyy"
            Me.dtpTanggal.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpTanggal.Location = New System.Drawing.Point(95, 16)
            Me.dtpTanggal.Name = "dtpTanggal"
            Me.dtpTanggal.Size = New System.Drawing.Size(205, 25)
            Me.dtpTanggal.TabIndex = 1
            '
            'lblPilihTanggal
            '
            Me.lblPilihTanggal.AutoSize = True
            Me.lblPilihTanggal.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPilihTanggal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblPilihTanggal.Location = New System.Drawing.Point(15, 20)
            Me.lblPilihTanggal.Name = "lblPilihTanggal"
            Me.lblPilihTanggal.Size = New System.Drawing.Size(69, 17)
            Me.lblPilihTanggal.TabIndex = 0
            Me.lblPilihTanggal.Text = "Tanggal: *"
            '
            'pnlContainer
            '
            Me.pnlContainer.BackColor = System.Drawing.Color.White
            Me.pnlContainer.Controls.Add(Me.dgvMatriks)
            Me.pnlContainer.Location = New System.Drawing.Point(20, 160)
            Me.pnlContainer.Name = "pnlContainer"
            Me.pnlContainer.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlContainer.Size = New System.Drawing.Size(1124, 455)
            Me.pnlContainer.TabIndex = 2
            '
            'dgvMatriks
            '
            Me.dgvMatriks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvMatriks.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvMatriks.Location = New System.Drawing.Point(12, 12)
            Me.dgvMatriks.Name = "dgvMatriks"
            Me.dgvMatriks.Size = New System.Drawing.Size(1100, 431)
            Me.dgvMatriks.TabIndex = 0
            '
            'pnlStats
            '
            Me.pnlStats.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.pnlStats.Controls.Add(Me.btnBookingBaru)
            Me.pnlStats.Controls.Add(Me.lblStatOkupansi)
            Me.pnlStats.Controls.Add(Me.lblStatKosong)
            Me.pnlStats.Controls.Add(Me.lblStatTerisi)
            Me.pnlStats.Controls.Add(Me.lblStatTotalSlot)
            Me.pnlStats.Location = New System.Drawing.Point(20, 625)
            Me.pnlStats.Name = "pnlStats"
            Me.pnlStats.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlStats.Size = New System.Drawing.Size(1124, 48)
            Me.pnlStats.TabIndex = 3
            '
            'btnBookingBaru
            '
            Me.btnBookingBaru.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBookingBaru.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.btnBookingBaru.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBookingBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBookingBaru.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBookingBaru.ForeColor = System.Drawing.Color.White
            Me.btnBookingBaru.Location = New System.Drawing.Point(905, 7)
            Me.btnBookingBaru.Name = "btnBookingBaru"
            Me.btnBookingBaru.Size = New System.Drawing.Size(205, 34)
            Me.btnBookingBaru.TabIndex = 4
            Me.btnBookingBaru.Text = "➕ Buat Pemesanan Baru"
            Me.btnBookingBaru.UseVisualStyleBackColor = False
            '
            'lblStatOkupansi
            '
            Me.lblStatOkupansi.AutoSize = True
            Me.lblStatOkupansi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatOkupansi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblStatOkupansi.Location = New System.Drawing.Point(545, 14)
            Me.lblStatOkupansi.Name = "lblStatOkupansi"
            Me.lblStatOkupansi.Size = New System.Drawing.Size(131, 19)
            Me.lblStatOkupansi.TabIndex = 3
            Me.lblStatOkupansi.Text = "Okupansi Hari Ini: 0%"
            '
            'lblStatKosong
            '
            Me.lblStatKosong.AutoSize = True
            Me.lblStatKosong.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblStatKosong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblStatKosong.Location = New System.Drawing.Point(365, 15)
            Me.lblStatKosong.Name = "lblStatKosong"
            Me.lblStatKosong.Size = New System.Drawing.Size(117, 17)
            Me.lblStatKosong.TabIndex = 2
            Me.lblStatKosong.Text = "Slot Tersedia: 0"
            '
            'lblStatTerisi
            '
            Me.lblStatTerisi.AutoSize = True
            Me.lblStatTerisi.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblStatTerisi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.lblStatTerisi.Location = New System.Drawing.Point(215, 15)
            Me.lblStatTerisi.Name = "lblStatTerisi"
            Me.lblStatTerisi.Size = New System.Drawing.Size(100, 17)
            Me.lblStatTerisi.TabIndex = 1
            Me.lblStatTerisi.Text = "Slot Terisi: 0"
            '
            'lblStatTotalSlot
            '
            Me.lblStatTotalSlot.AutoSize = True
            Me.lblStatTotalSlot.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblStatTotalSlot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblStatTotalSlot.Location = New System.Drawing.Point(15, 15)
            Me.lblStatTotalSlot.Name = "lblStatTotalSlot"
            Me.lblStatTotalSlot.Size = New System.Drawing.Size(147, 17)
            Me.lblStatTotalSlot.TabIndex = 0
            Me.lblStatTotalSlot.Text = "Total Slot Harian: 0"
            '
            'frmJadwal
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1164, 690)
            Me.Controls.Add(Me.pnlStats)
            Me.Controls.Add(Me.pnlContainer)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmJadwal"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SIPELA - Kalender Matriks Jadwal Sewa"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlToolbar.ResumeLayout(False)
            Me.pnlToolbar.PerformLayout()
            Me.pnlContainer.ResumeLayout(False)
            CType(Me.dgvMatriks, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlStats.ResumeLayout(False)
            Me.pnlStats.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents btnKembali As System.Windows.Forms.Button
        Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
        Friend WithEvents lblPilihTanggal As System.Windows.Forms.Label
        Friend WithEvents dtpTanggal As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnHariSebelumnya As System.Windows.Forms.Button
        Friend WithEvents btnHariIni As System.Windows.Forms.Button
        Friend WithEvents btnHariBerikutnya As System.Windows.Forms.Button
        Friend WithEvents lblLegendTersedia As System.Windows.Forms.Label
        Friend WithEvents lblLegendTerisi As System.Windows.Forms.Label
        Friend WithEvents lblLegendHolding As System.Windows.Forms.Label
        Friend WithEvents pnlContainer As System.Windows.Forms.Panel
        Friend WithEvents dgvMatriks As System.Windows.Forms.DataGridView
        Friend WithEvents pnlStats As System.Windows.Forms.Panel
        Friend WithEvents lblStatTotalSlot As System.Windows.Forms.Label
        Friend WithEvents lblStatTerisi As System.Windows.Forms.Label
        Friend WithEvents lblStatKosong As System.Windows.Forms.Label
        Friend WithEvents lblStatOkupansi As System.Windows.Forms.Label
        Friend WithEvents btnBookingBaru As System.Windows.Forms.Button

    End Class

End Namespace

