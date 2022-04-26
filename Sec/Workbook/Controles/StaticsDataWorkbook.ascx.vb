
Partial Class Sec_Workbook_Controles_staticsDataWorkbook
    Inherits System.Web.UI.UserControl

    Public idRoot As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myr As Lego.Root = New Lego.Root(Me.idRoot)
        Dim myca As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto
        Dim myclas As Lego.Clasificacion = New Lego.Clasificacion

        lblTitulo.Text = myr.titulo
        lblLecturas.Text = myca.Count(myr.id, myr.tipo, Contenidos.TipoContenido.Texto)
        lblArchivos.Text = myca.Count(myr.id, myr.tipo, Contenidos.TipoContenido.Archivo)
        lblimagenes.Text = myca.Count(myr.id, myr.tipo, Contenidos.TipoContenido.Imagen)
        lblCarpetas.Text = myclas.Count(myr.id)
        'lblActividades.Text = myca.Count(myr.id,

    End Sub
End Class
