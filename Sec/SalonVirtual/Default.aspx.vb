
Partial Class Sec_SalonVirtual_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocardatos()

        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Page.Title = mysv.nombre
        lblCursoBread.Text = mysv.nombre

        '    lblNombredelcurso.Text = mysv.nombre
        lblNombreTitulo.Text = mysv.nombre


        ' lnkApunte1.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkApunte2.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")


        ' lnkSalaVirtual1.NavigateUrl = "~/sec/salonvirtual/createBBB.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&bbb=1"
        '  lnkSalaVirtual2.NavigateUrl = "~/sec/salonvirtual/createBBB.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&bbb=1"
        If mysv.LigaSalonVirtual = "" Then
            lnkSalaVirtual2.NavigateUrl = "~/sec/salonvirtual/SalaVirtualNA.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        Else
            lnkSalaVirtual2.NavigateUrl = mysv.LigaSalonVirtual
            lnkSalaVirtual2.Target = "_blank"
        End If

        ' lnkPreguntas1.NavigateUrl = "~/sec/salonvirtual/preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkPreguntas2.NavigateUrl = "~/sec/salonvirtual/preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual")

        Dim mysve As Know.SalonVirtualEntrada = New Know.SalonVirtualEntrada()
        mysve.idSalonVirtual = CInt(Request("idSalonVirtual"))
        mysve.SessionId = Session.SessionID.ToString()
        mysve.idUserProfile = Session("gUserProfileSession").idUserProfile
        mysve.Fecha = Date.Now
        mysve.Add()



        Dim varesmaestro As Boolean = False
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)


        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myuser.id, mysv.id, False)
        If Not mysvu.existe Then
            Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysv)
            varesmaestro = mypermisos.existe

            If Not varesmaestro Then
                Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
                mypermisos = New MasUsuarios.Permiso(myuser, mye)
                varesmaestro = mypermisos.existe
            End If

            If Session("esAdministrador") Or Session("esGerenciaSalones") Then
                varesmaestro = True
            End If


        End If


        If varesmaestro Then
            If mysv.idRoot = 0 Then
                Response.Redirect("AddSalonVirtual.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
            End If

            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        Else
            If mysv.idRoot = 0 Then
                Response.Redirect("NoLibro.aspx")
            End If

            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        End If






        displayBoletin1.esmaestro = varesmaestro
        'displayCapilla1.esmaestro = varesmaestro

        displayEspectometro1.claveSalon = CInt(Request("idSalonVirtual"))
        displayEspectometro1.claveUsuario = Session("gUserProfileSession").idUserProfile
        displayEspectometro1.esmaestro = varesmaestro

        'displayIntroduccion1.idroot = mysv.idRoot
        'displayIntroduccion1.idSalonVirtual = mysv.id

    



    End Sub


   
End Class
