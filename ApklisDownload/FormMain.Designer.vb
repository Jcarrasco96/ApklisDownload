<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.txtPackage = New System.Windows.Forms.TextBox()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.lblApp = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.lblDev = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.progressDownload = New System.Windows.Forms.ProgressBar()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.checkDirectDownload = New System.Windows.Forms.CheckBox()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(12, 244)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(150, 44)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Descargar"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'txtPackage
        '
        Me.txtPackage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackage.Location = New System.Drawing.Point(12, 12)
        Me.txtPackage.Name = "txtPackage"
        Me.txtPackage.Size = New System.Drawing.Size(510, 20)
        Me.txtPackage.TabIndex = 0
        Me.txtPackage.Text = "com.jcarrasco96.miscuentas"
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(12, 194)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(150, 44)
        Me.btnScan.TabIndex = 1
        Me.btnScan.Text = "Escanear"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'lblApp
        '
        Me.lblApp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp.Location = New System.Drawing.Point(168, 38)
        Me.lblApp.Name = "lblApp"
        Me.lblApp.Size = New System.Drawing.Size(354, 16)
        Me.lblApp.TabIndex = 3
        Me.lblApp.Text = "Aplicacion: -"
        '
        'picIcon
        '
        Me.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(12, 38)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(150, 150)
        Me.picIcon.TabIndex = 4
        Me.picIcon.TabStop = False
        '
        'lblDev
        '
        Me.lblDev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDev.Location = New System.Drawing.Point(168, 59)
        Me.lblDev.Name = "lblDev"
        Me.lblDev.Size = New System.Drawing.Size(354, 16)
        Me.lblDev.TabIndex = 6
        Me.lblDev.Text = "Desarrollador: -"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(12, 315)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(510, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Recomendamos apoyar a los respectivos autores de las aplicaciones."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesc.Location = New System.Drawing.Point(168, 101)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(354, 208)
        Me.txtDesc.TabIndex = 10
        Me.txtDesc.TabStop = False
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrice.Location = New System.Drawing.Point(168, 80)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(174, 16)
        Me.lblPrice.TabIndex = 12
        Me.lblPrice.Text = "Precio: -"
        '
        'progressDownload
        '
        Me.progressDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressDownload.Location = New System.Drawing.Point(12, 334)
        Me.progressDownload.Name = "progressDownload"
        Me.progressDownload.Size = New System.Drawing.Size(510, 5)
        Me.progressDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressDownload.TabIndex = 13
        '
        'sfd
        '
        Me.sfd.DefaultExt = "apk"
        Me.sfd.Filter = "apk|*.apk"
        Me.sfd.Title = "Seleccione una ubicación para guardar la aplicación"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(348, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Tamaño: -"
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        '
        'checkDirectDownload
        '
        Me.checkDirectDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkDirectDownload.AutoSize = True
        Me.checkDirectDownload.Location = New System.Drawing.Point(12, 311)
        Me.checkDirectDownload.Name = "checkDirectDownload"
        Me.checkDirectDownload.Size = New System.Drawing.Size(107, 17)
        Me.checkDirectDownload.TabIndex = 15
        Me.checkDirectDownload.Text = "Descarga directa"
        Me.checkDirectDownload.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 351)
        Me.Controls.Add(Me.checkDirectDownload)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.progressDownload)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDev)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.lblApp)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.txtPackage)
        Me.Controls.Add(Me.btnDownload)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(550, 390)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ApklisDownload"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents txtPackage As System.Windows.Forms.TextBox
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents lblApp As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblDev As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents progressDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents checkDirectDownload As System.Windows.Forms.CheckBox

End Class
