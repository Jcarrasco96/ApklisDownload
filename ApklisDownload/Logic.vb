Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Module Logic

    Function ByteConv(Bytes As Double) As String
        Dim count As Integer = 0
        Dim factor As Integer = 1024
        Dim workingnum As Double = Bytes

        Dim Suffix() As String = {" B", " kB", " MB", "GB", " TB", " PB", " EB"}

        While workingnum > factor And count < Suffix.Length - 1
            workingnum = workingnum / factor
            count = count + 1
        End While

        Return workingnum.ToString("N") + Suffix(count)
    End Function

    Public Function ApkDataGeneral(package As String) As ApklisDataGeneral
        UpdatePolicies()

        Dim client As HttpWebRequest = CType(WebRequest.Create("https://api.apklis.cu/v1/application/?package_name=" & package), HttpWebRequest)
        UpdateClient(client)

        Try
            Dim reader = New StreamReader(client.GetResponse.GetResponseStream()).ReadToEnd.ToString

            Return JsonConvert.DeserializeObject(Of ApklisDataGeneral)(reader)
        Catch ex As Exception
            MsgBox("Ocurrió un error al intentar recuperar la página web solicitada. Compruebe su conexión a Internet e inténtelo de nuevo.")
        End Try

        Return Nothing
    End Function

    Public Function ApkData(package As String) As ApklisData
        UpdatePolicies()

        Dim client As HttpWebRequest = CType(WebRequest.Create("https://api.apklis.cu/v2/release/?package_name=" & package), HttpWebRequest)
        UpdateClient(client)

        Try
            Dim reader = New StreamReader(client.GetResponse.GetResponseStream())

            Return JsonConvert.DeserializeObject(Of ApklisData)(reader.ReadToEnd().ToString)
        Catch ex As Exception
            MsgBox("Ocurrió un error al intentar recuperar la página web solicitada. Compruebe su conexión a Internet e inténtelo de nuevo.")
        End Try

        Return Nothing
    End Function

    Public Function HttpUploadFile(key As String) As URL
        UpdatePolicies()

        Dim postdata As String = "{""release"":""" & key & """}"

        Dim client As HttpWebRequest = CType(WebRequest.Create("https://api.apklis.cu/v2/release/get_url/"), HttpWebRequest)
        client.ContentLength = postdata.Length
        UpdateClient(client, "POST")

        Try
            Dim requestWriter As New StreamWriter(client.GetRequestStream())
            requestWriter.Write(postdata)
            requestWriter.Close()

            Dim reader = New StreamReader(client.GetResponse.GetResponseStream())

            Return JsonConvert.DeserializeObject(Of URL)(reader.ReadToEnd().ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Nothing
    End Function

    Public Sub UpdatePolicies()
        ServicePointManager.SecurityProtocol = 3072
        ServicePointManager.ServerCertificateValidationCallback = Function(senderX, certificate, chain, sslPolicyErrors)
                                                                      Return True
                                                                  End Function
    End Sub

    Public Sub UpdateClient(ByRef client As HttpWebRequest, Optional method As String = "GET")
        client.ContentType = "application/json; charset=utf-8"
        client.Accept = "application/json"
        client.Method = method
    End Sub

End Module
