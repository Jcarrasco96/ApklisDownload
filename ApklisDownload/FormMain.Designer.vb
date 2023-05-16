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
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.progressDownload = New System.Windows.Forms.ProgressBar()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.checkDirectDownload = New System.Windows.Forms.CheckBox()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Location = New System.Drawing.Point(162, 88)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(510, 44)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Descargar"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'txtPackage
        '
        Me.txtPackage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackage.Location = New System.Drawing.Point(162, 12)
        Me.txtPackage.Name = "txtPackage"
        Me.txtPackage.Size = New System.Drawing.Size(510, 20)
        Me.txtPackage.TabIndex = 0
        Me.txtPackage.Text = "com.jcarrasco96.frasesjoker"
        Me.txtPackage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScan.Location = New System.Drawing.Point(162, 38)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(510, 44)
        Me.btnScan.TabIndex = 1
        Me.btnScan.Text = "Escanear"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'picIcon
        '
        Me.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(12, 12)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(144, 144)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 4
        Me.picIcon.TabStop = False
        '
        'progressDownload
        '
        Me.progressDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressDownload.Location = New System.Drawing.Point(321, 139)
        Me.progressDownload.Name = "progressDownload"
        Me.progressDownload.Size = New System.Drawing.Size(351, 17)
        Me.progressDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressDownload.TabIndex = 13
        '
        'sfd
        '
        Me.sfd.DefaultExt = "apk"
        Me.sfd.Filter = "apk|*.apk"
        Me.sfd.Title = "Seleccione una ubicación para guardar la aplicación"
        '
        'bw
        '
        '
        'checkDirectDownload
        '
        Me.checkDirectDownload.AutoSize = True
        Me.checkDirectDownload.Location = New System.Drawing.Point(162, 138)
        Me.checkDirectDownload.Name = "checkDirectDownload"
        Me.checkDirectDownload.Size = New System.Drawing.Size(107, 17)
        Me.checkDirectDownload.TabIndex = 15
        Me.checkDirectDownload.Text = "Descarga directa"
        Me.checkDirectDownload.UseVisualStyleBackColor = True
        '
        'txtUrl
        '
        Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUrl.Location = New System.Drawing.Point(12, 169)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.ReadOnly = True
        Me.txtUrl.Size = New System.Drawing.Size(660, 20)
        Me.txtUrl.TabIndex = 16
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 201)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.checkDirectDownload)
        Me.Controls.Add(Me.progressDownload)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.txtPackage)
        Me.Controls.Add(Me.btnDownload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
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
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents progressDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents checkDirectDownload As System.Windows.Forms.CheckBox
    Friend WithEvents txtUrl As TextBox
End Class
