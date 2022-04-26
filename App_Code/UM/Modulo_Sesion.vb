Imports System.Data.OracleClient

Namespace UM

    Public Class Modulo_Sesion
        Inherits DBObjectOracle

        Public sesion_id As String
        Public codigo_personal As String
        Public f_inicio As DateTime
        Public f_final As DateTime
        Public ip As String
        Public finalizo As String


        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property


        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property


        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As String)
            Dim queryString As String = "SELECT * FROM " & Me.sch & ".modulo_sesion where sesion_id= :sesion_id"

            Dim params As OracleParameter() = {New OracleParameter("sesion_id", clavePrincipal)}

            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("SESION_ID")) Then
                    Me.sesion_id = dr("SESION_ID")
                Else
                    Me.sesion_id = ""
                End If
                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.codigo_personal = dr("CODIGO_PERSONAL")
                Else
                    Me.codigo_personal = ""
                End If
                If Not Convert.IsDBNull(dr("F_INICIO")) Then
                    Me.f_inicio = CType(dr("F_INICIO"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("F_FINAL")) Then
                    Me.f_final = CType(dr("F_FINAL"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("IP")) Then
                    Me.ip = dr("IP")
                Else
                    Me.ip = ""
                End If
                If Not Convert.IsDBNull(dr("FINALIZO")) Then
                    Me.finalizo = dr("FINALIZO")
                Else
                    Me.finalizo = "N"
                End If
            
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function

     

        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet

        End Function

   

        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function
    End Class

End Namespace

