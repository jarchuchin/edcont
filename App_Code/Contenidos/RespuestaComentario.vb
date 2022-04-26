

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class RespuestaComentario
        Inherits DBObject


        Private idRespuestaComentario As Integer
        Public idRespuesta As Integer
        Public idUserProfile As Integer
        Public Observacion As String
        Public fecha As DateTime
        Public eliminado As Boolean

        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRespuestaComentario

            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.RespuestaComentario
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM [RespuestasComentarios] WHERE (" &
             "[idRespuestaContenido] = @idRespuestaContenido)"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRespuestaComentario", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuestaComentario = CInt(dr("idRespuestaComentario"))
                Me.idRespuesta = CInt(dr("idRespuesta"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.Observacion = CType(dr("Observacion"), String)
                Me.fecha = CType(dr("Fecha"), DateTime)
                Me.eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub







        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [RespuestasComentarios] (idRespuesta, idUserProfile, Observacion, Fecha, Eliminado) VALUES (@idRespuesta, @idUserProfile, @Observacion, @fecha, @eliminado)"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRespuesta", Me.idRespuesta),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@Observacion", Me.Observacion),
                  New SqlParameter("@Fecha", Me.fecha),
                  New SqlParameter("@Eliminado", Me.eliminado)}



            If Me.PuedeGrabar(Me.idUserProfile) Then
                Me.idRespuestaComentario = Me.ExecuteNonQuery(queryString, parametros, True)
            End If







            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = " UPDATE [RespuestasComentarios] SET [idRespuesta] =@idRespuesta, [idUserProfile]=@idUserProfile, Observacion=@Observacion, Fecha=@Fecha, Eliminado=@Eliminado WHERE idRespuestaComentario = @idRespuestaComentario"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRespuesta", Me.idRespuesta),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@Observacion", Me.Observacion),
                  New SqlParameter("@Fecha", Me.fecha),
                  New SqlParameter("@Eliminado", Me.eliminado),
                   New SqlParameter("@idRespuestaComentario", Me.idRespuestaComentario)}


            Return Me.ExecuteNonQuery(queryString, parametros)



        End Function

        Public Overrides Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function





        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function



        Public Overloads Function GetDS(ByVal claveRespuesta As Integer) As DataSet
            Dim queryString As String = "SELECT ca.*, u.nombre + ' ' + u.apellidos as nombre FROM RespuestasComentarios ca, UserProfiles u " &
     "WHERE  u.idUserProfile=ca.idUserProfile AND ca.idRespuesta = @idRespuesta and ca.eliminado=0  order by ca.fecha desc"

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idRespuesta", claveRespuesta)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function



        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Function PuedeGrabar(claveUsuario As Integer) As Boolean
            Dim regreso As Boolean = False

            Dim sql As String = "select count(idRespuestaComentario) as num from RespuestasComentarios where idUserProfile=@idUserProfile and day(fecha) = " & Date.Now.Day & " and month(fecha) = " & Date.Now.Month & " and year(fecha) = " & Date.Now.Year

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim num As Integer = 0
            If dr.Read Then
                num = CInt(dr("num"))
            End If
            dr.close()


            If num > 40 Then
                regreso = False
            Else
                regreso = True
            End If


            Return regreso
        End Function





        Public Overrides Function EnUso() As Boolean
            Return True
        End Function






    End Class



End Namespace
