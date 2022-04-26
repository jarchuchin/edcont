

Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace Know

    Public Class Bitacora
        Inherits DBObject

        Public idBitacora As Integer
        Public idUserProfile As Integer

        Public ip As String
        Public Modulo As String
        Public Bitacora As String
        Public Fecha As DateTime

        Public idSalonVirtual As Integer = 0

        Public varexiste As Boolean = False
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idBitacora
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Bitacora
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from Bitacoras where idBitacora=@idBitacora"

            Dim param As SqlParameter() = {New SqlParameter("@idBitacora", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idBitacora = CInt(dr("idBitacora"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.ip = dr("ip")
                Me.Modulo = dr("Modulo")
                Me.Bitacora = dr("Bitacora")
                Me.Fecha = CType(dr("Fecha"), DateTime)

                If Not Convert.IsDBNull(dr("idSalonVirtual")) Then
                    Me.idSalonVirtual = CInt(dr("idSalonVirtual"))
                End If

                Me.varexiste = True
            End If
            dr.Close()
        End Sub




        Public Overrides Function Add() As Integer
            Dim querystring As String = "INSERT INTO Bitacoras (idUserProfile, ip, Modulo, Bitacora, Fecha, idSalonVirtual) VALUES (@idUserProfile, @ip, @Modulo, @Bitacora, @Fecha, @idSalonVirtual)"

            Dim parameters As SqlParameter() = {
            New SqlParameter("@idUserProfile", Me.idUserProfile),
            New SqlParameter("@ip", Me.ip),
            New SqlParameter("@Modulo", Me.Modulo),
            New SqlParameter("@Bitacora", Bitacora),
            New SqlParameter("@Fecha", Fecha),
            New SqlParameter("@idSalonVirtual", idSalonVirtual)}
            Me.varexiste = True

            Me.idBitacora = Me.ExecuteNonQuery(querystring, parameters, True)
            Return 1

        End Function

        Public Overrides Function Update() As Integer
            Dim queryString As String = "UPDATE Bitacoras SET idUserProfile=@idUserProfile, ip=@ip, Modulo=@Modulo, Bitacora=@Bitacora, Fecha=@Fecha, idSalonVirtual=@idSalonVirtual WHERE idBitacora= @idBitacora"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idUserProfile", Me.idUserProfile),
             New SqlParameter("@ip", Me.ip),
             New SqlParameter("@Modulo", Me.Modulo),
             New SqlParameter("@Bitacora", Bitacora),
             New SqlParameter("@Fecha", Fecha),
            New SqlParameter("@idBitacora", Me.idBitacora),
            New SqlParameter("@idSalonVirtual", idSalonVirtual)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader

        End Function
        Public Overloads Overrides Function Count() As Integer


        End Function


        Public Overrides Function EnUso() As Boolean
            Return True
        End Function


        Public Overrides Function Remove() As Integer
            Dim queryString As String = "delete Bitacoras  WHERE idBitacora= @idBitacora"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idBitacora", Me.idBitacora)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet

        End Function
        Public Overloads Function GetDS(cantidad As Integer) As DataSet

            Dim sql As String = "select top " & cantidad & "  b.*, u.nombre + ' ' + u.apellidos from bitacoras b,  UserProfiles u where u.idUserProfile=b.idUserProfile order by b.fecha desc"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Overloads Function GetDS(claveAno As Integer, claveMes As Integer, claveTipo As String) As DataSet

            Dim sql As String = "select b.*, u.nombre + ' ' + u.apellidos as Usuario from bitacoras b,  UserProfiles u where u.idUserProfile=b.idUserProfile and year(b.Fecha)=@ano and month(b.Fecha)=@mes  and b.Modulo=@tipo order by b.fecha asc"

            Dim params As SqlParameter() = {New SqlParameter("@ano", claveAno), New SqlParameter("@mes", claveMes), New SqlParameter("@tipo", claveTipo)}

            Return Me.ExecuteDataSet(sql, params)
        End Function

        Public Overloads Function GetDS(claveDia As Integer, claveAno As Integer, claveMes As Integer, claveTipo As String) As DataSet

            Dim sql As String = "select b.*, u.nombre + ' ' + u.apellidos as Usuario from bitacoras b,  UserProfiles u where u.idUserProfile=b.idUserProfile and day(b.fecha)=@dia and year(b.Fecha)=@ano and month(b.Fecha)=@mes  and b.Modulo=@tipo order by b.fecha asc"

            Dim params As SqlParameter() = {New SqlParameter("@dia", claveDia), New SqlParameter("@ano", claveAno), New SqlParameter("@mes", claveMes), New SqlParameter("@tipo", claveTipo)}

            Return Me.ExecuteDataSet(sql, params)
        End Function

        Public Function GetDatosGraficaMensual(claveAno As Integer, claveMes As Integer, claveTipo As String) As DataSet
            Dim sql As String = "select day(b.Fecha) dia, count(b.idBitacora) as NumberOf from Bitacoras b where  year(b.Fecha)=@ano and month(b.Fecha)=@mes  and b.Modulo=@tipo group by  day(b.Fecha)  "

            Dim params As SqlParameter() = {New SqlParameter("@ano", claveAno), New SqlParameter("@mes", claveMes), New SqlParameter("@tipo", claveTipo)}

            Return Me.ExecuteDataSet(sql, params)

        End Function


        Public Function GetBitacoraProyecto(claveSalonVirtual As Integer) As DataSet
            Dim sql As String = "select b.* from bitacoras b where b.idSalonVirtual=@idSalonVirtual order by b.fecha asc"
            Dim params As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(sql, params)
        End Function


    End Class
End Namespace
