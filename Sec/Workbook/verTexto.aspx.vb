
Partial Class Sec_SalonVirtual_verTexto
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			colocarDatos()
		End If
	End Sub

	Sub colocarDatos()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		Dim idCI As Integer = getIdCI()

		Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
		Dim objClasificacion As New Lego.Clasificacion(objClasificacionItem.idClasificacion)
		Dim objContenido As Contenidos.Contenido = New Contenidos.Contenido(objClasificacionItem.idProc)
		Dim objRoot As New Lego.Root(objClasificacionItem.idRoot)

		If idSalonVirtual > 0 Then
			lnkSalir.NavigateUrl = "~/Sec/Workbook/AddContenido.aspx?idRoot=" & objClasificacionItem.idRoot & "&idCI=" & idCI & "&idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id
		Else
			lnkSalir.NavigateUrl = "~/Sec/Workbook/AddContenido.aspx?idRoot=" & objClasificacionItem.idRoot & "&idCI=" & idCI & "&idClasificacion=" & objClasificacion.id
		End If

		Page.Title = objContenido.titulo
		lblClasificacion.Text = objClasificacion.titulo
		lblTitulo.Text = objContenido.titulo
		literalTextoLargo.Text = objContenido.textoLargo
        literalDescripcion.Text = objContenido.textoCorto.Replace(vbCrLf, "<br>")

        pasaDatosACajitas(objContenido, showContenidos, Contenidos.TipoContenido.Texto)
        pasaDatosACajitas(objContenido, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo)
        pasaDatosACajitas(objContenido, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen)
        pasaDatosACajitas(objContenido, showFlashes, Contenidos.TipoContenido.Flash)
        pasaDatosACajitas(objContenido, showDirecciones, Contenidos.TipoContenido.Liga)


        Dim cadenaFlash As String
        If objContenido.url <> "" Then
            If objContenido.url.ToLower.Contains("http") Then
                If objContenido.url.Trim <> "" Then
                    cadenaFlash = "<iframe width=""700"" height=""620"" src=""" & objContenido.url & """></iframe><div style=""height:10px;""></div><a href=""" & objContenido.url & """ target=""_blank"" >Ver pantalla completa</a>"
                Else
                    cadenaFlash = "<br/>"
                End If

                literalUrlFrameBox.Text = cadenaFlash
            End If
        End If



        displayBuscadores1.Tags = objContenido.Tags
        displayBuscadores1.Titulo = objContenido.titulo
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

	Private Sub pasaDatosACajitas(ByRef objContenido As Contenidos.Contenido, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
		With control
			.idproc = objContenido.id
			.procedencia = objContenido.tipo.ToString
			.tipoAdjunto = tipo
		End With
	End Sub
End Class
