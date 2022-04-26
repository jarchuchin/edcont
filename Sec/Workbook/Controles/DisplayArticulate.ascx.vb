Imports Ionic.Zip

Partial Class Sec_Workbook_Controles_DisplayArticulate
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

            Dim pathserver As String = Request.Url.GetLeftPart(UriPartial.Authority) & HttpRuntime.AppDomainAppVirtualPath
            pathserver = pathserver & "/sec/liteContent/" & mycont.id & "/" & mycont.nombreOriginal

            lnkDownload.NavigateUrl = pathserver
            lblNombreOriginal.Text = mycont.nombreOriginal
            lblEspacio.Text = (Convert.ToDouble(mycont.espacio) / 1000) & "kb"

            lblEspacio.Visible = True
            lnkDownload.Visible = True
            lblNombreOriginal.Visible = True

            btnBorrar.Visible = True
            lnkVistaPrevia.Enabled = True
            lnkVistaPrevia.NavigateUrl = "~/Sec/Workbook/verCarpeta.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idSalonVirtual=" & Request("idSalonVirtual")



            Literal1.Text = "<iframe src=""" & mycont.url & """ width=""700px"" height=""550px"" ></iframe>"

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
            Dim esZip As Boolean
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    If File1.PostedFile.FileName <> "" Then
                        esZip = File1.PostedFile.FileName.ToLower.Contains(".zip")
                        If esZip Then

                            editar()
                        Else
                            lblNoarchivo.Visible = True
                        End If
                    Else
                        editar()
                    End If

                Else
                    If File1.PostedFile.FileName <> "" Then
                        esZip = File1.PostedFile.FileName.ToLower.Contains(".zip")

                        If esZip Then
                            grabar()
                        Else

                            lblNoarchivo.Visible = True
                        End If
                    Else
                        lblNoarchivo.Visible = True
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
            '    myContenidos.postedFile = File1.PostedFile
            'borrar contenido anterioror
            Dim filePath As String = ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\liteContent\"
            '  Dim mysubdir As New System.IO.DirectoryInfo(filePath & myContenidos.id)
            '      System.IO.Directory.Delete(filePath & myContenidos.id, True)

            myContenidos.url = ColocarZip(myContenidos)
            myContenidos.nombreOriginal = nombreOriginalLocal
            myContenidos.espacio = espacioLocal
        End If
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()



        Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Acticulate&idClasificacion=" & myCI.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myCI.id)
        End If

        Response.Redirect(cadenaredirec)

    End Sub

    Sub grabar()
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido
        myContenidos.idTipoContenido = Contenidos.TipoContenido.Articulate
        myContenidos.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        ' myContenidos.postedFile = File1.PostedFile
        myContenidos.Titulo = txtTitulo.Text.ToString
        myContenidos.TextoCorto = txtTextoCorto.Text
        myContenidos.TextoLargo = ""

        myContenidos.tipoArchivo = ""
        myContenidos.Extension = ""
        myContenidos.url = ""
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.nombreOriginal = ""
        myContenidos.Add()

        myContenidos.url = ColocarZip(myContenidos)
        myContenidos.nombreOriginal = nombreOriginalLocal
        myContenidos.espacio = espacioLocal

        myContenidos.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myContenidos.id
        myCI.procedencia = myContenidos.tipo
        myCI.Add()



        Dim cadenaredirec As String = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Acticulate&idClasificacion=" & myCI.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"
        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/SalonVirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myCI.id)
        End If

        Response.Redirect(cadenaredirec)

    End Sub

    Dim nombreOriginalLocal As String = ""
    Dim espacioLocal As Integer = 0

    Public Function ColocarZip(mycont As Contenidos.Contenido) As String

        Dim filePath As String = ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\liteContent\"
        ' Dim filePathTemp As String = ConfigurationManager.AppSettings("carpetaPrincipal") & "productos\images\temp\"
        Dim fileNameZip As String = File1.PostedFile.FileName.Substring((File1.PostedFile.FileName.LastIndexOf("\") + 1)).ToLower
        Dim filePathName As String = filePath & mycont.id & "\" & fileNameZip
        Dim nombreCarpeta As String = mycont.id
        Dim mydirInfor As New System.IO.DirectoryInfo(filePath)
        If mydirInfor.Exists Then

            Dim mysubdir As New System.IO.DirectoryInfo(filePath & mycont.id & "\")
            If Not mysubdir.Exists Then
                mydirInfor.CreateSubdirectory(mycont.id.ToString)
            End If

        End If
        espacioLocal = File1.PostedFile.ContentLength
        File1.PostedFile.SaveAs(filePathName)


        Dim regreso As String = ""

        Using varZip As ZipFile = ZipFile.Read(filePathName)
            For Each entry As ZipEntry In varZip
                entry.Extract(filePath & mycont.id & "\", ExtractExistingFileAction.OverwriteSilently)
                If entry.FileName.ToLower.Contains("/player.html") Then
                    regreso = entry.FileName
                End If
                If entry.FileName.ToLower.Contains("/story.html") Then
                    regreso = entry.FileName
                End If
            Next
        End Using

        If regreso = "" Then
            If System.IO.File.Exists(filePath & mycont.id & "\" & "story.html") Then
                regreso = "story.html"
            End If
            If System.IO.File.Exists(filePath & mycont.id & "\" & "player.html") Then
                regreso = "player.html"
            End If
        End If


        Dim pathserver As String = Request.Url.GetLeftPart(UriPartial.Authority) & HttpRuntime.AppDomainAppVirtualPath
        pathserver = pathserver & "/sec/liteContent/" & mycont.id & "/" & regreso

        nombreOriginalLocal = fileNameZip
     
        Return pathserver




    End Function

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
