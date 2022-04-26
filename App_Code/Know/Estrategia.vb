Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know

    Public Class Estrategia
        Inherits DBObjectLight

        Public claveEstrategia As String
        Public Nombre_Estrategia As String

        Public Existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As String)
            Dim mysql As String = "select * from Estrategias where claveEstrategia=@claveEstrategia"
            Dim param As SqlParameter() = {New SqlParameter("claveEstrategia", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, param)
            If dr.Read Then
                Me.claveEstrategia = dr("claveEstrategia")
                Me.Nombre_Estrategia = dr("calveEstrategia")
            End If
            dr.Close()
        End Sub


        Public Function GetDR() As SqlDataReader
            Dim mysql As String = "select * from Estrategias order by Nombre_Estrategia"
            Return Me.ExecuteReader(mysql, Nothing)

        End Function
    End Class





End Namespace
