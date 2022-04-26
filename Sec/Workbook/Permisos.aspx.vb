Imports System.Globalization
Imports System.Threading

Partial Class Sec_Workbook_Permisos
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()

        End If
    End Sub




    Sub iniciarControles()

        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo



        Dim myEmpresaUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile
        drpEmpresa.DataSource = myEmpresaUser.GetDR(Session("gUserProfileSession").idUserProfile)
        drpEmpresa.DataTextField = "nombreempresa"
        drpEmpresa.DataValueField = "idEmpresa"
        drpEmpresa.DataBind()
        ColocaTablaDePermisos()


        If Request("idPermiso") <> "" Then
            colocarDatos(0, CInt(Request("idPermiso")))
        End If







        lnkTitulo.Text = myr.titulo
        lnkTitulo.ToolTip = myr.titulo
        '  lblTitulo.Text = myr.titulo
        lnkTitulo.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & myr.id

        If Request("mensaje") = "1" Then
            alertSuccess.Visible = True

        End If


    End Sub


    Sub ColocaTablaDePermisos()
        Dim myPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso
        Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
        gvPermisos.DataSource = myPermisos.GetDR(True, , myr)
        gvPermisos.DataBind()
    End Sub


    Sub ColocarUsuariosDeEmpresa(ByVal clave As Integer)

        drpUsuarios.Visible = True
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        drpUsuarios.DataSource = myUsuarios.GetDR(clave, txtbuscar.Text.ToString)
        drpUsuarios.DataValueField = "idUserProfile"
        drpUsuarios.DataTextField = "nombre"
        drpUsuarios.DataBind()


        resetboxes()

        If drpUsuarios.Items.Count > 0 Then
            colocarDatos(Integer.Parse(drpUsuarios.Items(0).Value), 0)
        End If

    End Sub

    Sub resetboxes()

        lblUsuario.Text = ""

        txtid.Text = ""
        chkPRoots.Checked = False
        chkPPermisosRoots.Checked = False
        chkPCategorias.Checked = False
        'chkPRespuestas.Checked = False
        'chkPEvaluacion.Checked = False
        chkPSalonVirtual.Checked = False
        chkPContenidos.Checked = False
        chkPInterfaceGrafica.Checked = False
        chkPEstadisticas.Checked = False
        chkPAdministracion.Checked = False
    End Sub

    Sub editar()
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(Integer.Parse(txtid.Text))
        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myPermiso.idPermisoA, False)
        Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
        myPermiso.permisoA = myUserP.tipo
        myPermiso.recurso = myr.tipo
        myPermiso.PRoots = chkPRoots.Checked
        myPermiso.PPermisosRoots = chkPPermisosRoots.Checked
        myPermiso.PCategorias = chkPCategorias.Checked
        myPermiso.PRespuestas = False 'chkPRespuestas.Checked
        myPermiso.PEvaluacion = False 'chkPEvaluacion.Checked
        myPermiso.PSalonVirtual = chkPSalonVirtual.Checked
        myPermiso.PContenidos = chkPContenidos.Checked
        myPermiso.PInterfaceGrafica = chkPInterfaceGrafica.Checked
        myPermiso.PEstadisticas = chkPEstadisticas.Checked
        myPermiso.PAdministracion = chkPAdministracion.Checked
        myPermiso.Update()
    End Sub

    Sub grabar()
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso
        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Integer.Parse(drpUsuarios.SelectedItem.Value), False)
        Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))




        myPermiso.permisoA = myUserP.tipo
        myPermiso.idPermisoA = myUserP.id
        myPermiso.recurso = myr.tipo
        myPermiso.idRecurso = myr.id

        myPermiso.PRoots = chkPRoots.Checked
        myPermiso.PPermisosRoots = chkPPermisosRoots.Checked
        myPermiso.PCategorias = chkPCategorias.Checked
        myPermiso.PRespuestas = False 'chkPRespuestas.Checked
        myPermiso.PEvaluacion = False 'chkPEvaluacion.Checked
        myPermiso.PSalonVirtual = chkPSalonVirtual.Checked
        myPermiso.PContenidos = chkPContenidos.Checked
        myPermiso.PInterfaceGrafica = chkPInterfaceGrafica.Checked
        myPermiso.PEstadisticas = chkPEstadisticas.Checked
        myPermiso.PAdministracion = chkPAdministracion.Checked
        myPermiso.Add()

    End Sub

    'Private Sub dtgPermisos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgPermisos.SelectedIndexChanged
    '    colocarDatos(Integer.Parse(dtgPermisos.DataKeys(dtgPermisos.SelectedIndex)))
    'End Sub

    Sub colocarDatos(ByVal claveUsuario As Integer, ByVal clavePermiso As Integer)

        Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
        Dim myPermiso As MasUsuarios.Permiso
        If claveUsuario > 0 Then

            myPermiso = New MasUsuarios.Permiso(New MasUsuarios.UserProfile(claveUsuario, False), myr)
        Else
            myPermiso = New MasUsuarios.Permiso(clavePermiso)
        End If

        If myPermiso.existe Then

            Dim myu As New MasUsuarios.UserProfile(myPermiso.idPermisoA, False)
            lblUsuario.Text = myu.nombre & " " & myu.apellidos


            txtid.Text = myPermiso.id

            btnBorrar.Visible = True

            '         drpEmpresa.Visible = False
            '   lblEmpresas.Visible = False

            chkPRoots.Checked = myPermiso.PRoots
            chkPPermisosRoots.Checked = myPermiso.PPermisosRoots
            chkPCategorias.Checked = myPermiso.PCategorias
            '   chkPRespuestas.Checked = myPermiso.PRespuestas
            '  chkPEvaluacion.Checked = myPermiso.PEvaluacion
            chkPSalonVirtual.Checked = myPermiso.PSalonVirtual
            chkPContenidos.Checked = myPermiso.PContenidos
            chkPInterfaceGrafica.Checked = myPermiso.PInterfaceGrafica
            chkPEstadisticas.Checked = myPermiso.PEstadisticas
            chkPAdministracion.Checked = myPermiso.PAdministracion
        Else
            resetboxes()
        End If


    End Sub

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(Integer.Parse(txtid.Text))
        myPermiso.Remove()
        Response.Redirect(RecargarPagina)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If txtid.Text <> "" Then
            editar()
        Else
            grabar()

        End If
        Response.Redirect(RecargarPagina() & "&mensaje=1")
    End Sub

    Function RecargarPagina() As String
        Return "permisos.aspx?idRoot=" & Request("idRoot")

    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click



        panelPermisos.Visible = True
        ColocarUsuariosDeEmpresa(Integer.Parse(drpEmpresa.SelectedItem.Value.ToString))
    End Sub

    Private Sub drpUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpUsuarios.SelectedIndexChanged
        colocarDatos(Integer.Parse(drpUsuarios.SelectedValue), 0)
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
                    If myp.PPermisosRoots Or myp.PAdministracion Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("home.aspx?idRoot=" & Request("idRoot"))
    End Sub
End Class
