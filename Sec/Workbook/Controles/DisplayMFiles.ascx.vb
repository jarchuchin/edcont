
Partial Class Sec_Workbook_Controles_DisplayMFiles
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatosEnCaja()
        End If
    End Sub



    Sub colocarDatosEnCaja()
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        drpUbicacion.DataSource = myc.ClasificacionesRoot(CInt(Request("idRoot")))
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

        If drpUbicacion.Items.Count < 0 Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        Dim i As Integer = 0
        For i = 0 To drpUbicacion.Items.Count - 1
            drpUbicacion.Items(i).Selected = False
            If drpUbicacion.Items(i).Value = Request("idClasificacion") Then
                drpUbicacion.Items(i).Selected = True
            End If
        Next


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo



        hdr.Value = myr.id
        hdu.Value = CInt(Session("gUserProfileSession").idUserProfile)
        hdc.Value = drpUbicacion.SelectedValue




    End Sub







    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click

        If Request("regreso") = "ex" Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        If Request("regreso") = "carpeta" Then
            Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
        End If


        Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If Request("regreso") = "ex" Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        If Request("regreso") = "carpeta" Then
            Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
        End If


        Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
    End Sub
    Protected Sub drpUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpUbicacion.SelectedIndexChanged
        hdc.Value = drpUbicacion.SelectedValue
    End Sub
End Class
