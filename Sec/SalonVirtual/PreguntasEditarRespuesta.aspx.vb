
Partial Class Sec_SalonVirtual_PreguntasEditarRespuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()




        Dim esmaestroloc As Boolean = esmaestro()

        btnBorrar.Visible = esmaestroloc


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
            lblPregunta.Text = mysvp.Pregunta
            txtrespuesta.Text = mysvp.Respuesta


        Else
            Response.Redirect("Default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta(CInt(Request("idSalonVirtualPregunta")))
        mysvp.Respuesta = txtRespuesta.Text
        mysvp.RespuestaFecha = Date.Now
        mysvp.idMaestro = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        mysvp.Update()

        Response.Redirect("Preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idSalonVirtualPregunta=" & mysvp.id)
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
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


End Class
