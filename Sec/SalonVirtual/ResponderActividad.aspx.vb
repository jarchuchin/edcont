Imports System.Net.Mail
Imports System.Net
Imports System.Configuration
Partial Class Sec_SalonVirtual_ResponderActividad
    Inherits System.Web.UI.Page






    Private myActividad As Contenidos.Actividad
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("idActividad") = CInt(Request("idA"))
            myActividad = New Contenidos.Actividad(CInt(Session("idActividad")))
            If myActividad.existe Then
                colocarDatos()
            End If

        End If
    End Sub




    Sub colocarDatos()
        Dim myrespuesta As Contenidos.Respuesta = New Contenidos.Respuesta(0, myActividad.id, myActividad.tipo.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
        Dim mycal As Comm.Agenda = New Comm.Agenda(CInt(Request("idSalonVirtual")), myActividad.id, myActividad.tipo.ToString)
        If mycal.existe Then
            lblFechaEntrega.Text = mycal.fecha.ToLongDateString & " " & mycal.fecha.ToShortTimeString
        End If

        lblinstrucciones.Text = myActividad.instrucciones
     

        If myrespuesta.existe Then

            claveRespuesta = myrespuesta.id

            Panel1.Visible = True
            txtid.Text = myrespuesta.id
            txtMensaje.text = myrespuesta.texto
            Calificacion.Text = Format(myrespuesta.calificacion / 10, "0.0")
            If Not myrespuesta.status = Contenidos.StatusRespuesta.Enviada Then
                fechaRevision.Text = Format(myrespuesta.fechaRevision, "f")
            End If
            fechaRegistro.Text = Format(myrespuesta.fechaRegistro, "f")
            observaciones.Text = myrespuesta.observaciones



            Select Case myActividad.comoSeCalifica
                Case Contenidos.EComoSeCalifica.RubricaA
                    llenarRubricaTableA(myActividad.id)
                Case Contenidos.EComoSeCalifica.Rubrica
                    llenarRubricaTable(myActividad.id)
            End Select

            If myrespuesta.calificacion > 0 And myrespuesta.repetir Then
                btnGrabar.Visible = myrespuesta.repetir
            End If



            If Not btnGrabar.Visible Then
                lblMensajeReenviar.Visible = True
            End If



            colocarDatosEnCaja(myrespuesta)

            If myActividad.quienCalifica = Contenidos.EQuienCalifica.Alumnos Then
                lnkCalificaciones.Visible = True
                lnkCalificaciones.NavigateUrl = "~/Sec/SalonVirtual/CalificacionesActividad.aspx?idSalonVirtual=" & myrespuesta.idSalonVirtual & "&idR=" & myrespuesta.id
            Else
                lnkCalificaciones.Visible = False
            End If

            If myActividad.mostrarRespuestas Or myActividad.mostrarObservaciones Or myActividad.mostrarCalificacion Then
                Dim mysalon As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
                Dim myci As New Lego.ClasificacionItem(mysalon.idRoot, myActividad.id, myActividad.tipo.ToString)
                lnkVerRespuestas.Visible = True
                lnkVerRespuestas.NavigateUrl = "~/Sec/SalonVirtual/Verrespuestascompas.aspx?idSalonVirtual=" & myrespuesta.idSalonVirtual & "&idR=" & myrespuesta.id & "&idCI=" & myci.id

            Else
                lnkVerRespuestas.Visible = False
            End If

            'seccion para impedir envio de tarea despues de fecha limite
            btnGrabar.Visible = False



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
                        If myrespuesta.repetir Then
                            lblFechaVencida.Visible = False
                            btnGrabar.Visible = True
                        End If
                    Else
                        lblFechaVencida.Visible = False
                        btnGrabar.Visible = False
                        If myrespuesta.repetir Then
                            lblFechaVencida.Visible = False
                            btnGrabar.Visible = True
                        End If
                    End If

                End If


            Else
                lblFechaVencida.Visible = False

                If myrespuesta.repetir Then
                    btnGrabar.Visible = True
                Else
                    btnGrabar.Visible = False
                End If


            End If
            '  txtMensaje.Text = mycal.existe & mycal.fecha & "--" & mycal.fechaInicio
            'termina seccion para impedir envio de tareas de fecha limite

        Else
            Dim mySVU As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(Session("gUserProfileSession").idUserProfile), CInt(Request("idSalonVirtual")), False)
            If Not mySVU.existe Then
                btnGrabar.Visible = False
                lblMensajePermiso.Visible = True
            End If
            lnkCalificaciones.Visible = False

            Select Case myActividad.comoSeCalifica
                Case Contenidos.EComoSeCalifica.RubricaA
                    llenarRubricaTableA(myActividad.id)
                Case Contenidos.EComoSeCalifica.Rubrica
                    llenarRubricaTable(myActividad.id)
            End Select


            'seccion para impedir envio de tarea despues de fecha limite

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


            displayRespuestasComentarios1.Visible = False
            'txtMensaje.Text = mycal.existe & mycal.fecha & "--" & mycal.fechaInicio & "--" & myr
            'termina seccion para impedir envio de tareas de fecha limite
        End If

        Page.Title = myActividad.titulo
        lbltitulo.Text = myActividad.titulo

        Dim myie As New Contenidos.ActividadSalonVirtual(myActividad.id, CInt(Request("idSalonVirtual")))
        If myie.existe Then
            btnGrabar.Visible = True
        Else
            btnGrabar.Visible = False
        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        Dim esmaestroloc As Boolean = esmaestro()



        If esmaestroloc Then
            'Colocar menu
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        End If


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



    Sub llenarRubricaTable(claveActividad As Integer)


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

    Sub colocarDatosEnCaja(ByVal myR As Contenidos.Respuesta)

        displayRespuestaArchivos1.idRespuesta = myR.id

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Page.IsValid Then


            myActividad = New Contenidos.Actividad(CInt(Session("idActividad")))
            If myActividad.existe Then
                'seccion para impedir envio de tarea despues de fecha limite
                Dim myrespuesta As Contenidos.Respuesta = New Contenidos.Respuesta(0, myActividad.id, myActividad.tipo.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
                Dim mycal As Comm.Agenda = New Comm.Agenda(CInt(Request("idSalonVirtual")), myActividad.id, myActividad.tipo.ToString)

               



                If Not lblFechaVencida.Visible Then
                    If CInt(Session("gUserProfileSession").idUserProfile) > 0 Then
                        If txtid.Text <> "" Then
                            Session("idActividad") = 0
                            editar()
                        Else
                            Session("idActividad") = 0
                            grabar()
                        End If
                    Else
                        'enviar a alumnos a la fregada
                    End If
                End If

            End If



        End If

    End Sub




    Sub editar()
        Dim myRespuesta As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(txtid.Text))
        '      myRespuesta.titulo = lbltitulo.Text
        myRespuesta.texto = txtMensaje.Text
        myRespuesta.FechaEnvio = Date.Now
        myRespuesta.status = Contenidos.StatusRespuesta.Enviada
        myRespuesta.Update()
        If myRespuesta.id > 0 Then
            subirArchivosyLigas(myRespuesta)
        End If


        Response.Redirect("EsquemaEvaluacionAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub

    Sub grabar()
        Dim myRespuesta As Contenidos.Respuesta = New Contenidos.Respuesta
        myRespuesta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myRespuesta.idRaiz = 0
        myRespuesta.idProc = myActividad.id
        myRespuesta.procedencia = myActividad.tipo.ToString
        myRespuesta.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myRespuesta.titulo = myActividad.titulo
        myRespuesta.texto = txtMensaje.Text
        myRespuesta.Observaciones = ""
        myRespuesta.Calificacion = 0
        myRespuesta.FechaEnvio = Date.Now
        myRespuesta.FechaRevision = Date.Now
        myRespuesta.status = Contenidos.StatusRespuesta.Enviada
        myRespuesta.repetir = False
        myRespuesta.Add()
        If myRespuesta.id > 0 Then
            subirArchivosyLigas(myRespuesta)
        End If


        EnviarCorreo()

        Response.Redirect("EsquemaEvaluacionAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual"))



    End Sub

    Function subirArchivosyLigas(ByVal myR As Contenidos.Respuesta) As Integer
        'seccion para subir archivos 
        Dim myra As Contenidos.RespuestaArchivo


        If File1.PostedFile.FileName <> "" Then
            myra = New Contenidos.RespuestaArchivo
            myra.idRespuesta = myR.id
            myra.fechaCreacion = Date.Now

            Dim extension As String = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(".") + 1)
            Dim nombreoriginal As String = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\") + 1)
            myra.nombre = ""
            myra.nombreOriginal = nombreoriginal
            myra.espacio = File1.PostedFile.ContentLength
            myra.Add()

            Dim nombre As String = myra.id & "." & extension
            myra.nombre = nombre
            File1.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & myra.nombre)
            myra.Update()

        End If
        If File2.PostedFile.FileName <> "" Then
            myra = New Contenidos.RespuestaArchivo
            myra.idRespuesta = myR.id
            myra.fechaCreacion = Date.Now

            Dim extension As String = File2.PostedFile.FileName.Substring(File2.PostedFile.FileName.LastIndexOf(".") + 1)
            Dim nombreoriginal As String = File2.PostedFile.FileName.Substring(File2.PostedFile.FileName.LastIndexOf("\") + 1)
            myra.nombre = ""
            myra.nombreOriginal = nombreoriginal
            myra.espacio = File2.PostedFile.ContentLength
            myra.Add()

            Dim nombre As String = myra.id & "." & extension
            myra.nombre = nombre
            File2.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & myra.nombre)
            myra.Update()
        End If



        Return 1

    End Function

    Dim claveRespuesta As Integer

    Public Function GetCalificacionRubro(claveRubricaAlumno As Integer) As Integer
        Dim myRRubrica As New Contenidos.RespuestaRubrica(claveRespuesta, claveRubricaAlumno)
        Return myRRubrica.calificacion1


    End Function


    Public Function EnviarCorreo() As Integer

        Dim myup As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim direcciones As MailAddressCollection = New MailAddressCollection
        'Dim direccionesreplayto As MailAddressCollection = New MailAddressCollection

        'direccionesreplayto.Add(txtmailfrom.Text)


        Dim i As Integer



        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("info@skolar.online")
        MailMsg.To.Add(Trim(myup.email))







        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = "Recepción de actividad - " & lbltitulo.Text
            ' .ReplyToList.Add(txtmailfrom.Text)
            .Body = GetMensaje(myuser)
            .IsBodyHtml = True
            '.ReplyToList = direccionesreplayto
            '  .Headers.Add("X-SES-CONFIGURATION-SET", "ConfigSet")
        End With

        Dim numero As Integer = 0

        Dim f As New System.Net.Mail.SmtpClient("email-smtp.us-east-2.amazonaws.com")
        f.UseDefaultCredentials = False

        f.Port = 587


        ' f.Credentials = New System.Net.NetworkCredential()



        f.Credentials = New System.Net.NetworkCredential("AKIA4Q73D2ZEPWTSJE6K", "BDe+3nCDgRQ+h8HfccP1UyEb6G3DiqjSXUrX+x5PdpAF")
        f.EnableSsl = True
        f.DeliveryMethod = SmtpDeliveryMethod.Network
        'Try
        f.Send(MailMsg)
        '   Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
        'Catch ex As Exception

        'End Try
        ' f.Send(MailMsg)

        Return 1
    End Function


    Public Function GetMensaje(myup As MasUsuarios.UserProfile) As String
        Dim mye As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))


        Dim cadena As New StringBuilder()

        cadena.AppendLine("Estimado: " & myup.nombre & " " & myup.apellidos)
        cadena.AppendLine("<br>")

        cadena.AppendLine("<b>" & mye.nombre & "</b>, te agradece la participación en el envío de tus actividades académicas.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("Confirmamos la recepción de la siguiente actividad.")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("<b>Tipo de actividad</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine("Asincrónicas")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        Dim myA = New Contenidos.Actividad(CInt(Request("idA")))
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myasv As New Contenidos.ActividadSalonVirtual(myA.id, mysv.id)

        Dim myci As New Lego.ClasificacionItem(mysv.idRoot, myA.id, "Actividad")
        Dim myc As New Lego.Clasificacion(myci.idClasificacion)

        cadena.AppendLine("<b>Unidad de Actividad</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(myc.titulo)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")



        cadena.AppendLine("<b>Actividad</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(myA.titulo)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")



        Dim myie As New Know.ItemEvaluacion(myasv.idItemEvaluacion)

        cadena.AppendLine("<b>Valor de la actividad</b>")
        cadena.AppendLine("<br>")
        If myie.valor > 0 Then
            cadena.AppendLine(Format((myasv.valor * myie.valor) / 100, "0.00") & "%")
        Else
            cadena.AppendLine(Format(0, "0.00") & "%")
        End If
        ' cadena.AppendLine(Format((myasv.valor * 100) / myie.valor, "0.00") & "%")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")




        Dim mysvup As New Know.SalonVirtualUserProfile(CInt(Session("gUserProfileSession").idUserProfile), mysv.id)
        Dim computado As Decimal = mysvup.GetCalificacionGeneral(CInt(Session("gUserProfileSession").idUserProfile), mysv.id)

        cadena.AppendLine("<b>Avance general del curso</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine(Format(computado, "0.0") & "% de 100%")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        Dim mydoc As New MasUsuarios.UserProfile(mysv.idUserProfile, False)

        cadena.AppendLine("<b>" & mye.nombre & "</b>")
        cadena.AppendLine("<br>")
        cadena.AppendLine("<b>Curso:</b> " & mysv.nombre)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<b>Tutor:</b> " & mydoc.nombre & " " & mydoc.apellidos)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")


        cadena.AppendLine("<b>Fecha:</b> " & Date.Now)
        cadena.AppendLine("<br>")
        cadena.AppendLine("<br>")
        cadena.AppendLine()


        Return cadena.ToString
    End Function

End Class
