
Partial Class Sec_SolicitarIngreso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocarDatos(CInt(Request("idSalonVirtual")))
        End If
    End Sub



    Sub colocarDatos(ByVal clave As Integer)
        Panel2.Visible = True
        txtid.Text = clave
        txtid.Visible = False
        Dim mySalon As Know.SalonVirtual = New Know.SalonVirtual(clave, True)
        Dim myEmpresa As MasUsuarios.Empresa = New MasUsuarios.Empresa(mySalon.idEmpresa)

        lblEmpresa.Text = myEmpresa.nombre
        lblNombreSalon.Text = mySalon.nombre
        txtStatus.Text = mySalon.status
        txtFechaInicio.Text = mySalon.fechaInicio.ToLongDateString
        txtfechaFin.Text = mySalon.fechaFin.ToLongDateString
        txthorarioAtencion.Text = mySalon.horarioAtencion
        txtCalificacionMaxima.Text = mySalon.calificacionMaxima
        txtClaveID1.Text = mySalon.claveAux1
        txtClaveID2.Text = mySalon.claveAux2
        txtLibro.Text = mySalon.root.titulo
        txtDetallesLibro.Text = mySalon.root.descripcion
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso

        dtgInstructores.DataSource = myPermiso.GetDS(True, , mySalon)
        dtgInstructores.DataBind()
        dtgInstructores.Visible = True

        Dim mySalonUser As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), mySalon.id, False)
        If Not mySalonUser.existe Then
            myPermiso = New MasUsuarios.Permiso(New MasUsuarios.UserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), False), mySalon)
            If myPermiso.existe Then
                btnEnviar.Visible = False
                lblMensaje.Visible = True

            Else
                Select Case mySalonUser.status
                    Case "I"
                        Label2.Visible = True
                    Case "S"
                        Label3.Visible = True
                    Case "R"
                        Label4.Visible = True
                    Case "C"
                        Label5.Visible = True
                End Select
                'tiene permisos
                btnEnviar.Visible = True

            End If

        Else
            'esta inscrito
            btnEnviar.Visible = False
        End If




    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If txtid.Text <> "" Then
            Dim mySalon As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(txtid.Text), False)
            Dim mySalonUser As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
            mySalonUser.idSalonVirtual = mySalon.id
            mySalonUser.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
            mySalonUser.status = "S"
            mySalonUser.fechaInicio = Date.Now
            mySalonUser.fechaFin = Date.Now
            mySalonUser.calificacion = 0
            mySalonUser.calificacionComputada = 0
            mySalonUser.idUserProfileCalificador = 0
            mySalonUser.puntosExtras = 0
            mySalonUser.Add()
            Response.Redirect("Default.aspx")
        Else
            Response.Redirect("BuscarSalones.aspx")
        End If

    End Sub


End Class
