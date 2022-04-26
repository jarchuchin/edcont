
Partial Class Sec_Administracion_configurarAC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocadatos()
        End If
    End Sub

    Sub colocadatos()

        If Request("TipoC") = "Contenido" Then
            lblTitulo.Text = "Configurar contenido"
            lblCursoBread.Text = "Configurar contenido"
            lblNombreTitulo.Text = "Configurar contenido"


        End If

        If Request("idCatalogoActividadHP") <> "" Then
            Dim mycahp As New Contenidos.CatalogoActividadHP(CInt(Request("idCatalogoActividadHP")))

            txtNombre.Text = mycahp.Nombre
            drpTipoHP.Text = mycahp.TipoHP
            txtTiempoRealizacion.Text = mycahp.TiempoRealizacion


            If mycahp.FileFormato <> "" Then
                lnkFileFormato.NavigateUrl = "~/sec/shofile.aspx?idCatalogoActividadHP=" & Request("idCatalogoActividadHP") & "&tipoarchivo=formato"
                lnkFileFormato.Visible = True
            Else
                lnkFileFormato.Visible = False
            End If

            If mycahp.FileEjemplo <> "" Then
                lnkFileEjemplo.NavigateUrl = "~/sec/shofile.aspx?idCatalogoActividadHP=" & Request("idCatalogoActividadHP") & "&tipoarchivo=ejemplo"
                lnkFileEjemplo.Visible = True
            Else
                lnkFileEjemplo.Visible = False
            End If



        End If
    End Sub
    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        Response.Redirect("ListaAC.aspx")
    End Sub
    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Request("idCatalogoActividadHP") <> "" Then
            editar
        Else
            grabar
        End If
    End Sub

    Sub editar()
        Dim mycahp As New Contenidos.CatalogoActividadHP(CInt(Request("idCatalogoActividadHP")))
        mycahp.TipoHP = drpTipoHP.SelectedValue
        mycahp.Nombre = txtNombre.Text
        mycahp.TiempoRealizacion = txtTiempoRealizacion.Text
        mycahp.Update()

        subirArchivo(FileUpload1, mycahp, "formato")
        subirArchivo(FileUpload2, mycahp, "ejemplo")


        Response.Redirect("configurarAC.aspx?idCatalogoActividadHP=" & Request("idCatalgooActividadHP") & "&tipo" & Request("tipo"))

    End Sub

    Sub grabar()
        Dim mycahp As New Contenidos.CatalogoActividadHP
        mycahp.TipoC = Request("tipo")
        mycahp.TipoHP = drpTipoHP.SelectedValue
        mycahp.Nombre = txtNombre.Text
        mycahp.TiempoRealizacion = txtTiempoRealizacion.Text
        mycahp.FileFormato = ""
        mycahp.FileEjemplo = ""
        mycahp.Eliminado = False
        mycahp.Add()

        subirArchivo(FileUpload1, mycahp, "formato")
        subirArchivo(FileUpload2, mycahp, "ejemplo")


        Response.Redirect("configurarAC.aspx?idCatalogoActividadHP=" & Request("idCatalgooActividadHP") & "&tipo" & Request("tipo"))
    End Sub

    Public Function subirArchivo(upFile As System.Web.UI.WebControls.FileUpload, objhp As Contenidos.CatalogoActividadHP, tipoArchivo As String) As Boolean

        If Not upFile.HasFile Then Return False

        Dim postedFile As HttpPostedFile = upFile.PostedFile
        Dim dirPath As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "catalogoActividadesHP\"
        Dim extension As String = System.IO.Path.GetExtension(postedFile.FileName).ToLower()
        Dim fileName As String = "HP_" & tipoArchivo & "_" & objhp.id & extension

        postedFile.SaveAs(dirPath & fileName)

        If tipoArchivo = "formato" Then
            objhp.FileFormato = fileName
        Else
            objhp.FileEjemplo = fileName
        End If

        objhp.Update()

        Return True


    End Function
    Protected Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim mycahp As New Contenidos.CatalogoActividadHP(CInt(Request("idCatalogoActividadHP")))
        mycahp.Remove()

        Response.Redirect("ListaAC.aspx")

    End Sub
End Class
