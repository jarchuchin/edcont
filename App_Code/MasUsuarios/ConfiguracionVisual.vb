Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

'++++++++REVISAR++++++++++++

Namespace MasUsuarios
	Public NotInheritable Class ConfiguracionVisual
		Inherits DBObject

#Region "Variables"
		Private idConfiguracionVisual As Integer
        Public idCajaUniversal As Integer = 0
        Public idCssEstilo As Integer = 0
        Public idUserProfile As Integer
        Public idioma As String = String.Empty
		Public nombre As String = String.Empty

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idConfiguracionVisual
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.ConfiguracionVisual
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM ConfiguracionesVisuales WHERE idConfiguracionVisual = @idConfiguracionVisual"

			Dim parameters As SqlParameter() = {New SqlParameter("@idConfiguracionVisual", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
                Me.idConfiguracionVisual = CType(dr("idconfiguracionvisual"), Integer)
                ' Me.idCajaUniversal = CType(dr("idCajaUniversal"), Integer)
                ' Me.idCssEstilo = CType(dr("idCssEstilo"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.idioma = CType(dr("idioma"), String)
				Me.nombre = CType(dr("nombre"), String)
				Me.varExiste = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [ConfiguracionesVisuales] ([idCajaUniversal], [idCssEstilo], [idUserProfile], " & _
             "[idioma], [nombre]) VALUES (@idCajaUniversal, @idCssEstilo, @idUserProfile, @idioma, @nombre)"

            Dim parametros As SqlParameter() = { _
New SqlParameter("@idCajaUniversal", Me.idCajaUniversal), _
New SqlParameter("@idCssEstilo", Me.idCssEstilo), _
              New SqlParameter("@idUserProfile", Me.idUserProfile), _
              New SqlParameter("@idioma", Me.idioma), _
              New SqlParameter("@nombre", Me.nombre)}


            Me.idConfiguracionVisual = Me.ExecuteNonQuery(queryString, parametros, True)

            '	Catch ex As Exception
            'Dim m As String = ex.Message
            '  End Try

            Return 0
		End Function

		Public Overrides Function Update() As Integer
            '	Try
            Dim queryString As String = "UPDATE [ConfiguracionesVisuales] SET [idCajaUniversal]=@idCajaUniversal, " & _
             "[idCssEstilo]=@idCssEstilo, [idUserProfile]=@idUserProfile, [idioma]=@idioma , [nombre]=@nombre " & _
             "WHEREidConfiguracionVisual = @idConfiguracionVisual"


            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idConfiguracionVisual", Me.idConfiguracionVisual), _
            New SqlParameter("@idCajaUniversal", Me.idCajaUniversal), _
            New SqlParameter("@idCssEstilo", Me.idCssEstilo), _
           New SqlParameter("@idUserProfile", Me.idUserProfile), _
           New SqlParameter("@idioma", Me.idioma), _
           New SqlParameter("@nombre", Me.nombre)}

            Return Me.ExecuteNonQuery(queryString, parametros)

            'Catch ex As Exception
            'Return 0
            'End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM ConfiguracionesVisuales WHERE idConfiguracionVisual = @idConfiguracionVisual"

			Dim parametros As SqlParameter() = {New SqlParameter("@idConfiguracionVisual", Me.idConfiguracionVisual)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM ConfiguracionesVisuales"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overloads Function GetDR(ByVal claveUsuario As Integer) As SqlDataReader
			Dim queryString As String = "SELECT * FROM ConfiguracionesVisuales WHERE idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM ConfiguracionesVisuales"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveUsuario As Integer) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM ConfiguracionesVisuales WHERE idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idConfiguracionVisual) as num FROM ConfiguracionesVisuales"

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
			Return Integer.Parse(ConfigurationManager.AppSettings("CajaDefault")) = Me.idConfiguracionVisual
		End Function

		'++++++++++DEPRECATED: Utilizar EnUso() ++++++++++++
		Public Function SePuedeBorrar(ByVal claveUsuario As Integer) As Boolean
			Dim bandera As Boolean = True
			Dim myUser As New MasUsuarios.UserProfile(claveUsuario, True)
			If myUser.configuracionVisual.idConfiguracionVisual = Me.idConfiguracionVisual Then
				bandera = False
			End If

			Return bandera
		End Function
#End Region
	End Class
End Namespace