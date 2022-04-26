Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public MustInherit Class DBObject

#Region "Declaración de variables"
	Private connection As SqlConnection
#End Region

#Region "Constructores"
	Public Sub New()
	End Sub
#End Region

#Region "Métodos y propiedades públicos que deben implementarse para tener la funcionalidad de esta clase"
	Public MustOverride ReadOnly Property id() As Integer
	Public MustOverride ReadOnly Property tipo() As tipoObjeto
	Public MustOverride ReadOnly Property existe() As Boolean

	Public MustOverride Function Add() As Integer
	Public MustOverride Function Update() As Integer
	Public MustOverride Function Remove() As Integer
	Public MustOverride Function GetDR() As SqlClient.SqlDataReader
	Public MustOverride Function GetDS() As DataSet
	Public MustOverride Function Count() As Integer
	Public MustOverride Function EnUso() As Boolean
#End Region

#Region "Metodos de clase dbobject"
	Private Sub OpenConnection()
        '		Dim conString As String = ConfigurationManager.AppSettings("connectionString")

        connection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
		connection.Open()
	End Sub

	Protected Sub CloseConnection()
		connection.Close()
		connection.Dispose()
	End Sub

	Protected Function ExecuteScalar(ByVal mysql As String, ByVal myParameters() As IDataParameter) As Object
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myParameters)


		Try
			Return command.ExecuteScalar()
		Finally
			command.Dispose()
			Me.CloseConnection()
		End Try

		Return Nothing
	End Function

	Protected Function ExecuteReader(ByVal mysql As String, ByVal myparameters() As IDataParameter) As SqlDataReader
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		Return command.ExecuteReader(CommandBehavior.CloseConnection)
	End Function

	Protected Function ExecuteDataSet(ByVal mysql As String, ByVal myparameters() As IDataParameter) As DataSet
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		Dim ds As DataSet = New DataSet
		Dim myda As SqlDataAdapter = New SqlDataAdapter(command)
		myda.Fill(ds)
		command.Dispose()
		Me.CloseConnection()

		Return ds
	End Function

	Protected Function ExecuteNonQuery(ByVal mysql As String, ByVal myparameters() As IDataParameter, _
  Optional ByVal returnLastID As Boolean = False) As Integer

		Dim resultado As Integer

		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		resultado = command.ExecuteNonQuery()

		If returnLastID Then
			command = New SqlCommand("SELECT @@IDENTITY as lastId", Me.connection)
			Dim dr As SqlDataReader = command.ExecuteReader()
			dr.Read()
			If Not Convert.IsDBNull(dr("lastId")) Then
				resultado = CType(dr("lastId"), Integer)
			End If
			dr.Close()
		End If

		command.Dispose()
		Me.CloseConnection()

		Return resultado
	End Function

	Private Function BuildQueryCommand(ByVal mysql As String, ByVal myParameters() As IDataParameter) As SqlCommand
		Dim command As SqlCommand = New SqlCommand(mysql, Me.connection)
		command.CommandType = CommandType.Text
        ' command.CommandTimeout = 0

		If Not IsNothing(myParameters) Then
			For Each myp As SqlParameter In myParameters
				If Not IsNothing(myp) Then command.Parameters.Add(myp)
			Next
		End If

		Return command
	End Function
#End Region
End Class


Public MustInherit Class DBObjectLight

#Region "Declaración de variables"
	Private connection As SqlConnection
#End Region

#Region "Constructores"
	Public Sub New()
	End Sub
#End Region

	Private Sub OpenConnection()
        connection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
		connection.Open()
	End Sub

	Protected Sub CloseConnection()
		connection.Close()
		connection.Dispose()
	End Sub

	Protected Function ExecuteScalar(ByVal mysql As String, ByVal myParameters() As IDataParameter) As Object
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myParameters)

		Try
			Return command.ExecuteScalar()
		Finally
			command.Dispose()
			Me.CloseConnection()
		End Try

		Return Nothing
	End Function

	Protected Function ExecuteReader(ByVal mysql As String, ByVal myparameters() As IDataParameter) As SqlDataReader
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		Return command.ExecuteReader(CommandBehavior.CloseConnection)
	End Function

	Protected Function ExecuteDataSet(ByVal mysql As String, ByVal myparameters() As IDataParameter) As DataSet
		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		Dim ds As DataSet = New DataSet
		Dim myda As SqlDataAdapter = New SqlDataAdapter(command)
		myda.Fill(ds)
		command.Dispose()
		Me.CloseConnection()

		Return ds
	End Function

	Protected Function ExecuteNonQuery(ByVal mysql As String, ByVal myparameters() As IDataParameter, _
	 Optional ByVal returnLastID As Boolean = False) As Integer

		Dim resultado As Integer

		Me.OpenConnection()
		Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

		resultado = command.ExecuteNonQuery()

		If returnLastID Then
			command = New SqlCommand("SELECT @@IDENTITY as lastId", Me.connection)
			Dim dr As SqlDataReader = command.ExecuteReader()
			dr.Read()
			If Not Convert.IsDBNull(dr("lastId")) Then
				resultado = CType(dr("lastId"), Integer)
			End If
			dr.Close()
		End If

		command.Dispose()
		Me.CloseConnection()

		Return resultado
	End Function

	Private Function BuildQueryCommand(ByVal mysql As String, ByVal myParameters() As IDataParameter) As SqlCommand
		Dim command As SqlCommand = New SqlCommand(mysql, Me.connection)
		command.CommandType = CommandType.Text

		If Not IsNothing(myParameters) Then
			For Each myp As SqlParameter In myParameters
				command.Parameters.Add(myp)
			Next
		End If

		Return command
	End Function
End Class