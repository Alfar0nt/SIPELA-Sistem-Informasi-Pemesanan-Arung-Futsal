Option Strict On
Option Explicit On

Imports System

Public Module ModSesi

    Public Property IdUser As Integer = 0
    Public Property Username As String = String.Empty
    Public Property NamaLengkap As String = String.Empty
    Public Property Role As String = String.Empty

    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return IdUser > 0
        End Get
    End Property

    Public ReadOnly Property IsOwner As Boolean
        Get
            Return String.Equals(Role, "Owner", StringComparison.OrdinalIgnoreCase)
        End Get
    End Property

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return String.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase)
        End Get
    End Property

    Public Sub SetSesi(id As Integer, user As String, nama As String, peran As String)
        IdUser = id
        Username = user
        NamaLengkap = nama
        Role = peran
    End Sub

    Public Sub Logout()
        IdUser = 0
        Username = String.Empty
        NamaLengkap = String.Empty
        Role = String.Empty
    End Sub

End Module

