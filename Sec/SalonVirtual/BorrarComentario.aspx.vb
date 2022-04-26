
Partial Class Sec_SalonVirtual_BorrarComentario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mycc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion(CInt(Request("idContenidoCalificacion")))
        Dim usuario As Integer = CInt(Session("gUserProfileSession").idUserProfile)
        If usuario <> mycc.idUserProfile Then
            Response.Redirect("~/sec/default.aspx")

        End If

        txtComentario.Text = mycc.Observacion
        rbdCalificacion.SelectedValue = mycc.Calificacion

        lnkMuro.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        lnkApunte1.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkApunte2.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMinilink.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        System.Threading.Thread.Sleep(1500)
        Dim mycc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion(CInt(Request("idContenidoCalificacion")))

        Dim usuario As Integer = CInt(Session("gUserProfileSession").idUserProfile)
        If usuario <> mycc.idUserProfile Then
            Response.Redirect("~/sec/default.aspx")

        End If

        mycc.Observacion = txtComentario.Text
        mycc.Calificacion = CInt(rbdCalificacion.SelectedValue)
        mycc.Update()

        Response.Redirect(Request("pag") & "?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))

    End Sub

    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim mycc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion(CInt(Request("idContenidoCalificacion")))

        Dim usuario As Integer = CInt(Session("gUserProfileSession").idUserProfile)
        If usuario <> mycc.idUserProfile Then
            Response.Redirect("~/sec/default.aspx")

        End If

        mycc.Remove()

        Response.Redirect(Request("pag") & "?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        System.Threading.Thread.Sleep(1500)
        Response.Redirect(Request("pag") & "?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))
    End Sub
End Class
