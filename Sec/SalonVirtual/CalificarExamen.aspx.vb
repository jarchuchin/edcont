Imports System.IO


Partial Class Sec_SalonVirtual_CalificarExamen
    Inherits System.Web.UI.Page


    Dim myrespuesta As Contenidos.Respuesta
    Dim myActividad As Contenidos.Actividad


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iniciaryvalidar()
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub


    Sub iniciaryvalidar()

        Dim cadena As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/homepage.aspx"
        If Request("idSalonVirtual") <> "" And Request("idR") <> "" Then
            If IsNumeric(Request("idSalonVirtual")) And IsNumeric(Request("idR")) Then
                myrespuesta = New Contenidos.Respuesta(CInt(Request("idR")))
                If myrespuesta.procedencia = "Actividad" Then
                    myActividad = New Contenidos.Actividad(myrespuesta.idProc)
                Else
                    Response.Redirect(cadena)
                End If
            Else
                Response.Redirect(cadena)
            End If
        Else
            Response.Redirect(cadena)
        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub


    Sub iniciarControles()
        colocarDatos()
        llenarGrid()
    End Sub

    Sub colocarDatos()
        Dim myEstudiante As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myrespuesta.idUserProfile, False)
        estudiante.Text = myEstudiante.nombre & " " & myEstudiante.apellidos
        fechaenvio.Text = Format(myrespuesta.fechaEnvio, "f")
        totalMinutos.Text = myrespuesta.texto


        Dim puntosTotalesLocal As Decimal = 0

        If myActividad.activarBanco Then
            Dim myexorden As New Examenes.ExOrden(myActividad.id, CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)
            If Not myexorden.existe Then
                Dim myP As Examenes.Pregunta = New Examenes.Pregunta
                Dim ordenPreguntas As String = myP.GetDRAleatorioNumPreguntas(myActividad.id, myActividad.totalPreguntas)


                myexorden.idActividad = myActividad.id
                myexorden.idSalonVirtual = CInt(Request("idSalonVirtual"))
                myexorden.idUserProfile = myrespuesta.idUserProfile
                myexorden.Orden = ordenPreguntas
                myexorden.Fecha = Date.Now
                myexorden.Add()

                puntosTotalesLocal = getValorPreguntas(myexorden.Orden)
            Else
                puntosTotalesLocal = getValorPreguntas(myexorden.Orden)

            End If

        Else
            puntosTotalesLocal = myActividad.puntosTotales
        End If

        Dim myexr As Examenes.ExRespuesta = New Examenes.ExRespuesta
        calificacion.Text = Format(myexr.GetSumaValorObtenido(CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile, myActividad.id), "0.00") & " / " & puntosTotalesLocal
        'myrespuesta.Calificacion

        lbltotaltodos.Text = Format(myexr.GetSumaValorObtenido(CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile, myActividad.id), "0.00")


        Page.Title = myrespuesta.titulo


        Dim myuemp As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myrespuesta.idUserProfile, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        imgAlumno.ImageUrl = "http://Skolar.online/sec/showfile.aspx?idUserProfile=" & myrespuesta.idUserProfile   'getFoto(myuemp.claveAux1, myuemp.claveAux2)




    End Sub

    Sub llenarGrid()
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta
        If myActividad.activarBanco Then

            Dim myexorden As New Examenes.ExOrden(myActividad.id, CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)
            Dim puntosTotalesLocal As Decimal = getValorPreguntas(myexorden.Orden)

            dtgItem.DataSource = getTablaPreguntas(myexorden.Orden)
            dtgItem.DataBind()


        Else
            dtgItem.DataSource = myP.GetDS(myActividad.id)
            dtgItem.DataBind()
        End If
    End Sub





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


    Protected Function GetEnunciado(ByVal claveEnunciado As String) As String
        Return claveEnunciado.Replace(vbCrLf, "<br>")
    End Function

    Private Sub dtgItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then

            Dim myControllit As Literal = CType(e.Item.FindControl("litRespuesta"), Literal)
            Dim myControltxt As TextBox = CType(e.Item.FindControl("txtValorObtenido"), TextBox)
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



    Function GrabarCalificaciones() As Integer

        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim txtvalorasignado As System.Web.UI.WebControls.TextBox
        Dim myexr As Examenes.ExRespuesta = New Examenes.ExRespuesta
        For Each myDataGridItem In dtgItem.Items
            txtvalorasignado = myDataGridItem.FindControl("txtValorObtenido")
            myexr = New Examenes.ExRespuesta(CInt(dtgItem.DataKeys(myDataGridItem.ItemIndex)), CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)
            If myexr.existe Then
                myexr.valorObtenido = CDec(txtvalorasignado.Text)
                myexr.Update()
            Else

                myexr.idORSeleccionada = -5
                myexr.idPregunta = CInt(dtgItem.DataKeys(myDataGridItem.ItemIndex))
                myexr.idSalonVirtual = CInt(Request("idSalonVirtual"))
                myexr.idUserProfile = myrespuesta.idUserProfile
                myexr.valorObtenido = CDec(txtvalorasignado.Text)
                myexr.respuesta = "auto generada por Skolar system"
                myexr.fecha = Date.Now
                myexr.Add()
            End If

        Next



        Dim puntosTotalesLocal As Decimal = 0

        If myActividad.activarBanco Then
            Dim myexorden As New Examenes.ExOrden(myActividad.id, CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)
            puntosTotalesLocal = getValorPreguntas(myexorden.Orden)
        Else
            puntosTotalesLocal = myActividad.puntosTotales
        End If


        'asignar calificacion y actualizar datos de respuesta
        myrespuesta.calificacion = CDec((myexr.GetSumaValorObtenido(CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile, myActividad.id) / puntosTotalesLocal) * CDec(100))
        myrespuesta.status = Contenidos.StatusRespuesta.Calificada

        myrespuesta.Update()



        'actualizar calificacion general
        Dim mysvup As New Know.SalonVirtualUserProfile(myrespuesta.idUserProfile, myrespuesta.idSalonVirtual, False)
        mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myrespuesta.idUserProfile, myrespuesta.idSalonVirtual)
        mysvup.Update()


        If Request("pag") = "next" Then
            Response.Redirect("TareasRecibidas.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
        Else
            Response.Redirect("EvaluacionPorAlumno.aspx?idUserProfile=" & myrespuesta.idUserProfile & "&idSalonVirtual=" & Request("idSalonVirtual"))
        End If


    End Function

    Private Sub btnGrabar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar1.Click
        If Page.IsValid Then
            GrabarCalificaciones()
        End If
    End Sub

    Private Sub btnGrabar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar2.Click
        If Page.IsValid Then
            GrabarCalificaciones()
        End If
    End Sub


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

    Protected Sub btnBorrarRespuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrarRespuesta.Click
        If myrespuesta.existe Then


            Dim myuser As New MasUsuarios.EmpresaUserProfile(myrespuesta.idUserProfile, 4, "xyz")
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(myrespuesta.idSalonVirtual, False)
            Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual(myrespuesta.idProc, mysv.id)

            '  Dim myka As New UM.Krdx_Alumno_Activ(myuser.claveAux1, myASV.id, mysv.claveAux1)


            Dim myexorden As New Examenes.ExOrden(myActividad.id, CInt(Request("idSalonVirtual")), myrespuesta.idUserProfile)

            myexorden.Remove()

            myrespuesta.Remove()

            Response.Redirect("EvaluacionPorAlumno.aspx?idSalonVirtual=" & mysv.id & "&idUserProfile=" & myuser.idUserProfile)


        End If
    End Sub
End Class
