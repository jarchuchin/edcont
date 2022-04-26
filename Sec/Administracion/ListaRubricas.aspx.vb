
Partial Class Sec_Administracion_ListaRubricas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim myr As New Lego.Rubrica

        gvRubricas.DataSource = myr.GetDR(4)
        gvRubricas.DataBind()

    End Sub

    Protected Sub btnAgregarRubrica_Click(sender As Object, e As System.EventArgs) Handles btnAgregarRubrica.Click
        Response.Redirect("Rubrica.aspx")
    End Sub
End Class
