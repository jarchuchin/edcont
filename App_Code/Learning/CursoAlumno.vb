Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Learning
	Public NotInheritable Class CursoAlumno
		Inherits DBObject

#Region "Variables"
		Private idCursoAlumno As Integer
		Public idAlumno As Integer
		Public claveAlumno As String
		Public claveCurso As String
		Public grabado As Boolean

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idCursoAlumno
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.CursoAlumno
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE idCursoAlumno = @idCursoAlumno"

			Dim parameters As SqlParameter() = {New SqlParameter("@idCursoAlumno", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idCursoAlumno = clavePrincipal
				Me.idAlumno = CInt(dr("idAlumno"))
				Me.claveAlumno = CType(dr("claveAlumno"), String)
				Me.claveCurso = CType(dr("claveCurso"), String)
				Me.grabado = CType(dr("grabado"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [CursosAlumnos] ([idAlumno], [claveAlumno], [claveCurso], [grabado]) " & _
				 "VALUES (@idAlumno, @claveAlumno, @claveCurso, @grabado)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idAlumno", Me.idAlumno), _
				  New SqlParameter("@claveAlumno", Me.claveAlumno), _
				  New SqlParameter("@claveCurso", Me.claveCurso), _
				  New SqlParameter("@grabado", Me.grabado)}

				Me.idCursoAlumno = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [CursosAlumnos] SET [grabado]=@grabado WHERE idCursoAlumno = @idCursoAlumno)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idCursoAlumno", Me.idCursoAlumno), _
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
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal varidAlumno As Integer, ByVal varClaveAlumno As String) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE idAlumno = @idAlumno OR claveAlumno = @claveAlumno"

			Dim parametros As SqlParameter() = {New SqlParameter("@idAlumno", varidAlumno), New SqlParameter("@claveAlumno", varClaveAlumno)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Function GetDR(ByVal varidAlumno As Integer, ByVal varClaveAlumno As String, ByVal claveGrabado As Boolean) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE (idAlumno = @idAlumno OR claveAlumno = @claveAlumno) AND grabado = @grabado"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idAlumno", varidAlumno), _
			 New SqlParameter("@claveAlumno", varClaveAlumno), _
			 New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Function GetDR(ByVal claveGrabado As Boolean) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE grabado = @grabado"

			Dim parametros As SqlParameter() = {New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal varidAlumno As Integer, ByVal varClaveAlumno As String) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE idAlumno = @idAlumno OR claveAlumno = @claveAlumno"

			Dim parametros As SqlParameter() = {New SqlParameter("@idAlumno", varidAlumno), New SqlParameter("@claveAlumno", varClaveAlumno)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal varidAlumno As Integer, ByVal varClaveAlumno As String, ByVal claveGrabado As Boolean) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE (idAlumno = @idAlumno OR claveAlumno = @claveAlumno) AND grabado = @grabado"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idAlumno", varidAlumno), _
			 New SqlParameter("@claveAlumno", varClaveAlumno), _
			 New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveGrabado As Boolean) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE grabado = @grabado"

			Dim parametros As SqlParameter() = {New SqlParameter("@grabado", claveGrabado)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overloads Overrides Function EnUso() As Boolean
			Return True
		End Function

		Public Overloads Function EnUso(ByVal varClaveAlumno As String, ByVal varClaveCurso As String) As Boolean
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE claveAlumno = @claveAlumno AND claveCurso = @claveCurso"

			Dim parametros As SqlParameter() = {New SqlParameter("@claveAlumno", varClaveAlumno), New SqlParameter("@claveCurso", varClaveCurso)}

			Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
			Dim bandera As Boolean = False
			If dr.Read Then
				bandera = True
			End If
			dr.Close()

			Return bandera
		End Function

		'+++++++DEPRECATED: utilizar enUso() ++++++++++++++++++++
		Public Function ExisteRegistro(ByVal varClaveAlumno As String, ByVal varClaveCurso As String) As Boolean
			Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE claveAlumno = @claveAlumno AND claveCurso = @claveCurso"

			Dim parametros As SqlParameter() = {New SqlParameter("@claveAlumno", varClaveAlumno), New SqlParameter("@claveCurso", varClaveCurso)}

			Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

			Dim bandera As Boolean = False
			If dr.Read Then
				bandera = True
			End If
			dr.Close()

			Return bandera
		End Function
#End Region

	End Class
End Namespace

