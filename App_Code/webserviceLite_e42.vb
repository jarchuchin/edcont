Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class webserviceLite_Skolar
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function


    <WebMethod()> _
    Public Function RegistrarUsuario(login As String, password As String, nombre As String, apellidos As String, sexo As String, fechanacimiento As DateTime) As Integer

        Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(4)
        Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(login, False)
        If Not myUser.existe Then
            myUser.login = login
            myUser.password = password
            myUser.nombre = nombre
            myUser.apellidos = apellidos
            myUser.sexo = sexo


            myUser.fechaNacimiento = fechanacimiento

            myUser.telefono = ""
            myUser.direccion = ""
            myUser.ciudad = ""
            myUser.estado = ""
            myUser.pais = 161
            myUser.email = login
            myUser.webpage = ""
            myUser.caja = 0
            myUser.idioma = "ES"
            myUser.estilo = 0
            myUser.datosPublicos = "111111111111"
            myUser.fecharegistro = Date.Now

            myUser.empresa = myEmpresa
            myUser.claveAux1 = login
            myUser.claveAux2 = ""
            myUser.Add()

        End If

        Return myUser.id

    End Function


    <WebMethod()> _
    Public Function RegistrarUsuarioCurso(login As String, cursoclave As Integer) As Integer

        Dim claveLoginUsuario As String = login

        Dim myUser As New MasUsuarios.UserProfile(claveLoginUsuario, False)
        If myUser.id > 0 Then
            Dim mysv As New Know.SalonVirtual(cursoclave, False)
            If mysv.id > 0 Then
                Dim mysvuser As New Know.SalonVirtualUserProfile(myUser.id, mysv.id, False)

                mysvuser.salonVirtual = mysv
                mysvuser.idSalonVirtual = mysv.id
                mysvuser.idUserProfile = myUser.id

                mysvuser.fechaFin = Date.Now.ToShortDateString
                mysvuser.fechaInicio = Date.Now.ToShortDateString
                mysvuser.calificacion = 0
                mysvuser.calificacionComputada = 0
                mysvuser.idUserProfileCalificador = 0
                mysvuser.puntosExtras = 0
                mysvuser.calificacionDiferida = True
                mysvuser.fechaConvenio = Date.Now.AddMonths(10)
                If Not mysvuser.existe Then



                    mysvuser.status = "I"
                    mysvuser.Add()


                    'agenda personalizada
                    Dim mya As New Comm.Agenda
                    Dim numero As Integer = mya.GrabarCalendario(mysvuser.idUserProfile, mysvuser.idSalonVirtual, Date.Now)

                End If
                Return mysvuser.id
            Else
        
                Return -1

            End If

        Else


            'Dim myu As New MasUsuarios.UserProfile
            Dim myuserum As UM.UsuariosUM = New UM.UsuariosUM(login)
            Dim clave As Integer = 0

            If myuserum.existe Then

                Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myuserum.codigo_personal, 4, tipoObjeto.Alumno)
                If Not myeu.existe Then
                    myeu = New MasUsuarios.EmpresaUserProfile(myuserum.codigo_personal, 4, tipoObjeto.Maestro)
                    If myeu.existe Then
                        clave = myeu.idUserProfile
                    End If
                Else
                    clave = myeu.idUserProfile
                End If

                ' si la clave es mayor a cero el usuario existe y se realiza inscripcion
                If clave > 0 Then
                    '####################################
                    Dim mysv As New Know.SalonVirtual(cursoclave, False)
                    If mysv.id > 0 Then
                        Dim mysvuser As New Know.SalonVirtualUserProfile(clave, mysv.id, False)

                        mysvuser.salonVirtual = mysv
                        mysvuser.idSalonVirtual = mysv.id
                        mysvuser.idUserProfile = clave

                        mysvuser.fechaFin = Date.Now.ToShortDateString
                        mysvuser.fechaInicio = Date.Now.ToShortDateString
                        mysvuser.calificacion = 0
                        mysvuser.calificacionComputada = 0
                        mysvuser.idUserProfileCalificador = 0
                        mysvuser.puntosExtras = 0
                        mysvuser.calificacionDiferida = True
                        mysvuser.fechaConvenio = Date.Now.AddMonths(12)
                        If Not mysvuser.existe Then

                            mysvuser.status = "I"
                            mysvuser.Add()

                        End If
                        Return mysvuser.id
                    Else

                        Return -1

                    End If

                Else
                    Return 0
                End If
            Else

                Return 0

            End If

            '    Return myUser.id
        End If

    End Function


    <WebMethod()> _
    Public Function AutenticarSkolar(claveLogin As String, clavePassword As String) As UsuarioSkolar

        Dim myuSkolar As New UsuarioSkolar(claveLogin, clavePassword)
        Return myuSkolar

    End Function


    <WebMethod()> _
    Public Function GetPromedioCurso(claveLogin As String, claveSalonVirtual As Integer) As Decimal

        Dim myu As New MasUsuarios.UserProfile(claveLogin, 4, "")
        Dim mysvup As New Know.SalonVirtualUserProfile(myu.id, claveSalonVirtual)


        Return CDec(mysvup.GetCalificacionGeneral(myu.id, claveSalonVirtual)) / CDec(10.0)



    End Function

End Class

Public Class UsuarioSkolar

    Public idUserProfile As Integer = 0
    Public Email As String = String.Empty
    Public Nombre As String = String.Empty
    Public Apellidos As String = String.Empty
    Public Sexo As String = String.Empty
    Public Password As String = String.Empty
    Public FechaNacimiento As Date
    Public Login As String = String.Empty
    Public Status As Integer = 1


    Sub New()

    End Sub

    Sub New(claveLogin As String, clavePassword As String)

        Dim myu As New MasUsuarios.UserProfile
        Dim myuserum As UM.UsuariosUM = New UM.UsuariosUM(claveLogin)
        If myuserum.existe Then
            Me.Status = 2
            Dim clave As Integer = myu.AutenticadoClaveUser(claveLogin, clavePassword, False)
            If clave > 0 Then
                myu = New MasUsuarios.UserProfile(clave, True)
                Me.idUserProfile = myu.id
                Me.Email = myu.email
                Me.Nombre = myu.nombre
                Me.Apellidos = myu.apellidos
                Me.Sexo = myu.sexo
                Me.Password = myu.password
                Me.FechaNacimiento = myu.fechaNacimiento
                Me.Login = myu.login
                Me.Status = 3
            End If
        Else
            Me.Status = 1
        End If




    End Sub
End Class