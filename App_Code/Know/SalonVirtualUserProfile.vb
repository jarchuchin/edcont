Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
	Public NotInheritable Class SalonVirtualUserProfile
		Inherits DBObject


        Private idSalonVirtualUserProfile As Integer
        Public salonVirtual As SalonVirtual
        Public idSalonVirtual As Integer
        Public idUserProfile As Integer
        Public idUserProfileCalificador As Integer
        Public status As String
        Public fechaInicio As Date
        Public fechaFin As Date
        Public calificacion As Integer
        Public calificacionComputada As Integer
        Public puntosExtras As Integer
        Public calificacionDiferida As Boolean = False
        Public fechaConvenio As DateTime = Date.Now

        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idSalonVirtualUserProfile
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.SalonVirtualUserProfile
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM SalonVirtualUserProfile WHERE idSalonVirtualUserProfile = @idSalonVirtualUserProfile"

            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtualUserProfile", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualUserProfile = CType(dr("idSalonVirtualUserProfile"), Integer)
                If crearSubObjetos Then
                    Me.salonVirtual = New SalonVirtual(CType(dr("idSalonVirtual"), Integer), False)
                End If
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.status = CType(dr("status"), String)
                Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Me.fechaFin = CType(dr("fechafin"), Date)
                Me.calificacion = CType(dr("calificacion"), Integer)
                Me.calificacionComputada = CType(dr("calificacionComputada"), Integer)
                Me.idUserProfileCalificador = CType(dr("idUserProfileCalificador"), Integer)
                Me.puntosExtras = CType(dr("puntosExtras"), Integer)
                If Not Convert.IsDBNull(dr("calificacionDiferida")) Then
                    Me.calificacionDiferida = CType(dr("calificacionDiferida"), Boolean)
                Else
                    Me.calificacionDiferida = False
                End If
                If Not Convert.IsDBNull(dr("fechaConvenio")) Then
                    Me.fechaConvenio = CType(dr("fechaConvenio"), DateTime)
                Else
                    Me.fechaConvenio = Date.Now
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveUser As Integer, ByVal claveSalon As Integer, ByVal crearSubObjetos As Boolean)
            Dim queryString As String = "SELECT * FROM SalonVirtualUserProfile WHERE idUserProfile = @idUserProfile AND idSalonVirtual = @idSalonVirtual"

            Dim parameters As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idSalonVirtualUserProfile = CType(dr("idSalonVirtualUserProfile"), Integer)
                If crearSubObjetos Then
                    Me.salonVirtual = New Know.SalonVirtual(CType(dr("idSalonVirtual"), Integer), False)
                End If
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.status = CType(dr("status"), String)
                Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Me.fechaFin = CType(dr("fechafin"), Date)
                Me.calificacion = CType(dr("calificacion"), Integer)
                Me.calificacionComputada = CType(dr("calificacionComputada"), Integer)
                Me.idUserProfileCalificador = CType(dr("idUserProfileCalificador"), Integer)
                Me.puntosExtras = CType(dr("puntosExtras"), Integer)
                If Not Convert.IsDBNull(dr("calificacionDiferida")) Then
                    Me.calificacionDiferida = CType(dr("calificacionDiferida"), Boolean)
                Else
                    Me.calificacionDiferida = False
                End If
                If Not Convert.IsDBNull(dr("fechaConvenio")) Then
                    Me.fechaConvenio = CType(dr("fechaConvenio"), DateTime)
                Else
                    Me.fechaConvenio = Date.Now
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


        Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [SalonVirtualUserProfile] ([idSalonVirtual], [idUserProfile], [status], " & _
             "[fechaInicio], [fechaFin], [calificacion], [calificacionComputada], [idUserProfileCalificador], [puntosExtras], " & _
             "[calificacionDiferida], [fechaConvenio]) VALUES (@idSalonVirtual, @idUserProfile, @Status, @fechaInicio, " & _
             "@fechaFin, @calificacion, @calificacionComputada, @idUserProfileCalificador, @puntosExtras, " & _
             "@calificacionDiferida, @fechaConvenio)"

            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
              New SqlParameter("@idUserProfile", Me.idUserProfile), _
              New SqlParameter("@Status", Me.status), _
              New SqlParameter("@fechaInicio", Me.fechaInicio), _
              New SqlParameter("@fechaFin", Me.fechaFin), _
              New SqlParameter("@calificacion", Me.calificacion), _
              New SqlParameter("@calificacionComputada", Me.calificacionComputada), _
              New SqlParameter("@idUserProfileCalificador", Me.idUserProfileCalificador), _
              New SqlParameter("@puntosExtras", Me.puntosExtras), _
              New SqlParameter("@calificacionDiferida", Me.calificacionDiferida), _
              New SqlParameter("@fechaConvenio", Me.fechaConvenio)}

            Dim mySVU As New SalonVirtualUserProfile(Me.idUserProfile, Me.idSalonVirtual, False)
            If Not mySVU.existe Then
                Me.idSalonVirtualUserProfile = Me.ExecuteNonQuery(queryString, parametros, True)
                'If Me.status = "I" Then
                '    Dim myA As New Asistencia
                '    myA.SetAsistenciaLista(Me.salonVirtual.id, Me.idUserProfile)
                'End If
            End If

            'Catch ex As Exception
            ' Dim m As String = ex.Message
            '  End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            '	Try
            Dim queryString As String = "UPDATE [SalonVirtualUserProfile] SET [status]=@status, [fechaInicio]=@fechaInicio, " & _
             "[fechaFin]=@fechaFin, [calificacion]=@calificacion, [calificacionComputada]=@calificacionComputada, " & _
             "[idUserProfileCalificador]=@idUserProfileCalificador, [puntosExtras]=@puntosExtras, " & _
             "[calificacionDiferida]=@calificacionDiferida, [fechaConvenio]=@fechaConvenio " & _
             "WHERE idSalonVirtualUserProfile = @idSalonVirtualUserProfile"

            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idSalonVirtualUserProfile", Me.idSalonVirtualUserProfile), _
              New SqlParameter("@status", Me.status), _
              New SqlParameter("@fechaInicio", Me.fechaInicio), _
              New SqlParameter("@fechaFin", Me.fechaFin), _
              New SqlParameter("@calificacion", Me.calificacion), _
              New SqlParameter("@calificacionComputada", Me.calificacionComputada), _
              New SqlParameter("@idUserProfileCalificador", Me.idUserProfileCalificador), _
              New SqlParameter("@puntosExtras", Me.puntosExtras), _
              New SqlParameter("@calificacionDiferida", Me.calificacionDiferida), _
              New SqlParameter("@fechaConvenio", Me.fechaConvenio)}

            Return Me.ExecuteNonQuery(queryString, parametros)

            'Catch ex As Exception
            'Return 0
            ' End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM SalonVirtualUserProfile WHERE idSalonVirtualUserProfile = @idSalonVirtualUserProfile " & _
             "AND status = @status))"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idSalonVirtualUserProfile", Me.idSalonVirtualUserProfile), _
             New SqlParameter("@status", "R")}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM SalonVirtualUserProfile"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, Optional ByVal clavestatus As String = "") As System.Data.IDataReader
            Dim queryString As String = "SELECT svu.*, u.apellidos + ' ' + u.nombre as nombre, u.login, u.email, u.emailGoogle, eu.claveAux1 " & _
    " FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and eu.idUserProfile=svu.idUserProfile " & _
     " AND svu.idSalonVirtual = @idSalonVirtual "

            If clavestatus <> "" Then
                queryString = queryString & "AND svu.status = @status "
            Else
                queryString = queryString & "AND (svu.status = 'I' OR svu.status = 'C') "
            End If
            queryString = queryString & " ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            If clavestatus <> "" Then
                ReDim Preserve parametros(2)
                parametros(1) = New SqlParameter("@status", clavestatus)
            End If

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRConFotos(ByVal claveSalonVirtual As Integer, Optional ByVal claveCantidad As Integer = 0) As System.Data.IDataReader
            Dim queryString As String = "SELECT svu.*, u.apellidos + ' ' + u.nombre as nombre, u.login, u.email, u.emailGoogle, eu.claveAux1, u.imagen  FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and eu.idUserProfile=svu.idUserProfile AND svu.idSalonVirtual = @idSalonVirtual AND (svu.status = 'I' OR svu.status = 'C')   "

            If claveCantidad > 0 Then
                queryString = "SELECT top " & claveCantidad & " svu.*, u.apellidos + ' ' + u.nombre as nombre, u.login, u.email, u.emailGoogle, eu.claveAux1, u.imagen  FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and eu.idUserProfile=svu.idUserProfile AND svu.idSalonVirtual = @idSalonVirtual AND (svu.status = 'I' OR svu.status = 'C') order by newid() "
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveUser As Integer, ByVal claveStatus As String, ByVal excepcion As Boolean) As System.Data.IDataReader
            Dim queryString As String = "SELECT svu.*, sv.nombre  FROM SalonVirtualUserProfile svu, SalonesVirtuales sv " & _
   "WHERE sv.idSalonVirtual = svu.idSalonVirtual AND svu.idUserProfile = @idUserProfile AND Status "

            If excepcion Then
                queryString = queryString & "<> @status "
            Else
                queryString = queryString & "= @status"
            End If
            queryString = queryString & "ORDER BY sv.fechaInicio DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@Status", claveStatus)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM SalonVirtualUserProfile"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, Optional ByVal clavestatus As String = "") As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, u.email, u.nombre, u.apellidos, u.login, u.emailgoogle, eu.claveAux1, u.imagen, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.asistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as asistencia, " &
           " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.retraso=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as retraso, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.inasistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as inasistencia, " &
              " (select count(sve.idSalonVirtualEntrada) as num from salonesvirtualesentradas sve  where sve.idUserProfile=svu.idUserProfile and sve.idsalonvirtual=svu.idsalonvirtual) as numeroEntradas " &
    "FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and u.idUserProfile=eu.idUserProfile " &
     "AND svu.idSalonVirtual = @idSalonVirtual "

            If clavestatus <> "" Then
                queryString = queryString & " AND svu.status = @status "
            Else
                queryString = queryString & " AND (svu.status = 'I' OR svu.status = 'C') "
            End If
            queryString = queryString & " ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}
            If clavestatus <> "" Then
                ReDim Preserve parametros(2)
                parametros(1) = New SqlParameter("@status", clavestatus)
            End If

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDSTodos(ByVal claveSalonVirtual As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, u.email, u.nombre, u.apellidos, u.login, u.emailgoogle, eu.claveAux1, u.imagen, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.asistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as asistencia, " &
           " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.retraso=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as retraso, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.inasistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as inasistencia, " &
              " (select count(sve.idSalonVirtualEntrada) as num from salonesvirtualesentradas sve  where sve.idUserProfile=svu.idUserProfile and sve.idsalonvirtual=svu.idsalonvirtual) as numeroEntradas " &
    "FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and u.idUserProfile=eu.idUserProfile " &
     "AND svu.idSalonVirtual = @idSalonVirtual "


            queryString = queryString & " ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}


            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, claveUserProfile As Integer, Optional ByVal clavestatus As String = "") As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, u.email, u.nombre, u.apellidos, u.login, u.emailgoogle, eu.claveAux1, u.imagen, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.asistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as asistencia, " &
           " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.retraso=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as retraso, " &
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.inasistencia=1 and a.idsalonvirtual=svu.idsalonvirtual and al.iduserprofile=svu.idUserProfile) as inasistencia, " &
              " (select count(sve.idSalonVirtualEntrada) as num from salonesvirtualesentradas sve  where sve.idUserProfile=svu.idUserProfile and sve.idsalonvirtual=svu.idsalonvirtual) as numeroEntradas " &
    "FROM SalonVirtualUserProfile svu, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu.idUserProfile and u.idUserProfile=eu.idUserProfile " &
     "AND svu.idSalonVirtual = @idSalonVirtual AND svu.idUserProfile=@idUserProfile"

            If clavestatus <> "" Then
                queryString = queryString & " AND svu.status = @status "
            Else
                queryString = queryString & " AND (svu.status = 'I' OR svu.status = 'C') "
            End If
            queryString = queryString & " ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idUserProfile", claveUserProfile)}
            If clavestatus <> "" Then
                ReDim Preserve parametros(2)
                parametros(1) = New SqlParameter("@status", clavestatus)
            End If

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Function GetTablaSeguimiento(clavesalonVirtual As Integer, Optional claveuserprofile As Integer = 0) As DataTable
            Dim dsAlumnos As DataSet

            If claveuserprofile > 0 Then
                dsAlumnos = Me.GetDS(clavesalonVirtual, claveuserprofile, "")
            Else
                dsAlumnos = Me.GetDS(clavesalonVirtual, "")
            End If




            Dim dtSeguimiento As New DataTable

            dtSeguimiento.Columns.Add(New DataColumn("idUserProfile", GetType(Integer)))
            dtSeguimiento.Columns.Add(New DataColumn("idSalonVirtual", GetType(Integer)))
            dtSeguimiento.Columns.Add(New DataColumn("claveAux1", GetType(String)))
            dtSeguimiento.Columns.Add(New DataColumn("imagen", GetType(String)))
            dtSeguimiento.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dtSeguimiento.Columns.Add(New DataColumn("Email", GetType(String)))

            Dim mysv As New SalonVirtual(clavesalonVirtual, False)
            Dim fechaLoop As Date = mysv.fechaInicio
            Dim fechaSemana As Date = fechaLoop
            Dim semana As Integer = 1
            Dim actividad As Integer = 1

            Dim mya As New Comm.Agenda

            ' Dim dsAgenda As DataSet = mya.GetDS(clavesalonVirtual, "asc")
            'Dim dvItemsAgenda As DataView
            '  Dim drActividades As IDataReader

            Dim dr As DataRow


            Dim totalActividades As Integer = 0
            Dim totalActividadesEnviadas As Integer = 0


            Dim totalActividadesSemana As Integer = 0
            Dim totalActividadesEnviadasSemana As Integer = 0

            Dim promedioActividades As Decimal = 0


            Dim dsActividadesSalontodas As DataSet = mya.GetDSLista(clavesalonVirtual)
            Dim dvAST As DataView


            Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile

            Do While fechaLoop <= mysv.fechaFin

                dvAST = New DataView(dsActividadesSalontodas.Tables(0), "mes = " & fechaLoop.Month & " And dia = " & fechaLoop.Day & " And ano = " & fechaLoop.Year & " And Procedencia='Actividad'", "", DataViewRowState.CurrentRows)

                For Each drvAST As DataRowView In dvAST
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "A" & actividad, GetType(Integer)))
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "A" & actividad & "-Calificación", GetType(Decimal)))
                    actividad = actividad + 1
                Next

                If fechaLoop.DayOfWeek = DayOfWeek.Saturday Then
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "-Periodo", GetType(String)))
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "-Actividades", GetType(Integer)))
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "-ActividadesEnviadas", GetType(Integer)))
                    dtSeguimiento.Columns.Add(New DataColumn("S" & semana & "-IndiceCompletado", GetType(Decimal)))
                    fechaSemana = fechaLoop.AddDays(1)
                    semana = semana + 1
                    actividad = 1
                End If

                fechaLoop = fechaLoop.AddDays(1)

            Loop

            ' dtSeguimiento.Columns.Add(New DataColumn("Total", GetType(Integer)))
            dtSeguimiento.Columns.Add(New DataColumn("TotalActividades", GetType(Integer)))
            dtSeguimiento.Columns.Add(New DataColumn("TotalActividadesEnviadas", GetType(Integer)))
            dtSeguimiento.Columns.Add(New DataColumn("IndiceCompletado", GetType(Decimal)))
            dtSeguimiento.Columns.Add(New DataColumn("PromedioActividades", GetType(Decimal)))
            dtSeguimiento.Columns.Add(New DataColumn("CalificacionComputada", GetType(Decimal)))
            dtSeguimiento.Columns.Add(New DataColumn("Calificacion", GetType(Decimal)))



            'resetear datos
            fechaLoop = mysv.fechaInicio
            fechaSemana = fechaLoop
            semana = 1
            actividad = 1


            Dim myresp As New Contenidos.Respuesta


            For Each dra As DataRow In dsAlumnos.Tables(0).Rows
                dr = dtSeguimiento.NewRow()
                dr("iduserProfile") = dra("idUserProfile")
                dr("idSalonVirtual") = dra("idSalonVirtual")
                dr("claveAux1") = dra("claveAux1")
                dr("Imagen") = dra("Imagen")
                dr("Nombre") = dra("Apellidos") & " " & dra("Nombre")
                dr("Email") = dra("Email")


                Do While fechaLoop <= mysv.fechaFin

                    dvAST = New DataView(dsActividadesSalontodas.Tables(0), "mes = " & fechaLoop.Month & " And dia = " & fechaLoop.Day & " And ano = " & fechaLoop.Year & " And Procedencia='Actividad'", "", DataViewRowState.CurrentRows)

                    For Each drvAST As DataRowView In dvAST
                        myresp = New Contenidos.Respuesta(0, CInt(drvAST("idProc")), drvAST("Procedencia"), mysv.id, CInt(dra("idUserProfile")))

                        totalActividades = totalActividades + 1
                        totalActividadesSemana = totalActividadesSemana + 1

                        If myresp.existe Then
                            dr("S" & semana & "A" & actividad) = 1
                            dr("S" & semana & "A" & actividad & "-Calificación") = myresp.calificacion

                            totalActividadesEnviadas = totalActividadesEnviadas + 1
                            totalActividadesEnviadasSemana = totalActividadesEnviadasSemana + 1

                            promedioActividades = promedioActividades + myresp.calificacion

                        Else
                            dr("S" & semana & "A" & actividad) = 0
                            dr("S" & semana & "A" & actividad & "-Calificación") = 0

                        End If

                        actividad = actividad + 1
                    Next



                    If fechaLoop.DayOfWeek = DayOfWeek.Saturday Then
                        dr("S" & semana & "-Periodo") = Format(fechaSemana, "dd/MMM") & " al " & Format(fechaLoop, "dd/MMM")
                        dr("S" & semana & "-Actividades") = totalActividadesSemana
                        dr("S" & semana & "-ActividadesEnviadas") = totalActividadesEnviadasSemana
                        If totalActividadesSemana > 0 Then
                            dr("S" & semana & "-IndiceCompletado") = (CDec(totalActividadesEnviadasSemana) / CDec(totalActividadesSemana)) * 100.0
                        Else
                            dr("S" & semana & "-IndiceCompletado") = 0
                        End If

                        fechaSemana = fechaLoop.AddDays(1)
                        semana = semana + 1

                        totalActividadesEnviadasSemana = 0
                        totalActividadesSemana = 0

                        actividad = 1
                    End If





                    fechaLoop = fechaLoop.AddDays(1)
                    'resetear valores


                Loop



                dr("TotalActividades") = totalActividades
                dr("TotalActividadesEnviadas") = totalActividadesEnviadas
                If totalActividades > 0 Then
                    dr("IndiceCompletado") = (CDec(totalActividadesEnviadas) / CDec(totalActividades)) * 100.0
                    dr("PromedioActividades") = promedioActividades / CDec(totalActividades)
                Else
                    dr("IndiceCompletado") = 0
                    dr("PromedioActividades") = 0
                End If
                dr("CalificacionComputada") = dra("CalificacionComputada")
                dr("Calificacion") = CDec(mysvu.GetCalificacionGeneral(CInt(dra("idUserProfile")), CInt(dra("idSalonVirtual")))) / CDec(10.0)


                totalActividades = 0
                totalActividadesEnviadas = 0
                promedioActividades = 0
                semana = 1
                actividad = 1



                dtSeguimiento.Rows.Add(dr)


                fechaLoop = mysv.fechaInicio
                fechaSemana = fechaLoop


                totalActividadesEnviadasSemana = 0
                totalActividadesSemana = 0

            Next



            Return dtSeguimiento ' New DataView(dtSeguimiento)


        End Function

        Public Overloads Function GetDSListaAlumnos(ByVal claveSalonVirtual As Integer) As System.Data.DataSet


            Dim mysql As String = " (Select sum(puntospromedio) As num from " & _
                       " ( Select r.idrespuesta, r.calificacion, asv.valor, ie.valor As valorie,  " & _
                       " (((r.calificacion * asv.valor)/100.00) * ie.valor) / 100.00 As puntosPromedio " & _
                       " from respuestas r, actividadessalonvirtual asv, itemesevaluacion ie" & _
                       " where r.idProc = asv.idActividad And asv.idSalonVirtual=svu1.idSalonVirtual And asv.iditemevaluacion = ie.iditemevaluacion  " & _
                       " And r.idUserProfile=svu1.idUserProfile And r.idSalonVirtual=svu1.idSalonVirtual And r.idraiz=0 And r.Procedencia='Actividad' " & _
                       " union " & _
                       " select r.idrespuesta, r.calificacion, 777 as valor, ie.valor as valorie,  " & _
                       " ((r.calificacion * ie.valor) / 100.00) as puntosPromedio " & _
                       " from respuestas r,  itemesevaluacion ie " & _
                       " where r.idProc = ie.iditemevaluacion " & _
                       " and r.idUserProfile=svu1.idUserProfile and r.idSalonVirtual=svu1.idSalonVirtual and r.idraiz=0 and r.Procedencia='ItemEvaluacion') " & _
                       " as tablaPromedios) as calificacion"


            Dim queryString As String = "SELECT svu1.*, u.nombre, u.apellidos, u.login, u.emailgoogle, eu.claveAux1, " & _
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.asistencia=1 and a.idsalonvirtual=svu1.idsalonvirtual and al.iduserprofile=svu1.idUserProfile) as asistencia, " & _
           " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.retraso=1 and a.idsalonvirtual=svu1.idsalonvirtual and al.iduserprofile=svu1.idUserProfile) as retraso, " & _
            " (select count(al.idAsistenciaLista) from asistenciaslista al, asistencias a where al.idasistencia=a.idasistencia and al.inasistencia=1 and a.idsalonvirtual=svu1.idsalonvirtual and al.iduserprofile=svu1.idUserProfile) as inasistencia, " & mysql & _
    " FROM SalonVirtualUserProfile svu1, UserProfiles u, EmpresasUserProfiles eu WHERE u.idUserProfile = svu1.idUserProfile and u.idUserProfile=eu.idUserProfile " & _
     " AND svu1.idSalonVirtual = @idSalonVirtual "


            queryString = queryString & " AND (svu1.status = 'I' OR svu1.status = 'C') "

            queryString = queryString & " ORDER BY nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}


            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveUser As Integer, ByVal claveStatus As String, ByVal excepcion As Boolean) As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, sv.nombre, sv.claveAux1, " & _
            " (select count(sv1.idUserProfile) from salonVirtualUserProfile sv1 where sv1.idSalonVirtual=svu.idSalonVirtual) as numAlumnos " & _
            " FROM SalonVirtualUserProfile svu, SalonesVirtuales sv " & _
            " WHERE sv.idSalonVirtual = svu.idSalonVirtual AND svu.idUserProfile = @idUserProfile AND svu.Status "

            If excepcion Then
                queryString = queryString & "<> @status "
            Else
                queryString = queryString & "= @status "
            End If
            queryString = queryString & " ORDER BY sv.fechaInicio DESC "

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@Status", claveStatus)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Overloads Function GetDSSinAlumnos(ByVal claveUser As Integer, ByVal claveStatus As String, ByVal excepcion As Boolean) As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, sv.nombre, sv.claveAux1, sv.FechaInicio as FechaInicioSV, sv.FechaFin as FechaFinSV " &
             " FROM SalonVirtualUserProfile svu, SalonesVirtuales sv " &
            " WHERE sv.idSalonVirtual = svu.idSalonVirtual AND svu.idUserProfile = @idUserProfile AND svu.Status "

            If excepcion Then
                queryString = queryString & "<> @status "
            Else
                queryString = queryString & "= @status "
            End If
            queryString = queryString & " ORDER BY sv.fechaInicio DESC "

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser), New SqlParameter("@Status", claveStatus)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Overloads Function GetDSBuscar(ByVal claveUser As Integer, claveBuscar As String) As System.Data.DataSet
            Dim queryString As String = "SELECT svu.*, sv.nombre, sv.claveAux1, sv.FechaInicio as FechaInicioSV, sv.FechaFin as FechaFinSV " &
             " FROM SalonVirtualUserProfile svu, SalonesVirtuales sv " &
            " WHERE sv.idSalonVirtual = svu.idSalonVirtual AND svu.idUserProfile = @idUserProfile AND svu.Status = 'I' and sv.nombre + ' ' + sv.claveAux1 like '%" & claveBuscar & "%' COLLATE Modern_Spanish_CI_AI  ORDER BY sv.nombre, sv.fechaInicio asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function



        Public Overrides Function Count() As Integer
            Dim sql As String = "select count(idSalonVirtualUserProfile) as num from salonVirtualUserProfile  where idSalonVirtual=@idSalonVirtual"
            Dim param As SqlParameter() = {New SqlParameter("@idSalonVirtual", Me.idSalonVirtual)}
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(sql, param)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If

            End If
            dr.Close()

            Return numero
        End Function

        Public Overloads Function Count(ByVal claveUsuario As Integer) As Integer
            Dim sql As String = "select count(idSalonVirtualUserProfile) as num from salonVirtualUserProfile  where idUserProfile=@idUserProfile and Status='I'"
            Dim param As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(sql, param)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If
            End If

            dr.Close()

            Return numero

        End Function

        Public Function CountInscritos(ByVal claveUsuario As Integer) As Integer
            Dim sql As String = "SELECT count(idSalonVirtualUserProfile)  FROM SalonVirtualUserProfile svu   WHERE  svu.idUserProfile = @idUserProfile AND svu.Status = 'I' "
            Dim param As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(sql, param)
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

        Public Function GetCalificacionGeneralGrupo(ByVal claveSalon As Integer) As Integer
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveSalon)



            Dim sumatotal As Integer = 0
            Dim alumnos As Integer = 0
            Do While dr.Read
                sumatotal += Me.GetCalificacionGeneral(CInt(dr("idUserProfile")), claveSalon)
                alumnos += 1
            Loop
            dr.Close()


            If alumnos > 0 Then
                Return sumatotal / alumnos
            Else
                Return 0
            End If

        End Function

        Public Function GetCalificacionGeneral(ByVal varclaveUsuario As Integer, ByVal varclaveSalon As Integer) As Decimal



            Dim mysql As String = "select sum(puntospromedio) as num from " & _
                        " ( select r.idrespuesta, r.calificacion, asv.valor, ie.valor as valorie,  " & _
                        " (((r.calificacion * asv.valor)/100.00) * ie.valor) / 100.00 as puntosPromedio " & _
                        " from respuestas r, actividadessalonvirtual asv, itemesevaluacion ie" & _
                        " where r.idProc = asv.idActividad and asv.idSalonVirtual=@idSalonVirtual And asv.iditemevaluacion = ie.iditemevaluacion  " & _
                        " and r.idUserProfile=@idUserProfile and r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='Actividad' " & _
                        " union " & _
                        " select r.idrespuesta, r.calificacion, 777 as valor, ie.valor as valorie,  " & _
                        " ((r.calificacion * ie.valor) / 100.00) as puntosPromedio " & _
                        " from respuestas r,  itemesevaluacion ie " & _
                        " where r.idProc = ie.iditemevaluacion " & _
                        " and r.idUserProfile=@idUserProfile and r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='ItemEvaluacion') " & _
                        " as tablaPromedios"


            Dim param As SqlParameter() = {New SqlParameter("@idSalonVirtual", varclaveSalon), New SqlParameter("@idUserProfile", varclaveUsuario)}
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(mysql, param)
            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Decimal)
                End If

            End If
            dr.Close()

            Return numero

        End Function

        Public Function GetCalificacionGeneralTodos(ByVal varclaveSalon As Integer) As Decimal



            Dim mysql As String = "select sum(puntospromedio) as num from " & _
                        " ( select r.idrespuesta, r.calificacion, asv.valor, ie.valor as valorie,  " & _
                        " (((r.calificacion * asv.valor)/100.00) * ie.valor) / 100.00 as puntosPromedio " & _
                        " from respuestas r, actividadessalonvirtual asv, itemesevaluacion ie" & _
                        " where r.idProc = asv.idActividad and asv.idSalonVirtual=@idSalonVirtual And asv.iditemevaluacion = ie.iditemevaluacion  " & _
                        " and r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='Actividad' " & _
                        " union " & _
                        " select r.idrespuesta, r.calificacion, 777 as valor, ie.valor as valorie,  " & _
                        " ((r.calificacion * ie.valor) / 100.00) as puntosPromedio " & _
                        " from respuestas r,  itemesevaluacion ie " & _
                        " where r.idProc = ie.iditemevaluacion " & _
                        " and  r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='ItemEvaluacion') " & _
                        " as tablaPromedios"


            Dim param As SqlParameter() = {New SqlParameter("@idSalonVirtual", varclaveSalon)}
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(mysql, param)
            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    Me.idSalonVirtual = varclaveSalon
                    If Me.Count > 0 Then
                        numero = CType(dr("num"), Decimal) / Me.Count
                    Else
                        numero = 0
                    End If

                End If

            End If
            dr.Close()

            Return numero

        End Function



	End Class
End Namespace

