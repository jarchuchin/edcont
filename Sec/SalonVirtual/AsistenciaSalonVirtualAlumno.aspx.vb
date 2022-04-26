
Partial Class Sec_SalonVirtual_AsistenciaSalonVirtualAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myAL As Know.AsistenciaLista = New Know.AsistenciaLista

        dtgLista.DataSource = myAL.GetDS(CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
        dtgLista.DataBind()


        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))


        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If EsMaestro() Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual



    End Sub


    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermisos.existe
    End Function


End Class
