
Partial Class Sec_SalonVirtual_ContestarExamenListaPreguntas
    Inherits System.Web.UI.Page



    Public myCI As Lego.ClasificacionItem
    Dim myR As Contenidos.Respuesta
    Dim myA As Contenidos.Actividad



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iniciar()
        validarEntradaAlExamen()
        validarAgendayAlumnos(myCI)
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub





    Sub validarEntradaAlExamen()
        If Request("idCI") <> "" And Request("idSalonVirtual") <> "" Then
            myR = New Contenidos.Respuesta(0, myA.id, "Actividad", CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myR.existe Then
                lnkstatusexa.Text = lblExamenTerminado.Text
            Else
                lnkstatusexa.Text = lblTerminarexamen.Text
            End If
            lnkstatusexa.NavigateUrl = "TerminarExamen.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual")
        End If


    End Sub




    Sub iniciar()

        myCI = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myA = New Contenidos.Actividad(myCI.idProc)



        '################### 
        'Seccion de bread
        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objClasificacion As New Lego.Clasificacion(myCI.idClasificacion)
        '  Dim objActividad As New Contenidos.Actividad(myCI.idProc)


        If myA.activarBanco Then
            Dim myexo As New Examenes.ExOrden(myCI.idProc, mysv.id, CInt(Session("gUserProfileSession").idUserProfile))
            If Not myexo.existe Then
                Response.Redirect("ContestarExamen.aspx?idSalonVirtual=" & mysv.id & "&idCI=" & myCI.id & "&idA=" & myCI.idProc)
            End If
        End If

        Dim idSalonVirtual = mysv.id

        Page.Title = myA.titulo
        lblNombreTitulo.Text = myA.titulo

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
        lblCursoBread.Text = myA.titulo

    End Sub

    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermiso.existe
    End Function
    Sub iniciarControles()

        lbltituloexamen.Text = myA.titulo
        llenarGrid()


    End Sub

    Sub llenarGrid()
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta


        If examenEncursoAhora Then
            lnkstatusexa.Text = "El examen está en curso. Podrás ver tus respuestas en el periodo de revisión"
            '  UbicadorPreguntas1.Visible = False
        Else

            If myA.activarBanco Then

                Dim myexorden As New Examenes.ExOrden(myA.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
                Dim puntosTotalesLocal As Decimal = getValorPreguntas(myexorden.Orden)

                dtgItem.DataSource = getTablaPreguntas(myexorden.Orden)
                dtgItem.DataBind()

                totalexamen.Text = puntosTotalesLocal
            Else
                dtgItem.DataSource = myP.GetDS(myA.id)
                dtgItem.DataBind()
                totalexamen.Text = myA.puntosTotales
            End If


        End If




    End Sub


    Protected Function GetLiga(ByVal clavePregunta As Integer, ByVal claveTipoPregunta As Integer) As String
        Dim cadena As String = "?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & clavePregunta

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Directa
                cadena = "ContestarDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.Desarrollo
                cadena = "ContestarDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.FalsoVerdadero
                cadena = "ContestarFalsoVerdadero.aspx" & cadena
            Case Examenes.ETipoPregunta.OpcionMultiple
                cadena = "ContestarOpcionMultiple.aspx" & cadena
            Case Examenes.ETipoPregunta.RelacionColumnas
                cadena = "ContestarRelacionColumnas.aspx" & cadena
        End Select

        Return cadena

    End Function

    Protected Function GetEnunciado(ByVal claveEnunciado As String) As String
        Return claveEnunciado.Replace(vbCrLf, "<br>")
    End Function

    Protected Function GetStatus(ByVal clavePregunta As Integer) As String
        If Request("idCI") <> "" And Request("idSalonVirtual") <> "" Then
            Dim myExR As Examenes.ExRespuesta = New Examenes.ExRespuesta(clavePregunta, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myExR.existe Then
                Return lblContestada.Text
            Else
                Return lblnoContestada.Text
            End If
        Else
            Return lblnoContestada.Text
        End If

    End Function




    Private Function getTablaPreguntas(cadenaPreguntas As String) As System.Data.DataTable
        Dim mydt As New System.Data.DataTable
        Dim cadena() As String = cadenaPreguntas.Split(",")
        Dim dr As System.Data.DataRow
        mydt.Columns.Add("idPregunta")
        mydt.Columns.Add("idActividad")
        mydt.Columns.Add("idUserProfile")
        mydt.Columns.Add("idOR")
        mydt.Columns.Add("tipoPregunta")
        mydt.Columns.Add("enunciado")
        mydt.Columns.Add("archivo")
        mydt.Columns.Add("valor")
        mydt.Columns.Add("orden")
        mydt.Columns.Add("respuesta")
        mydt.Columns.Add("eliminado")
        mydt.Columns.Add("fileName")




        Dim myp As Examenes.Pregunta

        For i As Integer = 0 To cadena.Length - 1
            myp = New Examenes.Pregunta(CInt(cadena(i)))

            dr = mydt.NewRow
            dr("idPregunta") = myp.id
            dr("idActividad") = myp.idActividad
            dr("idUserProfile") = myp.idUserProfile
            dr("idOR") = myp.idOR

            dr("tipoPregunta") = myp.tipoPregunta
            dr("enunciado") = myp.enunciado
            dr("archivo") = myp.archivo
            dr("valor") = myp.valor
            dr("orden") = myp.orden
            dr("respuesta") = myp.respuesta
            dr("eliminado") = myp.Eliminado
            dr("fileName") = myp.fileName


            mydt.Rows.Add(dr)

        Next

        Return mydt


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




    Private Sub dtgItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then

            Dim myControllit As Literal = CType(e.Item.FindControl("litRespuesta"), Literal)
            Dim myControlRC As Label = CType(e.Item.FindControl("lblRespuestaCorrecta"), Label)
            Dim myControltxt As Label = CType(e.Item.FindControl("lbltipo"), Label)
            Dim myControlPuntos As Label = CType(e.Item.FindControl("lblPuntos"), Label)
            Dim myControlLabelRespuesta As Label = CType(e.Item.FindControl("labelrespuestafront"), Label)
            Dim myControlContestada As HyperLink = CType(e.Item.FindControl("lnkContestada"), HyperLink)


            myControlContestada.Text = lblnoContestada.Text
            myControlLabelRespuesta.Visible = False
            myControlRC.Visible = False
            myControlPuntos.Visible = False



            If Request("idCI") <> "" And Request("idSalonVirtual") <> "" Then

                Dim myxr As Examenes.ExRespuesta = New Examenes.ExRespuesta(CInt(dtgItem.DataKeys(e.Item.ItemIndex)), CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
                Dim myp As Examenes.Pregunta = New Examenes.Pregunta(myxr.idPregunta)

                If myxr.existe Then
                    myControlContestada.Text = lblContestada.Text

                    If myR.existe Then
                        myControlLabelRespuesta.Visible = True
                        myControlRC.Visible = True
                        myControlRC.Text = lblGuia.text
                        myControlPuntos.Visible = True
                        myControlPuntos.Text = "" ' Format(myxr.valorObtenido, "##0.00") & "<b>/</b>"

                        Dim tipo As Integer = CInt(myControltxt.Text)
                        Select Case tipo
                            Case Examenes.ETipoPregunta.Directa
                                myControllit.Text = myxr.respuesta
                                myControlRC.Text &= myp.respuesta
                            Case Examenes.ETipoPregunta.Desarrollo
                                myControllit.Text = myxr.respuesta
                                myControlRC.Text &= myp.respuesta
                            Case Examenes.ETipoPregunta.FalsoVerdadero
                                If myxr.idORSeleccionada = Examenes.EFalsoVerdadero.falso Then
                                    myControllit.Text = "<i>" & lblFalso.Text & "</i>"
                                Else
                                    myControllit.Text = "<i>" & lblverdadero.Text & "</i>"
                                End If
                                If myp.idOR = Examenes.EFalsoVerdadero.falso Then
                                    myControlRC.Text &= lblFalso.Text
                                Else
                                    myControlRC.Text &= lblverdadero.Text
                                End If

                            Case Examenes.ETipoPregunta.OpcionMultiple
                                'myControltxt.Enabled = True
                                Dim myor As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(myxr.idORSeleccionada)
                                myControllit.Text = "<i>" & myor.enunciado & "</i>"
                                myor = New Examenes.OpcionRespuesta(myp.idOR)
                                myControlRC.Text &= myor.enunciado
                            Case Examenes.ETipoPregunta.RelacionColumnas
                                'myControltxt.Enabled = True
                                myControllit.Text = myxr.GetTablaRelacionColumnas(myxr.id, False)
                        End Select

                        myControlRC.Text = "" ' mientras sabemos que pasa con las respuestas
                    End If


                End If

            End If





            ' myControltxt.Text = myr.valorObtenido

        End If
    End Sub

    Dim examenEncursoAhora As Boolean = False

    Sub validarAgendayAlumnos(objci As Lego.ClasificacionItem)


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myA As New Contenidos.Actividad(objci.idProc)


        Dim objAgenda As Comm.Agenda = New Comm.Agenda(mysv.id, myA.id, myA.tipo.ToString)
        Dim objAgendaUsuario As Comm.Agenda = New Comm.Agenda(mysv.id, myA.id, myA.tipo.ToString, CInt(Session("gUserProfileSession").idUserProfile))

        Dim permitirIngreso As Boolean = False
        Dim entro As Boolean = False



        If Not myR.existe Then

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

                        If objAgenda.fechaInicio >= Date.Now Then
                            permitirIngreso = False
                            examenEncursoAhora = True
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

                        If objAgenda.fechaInicio >= Date.Now Then
                            permitirIngreso = False
                            examenEncursoAhora = True
                        End If

                    End If


                End If


            End If






            If permitirIngreso = False And entro = True And examenEncursoAhora = False Then
                'el usuario ingreso a esta zona sin autorización
                Dim myb As New Know.Bitacora
                myb.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                myb.ip = Request.UserHostAddress
                myb.Modulo = "Examen"
                myb.Bitacora = "Ingreso NO AUTORIZADO al módulo de exámenes, " & myA.titulo & "-" & myA.id & "-" & mysv.id & "-" & mysv.claveAux1 & "-T.ListaPreguntas"
                myb.Fecha = Date.Now
                myb.idSalonVirtual = mysv.id
                myb.Add()
                Response.Redirect("~/sec/SalonVirtual/RestringirExamen.aspx")

            End If


            If Not mysv.fechaFin > Date.Now Then
                dtgItem.Visible = False
                lblmensajeautorizar.Visible = True


                Dim myb As New Know.Bitacora
                myb.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                myb.ip = Request.UserHostAddress
                myb.Modulo = "Examen"
                myb.Bitacora = "Alumnos entrando al exmaen despues de finalización de curso, " & myA.titulo & "-" & myA.id & "-" & mysv.id & "-" & mysv.claveAux1 & "-T.ListaPreguntas"
                myb.Fecha = Date.Now
                myb.idSalonVirtual = mysv.id
                myb.Add()


            End If

        Else

            If Date.Now <= objAgenda.fecha And Date.Now >= objAgenda.fechaInicio Then
                permitirIngreso = False
                examenEncursoAhora = True

                lnkstatusexa.Text = "El examen está en curso. Podrás ver tus respuestas en el periodo de revisión"


            End If







        End If



    End Sub


    Dim contador As Integer = 0

    Public Function getContador() As Integer

        contador = contador + 1

        Return contador

    End Function

End Class
