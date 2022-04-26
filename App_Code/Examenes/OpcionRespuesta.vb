Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Examenes
	Public NotInheritable Class OpcionRespuesta
		Inherits DBObject

#Region "Variables"
		Private idOR As Integer
		Public idPregunta As Integer
		Public enunciado As String
		Public archivo As Integer
        Public fileName As String = ""

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idOR
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.OpcionRespuesta
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Public Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM OpcionesRespuesta WHERE idOR = @idOR"

			Dim parameters As SqlParameter() = {New SqlParameter("@idOR", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idOR = CType(dr("idOR"), Integer)
				Me.idPregunta = CType(dr("idPregunta"), Integer)
				Me.enunciado = CType(dr("enunciado"), String)
                Me.archivo = CType(dr("archivo"), Integer)

                If Not Convert.IsDBNull(dr("fileName")) Then
                    Me.fileName = dr("fileName")
                Else
                    Me.fileName = ""
                End If

				Me.varExiste = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
                Dim queryString As String = "INSERT INTO [OpcionesRespuesta] ([idPregunta], [enunciado], [archivo], fileName) " & _
                "VALUES (@idPregunta, @enunciado, @archivo, @fileName)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idPregunta", Me.idPregunta), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                              New SqlParameter("@fileName", Me.fileName)}

				Me.idOR = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
                Dim queryString As String = "UPDATE [OpcionesRespuesta] SET [enunciado]=@enunciado, [archivo]=@archivo, fileName=@fileName " & _
     "WHERE idOR = @idOR"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idOR", Me.idOR), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                              New SqlParameter("@fileName", Me.fileName)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overloads Overrides Function Remove() As Integer
			Try
				Dim queryString As String = "DELETE FROM [OpcionesRespuesta] WHERE ([OpcionesRespuesta].[idOR] = @idOR)"

				Dim parametros As SqlParameter() = {New SqlParameter("@idOR", Me.idOR)}

				Return Me.ExecuteNonQuery(queryString, parametros)
			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overloads Function Remove(ByVal clavePregunta As Integer) As Integer
			Try
				Dim queryString As String = "DELETE FROM [OpcionesRespuesta] WHERE idPregunta = @idPregunta"

				Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

				Return Me.ExecuteNonQuery(queryString, parametros)
			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal clavePregunta As Integer) As System.Data.IDataReader
			Dim queryString As String = "SELECT * FROM OpcionesRespuesta WHERE idPregunta = @idPregunta"

			Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal clavePregunta As Integer) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM OpcionesRespuesta WHERE idPregunta = @idPregunta"

			Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

			Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overloads Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overloads Function Count(ByVal clavePregunta As Integer) As Integer
			Dim queryString As String = "SELECT count(idOR) as num FROM OpcionesRespuesta WHERE idPregunta = @idPregunta"

			Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

			Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
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
			If Me.Count(Me.idPregunta) > 1 Then
				Dim myOP As New OpcionPregunta

				Return Not myOP.GetDR(Me.idPregunta, Me.idOR).HasRows
			Else
				Return False
			End If
		End Function

		Public Function HayOpciones(ByVal clavePregunta As Integer) As Boolean
			Dim dr As SqlClient.SqlDataReader = Me.GetDR(clavePregunta)
			Return dr.HasRows
		End Function

		'++++++++++++ DEPRECATED: Utilizar EnUso() +++++++++++++++
		Public Function SePuedeBorrarOR() As Boolean
			If Me.Count(Me.idPregunta) > 1 Then
				Dim myOP As New OpcionPregunta
				Dim dr As SqlClient.SqlDataReader = myOP.GetDR(Me.idPregunta, Me.idOR)
				Return Not dr.HasRows
			Else
				Return False
			End If
		End Function
#End Region
	End Class
End Namespace
