
Imports System.Data.OracleClient

Namespace UM
    Public Class Carga_Grupo
        Inherits DBObjectOracle

        Public Curso_Carga_Id As String
        Public Carga_Id As String
        Public Bloque_id As Integer
        Public Codigo_Personal As String
        Public Grupo As String
        Public Modalidad_id As Integer

        Public F_Inicio As Date
        Public F_Final As Date
        Public F_Entrega As Date
        Public Estado As Integer

        Public varExiste As Boolean = False


        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As String)
            Dim sql As String = "select * from " & Me.sch & ".carga_grupo where curso_carga_id=:curso_carga_id"
            Dim params As OracleParameter() = {New OracleParameter("curso_carga_id", clavePrincipal)}
            Dim dr As OracleDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.Curso_Carga_Id = dr("CURSO_CARGA_ID")
                Else
                    Me.Curso_Carga_Id = ""
                End If

                If Not Convert.IsDBNull(dr("CARGA_ID")) Then
                    Me.Carga_Id = dr("CARGA_ID")
                Else
                    Me.Carga_Id = ""
                End If

                If Not Convert.IsDBNull(dr("BLOQUE_ID")) Then
                    Me.Bloque_id = CInt(dr("BLOQUE_ID"))
                Else
                    Me.Bloque_id = 0
                End If

                If Not Convert.IsDBNull(dr("Codigo_Personal")) Then
                    Me.Codigo_Personal = dr("Codigo_Personal")
                Else
                    Me.Codigo_Personal = ""
                End If


                If Not Convert.IsDBNull(dr("Grupo")) Then
                    Me.Grupo = dr("Grupo")
                Else
                    Me.Grupo = ""
                End If

                If Not Convert.IsDBNull(dr("Modalidad_id")) Then
                    Me.Modalidad_id = CInt(dr("Modalidad_id"))
                Else
                    Me.Modalidad_id = 0
                End If

                If Not Convert.IsDBNull(dr("Estado")) Then
                    Me.Estado = CInt(dr("Estado"))
                Else
                    Me.Estado = 0
                End If

                If Not Convert.IsDBNull(dr("F_Inicio")) Then
                    Me.F_Inicio = CDate(dr("F_Inicio"))
                Else
                    Me.F_Inicio = Date.Today
                End If

                If Not Convert.IsDBNull(dr("F_Final")) Then
                    Me.F_Final = CDate(dr("F_Final"))
                Else
                    Me.F_Final = Date.Today
                End If

                If Not Convert.IsDBNull(dr("F_Entrega")) Then
                    Me.F_Entrega = CDate(dr("F_Entrega"))
                Else
                    Me.F_Entrega = Date.Today
                End If


                varExiste = True


            End If

            dr.Close()

        End Sub

        'estado 1 o estado 2 


        Public Overrides Function Add() As Integer
            Return 0
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean

        End Function

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste

            End Get
        End Property

        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property

        Public Overrides Function Remove() As Integer
            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Return 0
        End Function
    End Class
End Namespace
