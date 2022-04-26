Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class SalonVirtualCompartido
        Inherits DBObject


        Private idSalonVirtualCompartido As Integer
        Public idSalonVirtualPrincipal As Integer
        Public idSalonVirtualSecundario As Integer
     

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualCompartido
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVirtualCompartido
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCompartidos WHERE idSalonVirtualCompartido = @idSalonVirtualCompartido"

            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualCompartido", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualCompartido = CInt(dr("idSalonVirtualCompartido"))
                Me.idSalonVirtualPrincipal = CInt(dr("idSalonVirtualPrincipal"))
                Me.idSalonVirtualSecundario = CInt(dr("idSalonVirtualSecundario"))
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal claveSecundaria As Integer)
            Dim queryString As String = "SELECT * FROM SalonesVirtualesCompartidos WHERE idSalonVirtualCompartido = @idSalonVirtualCompartido"

            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualCompartido", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualCompartido = CInt(dr("idSalonVirtualCompartido"))
                Me.idSalonVirtualPrincipal = CInt(dr("idSalonVirtualPrincipal"))
                Me.idSalonVirtualSecundario = CInt(dr("idSalonVirtualSecundario"))
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


        Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [SalonesVirtualesCompartidos] ([idSalonVirtualPrincipal], [idSalonVirtualSecundario]) VALUES (@idSalonVirtualPrincipal, @idSalonVirtualSecundario)"

            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idSalonVirtualPrincipal", Me.idSalonVirtualPrincipal), _
              New SqlParameter("@idSalonVirtualSecundario", Me.idSalonVirtualSecundario)}


            Dim mysvtemp As New Know.SalonVirtualCompartido(Me.idSalonVirtualPrincipal, Me.idSalonVirtualSecundario)
            If Not mysvtemp.existe Then
                Me.idSalonVirtualCompartido = Me.ExecuteNonQuery(queryString, parametros, True)
            Else
                Me.idSalonVirtualCompartido = 0
            End If



          
            Return 1
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [SalonesVirtualesCompartidos] SET [idSalonVirtualPrincipal]=@idSalonVirtualPrincipal, [idSalonVirtualSecundario]=@idSalonVirtualSecundario WHERE idSalonVirtualCompartido = @idSalonVirtualCompartido"

                Dim parametros As SqlParameter() = { _
           New SqlParameter("@idSalonVirtualPrincipal", Me.idSalonVirtualPrincipal), _
           New SqlParameter("@idSalonVirtualSecundario", Me.idSalonVirtualSecundario), _
              New SqlParameter("@idSalonVirtualCompartido", Me.idSalonVirtualCompartido)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM SalonesVirtualesCompartidos WHERE idSalonVirtualCompartido = @idSalonVirtualCompartido"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtualCompartido", Me.idSalonVirtualCompartido)}

            Dim rowsAffected As Integer = Me.ExecuteNonQuery(queryString, parametros)

          
            Return rowsAffected
        End Function




        Public Overrides Function getDR() As SqlDataReader
        
        End Function

        Public Overloads Function getDRSalonesDisponibles(ByVal usuario As Integer, ByVal salon As Integer) As SqlDataReader
            Dim queryString As String = "SELECT s.*, " & _
                        " (select count(svu.idSalonVirtualUserProfile) from salonvirtualUserProfile svu where svu.idSalonVirtual=s.idSalonVirtual)  as numAlumnos,  " & _
            " (select count(r.idRespuesta)  from Respuestas r  where r.procedencia = 'Actividad' and r.idRaiz = 0  and r.status = 1  and r.idSalonVirtual=s.idSalonVirtual) as ActividadeSinRevisar  " & _
" FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
" AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
" and s.idSalonVirtual not in (select idSalonVirtualSecundario from salonesvirtualesCompartidos ) and s.idsalonvirtual<>@salon" & _
" ORDER BY s.fechaInicio DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", usuario), New SqlParameter("@salon", salon)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function getDRSalonesComparrtidos(ByVal claveSalon As Integer) As SqlDataReader
            Dim sql As String = "select s.*, sc.* from salonesvirtuales s, salonesvirtualescompartidos sc where s.idSalonVirtual=sc.idSalonVirtualSecundario and  sc.idSalonVirtualPrincipal=@idSalonvirtual ORDER BY s.fechaInicio DESC"
            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonvirtual", claveSalon)}

            Return Me.ExecuteReader(sql, parametros)
        End Function

        Public Overloads Function estaCompartido(ByVal claveSalon As Integer) As Boolean
            Dim sql As String = "select * from salonesVirtualescompartidos sc where idSalonVirtualSecundario=@idSalonVirtual"

            Dim params As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Boolean = False
            If dr.Read Then
                regreso = True
            End If
            dr.Close()
            Return regreso


        End Function

        Public Overloads Function getSalonPrincipal(ByVal claveSalon As Integer) As Integer
            Dim sql As String = "select * from salonesVirtualescompartidos sc where idSalonVirtualSecundario=@idSalonVirtual"

            Dim params As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Integer = 0
            If dr.Read Then
                regreso = CInt(dr("idSalonVirtualPrincipal"))
            End If
            dr.Close()
            Return regreso


        End Function


        Public Overrides Function GetDS() As System.Data.DataSet

        End Function


        Public Overrides Function Count() As Integer

        End Function


        Public Overrides Function EnUso() As Boolean

        End Function
    End Class
End Namespace

