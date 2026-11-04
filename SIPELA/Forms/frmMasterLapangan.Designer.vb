Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMasterLapangan
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
            Me.grpInput = New System.Windows.Forms.GroupBox()
            Me.btnBersihkan = New System.Windows.Forms.Button()
            Me.btnHapus = New System.Windows.Forms.Button()
            Me.btnUbah = New System.Windows.Forms.Button()
            Me.btnSimpan = New System.Windows.Forms.Button()
            Me.chkAktif = New System.Windows.Forms.CheckBox()
            Me.numHargaPerJam = New System.Windows.Forms.NumericUpDown()
            Me.lblHargaPerJam = New System.Windows.Forms.Label()
            Me.cmbJenisLantai = New System.Windows.Forms.ComboBox()
            Me.lblJenisLantai = New System.Windows.Forms.Label()
            Me.txtNamaLapangan = New System.Windows.Forms.TextBox()
            Me.lblNamaLapangan = New System.Windows.Forms.Label()
            Me.txtIdLapangan = New System.Windows.Forms.TextBox()
            Me.lblIdLapangan = New System.Windows.Forms.Label()
            Me.grpData = New System.Windows.Forms.GroupBox()
            Me.txtCari = New System.Windows.Forms.TextBox()
            Me.lblCari = New System.Windows.Forms.Label()
            Me.dgvLapangan = New System.Windows.Forms.DataGridView()
            Me.btnKembali = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.grpInput.SuspendLayout()
            CType(Me.numHargaPerJam, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpData.SuspendLayout()
            CType(Me.dgvLapangan, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.pnlHeader.Size = New System.Drawing.Size(940, 75)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubJudul
            '
            Me.lblSubJudul.AutoSize = True
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.Lavender
            Me.lblSubJudul.Location = New System.Drawing.Point(22, 45)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(325, 15)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Kelola data lapangan, tarif sewa per jam, dan status operasional"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(20, 15)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(262, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "MASTER DATA LAPANGAN"
            '
            'grpInput
            '
            Me.grpInput.Controls.Add(Me.btnBersihkan)
            Me.grpInput.Controls.Add(Me.btnHapus)
            Me.grpInput.Controls.Add(Me.btnUbah)
            Me.grpInput.Controls.Add(Me.btnSimpan)
            Me.grpInput.Controls.Add(Me.chkAktif)
            Me.grpInput.Controls.Add(Me.numHargaPerJam)
            Me.grpInput.Controls.Add(Me.lblHargaPerJam)
            Me.grpInput.Controls.Add(Me.cmbJenisLantai)
            Me.grpInput.Controls.Add(Me.lblJenisLantai)
            Me.grpInput.Controls.Add(Me.txtNamaLapangan)
            Me.grpInput.Controls.Add(Me.lblNamaLapangan)
            Me.grpInput.Controls.Add(Me.txtIdLapangan)
            Me.grpInput.Controls.Add(Me.lblIdLapangan)
            Me.grpInput.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpInput.Location = New System.Drawing.Point(20, 90)
            Me.grpInput.Name = "grpInput"
            Me.grpInput.Size = New System.Drawing.Size(360, 420)
            Me.grpInput.TabIndex = 1
            Me.grpInput.TabStop = False
            Me.grpInput.Text = " Form Input Lapangan "
            '
            'btnBersihkan
            '
            Me.btnBersihkan.BackColor = System.Drawing.Color.Gray
            Me.btnBersihkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBersihkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBersihkan.ForeColor = System.Drawing.Color.White
            Me.btnBersihkan.Location = New System.Drawing.Point(185, 360)
            Me.btnBersihkan.Name = "btnBersihkan"
            Me.btnBersihkan.Size = New System.Drawing.Size(150, 35)
            Me.btnBersihkan.TabIndex = 12
            Me.btnBersihkan.Text = "Bersihkan"
            Me.btnBersihkan.UseVisualStyleBackColor = False
            '
            'btnHapus
            '
            Me.btnHapus.BackColor = System.Drawing.Color.IndianRed
            Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHapus.ForeColor = System.Drawing.Color.White
            Me.btnHapus.Location = New System.Drawing.Point(20, 360)
            Me.btnHapus.Name = "btnHapus"
            Me.btnHapus.Size = New System.Drawing.Size(150, 35)
            Me.btnHapus.TabIndex = 11
            Me.btnHapus.Text = "Nonaktifkan"
            Me.btnHapus.UseVisualStyleBackColor = False
            '
            'btnUbah
            '
            Me.btnUbah.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUbah.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnUbah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUbah.ForeColor = System.Drawing.Color.White
            Me.btnUbah.Location = New System.Drawing.Point(185, 315)
            Me.btnUbah.Name = "btnUbah"
            Me.btnUbah.Size = New System.Drawing.Size(150, 35)
            Me.btnUbah.TabIndex = 10
            Me.btnUbah.Text = "Ubah Data"
            Me.btnUbah.UseVisualStyleBackColor = False
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(20, 315)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.Size = New System.Drawing.Size(150, 35)
            Me.btnSimpan.TabIndex = 9
            Me.btnSimpan.Text = "Simpan Baru"
            Me.btnSimpan.UseVisualStyleBackColor = False
            '
            'chkAktif
            '
            Me.chkAktif.AutoSize = True
            Me.chkAktif.Checked = True
            Me.chkAktif.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAktif.Location = New System.Drawing.Point(20, 270)
            Me.chkAktif.Name = "chkAktif"
            Me.chkAktif.Size = New System.Drawing.Size(155, 21)
            Me.chkAktif.TabIndex = 8
            Me.chkAktif.Text = "Status: Lapangan Aktif"
            Me.chkAktif.UseVisualStyleBackColor = True
            '
            'numHargaPerJam
            '
            Me.numHargaPerJam.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numHargaPerJam.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            Me.numHargaPerJam.Location = New System.Drawing.Point(20, 230)
            Me.numHargaPerJam.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
            Me.numHargaPerJam.Name = "numHargaPerJam"
            Me.numHargaPerJam.Size = New System.Drawing.Size(315, 24)
            Me.numHargaPerJam.TabIndex = 7
            Me.numHargaPerJam.ThousandsSeparator = True
            '
            'lblHargaPerJam
            '
            Me.lblHargaPerJam.AutoSize = True
            Me.lblHargaPerJam.Location = New System.Drawing.Point(20, 208)
            Me.lblHargaPerJam.Name = "lblHargaPerJam"
            Me.lblHargaPerJam.Size = New System.Drawing.Size(147, 17)
            Me.lblHargaPerJam.TabIndex = 6
            Me.lblHargaPerJam.Text = "Harga Sewa / Jam (Rp):"
            '
            'cmbJenisLantai
            '
            Me.cmbJenisLantai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbJenisLantai.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cmbJenisLantai.FormattingEnabled = True
            Me.cmbJenisLantai.Items.AddRange(New Object() {"Vinyl", "Rumput Sintetis", "Karpet Interlock", "Semen / Parquet"})
            Me.cmbJenisLantai.Location = New System.Drawing.Point(20, 170)
            Me.cmbJenisLantai.Name = "cmbJenisLantai"
            Me.cmbJenisLantai.Size = New System.Drawing.Size(315, 25)
            Me.cmbJenisLantai.TabIndex = 5
            '
            'lblJenisLantai
            '
            Me.lblJenisLantai.AutoSize = True
            Me.lblJenisLantai.Location = New System.Drawing.Point(20, 148)
            Me.lblJenisLantai.Name = "lblJenisLantai"
            Me.lblJenisLantai.Size = New System.Drawing.Size(81, 17)
            Me.lblJenisLantai.TabIndex = 4
            Me.lblJenisLantai.Text = "Jenis Lantai:"
            '
            'txtNamaLapangan
            '
            Me.txtNamaLapangan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtNamaLapangan.Location = New System.Drawing.Point(20, 110)
            Me.txtNamaLapangan.MaxLength = 50
            Me.txtNamaLapangan.Name = "txtNamaLapangan"
            Me.txtNamaLapangan.Size = New System.Drawing.Size(315, 24)
            Me.txtNamaLapangan.TabIndex = 3
            '
            'lblNamaLapangan
            '
            Me.lblNamaLapangan.AutoSize = True
            Me.lblNamaLapangan.Location = New System.Drawing.Point(20, 88)
            Me.lblNamaLapangan.Name = "lblNamaLapangan"
            Me.lblNamaLapangan.Size = New System.Drawing.Size(109, 17)
            Me.lblNamaLapangan.TabIndex = 2
            Me.lblNamaLapangan.Text = "Nama Lapangan:"
            '
            'txtIdLapangan
            '
            Me.txtIdLapangan.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtIdLapangan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtIdLapangan.Location = New System.Drawing.Point(20, 50)
            Me.txtIdLapangan.Name = "txtIdLapangan"
            Me.txtIdLapangan.ReadOnly = True
            Me.txtIdLapangan.Size = New System.Drawing.Size(315, 24)
            Me.txtIdLapangan.TabIndex = 1
            '
            'lblIdLapangan
            '
            Me.lblIdLapangan.AutoSize = True
            Me.lblIdLapangan.Location = New System.Drawing.Point(20, 28)
            Me.lblIdLapangan.Name = "lblIdLapangan"
            Me.lblIdLapangan.Size = New System.Drawing.Size(109, 17)
            Me.lblIdLapangan.TabIndex = 0
            Me.lblIdLapangan.Text = "ID (Auto Number):"
            '
            'grpData
            '
            Me.grpData.Controls.Add(Me.txtCari)
            Me.grpData.Controls.Add(Me.lblCari)
            Me.grpData.Controls.Add(Me.dgvLapangan)
            Me.grpData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpData.Location = New System.Drawing.Point(395, 90)
            Me.grpData.Name = "grpData"
            Me.grpData.Size = New System.Drawing.Size(525, 420)
            Me.grpData.TabIndex = 2
            Me.grpData.TabStop = False
            Me.grpData.Text = " Daftar Lapangan "
            '
            'txtCari
            '
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtCari.Location = New System.Drawing.Point(120, 25)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Ketik nama / jenis lantai..."
            Me.txtCari.Size = New System.Drawing.Size(385, 24)
            Me.txtCari.TabIndex = 2
            '
            'lblCari
            '
            Me.lblCari.AutoSize = True
            Me.lblCari.Location = New System.Drawing.Point(15, 28)
            Me.lblCari.Name = "lblCari"
            Me.lblCari.Size = New System.Drawing.Size(95, 17)
            Me.lblCari.TabIndex = 1
            Me.lblCari.Text = "Cari Lapangan:"
            '
            'dgvLapangan
            '
            Me.dgvLapangan.AllowUserToAddRows = False
            Me.dgvLapangan.AllowUserToDeleteRows = False
            Me.dgvLapangan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvLapangan.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvLapangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLapangan.Location = New System.Drawing.Point(15, 60)
            Me.dgvLapangan.MultiSelect = False
            Me.dgvLapangan.Name = "dgvLapangan"
            Me.dgvLapangan.ReadOnly = True
            Me.dgvLapangan.RowHeadersVisible = False
            Me.dgvLapangan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvLapangan.Size = New System.Drawing.Size(490, 345)
            Me.dgvLapangan.TabIndex = 0
            '
            'btnKembali
            '
            Me.btnKembali.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKembali.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnKembali.ForeColor = System.Drawing.Color.White
            Me.btnKembali.Location = New System.Drawing.Point(20, 525)
            Me.btnKembali.Name = "btnKembali"
            Me.btnKembali.Size = New System.Drawing.Size(180, 35)
            Me.btnKembali.TabIndex = 3
            Me.btnKembali.Text = "← Kembali ke Menu"
            Me.btnKembali.UseVisualStyleBackColor = False
            '
            'frmMasterLapangan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(940, 575)
            Me.Controls.Add(Me.btnKembali)
            Me.Controls.Add(Me.grpData)
            Me.Controls.Add(Me.grpInput)
            Me.Controls.Add(Me.pnlHeader)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmMasterLapangan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Master Lapangan - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.grpInput.ResumeLayout(False)
            Me.grpInput.PerformLayout()
            CType(Me.numHargaPerJam, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpData.ResumeLayout(False)
            Me.grpData.PerformLayout()
            CType(Me.dgvLapangan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents grpInput As System.Windows.Forms.GroupBox
        Friend WithEvents lblIdLapangan As System.Windows.Forms.Label
        Friend WithEvents txtIdLapangan As System.Windows.Forms.TextBox
        Friend WithEvents lblNamaLapangan As System.Windows.Forms.Label
        Friend WithEvents txtNamaLapangan As System.Windows.Forms.TextBox
        Friend WithEvents lblJenisLantai As System.Windows.Forms.Label
        Friend WithEvents cmbJenisLantai As System.Windows.Forms.ComboBox
        Friend WithEvents lblHargaPerJam As System.Windows.Forms.Label
        Friend WithEvents numHargaPerJam As System.Windows.Forms.NumericUpDown
        Friend WithEvents chkAktif As System.Windows.Forms.CheckBox
        Friend WithEvents btnSimpan As System.Windows.Forms.Button
        Friend WithEvents btnUbah As System.Windows.Forms.Button
        Friend WithEvents btnHapus As System.Windows.Forms.Button
        Friend WithEvents btnBersihkan As System.Windows.Forms.Button
        Friend WithEvents grpData As System.Windows.Forms.GroupBox
        Friend WithEvents lblCari As System.Windows.Forms.Label
        Friend WithEvents txtCari As System.Windows.Forms.TextBox
        Friend WithEvents dgvLapangan As System.Windows.Forms.DataGridView
        Friend WithEvents btnKembali As System.Windows.Forms.Button
    End Class

End Namespace

