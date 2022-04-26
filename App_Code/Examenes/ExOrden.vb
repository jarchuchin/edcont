

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Examenes
    Public NotInheritable Class ExOrden
        Inherits DBObject


        Private idExOrden As Integer
        Public idActividad As Integer
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public Orden As String = String.Empty
        Public Fecha As Date = Date.Now


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idExOrden
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ExOrden
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * from exorden where idExOrden=idExOrden"

            Dim parameters As SqlParameter() = {New SqlParameter("@idExOrden", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idExOrden = CType(dr("idExOrden"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.Orden = CType(dr("Orden"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveActividad As Integer, ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer)
            Dim queryString As String = "SELECT [exorden].* FROM [exorden] WHERE (([exorden].[idActividad] =@idActividad) " &
             " AND ([exorden].[idSalonVirtual] = @idSalonVirtual) AND ([exorden].[idUserProfile] = @idUserProfile))"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idActividad", claveActividad),
             New SqlParameter("@idSalonVirtual", claveSalonVirtual),
             New SqlParameter("@idUserProfile", claveUserProfile)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idExOrden = CType(dr("idExOrden"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.Orden = CType(dr("Orden"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [exOrden] ([idActividad], [idSalonVirtual], [idUserProfile], [Orden], [Fecha]) VALUES (@idActividad, @idSalonVirtual, @idUserProfile, @Orden, @Fecha)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@Orden", Me.Orden),
                  New SqlParameter("@Fecha", Me.Fecha)}

                If New ExRespuesta(idActividad, idSalonVirtual, idUserProfile).existe Then
                    Me.Update()
                Else
                    Me.idExOrden = Me.ExecuteNonQuery(queryString, parametros, True)
                End If

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [ExOrden] SET [Orden]=@Orden, [fecha]=@fecha WHERE ([idExOrden] = @idExOrden)"

                Dim parametros As SqlParameter() = {
                  New SqlParameter("@Orden", Me.Orden),
                  New SqlParameter("@Fecha", Me.Fecha),
                  New SqlParameter("@idExOrden", Me.idExOrden)}

                If Me.idExOrden > 0 Then
                    Return Me.ExecuteNonQuery(queryString, parametros)
                Else
                    Return 0
                End If


            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE ExOrden WHERE idExOrden = @idExOrden"
            Dim parametros As SqlParameter() = {New SqlParameter("@idExOrden", Me.idExOrden)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function



        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal clavePregunta As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT idPregunta, idExRespuesta FROM ExRespuestas WHERE idPregunta = @idPregunta"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function



        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overloads Overrides Function Count() As Integer
            Return 0
        End Function



        Public Overrides Function EnUso() As Boolean

        End Function


    End Class
End Namespace
