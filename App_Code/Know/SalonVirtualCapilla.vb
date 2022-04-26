

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class SalonVirtualCapilla
        Inherits DBObject

#Region "Variables"
        Private idSalonVirtualCapilla As Integer
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public Fecha As DateTime
        Public Texto As String
        Public Eliminado As Boolean
        Public TipoCapilla As Integer
        Private varExiste As Boolean = False


#End Region

#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualCapilla
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVirtualCapilla
            End Get
        End Property
#End Region

#Region "Constructores"
        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCapillas WHERE idSalonVirtualCapilla = @idSalonVirtualCapilla"
            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualCapilla", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualCapilla = CType(dr("idSalonVirtualCapilla"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.Texto = CType(dr("Texto"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.TipoCapilla = CType(dr("TipoCapilla"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


#End Region

#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [SalonesVirtualesCapillas] (idSalonVirtual, idUserProfile, Texto, Fecha, Eliminado, TipoCapilla) VALUES (@idSalonVirtual, @idUserProfile, @Texto, @Fecha, @Eliminado, @TipoCapilla)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@Texto", Me.Texto), _
                  New SqlParameter("@Fecha", Me.Fecha), _
                  New SqlParameter("@Eliminado", Me.Eliminado), _
                  New SqlParameter("@TipoCapilla", Me.TipoCapilla)}


                Me.idSalonVirtualCapilla = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE SalonesVirtualesCapillas SET idSalonVirtual=@idSalonVirtual, idUserProfile=@idUserProfile, Texto=@Texto, Fecha=@Fecha, Eliminado=@Eliminado WHERE idSalonVirtualCapilla = @idSalonVirtualCapilla"

                Dim parametros As SqlParameter() = { _
                New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                New SqlParameter("@idUserProfile", Me.idUserProfile), _
                New SqlParameter("@Texto", Me.Texto), _
                New SqlParameter("@Fecha", Me.Fecha), _
                New SqlParameter("@idSalonVirtualCapilla", Me.idSalonVirtualCapilla), _
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
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCapillas"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal clavetop As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT  s.*, u.nombre + ' ' + u.apellidos as nombre, u.imagen, eu.claveAux1 from SalonesVirtualesCapillas s, UserProfiles u, EmpresasUserProfiles eu where u.idUserProfile=eu.idUserProfile and s.idUserProfile=u.idUserProfile and  idSalonVirtual =@idSalonVirtual and Eliminado=0 order by Fecha desc"

            If clavetop > 0 Then
                queryString = "SELECT top " & clavetop & " s.*, u.nombre + ' ' + u.apellidos as nombre, u.imagen, eu.claveAux1 from SalonesVirtualesCapillas s, UserProfiles u, EmpresasUserProfiles eu where u.idUserProfile=eu.idUserProfile and s.idUserProfile=u.idUserProfile and  idSalonVirtual =@idSalonVirtual and Eliminado=0 order by Fecha desc"

            End If
            
            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function


        Public Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCapillas where eliminado =0"


            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCapillas where idSalonVirtual =@idSalonVirtual and eliminado =0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal clavetop As Integer) As DataSet
            Dim queryString As String = "SELECT top " & clavetop & " * from SalonesVirtualesCapillas where  idSalonVirtual =@idSalonVirtual and Eliminado=0 order by Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Overrides Function Count() As Integer
            Return Me.GetDS(Me.idSalonVirtual).Tables(0).Rows.Count
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function




#End Region
    End Class
End Namespace
