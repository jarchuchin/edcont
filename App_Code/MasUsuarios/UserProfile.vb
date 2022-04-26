Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient



Namespace MasUsuarios
	Public NotInheritable Class UserProfile
		Inherits DBObject


        Private idUserProfile As Integer
        Public login As String
        Public password As String
        Public nombre As String
        Public apellidos As String
        Public sexo As String
        Public fechaNacimiento As Date
        Public email As String
        Public telefono As String
        Public direccion As String
        Public ciudad As String
        Public estado As String
        Public pais As Integer
        Public webpage As String
        Public configuracionVisual As New MasUsuarios.ConfiguracionVisual
        Public idConfiguracionVisual As Integer
        Public fecharegistro As Date
        Public datosPublicos As String
        Public enDirectorio As Boolean
        Public emailGoogle As String = ""
        Public emailGooglePassword As String = ""

        Public imagen As String = "default.jpg"
        Public carrera As String = ""

        Public passwordUM As String = ""
        Public usuarioUM As String = ""

        'atributos para inicializacion de usuario en el sitema
        Public estilo As Integer
        Public caja As Integer
        Public idioma As String
        Public empresa As MasUsuarios.Empresa

        'espacioenDisco sacado de tabla empresaUserProfile
        'espacioEnDiscoUsado sacado de tabla Archivos
        Public espacioEnDisco As Integer
        Public espacioEnDiscoUsado As Integer

        'claveDeUsuarioEnUnaEmpresa
        Public idAux As Integer = 0
        Public claveAux1 As String = String.Empty
        Public claveAux2 As String = String.Empty

        Public confirmado As Boolean = False
        Public confirmadoCode As String = ""


        Public bloqueado As Boolean = False
        Public bloqueadoMensaje As String = ""

        Public tipoUsuario As String = ""


        Public esAdministrador As Boolean = False

        Private varExiste As Boolean = False





        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idUserProfile
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.UserProfile
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal claveUsuario As String, ByVal claveEmpresa As Integer, parametrox As String)

            Dim objEUP As New EmpresaUserProfile(claveUsuario, claveEmpresa, tipoObjeto.Alumno)
            If objEUP.existe Then
                Me.varExiste = True
            Else
                objEUP = New MasUsuarios.EmpresaUserProfile(claveUsuario, claveEmpresa, tipoObjeto.Maestro)
                Me.varExiste = objEUP.existe
            End If

            If Me.varExiste Then
                Me.idAux = objEUP.idAux
                Me.claveAux1 = objEUP.claveAux1
                Me.claveAux2 = objEUP.claveAux2
                ColocarDatos(objEUP.idUserProfile)
            End If
        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM UserProfiles WHERE idUserProfile = @idUserProfile"

            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.login = CType(dr("login"), String)
                Me.password = CType(dr("password"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.fechaNacimiento = CType(dr("fechaNacimiento"), Date)
                Me.email = CType(dr("email"), String)
                Me.telefono = CType(dr("telefono"), String)
                Me.direccion = CType(dr("direccion"), String)
                Me.ciudad = CType(dr("ciudad"), String)
                Me.estado = CType(dr("estado"), String)
                Me.pais = CType(dr("pais"), Integer)
                Me.webpage = CType(dr("webpage"), String)
                Me.idConfiguracionVisual = CType(dr("idConfiguracionVisual"), Integer)
                Me.fecharegistro = CType(dr("fecharegistro"), Date)
                Me.datosPublicos = CType(dr("datosPublicos"), String)
                Me.enDirectorio = CType(dr("endirectorio"), Boolean)
                Me.emailGoogle = CType(dr("emailGoogle"), String)
                Me.emailGooglePassword = CType(dr("emailGooglePassword"), String)

                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("carrera")) Then
                    Me.carrera = dr("carrera")
                End If

                If Not Convert.IsDBNull(dr("passwordUM")) Then
                    Me.passwordUM = dr("passwordUM")
                End If

                If Not Convert.IsDBNull(dr("usuarioUM")) Then
                    Me.usuarioUM = dr("usuarioUM")
                End If


                If Not Convert.IsDBNull(dr("confirmado")) Then
                    Me.confirmado = dr("confirmado")
                End If
                If Not Convert.IsDBNull(dr("confirmadoCode")) Then
                    Me.confirmadoCode = dr("confirmadoCode")
                End If

                If Not Convert.IsDBNull(dr("bloqueado")) Then
                    Me.bloqueado = CBool(dr("bloqueado"))
                End If

                If Not Convert.IsDBNull(dr("bloqueadoMensaje")) Then
                    Me.bloqueadoMensaje = dr("bloqueadoMensaje")
                End If

                If Not Convert.IsDBNull(dr("tipoUsuario")) Then
                    Me.tipoUsuario = dr("tipoUsuario")
                End If

                If crearSubObjetos Then
                    Me.configuracionVisual = New MasUsuarios.ConfiguracionVisual(CType(dr("idConfiguracionVisual"), Integer))
                    Dim myEmpresaUserProfile As New MasUsuarios.EmpresaUserProfile
                    Dim myContenido As Contenidos.Contenido = New Contenidos.Contenido
                    Me.espacioEnDisco = myEmpresaUserProfile.GetEspacio(Me.idUserProfile)
                    Me.espacioEnDiscoUsado = 0
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal clavePrincipal As String, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM UserProfiles WHERE login = @login"

            Dim parameters As SqlParameter() = {New SqlParameter("@login", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.login = CType(dr("login"), String)
                Me.password = CType(dr("password"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.fechaNacimiento = CType(dr("fechaNacimiento"), Date)
                Me.email = CType(dr("email"), String)
                Me.telefono = CType(dr("telefono"), String)
                Me.direccion = CType(dr("direccion"), String)
                Me.ciudad = CType(dr("ciudad"), String)
                Me.estado = CType(dr("estado"), String)
                Me.pais = CType(dr("pais"), Integer)
                Me.webpage = CType(dr("webpage"), String)
                Me.idConfiguracionVisual = CType(dr("idConfiguracionVisual"), Integer)
                Me.fecharegistro = CType(dr("fecharegistro"), Date)
                Me.datosPublicos = CType(dr("datosPublicos"), String)
                Me.enDirectorio = CType(dr("endirectorio"), Boolean)
                Me.emailGoogle = CType(dr("emailGoogle"), String)
                Me.emailGooglePassword = CType(dr("emailGooglePassword"), String)

                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("carrera")) Then
                    Me.carrera = dr("carrera")
                End If

                If Not Convert.IsDBNull(dr("passwordUM")) Then
                    Me.passwordUM = dr("passwordUM")
                End If

                If Not Convert.IsDBNull(dr("usuarioUM")) Then
                    Me.usuarioUM = dr("usuarioUM")
                End If


                If Not Convert.IsDBNull(dr("confirmado")) Then
                    Me.confirmado = dr("confirmado")
                End If
                If Not Convert.IsDBNull(dr("confirmadoCode")) Then
                    Me.confirmadoCode = dr("confirmadoCode")
                End If

                If Not Convert.IsDBNull(dr("bloqueado")) Then
                    Me.bloqueado = CBool(dr("bloqueado"))
                End If

                If Not Convert.IsDBNull(dr("bloqueadoMensaje")) Then
                    Me.bloqueadoMensaje = dr("bloqueadoMensaje")
                End If

                If Not Convert.IsDBNull(dr("tipoUsuario")) Then
                    Me.tipoUsuario = dr("tipoUsuario")
                End If

                If crearSubObjetos Then
                    Me.configuracionVisual = New MasUsuarios.ConfiguracionVisual(CType(dr("idConfiguracionVisual"), Integer))
                    Dim myEmpresaUserProfile As New MasUsuarios.EmpresaUserProfile
                    Dim myContenido As Contenidos.Contenido = New Contenidos.Contenido
                    Me.espacioEnDisco = 1000000000 'myEmpresaUserProfile.GetEspacio(Me.idUserProfile)
                    Me.espacioEnDiscoUsado = 0 'myContenido.GetEspacioUsado(Me.idUserProfile)
                End If
                Me.varExiste = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveEmail As String)
            Dim queryString As String = "SELECT * FROM UserProfiles WHERE email = @email"

            Dim parameters As SqlParameter() = {New SqlParameter("@email", claveEmail)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.login = CType(dr("login"), String)
                Me.password = CType(dr("password"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.fechaNacimiento = CType(dr("fechaNacimiento"), Date)
                Me.email = CType(dr("email"), String)
                Me.telefono = CType(dr("telefono"), String)
                Me.direccion = CType(dr("direccion"), String)
                Me.ciudad = CType(dr("ciudad"), String)
                Me.estado = CType(dr("estado"), String)
                Me.pais = CType(dr("pais"), Integer)
                Me.webpage = CType(dr("webpage"), String)
                Me.idConfiguracionVisual = CType(dr("idConfiguracionVisual"), Integer)
                Me.fecharegistro = CType(dr("fecharegistro"), Date)
                Me.datosPublicos = CType(dr("datosPublicos"), String)
                Me.enDirectorio = CType(dr("endirectorio"), Boolean)
                Me.emailGoogle = CType(dr("emailGoogle"), String)
                Me.emailGooglePassword = CType(dr("emailGooglePassword"), String)

                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("carrera")) Then
                    Me.carrera = dr("carrera")
                End If

                If Not Convert.IsDBNull(dr("passwordUM")) Then
                    Me.passwordUM = dr("passwordUM")
                End If

                If Not Convert.IsDBNull(dr("usuarioUM")) Then
                    Me.usuarioUM = dr("usuarioUM")
                End If


                If Not Convert.IsDBNull(dr("confirmado")) Then
                    Me.confirmado = dr("confirmado")
                End If
                If Not Convert.IsDBNull(dr("confirmadoCode")) Then
                    Me.confirmadoCode = dr("confirmadoCode")
                End If
                If Not Convert.IsDBNull(dr("bloqueado")) Then
                    Me.bloqueado = CBool(dr("bloqueado"))
                End If

                If Not Convert.IsDBNull(dr("bloqueadoMensaje")) Then
                    Me.bloqueadoMensaje = dr("bloqueadoMensaje")
                End If

                If Not Convert.IsDBNull(dr("tipoUsuario")) Then
                    Me.tipoUsuario = dr("tipoUsuario")
                End If

                Me.varExiste = True
            End If
            dr.Close()

        End Sub

        Public Overrides Function Add() As Integer
            '      Try
            Dim queryString As String = "INSERT INTO [UserProfiles] ([login], [password], [nombre], [apellidos], [sexo], [fechaNacimiento], [telefono], [direccion], [ciudad], [estado], [pais], [email], [webpage], [idConfiguracionVisual], [fechaRegistro], [datosPublicos], enDirectorio, emailGoogle, emailGooglePassword, imagen, carrera, confirmado, confirmadoCode, passwordUM, usuarioUM, bloqueado, bloqueadoMensaje, tipoUsuario) VALUES (@login, @password, @nombre, @apellidos, @sexo, @fechaNacimiento, @telefono, @direccion, @ciudad, @estado, @pais,  @email, @webpage, @idConfiguracionVisual, @fechaRegistro, @datosPublicos, @enDirectorio, @emailGoogle, @emailGooglePassword, @imagen, @carrera, @confirmado, @confirmadoCode, @passwordUM, @usuarioUM, @bloqueado, @bloqueadoMensaje, @tipoUsuario)"

            If Me.fechaNacimiento.Year < 1900 Then
                Me.fechaNacimiento = Date.Now
            End If
            Me.fecharegistro = Date.Now

            Dim parametros As SqlParameter() = {
              New SqlParameter("@login", Me.login),
              New SqlParameter("@password", Me.password),
              New SqlParameter("@nombre", Me.nombre),
              New SqlParameter("@apellidos", Me.apellidos),
              New SqlParameter("@sexo", Me.sexo),
              New SqlParameter("@fechaNacimiento", Me.fechaNacimiento),
              New SqlParameter("@telefono", Me.telefono),
              New SqlParameter("@direccion", Me.direccion),
              New SqlParameter("@ciudad", Me.ciudad),
              New SqlParameter("@estado", Me.estado),
              New SqlParameter("@pais", Me.pais),
              New SqlParameter("@email", Me.email),
              New SqlParameter("@webpage", Me.webpage),
              New SqlParameter("@idConfiguracionVisual", Me.idConfiguracionVisual),
              New SqlParameter("@fechaRegistro", Me.fecharegistro),
              New SqlParameter("@datosPublicos", Me.datosPublicos),
              New SqlParameter("@enDirectorio", Me.enDirectorio),
              New SqlParameter("@emailGoogle", Me.emailGoogle),
              New SqlParameter("@emailGooglePassword", Me.emailGooglePassword),
              New SqlParameter("@imagen", Me.imagen),
              New SqlParameter("@carrera", Me.carrera),
              New SqlParameter("@confirmado", Me.confirmado),
              New SqlParameter("@confirmadoCode", Me.confirmadoCode),
              New SqlParameter("@passwordUM", Me.passwordUM),
              New SqlParameter("@usuarioUM", Me.usuarioUM),
              New SqlParameter("@bloqueado", Me.bloqueado),
              New SqlParameter("@bloqueadoMensaje", Me.bloqueadoMensaje),
              New SqlParameter("@tipoUsuario", Me.tipoUsuario)}

            Me.idUserProfile = Me.ExecuteNonQuery(queryString, parametros, True)

            '*************************************************************
            'configuracion de cajilla  y asignarvalor a idconfiguracionvisual
            '*************************************************************
            'Dim myXMLIdiomas As New Utilerias.XMLIdioma(Me.idioma)

            Me.configuracionVisual.nombre = "Default"
            Me.configuracionVisual.idUserProfile = Me.idUserProfile
            Me.configuracionVisual.idioma = Me.idioma
            Me.configuracionVisual.nombre = Me.login
            Me.configuracionVisual.Add()
            Me.Update()
            '*************************************************************
            'Crear registro en empresauserprofile
            '*************************************************************
            Dim myEmpresaUserProfiles As New EmpresaUserProfile
            Dim myConfiguracion As New Configuracion(Me.empresa.id)
            myEmpresaUserProfiles.idEmpresa = Me.empresa.id
            myEmpresaUserProfiles.empresa = Me.empresa
            myEmpresaUserProfiles.userProfile = Me
            myEmpresaUserProfiles.espacioEnDisco = myConfiguracion.espacioPersonalMax
            myEmpresaUserProfiles.status = True
            myEmpresaUserProfiles.idAux = Me.idAux
            myEmpresaUserProfiles.claveAux1 = Me.claveAux1
            myEmpresaUserProfiles.claveAux2 = Me.claveAux2
            myEmpresaUserProfiles.defaultSession = True
            myEmpresaUserProfiles.Add()


            '********************************************************
            'Asigna permisos predeterminados para usuarios 
            '********************************************************
            Dim myPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso
            myPermisos.idRecurso = Me.empresa.id
            myPermisos.recurso = Me.empresa.tipo
            myPermisos.idPermisoA = Me.idUserProfile
            myPermisos.permisoA = Me.tipo
            myPermisos.PRoots = esAdministrador
            myPermisos.PPermisosRoots = esAdministrador
            myPermisos.PCategorias = esAdministrador
            myPermisos.PRespuestas = esAdministrador
            myPermisos.PEvaluacion = esAdministrador
            myPermisos.PSalonVirtual = esAdministrador
            myPermisos.PContenidos = esAdministrador
            myPermisos.PInterfaceGrafica = esAdministrador
            myPermisos.PEstadisticas = esAdministrador
            myPermisos.PAdministracion = esAdministrador
            myPermisos.Add()
            ' Catch ex As Exception
            '     Dim m As String = ex.Message
            'End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            ' Try
            Dim queryString As String = "UPDATE [UserProfiles] SET [password]=@password, [nombre]=@nombre, [apellidos]=@apellidos, [sexo]=@sexo, [fechaNacimiento]=@fechaNacimiento, [email]=@email, [telefono]=@telefono, [direccion]=@direccion, [ciudad]=@ciudad, [estado]=@estado, [pais]=@pais, [webpage]=@webpage, [idConfiguracionVisual]=@idConfiguracionVisual, [datosPublicos]=@datosPublicos, [enDirectorio]=@enDirectorio,  emailGoogle=@emailGoogle, emailGooglePassword=@emailGooglePassword, imagen=@imagen, carrera=@carrera, confirmado=@confirmado, confirmadoCode=@confirmadoCode, passwordUM=@passwordUM, usuarioUM=@usuarioUM, bloqueado=@bloqueado, bloqueadoMensaje=@bloqueadoMensaje, tipoUsuario=@tipoUsuario WHERE idUserProfile = @idUserProfile"

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idUserProfile", Me.idUserProfile),
             New SqlParameter("@password", Me.password),
             New SqlParameter("@nombre", Me.nombre),
             New SqlParameter("@apellidos", Me.apellidos),
             New SqlParameter("@sexo", Me.sexo),
             New SqlParameter("@fechaNacimiento", Me.fechaNacimiento),
             New SqlParameter("@email", Me.email),
             New SqlParameter("@telefono", Me.telefono),
             New SqlParameter("@direccion", Me.direccion),
             New SqlParameter("@ciudad", Me.ciudad),
             New SqlParameter("@estado", Me.estado),
             New SqlParameter("@pais", Me.pais),
             New SqlParameter("@webpage", Me.webpage),
             New SqlParameter("@idConfiguracionVisual", Me.idConfiguracionVisual),
             New SqlParameter("@datosPublicos", Me.datosPublicos),
             New SqlParameter("@enDirectorio", Me.enDirectorio),
             New SqlParameter("@emailGoogle", Me.emailGoogle),
             New SqlParameter("@emailGooglePassword", Me.emailGooglePassword),
              New SqlParameter("@imagen", Me.imagen),
              New SqlParameter("@carrera", Me.carrera),
              New SqlParameter("@confirmado", Me.confirmado),
              New SqlParameter("@confirmadoCode", Me.confirmadoCode),
              New SqlParameter("@passwordUM", Me.passwordUM),
              New SqlParameter("@usuarioUM", Me.usuarioUM),
              New SqlParameter("@bloqueado", Me.bloqueado),
              New SqlParameter("@bloqueadoMensaje", Me.bloqueadoMensaje),
              New SqlParameter("@tipoUsuario", Me.tipoUsuario)}

            'validacion de configuracion.. EN un UPDATE nunca debe colocarse el valor 0 en  el campo idConfiguracionVisual pues estropearia todo el negocio

            Return Me.ExecuteNonQuery(queryString, parametros)

            'Catch ex As Exception
            '    Return 0
            '  End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM UserProfiles WHERE idUserProfile = @idUserProfile"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", Me.idUserProfile)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM UserProfiles"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveEmpresa As Integer) As SqlDataReader
            Dim queryString As String = "SELECT u.idUserProfile as idUserProfile, u.apellidos + ' ' +  u.nombre + ' (' +  u.login + ')' ) as nombre " & _
              "FROM UserProfiles u, EmpresasUserProfiles eup WHERE eup.idUserProfile = u.idUserProfile AND eup.idEmpresa = @idEmpresa ORDER BY apellidos, nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveEmpresa As Integer, ByVal cadenaBusqueda As String) As SqlDataReader
            Dim queryString As String = "SELECT eu.idAux, eu.claveAux1, EU.claveAux2, (eu.EspacioEnDisco/1000000) as EspacioEnDisco, " & _
             "u.login, u.password, u.email, u.idUserProfile as idUserProfile, (u.apellidos + ' ' + u.nombre + '  (' + u.login + ')' ) as nombre  " & _
             "FROM UserProfiles u, EmpresasUserProfiles eu WHERE eu.idUserProfile = u.idUserProfile AND eu.idEmpresa = @idEmpresa " & _
             "AND (u.nombre like '%" & cadenaBusqueda & "%' OR u.login like '%" & cadenaBusqueda & "%' OR u.apellidos like '%" & cadenaBusqueda & "%') " & _
              "ORDER BY apellidos, nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM UserProfiles"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveEmpresa As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT u.idUserProfile as idUserProfile, u.apellidos + ' ' +  u.nombre + ' (' +  u.login + ')' ) as nombre " & _
              "FROM UserProfiles u, EmpresasUserProfiles eup WHERE eup.idUserProfile = u.idUserProfile AND eup.idEmpresa = @idEmpresa ORDER BY apellidos, nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveEmpresa As Integer, ByVal cadenaBusqueda As String) As System.Data.DataSet
            Dim queryString As String = "SELECT eu.idAux, eu.claveAux1, EU.claveAux2, (eu.EspacioEnDisco/1000000) as EspacioEnDisco, " &
             " u.login, u.password, u.email, u.emailGoogle, u.idUserProfile as idUserProfile, u.apellidos,  u.nombre, eu.idEmpresa   " &
             " FROM UserProfiles u, EmpresasUserProfiles eu WHERE eu.idUserProfile = u.idUserProfile AND eu.idEmpresa = @idEmpresa " &
             " AND (u.nombre like '%" & cadenaBusqueda & "%' OR u.login like '%" & cadenaBusqueda & "%' OR u.apellidos like '%" & cadenaBusqueda & "%' OR eu.claveAux1 like '%" & cadenaBusqueda & "%' OR eu.claveAux2 like '%" & cadenaBusqueda & "%' )  " &
              " ORDER BY apellidos, nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function GetDSBuscar(claveempresa As Integer, cadenaBusqueda As String) As System.Data.DataSet
            Dim sql As String = "SELECT eu.idAux, eu.claveAux1, EU.claveAux2, (eu.EspacioEnDisco/1000000) as EspacioEnDisco,  u.login, u.password, u.email, u.emailGoogle, u.idUserProfile as idUserProfile, u.apellidos,  u.nombre, eu.idEmpresa, u.tipoUsuario  FROM UserProfiles u, EmpresasUserProfiles eu WHERE eu.idUserProfile = u.idUserProfile AND eu.idEmpresa = @idEmpresa  AND u.nombre  + ' ' +  u.apellidos  + ' ' + u.login + ' ' + eu.claveaux1  + ' ' + eu.claveaux2   like '%" & cadenaBusqueda & "%'  COLLATE Modern_Spanish_CI_AI  ORDER BY u.apellidos, u.nombre"


            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveempresa)}

            Return Me.ExecuteDataSet(sql, parametros)
        End Function

        Public Function GetDSBuscarToditos(cadenaBusqueda As String) As System.Data.DataSet
            Dim sql As String = "SELECT eu.idAux, eu.claveAux1, EU.claveAux2, (eu.EspacioEnDisco/1000000) as EspacioEnDisco,  u.login, u.password, u.email, u.emailGoogle, u.idUserProfile as idUserProfile, u.apellidos,  u.nombre, eu.idEmpresa, u.tipoUsuario  FROM UserProfiles u, EmpresasUserProfiles eu WHERE eu.idUserProfile = u.idUserProfile AND  u.nombre  + ' ' +  u.apellidos  + ' ' + u.login + ' ' + eu.claveaux1  + ' ' + eu.claveaux2   like '%" & cadenaBusqueda & "%'  COLLATE Modern_Spanish_CI_AI  ORDER BY u.apellidos, u.nombre"




            Return Me.ExecuteDataSet(sql, Nothing)
        End Function


        Public Function GetDSBuscarTodos(claveempresa As Integer) As System.Data.DataSet
            Dim sql As String = "SELECT eu.idAux, eu.claveAux1, EU.claveAux2, (eu.EspacioEnDisco/1000000) as EspacioEnDisco,  u.login, u.password, u.email, u.emailGoogle, u.idUserProfile as idUserProfile, u.apellidos,  u.nombre, eu.idEmpresa, u.tipoUsuario  FROM UserProfiles u, EmpresasUserProfiles eu WHERE eu.idUserProfile = u.idUserProfile AND eu.idEmpresa = @idEmpresa  ORDER BY u.apellidos, u.nombre"


            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveempresa)}

            Return Me.ExecuteDataSet(sql, parametros)


        End Function
        Public Overrides Function Count() As Integer
            Dim queryString As String = "Select COUNT(idUserProfile) As num FROM UserProfiles"

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, Nothing)
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

        '++++++++REVISAR espacioEnDiscoUsado++++++++++++
        Sub ColocarDatos(ByVal claveUsuario As Integer)
            Dim queryString As String = "Select * FROM UserProfiles WHERE idUserProfile  = @idUserProfile"

            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idUserProfile = claveUsuario
                Me.login = CType(dr("login"), String)
                Me.password = CType(dr("password"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.fechaNacimiento = CType(dr("fechaNacimiento"), Date)
                Me.email = CType(dr("email"), String)
                Me.telefono = CType(dr("telefono"), String)
                Me.direccion = CType(dr("direccion"), String)
                Me.ciudad = CType(dr("ciudad"), String)
                Me.estado = CType(dr("estado"), String)
                Me.pais = CType(dr("pais"), Integer)
                Me.webpage = CType(dr("webpage"), String)
                Me.idConfiguracionVisual = CType(dr("idConfiguracionVisual"), Integer)
                Me.fecharegistro = CType(dr("fecharegistro"), Date)
                Me.datosPublicos = CType(dr("datosPublicos"), String)
                Me.enDirectorio = CType(dr("endirectorio"), Boolean)
                Me.emailGoogle = CType(dr("emailGoogle"), String)
                Me.emailGooglePassword = CType(dr("emailGooglePassword"), String)

                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("carrera")) Then
                    Me.carrera = dr("carrera")
                End If

                If Not Convert.IsDBNull(dr("passwordUM")) Then
                    Me.passwordUM = dr("passwordUM")
                End If

                If Not Convert.IsDBNull(dr("usuarioUM")) Then
                    Me.usuarioUM = dr("usuarioUM")
                End If


                If Not Convert.IsDBNull(dr("confirmado")) Then
                    Me.confirmado = dr("confirmado")
                End If
                If Not Convert.IsDBNull(dr("confirmadoCode")) Then
                    Me.confirmadoCode = dr("confirmadoCode")
                End If

                If Not Convert.IsDBNull(dr("bloqueadoMensaje")) Then
                    Me.bloqueadoMensaje = dr("bloqueadoMensaje")
                End If

                If Not Convert.IsDBNull(dr("tipoUsuario")) Then
                    Me.tipoUsuario = dr("tipoUsuario")
                End If

                Me.configuracionVisual = New MasUsuarios.ConfiguracionVisual(CType(dr("idConfiguracionVisual"), Integer))
                Dim myEmpresaUserProfile As New MasUsuarios.EmpresaUserProfile
                Dim myContenido As Contenidos.Contenido = New Contenidos.Contenido
                Me.espacioEnDisco = myEmpresaUserProfile.GetEspacio(Me.idUserProfile)
                Me.espacioEnDiscoUsado = 0
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Public Function AutenticadoClaveUser(ByVal claveLogin As String, ByVal clavePassword As String, ByVal validacionPersonalizada As Boolean) As Integer

            Dim regreso As Integer = 0
            '  If validacionPersonalizada Then
            ' Dim objOperador As New MiddleUS.Operador(claveLogin)


            '    If MiddleUS.Operador.validarUsuario(clavePassword) Then

            '        Dim myeu As EmpresaUserProfile = New EmpresaUserProfile(objOperador.codigoPersonal, 4, tipoObjeto.Alumno)
            '        If myeu.existe Then
            '            regreso = myeu.idUserProfile
            '        Else
            '            myeu = New EmpresaUserProfile(objOperador.codigoPersonal, claveEmpresa, tipoObjeto.Maestro)
            '            If myeu.existe Then
            '                regreso = myeu.idUserProfile
            '            End If
            '        End If
            '    End If


            'Else


            Dim myuserprofile As New MasUsuarios.UserProfile(claveLogin, True)
            If myuserprofile.password = clavePassword Then
                Return myuserprofile.id
            Else
                Return 0
            End If

            'Try
            '    Dim myuserum As UM.UsuariosUM = New UM.UsuariosUM(claveLogin)
            '    If myuserum.validarUsuario(clavePassword) Then
            '        Dim myeu As EmpresaUserProfile = New EmpresaUserProfile(myuserum.codigo_personal, 4, tipoObjeto.Alumno)
            '        If Not myeu.existe Then
            '            myeu = New EmpresaUserProfile(myuserum.codigo_personal, claveEmpresa, tipoObjeto.Maestro)
            '            If myeu.existe Then
            '                regreso = myeu.idUserProfile
            '            End If
            '        Else
            '            regreso = myeu.idUserProfile
            '        End If
            '    End If

            '    Dim myup As New MasUsuarios.UserProfile()
            'Catch ex As Exception



            'Dim myeu As EmpresaUserProfile = New EmpresaUserProfile(claveLogin, 4, tipoObjeto.Alumno)
            '   Dim usuariolocal As Integer = getUserUM(claveLogin)
            'If Not myeu.existe Then
            '    myeu = New EmpresaUserProfile(claveLogin, claveEmpresa, tipoObjeto.Maestro)
            '    If myeu.existe Then
            '        usuariolocal = myeu.idUserProfile
            '    End If
            'Else
            '    usuariolocal = myeu.idUserProfile
            'End If
            'Dim myusertemp As New MasUsuarios.UserProfile(usuariolocal, False)
            'If myusertemp.existe Then
            '    If myusertemp.passwordUM = convertirpass(clavePassword) Then
            '        regreso = usuariolocal
            '    Else
            '        regreso = -1
            '    End If
            'Else
            '    regreso = -1
            'End If


            '  End Try




            Return regreso
        End Function

        Public Function getUserUM(claveUsuarioUM As String) As Integer
            Dim sql As String = "Select * from UserProfiles where usuarioUM=@usuarioUM"
            Dim parametros As SqlParameter() = {New SqlParameter("@usuarioUM", claveUsuarioUM)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametros)

            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("usuarioUM")) Then
                    regreso = CInt(dr("idUserProfile"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function


        Public Function convertirpass(ByVal pass As String) As String
            Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bs As Byte() = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass))
            Dim result As String = Convert.ToBase64String(bs)
            Return result
        End Function

        Public Function GetUserProfilesSession() As MasUsuarios.UserProfileSession
            Dim myUserSession As New UserProfileSession
            myUserSession.idUserProfile = Me.idUserProfile
            myUserSession.login = Me.login
            myUserSession.nombre = Me.nombre & " " & Me.apellidos
            myUserSession.idioma = "es" 'Me.configuracionVisual.idioma
            myUserSession.estilo = String.Empty
            myUserSession.caja = String.Empty
            myUserSession.emailgoogle = Me.emailGoogle
            myUserSession.tipousuario = Me.tipoUsuario

            Dim myEmpresaUser As New EmpresaUserProfile(Me.idUserProfile, True)
            myUserSession.idEmpresaDefault = myEmpresaUser.empresa.id

            Dim myEmpresa As New Empresa(myEmpresaUser.empresa.id)
            If myEmpresa.existe Then
                myUserSession.header = myEmpresa.configuracion.htmlHeader
                myUserSession.footer = myEmpresa.configuracion.htmlFooter
            End If


            Return myUserSession
        End Function

        Public Function GetDSWebService(ByVal claveEmpresa As Integer, ByVal cadenaBusqueda As String) As DataSet
            Dim queryString As String = "Select eup.idAux, eup.claveAux1, eup.claveID2,  u.*  FROM UserProfiles u, EmpresasUserProfiles eup " & _
    "WHERE (eup.idUserProfile = u.idUserProfile And eup.idEmpresa = @idEmpresa) And (u.nombre Like '%" & cadenaBusqueda & "%' " & _
    "OR u.login like '%" & cadenaBusqueda & "%' OR u.apellidos like '%" & cadenaBusqueda & "%')  ORDER BY apellidos, nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Function SendMail() As Integer
            Dim cadena As String = Chr(10) _
             & "login: " & Me.login & Chr(10) _
             & "password: " & Me.password & Chr(10) _
             & "Nombre: " & Me.nombre & " " & Me.apellidos & Chr(10) _
             & "Direccion: " & Me.direccion & Chr(10) _
             & "Estado: " & Me.estado & Chr(10) _
             & "Pais: " & Me.pais & Chr(10) _
             & "Ciudad: " & Me.ciudad & Chr(10)

            Dim myEmpresaUser As New EmpresaUserProfile(Me.idUserProfile, True)
            Dim objMailer As New Comm.Mailer
            objMailer.SendMail( _
             New System.Net.Mail.MailAddress(myEmpresaUser.empresa.email), _
             New System.Net.Mail.MailAddress(Me.email), _
             myEmpresaUser.empresa.nombre, _
             cadena)

            Return 1
        End Function


	End Class
End Namespace