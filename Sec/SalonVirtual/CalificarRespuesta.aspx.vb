
Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports System.IO


Partial Class Sec_SalonVirtual_CalificarRespuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If



        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    End Sub

    Sub colocarDatos()
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)

        If mya.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Response.Redirect("CalificarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & myr.id & "&pag=" & Request("pag"))
        End If


        Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myu.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        '   imgAlumno.ImageUrl = getFoto(myeu.claveAux1, myeu.claveAux2)
        imgAlumno.ImageUrl = "~/sec/showfile.aspx?idUserProfile=" & myeu.idUserProfile


        estudiante.Text = myu.nombre & " " & myu.apellidos
        fechaenvio.Text = myr.fechaEnvio.ToLongDateString & " " & myr.fechaEnvio.ToLongTimeString
        fecharegistro.Text = Format(myr.fechaRegistro, "f")
        actividad.Text = mya.titulo
        lbltextoinstrucciones.Text = mya.instrucciones
        txtCalificacion.Text = Format(myr.calificacion / 10, "0.0")
        txtMensaje.Text = myr.observaciones
        littexto.Text = myr.texto
        chkPermitir.Checked = myr.repetir

        If mya.quienCalifica = Contenidos.EQuienCalifica.Alumnos Then
            lnkCalificaciones.Visible = True
            lnkCalificaciones.NavigateUrl &= "?idSalonVirtual=" & myr.idSalonVirtual & "&idR=" & myr.id


            'Dim myrtemp As New Contenidos.Respuesta(myr.id, myr.idProc, myr.procedencia.ToString, myr.idSalonVirtual, Session("gUserProfileSession").idUserProfile)
            'If myrtemp.existe Then
            '    txtCalificacion.Text = Format(myrtemp.calificacion / 10, "0.0")
            'Else
            '    txtCalificacion.Text = "0.0"
            'End If

        Else
            lnkCalificaciones.Visible = False
        End If



        'Colocar adjuntos
        displayRespuestaArchivos1.idRespuesta = myr.id

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.Ranking Then
            PanelRanking.Visible = True
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.ValorNumerico Then
            PanelCalifica.Visible = True
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.Rubrica Then
            PanelRubrica.Visible = True

            llenarRubricaTable(mya.id)
            SetCalificacionRubrica(myr.id)
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.RubricaA Then
            panelRubricaA.Visible = True

            llenarRubricaTablea(mya.id)
            SetCalificacionRubricaA(myr)
        End If

        claveSalon = myr.idSalonVirtual
        claveUsuario = myr.idUserProfile
        claveRespuesta = myr.id



    End Sub


    Public Function getRubricasDrop(claveRubrica As Integer) As DataView

        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        Dim dTable As New DataTable("Rubrica")
        dTable.Columns.Add(New DataColumn("valor", GetType(Integer)))

        Dim dRow As DataRow = dTable.NewRow()
        dRow(0) = myrubrica.Val4
        dTable.Rows.Add(dRow)

        Dim dRow2 As DataRow = dTable.NewRow()
        dRow2(0) = myrubrica.Val3
        dTable.Rows.Add(dRow2)

        Dim dRow3 As DataRow = dTable.NewRow()
        dRow3(0) = myrubrica.Val2
        dTable.Rows.Add(dRow3)

        Dim dRow4 As DataRow = dTable.NewRow()
        dRow4(0) = myrubrica.Val1
        dTable.Rows.Add(dRow4)

        Return dTable.DefaultView

    End Function


    Public Function getRubricasDropA(claveRubrica As Integer) As DataView

        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        Dim dTable As New DataTable("Rubrica")
        dTable.Columns.Add(New DataColumn("valor", GetType(Integer)))

        Dim i As Integer = 0
        For i = myrubrica.Val1 To 0 Step -1
            Dim dRow4 As DataRow = dTable.NewRow()
            dRow4(0) = i
            dTable.Rows.Add(dRow4)
        Next

        'Dim dRow As DataRow = dTable.NewRow()
        'dRow(0) = myrubrica.Val4
        'dTable.Rows.Add(dRow)

        'Dim dRow2 As DataRow = dTable.NewRow()
        'dRow2(0) = myrubrica.Val3
        'dTable.Rows.Add(dRow2)

        'Dim dRow3 As DataRow = dTable.NewRow()
        'dRow3(0) = myrubrica.Val2
        'dTable.Rows.Add(dRow3)

        'Dim dRow4 As DataRow = dTable.NewRow()
        'dRow4(0) = myrubrica.Val1
        'dTable.Rows.Add(dRow4)

        Return dTable.DefaultView

    End Function

    Sub llenarRubricaTable(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricas.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricas.DataBind()

    End Sub


    Sub llenarRubricaTablea(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricaA.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricaA.DataBind()

    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        calificar()
    End Sub


    Sub calificar()

        Dim respuesta As Boolean = False
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)

        If myr.existe Then
            Select Case mya.quienCalifica
                Case Contenidos.EQuienCalifica.Alumnos
                    respuesta = calificanAlumnos()
                Case Contenidos.EQuienCalifica.Maestro
                    respuesta = calificanMaestros()
            End Select
        End If




        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(myr.idSalonVirtual, False)
        Dim mymaestro As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        If mymaestro.emailGoogle = "j.alvarado@um.edu.mx" Or mymaestro.emailGoogle = "jrsnchz@um.edu.mx" Then
            mymaestro = New MasUsuarios.UserProfile(mysalon.idUserProfile, False)
        End If
        Dim myalumno As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)

        If myalumno.email <> "" Then

            Try
                ''Dim MailMsg As New MailMessage("Skolar@um.edu.mx", myalumno.email)




                ''With MailMsg
                ''    .From = New MailAddress("Skolar@um.edu.mx", mymaestro.nombre & " " & mymaestro.apellidos)
                ''    .Subject = myr.titulo & " Calif: " & txtCalificacion.Text
                ''    .Body = "Actividad calificada: " & myr.titulo & vbCrLf & vbCrLf & _
                ''            "Calificación: " & txtCalificacion.Text & vbCrLf & vbCrLf & _
                ''            "Observaciones del maestro: " & myr.observaciones & vbCrLf & vbCrLf & _
                ''            "Ver actividad en el Skolar: http://Skolar.um.edu.mx/sec/SalonVirtual/ResponderActividad.aspx?idSalonVirtual=" & myr.idSalonVirtual & "&idA=" & mya.id & vbCrLf & vbCrLf & _
                ''            "Fecha: " & myr.fechaRevision & vbCrLf & vbCrLf

                ''    .IsBodyHtml = True
                ''    .ReplyTo = New MailAddress(mymaestro.emailGoogle)

                ''    If myalumno.emailGoogle <> "" Then
                ''        .CC.Add(myalumno.emailGoogle)
                ''    End If

                ''End With

                ''Dim numero As Integer = 0


                ''Dim f As New System.Net.Mail.SmtpClient()
                ''f.Host = "smtp.gmail.com"
                ' ''    f.Port = 465
                ''f.Credentials = New System.Net.NetworkCredential("Skolar@um.edu.mx", "alaska")
                ''f.EnableSsl = True
                ''f.Send(MailMsg)


                'Dim mail As MailMessage = New MailMessage()
                'mail.To.Add(myalumno.email)
                'If myalumno.emailGoogle <> "" Then
                '    mail.To.Add(myalumno.emailGoogle)
                'End If

                'mail.From = New MailAddress("Skolar@um.edu.mx")
                'mail.Subject = myr.titulo & " Calif: " & txtCalificacion.Text
                'mail.ReplyTo = New MailAddress(mymaestro.emailGoogle)

                'Dim Body As String = "Actividad calificada:  " & myr.titulo & vbCrLf & vbCrLf & _
                '            "<br><b>Calificación:</b> " & txtCalificacion.Text & vbCrLf & vbCrLf & _
                '            "<br><b>Observaciones del maestro:</b> " & myr.observaciones & vbCrLf & vbCrLf & _
                '            "<br><b>Ver actividad en el Skolar:</b>  http://Skolar.um.edu.mx/sec/SalonVirtual/ResponderActividad.aspx?idSalonVirtual=" & myr.idSalonVirtual & "&idA=" & mya.id & vbCrLf & vbCrLf & _
                '            "<br><b>Fecha:</b> " & myr.fechaRevision & vbCrLf & vbCrLf
                'mail.Body = Body

                'mail.IsBodyHtml = True
                'Dim smtp As SmtpClient = New SmtpClient()
                'smtp.Host = "smtp.gmail.com" 'Or Your SMTP Server Address
                'smtp.Credentials = New System.Net.NetworkCredential("Skolar@um.edu.mx", "alaska")
                'smtp.EnableSsl = True
                'smtp.Send(mail)


            Catch ex As Exception
                Response.Redirect("MensajeError.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correo=" & myalumno.email & "&correoUM=" & myalumno.emailGoogle & "&mensaje=" & ex.Message.ToString)

            End Try


        End If




        If respuesta Then

            Dim mysvup As New Know.SalonVirtualUserProfile(myr.idUserProfile, myr.idSalonVirtual, False)
            mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myr.idUserProfile, myr.idSalonVirtual)
            mysvup.Update()

            Select Case Request("pag")
                Case "next"
                    Response.Redirect("TareasRecibidas.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
                Case "actividadesporcalificar"
                    Response.Redirect("ActividadesPorCalificar.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))
                Case "calificacionesactividad"
                    Response.Redirect("CalificacionesActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & Request("idR"))
                Case Else
                    Response.Redirect("EvaluacionPorAlumno.aspx?idUserProfile=" & myr.idUserProfile & "&idSalonVirtual=" & Request("idSalonVirtual"))
            End Select


        End If



    End Sub

    Function calificanAlumnos() As Boolean
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)

        Dim myrnueva As Contenidos.Respuesta = New Contenidos.Respuesta()

        Dim myrxt As Contenidos.Respuesta = New Contenidos.Respuesta(myr.id, myr.idProc, myr.procedencia, myr.idSalonVirtual, CInt(Session("idUsuerProfile")))
        If myrxt.existe Then
         
            myrxt.observaciones = txtMensaje.Text
            myrxt.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myrxt.fechaEnvio = myr.fechaEnvio
            myrxt.fechaRevision = Date.Now

            Select Case mya.comoSeCalifica
                Case Contenidos.EComoSeCalifica.ValorNumerico
                    myrnueva.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
                Case Contenidos.EComoSeCalifica.Ranking
                    myrnueva.calificacion = regresarValorSeleccionado() * 10
                Case Contenidos.EComoSeCalifica.Rubrica
                    myrnueva.calificacion = regresarValorRubrica(mya.idRubrica, myr.id) * 10
            End Select



            myrxt.repetir = False
            myrxt.status = Contenidos.StatusRespuesta.Calificada

            myrxt.Update()
        Else

            myrnueva.idProc = myr.idProc
            myrnueva.procedencia = myr.procedencia
            myrnueva.idRaiz = myr.id
            If Request("idUserProfile") <> "" Then
                myrnueva.idUserProfile = CInt(Request("idUserProfile"))
            Else
                myrnueva.idUserProfile = Session("gUserProfileSession").idUserProfile
            End If
            myrnueva.titulo = myr.titulo
            myrnueva.texto = ""
            myrnueva.observaciones = txtMensaje.Text
            myrnueva.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myrnueva.fechaEnvio = myr.fechaEnvio
            myrnueva.fechaRevision = Date.Now

            Select Case mya.comoSeCalifica
                Case Contenidos.EComoSeCalifica.ValorNumerico
                    myrnueva.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
                Case Contenidos.EComoSeCalifica.Ranking
                    myrnueva.calificacion = regresarValorSeleccionado() * 10
                Case Contenidos.EComoSeCalifica.Rubrica
                    myr.calificacion = regresarValorRubrica(mya.id, myr.id) * 10
            End Select



            myrnueva.repetir = False
            myrnueva.status = Contenidos.StatusRespuesta.Calificada

            myrnueva.Add()
        End If

     
        myr.observaciones = txtMensaje.Text

        myr.calificacion = myrnueva.GetPromedioRaiz(myr.id)
        myr.repetir = chkPermitir.Checked
        myr.status = Contenidos.StatusRespuesta.Calificada
        myr.Update()
        subirArchivosyLigas(myr)

        Return True


    End Function

    Function calificanMaestros() As Boolean
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)


        myr.observaciones = txtMensaje.Text
        Select Case mya.comoSeCalifica
            Case Contenidos.EComoSeCalifica.ValorNumerico
                myr.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
                myr.repetir = chkPermitir.Checked
            Case Contenidos.EComoSeCalifica.Ranking
                myr.calificacion = regresarValorSeleccionado() * 10
                myr.repetir = chkPermitir.Checked
            Case Contenidos.EComoSeCalifica.Rubrica
                myr.calificacion = regresarValorRubrica(mya.id, myr.id)

                '   temp
                Dim myrubrica As New Lego.Rubrica()
                Dim totalRubrica As Decimal = regresarValorRubrica(mya.id, myr.id)
                myr.observaciones = myr.observaciones & "----" & Date.Now & "--cal" & totalRubrica & " ---  "
                ' fin temp


                myr.repetir = chkPermitir2.Checked


            Case Contenidos.EComoSeCalifica.RubricaA
                myr.calificacion = regresarValorRubricaA(mya.id, myr.id)

                '   temp
                Dim myrubrica As New Lego.Rubrica()
                Dim totalRubrica As Decimal = regresarValorRubricaA(mya.id, myr.id)
                myr.observaciones = myr.observaciones & "----" & Date.Now & "--cal" & totalRubrica & " ---  "
                ' fin temp


                myr.repetir = chkPermitir2ra.Checked


        End Select

        myr.status = Contenidos.StatusRespuesta.Calificada

        myr.Update()
        subirArchivosyLigas(myr)

        Return True

    End Function


    Function regresarValorSeleccionado() As Integer
        Dim cal As Integer = 0
        If Rate1.Checked Then
            cal = 1
        End If
        If Rate2.Checked Then
            cal = 2
        End If
        If Rate3.Checked Then
            cal = 3
        End If
        If Rate4.Checked Then
            cal = 4
        End If
        If Rate5.Checked Then
            cal = 5
        End If
        If Rate6.Checked Then
            cal = 6
        End If
        If Rate7.Checked Then
            cal = 7
        End If
        If Rate8.Checked Then
            cal = 8
        End If
        If Rate9.Checked Then
            cal = 9
        End If
        If Rate10.Checked Then
            cal = 10
        End If
        Return cal
    End Function




    Function subirArchivosyLigas(ByVal myR As Contenidos.Respuesta) As Integer
        'seccion para subir archivos 
        Dim myra As Contenidos.RespuestaArchivo

        If File1.PostedFile IsNot Nothing Then
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
        End If


        If File2.PostedFile IsNot Nothing Then
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

        End If



        Return 1

    End Function


    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function


    Function getFoto(ByVal claveAlumno As String, ByVal claveMaestro As String) As String


        If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveAlumno & ".jpg") Then
            Return "~/sec/Usuarios/Fotos/" & claveAlumno & ".jpg"
        Else
            If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveMaestro & ".jpg") Then
                Return "~/sec/Usuarios/Fotos/" & claveMaestro & ".jpg"
            Else
                Return "~/images/pagina/IconAlumno.jpg"
            End If

        End If

    End Function


    Dim claveSalon As Integer
    Dim claveUsuario As Integer
    Dim claveRespuesta As Integer

    Public Function SetCalificacionRubrica(claveRespuestaAlumno As Integer) As Integer
        Dim myRRubrica As New Contenidos.RespuestaRubrica()

        For i = 0 To rptRubricas.Items.Count - 1
            Dim myControlCalificacion As DropDownList = CType(rptRubricas.Items(i).FindControl("drpRubricaRow"), DropDownList)
            Dim myControlRubro As Label = CType(rptRubricas.Items(i).FindControl("lblRubricaID"), Label)
            myRRubrica = New Contenidos.RespuestaRubrica(claveRespuestaAlumno, CInt(myControlRubro.Text))
            myControlCalificacion.SelectedValue = myRRubrica.calificacion1

        Next
        Return 0
    End Function


    Public Function SetCalificacionRubricaA(claveRespuestaAlumno As Contenidos.Respuesta) As Integer
        If claveRespuestaAlumno.existe Then
            Dim myRRubrica As New Contenidos.RespuestaRubrica()

            For i = 0 To rptRubricaA.Items.Count - 1
                Dim myControlCalificacion As DropDownList = CType(rptRubricaA.Items(i).FindControl("drpRubricaRow"), DropDownList)
                Dim myControlRubro As Label = CType(rptRubricaA.Items(i).FindControl("lblRubricaID"), Label)
                myRRubrica = New Contenidos.RespuestaRubrica(claveRespuestaAlumno.id, CInt(myControlRubro.Text))
                myControlCalificacion.SelectedValue = myRRubrica.calificacion1

            Next

            lblTotalRA.Text = CInt(claveRespuestaAlumno.calificacion)
        End If

        Return 0
    End Function

    Private Function regresarValorRubrica(claveActividad As Integer, claveRespuestaAlumno As Integer) As Decimal


        Dim myrubrica As New Lego.Rubrica()

        Dim calificacion As Decimal = 0
        Dim totalRubrica As Decimal = myrubrica.GetTotalValorRubrica(claveActividad)

        Dim myRR As Contenidos.RespuestaRubrica
        Dim i As Integer = 0

        For i = 0 To rptRubricas.Items.Count - 1
            Dim myControlCalificacion As DropDownList = CType(rptRubricas.Items(i).FindControl("drpRubricaRow"), DropDownList)
            Dim myControlRubro As Label = CType(rptRubricas.Items(i).FindControl("lblRubricaID"), Label)
            myRR = New Contenidos.RespuestaRubrica(claveRespuestaAlumno, CInt(myControlRubro.Text))

            If myRR.existe Then
                myRR.calificacion1 = CDec(myControlCalificacion.SelectedValue)
                myRR.Update()
            Else
                myRR.idRespuesta = claveRespuestaAlumno
                myRR.idRubrica = CInt(myControlRubro.Text)
                myRR.calificacion1 = CDec(myControlCalificacion.SelectedValue)
                myRR.Add()
            End If

            calificacion = calificacion + CDec(myRR.calificacion1)

        Next


        '   Return totalRubrica

        If totalRubrica = 0 Then
            Return 0
        Else
            Return (calificacion * CDec(100.0)) / totalRubrica
        End If



    End Function



    Private Function regresarValorRubricaA(claveActividad As Integer, claveRespuestaAlumno As Integer) As Decimal


        Dim myrubrica As New Lego.Rubrica()

        Dim calificacion As Decimal = 0
        Dim totalRubrica As Decimal = myrubrica.GetTotalValorRubrica(claveActividad)

        Dim myRR As Contenidos.RespuestaRubrica
        Dim i As Integer = 0

        For i = 0 To rptRubricaA.Items.Count - 1
            Dim myControlCalificacion As DropDownList = CType(rptRubricaA.Items(i).FindControl("drpRubricaRow"), DropDownList)
            Dim myControlRubro As Label = CType(rptRubricaA.Items(i).FindControl("lblRubricaID"), Label)
            myRR = New Contenidos.RespuestaRubrica(claveRespuestaAlumno, CInt(myControlRubro.Text))

            If myRR.existe Then
                myRR.calificacion1 = CDec(myControlCalificacion.SelectedValue)
                myRR.Update()
            Else
                myRR.idRespuesta = claveRespuestaAlumno
                myRR.idRubrica = CInt(myControlRubro.Text)
                myRR.calificacion1 = CDec(myControlCalificacion.SelectedValue)
                myRR.Add()
            End If

            calificacion = calificacion + CDec(myRR.calificacion1)

        Next


        Return calificacion

        'If totalRubrica = 0 Then
        '    Return 0
        'Else
        '    Return (calificacion * CDec(100.0)) / totalRubrica
        'End If



    End Function
End Class
