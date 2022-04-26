Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Lego
	Public NotInheritable Class ClasificacionItem
		Inherits DBObject

#Region "Variables"
		Private idClasificacionItem As Integer
		Public idClasificacion As Integer
		Public idRoot As Integer
		Public idProc As Integer
		Public procedencia As tipoObjeto
		Public orden As Integer

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idClasificacionItem
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.ClasificacionItem
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM ClasificacionesItems WHERE idClasificacionItem = @idClasificacionItem"

			Dim parameters As SqlParameter() = {New SqlParameter("@idClasificacionItem", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idClasificacionItem = CType(dr("idClasificacionItem"), Integer)
				Me.idClasificacion = CType(dr("idClasificacion"), Integer)
				Me.idRoot = CType(dr("idRoot"), Integer)
				Me.idProc = CType(dr("idProc"), Integer)
				Me.procedencia = CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
				Me.orden = CType(dr("orden"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveRoot As Integer, ByVal claveProc As Integer, ByVal claveProcedencia As String)
            Dim queryString As String = "SELECT * FROM ClasificacionesItems WHERE idRoot = @idRoot AND idProc = @idProc AND procedencia = @procedencia"

            Dim parameters As SqlParameter() = { _
			 New SqlParameter("@idRoot", claveRoot), _
			 New SqlParameter("@idProc", claveProc), _
			 New SqlParameter("@procedencia", claveProcedencia)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idClasificacionItem = CType(dr("idClasificacionItem"), Integer)
				Me.idClasificacion = CType(dr("idClasificacion"), Integer)
				Me.idRoot = CType(dr("idRoot"), Integer)
				Me.idProc = CType(dr("idProc"), Integer)
				Me.procedencia = CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
				Me.orden = CType(dr("orden"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal claveClasificacion As Integer, ByVal claveOrden As Integer)
			Dim queryString As String = "SELECT * FROM ClasificacionesItems WHERE idClasificacion = @idClasificacion AND orden = @orden"

			Dim parameters As SqlParameter() = { _
			 New SqlParameter("@idClasificacion", claveClasificacion), _
			 New SqlParameter("@orden", claveOrden)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idClasificacionItem = CType(dr("idClasificacionItem"), Integer)
				Me.idClasificacion = CType(dr("idClasificacion"), Integer)
				Me.idRoot = CType(dr("idRoot"), Integer)
				Me.idProc = CType(dr("idProc"), Integer)
				Me.procedencia = CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
				Me.orden = CType(dr("orden"), Integer)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [ClasificacionesItems] ([idClasificacion], [idRoot], [idProc], " & _
				 "[procedencia], [orden]) VALUES (@idClasificacion, @idRoot, @idProc, @procedencia, @orden)"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idClasificacion", Me.idClasificacion), _
				  New SqlParameter("@idRoot", Me.idRoot), _
				  New SqlParameter("@idProc", Me.idProc), _
				  New SqlParameter("@procedencia", Me.procedencia.ToString), _
				  New SqlParameter("@orden", Me.GetOrden)}

				Me.idClasificacionItem = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [ClasificacionesItems] SET [idClasificacion]=@idClasificacion, [idRoot]=@idRoot, " & _
				 "[idProc]=@idProc, [procedencia]=@procedencia, [orden]=@orden WHERE idClasificacionItem = @idClasificacionItem"

				Dim parametros As SqlParameter() = { _
				  New SqlParameter("@idClasificacionItem", Me.idClasificacionItem), _
				  New SqlParameter("@idClasificacion", Me.idClasificacion), _
				  New SqlParameter("@idRoot", Me.idRoot), _
				  New SqlParameter("@idProc", Me.idProc), _
				  New SqlParameter("@procedencia", Me.procedencia.ToString), _
				  New SqlParameter("@orden", Me.orden)}

				Return Me.ExecuteNonQuery(queryString, parametros)

			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM ClasificacionesItems WHERE idClasificacionItem = @idClasificacionItem"

			Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacionItem", Me.idClasificacionItem)}

			Dim rowsAffected As Integer

			rowsAffected = Me.ExecuteNonQuery(queryString, parametros)

            'Select Case Me.procedencia
            '	Case tipoObjeto.Contenido
            '		Dim myContenido As New Contenidos.Contenido(Me.idProc)
            '		myContenido.Remove()
            '	Case tipoObjeto.Actividad
            '		Dim myActividad As New Contenidos.Actividad(Me.idProc)
            '		myActividad.Remove()
            '	Case tipoObjeto.Foro
            '		Dim myForo As New Contenidos.Foro(Me.idProc)
            '		myForo.Remove()
            'End Select

			Return rowsAffected
		End Function

		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
        End Function

        Public Overloads Function getDRProcedencia(ByVal claveprocedencia As String) As SqlDataReader

            Dim sql As String = "select * from clasificacionesItems where procedencia=@Procedencia"
            Dim param As SqlParameter() = {New SqlParameter("@Procedencia", claveprocedencia)}
            Return Me.ExecuteReader(sql, param)
        End Function


        Public Overloads Function getDRObjetosAprendizaje(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, c.titulo from clasificacionesItems ci, contenidos c  where ci.procedencia='Contenido' and ci.idproc=c.idContenido and ci.idClasificacion=@idClasificacion order by c.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function

        Public Overloads Function getDRObjetosAprendizajeContenidos(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, c.titulo from clasificacionesItems ci, contenidos c  where ci.procedencia='Contenido' and ci.idproc=c.idContenido and ci.idClasificacion=@idClasificacion and c.idTipoContenido=4 order by c.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function
        Public Overloads Function getDRObjetosAprendizajeAnexos(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, c.titulo from clasificacionesItems ci, contenidos c  where ci.procedencia='Contenido' and ci.idproc=c.idContenido and ci.idClasificacion=@idClasificacion and c.idTipoContenido<>4 order by c.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function



        Public Overloads Function getDRActvidades(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, a.titulo from clasificacionesItems ci, Actividades a  where ci.procedencia='Actividad' and ci.idproc=a.idActividad and a.tipodeActividad=2 and ci.idClasificacion=@idClasificacion order by a.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function


        Public Overloads Function getDRForos(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, f.titulo from clasificacionesItems ci, Foros f  where ci.procedencia='Foro' and ci.idproc=f.idForo and  ci.idClasificacion=@idClasificacion order by f.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function

        Public Overloads Function getDRExamenes(claveClasificacion As String) As SqlDataReader
            Dim sql As String = "select ci.*, a.titulo from clasificacionesItems ci, Actividades a  where ci.procedencia='Actividad' and ci.idproc=a.idActividad and a.tipodeActividad=1 and ci.idClasificacion=@idClasificacion order by a.titulo asc"
            Dim param As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
            Return Me.ExecuteReader(sql, param)


        End Function

		Public Overloads Function GetDR(ByVal claveClasificacion As Integer, ByVal miOrden As ordenamiento) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM ClasificacionesItems WHERE idClasificacion = @idClasificacion " & _
             "ORDER BY orden " & miOrden.ToString

            queryString = "select t.*  from (" & _
                                    "select ci.*, c.titulo as titulo from clasificacionesitems ci, contenidos c where ci.Procedencia='Contenido' and c.idContenido=ci.idProc and ci.idClasificacion=@idClasificacion union " & _
                                    "select ci.*, a.titulo as titulo from clasificacionesitems ci, Actividades a where ci.Procedencia='Actividad' and a.idActividad=ci.idProc and ci.idClasificacion=@idClasificacion union " & _
                                    "select ci.*, f.titulo as titulo from clasificacionesitems ci, Foros f where ci.Procedencia='Foro' and f.idForo=ci.idProc  and ci.idClasificacion=@idClasificacion) as t order by t.titulo asc "


			Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Function GetDS(ByVal claveClasificacion As Integer, ByVal claveOrden As String) As System.Data.DataSet
			Dim queryString As String = "SELECT * FROM ClasificacionesItems WHERE idClasificacion = @idClasificacion " & _
			 "ORDER BY orden " & claveOrden

			Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}

            Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		Public Overrides Function Count() As Integer
            Dim queryString As String = "SELECT count(idClasificacionItem) as num FROM ClasificacionesItems WHERE idRoot = @idRoot and procedencia<>'Foro'"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", Me.idRoot)}
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

        Public Overloads Function Count(ByVal claveClasificacion As Integer) As Integer
            Dim queryString As String = "SELECT count(idClasificacionItem) as num FROM ClasificacionesItems WHERE idClasificacion = @idClasificacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", claveClasificacion)}
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
            Dim dr As Data.SqlClient.SqlDataReader = New Contenidos.ContenidoAdjunto().GetDR(Me.idProc, Me.procedencia)
            Dim retorno As Boolean

            If dr.HasRows Then
                retorno = True
            Else
                If Me.procedencia = tipoObjeto.Actividad Then
                    If New Contenidos.Respuesta().HayRespuestas(Me.idProc, Me.procedencia) Then
                        retorno = True
                    End If
                End If
            End If
            dr.Close()

            Return retorno
        End Function

        Public Function MoveArriba() As Integer
            Dim resultado As Integer
            If Me.orden > 0 Then
                Dim objVecino As New ClasificacionItem(Me.idClasificacion, Me.orden - 1)
                If objVecino.existe Then
                    objVecino.orden = objVecino.orden + 1
                    resultado = objVecino.Update()

                    Me.orden = Me.orden - 1
                    resultado = resultado + Me.Update
                End If
            End If

            Return resultado
        End Function

        Public Function MoveAbajo() As Integer
            Dim resultado As Integer

            Dim objVecino As New ClasificacionItem(Me.idClasificacion, Me.orden + 1)
            If objVecino.existe Then
                objVecino.orden = objVecino.orden - 1
                resultado = objVecino.Update()

                Me.orden = Me.orden + 1
                resultado = resultado + Me.Update
            End If

            Return resultado
        End Function

        Public Function GetOrden() As Integer
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(Me.idClasificacion, ordenamiento.DESC)
            Dim numero As Integer = 1
            If dr.Read Then
                numero = CType(dr("orden"), Integer) + 1
            End If
            dr.Close()

            Return numero
        End Function

        ''++++++++++ DEPRECATED: Utilizar EnUso() +++++++++++++
        'Public Function SePuedeBorrar() As Boolean
        '	Dim myCA As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto
        '	Dim dr As Data.SqlClient.SqlDataReader = myCA.GetDR(Me.idProc, Me.procedencia)
        '	Dim sepuede As Boolean = False
        '	If dr.Read Then
        '		sepuede = False
        '	Else
        '		If Me.procedencia = "Actividad" Then
        '			Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta
        '			If Not myr.HayRespuestas(Me.idProc, Me.procedencia) Then
        '				sepuede = True
        '			End If

        '		Else
        '			sepuede = True
        '		End If

        '	End If

        '	dr.Close()
        '	Return sepuede
        'End Function

        '++++++++REVISAR++++++++++++
        Public Function GetItemsEdicion(ByVal claveClasificacion As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idClasificacionItem", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idRoot", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idProc", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("procedencia", GetType(String)))
            dTable.Columns.Add(New DataColumn("orden", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("numero", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("cadena", GetType(String)))
            dTable.Columns.Add(New DataColumn("imagen", GetType(String)))

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.GetDR(claveClasificacion, ordenamiento.ASC)
            Dim dRow As DataRow
            Dim numero As Integer = 0

            Do While dr.Read
                numero = numero + 1
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idClasificacionItem"), Integer)
                dRow(1) = CType(dr("idClasificacion"), Integer)
                dRow(2) = CType(dr("idRoot"), Integer)
                dRow(3) = CType(dr("idProc"), Integer)
                dRow(4) = CType(dr("procedencia"), String)
                dRow(5) = CType(dr("orden"), Integer)
                dRow(6) = numero

                Select Case CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
                    Case tipoObjeto.Contenido
                        Dim myContenido As New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        dRow(7) = myContenido.titulo
                        Select Case myContenido.idTipoContenido
                            Case Contenidos.TipoContenido.Archivo
                                dRow(8) = "AddFiles.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "files.gif"
                            Case Contenidos.TipoContenido.Imagen
                                dRow(8) = "AddImages.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "images.gif"
                            Case Contenidos.TipoContenido.Liga
                            Case Contenidos.TipoContenido.Texto
                                dRow(8) = "AddLecturas.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "lectures.gif"
                            Case Contenidos.TipoContenido.Flash
                                dRow(8) = "AddPFlash.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "flashmov.gif"
                        End Select
                    Case tipoObjeto.Actividad
                        Dim myActividad As New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        dRow(7) = myActividad.titulo
                        Select Case myActividad.tipodeActividad
                            Case Contenidos.ETipodeActividad.Actividad
                                dRow(8) = "AddActividad.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "actvs.gif"
                            Case Contenidos.ETipodeActividad.Examen
                                dRow(8) = "AddExamenes.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "exam.gif"
                        End Select
                    Case tipoObjeto.Foro
                        Dim myForo As New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(7) = myForo.titulo
                        dRow(8) = "AddForos.aspx?idRoot=" & CType(dr("idRoot"), Integer) & "&idC=" & CType(dr("idClasificacion"), Integer) & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                        dRow(9) = "forums.gif"
                End Select

                dTable.Rows.Add(dRow)
            Loop
            dr.Close()

            Dim dView As New DataView(dTable)

            Return dView
        End Function

        '++++++++REVISAR++++++++++++
        Public Function GetItemsDisplay(ByVal claveClasificacion As Integer, ByVal claveSalon As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idClasificacionItem", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idRoot", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idProc", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("procedencia", GetType(String)))
            dTable.Columns.Add(New DataColumn("orden", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("numero", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("cadena", GetType(String)))
            dTable.Columns.Add(New DataColumn("imagen", GetType(String)))
            dTable.Columns.Add(New DataColumn("idSalonVirtual", GetType(Integer)))

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.GetDR(claveClasificacion, ordenamiento.ASC)
            Dim dRow As DataRow
            Dim numero As Integer = 0

            Do While dr.Read
                numero = numero + 1
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idClasificacionItem"), Integer)
                dRow(1) = CType(dr("idClasificacion"), Integer)
                dRow(2) = CType(dr("idRoot"), Integer)
                dRow(3) = CType(dr("idProc"), Integer)
                dRow(4) = CType(dr("procedencia"), String)
                dRow(5) = CType(dr("orden"), Integer)
                dRow(10) = claveSalon
                dRow(6) = numero

                Select Case CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
                    Case tipoObjeto.Contenido
                        Dim myContenido As New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        dRow(7) = myContenido.titulo
                        Select Case myContenido.idTipoContenido
                            Case Contenidos.TipoContenido.Archivo
                                dRow(8) = "DisplayFiles.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "files.gif"
                            Case Contenidos.TipoContenido.Imagen
                                dRow(8) = "DisplayImages.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "images.gif"
                            Case Contenidos.TipoContenido.Liga
                            Case Contenidos.TipoContenido.Texto
                                dRow(8) = "DisplayLectura.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "lectures.gif"
                            Case Contenidos.TipoContenido.Flash
                                dRow(8) = "DisplayPFlash.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "flashmov.gif"
                        End Select
                    Case tipoObjeto.Actividad
                        Dim myActividad As New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        dRow(7) = myActividad.titulo
                        Select Case myActividad.tipodeActividad
                            Case Contenidos.ETipodeActividad.Actividad
                                dRow(8) = "DisplayActividad.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "actvs.gif"
                            Case Contenidos.ETipodeActividad.Examen
                                dRow(8) = "DisplayExamen.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & CType(dr("idClasificacionItem"), Integer)
                                dRow(9) = "exam.gif"
                        End Select
                    Case tipoObjeto.Foro
                        Dim myForo As New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(7) = myForo.titulo
                        dRow(8) = "Foro.aspx?idSalonVirtual=" & claveSalon & "&idForo=" & myForo.id
                        dRow(9) = "forums.gif"
                End Select

                dTable.Rows.Add(dRow)
            Loop
            dr.Close()

            Dim dView As New DataView(dTable)

            Return dView
        End Function



        Public Function countActividadas(claveRoot As Integer) As Integer
            Dim sql As String = "select count(ci.idClasificacionItem) as num from ClasificacionesItems ci left outer join Clasificaciones c on c.idClasificacion=ci.idClasificacion left outer join Actividades a on a.idActividad=ci.idProc where ci.procedencia='Actividad' and ci.idproc=a.idActividad and a.tipodeActividad=2  and c.idRoot=@idRoot"
            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot)}
            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function

        Public Function countContenidos(claveRoot As Integer) As Integer
            Dim sql As String = "select count(ci.idClasificacionItem) as num from ClasificacionesItems ci left outer join Clasificaciones c on c.idClasificacion=ci.idClasificacion where ci.procedencia='Contenido' and c.idRoot=@idRoot"
            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot)}
            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function

        Public Function countExamenes(claveRoot As Integer) As Integer
            Dim sql As String = "select count(ci.idClasificacionItem) as num from ClasificacionesItems ci left outer join Clasificaciones c on c.idClasificacion=ci.idClasificacion left outer join Actividades a on a.idActividad=ci.idProc where ci.procedencia='Actividad' and ci.idproc=a.idActividad and a.tipodeActividad=1  and c.idRoot=@idRoot"
            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot)}
            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function

        Public Function countForos(claveRoot As Integer) As Integer
            Dim sql As String = "select count(ci.idClasificacionItem) as num from ClasificacionesItems ci left outer join Clasificaciones c on c.idClasificacion=ci.idClasificacion where ci.procedencia='Foro' and c.idRoot=@idRoot"
            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot)}
            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(sql, parametros)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function




#End Region
    End Class
End Namespace

