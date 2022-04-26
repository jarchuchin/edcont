
Partial Class Sec_SalonVirtual_PreguntasNueva
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()

        Dim esmaestroloc As Boolean = esmaestro()




        If esmaestroloc Then
            'Colocar menu
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        End If

        If Request("idSalonVirtualPregunta") <> "" Then
            Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta(CInt(Request("idSalonVirtualPregunta")))
            txtpregunta.Text = mysvp.Pregunta

            btnBorrar.Visible = esmaestroloc


        End If





        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Request("idSalonVirtualPregunta") <> "" Then
            editar()
        Else
            grabar()
        End If

        Response.Redirect("Preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub

    Sub grabar()
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta()
        mysvp.idSalonVirtual = CInt(Request("idSalonVirtual"))
        mysvp.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        mysvp.idMaestro = mysv.idUserProfile
        mysvp.Pregunta = txtpregunta.Text
        mysvp.PreguntaFecha = Date.Now
        mysvp.Respuesta = ""
        mysvp.RespuestaFecha = Date.Now
        mysvp.Calificacion = 0
        mysvp.CalificacionFecha = Date.Now
        mysvp.Observacion = ""
        mysvp.Add()

    End Sub

    Sub editar()
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta(CInt(Request("idSalonVirtualPregunta")))
        'mysvp.idSalonVirtual = CInt(Request("idSalonVirtual"))
        'mysvp.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        'mysvp.idMaestro = mysv.idUserProfile
        mysvp.Pregunta = txtpregunta.Text
        mysvp.PreguntaFecha = Date.Now
        'mysvp.Respuesta = ""
        'mysvp.RespuestaFecha = Date.Now
        'mysvp.Calificacion = 0
        'mysvp.CalificacionFecha = Date.Now
        'mysvp.Observacion = ""
        mysvp.Update()
    End Sub

    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta(CInt(Request("idSalonVirtualPregunta")))
        mysvp.Remove()
        Response.Redirect("Preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

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

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
End Class
