
Partial Class Sec_SalonVirtual_verActividad
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
        Dim objActividad As New Contenidos.Actividad(objClasificacionItem.idProc)
        Dim objRoot As New Lego.Root(objClasificacionItem.idRoot)

        panelEdicion.Visible = EsMaestro()
        '  lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/Actividad.aspx?idRoot=" & objClasificacionItem.idRoot & "&idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacionItem.idClasificacion

        Page.Title = objActividad.titulo

        '     Page.Title = objClasificacion.titulo
        'lblTitulo.Text = objClasificacion.titulo
        lblNombreTitulo.Text = objClasificacion.titulo




        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)



        lnkTitulo.Text = objRoot.titulo

        lnkTitulo.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & objRoot.id

        lbltit.Text = objClasificacion.titulo
        lbltit.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id
        lbltits.Text = objActividad.titulo



        lblClasificacion.Text = objClasificacion.titulo
        lblTitulo.Text = objActividad.titulo

        If objActividad.TipoX <> String.Empty Then lblTipoActividad.Text = objActividad.TipoX
        If objActividad.Objetivo <> String.Empty Then lblObjetivo.Text = objActividad.Objetivo.Replace(vbCrLf, "<br/>")
        If objActividad.Tags <> String.Empty Then lbltags.Text = objActividad.Tags
        litInstrucciones.Text = objActividad.instrucciones

        'displayComentarios1.claveidProc = objActividad.id
        'displayComentarios1.claveProcedencia = objActividad.tipo.ToString

        ' +++++++++  RÚBRICA B+++++++++++++
        If objActividad.comoSeCalifica = Contenidos.EComoSeCalifica.Rubrica Then


            llenarRubricaTableB(objActividad.id)
            panelRubricas.Visible = True


        End If
        ' +++++++++  RÚBRICA  A+++++++++++++
        If objActividad.comoSeCalifica = Contenidos.EComoSeCalifica.RubricaA Then


            llenarRubricaTableA(objActividad.id)
            panelRubricas.Visible = True


        End If

        If objActividad.respuestaGrupal Then
            panelGrupos.Visible = True
            ' lnknuevogrupo.NavigateUrl = "~/sec/salonVirtual/AddGrupoActividad.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual")



        End If

        ' +++++++++  RÚBRICA +++++++++++++

        Dim objAgenda As Comm.Agenda = New Comm.Agenda(idSalonVirtual, objActividad.id, objActividad.tipo.ToString)
        Dim objAgendaUsuario As Comm.Agenda = New Comm.Agenda(idSalonVirtual, objActividad.id, objActividad.tipo.ToString, CInt(Session("gUserProfileSession").idUserProfile))
        'If objAgenda.existe Then
        '	lblFechaEntrega.Text = objAgenda.fecha.ToString("ddd dd \de MMMM \de yyyy") & " " & objAgenda.fecha.ToShortTimeString
        '	lblFechaEntrega.Visible = True
        '	lblNoFecha.Visible = False

        '	If objAgenda.fecha >= Date.Now Then
        '		btnEnviarTarea.Visible = True

        '		If objAgenda.fechaInicio >= Date.Now Then
        '			btnEnviarTarea.Visible = False
        '		End If
        '	Else
        '		If objAgenda.activarLimite Then
        '			lblFechaVencida.Visible = True
        '		Else
        '			btnEnviarTarea.Visible = True
        '		End If
        '	End If

        'Else
        '	lblFechaEntrega.Visible = False
        '	lblNoFecha.Visible = True
        '	btnEnviarTarea.Visible = True
        '      End If


        '#####

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
            lblFechaEntrega.Visible = False
            lblNoFecha.Visible = True
            btnEnviarTarea.Visible = True
        End If

        '#######

        'Inicia Seccion para colocar los parametros de la fecha personalidazada en caso de existir
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
        'Termina Seccion para colocar los parametros de la fecha personalidazada en caso de existir

        Dim objRespuesta As New Contenidos.Respuesta(0, objActividad.id, "Actividad", idSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile))
        If objRespuesta.repetir Then
            btnEnviarTarea.Visible = True
        End If

        If objActividad.quienCalifica = Contenidos.EQuienCalifica.Alumnos Then
            btnCalificar.Visible = True
        End If

        btnVerRespuestas.Visible = objActividad.mostrarRespuestas

        Dim idActividad As Integer = 0
        If btnEnviarTarea.Visible Then
            idActividad = objActividad.id
        End If

        If lblFechaEntrega2.Text <> "" Then
            'Desplegar Fechas
            panelDesplegarFechas.Visible = True
        End If


        pasaDatosACajitas(objActividad, showContenidos, Contenidos.TipoContenido.Texto, idActividad)
        pasaDatosACajitas(objActividad, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo, idActividad)
        pasaDatosACajitas(objActividad, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen, idActividad)
        pasaDatosACajitas(objActividad, showFlashes, Contenidos.TipoContenido.Flash, idActividad)
        pasaDatosACajitas(objActividad, showDirecciones, Contenidos.TipoContenido.Liga, idActividad)



        btnEnviarTarea.Enabled = False
        btnCalificar.Enabled = False
        btnVerRespuestas.Enabled = False

    End Sub


    Sub llenarRubricaTableB(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricas.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricas.DataBind()

    End Sub

    Sub llenarRubricaTableA(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricasA.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricasA.DataBind()

        lblTotalRubricaA.Text = myrubrica.GetTotalValorRubricaA(claveActividad)
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

    Private Sub pasaDatosACajitas(ByRef objActividad As Contenidos.Actividad, control As Sec_Workbook_Controles_showadjuntos,
             tipo As Contenidos.TipoContenido, Optional idActividad As Integer = 0)
        With control
            .idProc = objActividad.id
            .procedencia = objActividad.tipo.ToString
            .tipoAdjunto = tipo
        End With
    End Sub

    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
        Dim objUserProfile As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermiso.existe
    End Function

    Protected Sub btnEnviarTarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarTarea.Click
        Dim objClasificacionItem As New Lego.ClasificacionItem(getIdCI)
        Dim objActividad As Contenidos.Actividad = New Contenidos.Actividad(objClasificacionItem.idProc)

        Response.Redirect("ResponderActividad.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idA=" & objActividad.id)
    End Sub

    Protected Sub btnCalificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalificar.Click
        Response.Redirect("ActividadesPorCalificar.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & getIdCI())
    End Sub

    Protected Sub btnVerRespuestas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerRespuestas.Click
        Response.Redirect("Verrespuestascompas.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & getIdCI())
    End Sub
    Protected Sub lnknuevogrupo_Click(sender As Object, e As EventArgs) Handles lnknuevogrupo.Click

    End Sub
End Class
