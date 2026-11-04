Option Strict On
Option Explicit On

Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms

Namespace Forms

    ''' <summary>
    ''' Form Pratinjau & Pencetakan Nota Pembayaran Resmi Arung Futsal.
    ''' Mendukung pencetakan fisik ke printer sistem menggunakan System.Drawing.Printing.
    ''' </summary>
    Public Class frmNotaPreview

        Private _teksNota As String = String.Empty

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Konstruktor untuk menginisialisasi pratinjau dengan teks struk yang sudah diformat.
        ''' </summary>
        Public Sub New(teksNota As String)
            Me.New()
            _teksNota = teksNota
        End Sub

        Private Sub frmNotaPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ModUIHelper.TerapkanTemaForm(Me)
            ModUIHelper.TerapkanGayaTombol(btnCetak, ModUIHelper.TombolTipe.PrimaryMint)
            ModUIHelper.TerapkanGayaTombol(btnTutup, ModUIHelper.TombolTipe.OutlineWhite)

            txtStruk.Text = _teksNota
        End Sub

        Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
            Me.Close()
        End Sub

        Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
            Try
                Dim printDoc As New PrintDocument()
                AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage

                Using printDlg As New PrintDialog()
                    printDlg.Document = printDoc
                    If printDlg.ShowDialog(Me) = DialogResult.OK Then
                        printDoc.Print()
                        ModErrorHandler.TampilkanInfo("Dokumen nota berhasil dikirim ke printer.", "Cetak Berhasil")
                    End If
                End Using
            Catch ex As Exception
                ModErrorHandler.TampilkanError("Mencetak nota", ex)
            End Try
        End Sub

        Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
            Using fontCetak As New Font("Consolas", 10.0!, FontStyle.Regular)
                Using brushTeks As New SolidBrush(Color.Black)
                    Dim marginKiri As Single = e.MarginBounds.Left
                    Dim marginAtas As Single = e.MarginBounds.Top
                    e.Graphics.DrawString(_teksNota, fontCetak, brushTeks, marginKiri, marginAtas)
                End Using
            End Using
        End Sub

    End Class

End Namespace

