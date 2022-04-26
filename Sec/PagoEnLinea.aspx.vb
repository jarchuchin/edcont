
Partial Class Sec_PagoEnLinea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenardrops
            colocarDatos()
        End If
    End Sub


    Sub llenardrops()
        For i As Integer = Today.Year To Today.Year + 10
            drpAno.Items.Add(New ListItem(i, i))
        Next
    End Sub

    Sub colocarDatos()

        If Session("gUserProfileSession").nombre <> "" Then

            Dim myu As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.existe Then
                Dim myue As New MasUsuarios.EmpresaUserProfile(myu.id, 4, "")
                If myue.existe Then
                    lblAlumno.Text = myue.claveAux1 & " - " & Session("gUserProfileSession").nombre
                Else
                    btnPagar.Visible = False
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If
        Else
            Response.Redirect("~/logout.aspx")
        End If




    End Sub
    Protected Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click


        If Page.IsValid Then



            Dim myu As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.existe Then
                Dim myue As New MasUsuarios.EmpresaUserProfile(myu.id, 4, "")
                If myue.existe Then
                    lblAlumno.Text = myue.claveAux1 & " - " & Session("gUserProfileSession").nombre

                    Session("pagoMatricula") = myue.claveAux1
                    Session("pagoAlumno") = Session("gUserProfileSession").nombre
                    Session("pagoCantidad") = txtpago.Text
                    Session("pagoNumero") = txtNumeroCuenta.Text
                    Session("pagoNombreTarjeta") = txtNombre.Text
                    Session("pagoTipo") = drpTipoTarjeta.SelectedValue
                    Session("pagoMes") = drpMes.SelectedValue
                    Session("pagoAno") = drpAno.SelectedValue
                    Session("pagoCodigo") = txtNumeroExtra.Text

                    Session("pagoCP") = "" 'txtCP.Text

                    Response.Redirect("PagoEnLinea02.aspx")

                Else
                    Response.Redirect("~/logout.aspx")
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If



    End Sub
    Protected Sub CustomValidator1_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If txtNumeroCuenta.Text.Length = 16 Then
            args.IsValid = True
        Else
            args.IsValid = False

        End If
    End Sub
End Class
