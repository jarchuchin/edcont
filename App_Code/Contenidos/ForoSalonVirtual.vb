Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class ForoSalonVirtual
		Inherits DBObject


        Private idForoSalonVirtual As Integer
        Public idForo As Integer
        Public idSalonVirtual As Integer
        Public idRaiz As Integer
        Public iduserProfile As Integer
        Public titulo As String
        Public texto As String
        Public fechaCreacion As Date
        Public nombre As String = ""
        Public nombreOriginal As String = ""
        Public espacio As Integer = 0



        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idForoSalonVirtual
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ForoSalonVirtual
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM ForosSalonVirtual WHERE idForoSalonVirtual = @idForoSalonVirtual"

            Dim parameters As SqlParameter() = {New SqlParameter("@idForoSalonVirtual", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idForoSalonVirtual = CType(dr("idForoSalonVirtual"), Integer)
                Me.idForo = CType(dr("idForo"), Integer)
                Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
                Me.idRaiz = CType(dr("idRaiz"), Integer)
                Me.iduserProfile = CType(dr("idUserProfile"), Integer)
                Me.titulo = CType(dr("titulo"), String)
                Me.texto = CType(dr("texto"), String)
                Me.fechaCreacion = CType(dr("fechaCreacion"), Date)
                If Not Convert.IsDBNull(dr("nombre")) Then
                    Me.nombre = CType(dr("nombre"), String)
                End If
                If Not Convert.IsDBNull(dr("nombreOriginal")) Then
                    Me.nombreOriginal = CType(dr("nombreOriginal"), String)
                End If
                If Not Convert.IsDBNull(dr("espacio")) Then
                    Me.espacio = CType(dr("espacio"), Integer)
                End If
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [ForosSalonVirtual] ([idForo], [idSalonVirtual], [idRaiz], [idUserProfile], " & _
             "[titulo], [texto], [fechaCreacion], nombre, nombreoriginal, espacio) VALUES (@idForo, @idSalonVirtual, @idRaiz, @idUserProfile, " & _
             "@titulo, @texto, @fechaCreacion, @nombre, @nombreoriginal, @espacio)"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idForo", Me.idForo), _
              New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
              New SqlParameter("@idRaiz", Me.idRaiz), _
             New SqlParameter("@idUserProfile", Me.iduserProfile), _
              New SqlParameter("@titulo", Me.titulo), _
              New SqlParameter("@texto", Me.texto), _
              New SqlParameter("@fechaCreacion", Me.fechaCreacion), _
              New SqlParameter("@nombre", Me.nombre), _
              New SqlParameter("@nombreoriginal", Me.nombreOriginal), _
              New SqlParameter("@espacio", Me.espacio)}

            Me.idForoSalonVirtual = Me.ExecuteNonQuery(queryString, parametros, True)

           
        End Function

        Public Overrides Function Update() As Integer
            Dim mysql As String = "update forossalonvirtual set idForo=@idForo, idSalonVirtual=@idSalonVirtual, idRaiz=@idRaiz, idUserProfile=@idUserProfile, titulo=@titulo, texto=@texto,  nombre=@nombre, nombreOriginal=@nombreOriginal, espacio=@espacio where idForoSalonVirtual=@idForoSalonVirtual"
            Dim param As SqlParameter() = { _
            New SqlParameter("@idForo", Me.idForo), _
            New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
            New SqlParameter("@idRaiz", Me.idRaiz), _
            New SqlParameter("@idUserProfile", Me.iduserProfile), _
            New SqlParameter("@titulo", Me.titulo), _
            New SqlParameter("@texto", Me.texto), _
            New SqlParameter("@nombre", Me.nombre), _
            New SqlParameter("@nombreOriginal", Me.nombreOriginal), _
            New SqlParameter("@espacio", Me.espacio), _
            New SqlParameter("@idForoSalonVirtual", Me.idForoSalonVirtual)}

            Me.ExecuteNonQuery(mysql, param)



        End Function

        Public Overrides Function Remove() As Integer
            Return 0
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function


        Public Overloads Function GetDRDisplay(ByVal claveForo As Integer, ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT fs.*, u.nombre + ' ' + u.apellidos as nombreUsuario, isnull(u.imagen, 'default.jpg') as imagen,   u.login, isnull(eu.claveAux1, '') as claveAux1, isnull(eu.claveAux2,'') as claveAux2 FROM  ForosSalonVirtual   as fs left outer join UserProfiles as u on u.idUserProfile = fs.idUserProfile left outer join  EmpresasUserProfiles as eu on  u.iduserprofile=eu.idUserProfile and eu.idEmpresa=4   WHERE  fs.idSalonVirtual = @idSalonVirtual and fs.idForo=@idForo order by fs.fechaCreacion  desc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idForo", claveForo), New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overloads Function GetDSDisplayRaiz(ByVal claveForo As Integer, ByVal claveSalonVirtual As Integer, claveRaiz As Integer) As DataSet
            Dim queryString As String = "SELECT fs.*, u.nombre + ' ' + u.apellidos as nombreUsuario, isnull(u.imagen, 'default.jpg') as imagen,   u.login, isnull(eu.claveAux1, '') as claveAux1, isnull(eu.claveAux2,'') as claveAux2 FROM  ForosSalonVirtual   as fs left outer join UserProfiles as u on u.idUserProfile = fs.idUserProfile left outer join  EmpresasUserProfiles as eu on  u.iduserprofile=eu.idUserProfile and eu.idEmpresa=4   WHERE  fs.idSalonVirtual = @idSalonVirtual and fs.idForo=@idForo and fs.idRaiz=@idRaiz order by fs.fechaCreacion "

            If claveRaiz > 0 Then
                queryString = queryString & " asc"
            Else
                queryString = queryString & " desc"

            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idForo", claveForo), New SqlParameter("@idSalonVirtual", claveSalonVirtual), New SqlParameter("@idRaiz", claveRaiz)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Overloads Function GetDR(ByVal claveForo As Integer, ByVal claveSalonVirtual As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT fs.*, u.nombre + ' ' + u.apellidos as nombreUsuario FROM ForosSalonVirtual fs, UserProfiles u " & _
            "WHERE u.idUserProfile = fs.idUserProfile AND fs.idForo = @idForo AND fs.idSalonVirtual = @idSalonVirtual order by fs.fechaCreacion asc"

            Dim parametros As SqlParameter() = {New SqlParameter("@idForo", claveForo), New SqlParameter("@idSalonVirtual", claveSalonVirtual)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveForo As Integer, ByVal claveSalonVirtual As Integer, ByVal claveRaiz As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT fs.*, u.nombre + ' ' + u.apellidos as nombreUsuario FROM ForosSalonVirtual fs, UserProfiles u " & _
            "WHERE u.idUserProfile = fs.idUserProfile AND fs.idForo = @idForo AND fs.idSalonVirtual = @idSalonVirtual AND fs.idRaiz = @idRaiz order by fs.fechaCreacion asc"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idForo", claveForo), _
             New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
             New SqlParameter("@idRaiz", claveRaiz)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

        '+++++++++ REVISAR +++++++++++++
        Public Function GetTree(ByVal claveForo As Integer, ByVal claveSalonVirtual As Integer, ByVal claveRaiz As Integer, ByVal paginaActual As String, ByVal claveCI As Integer) As String
            Dim superString As String = ""

            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveForo, claveSalonVirtual, claveRaiz)
            If dr.HasRows Then
                superString = superString & "<ul>" & vbCrLf
                Do While dr.Read()
                    superString = superString & "<li>" & vbCrLf
                    superString = superString & "<a href='" & paginaActual & "?idForo=" & dr("idForo") & "&idCI=" & claveCI & "&idSalonVirtual=" & dr("idSalonVirtual") & "#" & dr("idForoSalonVirtual") & "' class='LigaVerde' >" & dr("titulo") & "</a>"
                    If Not Convert.IsDBNull(dr("nombre")) Then
                        If CStr(dr("nombre")) <> "" Then
                            superString = superString & "&nbsp; <a href='../showfile.aspx?idForoSalonVirtual=" & dr("idForoSalonVirtual") & "'><img src='../../images/filemanager.gif' border='0' ></a> &nbsp;"
                        End If
                    End If
                    superString = superString & " <font class='Chica'> " & dr("nombreUsuario") & ",  " & Format(dr("fechaCreacion"), "f") & " </font>" & vbCrLf
                    superString = superString & "               " & GetTree(claveForo, claveSalonVirtual, dr("idForoSalonVirtual"), paginaActual, claveCI)
                    superString = superString & "</li>" & vbCrLf
                Loop
                superString = superString & "</ul>" & vbCrLf
            End If
            dr.Close()

            Return superString
        End Function




      

	End Class
End Namespace
