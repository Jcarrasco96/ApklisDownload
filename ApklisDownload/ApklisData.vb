Public Class ApklisData

    Public count As Integer
    Public results As List(Of Result)

End Class

Public Class Result

    Public version_code As String
    Public sha256 As String
    Public icon As String
    Public package_name As String
    Public size As String

End Class

Public Class URL

    Public url As String

End Class
