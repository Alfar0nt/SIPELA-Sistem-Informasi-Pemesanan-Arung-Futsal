Option Strict On
Option Explicit On

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms

Namespace Modules

    Public Module ModUIHelper

        Private ReadOnly _cacheIcon As New Collections.Generic.Dictionary(Of String, Image)()

        ''' <summary>
        ''' Mendapatkan image icon 16x16 px untuk tombol CRUD sesuai ketentuan tugas.
        ''' Jika file lokal tidak ditemukan, icon akan digambar secara runtime via GDI+ (fallback aman).
        ''' </summary>
        Public Function DapatkanIcon(namaIcon As String) As Image
            If _cacheIcon.ContainsKey(namaIcon) Then
                Return _cacheIcon(namaIcon)
            End If

            Dim img As Image = Nothing

            ' Coba cari file di beberapa lokasi umum
            Dim daftarPath As String() = {
                Path.Combine(Application.StartupPath, "Resources", "Icons", namaIcon),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons", namaIcon),
                Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "Icons", namaIcon)
            }

            For Each p As String In daftarPath
                If File.Exists(p) Then
                    Try
                        Using fs As New FileStream(p, FileMode.Open, FileAccess.Read)
                            img = Image.FromStream(fs)
                        End Using
                        Exit For
                    Catch
                        ' Lanjut ke fallback runtime jika gagal baca stream
                    End Try
                End If
            Next

            ' Fallback runtime: gambar icon 16x16 langsung di memori
            If img Is Nothing Then
                img = BuatIconRuntime(namaIcon)
            End If

            _cacheIcon(namaIcon) = img
            Return img
        End Function

        ''' <summary>
        ''' Menggambar icon 16x16 secara dinamis jika file PNG tidak tersedia.
        ''' </summary>
        Private Function BuatIconRuntime(namaIcon As String) As Image
            Dim bmp As New Bitmap(16, 16)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.Clear(Color.Transparent)

                Select Case namaIcon.ToLowerInvariant()
                    Case "insert.png"
                        Using brush As New SolidBrush(Color.FromArgb(46, 139, 87)),
                              pen As New Pen(Color.FromArgb(34, 110, 68), 1.0F),
                              whitePen As New Pen(Color.White, 2.0F)
                            g.FillEllipse(brush, 1, 1, 13, 13)
                            g.DrawEllipse(pen, 1, 1, 13, 13)
                            g.DrawLine(whitePen, 7.5F, 4.0F, 7.5F, 11.0F)
                            g.DrawLine(whitePen, 4.0F, 7.5F, 11.0F, 7.5F)
                        End Using

                    Case "update.png"
                        Using brush As New SolidBrush(Color.FromArgb(30, 144, 255)),
                              pen As New Pen(Color.FromArgb(24, 100, 180), 1.0F),
                              whitePen As New Pen(Color.White, 1.5F)
                            g.FillEllipse(brush, 1, 1, 13, 13)
                            g.DrawEllipse(pen, 1, 1, 13, 13)
                            g.DrawLine(whitePen, 4.0F, 11.0F, 10.0F, 5.0F)
                            g.DrawLine(whitePen, 10.0F, 5.0F, 11.0F, 6.0F)
                            g.DrawLine(whitePen, 11.0F, 6.0F, 5.0F, 12.0F)
                            g.DrawLine(whitePen, 4.0F, 11.0F, 3.0F, 12.0F)
                        End Using

                    Case "delete.png"
                        Using brush As New SolidBrush(Color.FromArgb(220, 20, 60)),
                              pen As New Pen(Color.FromArgb(160, 15, 45), 1.0F),
                              whitePen As New Pen(Color.White, 2.0F)
                            g.FillEllipse(brush, 1, 1, 13, 13)
                            g.DrawEllipse(pen, 1, 1, 13, 13)
                            g.DrawLine(whitePen, 4.5F, 4.5F, 10.5F, 10.5F)
                            g.DrawLine(whitePen, 10.5F, 4.5F, 4.5F, 10.5F)
                        End Using

                    Case "deactivate.png"
                        Using brush As New SolidBrush(Color.FromArgb(255, 140, 0)),
                              pen As New Pen(Color.FromArgb(200, 100, 0), 1.0F),
                              whitePen As New Pen(Color.White, 2.0F)
                            g.FillEllipse(brush, 1, 1, 13, 13)
                            g.DrawEllipse(pen, 1, 1, 13, 13)
                            g.DrawLine(whitePen, 4.0F, 7.5F, 11.0F, 7.5F)
                        End Using

                    Case Else ' clear.png
                        Using brush As New SolidBrush(Color.FromArgb(112, 128, 144)),
                              pen As New Pen(Color.FromArgb(80, 90, 100), 1.0F),
                              whitePen As New Pen(Color.White, 1.5F)
                            g.FillEllipse(brush, 1, 1, 13, 13)
                            g.DrawEllipse(pen, 1, 1, 13, 13)
                            g.DrawArc(whitePen, 4.0F, 4.0F, 7.0F, 7.0F, 45.0F, 270.0F)
                        End Using
                End Select
            End Using
            Return bmp
        End Function

        ''' <summary>
        ''' Menerapkan styling tombol sesuai rubrik penugasan:
        ''' - Image: 16x16 px
        ''' - ImageAlign: MiddleCenter
        ''' - TextAlign: MiddleRight
        ''' - TextImageRelation: ImageBeforeText
        ''' </summary>
        Public Sub TerapkanStyleTombol(btn As Button, namaIcon As String)
            btn.Image = DapatkanIcon(namaIcon)
            btn.ImageAlign = ContentAlignment.MiddleCenter
            btn.TextAlign = ContentAlignment.MiddleRight
            btn.TextImageRelation = TextImageRelation.ImageBeforeText
        End Sub

    End Module

End Namespace

