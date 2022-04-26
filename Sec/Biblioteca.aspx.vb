
Partial Class Sec_Biblioteca
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mye As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))
        lblbibliotecas.Text = mye.Bibliotecas
    End Sub
End Class
