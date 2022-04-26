Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Know
    Public NotInheritable Class ItemEvaluacion
        Inherits DBObject

        Private idItemEvaluacion As Integer
        Public salonVirtual As Know.SalonVirtual
        Public titulo As String
        Public valor As Integer
        Public tipoItem As TipoItemEvaluacion
        Public claveEstrategia As String = String.Empty
        Public fecha As Date = Date.MinValue

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idItemEvaluacion
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ItemEvaluacion
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idItemEvaluacion = @idItemEvaluacion"

            Dim parameters As SqlParameter() = {New SqlParameter("@idItemEvaluacion", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idItemEvaluacion = CType(dr("idItemEvaluacion"), Integer)
                Me.salonVirtual = New Know.SalonVirtual(CType(dr("idSalonVirtual"), Integer), False)
                Me.titulo = CType(dr("titulo"), String)
                Me.valor = CType(dr("valor"), Integer)
                Me.tipoItem = CType(dr("tipoItem"), String)
                Me.claveEstrategia = CType(dr("claveEstrategia"), String)
                If Not Convert.IsDBNull(dr("fecha")) Then
                    Me.fecha = CDate(dr("fecha"))
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal clavePrincipal As Integer, ByVal crearobjetos As Boolean)
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idItemEvaluacion = @idItemEvaluacion"

            Dim parameters As SqlParameter() = {New SqlParameter("@idItemEvaluacion", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idItemEvaluacion = CType(dr("idItemEvaluacion"), Integer)
                'Me.salonVirtual = New Know.SalonVirtual(CType(dr("idSalonVirtual"), Integer), False)
                Me.titulo = CType(dr("titulo"), String)
                Me.valor = CType(dr("valor"), Integer)
                Me.tipoItem = CType(dr("tipoItem"), String)
                Me.claveEstrategia = CType(dr("claveEstrategia"), String)
                If Not Convert.IsDBNull(dr("fecha")) Then
                    Me.fecha = CDate(dr("fecha"))
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub


        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [ItemesEvaluacion] ([idSalonVirtual], [titulo], [valor], [tipoItem], [claveEstrategia], fecha) " &
                 "VALUES (@idSalonVirtual, @titulo, @valor, @tipoItem, @claveEstrategia, @fecha)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idSalonVirtual", Me.salonVirtual.id),
                 New SqlParameter("@titulo", Me.titulo),
                 New SqlParameter("@valor", Me.valor),
                 New SqlParameter("@tipoItem", Me.tipoItem),
                  New SqlParameter("@claveEstrategia", Me.claveEstrategia),
                  New SqlParameter("@fecha", Me.fecha)}

                Me.idItemEvaluacion = Me.ExecuteNonQuery(queryString, parametros, True)

            'If Me.idItemEvaluacion > 0 Then
            '    If Me.salonVirtual.claveAux1 <> "" Then
            '        Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(Me.salonVirtual.claveAux1)
            '        If mycg.Estado < 3 Then
            '            Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion()
            '            mycge.Curso_Carga_Id = Me.salonVirtual.claveAux1
            '            mycge.Nombre_Evaluacion = Me.titulo
            '            mycge.Fecha = Date.Today
            '            mycge.Estrategia_Id = Me.claveEstrategia
            '            mycge.Valor = Me.valor
            '            mycge.Tipo = "%"
            '            mycge.Evaluacion_Skolar = Me.idItemEvaluacion
            '            mycge.Fecha = Me.fecha
            '            mycge.Add()

            '        End If
            '    End If



            'End If




            Return 1
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE ItemesEvaluacion SET idSalonVirtual=@idSalonVirtual, titulo=@titulo, " &
                 "valor=@valor, tipoItem=@tipoItem, claveEstrategia=@claveEstrategia, fecha=@fecha WHERE idItemEvaluacion = @idItemEvaluacion"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idItemEvaluacion", Me.idItemEvaluacion),
                 New SqlParameter("@idSalonVirtual", Me.salonVirtual.id),
                 New SqlParameter("@titulo", Me.titulo),
                 New SqlParameter("@valor", Me.valor),
                 New SqlParameter("@tipoItem", Me.tipoItem),
                  New SqlParameter("@claveEstrategia", Me.claveEstrategia),
                  New SqlParameter("@fecha", Me.fecha)}

                Me.ExecuteNonQuery(queryString, parametros)


            'If Me.salonVirtual.claveAux1 <> "" Then
            '    Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(Me.salonVirtual.claveAux1)
            '    If mycg.Estado < 3 Then
            '        Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(Me.idItemEvaluacion)
            '        mycge.Curso_Carga_Id = Me.salonVirtual.claveAux1
            '        mycge.Nombre_Evaluacion = Me.titulo
            '        mycge.Estrategia_Id = Me.claveEstrategia
            '        mycge.Valor = Me.valor
            '        mycge.Tipo = "%"
            '        mycge.Evaluacion_Skolar = Me.idItemEvaluacion
            '        mycge.Fecha = Me.fecha

            '        If mycge.existe Then
            '            mycge.Update()
            '        Else
            '            ' mycge.Fecha = Date.Today
            '            mycge.Add()
            '        End If


            '    End If
            'End If



            Return 1

        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM ItemesEvaluacion WHERE idItemEvaluacion = @idItemEvaluacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idItemEvaluacion", Me.idItemEvaluacion)}
            Me.ExecuteNonQuery(queryString, parametros)

            'Dim mycge As UM.Carga_Grupo_Evaluacion = New UM.Carga_Grupo_Evaluacion(Me.idItemEvaluacion)
            'If mycge.existe Then
            '    mycge.Remove()
            'End If



            Return 1
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal claveSalon As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idSalonVirtual = @idSalonVirtual ORDER BY tipoItem, titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveSalon As Integer, ByVal claveTipo As String) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idSalonVirtual = @idSalonVirtual " &
             "AND tipoItem = @tipoItem ORDER BY titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@tipoItem", claveTipo)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function




        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal claveSalon As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idSalonVirtual = @idSalonVirtual ORDER BY tipoItem, titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveSalon As Integer, ByVal claveTipo As String) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM ItemesEvaluacion WHERE idSalonVirtual = @idSalonVirtual " &
             "AND tipoItem = @tipoItem ORDER BY titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@tipoItem", claveTipo)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Dim regreso As Boolean
            Dim myActSV As New Contenidos.ActividadSalonVirtual
            Dim dr As SqlClient.SqlDataReader = myActSV.GetDR(Me.idItemEvaluacion)
            If dr.HasRows Then
                regreso = True
            End If
            dr.Close()

            Return regreso
        End Function

        Public Function GetPorcentajePonderado(ByVal claveSalon As Integer) As Integer
            Dim queryString As String = "SELECT SUM(valor) as num FROM ItemesEvaluacion WHERE idSalonVirtual = @idSalonVirtual"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon)}

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

        Public Function GetPromedioItemEvaluacion(ByVal claveItem As Integer, ByVal claveUsuario As Integer, ByVal claveSalon As Integer, ByVal tipo As String) As Integer
            Dim sql As String = ""

            Select Case tipo
                Case "Actividad"
                    sql = "select sum(puntospromedio) as num from ( select r.idrespuesta, r.calificacion, asv.valor, ie.valor as valorie,  " &
                        " ((r.calificacion * asv.valor)/100.00)  as puntosPromedio " &
                        " from respuestas r, actividadessalonvirtual asv, itemesevaluacion ie" &
                        " where r.idProc = asv.idActividad And asv.iditemevaluacion = ie.iditemevaluacion  " &
                        " and ie.iditemevaluacion=@idItemEvaluacion and  r.idUserProfile=@idUserProfile and r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='Actividad' )  as tablaPromedios"
                Case "ItemEvaluacion"
                    sql = "select sum(puntospromedio) as num from (select r.idrespuesta, r.calificacion, 777 as valor, ie.valor as valorie,  " &
                        " r.calificacion as puntosPromedio " &
                        " from respuestas r,  itemesevaluacion ie " &
                        " where r.idProc = ie.iditemevaluacion " &
                        " and ie.iditemevaluacion=@idItemEvaluacion  and r.idUserProfile=@idUserProfile and r.idSalonVirtual=@idSalonVirtual and r.idraiz=0 and r.Procedencia='ItemEvaluacion') " &
                        " as tablaPromedios"
            End Select


            Dim parametros As SqlParameter() = {New SqlParameter("@idItemEvaluacion", claveItem), New SqlParameter("@idUserProfile", claveUsuario), New SqlParameter("@idSalonVirtual", claveSalon)}

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

        '++++++++++ DEPRECATED: Utilizar EnUso() ++++++++++++
        Public Function SePuedeBorrar() As Boolean
            Dim regreso As Boolean = True
            Dim myActSV As New Contenidos.ActividadSalonVirtual
            Dim dr As SqlClient.SqlDataReader = myActSV.GetDR(Me.idItemEvaluacion)
            If dr.Read Then
                regreso = False
            End If
            dr.Close()

            Return regreso
        End Function

    End Class


    Public Enum TipoItemEvaluacion As Byte
        Computo = 1 'C	Computo exacto
        Ranking = 2 'R Ranking que los compañeros y maestros asignan valores a las respuestas del alumno
        Subjetivo = 3 'S	el maestro asigna los puntos directamente
    End Enum



End Namespace

