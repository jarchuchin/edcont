
Partial Class Sec_SalonVirtual_ContestarOpcionMultiple
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        validaringreso()
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub

	Sub validaringreso()
		If Request("idSalonVirtual") <> "" And Request("idCI") <> "" And CInt(Session("gUserProfileSession").idUserProfile) > 0 Then
            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

            Dim mya As New Contenidos.Actividad(myci.idProc)
            If mya.activarBanco Then
                Dim myexo As New Examenes.ExOrden(myci.idProc, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
                If Not myexo.existe Then
                    Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & CInt(Request("idSalonVirtual")) & "&idCI=" & CInt(Request("idCI")) & "&idA=" & myci.idProc)
                End If
            End If


            Dim myR As Contenidos.Respuesta = New Contenidos.Respuesta(0, myci.idProc, "Actividad", CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myR.existe Then
                Response.Redirect("TerminarExamen.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual"))
            Else
                validarAgendayAlumnos(myci)
            End If
		End If

	End Sub

	Sub iniciarControles()


		Dim myP As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
		pregunta.Text = myP.enunciado
		valor.Text = myP.valor
		llenarRDB()
		colocarImagenesEnRBD()
		colocarDatos()


		If myP.fileName <> "" Then
			imgPregunta.Visible = True
			imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id

			imgPreguntalink.Visible = True
			imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id & "&display=x"

		End If

	End Sub

    Sub colocarDatos()


        Dim idSalonVirtual As Integer = getIdSalonVirtual()
        Dim idUserProfile As Integer = getIdUserProfile()
        Dim idCI As Integer = getIdCI()


        If Request("idSalonVirtual") <> "" Then
            Dim myER As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(Request("idP")), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myER.existe Then
                txtid.Text = myER.id

                rdbOpcionesDisponibles.SelectedValue = myER.idORSeleccionada

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
		Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
        Response.Redirect(myp.GetSiguiente(CInt(Request("idCI")), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile)))
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
        Response.Redirect(myp.GetAnterior(CInt(Request("idCI")), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile)))
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
            Dim cadena As String = "login.aspx?ReturnUrl=" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/examenes/ContestarOpcionMultiple.aspx?idSalonVirtual" & Request("idSalonVirtual") & "&idCI=" & Request("idCI") & "&idP=" & Request("idP")
            Response.Redirect(cadena)
        Else
            If Request("idSalonVirtual") <> "" Then
                If txtid.Text <> "" Then
                    editar()
                Else
                    grabar()
                End If
            End If
            Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
            Response.Redirect(myp.GetSiguiente(CInt(Request("idCI")), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile)))
        End If

    End Sub

    Sub llenarRDB()
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        rdbOpcionesDisponibles.DataSource = myOR.GetDR(CInt(Request("idP")))
        rdbOpcionesDisponibles.DataTextField = "enunciado"
        rdbOpcionesDisponibles.DataValueField = "idOR"
        rdbOpcionesDisponibles.DataBind()
    End Sub

    Sub colocarImagenesEnRBD()
        Dim i As Integer
        Dim myor As Examenes.OpcionRespuesta
        For i = 0 To rdbOpcionesDisponibles.Items.Count - 1
            myor = New Examenes.OpcionRespuesta(CInt(rdbOpcionesDisponibles.Items(i).Value))
            Dim cadena As String = myor.enunciado
            If myor.fileName <> "" Then
                cadena = cadena & " " & "<a border=""0"" href=""../showfile.aspx?idOpcionRespuesta=" & myor.id & "&display=x"" target=""_blank""><img src=""../showfile.aspx?idOpcionRespuesta=" & myor.id & "&display=x"" width=""150px""/></a>"
            End If
            rdbOpcionesDisponibles.Items(i).Text = cadena

        Next
    End Sub

    Sub editar()
        Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(txtid.Text))
        myer.idORSeleccionada = CInt(rdbOpcionesDisponibles.SelectedValue)
        myer.fecha = Date.Now
        myer.Update()
        myer.AutoCalificarRespuesta()
    End Sub

    Sub grabar()
        Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta
        myer.idORSeleccionada = CInt(rdbOpcionesDisponibles.SelectedValue)
        myer.idPregunta = CInt(Request("idP"))
        myer.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myer.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
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
