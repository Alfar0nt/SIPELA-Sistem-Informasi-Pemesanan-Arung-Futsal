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
            Me.btnLogout = New System.Windows.Forms.Button()
            Me.lblBadgeKoneksi = New System.Windows.Forms.Label()
            Me.lblUserInfo = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.pnlStats = New System.Windows.Forms.Panel()
            Me.pnlCardOmzetBulan = New System.Windows.Forms.Panel()
            Me.lblStatOmzetBulan = New System.Windows.Forms.Label()
            Me.lblTitleOmzetBulan = New System.Windows.Forms.Label()
            Me.pnlCardPendingDP = New System.Windows.Forms.Panel()
            Me.lblStatPendingDP = New System.Windows.Forms.Label()
            Me.lblTitlePendingDP = New System.Windows.Forms.Label()
            Me.pnlCardBkgHariIni = New System.Windows.Forms.Panel()
            Me.lblStatBkgHariIni = New System.Windows.Forms.Label()
            Me.lblTitleBkgHariIni = New System.Windows.Forms.Label()
            Me.pnlCardLap = New System.Windows.Forms.Panel()
            Me.lblStatLap = New System.Windows.Forms.Label()
            Me.lblTitleLap = New System.Windows.Forms.Label()
            Me.pnlMenuContainer = New System.Windows.Forms.Panel()
            Me.btnLaporan = New System.Windows.Forms.Button()
            Me.btnJadwal = New System.Windows.Forms.Button()
            Me.btnPembayaran = New System.Windows.Forms.Button()
            Me.btnPemesanan = New System.Windows.Forms.Button()
            Me.btnMasterUsers = New System.Windows.Forms.Button()
            Me.btnMasterLapangan = New System.Windows.Forms.Button()
            Me.pnlFooter = New System.Windows.Forms.Panel()
            Me.lblAutoStatus = New System.Windows.Forms.Label()
            Me.lblFooter = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlStats.SuspendLayout()
            Me.pnlCardOmzetBulan.SuspendLayout()
            Me.pnlCardPendingDP.SuspendLayout()
            Me.pnlCardBkgHariIni.SuspendLayout()
            Me.pnlCardLap.SuspendLayout()
            Me.pnlMenuContainer.SuspendLayout()
            Me.pnlFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.btnLogout)
            Me.pnlHeader.Controls.Add(Me.lblBadgeKoneksi)
            Me.pnlHeader.Controls.Add(Me.lblUserInfo)
            Me.pnlHeader.Controls.Add(Me.lblJudul)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(984, 85)
            Me.pnlHeader.TabIndex = 0
            '
            'btnLogout
            '
            Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
            Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnLogout.Location = New System.Drawing.Point(850, 24)
            Me.btnLogout.Name = "btnLogout"
            Me.btnLogout.Size = New System.Drawing.Size(115, 38)
            Me.btnLogout.TabIndex = 3
            Me.btnLogout.Text = "🚪 Keluar"
            Me.btnLogout.UseVisualStyleBackColor = False
            '
            'lblBadgeKoneksi
            '
            Me.lblBadgeKoneksi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBadgeKoneksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.lblBadgeKoneksi.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblBadgeKoneksi.ForeColor = System.Drawing.Color.White
            Me.lblBadgeKoneksi.Location = New System.Drawing.Point(700, 29)
            Me.lblBadgeKoneksi.Name = "lblBadgeKoneksi"
            Me.lblBadgeKoneksi.Size = New System.Drawing.Size(135, 28)
            Me.lblBadgeKoneksi.TabIndex = 2
            Me.lblBadgeKoneksi.Text = "● MySQL Online"
            Me.lblBadgeKoneksi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblUserInfo
            '
            Me.lblUserInfo.AutoSize = True
            Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.lblUserInfo.Location = New System.Drawing.Point(22, 48)
            Me.lblUserInfo.Name = "lblUserInfo"
            Me.lblUserInfo.Size = New System.Drawing.Size(170, 17)
            Me.lblUserInfo.TabIndex = 1
            Me.lblUserInfo.Text = "Login sebagai: User (Peran)"
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(20, 15)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(462, 30)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "SIPELA — SISTEM OPERASIONAL ARUNG"
            '
            'pnlStats
            '
            Me.pnlStats.Controls.Add(Me.pnlCardOmzetBulan)
            Me.pnlStats.Controls.Add(Me.pnlCardPendingDP)
            Me.pnlStats.Controls.Add(Me.pnlCardBkgHariIni)
            Me.pnlStats.Controls.Add(Me.pnlCardLap)
            Me.pnlStats.Location = New System.Drawing.Point(20, 100)
            Me.pnlStats.Name = "pnlStats"
            Me.pnlStats.Size = New System.Drawing.Size(944, 85)
            Me.pnlStats.TabIndex = 1
            '
            'pnlCardOmzetBulan
            '
            Me.pnlCardOmzetBulan.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.pnlCardOmzetBulan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardOmzetBulan.Controls.Add(Me.lblStatOmzetBulan)
            Me.pnlCardOmzetBulan.Controls.Add(Me.lblTitleOmzetBulan)
            Me.pnlCardOmzetBulan.Location = New System.Drawing.Point(714, 0)
            Me.pnlCardOmzetBulan.Name = "pnlCardOmzetBulan"
            Me.pnlCardOmzetBulan.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlCardOmzetBulan.Size = New System.Drawing.Size(230, 80)
            Me.pnlCardOmzetBulan.TabIndex = 3
            '
            'lblStatOmzetBulan
            '
            Me.lblStatOmzetBulan.AutoSize = True
            Me.lblStatOmzetBulan.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatOmzetBulan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblStatOmzetBulan.Location = New System.Drawing.Point(10, 36)
            Me.lblStatOmzetBulan.Name = "lblStatOmzetBulan"
            Me.lblStatOmzetBulan.Size = New System.Drawing.Size(53, 25)
            Me.lblStatOmzetBulan.TabIndex = 1
            Me.lblStatOmzetBulan.Text = "Rp 0"
            '
            'lblTitleOmzetBulan
            '
            Me.lblTitleOmzetBulan.AutoSize = True
            Me.lblTitleOmzetBulan.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblTitleOmzetBulan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTitleOmzetBulan.Location = New System.Drawing.Point(10, 12)
            Me.lblTitleOmzetBulan.Name = "lblTitleOmzetBulan"
            Me.lblTitleOmzetBulan.Size = New System.Drawing.Size(107, 15)
            Me.lblTitleOmzetBulan.TabIndex = 0
            Me.lblTitleOmzetBulan.Text = "OMZET BULAN INI"
            '
            'pnlCardPendingDP
            '
            Me.pnlCardPendingDP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
            Me.pnlCardPendingDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardPendingDP.Controls.Add(Me.lblStatPendingDP)
            Me.pnlCardPendingDP.Controls.Add(Me.lblTitlePendingDP)
            Me.pnlCardPendingDP.Location = New System.Drawing.Point(476, 0)
            Me.pnlCardPendingDP.Name = "pnlCardPendingDP"
            Me.pnlCardPendingDP.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlCardPendingDP.Size = New System.Drawing.Size(230, 80)
            Me.pnlCardPendingDP.TabIndex = 2
            '
            'lblStatPendingDP
            '
            Me.lblStatPendingDP.AutoSize = True
            Me.lblStatPendingDP.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatPendingDP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblStatPendingDP.Location = New System.Drawing.Point(10, 36)
            Me.lblStatPendingDP.Name = "lblStatPendingDP"
            Me.lblStatPendingDP.Size = New System.Drawing.Size(103, 25)
            Me.lblStatPendingDP.TabIndex = 1
            Me.lblStatPendingDP.Text = "0 Booking"
            '
            'lblTitlePendingDP
            '
            Me.lblTitlePendingDP.AutoSize = True
            Me.lblTitlePendingDP.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblTitlePendingDP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTitlePendingDP.Location = New System.Drawing.Point(10, 12)
            Me.lblTitlePendingDP.Name = "lblTitlePendingDP"
            Me.lblTitlePendingDP.Size = New System.Drawing.Size(127, 15)
            Me.lblTitlePendingDP.TabIndex = 0
            Me.lblTitlePendingDP.Text = "MENUNGGU DP (15M)"
            '
            'pnlCardBkgHariIni
            '
            Me.pnlCardBkgHariIni.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.pnlCardBkgHariIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardBkgHariIni.Controls.Add(Me.lblStatBkgHariIni)
            Me.pnlCardBkgHariIni.Controls.Add(Me.lblTitleBkgHariIni)
            Me.pnlCardBkgHariIni.Location = New System.Drawing.Point(238, 0)
            Me.pnlCardBkgHariIni.Name = "pnlCardBkgHariIni"
            Me.pnlCardBkgHariIni.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlCardBkgHariIni.Size = New System.Drawing.Size(230, 80)
            Me.pnlCardBkgHariIni.TabIndex = 1
            '
            'lblStatBkgHariIni
            '
            Me.lblStatBkgHariIni.AutoSize = True
            Me.lblStatBkgHariIni.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatBkgHariIni.ForeColor = System.Drawing.Color.White
            Me.lblStatBkgHariIni.Location = New System.Drawing.Point(10, 36)
            Me.lblStatBkgHariIni.Name = "lblStatBkgHariIni"
            Me.lblStatBkgHariIni.Size = New System.Drawing.Size(66, 25)
            Me.lblStatBkgHariIni.TabIndex = 1
            Me.lblStatBkgHariIni.Text = "0 Slot"
            '
            'lblTitleBkgHariIni
            '
            Me.lblTitleBkgHariIni.AutoSize = True
            Me.lblTitleBkgHariIni.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblTitleBkgHariIni.ForeColor = System.Drawing.Color.White
            Me.lblTitleBkgHariIni.Location = New System.Drawing.Point(10, 12)
            Me.lblTitleBkgHariIni.Name = "lblTitleBkgHariIni"
            Me.lblTitleBkgHariIni.Size = New System.Drawing.Size(117, 15)
            Me.lblTitleBkgHariIni.TabIndex = 0
            Me.lblTitleBkgHariIni.Text = "BOOKING HARI INI"
            '
            'pnlCardLap
            '
            Me.pnlCardLap.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.pnlCardLap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCardLap.Controls.Add(Me.lblStatLap)
            Me.pnlCardLap.Controls.Add(Me.lblTitleLap)
            Me.pnlCardLap.Location = New System.Drawing.Point(0, 0)
            Me.pnlCardLap.Name = "pnlCardLap"
            Me.pnlCardLap.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlCardLap.Size = New System.Drawing.Size(230, 80)
            Me.pnlCardLap.TabIndex = 0
            '
            'lblStatLap
            '
            Me.lblStatLap.AutoSize = True
            Me.lblStatLap.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatLap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblStatLap.Location = New System.Drawing.Point(10, 36)
            Me.lblStatLap.Name = "lblStatLap"
            Me.lblStatLap.Size = New System.Drawing.Size(119, 25)
            Me.lblStatLap.TabIndex = 1
            Me.lblStatLap.Text = "0 Lapangan"
            '
            'lblTitleLap
            '
            Me.lblTitleLap.AutoSize = True
            Me.lblTitleLap.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblTitleLap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.lblTitleLap.Location = New System.Drawing.Point(10, 12)
            Me.lblTitleLap.Name = "lblTitleLap"
            Me.lblTitleLap.Size = New System.Drawing.Size(107, 15)
            Me.lblTitleLap.TabIndex = 0
            Me.lblTitleLap.Text = "TOTAL LAPANGAN"
            '
            'pnlMenuContainer
            '
            Me.pnlMenuContainer.Controls.Add(Me.btnLaporan)
            Me.pnlMenuContainer.Controls.Add(Me.btnJadwal)
            Me.pnlMenuContainer.Controls.Add(Me.btnPembayaran)
            Me.pnlMenuContainer.Controls.Add(Me.btnPemesanan)
            Me.pnlMenuContainer.Controls.Add(Me.btnMasterUsers)
            Me.pnlMenuContainer.Controls.Add(Me.btnMasterLapangan)
            Me.pnlMenuContainer.Location = New System.Drawing.Point(20, 200)
            Me.pnlMenuContainer.Name = "pnlMenuContainer"
            Me.pnlMenuContainer.Size = New System.Drawing.Size(944, 400)
            Me.pnlMenuContainer.TabIndex = 2
            '
            'btnLaporan
            '
            Me.btnLaporan.BackColor = System.Drawing.Color.White
            Me.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLaporan.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnLaporan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnLaporan.Location = New System.Drawing.Point(636, 205)
            Me.btnLaporan.Name = "btnLaporan"
            Me.btnLaporan.Padding = New System.Windows.Forms.Padding(12)
            Me.btnLaporan.Size = New System.Drawing.Size(300, 180)
            Me.btnLaporan.TabIndex = 5
            Me.btnLaporan.Text = "📊 LAPORAN & ANALITIK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Omzet Bulanan, Okupansi Lapangan && Ekspor Data (Owner)"
            Me.btnLaporan.UseVisualStyleBackColor = False
            '
            'btnJadwal
            '
            Me.btnJadwal.BackColor = System.Drawing.Color.White
            Me.btnJadwal.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnJadwal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnJadwal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnJadwal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnJadwal.Location = New System.Drawing.Point(636, 10)
            Me.btnJadwal.Name = "btnJadwal"
            Me.btnJadwal.Padding = New System.Windows.Forms.Padding(12)
            Me.btnJadwal.Size = New System.Drawing.Size(300, 180)
            Me.btnJadwal.TabIndex = 4
            Me.btnJadwal.Text = "📅 MATRIKS JADWAL SEWA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kalender Visual Ketersediaan Lapangan per Jam (08-24 WIB)"
            Me.btnJadwal.UseVisualStyleBackColor = False
            '
            'btnPembayaran
            '
            Me.btnPembayaran.BackColor = System.Drawing.Color.White
            Me.btnPembayaran.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPembayaran.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnPembayaran.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnPembayaran.Location = New System.Drawing.Point(318, 10)
            Me.btnPembayaran.Name = "btnPembayaran"
            Me.btnPembayaran.Padding = New System.Windows.Forms.Padding(12)
            Me.btnPembayaran.Size = New System.Drawing.Size(300, 180)
            Me.btnPembayaran.TabIndex = 3
            Me.btnPembayaran.Text = "💰 KASIR & PEMBAYARAN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Proses Uang Muka (DP), Pelunasan && Cetak Nota Resmi"
            Me.btnPembayaran.UseVisualStyleBackColor = False
            '
            'btnPemesanan
            '
            Me.btnPemesanan.BackColor = System.Drawing.Color.White
            Me.btnPemesanan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPemesanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPemesanan.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnPemesanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnPemesanan.Location = New System.Drawing.Point(0, 10)
            Me.btnPemesanan.Name = "btnPemesanan"
            Me.btnPemesanan.Padding = New System.Windows.Forms.Padding(12)
            Me.btnPemesanan.Size = New System.Drawing.Size(300, 180)
            Me.btnPemesanan.TabIndex = 2
            Me.btnPemesanan.Text = "📝 TRANSAKSI PEMESANAN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Input Booking Sewa && Pemilihan Slot Jam Anti-Bentrok"
            Me.btnPemesanan.UseVisualStyleBackColor = False
            '
            'btnMasterUsers
            '
            Me.btnMasterUsers.BackColor = System.Drawing.Color.White
            Me.btnMasterUsers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMasterUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMasterUsers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnMasterUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnMasterUsers.Location = New System.Drawing.Point(318, 205)
            Me.btnMasterUsers.Name = "btnMasterUsers"
            Me.btnMasterUsers.Padding = New System.Windows.Forms.Padding(12)
            Me.btnMasterUsers.Size = New System.Drawing.Size(300, 180)
            Me.btnMasterUsers.TabIndex = 1
            Me.btnMasterUsers.Text = "👤 MASTER PENGGUNA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kelola Akun Staf Kasir && Hak Akses Peran (Owner)"
            Me.btnMasterUsers.UseVisualStyleBackColor = False
            '
            'btnMasterLapangan
            '
            Me.btnMasterLapangan.BackColor = System.Drawing.Color.White
            Me.btnMasterLapangan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMasterLapangan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMasterLapangan.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnMasterLapangan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnMasterLapangan.Location = New System.Drawing.Point(0, 205)
            Me.btnMasterLapangan.Name = "btnMasterLapangan"
            Me.btnMasterLapangan.Padding = New System.Windows.Forms.Padding(12)
            Me.btnMasterLapangan.Size = New System.Drawing.Size(300, 180)
            Me.btnMasterLapangan.TabIndex = 0
            Me.btnMasterLapangan.Text = "📋 MASTER LAPANGAN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kelola Data Fasilitas && Penyesuaian Tarif Sewa (Owner)"
            Me.btnMasterLapangan.UseVisualStyleBackColor = False
            '
            'pnlFooter
            '
            Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.pnlFooter.Controls.Add(Me.lblAutoStatus)
            Me.pnlFooter.Controls.Add(Me.lblFooter)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 615)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(984, 45)
            Me.pnlFooter.TabIndex = 3
            '
            'lblAutoStatus
            '
            Me.lblAutoStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoStatus.AutoSize = True
            Me.lblAutoStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
            Me.lblAutoStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(158, Byte), Integer))
            Me.lblAutoStatus.Location = New System.Drawing.Point(670, 15)
            Me.lblAutoStatus.Name = "lblAutoStatus"
            Me.lblAutoStatus.Size = New System.Drawing.Size(294, 15)
            Me.lblAutoStatus.TabIndex = 1
            Me.lblAutoStatus.Text = "⚙️ Pemeliharaan Otomatis: Aktif (Pengecekan per 30 detik)"
            '
            'lblFooter
            '
            Me.lblFooter.AutoSize = True
            Me.lblFooter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
            Me.lblFooter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(158, Byte), Integer))
            Me.lblFooter.Location = New System.Drawing.Point(20, 15)
            Me.lblFooter.Name = "lblFooter"
            Me.lblFooter.Size = New System.Drawing.Size(377, 15)
            Me.lblFooter.TabIndex = 0
            Me.lblFooter.Text = "SIPELA v2.0 • Sistem Informasi Pemesanan Arung Futsal • UPNVJT 2026"
            '
            'frmMenuUtama
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(984, 660)
            Me.Controls.Add(Me.pnlFooter)
            Me.Controls.Add(Me.pnlMenuContainer)
            Me.Controls.Add(Me.pnlStats)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmMenuUtama"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "SIPELA - Menu Utama & Dasbor Operasional"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlStats.ResumeLayout(False)
            Me.pnlCardOmzetBulan.ResumeLayout(False)
            Me.pnlCardOmzetBulan.PerformLayout()
            Me.pnlCardPendingDP.ResumeLayout(False)
            Me.pnlCardPendingDP.PerformLayout()
            Me.pnlCardBkgHariIni.ResumeLayout(False)
            Me.pnlCardBkgHariIni.PerformLayout()
            Me.pnlCardLap.ResumeLayout(False)
            Me.pnlCardLap.PerformLayout()
            Me.pnlMenuContainer.ResumeLayout(False)
            Me.pnlFooter.ResumeLayout(False)
            Me.pnlFooter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblUserInfo As System.Windows.Forms.Label
        Friend WithEvents lblBadgeKoneksi As System.Windows.Forms.Label
        Friend WithEvents btnLogout As System.Windows.Forms.Button
        Friend WithEvents pnlStats As System.Windows.Forms.Panel
        Friend WithEvents pnlCardLap As System.Windows.Forms.Panel
        Friend WithEvents lblTitleLap As System.Windows.Forms.Label
        Friend WithEvents lblStatLap As System.Windows.Forms.Label
        Friend WithEvents pnlCardBkgHariIni As System.Windows.Forms.Panel
        Friend WithEvents lblTitleBkgHariIni As System.Windows.Forms.Label
        Friend WithEvents lblStatBkgHariIni As System.Windows.Forms.Label
        Friend WithEvents pnlCardPendingDP As System.Windows.Forms.Panel
        Friend WithEvents lblTitlePendingDP As System.Windows.Forms.Label
        Friend WithEvents lblStatPendingDP As System.Windows.Forms.Label
        Friend WithEvents pnlCardOmzetBulan As System.Windows.Forms.Panel
        Friend WithEvents lblTitleOmzetBulan As System.Windows.Forms.Label
        Friend WithEvents lblStatOmzetBulan As System.Windows.Forms.Label
        Friend WithEvents pnlMenuContainer As System.Windows.Forms.Panel
        Friend WithEvents btnPemesanan As System.Windows.Forms.Button
        Friend WithEvents btnPembayaran As System.Windows.Forms.Button
        Friend WithEvents btnJadwal As System.Windows.Forms.Button
        Friend WithEvents btnMasterLapangan As System.Windows.Forms.Button
        Friend WithEvents btnMasterUsers As System.Windows.Forms.Button
        Friend WithEvents btnLaporan As System.Windows.Forms.Button
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents lblFooter As System.Windows.Forms.Label
        Friend WithEvents lblAutoStatus As System.Windows.Forms.Label

    End Class

End Namespace
