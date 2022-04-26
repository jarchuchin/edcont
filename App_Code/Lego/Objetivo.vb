Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Lego
	Public NotInheritable Class Objetivo
		Inherits DBObject


        Private idObjetivo As Integer
		Public idClasificacion As Integer
        Public objetivox As String
        Public habilidad As String = ""
        Public aptitud As String = ""



        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idObjetivo
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Objetivo
			End Get
		End Property



        Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Objetivos WHERE idObjetivo = @idObjetivo"

			Dim parameters As SqlParameter() = {New SqlParameter("@idObjetivo", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idObjetivo = CType(dr("idObjetivo"), Integer)
				Me.idClasificacion = CType(dr("idClasificacion"), Integer)
                Me.objetivox = CType(dr("objetivo"), String)
                If Not Convert.IsDBNull(dr("habilidad")) Then
                    Me.habilidad = dr("habilidad")
                End If
                If Not Convert.IsDBNull(dr("aptitud")) Then
                    Me.aptitud = dr("aptitud")
                End If
                Me.varExiste = True
			End If
			dr.Close()
		End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [Objetivos] ([idClasificacion], [objetivo], habilidad, aptitud) VALUES (@idClasificacion, @objetivo, @habilidad, @aptitud)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idClasificacion", Me.idClasificacion),
                  New SqlParameter("@objetivo", Me.objetivox),
                  New SqlParameter("@habilidad", Me.habilidad),
                  New SqlParameter("@aptitud", Me.aptitud)}

                Me.idObjetivo = Me.ExecuteNonQuery(queryString, parametros, True)



            Return 1
        End Function

		Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [Objetivos] SET [objetivo]=@objetivo, habilidad=@habilidad, aptitud=@aptitud WHERE idObjetivo = @idObjetivo"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idObjetivo", Me.idObjetivo),
                  New SqlParameter("@objetivo", Me.objetivox),
                  New SqlParameter("@habilidad", Me.habilidad),
                  New SqlParameter("@aptitud", Me.aptitud)}

                Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM Objetivos WHERE idObjetivo = @idObjetivo"

			Dim parametros As SqlParameter() = {New SqlParameter("@idObjetivo", Me.idObjetivo)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal claveClasificacion As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM Objetivos WHERE idClasificacion = @idClasificacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}

            Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveClasificacion As Integer) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM Objetivos WHERE idClasificacion = @idClasificacion"

			Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function




    End Class
End Namespace

