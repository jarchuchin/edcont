
Partial Class Sec_Workbook_Controles_Menu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        autorizacion()
        If Not IsPostBack Then

            colocarDatos()
        End If
    End Sub

    Private myp As MasUsuarios.Permiso

    Sub autorizacion()

        If Session("esAdministrador") Then
            Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
            myp = New MasUsuarios.Permiso(myu, mye)

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else
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
                        If Not myp.existe Then
                            If myu.id <> myr.idUserProfile Then
                                Response.Redirect("../default.aspx")
                            End If

                        End If

                    End If
                End If

            End If
        End If


    End Sub

    Sub colocarDatos()



        If Request("idRoot") <> "" Then
            If IsNumeric(Request("idRoot")) Then

                Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                If myr.existe Then



                    lnkAgregarContenido1.NavigateUrl &= "?idRoot=" & Request("idRoot")

                    lnkPortal1.NavigateUrl &= "?idRoot=" & Request("idRoot")

                    lnkPermisos1.NavigateUrl &= "?idRoot=" & Request("idRoot")
                    lnkIdiomas.NavigateUrl &= "?idRoot=" & Request("idRoot")
                    lnkRevisionAutomatico.NavigateUrl &= "?idRoot=" & Request("idRoot")

                    '   panelDatosGenerales.Visible = myp.PRoots
                    lnkPermisos1.Visible = myp.PPermisosRoots
                    lnkAgregarContenido1.Visible = myp.PContenidos



                Else
                    Response.Redirect("../default.asxp")
                End If


            End If


        End If




    End Sub

    Public Function getcurrentPage() As String

        Dim oInfo As System.IO.FileInfo = New System.IO.FileInfo(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
        Return oInfo.Name.ToLower
    End Function





End Class
