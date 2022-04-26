



Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Namespace Lego
    Public Class Rubro
        Inherits DBObject



        Private idRubro As Integer
        Public idRubrica As Integer
        Public Titulo As String
        Public Descripcion As String
        Public Valor As Integer
        Public Eliminado As Boolean


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRubro
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Rubro
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Rubros WHERE idRubro= @idRubro"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRubro", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRubrica = CType(dr("idRubrica"), Integer)
                Me.idRubro = CType(dr("idRubro"), Integer)
                Me.Titulo = CType(dr("Titulo"), String)
                Me.Descripcion = CType(dr("Descripcion"), String)
                Me.Valor = CType(dr("Valor"), Integer)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub





        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [Rubros] (idRubrica, Titulo, Descripcion, Valor, Eliminado) VALUES (@idRubrica, @Titulo, @Descripcion, @Valor, @Eliminado)"


                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idRubrica", Me.idRubrica), _
                 New SqlParameter("@Titulo", Me.Titulo), _
                 New SqlParameter("@Descripcion", Me.Descripcion), _
                 New SqlParameter("@Valor", Me.Valor), _
                  New SqlParameter("@Eliminado", Me.Eliminado)}

                Me.idRubrica = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Rubros] SET idRubrica=@idRubrica, Titulo=@Titulo, Descripcion=@Descripcion, Valor=@Valor, Eliminado=@Eliminado WHERE idRubro = @idRubro"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idRubrica", Me.idRubrica), _
                 New SqlParameter("@Titulo", Me.Titulo), _
                 New SqlParameter("@Descripcion", Me.Descripcion), _
                 New SqlParameter("@Valor", Me.Valor), _
                  New SqlParameter("@Eliminado", Me.Eliminado), _
                              New SqlParameter("@idRubro", Me.idRubro)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()
            Return 1

        End Function



        Public Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Rubros"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveRubrica As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM Rubros WHERE idRubrica = @idRubrica order by titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRubrica", claveRubrica)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Rubricas"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveRubrica As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Rubricas  WHERE idRubrica = @idRubrica order by titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRubrica", claveRubrica)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function



        Public Overloads Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idRubro) as num FROM Rubros"

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

        Public Overloads Function Count(ByVal claveRubricas As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(idRubro) as num FROM Rubros where idRubrica =@idRubrica"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRubrica", claveRubricas)}

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





        Public Overrides Function EnUso() As Boolean

        End Function
    End Class
End Namespace


