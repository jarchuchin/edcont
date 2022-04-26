Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace MasUsuarios
	Public NotInheritable Class Configuracion
		Inherits DBObject

#Region "Variables"
		Private idConfiguracion As Integer
		Public idEmpresa As Integer
		Public espacioPersonalMax As Integer
		Public espacioEmpresaMax As Integer
		Public usuariosMax As Integer
		Public porcentajeAprobacion As Integer
		Public porcentajeExtra As Integer
		Public fechaInicio As Date
		Public fechaFin As Date
		Public defaultUser As Boolean
		Public crearBooks As Boolean
		Public crearSalones As Boolean
		Public buscarCursos As Boolean
		Public administracion As Boolean
		Public asignarPermisos As Boolean
		Public asignarSalonesBooks As Boolean
		Public htmlHeader As String			'++++++++REVISAR++++++++++++
		Public htmlFooter As String		'++++++++REVISAR++++++++++++

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idConfiguracion
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Configuracion
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Configuraciones WHERE idEmpresa = @idEmpresa"

            Dim parameters As SqlParameter() = {New SqlParameter("@idEmpresa", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idConfiguracion = CType(dr("idConfiguracion"), Integer)
				Me.idEmpresa = CType(dr("idempresa"), Integer)
				Me.espacioPersonalMax = CType(dr("espacioPersonalMax"), Integer)
				Me.espacioEmpresaMax = CType(dr("espacioEmpresaMax"), Integer)
				Me.porcentajeAprobacion = CType(dr("porcentajeAprobacion"), Integer)
				Me.porcentajeExtra = CType(dr("porcentajeExtra"), Integer)
				Me.fechaInicio = CType(dr("fechaInicio"), Date)
				Me.fechaFin = CType(dr("fechaFin"), Date)
				Me.defaultUser = CType(dr("defaultUser"), Boolean)
				Me.crearBooks = CType(dr("crearBooks"), Boolean)
				Me.crearSalones = CType(dr("crearSalones"), Boolean)
				Me.buscarCursos = CType(dr("buscarCursos"), Boolean)
				Me.administracion = CType(dr("administracion"), Boolean)
				Me.asignarPermisos = CType(dr("asignarPermisos"), Boolean)
				Me.asignarSalonesBooks = CType(dr("asignarSalonesBooks"), Boolean)
				Me.htmlHeader = CType(dr("htmlHeader"), String)
				Me.htmlFooter = CType(dr("htmlFooter"), String)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [Configuraciones] ([idEmpresa], [espacioPersonalMax], [espacioEmpresaMax], " & _
				"[usuariosMax], [porcentajeAprobacion], [porcentajeExtra], [fechaInicio], [fechaFin], [defaultUser], [crearBooks], " & _
				"[crearSalones], [buscarCursos], [administracion], [asignarPermisos], [asignarSalonesBooks], [htmlHeader], " & _
				"[htmlFooter] ) VALUES (@idEmpresa, @espacioPersonalMax, @espacioEmpresaMax, @usuariosMax, @por" & _
				"centajeAprobacion, @porcentajeExtra, @fechaInicio, @fechaFin, @defaultUser, @crearBooks, @crearSalones, " & _
				"@buscarCursos, @administracion, @asignarPermisos, @asignarSalonesBooks, @htmlHeader, @htmlFooter)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idEmpresa", Me.idEmpresa), _
				  New SqlParameter("@espacioPersonalMax", Me.espacioPersonalMax), _
				  New SqlParameter("@espacioEmpresaMax", Me.espacioEmpresaMax), _
				  New SqlParameter("@usuariosMax", Me.usuariosMax), _
				  New SqlParameter("@porcentajeAprobacion", Me.porcentajeAprobacion), _
				  New SqlParameter("@porcentajeExtra", Me.porcentajeExtra), _
				  New SqlParameter("@fechaInicio", Me.fechaInicio), _
				  New SqlParameter("@fechaFin", Me.fechaFin), _
				  New SqlParameter("@defaultUser", Me.defaultUser), _
				  New SqlParameter("@crearBooks", Me.crearBooks), _
				  New SqlParameter("@crearSalones", Me.crearSalones), _
				  New SqlParameter("@buscarCursos", Me.buscarCursos), _
				  New SqlParameter("@administracion", Me.administracion), _
				  New SqlParameter("@asignarPermisos", Me.asignarPermisos), _
				  New SqlParameter("@asignarSalonesBooks", Me.asignarSalonesBooks), _
				  New SqlParameter("@htmlHeader", Me.htmlHeader), _
				  New SqlParameter("@htmlFooter", Me.htmlFooter)}

				Me.idConfiguracion = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [Configuraciones] SET [fechaFin]=@fechaFin, [fechainicio]=@fechainicio, " & _
				"[asignarSalonesBooks]=@asignarSalonesBooks, [crearBooks]=@crearBooks, [asignarPermisos]=@asignarPermisos, " & _
				"[porcentajeExtra]=@porcentajeExtra, [porcentajeAprobacion]=@porcentajeAprobacion, " & _
				"[usuariosMax]=@usuariosMax, [defaultUser]=@defaultUser, [espacioPersonalMax]=@espacioPersonalMax, " & _
				"[buscarCursos]=@buscarCursos, [crearSalones]=@crearSalones, [administracion]=@administracion, " & _
				"[espacioEmpresaMax]=@espacioEmpresaMax, [htmlHeader]=@htmlHeader, [htmlFooter]=@htmlFooter " & _
				"WHERE ([Configuraciones].[idEmpresa] = @idEmpresa)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idEmpresa", Me.idEmpresa), _
				  New SqlParameter("@espacioPersonalMax", Me.espacioPersonalMax), _
				  New SqlParameter("@espacioEmpresaMax", Me.espacioEmpresaMax), _
				  New SqlParameter("@usuariosMax", Me.usuariosMax), _
				  New SqlParameter("@porcentajeAprobacion", Me.porcentajeAprobacion), _
				  New SqlParameter("@porcentajeExtra", Me.porcentajeExtra), _
				  New SqlParameter("@fechaInicio", Me.fechaInicio), _
				  New SqlParameter("@fechaFin", Me.fechaFin), _
				  New SqlParameter("@defaultUser", Me.defaultUser), _
				  New SqlParameter("@crearBooks", Me.crearBooks), _
				  New SqlParameter("@crearSalones", Me.crearSalones), _
				  New SqlParameter("@buscarCursos", Me.buscarCursos), _
				  New SqlParameter("@administracion", Me.administracion), _
				  New SqlParameter("@asignarPermisos", Me.asignarPermisos), _
				  New SqlParameter("@asignarSalonesBooks", Me.asignarSalonesBooks), _
				  New SqlParameter("@htmlHeader", Me.htmlHeader), _
				  New SqlParameter("@htmlFooter", Me.htmlFooter)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "SELECT * FROM Configuraciones WHERE idConfiguracion = @idConfiguracion"

			Dim parametros As SqlParameter() = {New SqlParameter("@idConfiguracion", Me.idConfiguracion)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overrides Function GetDR() As SqlDataReader
			Dim queryString As String = "SELECT * FROM Configuraciones"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Configuraciones"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Overrides Function Count() As Integer
			Dim queryString As String = "SELECT COUNT(idConfiguracion) AS num FROM Configuraciones"

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
			Dim dr As Data.SqlClient.SqlDataReader = Me.GetDREmpresa(Me.idEmpresa)
			Dim retorno As Boolean = dr.HasRows
			dr.Close()

			Return retorno
		End Function

		Public Function GetDREmpresa(ByVal claveEmpresa As Integer) As Data.SqlClient.SqlDataReader
			Dim queryString As String = "SELECT * FROM Configuraciones WHERE idEmpresa = @idEmpresa"

			Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		'+++++++ DEPRECATED: Utilizar EnUso() +++++++++++++++
		Function HayAplicaciones(ByVal claveEmpresa As Integer) As Boolean
			Dim bandera As Boolean = False
			Dim dr As Data.SqlClient.SqlDataReader = Me.GetDREmpresa(claveEmpresa)
			If dr.Read Then
				bandera = True
			End If
			dr.Close()
			Return bandera
		End Function
#End Region
	End Class
End Namespace