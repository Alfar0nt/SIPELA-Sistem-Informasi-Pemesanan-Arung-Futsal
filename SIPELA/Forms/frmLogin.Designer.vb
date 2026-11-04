Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmLogin
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
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.btnLogin = New System.Windows.Forms.Button()
            Me.btnKeluar = New System.Windows.Forms.Button()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(420, 90)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubJudul
            '
            Me.lblSubJudul.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubJudul.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblSubJudul.Location = New System.Drawing.Point(12, 50)
            Me.lblSubJudul.Name = "lblSubJudul"
            Me.lblSubJudul.Size = New System.Drawing.Size(396, 25)
            Me.lblSubJudul.TabIndex = 1
            Me.lblSubJudul.Text = "Sistem Pemesanan Lapangan Arung Futsal"
            Me.lblSubJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblJudul
            '
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(12, 12)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(396, 38)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "SIPELA - LOGIN"
            Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUsername.Location = New System.Drawing.Point(45, 115)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(73, 17)
            Me.lblUsername.TabIndex = 1
            Me.lblUsername.Text = "Username:"
            '
            'txtUsername
            '
            Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtUsername.Location = New System.Drawing.Point(45, 137)
            Me.txtUsername.MaxLength = 50
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(330, 25)
            Me.txtUsername.TabIndex = 2
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblPassword.Location = New System.Drawing.Point(45, 175)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(69, 17)
            Me.lblPassword.TabIndex = 3
            Me.lblPassword.Text = "Password:"
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPassword.Location = New System.Drawing.Point(45, 197)
            Me.txtPassword.MaxLength = 50
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(330, 25)
            Me.txtPassword.TabIndex = 4
            '
            'btnLogin
            '
            Me.btnLogin.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLogin.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnLogin.ForeColor = System.Drawing.Color.White
            Me.btnLogin.Location = New System.Drawing.Point(45, 245)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(160, 36)
            Me.btnLogin.TabIndex = 5
            Me.btnLogin.Text = "Masuk"
            Me.btnLogin.UseVisualStyleBackColor = False
            '
            'btnKeluar
            '
            Me.btnKeluar.BackColor = System.Drawing.Color.Gray
            Me.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnKeluar.ForeColor = System.Drawing.Color.White
            Me.btnKeluar.Location = New System.Drawing.Point(215, 245)
            Me.btnKeluar.Name = "btnKeluar"
            Me.btnKeluar.Size = New System.Drawing.Size(160, 36)
            Me.btnKeluar.TabIndex = 6
            Me.btnKeluar.Text = "Keluar"
            Me.btnKeluar.UseVisualStyleBackColor = False
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblStatus.ForeColor = System.Drawing.Color.IndianRed
            Me.lblStatus.Location = New System.Drawing.Point(45, 290)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(330, 40)
            Me.lblStatus.TabIndex = 7
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'frmLogin
            '
            Me.AcceptButton = Me.btnLogin
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(420, 345)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.btnKeluar)
            Me.Controls.Add(Me.btnLogin)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.lblUsername)
            Me.Controls.Add(Me.pnlHeader)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLogin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Login - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSubJudul As System.Windows.Forms.Label
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents btnLogin As System.Windows.Forms.Button
        Friend WithEvents btnKeluar As System.Windows.Forms.Button
        Friend WithEvents lblStatus As System.Windows.Forms.Label
    End Class

End Namespace

