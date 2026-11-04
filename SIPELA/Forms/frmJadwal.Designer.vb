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
            Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
            pnlHeader = New Panel()
            btnKembali = New Button()
            lblSubJudul = New Label()
            lblJudul = New Label()
            pnlToolbar = New Panel()
            lblLegendHolding = New Label()
            lblLegendTerisi = New Label()
            lblLegendTersedia = New Label()
            btnHariBerikutnya = New Button()
            btnHariIni = New Button()
            btnHariSebelumnya = New Button()
            dtpTanggal = New DateTimePicker()
            lblPilihTanggal = New Label()
            pnlContainer = New Panel()
            dgvMatriks = New DataGridView()
            pnlStats = New Panel()
            btnBookingBaru = New Button()
            lblStatOkupansi = New Label()
            lblStatKosong = New Label()
            lblStatTerisi = New Label()
            lblStatTotalSlot = New Label()
            pnlHeader.SuspendLayout()
            pnlToolbar.SuspendLayout()
            pnlContainer.SuspendLayout()
            CType(dgvMatriks, ComponentModel.ISupportInitialize).BeginInit()
            pnlStats.SuspendLayout()
            SuspendLayout()
            ' 
            ' pnlHeader
            ' 
            pnlHeader.BackColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            pnlHeader.Controls.Add(btnKembali)
            pnlHeader.Controls.Add(lblSubJudul)
            pnlHeader.Controls.Add(lblJudul)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Location = New Point(0, 0)
            pnlHeader.Margin = New Padding(3, 4, 3, 4)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New Size(1330, 100)
            pnlHeader.TabIndex = 0
            ' 
            ' btnKembali
            ' 
            btnKembali.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            btnKembali.BackColor = Color.White
            btnKembali.Cursor = Cursors.Hand
            btnKembali.FlatStyle = FlatStyle.Flat
            btnKembali.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnKembali.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            btnKembali.Location = New Point(1177, 24)
            btnKembali.Margin = New Padding(3, 4, 3, 4)
            btnKembali.Name = "btnKembali"
            btnKembali.Size = New Size(131, 51)
            btnKembali.TabIndex = 2
            btnKembali.Text = "← Kembali"
            btnKembali.UseVisualStyleBackColor = False
            ' 
            ' lblSubJudul
            ' 
            lblSubJudul.AutoSize = True
            lblSubJudul.Font = New Font("Segoe UI", 9.5F)
            lblSubJudul.ForeColor = Color.FromArgb(CByte(216), CByte(212), CByte(242))
            lblSubJudul.Location = New Point(27, 57)
            lblSubJudul.Name = "lblSubJudul"
            lblSubJudul.Size = New Size(559, 21)
            lblSubJudul.TabIndex = 1
            lblSubJudul.Text = "Visibilitas matriks ketersediaan seluruh lapangan per jam (08.00 s.d. 24.00 WIB)"
            ' 
            ' lblJudul
            ' 
            lblJudul.AutoSize = True
            lblJudul.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
            lblJudul.ForeColor = Color.White
            lblJudul.Location = New Point(25, 16)
            lblJudul.Name = "lblJudul"
            lblJudul.Size = New Size(443, 35)
            lblJudul.TabIndex = 0
            lblJudul.Text = "KALENDER MATRIKS JADWAL SEWA"
            ' 
            ' pnlToolbar
            ' 
            pnlToolbar.BackColor = Color.White
            pnlToolbar.Controls.Add(lblLegendHolding)
            pnlToolbar.Controls.Add(lblLegendTerisi)
            pnlToolbar.Controls.Add(lblLegendTersedia)
            pnlToolbar.Controls.Add(btnHariBerikutnya)
            pnlToolbar.Controls.Add(btnHariIni)
            pnlToolbar.Controls.Add(btnHariSebelumnya)
            pnlToolbar.Controls.Add(dtpTanggal)
            pnlToolbar.Controls.Add(lblPilihTanggal)
            pnlToolbar.Location = New Point(23, 120)
            pnlToolbar.Margin = New Padding(3, 4, 3, 4)
            pnlToolbar.Name = "pnlToolbar"
            pnlToolbar.Padding = New Padding(14, 16, 14, 16)
            pnlToolbar.Size = New Size(1285, 80)
            pnlToolbar.TabIndex = 1
            ' 
            ' lblLegendHolding
            ' 
            lblLegendHolding.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(199))
            lblLegendHolding.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblLegendHolding.ForeColor = Color.FromArgb(CByte(146), CByte(64), CByte(14))
            lblLegendHolding.Location = New Point(1109, 20)
            lblLegendHolding.Name = "lblLegendHolding"
            lblLegendHolding.Size = New Size(160, 37)
            lblLegendHolding.TabIndex = 7
            lblLegendHolding.Text = ChrW(55357) & ChrW(57313) & " Menunggu DP"
            lblLegendHolding.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' lblLegendTerisi
            ' 
            lblLegendTerisi.BackColor = Color.FromArgb(CByte(255), CByte(181), CByte(181))
            lblLegendTerisi.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblLegendTerisi.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            lblLegendTerisi.Location = New Point(954, 20)
            lblLegendTerisi.Name = "lblLegendTerisi"
            lblLegendTerisi.Size = New Size(143, 37)
            lblLegendTerisi.TabIndex = 6
            lblLegendTerisi.Text = "🔴 Terisi (DP/Lunas)"
            lblLegendTerisi.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' lblLegendTersedia
            ' 
            lblLegendTersedia.BackColor = Color.FromArgb(CByte(37), CByte(193), CByte(111))
            lblLegendTersedia.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblLegendTersedia.ForeColor = Color.White
            lblLegendTersedia.Location = New Point(817, 20)
            lblLegendTersedia.Name = "lblLegendTersedia"
            lblLegendTersedia.Size = New Size(126, 37)
            lblLegendTersedia.TabIndex = 5
            lblLegendTersedia.Text = ChrW(55357) & ChrW(57314) & " Tersedia"
            lblLegendTersedia.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' btnHariBerikutnya
            ' 
            btnHariBerikutnya.BackColor = Color.White
            btnHariBerikutnya.Cursor = Cursors.Hand
            btnHariBerikutnya.FlatStyle = FlatStyle.Flat
            btnHariBerikutnya.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnHariBerikutnya.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            btnHariBerikutnya.Location = New Point(623, 19)
            btnHariBerikutnya.Margin = New Padding(3, 4, 3, 4)
            btnHariBerikutnya.Name = "btnHariBerikutnya"
            btnHariBerikutnya.Size = New Size(137, 40)
            btnHariBerikutnya.TabIndex = 4
            btnHariBerikutnya.Text = "Besok ▶"
            btnHariBerikutnya.UseVisualStyleBackColor = False
            ' 
            ' btnHariIni
            ' 
            btnHariIni.BackColor = Color.FromArgb(CByte(174), CByte(212), CByte(230))
            btnHariIni.Cursor = Cursors.Hand
            btnHariIni.FlatStyle = FlatStyle.Flat
            btnHariIni.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnHariIni.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            btnHariIni.Location = New Point(509, 19)
            btnHariIni.Margin = New Padding(3, 4, 3, 4)
            btnHariIni.Name = "btnHariIni"
            btnHariIni.Size = New Size(103, 40)
            btnHariIni.TabIndex = 3
            btnHariIni.Text = "Hari Ini"
            btnHariIni.UseVisualStyleBackColor = False
            ' 
            ' btnHariSebelumnya
            ' 
            btnHariSebelumnya.BackColor = Color.White
            btnHariSebelumnya.Cursor = Cursors.Hand
            btnHariSebelumnya.FlatStyle = FlatStyle.Flat
            btnHariSebelumnya.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnHariSebelumnya.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            btnHariSebelumnya.Location = New Point(360, 19)
            btnHariSebelumnya.Margin = New Padding(3, 4, 3, 4)
            btnHariSebelumnya.Name = "btnHariSebelumnya"
            btnHariSebelumnya.Size = New Size(137, 40)
            btnHariSebelumnya.TabIndex = 2
            btnHariSebelumnya.Text = "◀ Kemarin"
            btnHariSebelumnya.UseVisualStyleBackColor = False
            ' 
            ' dtpTanggal
            ' 
            dtpTanggal.CustomFormat = "dddd, dd MMMM yyyy"
            dtpTanggal.Font = New Font("Segoe UI", 10F)
            dtpTanggal.Format = DateTimePickerFormat.Custom
            dtpTanggal.Location = New Point(109, 21)
            dtpTanggal.Margin = New Padding(3, 4, 3, 4)
            dtpTanggal.Name = "dtpTanggal"
            dtpTanggal.Size = New Size(234, 30)
            dtpTanggal.TabIndex = 1
            ' 
            ' lblPilihTanggal
            ' 
            lblPilihTanggal.AutoSize = True
            lblPilihTanggal.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblPilihTanggal.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            lblPilihTanggal.Location = New Point(17, 27)
            lblPilihTanggal.Name = "lblPilihTanggal"
            lblPilihTanggal.Size = New Size(86, 21)
            lblPilihTanggal.TabIndex = 0
            lblPilihTanggal.Text = "Tanggal: *"
            ' 
            ' pnlContainer
            ' 
            pnlContainer.BackColor = Color.White
            pnlContainer.Controls.Add(dgvMatriks)
            pnlContainer.Location = New Point(23, 213)
            pnlContainer.Margin = New Padding(3, 4, 3, 4)
            pnlContainer.Name = "pnlContainer"
            pnlContainer.Padding = New Padding(14, 16, 14, 16)
            pnlContainer.Size = New Size(1285, 607)
            pnlContainer.TabIndex = 2
            ' 
            ' dgvMatriks
            ' 
            DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = SystemColors.Control
            DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
            DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
            dgvMatriks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            dgvMatriks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = SystemColors.Window
            DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
            DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
            dgvMatriks.DefaultCellStyle = DataGridViewCellStyle2
            dgvMatriks.Dock = DockStyle.Fill
            dgvMatriks.Location = New Point(14, 16)
            dgvMatriks.Margin = New Padding(3, 4, 3, 4)
            dgvMatriks.Name = "dgvMatriks"
            dgvMatriks.RowHeadersWidth = 51
            dgvMatriks.Size = New Size(1257, 575)
            dgvMatriks.TabIndex = 0
            ' 
            ' pnlStats
            ' 
            pnlStats.BackColor = Color.FromArgb(CByte(253), CByte(251), CByte(247))
            pnlStats.Controls.Add(btnBookingBaru)
            pnlStats.Controls.Add(lblStatOkupansi)
            pnlStats.Controls.Add(lblStatKosong)
            pnlStats.Controls.Add(lblStatTerisi)
            pnlStats.Controls.Add(lblStatTotalSlot)
            pnlStats.Location = New Point(23, 833)
            pnlStats.Margin = New Padding(3, 4, 3, 4)
            pnlStats.Name = "pnlStats"
            pnlStats.Padding = New Padding(11, 13, 11, 13)
            pnlStats.Size = New Size(1285, 64)
            pnlStats.TabIndex = 3
            ' 
            ' btnBookingBaru
            ' 
            btnBookingBaru.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            btnBookingBaru.BackColor = Color.FromArgb(CByte(37), CByte(193), CByte(111))
            btnBookingBaru.Cursor = Cursors.Hand
            btnBookingBaru.FlatStyle = FlatStyle.Flat
            btnBookingBaru.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            btnBookingBaru.ForeColor = Color.White
            btnBookingBaru.Location = New Point(1034, 9)
            btnBookingBaru.Margin = New Padding(3, 4, 3, 4)
            btnBookingBaru.Name = "btnBookingBaru"
            btnBookingBaru.Size = New Size(234, 45)
            btnBookingBaru.TabIndex = 4
            btnBookingBaru.Text = "➕ Buat Pemesanan Baru"
            btnBookingBaru.UseVisualStyleBackColor = False
            ' 
            ' lblStatOkupansi
            ' 
            lblStatOkupansi.AutoSize = True
            lblStatOkupansi.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
            lblStatOkupansi.ForeColor = Color.FromArgb(CByte(37), CByte(193), CByte(111))
            lblStatOkupansi.Location = New Point(623, 19)
            lblStatOkupansi.Name = "lblStatOkupansi"
            lblStatOkupansi.Size = New Size(184, 23)
            lblStatOkupansi.TabIndex = 3
            lblStatOkupansi.Text = "Okupansi Hari Ini: 0%"
            ' 
            ' lblStatKosong
            ' 
            lblStatKosong.AutoSize = True
            lblStatKosong.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblStatKosong.ForeColor = Color.FromArgb(CByte(37), CByte(193), CByte(111))
            lblStatKosong.Location = New Point(417, 20)
            lblStatKosong.Name = "lblStatKosong"
            lblStatKosong.Size = New Size(124, 21)
            lblStatKosong.TabIndex = 2
            lblStatKosong.Text = "Slot Tersedia: 0"
            ' 
            ' lblStatTerisi
            ' 
            lblStatTerisi.AutoSize = True
            lblStatTerisi.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblStatTerisi.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
            lblStatTerisi.Location = New Point(246, 20)
            lblStatTerisi.Name = "lblStatTerisi"
            lblStatTerisi.Size = New Size(101, 21)
            lblStatTerisi.TabIndex = 1
            lblStatTerisi.Text = "Slot Terisi: 0"
            ' 
            ' lblStatTotalSlot
            ' 
            lblStatTotalSlot.AutoSize = True
            lblStatTotalSlot.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblStatTotalSlot.ForeColor = Color.FromArgb(CByte(45), CByte(51), CByte(74))
            lblStatTotalSlot.Location = New Point(17, 20)
            lblStatTotalSlot.Name = "lblStatTotalSlot"
            lblStatTotalSlot.Size = New Size(154, 21)
            lblStatTotalSlot.TabIndex = 0
            lblStatTotalSlot.Text = "Total Slot Harian: 0"
            ' 
            ' frmJadwal
            ' 
            AutoScaleDimensions = New SizeF(8F, 20F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.FromArgb(CByte(253), CByte(251), CByte(247))
            ClientSize = New Size(1330, 920)
            Controls.Add(pnlStats)
            Controls.Add(pnlContainer)
            Controls.Add(pnlToolbar)
            Controls.Add(pnlHeader)
            Font = New Font("Segoe UI", 9F)
            FormBorderStyle = FormBorderStyle.FixedDialog
            Margin = New Padding(3, 4, 3, 4)
            MaximizeBox = False
            Name = "frmJadwal"
            StartPosition = FormStartPosition.CenterParent
            Text = "SIPELA - Kalender Matriks Jadwal Sewa"
            pnlHeader.ResumeLayout(False)
            pnlHeader.PerformLayout()
            pnlToolbar.ResumeLayout(False)
            pnlToolbar.PerformLayout()
            pnlContainer.ResumeLayout(False)
            CType(dgvMatriks, ComponentModel.ISupportInitialize).EndInit()
            pnlStats.ResumeLayout(False)
            pnlStats.PerformLayout()
            ResumeLayout(False)

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

