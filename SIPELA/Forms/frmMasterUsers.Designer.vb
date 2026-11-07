Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMasterUsers
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
            Me.lblPasswordHint = New System.Windows.Forms.Label()
            Me.btnBersihkan = New System.Windows.Forms.Button()
            Me.btnHapusPermanen = New System.Windows.Forms.Button()
            Me.btnHapus = New System.Windows.Forms.Button()
            Me.btnUbah = New System.Windows.Forms.Button()
            Me.btnSimpan = New System.Windows.Forms.Button()
            Me.chkAktif = New System.Windows.Forms.CheckBox()
            Me.cmbRole = New System.Windows.Forms.ComboBox()
            Me.lblRole = New System.Windows.Forms.Label()
            Me.txtNamaLengkap = New System.Windows.Forms.TextBox()
            Me.lblNamaLengkap = New System.Windows.Forms.Label()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.txtIdUser = New System.Windows.Forms.TextBox()
            Me.lblIdUser = New System.Windows.Forms.Label()
            Me.grpData = New System.Windows.Forms.GroupBox()
            Me.txtCari = New System.Windows.Forms.TextBox()
            Me.lblCari = New System.Windows.Forms.Label()
            Me.dgvUsers = New System.Windows.Forms.DataGridView()
            Me.btnKembali = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.grpInput.SuspendLayout()
            Me.grpData.SuspendLayout()
            CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.pnlHeader.Size = New System.Drawing.Size(950, 75)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubJudul
            '
            Me.lblSubJudul.AutoSize = True
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.Lavender
            Me.lblSubJudul.Location = New System.Drawing.Point(22, 45)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(355, 15)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Kelola akun pengguna, hak akses (Admin/Owner), dan status login"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(20, 15)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(296, 28)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "MASTER DATA PENGGUNA"
            '
            'grpInput
            '
            Me.grpInput.Controls.Add(Me.lblPasswordHint)
            Me.grpInput.Controls.Add(Me.btnBersihkan)
            Me.grpInput.Controls.Add(Me.btnHapusPermanen)
            Me.grpInput.Controls.Add(Me.btnHapus)
            Me.grpInput.Controls.Add(Me.btnUbah)
            Me.grpInput.Controls.Add(Me.btnSimpan)
            Me.grpInput.Controls.Add(Me.chkAktif)
            Me.grpInput.Controls.Add(Me.cmbRole)
            Me.grpInput.Controls.Add(Me.lblRole)
            Me.grpInput.Controls.Add(Me.txtNamaLengkap)
            Me.grpInput.Controls.Add(Me.lblNamaLengkap)
            Me.grpInput.Controls.Add(Me.txtPassword)
            Me.grpInput.Controls.Add(Me.lblPassword)
            Me.grpInput.Controls.Add(Me.txtUsername)
            Me.grpInput.Controls.Add(Me.lblUsername)
            Me.grpInput.Controls.Add(Me.txtIdUser)
            Me.grpInput.Controls.Add(Me.lblIdUser)
            Me.grpInput.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpInput.Location = New System.Drawing.Point(20, 90)
            Me.grpInput.Name = "grpInput"
            Me.grpInput.Size = New System.Drawing.Size(365, 480)
            Me.grpInput.TabIndex = 1
            Me.grpInput.TabStop = False
            Me.grpInput.Text = " Form Input User "
            '
            'lblPasswordHint
            '
            Me.lblPasswordHint.AutoSize = True
            Me.lblPasswordHint.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
            Me.lblPasswordHint.ForeColor = System.Drawing.Color.DimGray
            Me.lblPasswordHint.Location = New System.Drawing.Point(20, 192)
            Me.lblPasswordHint.Name = "lblPasswordHint"
            Me.lblPasswordHint.Size = New System.Drawing.Size(236, 13)
            Me.lblPasswordHint.TabIndex = 15
            Me.lblPasswordHint.Text = "*Kosongkan jika password tidak ingin diubah (saat edit)"
            '
            'btnBersihkan
            '
            Me.btnBersihkan.BackColor = System.Drawing.Color.Gray
            Me.btnBersihkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBersihkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBersihkan.ForeColor = System.Drawing.Color.White
            Me.btnBersihkan.Location = New System.Drawing.Point(20, 431)
            Me.btnBersihkan.Name = "btnBersihkan"
            Me.btnBersihkan.Size = New System.Drawing.Size(320, 35)
            Me.btnBersihkan.TabIndex = 15
            Me.btnBersihkan.Text = "Clear"
            Me.btnBersihkan.UseVisualStyleBackColor = False
            '
            'btnHapusPermanen
            '
            Me.btnHapusPermanen.BackColor = System.Drawing.Color.Crimson
            Me.btnHapusPermanen.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHapusPermanen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHapusPermanen.ForeColor = System.Drawing.Color.White
            Me.btnHapusPermanen.Location = New System.Drawing.Point(185, 388)
            Me.btnHapusPermanen.Name = "btnHapusPermanen"
            Me.btnHapusPermanen.Size = New System.Drawing.Size(155, 35)
            Me.btnHapusPermanen.TabIndex = 14
            Me.btnHapusPermanen.Text = "Delete"
            Me.btnHapusPermanen.UseVisualStyleBackColor = False
            '
            'btnHapus
            '
            Me.btnHapus.BackColor = System.Drawing.Color.DarkOrange
            Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnHapus.ForeColor = System.Drawing.Color.White
            Me.btnHapus.Location = New System.Drawing.Point(20, 388)
            Me.btnHapus.Name = "btnHapus"
            Me.btnHapus.Size = New System.Drawing.Size(155, 35)
            Me.btnHapus.TabIndex = 13
            Me.btnHapus.Text = "Nonaktifkan"
            Me.btnHapus.UseVisualStyleBackColor = False
            '
            'btnUbah
            '
            Me.btnUbah.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUbah.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnUbah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUbah.ForeColor = System.Drawing.Color.White
            Me.btnUbah.Location = New System.Drawing.Point(185, 345)
            Me.btnUbah.Name = "btnUbah"
            Me.btnUbah.Size = New System.Drawing.Size(155, 35)
            Me.btnUbah.TabIndex = 12
            Me.btnUbah.Text = "Update"
            Me.btnUbah.UseVisualStyleBackColor = False
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(20, 345)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.Size = New System.Drawing.Size(155, 35)
            Me.btnSimpan.TabIndex = 11
            Me.btnSimpan.Text = "Insert"
            Me.btnSimpan.UseVisualStyleBackColor = False
            '
            'chkAktif
            '
            Me.chkAktif.AutoSize = True
            Me.chkAktif.Checked = True
            Me.chkAktif.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAktif.Location = New System.Drawing.Point(20, 315)
            Me.chkAktif.Name = "chkAktif"
            Me.chkAktif.Size = New System.Drawing.Size(130, 21)
            Me.chkAktif.TabIndex = 10
            Me.chkAktif.Text = "Status: Akun Aktif"
            Me.chkAktif.UseVisualStyleBackColor = True
            '
            'cmbRole
            '
            Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbRole.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cmbRole.FormattingEnabled = True
            Me.cmbRole.Items.AddRange(New Object() {"Admin", "Owner"})
            Me.cmbRole.Location = New System.Drawing.Point(20, 280)
            Me.cmbRole.Name = "cmbRole"
            Me.cmbRole.Size = New System.Drawing.Size(320, 25)
            Me.cmbRole.TabIndex = 9
            '
            'lblRole
            '
            Me.lblRole.AutoSize = True
            Me.lblRole.Location = New System.Drawing.Point(20, 260)
            Me.lblRole.Name = "lblRole"
            Me.lblRole.Size = New System.Drawing.Size(107, 17)
            Me.lblRole.TabIndex = 8
            Me.lblRole.Text = "Peran / Role User:"
            '
            'txtNamaLengkap
            '
            Me.txtNamaLengkap.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtNamaLengkap.Location = New System.Drawing.Point(20, 225)
            Me.txtNamaLengkap.MaxLength = 100
            Me.txtNamaLengkap.Name = "txtNamaLengkap"
            Me.txtNamaLengkap.Size = New System.Drawing.Size(320, 24)
            Me.txtNamaLengkap.TabIndex = 7
            '
            'lblNamaLengkap
            '
            Me.lblNamaLengkap.AutoSize = True
            Me.lblNamaLengkap.Location = New System.Drawing.Point(20, 205)
            Me.lblNamaLengkap.Name = "lblNamaLengkap"
            Me.lblNamaLengkap.Size = New System.Drawing.Size(103, 17)
            Me.lblNamaLengkap.TabIndex = 6
            Me.lblNamaLengkap.Text = "Nama Lengkap:"
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPassword.Location = New System.Drawing.Point(20, 165)
            Me.txtPassword.MaxLength = 50
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(320, 24)
            Me.txtPassword.TabIndex = 5
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Location = New System.Drawing.Point(20, 145)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(69, 17)
            Me.lblPassword.TabIndex = 4
            Me.lblPassword.Text = "Password:"
            '
            'txtUsername
            '
            Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtUsername.Location = New System.Drawing.Point(20, 105)
            Me.txtUsername.MaxLength = 50
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(320, 24)
            Me.txtUsername.TabIndex = 3
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Location = New System.Drawing.Point(20, 85)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(73, 17)
            Me.lblUsername.TabIndex = 2
            Me.lblUsername.Text = "Username:"
            '
            'txtIdUser
            '
            Me.txtIdUser.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtIdUser.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtIdUser.Location = New System.Drawing.Point(20, 48)
            Me.txtIdUser.Name = "txtIdUser"
            Me.txtIdUser.ReadOnly = True
            Me.txtIdUser.Size = New System.Drawing.Size(320, 24)
            Me.txtIdUser.TabIndex = 1
            '
            'lblIdUser
            '
            Me.lblIdUser.AutoSize = True
            Me.lblIdUser.Location = New System.Drawing.Point(20, 28)
            Me.lblIdUser.Name = "lblIdUser"
            Me.lblIdUser.Size = New System.Drawing.Size(109, 17)
            Me.lblIdUser.TabIndex = 0
            Me.lblIdUser.Text = "ID (Auto Number):"
            '
            'grpData
            '
            Me.grpData.Controls.Add(Me.txtCari)
            Me.grpData.Controls.Add(Me.lblCari)
            Me.grpData.Controls.Add(Me.dgvUsers)
            Me.grpData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpData.Location = New System.Drawing.Point(400, 90)
            Me.grpData.Name = "grpData"
            Me.grpData.Size = New System.Drawing.Size(530, 480)
            Me.grpData.TabIndex = 2
            Me.grpData.TabStop = False
            Me.grpData.Text = " Daftar Pengguna "
            '
            'txtCari
            '
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtCari.Location = New System.Drawing.Point(120, 25)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Ketik username / nama / role..."
            Me.txtCari.Size = New System.Drawing.Size(390, 24)
            Me.txtCari.TabIndex = 2
            '
            'lblCari
            '
            Me.lblCari.AutoSize = True
            Me.lblCari.Location = New System.Drawing.Point(15, 28)
            Me.lblCari.Name = "lblCari"
            Me.lblCari.Size = New System.Drawing.Size(89, 17)
            Me.lblCari.TabIndex = 1
            Me.lblCari.Text = "Cari Pengguna:"
            '
            'dgvUsers
            '
            Me.dgvUsers.AllowUserToAddRows = False
            Me.dgvUsers.AllowUserToDeleteRows = False
            Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvUsers.BackgroundColor = System.Drawing.Color.WhiteSmoke
            Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvUsers.Location = New System.Drawing.Point(15, 60)
            Me.dgvUsers.MultiSelect = False
            Me.dgvUsers.Name = "dgvUsers"
            Me.dgvUsers.ReadOnly = True
            Me.dgvUsers.RowHeadersVisible = False
            Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvUsers.Size = New System.Drawing.Size(495, 400)
            Me.dgvUsers.TabIndex = 0
            '
            'btnKembali
            '
            Me.btnKembali.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKembali.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnKembali.ForeColor = System.Drawing.Color.White
            Me.btnKembali.Location = New System.Drawing.Point(20, 585)
            Me.btnKembali.Name = "btnKembali"
            Me.btnKembali.Size = New System.Drawing.Size(180, 35)
            Me.btnKembali.TabIndex = 3
            Me.btnKembali.Text = "← Kembali ke Menu"
            Me.btnKembali.UseVisualStyleBackColor = False
            '
            'frmMasterUsers
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(950, 635)
            Me.Controls.Add(Me.btnKembali)
            Me.Controls.Add(Me.grpData)
            Me.Controls.Add(Me.grpInput)
            Me.Controls.Add(Me.pnlHeader)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmMasterUsers"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Master Data Users - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.grpInput.ResumeLayout(False)
            Me.grpInput.PerformLayout()
            Me.grpData.ResumeLayout(False)
            Me.grpData.PerformLayout()
            CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents grpInput As System.Windows.Forms.GroupBox
        Friend WithEvents lblIdUser As System.Windows.Forms.Label
        Friend WithEvents txtIdUser As System.Windows.Forms.TextBox
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents lblNamaLengkap As System.Windows.Forms.Label
        Friend WithEvents txtNamaLengkap As System.Windows.Forms.TextBox
        Friend WithEvents lblRole As System.Windows.Forms.Label
        Friend WithEvents cmbRole As System.Windows.Forms.ComboBox
        Friend WithEvents chkAktif As System.Windows.Forms.CheckBox
        Friend WithEvents btnSimpan As System.Windows.Forms.Button
        Friend WithEvents btnUbah As System.Windows.Forms.Button
        Friend WithEvents btnHapus As System.Windows.Forms.Button
        Friend WithEvents btnHapusPermanen As System.Windows.Forms.Button
        Friend WithEvents btnBersihkan As System.Windows.Forms.Button
        Friend WithEvents lblPasswordHint As System.Windows.Forms.Label
        Friend WithEvents grpData As System.Windows.Forms.GroupBox
        Friend WithEvents lblCari As System.Windows.Forms.Label
        Friend WithEvents txtCari As System.Windows.Forms.TextBox
        Friend WithEvents dgvUsers As System.Windows.Forms.DataGridView
        Friend WithEvents btnKembali As System.Windows.Forms.Button
    End Class

End Namespace

