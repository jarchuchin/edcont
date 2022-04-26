
Partial Class Sec_SalonVirtual_CalificarSubjetivo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")


    End Sub

    Sub colocarDatos()

        Dim myitem As Know.ItemEvaluacion = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))
        '  lbltitulo.Text = myitem.titulo


        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, CInt(Request("idItemEvaluacion")), tipoObjeto.ItemEvaluacion.ToString, CInt(Request("idSalonVirtual")), CInt(Request("idUserProfile")))
        If myr.existe Then
            txtCalificacion.Text = Format(myr.calificacion / 10, "0.0")
            txtMensaje.Text = myr.observaciones

           

        End If


        Dim myu As New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
        lblAlumno.Text = myu.nombre & " " & myu.apellidos

    End Sub




    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        System.Threading.Thread.Sleep(1000)
        Dim myitem As Know.ItemEvaluacion = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myitem.id, tipoObjeto.ItemEvaluacion.ToString, CInt(Request("idSalonVirtual")), CInt(Request("idUserProfile")))

        If myr.existe Then
            myr.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
            myr.observaciones = txtMensaje.Text
            myr.Update()
        Else
            myr.idUserProfile = CInt(Request("idUserProfile"))
            myr.idRaiz = 0
            myr.idProc = CInt(Request("idItemEvaluacion"))
            myr.procedencia = tipoObjeto.ItemEvaluacion.ToString
            myr.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myr.titulo = myitem.titulo
            myr.texto = ""
            myr.observaciones = txtMensaje.Text
            myr.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
            myr.fechaEnvio = Date.Now
            myr.fechaRevision = Date.Now
            myr.repetir = False
            myr.status = Contenidos.StatusRespuesta.Calificada
            myr.Add()

        End If


        'actualizar calificacion general
        Dim mysvup As New Know.SalonVirtualUserProfile(myr.idUserProfile, myr.idSalonVirtual, False)
        mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myr.idUserProfile, myr.idSalonVirtual)
        mysvup.Update()

        Response.Redirect("EvaluacionPorAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & Request("idUserProfile"))

    End Sub
End Class
