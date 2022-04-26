Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class RespuestaArchivo
        Inherits DBObject


        Private idRespuestaArchivo As Integer
        Public idRespuesta As Integer
        Public fechaCreacion As Date
        Public nombre As String
        Public nombreOriginal As String
        Public espacio As Integer



        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRespuestaArchivo
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.RespuestaArchivo
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM RespuestasArchivos WHERE idRespuestaArchivo = @idRespuestaArchivo"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRespuestaArchivo", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuestaArchivo = CType(dr("idRespuestaArchivo"), Integer)
                Me.idRespuesta = CType(dr("idRespuesta"), Integer)
                Me.fechaCreacion = CType(dr("fechaCreacion"), Date)
                Me.nombre = CType(dr("nombre"), String)
                Me.nombreOriginal = CType(dr("nombreOriginal"), String)
                Me.espacio = CType(dr("espacio"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [RespuestasArchivos] ([idRespuesta], [fechaCreacion], nombre, nombreoriginal, espacio) " & _
                "VALUES (@idRespuesta, @fechaCreacion, @nombre, @nombreoriginal, @espacio)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idRespuesta", Me.idRespuesta), _
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion), _
                  New SqlParameter("@nombre", Me.nombre), _
                  New SqlParameter("@nombreoriginal", Me.nombreOriginal), _
                  New SqlParameter("@espacio", Me.espacio)}

                Me.idRespuestaArchivo = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Dim mysql As String = "update RespuestasArchivos set idRespuesta=@idRespuesta, nombre=@nombre, nombreOriginal=@nombreOriginal, espacio=@espacio where idRespuestaArchivo=@idRespuestaArchivo"
            Dim param As SqlParameter() = { _
            New SqlParameter("@idRespuesta", Me.idRespuesta), _
            New SqlParameter("@nombre", Me.nombre), _
            New SqlParameter("@nombreOriginal", Me.nombreOriginal), _
            New SqlParameter("@espacio", Me.espacio), _
            New SqlParameter("@idRespuestaArchivo", Me.idRespuestaArchivo)}

            Me.ExecuteNonQuery(mysql, param)



        End Function

        Public Overrides Function Remove() As Integer
            Dim mysql As String = "delete RespuestasArchivos where idRespuestaArchivo=@idRespuestaArchivo"
            Dim param As SqlParameter() = {New SqlParameter("@idRespuestaArchivo", Me.idRespuestaArchivo)}
            Return Me.ExecuteNonQuery(mysql, param)

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal claveRespuesta As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT fs.*  FROM RespuestasArchivos fs " & _
            "WHERE fs.idRespuesta = @idRespuesta order by fs.fechaCreacion asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRespuesta", claveRespuesta)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

       

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing

        End Function

        Public Overloads Function GetDS(ByVal claveRespuesta As Integer) As DataSet
            Dim queryString As String = "SELECT fs.*  FROM RespuestasArchivos fs " & _
            "WHERE fs.idRespuesta = @idRespuesta order by fs.fechaCreacion asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRespuesta", claveRespuesta)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function



        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

    End Class
End Namespace
