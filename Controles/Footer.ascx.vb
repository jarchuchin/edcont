
Partial Class Controles_Footer
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblUsuarios.Text = Application("usuariosconectados")
            colocarIdiomas()
        End If

    End Sub


    Sub colocarIdiomas()
        Select Case Session("CultureID")
            Case "es-MX"
                lnkIngles.Visible = True
                lnkEspanol.Visible = False
            Case "en-US"
                lnkIngles.Visible = False
                lnkEspanol.Visible = True
            Case Else
                lnkIngles.Visible = False
                lnkEspanol.Visible = True
        End Select
    End Sub


    Private Sub lnkIngles_Click(sender As Object, e As EventArgs) Handles lnkIngles.Click
        Session("CultureID") = "en-US"
        Server.Transfer(Request.Path)
    End Sub

    Private Sub lnkEspanol_Click(sender As Object, e As EventArgs) Handles lnkEspanol.Click
        Session("CultureID") = "es-MX"
        Server.Transfer(Request.Path)
    End Sub


End Class
