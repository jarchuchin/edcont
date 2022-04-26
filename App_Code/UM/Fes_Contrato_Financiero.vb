Imports System.Data.OracleClient
Namespace UM
    Public Class Fes_Contrato_Financiero
        Inherits DBObjectOracleFinanciero

        Public matricula As String
        Public fecha_vencimiento As Date
        Public importe As Decimal
        Public liquidado As String

        Public existedato As Boolean = False

        Sub New(ByVal clavematricula As String, ByVal clavefechavencimiento As Date)

            Dim sql As String = "SELECT * FROM " & Me.sch & ".FES_CONTRATO_FINANCIERO WHERE MATRICULA=:MATRICULA  AND FECHA_VENCIMIENTO<:FECHA_VENCIMIENTO AND LIQUIDADO='N' "
            Dim param As OracleParameter() = {New OracleParameter("MATRICULA", clavematricula), New OracleParameter("FECHA_VENCIMIENTO", clavefechavencimiento)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(sql, param)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("MATRICULA")) Then
                    Me.matricula = dr("MATRICULA")
                Else
                    Me.matricula = ""
                End If

                If Not Convert.IsDBNull(dr("FECHA_VENCIMIENTO")) Then
                    Me.fecha_vencimiento = CDate(dr("FECHA_VENCIMIENTO"))
                Else
                    Me.fecha_vencimiento = ""
                End If

                If Not Convert.IsDBNull(dr("IMPORTE")) Then
                    Me.importe = CDec(dr("IMPORTE"))
                Else
                    Me.importe = ""
                End If

                If Not Convert.IsDBNull(dr("LIQUIDADO")) Then
                    Me.liquidado = dr("LIQUIDADO")
                Else
                    Me.liquidado = ""
                End If
                existedato = True

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
