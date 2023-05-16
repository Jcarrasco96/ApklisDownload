Public Class ApklisDataGeneral

    Public results As List(Of ResultGeneral)

End Class

Public Class ResultGeneral

    Public last_release As LastRelease
    Public size As Integer
    Public package_name As String

End Class

Public Class LastRelease

    Public direct_key As String
    Public version_code As String
    Public icon As String

End Class