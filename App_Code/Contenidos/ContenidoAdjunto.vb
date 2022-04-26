Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class ContenidoAdjunto
		Inherits DBObject

#Region "Variables"
		Private idContenidoAdjunto As Integer
		Public idProc As Integer
		Public Procedencia As String
		Public idContenido As Integer

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idContenidoAdjunto
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.ContenidoAdjunto
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM [ContenidosAdjuntos] WHERE (" & _
             "[idContenidoAdjunto] = @idContenidoAdjunto)"

			Dim parameters As SqlParameter() = {New SqlParameter("@idContenidoAdjunto", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idContenidoAdjunto = CInt(dr("idContenidoAdjunto"))
				Me.idProc = CInt(dr("idProc"))
				Me.Procedencia = CType(dr("Procedencia"), String)
				Me.idContenido = CInt(dr("idContenido"))
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveIdContenido As Integer)
			Dim queryString As String = "SELECT * FROM ContenidosAdjuntos WHERE idProc = @idProc AND Procedencia = @Procedencia " & _
			 "AND idContenido = @idContenido"

			Dim parameters As SqlParameter() = { _
			 New SqlParameter("@idProc", claveidProc), _
			 New SqlParameter("@Procedencia", claveProcedencia), _
			 New SqlParameter("@idContenido", claveIdContenido)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idContenidoAdjunto = CInt(dr("idContenidoAdjunto"))
				Me.idProc = CInt(dr("idProc"))
				Me.Procedencia = CType(dr("Procedencia"), String)
				Me.idContenido = CInt(dr("idContenido"))
				Me.varExiste = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [ContenidosAdjuntos] ([idProc], [Procedencia], [idContenido]) VALUES (@" & _
				 "idProc, @Procedencia, @idContenido)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idProc", Me.idProc), _
				  New SqlParameter("@Procedencia", Me.Procedencia), _
				  New SqlParameter("@idContenido", Me.idContenido)}

				Dim objContAdj As New ContenidoAdjunto(Me.idProc, Me.Procedencia, Me.idContenido)
				If Not objContAdj.existe Then
					Me.idContenidoAdjunto = Me.ExecuteNonQuery(queryString, parametros, True)
				End If

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Return 0
		End Function

		Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM ContenidosAdjuntos WHERE (idContenidoAdjunto = @idContenidoAdjunto)"
            Dim parametros As SqlParameter() = {New SqlParameter("@idContenidoAdjunto", Me.idContenidoAdjunto)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

        Public Overloads Function GetDR(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveTipoContenido As Contenidos.TipoContenido) As System.Data.IDataReader

            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " & _
     "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia AND idTipoContenido = @IdTipoContenido"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idProc", claveidProc), _
             New SqlParameter("@Procedencia", claveProcedencia), _
             New SqlParameter("@IdTipoContenido", claveTipoContenido)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveidProc As Integer, ByVal claveProcedencia As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " &
    "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia "

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idProc", claveidProc),
             New SqlParameter("@Procedencia", claveProcedencia)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRNoLigas(ByVal claveidProc As Integer, ByVal claveProcedencia As String) As System.Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " &
    "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia and idTipoContenido <> 1 "

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idProc", claveidProc),
             New SqlParameter("@Procedencia", claveProcedencia)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRLigas(ByVal claveidProc As Integer, ByVal claveProcedencia As String) As System.Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " &
    "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia and idTipoContenido = 1 "

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idProc", claveidProc),
             New SqlParameter("@Procedencia", claveProcedencia)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveProcedencia As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " & _
    "WHERE  Procedencia = @Procedencia "

            Dim parametros As SqlParameter() = {New SqlParameter("@Procedencia", claveProcedencia)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveTipoContenido As Contenidos.TipoContenido) As System.Data.DataSet
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " & _
     "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia AND idTipoContenido = @IdTipoContenido"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idProc", claveidProc), _
             New SqlParameter("@Procedencia", claveProcedencia), _
             New SqlParameter("@IdTipoContenido", claveTipoContenido)}

			Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overloads Function GetDS(ByVal claveidProc As Integer, ByVal claveProcedencia As String) As System.Data.DataSet
            Dim queryString As String = "SELECT c.*, ca.idContenidoAdjunto, ca.idProc, ca.Procedencia FROM ContenidosAdjuntos ca, Contenidos c " & _
    "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia "

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idProc", claveidProc), _
			 New SqlParameter("@Procedencia", claveProcedencia)}

			Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overloads Function GetDSClasificacion(ByVal claveRoot As Integer, ByVal claveClasificacion As Integer, ByVal tipoContenido As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT c.*, ci.idClasificacionItem, ci.idClasificacion FROM ClasificacionesItems AS ci INNER JOIN Contenidos AS c ON ci.idProc = c.idContenido " _
             & "WHERE (ci.procedencia = 'Contenido') AND (ci.idRoot = @idRoot) AND (c.idTipoContenido = @idTipoContenido) " _
             & "AND (ci.idClasificacion = @idClasificacion)"

            Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idRoot", claveRoot), _
			 New SqlParameter("@idClasificacion", claveClasificacion), _
			 New SqlParameter("@idTipoContenido", tipoContenido)}

			Return Me.ExecuteDataSet(queryString, parametros)
		End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveTipoContenido As Contenidos.TipoContenido) As Integer
            Dim queryString As String = "SELECT  count (c.idContenido) as num FROM ContenidosAdjuntos ca, Contenidos c " & _
              "WHERE ca.idContenido = c.idContenido AND idProc = @idProc AND Procedencia = @Procedencia AND idTipoContenido = @IdTipoContenido"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idProc", claveidProc), _
             New SqlParameter("@Procedencia", claveProcedencia), _
             New SqlParameter("@IdTipoContenido", claveTipoContenido)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim num As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    num = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return num
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function
#End Region
    End Class
End Namespace
