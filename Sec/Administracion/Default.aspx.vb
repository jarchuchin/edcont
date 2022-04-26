
Partial Class Sec_Administracion_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        autorizacion()

        If Not IsPostBack Then
            If Request("idUserProfile") <> "" Then
                If IsNumeric(Request("idUserProfile")) Then

                    If Session("esAdministrador") Then
                        enviarHomePage(CInt(Request("idUserProfile")))
                    Else
                        Response.Redirect("~/logout.aspx?mensaje=usuarionoautorizado")
                    End If

                End If
            End If
            llenaEmpresas()


        End If

    End Sub

    Sub llenaEmpresas()
        Dim mye As New MasUsuarios.Empresa
        drpEmpresas.DataSource = mye.GetDR()
        drpEmpresas.DataValueField = "idEmpresa"
        drpEmpresas.DataTextField = "Nombre"
        drpEmpresas.DataBind()

        Dim myli As New ListItem("Todos", "0")
        drpEmpresas.Items.Insert(0, myli)


        drpEmpresas.SelectedValue = Session("idEmpresa")

        If CInt(Session("idEmpresa")) = 4 Then
            Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.login.ToLower = "jarchuchin" Or myu.login.ToLower = "laura" Or myu.login.ToLower = "felipe" Then
                drpEmpresas.Visible = True
            Else
                drpEmpresas.Visible = False
            End If

        Else
            drpEmpresas.Visible = False
        End If

    End Sub
    Sub enviarHomePage(ByVal claveusuario As Integer)
        Dim actual As Integer = CInt(Session("gUserProfileSession").idUserProfile)



        Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(claveusuario, True)
        If myUser.login.ToLower = "jarchuchin" Or myUser.login.ToLower = "laura" Or myUser.login.ToLower = "felipe" Then
            If actual = 23 Or actual = 45484 Or actual = 45483 Then
                Session("gUserProfileSession") = myUser.GetUserProfilesSession()
                Session("bloqueadoMensaje") = myUser.bloqueadoMensaje
                FormsAuthentication.SetAuthCookie(myUser.login, False)
                Session("idEmpresa") = CInt(Session("gUserProfileSession").idEmpresaDefault)

                Response.Redirect("~/sec/home.aspx")
            Else
                Response.Redirect("~/logout.aspx")
            End If
        Else
            Session("gUserProfileSession") = myUser.GetUserProfilesSession()
            Session("bloqueadoMensaje") = myUser.bloqueadoMensaje
            FormsAuthentication.SetAuthCookie(myUser.login, False)
            Session("idEmpresa") = CInt(Session("gUserProfileSession").idEmpresaDefault)

            Response.Redirect("~/sec/home.aspx")
        End If


    End Sub


    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myu, mye)

        Session("ingresoAdmin") = True

        If Not myp.existe Then
            Response.Redirect("~/sec/home.aspx")
        End If


    End Sub


    Public Property GridViewSortDirection() As SortDirection
        Get
            If IsNothing(ViewState("sortDirection")) Then
                ViewState("sortDirection") = SortDirection.Ascending
            End If
            Return CType(ViewState("sortDirection"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("sortDirection") = value
        End Set
    End Property


    Public numeroRegistro As Integer


    Protected Sub gvMisSalones_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvSalones.Sorting

        Dim orden As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            Ordenar(orden, "desc")
        Else
            GridViewSortDirection = SortDirection.Ascending
            Ordenar(orden, "asc")
        End If
    End Sub


    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String) As Integer
        Dim myUsuario As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        Dim ds As Data.DataSet

        Dim claveEmpresa As Integer = 0


        If CInt(Session("idEmpresa")) = 4 Then
            If CInt(drpEmpresas.SelectedValue) > 0 Then
                claveEmpresa = CInt(drpEmpresas.SelectedValue)

            End If

        Else
            '
            claveEmpresa = CInt(Session("idEmpresa"))


        End If

        If claveEmpresa > 0 Then
            ds = myUsuario.GetDSBuscar(claveEmpresa, txtBuscar.Text.ToString)

        Else
            ds = myUsuario.GetDSBuscarToditos(txtBuscar.Text.ToString)
        End If

        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        If claveEmpresa > 0 Then
            mydv.RowFilter = "idEmpresa=" & claveEmpresa
        End If



        mydv.Sort = expresion + " " + direccion
        gvSalones.DataSource = mydv
        gvSalones.DataBind()


        If ds.Tables(0).Rows.Count > 0 Then
            divespacio.Visible = False
        Else
            divespacio.Visible = True
        End If

    End Function



    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Ordenar("Nombre", "asc")
    End Sub



    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Response.Redirect("RegistroAdmin.aspx")
    End Sub
    Protected Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click


        Dim myUsuario As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        Dim ds As Data.DataSet = myUsuario.GetDSBuscarTodos(Integer.Parse(Session("gUserProfileSession").idEmpresaDefault))




        gvSalones.DataSource = ds
        gvSalones.DataBind()


        If ds.Tables(0).Rows.Count > 0 Then
            divespacio.Visible = False
        Else
            divespacio.Visible = True
        End If



    End Sub
End Class
