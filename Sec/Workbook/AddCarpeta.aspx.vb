Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_AddCarpeta
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        autorizacion()

        If Not IsPostBack Then
            llenarubicacion()
            colocarDatos()
        End If
    End Sub

    Sub llenarubicacion()

        Dim clave As Integer = 0
        If Request("idClasificacion") <> "" Then
            clave = CInt(Request("idClasificacion"))
        Else
            '       btnAgregarObjetivo.Visible = False
        End If




        Dim myci As New Lego.ClasificacionItem
        drpDiagnostico.DataSource = myci.getDRExamenes(clave)
        drpDiagnostico.DataValueField = "idproc"
        drpDiagnostico.DataTextField = "titulo"
        drpDiagnostico.DataBind()

        Dim myli As New ListItem("Selecciona un examen", "0")
        drpDiagnostico.Items.Insert(0, myli)





    End Sub

    Sub colocarDatos()

        txtTitulo.Focus()

        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo



        If Request("idClasificacion") <> "" Then
            Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion(CInt(Request("idClasificacion")))



            txtTitulo.Text = myclasifica.titulo
            txtdiadisplay.Text = myclasifica.diaDisplay
            txttexto.Text = myclasifica.texto
            chkstatus.Checked = myclasifica.status

            txtPlanteamientoBreve.Text = myclasifica.PlanteamientoBreve
            If myclasifica.Imagen1 <> "" Then
                img1.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & myclasifica.id & "&num=1"
                img1.Visible = True
                lnkBorrar1.Visible = True
            End If


            btnBorrar1.Visible = True


            drpDiagnostico.SelectedValue = myclasifica.idActividad
            lnkSalirEdicion.NavigateUrl = "~/sec/workbook/carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot")






        Else


            lnkSalirEdicion.NavigateUrl = "~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot")


        End If





    End Sub




    Protected Sub btnGrabar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar1.Click
        If Page.IsValid Then
            Dim esImagen As Boolean = False
            Dim entro As Boolean = False

            If FileUpload1.PostedFile.FileName <> "" Then
                esImagen = System.Text.RegularExpressions.Regex.IsMatch(FileUpload1.PostedFile.ContentType, "image/\S+")
                entro = True
            End If

            If entro = True And esImagen = False Then
                lblmensajeimagenes.Visible = True
            Else
                If Request("idClasificacion") <> "" Then

                    editar()
                Else
                    grabar()
                End If
            End If

          
        End If

    End Sub

    Sub editar()
        Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion(CInt(Request("idClasificacion")))
        myclasifica.titulo = txtTitulo.Text
        myclasifica.idRaiz = 0
        myclasifica.diaDisplay = CInt(txtdiadisplay.Text)
        myclasifica.texto = txttexto.Text
        myclasifica.PlanteamientoBreve = txtPlanteamientoBreve.Text
        myclasifica.status = chkstatus.Checked
        Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Clasificaciones\"
        Dim extension As String = ""
        Dim filename As String = ""
        If FileUpload1.PostedFile.FileName <> "" Then
            extension = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1)
            filename = "clasif_" & myclasifica.id & "_1." & extension
            FileUpload1.SaveAs(pathfile & filename)
            myclasifica.Imagen1 = filename
        End If

        myclasifica.idActividad = CInt(drpDiagnostico.SelectedValue)
        myclasifica.Update()


        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myclasifica.id)
        End If
        Response.Redirect("Carpeta.aspx?idRoot=" & myclasifica.idRoot & "&idClasificacion=" & myclasifica.id)
    End Sub

    Sub grabar()
        Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion()
        myclasifica.titulo = txtTitulo.Text
        myclasifica.idRaiz = 0
        myclasifica.idRoot = CInt(Request("idRoot"))
        myclasifica.diaDisplay = CInt(txtdiadisplay.Text)
        myclasifica.texto = txttexto.Text
        myclasifica.status = chkstatus.Checked
        myclasifica.PlanteamientoBreve = txtPlanteamientoBreve.Text
        myclasifica.idActividad = CInt(drpDiagnostico.SelectedValue)
        myclasifica.Add()

        Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Clasificaciones\"
        Dim extension As String = ""
        Dim filename As String = ""
        If FileUpload1.PostedFile.FileName <> "" Then
            extension = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1)
            filename = "clasif_" & myclasifica.id & "_1." & extension
            FileUpload1.SaveAs(pathfile & filename)
            myclasifica.Imagen1 = filename
        End If

        myclasifica.Update()


        If Request("idSalonVirtual") <> "" Then
            Response.Redirect("~/sec/salonvirtual/verCarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myclasifica.id)
        End If

        Response.Redirect("Carpeta.aspx?idRoot=" & myclasifica.idRoot & "&idClasificacion=" & myclasifica.id)

    End Sub



    Protected Sub btnBorrar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar1.Click

        Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion(CInt(Request("idClasificacion")))
        If myclasifica.SePuedeBorrar Then
            myclasifica.Remove()
            Response.Redirect("Explorar.aspx?idRoot=" & myclasifica.idRoot)
        Else
            lblmensajeBorrar.Visible = True
        End If

    End Sub


    Protected Sub btnregresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnregresar.Click
        Response.Redirect("carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot"))

    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If IsNumeric(txtdiadisplay.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

	Protected Sub lnkBorrarImg_Click(sender As Object, e As System.EventArgs)
		Dim lnk As LinkButton = CType(sender, LinkButton)
		Dim objClasificacion As New Lego.Clasificacion(CInt(Request("idClasificacion")))
		Select Case lnk.CommandName
			Case "1"
				objClasificacion.Imagen1 = ""
			Case "2"
				objClasificacion.Imagen2 = ""
			Case "3"
				objClasificacion.Imagen3 = ""
		End Select

		objClasificacion.Update()

        Response.Redirect("Carpeta.aspx?idRoot=" & objClasificacion.idRoot & "&idClasificacion=" & objClasificacion.id)
    End Sub












    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PCategorias Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


End Class
