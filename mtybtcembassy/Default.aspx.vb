
Partial Class ceduca_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Redirect("~/default.aspx?idEmpresa=12")
    End Sub



End Class
