
Partial Class Sec_DefaultDocente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargardatos()
        End If
    End Sub

    Sub cargardatos()

        If CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
            Response.Redirect("../logout.aspx")
        End If

        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myu, mye)





        MisSalonesVirtualesInstructor1.idUserProfile = Session("gUserProfileSession").idUserProfile

        ' DatosUserProfile1.idUserProfile = Session("gUserProfileSession").idUserProfile









    End Sub




End Class
