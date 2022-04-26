
Partial Class Sec_SalonVirtual_verArchivo
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Private Function getIdSalonVirtual() As Integer
        Dim idSalonVirtual As Integer
        Try
            idSalonVirtual = CInt(Request("idSalonVirtual"))
        Catch ex As Exception
            idSalonVirtual = 0
        End Try

        If idSalonVirtual < 0 Then idSalonVirtual = 0

        Return idSalonVirtual
    End Function

    Sub colocarDatos()
        Dim myci As Lego.ClasificacionItem
        Dim myc As Contenidos.Contenido
        Dim myclas As Lego.Clasificacion
        Dim idSalonVirtual As Integer = getIdSalonVirtual()


        If Request("idContenido") <> "" Then
            myci = New Lego.ClasificacionItem(CInt(Request("idCI")))
            myc = New Contenidos.Contenido(Request("idContenido"))
            myclas = New Lego.Clasificacion(Request("idClasificacion"))
        Else
            myci = New Lego.ClasificacionItem(CInt(Request("idCI")))
            myc = New Contenidos.Contenido(myci.idProc)
            myclas = New Lego.Clasificacion(myci.idClasificacion)
        End If


        Dim objRoot As New Lego.Root(myclas.idRoot)
        PanelEdicion.Visible = EsMaestro()
        lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/AddContenido.aspx?idRoot=" & myci.idRoot & "&idCI=" & myci.id & "&idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & myclas.id


        Page.Title = myc.titulo
        lblClasificacion.Text = myclas.titulo
        lblTitulo.Text = myc.titulo
        ' literalTextoLargo.Text = myc.textoLargo
        '  literalDescripcion.Text = objContenido.textoCorto.Replace(vbCrLf, "<br>")



        lblTags.Text = myc.Tags

        If myc.extension.ToLower = "pdf" Then
            litPdf.Text = "<object type=""application/pdf""  width=""100%"" height=""350px"" data=""../showfile.aspx?idCont=" & myc.id & "&down=1""><embed src=""../showfile.aspx?idCont=" & myc.id & "&down=1"" type=""application/pdf"" /></object>"
        End If

        litdescripcion.Text = myc.textoCorto & " " & myc.textoLargo
        lnkDescargar.NavigateUrl = "../showfile.aspx?idCont=" & myc.id
        lblNombreOriginal.Text = myc.nombreOriginal
        Dim myconv As Utilerias.Conversiones = New Utilerias.Conversiones

        lblbites.Text = myconv.Numeric2Bytes((Convert.ToDouble(myc.espacio)))


        PanelEdicion.Visible = EsMaestro()

        displayBuscadores2.Tags = myc.Tags
        displayBuscadores2.Titulo = myc.titulo

        displayComentarios1.claveidProc = myc.id
        displayComentarios1.claveProcedencia = myc.tipo.ToString


        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If PanelEdicion.Visible Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

        lnkUnidad.Text = myclas.titulo
        lnkUnidad.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & myclas.id
        lblCursoBread.Text = myc.titulo



        displayBuscadores2.Tags = myc.Tags
        displayBuscadores2.Titulo = myc.titulo



        'Bitacora de vista a contenidos
        Dim mybc As New Know.BitacoraContenido
        mybc.idProc = myc.id
        mybc.Procedencia = myc.tipo.ToString
        mybc.idSalonVirtual = mysv.id
        mybc.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mybc.ip = Request.UserHostAddress
        mybc.Browser = Request.Browser.Type & "-" & Request.Browser.Browser & "-" & Request.Browser.Platform & "-" & Request.Browser.Version
        mybc.Fecha = Date.Now
        mybc.Add()


    End Sub


    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function



End Class
