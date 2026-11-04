Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmNotaPreview
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
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.pnlNota = New System.Windows.Forms.Panel()
            Me.txtStruk = New System.Windows.Forms.TextBox()
            Me.pnlFooter = New System.Windows.Forms.Panel()
            Me.btnTutup = New System.Windows.Forms.Button()
            Me.btnCetak = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.pnlNota.SuspendLayout()
            Me.pnlFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.lblJudul)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(434, 55)
            Me.pnlHeader.TabIndex = 0
            '
            'lblJudul
            '
            Me.lblJudul.AutoSize = True
            Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(18, 16)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(264, 21)
            Me.lblJudul.TabIndex = 0
            Me.lblJudul.Text = "BUKTI PEMBAYARAN SEWA (NOTA)"
            '
            'pnlNota
            '
            Me.pnlNota.BackColor = System.Drawing.Color.White
            Me.pnlNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlNota.Controls.Add(Me.txtStruk)
            Me.pnlNota.Location = New System.Drawing.Point(18, 68)
            Me.pnlNota.Name = "pnlNota"
            Me.pnlNota.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlNota.Size = New System.Drawing.Size(398, 440)
            Me.pnlNota.TabIndex = 1
            '
            'txtStruk
            '
            Me.txtStruk.BackColor = System.Drawing.Color.White
            Me.txtStruk.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtStruk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtStruk.Font = New System.Drawing.Font("Consolas", 9.5!, System.Drawing.FontStyle.Regular)
            Me.txtStruk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.txtStruk.Location = New System.Drawing.Point(10, 10)
            Me.txtStruk.Multiline = True
            Me.txtStruk.Name = "txtStruk"
            Me.txtStruk.ReadOnly = True
            Me.txtStruk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtStruk.Size = New System.Drawing.Size(376, 418)
            Me.txtStruk.TabIndex = 0
            '
            'pnlFooter
            '
            Me.pnlFooter.Controls.Add(Me.btnTutup)
            Me.pnlFooter.Controls.Add(Me.btnCetak)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 520)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(434, 65)
            Me.pnlFooter.TabIndex = 2
            '
            'btnTutup
            '
            Me.btnTutup.BackColor = System.Drawing.Color.White
            Me.btnTutup.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTutup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTutup.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnTutup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(74, Byte), Integer))
            Me.btnTutup.Location = New System.Drawing.Point(18, 12)
            Me.btnTutup.Name = "btnTutup"
            Me.btnTutup.Size = New System.Drawing.Size(120, 38)
            Me.btnTutup.TabIndex = 1
            Me.btnTutup.Text = "Tutup"
            Me.btnTutup.UseVisualStyleBackColor = False
            '
            'btnCetak
            '
            Me.btnCetak.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(111, Byte), Integer))
            Me.btnCetak.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnCetak.ForeColor = System.Drawing.Color.White
            Me.btnCetak.Location = New System.Drawing.Point(155, 12)
            Me.btnCetak.Name = "btnCetak"
            Me.btnCetak.Size = New System.Drawing.Size(261, 38)
            Me.btnCetak.TabIndex = 0
            Me.btnCetak.Text = "🖨️ Cetak Dokumen Struk"
            Me.btnCetak.UseVisualStyleBackColor = False
            '
            'frmNotaPreview
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(434, 585)
            Me.Controls.Add(Me.pnlFooter)
            Me.Controls.Add(Me.pnlNota)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmNotaPreview"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Bukti Pembayaran - Arung Futsal"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlNota.ResumeLayout(False)
            Me.pnlNota.PerformLayout()
            Me.pnlFooter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents pnlNota As System.Windows.Forms.Panel
        Friend WithEvents txtStruk As System.Windows.Forms.TextBox
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents btnCetak As System.Windows.Forms.Button
        Friend WithEvents btnTutup As System.Windows.Forms.Button

    End Class

End Namespace

