Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
	Public NotInheritable Class AsistenciaLista
		Inherits DBObject

#Region "Variables"
		Private idAsistenciaLista As Integer
		Public idAsistencia As Integer
		Public idUserProfile As Integer
		Public asistencia As Boolean
		Public retraso As Boolean
		Public inasistencia As Boolean

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idAsistenciaLista
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.AsistenciaLista
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM AsistenciasLista WHERE idAsistenciaLista = @idAsistenciaLista"

			Dim parameters As SqlParameter() = {New SqlParameter("@idAsistenciaLista", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idAsistenciaLista = CType(dr("idAsistenciaLista"), Integer)
				Me.idAsistencia = CType(dr("idAsistencia"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.asistencia = CType(dr("asistencia"), Boolean)
				Me.retraso = CType(dr("retraso"), Integer)
				Me.inasistencia = CType(dr("inasistencia"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
        End Sub


        Sub New(ByVal clavePrincipal As Integer, ByVal claveUsuario As Integer)
            Dim queryString As String = "SELECT * FROM AsistenciasLista WHERE idAsistencia = @idAsistencia and idUserProfile=@idUserProfile"

            Dim parameters As SqlParameter() = {New SqlParameter("@idAsistencia", clavePrincipal), New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idAsistenciaLista = CType(dr("idAsistenciaLista"), Integer)
                Me.idAsistencia = CType(dr("idAsistencia"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.asistencia = CType(dr("asistencia"), Boolean)
                Me.retraso = CType(dr("retraso"), Integer)
                Me.inasistencia = CType(dr("inasistencia"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [AsistenciasLista] ([idAsistencia], [idUserProfile], [asistencia], " & _
				 "[retraso], [inasistencia]) VALUES (@idAsistencia, @idUserProfile, @asistencia, @retraso, @inasistencia)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idAsistencia", Me.idAsistencia), _
				 New SqlParameter("@idUserProfile", Me.idUserProfile), _
				 New SqlParameter("@asistencia", Me.asistencia), _
				 New SqlParameter("@retraso", Me.retraso), _
				  New SqlParameter("@inasistencia", Me.inasistencia)}

				Me.idAsistenciaLista = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
                Dim queryString As String = "UPDATE [AsistenciasLista] SET [asistencia]=@asistencia, [retraso]=@retraso, " & _
                 "[inasistencia]=@inasistencia WHERE idAsistenciaLista = @idAsistenciaLista"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idAsistenciaLista", Me.idAsistenciaLista), _
				 New SqlParameter("@asistencia", Me.asistencia), _
				 New SqlParameter("@retraso", Me.retraso), _
				  New SqlParameter("@inasistencia", Me.inasistencia)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Return 0
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal claveAsistencia As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT al.*, u.nombre ,  u.apellidos FROM AsistenciasLista al, UserProfiles u " & _
         "WHERE al.idAsistencia = @idAsistencia AND u.idUserProfile = al.idUserProfile "

			Dim parametros As SqlParameter() = {New SqlParameter("@idAsistencia", claveAsistencia)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

        Public Overloads Function GetDS(ByVal claveSalon As Integer, ByVal claveUsuario As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT al.*, a.idSalonVirtual, a.fecha FROM Asistenciaslista al, asistencias a " & _
              "WHERE al.idAsistencia = a.idAsistencia AND a.idSalonVirtual = @idSalonVirtual AND al.idUserProfile = @idUserProfile"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveAsistencia As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT al.*, u.nombre ,  u.apellidos, eu.claveAux1  FROM AsistenciasLista al, UserProfiles u, EmpresasUserProfiles eu " & _
    "WHERE al.idAsistencia = @idAsistencia AND u.idUserProfile = al.idUserProfile and eu.idUserProfile=al.idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idAsistencia", claveAsistencia)}

            Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overloads Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overloads Function Count(ByVal claveSalon As Integer, ByVal claveUsuario As Integer, ByVal claveStatus As String) As Integer
            Dim queryString As String = "SELECT COUNT(al.idAsistencia) as num FROM AsistenciasLista al, asistencias a WHERE a.idAsistencia = al.idAsistencia " & _
    "AND a.idSalonVirtual = @idSalonVirtual AND al.idUserProfile = @IdUserProfile "

			Select Case claveStatus
				Case "A"
					queryString = queryString & "AND al.asistencia = 1"
				Case "I"
					queryString = queryString & "AND al.inasistencia = 1"
				Case "R"
					queryString = queryString & "AND al.retraso = 1"
			End Select

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@IdUserProfile", claveUsuario)}

			Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
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

		Public Function RemoveLista(ByVal claveLista As Integer) As Integer
			Dim queryString As String = "DELETE FROM AsistenciasLista WHERE idAsistencia = @idAsistencia"

			Dim parametros As SqlParameter() = {New SqlParameter("@idAsistencia", claveLista)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function AddLista(ByVal claveLista As Integer) As Integer
			Dim numero As Integer = 0
			Dim myAsistencia As New Asistencia(claveLista)
			Dim mySalonUsers As New SalonVirtualUserProfile()

			'todos los alumnos inscritos
			Dim dr As SqlClient.SqlDataReader = mySalonUsers.GetDR(myAsistencia.idSalonVirtual, "I")
			Do While dr.Read
				Dim myLista As New AsistenciaLista()
				myLista.idAsistencia = claveLista
				myLista.idUserProfile = CType(dr("idUserProfile"), Integer)
				myLista.asistencia = False
				myLista.retraso = False
				myLista.inasistencia = False
				myLista.Add()
				numero = numero + 1
            Loop
            dr.Close()

			Return myAsistencia.idSalonVirtual

		End Function
#End Region
	End Class
End Namespace

