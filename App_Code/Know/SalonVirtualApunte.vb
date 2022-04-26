
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class SalonVirtualApunte
        Inherits DBObject

#Region "Variables"
        Private idSalonVirtualApunte As Integer
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public Fecha As DateTime
        Public Texto As String
        Public Eliminado As Boolean
        Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualApunte
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVritualEntrada
            End Get
        End Property
#End Region

#Region "Constructores"
        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesApuntes WHERE idSalonVirtualApunte = @idSalonVirtualApunte"
            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualApunte", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualApunte = CType(dr("idSalonVirtualApunte"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.Texto = CType(dr("Texto"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

    
#End Region

#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [SalonesVirtualesApuntes] (idSalonVirtual, idUserProfile, Texto, Fecha, Eliminado) VALUES (@idSalonVirtual, @idUserProfile, @Texto, @Fecha, @Eliminado)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@Texto", Me.Texto), _
                  New SqlParameter("@Fecha", Me.Fecha), _
                  New SqlParameter("@Eliminado", Me.Eliminado)}


                Me.idSalonVirtualApunte = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE SalonesVirtualesApuntes SET idSalonVirtual=@idSalonVirtual, idUserProfile=@idUserProfile, Texto=@Texto, Fecha=@Fecha, Eliminado=@Eliminado WHERE idSalonVirtualApunte = @idSalonVirtualApunte"

                Dim parametros As SqlParameter() = { _
                New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                New SqlParameter("@idUserProfile", Me.idUserProfile), _
                New SqlParameter("@Texto", Me.Texto), _
                New SqlParameter("@Fecha", Me.Fecha), _
                New SqlParameter("@idSalonVirtualApunte", Me.idSalonVirtualApunte), _
                  New SqlParameter("@Eliminado", Me.Eliminado)}



                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()


        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtualesApuntes"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT * from SalonesVirtualesApuntes where idUserProfile = @idUserProfile and idSalonVirtual =@idSalonVirtual and Eliminado=0 order by Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

      


        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtualesApuntes"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As DataSet
            Dim queryString As String = "SELECT * from SalonesVirtualesApuntes where idUserProfile = @idUserProfile and idSalonVirtual =@idSalonVirtual and Eliminado=0 order by Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Overrides Function Count() As Integer
            Return Me.GetDS(Me.idSalonVirtual, Me.idUserProfile).Tables(0).Rows.Count
        End Function
    
        Public Overrides Function EnUso() As Boolean
            Return True
        End Function




#End Region
    End Class
End Namespace

