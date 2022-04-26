
Partial Class Sec_SalonVirtual_verTexto
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			colocarDatos()
		End If
	End Sub

	Sub colocarDatos()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idCI As Integer = getIdCI()

		Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
		Dim objClasificacion As New Lego.Clasificacion(objClasificacionItem.idClasificacion)
		Dim objContenido As Contenidos.Contenido = New Contenidos.Contenido(objClasificacionItem.idProc)


        panelEdicion.Visible = EsMaestro()
		lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/AddContenido.aspx?idRoot=" & objClasificacionItem.idRoot & "&idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id

		Page.Title = objContenido.titulo
		lblClasificacion.Text = objClasificacion.titulo
		lblTitulo.Text = objContenido.titulo
        literalTextoLargo.Text = objContenido.textoLargo
        '  literalDescripcion.Text = objContenido.textoCorto.Replace(vbCrLf, "<br>")

        panelSugerencias.Visible = panelEdicion.Visible

        lbltags.Text = objContenido.Tags
        lblSugerencias.Text = objContenido.ParaInstructor


        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If panelEdicion.Visible Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

        lnkUnidad.Text = objClasificacion.titulo
        lnkUnidad.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id
        lblCursoBread.Text = objContenido.titulo
        lblNombreTitulo.Text = objContenido.titulo


        pasaDatosACajitas(objContenido, showContenidos, Contenidos.TipoContenido.Texto)
        pasaDatosACajitas(objContenido, showarchivosAdjuntos, Contenidos.TipoContenido.Archivo)
		pasaDatosACajitas(objContenido, showimagenesAdjuntos, Contenidos.TipoContenido.Imagen)
		pasaDatosACajitas(objContenido, Showflashes, Contenidos.TipoContenido.Flash)
		pasaDatosACajitas(objContenido, showdirecciones, Contenidos.TipoContenido.Liga)

		displayComentarios1.claveidProc = objContenido.id
        displayComentarios1.claveProcedencia = objContenido.tipo.ToString
        Dim cadenaFlash As String
        If objContenido.url <> "" Then
            If objContenido.url.ToLower.Contains("http") Then
                If objContenido.url.Trim <> "" Then
                    cadenaFlash = "<iframe width=""100%"" height=""420"" src=""" & objContenido.url & """></iframe><div style=""height:10px;""></div><a href=""" & objContenido.url & """ target=""_blank"" >Ver pantalla completa</a>"
                Else
                    cadenaFlash = "<br/>"
                End If

                literalUrlFrameBox.Text = cadenaFlash
            End If
        End If



        displayBuscadores1.Tags = objContenido.Tags
        displayBuscadores1.Titulo = objContenido.titulo


        'Bitacora de vista a contenidos
        Dim mybc As New Know.BitacoraContenido
        mybc.idProc = objContenido.id
        mybc.Procedencia = objContenido.tipo.ToString
        mybc.idSalonVirtual = mysv.id
        mybc.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mybc.ip = Request.UserHostAddress
        mybc.Browser = Request.Browser.Type & "-" & Request.Browser.Browser & "-" & Request.Browser.Platform & "-" & Request.Browser.Version
        mybc.Fecha = Date.Now
        mybc.Add()



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

	Private Function getIdCI() As Integer
		Dim idCI As Integer
		Try
			idCI = CInt(Request("idCI"))
		Catch ex As Exception
			idCI = 0
		End Try

		If idCI < 0 Then idCI = 0

		Return idCI
	End Function

	Private Sub pasaDatosACajitas(ByRef objContenido As Contenidos.Contenido, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
		With control
			.idproc = objContenido.id
			.procedencia = objContenido.tipo.ToString
			.tipoAdjunto = tipo
		End With
	End Sub

	Public Function EsMaestro() As Boolean
		Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
		Dim objUserProfile As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
		Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

		Return objPermiso.existe
    End Function



End Class
