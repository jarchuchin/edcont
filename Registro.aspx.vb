
Partial Class registro
    Inherits System.Web.UI.Page

 
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Page.IsValid Then
            grabarUserProfile()
            FormsAuthentication.SetAuthCookie(txtLogin.Text, False)
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/Default.aspx")
        End If

    End Sub
    Sub grabarUserProfile()
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        myUsuarios.login = txtLogin.Text.ToString
        myUsuarios.password = txtPassword.Text.ToString
        myUsuarios.nombre = txtNombre.Text.ToString
        myUsuarios.apellidos = txtApellidos.Text.ToString
        myUsuarios.sexo = DropSexo.SelectedItem.Value.ToString
        myUsuarios.fechaNacimiento = CType(txtFechaNacimiento.Text, Date)
        myUsuarios.telefono = txtTelefono.Text.ToString
        myUsuarios.direccion = txtDireccion.Text.ToString
        myUsuarios.ciudad = txtCiudad.Text.ToString
        myUsuarios.estado = txtEstado.Text.ToString
        myUsuarios.pais = CType(DropPais.SelectedItem.Value, Integer)
        myUsuarios.email = txtEmail.Text.ToString
        myUsuarios.webpage = txtwebpage.Text.ToString
        myUsuarios.caja = 0
        myUsuarios.idioma = Session("gUserProfileSession").Idioma
        myUsuarios.estilo = 0
        myUsuarios.datosPublicos = "111111111111"
        Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(Integer.Parse(System.Configuration.ConfigurationManager.AppSettings("EmpresaDefault")))
        myUsuarios.empresa = myEmpresa
        myUsuarios.Add()

        Session("gUserProfileSession") = myUsuarios.GetUserProfilesSession()
    End Sub

    Private Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate

        If IsDate(args.Value) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub



    Private Sub validadorlogin_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles validadorlogin.ServerValidate
        Dim myusuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(txtLogin.Text.ToString, False)
        If Not myusuarios.existe And myusuarios.password = txtPassword.Text Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub



    Sub iniciarpagina()
        Dim myPaises As Utilerias.Pais = New Utilerias.Pais
        DropPais.DataSource = myPaises.GetDR
        DropPais.DataTextField = Session("gUserProfileSession").Idioma
        DropPais.DataValueField = "idPais"
        DropPais.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarpagina()
        End If
    End Sub
End Class
