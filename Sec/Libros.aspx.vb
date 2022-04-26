Imports System.Globalization
Imports System.Threading
Partial Class Sec_Libros
    Inherits System.Web.UI.Page



    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
            Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myu, mye)

            MyWorkBooks1.idUserProfile = Session("gUserProfileSession").idUserProfile
            MyWorkBooks1.mostrarLigaNuevoRoot = myp.PRoots




        End If
    End Sub


End Class
