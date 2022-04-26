Imports System.Globalization
Imports System.Threading

Partial Class Sec_Workbook_Carpeta
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '   IndiceClasificacion1.modoEdicion = False
        If Not IsPostBack Then
            llenado()
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


    Sub llenado()
        Dim idSalonVirtual As Integer = getIdSalonVirtual()
        Dim idClasificacion As Integer = getIdClasificacion()
        Dim objClasificacion As Lego.Clasificacion

        If idClasificacion > 0 Then
            objClasificacion = New Lego.Clasificacion(idClasificacion)
        Else
            objClasificacion = New Lego.Clasificacion(idSalonVirtual, True)
        End If

        Dim mysv As New Lego.Root(objClasificacion.idRoot)

        'seccion breadcrump
        lnkb1.Text = mysv.titulo
        lnkb1.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & objClasificacion.idRoot
        lnkb2.NavigateUrl = "~/sec/workbook/Explorar.aspx?idRoot=" & objClasificacion.idRoot
        lbltit.Text = objClasificacion.titulo
        lblTitulobox.Text = objClasificacion.titulo


        idClasificacion = objClasificacion.id

        Dim objRoot As New Lego.Root(objClasificacion.idRoot)



        Page.Title = objClasificacion.titulo
        lblTitulo.Text = objClasificacion.titulo
        literalTexto.Text = objClasificacion.texto
        literalPlanteamientoBreve.Text = objClasificacion.PlanteamientoBreve.Replace(vbCrLf, "<br/>")
        literalDia.Text = objClasificacion.diaDisplay


        If objClasificacion.idActividad > 0 Then
            lnkExamenDiagnostico.NavigateUrl = "~/sec/workbook/verExamen.aspx?idActivida"
        End If


        Dim objObjetivo As New Lego.Objetivo
        rptObjetivos.DataSource = objObjetivo.GetDR(idClasificacion)
        rptObjetivos.DataBind()

        lnkAgregarObjetivo.NavigateUrl = "AddObjetivo.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual")
        lnkEditarCarpeta.NavigateUrl = "addCarpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=" & Request("regreso")



        If objClasificacion.Imagen1 <> "" Then
            imagenClasificacion1.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & idClasificacion & "&num=1"
            imagenClasificacion1.Visible = True
        Else
            imagenClasificacion1.Visible = False
            panelImagen2.Visible = False
        End If





        DisplayContenidoTipo1.Tipo = "Contenido"
        DisplayContenidoTipo2.Tipo = "Actividad"
        DisplayContenidoTipo3.Tipo = "Examen"
        DisplayContenidoTipo4.Tipo = "Foro"

        'IndiceClasificacion1.idRoot = objClasificacion.idRoot
        'IndiceClasificacion1.modoEdicion = True
        'IndiceClasificacion1.modoVistaPrevia = True



        colocarLinks()
    End Sub


    Sub colocarLinks()


        ibLectura.NavigateUrl = "~/sec/Workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&proc=Contenido&regreso=carpeta" & "&idSalonVirtual=" & Request("idSalonVirtual")
        ibArchivo.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&display=mfiles&regreso=carpeta" & "&idSalonVirtual=" & Request("idSalonVirtual")
        ' ibArticulate.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&display=articulate&regreso=carpeta" & "&idSalonVirtual=" & Request("idSalonVirtual")
        ibActividad.NavigateUrl = "~/sec/Workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&regreso=carpeta" & "&idSalonVirtual=" & Request("idSalonVirtual")
        ibExamen.NavigateUrl = "~/sec/Workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&regreso=carpeta" & "&idSalonVirtual=" & Request("idSalonVirtual")
        ibForo.NavigateUrl = "~/sec/Workbook/Foro.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=carpeta"
        ibBuscar.NavigateUrl = "~/sec/Workbook/Buscar.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=carpeta"


        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        If myc.Count(CInt(Request("idRoot"))) > 0 Then
            PanelIcons.Visible = True
        Else
            PanelIcons.Visible = False

        End If
    End Sub


    Private Function getIdSalonVirtual() As Integer
        Dim idSalonVirtual As Integer
        Try
            idSalonVirtual = CInt(Request("idSalonVirtual"))
        Catch ex As Exception
            idSalonVirtual = 0
        End Try

        If idSalonVirtual < 0 Then idSalonVirtual = 0

        Return idSalonVirtual
    End Function

    Private Function getIdCI() As Integer
        Dim idCI As Integer
        Try
            idCI = CInt(Request("idCI"))
        Catch ex As Exception
            idCI = 0
        End Try

        If idCI < 0 Then idCI = 0

        Return idCI
    End Function

    Private Function getIdClasificacion() As Integer
        Dim idClasificacion As Integer
        Try
            idClasificacion = CInt(Request("idClasificacion"))
        Catch ex As Exception
            idClasificacion = 0
        End Try

        If idClasificacion < 0 Then idClasificacion = 0

        Return idClasificacion
    End Function

    Public Function getObjetivo(claveobjetivo As Object) As String
        Dim cadena As String = ""

        If Not Convert.IsDBNull(claveobjetivo) Then
            Return Replace(claveobjetivo, vbCr, "<br/>")
        Else
            Return ""
        End If

        Return cadena
    End Function



End Class
