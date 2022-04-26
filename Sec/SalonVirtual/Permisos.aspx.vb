
Partial Class Sec_SalonVirtual_Permisos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()

        End If
    End Sub




    Sub iniciarControles()

        If Request("idSalonVirtual") <> "" Then

            Dim myEmpresaUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile
            drpEmpresa.DataSource = myEmpresaUser.GetDR(Session("gUserProfileSession").idUserProfile)
            drpEmpresa.DataTextField = "nombreempresa"
            drpEmpresa.DataValueField = "idEmpresa"
            drpEmpresa.DataBind()
            ColocaTablaDePermisos()


            If Request("idPermiso") <> "" Then
                colocarDatos(0, CInt(Request("idPermiso")))
            End If



            Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))


            Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

            If EsMaestro() Then
                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
            Else
                lnkMisCursos.Text = labelCursosComoAlumno.Text
                lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
            End If
            lnkCurso.Text = mysv.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual



        End If
    End Sub



    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermisos.existe
    End Function


    Sub ColocaTablaDePermisos()
        Dim myPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        gvPermisos.DataSource = myPermisos.GetDR(True, , mysv)
        gvPermisos.DataBind()
    End Sub


    Sub ColocarUsuariosDeEmpresa(ByVal clave As Integer)

        drpUsuarios.Visible = True
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        drpUsuarios.DataSource = myUsuarios.GetDR(clave, txtbuscar.Text.ToString)
        drpUsuarios.DataValueField = "idUserProfile"
        drpUsuarios.DataTextField = "nombre"
        drpUsuarios.DataBind()


        txtid.Text = ""
        chkPRoots.Checked = False
        chkPPermisosRoots.Checked = False
        chkPCategorias.Checked = False
        chkPRespuestas.Checked = False
        chkPEvaluacion.Checked = False
        chkPSalonVirtual.Checked = False
        chkPContenidos.Checked = False
        chkPInterfaceGrafica.Checked = False
        chkPEstadisticas.Checked = False
        chkPAdministracion.Checked = False

        If drpUsuarios.Items.Count > 0 Then
            colocarDatos(Integer.Parse(drpUsuarios.Items(0).Value), 0)
        End If

    End Sub

    Sub editar()
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(Integer.Parse(txtid.Text))
        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myPermiso.idPermisoA, False)

        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        myPermiso.permisoA = myUserP.tipo
        myPermiso.recurso = mysv.tipo
        myPermiso.PRoots = chkPRoots.Checked
        myPermiso.PPermisosRoots = chkPPermisosRoots.Checked
        myPermiso.PCategorias = chkPCategorias.Checked
        myPermiso.PRespuestas = chkPRespuestas.Checked
        myPermiso.PEvaluacion = chkPEvaluacion.Checked
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
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        myPermiso.permisoA = myUserP.tipo
        myPermiso.idPermisoA = myUserP.id
        myPermiso.recurso = mysv.tipo
        myPermiso.idRecurso = mysv.id


        myPermiso.PRoots = chkPRoots.Checked
        myPermiso.PPermisosRoots = chkPPermisosRoots.Checked
        myPermiso.PCategorias = chkPCategorias.Checked
        myPermiso.PRespuestas = chkPRespuestas.Checked
        myPermiso.PEvaluacion = chkPEvaluacion.Checked
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
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myPermiso As MasUsuarios.Permiso
        If claveUsuario > 0 Then
            myPermiso = New MasUsuarios.Permiso(New MasUsuarios.UserProfile(claveUsuario, False), mysv)
        Else
            myPermiso = New MasUsuarios.Permiso(clavePermiso)
        End If

        If myPermiso.existe Then
            txtid.Text = myPermiso.id

            btnBorrar.Visible = True

            drpEmpresa.Visible = False
            lblEmpresas.Visible = False

            chkPRoots.Checked = myPermiso.PRoots
            chkPPermisosRoots.Checked = myPermiso.PPermisosRoots
            chkPCategorias.Checked = myPermiso.PCategorias
            chkPRespuestas.Checked = myPermiso.PRespuestas
            chkPEvaluacion.Checked = myPermiso.PEvaluacion
            chkPSalonVirtual.Checked = myPermiso.PSalonVirtual
            chkPContenidos.Checked = myPermiso.PContenidos
            chkPInterfaceGrafica.Checked = myPermiso.PInterfaceGrafica
            chkPEstadisticas.Checked = myPermiso.PEstadisticas
            chkPAdministracion.Checked = myPermiso.PAdministracion
        End If


    End Sub

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(Integer.Parse(txtid.Text))
        myPermiso.Remove()
        Response.Redirect(RecargarPagina)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If txtid.Text <> "" Then
            If txtid.Text = "0" Then
                grabar()
                Response.Redirect(RecargarPagina)
            Else
                editar()
            End If

        Else
            grabar()
            Response.Redirect(RecargarPagina)
        End If

    End Sub

    Function RecargarPagina() As String
        Return "permisos.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        ColocarUsuariosDeEmpresa(Integer.Parse(drpEmpresa.SelectedItem.Value.ToString))
    End Sub

    Private Sub drpUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpUsuarios.SelectedIndexChanged
        colocarDatos(Integer.Parse(drpUsuarios.SelectedValue), 0)
    End Sub

End Class
