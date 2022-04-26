Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient


Namespace UM
    Public Class Alumno
        Inherits DBObjectLight

        Public IdAlumno As Integer
        Public idEmpresa As Integer
        Public login As String
        Public clave As String
        Public nombre As String
        Public apellidos As String
        Public fechaNac As String
        Public sexo As String
        Public grabado As Boolean


        Public alumnosGrabados As Integer
        Public cursosGrabados As Integer

        Public Existe As Boolean = False

        '***********************************************************
        'Constructores
        '***********************************************************

        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[idAlumno] = @idAlumno)"
            Dim params As SqlParameter() = {New SqlParameter("@idAlumno", clavePrincipal)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, params)

            If dr.Read Then

                Me.IdAlumno = CType(dr("IdAlumno"), Integer)
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
            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[login] = @login)"
            Dim params As SqlParameter() = {New SqlParameter("@login", clavePrincipal)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, params)

            If dr.Read Then

                Me.IdAlumno = CType(dr("IdAlumno"), Integer)
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

            Dim queryString As String = "INSERT INTO [Alumnos] ([idEmpresa], [login], [clave], [nombre], [apellidos], [fechaNac" & _
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

            Dim myal As Alumno = New Alumno(Me.clave)
            If Not myal.Existe Then
                Me.IdAlumno = Me.ExecuteNonQuery(queryString, parametros, True)
            End If


            Return 1

        End Function

        Public Function Update() As Integer
            Dim queryString As String = "UPDATE [Alumnos] SET [grabado]=@grabado WHERE ([Alumnos].[idAlumno] = @idAlumno)"
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@grabado", Me.grabado), New SqlParameter("@idAlumno", Me.IdAlumno)}

            Me.ExecuteNonQuery(queryString, parametros)
            Return 1


        End Function

        Public Function Remove() As Integer

        End Function

        Public Function Count() As Integer

        End Function


        Public Function GetDR() As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] order by apellidos, nombre"


            Return Me.ExecuteReader(queryString, Nothing)

        End Function


        Public Function GetDS() As DataSet

            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] order by apellidos, nombre"
            Dim dataSet As System.Data.DataSet = Me.ExecuteDataSet(queryString, Nothing)

            Return dataSet

        End Function


        Public Function GetDR(ByVal claveEmpresa As Integer) As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[idEmpresa] = @idEmpresa) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idEmpresa", claveEmpresa)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Function GetDS(ByVal claveEmpresa As Integer) As DataSet
            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[idEmpresa] = @idEmpresa) order by apellidos, nombre"
            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idEmpresa", claveEmpresa)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GetDR(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[idEmpresa] = @idEmpresa) and ([Alumnos].grabado = @Grabado) order by apellidos, nombre"
            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@Grabado", claveGrabado)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Function GetDS(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As DataSet
            Dim queryString As String = "SELECT [Alumnos].* FROM [Alumnos] WHERE ([Alumnos].[idEmpresa] = @idEmpresa) and ([Alumnos].grabado = @Grabado) order by apellidos, nombre"
            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@Grabado", claveGrabado)}


            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GrabarUsuarios(ByVal claveEmpresa As Integer) As Integer
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveEmpresa, False)

            Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(claveEmpresa)
            Do While dr.Read

                Dim myEU As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(CType(dr("clave"), String), claveEmpresa, tipoObjeto.Alumno)
                If Not myEU.existe Then
                    ' inscribir  alumno y crear cuenta user Profile
                    Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
                    myUser.login = CType(dr("login"), String)
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
                    myUser.idioma = "ES"
                    myUser.estilo = 0
                    myUser.datosPublicos = "111111111111"
                    myUser.fecharegistro = Date.Now

                    myUser.empresa = myEmpresa
                    myUser.claveAux1 = CType(dr("clave"), String)
                    myUser.claveAux2 = ""
                    myUser.Add()
                    If myUser.id > 0 Then
                        alumnosGrabados = alumnosGrabados + 1
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

                Dim myAlumno As UM.Alumno = New UM.Alumno(CInt(dr("idAlumno")))
                myAlumno.grabado = True
                myAlumno.Update()

            Loop
            dr.Close()
            GrabarCursos(claveEmpresa)
        End Function

        Public Function GrabarCursos(ByVal claveEmpresa As Integer) As Integer
            Dim myCursoAlumno As UM.CursosAlumno = New UM.CursosAlumno
            Dim dr As SqlClient.SqlDataReader
            Dim mysv As Know.SalonVirtual
            Dim mysvuser As Know.SalonVirtualUserProfile
            Dim myeu As MasUsuarios.EmpresaUserProfile


            dr = myCursoAlumno.GetDR(False)


            Do While dr.Read
                myeu = New MasUsuarios.EmpresaUserProfile(CType(dr("claveAlumno"), String), claveEmpresa, tipoObjeto.Alumno)
                mysv = New Know.SalonVirtual(CType(dr("claveCurso"), String), False)
                If myeu.existe And mysv.existe Then
                    mysvuser = New Know.SalonVirtualUserProfile(myeu.idUserProfile, mysv.id, False)

                    mysvuser.salonVirtual = mysv
                    mysvuser.idSalonVirtual = mysv.id
                    mysvuser.idUserProfile = myeu.idUserProfile
                    mysvuser.status = "I"
                    mysvuser.fechaFin = Date.Now.ToShortDateString
                    mysvuser.fechaInicio = Date.Now.ToShortDateString
                    mysvuser.calificacion = 0
                    mysvuser.calificacionComputada = 0
                    mysvuser.idUserProfileCalificador = 0
                    mysvuser.puntosExtras = 0
                    mysvuser.calificacionDiferida = False
                    mysvuser.fechaConvenio = mysv.fechaFin
                    mysvuser.Add()
                    If mysvuser.id > 0 Then
                        cursosGrabados = cursosGrabados + 1
                        Dim myCA As UM.CursosAlumno = New UM.CursosAlumno(CInt(dr("idCursoAlumno")))
                        myCA.grabado = True
                        myCA.Update()
                    End If


                End If
            Loop
            dr.Close()


        End Function

    End Class
End Namespace