Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports System.Text

Public Class FormMain

    'Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

    Private Const URL As String = "https://api.apklis.cu/v1/application/?package_name="
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

        ServicePointManager.SecurityProtocol = 3072

        Dim client As HttpWebRequest = CType(WebRequest.Create(URL & txtPackage.Text), HttpWebRequest)

        client.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.1)"
        client.ContentType = "application/json; charset=utf-8"
        client.Accept = "application/json"
        client.Method = "GET"

        Try
            Dim response As HttpWebResponse = client.GetResponse
            Dim sr As New StreamReader(response.GetResponseStream())

            Dim html As New StringBuilder()
            Dim buffer As Char()
            Dim percentage = 0

            While sr.Peek() >= 0
                ReDim buffer(1024)

                sr.Read(buffer, 0, buffer.Length)
                html.Append(buffer)

                percentage = html.Length / response.ContentLength * 100

                If percentage > 100 Then
                    percentage = 100
                End If

                bw.ReportProgress(percentage)
            End While
            bw.ReportProgress(100)

            Dim json = JsonConvert.DeserializeObject(Of ApklisResponse)(html.ToString)

            If json.results.Count <> 0 Then
                Dim first As Result = json.results(0)

                FILENAME = first.package_name & "-v" & first.last_release.version_code & ".apk"
                URL_DOWNLOAD = "https://archive.apklis.cu/application/apk/" & FILENAME & "?key=" & first.last_release.direct_key

                Debug.WriteLine(URL_DOWNLOAD)

                picIcon.ImageLocation = first.last_release.icon
                lblApp.Text = "Aplicación: " & first.name & " (" & first.package_name & ")"
                lblDev.Text = "Desarrollador: " & first.developer.fullname & " (" & first.developer.email & ")"
                lblPrice.Text = "Precio: " & first.price
                Label1.Text = "Tamaño: " & ByteConv(first.last_release.size)
                txtDesc.Text = first.description

                If first.price = 0 Then
                    MsgBox("Esta aplicación es gratis.")
                End If

                If URL_DOWNLOAD <> "" And FILENAME <> "" Then
                    btnDownload.Enabled = True
                Else
                    btnDownload.Enabled = False
                End If
            Else
                MsgBox("No existe esta aplicación.")
            End If
        Catch ex As Exception
            URL_DOWNLOAD = ""
            FILENAME = ""
            MsgBox("Ocurrió un error al intentar recuperar la página web solicitada. Compruebe su conexión a Internet e inténtelo de nuevo.")
        End Try
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
