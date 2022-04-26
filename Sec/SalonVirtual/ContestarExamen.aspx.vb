Imports System.Data
Imports System.Data.SqlClient

Partial Class Sec_SalonVirtual_ContestarExamen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

        validarEntradaAlExamen(myci)
        validarAgendayAlumnos(myci)

        Dim myP As Examenes.Pregunta = New Examenes.Pregunta

        Dim mya As New Contenidos.Actividad(myci.idProc)

        Dim ordenPreguntas As String = ""
        Dim cantidadPreguntas As Integer = 0

        Dim myexo As New Examenes.ExOrden(mya.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
        If myexo.existe Then
            ordenPreguntas = myexo.Orden
        Else
            If mya.presentacionAleatoria Then
                If mya.activarBanco Then
                    'Colocar lista de preguntas  con maximo de preguntas mya.totalPreguntas
                    ordenPreguntas = myP.GetDRAleatorioNumPreguntas(mya.id, mya.totalPreguntas)
                Else
                    'Colocar lista de preguntas 
                    ordenPreguntas = myP.GetDRAleatorio(mya.id)
                End If

                If ordenPreguntas <> "" Then
                    myexo.idActividad = mya.id
                    myexo.idSalonVirtual = CInt(Request("idSalonVirtual"))
                    myexo.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                    myexo.Orden = ordenPreguntas
                    myexo.Fecha = Date.Now
                    myexo.Add()
                End If

            Else

                If mya.activarBanco Then
                    'Colocar lista de preguntas  con maximo de preguntas mya.totalPreguntas
                    ordenPreguntas = myP.GetDRAleatorioNumPreguntas(mya.id, mya.totalPreguntas)

                    If ordenPreguntas <> "" Then
                        myexo.idActividad = mya.id
                        myexo.idSalonVirtual = CInt(Request("idSalonVirtual"))
                        myexo.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                        myexo.Orden = ordenPreguntas
                        myexo.Fecha = Date.Now
                        myexo.Add()
                    End If

                Else
                    ' caso default para examenes normales. 
                    ' En esta opción el examen se presenta de forma normal
                    ' No hay cambios al modelo pues se barren todas las preguntas en el orden definido al configurar el examen
                    Dim dr As SqlDataReader = myP.GetDR(myci.idProc)
                    Dim cadena As String = ""
                    If dr.Read Then
                        myP = New Examenes.Pregunta(CType(dr("idPregunta"), Integer))
                    End If
                    dr.Close()
                    If myP.existe Then
                        cadena = "?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myP.id

                        Select Case myP.tipoPregunta
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


                        Response.Redirect(cadena)
                    Else
                        Response.Redirect("default.aspx")
                    End If

                End If



            End If


        End If





        Dim cadenaItems() As String = ordenPreguntas.Split(",")
        If cadenaItems.Length > 0 Then
            myP = New Examenes.Pregunta(CType(cadenaItems(0), Integer))
            Dim cadena As String = "?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myP.id

            Select Case myP.tipoPregunta
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
            Response.Redirect(cadena)
        End If





    End Sub




    Sub validarEntradaAlExamen(ByVal objci As Lego.ClasificacionItem)
        If Request("idCI") <> "" And Request("idSalonVirtual") <> "" Then
            Dim myR As Contenidos.Respuesta = New Contenidos.Respuesta(0, objci.idProc, objci.procedencia.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
            If myR.existe Or CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
                Dim myA As New Contenidos.Actividad(objci.idProc)

                Response.Redirect("TerminarExamen.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual"))
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
            'el usuario ingreso a esta zona sin autorización
            Dim myb As New Know.Bitacora
            myb.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myb.ip = Request.UserHostAddress
            myb.Modulo = "Examen"
            myb.Bitacora = "Ingreso NO AUTORIZADO al módulo de exámenes, " & myA.titulo & "-" & myA.id & "-" & mysv.id & "-" & mysv.claveAux1 & "-T.ContestarExamen"
            myb.Fecha = Date.Now
            myb.idSalonVirtual = mysv.id
            myb.Add()
            Response.Redirect("~/sec/SalonVirtual/RestringirExamen.aspx")

        End If


    End Sub
End Class
