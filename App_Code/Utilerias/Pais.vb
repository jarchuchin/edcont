Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Utilerias
	Public NotInheritable Class Pais
		Inherits DBObject

#Region "Variables"
		Private idPais As Integer
		Public es As String
		Public en As String
		Public ps As String
		Public fr As String

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idPais
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Pais
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Paises WHERE idPais = @idPais"

			Dim parameters As SqlParameter() = {New SqlParameter("@idPais", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idPais = CType(dr("idPais"), Integer)
				Me.es = CType(dr("es"), String)
				Me.en = CType(dr("en"), String)
				Me.ps = CType(dr("ps"), String)
				Me.fr = CType(dr("fr"), String)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Paises] ([es], [en], [ps], [fr]) VALUES (@es, @en, @ps, @fr)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@es", Me.es), _
				 New SqlParameter("@en", Me.en), _
				 New SqlParameter("@ps", Me.ps), _
				 New SqlParameter("@fr", Me.fr)}

				Me.idPais = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [Paises] SET [es]=@es, [en]=@en, [ps]=@ps, [fr]=@fr WHERE idPais = @idPais"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idPais", Me.idPais), _
				 New SqlParameter("@es", Me.es), _
				 New SqlParameter("@en", Me.en), _
				 New SqlParameter("@ps", Me.ps), _
				 New SqlParameter("@fr", Me.fr)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM Paises WHERE idPais = @idPais"

			Dim parametros As SqlParameter() = {New SqlParameter("@idPais", Me.idPais)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM Paises"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Paises"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idPais) as num FROM Paises"

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