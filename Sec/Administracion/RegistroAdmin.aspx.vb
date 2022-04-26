
Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports System.IO

Partial Class registroAdmin
    Inherits System.Web.UI.Page


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If Page.IsValid Then

            If Request("idUserProfile") <> "" Then
                editar()
            Else
                grabarUserProfile()
            End If

            'FormsAuthentication.SetAuthCookie(txtLogin.Text, False)
            'Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/Default.aspx")



        End If

    End Sub

    Sub llenarDrops()
        Dim mye As New MasUsuarios.Empresa

        drpEmpresas.DataSource = mye.GetDR()
        drpEmpresas.DataTextField = "Nombre"
        drpEmpresas.DataValueField = "idEmpresa"
        drpEmpresas.DataBind()


    End Sub

    Sub editar()
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
        myUsuarios.login = txtLogin.Text.ToString
        myUsuarios.password = txtPassword.Text.ToString
        myUsuarios.nombre = txtNombre.Text.ToString
        myUsuarios.apellidos = txtApellidos.Text.ToString
        myUsuarios.sexo = DropSexo.SelectedItem.Value.ToString
        myUsuarios.fechaNacimiento = CType(txtFechaNacimiento.Text, Date)

        myUsuarios.email = txtEmail.Text
        myUsuarios.bloqueado = chkbloqueado.Checked
        myUsuarios.bloqueadoMensaje = txtbloqueadoMensaje.Text

        myUsuarios.tipoUsuario = drpTipoUsuario.SelectedValue
        myUsuarios.Update()


        Dim myeu As New MasUsuarios.EmpresaUserProfile(myUsuarios.id, False)
        myeu.claveAux1 = txtMatricula.Text
        myeu.idEmpresa = CInt(drpEmpresas.SelectedValue)
        myeu.Update()


        Response.Redirect("RegistroAdmin.aspx?idUserProfile=" & myUsuarios.id & "&msg=2")

    End Sub
    Sub grabarUserProfile()
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        myUsuarios.login = txtLogin.Text.ToString
        myUsuarios.password = txtPassword.Text.ToString
        myUsuarios.nombre = txtNombre.Text.ToString
        myUsuarios.apellidos = txtApellidos.Text.ToString
        myUsuarios.sexo = DropSexo.SelectedItem.Value.ToString
        myUsuarios.fechaNacimiento = CType(txtFechaNacimiento.Text, Date)
        myUsuarios.telefono = ""
        myUsuarios.direccion = ""
        myUsuarios.ciudad = ""
        myUsuarios.estado = ""
        myUsuarios.pais = 1
        myUsuarios.email = txtEmail.Text
        myUsuarios.webpage = ""
        myUsuarios.caja = 0
        myUsuarios.idioma = Session("gUserProfileSession").Idioma
        myUsuarios.estilo = 0
        myUsuarios.datosPublicos = "111111111111"
        Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(drpEmpresas.SelectedValue))
        myUsuarios.empresa = myEmpresa
        myUsuarios.claveAux1 = txtMatricula.Text
        myUsuarios.esAdministrador = chkEsAdministrador.Checked
        myUsuarios.bloqueado = chkbloqueado.Checked
        myUsuarios.bloqueadoMensaje = txtbloqueadoMensaje.Text
        myUsuarios.tipoUsuario = drpTipoUsuario.SelectedValue
        myUsuarios.Add()


        'Enviar Mail

        EnviarCorreo(myUsuarios)
        ' Response.Redirect("RegistroAdmin.aspx?idUserProfile=" & myUsuarios.id & "&msg=1")
        Response.Redirect("RegistroAdmin.aspx?msg=1")

        ' Session("gUserProfileSession") = myUsuarios.GetUserProfilesSession()
    End Sub

    Private Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate

        If IsDate(args.Value) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub



    Private Sub validadorlogin_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles validadorlogin.ServerValidate

        If Request("idUserProfile") <> "" Then
            args.IsValid = True
        Else
            Dim myusuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(txtLogin.Text.ToString, False)
            If myusuarios.existe Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If
        End If

    End Sub



    Sub iniciarpagina()

        llenarDrops()

        If Request("idUserProfile") <> "" Then
            Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
            Dim myeu As New MasUsuarios.EmpresaUserProfile(myUsuarios.id, False)


            drpEmpresas.SelectedValue = myeu.idEmpresa
            If CInt(Session("idEmpresa")) = 4 Then
                drpEmpresas.Enabled = True
            Else
                drpEmpresas.Enabled = False

            End If

            txtLogin.Text = myUsuarios.login
            txtMatricula.Text = myeu.claveAux1
            txtPassword.Attributes.Add("value", myUsuarios.password)
            txtConfirmar.Attributes.Add("value", myUsuarios.password)

            txtNombre.Text = myUsuarios.nombre
            txtApellidos.Text = myUsuarios.apellidos
            DropSexo.SelectedValue = myUsuarios.sexo
            txtFechaNacimiento.Text = myUsuarios.fechaNacimiento.ToShortDateString
            txtEmail.Text = myUsuarios.email

            chkEsAdministrador.Visible = False

            chkbloqueado.Checked = myUsuarios.bloqueado
            txtbloqueadoMensaje.Text = myUsuarios.bloqueadoMensaje

            drpTipoUsuario.SelectedValue = myUsuarios.tipoUsuario

            btnBorrar.Visible = True

            If Request("msg") = "1" Then
                divMensaje.Visible = True
                lblMensaje.Text = "Se ha grabado exitosamente al usuario"
            End If


            If Request("msg") = "2" Then
                divMensaje.Visible = True
                lblMensaje.Text = "Actualización realizada " & Date.Now
            End If

            txtLogin.Enabled = False


            Dim myux As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myux.login.ToLower = "jarchuchin" Or myux.login.ToLower = "laura" Or myux.login.ToLower = "felipe" Then
                lblPass.Visible = True
                lblPass.Text = myUsuarios.password
            Else
                lblPass.Visible = False
            End If

            btnEnviarDatos.Visible = True
        Else


            If Request("msg") = "1" Then
                divMensaje.Visible = True
                lblMensaje.Text = "Se ha grabado exitosamente al usuario"
            End If


            If Request("msg") = "2" Then
                divMensaje.Visible = True
                lblMensaje.Text = "Actualización realizada " & Date.Now
            End If


            drpEmpresas.SelectedValue = CInt(Session("idEmpresa"))

            If CInt(Session("idEmpresa")) = 4 Then
                Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
                If myu.login.ToLower = "jarchuchin" Or myu.login.ToLower = "laura" Or myu.login.ToLower = "felipe" Then
                    drpEmpresas.Enabled = True
                Else
                    drpEmpresas.Enabled = False
                End If

            Else
                drpEmpresas.Enabled = False
            End If
        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarpagina()
        End If
    End Sub
    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)

        myUsuarios.Remove()

        Response.Redirect("default.aspx")
    End Sub





    Public Function EnviarCorreo(objUsuario As MasUsuarios.UserProfile) As Integer

        ' Dim myup As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim direcciones As MailAddressCollection = New MailAddressCollection
        'Dim direccionesreplayto As MailAddressCollection = New MailAddressCollection

        'direccionesreplayto.Add(txtmailfrom.Text)


        Dim i As Integer



        ' Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("info@skolar.online")
        MailMsg.To.Add(Trim(objUsuario.email))







        ' Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = "Activación de cuenta - " & objUsuario.nombre & " " & objUsuario.apellidos
            ' .ReplyToList.Add(txtmailfrom.Text)
            .Body = GetMensaje(objUsuario)
            .IsBodyHtml = True
            '.ReplyToList = direccionesreplayto
            '  .Headers.Add("X-SES-CONFIGURATION-SET", "ConfigSet")
        End With

        Dim numero As Integer = 0

        Dim f As New System.Net.Mail.SmtpClient("email-smtp.us-east-2.amazonaws.com")
        f.UseDefaultCredentials = False

        f.Port = 587


        ' f.Credentials = New System.Net.NetworkCredential()



        f.Credentials = New System.Net.NetworkCredential("AKIA4Q73D2ZEPWTSJE6K", "BDe+3nCDgRQ+h8HfccP1UyEb6G3DiqjSXUrX+x5PdpAF")
        f.EnableSsl = True
        f.DeliveryMethod = SmtpDeliveryMethod.Network
        'Try
        f.Send(MailMsg)
        '   Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
        'Catch ex As Exception

        'End Try
        ' f.Send(MailMsg)

        Return 1
    End Function


    Public Function GetMensaje(myup As MasUsuarios.UserProfile) As String
        Dim mye As New MasUsuarios.Empresa(CInt(drpEmpresas.SelectedValue))


        Dim cadena As New StringBuilder()

        cadena.AppendLine("Estimado: " & myup.nombre & " " & myup.apellidos)
        cadena.AppendLine("<br>")


        cadena.AppendLine("Te damos la bienvenida a la experiencia digital de <b>" & mye.nombre & "</b>, a través de Skolar Education Solutions.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("Disfruta de los servicios digitales a partir de este momento.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("Estarán disponibles durante toda tu vida activa como alumno, por lo cual, buscamos contar con una oferta tecnológica actualizada que corresponda a las necesidades de la comunidad de nuestra escuela.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("Para obtener acceso a estos servicios digitales se ha creado la siguiente cuenta:")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("<b>Liga de Acceso</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<a href=""https://skolar.online/" & mye.codigoGobernacion & """" & " > https:  //skolar.online/" & mye.codigoGobernacion & "</a>")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("<b>Nombre de usuario</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(myup.nombre & " " & myup.apellidos)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("<b>Usuario</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(myup.login)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("<b>Password</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(myup.password)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("Para mejorar tu experiencia de usuario contamos con un servicio de Soporte disponible en cualquier momento enviando un whatsapp al <b>+52 8131102295</b> o en el mail <b>info@skolar.online</b>.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("Te deseamos éxito en tus actividades y mucha suerte.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("Bienvenido.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")




        cadena.AppendLine("Atentamente,")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("<b>" & mye.nombre & "</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")

        cadena.AppendLine("<b>Fecha:</b> " & Date.Now)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")
        cadena.AppendLine()


        Return cadena.ToString
    End Function


    Protected Sub btnEnviarDatos_Click(sender As Object, e As EventArgs) Handles btnEnviarDatos.Click
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
        EnviarCorreo(myUsuarios)
    End Sub
End Class
