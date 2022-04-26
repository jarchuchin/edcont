Imports System.Data
Imports System.IO
Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Home
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub


    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim myr As Lego.Root

        If Request("idIdioma") <> "" Then
            myr = New Lego.Root(CInt(Request("idRoot")), CInt(Request("idIdioma")))
            If Not myr.existe Then
                lblNoIdioma.Visible = True
                myr = New Lego.Root(CInt(Request("idRoot")))
            End If
        Else
            myr = New Lego.Root(CInt(Request("idRoot")))
        End If


        If Request("mensaje") = "2" Then
            lblNoIdioma.Visible = True
        End If

        DesplegarBotonesIdiomas()


        lblNombreDelLibro.Text = myr.titulo
        lblNombredelLibro2.Text = myr.titulo
        lblTitulobox.Text = myr.titulo


        lblautor.Text = myr.Autor
        '    lbldescripcion.Text = myr.descripcion.Replace(vbCrLf, "xxxxxxxxxxxxxxxx")
        lbldescripcion.Text = myr.descripcion.Replace(vbLf, "<br/>")
        lblbiblioteca.Text = myr.Biblioteca
        lbltags.Text = myr.Tags
        lblUltimaActualizacion.Text = myr.fechaUltimaActualizacion.ToShortDateString
        lblparainstructor.Text = myr.ParaInstructor.Replace(vbLf, "<br/>")
        lblConvenios.Text = myr.Convenios.Replace(vbLf, "<br/>")

        Dim myi As New Utilerias.Idioma(myr.idIdioma)
        lblIdioma.Text = myi.Nombre

        If myr.CertificacionDoc <> "" Then
            lnkcertificacion.Visible = True
            lnkcertificacion.NavigateUrl = myr.CertificacionDoc
            lnkcertificacion.Text = myr.CertificacionDoc

        Else
            lnkcertificacion.Visible = False
        End If

        ' btngenerarpdf.Visible = True

        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As New MasUsuarios.Permiso(myu, mye)

        'If myp.PAdministracion Then
        '    btnClonar.Visible = True
        'Else
        '    btnClonar.Visible = False
        'End If

    End Sub

    Sub DesplegarBotonesIdiomas()


        Dim myr As New Lego.Root(CInt(Request("idRoot")))

        Dim myi As New Utilerias.Idioma(myr.idIdioma)
        lnkIdiomaDefault.Text = myi.Nombre
        lnkIdiomaDefault.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & myr.id

        Dim myri As New Lego.RootIdioma

        rptIdiomas.DataSource = myri.GetDR(CInt(Request("idRoot")))
        rptIdiomas.DataBind()

    End Sub

    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If Request("idIdioma") <> "" Then

            Response.Redirect("default.aspx?idRoot=" & Request("idRoot") & "&idIdioma=" & Request("idIdioma"))

        Else
            Response.Redirect("default.aspx?idRoot=" & Request("idRoot"))
        End If

    End Sub





    Sub grabarRootEmpresa(ByVal claveRoot As Integer)
        Dim myRootEmpresa As Lego.RootEmpresa = New Lego.RootEmpresa
        myRootEmpresa.idEmpresa = 4
        myRootEmpresa.idRoot = claveRoot
        myRootEmpresa.Add()
    End Sub

    Sub grabarPermisos(ByVal claveroot As Integer)
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso
        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), False)
        Dim myr As Lego.Root = New Lego.Root(claveroot)

        myPermiso.permisoA = myUserP.tipo
        myPermiso.idPermisoA = myUserP.id
        myPermiso.recurso = myr.tipo
        myPermiso.idRecurso = myr.id

        myPermiso.PRoots = True
        myPermiso.PPermisosRoots = True
        myPermiso.PCategorias = True
        myPermiso.PRespuestas = True
        myPermiso.PEvaluacion = True
        myPermiso.PSalonVirtual = True
        myPermiso.PContenidos = True
        myPermiso.PInterfaceGrafica = True
        myPermiso.PEstadisticas = True
        myPermiso.PAdministracion = True
        myPermiso.Add()

    End Sub

    Sub asignarbookasalon(ByVal clavesalon As Integer, ByVal clavebook As Integer)
        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(clavesalon, False)
        mysalon.idRoot = clavebook
        mysalon.Update()

    End Sub

    'Protected Sub btnClonar_Click(sender As Object, e As EventArgs) Handles btnClonar.Click


    '    '###################################
    '    'DATOS GENERALES
    '    Dim myRootOriginal As New Lego.Root(CInt(Request("idRoot")))
    '    Dim myRoot As Lego.Root = New Lego.Root
    '    myRoot.titulo = "Copia de " & myRootOriginal.titulo
    '    myRoot.descripcion = myRootOriginal.descripcion
    '    myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
    '    myRoot.Tags = myRootOriginal.Tags
    '    myRoot.fechaCreacion = Date.Now
    '    myRoot.Eliminado = False
    '    myRoot.Autor = myRootOriginal.Autor
    '    myRoot.Biblioteca = myRootOriginal.Biblioteca
    '    myRoot.Add()
    '    grabarRootEmpresa(myRoot.id)
    '    If Request("idUserProfile") <> "0" Then
    '        grabarPermisos(myRoot.id)
    '    End If
    '    'DATOS GENERALES
    '    '###################################

    '    '###################################
    '    'CLASIFICACIONES
    '    Dim myCOriginal As New Lego.Clasificacion
    '    Dim myC As Lego.Clasificacion
    '    Dim myCIOriginal As New Lego.ClasificacionItem
    '    Dim myCI As Lego.ClasificacionItem
    '    Dim dsCI As DataSet
    '    Dim dsC As DataSet = myCOriginal.GetDS(myRootOriginal.id, 0)
    '    For Each drC As DataRow In dsC.Tables(0).Rows
    '        myC = New Lego.Clasificacion
    '        myC.idRaiz = 0
    '        myC.idRoot = myRoot.id
    '        myC.titulo = drC("titulo")
    '        myC.status = CBool(drC("status"))
    '        myC.orden = CInt(drC("orden"))
    '        myC.texto = drC("texto")
    '        myC.diaDisplay = CInt(drC("diaDisplay"))
    '        myC.Add()


    '        dsCI = myCIOriginal.GetDS(CInt(drC("idClasificacion")), "asc")
    '        For Each drCI As DataRow In dsCI.Tables(0).Rows
    '            myCI = New Lego.ClasificacionItem
    '            myCI.idClasificacion = myC.id
    '            myCI.idRoot = myRoot.id
    '            myCI.orden = CInt(drCI("orden"))

    '            Select Case drCI("procedencia")
    '                Case "Contenido"
    '                    myCI.procedencia = tipoObjeto.Contenido
    '                    myCI.idProc = grabarContenido(CInt(drCI("idProc")))
    '                Case "Foro"
    '                    myCI.procedencia = tipoObjeto.Foro
    '                    myCI.idProc = grabarForo(CInt(drCI("idProc")))
    '                Case "Actividad"
    '                    myCI.procedencia = tipoObjeto.Actividad
    '                    myCI.idProc = grabarActividad(CInt(drCI("idProc")))
    '            End Select

    '            myCI.Add()
    '        Next
    '    Next


    '    Response.Redirect("~/sec/workbook/home.aspx?idRoot=" & myRoot.id)

    'End Sub




    Function grabarActividad(claveActividad As Integer) As Integer
        Dim myactividad As New Contenidos.Actividad(claveActividad)
        Dim mynewactividad As New Contenidos.Actividad
        mynewactividad.titulo = myactividad.titulo
        mynewactividad.tipodeActividad = myactividad.tipodeActividad
        mynewactividad.instrucciones = myactividad.instrucciones
        mynewactividad.respuesta = myactividad.respuesta
        mynewactividad.respuestaGrupal = myactividad.respuestaGrupal
        mynewactividad.comoSeCalifica = myactividad.comoSeCalifica
        mynewactividad.quienCalifica = myactividad.quienCalifica
        mynewactividad.mostrarCalificacion = myactividad.mostrarCalificacion
        mynewactividad.mostrarRespuestas = myactividad.mostrarRespuestas
        mynewactividad.mostrarObservaciones = myactividad.mostrarObservaciones
        mynewactividad.puntosPorRespuesta = myactividad.puntosPorRespuesta
        mynewactividad.puntosTotales = myactividad.puntosTotales
        mynewactividad.tiempoEnMinutos = myactividad.tiempoEnMinutos
        mynewactividad.numeroSecciones = myactividad.numeroSecciones
        mynewactividad.status = myactividad.numeroSecciones
        mynewactividad.status = myactividad.status
        mynewactividad.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mynewactividad.fechaCreacion = Date.Now
        mynewactividad.Tags = myactividad.Tags
        mynewactividad.Add()



        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Imagen")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Archivo")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Flash")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Liga")


        'Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        'myci.idClasificacion = claveClasificacion
        'myci.idProc = mynewactividad.id
        'myci.procedencia = tipoObjeto.Actividad
        'myci.idRoot = claveRoot
        'myci.Add()


        If mynewactividad.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Dim mypreg As New Examenes.Pregunta
            Dim drPreguntas As System.Data.SqlClient.SqlDataReader = mypreg.GetDR(myactividad.id, True)
            Dim mypregunta As Examenes.Pregunta
            Dim idOr_Seleccionado As Integer = 0

            Do While drPreguntas.Read
                idOr_Seleccionado = 0

                mypregunta = New Examenes.Pregunta()
                mypregunta.idActividad = mynewactividad.id
                mypregunta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                mypregunta.idOR = CInt(drPreguntas("idOR")) 'mismo valor en caso de FyV
                idOr_Seleccionado = CInt(drPreguntas("idOR"))
                mypregunta.tipoPregunta = CInt(drPreguntas("tipoPregunta"))
                mypregunta.enunciado = drPreguntas("enunciado")
                mypregunta.archivo = CInt(drPreguntas("archivo"))
                mypregunta.valor = CDec(drPreguntas("valor"))
                mypregunta.orden = CInt(drPreguntas("orden"))
                mypregunta.respuesta = drPreguntas("respuesta")
                mypregunta.Eliminado = CBool(drPreguntas("eliminado"))
                mypregunta.fileName = ""
                mypregunta.Add()

                If Not Convert.IsDBNull(drPreguntas("fileName")) Then
                    If drPreguntas("fileName") <> "" Then
                        Dim nombreOriginal As String = drPreguntas("fileName")
                        mypregunta.fileName = mypregunta.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                        mypregunta.Update()

                        Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & nombreOriginal
                        Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & mypregunta.fileName
                        File.Copy(fileOriginal, fileCopia)
                    End If
                End If

                Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
                Dim drOpcionesRespuesta As System.Data.SqlClient.SqlDataReader = myOR.GetDR(CInt(drPreguntas("idPregunta")))
                Dim myOP As Examenes.OpcionPregunta = New Examenes.OpcionPregunta

                Do While drOpcionesRespuesta.Read
                    myOR = New Examenes.OpcionRespuesta
                    myOR.idPregunta = mypregunta.id
                    myOR.enunciado = drOpcionesRespuesta("enunciado")
                    myOR.archivo = CInt(drOpcionesRespuesta("archivo"))
                    myOR.fileName = ""
                    myOR.Add()


                    If Not Convert.IsDBNull(drOpcionesRespuesta("fileName")) Then
                        If drOpcionesRespuesta("fileName") <> "" Then
                            Dim nombreOriginal As String = drOpcionesRespuesta("fileName")
                            myOR.fileName = myOR.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                            myOR.Update()

                            Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                            Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                            File.Copy(fileOriginal, fileCopia)
                        End If
                    End If

                    If idOr_Seleccionado = CInt(drOpcionesRespuesta("idOR")) Then
                        mypregunta.idOR = myOR.id
                        mypregunta.Update()
                    End If


                    Dim drOpcionPregunta As System.Data.SqlClient.SqlDataReader = myOP.GetDR(CInt(drPreguntas("idPregunta")), CInt(drOpcionesRespuesta("idOR")))
                    Do While drOpcionPregunta.Read
                        myOP = New Examenes.OpcionPregunta
                        myOP.idOR = myOR.id
                        myOP.idPregunta = mypregunta.id
                        myOP.enunciado = drOpcionPregunta("enunciado")
                        myOP.archivo = 0
                        myOP.Eliminado = CBool(drOpcionPregunta("Eliminado"))
                        myOP.fileName = ""
                        myOP.Add()

                        If Not Convert.IsDBNull(drOpcionPregunta("fileName")) Then
                            If drOpcionPregunta("fileName") <> "" Then
                                Dim nombreOriginal As String = drOpcionPregunta("fileName")
                                myOP.fileName = myOP.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                                myOP.Update()

                                Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                                Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                                File.Copy(fileOriginal, fileCopia)
                            End If
                        End If


                    Loop
                    drOpcionPregunta.Close()






                Loop
                drOpcionesRespuesta.Close()


                'seccion para colocar preguntas sin seleccion
                Dim drOpcionPregunta2 As System.Data.SqlClient.SqlDataReader = myOP.GetDR(CInt(drPreguntas("idPregunta")), 0)
                Do While drOpcionPregunta2.Read
                    myOP = New Examenes.OpcionPregunta
                    myOP.idOR = 0
                    myOP.idPregunta = mypregunta.id
                    myOP.enunciado = drOpcionPregunta2("enunciado")
                    myOP.archivo = 0
                    myOP.Eliminado = CBool(drOpcionPregunta2("Eliminado"))
                    myOP.fileName = ""
                    myOP.Add()

                    If Not Convert.IsDBNull(drOpcionPregunta2("fileName")) Then
                        If drOpcionPregunta2("fileName") <> "" Then
                            Dim nombreOriginal As String = drOpcionPregunta2("fileName")
                            myOP.fileName = myOP.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                            myOP.Update()

                            Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                            Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                            File.Copy(fileOriginal, fileCopia)
                        End If
                    End If


                Loop
                drOpcionPregunta2.Close()


            Loop
            drPreguntas.Close()

        End If


        Return mynewactividad.id

    End Function
    Function grabarContenido(claveContenido As Integer) As Integer

        Dim myCont As Contenidos.Contenido
        Dim myContTemp As New Contenidos.Contenido(claveContenido)


        myCont = New Contenidos.Contenido
        myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myCont.idTipoContenido = myContTemp.idTipoContenido
        myCont.titulo = myContTemp.titulo
        myCont.textoCorto = myContTemp.textoCorto
        myCont.textoLargo = myContTemp.textoLargo
        myCont.espacio = myContTemp.espacio
        myCont.nombreOriginal = myContTemp.nombreOriginal
        myCont.tipoArchivo = myContTemp.tipoArchivo
        myCont.extension = myContTemp.extension
        myCont.url = myContTemp.url
        myCont.fechaCreacion = Date.Now
        myCont.ancho = myContTemp.ancho
        myCont.alto = myContTemp.alto
        myCont.Tags = myContTemp.Tags
        myCont.youtubeID = myContTemp.youtubeID
        myCont.Add()

        Dim pathArchivos As String = ConfigurationManager.AppSettings("carpetaArchivos")
        If File.Exists(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension) Then
            File.Copy(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension, pathArchivos & "files\" & myCont.id & "." & myCont.extension)
        End If

        grabarAdjunto(myCont.id, myCont.tipo, "Imagen")
        grabarAdjunto(myCont.id, myCont.tipo, "Archivo")
        grabarAdjunto(myCont.id, myCont.tipo, "Flash")
        grabarAdjunto(myCont.id, myCont.tipo, "Liga")


        'Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        'myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        'myci.idProc = myCont.id
        'myci.procedencia = tipoObjeto.Contenido
        'myci.idRoot = CInt(Request("idRoot"))
        'myci.Add()

        Return myCont.id

    End Function
    Function grabarForo(claveForo As Integer) As Integer
        Dim myf As New Contenidos.Foro(claveForo)
        Dim myfnew As New Contenidos.Foro
        myfnew.titulo = myf.titulo
        myfnew.texto = myf.texto
        myfnew.fechaCreacion = Date.Now
        myfnew.autor = myf.autor
        myfnew.Add()


        Return myfnew.id


    End Function

    Function grabarAdjunto(ByVal claveidproce As Integer, ByVal claveproce As String, ByVal clavetipo As String) As Integer
        Dim myAdjuntos As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto
        Dim dr As System.Data.SqlClient.SqlDataReader

        Select Case clavetipo
            Case "Imagen"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Imagen)
            Case "Archivo"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Archivo)
            Case "Flash"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Flash)
            Case "Liga"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Liga)
            Case Else
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Archivo)
        End Select


        Dim pathArchivos As String = ConfigurationManager.AppSettings("carpetaArchivos")

        Do While dr.Read
            Dim myCA As Contenidos.ContenidoAdjunto
            Dim myCont As Contenidos.Contenido
            Dim myContTemp As New Contenidos.Contenido(CInt(dr("idContenido")))


            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myCont.idTipoContenido = myContTemp.idTipoContenido
            myCont.titulo = myContTemp.titulo
            myCont.textoCorto = myContTemp.textoCorto
            myCont.textoLargo = myContTemp.textoLargo
            myCont.espacio = myContTemp.espacio
            myCont.nombreOriginal = myContTemp.nombreOriginal
            myCont.tipoArchivo = myContTemp.tipoArchivo
            myCont.extension = myContTemp.extension
            myCont.url = myContTemp.url
            myCont.fechaCreacion = Date.Now
            myCont.ancho = myContTemp.ancho
            myCont.alto = myContTemp.alto
            myCont.Tags = myContTemp.Tags
            myCont.youtubeID = myContTemp.youtubeID
            myCont.Add()


            If File.Exists(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension) Then
                File.Copy(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension, pathArchivos & "files\" & myCont.id & "." & myCont.extension)
            End If

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = CInt(dr("idProc"))
            myCA.Procedencia = dr("procedencia")
            myCA.idContenido = myCont.id
            myCA.Add()


        Loop
        dr.close()

        Return 1
    End Function
End Class
