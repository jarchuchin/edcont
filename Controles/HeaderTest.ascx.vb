
Partial Class Controles_HeaderTest
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocar()
        End If
    End Sub


    Sub colocar()


        logoPrincipal.ImageUrl = "~/images/empresas/" & Session("logoPrincipal")

        Select Case Session("CultureID")
            Case "es-MX"
                imgSeleccionada.ImageUrl = "~/img/flags/mexico.jpg"

                '  lnkIngles.Visible = True
              '  lnkEspanol.Visible = False
            Case "en-US"
                imgSeleccionada.ImageUrl = "~/img/flags/usa.jpg"
                '  lnkIngles.Visible = False
                '  lnkEspanol.Visible = True
            Case Else
                '  lnkIngles.Visible = False
                ' lnkEspanol.Visible = True
        End Select

        If Session("gUserProfileSession").nombre <> "" Then
            'lblnombre.Text = Session("gUserProfileSession").nombre
            'lnkmiportal.Visible = True
            '' lnkhome.Visible = False
            'lnkSalir.Visible = True


            'lnkCursos.Visible = True
            'lnkLibrosDeTrabajo.Visible = True
            'lnkBiblioteca.Visible = True
            'lnkPerfil.Visible = True
            'lnkSalir.Visible = True
            'imgProfile.Visible = True

            lblnombre.Text = Session("gUserProfileSession").nombre

            litsaldoglobal.Text = Session("saldoGlobal")

            If Session("fotoUsuario") <> "" Then
                imgProfile.ImageUrl = "~/sec/showfile.aspx?idUserprofile=" & Session("gUserProfileSession").idUserProfile
            End If


        End If
        '      lblFecha.Text = Date.Now.Day & " de " & MonthName(Date.Now.Month) & " de " & Date.Now.Year





        'If Request("idSalonVirtual") <> "" Then
        '    lnkApunte.Visible = True
        '    lnkApunte.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        '    lnkpregunta.Visible = True
        '    lnkpregunta.NavigateUrl = "~/sec/salonvirtual/preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        '    lnkbb.NavigateUrl = "~/sec/salonvirtual/createBBB.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&bbb=1"
        '    lnkbb.Visible = True


        'End If

        'lblmensajefinanzas.Text = Session("finanzas")
        'If lblmensajefinanzas.Text <> "" Then
        '    panelfinanzas.Visible = True
        'Else
        '    panelfinanzas.Visible = False
        'End If

    End Sub

    'Private Sub lnkIngles_Click(sender As Object, e As EventArgs) Handles lnkIngles.Click
    '    Session("CultureID") = "en-US"
    '    Server.Transfer(Request.Path)
    'End Sub

    'Private Sub lnkEspanol_Click(sender As Object, e As EventArgs) Handles lnkEspanol.Click
    '    Session("CultureID") = "es-MX"
    '    Server.Transfer(Request.Path)
    'End Sub

End Class
