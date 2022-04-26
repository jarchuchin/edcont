

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class RespuestaRubrica
        Inherits DBObject


        Private idRespuestaRubrica As Integer
        Public idRespuesta As Integer
        Public idRubrica As Integer
        Public calificacion1 As Integer
        Public calificacion2 As Integer
        Public calificacion3 As Integer
        Public calificacion4 As Integer

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRespuestaRubrica
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.RespuestaRubrica
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT [RespuestasRubricas].* FROM [RespuestasRubricas] WHERE ([RespuestasRubricas].[idRespuestaRubrica] = @idRespuestaRubrica)"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRespuestaRubrica", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuestaRubrica = CType(dr("idRespuestaRubrica"), Integer)
                Me.idRespuesta = CType(dr("idRespuesta"), Integer)
                Me.idRubrica = CType(dr("idRubrica"), Integer)
                Me.calificacion1 = CType(dr("calificacion1"), Integer)
                Me.calificacion2 = CType(dr("calificacion2"), Integer)
                Me.calificacion3 = CType(dr("calificacion3"), Integer)
                Me.calificacion4 = CType(dr("calificacion4"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveRespuesta As Integer, claveRubrica As Integer)
            Dim queryString As String = "SELECT * FROM RespuestasRubricas WHERE idRespuesta=@idRespuesta and idRubrica=@idRubrica"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRespuesta", claveRespuesta), New SqlParameter("@idRubrica", claveRubrica)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuestaRubrica = CType(dr("idRespuestaRubrica"), Integer)
                Me.idRespuesta = CType(dr("idRespuesta"), Integer)
                Me.idRubrica = CType(dr("idRubrica"), Integer)
                Me.calificacion1 = CType(dr("calificacion1"), Integer)
                Me.calificacion2 = CType(dr("calificacion2"), Integer)
                Me.calificacion3 = CType(dr("calificacion3"), Integer)
                Me.calificacion4 = CType(dr("calificacion4"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


#Region "Acceso a datos"
        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [RespuestasRubricas] (idRespuesta, idRubrica, calificacion1, calificacion2, calificacion3, calificacion4) VALUES (@idRespuesta, @idRubrica, @calificacion1, @calificacion2, @calificacion3, @calificacion4)"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idRespuesta", Me.idRespuesta), _
              New SqlParameter("@idRubrica", Me.idRubrica), _
             New SqlParameter("@calificacion1", Me.calificacion1), _
             New SqlParameter("@calificacion2", Me.calificacion2), _
             New SqlParameter("@calificacion3", Me.calificacion3), _
              New SqlParameter("@calificacion4", Me.calificacion4)}

            Me.idRespuestaRubrica = Me.ExecuteNonQuery(queryString, parametros, True)

            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE RespuestasRubricas SET idRespuesta=@idRespuesta, idRubrica=@idRubrica, " & _
             "calificacion1=@calificacion1, calificacion2=@calificacion2, calificacion3=@calificacion3, calificacion4=@calificacion4 WHERE (idRespuestaRubrica = @idRespuestaRubrica)"

            Dim parametros As SqlParameter() = { _
               New SqlParameter("@idRespuesta", Me.idRespuesta), _
              New SqlParameter("@idRubrica", Me.idRubrica), _
             New SqlParameter("@calificacion1", Me.calificacion1), _
             New SqlParameter("@calificacion2", Me.calificacion2), _
             New SqlParameter("@calificacion3", Me.calificacion3), _
              New SqlParameter("@calificacion4", Me.calificacion4), _
              New SqlParameter("@idRespuestaRubrica", Me.idRespuestaRubrica)}

            Return Me.ExecuteNonQuery(queryString, parametros)





        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM [RespuestasRubricas] WHERE (idRespuestaRubrica = @idRespuestaRubrica)"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRespuestaRubrica", Me.idRespuestaRubrica)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function


        Public Overloads Function GetDR(ByVal claveRespuesta As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT * from RespuestasRubricas where idRespuesta =@idRespuesta"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRespuesta", claveRespuesta)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function


#End Region
    End Class
End Namespace
