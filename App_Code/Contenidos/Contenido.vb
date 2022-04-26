Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions

Namespace Contenidos
	Public NotInheritable Class Contenido
		Inherits DBObject

#Region "Variables"
		Private idContenido As Integer
		Public idTipoContenido As Integer
		Public idUserProfile As Integer
		Public titulo As String
		Public textoCorto As String
		Public textoLargo As String
		Public espacio As Integer
		Public nombreOriginal As String
		Public tipoArchivo As String
		Public extension As String
		Public url As String
		Public fechaCreacion As Date
		Public alto As Integer = 0
        Public ancho As Integer = 0
        Public Tags As String = ""
        Public youtubeID As String = ""

        Public ParaInstructor As String = ""



        Private options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.ExplicitCapture
		Public archivoStream As Stream
		Public postedFile As System.Web.HttpPostedFile

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idContenido
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Contenido
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Public Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Contenidos WHERE idContenido = @idContenido"

			Dim parameters As SqlParameter() = {New SqlParameter("@idContenido", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idContenido = clavePrincipal
				Me.idTipoContenido = CType(dr("idTipoContenido"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.titulo = CType(dr("titulo"), String)
				Me.textoCorto = CType(dr("textoCorto"), String)
				Me.textoLargo = CType(dr("textoLargo"), String)
				Me.espacio = CType(dr("espacio"), Integer)
				Me.nombreOriginal = CType(dr("nombreOriginal"), String)
				Me.tipoArchivo = CType(dr("tipoArchivo"), String)
				Me.extension = CType(dr("extension"), String)
				Me.nombreOriginal = CType(dr("nombreOriginal"), String)
				Me.url = CType(dr("url"), String)
				Me.fechaCreacion = CType(dr("fechaCreacion"), Date)
				Me.alto = CType(dr("alto"), Integer)
                Me.ancho = CType(dr("ancho"), Integer)

                If Not Convert.IsDBNull(dr("Tags")) Then
                    Me.Tags = dr("Tags")
                Else
                    Me.Tags = ""
                End If



                If Not Convert.IsDBNull(dr("youtubeID")) Then
                    Me.youtubeID = dr("youtubeID")
                Else
                    Me.youtubeID = ""
                End If


                If Not Convert.IsDBNull(dr("ParaInstructor")) Then
                    Me.ParaInstructor = dr("ParaInstructor")

                End If

                Me.varExiste = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
            '	Try
            Dim queryString As String = "INSERT INTO [Contenidos] ([idTipoContenido], [idUserProfile], [titulo], [textoCorto], " &
             "[textoLargo], [espacio], [nombreOriginal], [tipoArchivo], [extension], [Url], " &
             "[fechaCreacion], [ancho], [alto], tags, youtubeID, ParaInstructor) VALUES (@idTipoContenido, @idUserProfile, " &
             "@titulo, @textoCorto, @textoLargo, @espacio, @nombreOriginal, @tipoArchivo, " &
             "@extension, @Url, @fechaCreacion, @ancho, @alto, @tags, @youtubeID, @ParaInstructor)"

            If Not IsNothing(Me.postedFile) Then
                colocarDatosArchivo()
            End If

            Dim parametros As SqlParameter() = {
              New SqlParameter("@idTipoContenido", Me.idTipoContenido),
              New SqlParameter("@idUserProfile", Me.idUserProfile),
              New SqlParameter("@titulo", Me.titulo),
              New SqlParameter("@textoCorto", Me.textoCorto),
              New SqlParameter("@textoLargo", Me.textoLargo),
              New SqlParameter("@espacio", Me.espacio),
              New SqlParameter("@nombreOriginal", Me.nombreOriginal),
              New SqlParameter("@tipoArchivo", Me.tipoArchivo),
              New SqlParameter("@extension", Me.extension),
              New SqlParameter("@url", Me.url),
              New SqlParameter("@fechaCreacion", Me.fechaCreacion),
              New SqlParameter("@ancho", Me.ancho),
              New SqlParameter("@alto", Me.alto),
              New SqlParameter("@tags", Me.Tags),
              New SqlParameter("@youtubeID", Me.youtubeID),
              New SqlParameter("@ParaInstructor", Me.ParaInstructor)}

            Me.idContenido = Me.ExecuteNonQuery(queryString, parametros, True)

            If Not IsNothing(Me.postedFile) Then
                grabarArchivo()
            End If

            '		Catch ex As Exception
            'Dim m As String = ex.Message
            '  End Try

            Return 0
		End Function

		Public Overrides Function Update() As Integer
            'Try
            Dim queryString As String = "UPDATE [Contenidos] SET [idTipoContenido]=@idTipoContenido, [idUserProfile]=@idUserProfile, " &
             " [titulo]=@titulo, [textoCorto]=@textoCorto, [textoLargo]=@textoLargo, [espacio]=@espacio, " &
            " [nombreOriginal]=@nombreOriginal, [tipoArchivo]=@tipoArchivo, [extension]=@extension, [url]=@url,  " &
            " [fechaCreacion]=@fechaCreacion, [ancho]=@ancho, [alto]=@alto, tags=@tags, youtubeID=@youtubeID, ParaInstructor=@ParaInstructor WHERE [idContenido] = @idContenido"

            If Not IsNothing(Me.postedFile) Then
                colocarDatosArchivo()
            End If

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idContenido", Me.idContenido),
              New SqlParameter("@idTipoContenido", Me.idTipoContenido),
              New SqlParameter("@idUserProfile", Me.idUserProfile),
              New SqlParameter("@titulo", Me.titulo),
              New SqlParameter("@textoCorto", Me.textoCorto),
              New SqlParameter("@textoLargo", Me.textoLargo),
              New SqlParameter("@espacio", Me.espacio),
              New SqlParameter("@nombreOriginal", Me.nombreOriginal),
              New SqlParameter("@tipoArchivo", Me.tipoArchivo),
              New SqlParameter("@extension", Me.extension),
              New SqlParameter("@url", Me.url),
              New SqlParameter("@fechaCreacion", Me.fechaCreacion),
              New SqlParameter("@ancho", Me.ancho),
              New SqlParameter("@alto", Me.alto),
              New SqlParameter("@tags", Me.Tags),
              New SqlParameter("@youtubeID", Me.youtubeID),
              New SqlParameter("@ParaInstructor", Me.ParaInstructor)}

            Dim resultado As Integer = Me.ExecuteNonQuery(queryString, parametros)

            If Not IsNothing(Me.postedFile) Then
                grabarArchivo()
            End If

            Return resultado

            'Catch ex As Exception
            'Return 0
            ' End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM Contenidos WHERE idContenido = @idContenido"

			Dim parametros As SqlParameter() = {New SqlParameter("@idContenido", Me.idContenido)}

			Try
				Dim resultado As Integer = Me.ExecuteNonQuery(queryString, parametros)

                If Me.idTipoContenido = Contenidos.TipoContenido.Imagen Or Me.idTipoContenido = Contenidos.TipoContenido.Archivo Then
                    Dim myArchivo As New Archivo(Me.idContenido, Me.extension)
                    myArchivo.Remove()
                End If

                Return resultado
            Catch ex As Exception

            End Try

            Return 0
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overloads Function GetDS(ByVal claveUsuario As Integer, ByVal textoBuscar As String) As DataSet
            Dim sql As String = "select t.* from " & _
                                                "(select c.idContenido as id, c.titulo, c.idtipocontenido as tipo, 'Contenido' as Procedencia, c.fechaCreacion  from contenidos c where c.idtipocontenido <> 1 and c.idUserProfile=@idUserProfile and c.titulo like '%" & textoBuscar & "%' " & _
                                                " union " & _
                                                " select f.idForo as id, f.titulo, 1 as tipo, 'Foro' as Procedencia, f.fechaCreacion from foros f where f.autor=@idUserProfile and f.titulo like '%" & textoBuscar & "%' " & _
                                                " union " & _
                                                " select a.idActividad as id, a.titulo, a.tipodeActividad as tipo, 'Actividad' as Procedencia, a.fechaCreacion from actividades a where a.idUserProfile=@idUserProfile and a.titulo like '%" & textoBuscar & "%' ) as t" & _
                                                " order  by t.titulo"






            Dim param As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(sql, param)
        End Function

        Public Overloads Function GetDSBuscarTodos(ByVal textoBuscar As String) As DataSet
            Dim sql As String = "select t.* from " & _
                                                "(select c.idContenido as id, c.titulo, c.idtipocontenido as tipo, 'Contenido' as Procedencia, c.fechaCreacion  from contenidos c where c.idtipocontenido <> 1  and c.titulo like '%" & textoBuscar & "%' " & _
                                                " union " & _
                                                " select f.idForo as id, f.titulo, 1 as tipo, 'Foro' as Procedencia, f.fechaCreacion from foros f where  f.titulo like '%" & textoBuscar & "%' " & _
                                                " union " & _
                                                " select a.idActividad as id, a.titulo, a.tipodeActividad as tipo, 'Actividad' as Procedencia, a.fechaCreacion from actividades a where  a.titulo like '%" & textoBuscar & "%' ) as t" & _
                                                " order  by t.titulo"






            ' Dim param As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function


        Public Function GetContenidosNoEnAgenda(ByVal claveSalon As Integer, ByVal claveRoot As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT c.idContenido, c.titulo,  ci.idRoot, ci.idClasificacion FROM ClasificacionesItems ci, Contenidos c " & _
             "WHERE c.idContenido = ci.idProc AND ci.Procedencia = 'Contenido' AND ci.idRoot = @idRoot AND c.idContenido " & _
             "NOT IN (SELECT ag.idProc FROM Agenda ag WHERE ag.idSalonVirtual = @idSalonVirtual AND ag.Procedencia = 'Contenido') ORDER BY c.titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idSalonVirtual", claveSalon), New SqlParameter("@idRoot", claveRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Function colocarDatosArchivo() As Integer
            Dim inicioNombreOriginal = postedFile.FileName.LastIndexOf("\") + 1
            Dim nombreOriginal As String = postedFile.FileName.Substring(inicioNombreOriginal)
            Dim extension As String = ""
            Dim inicioExtension As Integer = nombreOriginal.LastIndexOf(".")
            If inicioExtension > -1 Then
                extension = nombreOriginal.Substring(inicioExtension + 1)
            End If
            Dim esImagen As Boolean = System.Text.RegularExpressions.Regex.IsMatch(postedFile.ContentType, "image/\S+")

            If esImagen Then
                Me.idTipoContenido = Contenidos.TipoContenido.Imagen
            Else
                If extension <> "" Then
                    If extension.ToLower = "swf" Then
                        Me.idTipoContenido = Contenidos.TipoContenido.Flash
                    Else
                        Me.idTipoContenido = Contenidos.TipoContenido.Archivo
                    End If
                End If
            End If

            Me.url = ""
            Me.fechaCreacion = Date.Now
            Me.espacio = postedFile.ContentLength
            Me.nombreOriginal = nombreOriginal
            Me.tipoArchivo = postedFile.ContentType
            Me.extension = extension
            If Me.titulo = "" Then
                Me.titulo = Me.nombreOriginal
            End If
        End Function

        Function grabarArchivo() As Integer
            Dim myArchivo As New Archivo
            myArchivo.idContenido = Me.idContenido
            myArchivo.Extension = Me.extension
            myArchivo.ArchivoSize = Me.espacio
            myArchivo.ArchivoStream = postedFile.InputStream
            myArchivo.Add()
        End Function

        Function updateArchivo(ByVal claveContenido As Integer) As Integer
            Dim myArchivo As New Archivo(claveContenido, Me.extension)
            myArchivo.Remove()

            myArchivo = New Contenidos.Archivo
            myArchivo.idContenido = Me.idContenido
            myArchivo.Extension = Me.extension
            myArchivo.ArchivoSize = Me.espacio
            myArchivo.ArchivoStream = postedFile.InputStream
            myArchivo.Add()
        End Function

		Public Function eliminaFormTags(ByVal texto As String) As String
			Dim regex As New Regex("<form( [^>]+)?>|</form( [^>]+)?>|&lt;form( [^>]+)?&gt;|&lt;/form( [^>]+)?&gt;|(\s{2})|\t", options)
			Dim textoTemp As String = regex.Replace(texto, "")

			Return Trim(textoTemp)
        End Function


        Public Function getProntuarios(clavefecha As Date) As SqlDataReader



            Dim sql As String = "select * from Contenidos where ((Titulo like '%plan%' and Titulo like '%curso%') or Titulo like '%prontuario%') and fechaCreacion > @fechax and Espacio>0 order by fechaCreacion asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@fechax", clavefecha)}

            Return Me.ExecuteReader(sql, parametros)

        End Function
#End Region
	End Class

#Region "Enumeraciones de la clase"
	Public Enum TipoContenido As Byte
		Liga = 1
		Archivo = 2
		Imagen = 3
		Texto = 4
        Flash = 5
        Video = 6
        Articulate = 7
    End Enum


#End Region
End Namespace
