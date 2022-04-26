Imports System.Data

Partial Class Sec_SalonVirtual_Controles_IndiceClasificacion
    Inherits System.Web.UI.UserControl

	Public WriteOnly Property modoEdicion As Boolean
		Set(value As Boolean)
			hiddenModoEdicion.Value = value
		End Set
	End Property

	Public WriteOnly Property idRoot As Integer
		Set(value As Integer)
			HiddenidRoot.Value = value
		End Set
	End Property

	Public WriteOnly Property idClasificacion As Integer
		Set(value As Integer)
			hiddenIdClasificacion.Value = value
		End Set
	End Property

	Public WriteOnly Property modoVistaPrevia As Boolean
		Set(value As Boolean)
			hiddenModoVistaPrevia.Value = value
		End Set
	End Property

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		llenado()
	End Sub

	Private Sub llenado()
		Dim objClasificacion As New Lego.Clasificacion
        Dim idRoot As Integer = getIdRoot()



        Dim ds As DataSet = objClasificacion.getAnexosDeClasificacion(idRoot, getIdClasificacion)
		Dim dView As DataView = ds.Tables(0).DefaultView

		dView.RowFilter = "tipoAnexo = 'Contenido'"
		listViewContenidos.DataSource = dView
		listViewContenidos.DataBind()

		dView.RowFilter = "tipoAnexo = 'Actividad'"
		listViewActividades.DataSource = dView
		listViewActividades.DataBind()

		dView.RowFilter = "tipoAnexo = 'Examen'"
		listViewExamenes.DataSource = dView
		listViewExamenes.DataBind()

		dView.RowFilter = "tipoAnexo = 'Foro'"
		listViewForos.DataSource = dView
		listViewForos.DataBind()
	End Sub

    Public claveSalon As Integer = 0


    Private Function getIdSalonVirtual() As Integer
        Dim idSalonVirtual As Integer
        Try
            idSalonVirtual = CInt(Request("idSalonVirtual"))
            claveSalon = idSalonVirtual
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

		If idClasificacion < 0 Then Return idClasificacion

		Try
			idClasificacion = CInt(hiddenIdClasificacion.Value)
		Catch ex As Exception
		End Try

		If idClasificacion < 0 Then idClasificacion = 0

		Return idClasificacion
	End Function

	Private Function getIdRoot() As Integer
		Dim idRoot As Integer
		Try
			idRoot = CInt(HiddenidRoot.Value)
		Catch ex As Exception
		End Try

		If idRoot < 0 Then Return idRoot

		Try
			idRoot = CInt(HiddenidRoot.Value)
		Catch ex As Exception
		End Try

		If idRoot < 0 Then idRoot = 0

		Return idRoot
	End Function

	Private Function getModoEdicion() As Boolean
		Dim modoEdicion As Boolean
		Try
			modoEdicion = CBool(hiddenModoEdicion.Value)
		Catch ex As Exception
		End Try

		Return modoEdicion
	End Function

	Private Function getModoVistaPrevia() As Boolean
		Dim modoVistaPrevia As Boolean
		Try
			modoVistaPrevia = CBool(hiddenModoVistaPrevia.Value)
		Catch ex As Exception
		End Try

		Return modoVistaPrevia
	End Function

	Protected Function getLinkAnexos(idRoot As Integer, idClasificacionItem As Integer, tipoAnexo As String, idTipo As Integer) As String
		Dim modoEdicion As Boolean = getModoEdicion()

		Dim filePath, file, proc As String

		If modoEdicion Then
			filePath = "~/Sec/Workbook/"

			If getModoVistaPrevia() Then

				Select Case tipoAnexo
					Case "Contenido"
						file = "verTexto.aspx"
						proc = "Contenido"

					Case "Actividad"
						file = "verActividad.aspx"
						proc = "Actividad"

					Case "Examen"
						file = "verExamen.aspx"
						proc = "Examen"

					Case "Foro"
						file = "verForo.aspx"
						proc = "Foro"
				End Select

			Else

				Select Case tipoAnexo
					Case "Contenido"
						file = "Texto.aspx"
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
				End Select

			End If

			Return filePath & file & "?idRoot=" & idRoot & "&idCI=" & idClasificacionItem & "&idClasificacion=" & getIdClasificacion() & "&proc=" & proc

		Else

			filePath = "~/Sec/SalonVirtual/"
			Select Case tipoAnexo
				Case "Contenido"
					file = "verTexto.aspx"
				Case "Actividad"
					file = "verActividad.aspx"
				Case "Examen"
					file = "verActividad.aspx"
				Case "Foro"
					file = "verForo.aspx"
			End Select

			Return filePath & file & "?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & idClasificacionItem & "&idClasificacion=" & getIdClasificacion()

		End If

	End Function

	Protected Function evaluador(quienCalifica As Contenidos.EQuienCalifica) As String
		Return quienCalifica.ToString
	End Function

	Protected Function seMuestra(mostrarRespuestas As Boolean, mostrarCalificacion As Boolean, mostrarObservaciones As Boolean) As String
		Dim hayElementoPrevio As Boolean = False
		Dim retorno As String = String.Empty

		If mostrarRespuestas Then
			retorno = "respuestas"
			hayElementoPrevio = True
		End If

		If mostrarCalificacion Then
			If hayElementoPrevio Then
				retorno &= ", calificaciones"
			Else
				retorno = "calificaciones"
				hayElementoPrevio = True
			End If
		End If

		If mostrarObservaciones Then
			If hayElementoPrevio Then
				retorno &= " y observaciones del maestro"
			Else
				retorno = "observaciones del maestro"
			End If
		Else

			If hayElementoPrevio Then
				retorno = retorno.Replace(",", " y")
			Else
				retorno = "ninguno"
			End If

		End If

		Return retorno
	End Function

	Protected Function getTextoForo(texto As String) As String
		If texto.Length > 100 Then
			Return ": " & texto.Substring(0, 97) & "..."
		ElseIf texto <> String.Empty Then
			Return ": " & texto
		Else
			Return String.Empty
		End If
	End Function

	Protected Function getTextoCorto(textoCorto As String) As String
		If textoCorto <> String.Empty Then
			Return ". " & textoCorto
		Else
			Return String.Empty
		End If
	End Function
End Class
