
Partial Class Sec_Workbook_Controles_DisplayLectura
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        If Not IsPostBack Then
            colocarDatos(myCI)
        End If
    End Sub





    Sub colocarDatos(ByRef myCI As Lego.ClasificacionItem)


        If Request("grabado") = "1" Then
            alertSuccess.Visible = True
        End If

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


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo


        If Request("idCI") <> "" Then
            Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(myCI.idProc)
            Dim mycontDraft As Contenidos.ContenidoDraft = New Contenidos.ContenidoDraft(myCI.idProc, True)

            txtid.Text = mycont.id

            If mycontDraft.existe Then
                txtTitulo.Text = mycontDraft.titulo
                txttags.Text = mycontDraft.Tags
                txtparaInstructor.Text = mycontDraft.ParaInstructor
                ' lblTitulo.Text = mycont.textoLargo
                txtMensaje.Text = mycontDraft.textoLargo
                txturl.Text = mycontDraft.url

                lblMensajePublicar.Visible = True
                btnPublicar.Visible = True
            Else

                txtTitulo.Text = mycont.titulo
                txttags.Text = mycont.Tags
                txtparaInstructor.Text = mycont.ParaInstructor
                ' lblTitulo.Text = mycont.textoLargo
                txtMensaje.Text = mycont.textoLargo
                txturl.Text = mycont.url


                lblMensajePublicar.Visible = False
                btnPublicar.Visible = False
            End If







            Page.Title = mycont.titulo
            btnBorrar.Visible = True


            lnkVistaPrevia.Enabled = True
            lnkVistaPrevia.NavigateUrl = "~/Sec/Workbook/verTexto.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id & "&idSalonVirtual=" & Request("idSalonVirtual")


            hdc.Value = mycont.id
            hdUs.Value = CInt(Session("gUserProfileSession").idUserProfile)



            Dim cadena As New StringBuilder
            cadena.AppendLine("<script type=""text/javascript"" >")
            cadena.AppendLine("$(document).ready(function () {")
            cadena.AppendLine("$(""#fileuploader"").uploadFile({")
            cadena.AppendLine(" url: ""Upload.ashx?idus="" + document.getElementById(""hdUs"").value + ""&idc="" + document.getElementById(""hdc"").value,")
            cadena.AppendLine("fileName: ""myfile"",")
            cadena.AppendLine("dragDrop: true,")
            cadena.AppendLine("afterUploadAll: function (obj) {")
            cadena.AppendLine("$('#btnRefrescar').click();")
            cadena.AppendLine("}")
            cadena.AppendLine("});")
            cadena.AppendLine("});")
            cadena.AppendLine("</script>")

            litScript.Text = cadena.ToString


            rowAdjuntos.Visible = True
            lnkVistaPrevia.Visible = True
        Else
            rowAdjuntos.Visible = False
            lnkVistaPrevia.Visible = False

            btnPublicar.Visible = False
        End If

    End Sub




    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.Remove()

        'Dim myc As New Contenidos.Contenido(myCI.idProc)
        'myc.Remove()

        Response.Redirect("~/sec/workbook/addcontenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim myci As Lego.ClasificacionItem
        If Page.IsValid Then
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    myci = editar()
                    Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"



                    If Request("idSalonVirtual") <> "" Then
                        myci = publicar()
                        Response.Redirect("~/sec/SalonVirtual/verTexto.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                    Else
                        Response.Redirect(cadenaredirec)
                    End If

                Else
                    myci = grabar()

                    Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"

                    Response.Redirect(cadenaredirec)
                End If
            Else
                lblMensajeEspacio.Visible = True
            End If

        End If
    End Sub

    Function tieneEspacio() As Boolean
        Dim tiene As Boolean = True
        'Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), True)

        'Dim espacioDeEstosArchivos As Integer = 0

        'If File1.PostedFile.FileName <> "" Then
        '    espacioDeEstosArchivos = File1.PostedFile.ContentLength
        'End If
        'If File2.PostedFile.FileName <> "" Then
        '    espacioDeEstosArchivos = espacioDeEstosArchivos + File2.PostedFile.ContentLength
        'End If

        'If espacioDeEstosArchivos > 0 Then
        '    espacioDeEstosArchivos = espacioDeEstosArchivos + myUser.espacioEnDiscoUsado
        '    If espacioDeEstosArchivos > myUser.espacioEnDisco Then
        '        tiene = False
        '    End If
        'End If

        Return tiene
    End Function

    Function editar() As Lego.ClasificacionItem

        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido(CInt(txtid.Text))
        Dim mycd As New Contenidos.ContenidoDraft(CInt(txtid.Text), True)

        mycd.idContenido = myContenidos.id
        mycd.idTipoContenido = Contenidos.TipoContenido.Texto
        mycd.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mycd.titulo = txtTitulo.Text.ToString
        mycd.textoCorto = ""
        mycd.Tags = txttags.Text
        mycd.textoLargo = txtMensaje.Text
        mycd.espacio = 0
        mycd.nombreOriginal = ""
        mycd.tipoArchivo = ""
        mycd.extension = ""
        mycd.url = txturl.Text
        mycd.fechaCreacion = Date.Now
        mycd.Tags = txttags.Text
        mycd.ParaInstructor = txtparaInstructor.Text
        mycd.Activo = True

        If mycd.existe Then
            mycd.Update()
        Else
            mycd.Add()
        End If


        'myContenidos.titulo = txtTitulo.Text.ToString
        'myContenidos.Tags = txttags.Text
        'myContenidos.textoLargo = txtMensaje.Text
        'myContenidos.fechaCreacion = Date.Now
        'myContenidos.Tags = txttags.Text
        'myContenidos.url = txturl.Text
        'myContenidos.ParaInstructor = txtparaInstructor.Text
        'myContenidos.Update()


        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        subirArchivosyLigas(myContenidos)



        Return myCI
    End Function

    Function publicar() As Lego.ClasificacionItem
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido(CInt(txtid.Text))
        myContenidos.titulo = txtTitulo.Text.ToString
        myContenidos.Tags = txttags.Text
        myContenidos.textoLargo = txtMensaje.Text
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.url = txturl.Text
        myContenidos.ParaInstructor = txtparaInstructor.Text
        myContenidos.Update()

        Dim myContenidosDraft As Contenidos.ContenidoDraft = New Contenidos.ContenidoDraft(CInt(txtid.Text), True)
        myContenidosDraft.titulo = txtTitulo.Text.ToString
        myContenidosDraft.Tags = txttags.Text
        myContenidosDraft.textoLargo = txtMensaje.Text
        myContenidosDraft.fechaCreacion = Date.Now
        myContenidosDraft.Tags = txttags.Text
        myContenidosDraft.url = txturl.Text
        myContenidosDraft.ParaInstructor = txtparaInstructor.Text
        myContenidosDraft.Activo = False
        myContenidosDraft.Update()


        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        subirArchivosyLigas(myContenidos)


        Return myCI

    End Function

    Function grabar() As Lego.ClasificacionItem
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido
        myContenidos.idTipoContenido = Contenidos.TipoContenido.Texto
        myContenidos.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myContenidos.titulo = txtTitulo.Text.ToString
        myContenidos.textoCorto = ""
        myContenidos.Tags = txttags.Text
        myContenidos.textoLargo = txtMensaje.Text
        myContenidos.espacio = 0
        myContenidos.nombreOriginal = ""
        myContenidos.tipoArchivo = ""
        myContenidos.extension = ""
        myContenidos.url = txturl.Text
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.ParaInstructor = txtparaInstructor.Text
        myContenidos.Add()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myContenidos.id
        myCI.procedencia = myContenidos.tipo
        myCI.Add()

        subirArchivosyLigas(myContenidos)

        Return myCI

    End Function

    Function subirArchivosyLigas(ByVal myContenidos As Contenidos.Contenido) As Integer
        'seccion para subir archivos 
        Dim myCA As Contenidos.ContenidoAdjunto
        Dim myCont As Contenidos.Contenido
        'If File1.PostedFile.FileName <> "" Then
        '    myCont = New Contenidos.Contenido
        '    myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        '    myCont.postedFile = File1.PostedFile
        '    myCont.titulo = ""
        '    myCont.textoCorto = ""
        '    myCont.textoLargo = ""
        '    myCont.Tags = ""
        '    myCont.Add()

        '    myCA = New Contenidos.ContenidoAdjunto
        '    myCA.idProc = myContenidos.id
        '    myCA.Procedencia = myContenidos.tipo.ToString
        '    myCA.idContenido = myCont.id
        '    myCA.Add()

        'End If
        'If File2.PostedFile.FileName <> "" Then
        '    myCont = New Contenidos.Contenido
        '    myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        '    myCont.postedFile = File2.PostedFile
        '    myCont.titulo = ""
        '    myCont.textoCorto = ""
        '    myCont.textoLargo = ""
        '    myCont.Tags = ""
        '    myCont.Add()

        '    myCA = New Contenidos.ContenidoAdjunto
        '    myCA.idProc = myContenidos.id
        '    myCA.Procedencia = myContenidos.tipo.ToString
        '    myCA.idContenido = myCont.id
        '    myCA.Add()
        'End If

        If txtLigatitulo.Text <> "" And txtLigaurl.Text <> "" Then
            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myCont.idTipoContenido = Contenidos.TipoContenido.Liga
            myCont.titulo = txtLigatitulo.Text
            myCont.textoCorto = ""
            myCont.textoLargo = ""
            myCont.espacio = 0
            myCont.nombreOriginal = ""
            myCont.tipoArchivo = ""
            myCont.extension = ""
            myCont.url = txtLigaurl.Text
            myCont.fechaCreacion = Date.Now
            myCont.Tags = ""
            myCont.Add()

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = myContenidos.id
            myCA.Procedencia = myContenidos.tipo.ToString
            myCA.idContenido = myCont.id
            myCA.Add()

        End If

    End Function

    'Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    System.Threading.Thread.Sleep(1000)
    '    Dim clave As Integer
    '    If Page.IsValid Then
    '        If txtid.Text <> "" Then
    '            clave = CInt(Request("idCI"))
    '            editar()
    '        Else
    '            Dim myci As Lego.ClasificacionItem = grabar()
    '            clave = myCI.id
    '        End If

    '        Response.Redirect("~/sec/workbook/preview.aspx?idRoot=" & Request("idRoot") & "&idCI=" & clave & "&Proc=Texto&idClasificacion=" & Request("idClasificacion"))
    '    End If

    'End Sub


    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        If Request("regreso") = "carpeta" Then
            Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
        End If

        Response.Redirect("~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot"))
    End Sub
    Protected Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        editar()

        '    Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion

        Response.Redirect("~/sec/workbook/addcontenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Texto&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1")

    End Sub
    Protected Sub btnGrabarLiga_Click(sender As Object, e As EventArgs) Handles btnGrabarLiga.Click
        Dim myci As Lego.ClasificacionItem
        If Page.IsValid Then
            If tieneEspacio() Then
                myci = editar()
                Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"


                Response.Redirect(cadenaredirec)


            End If
        End If

    End Sub
    Protected Sub btnPublicar_Click(sender As Object, e As EventArgs) Handles btnPublicar.Click
        Dim myci As Lego.ClasificacionItem

        myci = publicar()

        Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion & "&regreso=" & Request("regreso") & "&grabado=1"



        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/SalonVirtual/verTexto.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
        Else
            Response.Redirect(cadenaredirec)
        End If



    End Sub
End Class
