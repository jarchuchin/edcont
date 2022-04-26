
Partial Class Sec_SalonVirtual_verExamen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

	Sub colocarDatos()
		Dim idActividad As Integer = getIdActividad()
		Dim idClasificacion As Integer = getIdClasificacion()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()

        If idActividad = 0 Or idClasificacion = 0 Then
            Dim idCI As Integer = getIdCI()
            Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
            idActividad = objClasificacionItem.idProc
            idClasificacion = objClasificacionItem.idClasificacion
        End If

		Dim objClasificacion As New Lego.Clasificacion(idClasificacion)
		Dim objActividad As New Contenidos.Actividad(idActividad)
		Dim objAgenda As Comm.Agenda = New Comm.Agenda(idSalonVirtual, objActividad.id, objActividad.tipo.ToString)
		Dim objRespuesta As New Contenidos.Respuesta(0, objActividad.id, "Actividad", idSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile))
		Dim objRoot As New Lego.Root(objClasificacion.idRoot)

		If idSalonVirtual > 0 Then
			lnkSalir.NavigateUrl = "~/Sec/Workbook/Examen.aspx?idRoot=" & objClasificacion.idRoot & "&idClasificacion=" & idClasificacion & "&idSalonVirtual=" & idSalonVirtual & "&idA=" & idActividad
		Else
			lnkSalir.NavigateUrl = "~/Sec/Workbook/Examen.aspx?idRoot=" & objClasificacion.idRoot & "&idClasificacion=" & idClasificacion & "&idA=" & idActividad
		End If

		Page.Title = objActividad.titulo
		lnkPaginaPrincipalCurso.Text = objRoot.titulo
		lnkClasificacion.Text = objClasificacion.titulo
		lblClasificacion.Text = objClasificacion.titulo
		lblTitulo.Text = objActividad.titulo
        litInstrucciones.Text = objActividad.instrucciones.Replace(vbCrLf, "<br/>")

		If objAgenda.existe Then
			If objAgenda.fecha >= Date.Now Then
				btnEnviarTarea.Visible = True

				If objAgenda.fechaInicio >= Date.Now Then
					btnEnviarTarea.Visible = False
				End If
			Else
				If objAgenda.activarLimite Then
					lblFechaVencida.Visible = True
				Else
					btnEnviarTarea.Visible = True
				End If

			End If
			lblFechaEntrega.Text &= "--" & objAgenda.fecha.ToLongDateString & " " & objAgenda.fecha.ToShortTimeString

		Else
			btnEnviarTarea.Visible = True
		End If

        If objRespuesta.repetir Then
            btnEnviarTarea.Visible = True
        End If

        Dim objSalonVirtual As New Know.SalonVirtual(idSalonVirtual, False)
        If objSalonVirtual.permitirVerExamenes Then
            btnEnviarTarea.Visible = True
        End If

        pasaDatosACajitas(objActividad, showarchivosAdjuntos, Contenidos.TipoContenido.Archivo)
		pasaDatosACajitas(objActividad, showimagenesAdjuntos, Contenidos.TipoContenido.Imagen)
		pasaDatosACajitas(objActividad, Showflashes, Contenidos.TipoContenido.Flash)
		pasaDatosACajitas(objActividad, showdirecciones, Contenidos.TipoContenido.Liga)

		If objClasificacion.Imagen1 <> "" Then
			panelImagen.Visible = True
			imagenClasificacion.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & objClasificacion.id & "&num=1"
		End If
	End Sub

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

	Private Function getIdActividad() As Integer
		Dim idA As Integer
		Try
			idA = CInt(Request("idA"))
		Catch ex As Exception
			idA = 0
		End Try

		If idA < 0 Then idA = 0

		Return idA
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

	Private Sub pasaDatosACajitas(ByRef objActividad As Contenidos.Actividad, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
		With control
			.idProc = objActividad.id
			.procedencia = objActividad.tipo.ToString
			.tipoAdjunto = tipo
		End With
	End Sub

	Protected Sub btnEnviarTarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarTarea.Click
		Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & getIdCI() & "&idA=" & getIdActividad())
	End Sub
End Class
