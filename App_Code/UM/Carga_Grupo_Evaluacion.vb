Imports System.Data.OracleClient

Namespace UM


    Public Class Carga_Grupo_Evaluacion
        Inherits DBObjectOracle

        Public Curso_Carga_Id As String
        Public Evaluacion_id As Integer
        Public Nombre_Evaluacion As String
        Public Fecha As Date
        Public Estrategia_Id As String
        Public Valor As Integer
        Public Tipo As String
        Public Evaluacion_Skolar As Integer

        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property


        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As Integer)

            If clavePrincipal > 0 Then
                Dim queryString As String = "SELECT * FROM " & Me.sch & ".CARGA_GRUPO_EVALUACION where EVALUACION_Skolar = :EVALUACION_Skolar"
                Dim params As OracleParameter() = {New OracleParameter("EVALUACION_Skolar", clavePrincipal)}
                Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
                If dr.Read Then

                    If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                        Me.Curso_Carga_Id = dr("CURSO_CARGA_ID")
                    Else
                        Me.Curso_Carga_Id = ""
                    End If

                    If Not Convert.IsDBNull(dr("EVALUACION_ID")) Then
                        Me.Evaluacion_id = CInt(dr("EVALUACION_ID"))
                    Else
                        Me.Evaluacion_id = 0
                    End If

                    If Not Convert.IsDBNull(dr("NOMBRE_EVALUACION")) Then
                        Me.Nombre_Evaluacion = dr("NOMBRE_EVALUACION")
                    Else
                        Me.Nombre_Evaluacion = ""
                    End If

                    If Not Convert.IsDBNull(dr("FECHA")) Then
                        Me.Fecha = CDate(dr("FECHA"))
                    Else
                        Me.Fecha = Date.Today
                    End If


                    If Not Convert.IsDBNull(dr("ESTRATEGIA_ID")) Then
                        Me.Estrategia_Id = dr("ESTRATEGIA_ID")
                    Else
                        Me.Estrategia_Id = ""
                    End If
                   
                    If Not Convert.IsDBNull(dr("VALOR")) Then
                        Me.Valor = CInt(dr("VALOR"))
                    Else
                        Me.Valor = 0
                    End If


                    If Not Convert.IsDBNull(dr("TIPO")) Then
                        Me.Tipo = dr("TIPO")
                    Else
                        Me.Tipo = "%"
                    End If


                    If Not Convert.IsDBNull(dr("EVALUACION_Skolar")) Then
                        Me.Evaluacion_Skolar = CInt(dr("EVALUACION_Skolar"))
                    Else
                        Me.Evaluacion_Skolar = 0
                    End If

                    Me.varExiste = True
                End If
                dr.Close()
            End If


        End Sub





        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO " & Me.sch & ".CARGA_GRUPO_EVALUACION (CURSO_CARGA_ID, EVALUACION_ID, " & _
     " NOMBRE_EVALUACION, FECHA, ESTRATEGIA_ID, VALOR, TIPO, EVALUACION_Skolar) VALUES (:CURSO_CARGA_ID, :EVALUACION_ID, " & _
     " :NOMBRE_EVALUACION, :FECHA, :ESTRATEGIA_ID, :VALOR, :TIPO, :EVALUACION_Skolar)"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
              New OracleParameter("EVALUACION_ID", GetNuevaEvaluacion_ID(Me.Curso_Carga_Id)), _
              New OracleParameter("NOMBRE_EVALUACION", Me.Nombre_Evaluacion), _
              New OracleParameter("FECHA", Me.Fecha), _
              New OracleParameter("ESTRATEGIA_ID", Me.Estrategia_Id), _
              New OracleParameter("VALOR", Me.Valor), _
              New OracleParameter("TIPO", Me.Tipo), _
              New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar)}

            Return Me.ExecuteNonQuery(queryString, parametros, False)

        End Function

        Public Overrides Function Update() As Integer
            Dim queryString As String = "UPDATE  " & Me.sch & ".CARGA_GRUPO_EVALUACION SET  CURSO_CARGA_ID=:CURSO_CARGA_ID, EVALUACION_ID=:EVALUACION_ID, " & _
   " NOMBRE_EVALUACION=:NOMBRE_EVALUACION, FECHA=:FECHA, ESTRATEGIA_ID=:ESTRATEGIA_ID, VALOR=:VALOR, TIPO=:TIPO WHERE  EVALUACION_Skolar=:EVALUACION_Skolar"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_id), _
              New OracleParameter("NOMBRE_EVALUACION", Me.Nombre_Evaluacion), _
              New OracleParameter("FECHA", Me.Fecha), _
              New OracleParameter("ESTRATEGIA_ID", Me.Estrategia_Id), _
              New OracleParameter("VALOR", Me.Valor), _
              New OracleParameter("TIPO", Me.Tipo), _
              New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar)}

            If Me.Evaluacion_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If

        End Function

        Public Function GetNuevaEvaluacion_ID(ByVal claveCursoCargaID As String) As Integer
            Dim sql As String = "SELECT  MAX(EVALUACION_ID) AS NUM  FROM " & Me.sch & ".CARGA_GRUPO_EVALUACION WHERE CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim parametros As OracleParameter() = { _
              New OracleParameter("CURSO_CARGA_ID", claveCursoCargaID)}
            Dim regreso As Integer = 1
            Dim dr As OracleDataReader = Me.ExecuteReader(sql, parametros)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("NUM")) Then
                    regreso = CInt(dr("NUM")) + 1
                End If
            End If
            dr.Close()

            Return regreso
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE  " & Me.sch & ".CARGA_GRUPO_EVALUACION  WHERE  EVALUACION_Skolar=:EVALUACION_Skolar"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar)}

            If Me.Evaluacion_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If

        End Function


        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function



        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing

        End Function

        Public Overloads Function GetDR(ByVal clavecarga_grupo_id As String) As System.Data.OracleClient.OracleDataReader

            Dim queryString As String = "select * from " & sch & ".CARGA_GRUPO_EVALUACION where (CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim parametros As OracleParameter() = { _
         New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing

        End Function

        Public Overloads Function GetDS(ByVal clavecarga_grupo_id As String) As System.Data.DataSet

            Dim queryString As String = "select * from " & sch & ".CARGA_GRUPO_EVALUACION where (CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim parametros As OracleParameter() = { _
         New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


    End Class
End Namespace
