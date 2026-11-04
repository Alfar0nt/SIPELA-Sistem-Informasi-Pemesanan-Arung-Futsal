Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMenuUtama
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
            Me.lblUserInfo = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.flpMenu = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnMasterLapangan = New System.Windows.Forms.Button()
            Me.btnMasterUsers = New System.Windows.Forms.Button()
            Me.btnPemesanan = New System.Windows.Forms.Button()
            Me.btnPembayaran = New System.Windows.Forms.Button()
            Me.btnJadwal = New System.Windows.Forms.Button()
            Me.btnLaporan = New System.Windows.Forms.Button()
            Me.pnlFooter = New System.Windows.Forms.Panel()
            Me.lblFooter = New System.Windows.Forms.Label()
            Me.btnLogout = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.flpMenu.SuspendLayout()
            Me.pnlFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.DarkSlateBlue
            Me.pnlHeader.Controls.Add(Me.lblUserInfo)
            Me.pnlHeader.Controls.Add(Me.lblJudul)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(720, 95)
            Me.pnlHeader.TabIndex = 0
            '
            'lblUserInfo
            '
            Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblUserInfo.ForeColor = System.Drawing.Color.Lavender
            Me.lblUserInfo.Location = New System.Drawing.Point(20, 55)
            Me.lblUserInfo.Name = "lblUserInfo"
            Me.lblUserInfo.Size = New System.Drawing.Size(680, 25)
            Me.lblUserInfo.TabIndex = 1
            Me.lblUserInfo.Text = "Login sebagai: User (Role)"
            Me.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblJudul
            '
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(18, 15)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(680, 35)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "SIPELA - Menu Utama"
            Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'flpMenu
            '
            Me.flpMenu.Controls.Add(Me.btnMasterLapangan)
            Me.flpMenu.Controls.Add(Me.btnMasterUsers)
            Me.flpMenu.Controls.Add(Me.btnPemesanan)
            Me.flpMenu.Controls.Add(Me.btnPembayaran)
            Me.flpMenu.Controls.Add(Me.btnJadwal)
            Me.flpMenu.Controls.Add(Me.btnLaporan)
            Me.flpMenu.Location = New System.Drawing.Point(25, 120)
            Me.flpMenu.Name = "flpMenu"
            Me.flpMenu.Padding = New System.Windows.Forms.Padding(10)
            Me.flpMenu.Size = New System.Drawing.Size(670, 310)
            Me.flpMenu.TabIndex = 1
            '
            'btnMasterLapangan
            '
            Me.btnMasterLapangan.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnMasterLapangan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMasterLapangan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMasterLapangan.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnMasterLapangan.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.btnMasterLapangan.Location = New System.Drawing.Point(20, 20)
            Me.btnMasterLapangan.Margin = New System.Windows.Forms.Padding(10)
            Me.btnMasterLapangan.Name = "btnMasterLapangan"
            Me.btnMasterLapangan.Size = New System.Drawing.Size(195, 120)
            Me.btnMasterLapangan.TabIndex = 0
            Me.btnMasterLapangan.Text = "Master Data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lapangan"
            Me.btnMasterLapangan.UseVisualStyleBackColor = False
            '
            'btnMasterUsers
            '
            Me.btnMasterUsers.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnMasterUsers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMasterUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMasterUsers.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnMasterUsers.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.btnMasterUsers.Location = New System.Drawing.Point(235, 20)
            Me.btnMasterUsers.Margin = New System.Windows.Forms.Padding(10)
            Me.btnMasterUsers.Name = "btnMasterUsers"
            Me.btnMasterUsers.Size = New System.Drawing.Size(195, 120)
            Me.btnMasterUsers.TabIndex = 1
            Me.btnMasterUsers.Text = "Master Data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Users (Pengguna)"
            Me.btnMasterUsers.UseVisualStyleBackColor = False
            '
            'btnPemesanan
            '
            Me.btnPemesanan.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnPemesanan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPemesanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPemesanan.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnPemesanan.ForeColor = System.Drawing.Color.Gray
            Me.btnPemesanan.Location = New System.Drawing.Point(450, 20)
            Me.btnPemesanan.Margin = New System.Windows.Forms.Padding(10)
            Me.btnPemesanan.Name = "btnPemesanan"
            Me.btnPemesanan.Size = New System.Drawing.Size(195, 120)
            Me.btnPemesanan.TabIndex = 2
            Me.btnPemesanan.Text = "Transaksi" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pemesanan"
            Me.btnPemesanan.UseVisualStyleBackColor = False
            '
            'btnPembayaran
            '
            Me.btnPembayaran.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnPembayaran.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPembayaran.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnPembayaran.ForeColor = System.Drawing.Color.Gray
            Me.btnPembayaran.Location = New System.Drawing.Point(20, 160)
            Me.btnPembayaran.Margin = New System.Windows.Forms.Padding(10)
            Me.btnPembayaran.Name = "btnPembayaran"
            Me.btnPembayaran.Size = New System.Drawing.Size(195, 120)
            Me.btnPembayaran.TabIndex = 3
            Me.btnPembayaran.Text = "Transaksi" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pembayaran"
            Me.btnPembayaran.UseVisualStyleBackColor = False
            '
            'btnJadwal
            '
            Me.btnJadwal.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnJadwal.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnJadwal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnJadwal.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnJadwal.ForeColor = System.Drawing.Color.Gray
            Me.btnJadwal.Location = New System.Drawing.Point(235, 160)
            Me.btnJadwal.Margin = New System.Windows.Forms.Padding(10)
            Me.btnJadwal.Name = "btnJadwal"
            Me.btnJadwal.Size = New System.Drawing.Size(195, 120)
            Me.btnJadwal.TabIndex = 4
            Me.btnJadwal.Text = "Kalender" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Jadwal Lapangan"
            Me.btnJadwal.UseVisualStyleBackColor = False
            '
            'btnLaporan
            '
            Me.btnLaporan.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLaporan.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnLaporan.ForeColor = System.Drawing.Color.Gray
            Me.btnLaporan.Location = New System.Drawing.Point(450, 160)
            Me.btnLaporan.Margin = New System.Windows.Forms.Padding(10)
            Me.btnLaporan.Name = "btnLaporan"
            Me.btnLaporan.Size = New System.Drawing.Size(195, 120)
            Me.btnLaporan.TabIndex = 5
            Me.btnLaporan.Text = "Laporan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pendapatan && Okupansi"
            Me.btnLaporan.UseVisualStyleBackColor = False
            '
            'pnlFooter
            '
            Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
            Me.pnlFooter.Controls.Add(Me.lblFooter)
            Me.pnlFooter.Controls.Add(Me.btnLogout)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 450)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(720, 60)
            Me.pnlFooter.TabIndex = 2
            '
            'lblFooter
            '
            Me.lblFooter.AutoSize = True
            Me.lblFooter.ForeColor = System.Drawing.Color.Gray
            Me.lblFooter.Location = New System.Drawing.Point(25, 22)
            Me.lblFooter.Name = "lblFooter"
            Me.lblFooter.Size = New System.Drawing.Size(262, 15)
            Me.lblFooter.TabIndex = 1
            Me.lblFooter.Text = "SIPELA v1.0 • Pemrograman Desktop UPNVJT 2026"
            '
            'btnLogout
            '
            Me.btnLogout.BackColor = System.Drawing.Color.IndianRed
            Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnLogout.ForeColor = System.Drawing.Color.White
            Me.btnLogout.Location = New System.Drawing.Point(575, 12)
            Me.btnLogout.Name = "btnLogout"
            Me.btnLogout.Size = New System.Drawing.Size(120, 36)
            Me.btnLogout.TabIndex = 0
            Me.btnLogout.Text = "Keluar / Logout"
            Me.btnLogout.UseVisualStyleBackColor = False
            '
            'frmMenuUtama
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(720, 510)
            Me.Controls.Add(Me.pnlFooter)
            Me.Controls.Add(Me.flpMenu)
            Me.Controls.Add(Me.pnlHeader)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "frmMenuUtama"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Menu Utama - SIPELA"
            Me.pnlHeader.ResumeLayout(False)
            Me.flpMenu.ResumeLayout(False)
            Me.pnlFooter.ResumeLayout(False)
            Me.pnlFooter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblUserInfo As System.Windows.Forms.Label
        Friend WithEvents flpMenu As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnMasterLapangan As System.Windows.Forms.Button
        Friend WithEvents btnMasterUsers As System.Windows.Forms.Button
        Friend WithEvents btnPemesanan As System.Windows.Forms.Button
        Friend WithEvents btnPembayaran As System.Windows.Forms.Button
        Friend WithEvents btnJadwal As System.Windows.Forms.Button
        Friend WithEvents btnLaporan As System.Windows.Forms.Button
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents btnLogout As System.Windows.Forms.Button
        Friend WithEvents lblFooter As System.Windows.Forms.Label
    End Class

End Namespace

