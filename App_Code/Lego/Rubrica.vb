

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Namespace Lego
    Public Class Rubrica
        Inherits DBObject



        Private idRubrica As Integer
        Public idActividad As Integer
        Public Titulo As String
        Public Val1 As Integer
        Public Val1Descripcion As String
        Public Val2 As Integer
        Public Val2Descripcion As String
        Public Val3 As Integer
        Public Val3Descripcion As String
        Public Val4 As Integer
        Public Val4Descripcion As String
        Public Eliminado As Boolean


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRubrica
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Rubrica
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Rubricas WHERE idRubrica= @idRubrica"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRubrica", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRubrica = CType(dr("idRubrica"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.Titulo = CType(dr("Titulo"), String)
                Me.Val1 = CType(dr("Val1"), Integer)
                Me.Val1Descripcion = dr("Val1Descripcion")
                Me.Val2 = CType(dr("Val2"), Integer)
                Me.Val2Descripcion = dr("Val2Descripcion")
                Me.Val3 = CType(dr("Val3"), Integer)
                Me.Val3Descripcion = dr("Val3Descripcion")
                Me.Val4 = CType(dr("Val4"), Integer)
                Me.Val4Descripcion = dr("Val4Descripcion")
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub





        Public Overrides Function Add() As Integer
            ' Try
            Dim queryString As String = "INSERT INTO [Rubricas] (idActividad, Titulo, Val1, Val1Descripcion, Val2, Val2Descripcion, Val3, Val3Descripcion, Val4, Val4Descripcion,  Eliminado) VALUES (@idActividad, @Titulo, @Val1, @Val1Descripcion, @Val2, @Val2Descripcion, @Val3, @Val3Descripcion, @Val4, @Val4Descripcion,  @Eliminado)"


                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idActividad", Me.idActividad), _
                 New SqlParameter("@Titulo", Me.Titulo), _
                 New SqlParameter("@Val1", Me.Val1), _
                 New SqlParameter("@Val1Descripcion", Me.Val1Descripcion), _
                 New SqlParameter("@Val2", Me.Val2), _
                 New SqlParameter("@Val2Descripcion", Me.Val2Descripcion), _
                 New SqlParameter("@Val3", Me.Val3), _
                 New SqlParameter("@Val3Descripcion", Me.Val3Descripcion), _
                 New SqlParameter("@Val4", Me.Val4), _
                 New SqlParameter("@Val4Descripcion", Me.Val4Descripcion), _
                  New SqlParameter("@Eliminado", Me.Eliminado)}

                Me.idRubrica = Me.ExecuteNonQuery(queryString, parametros, True)

            '  Catch ex As Exception
            '   Dim m As String = ex.Message
            '  End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [Rubricas] SET idActividad=@idActividad, Titulo=@Titulo, Val1=@Val1, Val1Descripcion=@Val1Descripcion, Val2=@Val2, Val2Descripcion=@Val2Descripcion, Val3=@Val3, Val3Descripcion=@Val3Descripcion, Val4=@Val4, Val4Descripcion=@Val4Descripcion, Eliminado=@Eliminado WHERE idRubrica = @idRubrica"

            Dim parametros As SqlParameter() = { _
           New SqlParameter("@idActividad", Me.idActividad), _
           New SqlParameter("@Titulo", Me.Titulo), _
           New SqlParameter("@Val1", Me.Val1), _
           New SqlParameter("@Val1Descripcion", Me.Val1Descripcion), _
           New SqlParameter("@Val2", Me.Val2), _
           New SqlParameter("@Val2Descripcion", Me.Val2Descripcion), _
           New SqlParameter("@Val3", Me.Val3), _
           New SqlParameter("@Val3Descripcion", Me.Val3Descripcion), _
           New SqlParameter("@Val4", Me.Val4), _
           New SqlParameter("@Val4Descripcion", Me.Val4Descripcion), _
            New SqlParameter("@Eliminado", Me.Eliminado), _
                        New SqlParameter("@idRubrica", Me.idRubrica)}

            Return Me.ExecuteNonQuery(queryString, parametros)


            Return 0

        End Function

        Public Overrides Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()
            Return 1

        End Function



        Public Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Rubricas where eliminado = 0 order by titulo"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveActividad As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM Rubricas WHERE idActividad = @idActividad and eliminado=0 order by titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Rubricas where  eliminado=0 order by titulo "

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveActividad As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Rubricas WHERE idActividad=@idActividad and eliminado=0 order by titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function



        Public Overloads Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idRubrica) as num FROM Rubricas where eliminado=0"

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

        Public Overloads Function Count(ByVal claveActividad As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(idRubrica) as num FROM Rubricas where idActividad =@idActividad  and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

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


        Public Function GetTotalValorRubrica(claveActividad As Integer) As Decimal
            Dim queryString As String = "SELECT sum(val4) as num FROM Rubricas where idActividad=@idActividad  and eliminado=0"
            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Decimal)
                End If

            End If
            dr.Close()

            Return numero
        End Function

        Public Function GetTotalValorRubricaA(claveActividad As Integer) As Decimal
            Dim queryString As String = "SELECT sum(val1) as num FROM Rubricas where idActividad=@idActividad  and eliminado=0"
            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Decimal)
                End If

            End If
            dr.Close()

            Return numero
        End Function

        Public Overrides Function EnUso() As Boolean

        End Function
    End Class
End Namespace

