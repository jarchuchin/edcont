Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace MasUsuarios
	Public NotInheritable Class EmpresaUserProfile
		Inherits DBObject

#Region "Variables"
		Private idEmpresaUserProfile As Integer
		Public userProfile As New UserProfile()
		Public empresa As New Empresa
		Public idUserProfile As Integer
		Public idEmpresa As Integer
		Public espacioEnDisco As Integer
		Public status As Boolean
		Public idAux As Integer
		Public claveAux1 As String = String.Empty
		Public claveAux2 As String = String.Empty
		Public defaultSession As Boolean

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idEmpresaUserProfile
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.EmpresaUserProfile
			End Get
		End Property
#End Region


        Public Sub New()
		End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE idEmpresaUserProfile = @idEmpresaUserProfile"

            Dim parameters As SqlParameter() = {New SqlParameter("@idEmpresaUserProfile", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
                Me.userProfile = New MasUsuarios.UserProfile(CType(dr("idUserProfile"), Integer), False)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
                Me.status = CType(dr("status"), Boolean)
                Me.idAux = CInt(dr("idAux"))
                Me.claveAux1 = CType(dr("claveAux1"), String)
                Me.claveAux2 = CType(dr("claveAux2"), String)
                Me.defaultSession = CType(dr("defaultSession"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveUsuario As Integer, solousuario As Boolean)

            Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE  idUserProfile = @idUserProfile "



            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
                '  Me.userProfile = New MasUsuarios.UserProfile(CType(dr("idUserProfile"), Integer), False)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
                Me.status = CType(dr("status"), Boolean)
                Me.idAux = CInt(dr("idAux"))
                Me.claveAux1 = CType(dr("claveAux1"), String)
                Me.claveAux2 = CType(dr("claveAux2"), String)
                Me.defaultSession = CType(dr("defaultSession"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub
        Sub New(ByVal claveUsuario As Integer, ByVal claveEmpresa As Integer, ByVal varfalse As String)

            Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE  idEmpresa = @idEmpresa AND idUserProfile = @idUserProfile "



            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario), New SqlParameter("@idEmpresa", claveEmpresa)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
                '  Me.userProfile = New MasUsuarios.UserProfile(CType(dr("idUserProfile"), Integer), False)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                ' Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
                Me.status = CType(dr("status"), Boolean)
                Me.idAux = CInt(dr("idAux"))
                Me.claveAux1 = CType(dr("claveAux1"), String)
                Me.claveAux2 = CType(dr("claveAux2"), String)
                Me.defaultSession = CType(dr("defaultSession"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

		Sub New(ByVal claveUsuario As Integer, ByVal claveEmpresa As Integer, Optional ByVal usarClaveAux As Boolean = False)
			Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE  idEmpresa = @idEmpresa "

			Dim userSQLParam As SqlParameter
			If usarClaveAux Then
				queryString = queryString & "AND idAux = @idAux"
				userSQLParam = New SqlParameter("@idAux", claveUsuario)
			Else
				queryString = queryString & "AND idUserProfile = @idUserProfile"
				userSQLParam = New SqlParameter("@idUserProfile", claveUsuario)
			End If

			Dim parameters As SqlParameter() = {userSQLParam, New SqlParameter("@idEmpresa", claveEmpresa)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
                Me.userProfile = New MasUsuarios.UserProfile(CType(dr("idUserProfile"), Integer), False)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
				Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
				Me.status = CType(dr("status"), Boolean)
				Me.idAux = CInt(dr("idAux"))
				Me.claveAux1 = CType(dr("claveAux1"), String)
				Me.claveAux2 = CType(dr("claveAux2"), String)
				Me.defaultSession = CType(dr("defaultSession"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()

		End Sub

        Sub New(ByVal claveUsuario As String, ByVal claveEmpresa As Integer, Optional ByVal tipoUsuario As tipoObjeto = tipoObjeto.Alumno)

            If claveUsuario <> "" Then
                Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE "
                Select Case tipoUsuario
                    Case tipoObjeto.Alumno
                        queryString = queryString & "claveAux1 = @claveAux "
                    Case tipoObjeto.Maestro
                        queryString = queryString & "claveAux2 = @claveAux or claveAux1 = @claveAux "
                End Select
                queryString = queryString & "AND idEmpresa = @idEmpresa"

                Dim parameters As SqlParameter() = {New SqlParameter("@claveAux", claveUsuario), New SqlParameter("@idEmpresa", claveEmpresa)}

                Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
                If dr.Read Then
                    Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
                    Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                    Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                    Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
                    Me.status = CType(dr("status"), Boolean)
                    Me.idAux = CInt(dr("idAux"))
                    Me.claveAux1 = CType(dr("claveAux1"), String)
                    Me.claveAux2 = CType(dr("claveAux2"), String)
                    Me.defaultSession = CType(dr("defaultSession"), Boolean)
                    Me.varExiste = True
                End If
                dr.Close()
            End If


        End Sub

		Sub New(ByVal claveUsuario As Integer, ByVal claveSession As Boolean, Optional ByVal usarClaveAux As Boolean = False)
            Dim queryString As String = "SELECT * FROM EmpresasUserProfiles WHERE defaultSession = @defaultSession "

			Dim userSQLParam As SqlParameter
			If usarClaveAux Then
                queryString = queryString & " AND idAux = @idAux"
				userSQLParam = New SqlParameter("@idAux", claveUsuario)
			Else
                queryString = queryString & " AND idUserProfile = @idUserProfile"
				userSQLParam = New SqlParameter("@idUserProfile", claveUsuario)
			End If

			Dim parameters As SqlParameter() = {userSQLParam, New SqlParameter("@defaultSession", claveSession)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idEmpresaUserProfile = CType(dr("idEmpresaUserProfile"), Integer)
				Me.userProfile = New MasUsuarios.UserProfile(CType(dr("idUserProfile"), Integer), False)
				Me.empresa = New MasUsuarios.Empresa(CType(dr("idEmpresa"), Integer))
				Me.espacioEnDisco = CType(dr("espacioEnDisco"), Integer)
				Me.status = CType(dr("status"), Boolean)
				Me.idAux = CInt(dr("idAux"))
				Me.claveAux1 = CType(dr("claveAux1"), String)
				Me.claveAux2 = CType(dr("claveAux2"), String)
				Me.defaultSession = CType(dr("defaultSession"), Boolean)
				Me.varExiste = True
			End If
			dr.Close()

		End Sub



        Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [EmpresasUserProfiles] ([idUserProfile], [idEmpresa], [espacioEnDisco], " & _
             "[status], [idAux], [claveAux1], [claveAux2], [defaultSession]) VALUES (@idUserProfile, @idEmpresa, @espacioEnDisco, " & _
             "@status, @idAux, @claveAux1, @claveAux2, @defaultSession)"

            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idUserProfile", Me.userProfile.id), _
              New SqlParameter("@idEmpresa", Me.empresa.id), _
              New SqlParameter("@espacioEnDisco", Me.espacioEnDisco), _
              New SqlParameter("@status", Me.status), _
              New SqlParameter("@idAux", Me.idAux), _
              New SqlParameter("@claveAux1", Me.claveAux1), _
              New SqlParameter("@claveAux2", Me.claveAux2), _
              New SqlParameter("@defaultSession", Me.defaultSession)}

            Me.idEmpresaUserProfile = Me.ExecuteNonQuery(queryString, parametros, True)

            '	Catch ex As Exception
            ' Dim m As String = ex.Message
            ' End Try

            Return 0
		End Function

		Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [EmpresasUserProfiles] SET [espacioEnDisco]=@espacioEnDisco, [status]=@status, " &
                 "[idAux]=@idAux, [claveAux1]=@claveAux1, [claveAux2]=@claveAux2, [defaultSession]=@defaultSession, idEmpresa=@idEmpresa " &
                 "WHERE idEmpresaUserProfile = @idEmpresaUserProfile"

            Dim parametros As SqlParameter() = {
                  New SqlParameter("@idEmpresaUserProfile", Me.idEmpresaUserProfile),
                  New SqlParameter("@espacioEnDisco", Me.espacioEnDisco),
                  New SqlParameter("@status", Me.status),
                  New SqlParameter("@idAux", Me.idAux),
                  New SqlParameter("@idEmpresa", Me.idEmpresa),
                  New SqlParameter("@claveAux1", Me.claveAux1),
                  New SqlParameter("@claveAux2", Me.claveAux2),
                  New SqlParameter("@defaultSession", Me.defaultSession)}

                Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM EmpresasUserProfiles WHERE idEmpresaUserProfile = @idEmpresaUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresaUserProfile", Me.idEmpresaUserProfile)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM EmpresasUserProfiles"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overloads Function GetDR(ByVal claveUsuario As Integer) As SqlDataReader
            Dim queryString As String = "SELECT eup.*, e.nombre AS nombreEmpresa FROM EmpresasUserProfiles eup, Empresas e " & _
    "WHERE eup.idEmpresa = e.idEmpresa AND eup.idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM EmpresasUserProfiles"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overloads Function GetDS(ByVal claveUsuario As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT eup.*, e.nombre AS nombreEmpresa FROM EmpresasUserProfiles eup, Empresas e " & _
             " WHERE eup.idEmpresa = e.idEmpresa AND eup.idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idEmpresaUserProfile) as num FROM EmpresasUserProfiles"

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


        Public Function GetMaestros() As DataSet
            Dim queryString As String = "SELECT e.*, u.nombre, u.apellidos, u.login, u.apellidos + ' '  + u.nombre + ' (' + e.claveAux2 + ')'  as nombrecompleto FROM EmpresasUserProfiles e, UserProfiles u " & _
            " WHERE e.idUserProfile = u.idUserProfile AND e.claveAux2 <> '' ORDER BY u.apellidos, u.nombre"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

		Public Function GetMaestros(ByVal buscar As String) As DataSet
            Dim queryString As String = "SELECT e.*, u.nombre, u.apellidos, u.login as nombreEmpresa FROM EmpresasUserProfiles e, UserProfiles u " & _
            " WHERE e.idUserProfile = u.idUserProfile AND e.claveAux2 <> '' AND (e.claveAux2 like '%" & buscar & "%' OR u.nombre like '%" & buscar & "%' " & _
            " OR u.apellidos like '%" & buscar & "%') ORDER BY u.apellidos"

			Return Me.ExecuteDataSet(queryString, Nothing)
        End Function



		Public Function GetAlumnos(ByVal buscar As String) As DataSet
            Dim queryString As String = "SELECT e.*, u.nombre, u.apellidos, u.login as nombreempresa FROM EmpresasUserProfiles e, UserProfiles u " & _
            " WHERE e.idUserProfile = u.idUserProfile and e.claveAux1 <> '' and (e.claveAux1 like '%" & buscar & "%' OR u.nombre like '%" & buscar & "%' " & _
            " OR u.apellidos like '%" & buscar & "%') ORDER BY u.apellidos"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Function GetEspacio(ByVal claveUsuario As Integer) As Integer
			Dim queryString As String = "SELECT SUM(espacioEnDisco) as num FROM EmpresasUserProfiles WHERE idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

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

		Function UpdateStatusTo0(ByVal claveUserProfile As Integer, ByVal claveEmpresa As Integer) As Integer
            Dim queryString As String = "UPDATE EmpresasUserProfiles SET defaultSession=0 WHERE idUserProfile = @idUserProfile"

			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUserProfile)}

			Dim rowsAffected As Integer = Me.ExecuteNonQuery(queryString, parametros)

			'*************************************************
			'asigna true al status del registro seleccionado
			'*************************************************
			Dim myEmpresaUserProfile As New EmpresaUserProfile(claveUserProfile, claveEmpresa)
			myEmpresaUserProfile.defaultSession = True
			myEmpresaUserProfile.Update()

			Return rowsAffected
		End Function

		'++++++++REVISAR++++++++++++ ¿Incompleto?
		Function GetEmpresasSession(ByVal claveUsuario As Integer) As ICollection
			Dim dTable As New DataTable

			dTable.Columns.Add(New DataColumn("tipo", GetType(Integer)))
			dTable.Columns.Add(New DataColumn("actividad", GetType(String)))
			dTable.Columns.Add(New DataColumn("tieneValor", GetType(Boolean)))

			Return Nothing
		End Function

		Public Function GetUsersEmpresa(ByVal claveEmpresa As Integer) As DataSet
			Dim queryString As String = "SELECT * FROM vEmpresasUserProfile WHERE idEmpresa = @idEmpresa ORDER BY apellidos, nombre"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

    End Class
End Namespace