Imports System.IO


Partial Class Sec_Controles_DatosUserProfile
    Inherits System.Web.UI.UserControl

    Public idUserProfile As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(idUserProfile, False)
        lblNombre.Text = myuser.nombre & " " & myuser.apellidos
        Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myuser.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)


        imgAlumno.ImageUrl = getFoto(myeu.claveAux1, myeu.claveAux2)

    End Sub


    Function getFoto(ByVal claveAlumno As String, ByVal claveMaestro As String) As String


        If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveAlumno & ".jpg") Then
            Return "~/sec/Usuarios/Fotos/" & claveAlumno & ".jpg"
        Else
            If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveMaestro & ".jpg") Then
                Return "~/sec/Usuarios/Fotos/" & claveMaestro & ".jpg"
            Else
                Return "~/images/pagina/IconAlumno.jpg"
            End If

        End If

    End Function

End Class
