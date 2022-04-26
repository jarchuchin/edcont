Imports System.Data.OracleClient

Namespace UM

    Public Class Krdx_Alumno_Activ
        Inherits DBObjectOracle

        Public Codigo_Personal As String
        Public Actividad_Id As Integer
        Public Curso_Carga_ID As String
        Public Nota As Integer
        Public Actividad_Skolar As Integer

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

        Sub New(ByVal claveCodigoPersonal As String, ByVal claveActividad_Skolar As Integer, ByVal claveCursoCargaID As String)
            Dim queryString As String = "SELECT * FROM " & Me.sch & ".KRDX_ALUMNO_ACTIV where CODIGO_PERSONAL=:CODIGO_PERSONAL AND ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar AND CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim params As OracleParameter() = {New OracleParameter("CODIGO_PERSONAL", claveCodigoPersonal), _
                                               New OracleParameter("ACTIVIDAD_Skolar", claveActividad_Skolar), _
                                               New OracleParameter("CURSO_CARGA_ID", claveCursoCargaID)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.Codigo_Personal = dr("CODIGO_PERSONAL")
                Else
                    Me.Codigo_Personal = ""
                End If

                If Not Convert.IsDBNull(dr("ACTIVIDAD_ID")) Then
                    Me.Actividad_Id = dr("ACTIVIDAD_ID")
                Else
                    Me.Actividad_Id = 0
                End If

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.Curso_Carga_ID = dr("CURSO_CARGA_ID")
                Else
                    Me.Curso_Carga_ID = ""
                End If

                If Not Convert.IsDBNull(dr("NOTA")) Then
                    Me.Nota = dr("NOTA")
                Else
                    Me.Nota = 0
                End If


                If Not Convert.IsDBNull(dr("ACTIVIDAD_Skolar")) Then
                    Me.Actividad_Skolar = dr("ACTIVIDAD_Skolar")
                Else
                    Me.Actividad_Skolar = 0
                End If

                varExiste = True

            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveCodigoPersonal As String, ByVal claveACTIVIDAD_ID As Integer, ByVal claveCursoCargaID As String, ByVal casoExtremo As Boolean)
            Dim queryString As String = "SELECT * FROM " & Me.sch & ".KRDX_ALUMNO_ACTIV where CODIGO_PERSONAL=:CODIGO_PERSONAL AND ACTIVIDAD_ID=:ACTIVIDAD_ID AND CURSO_CARGA_ID=:CURSO_CARGA_ID"
            Dim params As OracleParameter() = {New OracleParameter("CODIGO_PERSONAL", claveCodigoPersonal), _
                                               New OracleParameter("ACTIVIDAD_ID", claveACTIVIDAD_ID), _
                                               New OracleParameter("CURSO_CARGA_ID", claveCursoCargaID)}
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.Codigo_Personal = dr("CODIGO_PERSONAL")
                Else
                    Me.Codigo_Personal = ""
                End If

                If Not Convert.IsDBNull(dr("ACTIVIDAD_ID")) Then
                    Me.Actividad_Id = dr("ACTIVIDAD_ID")
                Else
                    Me.Actividad_Id = 0
                End If

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.Curso_Carga_ID = dr("CURSO_CARGA_ID")
                Else
                    Me.Curso_Carga_ID = ""
                End If

                If Not Convert.IsDBNull(dr("NOTA")) Then
                    Me.Nota = dr("NOTA")
                Else
                    Me.Nota = 0
                End If


                If Not Convert.IsDBNull(dr("ACTIVIDAD_Skolar")) Then
                    Me.Actividad_Skolar = dr("ACTIVIDAD_Skolar")
                Else
                    Me.Actividad_Skolar = 0
                End If

                varExiste = True

            End If
            dr.Close()

        End Sub


        Public Overrides Function Add() As Integer
            Dim queryString As String = "INSERT INTO " & Me.sch & ".KRDX_ALUMNO_ACTIV (CODIGO_PERSONAL, ACTIVIDAD_ID, " & _
" CURSO_CARGA_ID, NOTA, ACTIVIDAD_Skolar) VALUES (:CODIGO_PERSONAL, :ACTIVIDAD_ID, " & _
" :CURSO_CARGA_ID, :NOTA, :ACTIVIDAD_Skolar)"

            Dim parametros As OracleParameter() = { _
              New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("ACTIVIDAD_ID", Me.Actividad_Id), _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_ID), _
              New OracleParameter("NOTA", Me.Nota), _
              New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar)}

            If Me.Actividad_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If

        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE " & Me.sch & ".KRDX_ALUMNO_ACTIV SET  " & _
" NOTA=:NOTA  WHERE  CODIGO_PERSONAL=:CODIGO_PERSONAL AND ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar AND CURSO_CARGA_ID=:CURSO_CARGA_ID AND ACTIVIDAD_ID=:ACTIVIDAD_ID"

            Dim parametros As OracleParameter() = { _
            New OracleParameter("NOTA", Me.Nota), _
              New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar), _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_ID), _
                New OracleParameter("ACTIVIDAD_ID", Me.Actividad_Id)}

            If Me.Actividad_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If


        End Function


        Public Function Update_Skolar() As Integer

            Dim queryString As String = "UPDATE " & Me.sch & ".KRDX_ALUMNO_ACTIV SET  " & _
" NOTA=:NOTA, ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar  WHERE  CODIGO_PERSONAL=:CODIGO_PERSONAL AND  AND CURSO_CARGA_ID=:CURSO_CARGA_ID AND ACTIVIDAD_ID=:ACTIVIDAD_ID"

            Dim parametros As OracleParameter() = { _
            New OracleParameter("NOTA", Me.Nota), _
              New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar), _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_ID), _
                New OracleParameter("ACTIVIDAD_ID", Me.Actividad_Id)}


            Return Me.ExecuteNonQuery(queryString, parametros, False)



        End Function


        Public Overrides Function Remove() As Integer

            Dim queryString As String = "DELETE " & Me.sch & ".KRDX_ALUMNO_ACTIV WHERE CODIGO_PERSONAL=:CODIGO_PERSONAL AND ACTIVIDAD_Skolar=:ACTIVIDAD_Skolar AND CURSO_CARGA_ID=:CURSO_CARGA_ID AND ACTIVIDAD_ID=:ACTIVIDAD_ID "

            Dim parametros As OracleParameter() = { _
               New OracleParameter("CODIGO_PERSONAL", Me.Codigo_Personal), _
              New OracleParameter("ACTIVIDAD_Skolar", Me.Actividad_Skolar), _
              New OracleParameter("CURSO_CARGA_ID", Me.Curso_Carga_ID), _
                New OracleParameter("ACTIVIDAD_ID", Me.Actividad_Id)}

            If Me.Actividad_Skolar > 0 Then
                Return Me.ExecuteNonQuery(queryString, parametros, False)
            Else
                Return 0
            End If

        End Function

        


        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function



        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        
     
    End Class


End Namespace
