
Partial Class Sec_Administracion_Rubro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocardatos()
        Dim myrubrica As New Lego.Rubrica(Request("idRubrica"))
        lblTitulo.Text = myrubrica.Titulo

        If Request("idRubro") <> "" Then
            Dim myrubro As New Lego.Rubro(Request("idRubro"))
            txtTituloRubro.Text = myrubro.Titulo
            txtDescripcionRubro.Text = myrubro.Descripcion
            txtValorRubro.Text = myrubro.Valor
            btnBorrar.Visible = True
        Else
            btnBorrar.Visible = False

        End If


    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("Rubrica.aspx?idRubrica=" & Request("idRubrica"))
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        If Request("idRubro") <> "" Then
            editar()
        Else
            grabar()
        End If


        Response.Redirect("Rubrica.aspx?idRubrica=" & Request("idRubrica"))
    End Sub


    Sub editar()
        Dim myrubro As New Lego.Rubro(Request("idRubro"))
        myrubro.Titulo = txtTituloRubro.Text
        myrubro.Descripcion = txtDescripcionRubro.Text
        myrubro.Valor = CInt(txtValorRubro.Text)
        myrubro.Update()

    End Sub

    Sub grabar()
        Dim myrubro As New Lego.Rubro
        myrubro.Titulo = txtTituloRubro.Text
        myrubro.Descripcion = txtDescripcionRubro.Text
        myrubro.Valor = CInt(txtValorRubro.Text)
        myrubro.Eliminado = False
        myrubro.idRubrica = CInt(Request("idRubrica"))

        myrubro.Add()
    End Sub

    Protected Sub btnBorrar_Click(sender As Object, e As System.EventArgs) Handles btnBorrar.Click
        Dim myrubro As New Lego.Rubro(Request("idRubro"))
        myrubro.Remove()
        Response.Redirect("Rubrica.aspx?idRubrica=" & Request("idRubrica"))
    End Sub
End Class
