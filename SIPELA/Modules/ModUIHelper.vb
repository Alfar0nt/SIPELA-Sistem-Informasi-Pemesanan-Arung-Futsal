Option Strict On
Option Explicit On

Imports System
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

''' <summary>
''' Modul Helper UI terpusat untuk menerapkan gaya visual Tactile Claymorphism + Neo-Brutalism
''' pada aplikasi desktop Windows Forms (.NET 10).
''' </summary>
Public Module ModUIHelper

    ' =========================================================================
    ' 1. PALET WARNA RESMI TACTILE CLAYMORPHISM + NEO-BRUTALISM
    ' =========================================================================

    ''' <summary>Kanvas latar belakang form utama (#FDFBF7).</summary>
    Public ReadOnly ColorWarmCream As Color = Color.FromArgb(253, 251, 247)

    ''' <summary>Tinta garis border, teks utama, dan kisi (#2D334A).</summary>
    Public ReadOnly ColorCrispSlate As Color = Color.FromArgb(45, 51, 74)

    ''' <summary>Aksen utama sukses, tombol aksi simpan, slot tersedia (#25C16F).</summary>
    Public ReadOnly ColorMintGreen As Color = Color.FromArgb(37, 193, 111)

    ''' <summary>Aksen sekunder navigasi, slot terpilih, filter (#AED4E6).</summary>
    Public ReadOnly ColorSkyBlue As Color = Color.FromArgb(174, 212, 230)

    ''' <summary>Aksen peringatan, bahaya, batal, slot terisi (#FFB5B5).</summary>
    Public ReadOnly ColorCoral As Color = Color.FromArgb(255, 181, 181)

    ''' <summary>Aksen netral, kartu metrik, baris alternatif (#D8D4F2).</summary>
    Public ReadOnly ColorLavender As Color = Color.FromArgb(216, 212, 242)

    ''' <summary>Teks redup, petunjuk input, label sekunder (#7A829E).</summary>
    Public ReadOnly ColorSlateMuted As Color = Color.FromArgb(122, 130, 158)

    ''' <summary>Latar permukaan kartu input (#FFFFFF).</summary>
    Public ReadOnly ColorCardWhite As Color = Color.White

    ''' <summary>
    ''' Tipe gaya warna untuk tombol taktil.
    ''' </summary>
    Public Enum TombolTipe
        PrimaryMint
        SecondarySky
        DangerCoral
        NeutralLavender
        OutlineWhite
    End Enum

    ' =========================================================================
    ' 2. METODE STYLING FORM & KONTROL
    ' =========================================================================

    ''' <summary>
    ''' Menerapkan tema visual Neo-Brutalist pada form dan mengaktifkan DoubleBuffering.
    ''' </summary>
    ''' <param name="frm">Form target.</param>
    Public Sub TerapkanTemaForm(frm As Form)
        If frm Is Nothing Then Return

        frm.BackColor = ColorWarmCream
        frm.ForeColor = ColorCrispSlate
        frm.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)

        ' Aktifkan DoubleBuffered lewat reflection agar render lebih halus
        Try
            Dim prop As PropertyInfo = GetType(Form).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
            If prop IsNot Nothing Then
                prop.SetValue(frm, True, Nothing)
            End If
        Catch
            ' Abaikan jika reflection dibatasi lingkungan sandbox
        End Try
    End Sub

    ''' <summary>
    ''' Menerapkan gaya taktil Neo-Brutalism pada tombol Windows Forms dengan border tebal dan efek tekan mekanis.
    ''' </summary>
    ''' <param name="btn">Tombol target.</param>
    ''' <param name="tipe">Pilihan skema warna tombol.</param>
    Public Sub TerapkanGayaTombol(btn As Button, tipe As TombolTipe)
        If btn Is Nothing Then Return

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 2
        btn.FlatAppearance.BorderColor = ColorCrispSlate
        btn.Cursor = Cursors.Hand
        btn.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)

        Select Case tipe
            Case TombolTipe.PrimaryMint
                btn.BackColor = ColorMintGreen
                btn.ForeColor = Color.White
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 175, 99)

            Case TombolTipe.SecondarySky
                btn.BackColor = ColorSkyBlue
                btn.ForeColor = ColorCrispSlate
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(154, 198, 218)

            Case TombolTipe.DangerCoral
                btn.BackColor = ColorCoral
                btn.ForeColor = ColorCrispSlate
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 160, 160)

            Case TombolTipe.NeutralLavender
                btn.BackColor = ColorLavender
                btn.ForeColor = ColorCrispSlate
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 192, 232)

            Case TombolTipe.OutlineWhite
                btn.BackColor = ColorCardWhite
                btn.ForeColor = ColorCrispSlate
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 243, 238)
        End Select

        ' Tambahkan efek mikro-interaksi taktil: bergeser 2px saat ditekan
        RemoveHandler btn.MouseDown, AddressOf Tombol_MouseDown
        RemoveHandler btn.MouseUp, AddressOf Tombol_MouseUp
        AddHandler btn.MouseDown, AddressOf Tombol_MouseDown
        AddHandler btn.MouseUp, AddressOf Tombol_MouseUp
    End Sub

    Private Sub Tombol_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim btn As Button = TryCast(sender, Button)
            If btn IsNot Nothing Then
                btn.Location = New Point(btn.Left + 2, btn.Top + 2)
            End If
        End If
    End Sub

    Private Sub Tombol_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim btn As Button = TryCast(sender, Button)
            If btn IsNot Nothing Then
                btn.Location = New Point(btn.Left - 2, btn.Top - 2)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Menerapkan border tebal solid slate ink (#2D334A) pada container Panel.
    ''' </summary>
    ''' <param name="pnl">Panel container target.</param>
    ''' <param name="latarBelakang">Warna latar belakang panel (default: Pure White).</param>
    Public Sub TerapkanGayaCard(pnl As Panel, Optional latarBelakang As Nullable(Of Color) = Nothing)
        If pnl Is Nothing Then Return

        pnl.BackColor = If(latarBelakang.HasValue, latarBelakang.Value, ColorCardWhite)
        RemoveHandler pnl.Paint, AddressOf PanelCard_Paint
        AddHandler pnl.Paint, AddressOf PanelCard_Paint
        pnl.Invalidate()
    End Sub

    Private Sub PanelCard_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = TryCast(sender, Panel)
        If pnl Is Nothing Then Return

        Dim rect As Rectangle = pnl.ClientRectangle
        rect.Width -= 2
        rect.Height -= 2

        Using penSlate As New Pen(ColorCrispSlate, 2.0!)
            e.Graphics.DrawRectangle(penSlate, rect)
        End Using
    End Sub

    ''' <summary>
    ''' Menerapkan styling DataGridView Neo-Brutalism: header slate gelap, alternating rows pastel lavender,
    ''' dan baris terpilih sky blue.
    ''' </summary>
    ''' <param name="dgv">DataGridView target.</param>
    Public Sub TerapkanGayaGrid(dgv As DataGridView)
        If dgv Is Nothing Then Return

        dgv.BackgroundColor = ColorWarmCream
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.GridColor = Color.FromArgb(200, 205, 220)
        dgv.RowHeadersVisible = False
        dgv.MultiSelect = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.EnableHeadersVisualStyles = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Header tabel
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorCrispSlate
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.ColumnHeadersHeight = 36
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        ' Baris data utama
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.ForeColor = ColorCrispSlate
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        dgv.DefaultCellStyle.SelectionBackColor = ColorSkyBlue
        dgv.DefaultCellStyle.SelectionForeColor = ColorCrispSlate

        ' Baris data selang-seling (Soft Lavender Tint)
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 246, 253)
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = ColorCrispSlate
        dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorSkyBlue
        dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = ColorCrispSlate

        dgv.RowTemplate.Height = 32
    End Sub

    ''' <summary>
    ''' Memformat Label menjadi pill badge dengan teks tebal dan sudut rata berlatar pastel.
    ''' </summary>
    Public Sub TerapkanBadgePill(lbl As Label, latar As Color, teks As Color)
        If lbl Is Nothing Then Return

        lbl.AutoSize = False
        lbl.BackColor = latar
        lbl.ForeColor = teks
        lbl.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
        lbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub

End Module

