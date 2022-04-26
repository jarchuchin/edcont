Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
	Public NotInheritable Class SalonVirtual
		Inherits DBObject


        Private idSalonVirtual As Integer
        Public root As Lego.Root
        Public idEmpresa As Integer
        Public idUserProfile As Integer
        Public idRoot As Integer
        Public nombre As String
        Public fechaInicio As Date
        Public fechaFin As Date
        Public horarioAtencion As String
        Public calificacionMaxima As Integer
        Public status As Boolean
        Public claveAux1 As String
        Public claveAux2 As String
        Public bbmeetingID As String = ""
        Public bbmoderatorPW As String = ""
        Public bbattendeePW As String = ""
        Public permitirVerExamenes As Boolean = False

        Public sincronizado As Boolean = False
        Public sincronizadoFecha As DateTime = CDate("1/1/2001")

        Public LigaSalonVirtual As String = ""

        Public calendarID As String = ""
        Public fileDisplay As String = ""
        Public videoDisplay As String = ""
        Public embeddedDisplay As String = ""

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtual
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVirtual
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE idSalonVirtual = @idSalonVirtual"

            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtual", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                If crearSubObjetos Then
                    Me.root = New Lego.Root(CType(dr("idRoot"), Integer))
                End If
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.nombre = CType(dr("nombre"), String)
                Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Me.fechaFin = CType(dr("fechafin"), Date)
                Me.horarioAtencion = CType(dr("horarioAtencion"), String)
                Me.calificacionMaxima = CType(dr("calificacionMaxima"), Integer)
                Me.status = CType(dr("status"), Boolean)
                Me.claveAux1 = CType(dr("claveAux1"), String)
                Me.claveAux2 = CType(dr("claveAux2"), String)

                If Not Convert.IsDBNull(dr("bbmeetingID")) Then
                    Me.bbmeetingID = dr("bbmeetingID")
                Else
                    Me.bbmeetingID = ""
                End If
                If Not Convert.IsDBNull(dr("bbmoderatorPW")) Then
                    Me.bbmoderatorPW = dr("bbmoderatorPW")
                Else
                    Me.bbmoderatorPW = ""
                End If
                If Not Convert.IsDBNull(dr("bbattendeePW")) Then
                    Me.bbattendeePW = dr("bbattendeePW")
                Else
                    Me.bbattendeePW = ""
                End If
                If Not Convert.IsDBNull(dr("calendarID")) Then
                    Me.calendarID = dr("calendarID")
                Else
                    Me.calendarID = ""
                End If
                If Not Convert.IsDBNull(dr("permitirVerExamenes")) Then
                    Me.permitirVerExamenes = dr("permitirVerExamenes")
                End If

                If Not Convert.IsDBNull(dr("sincronizado")) Then
                    Me.sincronizado = dr("sincronizado")
                End If
                If Not Convert.IsDBNull(dr("sincronizadoFecha")) Then
                    Me.sincronizadoFecha = CDate(dr("sincronizadoFecha"))
                End If
                If Not Convert.IsDBNull(dr("LigaSalonVirtual")) Then
                    Me.LigaSalonVirtual = CStr(dr("LigaSalonVirtual"))
                End If
                If Not Convert.IsDBNull(dr("fileDisplay")) Then
                    Me.fileDisplay = CStr(dr("fileDisplay"))
                End If
                If Not Convert.IsDBNull(dr("videoDisplay")) Then
                    Me.videoDisplay = CStr(dr("videoDisplay"))
                End If
                If Not Convert.IsDBNull(dr("embeddedDisplay")) Then
                    Me.embeddedDisplay = CStr(dr("embeddedDisplay"))
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal varClaveAux1 As String, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE claveAux1 = @claveAux1"

            If varClaveAux1 <> "" Then


                Dim parameters As SqlParameter() = {New SqlParameter("@claveAux1", varClaveAux1)}

                Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
                If dr.Read Then
                    Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                    Me.idEmpresa = CType(dr("idEmpresa"), Integer)
                    Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                    If crearSubObjetos Then
                        Me.root = New Lego.Root(CType(dr("idRoot"), Integer))
                    End If
                    Me.idRoot = CType(dr("idRoot"), Integer)
                    Me.nombre = CType(dr("nombre"), String)
                    Me.fechaInicio = CType(dr("fechaInicio"), Date)
                    Me.fechaFin = CType(dr("fechafin"), Date)
                    Me.horarioAtencion = CType(dr("horarioAtencion"), String)
                    Me.calificacionMaxima = CType(dr("calificacionMaxima"), Integer)
                    Me.status = CType(dr("status"), Boolean)
                    Me.claveAux1 = CType(dr("claveAux1"), String)
                    Me.claveAux2 = CType(dr("claveAux2"), String)



                    If Not Convert.IsDBNull(dr("bbmeetingID")) Then
                        Me.bbmeetingID = dr("bbmeetingID")
                    Else
                        Me.bbmeetingID = ""
                    End If
                    If Not Convert.IsDBNull(dr("bbmoderatorPW")) Then
                        Me.bbmoderatorPW = dr("bbmoderatorPW")
                    Else
                        Me.bbmoderatorPW = ""
                    End If
                    If Not Convert.IsDBNull(dr("bbattendeePW")) Then
                        Me.bbattendeePW = dr("bbattendeePW")
                    Else
                        Me.bbattendeePW = ""
                    End If
                    If Not Convert.IsDBNull(dr("calendarID")) Then
                        Me.calendarID = dr("calendarID")
                    Else
                        Me.calendarID = ""
                    End If
                    If Not Convert.IsDBNull(dr("permitirVerExamenes")) Then
                        Me.permitirVerExamenes = dr("permitirVerExamenes")
                    End If


                    If Not Convert.IsDBNull(dr("sincronizado")) Then
                        Me.sincronizado = dr("sincronizado")
                    End If
                    If Not Convert.IsDBNull(dr("sincronizadoFecha")) Then
                        Me.sincronizadoFecha = CDate(dr("sincronizadoFecha"))
                    End If
                    If Not Convert.IsDBNull(dr("LigaSalonVirtual")) Then
                        Me.LigaSalonVirtual = CStr(dr("LigaSalonVirtual"))
                    End If
                    If Not Convert.IsDBNull(dr("fileDisplay")) Then
                        Me.fileDisplay = CStr(dr("fileDisplay"))
                    End If
                    If Not Convert.IsDBNull(dr("videoDisplay")) Then
                        Me.videoDisplay = CStr(dr("videoDisplay"))
                    End If
                    If Not Convert.IsDBNull(dr("embeddedDisplay")) Then
                        Me.embeddedDisplay = CStr(dr("embeddedDisplay"))
                    End If

                    Me.varExiste = True
                End If
                dr.Close()

            End If
        End Sub



        Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [SalonesVirtuales] ([idEmpresa], [idUserProfile], [idRoot], [nombre],[fechaInicio], [fechaFin], [horarioAtencion], [calificacionMaxima], [status], [claveAux1], [claveAux2], bbmeetingID, bbmoderatorPW, bbattendeePW, calendarID, permitirVerExamenes, sincronizado, sincronizadoFecha, LigaSalonVirtual, fileDisplay, embeddedDisplay, videoDisplay) VALUES (@idEmpresa, @idUserProfile, @idRoot, @nombre, @fechaInicio, @fechaFin, @horarioAtencion, @calificacionMaxima, @status, @claveAux1, @claveAux2, @bbmeetingID, @bbmoderatorPW, @bbattendeePW, @calendarID,  @permitirVerExamenes, @sincronizado, @sincronizadoFecha, @LigaSalonVirtual, @fileDisplay, @embeddedDisplay, @videoDisplay)"

            Dim parametros As SqlParameter() = {
              New SqlParameter("@idEmpresa", Me.idEmpresa),
              New SqlParameter("@idUserProfile", Me.idUserProfile),
              New SqlParameter("@idRoot", Me.idRoot),
              New SqlParameter("@nombre", Me.nombre),
              New SqlParameter("@fechaInicio", Me.fechaInicio),
              New SqlParameter("@fechaFin", Me.fechaFin),
              New SqlParameter("@horarioAtencion", Me.horarioAtencion),
              New SqlParameter("@calificacionMaxima", Me.calificacionMaxima),
              New SqlParameter("@status", Me.status),
              New SqlParameter("@claveAux1", Me.claveAux1),
              New SqlParameter("@claveAux2", Me.claveAux2),
              New SqlParameter("@bbmeetingID", Me.bbmeetingID),
              New SqlParameter("@bbmoderatorPW", Me.bbmoderatorPW),
              New SqlParameter("@bbattendeePW", Me.bbattendeePW),
              New SqlParameter("@calendarID", Me.calendarID),
              New SqlParameter("@permitirVerExamenes", Me.permitirVerExamenes),
              New SqlParameter("@sincronizado", Me.sincronizado),
              New SqlParameter("@sincronizadoFecha", Date.Now),
              New SqlParameter("@LigaSalonVirtual", Me.LigaSalonVirtual),
              New SqlParameter("@fileDisplay", Me.fileDisplay),
              New SqlParameter("@videoDisplay", Me.videoDisplay),
              New SqlParameter("@embeddedDisplay", Me.embeddedDisplay)}

            Me.idSalonVirtual = Me.ExecuteNonQuery(queryString, parametros, True)

            'asignando permiso por default
            Dim user As New MasUsuarios.UserProfile(Me.idUserProfile, False)
            Dim mypermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso
            mypermiso.permisoA = user.tipo
            mypermiso.idPermisoA = user.id
            mypermiso.recurso = Me.tipo
            mypermiso.idRecurso = Me.id
            mypermiso.PRoots = True
            mypermiso.PPermisosRoots = True
            mypermiso.PCategorias = True
            mypermiso.PRespuestas = True
            mypermiso.PEvaluacion = True
            mypermiso.PSalonVirtual = True
            mypermiso.PContenidos = True
            mypermiso.PInterfaceGrafica = True
            mypermiso.PEstadisticas = True
            mypermiso.PAdministracion = True
            mypermiso.Add()

            '	Catch ex As Exception
            'Dim m As String = ex.Message
            '       End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [SalonesVirtuales] SET [idEmpresa]=@IdEmpresa, [idUserProfile]=@IdUserProfile, " &
                 "[idRoot]=@idRoot, [nombre]=@nombre, [fechaInicio]=@fechaInicio, [fechaFin]=@fechaFin, " &
                 "[horarioAtencion]=@horarioAtencion, [calificacionMaxima]=@calificacionMaxima, [status]=@status, [claveAux1]=@claveAux1, " &
                 "[claveAux2]=@claveAux2, bbmeetingID=@bbmeetingID, bbmoderatorPW=@bbmoderatorPW, bbattendeePW=@bbattendeePW, calendarID=@calendarID, permitirVerExamenes=@permitirVerExamenes, sincronizado=@sincronizado, sincronizadoFecha=@sincronizadoFecha, LigaSalonVirtual=@LigaSalonVirtual, fileDisplay=@fileDisplay, embeddedDisplay=@embeddedDisplay, videoDisplay=@videoDisplay WHERE idSalonVirtual = @idSalonVirtual"



            Dim parametros As SqlParameter() = {
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
                  New SqlParameter("@idEmpresa", Me.idEmpresa),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@idRoot", Me.idRoot),
                  New SqlParameter("@nombre", Me.nombre),
                  New SqlParameter("@fechaInicio", Me.fechaInicio),
                  New SqlParameter("@fechaFin", Me.fechaFin),
                  New SqlParameter("@horarioAtencion", Me.horarioAtencion),
                  New SqlParameter("@calificacionMaxima", Me.calificacionMaxima),
                  New SqlParameter("@status", Me.status),
                  New SqlParameter("@claveAux1", Me.claveAux1),
                  New SqlParameter("@claveAux2", Me.claveAux2),
              New SqlParameter("@bbmeetingID", Me.bbmeetingID),
              New SqlParameter("@bbmoderatorPW", Me.bbmoderatorPW),
              New SqlParameter("@bbattendeePW", Me.bbattendeePW),
              New SqlParameter("@calendarID", Me.calendarID),
              New SqlParameter("@permitirVerExamenes", Me.permitirVerExamenes),
              New SqlParameter("@sincronizado", Me.sincronizado),
              New SqlParameter("@sincronizadoFecha", Me.sincronizadoFecha),
              New SqlParameter("@LigaSalonVirtual", Me.LigaSalonVirtual),
              New SqlParameter("@videoDisplay", Me.videoDisplay),
              New SqlParameter("@fileDisplay", Me.fileDisplay),
              New SqlParameter("@embeddedDisplay", Me.embeddedDisplay)}

            Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM SalonesVirtuales WHERE idSalonVirtual = @idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", Me.idSalonVirtual)}

            Dim rowsAffected As Integer = Me.ExecuteNonQuery(queryString, parametros)

            Dim mypermiso As New MasUsuarios.Permiso
            mypermiso.Remove(Me)
            Dim myAsistencia As New Asistencia
            myAsistencia.Remove(Me.idSalonVirtual)

            Return rowsAffected
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtuales"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal objRoot As Lego.Root) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE idRoot = @idRoot ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", objRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveUser As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT s.* FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
    "AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
     "ORDER BY s.fechaInicio DESC, s.nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveUser As Integer, ByVal claveStatus As Boolean) As System.Data.IDataReader
            Dim queryString As String = "SELECT s.*, " & _
            " (select count(svu.idSalonVirtualUserProfile) from salonvirtualUserProfile svu where svu.idSalonVirtual=s.idSalonVirtual)  as numAlumnos,  " & _
            " (select count(r.idRespuesta)  from Respuestas r  where r.procedencia = 'Actividad' and r.idRaiz = 0  and r.status = 1  and r.idSalonVirtual=s.idSalonVirtual) as ActividadeSinRevisar  " & _
        " FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
    "AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
    "AND s.status = @status ORDER BY s.fechaInicio DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@status", claveStatus)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function


        Public Overloads Function GetDS(ByVal claveUser As Integer, ByVal claveStatus As Boolean, ByVal numeroRegistros As Integer) As DataSet
            Dim queryString As String = "SELECT top " & numeroRegistros & " s.*, " & _
            " (select count(svu.idSalonVirtualUserProfile) from salonvirtualUserProfile svu where svu.idSalonVirtual=s.idSalonVirtual)  as numAlumnos,  " & _
            " (select count(r.idRespuesta)  from Respuestas r  where r.procedencia = 'Actividad' and r.idRaiz = 0  and r.status = 1  and r.idSalonVirtual=s.idSalonVirtual) as ActividadeSinRevisar  " & _
        " FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
    "AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
    "AND s.status = @status ORDER BY s.fechaInicio DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@status", claveStatus)}

            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Overloads Function GetDSBuscar(ByVal claveUser As Integer, claveBuscar As String) As DataSet
            Dim queryString As String = "SELECT  s.*, " & _
            " (select count(svu.idSalonVirtualUserProfile) from salonvirtualUserProfile svu where svu.idSalonVirtual=s.idSalonVirtual)  as numAlumnos,  " & _
            " (select count(r.idRespuesta)  from Respuestas r  where r.procedencia = 'Actividad' and r.idRaiz = 0  and r.status = 1  and r.idSalonVirtual=s.idSalonVirtual) as ActividadeSinRevisar  " & _
        " FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
    "AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
    "AND s.Nombre + ' ' + s.claveAux1 like '%" & claveBuscar & "%' COLLATE Modern_Spanish_CI_AI ORDER BY s.nombre, s.fechaInicio"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

            Return Me.ExecuteDataSet(queryString, parametros)

        End Function

        Public Overloads Function GetDR(ByVal claveEmpresa As Integer, ByVal clavePalabra As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE idEmpresa = @idEmpresa " & _
            "AND nombre like @nombre ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@nombre", "%" & clavePalabra & "%")}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtuales"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal objRoot As Lego.Root) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE idRoot = @idRoot ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", objRoot)}

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveUser As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT s.* FROM SalonesVirtuales s, Permisos p1 WHERE p1.idPermisoA = @idUserProfile " & _
    "AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' " & _
     "ORDER BY s.fechaInicio DESC, s.nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveEmpresa As Integer, ByVal clavePalabra As String) As System.Data.DataSet
            Dim queryString As String = "SELECT sv.*, (select count(svup.idSalonVirtualUserProfile) from SalonVirtualUserProfile svup where svup.idSalonVirtual=sv.idSalonVirtual and (svup.[Status]='I' or svup.[Status] = 'C') ) as Alumnos, (select avg(svup.CalificacionComputada) from SalonVirtualUserProfile svup where svup.idSalonVirtual=sv.idSalonVirtual and (svup.[Status]='I' or svup.[Status] = 'C') ) as CalificacionPromedio FROM SalonesVirtuales  sv WHERE sv.idEmpresa = @idEmpresa " &
            "AND (sv.nombre like @nombre or sv.claveAux1 like @nombre)  ORDER BY sv.nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idEmpresa", claveEmpresa), New SqlParameter("@nombre", "%" & clavePalabra & "%")}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idSalonVirtual) as num FROM SalonesVirtuales"

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

        Public Overloads Function Count(ByVal myidRoot As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(*) as num FROM SalonesVirtuales WHERE idRoot = @idRoot"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", myidRoot)}

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


        Public Overloads Function Count(ByVal myuser As MasUsuarios.UserProfile) As Integer
            Dim queryString As String = "SELECT COUNT(*) as num FROM SalonesVirtuales WHERE idUserProfile = @idUserProfile"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", myuser.id)}

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


        Public Overloads Function Count(ByVal claveUsuario As Integer, ByVal claveSalon As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(*) as num FROM SalonesVirtuales WHERE idUserProfile = @idUserProfile"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

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
            Return True
        End Function

        Function ExistenElementos(ByVal objRoot As Lego.Root) As Boolean
            Dim bandera As Boolean = False
            Dim dr As SqlDataReader = Me.GetDR(objRoot)
            bandera = dr.HasRows
            dr.Close()

            Return bandera
        End Function

        Public Function GetSalonesConRoot() As Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE idRoot > 0 AND claveAux1 <> ''"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        '++++++++++REVISAR+++++++++++++
        Public Function GetSalonesFiltro(ByVal varClaveAux1 As String()) As Data.SqlClient.SqlDataReader
            'Dim queryString As String = "SELECT * FROM SalonesVirtuales WHERE claveAux1 = '05061A-0286' " & _
            ' "OR claveAux1 = '05061A-0272' OR claveAux1 = '05061A-0930'"

            If varClaveAux1.Length > 0 Then
                Dim enumerador As IEnumerator = varClaveAux1.GetEnumerator
                Dim queryString As String

                enumerador.MoveNext()
                queryString = "SELECT * FROM SalonesVirtuales WHERE '" & enumerador.Current.ToString & "'"

                Do While enumerador.MoveNext
                    queryString = queryString & " OR claveAux1 = '" & enumerador.Current.ToString & "'"
                Loop

                Return Me.ExecuteReader(queryString, Nothing)
            Else
                Return Nothing
            End If
        End Function



	End Class
End Namespace

