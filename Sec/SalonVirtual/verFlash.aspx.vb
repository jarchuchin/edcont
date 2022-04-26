
Partial Class Sec_SalonVirtual_verFlash
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        Dim myc As Contenidos.Contenido = New Contenidos.Contenido(myci.idProc)
        lblTitulo.Text = myc.titulo
        Page.Title = myc.titulo
        litdescripcion.Text = myc.textoCorto & " " & myc.textoLargo
        lnkDescargar.NavigateUrl = "../showfile.aspx?idCont=" & myc.id
        lblNombreOriginal.Text = myc.nombreOriginal
        Dim myconv As Utilerias.Conversiones = New Utilerias.Conversiones

        lblbites.Text = myconv.Numeric2Bytes((Convert.ToDouble(myc.espacio)))




        Dim cadenabase As String = txtbase.Text
        If myc.url <> "" Then
            cadenabase = cadenabase.Replace("pelicula", myc.url)
            lblbites.Visible = False
            lnkDescargar.Visible = False
        Else
            cadenabase = cadenabase.Replace("pelicula", "../showfile.aspx?idCont=" & myc.id)
            lnkDescargar.NavigateUrl = "../showfile.aspx?idCont=" & myc.id & "&down=1"
            lblNombreOriginal.Text = myc.nombreOriginal
            lblbites.Visible = True
            lnkDescargar.Visible = True
            lblNombreOriginal.Visible = True
        End If

        cadenabase = cadenabase.Replace("cancho", myc.ancho.ToString)
        cadenabase = cadenabase.Replace("calto", myc.alto.ToString)

        litflas.Text = cadenabase
        litflas.Visible = True


        PanelEdicion.Visible = EsMaestro()

        displayBuscadores1.Tags = myc.Tags
        displayBuscadores1.Titulo = myc.titulo

        displayComentarios1.claveidProc = myc.id
        displayComentarios1.claveProcedencia = myc.tipo.ToString

        Dim myclas As New Lego.Clasificacion(myci.idClasificacion)
        If myclas.Imagen1 <> "" Then
            imagenClasificacion.Visible = True
            imagenClasificacion.Visible = True
            imagenClasificacion.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & myclas.id & "&num=1"
        End If

        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

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

    Protected Sub btnEditarActividad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditarActividad.Click
        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Response.Redirect("../workbook/Flash.aspx?idRoot=" & mysalonVirtual.idRoot & "&idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub

End Class
