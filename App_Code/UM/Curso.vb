Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient



Namespace UM

    Public Class Curso
        Inherits DBObjectLight

        Public idCurso As Integer
        Public idEmpresa As Integer
        Public clave As String
        Public claveAux As String
        Public Nombre As String
        Public FechaInicio As String
        Public FechaFin As String
        Public HoraAtencion As String
        Public grabado As Boolean

        Public Existe As Boolean = False

        '***********************************************************
        'Constructores
        '***********************************************************
        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As String)


            Dim queryString As String = "SELECT [Cursos].* FROM [Cursos] WHERE ([Cursos].[clave] = @clave)"

            Dim parameters As SqlParameter() = {New SqlParameter("@clave", clavePrincipal)}



            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idCurso = CType(dr("idCurso"), Integer)
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.clave = CType(dr("clave"), String)
                Me.claveAux = CType(dr("claveAux"), String)
                Me.Nombre = CType(dr("Nombre"), String)
                Me.FechaInicio = CType(dr("FechaInicio"), String)
                Me.FechaFin = CType(dr("FechaFin"), String)
                Me.HoraAtencion = CType(dr("HoraAtencion"), String)
                Me.grabado = CType(dr("grabado"), Boolean)

                Existe = True
            End If
            dr.Close()



        End Sub




        Public Function Add() As Integer
        

            Dim queryString As String = "INSERT INTO [Cursos] ([idEmpresa], [clave], [claveAux], [Nombre], [FechaInicio" & _
    "], [FechaFin], [HoraAtencion], [grabado]) VALUES (@idEmpresa, @clave, @claveAux, @Nombre, @FechaInicio, " & _
    " @FechaFin, @HoraAtencion, @grabado)"
            Dim parametros As SqlParameter() = { _
                New SqlParameter("@idEmpresa", Me.idEmpresa), _
                New SqlParameter("@clave", Me.clave), _
                New SqlParameter("@claveAux", Me.claveAux), _
                New SqlParameter("@Nombre", Me.Nombre), _
                New SqlParameter("@FechaInicio", Me.FechaInicio), _
                New SqlParameter("@FechaFin", Me.FechaFin), _
                New SqlParameter("@HoraAtencion", Me.HoraAtencion), _
                New SqlParameter("@grabado", Me.grabado)}



            Return Me.ExecuteNonQuery(queryString, parametros)

        End Function

        Public Function Update() As Integer

            Dim queryString As String = "UPDATE [Cursos] SET idEmpresa=@idEmpresa, clave=@clave, claveAux=@claveAux, Nombre=@Nombre, FechaInicio=@FechaInicio, FechaFin=@FechaFin, " & _
            " HoraAtencion=@HoraAtencion,  [grabado]=@grabado WHERE ([Cursos].[idCurso] = @idCurso)"
            Dim parametros As SqlParameter() = { _
                      New SqlParameter("@idCurso", Me.idCurso), _
                    New SqlParameter("@idEmpresa", Me.idEmpresa), _
                New SqlParameter("@clave", Me.clave), _
                New SqlParameter("@claveAux", Me.claveAux), _
                New SqlParameter("@Nombre", Me.Nombre), _
                New SqlParameter("@FechaInicio", Me.FechaInicio), _
                New SqlParameter("@FechaFin", Me.FechaFin), _
                New SqlParameter("@HoraAtencion", Me.HoraAtencion), _
                New SqlParameter("@grabado", Me.grabado)}

            Return Me.ExecuteNonQuery(queryString, parametros)

        End Function

        Public Function Remove() As Integer

        End Function

        Public Function Count() As Integer

        End Function


       

        Public Function GetDR(ByVal claveEmpresa As Integer, ByVal claveStatus As Boolean) As SqlDataReader


            Dim queryString As String = "SELECT [Cursos].* FROM [Cursos] WHERE idEmpresa=@idEmpresa and grabado=@grabado"
            Dim parametros As SqlParameter() = { _
                New SqlParameter("@idEmpresa", claveEmpresa), _
                New SqlParameter("@grabado", claveStatus)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function


        Public Function GrabarCursos(ByVal claveEmpresa As Integer) As Integer
            Dim numero As Integer = 0

            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveEmpresa, False)
            Dim mySalon As Know.SalonVirtual
            Dim myUserEmpresa As MasUsuarios.EmpresaUserProfile
            Dim myCurso As UM.Curso


            Do While dr.Read
                mySalon = New Know.SalonVirtual(Convert.ToString(dr("clave")), False)
                myUserEmpresa = New MasUsuarios.EmpresaUserProfile(Convert.ToString(dr("claveAux")), claveEmpresa, tipoObjeto.Maestro)

                If myUserEmpresa.existe Then
                    mySalon.claveAux1 = Convert.ToString(dr("clave"))
                    mySalon.claveAux2 = ""
                    mySalon.idUserProfile = myUserEmpresa.idUserProfile

                    If mySalon.existe Then
                        mySalon.Update()
                        grabarPermisos(myUserEmpresa.idUserProfile, mySalon.id)
                        numero = numero + 1
                    Else
                        mySalon.idRoot = 0
                        mySalon.idEmpresa = claveEmpresa
                        mySalon.nombre = Convert.ToString(dr("Nombre"))
                        mySalon.fechaInicio = Convert.ToDateTime(dr("FechaInicio"))
                        mySalon.fechaFin = Convert.ToDateTime(dr("FechaFin"))
                        mySalon.horarioAtencion = Convert.ToString(dr("horaAtencion"))
                        mySalon.calificacionMaxima = 100
                        mySalon.status = True

                        mySalon.Add()

                        If mySalon.id > 0 Then
                            numero = numero + 1
                        End If


                    End If


                    myCurso = New UM.Curso(mySalon.claveAux1)
                    myCurso.grabado = True
                    myCurso.Update()



                End If
            Loop
            dr.Close()

            Return numero
        End Function


        Function grabarPermisos(ByVal claveUsuario As Integer, ByVal claveidSalonVirtual As Integer) As Integer


            Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso

            Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(claveUsuario, False)
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(claveidSalonVirtual, False)

            myPermiso.permisoA = myUserP.tipo
            myPermiso.idPermisoA = myUserP.id
            myPermiso.recurso = mysv.tipo
            myPermiso.idRecurso = mysv.id


            myPermiso.PRoots = True
            myPermiso.PPermisosRoots = True
            myPermiso.PCategorias = True
            myPermiso.PRespuestas = True
            myPermiso.PEvaluacion = True
            myPermiso.PSalonVirtual = True
            myPermiso.PContenidos = True
            myPermiso.PInterfaceGrafica = True
            myPermiso.PEstadisticas = True
            myPermiso.PAdministracion = True
            myPermiso.Add()


            Return 1

        End Function


    End Class
End Namespace