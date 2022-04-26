Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
	Public NotInheritable Class BoletinSalonVirtual
		Inherits DBObject

#Region "Variables"
		Private idBoletinSalonVirtual As Integer
		Public idSalonVirtual As Integer
		Public idUserProfile As Integer
		Public texto As String
        Public fecha As Date
        Public esMaestro As Boolean = False

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idBoletinSalonVirtual
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.BoletinSalonVirtual
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM BoletinesSalonVirtual WHERE idBoletinSalonVirtual = @idBoletinSalonVirtual"

			Dim parameters As SqlParameter() = {New SqlParameter("@idBoletinSalonVirtual", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idBoletinSalonVirtual = CType(dr("idBoletinSalonVirtual"), Integer)
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.texto = CType(dr("texto"), String)
                Me.fecha = CType(dr("fecha"), Date)
                If Not Convert.IsDBNull(dr("esMaestro")) Then
                    Me.esMaestro = CBool(dr("esMaestro"))
                End If
                Me.varExiste = True
            End If
            dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
                Dim queryString As String = "INSERT INTO [BoletinesSalonVirtual] ([idSalonVirtual], [idUserProfile], [texto], " & _
                 "[fecha], esMaestro) VALUES (@idSalonVirtual, @idUserProfile, @texto, @fecha, @esMaestro)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                 New SqlParameter("@idUserProfile", Me.idUserProfile), _
                 New SqlParameter("@texto", Me.texto), _
                  New SqlParameter("@fecha", Me.fecha), _
                  New SqlParameter("@esMaestro", Me.esMaestro)}

				Me.idBoletinSalonVirtual = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
                Dim queryString As String = "UPDATE [BoletinesSalonVirtual] SET [idSalonVirtual]=@idSalonVirtual, [idUserProfile]=@idUserProfile, " & _
                 "[texto]=@texto, [fecha]=@fecha, esMaestro=@esMaestro WHERE idBoletinSalonVirtual = @idBoletinSalonVirtual"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idBoletinSalonVirtual", Me.idBoletinSalonVirtual), _
                 New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                 New SqlParameter("@idUserProfile", Me.idUserProfile), _
                 New SqlParameter("@texto", Me.texto), _
                  New SqlParameter("@fecha", Me.fecha), _
                  New SqlParameter("@esMaestro", Me.esMaestro)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM BoletinesSalonVirtual WHERE idBoletinSalonVirtual = @idBoletinSalonVirtual"

			Dim parametros As SqlParameter() = {New SqlParameter("@idBoletinSalonVirtual", Me.idBoletinSalonVirtual)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

        Public Overloads Function GetDR(ByVal claveSalon As Integer, Optional ByVal numero As Integer = 0) As System.Data.IDataReader
            Dim queryString As String = "SELECT "
            If numero > 0 Then
                queryString = "SELECT TOP " & numero & " "
            End If

            queryString = queryString & "bsv.*, u.nombre + ' ' + u.apellidos as nombre, u.imagen, eu.claveaux1 FROM BoletinesSalonVirtual bsv, UserProfiles u, EmpresasUserProfiles eu " & _
    "WHERE u.idUserProfile=eu.idUserProfile and bsv.idSalonVirtual = @idSalonVirtual AND u.idUserProfile = bsv.idUserProfile ORDER BY fecha DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveSalon As Integer, Optional ByVal numero As Integer = Nothing) As System.Data.DataSet
			Dim queryString As String = "SELECT "
			If Not IsNothing(numero) Then
				queryString = "SELECT TOP " & numero & " "
			End If

			queryString = queryString & "bsv.*, u.nombre + ' ' + u.apellidos as nombre FROM BoletinesSalonVirtual bsv, UserProfiles u " & _
			 "WHERE bsv.idSalonVirtual = @idSalonVirtual AND u.idUserProfile = bsv.idUserProfile ORDER BY fecha DESC"

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idBoletinSalonVirtual) as num FROM BoletinesSalonVirtual"

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