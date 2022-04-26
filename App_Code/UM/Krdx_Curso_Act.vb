Imports System.Data.OracleClient
Namespace UM
    Public Class Krdx_Curso_Act
        Inherits DBObjectOracle

        Public codigo_personal As String
        Public curso_carga_id As String
        Public tipocal_id As String

        Sub New(ByVal claveusuario As String, ByVal clavecurso As String)

            Dim sql As String = "SELECT * FROM " & Me.sch & ".KRDX_CURSO_ACT WHERE CODIGO_PERSONAL=:CODIGO_PERSONAL AND CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim param As OracleParameter() = {New OracleParameter("CODIGO_PERSONAL", claveusuario), New OracleParameter("CURSO_CARGA_ID", clavecurso)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(sql, param)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.codigo_personal = dr("CODIGO_PERSONAL")
                Else
                    Me.codigo_personal = ""
                End If

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.curso_carga_id = dr("CURSO_CARGA_ID")
                Else
                    Me.curso_carga_id = ""
                End If

                If Not Convert.IsDBNull(dr("TIPOCAL_ID")) Then
                    Me.tipocal_id = dr("TIPOCAL_ID")
                Else
                    Me.tipocal_id = ""
                End If
            End If
            dr.Close()

        End Sub

        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function

        Public Overrides ReadOnly Property existe() As Boolean
            Get

            End Get
        End Property

        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet

        End Function

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property

        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function
    End Class

End Namespace
