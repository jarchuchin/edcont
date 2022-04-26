
Partial Class Controles_HeaderBreadcrumSalon
    Inherits System.Web.UI.UserControl

	Public WriteOnly Property procedencia As tipoObjeto
		Set(value As tipoObjeto)
			Select Case value.ToString
				Case "Actividad"
					lblUbicacion.Text = "Actividades"
				Case "Contenido"
					lblUbicacion.Text = "contenidos"
				Case "Foro"
					lblUbicacion.Text = "Foros"
			End Select
		End Set
	End Property

	Public WriteOnly Property tituloRoot As String
		Set(value As String)
			lnkPaginaPrincipalCurso.Text = value
		End Set
	End Property

	Public WriteOnly Property tituloClasificacion As String
		Set(value As String)
			lnkClasificacion.Text = value
		End Set
	End Property

	Public WriteOnly Property idClasificacion As Integer
		Set(value As Integer)
			hiddenIdClasificacion.Value = value
		End Set
	End Property

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			llenado()
		End If
	End Sub

	Private Sub llenado()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()

		If getIdCI() = 0 Then lblUbicacion.Visible = False
		lnkPaginaPrincipalCurso.NavigateUrl &= idSalonVirtual
		lnkClasificacion.NavigateUrl = "~/Sec/SalonVirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & getIdClasificacion()

		ajustaTexto()
	End Sub

	Private Sub ajustaTexto()
		Dim longitudMaxima As Integer = 70 - lblUbicacion.Text.Length
		Dim curso As String = lnkPaginaPrincipalCurso.Text
		Dim clasificacion As String = lnkClasificacion.Text
		Dim minimoClasificacion As Integer = 12
		Dim excedenteCurso As Integer = (longitudMaxima - minimoClasificacion) - curso.Length

		If excedenteCurso >= 0 Then	'el título del curso cabe completo

			If clasificacion.Length > minimoClasificacion + excedenteCurso Then
				clasificacion = clasificacion.Substring(0, minimoClasificacion + excedenteCurso - 3) & "..."
			End If

		Else
			curso = curso.Substring(0, curso.Length + excedenteCurso - 3) & "..."
			If clasificacion.Length > minimoClasificacion Then
				clasificacion = clasificacion.Substring(0, minimoClasificacion - 3) & "..."
			End If
		End If

		lnkPaginaPrincipalCurso.Text = curso
		lnkClasificacion.Text = clasificacion
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

		If idClasificacion > 0 Then Return idClasificacion

		Try
			idClasificacion = CInt(hiddenIdClasificacion.Value)
		Catch ex As Exception
		End Try

		If idClasificacion < 0 Then idClasificacion = 0

		Return idClasificacion
	End Function
End Class
