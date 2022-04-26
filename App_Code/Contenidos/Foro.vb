Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class Foro
		Inherits DBObject


        Private idForo As Integer
		Public titulo As String
		Public texto As String
		Public fechaCreacion As Date
        Public autor As Integer

        Public idUserProfile As Integer = 0
        Public Objetivo As String = String.Empty


		Private varExiste As Boolean = False





        Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idForo
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Foro
			End Get
		End Property



        Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT [Foros].* FROM [Foros] WHERE ([Foros].[idForo] = @idForo)"

			Dim parameters As SqlParameter() = {New SqlParameter("@idForo", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idForo = CType(dr("idForo"), Integer)
				Me.titulo = CType(dr("titulo"), String)
				Me.texto = CType(dr("texto"), String)
				Me.fechaCreacion = CType(dr("fechaCreacion"), Date)
                Me.autor = CType(dr("autor"), Integer)

                If Not Convert.IsDBNull(dr("idUserProfile")) Then
                    Me.idUserProfile = CInt(dr("idUserProfile"))
                End If

                If Not Convert.IsDBNull(dr("Objetivo")) Then
                    Me.Objetivo = dr("Objetivo")
                End If

				Me.varExiste = True
			End If
			dr.Close()
		End Sub



        Public Overrides Function Add() As Integer
			Try
                Dim queryString As String = "INSERT INTO [Foros] ([titulo], [texto], [fechaCreacion], [autor], idUserProfile, Objetivo) VALUES (@titulo, @texto, @fechaCreacion, @Autor, @idUserProfile, @Objetivo)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@titulo", Me.titulo), _
                  New SqlParameter("@texto", Me.texto), _
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion), _
                  New SqlParameter("@autor", Me.autor), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@Objetivo", Me.Objetivo)}

				Me.idForo = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
                Dim queryString As String = "UPDATE [Foros] SET [titulo]=@titulo, [texto]=@texto, " & _
                 "[fechaCreacion]=@fechaCreacion, [Autor]=@Autor, idUserProfile=@idUserProfile, Objetivo=@Objetivo WHERE ([Foros].[idForo] = @idForo)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idForo", Me.idForo), _
                 New SqlParameter("@titulo", Me.titulo), _
                  New SqlParameter("@texto", Me.texto), _
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion), _
                  New SqlParameter("@autor", Me.autor), _
                              New SqlParameter("@idUserProfile", Me.idUserProfile), _
                              New SqlParameter("@Objetivo", Me.Objetivo)}


				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM [Foros] WHERE ([Foros].[idForo] = @idForo)"

			Dim parametros As SqlParameter() = {New SqlParameter("@idForo", Me.idForo)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function


        Public Overloads Function GetDR(ByVal claveRoot As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT f.idForo, f.titulo, f.objetivo,  f.texto, f.fechaCreacion, ci.idRoot, ci.idClasificacion, " & _
             "FROM ClasificacionesItems ci, Foros f WHERE f.idForo = ci.idProc AND ci.Procedencia = 'Foro' " & _
             "AND ci.idRoot = @idRoot ORDER BY f.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function
        Public Overloads Function GetDR(ByVal claveRoot As Integer, ByVal claveSalon As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT f.idForo, f.titulo, f.objetivo, f.texto, f.fechaCreacion, ci.idRoot, ci.idClasificacion, ci.idClasificacionItem, " &
                     " (select count(fs.idForoSalonVirtual) from  ForosSalonVirtual fs where fs.idForo=f.idForo and  fs.idSalonVirtual=@idSalonVirtual) as comentarios" &
             " FROM ClasificacionesItems ci, Foros f WHERE f.idForo = ci.idProc AND ci.Procedencia = 'Foro' " &
             " AND ci.idRoot = @idRoot ORDER BY f.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overloads Function GetDR(ByVal claveRoot As Integer, ByVal claveSalon As Integer, claveClasificacion As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT f.idForo, f.titulo, f.objetivo, f.texto, f.fechaCreacion, ci.idRoot, ci.idClasificacion, ci.idClasificacionItem, " &
                     " (select count(fs.idForoSalonVirtual) from  ForosSalonVirtual fs where fs.idForo=f.idForo and  fs.idSalonVirtual=@idSalonVirtual) as comentarios" &
             " FROM ClasificacionesItems ci, Foros f WHERE f.idForo = ci.idProc AND ci.Procedencia = 'Foro' " &
             " AND ci.idRoot = @idRoot and ci.idClasificacion=@idClasificacion ORDER BY f.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idClasificacion", claveClasificacion)}

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

		Public Function GetForosNoEnAgenda(ByVal claveSalon As Integer, ByVal claveRoot As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT f.idForo, f.titulo, f.objetivo,   ci.idRoot, ci.idClasificacion FROM ClasificacionesItems ci, Foros f " & _
    "WHERE f.idForo = ci.idProc AND ci.Procedencia = 'Foro' AND ci.idRoot = @idRoot AND f.idForo " & _
    "NOT IN (SELECT ag.idProc FROM Agenda ag WHERE idSalonVirtual = @idSalonVirtual AND Procedencia = 'Foro') ORDER BY f.titulo"

			Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idRoot", claveRoot)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function



    End Class
End Namespace
