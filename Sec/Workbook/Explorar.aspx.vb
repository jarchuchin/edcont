Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization
Imports System.Threading


Partial Class Sec_Workbook_Explorar
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
            llenado()
            colocarLinks()
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

    Sub colocarLinks()
        ibNuevoFolder.NavigateUrl = "~/sec/Workbook/AddCarpeta.aspx?idRoot=" & Request("idRoot") & "&regreso=ex"

        ibLectura.NavigateUrl = "~/sec/Workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&proc=Contenido" & "&regreso=ex"
        ibArchivo.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=mfiles" & "&regreso=ex"
        'AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & request("idSalonVirtual") & "&display=file
        ibAticulate.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=articulate" & "&regreso=ex"
        'ibImagen.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=image" & "&regreso=ex"
        'ibFlash.NavigateUrl = "~/sec/Workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file" & "&regreso=ex"
        ibActividad.NavigateUrl = "~/sec/Workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&regreso=ex"
        ibExamen.NavigateUrl = "~/sec/Workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&regreso=ex"
        ibForo.NavigateUrl = "~/sec/Workbook/Foro.aspx?idRoot=" & Request("idRoot") & "&regreso=ex"
        ibBuscar.NavigateUrl = "~/sec/Workbook/Buscar.aspx?idRoot=" & Request("idRoot") & "&regreso=ex"


        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        If myc.Count(CInt(Request("idRoot"))) > 0 Then
            PanelIcons.Visible = True
        Else
            PanelIcons.Visible = False

        End If
    End Sub

    Private Sub llenado()
		Dim idRoot As Integer = getIdRoot()
		Dim objRoot As New Lego.Root(idRoot)
		If Not objRoot.existe Then Response.Redirect("~/sec/Libros.aspx")

        'If objRoot.titulo.Length > 30 Then
        '	lnkTitulo.Text = objRoot.titulo.Substring(0, 30) & "..."
        'Else
        lnkTitulo.Text = objRoot.titulo
        'End If
        lnkTitulo.ToolTip = objRoot.titulo
        lblTitulobox.Text = objRoot.titulo


        lblTitulo.text = objRoot.titulo
        lnkTitulo.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & idRoot
        'lnkAgregarCarpeta.NavigateUrl = "~/sec/workbook/addcarpeta.aspx?idRoot=" & idRoot

        '      Dim ds As System.Data.DataSet = New Lego.Clasificacion().IndiceNested(idRoot, False)
        'listViewUnidades.DataSource = ds
        'listViewUnidades.DataBind()

        'repeaterClasificaciones.DataSource = ds
        'repeaterClasificaciones.DataBind()

    End Sub

	Private Function getIdRoot() As Integer
		Dim idRoot As Integer
		Try
			idRoot = CInt(Request("idRoot"))
		Catch ex As Exception
			idRoot = 0
		End Try

		If idRoot < 0 Then idRoot = 0

		Return idRoot
	End Function

	Protected Function getLinkAnexos(idRoot As Integer, idClasificacionItem As Integer, idClasificacion As Integer, tipoAnexo As String, idTipo As Integer) As String
		Dim filePath, file, proc As String

		filePath = "~/Sec/Workbook/"

		Select Case tipoAnexo
			Case "Contenido"
				'file = "Texto.aspx"
				file = "AddContenido.aspx"
				Select Case idTipo
					Case Contenidos.TipoContenido.Archivo
						proc = "Archivo"
					Case Contenidos.TipoContenido.Flash
						proc = "Flash"
					Case Contenidos.TipoContenido.Imagen
						proc = "Imagen"
					Case Contenidos.TipoContenido.Texto
						proc = "Contenido"
				End Select
			Case "Actividad"
				file = "Actividad.aspx"
				proc = "Actividad"
			Case "Examen"
				file = "Examen.aspx"
				proc = "Examen"
			Case "Foro"
				file = "Foro.aspx"
				proc = "Foro"
			Case Else
				file = "AddContenido.aspx"
				proc = "Contenido"
		End Select

		Return filePath & file & "?idRoot=" & idRoot & "&idCI=" & idClasificacionItem & "&idClasificacion=" & idClasificacion & "&proc=" & proc
	End Function

    'Protected Sub listViewUnidades_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles listViewUnidades.ItemDataBound
    '	If e.Item.ItemType = ListViewItemType.DataItem Then
    '		Dim dView As Data.DataView
    '		Dim lbl As Label

    '		dView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionContenido")
    '		lbl = CType(e.Item.FindControl("lblContenidos"), Label)
    '		lbl.Text = dView.Count

    '		dView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionActividad")
    '		lbl = CType(e.Item.FindControl("lblActividades"), Label)
    '		lbl.Text = dView.Count

    '		dView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionExamen")
    '		lbl = CType(e.Item.FindControl("lblExamenes"), Label)
    '		lbl.Text = dView.Count

    '		dView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionForo")
    '		lbl = CType(e.Item.FindControl("lblForos"), Label)
    '		lbl.Text = dView.Count

    '		Dim idClasificacion As Integer = CInt(CType(e.Item.DataItem, DataRowView)("idClasificacion"))
    '		Dim objClasificacion As New Lego.Clasificacion
    '		lbl = CType(e.Item.FindControl("lblAnexos"), Label)
    '		lbl.Text = objClasificacion.getTotalAnexos(idClasificacion)

    '		lbl = CType(e.Item.FindControl("lblObjetivos"), Label)
    '		lbl.Text = objClasificacion.getTotalObjetivos(idClasificacion)
    '	End If

    'End Sub

    '   Protected Sub repeaterClasificaciones_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repeaterClasificaciones.ItemDataBound
    '	If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
    '		Dim dView As Data.DataView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionContenido")
    '		CType(e.Item.FindControl("listViewContenidos"), ListView).DataSource = dView
    '		CType(e.Item.FindControl("listViewContenidos"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewActividades"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionActividad")
    '		CType(e.Item.FindControl("listViewActividades"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewExamenes"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionExamen")
    '		CType(e.Item.FindControl("listViewExamenes"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewForos"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionForo")
    '		CType(e.Item.FindControl("listViewForos"), ListView).DataBind()
    '	End If

    'End Sub
End Class
