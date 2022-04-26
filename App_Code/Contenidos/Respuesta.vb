Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class Respuesta
		Inherits DBObject

        Private idRespuesta As Integer
        Public idUserProfile As Integer
        Public idRaiz As Integer
        Public idProc As Integer
        Public procedencia As String
        Public idSalonVirtual As Integer
        Public titulo As String
        Public texto As String
        Public observaciones As String
        Public calificacion As Integer
        Public fechaEnvio As Date
        Public fechaRevision As Date
        Public status As StatusRespuesta
        Public repetir As Boolean
        Public fechaRegistro As DateTime = Date.Now

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRespuesta
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Respuesta
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRespuesta = @idRespuesta"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRespuesta", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuesta = CType(dr("idRespuesta"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.idRaiz = CType(dr("idRaiz"), Integer)
                Me.idProc = CType(dr("idProc"), Integer)
                Me.procedencia = CType(dr("procedencia"), String)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.titulo = CType(dr("titulo"), String)
                Me.texto = CType(dr("texto"), String)
                Me.observaciones = CType(dr("observaciones"), String)
                Me.calificacion = CType(dr("calificacion"), Integer)
                Me.fechaEnvio = CType(dr("fechaEnvio"), Date)
                Me.fechaRevision = CType(dr("fechaRevision"), Date)
                Me.status = CType(dr("status"), String)
                Me.repetir = CType(dr("repetir"), Boolean)
                If Not Convert.IsDBNull(dr("fechaRegistro")) Then
                    Me.fechaRegistro = CType(dr("fechaRegistro"), DateTime)
                Else
                    Me.fechaRegistro = Me.fechaEnvio
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveRaiz As Integer, ByVal claveProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer, ByVal claveUsuario As Integer)
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRaiz = @idRaiz AND idProc = @idProc " & _
             "AND procedencia = @procedencia AND idSalonVirtual = @idSalonVirtual AND  idUserProfile = @IdUserProfile"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRaiz", claveRaiz), _
             New SqlParameter("@idProc", claveProc), _
             New SqlParameter("@procedencia", claveProcedencia), _
             New SqlParameter("@idSalonVirtual", claveSalon), _
             New SqlParameter("@idUserProfile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRespuesta = CType(dr("idRespuesta"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.idRaiz = CType(dr("idRaiz"), Integer)
                Me.idProc = CType(dr("idProc"), Integer)
                Me.procedencia = CType(dr("procedencia"), String)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.titulo = CType(dr("titulo"), String)
                Me.texto = CType(dr("texto"), String)
                Me.observaciones = CType(dr("observaciones"), String)
                Me.calificacion = CType(dr("calificacion"), Integer)
                Me.fechaEnvio = CType(dr("fechaEnvio"), Date)
                Me.fechaRevision = CType(dr("fechaRevision"), Date)
                Me.status = CType(dr("status"), StatusRespuesta)
                Me.repetir = CType(dr("repetir"), Boolean)
                If Not Convert.IsDBNull(dr("fechaRegistro")) Then
                    Me.fechaRegistro = CType(dr("fechaRegistro"), DateTime)
                Else
                    Me.fechaRegistro = Me.fechaEnvio
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Public Overrides Function Add() As Integer
            'Try
            Dim queryString As String = "INSERT INTO [Respuestas] ([idUserProfile], [idRaiz], [idProc], [procedencia], [idSalonVirtual], " & _
             "[titulo], [texto], [observaciones], [calificacion], [fechaEnvio], [fechaRevision], [status], [repetir], fechaRegistro) " & _
             "VALUES (@idUserProfile, @idRaiz, @idProc, @procedencia, @idSalonVirtual, @titulo, " & _
             "@texto, @observaciones, @calificacion, @fechaEnvio, @fechaRevision, @status, @repetir, @fechaRegistro)"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idUserProfile", Me.idUserProfile), _
              New SqlParameter("@idRaiz", Me.idRaiz), _
              New SqlParameter("@idProc", Me.idProc), _
              New SqlParameter("@procedencia", Me.procedencia), _
              New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
              New SqlParameter("@titulo", Me.titulo), _
              New SqlParameter("@texto", Me.texto), _
              New SqlParameter("@observaciones", Me.observaciones), _
              New SqlParameter("@calificacion", Me.calificacion), _
              New SqlParameter("@fechaEnvio", Me.fechaEnvio), _
              New SqlParameter("@fechaRevision", Me.fechaRevision), _
              New SqlParameter("@status", Me.status), _
              New SqlParameter("@repetir", Me.repetir), _
              New SqlParameter("@fechaRegistro", Date.Now)}


            If Me.idUserProfile > 0 Then
                Dim objRespuesta As New Respuesta(Me.idRaiz, Me.idProc, Me.procedencia, Me.idSalonVirtual, Me.idUserProfile)
                If Not objRespuesta.existe Then
                    Me.idRespuesta = Me.ExecuteNonQuery(queryString, parametros, True)
                Else
                    objRespuesta.calificacion = Me.calificacion
                    objRespuesta.fechaRevision = Date.Now
                    objRespuesta.Update()
                    Me.idRespuesta = objRespuesta.id

                End If
            End If


            '	Catch ex As Exception
            '      Dim m As String = ex.Message
            '   End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            'Try
            Dim queryString As String = "UPDATE [Respuestas] SET [Calificacion]=@Calificacion, [FechaEnvio]=@FechaEnvio, " & _
             "[idProc]=@idProc, [idRaiz]=@idRaiz, [texto]=@texto, [FechaRevision]=@FechaRevision, " & _
             "[Repetir]=@Repetir, [procedencia]=@procedencia, [Status]=@Status, [idUserProfile]=@idUserProfile, " & _
             "[Observaciones]=@Observaciones, [idSalonVirtual]=@idSalonVirtual WHERE idRespuesta = @idRespuesta"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idRespuesta", Me.idRespuesta), _
             New SqlParameter("@idUserProfile", Me.idUserProfile), _
              New SqlParameter("@idRaiz", Me.idRaiz), _
              New SqlParameter("@idProc", Me.idProc), _
              New SqlParameter("@procedencia", Me.procedencia), _
              New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
              New SqlParameter("@titulo", Me.titulo), _
              New SqlParameter("@texto", Me.texto), _
              New SqlParameter("@observaciones", Me.observaciones), _
              New SqlParameter("@calificacion", Me.calificacion), _
              New SqlParameter("@fechaEnvio", Me.fechaEnvio), _
              New SqlParameter("@fechaRevision", Me.fechaRevision), _
              New SqlParameter("@status", Me.status), _
              New SqlParameter("@repetir", Me.repetir)}

            If Me.idUserProfile > 0 Then
                Me.ExecuteNonQuery(queryString, parametros)
            End If
            Dim regreso As Integer = 1

            'Dim myuser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(Me.idUserProfile, 4, "xyz")
            'Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(Me.idSalonVirtual, False)


            'Dim mysvup As New Know.SalonVirtualUserProfile(myuser.idUserProfile, mysv.id, False)

            ''    Try

            'Dim mysvkca As UM.Krdx_Curso_Act = New UM.Krdx_Curso_Act(myuser.claveAux1, mysv.claveAux1)
            '    ' revisa si el alumno esta inscrito.. solo si esta inscrito pueden alterarse o sincronizar datos 
            '    'validación necesaria por motivo de calificacion diferida y alguna otra cosa

            '    If mysvkca.tipocal_id = "M" Or mysvkca.tipocal_id = "I" Then

            '        regreso = 2

            '        If Me.idRaiz = 0 Then

            '            regreso = 3

            '            Select Case procedencia
            '                Case "Actividad"

            '                    Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual(Me.idProc, Me.idSalonVirtual)
            '                    Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(myasv.idItemEvaluacion)
            '                    Dim mycga As UM.Carga_Grupo_Actividad = New UM.Carga_Grupo_Actividad(myasv.id)

            '                    If Not mysvup.calificacionDiferida Then
            '                        Dim myka As UM.Krdx_Alumno_Activ = New UM.Krdx_Alumno_Activ(myuser.claveAux1, myasv.id, mysv.claveAux1)
            '                        myka.Actividad_Skolar = myasv.id
            '                        myka.Actividad_Id = mycga.id
            '                        myka.Codigo_Personal = myuser.claveAux1
            '                        myka.Curso_Carga_ID = mysv.claveAux1
            '                        myka.Nota = Me.calificacion
            '                        regreso = 31

            '                        If myka.existe Then
            '                            myka.Update()
            '                        Else

            '                            Dim mykatemporal As UM.Krdx_Alumno_Activ = New UM.Krdx_Alumno_Activ(myuser.claveAux1, mycga.id, mysv.claveAux1, True)
            '                            If mykatemporal.existe And mykatemporal.Actividad_Skolar = 0 Then
            '                                mykatemporal.Actividad_Skolar = myasv.id
            '                                mykatemporal.Nota = Me.calificacion
            '                                mykatemporal.Update()
            '                                regreso = 32
            '                            Else
            '                                myka.Add()
            '                                regreso = 33
            '                            End If


            '                        End If







            '                        Dim myie As Know.ItemEvaluacion = New Know.ItemEvaluacion
            '                        Dim myke As UM.Krdx_Alumno_Eval = New UM.Krdx_Alumno_Eval(myasv.idItemEvaluacion, myuser.claveAux1, mysv.claveAux1)
            '                        myke.Codigo_Personal = myuser.claveAux1
            '                        myke.Curso_Carga_Id = mysv.claveAux1
            '                        myke.Evaluacion_Skolar = myasv.idItemEvaluacion
            '                        myke.Evaluacion_Id = mycge.Evaluacion_id
            '                        myke.Nota = myie.GetPromedioItemEvaluacion(myasv.idItemEvaluacion, Me.idUserProfile, Me.idSalonVirtual, "Actividad")




            '                        If myke.existe Then
            '                            myke.Update()
            '                            regreso = 34
            '                        Else

            '                            If mycge.Evaluacion_id > 0 Then
            '                                Dim myketemporal As UM.Krdx_Alumno_Eval = New UM.Krdx_Alumno_Eval(mycge.Evaluacion_id, myuser.claveAux1, mysv.claveAux1, True)
            '                                If myketemporal.existe And myketemporal.Evaluacion_Skolar = 0 Then
            '                                    myketemporal.Evaluacion_Skolar = myasv.idItemEvaluacion
            '                                    myketemporal.Nota = myie.GetPromedioItemEvaluacion(myasv.idItemEvaluacion, Me.idUserProfile, Me.idSalonVirtual, "Actividad")
            '                                    myketemporal.Update_Skolar()
            '                                    regreso = 35
            '                                Else
            '                                    myke.Add()
            '                                    regreso = 36
            '                                End If
            '                            End If


            '                        End If



            '                    End If



            '                Case "ItemEvaluacion"
            '                    regreso = 4
            '                    'Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual(Me.idProc, Me.idSalonVirtual)
            '                    Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(Me.idProc)
            '                    ' Dim mycga As UM.Carga_Grupo_Actividad = New UM.Carga_Grupo_Actividad(myasv.id)
            '                    If mycge.existe Then
            '                        regreso = 5
            '                        If Not mysvup.calificacionDiferida Then

            '                            regreso = 6
            '                            Dim myie As Know.ItemEvaluacion = New Know.ItemEvaluacion(Me.idProc, True)
            '                            Dim myke As UM.Krdx_Alumno_Eval = New UM.Krdx_Alumno_Eval(Me.idProc, myuser.claveAux1, mysv.claveAux1)
            '                            myke.Codigo_Personal = myuser.claveAux1
            '                            myke.Curso_Carga_Id = mysv.claveAux1
            '                            myke.Evaluacion_Skolar = Me.idProc
            '                            myke.Evaluacion_Id = mycge.Evaluacion_id
            '                            myke.Nota = myie.GetPromedioItemEvaluacion(Me.idProc, Me.idUserProfile, Me.idSalonVirtual, "ItemEvaluacion")

            '                            If myke.existe Then
            '                                myke.Update()
            '                                regreso = 7
            '                            Else
            '                                myke.Add()
            '                                regreso = 8
            '                            End If

            '                        End If
            '                    End If


            '                    mycge = Nothing

            '            End Select
            '        End If ' termina validación de me.raizid

            '    End If '

            'Catch ex As Exception
            '    ' aqui debe cambiarse el status de salonvirtualsinconizado


            '    mysv.sincronizado = False
            '    mysv.Update()


            'End Try










            ' End If
            Return regreso

            'Catch ex As Exception
            'Return 0
            'End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Respuestas WHERE idRespuesta = @idRespuesta"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRespuesta", Me.idRespuesta)}

            Try
                Return Me.ExecuteNonQuery(queryString, parametros)
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal claveProc As Integer, ByVal claveProcedencia As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idProc = @idProc AND procedencia = @procedencia"

            Dim parametros As SqlParameter() = {New SqlParameter("@idProc", claveProc), New SqlParameter("@procedencia", claveProcedencia)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overloads Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(ByVal claveRaiz As Integer) As Integer
            Dim queryString As String = "SELECT count(idRespuesta) as num FROM Respuestas WHERE idRaiz = @idRaiz"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRaiz", claveRaiz)}

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


        Public Overloads Function Count(ByVal claveSalon As Integer, ByVal claveUsuario As Integer) As Integer
            Dim queryString As String = "SELECT count(idRespuesta) as num FROM Respuestas WHERE " & _
            " idSalonVirtual=@idSalonVirtual and idUserProfile=@idUserProfile and Procedencia='Actividad' and idraiz=0 "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idUserProfile", claveUsuario)}

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

        Public Function CountActividadesSalon(ByVal claveSalon As Integer) As Integer
            Dim queryString As String = "SELECT count(idRespuesta) as num FROM Respuestas WHERE " & _
           " idSalonVirtual=@idSalonVirtual  and Procedencia='Actividad' and idraiz=0 "

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

        Public Function CountEnviadasParaMeaestro(ByVal claveSalonVirtual As Integer) As Integer
            Dim queryString As String = "select count(r.idRespuesta) as num   from Respuestas r  where r.procedencia = 'Actividad' and r.idRaiz = 0  and r.idSalonVirtual = @idSalonVirtual  and (r.status = 1) "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
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
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(Me.idProc, Me.procedencia)
            Dim regreso As Boolean = dr.HasRows
            dr.Close()

            Return regreso
        End Function

        Public Function GetEnviadasParaAlumno(ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT r.idRespuesta, r.titulo, r.idSalonVirtual, r.fechaEnvio, r.status, a.idActividad, " & _
             "a.titulo AS tituloActividad, a.tipodeactividad, a.quienCalifica, up.nombre + ' ' + up.apellidos AS nombre " & _
             "FROM Respuestas r, Actividades a, UserProfiles up WHERE up.idUserProfile = r.idUserProfile And r.idProc = a.idActividad " & _
             "AND a.quienCalifica = 2 AND r.idUserprofile <> @idUserProfile AND r.procedencia = 'Actividad' AND r.idRaiz = 0 " & _
             "AND r.idSalonVirtual = @idSalonVirtual AND (@idUserProfile NOT IN " & _
             "(SELECT resp.idUserProfile FROM Respuestas resp WHERE resp.idRaiz = r.idRespuesta)) "

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
             New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetEnviadasParaMeaestro(ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "select r.idRespuesta, r.titulo, r.idSalonVirtual, r.fechaEnvio, r.status, a.idActividad, " &
             " a.titulo  as tituloActividad, a.tipodeactividad, a.quienCalifica, up.nombre + ' ' + up.apellidos as nombrecompleto " &
             " from Respuestas r, Actividades a, UserProfiles up " &
             " where up.idUserProfile = r.idUserProfile And r.idProc = a.idActividad " &
             " and r.procedencia = 'Actividad' and r.idRaiz = 0  and r.idSalonVirtual = @idSalonVirtual  " &
             "and ((r.status = 1)) order by r.fechaenvio desc "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetEnviadasParaMeaestroDS(ByVal claveSalonVirtual As Integer) As DataSet
            Dim queryString As String = "select r.idRespuesta, r.titulo, r.idSalonVirtual, r.fechaEnvio, r.status, a.idActividad, " &
             " a.titulo  as tituloActividad, a.tipodeactividad, a.quienCalifica, up.nombre, up.apellidos, up.nombre + ' ' + up.apellidos as nombrecompleto " &
             " from Respuestas r, Actividades a, UserProfiles up " &
             " where up.idUserProfile = r.idUserProfile And r.idProc = a.idActividad " &
             " and r.procedencia = 'Actividad' and r.idRaiz = 0  and r.idSalonVirtual = @idSalonVirtual  " &
             "and ((r.status = 1)) order by r.fechaenvio desc "

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Function GetRespuestas(ByVal claveActividad As Integer, ByVal claveSalonVirtual As Integer, ByVal claveUsuario As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT r.*,  u.nombre + ' ' +  u.apellidos as nombre FROM Respuestas r, UserProfiles u " & _
             " WHERE u.idUserProfile = r.idUserProfile AND r.iduserprofile <> @idUserProfile AND r.idRaiz = 0 " & _
             "AND r.idProc = @idProc AND r.procedencia = 'Actividad' AND r.idSalonVirtual = @idSalonVirtual"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idProc", claveActividad), _
             New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
             New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetRespuestasRaiz(ByVal claveRaiz As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT r.*,  u.nombre + ' ' +  u.apellidos as nombre FROM Respuestas r, UserProfiles u " & _
             "WHERE u.idUserProfile = r.idUserProfile AND r.idRaiz = @idRaiz"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRaiz", claveRaiz)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function CountRaiz(ByVal claveRaiz As Integer, ByVal claveValor As Integer) As Integer
            Dim queryString As String = "SELECT count(idRespuesta) as num FROM Respuestas WHERE idRaiz = @idRaiz AND calificacion = @calificacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRaiz", claveRaiz), New SqlParameter("@calificacion", claveValor)}

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

        Public Function GetPromedioRaiz(ByVal claveRaiz As Integer) As Integer
            Dim queryString As String = "SELECT avg(calificacion) as num FROM Respuestas WHERE idRaiz = @idRaiz"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRaiz", claveRaiz)}

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

        Public Function GetPromedioActividad(ByVal claveRaiz As Integer, ByVal claveidProc As Integer, ByVal claveProcedencia As tipoObjeto, ByVal clavesalonvirtual As Integer) As Decimal
            Dim queryString As String = "SELECT avg(calificacion) as num FROM Respuestas WHERE idRaiz = @idRaiz and idProc=@idProc and Procedencia=@Procedencia and idSalonVirtual=@idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRaiz", claveRaiz), _
                                                New SqlParameter("@idProc", claveidProc), _
                                                New SqlParameter("@Procedencia", claveProcedencia.ToString), _
                                                New SqlParameter("@idSalonVirtual", clavesalonvirtual)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = Convert.ToDecimal(dr("num"))
                End If
            End If
            dr.Close()

            Return numero
        End Function


        Public Function GetPromedioActividad(ByVal clavesalonvirtual As Integer, ByVal claveusuario As Integer) As Decimal
            Dim queryString As String = "SELECT avg(calificacion) as num FROM Respuestas WHERE " & _
            " idRaiz=0 and idUserProfile=@idUserProfile  and idSalonVirtual=@idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveusuario), _
                                                New SqlParameter("@idSalonVirtual", clavesalonvirtual)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = Convert.ToDecimal(dr("num"))
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Function GetPromedioActividad(ByVal clavesalonvirtual As Integer) As Decimal
            Dim queryString As String = "SELECT avg(calificacion) as num FROM Respuestas WHERE " & _
            " idRaiz=0 and idSalonVirtual=@idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", clavesalonvirtual)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = Convert.ToDecimal(dr("num"))
                End If
            End If
            dr.Close()

            Return numero
        End Function



        Public Overloads Function GetDR(ByVal claveProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer) As SqlClient.SqlDataReader
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRaiz = @idRaiz AND idProc = @idProc " & _
             "AND procedencia = @procedencia AND idSalonVirtual = @idSalonVirtual "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRaiz", 0), _
             New SqlParameter("@idProc", claveProc), _
             New SqlParameter("@procedencia", claveProcedencia), _
             New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parameters)


        End Function


        Public Overloads Function GetDS(ByVal claveProc As Integer, ByVal claveProcedencia As String, ByVal claveSalon As Integer) As DataSet
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRaiz = @idRaiz AND idProc = @idProc " & _
             "AND procedencia = @procedencia AND idSalonVirtual = @idSalonVirtual "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRaiz", 0), _
             New SqlParameter("@idProc", claveProc), _
             New SqlParameter("@procedencia", claveProcedencia), _
             New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parameters)


        End Function

        Public Overloads Function GetDR(ByVal claveSalon As Integer) As SqlClient.SqlDataReader
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRaiz = @idRaiz AND idSalonVirtual = @idSalonVirtual "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRaiz", 0), _
             New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parameters)


        End Function


        Public Overloads Function GetDS(ByVal claveSalon As Integer) As DataSet
            Dim queryString As String = "SELECT * FROM Respuestas WHERE idRaiz = @idRaiz AND idSalonVirtual = @idSalonVirtual "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRaiz", 0), _
             New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parameters)


        End Function



        '++++++++++++  DEPRECATED: usar EnUso() +++++++++++++++
        Public Function HayRespuestas(ByVal claveProc As Integer, ByVal claveprocedencia As String) As Boolean
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveProc, claveprocedencia)
            Dim regreso As Boolean = dr.HasRows
            dr.Close()

            Return regreso
        End Function

    End Class


    Public Enum StatusRespuesta As Byte 'E=Enviada; C=Calificada; R=Regresada; N=No enviada
        Enviada = 1
        Calificada = 2
        Regresada = 3
        NoEnviada = 4
    End Enum



End Namespace
