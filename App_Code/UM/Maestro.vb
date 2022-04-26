Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace UM
    Public Class Maestro
        Inherits DBObjectLight


        Public IdMaestro As Integer
        Public idEmpresa As Integer
        Public login As String
        Public clave As String
        Public nombre As String
        Public apellidos As String
        Public fechaNac As String
        Public sexo As String
        Public grabado As Boolean

        Public maestrosGrabados As Integer
        Public cursosGrabados As Integer

        Public Existe As Boolean = False

        '***********************************************************
        'Constructores
        '***********************************************************

        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As Integer)

            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[idMaestro] = @idMaestro)"
            Dim params As SqlParameter() = {New SqlParameter("@idMaestro", clavePrincipal)}


            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, params)

            If dr.Read Then
                Me.IdMaestro = CType(dr("IdMaestro"), Integer)
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.login = CType(dr("login"), String)
                Me.clave = CType(dr("clave"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.fechaNac = CType(dr("fechaNac"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.grabado = CType(dr("grabado"), Boolean)
                Existe = True
            End If

            dr.Close()

        End Sub


        Sub New(ByVal clavePrincipal As String)

            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[clave] = @clave)"
            Dim params As SqlParameter() = {New SqlParameter("@clave", clavePrincipal)}


            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, params)

            If dr.Read Then
                Me.IdMaestro = CType(dr("IdMaestro"), Integer)
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.login = CType(dr("login"), String)
                Me.clave = CType(dr("clave"), String)
                Me.nombre = CType(dr("nombre"), String)
                Me.apellidos = CType(dr("apellidos"), String)
                Me.fechaNac = CType(dr("fechaNac"), String)
                Me.sexo = CType(dr("sexo"), String)
                Me.grabado = CType(dr("grabado"), Boolean)
                Existe = True
            End If

            dr.Close()

        End Sub

      


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO [Maestros] ([idEmpresa], [login], [clave], [nombre], [apellidos], [fechaNac" & _
   "], [sexo], [grabado]) VALUES (@idEmpresa, @login, @clave, @nombre, @apellidos, @fechaNac" & _
   ", @sexo, @grabado)"
            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idEmpresa", Me.idEmpresa), _
             New SqlParameter("@login", Me.login), _
             New SqlParameter("@clave", Me.clave), _
             New SqlParameter("@nombre", Me.nombre), _
              New SqlParameter("@apellidos", Me.apellidos), _
              New SqlParameter("@fechaNac", Me.fechaNac), _
              New SqlParameter("@sexo", Me.sexo), _
              New SqlParameter("@grabado", Me.grabado)}
            Dim myma As Maestro = New Maestro(clave)
            If Not myma.Existe Then
                Me.IdMaestro = Me.ExecuteNonQuery(queryString, parametros, True)
            End If

            Return 1
        End Function

        Public Function Update() As Integer
           
            Dim queryString As String = "UPDATE [Maestros] SET [grabado]=@grabado WHERE ([Maestros].[idMaestro] = @idMaestro)"
            Dim parametros As SqlParameter() = { _
                   New SqlParameter("@idMaestro", Me.IdMaestro), _
                   New SqlParameter("@grabado", Me.grabado)}

            Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

     


        Public Function GetDR() As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] order by apellidos, nombre"
            Return Me.ExecuteReader(queryString, Nothing)

        End Function


        Public Function GetDS() As DataSet
            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] order by apellidos, nombre"
            Return Me.ExecuteDataSet(queryString, Nothing)

        End Function


        Public Function GetDR(ByVal claveEmpresa As Integer) As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[idEmpresa] = @idEmpresa) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Function GetDS(ByVal claveEmpresa As Integer) As DataSet
            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[idEmpresa] = @idEmpresa) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idEmpresa", claveEmpresa)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GetDR(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[idEmpresa] = @idEmpresa) and ([Maestros].grabado = @Grabado) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idEmpresa", claveEmpresa), _
                  New SqlParameter("@Grabado", claveGrabado)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Function GetDS(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As DataSet
            Dim queryString As String = "SELECT [Maestros].* FROM [Maestros] WHERE ([Maestros].[idEmpresa] = @idEmpresa) and ([Maestros].grabado = @Grabado) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idEmpresa", claveEmpresa), _
                  New SqlParameter("@Grabado", claveGrabado)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GrabarMaestros(ByVal claveEmpresa As Integer) As Integer
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveEmpresa, False)

            Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(claveEmpresa)
            Do While dr.Read


                Dim myEU As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(CType(dr("clave"), String), claveEmpresa, tipoObjeto.Maestro)
                If Not myEU.existe Then

                    ' inscribir  alumno y crear cuenta user Profile
                    Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
                    myUser.login = CType(dr("clave"), String)
                    myUser.password = CType(dr("login"), String)
                    myUser.nombre = CType(dr("nombre"), String)
                    myUser.apellidos = CType(dr("apellidos"), String)
                    myUser.sexo = CType(dr("sexo"), String)

                    If IsDate(dr("fechaNac")) Then
                        Dim fechanac As Date = CType(dr("fechaNac"), Date)
                        If fechanac.Year < 1900 Then
                            myUser.fechaNacimiento = Date.Now
                        Else
                            myUser.fechaNacimiento = CType(dr("fechaNac"), Date)
                        End If

                    Else
                        myUser.fechaNacimiento = Date.Now
                    End If
                    myUser.telefono = ""
                    myUser.direccion = ""
                    myUser.ciudad = ""
                    myUser.estado = ""
                    myUser.pais = 161
                    myUser.email = ""
                    myUser.webpage = ""
                    myUser.caja = 0
                    myUser.idioma = "es"
                    myUser.estilo = 0
                    myUser.datosPublicos = "111111111111"
                    myUser.fecharegistro = Date.Now

                    myUser.empresa = myEmpresa
                    myUser.claveAux1 = CType(dr("clave"), String)
                    myUser.claveAux2 = ""
                    myUser.Add()

                    If myUser.id > 0 Then
                        maestrosGrabados = maestrosGrabados + 1
                    End If
                Else
                    Dim myup As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myEU.idUserProfile, False)
                    Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myup, myEmpresa)
                    If Not myp.existe Then
                        '********************************************************
                        'Asigna permisos predeterminados para usuarios 
                        '********************************************************
                        Dim myPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso
                        myPermisos.idRecurso = myEmpresa.id
                        myPermisos.recurso = myEmpresa.tipo
                        myPermisos.idPermisoA = myup.id
                        myPermisos.permisoA = myup.tipo
                        myPermisos.PRoots = False
                        myPermisos.PPermisosRoots = False
                        myPermisos.PCategorias = False
                        myPermisos.PRespuestas = False
                        myPermisos.PEvaluacion = False
                        myPermisos.PSalonVirtual = False
                        myPermisos.PContenidos = False
                        myPermisos.PInterfaceGrafica = False
                        myPermisos.PEstadisticas = False
                        myPermisos.PAdministracion = False
                        myPermisos.Add()
                    End If

                End If

                Dim mymaestro As UM.Maestro = New UM.Maestro(CType(dr("idMaestro"), String))
                mymaestro.grabado = True
                mymaestro.Update()

            Loop

            dr.Close()
            cursosGrabados = GrabarCursos(myEmpresa.id)
        End Function

        Private Function GrabarCursos(ByVal claveEmpresa As Integer) As Integer
            Dim myCurso As UM.Curso = New UM.Curso
            Return myCurso.GrabarCursos(claveEmpresa)


        End Function

    End Class
End Namespace