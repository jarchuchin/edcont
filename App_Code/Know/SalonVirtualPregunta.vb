Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class SalonVirtualPregunta
        Inherits DBObject

#Region "Variables"
        Private idSalonVirtualPregunta As Integer
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public idMaestro As Integer
        Public Pregunta As String
        Public PreguntaFecha As DateTime
        Public Respuesta As String
        Public RespuestaFecha As DateTime
        Public Calificacion As Integer
        Public CalificacionFecha As DateTime
        Public Observacion As String
        Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualPregunta
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVirtualPregunta
            End Get
        End Property
#End Region

#Region "Constructores"
        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesPreguntas WHERE idSalonVirtualPregunta = @idSalonVirtualPregunta"
            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualPregunta", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualPregunta = CType(dr("idSalonVirtualPregunta"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.idMaestro = CType(dr("idMaestro"), Integer)
                Me.Pregunta = CType(dr("Pregunta"), String)
                Me.PreguntaFecha = CType(dr("PreguntaFecha"), DateTime)
                Me.Respuesta = CType(dr("Respuesta"), String)
                Me.RespuestaFecha = CType(dr("RespuestaFecha"), DateTime)
                Me.Calificacion = CType(dr("calificacion"), Integer)
                Me.CalificacionFecha = CType(dr("CalificacionFecha"), DateTime)
                Me.Observacion = CType(dr("Observacion"), String)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub
#End Region

#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [SalonesVirtualesPreguntas] (idSalonVirtual, idUserProfile, idMaestro, Pregunta, PreguntaFecha, Respuesta, RespuestaFecha, Calificacion, CalificacionFecha, Observacion) VALUES (@idSalonVirtual, @idUserProfile, @idMaestro, @Pregunta, @PreguntaFecha, @Respuesta, @RespuestaFecha, @Calificacion, @CalificacionFecha, @Observacion)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@idMaestro", Me.idMaestro), _
                  New SqlParameter("@Pregunta", Me.Pregunta), _
                  New SqlParameter("@PreguntaFecha", Me.PreguntaFecha), _
                  New SqlParameter("@Respuesta", Me.Respuesta), _
                  New SqlParameter("@RespuestaFecha", Me.RespuestaFecha), _
                  New SqlParameter("@Calificacion", Me.Calificacion), _
                  New SqlParameter("@CalificacionFecha", Me.CalificacionFecha), _
                  New SqlParameter("@Observacion", Me.Observacion)}

           
                Me.idSalonVirtualPregunta = Me.ExecuteNonQuery(queryString, parametros, True)
        
            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE SalonesVirtualesPreguntas SET idSalonVirtual=@idSalonVirtual, idUserProfile=@idUserProfile, idMaestro=@idMaestro, Pregunta=@Pregunta, PreguntaFecha=@PreguntaFecha, Respuesta=@Respuesta, RespuestaFecha=@RespuestaFecha, Calificacion=@Calificacion, CalificacionFecha=@CalificacionFecha, Observacion=@Observacion WHERE idSalonVirtualPregunta = @idSalonVirtualPregunta"

                Dim parametros As SqlParameter() = { _
                    New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                    New SqlParameter("@idUserProfile", Me.idUserProfile), _
                    New SqlParameter("@idMaestro", Me.idMaestro), _
                    New SqlParameter("@Pregunta", Me.Pregunta), _
                    New SqlParameter("@PreguntaFecha", Me.PreguntaFecha), _
                    New SqlParameter("@Respuesta", Me.Respuesta), _
                    New SqlParameter("@RespuestaFecha", Me.RespuestaFecha), _
                    New SqlParameter("@Calificacion", Me.Calificacion), _
                    New SqlParameter("@CalificacionFecha", Me.CalificacionFecha), _
                    New SqlParameter("@Observacion", Me.Observacion), _
                    New SqlParameter("@idSalonVirtualPregunta", Me.idSalonVirtualPregunta)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM SalonesVirtualesPreguntas WHERE idSalonVirtualPregunta = @idSalonVirtualPregunta "
            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtualPregunta", Me.idSalonVirtualPregunta)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtualesPreguntas"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT svp.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesPreguntas svp, UserProfiles u WHERE u.idUserProfile = svp.idUserProfile " & _
              "AND svp.idSalonVirtual = @idSalonVirtual and svp.idUserProfile = @idUserProfile order by svp.PreguntaFecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT svp.*, u.nombre + ' ' + u.apellidos as nombre, isnull(u.imagen, 'default.jpg') as imagen,  ux.nombre + ' ' + ux.apellidos as nombreMaestro, isnull(ux.imagen,'default.jpg') as imagenM, isnull(eux.claveAux1,'') as claveAux1M, isnull(eux.claveAux2,'') as claveAux2M,   u.login, isnull(eu.claveAux1, '') as claveAux1, isnull(eu.claveAux2,'') as claveAux2 FROM SalonesVirtualesPreguntas  as svp left outer join UserProfiles as u on u.idUserProfile = svp.idUserProfile left outer join  EmpresasUserProfiles as eu on  u.iduserprofile=eu.idUserProfile and eu.idEmpresa=4  left outer join UserProfiles ux on ux.idUserProfile = svp.idMaestro left outer join EmpresasUserProfiles  eux on svp.idMaestro=eux.idUserProfile  WHERE  svp.idSalonVirtual = @idSalonVirtual order by svp.PreguntaFecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Overloads Function GetDRSinRespuesta(ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT svp.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesPreguntas svp, UserProfiles u WHERE u.idUserProfile = svp.idUserProfile " & _
              "AND svp.idSalonVirtual = @idSalonVirtual and svp.respuesta = '' order by svp.PreguntaFecha asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtualesPreguntas"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As DataSet
            Dim queryString As String = "SELECT svp.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesPreguntas svp, UserProfiles u WHERE u.idUserProfile = svp.idUserProfile " & _
              "AND svp.idSalonVirtual = @idSalonVirtual and svp.idUserProfile = @idUserProfile order by svp.PreguntaFecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer) As DataSet
            Dim queryString As String = "SELECT svp.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesPreguntas svp, UserProfiles u WHERE u.idUserProfile = svp.idUserProfile " & _
              "AND svp.idSalonVirtual = @idSalonVirtual order by svp.PreguntaFecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function



        Public Overrides Function Count() As Integer
            Return Me.GetDS(Me.idSalonVirtual).Tables(0).Rows.Count
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

       
#End Region
    End Class
End Namespace

