
Partial Class Sec_Workbook_Controles_DisplayListaObjetos
    Inherits System.Web.UI.UserControl

	Public WriteOnly Property paginaDestino As String
		Set(value As String)
			hiddenPaginaDestino.Value = value
		End Set
	End Property

	Public WriteOnly Property tipo As tipoObjeto
		Set(value As tipoObjeto)
			hiddenTipo.Value = value
		End Set
	End Property

	Public WriteOnly Property esExamen As Boolean
		Set(value As Boolean)
			hiddenEsExamen.Value = value
		End Set
	End Property

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			colocarDatos()
		End If
	End Sub

	Sub colocarDatos()
		Dim objClasificacion As New Lego.ClasificacionItem
		Dim dr As Data.SqlClient.SqlDataReader

		Select Case getTipo()
			Case tipoObjeto.Actividad

				If CBool(hiddenEsExamen.Value) Then
					lblTitulo.Text = "EXÁMENES GUARDADOS"
					dr = objClasificacion.getDRExamenes(getIdClasificacion)
				Else
					lblTitulo.Text = "ACTIVIDADES GUARDADAS"
					dr = objClasificacion.getDRActvidades(getIdClasificacion)
				End If

			Case tipoObjeto.Foro
				lblTitulo.Text = "FOROS GUARDADOS"
				dr = objClasificacion.getDRForos(getIdClasificacion)
            Case tipoObjeto.Contenido
                lblTitulo.Text = "CONTENIDOS GUARDADOS"
                dr = objClasificacion.getDRObjetosAprendizajeContenidos(getIdClasificacion)
            Case tipoObjeto.Anexos
                lblTitulo.Text = "ANEXOS GUARDADOS"
                dr = objClasificacion.getDRObjetosAprendizajeAnexos(getIdClasificacion)


        End Select

		listViewObjetos.DataSource = dr
		listViewObjetos.DataBind()
	End Sub

	Public Function getUrl(claveClasificacionItem As Integer, claveClasificacion As Integer, claveidProc As Integer, claveProcedencia As String, claveRoot As Integer) As String
		Dim pagina As String = hiddenPaginaDestino.Value
		If pagina = String.Empty Then pagina = "AddContenido.aspx"

		Return pagina & "?idRoot=" & claveRoot & "&idClasificacion=" & claveClasificacion & "&idCI=" & claveClasificacionItem
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

	Private Function getTipo() As tipoObjeto
		Dim varTipo As tipoObjeto = tipoObjeto.Actividad
		Try
			varTipo = [Enum].Parse(GetType(tipoObjeto), hiddenTipo.Value)
		Catch ex As Exception
		End Try

		Return varTipo
	End Function

	Protected Sub btnAgregar_Click(sender As Object, e As System.EventArgs) Handles btnAgregar.Click
		Dim pagina As String = hiddenPaginaDestino.Value
		If pagina = String.Empty Then pagina = "AddContenido.aspx"
		Response.Redirect(pagina & "?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
	End Sub
End Class
