Imports System.Data.OracleClient

Namespace UM

    Public Class Carga_Grupo_Actividad
        Inherits DBObjectOracle

        Private Actividad_Id As Integer
        Public Curso_Carga_Id As String
        Public Evaluacion_Id As Integer
        Public Nombre As String
        Public Valor As Integer
        Public Actividad_Skolar As Integer
        Public Agendada_Skolar As String = "N"
        Public Fecha As Date

        Public varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.Actividad_Id
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property


        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal claveCurso_carga_id As String)

            Dim queryString As String = "SELECT * FROM " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD where ACTIVIDAD_ID = :ACTIVIDAD_ID and CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim params As OracleParameter() = {New OracleParameter("ACTIVIDAD_ID", clavePrincipal), New OracleParameter("CURSO_CARGA_ID", claveCurso_carga_id)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("ACTIVIDAD_ID")) Then
                    Me.Actividad_Id = CInt(dr("ACTIVIDAD_ID"))
                Else
                    Me.Actividad_Id = 0
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

                If Not Convert.IsDBNull(dr("NOMBRE")) Then
                    Me.Nombre = dr("NOMBRE")
                Else
                    Me.Nombre = ""
                End If

                If Not Convert.IsDBNull(dr("VALOR")) Then
                    Me.Valor = CInt(dr("VALOR"))
                Else
                    Me.Valor = 0
                End If

                If Not Convert.IsDBNull(dr("ACTIVIDAD_Skolar")) Then
                    Me.Actividad_Skolar = CInt(dr("ACTIVIDAD_Skolar"))
                Else
                    Me.Actividad_Skolar = 0
                End If

                If Not Convert.IsDBNull(dr("AGENDADA_Skolar")) Then
                    Me.Agendada_Skolar = dr("AGENDADA_Skolar")
                Else
                    Me.Agendada_Skolar = 0
                End If

                If Not Convert.IsDBNull(dr("FECHA")) Then
                    Me.Fecha = CDate(dr("FECHA"))
                Else
                    Me.Fecha = Date.Today
                End If
                varExiste = True

            End If
            dr.Close()


        End Sub
        Sub New(ByVal clavePrincipalSkolar As Integer)
            If clavePrincipalSkolar > 0 Then
                Dim queryString As String = "SELECT * FROM " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD where ACTIVIDAD_Skolar = :ACTIVIDAD_Skolar"
                Dim params As OracleParameter() = {New OracleParameter("ACTIVIDAD_Skolar", clavePrincipalSkolar)}
                Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
                If dr.Read Then

                    If Not Convert.IsDBNull(dr("ACTIVIDAD_ID")) Then
                        Me.Actividad_Id = dr("ACTIVIDAD_ID")
                    Else
                        Me.Actividad_Id = 0
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

                    If Not Convert.IsDBNull(dr("NOMBRE")) Then
                        Me.Nombre = dr("NOMBRE")
                    Else
                        Me.Nombre = ""
                    End If

                    If Not Convert.IsDBNull(dr("VALOR")) Then
                        Me.Valor = CInt(dr("VALOR"))
                    Else
                        Me.Valor = 0
                    End If

                    If Not Convert.IsDBNull(dr("ACTIVIDAD_Skolar")) Then
                        Me.Actividad_Skolar = CInt(dr("ACTIVIDAD_Skolar"))
                    Else
                        Me.Actividad_Skolar = 0
                    End If

                    If Not Convert.IsDBNull(dr("AGENDADA_Skolar")) Then
                        Me.Agendada_Skolar = dr("AGENDADA_Skolar")
                    Else
                        Me.Agendada_Skolar = 0
                    End If

                    If Not Convert.IsDBNull(dr("FECHA")) Then
                        Me.Fecha = CDate(dr("FECHA"))
                    Else
                        Me.Fecha = Date.Today
                    End If
                    varExiste = True


                End If
                dr.Close()

            End If

        End Sub

        Public Overrides Function Add() As Integer
            Dim queryString As String = "INSERT INTO " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD (ACTIVIDAD_ID, CURSO_CARGA_ID, EVALUACION_ID, " &
   " NOMBRE, VALOR, ACTIVIDAD_Skolar, AGENDADA_Skolar, FECHA) VALUES (:ACTIVIDAD_ID, :CURSO_CARGA_ID, :EVALUACION_ID, " &
   " :NOMBRE, :VALOR, :ACTIVIDAD_Skolar, :AGENDADA_Skolar, :FECHA)"

            Dim parametros As OracleParameter() = {
            New OracleParameter("ACTIVIDAD_ID", Me.GetNuevaActividad_ID()),
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id),
              New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id),
              New OracleParameter("NOMBRE", Me.Nombre),
              New OracleParameter("VALOR", Me.Valor),
              New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar),
              New OracleParameter("AGENDADA_Skolar", Me.Agendada_Skolar),
              New OracleParameter("FECHA", Me.Fecha)}

            Return Me.ExecuteNonQuery(queryString, parametros, False)
        End Function

        Public Overrides Function Update() As Integer
            Dim queryString As String = "UPDATE  " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD SET CURSO_CARGA_ID=:CURSO_CARGA_ID, EVALUACION_ID=:EVALUACION_ID, " &
   "NOMBRE=:NOMBRE, VALOR=:VALOR, AGENDADA_Skolar=:AGENDADA_Skolar, FECHA=:FECHA  WHERE  ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar"

            Dim parametros As OracleParameter() = {
                 New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_Id),
                 New OracleParameter("EVALUACION_ID", Me.Evaluacion_Id),
                 New OracleParameter("NOMBRE", Me.Nombre),
                 New OracleParameter("VALOR", Me.Valor),
                New OracleParameter("FECHA", Me.Fecha),
              New OracleParameter("AGENDADA_Skolar", Me.Agendada_Skolar),
                New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar)}

            If Me.Actividad_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If


        End Function

        Public Overrides Function Remove() As Integer

            Dim queryString As String = "delete " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD  WHERE  ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar"

            Dim parametros As OracleParameter() = {
                New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar)}

            If Me.Actividad_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If


        End Function


        Public Overrides Function EnUso() As Boolean
            Return False
        End Function
        Public Overrides Function Count() As Integer
            Return 0
        End Function


        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing

        End Function


        Public Function GetNuevaActividad_ID() As Integer
            Dim sql As String = "SELECT  MAX(ACTIVIDAD_ID) AS NUM FROM " & Me.sch & ".CARGA_GRUPO_ACTIVIDAD"

            Dim regreso As Integer = 1
            Dim dr As OracleDataReader = Me.ExecuteReader(sql, Nothing)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("NUM")) Then
                    regreso = CInt(dr("NUM")) + 1
                End If
            End If
            dr.Close()

            Return regreso
        End Function



    End Class


End Namespace
