
Partial Class MPUsmart05
    Inherits System.Web.UI.MasterPage

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		Menu1.modoEdicion = False
		llenado()
		cargaReferenciasJavascript()
		getCurrentClasificacionenAccordion()
	End Sub

	Private Sub llenado()
		Dim idSalonVirtual As Integer = getIdSalonVirtual()
		lnkApuntes.NavigateUrl &= idSalonVirtual
	End Sub

	Private Sub cargaReferenciasJavascript()
		Dim path As String = ConfigurationManager.AppSettings("carpetaVirtual")

		literalHead.Text = "<script type=""text/javascript"" src=""" & path & "App_themes/Default/jquery-1.7.2.min.js""></script>" _
		 & "<script type=""text/javascript"" src=""" & path & "App_Themes/Default/jquery-1.8.ui.min.js""></script>"
	End Sub

	Private Sub getCurrentClasificacionenAccordion()
		Dim idRoot As Integer = getIdRoot()
		Dim idClasificacion As Integer = getIdClasificacion()
		Dim objClasificacion As New Lego.Clasificacion()
		Dim accordionActivo As Integer = 0

		If idRoot = 0 Or idClasificacion = 0 Then
			Dim idCI As Integer = getIdCI()

			If idCI > 0 Then
				Dim objClasificacionItem As New Lego.ClasificacionItem(getIdCI)
				idRoot = objClasificacionItem.idRoot
				idClasificacion = objClasificacionItem.idClasificacion
			Else
				If idClasificacion > 0 Then
					objClasificacion = New Lego.Clasificacion(idClasificacion)
					idRoot = objClasificacion.idRoot
				End If
			End If

		End If

		Dim dView As Data.DataView = New Lego.Clasificacion().IndiceClasificaciones(idRoot, Not esMaestro())
		dView.RowFilter = "idClasificacion = " & idClasificacion

		Try
			accordionActivo = CInt(dView(0)("numero")) - 1
		Catch ex As Exception
		End Try

		If accordionActivo < 0 Then accordionActivo = 0

        litSript.Text = "<script type=""text/javascript"">	$(window).load(function () {$("".accordion"").accordion({active: " & accordionActivo & "});});</script>"

        lnkMinilink.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

	End Sub

	Private Function getIdRoot() As Integer
		Dim claveRoot As Integer
		Try
			claveRoot = CInt(Request("idRoot"))
		Catch ex As Exception
			claveRoot = 0
		End Try

		If claveRoot < 0 Then claveRoot = 0

		Return claveRoot
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

	Public Function esMaestro() As Boolean
		Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
		Dim objUsuarios As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)

		Return New MasUsuarios.Permiso(objUsuarios, objSalonVirtual).existe
	End Function
End Class
