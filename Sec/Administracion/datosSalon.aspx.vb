Imports System.Data

Partial Class Sec_Administracion_datosSalon
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenardrop()
            colocarDatos()

        End If

    End Sub


    Sub llenardrop()
        Dim myu As New MasUsuarios.EmpresaUserProfile
        drpUsuarios.DataSource = myu.GetMaestros()
        drpUsuarios.DataTextField = "nombrecompleto"
        drpUsuarios.DataValueField = "idUserprofile"
        drpUsuarios.DataBind()

        Dim myi As New System.Web.UI.WebControls.ListItem("Seleccionar un usario", "")
        drpUsuarios.Items.Insert(0, myi)


    End Sub

    Sub colocarDatos()
        Dim mySalonV As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), True)
        txtNombre.Text = mySalonV.nombre
        txtFechaInicio.Text = mySalonV.fechaInicio.ToShortDateString

        txtFechaFin.Text = mySalonV.fechaFin.ToShortDateString


        txtHorarioAtencion.Text = mySalonV.horarioAtencion
        txtCalificacionMaxima.Text = mySalonV.calificacionMaxima
        If mySalonV.status Then
            rdbStatus.Items(0).Selected = True
            rdbStatus.Items(1).Selected = False
        Else
            rdbStatus.Items(0).Selected = False
            rdbStatus.Items(1).Selected = True
        End If
        txtClaveID1.Text = mySalonV.claveAux1
        txtClaveID2.Text = mySalonV.claveAux2


        If mySalonV.idUserProfile > 0 Then
            drpUsuarios.SelectedValue = mySalonV.idUserProfile

        End If



        ' btnBorrar.Visible = True



        txtLibro.Visible = True
        txtLibro.Text = mySalonV.root.titulo

        lnkIngresar.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & mySalonV.id




    End Sub
    Sub desabilitar(ByVal estado As Boolean)
        txtNombre.Enabled = estado
        txtFechaInicio.Enabled = estado
        txtFechaFin.Enabled = estado
        txtHorarioAtencion.Enabled = estado
        txtCalificacionMaxima.Enabled = estado
        rdbStatus.Enabled = estado
        txtClaveID1.Enabled = estado
        txtClaveID2.Enabled = estado

        '         btnBorrar.Visible = estado
        btnGrabar.Visible = estado
    End Sub


    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If IsDate(txtFechaInicio.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Private Sub Customvalidator2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles Customvalidator2.ServerValidate
        If IsDate(txtFechaFin.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Function editar() As Integer

        Dim mySalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), True)
        'mySalonVirtual.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)


        mySalonVirtual.nombre = txtNombre.Text
        mySalonVirtual.fechaInicio = CDate(txtFechaInicio.Text)
        mySalonVirtual.fechaFin = CDate(txtFechaFin.Text)
        mySalonVirtual.horarioAtencion = txtHorarioAtencion.Text
        mySalonVirtual.calificacionMaxima = Integer.Parse(txtCalificacionMaxima.Text)
        If rdbStatus.SelectedItem.Value = "1" Then
            mySalonVirtual.status = True
        Else
            mySalonVirtual.status = False
        End If
        mySalonVirtual.claveAux1 = txtClaveID1.Text
        mySalonVirtual.claveAux2 = txtClaveID2.Text

        Dim usuario As Integer = mySalonVirtual.idUserProfile
        If drpUsuarios.SelectedValue > 0 Then
            mySalonVirtual.idUserProfile = CInt(drpUsuarios.SelectedValue)
        Else
            mySalonVirtual.idUserProfile = 0
        End If


        mySalonVirtual.Update()





        'asignar permisos



        ' Dim myUserPActual As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(usuario, False)
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso()
        myPermiso.Remove(mySalonVirtual)


        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(mySalonVirtual.idUserProfile, False)

        myPermiso.permisoA = myUserP.tipo
        myPermiso.idPermisoA = myUserP.id
        myPermiso.recurso = mySalonVirtual.tipo
        myPermiso.idRecurso = mySalonVirtual.id


        myPermiso.PRoots = True
        myPermiso.PPermisosRoots = True
        myPermiso.PCategorias = True
        myPermiso.PRespuestas = True
        myPermiso.PEvaluacion = True
        myPermiso.PSalonVirtual = True
        myPermiso.PContenidos = True
        myPermiso.PInterfaceGrafica = True
        myPermiso.PEstadisticas = True
        myPermiso.PAdministracion = True
        myPermiso.Add()





        Return mySalonVirtual.id

    End Function



    Private Sub Customvalidator3_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles Customvalidator3.ServerValidate
        If IsNumeric(txtCalificacionMaxima.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click


        If Page.IsValid Then

            Dim numero As Integer
            If Request("idSalonVirtual") <> "" Then
                numero = editar()


            End If
            Response.Redirect("datossalon.aspx?idSalonVirtual=" & numero)
        End If
    End Sub



    Protected Sub btnCambiarlibro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiarlibro.Click



        Dim mySalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), False)
        mySalonVirtual.idRoot = 0
        mySalonVirtual.Update()


        Response.Redirect("datosSalon.aspx?idSalonVirtual=" & mySalonVirtual.id)

    End Sub

    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizar.Click


        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        'Esqueme de evaluacion
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        Dim dseval As DataSet = myItemEvaluacion.GetDS(Integer.Parse(Request("idSalonVirtual")))

        Dim myie As Know.ItemEvaluacion
        Dim i As Integer = 0
        For i = 0 To dseval.Tables(0).Rows.Count - 1
            myie = New Know.ItemEvaluacion(CInt(dseval.Tables(0).Rows(i).Item("idItemEvaluacion")))
            If myie.existe Then
                myie.Update()

                'actividades para esta evaluacion
                If myie.tipoItem = Know.TipoItemEvaluacion.Computo Then
                    Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
                    Dim dsActividades As DataSet = myasv.GetDS(myie.id)
                    Dim iactiv As Integer
                    For iactiv = 0 To dsActividades.Tables(0).Rows.Count - 1
                        myasv = New Contenidos.ActividadSalonVirtual(CInt(dsActividades.Tables(0).Rows(i).Item("idActividadSalonVirtual")))
                        myasv.Update()
                    Next
                Else

                End If


            End If
        Next









        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta
                Dim dr As DataSet = myr.GetDS(mysv.id)
        ' Dim i As Integer = 0
        i = 0
        For i = 0 To dr.Tables(0).Rows.Count - 1
            myr = New Contenidos.Respuesta(CInt(dr.Tables(0).Rows(i).Item("idRespuesta")))
            If myr.existe Then
                myr.Update()
            End If
        Next

        lblsincronizacion.Text &= " --- " & Date.Now
        lblsincronizacion.Visible = True













    End Sub






End Class
