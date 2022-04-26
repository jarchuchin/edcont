
Partial Class Sec_SalonVirtual_EsquemaEvaluacionAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()

        displayEvaluacionAlumno1.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)

        Dim varmaestro As Boolean = esmaestro()
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & mysv.id


        If varmaestro Then
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



End Class
