
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

        Dim idCI As Integer = getIdCI()
        Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
        idActividad = objClasificacionItem.idProc
        idClasificacion = objClasificacionItem.idClasificacion
  

        Dim objClasificacion As New Lego.Clasificacion(idClasificacion)
        Dim objActividad As New Contenidos.Actividad(idActividad)
        Dim objAgenda As Comm.Agenda = New Comm.Agenda(idSalonVirtual, objActividad.id, objActividad.tipo.ToString)
        Dim objAgendaUsuario As Comm.Agenda = New Comm.Agenda(idSalonVirtual, objActividad.id, objActividad.tipo.ToString, CInt(Session("gUserProfileSession").idUserProfile))
        Dim objRespuesta As New Contenidos.Respuesta(0, objActividad.id, "Actividad", idSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile))
        Dim objRoot As New Lego.Root(objClasificacion.idRoot)

        panelEdicion.Visible = EsMaestro()
        lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/Examen.aspx?idRoot=" & objClasificacion.idRoot & "&idClasificacion=" & idClasificacion & "&idSalonVirtual=" & idSalonVirtual & "&idA=" & idActividad & "&idCI=" & getIdCI()

        Page.Title = objActividad.titulo
        lblNombreTitulo.Text = objActividad.titulo




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
        lblCursoBread.Text = objActividad.titulo



        lblClasificacion.Text = objClasificacion.titulo
        lblTitulo.Text = objActividad.titulo




        ' If objActividad.TipoX <> String.Empty Then lblTipoActividad.Text = objActividad.TipoX

        If objActividad.Objetivo <> String.Empty Then lblObjetivo.Text = objActividad.Objetivo.Replace(vbCrLf, "<br/>")
        litInstrucciones.Text = objActividad.instrucciones

        displayComentarios1.claveidProc = objActividad.id
        displayComentarios1.claveProcedencia = objActividad.tipo.ToString


        If objAgenda.existe Then

            lblFechaEntrega.Text = objAgenda.fechaInicio.ToString("ddd dd \de MMMM \de yyyy") & " " & objAgenda.fechaInicio.ToShortTimeString
            lblFechaEntrega.Visible = True
            lblNoFecha.Visible = False


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
            lblFechaEntrega2.Text = objAgenda.fecha.ToString("ddd dd \de MMMM \de yyyy") & " " & objAgenda.fecha.ToShortTimeString

        Else

            If mysv.permitirVerExamenes Then
                lblFechaEntrega.Visible = False
                lblNoFecha.Visible = True
                btnEnviarTarea.Visible = True
            Else
                If objActividad.contestarSinAgenda Then
                    lblFechaEntrega.Visible = False
                    lblNoFecha.Visible = True
                    btnEnviarTarea.Visible = True
                Else
                    lblFechaEntrega.Visible = True
                    lblNoFecha.Visible = False
                    btnEnviarTarea.Visible = False
                End If
            End If



        End If


        'Agenda Usuario
        If objAgendaUsuario.existe Then

            lblFechaEntrega.Text = objAgendaUsuario.fechaInicio.ToString("ddd dd \de MMMM \de yyyy") & " " & objAgendaUsuario.fechaInicio.ToShortTimeString
            lblFechaEntrega.Visible = True
            lblNoFecha.Visible = False

            If objAgendaUsuario.fecha >= Date.Now Then
                btnEnviarTarea.Visible = True

                If objAgendaUsuario.fechaInicio >= Date.Now Then
                    btnEnviarTarea.Visible = False
                End If
            Else
                If objAgendaUsuario.activarLimite Then
                    lblFechaVencida.Visible = True
                Else
                    btnEnviarTarea.Visible = True
                End If

            End If
            lblFechaEntrega2.Text = objAgendaUsuario.fecha.ToString("ddd dd \de MMMM \de yyyy") & " " & objAgendaUsuario.fecha.ToShortTimeString

            'Else
            '    lblFechaEntrega.Visible = False
            '    lblNoFecha.Visible = True
            '    btnEnviarTarea.Visible = True
        End If


        ''###########

        'If objAgenda.existe Then
        '    'lblFechaEntrega.Text &= "xx --" & mycal.fecha & "---" & Date.Now & "---" & mycal.fechaInicio
        '    If objAgenda.fecha >= Date.Now Then
        '        btnEnviarTarea.Visible = True

        '        If objAgenda.fechaInicio >= Date.Now Then
        '            btnEnviarTarea.Visible = False
        '        End If
        '    Else
        '        If objAgenda.activarLimite Then
        '            lblFechaVencida.Visible = True
        '        Else
        '            btnEnviarTarea.Visible = True
        '        End If

        '    End If
        '    lblFechaEntrega.Text &= "--" & objAgenda.fecha.ToLongDateString & " " & objAgenda.fecha.ToShortTimeString

        'Else
        '    btnEnviarTarea.Visible = True
        'End If

        ''#########


        If objRespuesta.repetir Then
            btnEnviarTarea.Visible = True
        End If


        If lblFechaEntrega2.Text <> "" Then
            'Desplegar Fechas
            panelDesplegarFechas.Visible = True
        End If

        pasaDatosACajitas(objActividad, showarchivosAdjuntos, Contenidos.TipoContenido.Archivo)
        pasaDatosACajitas(objActividad, showimagenesAdjuntos, Contenidos.TipoContenido.Imagen)
        pasaDatosACajitas(objActividad, Showflashes, Contenidos.TipoContenido.Flash)
        pasaDatosACajitas(objActividad, showdirecciones, Contenidos.TipoContenido.Liga)

        If objRespuesta.existe Then
            If Not btnEnviarTarea.Visible Then
                'aqui el alumno envio el examen asi que ahora puede entrar a ver 
                btnRevisarExamen.Visible = True
            End If
        End If




        'Bitacora de vista a contenidos
        Dim mybc As New Know.BitacoraContenido
        mybc.idProc = objActividad.id
        mybc.Procedencia = objActividad.tipo.ToString
        mybc.idSalonVirtual = mysv.id
        mybc.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mybc.ip = Request.UserHostAddress
        mybc.Browser = Request.Browser.Type & "-" & Request.Browser.Browser & "-" & Request.Browser.Platform & "-" & Request.Browser.Version
        mybc.Fecha = Date.Now
        mybc.Add()




        '  Page.Title = idSalonVirtual & "-" & objActividad.id & "-" & objActividad.tipo.ToString
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

	Public Function EsMaestro() As Boolean
		Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
		Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
		Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

		Return objPermisos.existe
	End Function

    Protected Sub btnEnviarTarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarTarea.Click
        Dim idActividad As Integer
        Dim idCI As Integer = getIdCI()
        Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
        idActividad = objClasificacionItem.idProc

        Dim idClasificacion As Integer = objClasificacionItem.idClasificacion


        Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & idCI & "&idA=" & idActividad)
    End Sub
    Protected Sub btnRevisarExamen_Click(sender As Object, e As EventArgs) Handles btnRevisarExamen.Click

        Dim idActividad As Integer
        Dim idCI As Integer = getIdCI()
        Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
        idActividad = objClasificacionItem.idProc

        Dim idClasificacion As Integer = objClasificacionItem.idClasificacion

        Response.Redirect("ContestarExamenListaPreguntas.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & idCI & "&idA=" & idActividad)

    End Sub
End Class
