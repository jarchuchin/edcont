

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class ContenidoCalificacion
        Inherits DBObject


        Private idContenidoCalificacion As Integer
        Public idProc As Integer
        Public Procedencia As String
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public Calificacion As Integer
        Public Observacion As String
        Public fecha As DateTime
        Public eliminado As Boolean

        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idContenidoCalificacion

            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ContenidoCalificacion
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM [ContenidosCalificaciones] WHERE (" & _
             "[idContenidoCalificacion] = @idContenidoCalificacion)"

            Dim parameters As SqlParameter() = {New SqlParameter("@idContenidoCalificacion", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idContenidoCalificacion = CInt(dr("idContenidoCalificacion"))
                Me.idProc = CInt(dr("idProc"))
                Me.Procedencia = CType(dr("Procedencia"), String)
                Me.idSalonVirtual = CInt(dr("idSalonVirtual"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.Calificacion = CInt(dr("Calificacion"))
                Me.Observacion = CType(dr("Observacion"), String)
                Me.fecha = CType(dr("Fecha"), DateTime)
                Me.eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


        Sub New(ByVal claveSalon As Integer, ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveUsuario As Integer)
            Dim queryString As String = "SELECT * FROM [ContenidosCalificaciones] WHERE (" & _
             "[idUserProfile] = @idUserProfile and idProc=@idProc and Procedencia=@Procedencia and idSalonVirtual=@idSalonVirtual and eliminado=0)"

            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario), _
                                                                        New SqlParameter("@idProc", claveidProc), _
                                                                        New SqlParameter("@Procedencia", claveProcedencia), _
                                                                        New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idContenidoCalificacion = CInt(dr("idContenidoCalificacion"))
                Me.idProc = CInt(dr("idProc"))
                Me.Procedencia = CType(dr("Procedencia"), String)
                Me.idSalonVirtual = CInt(dr("idSalonVirtual"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.Calificacion = CInt(dr("Calificacion"))
                Me.Observacion = CType(dr("Observacion"), String)
                Me.fecha = CType(dr("Fecha"), DateTime)
                Me.eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub




        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [ContenidosCalificaciones] ([idProc], [Procedencia], [idSalonVirtual], idUserProfile, Calificacion, Observacion, fecha, eliminado) VALUES (@" & _
                 "idProc, @Procedencia, @idSalonVirtual, @idUserProfile, @Calificacion, @Observacion, @fecha, @eliminado)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idProc", Me.idProc), _
                  New SqlParameter("@Procedencia", Me.Procedencia), _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@Calificacion", Me.Calificacion), _
                  New SqlParameter("@Observacion", Me.Observacion), _
                  New SqlParameter("@Fecha", Me.fecha), _
                  New SqlParameter("@Eliminado", Me.eliminado)}


                
                Me.idContenidoCalificacion = Me.ExecuteNonQuery(queryString, parametros, True)




            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [ContenidosCalificaciones] SET [idProc]=@idproc, procedencia=@procedencia, " & _
                 "[idSalonVirtual]=@idSalonVirtual, [idUserProfile]=@idUserProfile, Calificacion=@Calificacion, Observacion=@Observacion, Fecha=@Fecha, Eliminado=@Eliminado WHERE idContenidoCalificacion = @idContenidoCalificacion"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idProc", Me.idProc), _
                   New SqlParameter("@Procedencia", Me.Procedencia), _
                   New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                   New SqlParameter("@idUserProfile", Me.idUserProfile), _
                   New SqlParameter("@Calificacion", Me.Calificacion), _
                   New SqlParameter("@Observacion", Me.Observacion), _
                   New SqlParameter("@Fecha", Me.fecha), _
                   New SqlParameter("@Eliminado", Me.eliminado), _
                   New SqlParameter("@idContenidoCalificacion", Me.idContenidoCalificacion)}


                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try

        End Function

        Public Overrides Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

     

        

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

    

        Public Overloads Function GetDS(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer) As DataSet
            Dim queryString As String = "SELECT ca.*, u.nombre + ' ' + u.apellidos as nombre FROM ContenidosCalificaciones ca, UserProfiles u " & _
     "WHERE  u.idUserProfile=ca.idUserProfile AND ca.idProc = @idProc AND ca.Procedencia = @Procedencia AND ca.idSalonVirtual= @idSalonVirtual and ca.eliminado=0"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idProc", claveidProc), _
             New SqlParameter("@Procedencia", claveProcedencia), _
             New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

     

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function count(ByVal claveSalon As Integer, ByVal claveUsuario As Integer) As Integer
            Dim mysql As String = "select count(idContenidoCalificacion) as num from contenidoscalificaciones where   idSalonVirtual= @idSalonVirtual and idUserProfile=@idUserProfile and eliminado=0"
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function


        Public Function GetPromedio(ByVal claveidProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer) As Decimal
            Dim mysql As String = "select avg(calificacion) as num from contenidoscalificaciones where  idProc = @idProc AND Procedencia = @Procedencia AND idSalonVirtual= @idSalonVirtual and eliminado=0"
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idProc", claveidProc), _
            New SqlParameter("@Procedencia", claveProcedencia), _
            New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, parametros)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function


        Public Function GetPromedio(ByVal claveSalon As Integer) As Decimal
            Dim mysql As String = "select avg(calificacion) as num from contenidoscalificaciones where   idSalonVirtual= @idSalonVirtual and eliminado=0"
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, parametros)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function

        Public Function GetPromedio(ByVal claveSalon As Integer, ByVal claveUsuario As Integer) As Decimal
            Dim mysql As String = "select avg(calificacion) as num from contenidoscalificaciones where   idSalonVirtual= @idSalonVirtual and idUserProfile=@idUserProfile and eliminado=0"
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, parametros)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function



        Public Overrides Function EnUso() As Boolean
            Return True
        End Function






    End Class
End Namespace
