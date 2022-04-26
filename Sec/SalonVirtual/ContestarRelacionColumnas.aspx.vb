Imports System.Data

Partial Class Sec_SalonVirtual_ContestarRelacionColumnas
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


        Dim idSalonVirtual As Integer = getIdSalonVirtual()
        Dim idUserProfile As Integer = getIdUserProfile()
        Dim idCI As Integer = getIdCI()

        Dim myP As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
		pregunta.Text = myP.enunciado
		valor.Text = myP.valor
		colocarDatos()
		llenarGrids()


		If myP.fileName <> "" Then
			imgPregunta.Visible = True
			imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id

			imgPreguntalink.Visible = True
			imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myP.id & "&display=x"

		End If




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


    Sub llenarGrids()

        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        dtgItem.DataSource = myOR.GetDS(CInt(Request("idP")))
        dtgItem.DataBind()

        Dim myOP As Examenes.OpcionPregunta = New Examenes.OpcionPregunta
        dtgItem0.DataSource = myOP.GetDS(CInt(Request("idP")))
        dtgItem0.DataBind()


        dtgSeleccion.DataSource = myOP.GetDS(CInt(Request("idP")))
        dtgSeleccion.DataBind()

    End Sub

    Sub colocarDatos()
        If Request("idSalonVirtual") <> "" Then
            Dim myER As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(Request("idP")), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myER.existe Then
                txtid.Text = myER.id

            End If
        End If

		'++++++++++  PENDIENTE ++++++++++
		'panelEdicion.Visible = EsMaestro()
		'lnkEdicionContenido.NavigateUrl = "...."
	End Sub


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
            Dim cadena As String = "login.aspx?ReturnUrl=" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/examenes/ContestarRelacionColumnas.aspx?idSalonVirtual" & Request("idSalonVirtual") & "&idCI=" & Request("idCI") & "&idP=" & Request("idP")
            Response.Write(cadena)
        Else
            If Request("idSalonVirtual") <> "" Then
                If txtid.Text <> "" Then
                    editar()
                Else
                    grabar()
                End If
            End If
            Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
            Response.Redirect(myp.GetSiguiente(Request("idCI"), Request("idSalonVirtual"), CInt(Session("gUserProfileSession").idUserProfile)))
        End If


    End Sub

	Sub editar()
		Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(txtid.Text))
		myer.fecha = Date.Now
		myer.Update()
		EditarSeleccionados()
		myer.AutoCalificarRespuesta()
	End Sub

	Function EditarSeleccionados() As Integer

		Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
		Dim drpSelected As System.Web.UI.WebControls.DropDownList
		Dim myexrOP As Examenes.ExRespuestaOP
		For Each myDataGridItem In dtgSeleccion.Items
			drpSelected = myDataGridItem.FindControl("drpChido")
			myexrOP = New Examenes.ExRespuestaOP(dtgSeleccion.DataKeys(myDataGridItem.ItemIndex), CInt(txtid.Text))
			myexrOP.idORSeleccionada = Convert.ToInt32(drpSelected.SelectedValue.ToString)
			myexrOP.Update()
		Next
	End Function

    Sub grabar()
        Dim myer As Examenes.ExRespuesta = New Examenes.ExRespuesta
        myer.idORSeleccionada = 0
        myer.idPregunta = CInt(Request("idP"))
        myer.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myer.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myer.valorObtenido = 0
        myer.Respuesta = ""
        myer.fecha = Date.Now
        myer.Add()
        GrabarSeleccionados(myer.id)
        myer.AutoCalificarRespuesta()
    End Sub

	Function GrabarSeleccionados(ByVal ClaveExRespuesta As Integer) As Integer

		Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
		Dim drpSelected As System.Web.UI.WebControls.DropDownList
		Dim myexrOP As Examenes.ExRespuestaOP
		For Each myDataGridItem In dtgSeleccion.Items
			drpSelected = myDataGridItem.FindControl("drpChido")
			myexrOP = New Examenes.ExRespuestaOP
			myexrOP.idOP = dtgSeleccion.DataKeys(myDataGridItem.ItemIndex)
			myexrOP.idExRespuesta = ClaveExRespuesta
			myexrOP.idORSeleccionada = Convert.ToInt32(drpSelected.SelectedValue.ToString)
			myexrOP.Add()
		Next
	End Function

	Protected Function GetOpciones() As DataSet
		Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
		Return myOR.GetDS(CInt(Request("idP")))
	End Function

    Private Sub dtgSeleccion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgSeleccion.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then

            Dim myControl As DropDownList = CType(e.Item.FindControl("drpChido"), DropDownList)

            If txtid.Text <> "" Then
                Dim myexROP As Examenes.ExRespuestaOP = New Examenes.ExRespuestaOP(CInt(dtgSeleccion.DataKeys(e.Item.ItemIndex)), CInt(txtid.Text))
                Dim i As Integer
                For i = 0 To myControl.Items.Count - 1
                    myControl.Items(i).Selected = False
                    If myexROP.idORSeleccionada.ToString = myControl.Items(i).Value.ToString Then
                        myControl.Items(i).Selected = True
                    End If
                Next

            End If

        End If

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
            myb.Bitacora = "Ingreso NO AUTORIZADO al módulo de exámenes, " & myA.titulo & "-" & myA.id & "-" & mysv.id & "-" & mysv.claveAux1 & "-P." & myp.id
            myb.Fecha = Date.Now
            myb.idSalonVirtual = mysv.id
            myb.Add()
            Response.Redirect("~/sec/SalonVirtual/RestringirExamen.aspx")

        End If


    End Sub
End Class
