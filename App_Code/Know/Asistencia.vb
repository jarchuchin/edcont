Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
	Public NotInheritable Class Asistencia
		Inherits DBObject

#Region "Variables"
		Private idAsistencia As Integer
		Public idSalonVirtual As Integer
		Public fecha As Date

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idAsistencia
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Asistencia
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Asistencias WHERE idAsistencia = @idAsistencia"

			Dim parameters As SqlParameter() = {New SqlParameter("@idAsistencia", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idAsistencia = CType(dr("idAsistencia"), Integer)
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.fecha = CType(dr("fecha"), Date)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveSalon As Integer, ByVal clavefecha As Date)
			Dim queryString As String = "SELECT * FROM Asistencias WHERE idSalonVirtual = @idSalonVirtual AND fecha = @fecha"

			Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@echa", clavefecha)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idAsistencia = CType(dr("idAsistencia"), Integer)
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.fecha = CType(dr("fecha"), Date)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Asistencias] ([idSalonVirtual], [fecha]) VALUES (@idSalonVirtual, @fecha)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
				  New SqlParameter("@fecha", Me.fecha)}

				Me.idAsistencia = Me.ExecuteNonQuery(queryString, parametros, True)

				Dim myLista As New Know.AsistenciaLista()
				myLista.AddLista(Me.idAsistencia)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Return 0
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM Asistencias WHERE idAsistencia = @idAsistencia"

			Dim parametros As SqlParameter() = {New SqlParameter("@idAsistencia", Me.idAsistencia)}

			Dim rowsAffected As Integer = Me.ExecuteNonQuery(queryString, parametros)

			Dim myLista As Know.AsistenciaLista = New Know.AsistenciaLista()
			myLista.RemoveLista(Me.idAsistencia)

			Return rowsAffected
		End Function

		Public Overloads Function Remove(ByVal claveSalonVirtual As Integer) As Integer
			Dim queryString As String = "DELETE FROM Asistencias WHERE idSalonVirtual = @idSalonVirtual"

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

			Dim rowsAffected As Integer = Me.ExecuteNonQuery(queryString, parametros)

			Return rowsAffected
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal claveSalon As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM Asistencias WHERE idSalonVirtual = @idSalonVirtual"

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveSalon As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Asistencias WHERE idSalonVirtual = @idSalonVirtual"

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function

		Public Sub SetAsistenciaLista(ByVal claveSalon As Integer, ByVal claveUsuario As Integer)
			Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveSalon)
			Dim myAL As AsistenciaLista
			Do While dr.Read
				myAL = New AsistenciaLista
				myAL.idAsistencia = CType(dr("idAsistencia"), Integer)
				myAL.idUserProfile = claveUsuario
				myAL.asistencia = False
				myAL.inasistencia = False
				myAL.retraso = False
				myAL.Add()
			Loop
			dr.Close()
		End Sub
#End Region
	End Class
End Namespace