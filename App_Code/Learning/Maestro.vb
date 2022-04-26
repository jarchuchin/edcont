Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Learning
	Public NotInheritable Class Maestro
		Inherits DBObject

#Region "Variables"
		Private idMaestro As Integer
		Public idEmpresa As Integer
		Public clave As String
		Public login As String
		Public nombre As String
		Public apellidos As String
		Public fechaNac As String
		Public sexo As String
		Public grabado As Boolean
		Public maestrosGrabados As Integer
		Public cursosGrabados As Integer

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idMaestro
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Maestro
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Maestros WHERE idMaestro = @idMaestro"

			Dim parameters As SqlParameter() = {New SqlParameter("@idMaestro", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idMaestro = CType(dr("idMaestro"), Integer)
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.clave = CType(dr("clave"), String)
				Me.login = CType(dr("login"), String)
				Me.nombre = CType(dr("nombre"), String)
				Me.apellidos = CType(dr("apellidos"), String)
				Me.fechaNac = CType(dr("fechaNac"), String)
				Me.sexo = CType(dr("sexo"), String)
				Me.grabado = CType(dr("grabado"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveCadena As String)
			Dim queryString As String = "SELECT * FROM Maestros WHERE clave = @clave"

			Dim parameters As SqlParameter() = {New SqlParameter("@clave", claveCadena)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idMaestro = CType(dr("idMaestro"), Integer)
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.clave = CType(dr("clave"), String)
				Me.login = CType(dr("login"), String)
				Me.nombre = CType(dr("nombre"), String)
				Me.apellidos = CType(dr("apellidos"), String)
				Me.fechaNac = CType(dr("fechaNac"), String)
				Me.sexo = CType(dr("sexo"), String)
				Me.grabado = CType(dr("grabado"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Maestros] ([idEmpresa], [clave], [login], [nombre], [apellidos], [fechaNac], " & _
				 "[sexo], [grabado]) VALUES (@idEmpresa, @clave, @login, @nombre, @apellidos, @fechaNac, @sexo, @grabado)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idEmpresa", Me.idEmpresa), _
				  New SqlParameter("@clave", Me.clave), _
				  New SqlParameter("@login", Me.login), _
				  New SqlParameter("@nombre", Me.nombre), _
				  New SqlParameter("@apellidos", Me.apellidos), _
				  New SqlParameter("@fechaNac", Me.fechaNac), _
				  New SqlParameter("@sexo", Me.sexo), _
				  New SqlParameter("@grabado", Me.grabado)}

				Me.idMaestro = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [Maestros] SET [grabado]=@grabado WHERE idMaestro = @idMaestro OR clave = @clave"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idMaestro", Me.idMaestro), _
				 New SqlParameter("@clave", Me.clave), _
				 New SqlParameter("@grabado", Me.grabado)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Return 0
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM Maestros ORDER BY apellidos, nombre"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overloads Function GetDR(ByVal claveEmpresa As Integer) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM Maestros WHERE idEmpresa = @idEmpresa ORDER BY apellidos, nombre"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Function GetDR(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM Maestros WHERE idEmpresa = @idEmpresa AND grabado = @grabado " & _
			 "ORDER BY apellidos, nombre"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Maestros ORDER BY apellidos, nombre"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveEmpresa As Integer) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Maestros WHERE idEmpresa = @idEmpresa ORDER BY apellidos, nombre"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveEmpresa As Integer, ByVal claveGrabado As Boolean) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Maestros WHERE idEmpresa = @idEmpresa AND grabado = @grabado " & _
			 "ORDER BY apellidos, nombre"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function

		Public Sub GrabarMaestros(ByVal claveEmpresa As Integer)
			Dim myEmpresa As New MasUsuarios.Empresa(claveEmpresa)
			Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveEmpresa, False)

			Do While dr.Read
				maestrosGrabados = maestrosGrabados + 1

				Dim myEU As New MasUsuarios.EmpresaUserProfile(CType(dr("clave"), String), claveEmpresa, tipoObjeto.Maestro)
				If Not myEU.existe Then
					' inscribir  maestro y crear cuenta user Profile
					Dim myUser As New MasUsuarios.UserProfile
					myUser.nombre = CType(dr("nombre"), String)
					myUser.apellidos = CType(dr("apellidos"), String)
					myUser.fechaNacimiento = CType(dr("fechaNac"), Date)
					myUser.fecharegistro = Date.Now
					myUser.sexo = CType(dr("sexo"), String)
					myUser.pais = 161
					myUser.password = CType(dr("login"), String)
					myUser.ciudad = String.Empty
					myUser.estado = String.Empty
					myUser.webpage = String.Empty
					myUser.login = CType(dr("clave"), String)
					myUser.idAux = CInt(dr("idMaestro"))
					myUser.claveAux2 = CType(dr("clave"), String)
					myUser.datosPublicos = "111111111111"
					myUser.caja = Integer.Parse(ConfigurationManager.AppSettings("CajaDefault"))
					myUser.idioma = ConfigurationManager.AppSettings("IdiomaDefault")
					myUser.estilo = Integer.Parse(ConfigurationManager.AppSettings("EstiloDefault"))
					myUser.telefono = ""
					myUser.direccion = ""
					myUser.email = ""
					myUser.empresa = myEmpresa
					myUser.Add()
				End If

				Dim mymaestro As New Learning.Maestro(CType(dr("ID"), String))
				mymaestro.grabado = True
				mymaestro.Update()
			Loop
			dr.Close()

			cursosGrabados = GrabarCursos(myEmpresa.id)
		End Sub

		Private Function GrabarCursos(ByVal claveEmpresa As Integer) As Integer
			Return New Learning.Curso().GrabarCursos(claveEmpresa)
		End Function
#End Region

	End Class
End Namespace

