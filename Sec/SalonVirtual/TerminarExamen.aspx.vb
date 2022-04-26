
Partial Class Sec_SalonVirtual_TerminarExamen
    Inherits System.Web.UI.Page

    Dim myci As Lego.ClasificacionItem
    Dim myA As Contenidos.Actividad
    Dim myRespuesta As Contenidos.Respuesta

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        validarEntradaAlExamen()

        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub


    Sub iniciarControles()



        If Request("idCI") <> "" And Request("idSalonVirtual") <> "" And CInt(Session("gUserProfileSession").idUserProfile) > 0 Then

            lbltituloexamen.Text = myA.titulo
            Dim myP As Examenes.Pregunta = New Examenes.Pregunta
            Dim myr As Examenes.ExRespuesta = New Examenes.ExRespuesta


            Dim contestadas As Integer = myr.Count(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)
            Dim existentes As Integer
            If myA.activarBanco Then
                Dim myexorden As New Examenes.ExOrden(myA.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))

                Dim cadena() As String = myexorden.Orden.Split(",")
                existentes = cadena.Length

            Else
                existentes = myP.Count(myA.id)
            End If


            preguntasContestadas.Text = contestadas & "/" & existentes


            If Not contestadas >= existentes Then
                btnGrabar.Visible = False
                lblerrorcontestarpreguntas.Visible = True
            End If


            'seccion para impedir envio de tarea despues de fecha limite
            myRespuesta = New Contenidos.Respuesta(0, myA.id, myA.tipo.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            Dim mycal As Comm.Agenda = New Comm.Agenda(CInt(Request("idSalonVirtual")), myA.id, myA.tipo.ToString)
            Dim mycalUsuario As Comm.Agenda = New Comm.Agenda(CInt(Request("idSalonVirtual")), myA.id, myA.tipo.ToString, CInt(Session("gUserProfileSession").idUserProfile))

            If Not myRespuesta.existe Then
                If mycal.existe Then
                    If mycal.fecha >= Date.Now Then
                        btnGrabar.Visible = True
                        If mycal.fechaInicio >= Date.Now Then
                            btnGrabar.Visible = False
                        End If
                    Else
                        If mycal.activarLimite Then
                            lblFechaVencida.Visible = True
                            btnGrabar.Visible = False
                        Else
                            lblFechaVencida.Visible = False
                            btnGrabar.Visible = True
                        End If

                    End If


                Else
                    btnGrabar.Visible = True
                End If


                'revisarUsuario
                If mycalUsuario.existe Then
                    If mycalUsuario.fecha >= Date.Now Then
                        btnGrabar.Visible = True
                        If mycalUsuario.fechaInicio >= Date.Now Then
                            btnGrabar.Visible = False
                        End If
                    Else
                        If mycalUsuario.activarLimite Then
                            lblFechaVencida.Visible = True
                            btnGrabar.Visible = False
                        Else
                            lblFechaVencida.Visible = False
                            btnGrabar.Visible = True
                        End If

                    End If

                End If


            Else
                btnRecontestar0.Visible = True
            End If




            'nueva seccion de autoevaluacion
            If myA.Autoevaluacion Then


                If btnGrabar.Visible = True Then
                    lblMensaje2.Visible = True
                    lblMensaje.Visible = False
                Else
                    lblMensaje2.Visible = False
                    lblMensaje.Visible = False
                    btnRecontestar.Visible = True
                    llenarGrid()
                End If




            End If

            '     lblMensaje.Text &= myA.Autoevaluacion & "-" & btnGrabar.Visible


            '  txtMensaje.Text = mycal.existe & mycal.fecha & "--" & mycal.fechaInicio
            'termina seccion para impedir envio de tareas de fecha limite


        End If

        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))

        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)
        Dim objClasificacionItem As New Lego.ClasificacionItem(CInt(Request("idCI")))
        Dim objClasificacion As New Lego.Clasificacion(objClasificacionItem.idClasificacion)
        Dim objActividad As New Contenidos.Actividad(objClasificacionItem.idProc)

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



        ' lblClasificacion.Text = objClasificacion.titulo
        ' lbltitulo.Text = objActividad.titulo

        'colocarDatosCalificacion()



    End Sub

    Sub validarEntradaAlExamen()
        myci = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myA = New Contenidos.Actividad(myci.idProc)

        If Request("idCI") <> "" And Request("idSalonVirtual") <> "" And CInt(Session("gUserProfileSession").idUserProfile) > 0 Then
            myRespuesta = New Contenidos.Respuesta(0, myci.idProc, "Actividad", CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myRespuesta.existe Then
                colocarDatosCalificacion()
                panelResumen.Visible = True
            Else
                panelResumen.Visible = False
            End If

        Else
            lblsimulacion.Visible = True
            Panel1.Visible = False
            btnGrabar.Visible = False
            btnCancelar.Visible = False
            lblMensaje.Visible = False
        End If

    End Sub

    Sub colocarDatosCalificacion()

        Dim myExR As Examenes.ExRespuesta = New Examenes.ExRespuesta
        Dim myR As Contenidos.Respuesta = New Contenidos.Respuesta(0, myA.id, "Actividad", CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))

        Dim fechainicio, fechafin As Date
        fechainicio = myExR.GetPrimeraRespuesta(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)
        fechafin = myExR.GetUltimaRespuesta(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)

        inicio.Text = fechainicio
        fin.Text = fechafin

        Dim calif As Decimal = myExR.GetSumaValorObtenido(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)


        Dim puntosTotalesLocal As Decimal = 0

        If myA.activarBanco Then
            Dim myexorden As New Examenes.ExOrden(myA.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))

            If Not myexorden.existe Then
                Dim myP As Examenes.Pregunta = New Examenes.Pregunta
                Dim ordenPreguntas As String = myP.GetDRAleatorioNumPreguntas(myA.id, myA.totalPreguntas)
                myexorden.idActividad = myA.id
                myexorden.idSalonVirtual = CInt(Request("idSalonVirtual"))
                myexorden.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                myexorden.Orden = ordenPreguntas
                myexorden.Fecha = Date.Now
                myexorden.Add()
            End If


            puntosTotalesLocal = getValorPreguntas(myexorden.Orden)
        Else
            puntosTotalesLocal = myA.puntosTotales
        End If
        'colocar calificacion 

        'Dim comentario As String = ""
        'If puntosTotalesLocal > 0 Then
        '    calif = (calif / puntosTotalesLocal) * 100
        'Else
        '    calif = 0
        '    comentario = "El examen no esta configurado correctamente favor de revisar el examen"
        'End If


        calificacion.Text = CDec(calif) & "/" & puntosTotalesLocal


        totalMinutos.Text = fechafin.Subtract(fechainicio).TotalMinutes



        Panel1.Visible = True
        btnGrabar.Visible = False
        btnCancelar.Visible = False
        lblMensaje.Visible = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
            Dim cadena As String = "login.aspx?ReturnUrl=" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/examenes/TerminarExamen.aspx?idSalonVirtual" & Request("idSalonVirtual") & "&idCI=" & Request("idCI")
            Response.Redirect(cadena)
        Else
            calificar()
            ' colocarDatosCalificacion()
        End If

    End Sub

    Function calificar() As Boolean

        Dim myp As Examenes.Pregunta = New Examenes.Pregunta
        Dim myExR As Examenes.ExRespuesta = New Examenes.ExRespuesta
        Dim calif As Decimal = myExR.GetSumaValorObtenido(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)

        Dim status As Byte = Contenidos.StatusRespuesta.Calificada
        If myp.HayPreguntasDirectasODesarrollo(myA.id) Then
            lblEstatus.Visible = True
            status = Contenidos.StatusRespuesta.Enviada
        Else
            status = Contenidos.StatusRespuesta.Calificada
        End If

        Dim puntosTotalesLocal As Decimal = 0

        If myA.activarBanco Then
            Dim myexorden As New Examenes.ExOrden(myA.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            puntosTotalesLocal = getValorPreguntas(myexorden.Orden)
        Else
            puntosTotalesLocal = myA.puntosTotales
        End If
        'colocar calificacion 

        Dim comentario As String = ""
        If puntosTotalesLocal > 0 Then
            calif = (calif / puntosTotalesLocal) * 100
        Else
            calif = 0
            comentario = "El examen no esta configurado correctamente favor de revisar el examen"
        End If

        'minutos 
        Dim fechainicio, fechafin As Date
        fechainicio = myExR.GetPrimeraRespuesta(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)
        fechafin = myExR.GetUltimaRespuesta(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile), myA.id)


        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta
        myr.idProc = myA.id
        myr.procedencia = myA.tipo.ToString
        myr.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myr.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myr.observaciones = comentario
        myr.Repetir = False
        myr.Status = status
        myr.texto = fechafin.Subtract(fechainicio).TotalMinutes.ToString
        myr.titulo = myA.titulo
        If calif > 100 Then
            calif = 100
        End If
        myr.Calificacion = calif
        myr.FechaEnvio = Date.Now
        myr.FechaRevision = Date.Now
        myr.Add()

        myr.Update()


        Panel1.Visible = True
        btnGrabar.Visible = False
        btnCancelar.Visible = False


        'actualizar calificacion general
        Dim mysvup As New Know.SalonVirtualUserProfile(myr.idUserProfile, myr.idSalonVirtual, False)
        If mysvup.existe Then
            mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myr.idUserProfile, myr.idSalonVirtual)
            mysvup.Update()


            Response.Redirect("TerminarExamen.aspx" & "?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual"))
        Else
            lblMensaje.Text = "Error al buscar el registro del alumno"
            lblMensaje.Visible = True
        End If






    End Function



    Private Function getValorPreguntas(cadenaPreguntas As String) As Decimal

        Dim cadena() As String = cadenaPreguntas.Split(",")

        Dim myp As Examenes.Pregunta

        Dim valor As Decimal = 0


        For i As Integer = 0 To cadena.Length - 1
            myp = New Examenes.Pregunta(CInt(cadena(i)))

            valor = valor + myp.valor
        Next

        Return valor


    End Function



    Sub llenarGrid()
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta
        '  estudiante.text = estudiante.text & " --- " & myactividad.id
        dtgItem.DataSource = myP.GetDS(myA.id)
        dtgItem.DataBind()
    End Sub

    Protected Function GetEnunciado(ByVal claveEnunciado As String) As String
        Return claveEnunciado.Replace(vbCrLf, "<br>")
    End Function

    Private Sub dtgItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then

            Dim myControllit As Literal = CType(e.Item.FindControl("litRespuesta"), Literal)
            Dim myControltxt As Label = CType(e.Item.FindControl("txtValorObtenido"), Label)
            Dim myplaceholder As PlaceHolder = CType(e.Item.FindControl("myplaceholder"), PlaceHolder)
            Dim clavepregunta As Integer = CInt(dtgItem.DataKeys(e.Item.ItemIndex))
            Dim mycontrolclave As Literal = CType(e.Item.FindControl("litClave"), Literal)

            Dim myr As Examenes.ExRespuesta = New Examenes.ExRespuesta(clavepregunta, CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)
            Dim myp As Examenes.Pregunta = New Examenes.Pregunta(clavepregunta)

            Dim tipo As Integer = CInt(myControltxt.Text)
            Select Case tipo
                Case Examenes.ETipoPregunta.Directa
                    myControltxt.Enabled = True
                    myControllit.Text = myr.respuesta
                    mycontrolclave.Text = myp.respuesta
                Case Examenes.ETipoPregunta.Desarrollo
                    myControltxt.Enabled = True
                    myControllit.Text = myr.respuesta
                    mycontrolclave.Text = myp.respuesta
                Case Examenes.ETipoPregunta.FalsoVerdadero
                    myControltxt.Enabled = True
                    If myr.idORSeleccionada = Examenes.EFalsoVerdadero.falso Then
                        myControllit.Text = "<i>" & lblFalso.Text & "</i>"
                    Else
                        myControllit.Text = "<i>" & lblverdadero.Text & "</i>"
                    End If
                    If myp.idOR = Examenes.EFalsoVerdadero.falso Then
                        mycontrolclave.Text &= lblFalso.Text
                    Else
                        mycontrolclave.Text &= lblverdadero.Text
                    End If
                Case Examenes.ETipoPregunta.OpcionMultiple
                    myControltxt.Enabled = True
                    Dim myor As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(myr.idORSeleccionada)
                    myControllit.Text = "<i>" & myor.enunciado & "</i>"
                    myor = New Examenes.OpcionRespuesta(myp.idOR)
                    mycontrolclave.Text &= myor.enunciado
                Case Examenes.ETipoPregunta.RelacionColumnas
                    myControltxt.Enabled = True
                    'estudiante.Text = estudiante.Text & " -- " & myActividad.id & " -- " & myr.id & " --clavepregunta:" & clavepregunta & " --salonvirtual: " & CInt(Request("idSalonVirtual")) & " ---respuestauserprofile:" & myrespuesta.idUserProfile
                    If myr.existe Then
                        mycontrolclave.Text = myr.GetTablaRelacionColumnas(myr.id, True)
                    Else
                        mycontrolclave.Text = "<b>no contestada</b>"
                    End If
            End Select

            myControltxt.Text = myr.valorObtenido

        End If
    End Sub


   
    Protected Sub btnRecontestar_Click(sender As Object, e As System.EventArgs) Handles btnRecontestar.Click
        ' Remover respuestas y preguntas.

        If myRespuesta.existe Then


            Dim myuser As New MasUsuarios.EmpresaUserProfile(myRespuesta.idUserProfile, 4, "xyz")
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(myRespuesta.idSalonVirtual, False)
            Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual(myRespuesta.idProc, mysv.id)

            Dim myka As New UM.Krdx_Alumno_Activ(myuser.claveAux1, myASV.id, mysv.claveAux1)

            Dim myPreguntas As Examenes.Pregunta = New Examenes.Pregunta
            Dim dsPreguntas As System.Data.DataSet = myPreguntas.GetDS(myA.id)
            Dim myexrs As Examenes.ExRespuesta

            If myka.existe Then
                myka.Remove()
                myRespuesta.Remove()
                ' Response.Redirect("EvaluacionPorAlumno.aspx?idSalonVirtual=" & mysv.id & "&idUserProfile=" & myuser.idUserProfile)
            Else
                myRespuesta.Remove()
            End If

            Dim claveSalon As Integer = CInt(Request("idSalonVirtual"))
            For Each drow As System.Data.DataRow In dsPreguntas.Tables(0).Rows
                myexrs = New Examenes.ExRespuesta(CInt(drow("idPregunta")), claveSalon, myRespuesta.idUserProfile)
                If myexrs.existe Then
                    myexrs.Remove()
                End If
            Next

        End If


        'lbltituloexamen.Text = myRespuesta.existe

        Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))


    End Sub

    Protected Sub btnRecontestar0_Click(sender As Object, e As System.EventArgs) Handles btnRecontestar0.Click
        Response.Redirect("EsquemaEvaluacionAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermisos.existe
    End Function



End Class
