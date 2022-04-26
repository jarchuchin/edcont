Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Default
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        autorizacion()

        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        If Request("idRoot") <> "" Then


            DesplegarBotonesIdiomas()

        End If
    End Sub


    Sub DesplegarBotonesIdiomas()

        Dim myr As New Lego.Root(CInt(Request("idRoot")))

        Page.Title = myr.titulo
        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & myr.id & "&idIdioma=" & Request("idIdioma")

        Dim myi As New Utilerias.Idioma(myr.idIdioma)
        lnkIdiomaDefault.Text = myi.Nombre
        lnkIdiomaDefault.NavigateUrl = "~/sec/workbook/default.aspx?idRoot=" & myr.id

        Dim myri As New Lego.RootIdioma

        rptIdiomas.DataSource = myri.GetDR(CInt(Request("idRoot")))
        rptIdiomas.DataBind()

    End Sub



    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If
                   

                End If
            End If

        End If

    End Sub

 

End Class
