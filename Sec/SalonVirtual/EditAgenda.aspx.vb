
Partial Class Sec_SalonVirtual_EditAgenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If

        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub


    Sub colocarDatos()
        'If Not IsDate(Request("fecha")) Then
        '    Response.Redirect("Calendario.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
        'Else


        If Not esmaestro() Then
            Response.Redirect("~/logout.aspx")
        End If


        Dim fechaActual As Date = Date.Now
        If Request("year") <> "" And Request("mes") <> "" And Request("dia") <> "" Then
            fechaActual = New Date(CInt(Request("year")), CInt(Request("mes")), CInt(Request("dia")))
        End If

        Dim mys As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        txtFecha1.Text = mys.fechaInicio.ToShortDateString

        lblCalendario.Text = "Agendar en: " & fechaActual.ToLongDateString
        Page.Title = "Agendar actividades"
        txtFecha2.Text = fechaActual.ToShortDateString
        cargarAgenda(fechaActual)
        llenarListas()
        esconderTodo(False)
        lstActividades.Visible = True
        'lblMensajeActividades.Visible = True


        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    End Sub




    Sub esconderTodo(ByVal esconde As Boolean)
        lstActividades.Visible = esconde
        lstForos.Visible = esconde
        lstContenidos.Visible = esconde
        PanelAgenda.Visible = esconde
    End Sub

    Sub cargarAgenda(ByVal claveFecha As Date)
        Dim myAgenda As Comm.Agenda = New Comm.Agenda
        dtgAgenda.DataSource = myAgenda.GetItemsAgenda(CInt(Request("idSalonVirtual")), claveFecha)
        dtgAgenda.DataBind()

        If dtgAgenda.Items.Count > 0 Then
            btnBorrar.Visible = True
        Else
            btnBorrar.Visible = False
        End If


        If Request("hora") <> "" Then
            Select Case Request("hora")
                Case "04"
                    drphorafin.SelectedValue = "04"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "AM"
                Case "06"
                    drphorafin.SelectedValue = "06"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "AM"
                Case "08"
                    drphorafin.SelectedValue = "08"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "AM"
                Case "10"
                    drphorafin.SelectedValue = "10"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "AM"
                Case "12"
                    drphorafin.SelectedValue = "12"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "14"
                    drphorafin.SelectedValue = "02"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "16"
                    drphorafin.SelectedValue = "04"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "18"
                    drphorafin.SelectedValue = "06"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "20"
                    drphorafin.SelectedValue = "08"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "22"
                    drphorafin.SelectedValue = "10"
                    drpminutosfin.SelectedValue = "00"
                    drpampmfin.SelectedValue = "PM"
                Case "24"
                    drphorafin.SelectedValue = "11"
                    drpminutosfin.SelectedValue = "59"
                    drpampmfin.SelectedValue = "PM"
                Case Else
                    drphorafin.SelectedValue = "11"
                    drpminutosfin.SelectedValue = "59"
                    drpampmfin.SelectedValue = "PM"



            End Select
        End If

    End Sub

    Sub borrarMensajes()
        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim chkSelected As System.Web.UI.WebControls.CheckBox
        Dim myAgenda As Comm.Agenda
        For Each myDataGridItem In dtgAgenda.Items

            chkSelected = myDataGridItem.FindControl("chkMarcar")
            If chkSelected.Checked Then
                Dim clave As String = CType(myDataGridItem.FindControl("lblID"), System.Web.UI.WebControls.Label).Text
                myAgenda = New Comm.Agenda(Integer.Parse(clave))
                myAgenda.Remove()
            End If

        Next

    End Sub


    Sub llenarListas()
        Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lstActividades.DataSource = myASV.GetActividadesNoEnAgenda(mysalon.id)
        lstActividades.DataTextField = "Titulo"
        lstActividades.DataValueField = "idActividad"
        lstActividades.DataBind()

        Dim myForos As Contenidos.Foro = New Contenidos.Foro
        lstForos.DataSource = myForos.GetForosNoEnAgenda(mysalon.id, mysalon.idRoot)
        lstForos.DataTextField = "Titulo"
        lstForos.DataValueField = "idForo"
        lstForos.DataBind()

        Dim myCont As Contenidos.Contenido = New Contenidos.Contenido
        lstContenidos.DataSource = myCont.GetContenidosNoEnAgenda(mysalon.id, mysalon.idRoot)
        lstContenidos.DataTextField = "Titulo"
        lstContenidos.DataValueField = "idContenido"
        lstContenidos.DataBind()





    End Sub

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        borrarMensajes()
        Response.Redirect("EditAgenda.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&fecha=" & Request("fecha"))
    End Sub




    Protected Sub drpSeleccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpSeleccion.SelectedIndexChanged

        Select Case drpSeleccion.SelectedValue
            Case "Actividades"
                esconderTodo(False)
                lstActividades.Visible = True
               ' lblMensajeActividades.visible = True
            Case "Foros"
                esconderTodo(False)
                lstForos.Visible = True
                lblMensajeActividades.visible = False
            Case "Contenidos"
                esconderTodo(False)
                lstContenidos.Visible = True
                lblMensajeActividades.visible = False
            Case "Eventos"
                esconderTodo(False)
                PanelAgenda.Visible = True
                lblMensajeActividades.visible = False
        End Select

    End Sub


    Dim fechainicio As DateTime
    Dim fechafin As DateTime

    Private Function fechasCorrectas() As Boolean
        Dim regreso As Boolean = True

        If txtFecha1.Text <> "" Then
            If IsDate(txtFecha1.Text) Then
                fechainicio = DateTime.Parse(txtFecha1.Text & " " & drphora.SelectedValue & ":" & drpMinutos.SelectedValue & ":00 " & drpAMPM.SelectedValue)
            Else
                regreso = False
            End If
        Else
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            fechainicio = DateTime.Parse(mysv.fechaInicio.ToShortDateString & " 00:00:00 AM")
        End If


        If IsDate(txtFecha2.Text) Then
            If drphorafin.SelectedValue = "11" And drpminutosfin.SelectedValue = "59" And drpampmfin.SelectedValue = "PM" Then
                fechafin = DateTime.Parse(txtFecha2.Text & " " & drphorafin.SelectedValue & ":" & drpminutosfin.SelectedValue & ":59 " & drpampmfin.SelectedValue)
            Else
                fechafin = DateTime.Parse(txtFecha2.Text & " " & drphorafin.SelectedValue & ":" & drpminutosfin.SelectedValue & ":00 " & drpampmfin.SelectedValue)
            End If

        Else
            regreso = False
        End If

        If fechafin < fechainicio Then
            regreso = False
        End If

        Return regreso


    End Function

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click



        If fechasCorrectas() Then
            Dim i As Integer = 0
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            Dim myagenda As Comm.Agenda = New Comm.Agenda

            If lstActividades.Visible Then
                For i = 0 To lstActividades.Items.Count - 1
                    If lstActividades.Items(i).Selected Then
                        myagenda = New Comm.Agenda()
                        myagenda.idSalonVirtual = mysv.id
                        myagenda.idProc = CInt(lstActividades.Items(i).Value)
                        myagenda.procedencia = "Actividad"
                        myagenda.titulo = ""
                        myagenda.nota = ""
                        myagenda.fecha = fechafin
                        myagenda.fechaInicio = fechainicio
                        myagenda.activarLimite = chkImpedir.Checked

                        myagenda.Add()


                        'Try
                        'Dim myAsv As New Contenidos.ActividadSalonVirtual(myagenda.idProc, myagenda.idSalonVirtual)
                        '    If myAsv.existe Then
                        '        Dim mycga As UM.Carga_Grupo_Actividad = New UM.Carga_Grupo_Actividad(myAsv.id)
                        '        If mycga.existe Then
                        '            mycga.Fecha = myagenda.fecha
                        '            mycga.Agendada_Skolar = "S"
                        '            mycga.Update()
                        '        End If
                        '    End If
                        '  Catch ex As Exception
                        '  lblMensajeUM.Visible = True
                        '  End Try



                        'Dim myci As New Lego.ClasificacionItem(mysv.idRoot, myagenda.idProc, myagenda.procedencia)
                        'Dim ligaActividad As String = myagenda.nota & "\n" & "http://Skolar.um.edu.mx/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & mysv.id & "&idCI=" & myci.id
                        'Dim calendarID As String = CrearCalendario(mysv.id)
                        'Dim mysrCal As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")
                        'Dim eventid As String = mysrCal.createEvent(calendarID, myagenda.titulo, ligaActividad, Format(myagenda.fechaInicio, "yyyy-MM-ddT6:00:00-HH:mm"), Format(myagenda.fecha, "yyyy-MM-ddT6:00:00-HH:mm"))
                        'myagenda.EventID = eventid
                        'myagenda.Update()

                    End If
                Next
            End If
            If lstContenidos.Visible Then
                For i = 0 To lstContenidos.Items.Count - 1
                    If lstContenidos.Items(i).Selected Then
                        myagenda = New Comm.Agenda()
                        myagenda.idSalonVirtual = mysv.id
                        myagenda.idProc = CInt(lstContenidos.Items(i).Value)
                        myagenda.procedencia = "Contenido"
                        myagenda.titulo = ""
                        myagenda.nota = ""
                        myagenda.fecha = fechafin
                        myagenda.fechaInicio = fechainicio
                        myagenda.activarLimite = chkImpedir.Checked

                        myagenda.Add()
                        'Dim calendarID As String = CrearCalendario(mysv.id)
                        'Dim mysrCal As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")
                        'Dim eventid As String = mysrCal.createEvent(calendarID, myagenda.titulo, myagenda.nota, Format(myagenda.fechaInicio, "yyyy-MM-ddT6:00:00-HH:mm"), Format(myagenda.fecha, "yyyy-MM-ddT6:00:00-HH:mm"))
                        'myagenda.EventID = eventid
                        'myagenda.Update()
                    End If
                Next
            End If
            If lstForos.Visible Then
                For i = 0 To lstForos.Items.Count - 1
                    If lstForos.Items(i).Selected Then
                        myagenda = New Comm.Agenda()
                        myagenda.idSalonVirtual = mysv.id
                        myagenda.idProc = CInt(lstForos.Items(i).Value)
                        myagenda.procedencia = "Foro"
                        myagenda.titulo = ""
                        myagenda.nota = ""
                        myagenda.fecha = fechafin
                        myagenda.fechaInicio = fechainicio
                        myagenda.activarLimite = chkImpedir.Checked

                        myagenda.Add()
                        'Dim calendarID As String = CrearCalendario(mysv.id)
                        'Dim mysrCal As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")
                        'Dim eventid As String = mysrCal.createEvent(calendarID, myagenda.titulo, myagenda.nota, Format(myagenda.fechaInicio, "yyyy-MM-ddT6:00:00-HH:mm"), Format(myagenda.fecha, "yyyy-MM-ddT6:00:00-HH:mm"))
                        'myagenda.EventID = eventid
                        'myagenda.Update()
                    End If
                Next
            End If

            If PanelAgenda.Visible Then
                myagenda = New Comm.Agenda()
                myagenda.idSalonVirtual = mysv.id
                myagenda.idProc = CInt(Request("idSalonVirtual"))
                myagenda.procedencia = "SalonVirtual"
                myagenda.titulo = txtTitulo.Text
                myagenda.nota = txtTextoCorto.Text
                myagenda.fecha = fechafin
                myagenda.fechaInicio = fechainicio
                myagenda.activarLimite = chkImpedir.Checked

                myagenda.Add()
                'Dim calendarID As String = CrearCalendario(mysv.id)
                'Dim mysrCal As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")
                'Dim eventid As String = mysrCal.createEvent(calendarID, myagenda.titulo, myagenda.nota, Format(myagenda.fechaInicio, "yyyy-MM-ddT6:00:00-HH:mm"), Format(myagenda.fecha, "yyyy-MM-ddT6:00:00-HH:mm"))
                'myagenda.EventID = eventid
                'myagenda.Update()
            End If


            cargarAgenda(myagenda.fecha)
            llenarListas()
        Else
            lblMensajeFechas.Visible = True
        End If


    End Sub

    'Public Function CrearCalendario(SalonVirtual As Integer) As String
    '    Dim mysrCald As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")

    '    Dim mysv As New Know.SalonVirtual(SalonVirtual, False)
    '    If mysv.calendarID = "" Then
    '        mysv.calendarID = mysrCald.createCalendar(mysv.nombre & mysv.claveAux1, mysv.horarioAtencion)
    '        mysv.Update()

    '    End If

    '    Return mysv.calendarID
    'End Function

    Protected Sub CustomValidator3_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator3.ServerValidate
        If IsDate(txtFecha1.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        If IsDate(txtFecha2.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("Calendario.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&fecha=" & Request("fecha") & "&mes=1")

    End Sub



    Function esmaestro() As Boolean
        Dim mysalonVirtual As Know.SalonVirtual
        Dim myuser As MasUsuarios.UserProfile
        mysalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)

        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        If mypermisos.existe Then
            Return True
        Else

            If Session("esAdministrador") Or Session("esGerenciaSalones") Then
                Return True
            End If
            Return False

        End If
    End Function


End Class
