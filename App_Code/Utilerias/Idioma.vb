Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Utilerias
    Public NotInheritable Class Idioma
        Inherits DBObject


        Public idIdioma As Integer
        Public Nombre As String
        Public CultureID As String


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idIdioma
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Idioma
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As String)
            Dim queryString As String = "SELECT * FROM idiomas WHERE CultureID = @CultureID"

            Dim parameters As SqlParameter() = {New SqlParameter("@CultureID", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idIdioma = CType(dr("idIdioma"), Integer)
                Me.Nombre = CType(dr("Nombre"), String)
                Me.CultureID = CType(dr("CultureID"), String)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM idiomas WHERE idIdioma = @idIdioma"

            Dim parameters As SqlParameter() = {New SqlParameter("@idIdioma", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idIdioma = CType(dr("idIdioma"), Integer)
                Me.Nombre = CType(dr("Nombre"), String)
                Me.CultureID = CType(dr("CultureID"), String)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [Idiomas] ([Nombre], [CultureID]) VALUES (@Nombre, @CultureID)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@Nombre", Me.Nombre),
                 New SqlParameter("@CultureID", Me.CultureID)}

                Me.idIdioma = Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Idiomas] SET [Nombre]=@Nombre, [CultureID]=@CultureID WHERE idIdioma = @idIdioma"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@Nombre", Me.Nombre),
                 New SqlParameter("@CultureID", Me.CultureID),
                  New SqlParameter("@idIdioma", Me.idIdioma)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Idiomas WHERE idIdioma = @idIdioma"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", Me.idIdioma)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Idiomas"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Idiomas"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idIdioma) as num FROM Idiomas"

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

    End Class
End Namespace

