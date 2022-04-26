Imports System.Math

Partial Class Controles_Login
    Inherits System.Web.UI.UserControl

    Protected Sub btnLogear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim myU As MasUsuarios.UserProfile = New MasUsuarios.UserProfile()



        ''  ################## seccion para prueba ##################################################
        'Application("usuariosconectados") = Application("usuariosconectados") + 1
        'If txtlogin.Text = "jarchuchin" Then
        '    myU = New MasUsuarios.UserProfile(23, True)
        'End If
        'If txtlogin.Text = "jrsnchz" Then
        '    myU = New MasUsuarios.UserProfile(62, True)
        'End If
        'If myU.existe Then
        '    Session("gUserProfileSession") = myU.GetUserProfilesSession()
        '    Session("fotoUsuario") = myU.imagen

        '    '###############   Asignar Permisos
        '    Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        '    Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myU, mye)

        '    Session("esAdministrador") = myp.PAdministracion
        '    Session("esGerenciaSalones") = myp.PSalonVirtual


        '    If Request.QueryString("ReturnUrl") <> "" Then
        '        FormsAuthentication.RedirectFromLoginPage("jarchuchin", False)
        '        Response.Redirect(Request.QueryString("ReturnUrl"))
        '    Else
        '        FormsAuthentication.SetAuthCookie("jarchuhin", False)
        '        Response.Redirect("~/sec/home.aspx")
        '    End If
        'Else
        '    lblMensajeError.Visible = True
        'End If



        '  ################## UMVIRTUAL ##################################################
        'If txtlogin.Text.Contains("@") Then
        '    'Ingresar sin conectarse al sistema academico
        '    myU = New MasUsuarios.UserProfile(txtlogin.Text, False)
        '    If myU.password = txtPassword.Text Then
        '        Session("gUserProfileSession") = myU.GetUserProfilesSession()

        '        '###############   Asignar Permisos
        '        Session("esAdministrador") = False
        '        Session("esGerenciaSalones") = False
        '        Session("idEmpresa") = Session("gUserProfileSession").idEmpresaDefault

        '        If Request.QueryString("ReturnUrl") <> "" Then
        '            FormsAuthentication.RedirectFromLoginPage(txtlogin.Text.ToString, False)
        '        Else
        '            FormsAuthentication.SetAuthCookie(txtlogin.Text, False)
        '            Response.Redirect("~/sec/home.aspx")

        '        End If
        '    Else
        '        lblMensajeError.Visible = True
        '    End If
        'End If
        '  ################## UMVIRTUAL ##################################################


        'cada empresa tendra decidira si consume una validacion personalizada o no
        Dim clave As Integer = myU.AutenticadoClaveUser(txtlogin.Text, txtPassword.Text, False)
        If clave > 0 Then
            myU = New MasUsuarios.UserProfile(clave, True)

            If myU.bloqueado Then

                lblMensajeError.Text = "Tu portal ha sido bloqueado --- " & myU.bloqueadoMensaje
                lblMensajeError.Visible = True


            Else




                Session("fotoUsuario") = myU.imagen
                Dim myEmpresaUserProfile As New MasUsuarios.EmpresaUserProfile(clave, False)

                ' Dim mysaldoestudiante As New UM.Saldos_Estudiantes(myEmpresaUserProfile.claveAux1)
                Application("usuariosconectados") = Application("usuariosconectados") + 1

                Session("bloqueadoMensaje") = myU.bloqueadoMensaje



                '###############   Asignar Permisos
                Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(myEmpresaUserProfile.idEmpresa)
                Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myU, mye)

                Session("esAdministrador") = myp.PAdministracion
                Session("esGerenciaSalones") = myp.PSalonVirtual
                Session("idEmpresa") = myEmpresaUserProfile.idEmpresa
                Session("logoPrincipal") = mye.ImagenLogo

                '  Session("saldoGlobal") = Format(Abs(mysaldoestudiante.saldoglobal), "c")

                'If mysaldoestudiante.saldoglobal > 150 Then
                '    Session("finanzas") = "Tu saldo vencido es de " & Format(Abs(mysaldoestudiante.saldoglobal), "c") & " y deberá ser pagado antes  del 8 de abril evitando así se cierre tu portal o tu Skolar. Cualquier duda con tu saldo, pasa a Finanzas Estudiantiles para aclararlo. <br><br>CP. Raúl randeles<br>Dir. Finanzas Estudiantiles"
                'Else
                '    Session("finanzas") = ""
                'End If




                If myU.login = "jarchuchin" Or myU.login = "jrsnchzx" Or myU.login = "0871074" Then
                    Session("gUserProfileSession") = myU.GetUserProfilesSession()
                    If Request.QueryString("ReturnUrl") <> "" Then
                        FormsAuthentication.RedirectFromLoginPage(txtlogin.Text.ToString, False)
                    Else
                        FormsAuthentication.SetAuthCookie(txtlogin.Text, False)
                        Response.Redirect("~/sec/home.aspx")
                        'If myU.emailGoogle <> "" Then
                        '    Response.Redirect("~/sec/home.aspx")
                        'Else
                        '    Response.Redirect("~/sec/DatosPersonales.aspx")
                        'End If
                    End If
                End If



                'seccion colocada nomas para pasar a todos

                Dim mys As Know.SalonVirtual = New Know.SalonVirtual
                Dim cursosMestro As Integer = mys.Count(CInt(Session("gUserProfileSession").idUserProfile), 0)



                Session("gUserProfileSession") = myU.GetUserProfilesSession()
                If Request.QueryString("ReturnUrl") <> "" Then
                    FormsAuthentication.RedirectFromLoginPage(txtlogin.Text.ToString, False)
                Else
                    FormsAuthentication.SetAuthCookie(txtlogin.Text, False)
                    Response.Redirect("~/sec/home.aspx")
                    'If myU.emailGoogle <> "" Then
                    '    Response.Redirect("~/sec/home.aspx")
                    'Else
                    '    Response.Redirect("~/sec/DatosPersonales.aspx")
                    'End If
                End If


            End If








        Else


            If clave = -1 Then
                lblMensajeError.Text = "Los datos proporcionados no son correctos. No se ha podido conectar al Sistema Academico para validar tus datos. " & Date.Now.ToShortDateString & "-" & Date.Now.ToShortTimeString
            Else
                lblMensajeError.Text = "Los datos proporcionados no son correctos " & Date.Now.ToShortDateString & "-" & Date.Now.ToShortTimeString
            End If



        End If



    End Sub


  

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtlogin.Focus()

            If Request("idEmpresa") <> "" Then
                Dim mye As New MasUsuarios.Empresa(CInt(Request("idEmpresa")))
                If mye.ImagenLogo <> "" Then
                    imgLogo.ImageUrl = "~/images/empresas/" & mye.ImagenLogo
                End If
                lnkOlvidaste.NavigateUrl = "~/Recordar.aspx?idEmpresa=" & Request("idEmpresa")
            End If
        End If
    End Sub

   
End Class
