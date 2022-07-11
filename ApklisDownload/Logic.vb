Module Logic

    Function ByteConv(Bytes As Double) As String
        Dim count As Integer = 0
        Dim factor As Integer = 1024
        Dim workingnum As Double = Bytes

        Dim Suffix() As String = {" Bytes", " Kb", " Mb", " Tb", " Pb", " Eb"}

        While workingnum > factor And count < Suffix.Length - 1
            workingnum = workingnum / factor                ' '
            count = count + 1
        End While

        Return workingnum.ToString("N") + Suffix(count)
    End Function

End Module
