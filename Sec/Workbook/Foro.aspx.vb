Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Foro
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            autorizacion()
            colocarDatosEnCaja()
        End If

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
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub



    Sub colocarDatosEnCaja()


        If Request("grabado") = "1" Then
            alertSuccess.Visible = True
        End If

        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        drpUbicacion.DataSource = myc.ClasificacionesRoot(CInt(Request("idRoot")))
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

        If drpUbicacion.Items.Count < 0 Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo


        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot")
        If Request("regreso") = "carpeta" Then
            lnkSalirEdicion.NavigateUrl = "~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&regreso=" & Request("regreso")
        End If


        drpUbicacion.SelectedValue = Request("idClasificacion")




        If Request("idCI") <> "" Then
            Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
            Dim myForo As Contenidos.Foro = New Contenidos.Foro(myCI.idProc)

            txtid.Text = myForo.id
            txtTitulo.Text = myForo.titulo
            txtTextoCorto.Text = myForo.texto
            txtObjetivoCompetencia.Text = myForo.Objetivo

            btnBorrar.Visible = True
            lnkVistaPrevia.Enabled = True
            lnkVistaPrevia.Visible = True
            lnkVistaPrevia.NavigateUrl = "verForo.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id & "&idSalonVirtual=" & Request("idSalonVirtual")



            If Request("idSalonVirtual") <> "" Then
                lnkSalirEdicion.NavigateUrl = "~/sec/salonvirtual/vercarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id
            End If



        Else
            lnkVistaPrevia.Visible = False

        End If


    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.Remove()
        If Request("regreso") = "ex" Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        If Request("regreso") = "carpeta" Then
            Response.Redirect("Carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)
        End If

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If Page.IsValid Then

            Dim myCI As Lego.ClasificacionItem

            If txtid.Text <> "" Then
                myCI = editar()
                Dim cadenaredirec As String = "Foro.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Foro&idClasificacion=" & myCI.idClasificacion & "&grabado=1&regreso=" & Request("regreso")



                Response.Redirect(cadenaredirec)

            Else
                myCI = grabar()

                Dim cadenaredirec As String = "Foro.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myCI.id & "&Proc=Foro&idClasificacion=" & myCI.idClasificacion & "&grabado=1&regreso=" & Request("regreso")



                Response.Redirect(cadenaredirec)
            End If
        End If
    End Sub

    Function editar() As Lego.ClasificacionItem

        Dim myForo As Contenidos.Foro = New Contenidos.Foro(CInt(txtid.Text))
        myForo.titulo = txtTitulo.Text.ToString
        myForo.texto = txtTextoCorto.Text
        myForo.Objetivo = txtObjetivoCompetencia.Text
        myForo.fechaCreacion = Date.Now
        myForo.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        Return myCI

    End Function

    Function grabar() As Lego.ClasificacionItem


        Dim myForo As Contenidos.Foro = New Contenidos.Foro
        myForo.titulo = txtTitulo.Text.ToString
        myForo.texto = txtTextoCorto.Text
        myForo.Objetivo = txtObjetivoCompetencia.Text
        myForo.autor = CInt(Session("gUserProfileSession").idUserProfile)
        myForo.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myForo.fechaCreacion = Date.Now
        myForo.Add()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myForo.id
        myCI.procedencia = myForo.tipo
        myCI.Add()

        Return myCI

    End Function


    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        If Request("regreso") = "ex" Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        If Request("regreso") = "carpeta" Then
            Response.Redirect("Carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
        End If
    End Sub
End Class
