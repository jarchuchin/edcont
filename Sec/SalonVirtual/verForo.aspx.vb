Imports System.Data

Partial Class Sec_SalonVirtual_verForo
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			llenado()
		End If
	End Sub
    Public idCI As Integer
    Sub llenado()
        Dim idSalonVirtual As Integer = getIdSalonVirtual()
        idCI = getIdCI()

        Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
        Dim objClasificacion As New Lego.Clasificacion(objClasificacionItem.idClasificacion)
        Dim objForo As New Contenidos.Foro(objClasificacionItem.idProc)
        Dim objForoSalonVirtual As New Contenidos.ForoSalonVirtual
        Dim objRoot As New Lego.Root(objClasificacionItem.idRoot)

        panelEdicion.Visible = EsMaestro()
        lnkEdicionContenido.NavigateUrl = "~/Sec/Workbook/Foro.aspx?idRoot=" & objClasificacionItem.idRoot & "&idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacionItem.idClasificacion

        Page.Title = objForo.titulo
        lblNombreTitulo.Text = objForo.titulo
        lblClasificacion.Text = objClasificacion.titulo
        lblTitulo.Text = objForo.titulo
        littexto.Text = objForo.texto
        lblObjetivo.Text = objForo.Objetivo
        lblFecha.Text = Format(objForo.fechaCreacion, "f")
        '	litarbol.Text = objForoSalonVirtual.GetTree(objForo.id, idSalonVirtual, 0, "verForo.aspx", idCI)



        'dtgLista.DataSource = objForoSalonVirtual.GetDR(objForo.id, CInt(Request("idSalonVirtual")))
        'dtgLista.DataBind()



        pasaDatosACajitas(objForo, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo)
        pasaDatosACajitas(objForo, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen)
        pasaDatosACajitas(objForo, showFlashes, Contenidos.TipoContenido.Flash)
        pasaDatosACajitas(objForo, showDirecciones, Contenidos.TipoContenido.Liga)



        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If panelEdicion.Visible Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

        lnkUnidad.Text = objClasificacion.titulo
        lnkUnidad.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id
        lblCursoBread.Text = objForo.titulo



        lblClasificacion.Text = objClasificacion.titulo
        lblTitulo.Text = objForo.titulo





        DataList1.DataSource = objForoSalonVirtual.GetDSDisplayRaiz(objForo.id, idSalonVirtual, 0)
        ' DataList1.DataSource = objForoSalonVirtual.GetDRDisplay(objForo.id, idSalonVirtual)
        DataList1.DataBind()

        If Request("idRaiz") <> "" Then
            lblTituloComentario.Text = "Respuesta a comentario"
        End If

        'Bitacora de vista a contenidos
        Dim mybc As New Know.BitacoraContenido
        mybc.idProc = objForo.id
        mybc.Procedencia = objForo.tipo.ToString
        mybc.idSalonVirtual = mysv.id
        mybc.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mybc.ip = Request.UserHostAddress
        mybc.Browser = Request.Browser.Type & "-" & Request.Browser.Browser & "-" & Request.Browser.Platform & "-" & Request.Browser.Version
        mybc.Fecha = Date.Now
        mybc.Add()

    End Sub

    Public Function getForoRaiz(claveforo As Integer, clavesalon As Integer, claveRaiz As Integer) As DataSet
        Dim obfs As New Contenidos.ForoSalonVirtual
        Return obfs.GetDSDisplayRaiz(claveforo, clavesalon, claveRaiz)
    End Function
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

	Private Sub pasaDatosACajitas(ByRef objForo As Contenidos.Foro, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
		With control
			.idProc = objForo.id
			.procedencia = objForo.tipo.ToString
			.tipoAdjunto = tipo
		End With
	End Sub

    'Protected Sub btnResponder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResponder.Click
    '	Dim objClasificacionItem As New Lego.ClasificacionItem(getIdCI)
    '	Dim objForo As New Contenidos.Foro(objClasificacionItem.idProc)

    '	Response.Redirect("verForoRespuesta.aspx?idForo=" & objForo.id & "&idSalonVirtual=" & getIdSalonVirtual() & "&idRaiz=0" & "&idCI=" & objClasificacionItem.id)
    'End Sub

	Public Function getLiga(ByVal claveNombre As Object, ByVal claveForo As Integer) As String
		Dim regreso As String = String.Empty

		If Not Convert.IsDBNull(claveNombre) Then
			Dim cadena As String = claveNombre.Substring(claveNombre.LastIndexOf(".") + 1)
			If cadena <> String.Empty Then

				Select Case cadena.ToLower
					Case "jpg", "bmp", "gif", "png"
						regreso = "~/sec/showfile.aspx?idForoSalonVirtual=" & claveForo
				End Select

				Return regreso
			End If
		End If

		Return regreso
	End Function

	Public Function getMostrar(ByVal clavenombre As Object) As Boolean
		If Not Convert.IsDBNull(clavenombre) Then
			If clavenombre <> String.Empty Then
				Return True
			End If
		End If

		Return False
	End Function

	Public Function EsMaestro() As Boolean
		Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
		Dim objUserProfile As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
		Dim objPermiso As New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

		Return objPermiso.existe
    End Function



    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveClaveAux2 As String, claveUsuario As Integer) As String


        If Not Convert.IsDBNull(claveFoto) Then
            If claveFoto = "default.jpg" Then
                If claveClaveAux1 <> "" Then
                    Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
                End If
                If claveClaveAux2 <> "" Then
                    Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
                End If
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            Else
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            End If
        Else
            If claveClaveAux1 <> "" Then
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            End If
            If claveClaveAux2 <> "" Then
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            End If
            Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
        End If
    End Function

    Protected Sub btngrabar_Click(sender As Object, e As System.EventArgs) Handles btngrabar.Click
        If Page.IsValid Then


            Dim idCI As Integer = getIdCI()

            Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)


            Dim myfsv As Contenidos.ForoSalonVirtual = New Contenidos.ForoSalonVirtual
            myfsv.idForo = objClasificacionItem.idProc
            myfsv.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myfsv.idRaiz = CInt(Request("idRaiz"))
            myfsv.iduserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myfsv.titulo = lblTitulo.Text
            myfsv.texto = txtmensaje.Text
            myfsv.fechaCreacion = Date.Now
            myfsv.nombre = ""
            myfsv.nombreOriginal = ""
            myfsv.espacio = 0
            myfsv.Add()

            If FileUpload1.HasFile Then
                Dim extension As String = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1)
                Dim nombreoriginal As String = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\") + 1)
                Dim nombre As String = myfsv.id & "." & extension
                myfsv.nombre = nombre
                myfsv.nombreOriginal = nombreoriginal
                myfsv.espacio = FileUpload1.PostedFile.ContentLength
                FileUpload1.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "foros\" & myfsv.nombre)
                myfsv.Update()

            End If

            Response.Redirect("verForo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))
        End If

    End Sub

    Public Function presentarImagen(claveNombreOriginal As Object) As Boolean
        If Convert.IsDBNull(claveNombreOriginal) Then
            Return False
        Else
            If claveNombreOriginal <> "" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Class
