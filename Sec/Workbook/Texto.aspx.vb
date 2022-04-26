
Partial Class Sec_Workbook_Texto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        If Not IsPostBack Then
            autorizacion()
            colocarDatos(myCI)
            colocarDatosEnCaja(myCI)
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



    Sub colocarDatos(ByRef myCI As Lego.ClasificacionItem)
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
            Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(myCI.idProc)
            txtid.Text = mycont.id
            txtTitulo.Text = mycont.titulo
            txttags.Text = mycont.Tags
            txtMensaje.Text = mycont.textoLargo
            Page.Title = mycont.titulo
            btnBorrar.Visible = True
        End If

    End Sub

    Sub colocarDatosEnCaja(ByRef myCI As Lego.ClasificacionItem)
        If Request("idCI") <> "" Then

            CUImagenes.ClaveFiltro1 = "Imagen"
            CUImagenes.ClaveFiltro2 = myCI.idProc
            CUImagenes.ClaveFiltro3 = myCI.procedencia.ToString

            CUArchivos.ClaveFiltro1 = "Archivo"
            CUArchivos.ClaveFiltro2 = myCI.idProc
            CUArchivos.ClaveFiltro3 = myCI.procedencia.ToString

            CULigas.ClaveFiltro1 = "Liga"
            CULigas.ClaveFiltro2 = myCI.idProc
            CULigas.ClaveFiltro3 = myCI.procedencia.ToString


            CUFlash.ClaveFiltro1 = "Flash"
            CUFlash.ClaveFiltro2 = myCI.idProc
            CUFlash.ClaveFiltro3 = myCI.procedencia.ToString
        End If

    End Sub


    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1000)
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.Remove()
        Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1000)
        Dim myci As Lego.ClasificacionItem
        If Page.IsValid Then
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    myci = editar()
                    Dim cadenaredirec As String = "Texto.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion
                    If Request("idSalonVirtual") <> "" Then
                        Response.Redirect("../SalonVirtual/verTexto.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                    Else
                        Response.Redirect(cadenaredirec)
                    End If

                Else
                    myci = grabar()
                    Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myci.idClasificacion)
                End If
            Else
                lblMensajeEspacio.Visible = True
            End If

        End If
    End Sub

    Function tieneEspacio() As Boolean
        Dim tiene As Boolean = True
        Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), True)

        Dim espacioDeEstosArchivos As Integer = 0

        If File1.PostedFile.FileName <> "" Then
            espacioDeEstosArchivos = File1.PostedFile.ContentLength
        End If
        If File2.PostedFile.FileName <> "" Then
            espacioDeEstosArchivos = espacioDeEstosArchivos + File2.PostedFile.ContentLength
        End If

        If espacioDeEstosArchivos > 0 Then
            espacioDeEstosArchivos = espacioDeEstosArchivos + myUser.espacioEnDiscoUsado
            If espacioDeEstosArchivos > myUser.espacioEnDisco Then
                tiene = False
            End If
        End If

        Return tiene
    End Function

    Function editar() As Lego.ClasificacionItem
        Dim myContenidos As Contenidos.Contenido = New Contenidos.Contenido(CInt(txtid.Text))
        myContenidos.Titulo = txtTitulo.Text.ToString
        myContenidos.Tags = txttags.Text
        myContenidos.TextoLargo = txtMensaje.Text
        myContenidos.fechaCreacion = Date.Now
        myContenidos.Tags = txttags.Text
        myContenidos.Update()


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

        subirArchivosyLigas(myContenidos)

        Return myCI

    End Function

    Function subirArchivosyLigas(ByVal myContenidos As Contenidos.Contenido) As Integer
        'seccion para subir archivos 
        Dim myCA As Contenidos.ContenidoAdjunto
        Dim myCont As Contenidos.Contenido
        If File1.PostedFile.FileName <> "" Then
            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myCont.postedFile = File1.PostedFile
            myCont.titulo = ""
            myCont.textoCorto = ""
            myCont.textoLargo = ""
            myContenidos.Tags = ""
            myCont.Add()

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = myContenidos.id
            myCA.Procedencia = myContenidos.tipo.ToString
            myCA.idContenido = myCont.id
            myCA.Add()

        End If
        If File2.PostedFile.FileName <> "" Then
            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myCont.postedFile = File2.PostedFile
            myCont.titulo = ""
            myCont.textoCorto = ""
            myCont.textoLargo = ""
            myCont.Tags = ""
            myCont.Add()

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = myContenidos.id
            myCA.Procedencia = myContenidos.tipo.ToString
            myCA.idContenido = myCont.id
            myCA.Add()
        End If

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

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        System.Threading.Thread.Sleep(1000)
        Dim clave As Integer
        If Page.IsValid Then
            If txtid.Text <> "" Then
                clave = CInt(Request("idCI"))
                editar()
            Else
                Dim myci As Lego.ClasificacionItem = grabar()
                clave = myCI.id
            End If

            Response.Redirect("verTexto.aspx?idRoot=" & Request("idRoot") & "&idCI=" & clave & "&Proc=Texto&idClasificacion=" & Request("idClasificacion"))
        End If

    End Sub
    


    
End Class
