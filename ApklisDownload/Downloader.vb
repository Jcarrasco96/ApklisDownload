Imports System.IO
Imports System.Net

Public Class Downloader

    Private Const defaultSize As Long = 1048576
    Private chunk As Long = 1048576
    Private offset As Long = 0

    Function downloadFile(ByVal url As String, ByVal filename As String) As Boolean
        Dim size As Long = getSize(url)
        Dim blockSize As Integer = Convert.ToInt32(size / defaultSize)
        Dim remainder As Integer = Convert.ToInt32(size Mod defaultSize)

        If remainder > 0 Then
            blockSize += 1
        End If

        Dim fileStream As FileStream = File.Create("E:\" & filename)

        For i As Integer = 0 To blockSize - 1
            If i = blockSize - 1 Then
                chunk = remainder
            End If

            Dim req As HttpWebRequest = HttpWebRequest.Create(url)
            req.Method = WebRequestMethods.Http.Get
            req.AddRange(Convert.ToInt32(offset), Convert.ToInt32(chunk + offset))
            Dim resp As HttpWebResponse = req.GetResponse()

            Using respStream As Stream = resp.GetResponseStream
                Dim buffer(4096) As Byte
                Dim bytesRead As Integer
                Do
                    bytesRead = respStream.Read(buffer, 0, 4096)
                    If bytesRead > 0 Then fileStream.Write(buffer, 0, bytesRead)
                Loop While bytesRead > 0
            End Using

            offset += chunk + 1

            resp.Close()
            'resp.Dispose()
        Next

        fileStream.Close()

        Return True
    End Function

    Private Function getSize(ByVal url As String) As Long
        Dim req As WebRequest = WebRequest.Create(url)
        req.Method = WebRequestMethods.Http.Head
        Dim resp As WebResponse = req.GetResponse
        Return Long.Parse(resp.ContentLength)
    End Function

End Class
