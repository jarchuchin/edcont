Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class ActividadSalonVirtual
		Inherits DBObject


        Private idActividadSalonVirtual As Integer
        Public idActividad As Integer
        Public idSalonVirtual As Integer
        Public idItemEvaluacion As Integer
        Public valor As Integer
        Public CadenaRegreso As String = ""

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return idActividadSalonVirtual
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ActividadSalonVirtual
            End Get
        End Property



        Public Sub New()
        End Sub

        Public Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM ActividadesSalonVirtual WHERE idActividadSalonVirtual = @idActividadSalonVirtual"

            Dim parameters As SqlParameter() = {New SqlParameter("@idActividadSalonVirtual", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idActividadSalonVirtual = CType(dr("idActividadSalonVirtual"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idItemEvaluacion = CType(dr("idItemEvaluacion"), Integer)
                Me.valor = CType(dr("valor"), Integer)
                Me.varExiste = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveActividad As Integer, ByVal claveSalon As Integer)
            Dim queryString As String = "SELECT * FROM ActividadesSalonVirtual WHERE idActividad = @idActividad AND idSalonVirtual = @idSalonVirtual"

            Dim parameters As SqlParameter() = {New SqlParameter("@idActividad", claveActividad), New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idActividadSalonVirtual = CType(dr("idActividadSalonVirtual"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idItemEvaluacion = CType(dr("idItemEvaluacion"), Integer)
                Me.valor = CType(dr("valor"), Integer)
                Me.varExiste = True
            End If
            dr.Close()

        End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [ActividadesSalonVirtual] ([idActividad], [idSalonVirtual], " & _
                 "[idItemEvaluacion], [valor]) VALUES (@idActividad, @idSalonVirtual, @idItemEvaluacion, @valor)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idActividad", Me.idActividad), _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idItemEvaluacion", Me.idItemEvaluacion), _
                  New SqlParameter("@valor", Me.valor)}

                Me.idActividadSalonVirtual = Me.ExecuteNonQuery(queryString, parametros, True)

            ''###############Colocar Datos en sistema academico####################
            'Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
            'Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(mysv.claveAux1)
            'If mycg.Estado < 3 Then
            '    Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(Me.idItemEvaluacion)
            '    If mycge.existe Then
            '        Dim mycga As UM.Carga_Grupo_Actividad = New UM.Carga_Grupo_Actividad
            '        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(Me.idActividad)

            '        mycga.Curso_Carga_Id = mysv.claveAux1
            '        mycga.Evaluacion_Id = mycge.Evaluacion_id
            '        If mya.titulo.Length > 100 Then
            '            mycga.Nombre = mya.titulo.Substring(0, 99)
            '        Else
            '            mycga.Nombre = mya.titulo
            '        End If
            '        mycga.Valor = Me.valor
            '        mycga.Fecha = Date.Today
            '        mycga.Actividad_Skolar = Me.idActividadSalonVirtual
            '        mycga.Add()

            '    End If

            'End If




            Return 1
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [ActividadesSalonVirtual] SET [idActividad]=@idActividad, " & _
                 "[idSalonVirtual]=@idSalonVirtual, [idItemEvaluacion]=@idItemEvaluacion, [valor]=@valor " & _
                 "WHERE ([ActividadesSalonVirtual].[idActividadSalonVirtual] = @idActividadSalonVirtual)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idActividadSalonVirtual", Me.idActividadSalonVirtual), _
                  New SqlParameter("@idActividad", Me.idActividad), _
                  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
                  New SqlParameter("@idItemEvaluacion", Me.idItemEvaluacion), _
                  New SqlParameter("@valor", Me.valor)}

                Me.ExecuteNonQuery(queryString, parametros)

            ''###############Colocar Datos en sistema academico####################
            'Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
            'Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(mysv.claveAux1)
            'If mycg.Estado < 3 Then
            '    Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(Me.idItemEvaluacion)
            '    If mycge.existe Then
            '        Dim mycga As UM.Carga_Grupo_Actividad = New UM.Carga_Grupo_Actividad(Me.idActividadSalonVirtual)
            '        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(Me.idActividad)
            '        If mycga.existe Then


            '            ' mycga.Curso_Carga_Id = mysv.claveAux1
            '            mycga.Evaluacion_Id = mycge.Evaluacion_id
            '            If mya.titulo.Length > 100 Then
            '                mycga.Nombre = mya.titulo.Substring(0, 99)
            '            Else
            '                mycga.Nombre = mya.titulo
            '            End If
            '            mycga.Valor = Me.valor
            '            'mycga.Fecha = Date.Today
            '            mycga.Actividad_Skolar = Me.idActividadSalonVirtual
            '            mycga.Update()
            '        Else


            '            mycga.Curso_Carga_Id = mysv.claveAux1
            '            mycga.Evaluacion_Id = mycge.Evaluacion_id
            '            If mya.titulo.Length > 100 Then
            '                mycga.Nombre = mya.titulo.Substring(0, 99)
            '            Else
            '                mycga.Nombre = mya.titulo
            '            End If
            '            mycga.Valor = Me.valor
            '            mycga.Fecha = Date.Today
            '            mycga.Actividad_Skolar = Me.idActividadSalonVirtual
            '            mycga.Add()

            '        End If


            '    End If

            'End If

            Return 1

        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM [ActividadesSalonVirtual] WHERE (idActividadSalonVirtual = @idActividadSalonVirtual)"
            Dim parametros As SqlParameter() = {New SqlParameter("@idActividadSalonVirtual", Me.idActividadSalonVirtual)}
            Me.ExecuteNonQuery(queryString, parametros)

            'Aqui va el procedimiento para borrar todo
            Dim myrespuestas As New Contenidos.Respuesta
            Dim dsRespuestas As DataSet = myrespuestas.GetDS(Me.idActividad, "Actividad", Me.idSalonVirtual)
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)
            Dim myuser As MasUsuarios.EmpresaUserProfile
            ' Dim myka As UM.Krdx_Alumno_Activ
            Dim claveActividadSalonVirtual = Me.idActividadSalonVirtual

            Dim regreso As Integer = 0
            Dim i As Integer = 0
            For i = 0 To dsRespuestas.Tables(0).Rows.Count - 1

                myrespuestas = New Contenidos.Respuesta(CInt(dsRespuestas.Tables(0).Rows(i).Item("idRespuesta")))
               
                myuser = New MasUsuarios.EmpresaUserProfile(myrespuestas.idUserProfile, 4, "xyz")

                myrespuestas.Remove()
                CadenaRegreso = CadenaRegreso & " || " & myuser.claveAux1 & "-" & claveActividadSalonVirtual & "-" & mysv.claveAux1 & "###"

            Next






            Return regreso
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal claveItemEvaluacion As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT asv.*, a.titulo, a.tipodeActividad FROM ActividadesSalonVirtual asv, Actividades a " & _
             "WHERE a.idActividad = asv.idActividad AND asv.idItemEvaluacion = @idItemEvaluacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idItemEvaluacion", claveItemEvaluacion)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overloads Function GetDS(ByVal claveItemEvaluacion As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT asv.*, a.titulo, a.tipodeActividad FROM ActividadesSalonVirtual asv, Actividades a " & _
             "WHERE a.idActividad = asv.idActividad AND asv.idItemEvaluacion = @idItemEvaluacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idItemEvaluacion", claveItemEvaluacion)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(ByVal claveSalon As Integer) As Integer
            Dim queryString As String = "SELECT count(idActividadSalonVirtual) as num FROM ActividadesSalonVirtual WHERE idSalonVirtual = @idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = Convert.ToInt32(dr("num"))
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

        Public Function GetSuma(ByVal claveItemEvaluacion As Integer) As Integer
            Dim queryString As String = "SELECT SUM(valor) as num FROM ActividadesSalonVirtual WHERE idItemEvaluacion = @idItemEvaluacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idItemEvaluacion", claveItemEvaluacion)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = Convert.ToInt32(dr("num"))
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Function GetDisponibles(ByVal claveSalon As Integer, ByVal claveRoot As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT a.idActividad, a.titulo, a.tipodeActividad, ci.idRoot, ci.idClasificacion " & _
             "FROM ClasificacionesItems ci, Actividades a WHERE a.idActividad = ci.idProc AND ci.Procedencia = 'Actividad' " & _
             "AND ci.idRoot = @idRoot AND a.idActividad " & _
             "NOT IN (SELECT asv.idActividad FROM ActividadesSalonVirtual asv WHERE idSalonVirtual = @idSalonVirtual) ORDER BY a.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idRoot", claveRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetActividadesNoEnAgenda(ByVal claveSalon As Integer, ByVal claveRoot As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT a.idActividad, a.titulo, a.tipodeActividad, ci.idRoot, ci.idClasificacion " & _
             "FROM ClasificacionesItems ci, actividades a WHERE a.idActividad = ci.idProc AND ci.Procedencia = 'Actividad' " & _
             "AND ci.idRoot = @idRoot AND a.idActividad " & _
             "NOT IN (SELECT ag.idProc FROM Agenda ag WHERE idSalonVirtual = @idSalonVirtual AND Procedencia = 'Actividad') ORDER BY a.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idRoot", claveRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function
        Public Function GetActividadesNoEnAgenda(ByVal claveSalon As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT asv.idActividad, a.titulo, a.tipodeActividad " & _
             " FROM ActividadesSalonVirtual asv, actividades a WHERE asv.idActividad = a.idActividad and asv.idSalonVirtual=@idSalonVirtual " & _
             " AND  asv.idActividad " & _
             "NOT IN (SELECT ag.idProc FROM Agenda ag WHERE ag.idSalonVirtual=@idSalonVirtual AND ag.Procedencia = 'Actividad') ORDER BY a.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Function GetActividadesRespuestas(ByVal claveItem As Integer, ByVal claveSalon As Integer, ByVal claveUsuario As Integer, ByVal claveTipo As Integer, ByVal valorItem As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idActividad", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("valor", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("fechaEnvio", GetType(Date)))
            dTable.Columns.Add(New DataColumn("Calificacion", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("ValorCalificacion", GetType(Decimal)))
            dTable.Columns.Add(New DataColumn("idRespuesta", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("valorGeneral", GetType(Decimal)))
            dTable.Columns.Add(New DataColumn("tipo", GetType(String)))
            dTable.Columns.Add(New DataColumn("tipoActividad", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("Repetir", GetType(Boolean)))
            dTable.Columns.Add(New DataColumn("ValorItem", GetType(Integer)))

            Dim dRow As DataRow
            Dim myR As Contenidos.Respuesta
            Dim myitem As Know.ItemEvaluacion = New Know.ItemEvaluacion(claveItem)
            Select Case claveTipo
                Case 3

                    dRow = dTable.NewRow()
                    dRow(0) = myitem.id
                    dRow(1) = myitem.titulo
                    dRow(2) = 100 'myitem.valor
                    dRow(8) = claveTipo
                    dRow(9) = 0
                    dRow(10) = False
                    dRow(11) = myitem.valor

                    myR = New Contenidos.Respuesta(0, myitem.id, tipoObjeto.ItemEvaluacion.ToString, claveSalon, claveUsuario)

                    If Not myR.existe Then
                        dRow(4) = 0
                        dRow(5) = 0
                        dRow(6) = 0
                        dRow(7) = 0
                    Else
                        dRow(3) = myR.fechaEnvio
                        dRow(4) = myR.calificacion
                        dRow(5) = myR.calificacion  '(myR.Calificacion / 100) * myitem.Valor
                        dRow(6) = myR.id
                        dRow(7) = (CDec(dRow(5)) / 100) * valorItem
                    End If
                    dTable.Rows.Add(dRow)

                Case 1
                    Dim dr As System.Data.SqlClient.SqlDataReader = Me.GetDR(claveItem)
                    Do While dr.Read
                        dRow = dTable.NewRow()
                        dRow(0) = CType(dr("idActividad"), Integer)
                        dRow(1) = CType(dr("titulo"), String)
                        dRow(2) = CType(dr("valor"), Integer)
                        dRow(8) = claveTipo
                        dRow(9) = CType(dr("tipodeActividad"), Integer)
                        dRow(11) = myitem.valor

                        myR = New Contenidos.Respuesta(0, CInt(dr("idActividad")), tipoObjeto.Actividad.ToString, claveSalon, claveUsuario)

                        If Not myR.existe Then
                            dRow(4) = 0
                            dRow(5) = 0
                            dRow(6) = 0
                            dRow(7) = 0
                            dRow(10) = False
                        Else
                            dRow(3) = myR.fechaEnvio
                            dRow(4) = myR.calificacion
                            dRow(5) = (myR.calificacion / 100) * CInt(dr("valor"))
                            dRow(6) = myR.id
                            dRow(7) = (CDec(dRow(5)) / 100) * valorItem
                            dRow(10) = myR.repetir
                        End If


                        dTable.Rows.Add(dRow)
                    Loop
                    dr.Close()
            End Select

            Dim dView As New DataView(dTable)

            Return dView
        End Function


        Public Function SePuedeBorrar(ByVal claveProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer) As Boolean
            Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta

            Dim dr As SqlClient.SqlDataReader = myr.GetDR(claveProc, claveProcedencia, claveSalon)
            Dim regreso As Boolean = True
            If dr.Read Then
                regreso = False
            End If
            dr.Close()
            Return regreso


        End Function


        Public Function countActividadesSinResponder(claveUsuario As Integer) As Integer
            Dim sql As String = "select count(idActividadSalonVirtual) as num from (select asv.*,  isnull(r.idRespuesta, 0) as idRespuesta from ActividadesSalonVirtual asv left outer join Respuestas r on r.idProc = asv.idActividad and r.Procedencia='Actividad' and r.idUserProfile=@idUserProfile left outer join SalonesVirtuales svx on svx.idSalonVirtual=asv.idSalonVirtual  where asv.idSalonVirtual in (select  svup.idSalonVirtual  from SalonVirtualUserProfile svup   where svup.idUserProfile = @idUserProfile and svup.[status]<>'B' and  svx.FechaInicio <= GETDATE() and svx.FechaFin > DATEADD(day,1, GETDATE())) and asv.idActividad in (select ci.idProc from ClasificacionesItems ci where ci.idRoot=isnull(svx.idRoot,0)  and ci.Procedencia='Actividad' ) )as table1 where idRespuesta=0"


            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}
            Dim regreso As Integer = 0
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametros)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
                dr.Close()

            Return regreso
        End Function



        Public Function GetActiviadesPendientes(claveUsuario As Integer) As SqlDataReader
            Dim sql As String = "select  table1.*  from ( select asv.*, isnull(r.idRespuesta, 0) as idRespuesta, svx.Nombre as NombreSalon, a.titulo as Actividad, a.tipodeActividad, cix.idClasificacionItem,  ag.Fecha from ActividadesSalonVirtual asv left outer join Respuestas r on r.idProc = asv.idActividad and r.Procedencia='Actividad' and r.idUserProfile=@idUserProfile and r.idSalonVirtual=asv.idSalonVirtual left outer join SalonesVirtuales svx on svx.idSalonVirtual=asv.idSalonVirtual  left outer join Actividades a on a.idActividad=asv.idActividad left outer join ClasificacionesItems cix on cix.idProc=asv.idActividad and cix.Procedencia='Actividad' and cix.idRoot=svx.idRoot left outer join Agenda ag on ag.idProc=asv.idActividad and ag.Procedencia='Actividad' and ag.idSalonVirtual=asv.idSalonVirtual and ag.idUserProfile=0   where asv.idSalonVirtual in (select svu.idSalonVirtual from SalonVirtualUserProfile svu where svu.idUserProfile = @idUserProfile  and svu.status='I') and  svx.FechaInicio <= GETDATE() and svx.FechaFin > DATEADD(day,1, GETDATE()) union select asv.*, isnull(r.idRespuesta, 0) as idRespuesta, svx.Nombre as NombreSalon, a.titulo as Actividad, a.tipodeActividad, cix.idClasificacionItem,  ag.Fecha from ActividadesSalonVirtual asv left outer join Respuestas r on r.idProc = asv.idActividad and r.Procedencia='Actividad' and r.idUserProfile=@idUserProfile and r.idSalonVirtual=asv.idSalonVirtual left outer join SalonesVirtuales svx on svx.idSalonVirtual=asv.idSalonVirtual  left outer join Actividades a on a.idActividad=asv.idActividad left outer join ClasificacionesItems cix on cix.idProc=asv.idActividad and cix.Procedencia='Actividad' and cix.idRoot=svx.idRoot left outer join Agenda ag on ag.idProc=asv.idActividad and ag.Procedencia='Actividad' and ag.idSalonVirtual=asv.idSalonVirtual and ag.idUserProfile=@idUserProfile   where asv.idSalonVirtual in (select svu.idSalonVirtual from SalonVirtualUserProfile svu where svu.idUserProfile = @idUserProfile) and  svx.FechaInicio <= GETDATE() and svx.FechaFin > DATEADD(day,1, GETDATE()) ) as table1  where idRespuesta=0 and  fecha is not null order by fecha"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteReader(sql, parametros)
        End Function


        Public Function GetActiviadesPendientesDS(claveUsuario As Integer) As DataSet
            Dim sql As String = "select  table1.*  from ( select asv.*, isnull(r.idRespuesta, 0) as idRespuesta, svx.Nombre as NombreSalon, a.titulo as Actividad, a.tipodeActividad, cix.idClasificacionItem,  ag.Fecha from ActividadesSalonVirtual asv left outer join Respuestas r on r.idProc = asv.idActividad and r.Procedencia='Actividad' and r.idUserProfile=@idUserProfile and r.idSalonVirtual=asv.idSalonVirtual left outer join SalonesVirtuales svx on svx.idSalonVirtual=asv.idSalonVirtual  left outer join Actividades a on a.idActividad=asv.idActividad left outer join ClasificacionesItems cix on cix.idProc=asv.idActividad and cix.Procedencia='Actividad' and cix.idRoot=svx.idRoot left outer join Agenda ag on ag.idProc=asv.idActividad and ag.Procedencia='Actividad' and ag.idSalonVirtual=asv.idSalonVirtual and ag.idUserProfile=0   where asv.idSalonVirtual in (select svu.idSalonVirtual from SalonVirtualUserProfile svu where svu.idUserProfile = @idUserProfile and svu.status='I') and  svx.FechaInicio <= GETDATE() and svx.FechaFin > DATEADD(day,1, GETDATE()) union select asv.*, isnull(r.idRespuesta, 0) as idRespuesta, svx.Nombre as NombreSalon, a.titulo as Actividad, a.tipodeActividad, cix.idClasificacionItem,  ag.Fecha from ActividadesSalonVirtual asv left outer join Respuestas r on r.idProc = asv.idActividad and r.Procedencia='Actividad' and r.idUserProfile=@idUserProfile and r.idSalonVirtual=asv.idSalonVirtual left outer join SalonesVirtuales svx on svx.idSalonVirtual=asv.idSalonVirtual  left outer join Actividades a on a.idActividad=asv.idActividad left outer join ClasificacionesItems cix on cix.idProc=asv.idActividad and cix.Procedencia='Actividad' and cix.idRoot=svx.idRoot left outer join Agenda ag on ag.idProc=asv.idActividad and ag.Procedencia='Actividad' and ag.idSalonVirtual=asv.idSalonVirtual and ag.idUserProfile=@idUserProfile   where asv.idSalonVirtual in (select svu.idSalonVirtual from SalonVirtualUserProfile svu where svu.idUserProfile = @idUserProfile) and  svx.FechaInicio <= GETDATE() and svx.FechaFin > DATEADD(day,1, GETDATE()) ) as table1  where idRespuesta=0 and  fecha is not null order by fecha"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(sql, parametros)
        End Function

    End Class
End Namespace
