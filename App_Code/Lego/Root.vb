Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Lego
    Public NotInheritable Class Root
        Inherits DBObject

        Private idRoot As Integer
        Public idUserProfile As Integer
        Public titulo As String
        Public descripcion As String
        Public fechaCreacion As Date
        Public Tags As String
        Public Eliminado As String
        Public empresa As MasUsuarios.Empresa


        Public Biblioteca As String = ""
        Public Autor As String = ""

        Public ParaInstructor As String = ""
        Public Convenios As String = ""
        Public fechaUltimaActualizacion As Date = Date.MinValue

        Public CertificacionDoc As String = ""
        Public idIdioma As Integer = 1

        Public Raiz As Integer = 0
        Public Idioma As Integer = 0
        Public idEmpresa As Integer = 0



        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idRoot
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Root
            End Get
        End Property

        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Roots WHERE idRoot = @idRoot"

            Dim parameters As SqlParameter() = {New SqlParameter("@idRoot", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.titulo = CType(dr("titulo"), String)
                Me.descripcion = CType(dr("descripcion"), String)
                Me.fechaCreacion = CType(dr("fechaCreacion"), String)
                Me.idUserProfile = CType(dr("iduserProfile"), Integer)
                Me.Tags = CType(dr("Tags"), String)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True

                If Not Convert.IsDBNull(dr("Biblioteca")) Then
                    Me.Biblioteca = dr("Biblioteca")
                End If

                If Not Convert.IsDBNull(dr("Autor")) Then
                    Me.Autor = dr("Autor")
                End If

                If Not Convert.IsDBNull(dr("ParaInstructor")) Then
                    Me.ParaInstructor = dr("ParaInstructor")
                End If

                If Not Convert.IsDBNull(dr("Convenios")) Then
                    Me.Convenios = dr("Convenios")
                End If

                If Not Convert.IsDBNull(dr("fechaUltimaActualizacion")) Then
                    Me.fechaUltimaActualizacion = dr("fechaUltimaActualizacion")
                End If

                If Not Convert.IsDBNull(dr("CertificacionDoc")) Then
                    Me.CertificacionDoc = dr("CertificacionDoc")
                End If
                If Not Convert.IsDBNull(dr("idIdioma")) Then
                    Me.idIdioma = dr("idIdioma")
                End If

                If Not Convert.IsDBNull(dr("Raiz")) Then
                    Me.Raiz = dr("Raiz")
                End If
                If Not Convert.IsDBNull(dr("Idioma")) Then
                    Me.Idioma = dr("Idioma")
                End If

                If Not Convert.IsDBNull(dr("idEmpresa")) Then
                    Me.idEmpresa = CInt(dr("idEmpresa"))
                End If

            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveRaiz As Integer, claveIdioma As Integer)
            Dim queryString As String = "SELECT * FROM Roots WHERE Raiz=@Raiz and Idioma=@idioma and eliminado=0"

            Dim parameters As SqlParameter() = {New SqlParameter("@Raiz", claveRaiz), New SqlParameter("@idioma", claveIdioma)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.titulo = CType(dr("titulo"), String)
                Me.descripcion = CType(dr("descripcion"), String)
                Me.fechaCreacion = CType(dr("fechaCreacion"), String)
                Me.idUserProfile = CType(dr("iduserProfile"), Integer)
                Me.Tags = CType(dr("Tags"), String)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True

                If Not Convert.IsDBNull(dr("Biblioteca")) Then
                    Me.Biblioteca = dr("Biblioteca")
                End If

                If Not Convert.IsDBNull(dr("Autor")) Then
                    Me.Autor = dr("Autor")
                End If

                If Not Convert.IsDBNull(dr("ParaInstructor")) Then
                    Me.ParaInstructor = dr("ParaInstructor")
                End If

                If Not Convert.IsDBNull(dr("Convenios")) Then
                    Me.Convenios = dr("Convenios")
                End If

                If Not Convert.IsDBNull(dr("fechaUltimaActualizacion")) Then
                    Me.fechaUltimaActualizacion = dr("fechaUltimaActualizacion")
                End If

                If Not Convert.IsDBNull(dr("CertificacionDoc")) Then
                    Me.CertificacionDoc = dr("CertificacionDoc")
                End If
                If Not Convert.IsDBNull(dr("idIdioma")) Then
                    Me.idIdioma = dr("idIdioma")
                End If

                If Not Convert.IsDBNull(dr("Raiz")) Then
                    Me.Raiz = dr("Raiz")
                End If
                If Not Convert.IsDBNull(dr("Idioma")) Then
                    Me.Idioma = dr("Idioma")
                End If
                If Not Convert.IsDBNull(dr("idEmpresa")) Then
                    Me.idEmpresa = CInt(dr("idEmpresa"))
                End If

            End If
            dr.Close()
        End Sub

        Public Overrides Function Add() As Integer

            Dim queryString As String = "INSERT INTO [Roots] ([idUserProfile], [titulo], [descripcion], [fechaCreacion], Tags, Eliminado, Biblioteca, Autor, ParaInstructor, Convenios, fechaUltimaActualizacion, CertificacionDoc, idIdioma, Raiz, Idioma, idEmpresa) VALUES (@idUserProfile, @titulo, @descripcion, @fechaCreacion, @Tags, @Eliminado, @Biblioteca, @Autor, @ParaInstructor, @Convenios, @fechaUltimaActualizacion, @CertificacionDoc, @idIdioma, @Raiz, @Idioma, @idEmpresa)"


            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@titulo", Me.titulo),
                  New SqlParameter("@descripcion", Me.descripcion),
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion),
                             New SqlParameter("@Tags", Me.Tags),
                             New SqlParameter("@Eliminado", Me.Eliminado),
                             New SqlParameter("@Biblioteca", Me.Biblioteca),
                             New SqlParameter("@Autor", Me.Autor),
                             New SqlParameter("@ParaInstructor", Me.ParaInstructor),
                             New SqlParameter("@Convenios", Me.Convenios),
                              New SqlParameter("@fechaUltimaActualizacion", Date.Now),
                             New SqlParameter("@CertificacionDoc", Me.CertificacionDoc),
                             New SqlParameter("@idIdioma", Me.idIdioma),
                             New SqlParameter("@Raiz", Me.Raiz),
                             New SqlParameter("@Idioma", Me.Idioma),
                             New SqlParameter("@idEmpresa", Me.idEmpresa)}

            Me.idRoot = Me.ExecuteNonQuery(queryString, parametros, True)

                'Procedimiento en caso de venir alguna empresa
                If Not IsNothing(empresa) Then
                    If empresa.id > 0 Then
                        'grabar los datos en root EMpresa
                        Dim myRootEmpresa As New Lego.RootEmpresa
                        myRootEmpresa.root = Me
                        myRootEmpresa.empresa = Me.empresa
                        myRootEmpresa.Add()
                    End If
                End If



            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [Roots] SET  [titulo]=@titulo, [descripcion]=@descripcion, Tags=@Tags, Eliminado=@Eliminado, Biblioteca=@Biblioteca, Autor=@Autor, ParaInstructor=@ParaInstructor, Convenios=@Convenios, FechaUltimaActualizacion=@FechaUltimaActualizacion, CertificacionDoc=@CertificacionDoc, idIdioma=@idIdioma, Raiz=@Raiz, Idioma=@Idioma, idEmpresa=@idEmpresa WHERE ([Roots].[idRoot] = @idRoot) "

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRoot", Me.idRoot),
                  New SqlParameter("@titulo", Me.titulo),
                  New SqlParameter("@descripcion", Me.descripcion),
                                         New SqlParameter("@Tags", Me.Tags),
                                         New SqlParameter("@Eliminado", Me.Eliminado),
                             New SqlParameter("@Biblioteca", Me.Biblioteca),
                             New SqlParameter("@Autor", Me.Autor),
                             New SqlParameter("@ParaInstructor", Me.ParaInstructor),
                             New SqlParameter("@Convenios", Me.Convenios),
                             New SqlParameter("@fechaUltimaActualizacion", Date.Now),
                             New SqlParameter("@CertificacionDoc", Me.CertificacionDoc),
                             New SqlParameter("@idIdioma", Me.idIdioma),
                             New SqlParameter("@Raiz", Me.Raiz),
                             New SqlParameter("@Idioma", Me.Idioma),
                             New SqlParameter("@idEmpresa", Me.idEmpresa)}

            Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

        Public Overrides Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()

            Return 1
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Roots WHERE idRoot = @idRoot where Eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", Me.idRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveUsuario As Integer, ByVal presentarRootsConPermisos As Boolean) As System.Data.IDataReader
            Dim queryString As String
            If presentarRootsConPermisos Then
                queryString = "select r.idroot, r.iduserprofile, r.titulo, r.fechacreacion from roots r  " &
                                        " where  r.eliminado=0 and (  r.iduserprofile = @idUserProfile  or r.idroot =  " &
                                        " (select p.idrecurso from permisos p where p.idpermisoA = @idUserProfile and p.PermisoA = 'UserProfile' and p.recurso = 'Root' and p.idrecurso = r.idroot) ) order by r.titulo "
            Else
                queryString = "SELECT * FROM roots WHERE (idUserProfile = @idUserProfile) and Eliminado=0 "
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveUserProfile As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT r.idroot, r.iduserprofile, r.titulo, r.fechacreacion FROM Roots r " &
            "WHERE  r.eliminado=0 and (r.idUserProfile = @idUserProfile OR r.idRoot = (SELECT p.idRecurso FROM Permisos p " &
            "WHERE p.idPermisoA = @idUserProfile AND p.PermisoA = 'UserProfile' AND p.recurso = 'Roots' AND p.idRecurso = r.idRoot)) ORDER BY r.titulo "

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUserProfile)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT r.*, u.nombre, u.apellidos  FROM Roots r, UserProfiles u WHERE u.idUserProfile = r.idUserProfile and r.eliminado=0 ORDER BY titulo ASC"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal buscar As String) As System.Data.DataSet
            Dim queryString As String = "select r.*, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=4 and ci.idRoot=r.idRoot) as Texto, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=1 and ci.idRoot=r.idRoot) as Ligas, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=2 and ci.idRoot=r.idRoot) as Archivos, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=3 and ci.idRoot=r.idRoot) as Imagenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=2 and ci.idRoot=r.idRoot) as Actividades, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=1 and ci.idRoot=r.idRoot) as Examenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join foros c on c.idForo=ci.idProc where ci.Procedencia='Foro'  and ci.idRoot=r.idRoot) as Foros, (select sum(Adjuntos) as ArchivosAdj from  (select (select count(cad.idContenidoAdjunto) from ContenidosAdjuntos cad where ci.idProc=cad.idProc and ci.Procedencia=cad.Procedencia ) as Adjuntos  from ClasificacionesItems ci where ci.idRoot=r.idRoot ) as table1) as ArchivosAdjuntos  from roots r  " &
             "WHERE  r.eliminado=0 AND (r.titulo LIKE '%" & buscar & "%') ORDER BY titulo ASC"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS2() As System.Data.DataSet
            Dim queryString As String = "select r.*, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=4 and ci.idRoot=r.idRoot) as Texto, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=1 and ci.idRoot=r.idRoot) as Ligas, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=2 and ci.idRoot=r.idRoot) as Archivos, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=3 and ci.idRoot=r.idRoot) as Imagenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=2 and ci.idRoot=r.idRoot) as Actividades, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=1 and ci.idRoot=r.idRoot) as Examenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join foros c on c.idForo=ci.idProc where ci.Procedencia='Foro'  and ci.idRoot=r.idRoot) as Foros, (select sum(Adjuntos) as ArchivosAdj from  (select (select count(cad.idContenidoAdjunto) from ContenidosAdjuntos cad where ci.idProc=cad.idProc and ci.Procedencia=cad.Procedencia ) as Adjuntos  from ClasificacionesItems ci where ci.idRoot=r.idRoot ) as table1) as ArchivosAdjuntos  from roots r  " &
             "WHERE  r.eliminado=0 AND (r.Biblioteca = 'Educación a distancia') ORDER BY titulo ASC"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDSUnid() As System.Data.DataSet
            Dim queryString As String = "select r.*, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=4 and ci.idRoot=r.idRoot) as Texto, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=1 and ci.idRoot=r.idRoot) as Ligas, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=2 and ci.idRoot=r.idRoot) as Archivos, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Contenidos c on c.idContenido=ci.idProc where ci.Procedencia='Contenido' and c.idTipoContenido=3 and ci.idRoot=r.idRoot) as Imagenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=2 and ci.idRoot=r.idRoot) as Actividades, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join Actividades c on c.idActividad=ci.idProc where ci.Procedencia='Actividad' and c.tipodeActividad=1 and ci.idRoot=r.idRoot) as Examenes, (select count(ci.idClasificacionItem) from ClasificacionesItems ci  left outer join foros c on c.idForo=ci.idProc where ci.Procedencia='Foro'  and ci.idRoot=r.idRoot) as Foros, (select sum(Adjuntos) as ArchivosAdj from  (select (select count(cad.idContenidoAdjunto) from ContenidosAdjuntos cad where ci.idProc=cad.idProc and ci.Procedencia=cad.Procedencia ) as Adjuntos  from ClasificacionesItems ci where ci.idRoot=r.idRoot ) as table1) as ArchivosAdjuntos  from roots r   WHERE  r.eliminado=0 and (r.Biblioteca = 'Educación a distancia') ORDER BY r.titulo ASC"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function


        Public Overloads Function GetDS(ByVal claveUsuario As Integer, ByVal presentarRootsConPermisos As Boolean) As System.Data.DataSet

            Dim queryString As String
            If presentarRootsConPermisos Then
                queryString = "select r.idroot, r.iduserprofile, r.titulo, r.fechacreacion, " &
                                        " (select count(c.idClasificacion) from clasificaciones c where c.idRoot=r.idRoot)  as numeroCarpetas,  " &
                                        " (select count(ci.idClasificacionItem) from clasificacionesItems ci where ci.idRoot=r.idRoot)  as numeroContenidos  " &
                                        " from roots r  " &
                                        "  where   r.eliminado=0 and ( r.idroot =   " &
                                        "   (select top 1 p.idrecurso from permisos p where p.idpermisoA = @idUserProfile and  " &
                                        "   p.PermisoA = 'UserProfile' and p.recurso = 'Root' and  " &
                                        "   p.idrecurso = r.idroot) )  order by r.titulo "
            Else
                queryString = "SELECT r.*,  " &
                                        " (select count(c.idClasificacion) from clasificaciones c where c.idRoot=r.idRoot)  as numeroCarpetas, " &
                                        " (select count(ci.idClasificacionItem) from clasificacionesItems  ci where c.idRoot=r.idRoot)  as numeroContenidos " &
                                        " FROM roots r WHERE r.idUserProfile=@idUserProfile and  r.eliminado=0 order by r.titulo"
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDSBuscar(ByVal claveUsuario As Integer, ByVal claveBuscar As String) As System.Data.DataSet
            Dim queryString As String

            queryString = "select r.idroot, r.iduserprofile, r.titulo, r.fechacreacion, " &
                                    " (select count(c.idClasificacion) from clasificaciones c where c.idRoot=r.idRoot)  as numeroCarpetas,  " &
                                    " (select count(ci.idClasificacionItem) from clasificacionesItems ci where ci.idRoot=r.idRoot)  as numeroContenidos  " &
                                    " from roots r  " &
                                    "  where   r.eliminado=0 and ( r.idroot =   " &
                                    "   (select top 1 p.idrecurso from permisos p where p.idpermisoA = @idUserProfile and  " &
                                    "   p.PermisoA = 'UserProfile' and p.recurso = 'Root' and  " &
                                    "   p.idrecurso = r.idroot) ) and r.titulo like '%" & claveBuscar & "%' COLLATE Modern_Spanish_CI_AI  order by r.titulo "

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal claveUserProfile As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT r.idroot, r.iduserprofile, r.titulo, r.fechacreacion FROM Roots r " &
            "WHERE  r.eliminado=0 and( r.idUserProfile = @idUserProfile OR r.idRoot = (SELECT p.idRecurso FROM Permisos p " &
            "WHERE p.idPermisoA = @idUserProfile AND p.PermisoA = 'UserProfile' AND p.recurso = 'Roots' AND p.idRecurso = r.idRoot) ORDER BY r.titulo )"

            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUserProfile)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idRoot) as num FROM Roots WHERE idRoot = @idRoot and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", Me.idRoot)}

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


    End Class
End Namespace

