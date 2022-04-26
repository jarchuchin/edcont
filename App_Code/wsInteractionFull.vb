Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class wsInteractionFull
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function


    <WebMethod()> _
    Public Function Autenticar(login As String, password As String) As Integer


        Dim myup As New MasUsuarios.UserProfile()
        Dim regreso As Boolean = False
        Dim clave As Integer = myup.AutenticadoClaveUser(login, password, False)


        Return clave
    End Function

    <WebMethod()> _
    Public Function GetDatosSession(claveUsuario As Integer) As MasUsuarios.UserProfileSession

        Dim myup As New MasUsuarios.UserProfile(claveUsuario, False)
        Return myup.GetUserProfilesSession()
    End Function

    <WebMethod()> _
    Public Function GetMisCursos(claveUsuario As Integer) As DataSet

        Dim mySalones As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
      
        Return mySalones.GetDSSinAlumnos(claveUsuario, "I", False)
    End Function

End Class