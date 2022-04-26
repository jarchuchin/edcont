Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Lego
	Public NotInheritable Class RootEmpresa
		Inherits DBObject

#Region "Variables"
		Private idRootEmpresa As Integer
		Public root As Root
		Public empresa As MasUsuarios.Empresa
		Public idRoot As Integer
		Public idEmpresa As Integer

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idRootEmpresa
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.RootEmpresa
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer, ByVal crearSubObjetos As Boolean)
			Dim queryString As String = "SELECT * FROM RootsEmpresas WHERE idRootEmpresa = @idRootEmpresa"

			Dim parameters As SqlParameter() = {New SqlParameter("@idRootEmpresa", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idRootEmpresa = CType(dr("idRootEmpresa"), Integer)
				If crearSubObjetos Then
					Me.root = New Lego.Root(CType(dr("idRoot"), Integer))
					Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
				End If
				Me.idRoot = CType(dr("idRoot"), Integer)
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveRoot As Integer, ByVal claveEmpresa As Integer, ByVal crearSubObjetos As Boolean)
			Dim queryString As String = "SELECT * FROM RootsEmpresas WHERE idRoot = @idRoot AND idEmpresa = @idEmpresa"

			Dim parameters As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idEmpresa", claveEmpresa)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idRootEmpresa = CType(dr("idRootEmpresa"), Integer)
				If crearSubObjetos Then
					Me.root = New Lego.Root(CType(dr("idRoot"), Integer))
					Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
				End If
				Me.idRoot = CType(dr("idRoot"), Integer)
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [RootsEmpresas] ([idRoot], [idEmpresa]) VALUES (@idRoot, @idEmpresa)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idRoot", Me.idRoot), _
				  New SqlParameter("@idEmpresa", Me.idEmpresa)}

            If Not New RootEmpresa(Me.idRoot, Me.idEmpresa).existe Then
                Me.idRootEmpresa = Me.ExecuteNonQuery(queryString, parametros, True)
            End If


            Return 0
		End Function

		Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [RootsEmpresas] SET [idRoot]=@idRoot, [idEmpresa]=@idEmpresa WHERE idRootEmpresa = @idRootEmpresa"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idRootEmpresa", Me.idRootEmpresa), _
				  New SqlParameter("@idRoot", Me.idRoot), _
				  New SqlParameter("@idEmpresa", Me.idEmpresa)}

				Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM RootsEmpresas WHERE idRootEmpresa = @idRootEmpresa"

			Dim parametros As SqlParameter() = {New SqlParameter("@idRootEmpresa", Me.idRootEmpresa)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM RootsEmpresas"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overloads Function GetDR(ByVal objEmpresa As MasUsuarios.Empresa) As System.Data.IDataReader
			Dim queryString As String = "SELECT re.*, e.nombre AS nombreEmpresa, r.titulo AS titulo FROM RootsEmpresas re, Empresa e, Root r " & _
			 "WHERE re.idEmpresa = @idEmpresa AND re.idEmpresa = e.idEmpresa AND r.idRoot = re.idRoot"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", objEmpresa.id)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM RootsEmpresas"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal objEmpresa As MasUsuarios.Empresa) As System.Data.DataSet
			Dim queryString As String = "SELECT re.*, e.nombre AS nombreEmpresa, r.titulo AS titulo FROM RootsEmpresas re, Empresa e, Root r " & _
			 "WHERE re.idEmpresa = @idEmpresa AND re.idEmpresa = e.idEmpresa AND r.idRoot = re.idRoot"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", objEmpresa.id)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function
#End Region
	End Class
End Namespace