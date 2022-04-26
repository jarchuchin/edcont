Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace MasUsuarios
	Public NotInheritable Class TipoPermiso
		Inherits DBObject

#Region "Variables"
		Private idTipoPermiso As Integer
		Public PRoots As Boolean
		Public PRootsLabel As String
		Public PPermisosRoots As Boolean
		Public PPermisosRootsLabel As String
		Public PCategorias As Boolean
		Public PCategoriasLabel As String
		Public PRespuestas As Boolean
		Public PRespuestasLabel As String
		Public PEvaluacion As Boolean
		Public PEvaluacionLabel As String
		Public PSalonVirtual As Boolean
		Public PSalonVirtualLabel As String
		Public PContenidos As Boolean
		Public PContenidosLabel As String
		Public PInterfaceGrafica As Boolean
		Public PInterfaceGraficaLabel As String
		Public PEstadisticas As Boolean
		Public PEstadisticasLabel As String
		Public PAdministracion As Boolean
		Public PAdministracionLabel As String

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idTipoPermiso
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.TipoPermiso
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM TiposPermiso WHERE idTipoPermiso = @idTipoPermiso"

			Dim parameters As SqlParameter() = {New SqlParameter("@idTipoPermiso", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idTipoPermiso = CType(dr("idTipoPermiso"), Integer)
				Me.PRoots = CType(dr("PRoots"), Boolean)
				Me.PRootsLabel = CType(dr("PRootsLabel"), String)
				Me.PPermisosRoots = CType(dr("PPermisosRoots"), Boolean)
				Me.PPermisosRootsLabel = CType(dr("PPermisosRootsLabel"), String)
				Me.PCategorias = CType(dr("PCategorias"), Boolean)
				Me.PCategoriasLabel = CType(dr("PCategoriasLabel"), String)
				Me.PRespuestas = CType(dr("PRespuestas"), Boolean)
				Me.PRespuestasLabel = CType(dr("PRespuestasLabel"), String)
				Me.PEvaluacion = CType(dr("PEvaluacion"), Boolean)
				Me.PEvaluacionLabel = CType(dr("PEvaluacionLabel"), String)
				Me.PSalonVirtual = CType(dr("PSalonVirtual"), Boolean)
				Me.PSalonVirtualLabel = CType(dr("PSalonVirtualLabel"), String)
				Me.PContenidos = CType(dr("PContenidos"), Boolean)
				Me.PContenidosLabel = CType(dr("PContenidosLabel"), String)
				Me.PInterfaceGrafica = CType(dr("PInterfaceGrafica"), Boolean)
				Me.PInterfaceGraficaLabel = CType(dr("PInterfaceGraficaLabel"), String)
				Me.PEstadisticas = CType(dr("PEstadisticas"), Boolean)
				Me.PEstadisticasLabel = CType(dr("PEstadisticasLabel"), String)
				Me.PAdministracion = CType(dr("PAdministracion"), Boolean)
				Me.PAdministracionLabel = CType(dr("PAdministracionLabel"), String)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [TiposPermiso] ([PRoots], [PRootsLabel], [PPermisosRoots], [PPermisosRootsLabel], " & _
				 "[PCategorias], [PCategoriasLabel], [PRespuestas], [PRespuestasLabel], [PEvaluacion], [PEvaluacionLabel], " & _
				 "[PSalonVirtual], [PSalonVirtualLabel], [PContenidos], [PContenidosLabel], [PInterfaceGrafica], [PInterfaceGraficaLabel], " & _
				 "[PEstadisticas], [PEstadisticasLabel], [PAdministracion], [PAdministracionLabel]) VALUES (@PRoots, @PRootsLabel, " & _
				 "@PPermisosRoots, @PPermisosRootsLabel, @PCategorias, @PCategoriasLabel, @PRespuestas, @PRespuestasLabel, " & _
				 "@PEvaluacion, @PEvaluacionLabel, @PSalonVirtual, @PSalonVirtualLabel, @PContenidos, @PContenidosLabel, " & _
				 "@PInterfaceGrafica, @PInterfaceGraficaLabel, @PEstadisticas, @PEstadisticasLabel, @PAdministracion, " & _
				 "@PAdministracionLabel)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@PRoots", Me.PRoots), _
				  New SqlParameter("@PRootsLabel", Me.PRootsLabel), _
				  New SqlParameter("@PPermisosRoots", Me.PPermisosRoots), _
				  New SqlParameter("@PPermisosRootsLabel", Me.PPermisosRootsLabel), _
				  New SqlParameter("@PCategorias", Me.PCategorias), _
				  New SqlParameter("@PCategoriasLabel", Me.PCategoriasLabel), _
				  New SqlParameter("@PRespuestas", Me.PRespuestas), _
				  New SqlParameter("@PRespuestasLabel", Me.PRespuestasLabel), _
				  New SqlParameter("@PEvaluacion", Me.PEvaluacion), _
				  New SqlParameter("@PEvaluacionLabel", Me.PEvaluacionLabel), _
				  New SqlParameter("@PSalonVirtual", Me.PSalonVirtual), _
				  New SqlParameter("@PSalonVirtualLabel", Me.PSalonVirtualLabel), _
				  New SqlParameter("@PContenidos", Me.PContenidos), _
				  New SqlParameter("@PContenidosLabel", Me.PContenidosLabel), _
				  New SqlParameter("@PInterfaceGrafica", Me.PInterfaceGrafica), _
				  New SqlParameter("@PInterfaceGraficaLabel", Me.PInterfaceGraficaLabel), _
				  New SqlParameter("@PEstadisticas", Me.PEstadisticas), _
				  New SqlParameter("@PEstadisticasLabel", Me.PEstadisticasLabel), _
				  New SqlParameter("@PAdministracion", Me.PAdministracion), _
				  New SqlParameter("@PAdministracionLabel", Me.PAdministracionLabel)}

				Me.idTipoPermiso = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [TiposPermiso] SET [PRoots]=@PRoots, [PRootsLabel]=@PRootsLabel, " & _
				 "[PPermisosRoots]=@PPermisosRoots, [PPermisosRootsLabel]=@PPermisosRootsLabel, [PCategorias]=@PCategorias, " & _
				 "[PCategoriasLabel]=@PCategoriasLabel, [PRespuestas]=@PRespuestas, [PRespuestasLabel]=@PRespuestasLabel, " & _
				 "[PEvaluacion]=@PEvaluacion, [PEvaluacionLabel]=@PEvaluacionLabel, [PSalonVirtual]=@PSalonVirtual, " & _
				 "[PSalonVirtualLabel]=@PSalonVirtualLabel, [PContenidos]=@PContenidos, [PContenidosLabel]=@PContenidosLabel, " & _
				 "[PInterfaceGrafica]=@PInterfaceGrafica, [PInterfaceGraficaLabel]=@PInterfaceGraficaLabel, " & _
				 "[PEstadisticas]=@PEstadisticas, [PEstadisticasLabel]=@PEstadisticasLabel, [PAdministracion]=@PAdministracion, " & _
				 "[PAdministracionLabel]=@PAdministracionLabel WHERE idTipoPermiso = @idTipoPermiso"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@PRoots", Me.PRoots), _
				  New SqlParameter("@PRootsLabel", Me.PRootsLabel), _
				  New SqlParameter("@PPermisosRoots", Me.PPermisosRoots), _
				  New SqlParameter("@PPermisosRootsLabel", Me.PPermisosRootsLabel), _
				  New SqlParameter("@PCategorias", Me.PCategorias), _
				  New SqlParameter("@PCategoriasLabel", Me.PCategoriasLabel), _
				  New SqlParameter("@PRespuestas", Me.PRespuestas), _
				  New SqlParameter("@PRespuestasLabel", Me.PRespuestasLabel), _
				  New SqlParameter("@PEvaluacion", Me.PEvaluacion), _
				  New SqlParameter("@PEvaluacionLabel", Me.PEvaluacionLabel), _
				  New SqlParameter("@PSalonVirtual", Me.PSalonVirtual), _
				  New SqlParameter("@PSalonVirtualLabel", Me.PSalonVirtualLabel), _
				  New SqlParameter("@PContenidos", Me.PContenidos), _
				  New SqlParameter("@PContenidosLabel", Me.PContenidosLabel), _
				  New SqlParameter("@PInterfaceGrafica", Me.PInterfaceGrafica), _
				  New SqlParameter("@PInterfaceGraficaLabel", Me.PInterfaceGraficaLabel), _
				  New SqlParameter("@PEstadisticas", Me.PEstadisticas), _
				  New SqlParameter("@PEstadisticasLabel", Me.PEstadisticasLabel), _
				  New SqlParameter("@PAdministracion", Me.PAdministracion), _
				  New SqlParameter("@PAdministracionLabel", Me.PAdministracionLabel)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM TiposPermiso WHERE idTipoPermiso = @idTipoPermiso"

			Dim parametros As SqlParameter() = {New SqlParameter("@idTipoPermiso", Me.idTipoPermiso)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM TiposPermiso"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM TiposPermiso"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function
#End Region
	End Class
End Namespace