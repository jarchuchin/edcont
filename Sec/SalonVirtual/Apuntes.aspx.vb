
Partial Class Sec_SalonVirtual_Apuntes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        If Request("idSalonVirtualApunte") <> "" Then
            Dim mysa As Know.SalonVirtualApunte = New Know.SalonVirtualApunte(CInt(Request("idSalonVirtualApunte")))
            txtMensaje.Text = mysa.Texto
            btnBorrar.Visible = True
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

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Request("idSalonVirtualApunte") <> "" Then
            editar()
        Else
            grabar()
        End If
    End Sub


    Sub editar()
        Dim myas As Know.SalonVirtualApunte = New Know.SalonVirtualApunte(CInt(Request("idSalonVirtualApunte")))
        myas.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myas.idUserProfile = Session("gUserProfileSession").idUserProfile
        myas.Texto = txtMensaje.Text
        myas.Fecha = Date.Now
        myas.Update()

        Response.Redirect("default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub

    Sub grabar()

        Dim myas As Know.SalonVirtualApunte = New Know.SalonVirtualApunte()
        myas.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myas.idUserProfile = Session("gUserProfileSession").idUserProfile
        myas.Texto = txtMensaje.Text
        myas.Fecha = Date.Now
        myas.Eliminado = False
        myas.Add()
        Response.Redirect("default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub


    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim myas As Know.SalonVirtualApunte = New Know.SalonVirtualApunte(CInt(Request("idSalonVirtualApunte")))
        myas.Eliminado = True
        myas.Update()

        Response.Redirect("default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
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
