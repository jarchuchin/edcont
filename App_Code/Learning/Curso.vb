Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Learning
	Public NotInheritable Class Curso
		Inherits DBObject

#Region "Variables"
		Private idCurso As Integer
		Public idEmpresa As Integer
		Public clave As String
		Public claveAux As String
		Public nombre As String
		Public fechaInicio As String
		Public fechaFin As String
		Public horaAtencion As String
		Public grabado As Boolean

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idCurso
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Curso
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Cursos WHERE idCurso = @idCurso"

			Dim parameters As SqlParameter() = {New SqlParameter("@idCurso", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idCurso = CInt(dr("idCurso"))
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.clave = CType(dr("clave"), String)
				Me.claveAux = CType(dr("claveAux"), String)
				Me.nombre = CType(dr("nombre"), String)
				Me.fechaInicio = CType(dr("fechaInicio"), String)
				Me.fechaFin = CType(dr("fechaFin"), String)
				Me.horaAtencion = CType(dr("horaAtencion"), String)
				Me.grabado = CType(dr("grabado"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveCadena As String)
			Dim queryString As String = "SELECT * FROM Cursos WHERE clave = @clave"

			Dim parameters As SqlParameter() = {New SqlParameter("@clave", claveCadena)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idCurso = CInt(dr("idCurso"))
				Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.clave = CType(dr("clave"), String)
				Me.claveAux = CType(dr("claveAux"), String)
				Me.nombre = CType(dr("nombre"), String)
				Me.fechaInicio = CType(dr("fechaInicio"), String)
				Me.fechaFin = CType(dr("fechaFin"), String)
				Me.horaAtencion = CType(dr("horaAtencion"), String)
				Me.grabado = CType(dr("grabado"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Cursos] ([idEmpresa], [clave], [claveAux], [nombre], [fechaInicio], " & _
				 "[fechaFin], [horaAtencion], [grabado]) VALUES (@idEmpresa, @clave, @claveAux, @nombre, @fechaInicio, " & _
				 "@fechaFin, @horaAtencion, @grabado)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idEmpresa", Me.idEmpresa), _
				  New SqlParameter("@claveAux", Me.claveAux), _
				  New SqlParameter("@clave", Me.clave), _
				  New SqlParameter("@nombre", Me.nombre), _
				  New SqlParameter("@fechaInicio", Me.fechaInicio), _
				  New SqlParameter("@fechaFin", Me.fechaFin), _
				  New SqlParameter("@horaAtencion", Me.horaAtencion), _
				  New SqlParameter("@grabado", Me.grabado)}

				Me.idCurso = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [Cursos] SET [grabado]=@grabado WHERE idCurso = @idCurso OR clave = @clave"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idCurso", Me.idCurso), _
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
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal claveEmpresa As Integer, ByVal claveStatus As Boolean) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM Cursos WHERE idEmpresa = @idEmpresa AND grabado = @grabado"

			Dim parametros As SqlParameter() = {New SqlParameter("@grabado", claveEmpresa), New SqlParameter("@grabado", claveStatus)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function

		Public Function GrabarCursos(ByVal claveEmpresa As Integer, Optional ByVal usarClaveCadena As Boolean = True) As Integer
			Dim numero As Integer = 0
			Dim mySalon As Know.SalonVirtual
			Dim myUserEmpresa As MasUsuarios.EmpresaUserProfile

			Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveEmpresa, False)
			Do While dr.Read
				mySalon = New Know.SalonVirtual
				myUserEmpresa = New MasUsuarios.EmpresaUserProfile(CStr(dr("claveAux")), claveEmpresa, tipoObjeto.Maestro)

				If myUserEmpresa.existe Then
					mySalon.idRoot = 0
					mySalon.nombre = CStr(dr("nombre"))
					mySalon.fechaInicio = Convert.ToDateTime(dr("fechaInicio"))
					mySalon.fechaFin = Convert.ToDateTime(dr("fechaFin"))
					mySalon.horarioAtencion = Convert.ToString(dr("horaAtencion"))
					mySalon.calificacionMaxima = 100
					mySalon.status = True
					mySalon.claveAux1 = Convert.ToString(dr("clave"))
					mySalon.claveAux2 = ""
					mySalon.idUserProfile = myUserEmpresa.idUserProfile
					mySalon.idEmpresa = claveEmpresa

					mySalon.Add()
					numero = numero + 1

					Servicios.GrabarEvaluacion(mySalon, mySalon.claveAux1)

					Dim myCurso As Curso
					If usarClaveCadena Then
						myCurso = New Curso(CStr(dr("clave")))
					Else
						myCurso = New Curso(CInt(dr("idCurso")))
					End If
					myCurso.grabado = True
					myCurso.Update()
				End If
			Loop
			dr.Close()

			Return numero
		End Function
#End Region

	End Class
End Namespace

