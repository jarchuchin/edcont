Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Comm
	Public NotInheritable Class Agenda
		Inherits DBObject

        Private idAgenda As Integer
        Public idSalonVirtual As Integer
        Public idProc As Integer
        Public procedencia As String
        Public titulo As String
        Public nota As String
        Public fecha As DateTime
        Public fechaInicio As DateTime
        Public activarLimite As Boolean
        Public EventID As String = ""
        Public idUserProfile As Integer = 0

        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idAgenda
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Agenda
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Agenda WHERE idAgenda = @idAgenda"

            Dim parameters As SqlParameter() = {New SqlParameter("@idAgenda", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idAgenda = CType(dr("idAgenda"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idProc = CType(dr("idProc"), Integer)
                Me.procedencia = CType(dr("procedencia"), String)
                Me.titulo = CType(dr("titulo"), String)
                Me.nota = CType(dr("nota"), String)
                Me.fecha = CType(dr("fecha"), Date)
                Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Else
                    Me.fechaInicio = mysv.fechaInicio
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    Me.activarLimite = CType(dr("activarLimite"), Boolean)
                End If
                If Not Convert.IsDBNull(dr("EventID")) Then
                    Me.EventID = dr("EventID")
                End If
                If Not Convert.IsDBNull(dr("idUserProfile")) Then
                    Me.idUserProfile = CInt(dr("idUserProfile"))
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveSalon As Integer, ByVal claveProc As Integer, ByVal claveProcedencia As String)
            Dim queryString As String = "SELECT * FROM Agenda WHERE idSalonVirtual = @idSalonVirtual " & _
             "AND idProc = @idProc AND procedencia = @procedencia"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idSalonVirtual", claveSalon), _
             New SqlParameter("@idProc", claveProc), _
             New SqlParameter("@procedencia", claveProcedencia)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idAgenda = CType(dr("idAgenda"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idProc = CType(dr("idProc"), Integer)
                Me.procedencia = CType(dr("procedencia"), String)
                Me.titulo = CType(dr("titulo"), String)
                Me.nota = CType(dr("nota"), String)
                Me.fecha = CType(dr("fecha"), Date)
                Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Else
                    Me.fechaInicio = mysv.fechaInicio
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    Me.activarLimite = CType(dr("activarLimite"), Boolean)
                End If
                If Not Convert.IsDBNull(dr("EventID")) Then
                    Me.EventID = dr("EventID")
                End If
                If Not Convert.IsDBNull(dr("idUserProfile")) Then
                    Me.idUserProfile = CInt(dr("idUserProfile"))
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveSalon As Integer, ByVal claveProc As Integer, ByVal claveProcedencia As String, claveUserProfile As Integer)
            Dim queryString As String = "SELECT * FROM Agenda WHERE idSalonVirtual = @idSalonVirtual " & _
             "AND idProc = @idProc AND procedencia = @procedencia and idUserProfile=@idUserProfile"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idSalonVirtual", claveSalon), _
             New SqlParameter("@idProc", claveProc), _
             New SqlParameter("@procedencia", claveProcedencia), _
             New SqlParameter("@idUserProfile", claveUserProfile)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idAgenda = CType(dr("idAgenda"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idProc = CType(dr("idProc"), Integer)
                Me.procedencia = CType(dr("procedencia"), String)
                Me.titulo = CType(dr("titulo"), String)
                Me.nota = CType(dr("nota"), String)
                Me.fecha = CType(dr("fecha"), Date)
                Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    Me.fechaInicio = CType(dr("fechaInicio"), Date)
                Else
                    Me.fechaInicio = mysv.fechaInicio
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    Me.activarLimite = CType(dr("activarLimite"), Boolean)
                End If
                If Not Convert.IsDBNull(dr("EventID")) Then
                    Me.EventID = dr("EventID")
                End If
                If Not Convert.IsDBNull(dr("idUserProfile")) Then
                    Me.idUserProfile = CInt(dr("idUserProfile"))
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub


#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Dim queryString As String
            queryString = "INSERT INTO [Agenda] ([idSalonVirtual], [idProc], [procedencia], [titulo], [nota], " & _
   "[fecha], [activarLimite], [fechaInicio], EventID, idUserProfile) VALUES (@idSalonVirtual, @idProc, @procedencia, @titulo, " & _
   "@nota, @fecha, @activarLimite, @fechaInicio, @EventID, @idUserProfile)"


            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
             New SqlParameter("@idProc", Me.idProc), _
             New SqlParameter("@procedencia", Me.procedencia), _
             New SqlParameter("@titulo", Me.titulo), _
             New SqlParameter("@nota", Me.nota), _
             New SqlParameter("@fecha", Me.fecha), _
              New SqlParameter("@activarLimite", Me.activarLimite), _
              New SqlParameter("@fechaInicio", Me.fechaInicio), _
              New SqlParameter("@EventID", Me.EventID), _
             New SqlParameter("@idUserProfile", Me.idUserProfile)}

            Dim myagenda As Agenda = New Agenda(Me.idSalonVirtual, Me.idProc, procedencia)
            If existe = False Then
                Me.idAgenda = Me.ExecuteNonQuery(queryString, parametros, True)
            End If



            'Catch ex As Exception
            '    Dim m As String = ex.Message
            'End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Agenda] SET [idSalonVirtual]=@idSalonVirtual, [idProc]=@idProc, " & _
                 "[procedencia]=@procedencia, [titulo]=@titulo, [nota]=@nota, [fecha]=@fecha, [fechaInicio]=@fechaInicio, " & _
                 "[activarLimite]=@activarLimite, idUserProfile=@idUserProfile WHERE idAgenda = @idAgenda"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idAgenda", Me.idAgenda), _
                 New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                 New SqlParameter("@idProc", Me.idProc), _
                 New SqlParameter("@procedencia", Me.procedencia), _
                 New SqlParameter("@titulo", Me.titulo), _
                 New SqlParameter("@nota", Me.nota), _
                 New SqlParameter("@fecha", Me.fecha), _
                 New SqlParameter("@fechaInicio", Me.fechaInicio), _
                 New SqlParameter("@activarLimite", Me.activarLimite), _
              New SqlParameter("@EventID", Me.EventID), _
             New SqlParameter("@idUserProfile", Me.idUserProfile)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Agenda WHERE idAgenda = @idAgenda"

            Dim parametros As SqlParameter() = {New SqlParameter("@idAgenda", Me.idAgenda)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal claveOrden As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT *, day(fecha) as dia, month(fecha) as mes, year(fecha) as ano FROM Agenda WHERE idSalonVirtual = @idSalonVirtual ORDER BY fecha " & claveOrden

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRSinUsuarios(ByVal claveSalonVirtual As Integer, ByVal claveOrden As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM Agenda WHERE idSalonVirtual = @idSalonVirtual and idUserProfile=0 ORDER BY fecha " & claveOrden

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal clavefecha As DateTime) As System.Data.IDataReader
            Dim queryString As String = "SELECT a.*, u.nombre + ' ' + u.apellidos as NombreAlumno FROM Agenda as a left outer join UserProfiles as u on u.idUserProfile=a.idUserProfile WHERE a.idSalonVirtual = @idSalonVirtual AND day(a.fecha) = @dia and month(a.fecha) = @mes and year(a.fecha) = @ano order by a.fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
                                                New SqlParameter("@dia", clavefecha.Day), _
                                                New SqlParameter("@mes", clavefecha.Month), _
                                                New SqlParameter("@ano", clavefecha.Year)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRUsuarioyGeneral(ByVal claveSalonVirtual As Integer, ByVal clavefecha As DateTime, claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT a.*, u.nombre + ' ' + u.apellidos as NombreAlumno FROM Agenda as a left outer join UserProfiles as u on u.idUserProfile=a.idUserProfile WHERE a.idSalonVirtual = @idSalonVirtual AND day(a.fecha) = @dia and month(a.fecha) = @mes and year(a.fecha) = @ano and (a.idUserProfile=0 or a.idUserProfile=@idUserProfile) order by a.fecha desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
                                                New SqlParameter("@dia", clavefecha.Day), _
                                                New SqlParameter("@mes", clavefecha.Month), _
                                                New SqlParameter("@ano", clavefecha.Year), _
                                                New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function




        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Function GetDSLista(claveSalon As Integer) As System.Data.DataSet
            Dim queryString As String = "select *, year(fecha)  as ano, month(fecha) as mes, day(fecha) as dia from (select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot, ci.idClasificacionItem as idClasificacionItem, isnull(up.nombre,'') + ' ' + isnull(up.apellidos, '') as nombreAlumno  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Actividades ac on ac.idActividad=a.idProc left outer join clasificacionesItems ci on ci.idRoot=sv.idRoot and ci.idProc=a.idProc and ci.Procedencia=a.Procedencia  left outer join UserProfiles up on up.idUserProfile=a.idUserProfile   where  a.Procedencia='Actividad'   and a.idSalonVirtual  = @idSalonVirtual  and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0))  UNION select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot, ci.idClasificacionItem as idClasificacionItem, isnull(up.nombre,'') + ' ' + isnull(up.apellidos, '') as nombreAlumno  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Contenidos ac on ac.idContenido=a.idProc left outer join clasificacionesItems ci on ci.idRoot=sv.idRoot and ci.idProc=a.idProc and ci.Procedencia=a.Procedencia  left outer join UserProfiles up on up.idUserProfile=a.idUserProfile  where  a.Procedencia='Contenido' and a.idSalonVirtual  = @idSalonVirtual  and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0)) UNION select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot, ci.idClasificacionItem as idClasificacionItem, isnull(up.nombre,'') + ' ' + isnull(up.apellidos, '') as nombreAlumno  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Foros ac on ac.idForo=a.idProc left outer join clasificacionesItems ci on ci.idRoot=sv.idRoot and ci.idProc=a.idProc and ci.Procedencia=a.Procedencia left outer join UserProfiles up on up.idUserProfile=a.idUserProfile  where  a.Procedencia='Foro'  and a.idSalonVirtual = @idSalonVirtual  and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0)) UNION select a.*, sv.Nombre as nombreSalon, a.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot, ci.idClasificacionItem as idClasificacionItem, isnull(up.nombre,'') + ' ' + isnull(up.apellidos, '') as nombreAlumno  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join clasificacionesItems ci on ci.idRoot=sv.idRoot and ci.idProc=a.idProc and ci.Procedencia=a.Procedencia left outer join UserProfiles up on up.idUserProfile=a.idUserProfile   where  a.Procedencia='SalonVirtual' and a.idSalonVirtual  = @idSalonVirtual ) as table1     order by Fecha asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal claveOrden As String) As System.Data.DataSet
            Dim queryString As String = "select * from (SELECT a.*, day(a.fecha) as dia, month(a.fecha) as mes, year(a.fecha) as ano, sv.Nombre as Salon, isnull(ci.idClasificacionItem,0) as idClasificacionItem FROM Agenda a left outer join SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join ClasificacionesItems ci on ci.idProc=a.idProc and ci.Procedencia=a.Procedencia and ci.idRoot=sv.idRoot WHERE a.idSalonVirtual = @idSalonVirtual)   as table1 where idClasificacionItem>0 ORDER BY fecha " & claveOrden

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal clavefecha As DateTime) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Agenda WHERE idSalonVirtual = @idSalonVirtual AND day(fecha) = @dia and month(fecha)=@mes and year(fecha) = @ano order by fecha asc "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
                                                New SqlParameter("@dia", clavefecha.Day), _
                                                New SqlParameter("@mes", clavefecha.Month), _
                                                New SqlParameter("@ano", clavefecha.Year)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Overloads Function GetDS(ByVal claveSalonVirtual As Integer, ByVal clavefechaInicio As DateTime, ByVal claveFechafin As DateTime) As System.Data.DataSet

            Dim localfechaInicio As DateTime = DateTime.Parse(clavefechaInicio.ToShortDateString & " 00:00:00 AM")
            Dim localfechafin As DateTime = DateTime.Parse(claveFechafin.ToShortDateString & " 11:59:59 PM")

            Dim queryString As String = "SELECT * FROM Agenda WHERE idSalonVirtual = @idSalonVirtual AND fechaInicio >= @fechaInicio and fecha<=@fechafin order by fecha asc "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", SqlDbType.Int), _
                                                New SqlParameter("@fechaInicio", SqlDbType.DateTime), _
                                                New SqlParameter("@fechafin", SqlDbType.DateTime)}

            parametros(0).Value = claveSalonVirtual
            parametros(1).Value = localfechaInicio
            parametros(2).Value = localfechafin


            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

        Public Function GetItemsAgenda(ByVal claveSalonVirtual As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idAgenda", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idProc", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("procedencia", GetType(String)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("nota", GetType(String)))
            dTable.Columns.Add(New DataColumn("fecha", GetType(Date)))
            dTable.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
            dTable.Columns.Add(New DataColumn("activarLimite", GetType(Boolean)))
            dTable.Columns.Add(New DataColumn("url", GetType(String)))





            Dim dr As Data.IDataReader = Me.GetDR(claveSalonVirtual, "ASC")
            Dim mysalonvirtual As New Know.SalonVirtual(claveSalonVirtual, False)
            Dim myForo As Contenidos.Foro
            Dim myActividad As Contenidos.Actividad
            Dim myContenido As Contenidos.Contenido
            Dim myci As Lego.ClasificacionItem

            Dim dRow As DataRow

            Do While dr.Read
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idAgenda"), Integer)
                dRow(1) = CType(dr("idProc"), Integer)
                dRow(2) = CType(dr("procedencia"), String)
                dRow(4) = CType(dr("nota"), String)
                dRow(5) = CType(dr("fecha"), Date)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    dRow(6) = CType(dr("fechaInicio"), Date)
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    dRow(7) = CType(dr("activarLimite"), Boolean)
                Else
                    dRow(7) = False
                End If




                Select Case CType(dr("procedencia"), String)
                    Case "Foro"
                        myForo = New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(3) = myForo.titulo
                        myci = New Lego.ClasificacionItem(mysalonvirtual.idRoot, myForo.id, myForo.tipo.ToString)
                        dRow(8) = "verForo.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                    Case "Actividad"
                        myActividad = New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        dRow(3) = myActividad.titulo

                        myci = New Lego.ClasificacionItem(mysalonvirtual.idRoot, myActividad.id, myActividad.tipo.ToString)
                        Select Case myActividad.tipodeActividad
                            Case Contenidos.ETipodeActividad.Actividad
                                dRow(8) = "verActividad.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                            Case Contenidos.ETipodeActividad.Examen
                                dRow(8) = "verExamen.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                        End Select

                    Case "SalonVirtual"
                        dRow(3) = CType(dr("titulo"), String)
                        dRow(8) = ""
                    Case "Contenido"
                        myContenido = New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        dRow(3) = myContenido.titulo

                        myci = New Lego.ClasificacionItem(mysalonvirtual.idRoot, myContenido.id, myContenido.tipo.ToString)
                        Select Case myContenido.idTipoContenido
                            Case Contenidos.TipoContenido.Texto
                                dRow(8) = "verTexto.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Articulate
                                dRow(8) = "verTexto.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Imagen
                                dRow(8) = "verImagen.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Flash
                                dRow(8) = "verFlash.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Archivo
                                dRow(8) = "verArchivo.aspx?idSalonVirtual=" & mysalonvirtual.id & "&idCI=" & myci.id
                        End Select
                End Select





                dTable.Rows.Add(dRow)
            Loop

            dr.Close()
            Dim dView As New DataView(dTable)

            Return dView
        End Function


        Public Function GetItemsAgendaTodos(ByVal claveUserProfile As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idAgenda", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idProc", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("procedencia", GetType(String)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("nota", GetType(String)))
            dTable.Columns.Add(New DataColumn("fecha", GetType(Date)))
            dTable.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
            dTable.Columns.Add(New DataColumn("activarLimite", GetType(Boolean)))
            dTable.Columns.Add(New DataColumn("url", GetType(String)))
            dTable.Columns.Add(New DataColumn("nombreSalon", GetType(String)))





            Dim dr As Data.IDataReader = Me.getDSTotal(Date.Now, claveUserProfile)
            '       Dim mysalonvirtual As New Know.SalonVirtual(claveSalonVirtual, False)
            Dim myForo As Contenidos.Foro
            Dim myActividad As Contenidos.Actividad
            Dim myContenido As Contenidos.Contenido
            Dim myci As Lego.ClasificacionItem

            Dim dRow As DataRow

            Do While dr.Read
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idAgenda"), Integer)
                dRow(1) = CType(dr("idProc"), Integer)
                dRow(2) = CType(dr("procedencia"), String)
                dRow(4) = CType(dr("nota"), String)
                dRow(5) = CType(dr("fecha"), Date)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    dRow(6) = CType(dr("fechaInicio"), Date)
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    dRow(7) = CType(dr("activarLimite"), Boolean)
                Else
                    dRow(7) = False
                End If
                dRow(9) = dr("nombreSalon")



                Select Case CType(dr("procedencia"), String)
                    Case "Foro"
                        myForo = New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(3) = myForo.titulo
                        myci = New Lego.ClasificacionItem(dr("idRoot"), myForo.id, myForo.tipo.ToString)
                        dRow(8) = "verForo.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                    Case "Actividad"
                        myActividad = New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        dRow(3) = myActividad.titulo

                        myci = New Lego.ClasificacionItem(dr("idRoot"), myActividad.id, myActividad.tipo.ToString)
                        Select Case myActividad.tipodeActividad
                            Case Contenidos.ETipodeActividad.Actividad
                                dRow(8) = "verActividad.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                            Case Contenidos.ETipodeActividad.Examen
                                dRow(8) = "verExamen.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                        End Select

                    Case "SalonVirtual"
                        dRow(3) = CType(dr("titulo"), String)
                        dRow(8) = "default.aspx?idSalonVirtual=" & dr("idSalonVirtual")
                    Case "Contenido"
                        myContenido = New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        dRow(3) = myContenido.titulo

                        myci = New Lego.ClasificacionItem(dr("idRoot"), myContenido.id, myContenido.tipo.ToString)
                        Select Case myContenido.idTipoContenido
                            Case Contenidos.TipoContenido.Texto
                                dRow(8) = "verTexto.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Articulate
                                dRow(8) = "verTexto.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Imagen
                                dRow(8) = "verImagen.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Flash
                                dRow(8) = "verFlash.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                            Case Contenidos.TipoContenido.Archivo
                                dRow(8) = "verArchivo.aspx?idSalonVirtual=" & dr("idSalonVirtual") & "&idCI=" & myci.id
                        End Select
                End Select





                dTable.Rows.Add(dRow)
            Loop

            dr.Close()
            Dim dView As New DataView(dTable)

            Return dView
        End Function


        Public Function GetItemsAgenda(ByVal claveSalonVirtual As Integer, ByVal claveFecha As Date) As DataView

            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idAgenda", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idProc", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("procedencia", GetType(String)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("nota", GetType(String)))
            dTable.Columns.Add(New DataColumn("fecha", GetType(Date)))
            dTable.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
            dTable.Columns.Add(New DataColumn("activarLimite", GetType(Boolean)))


            Dim dr As Data.IDataReader = Me.GetDR(claveSalonVirtual, claveFecha)
            Dim myForo As Contenidos.Foro
            Dim myActividad As Contenidos.Actividad
            Dim myContenido As Contenidos.Contenido

            Dim dRow As DataRow

            Do While dr.Read
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idAgenda"), Integer)
                dRow(1) = CType(dr("idProc"), Integer)
                dRow(2) = CType(dr("procedencia"), String)
                dRow(4) = CType(dr("nota"), String)
                dRow(5) = CType(dr("fecha"), Date)
                If Not Convert.IsDBNull(dr("fechaInicio")) Then
                    dRow(6) = CType(dr("fechaInicio"), Date)
                End If
                If Not Convert.IsDBNull(dr("activarLimite")) Then
                    dRow(7) = CType(dr("activarLimite"), Boolean)
                Else
                    dRow(7) = False
                End If




                Select Case CType(dr("procedencia"), String)
                    Case "Foro"
                        myForo = New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(3) = myForo.titulo
                    Case "Actividad"
                        myActividad = New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        dRow(3) = myActividad.titulo
                    Case "SalonVirtual"
                        dRow(3) = CType(dr("titulo"), String)
                    Case "Contenido"
                        myContenido = New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        dRow(3) = myContenido.titulo
                End Select

                dTable.Rows.Add(dRow)
            Loop
            dr.Close()
            Dim dView As New DataView(dTable)

            Return dView
        End Function

        Public Function HayItems(ByVal claveSalon As Integer, ByVal claveFecha As Date) As Boolean
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveSalon, claveFecha)
            Dim regresas As Boolean = False
            If dr.HasRows Then
                regresas = True
            End If
            dr.Close()

            Return regresas
        End Function

        '++++++ REVISAR ++++++++
        Public Function GetLigaConItemsDiarios(ByVal claveSalon As Integer, ByVal fecha As Date, ByVal claveRoot As Integer, claveUsuario As Integer) As String
            Dim dr As SqlClient.SqlDataReader = Me.GetDRUsuarioyGeneral(claveSalon, fecha, claveUsuario)
            Dim cadena As String = String.Empty
            Dim root As String = ConfigurationManager.AppSettings("carpetaVirtual") & "sec/SalonVirtual/"
            Dim myci As Lego.ClasificacionItem


            Do While dr.Read
                Select Case CType(dr("Procedencia"), String)
                    Case "Actividad"
                        Dim myActividad As New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        myci = New Lego.ClasificacionItem(claveRoot, myActividad.id, myActividad.tipo.ToString)
                        If myActividad.tipodeActividad = Contenidos.ETipodeActividad.Actividad Then
                            cadena = cadena & "<a class='mini-link' href='" & root & "verActividad.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/miniIconActvs.gif'> " & myActividad.titulo & "</a>"
                            If Not Convert.IsDBNull(dr("NombreAlumno")) Then
                                cadena = cadena & "(" & dr("NombreAlumno") & ")"
                            End If
                            cadena = cadena & "<br>"
                        Else
                            cadena = cadena & "<a  class='mini-link'  href='" & root & "verExamen.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "'><img border=0 src='../../images/miniIconExam.gif'> " & myActividad.titulo & "</a>"
                            If Not Convert.IsDBNull(dr("NombreAlumno")) Then
                                cadena = cadena & "(" & dr("NombreAlumno") & ")"
                            End If
                            cadena = cadena & "<br>"
                        End If
                    Case "Foro"
                        Dim myForo As New Contenidos.Foro(CType(dr("idProc"), Integer))
                        myci = New Lego.ClasificacionItem(claveRoot, myForo.id, myForo.tipo.ToString)
                        cadena = cadena & "<a  class='mini-link'  href='" & root & "verForo.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "'><img border=0 src='../../images/miniIconForo.gif'> " & myForo.titulo & "</a>"
                        If Not Convert.IsDBNull(dr("NombreAlumno")) Then
                            cadena = cadena & "(" & dr("NombreAlumno") & ")"
                        End If
                        cadena = cadena & "<br>"
                    Case "SalonVirtual"
                        cadena = cadena & "<font class='Chica'><img border=0 src='../../images/createvc.gif'> " & CType(dr("titulo"), String) & "</font><br>" & "<font class='textosmall'>*" & CType(dr("nota"), String) & "</font>"
                        If Not Convert.IsDBNull(dr("NombreAlumno")) Then
                            cadena = cadena & "(" & dr("NombreAlumno") & ")"
                        End If
                        cadena = cadena & "<br>"
                    Case "Contenido"
                        Dim mycont As New Contenidos.Contenido(CInt(dr("idProc")))
                        myci = New Lego.ClasificacionItem(claveRoot, mycont.id, mycont.tipo.ToString)
                        Select Case mycont.idTipoContenido
                            Case Contenidos.TipoContenido.Archivo
                                cadena = cadena & "<a class='mini-link'  href='" & root & "verArchivo.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/miniIconArchivo.jpg'> " & mycont.titulo & "</a>"
                            Case Contenidos.TipoContenido.Flash
                                cadena = cadena & "<a class='mini-link'  href='" & root & "verFlash.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/miniIconFlash.gif'> " & mycont.titulo & "</a>"
                            Case Contenidos.TipoContenido.Imagen
                                cadena = cadena & "<a class='mini-link'  href='" & root & "verImagen.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/miniIconImagenes.gif'> " & mycont.titulo & "</a>"
                            Case Contenidos.TipoContenido.Texto
                                cadena = cadena & "<a class='mini-link'  href='" & root & "verTexto.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/MiniIconTexto.gif'> " & mycont.titulo & "</a>"
                            Case Contenidos.TipoContenido.Articulate
                                cadena = cadena & "<a class='mini-link'  href='" & root & "verTexto.aspx" & "?idSalonVirtual=" & claveSalon & "&idCI=" & myci.id & "' ><img border=0 src='../../images/MiniIconTexto.gif'> " & mycont.titulo & "</a>"
                        End Select


                        If Not Convert.IsDBNull(dr("NombreAlumno")) Then
                            cadena = cadena & "(" & dr("NombreAlumno") & ")"
                        End If
                        cadena = cadena & "<br>"
                End Select
            Loop
            dr.Close()

            Return cadena
        End Function

        Public Function GetTablaSemanaActividades(ByVal claveSalon As Integer, ByVal fecha As Date, claveusuario As Integer) As DataView
            Dim dTable As New DataTable
            Dim dRow As DataRow
            Dim fechaEnOperacion As Date
            Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(claveSalon, False)


            dTable.Columns.Add(New DataColumn("fecha", GetType(Date)))    '0
            dTable.Columns.Add(New DataColumn("actividad", GetType(String)))    '1

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(-3)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)

            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(-2)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(-1)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(1)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(2)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            dRow = dTable.NewRow()
            fechaEnOperacion = fecha.AddDays(3)
            dRow(0) = fechaEnOperacion
            dRow(1) = Me.GetLigaConItemsDiarios(claveSalon, fechaEnOperacion, mysalon.idRoot, claveusuario)
            dTable.Rows.Add(dRow)

            Dim dView As New DataView(dTable)

            Return dView
        End Function



        Public Function getDSTotal(ByVal claveFecha As DateTime, ByVal claveUserprofile As Integer) As SqlClient.SqlDataReader
            Dim sql As String = "select * from (select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Actividades ac on ac.idActividad=a.idProc  where  a.Procedencia='Actividad'   and a.idSalonVirtual  in (select  svup.idSalonVirtual  from SalonVirtualUserProfile svup where svup.idUserProfile = @idUserProfile and svup.[status]<>'B' union select s.idSalonVirtual from SalonesVirtuales s, permisos p1 where p1.idPermisoA = @idUserProfile AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' and s.FechaInicio <= GETDATE() and s.FechaFin > DATEADD(day,1, GETDATE()))  and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0)) Union select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Contenidos ac on ac.idContenido=a.idProc  where  a.Procedencia='Contenido' and a.idSalonVirtual  in (select  svup.idSalonVirtual  from SalonVirtualUserProfile svup where svup.idUserProfile = @idUserProfile and svup.[status]<>'B' union select s.idSalonVirtual from SalonesVirtuales s, permisos p1 where p1.idPermisoA = @idUserProfile AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' and s.FechaInicio <= GETDATE() and s.FechaFin > DATEADD(day,1, GETDATE())) and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0)) Union select a.*, sv.Nombre as nombreSalon, ac.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual left outer join Foros ac on ac.idForo=a.idProc  where  a.Procedencia='Foro'  and a.idSalonVirtual  in (select  svup.idSalonVirtual  from SalonVirtualUserProfile svup where svup.idUserProfile = @idUserProfile and svup.[status]<>'B' union select s.idSalonVirtual from SalonesVirtuales s, permisos p1 where p1.idPermisoA = @idUserProfile AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' and s.FechaInicio <= GETDATE() and s.FechaFin > DATEADD(day,1, GETDATE()) ) and a.idProc in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(sv.idRoot,0)) union select a.*, sv.Nombre as nombreSalon, a.Titulo as actividad, isnull(sv.idRoot,0)  as idRoot  from Agenda a left outer join  SalonesVirtuales sv on sv.idSalonVirtual=a.idSalonVirtual  where  a.Procedencia='SalonVirtual' and a.idSalonVirtual  in (select  svup.idSalonVirtual  from SalonVirtualUserProfile svup where svup.idUserProfile = @idUserProfile and svup.[status]<>'B' union select s.idSalonVirtual from SalonesVirtuales s, permisos p1 where p1.idPermisoA = @idUserProfile AND p1.PermisoA = 'UserProfile' AND p1.idRecurso = s.idSalonVirtual AND p1.Recurso = 'SalonVirtual' and s.FechaInicio <= GETDATE() and s.FechaFin > DATEADD(day,1, GETDATE()) )) as table1  where fecha >= @fecha and ( idUserProfile=0 or idUserProfile=@idUserProfile) order by Fecha asc "





            Dim parametros As SqlParameter() = {New SqlParameter("@fecha", claveFecha.AddDays(-15)),
                                              New SqlParameter("@idUserProfile", claveUserprofile)}
            Return Me.ExecuteReader(sql, parametros)


        End Function


        Public Function GrabarCalendario(claveUsuario As Integer, claveidSalonVirtual As Integer, fechaInicio As Date) As Integer

            Dim dr As SqlDataReader = GetDRSinUsuarios(claveidSalonVirtual, "asc")
            Dim mynewAgenda As Agenda
            Dim mysv As New Know.SalonVirtual(claveidSalonVirtual, False)
            Dim numeroItemsEnCalendario As Integer = 0

            Do While dr.Read
                mynewAgenda = New Agenda()
                mynewAgenda.idSalonVirtual = CInt(dr("idSalonVirtual"))
                mynewAgenda.idProc = CInt(dr("idProc"))
                mynewAgenda.procedencia = dr("Procedencia")
                mynewAgenda.titulo = dr("Titulo")
                mynewAgenda.nota = dr("Nota")

                Dim dtstart As DateTime = mysv.fechaInicio
                Dim dtEnd As DateTime = CDate(dr("Fecha"))
                Dim ts As TimeSpan = dtEnd - dtstart
                Dim dias As Integer = ts.TotalDays


                If fechaInicio.AddDays(dias).DayOfWeek = DayOfWeek.Saturday Then
                    mynewAgenda.fecha = fechaInicio.AddDays(dias + 1)
                Else
                    mynewAgenda.fecha = fechaInicio.AddDays(dias)
                End If


                If CDate(dr("FechaInicio")) > mysv.fechaInicio Then
                    dtstart = CDate(dr("FechaInicio"))
                    ts = dtEnd - dtstart
                    dias = ts.TotalDays
                    mynewAgenda.fechaInicio = mynewAgenda.fecha.AddDays(-dias)
                Else
                    mynewAgenda.fechaInicio = fechaInicio

                End If
                mynewAgenda.activarLimite = CBool(dr("ActivarLimite"))
                If Not Convert.IsDBNull(dr("EventID")) Then
                    mynewAgenda.EventID = dr("EventID")
                Else
                    mynewAgenda.EventID = ""
                End If

                mynewAgenda.idUserProfile = claveUsuario
                mynewAgenda.Add()
                numeroItemsEnCalendario = numeroItemsEnCalendario + 1
            Loop



            Return numeroItemsEnCalendario
        End Function





#End Region
    End Class
End Namespace