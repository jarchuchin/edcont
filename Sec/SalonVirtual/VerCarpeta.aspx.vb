
Partial Class Sec_SalonVirtual_VerCarpeta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '      IndiceClasificacion1.modoEdicion = False
        If Not IsPostBack Then

            llenado()
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

        idClasificacion = objClasificacion.id

        Dim objRoot As New Lego.Root(objClasificacion.idRoot)
        Dim esmaestroloc As Boolean = EsMaestro()

        panelEdicion.Visible = esmaestroloc

        Dim myuPer As New MasUsuarios.UserProfile(CInt(Session("idUserProfile")), False)


        lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/Carpeta.aspx?idRoot=" & objRoot.id & "&idClasificacion=" & objClasificacion.id & "&idSalonVirtual=" & idSalonVirtual
        'revisar Permisos 
        Dim mypermiso As New MasUsuarios.Permiso(myuPer, objRoot)
        If Session("esAdministrador") Then
            lnkEdicionContenido.Visible = True
        Else
            lnkEdicionContenido.Visible = mypermiso.PContenidos
        End If



        Page.Title = objClasificacion.titulo
        'lblTitulo.Text = objClasificacion.titulo
        lblNombreTitulo.Text = objClasificacion.titulo
        lblTituloClasificacionCentro.Text = objClasificacion.titulo


        literalTexto.Text = objClasificacion.texto
        literalPlanteamientoBreve.Text = objClasificacion.PlanteamientoBreve.Replace(vbCrLf, "<br/>")

        If objClasificacion.idActividad > 0 Then
            lnkExamenDiagnostico.NavigateUrl = "~/sec/salonvirtual/verExamen.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id & "&idA=" & objClasificacion.idActividad
            Dim mya As New Contenidos.Actividad(objClasificacion.idActividad)
            lnkExamenDiagnostico.Text = mya.titulo
        Else
            panelExamen.Visible = False
        End If


        literalDia.Text = objClasificacion.diaDisplay


        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If esmaestroloc Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else

            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lblCursoBread.Text = objClasificacion.titulo
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual



        If objClasificacion.Imagen1 <> "" Then

            imagenClasificacion1.ImageUrl = "~/sec/showfile.aspx?idClasificacion=" & idClasificacion & "&num=1"
            imagenClasificacion1.Visible = True
        End If


        Dim ds As System.Data.DataSet

        ds = objClasificacion.GetDSRaizRoot(0, objClasificacion.idRoot, Not esmaestroloc)

        IndiceContenido1.idRoot = objClasificacion.idRoot
        IndiceContenido1.dsContenidos = ds

        IndiceContenido2.idRoot = objClasificacion.idRoot
        IndiceContenido2.dsContenidos = ds

        IndiceContenido3.idRoot = objClasificacion.idRoot
        IndiceContenido3.dsContenidos = ds

        pasaDatosACajitas(showContenidos, objClasificacion, Contenidos.TipoContenido.Texto)
        pasaDatosACajitas(showContenidosArticulate, objClasificacion, Contenidos.TipoContenido.Articulate)

        pasaDatosACajitas(showArchivosAdjuntos, objClasificacion, Contenidos.TipoContenido.Archivo)
        pasaDatosACajitas(showImagenesAdjuntos, objClasificacion, Contenidos.TipoContenido.Imagen)
        pasaDatosACajitas(showFlashes, objClasificacion, Contenidos.TipoContenido.Flash)
        pasaDatosACajitas(showDirecciones, objClasificacion, Contenidos.TipoContenido.Liga)

        '		IndiceClasificacion1.idRoot = objClasificacion.idRoot
        '       IndiceClasificacion1.modoEdicion = False

        'displayComentarios1.claveidProc = objClasificacion.id
        'displayComentarios1.claveProcedencia = objClasificacion.tipo.ToString
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

    Private Sub pasaDatosACajitas(control As Sec_Workbook_Controles_showadjuntos, ByRef objClasificacion As Lego.Clasificacion, tipoAdjunto As Contenidos.TipoContenido)
        With control
            .idRoot = objClasificacion.idRoot
            .idClasificacion = objClasificacion.id
            .procedencia = objClasificacion.tipo.ToString
            .tipoAdjunto = tipoAdjunto
        End With
    End Sub

    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
        Dim objUserProfile As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)
        If Session("esAdministrador") Or Session("esGerenciaSalones") Then
            Return True
        End If
        Return objPermiso.existe
    End Function
End Class
