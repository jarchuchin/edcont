
Partial Class Sec_Workbook_Controles_TabsWorkbook
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        autorizacion()
        'If Request("idRoot") <> "" Then
        '    ASPxTabControl1.Visible = True


        '    If Request("idClasificacion") <> "" Then
        '        ASPxTabControl1.Tabs(0).NavigateUrl = "~/sec/workbook/addcarpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(1).NavigateUrl = "~/sec/workbook/addContenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(2).NavigateUrl = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(3).NavigateUrl = "~/sec/workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(4).NavigateUrl = "~/sec/workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(5).NavigateUrl = "~/sec/workbook/Foro.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        '        ASPxTabControl1.Tabs(6).NavigateUrl = "~/sec/workbook/Buscar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")

        '        Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion(CInt(Request("idClasificacion")))
        '        lbltituloUnidad.Text = myclasifica.titulo

        '        If Request.Path.ToLower.Contains("addcontenido.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 1
        '        End If

        '        If Request.Path.ToLower.Contains("addanexos.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 2
        '        End If

        '        If Request.Path.ToLower.Contains("actividad.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 3
        '        End If

        '        If Request.Path.ToLower.Contains("examen.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 4
        '        End If

        '        If Request.Path.ToLower.Contains("foro.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 5
        '        End If

        '        If Request.Path.ToLower.Contains("buscar.aspx") Then
        '            ASPxTabControl1.ActiveTabIndex = 6
        '        End If

        '        If Not myp.PContenidos And myp.PCategorias Then
        '            ASPxTabControl1.Tabs(1).Visible = False
        '            ASPxTabControl1.Tabs(2).Visible = False
        '            ASPxTabControl1.Tabs(3).Visible = False
        '            ASPxTabControl1.Tabs(4).Visible = False
        '            ASPxTabControl1.Tabs(5).Visible = False
        '            ASPxTabControl1.Tabs(6).Visible = False

        '        End If

        '    Else
        '        ASPxTabControl1.Tabs(0).NavigateUrl = "~/sec/workbook/addcarpeta.aspx?idRoot=" & Request("idRoot")

        '        ASPxTabControl1.Tabs(1).Visible = False
        '        ASPxTabControl1.Tabs(2).Visible = False
        '        ASPxTabControl1.Tabs(3).Visible = False
        '        ASPxTabControl1.Tabs(4).Visible = False
        '        ASPxTabControl1.Tabs(5).Visible = False
        '        ASPxTabControl1.Tabs(6).Visible = False


        '        lbltituloUnidad.Text = "Crear unidad"
        '    End If


        'Else
        '    ASPxTabControl1.Visible = False
        'End If




    End Sub




    Private myp As MasUsuarios.Permiso
    Public PAdministracion As Boolean = False
    Public PContenidos As Boolean = False

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
                    If myp.PAdministracion Or myp.PCategorias Or myp.PContenidos Then
                        PAdministracion = myp.PAdministracion
                        PContenidos = myp.PContenidos
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If
                  

                End If
            End If

        End If

    End Sub



End Class
