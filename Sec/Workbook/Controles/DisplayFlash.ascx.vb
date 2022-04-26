
Partial Class Sec_Workbook_Controles_DisplayFlash
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            txturl.Text = mycont.url
            txtancho.Text = mycont.ancho
            txtalto.Text = mycont.alto
            txttags.Text = mycont.Tags

            Dim cadena As String = txtbase.Text
            If mycont.url <> "" Then
                cadena = cadena.Replace("pelicula", mycont.url)
            Else
                cadena = cadena.Replace("pelicula", "../showfile.aspx?idCont=" & mycont.id)
                lnkDownload.NavigateUrl = "~/showfile.aspx?idCont=" & mycont.id & "&down=1"
                lblNombreOriginal.Text = mycont.nombreOriginal
                lblEspacio.Text = (Convert.ToDouble(mycont.espacio) / 1000) & "kb"
                lblEspacio.Visible = True
                lnkDownload.Visible = True
                lblNombreOriginal.Visible = True
            End If

            cadena = cadena.Replace("cancho", mycont.ancho.ToString)
            cadena = cadena.Replace("calto", mycont.alto.ToString)

            litflas.Text = cadena
            litflas.Visible = True
            btnBorrar.Visible = True
            lnkVistaPrevia.Visible = True
            lnkVistaPrevia.NavigateUrl = "~/Sec/Workbook/verCarpeta.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idSalonVirtual=" & Request("idSalonVirtual")
        Else
            lnkVistaPrevia.Visible = False

        End If


    End Sub

    Protected Sub CustomValidator1_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If txtTextoCorto.Text.Length > 1000 Then
            args.IsValid = False
        Else
            args.IsValid = True
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
        System.Threading.Thread.Sleep(1500)
        If Page.IsValid Then
            Dim myci As Lego.ClasificacionItem
            If tieneEspacio() Then

                If txtid.Text <> "" Then
                    If File1.PostedFile.FileName <> "" Then
                        Dim extension As String = ""
                        Dim inicioExtension As Integer = File1.PostedFile.FileName.LastIndexOf(".")
                        If inicioExtension > -1 Then
                            extension = File1.PostedFile.FileName.Substring(inicioExtension + 1)
                        End If
                        If extension.ToLower <> "swf" Then
                            lblNoarchivo.Visible = True
                            alertSuccess.Visible = False
                        Else
                            myci = editar()
                            Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Flash&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
                            If Request("idSalonVirtual") <> "" Then
                                Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                            End If

                            Response.Redirect(cadenaredirec)
                        End If
                    Else
                        myci = editar()
                        Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Flash&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
                        If Request("idSalonVirtual") <> "" Then
                            Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                        End If

                        Response.Redirect(cadenaredirec)
                    End If

                Else 'else txtid.text
                    If File1.PostedFile.FileName <> "" Then
                        Dim extension As String = ""
                        Dim inicioExtension As Integer = File1.PostedFile.FileName.LastIndexOf(".")
                        If inicioExtension > -1 Then
                            extension = File1.PostedFile.FileName.Substring(inicioExtension + 1)
                        End If
                        If extension.ToLower <> "swf" Then
                            lblNoarchivo.Visible = True
                            alertSuccess.Visible = False
                        Else
                            myci = grabar()
                            Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Flash&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
                            If Request("idSalonVirtual") <> "" Then
                                Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                            End If

                            Response.Redirect(cadenaredirec)
                        End If
                    Else
                        If txtUrl.Text <> "" Then
                            myci = grabar()
                            Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Flash&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
                            If Request("idSalonVirtual") <> "" Then
                                Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                            End If

                            Response.Redirect(cadenaredirec)
                        Else
                            lblNoarchivo.Visible = True
                            alertSuccess.Visible = False
                        End If

                    End If

                End If 'termina if txtid.text
            Else 'else tieneespacio
                lblMensajeEspacio.Visible = True
                alertSuccess.Visible = False
            End If 'termina if tieneespacio

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

    Function editar() As Lego.ClasificacionItem
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido(CInt(txtid.Text))
        myContenidos.Titulo = txtTitulo.Text.ToString
        myContenidos.TextoCorto = txtTextoCorto.Text
        myContenidos.url = txtUrl.Text
        myContenidos.Alto = CInt(txtAlto.Text)
        myContenidos.Ancho = CInt(txtAncho.Text)
        If File1.PostedFile.FileName <> "" Then
            myContenidos.postedFile = File1.PostedFile
        End If
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        Return myCI
    End Function

    Function grabar() As Lego.ClasificacionItem
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido
        myContenidos.idTipoContenido = Contenidos.TipoContenido.Flash
        myContenidos.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myContenidos.alto = CInt(txtAlto.Text)
        myContenidos.ancho = CInt(txtAncho.Text)
        If File1.PostedFile.FileName <> "" Then
            myContenidos.postedFile = File1.PostedFile
        End If
        myContenidos.titulo = txtTitulo.Text.ToString
        myContenidos.textoCorto = txtTextoCorto.Text
        myContenidos.textoLargo = ""
        myContenidos.nombreOriginal = ""
        myContenidos.tipoArchivo = ""
        myContenidos.extension = ""
        myContenidos.url = txtUrl.Text
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Add()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myContenidos.id
        myCI.procedencia = myContenidos.tipo
        myCI.Add()

        Return myCI

    End Function


    Private Sub CustomValidator2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        If IsNumeric(txtAncho.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Private Sub CustomValidator3_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator3.ServerValidate
        If IsNumeric(txtAlto.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub




    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        If Request("regreso") = "ex" Then
            Response.Redirect("~/sec/workbook/Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
    End Sub
End Class
