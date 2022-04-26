
Partial Class Sec_Workbook_Controles_DisplayArchivo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatosEnCaja()
        End If
    End Sub



    Sub colocarDatosEnCaja()


        If Request("grabado") = "1" Then
            alertSuccess.Visible = True
        End If

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

        If Request("idCI") <> "" Then
            Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

            Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(myCI.idProc)
            txtid.Text = mycont.id
            txtTitulo.Text = mycont.titulo
            txtTextoCorto.Text = mycont.textoCorto
            Page.Title = mycont.titulo
            txttags.Text = mycont.Tags

            lnkDownload.NavigateUrl = "~\sec\showfile.aspx?idCont=" & mycont.id
            lblNombreOriginal.Text = mycont.nombreOriginal
            lblEspacio.Text = (Convert.ToDouble(mycont.espacio) / 1000) & "kb"

            lblEspacio.Visible = True
            lnkDownload.Visible = True
            lblNombreOriginal.Visible = True

            btnBorrar.Visible = True
            '  lnkVistaPrevia.Visible = True
            lnkVistaPrevia.NavigateUrl = "~/Sec/Workbook/verCarpeta.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idSalonVirtual=" & Request("idSalonVirtual")



            If mycont.extension.ToLower = "pdf" Then
                litpdf.Text = "<object type=""application/pdf""  width=""100%"" height=""350px"" data=""../showfile.aspx?idCont=" & mycont.id & "&down=1""><embed src=""../showfile.aspx?idCont=" & mycont.id & "&down=1"" type=""application/pdf"" /></object>"
            End If

        Else
            lnkVistaPrevia.Visible = False
        End If


    End Sub


    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.Remove()


        If Request("regreso") = "ex" Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(5000)
        If Page.IsValid Then
            Dim esImagen As Boolean
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    If File1.PostedFile.FileName <> "" Then
                        esImagen = System.Text.RegularExpressions.Regex.IsMatch(File1.PostedFile.ContentType, "image/\S+")
                        If esImagen Then
                            lblNoarchivo.Visible = True
                            alertSuccess.Visible = False
                        Else
                            editar()
                        End If
                    Else
                        editar()
                    End If

                Else
                    If File1.PostedFile.FileName <> "" Then
                        esImagen = System.Text.RegularExpressions.Regex.IsMatch(File1.PostedFile.ContentType, "image/\S+")

                        If esImagen Then
                            lblNoarchivo.Visible = True
                            alertSuccess.Visible = False
                        Else
                            grabar()
                        End If
                    Else
                        lblNoarchivo.Visible = True
                        alertSuccess.Visible = False
                    End If

                End If  'termina txtid
            Else
                lblMensajeEspacio.Visible = True
            End If ' termina tieneespacio()

        End If
    End Sub

    Function tieneEspacio() As Boolean
        Dim tiene As Boolean = True
        'Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), True)

        'Dim espacioDeEstosArchivos As Integer = 0

        'If File1.PostedFile.FileName <> "" Then
        '    espacioDeEstosArchivos = File1.PostedFile.ContentLength
        '    espacioDeEstosArchivos = espacioDeEstosArchivos + myUser.espacioEnDiscoUsado
        '    If espacioDeEstosArchivos > myUser.espacioEnDisco Then
        '        tiene = False
        '    End If
        'End If



        Return tiene
    End Function

    Sub editar()
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido(CInt(txtid.Text))
        myContenidos.Titulo = txtTitulo.Text.ToString
        myContenidos.TextoCorto = txtTextoCorto.Text
        If File1.PostedFile.FileName <> "" Then
            myContenidos.postedFile = File1.PostedFile
        End If
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Archivo&idClasificacion=" & myCI.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myCI.id)
        End If

        Response.Redirect(cadenaredirec)
    End Sub

    Sub grabar()
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido
        myContenidos.idTipoContenido = Contenidos.TipoContenido.Archivo
        myContenidos.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myContenidos.postedFile = File1.PostedFile
        myContenidos.Titulo = txtTitulo.Text.ToString
        myContenidos.TextoCorto = txtTextoCorto.Text
        myContenidos.TextoLargo = ""
        myContenidos.nombreOriginal = ""
        myContenidos.tipoArchivo = ""
        myContenidos.Extension = ""
        myContenidos.url = ""
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Add()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myContenidos.id
        myCI.procedencia = myContenidos.tipo
        myCI.Add()


        Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Archivo&idClasificacion=" & myCI.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"

        Response.Redirect(cadenaredirec)

    End Sub






    Protected Sub CustomValidator1_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If txtTextoCorto.Text.Length > 1000 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub
    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click

        If Request("regreso") = "ex" Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
    End Sub
End Class
