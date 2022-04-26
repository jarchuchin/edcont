Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Comm
	Public NotInheritable Class Mensaje
		Inherits DBObject

#Region "Variables"
		Private idMensaje As Integer
		Public idSalonVirtual As Integer
		Public origen As MasUsuarios.UserProfile
		Public destino As MasUsuarios.UserProfile
		Public idOrigen As Integer
		Public idDestino As Integer
		Public asunto As String
		Public texto As String
		Public fecha As Date
		Public status As String
		Public borrado As Boolean
		Public prioridad As String

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idMensaje
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Mensaje
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Mensajes WHERE idMensaje = @idMensaje"

			Dim parameters As SqlParameter() = {New SqlParameter("@idMensaje", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idMensaje = clavePrincipal
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.origen = New MasUsuarios.UserProfile(CType(dr("idOrigen"), Integer), False)
				Me.destino = New MasUsuarios.UserProfile(CType(dr("idDestino"), Integer), False)
				Me.asunto = CType(dr("asunto"), String)
				Me.texto = CType(dr("texto"), String)
				Me.fecha = CType(dr("fecha"), Date)
				Me.status = CType(dr("status"), String)
				Me.borrado = CType(dr("borrado"), Boolean)
				Me.prioridad = CType(dr("Prioridad"), String)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Mensajes] ([idSalonVirtual], [idOrigen], [idDestino], [asunto], [texto], " & _
				 "[fecha], [status], [borrado], [prioridad]) VALUES (@idSalonVirtual, @idOrigen, @idDestino, @asunto, @texto, " & _
				 "@fecha, @status, @borrado, @prioridad)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
				 New SqlParameter("@idOrigen", Me.idOrigen), _
				 New SqlParameter("@idDestino", Me.idDestino), _
				 New SqlParameter("@asunto", Me.asunto), _
				 New SqlParameter("@texto", Me.texto), _
				 New SqlParameter("@fecha", Me.fecha), _
				 New SqlParameter("@status", Me.status), _
				 New SqlParameter("@borrado", Me.borrado), _
				 New SqlParameter("@prioridad", Me.prioridad)}

				Me.idMensaje = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [Mensajes] SET [borrado]=@borrado, [status]=@status WHERE idMensaje = @idMensaje"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idMensaje", Me.idMensaje), _
				  New SqlParameter("@borrado", Me.borrado), _
				  New SqlParameter("@status", Me.status)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Me.borrado = True
			Return Me.Update()
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM Mensajes"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overloads Function GetDR(ByVal claveUserDestino As Integer, Optional ByVal claveSalon As Integer = 0, _
		 Optional ByVal MensajesBorrados As Boolean = Nothing) As System.Data.IDataReader

			Dim queryString As String = "SELECT m.*, u.nombre + ' ' + u.apellidos AS nombre FROM Mensajes m, UserProfiles u " & _
			   "WHERE u.idUserProfile = m.idOrigen AND m.idDestino = @idDestino "
			If claveSalon > 0 Then
				queryString = queryString & "AND m.idSalonVirtual = @idSalonVirtual "
			End If
			If Not IsNothing(MensajesBorrados) Then
				queryString = queryString & "AND m.borrado = @borrado "
			End If
			queryString = queryString & "ORDER BY fecha DESC"

			Dim parametros As SqlParameter() = {New SqlParameter("@idDestino", claveUserDestino)}
			If claveSalon > 0 Then
				ReDim Preserve parametros(2)
				parametros(1) = New SqlParameter("@idSalonVirtual", claveSalon)
			End If
			If Not IsNothing(MensajesBorrados) Then
				ReDim Preserve parametros(3)
				parametros(2) = New SqlParameter("@borrado", MensajesBorrados)
			End If

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Mensajes"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveUserDestino As Integer, Optional ByVal claveSalon As Integer = 0, _
		 Optional ByVal MensajesBorrados As Boolean = Nothing) As System.Data.DataSet

			Dim queryString As String = "SELECT m.*, u.nombre + ' ' + u.apellidos AS nombre FROM Mensajes m, UserProfiles u " & _
			   "WHERE u.idUserProfile = m.idOrigen AND m.idDestino = @idDestino "
			If claveSalon > 0 Then
				queryString = queryString & "AND m.idSalonVirtual = @idSalonVirtual "
			End If
			If Not IsNothing(MensajesBorrados) Then
				queryString = queryString & "AND m.borrado = @borrado "
			End If
			queryString = queryString & "ORDER BY fecha DESC"

			Dim parametros As SqlParameter() = {New SqlParameter("@idDestino", claveUserDestino)}
			If claveSalon > 0 Then
				ReDim Preserve parametros(2)
				parametros(1) = New SqlParameter("@idSalonVirtual", claveSalon)
			End If
			If Not IsNothing(MensajesBorrados) Then
				ReDim Preserve parametros(3)
				parametros(2) = New SqlParameter("@borrado", MensajesBorrados)
			End If

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idMensaje) as num FROM Mensajes"

			Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, Nothing)
			Dim numero As Integer = 0
			If dr.Read Then
				If Not Convert.IsDBNull(dr("num")) Then
					numero = CType(dr("num"), Integer)
				End If

			End If
			dr.Close()

			Return numero
		End Function

		Public Overloads Function Count(ByVal claveUserDestino As Integer, Optional ByVal claveSalon As Integer = 0, Optional ByVal claveStatus As String = "") As Integer
			Dim queryString As String = "SELECT COUNT(idMensaje) as num FROM Mensajes WHERE idDestino = @idDestino "
			If claveSalon > 0 Then
				queryString = queryString & "AND idSalonVirtual = @idSalonVirtual "
			End If
			If claveStatus <> "" Then
				queryString = queryString & "AND status = @status "
			End If
			queryString = queryString & "AND borrado = 0"

			Dim parametros As SqlParameter() = {New SqlParameter("@idDestino", claveUserDestino)}
			If claveSalon > 0 Then
				ReDim Preserve parametros(2)
				parametros(1) = New SqlParameter("@idSalonVirtual", claveSalon)
			End If
			If claveStatus <> "" Then
				ReDim Preserve parametros(3)
				parametros(2) = New SqlParameter("@status", claveStatus)
			End If

			Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, Nothing)
			Dim numero As Integer = 0
			If dr.Read Then
				If Not Convert.IsDBNull(dr("num")) Then
					numero = CType(dr("num"), Integer)
				End If

			End If
			dr.Close()

			Return numero
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function
#End Region
	End Class
End Namespace

