Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace MasUsuarios
    Public NotInheritable Class Empresa
        Inherits DBObject


        Private idEmpresa As Integer
        Public nombre As String
        Public codigoGobernacion As String
        Public telefono As String
        Public direccion As String
        Public ciudad As String
        Public estado As String
        Public pais As Integer
        Public email As String
        Public webpage As String
        Public configuracion As Configuracion
        Public fecharegistro As Date
        Public mensajeUM As String = ""
        Public Bibliotecas As String = ""
        Public ImagenInicio As String = ""
        Public ImagenLogo As String = ""
        Public Video As String = ""
        Public Empotrado As String = ""

        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idEmpresa
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Empresa
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Empresas WHERE idEmpresa = @idEmpresa"

            Dim parameters As SqlParameter() = {New SqlParameter("@idEmpresa", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.nombre = CType(dr("nombre"), String)
                Me.codigoGobernacion = CType(dr("codigoGobernacion"), String)
                Me.telefono = CType(dr("telefono"), String)
                Me.direccion = CType(dr("direccion"), String)
                Me.ciudad = CType(dr("ciudad"), String)
                Me.estado = CType(dr("estado"), String)
                Me.pais = CType(dr("pais"), Integer)
                Me.email = CType(dr("email"), String)
                Me.webpage = CType(dr("webpage"), String)
                Me.fecharegistro = CType(dr("fecharegistro"), Date)
                Me.configuracion = New Configuracion(CType(dr("idEmpresa"), Integer))

                If Not Convert.IsDBNull(dr("mensajeUM")) Then
                    Me.mensajeUM = dr("mensajeUM")
                End If
                If Not Convert.IsDBNull(dr("Bibliotecas")) Then
                    Me.Bibliotecas = dr("Bibliotecas")
                End If
                If Not Convert.IsDBNull(dr("ImagenInicio")) Then
                    Me.ImagenInicio = dr("ImagenInicio")
                End If
                If Not Convert.IsDBNull(dr("ImagenLogo")) Then
                    Me.ImagenLogo = dr("ImagenLogo")
                End If
                If Not Convert.IsDBNull(dr("Video")) Then
                    Me.Video = dr("Video")
                End If
                If Not Convert.IsDBNull(dr("Empotrado")) Then
                    Me.Empotrado = dr("Empotrado")
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [Empresas] ([nombre], [codigoGobernacion], [telefono], [direccion], " &
                 "[ciudad], [estado], [pais], [email], [webpage], [fechaRegistro], mensajeUM, Bibliotecas, ImagenInicio, ImagenLogo, Video, Empotrado) VALUES (@nombre, @codigoGobernacion, " &
                 "@telefono, @direccion, @ciudad, @estado, @pais, @email, @webpage, @fechaRegistro, @mensajeUM, @Bibliotecas, @ImagenInicio, @ImagenLogo, @Video, @Empotrado)"

                Dim parametros As SqlParameter() = {
                  New SqlParameter("@nombre", Me.nombre),
                  New SqlParameter("@codigoGobernacion", Me.codigoGobernacion),
                  New SqlParameter("@telefono", Me.telefono),
                  New SqlParameter("@direccion", Me.direccion),
                  New SqlParameter("@ciudad", Me.ciudad),
                  New SqlParameter("@estado", Me.estado),
                  New SqlParameter("@pais", Me.pais),
                  New SqlParameter("@email", Me.email),
                  New SqlParameter("@webpage", Me.webpage),
                  New SqlParameter("@fechaRegistro", Me.fecharegistro),
                  New SqlParameter("@mensajeUM", Me.mensajeUM),
                  New SqlParameter("@Bibliotecas", Me.Bibliotecas),
                  New SqlParameter("@ImagenInicio", Me.ImagenInicio),
                  New SqlParameter("@ImagenLogo", Me.ImagenLogo),
                  New SqlParameter("@Video", Me.Video),
                  New SqlParameter("@Empotrado", Me.Empotrado)}

                Me.idEmpresa = Me.ExecuteNonQuery(queryString, parametros, True)

                'Seccion que agrega el registro de configuracion de la empresa. con valores default
                Me.configuracion = New MasUsuarios.Configuracion()
                Me.configuracion.idEmpresa = Me.idEmpresa
                Me.configuracion.espacioPersonalMax = 0
                Me.configuracion.espacioEmpresaMax = 0
                Me.configuracion.usuariosMax = 0
                Me.configuracion.porcentajeAprobacion = 0
                Me.configuracion.porcentajeExtra = 0
                Me.configuracion.fechaInicio = Date.Now
                Me.configuracion.fechaFin = Date.Now
                Me.configuracion.defaultUser = True
                Me.configuracion.crearBooks = True
                Me.configuracion.crearSalones = True
                Me.configuracion.buscarCursos = True
                Me.configuracion.administracion = False
                Me.configuracion.asignarPermisos = False
                Me.configuracion.asignarSalonesBooks = False
                Me.configuracion.htmlHeader = ""
                Me.configuracion.htmlFooter = ""
                Me.configuracion.Add()

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Empresas] SET [nombre]=@nombre, [codigoGobernacion]=@codigoGobernacion, " &
                 "[telefono]=@telefono, [direccion]=@direccion, [ciudad]=@ciudad, [estado]=@estado, [pais]=@pais, [email]=@email, " &
                 "[webpage]=@webpage, mensajeUM=@mensajeUM, Bibliotecas=@Bibliotecas, ImagenInicio=@ImagenInicio, ImagenLogo=@ImagenLogo, Video=@Video, Empotrado=@Empotrado WHERE ([Empresas].[idEmpresa] = @idEmpresa)"

                Dim parametros As SqlParameter() = {
                  New SqlParameter("@idEmpresa", Me.idEmpresa),
                  New SqlParameter("@nombre", Me.nombre),
                  New SqlParameter("@codigoGobernacion", Me.codigoGobernacion),
                  New SqlParameter("@telefono", Me.telefono),
                  New SqlParameter("@direccion", Me.direccion),
                  New SqlParameter("@ciudad", Me.ciudad),
                  New SqlParameter("@estado", Me.estado),
                  New SqlParameter("@pais", Me.pais),
                  New SqlParameter("@email", Me.email),
                  New SqlParameter("@webpage", Me.webpage),
                  New SqlParameter("@mensajeUM", Me.mensajeUM),
                  New SqlParameter("@Bibliotecas", Me.Bibliotecas),
                  New SqlParameter("@ImagenInicio", Me.ImagenInicio),
                  New SqlParameter("@ImagenLogo", Me.ImagenLogo),
                  New SqlParameter("@Video", Me.Video),
                  New SqlParameter("@Empotrado", Me.Empotrado)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Empresas WHERE idEmpresa = @idEmpresa"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", Me.idEmpresa)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Empresas ORDER BY nombre ASC"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Empresas ORDER BY nombre ASC"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idEmpresa) AS num FROM Empresas"

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, Nothing)
            Dim numero As Integer = 0

            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

        '+++++++++ DEPRECATED: Utilizar EnUso() ++++++++++++
        Public Function SePuedeBorrar() As Boolean
            Return False
        End Function

    End Class
End Namespace