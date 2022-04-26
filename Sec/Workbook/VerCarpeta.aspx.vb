
Partial Class Sec_SalonVirtual_VerCarpeta
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		IndiceClasificacion1.modoEdicion = False
		If Not IsPostBack Then
			llenado()
		End If
	End Sub

	Sub llenado()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idClasificacion As Integer = getIdClasificacion()
		Dim objClasificacion As Lego.Clasificacion

		If idClasificacion > 0 Then
			objClasificacion = New Lego.Clasificacion(idClasificacion)
		Else
			objClasificacion = New Lego.Clasificacion(idSalonVirtual, True)
		End If

		idClasificacion = objClasificacion.id

		Dim objRoot As New Lego.Root(objClasificacion.idRoot)

		If idSalonVirtual > 0 Then
			lnkSalir.NavigateUrl = "~/Sec/Workbook/AddCarpeta.aspx?idRoot=" & objRoot.id & "&idClasificacion=" & objClasificacion.id & "&idSalonVirtual=" & idSalonVirtual
		Else
			lnkSalir.NavigateUrl = "~/Sec/Workbook/AddCarpeta.aspx?idRoot=" & objRoot.id & "&idClasificacion=" & objClasificacion.id
		End If

		Page.Title = objClasificacion.titulo
		lnkPaginaPrincipalCurso.Text = objRoot.titulo
		lblClasificacion.Text = objClasificacion.titulo
		lblTitulo.Text = objClasificacion.titulo
		literalTexto.Text = objClasificacion.texto
        literalPlanteamientoBreve.Text = objClasificacion.PlanteamientoBreve.Replace(vbCrLf, "<br/>")

		Dim objObjetivo As New Lego.Objetivo
		listViewObjetivos.DataSource = objObjetivo.GetDR(idClasificacion)
		listViewObjetivos.DataBind()

		If objClasificacion.Imagen1 <> "" Then
			panelImagen1.Visible = True
			imagenClasificacion1.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & idClasificacion & "&num=1"
		End If

		If objClasificacion.Imagen2 <> "" Then
			'panelImagen3.Visible = True
			'imagenClasificacion2.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & idClasificacion & "&num=2"
		End If

		If objClasificacion.Imagen3 <> "" Then
			'panelImagen3.Visible = True
			'imagenClasificacion3.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & idClasificacion & "&num=3"
		End If

		pasaDatosACajitas(showArchivosAdjuntos, objClasificacion, Contenidos.TipoContenido.Archivo)
		pasaDatosACajitas(showImagenesAdjuntos, objClasificacion, Contenidos.TipoContenido.Imagen)
		pasaDatosACajitas(showFlashes, objClasificacion, Contenidos.TipoContenido.Flash)
		pasaDatosACajitas(showDirecciones, objClasificacion, Contenidos.TipoContenido.Liga)

		IndiceClasificacion1.idRoot = objClasificacion.idRoot
		IndiceClasificacion1.modoEdicion = True
		IndiceClasificacion1.modoVistaPrevia = True
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

	Private Function getIdClasificacion() As Integer
		Dim idClasificacion As Integer
		Try
			idClasificacion = CInt(Request("idClasificacion"))
		Catch ex As Exception
			idClasificacion = 0
		End Try

		If idClasificacion < 0 Then idClasificacion = 0

		Return idClasificacion
	End Function

	Private Sub pasaDatosACajitas(control As Sec_Workbook_Controles_showadjuntos, ByRef objClasificacion As Lego.Clasificacion, tipoAdjunto As Contenidos.TipoContenido)
		With control
			.idRoot = objClasificacion.idRoot
			.idClasificacion = objClasificacion.id
			.procedencia = objClasificacion.tipo.ToString
			.tipoAdjunto = tipoAdjunto
		End With
	End Sub
End Class
