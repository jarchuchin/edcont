
Partial Class Sec_Workbook_Imagen
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            autorizacion
            colocarDatosEnCaja()
        End If
    End Sub




    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Sub colocarDatosEnCaja()

        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        drpUbicacion.DataSource = myc.ClasificacionesRoot(CInt(Request("idRoot")))
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

        If drpUbicacion.Items.Count < 0 Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        Dim i As Integer = 0
        For i = 0 To drpUbicacion.Items.Count - 1
            drpUbicacion.Items(i).Selected = False
            If drpUbicacion.Items(i).Value = Request("idClasificacion") Then
                drpUbicacion.Items(i).Selected = True
            End If
        Next

        If Request("idCI") <> "" Then
            Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

            Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(myCI.idProc)
            txtid.Text = mycont.id
            txtTitulo.Text = mycont.titulo
            txtTextoCorto.Text = mycont.textoCorto
            Page.Title = mycont.titulo
            txttags.Text = mycont.Tags

            lnkDownload.NavigateUrl = "~/sec/showfile.aspx?idCont=" & mycont.id
            lblNombreOriginal.Text = mycont.nombreOriginal
            lblEspacio.Text = (Convert.ToDouble(mycont.espacio) / 1000) & "kb"

            Imagen.ImageUrl = "~/sec/showfile.aspx?idCont=" & mycont.id
            Imagen.Visible = True
            lblEspacio.Visible = True
            lnkDownload.Visible = True
            lblNombreOriginal.Visible = True

            btnBorrar.Visible = True

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
        Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Page.IsValid Then
            Dim esImagen As Boolean
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    If File1.PostedFile.FileName <> "" Then
                        esImagen = System.Text.RegularExpressions.Regex.IsMatch(File1.PostedFile.ContentType, "image/\S+")
                        If Not esImagen Then
                            lblNoarchivo.Visible = True
                        Else
                            editar()
                        End If
                    Else
                        editar()
                    End If

                Else
                    If File1.PostedFile.FileName <> "" Then
                        esImagen = System.Text.RegularExpressions.Regex.IsMatch(File1.PostedFile.ContentType, "image/\S+")

                        If Not esImagen Then
                            lblNoarchivo.Visible = True
                        Else
                            grabar()
                        End If
                    Else
                        lblNoarchivo.Visible = True
                    End If
                End If
            Else
                lblMensajeEspacio.Visible = True
            End If ' termina tieneespacio

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



        Dim cadenaredirec As String = "Imagen.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Imagen&idClasificacion=" & myCI.idClasificacion
        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("../SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myCI.id)
        Else
            Response.Redirect(cadenaredirec)
        End If
    End Sub

    Sub grabar()
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido
        myContenidos.idTipoContenido = Contenidos.TipoContenido.Imagen
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


        Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)

    End Sub


    
End Class
