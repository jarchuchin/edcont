Imports System.Data.OracleClient

Namespace UM



    Public Class Krdx_Alumno_Eval
        Inherits DBObjectOracle

        Public Codigo_Personal As String
        Public Curso_Carga_Id As String
        Public Evaluacion_Id As Integer
        Public Nota As Integer
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


        Sub New(ByVal clavePrincipal As Integer, ByVal claveUsuario As String, ByVal claveCurso As String)
            If clavePrincipal > 0 Then
                Dim sql As String = "SELECT * FROM " & Me.sch & ".KRDX_ALUMNO_EVAL WHERE EVALUACION_Skolar=:EVALUACION_Skolar and CODIGO_PERSONAL=:CODIGO_PERSONAL AND CURSO_CARGA_ID=:CURSO_CARGA_ID"
                Dim param As OracleParameter() = {New OracleParameter("EVALUACION_Skolar", clavePrincipal), New OracleParameter("CODIGO_PERSONAL", claveUsuario), New OracleParameter("CURSO_CARGA_ID", claveCurso)}
                Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(sql, param)
                If dr.Read Then

                    If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                        Me.Codigo_Personal = dr("CODIGO_PERSONAL")
                    Else
                        Me.Codigo_Personal = ""
                    End If

                    If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                        Me.Curso_Carga_Id = dr("CURSO_CARGA_ID")
                    Else
                        Me.Curso_Carga_Id = ""
                    End If

                    If Not Convert.IsDBNull(dr("EVALUACION_ID")) Then
                        Me.Evaluacion_Id = CInt(dr("EVALUACION_ID"))
                    Else
                        Me.Evaluacion_Id = 0
                    End If

                    If Not Convert.IsDBNull(dr("NOTA")) Then
                        Me.Nota = CInt(dr("NOTA"))
                    Else
                        Me.Nota = 0
                    End If

                    If Not Convert.IsDBNull(dr("EVALUACION_Skolar")) Then
                        Me.Evaluacion_Skolar = CInt(dr("EVALUACION_Skolar"))
                    Else
                        Me.Evaluacion_Skolar = 0
                    End If


                    varExiste = True
                End If
                dr.Close()

            End If

        End Sub


        Sub New(ByVal clavePrincipalEvaluacion_ID As Integer, ByVal claveUsuario As String, ByVal claveCurso As String, ByVal casoExtremo As Boolean)

            Dim sql As String = "SELECT * FROM " & Me.sch & ".KRDX_ALUMNO_EVAL WHERE CODIGO_PERSONAL=:CODIGO_PERSONAL AND EVALUACION_ID=:EVALUACION_ID AND CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim param As OracleParameter() = {New OracleParameter("CODIGO_PERSONAL", claveUsuario), New OracleParameter("EVALUACION_ID", clavePrincipalEvaluacion_ID), New OracleParameter("CURSO_CARGA_ID", claveCurso)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(sql, param)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.Codigo_Personal = dr("CODIGO_PERSONAL")
                Else
                    Me.Codigo_Personal = ""
                End If

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.Curso_Carga_Id = dr("CURSO_CARGA_ID")
                Else
                    Me.Curso_Carga_Id = ""
                End If

                If Not Convert.IsDBNull(dr("EVALUACION_ID")) Then
                    Me.Evaluacion_Id = CInt(dr("EVALUACION_ID"))
                Else
                    Me.Evaluacion_Id = 0
                End If

                If Not Convert.IsDBNull(dr("NOTA")) Then
                    Me.Nota = CInt(dr("NOTA"))
                Else
                    Me.Nota = 0
                End If

                If Not Convert.IsDBNull(dr("EVALUACION_Skolar")) Then
                    Me.Evaluacion_Skolar = CInt(dr("EVALUACION_Skolar"))
                Else
                    Me.Evaluacion_Skolar = 0
                End If


                varExiste = True
            End If
            dr.Close()



        End Sub

        Public Overrides Function Add() As Integer
            Dim queryString As String = "INSERT INTO " & Me.sch & ".KRDX_ALUMNO_EVAL (CODIGO_PERSONAL, EVALUACION_ID, " & _
 " CURSO_CARGA_ID, NOTA, EVALUACION_Skolar) VALUES (:CODIGO_PERSONAL, :EVALUACION_ID, " & _
 " :CURSO_CARGA_ID, :NOTA, :EVALUACION_Skolar)"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id), _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
              New OracleParameter("NOTA", Me.Nota), _
              New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar)}

            If Me.Evaluacion_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If



        End Function


        Public Overrides Function Update() As Integer


            Dim queryString As String = "UPDATE " & Me.sch & ".KRDX_ALUMNO_EVAL SET  " & _
" NOTA=:NOTA   WHERE EVALUACION_Skolar=:EVALUACION_Skolar AND  CURSO_CARGA_ID=:CURSO_CARGA_ID AND CODIGO_PERSONAL=:CODIGO_PERSONAL AND EVALUACION_ID=:EVALUACION_ID"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("NOTA", Me.Nota), _
            New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar), _
            New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
            New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id)}

            If Me.Evaluacion_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If



        End Function

        Public Function Update_Skolar() As Integer


            Dim queryString As String = "UPDATE " & Me.sch & ".KRDX_ALUMNO_EVAL SET  " & _
" NOTA=:NOTA,  EVALUACION_Skolar=:EVALUACION_Skolar   WHERE CURSO_CARGA_ID=:CURSO_CARGA_ID AND CODIGO_PERSONAL=:CODIGO_PERSONAL AND EVALUACION_ID=:EVALUACION_ID"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("NOTA", Me.Nota), _
            New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar), _
            New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
            New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id)}


            Return Me.ExecuteNonQuery(queryString, parametros, False)
          



        End Function


        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE" & Me.sch & ".KRDX_ALUMNO_EVAL WHERE EVALUACION_Skolar=:EVALUACION_Skolar AND  CURSO_CARGA_ID=:CURSO_CARGA_ID AND CODIGO_PERSONAL=:CODIGO_PERSONAL AND EVALUACION_ID=:EVALUACION_ID "

            Dim parametros As OracleParameter() = { _
                New OracleParameter("EVALUACION_Skolar", Me.Evaluacion_Skolar), _
            New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id), _
            New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id)}

            If Me.Evaluacion_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If

        End Function



        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return False
        End Function

        
        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        

    End Class


End Namespace
