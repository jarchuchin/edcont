
Partial Class Sec_SalonVirtual_EnviarCorreoConfirmacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Sub
End Class
