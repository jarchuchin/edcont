Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Learning
	Public NotInheritable Class Servicios
		Inherits DBObjectLight

#Region "Constructores"
		Public Sub New()
		End Sub
#End Region

		Public Shared Function GetDRCursoEvaluacion(ByVal claveCurso As String) As Data.IDataReader
			Dim queryString As String = "SELECT * FROM CursosEvaluacion WHERE claveCurso = @claveCurso"

			Dim parametros As SqlParameter() = {New SqlParameter("@claveCurso", claveCurso)}

			Return New Servicios().ExecuteReader(queryString, parametros)
		End Function

		Public Shared Sub GrabarEvaluacion(ByVal salon As Know.SalonVirtual, ByVal claveCurso As String)
			Dim numero As Integer = 0
			Dim dr As SqlClient.SqlDataReader = Servicios.GetDRCursoEvaluacion(claveCurso)
            Dim myIE As Know.ItemEvaluacion

			Do While dr.Read
				myIE = New Know.ItemEvaluacion
				myIE.salonVirtual = salon
				myIE.titulo = Convert.ToString(dr("nombre"))
				myIE.valor = Convert.ToInt32(dr("valor"))
				myIE.tipoItem = Know.TipoItemEvaluacion.Computo
				myIE.Add()
			Loop
			dr.Close()

		End Sub
	End Class
End Namespace

