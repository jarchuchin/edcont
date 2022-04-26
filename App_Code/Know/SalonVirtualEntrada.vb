

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class SalonVirtualEntrada
        Inherits DBObject

#Region "Variables"
        Private idSalonVirtualEntrada As Integer
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public SessionId As String
        Public Fecha As DateTime
        Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualEntrada
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
            Dim queryString As String = "SELECT * FROM SalonesVirtualesEntradas WHERE idSalonVirtualEntrada = @idSalonVirtualEntrada"
            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualEntrada", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualEntrada = CType(dr("idSalonVirtualEntrada"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.SessionId = CType(dr("SessionId"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveSalon As Integer, ByVal claveUsuario As Integer, ByVal claveSession As String)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesEntradas WHERE idSalonVirtual = @idSalonVirtual  and  idUserprofile=@idUserProfile and SessionID=@SessionID"
            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idUserProfile", claveUsuario), New SqlParameter("@SessionID", claveSession)}
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualEntrada = CType(dr("idSalonVirtualEntrada"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.SessionId = CType(dr("SessionId"), String)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


#End Region

#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [SalonesVirtualesEntradas] (idSalonVirtual, idUserProfile, SessionID, Fecha) VALUES (@idSalonVirtual, @idUserProfile, @SessionID, @Fecha)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@SessionID", Me.SessionId), _
                  New SqlParameter("@Fecha", Me.Fecha)}


                Dim mysve As SalonVirtualEntrada = New SalonVirtualEntrada(Me.idSalonVirtual, Me.idUserProfile, Me.SessionId)
                If Not mysve.existe Then
                    Me.idSalonVirtualEntrada = Me.ExecuteNonQuery(queryString, parametros, True)
                End If

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE SalonesVirtualesEntradas SET idSalonVirtual=@idSalonVirtual, idUserProfile=@idUserProfile, SessionID=@SessionID, Fecha=@Fecha WHERE idSalonVirtualEntrada = @idSalonVirtualEntrada"

                Dim parametros As SqlParameter() = { _
                New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                New SqlParameter("@idUserProfile", Me.idUserProfile), _
                New SqlParameter("@SessionID", Me.SessionId), _
                New SqlParameter("@Fecha", Me.Fecha), _
                New SqlParameter("@idSalonVirtualEntrada", Me.idSalonVirtualEntrada)}



                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM SalonesVirtualesEntradas WHERE idSalonVirtualEntrada = @idSalonVirtualEntrada "
            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtualEntrada", Me.idSalonVirtualEntrada)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtualesEntradas"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT sve.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
              "AND sve.idSalonVirtual = @idSalonVirtual and sve.idUserProfile = @idUserProfile order by sve.Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT sve.*, u.nombre + ' ' + u.apellidos as nombre, u.login " & _
             "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
              "AND sve.idSalonVirtual = @idSalonVirtual order by sve.Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteReader(queryString, parametros)

        End Function



        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtualesPreguntas"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As DataSet
            Dim queryString As String = "SELECT sve.*, u.apellidos + ' ' + u.nombre as nombre, u.login " & _
      "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
       "AND sve.idSalonVirtual = @idSalonVirtual and sve.idUserProfile = @idUserProfile order by sve.Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUsuario)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer) As DataSet
            Dim queryString As String = "SELECT sve.*, u.apellidos + ' ' + u.nombre as nombre, u.login " & _
            "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
             "AND sve.idSalonVirtual = @idSalonVirtual order by sve.Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Overloads Function GetDSTOP(ByVal claveSalonVirtual As Integer, ByVal numero As Integer) As DataSet
            Dim queryString As String = "SELECT  top " & numero & " sve.*, u.apellidos + ' ' + u.nombre as nombre, u.login " & _
            "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
             "AND sve.idSalonVirtual = @idSalonVirtual order by sve.Fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Overloads Function GetDSUsuarios(ByVal claveSalonVirtual As Integer) As DataSet
            Dim queryString As String = "SELECT  distinct sve.idUserProfile, u.apellidos + ' ' + u.nombre as nombre " & _
            "FROM SalonesVirtualesEntradas sve, UserProfiles u WHERE u.idUserProfile = sve.idUserProfile " & _
             "AND sve.idSalonVirtual = @idSalonVirtual order by nombre asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function



        Public Overrides Function Count() As Integer
            Return Me.GetDS(Me.idSalonVirtual).Tables(0).Rows.Count
        End Function
        Public Function CountUsuario() As Integer
            Return Me.GetDS(Me.idSalonVirtual, Me.idUserProfile).Tables(0).Rows.Count
        End Function

        Public Overloads Function Count(ByVal clavesalon As Integer, ByVal claveFecha As Date) As Integer
            Dim mysql As String = "select count(sve.idSalonVirtualEntrada) as num from salonesvirtualesentradas sve  where day(fecha) = " & claveFecha.Day & " and month(fecha) = " & claveFecha.Month & " and year(fecha) = " & claveFecha.Year & " and idSalonVirtual=" & clavesalon
            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, Nothing)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function


        Public Function CountSemana(ByVal claveSalon As Integer, ByVal claveFecha As Date) As Integer

            Dim nowdayofweek As Integer = claveFecha.DayOfWeek
            Dim fechaInicio, fechaFin As DateTime
            fechaInicio = DateAdd("d", 0 - claveFecha.DayOfWeek, claveFecha)
            fechaFin = DateAdd("d", 6 - claveFecha.DayOfWeek, claveFecha)

            Dim mysql As String = "select count(sve.idSalonVirtualEntrada) as num from salonesvirtualesentradas sve where fecha >= @fechaInicio and fecha <= @fechafin" & " and idSalonVirtual=" & claveSalon
            Dim params As SqlParameter() = {New SqlParameter("@fechaInicio", fechaInicio), New SqlParameter("@fechaFin", fechaFin)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, params)
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




#End Region
    End Class
End Namespace

