
Partial Class Sec_Administracion_Rubrica
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        colocardatos()
    '    End If
    'End Sub

    'Sub colocardatos()
    '    If Request("idRubrica") <> "" Then
    '        Dim myr As New Lego.Rubrica(CInt(Request("idRubrica")))
    '        txtTitulo.Text = myr.Titulo
    '        txtdescripcion.Text = myr.Descripcion
    '        txtHoras.Text = myr.TiempoElaboracion
    '        llenarRubros()

    '        btnBorrar.Visible = True
    '    Else
    '        btnBorrar.Visible = False


    '    End If
    'End Sub

    'Sub llenarRubros()
    '    Dim myro As New Lego.Rubro()
    '    gvRubros.DataSource = myro.GetDR(CInt(Request("idRubrica")))
    '    gvRubros.DataBind()

    'End Sub

    'Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
    '    If Request("idRubrica") <> "" Then
    '        editar()
    '    Else
    '        Grabar()

    '    End If



    'End Sub

    'Sub editar()
    '    Dim myr As New Lego.Rubrica(CInt(Request("idRubrica")))
    '    myr.Titulo = txtTitulo.Text
    '    ' myr.Descripcion = txtdescripcion.Text
    '    myr.TiempoElaboracion = CInt(txtHoras.Text)
    '    myr.Update()

    'End Sub
    'Sub grabar()
    '    Dim myr As New Lego.Rubrica()
    '    myr.idEmpresa = 4
    '    myr.Titulo = txtTitulo.Text
    '    myr.Descripcion = txtdescripcion.Text
    '    myr.TiempoElaboracion = CInt(txtHoras.Text)
    '    myr.Eliminado = False
    '    myr.Add()


    '    Dim myro As New Lego.Rubro

    '    myro.idRubrica = myr.id
    '    myro.Titulo = "Rubro 1"
    '    myro.Descripcion = ""
    '    myro.Valor = 4
    '    myro.Eliminado = False
    '    myro.Add()

    '    myro.idRubrica = myr.id
    '    myro.Titulo = "Rubro 2"
    '    myro.Descripcion = ""
    '    myro.Valor = 3
    '    myro.Eliminado = False
    '    myro.Add()

    '    myro.idRubrica = myr.id
    '    myro.Titulo = "Rubro 3"
    '    myro.Descripcion = ""
    '    myro.Valor = 2
    '    myro.Eliminado = False
    '    myro.Add()


    '    myro.idRubrica = myr.id
    '    myro.Titulo = "Rubro 4"
    '    myro.Descripcion = ""
    '    myro.Valor = 1
    '    myro.Eliminado = False
    '    myro.Add()

    '    Response.Redirect("Rubrica.aspx?idRubrica=" & myr.id)
    'End Sub

    'Protected Sub btnRegresar_Click(sender As Object, e As System.EventArgs) Handles btnRegresar.Click
    '    Response.Redirect("ListaRubricas.aspx")

    'End Sub

    'Protected Sub lnkpresentarPanel_Click(sender As Object, e As System.EventArgs) Handles lnkpresentarPanel.Click
    '    Response.Redirect("Rubro.aspx?idRubrica=" & Request("idRubrica"))
    'End Sub



    'Protected Sub btnBorrar_Click(sender As Object, e As System.EventArgs) Handles btnBorrar.Click
    '    Dim myr As New Lego.Rubrica(CInt(Request("idRubrica")))
    '    myr.Remove()
    '    Response.Redirect("ListaRubricas.aspx")

    'End Sub
End Class
