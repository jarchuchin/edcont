Namespace Utilerias

    Public Class Conversiones



        Public Function Numeric2Bytes(ByVal b As Double) As String
            Dim bSize(8) As String
            Dim i As Integer

            bSize(0) = "B"
            bSize(1) = "KB" 'Kilobytes
            bSize(2) = "MB" 'Megabytes
            bSize(3) = "GB" 'Gigabytes
            bSize(4) = "TB" 'Terabytes
            bSize(5) = "PB" 'Petabytes
            bSize(6) = "EB" 'Exabytes
            bSize(7) = "ZB" 'Zettabytes
            bSize(8) = "YB" 'Yottabytes

            b = CDbl(b) ' Make sure var is a Double (not just variant)

            Dim regreso As String = ""
            For i = UBound(bSize) To 0 Step -1
                If b >= (1024 ^ i) Then
                    regreso = ThreeNonZeroDigits(b / (1024 ^ i)) & " " & bSize(i)
                    Exit For
                End If
            Next


            Return regreso


        End Function

        Private Function ThreeNonZeroDigits(ByVal value As Double) As String
            If value >= 100 Then
                ' No digits after the decimal.
                Return Format$(CInt(value))
            ElseIf value >= 10 Then
                ' One digit after the decimal.
                Return Format$(value, "0.0")
            Else
                ' Two digits after the decimal.
                Return Format$(value, "0.00")
            End If
        End Function

    End Class


End Namespace
