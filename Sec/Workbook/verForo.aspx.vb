
Partial Class Sec_SalonVirtual_verForo
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			llenado()
		End If
	End Sub

	Sub llenado()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idCI As Integer = getIdCI()

		Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
		Dim objClasificacion As New Lego.Clasificacion(objClasificacionItem.idClasificacion)
		Dim objForo As New Contenidos.Foro(objClasificacionItem.idProc)
		Dim objForoSalonVirtual As New Contenidos.ForoSalonVirtual
		Dim objRoot As New Lego.Root(objClasificacionItem.idRoot)

		If idSalonVirtual > 0 Then
			lnkSalir.NavigateUrl = "~/Sec/Workbook/Foro.aspx?idRoot=" & objClasificacionItem.idRoot & "&idClasificacion=" & objClasificacion.id & "&idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual
		Else
			lnkSalir.NavigateUrl = "~/Sec/Workbook/Foro.aspx?idRoot=" & objClasificacionItem.idRoot & "&idClasificacion=" & objClasificacion.id & "&idCI=" & idCI
		End If

        Page.Title = objForo.titulo
        lblClasificacion.Text = objClasificacion.titulo
        lblTitulo.Text = objForo.titulo
        littexto.Text = objForo.texto
        '  literalDescripcion.Text = objForo.textoCorto.Replace(vbCrLf, "<br>")

        pasaDatosACajitas(objForo, showContenidos, Contenidos.TipoContenido.Texto)
        pasaDatosACajitas(objForo, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo)
        pasaDatosACajitas(objForo, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen)
        pasaDatosACajitas(objForo, showFlashes, Contenidos.TipoContenido.Flash)
        pasaDatosACajitas(objForo, showDirecciones, Contenidos.TipoContenido.Liga)

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

	Private Sub pasaDatosACajitas(ByRef objForo As Contenidos.Foro, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
		With control
			.idProc = objForo.id
			.procedencia = objForo.tipo.ToString
			.tipoAdjunto = tipo
		End With
	End Sub

	Protected Sub btnResponder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResponder.Click
		Dim objClasificacionItem As New Lego.ClasificacionItem(getIdCI)
		Dim objForo As New Contenidos.Foro(objClasificacionItem.idProc)

		Response.Redirect("verForoRespuesta.aspx?idForo=" & objForo.id & "&idSalonVirtual=" & getIdSalonVirtual() & "&idRaiz=0" & "&idCI=" & objClasificacionItem.id)
	End Sub

	Public Function getLiga(ByVal claveNombre As Object, ByVal claveForo As Integer) As String
		Dim regreso As String = String.Empty

		If Not Convert.IsDBNull(claveNombre) Then
			Dim cadena As String = claveNombre.Substring(claveNombre.LastIndexOf(".") + 1)
			If cadena <> String.Empty Then

				Select Case cadena.ToLower
					Case "jpg", "bmp", "gif", "png"
						regreso = "~/sec/showfile.aspx?idForoSalonVirtual=" & claveForo
				End Select

				Return regreso
			End If
		End If

		Return regreso
	End Function

	Public Function getMostrar(ByVal clavenombre As Object) As Boolean
		If Not Convert.IsDBNull(clavenombre) Then
			If clavenombre <> String.Empty Then
				Return True
			End If
		End If

		Return False
	End Function

End Class
