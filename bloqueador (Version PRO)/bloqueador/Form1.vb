Option Strict On
Option Explicit On

Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.Management

Public Class Form1

    Private band As Boolean = False

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If band = False Then
            Button1.BackgroundImage = Image.FromFile(Application.StartupPath & "\pause.jpg")
            band = True
            Timer1.Start()
        Else
            Button1.BackgroundImage = Image.FromFile("play.png")
            band = False
            Timer1.Stop()
        End If
    End Sub

    Private Function ObtenerProcesos() As List(Of Process)
        Dim l As New List(Of Process)
        Dim p As Process

        For Each p In Process.GetProcesses()
            If Not p Is Nothing Then
                l.Add(p)
            End If
        Next

        Return l
    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Button1.BackgroundImage = Image.FromFile(Application.StartupPath & "\play.png")
        cmbExt.SelectedIndex = 1
    End Sub

    Private Sub cmbExt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExt.SelectedIndexChanged
        cmbExt.MaxLength = Len(cmbExt.SelectedItem)
    End Sub

    Private Sub cmbExt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbExt.TextChanged
        If cmbExt.Text = "" Then
            txtExt.Enabled = True
        Else
            txtExt.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If txtExt.Enabled = True And txtExt.Text <> "." Then
            ListBox1.Items.Add(txtExt.Text)
        ElseIf txtExt.Enabled = False And cmbExt.Text <> "" Then
            ListBox1.Items.Add(cmbExt.SelectedItem)
        End If
        cmbExt.SelectedIndex = 0
        txtExt.Text = ""

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim listaProcesos As New List(Of Process)
        listaProcesos = ObtenerProcesos()

        Dim p As Process, ext As String

        For Each p In listaProcesos
            For Each ext In ListBox1.Items
                Dim titulo As String = p.MainWindowTitle
                titulo = LCase(titulo)
                If titulo.Contains(LCase(ext)) Then
                    p.Kill()
                End If
            Next
        Next

    End Sub


End Class
