
Partial Class Sec_SalonVirtual_ContestarFalsoVerdadero
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        validaringreso()
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub

	Sub validaringreso()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idCI As Integer = getIdCI()
		Dim idUserProfile As Integer = getIdUserProfile()

		If idSalonVirtual > 0 And idCI > 0 And idUserProfile > 0 Then
            Dim myci As New Lego.ClasificacionItem(idCI)

            Dim mya As New Contenidos.Actividad(myci.idProc)
            If mya.activarBanco Then
                Dim myexo As New Examenes.ExOrden(myci.idProc, idSalonVirtual, idUserProfile)
                If Not myexo.existe Then
                    Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & idSalonVirtual & "&idCI=" & idCI & "&idA=" & myci.idProc)
                End If
            End If


            Dim myR As New Contenidos.Respuesta(0, myci.idProc, "Actividad", idSalonVirtual, idUserProfile)
            If myR.existe Then
                Response.Redirect("TerminarExamen.aspx?idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual)
            Else
                validarAgendayAlumnos(myci)
            End If
		End If

	End Sub

	Sub iniciarControles()
		Dim myP As New Examenes.Pregunta(CInt(Request("idP")))
		pregunta.Text = myP.enunciado
		valor.Text = myP.valor

		If myP.fileName <> "" Then
			imgPregunta.Visible = True
			imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id

			imgPreguntalink.Visible = True
			imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id & "&display=x"

		End If

		colocarDatos()
	End Sub

	Sub colocarDatos()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idUserProfile As Integer = getIdUserProfile()
        Dim idCI As Integer = getIdCI()



        If idSalonVirtual > 0 Then
			Dim myER As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(Request("idP")), idSalonVirtual, idUserProfile)
			If myER.existe Then
				txtid.Text = myER.id
				Select Case myER.idORSeleccionada
					Case Examenes.EFalsoVerdadero.falso
						rdbFV2.Items(0).Selected = False
						rdbFV2.Items(1).Selected = True
					Case Examenes.EFalsoVerdadero.verdadero
						rdbFV2.Items(0).Selected = True
						rdbFV2.Items(1).Selected = False
				End Select
			End If
		End If

        '++++++++++  PENDIENTE ++++++++++
        'panelEdicion.Visible = EsMaestro()
        'lnkEdicionContenido.NavigateUrl = "...."



        '################### 
        'Seccion de bread
        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)
        Dim myci As New Lego.ClasificacionItem(idCI)
        Dim objClasificacion As New Lego.Clasificacion(myci.idClasificacion)
        Dim objActividad As New Contenidos.Actividad(myci.idProc)


        Page.Title = objActividad.titulo
        lblNombreTitulo.Text = objActividad.titulo

        If EsMaestro() Then
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

	Private Function getIdUserProfile() As Integer
		Dim idUserProfile As Integer
		Try
			idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
		Catch ex As Exception
			idUserProfile = 0
		End Try

		If idUserProfile < 0 Then idUserProfile = 0

		Return idUserProfile
	End Function

	Public Function EsMaestro() As Boolean
		Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
		Dim objUserProfile As New MasUsuarios.UserProfile(getIdUserProfile, False)
		Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

		Return objPermiso.existe
	End Function

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
		Dim myp As New Examenes.Pregunta(CInt(Request("idP")))
        Response.Redirect(myp.GetSiguiente(getIdCI, getIdSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile)))
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
        Response.Redirect(myp.GetAnterior(getIdCI, getIdSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile)))
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idCI As Integer = getIdCI()
		Dim idUserProfile As Integer = getIdUserProfile()

		If idUserProfile = 0 Then
			Dim cadena As String = "login.aspx?ReturnUrl=" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/examenes/ContestarFalsoVerdadero.aspx?idSalonVirtual" & idSalonVirtual & "&idCI=" & idCI & "&idP=" & Request("idP")
			Response.Redirect(cadena)
		Else
			If idSalonVirtual > 0 Then
				If txtid.Text <> "" Then
					editar()
				Else
					grabar()
				End If
			End If
			Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
            Dim cadena As String = myp.GetSiguiente(idCI, idSalonVirtual, CInt(Session("gUserProfileSession").idUserProfile))
            Response.Redirect(cadena)
		End If

    End Sub

    Sub editar()
        Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(txtid.Text))
        If rdbFV2.SelectedValue.ToString = "F" Then
            myer.idORSeleccionada = Examenes.EFalsoVerdadero.falso
        Else
            myer.idORSeleccionada = Examenes.EFalsoVerdadero.verdadero
        End If
        myer.fecha = Date.Now
        myer.Update()
        myer.AutoCalificarRespuesta()
    End Sub

    Sub grabar()
        Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta
        If rdbFV2.SelectedValue.ToString = "F" Then
            myer.idORSeleccionada = Examenes.EFalsoVerdadero.falso
        Else
            myer.idORSeleccionada = Examenes.EFalsoVerdadero.verdadero
        End If
        myer.idPregunta = CInt(Request("idP"))
        myer.idSalonVirtual = getIdSalonVirtual()
        myer.idUserProfile = getIdUserProfile()
        myer.valorObtenido = 0
        myer.Respuesta = ""
        myer.fecha = Date.Now
        myer.Add()
        myer.AutoCalificarRespuesta()
    End Sub



    Sub validarAgendayAlumnos(objci As Lego.ClasificacionItem)



        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myA As New Contenidos.Actividad(objci.idProc)


        Dim objAgenda As Comm.Agenda = New Comm.Agenda(mysv.id, myA.id, myA.tipo.ToString)
        Dim objAgendaUsuario As Comm.Agenda = New Comm.Agenda(mysv.id, myA.id, myA.tipo.ToString, CInt(Session("gUserProfileSession").idUserProfile))

        Dim permitirIngreso As Boolean = False
        Dim entro As Boolean = False

        If Not mysv.permitirVerExamenes Then
            entro = True


            If objAgenda.existe Then
                If objAgenda.fecha >= Date.Now Then
                    permitirIngreso = True

                    If objAgenda.fechaInicio >= Date.Now Then
                        permitirIngreso = False
                    End If
                Else
                    If Not objAgenda.activarLimite Then
                        permitirIngreso = True
                    End If

                End If

            Else

                If myA.contestarSinAgenda Then
                    permitirIngreso = True
                End If

            End If


            'Agenda Usuario
            If objAgendaUsuario.existe Then
                If objAgendaUsuario.fecha >= Date.Now Then
                    permitirIngreso = True

                    If objAgendaUsuario.fechaInicio >= Date.Now Then
                        permitirIngreso = False
                    End If
                Else
                    If Not objAgendaUsuario.activarLimite Then
                        permitirIngreso = True
                    End If

                End If


            End If


        End If



        If permitirIngreso = False And entro = True Then

            Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))

            'el usuario ingreso a esta zona sin autorización
            Dim myb As New Know.Bitacora
            myb.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myb.ip = Request.UserHostAddress
            myb.Modulo = "Examen"
            myb.Bitacora = "Ingreso NO AUTORIZADO al módulo de exámenes, " & myA.titulo & "-" & myA.id & "-" & mysv.id & "-" & mysv.claveAux1 & "-P." & myp.id & "-T." & myp.tipoPregunta
            myb.Fecha = Date.Now
            myb.idSalonVirtual = mysv.id
            myb.Add()
            Response.Redirect("~/sec/SalonVirtual/RestringirExamen.aspx")

        End If


    End Sub
End Class