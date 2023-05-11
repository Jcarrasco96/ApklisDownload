Imports System.Net

Public Class FormMain

    'Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

    Private URL_DOWNLOAD As String = ""
    Private FILENAME As String = ""

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        bw.RunWorkerAsync()
    End Sub

    Private Sub DisableAll()
        btnScan.Enabled = False
        btnDownload.Enabled = False
    End Sub

    Private Sub EnableAll()
        btnScan.Enabled = True
        btnDownload.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDownload.Enabled = False
        checkDirectDownload.Checked = My.Settings.DirectDownload
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If checkDirectDownload.Checked = True Then
            Download(FILENAME)
        Else
            sfd.FileName = FILENAME
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Download(sfd.FileName)
            End If
        End If
    End Sub

    Private Sub ShowDownloadProgress(sender As Object, e As DownloadProgressChangedEventArgs)
        progressDownload.Value = e.ProgressPercentage
    End Sub

    Private Sub OnDownloadComplete(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            MessageBox.Show("Download success")
        Else
            MessageBox.Show("Download failed")
        End If

        progressDownload.Value = 0
        EnableAll()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        CheckForIllegalCrossThreadCalls = False

        DisableAll()

        Dim apklisData = ApkData(txtPackage.Text.Trim)

        If apklisData Is Nothing Then
            btnDownload.Enabled = False
            MsgBox("No existe esta aplicación.")
            Exit Sub
        End If

        If apklisData.results.Count = 0 Then
            btnDownload.Enabled = False
            MsgBox("No existe esta aplicación.")
            Exit Sub
        End If

        Dim first As Result = apklisData.results(0)

        Dim url = HttpUploadFile(first.sha256)

        If url Is Nothing Then
            btnDownload.Enabled = False
            MsgBox("No se ha podido obtener el enlace para descargar esta aplicación. Reintente de nuevo en un momento.")
            Exit Sub
        End If

        FILENAME = first.package_name & "-v" & first.version_code & ".apk"
        URL_DOWNLOAD = URL.url

        Debug.WriteLine(URL_DOWNLOAD)

        picIcon.ImageLocation = first.icon
        lblSize.Text = "Tamaño: " & first.size

        If URL_DOWNLOAD <> "" And FILENAME <> "" Then
            btnDownload.Enabled = True
        Else
            btnDownload.Enabled = False
        End If
    End Sub

    Private Sub bw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bw.ProgressChanged
        progressDownload.Value = e.ProgressPercentage
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        progressDownload.Value = 0
        EnableAll()
    End Sub

    Private Sub Download(fn As String)
        Dim client As New WebClient()
        AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
        AddHandler client.DownloadFileCompleted, AddressOf OnDownloadComplete
        client.DownloadFileAsync(New Uri(URL_DOWNLOAD), fn)

        DisableAll()
    End Sub

    Private Sub checkDirectDownload_CheckedChanged(sender As Object, e As EventArgs) Handles checkDirectDownload.CheckedChanged
        My.Settings.DirectDownload = checkDirectDownload.Checked
        My.Settings.Save()
    End Sub

End Class
