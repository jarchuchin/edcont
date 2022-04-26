Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class GrupoActividad
        Inherits DBObject


        Private idGrupoActividad As Integer
        Public idActividad As Integer
        Public idSalonVirtual As Integer
        Public Nombre As String
        Public Fecha As datetime


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return idGrupoActividad
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.GrupoActividad
            End Get
        End Property



        Public Sub New()
        End Sub

        Public Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM GruposActividades WHERE idGrupoActividad = @idGrupoActividad"

            Dim parameters As SqlParameter() = {New SqlParameter("@idGrupoActividad", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idGrupoActividad = clavePrincipal
                Me.idActividad = CInt(dr("idActividad"))
                Me.idSalonVirtual = CInt(dr("idSalonVirtual"))
                Me.Nombre = CType(dr("Nombre"), String)
                Me.Fecha = CType(dr("Fecha"), datetime)


                Me.varExiste = True
            End If
            dr.Close()

        End Sub


        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [GruposActividades] (idActividad, idSalonVirtual, Nombre, Fecha) VALUES (@idActividad, @idSalonVirtual, @Nombre, @Fecha)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
                  New SqlParameter("@Nombre", Me.Nombre),
                  New SqlParameter("@Fecha", Me.Fecha)}


                Me.idGrupoActividad = Me.ExecuteNonQuery(queryString, parametros, True)


                Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [GruposActividades] SET idActividad=@idActividad, idSalonVirtual=@idSalonVirtual, Nombre=@Nombre, Fecha=@Fecha WHERE idGrupoActividad = @idGrupoActividad"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
                  New SqlParameter("@Nombre", Me.Nombre),
                  New SqlParameter("@Fecha", Me.Fecha),
                New SqlParameter("@idGrupoActividad", Me.idGrupoActividad)}

                Return Me.ExecuteNonQuery(queryString, parametros)

        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM [GruposActividades] WHERE idGrupoActividad = @idGrupoActividad"

            Dim parametros As SqlParameter() = {New SqlParameter("@idGrupoActividad", Me.idGrupoActividad)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Dim sql As String = "Select * from GruposActividades"
            Return Me.ExecuteReader(sql, Nothing)
        End Function

        Public Function GetGruposDR(claveSalon As Integer, claveActividad As Integer) As SqlDataReader

            Dim sql As String = "Select * from GruposActividades where idSalonVirtual=@idSalonVirtual and idActividad=@idActividad and order by Nombre"


            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteReader(sql, parametros)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(claveSalon As Integer, claveActividad As Integer) As Integer
            Dim sql As String = "select count(idGrupoActividad) as num where idSalonVirtual=@idSalonVirtual and idActividad=@idActividad"
            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idActividad", claveActividad)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function


        Public Function CrearGruposActividad(claveSalon As Integer, claveActividad As Integer) As Integer


            Dim myr As New know.salonVirtual(claveSalon, False)
            If myr.existe Then
                Dim mya As New Contenidos.Actividad(claveActividad)
                If mya.existe Then

                    Dim mysvup As New Know.SalonVirtualUserProfile()
                    Dim ds As DataSet = mysvup.GetDSListaAlumnos(myr.id)
                    Dim numAlumnos As Integer = ds.Tables(0).Rows.Count
                    '  Dim grupos As Integer = 

                End If
            End If



        End Function


    End Class



End Namespace
