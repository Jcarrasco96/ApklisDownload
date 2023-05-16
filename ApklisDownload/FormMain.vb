Imports System.Net

Public Class FormMain

    Private URL_DOWNLOAD As String = ""
    Private FILENAME As String = ""

    Private sw = New Stopwatch()

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
        CheckForIllegalCrossThreadCalls = False

        btnDownload.Enabled = False
        checkDirectDownload.Checked = My.Settings.DirectDownload
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If checkDirectDownload.Checked = True Then
            Download(FILENAME)
        Else
            sfd.FileName = FILENAME
            If sfd.ShowDialog = DialogResult.OK Then
                Download(sfd.FileName)
            End If
        End If

        'Process.Start(URL_DOWNLOAD)
    End Sub

    Private Sub ShowDownloadProgress(sender As Object, e As DownloadProgressChangedEventArgs)
        progressDownload.Value = e.ProgressPercentage

        Dim progress = String.Format("{0} / {1} ({2}%) @ {3}/s", ByteConv(e.BytesReceived), ByteConv(e.TotalBytesToReceive), e.ProgressPercentage, ByteConv(e.BytesReceived / sw.Elapsed.TotalSeconds))

        Text = "ApklisDownload - " & progress
    End Sub

    Private Sub OnDownloadComplete(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        progressDownload.Value = 0
        EnableAll()

        sw.Reset()
        Text = "ApklisDownload"

        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            MessageBox.Show("Download success")
        Else
            MessageBox.Show("Download failed")
        End If
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        DisableAll()

        Dim apklisDataGeneral = ApkDataGeneral(txtPackage.Text.Trim)

        If apklisDataGeneral Is Nothing Then
            btnDownload.Enabled = False
            MsgBox("No existe esta aplicación.")
            Exit Sub
        End If

        If apklisDataGeneral.results.Count = 0 Then
            btnDownload.Enabled = False
            MsgBox("No existe esta aplicación.")
            Exit Sub
        End If

        Dim first As ResultGeneral = apklisDataGeneral.results(0)

        FILENAME = first.package_name & "-v" & first.last_release.version_code & ".apk"
        URL_DOWNLOAD = "https://archive.apklis.cu/application/apk/" & FILENAME & "?key=" & first.last_release.direct_key

        'Dim apklisData = ApkData(txtPackage.Text.Trim)

        'If apklisData Is Nothing Then
        '    btnDownload.Enabled = False
        '    MsgBox("No existe esta aplicación.")
        '    Exit Sub
        'End If

        'If apklisData.results.Count = 0 Then
        '    btnDownload.Enabled = False
        '    MsgBox("No existe esta aplicación.")
        '    Exit Sub
        'End If

        'Dim url = HttpUploadFile(first.sha256)

        'If url Is Nothing Then
        '    btnDownload.Enabled = False
        '    MsgBox("No se ha podido obtener el enlace para descargar esta aplicación. Reintente de nuevo en un momento.")
        '    Exit Sub
        'End If

        'FILENAME = first.package_name & "-v" & first.version_code & ".apk"
        'URL_DOWNLOAD = URL.url

        Debug.WriteLine(URL_DOWNLOAD)

        picIcon.ImageLocation = first.last_release.icon
        btnDownload.Text = "Descargar (" & ByteConv(first.size) & ")"
        txtUrl.Text = URL_DOWNLOAD

        If URL_DOWNLOAD <> "" And FILENAME <> "" Then
            btnDownload.Enabled = True
        Else
            btnDownload.Enabled = False
        End If
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        EnableAll()
    End Sub

    Private Sub Download(fn As String)
        Dim client As New WebClient()
        AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
        AddHandler client.DownloadFileCompleted, AddressOf OnDownloadComplete

        sw.Start()

        client.DownloadFileAsync(New Uri(URL_DOWNLOAD), fn)

        DisableAll()
    End Sub

    Private Sub checkDirectDownload_CheckedChanged(sender As Object, e As EventArgs) Handles checkDirectDownload.CheckedChanged
        My.Settings.DirectDownload = checkDirectDownload.Checked
        My.Settings.Save()
    End Sub

End Class
