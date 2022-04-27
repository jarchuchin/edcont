Imports System.Data
Imports System.IO

Partial Class Sec_Workbook_Controles_GeneralData
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
            llenarDrop()
            iniciarpagina()
        End If
    End Sub



    Sub iniciarpagina()


        Dim myEmpresaUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile


        If Request("idRoot") <> "" Then

            colocarDatos()
        Else



            drpEmpresas.SelectedValue = CInt(Session("idEmpresa"))
            If CInt(Session("idEmpresa")) = 4 Then

                drpEmpresas.Enabled = True
            Else
                drpEmpresas.Enabled = False
            End If

            Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
            Dim myp As New MasUsuarios.Permiso(myu, mye)

            If drpEmpresas.Enabled Then
                If myp.PAdministracion Then
                    drpEmpresas.Enabled = True
                Else

                    drpEmpresas.Enabled = False
                End If
            End If



        End If

    End Sub



    Sub llenarDrop()
        Dim myi As New Utilerias.Idioma

        drpIdiomas.DataSource = myi.GetDR()
        drpIdiomas.DataTextField = "Nombre"
        drpIdiomas.DataValueField = "idIdioma"
        drpIdiomas.DataBind()



        Dim mye As New MasUsuarios.Empresa

        drpEmpresas.DataSource = mye.GetDR()
        drpEmpresas.DataTextField = "Nombre"
        drpEmpresas.DataValueField = "idEmpresa"
        drpEmpresas.DataBind()

    End Sub
    Sub colocarDatos()

        If Request("mensaje") = "1" Then
            alertSuccess.Visible = True
        End If


        If IsNumeric(Request("idRoot")) Then

            Dim myRoot As Lego.Root
            If Request("idIdioma") <> "" Then
                myRoot = New Lego.Root(Integer.Parse(Request("idRoot")), CInt(Request("idIdioma")))
                Dim myrTemp As New Lego.Root(Integer.Parse(Request("idRoot")))
                drpIdiomas.SelectedValue = myrTemp.idIdioma
                drpIdiomas.Enabled = False

                Dim myi As New Utilerias.Idioma(CInt(Request("idIdioma")))
                lblIdioma.Text = myi.Nombre
                pnlIdioma.Visible = True

                btnBorrar.Text = lblBorrarBotonIdioma.Text
                btnBorrar_ConfirmButtonExtender.ConfirmText = lblconfirmIdioma.Text


            Else
                myRoot = New Lego.Root(Integer.Parse(Request("idRoot")))
                drpIdiomas.SelectedValue = myRoot.idIdioma
            End If


            txtId.Text = myRoot.id
            txtTitulo.Text = myRoot.titulo
            txtDescripcion.Text = myRoot.descripcion
            txttags.Text = myRoot.Tags
            btnBorrar.Visible = True
            btngenerarpdf.Visible = True

            txtAutor.Text = myRoot.Autor
            'drpBiblioteca.SelectedValue = myRoot.Biblioteca

            txtConvenios.Text = myRoot.Convenios
            txtParaInstructor.Text = myRoot.ParaInstructor
            txtcertificacion.Text = myRoot.CertificacionDoc


            drpEmpresas.SelectedValue = myRoot.idEmpresa

            If CInt(Session("idEmpresa")) = 4 Then
                drpEmpresas.Enabled = True
            Else
                drpEmpresas.Enabled = False
            End If

        Else
            drpEmpresas.SelectedValue = CInt(Session("idEmpresa"))


        End If




        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then
            '   drpBiblioteca.Enabled = True
            btnClonar.Visible = True
        Else
            btnClonar.Visible = False
        End If

    End Sub





    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click


        If Page.IsValid Then
            Dim numero As Integer
            If Request("idRoot") <> "" Then
                numero = editar()
                Response.Redirect("default.aspx?idRoot=" & numero & "&idIdioma=" & Request("idIdioma") & "&mensaje=1")
            Else
                numero = grabar()
                Response.Redirect("Explorar.aspx?idRoot=" & numero & "&idIdioma=" & Request("idIdioma") & "&mensaje=1")
            End If

        End If
    End Sub

    Function editar() As Integer
        Dim myRoot As Lego.Root = New Lego.Root(CInt(Request("idRoot")))

        If Request("idIdioma") <> "" Then
            Dim myRoot2 As Lego.Root = New Lego.Root(CInt(Request("idRoot")), CInt(Request("idIdioma")))

            myRoot2.titulo = txtTitulo.Text
            myRoot2.descripcion = txtDescripcion.Text
            myRoot2.Tags = txttags.Text
            myRoot2.Autor = txtAutor.Text
            myRoot2.Biblioteca = "Educación a distancia"
            myRoot2.ParaInstructor = txtParaInstructor.Text
            myRoot2.Convenios = txtConvenios.Text
            myRoot2.CertificacionDoc = txtcertificacion.Text
            myRoot2.idIdioma = drpIdiomas.SelectedValue
            myRoot2.idEmpresa = drpEmpresas.SelectedValue

            If myRoot2.existe Then
                myRoot2.Update()
            Else
                myRoot2.fechaCreacion = Date.Now
                myRoot2.Eliminado = False
                myRoot2.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
                myRoot2.Raiz = CInt(Request("idRoot"))
                myRoot2.Idioma = CInt(Request("idIdioma"))
                myRoot2.Add()
            End If

        Else

            myRoot.titulo = txtTitulo.Text
            myRoot.descripcion = txtDescripcion.Text
            myRoot.Tags = txttags.Text
            myRoot.Autor = txtAutor.Text
            myRoot.Biblioteca = "Educación a distancia"
            myRoot.ParaInstructor = txtParaInstructor.Text
            myRoot.Convenios = txtConvenios.Text
            myRoot.CertificacionDoc = txtcertificacion.Text
            myRoot.idIdioma = drpIdiomas.SelectedValue
            myRoot.idEmpresa = drpEmpresas.SelectedValue
            myRoot.Update()
            grabarRootEmpresa(myRoot.id)

            Dim myri As New Lego.RootIdioma(myRoot.idIdioma, myRoot.id)
            If Not myri.existe Then
                myri.idIdioma = myRoot.idIdioma
                myri.idRoot = myRoot.id
                myri.Add()
            End If



        End If

        Return myRoot.id

    End Function

    Function grabar() As Integer
        Dim myRoot As Lego.Root = New Lego.Root
        myRoot.Titulo = txtTitulo.Text
        myRoot.Descripcion = txtDescripcion.Text
        If Request("idUserProfile") = "0" Then
            myRoot.idUserProfile = 0
        Else
            myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        End If

        myRoot.Tags = txttags.Text
        myRoot.fechaCreacion = Date.Now

        myRoot.Eliminado = False
        myRoot.Autor = txtAutor.Text
        myRoot.Biblioteca = "Educación a distancia"
        myRoot.ParaInstructor = txtParaInstructor.Text
        myRoot.Convenios = txtConvenios.Text
        myRoot.CertificacionDoc = txtcertificacion.Text
        myRoot.idIdioma = drpIdiomas.SelectedValue
        myRoot.Raiz = 0
        myRoot.Idioma = 0
        myRoot.idEmpresa = CInt(drpEmpresas.SelectedValue)
        myRoot.Add()




        Dim myri As New Lego.RootIdioma
        myri.idIdioma = myRoot.idIdioma
        myri.idRoot = myRoot.id
        myri.Add()


        grabarRootEmpresa(myRoot.id)

        If Request("idUserProfile") <> "0" Then
            grabarPermisos(myRoot.id)
        End If


        If Request("idSalonVirtual") <> "" Then
            If IsNumeric(Request("idSalonVirtual")) Then
                asignarbookasalon(CInt(Request("idSalonVirtual")), myRoot.id)
            End If
        End If

        Return myRoot.id
    End Function


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
    Sub grabarRootEmpresa(ByVal claveRoot As Integer)
        Dim myRootEmpresa As Lego.RootEmpresa = New Lego.RootEmpresa
        myRootEmpresa.idEmpresa = CInt(drpEmpresas.SelectedValue)
        myRootEmpresa.idRoot = claveRoot
        myRootEmpresa.Add()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click


        Dim myroot As Lego.Root
        If Request("idIdioma") <> "" Then
            myroot = New Lego.Root(CInt(Request("idRoot")), CInt(Request("idIdioma")))
            myroot.Remove()
            Response.Redirect("/sec/workbook/Home.aspx?idRoot=" & myroot.Raiz)
        Else
            myroot = New Lego.Root(CInt(Request("idRoot")))
            myroot.Remove()
            Response.Redirect("/sec/libros.aspx")
        End If




    End Sub

    Protected Sub btngenerarpdf_Click(sender As Object, e As EventArgs) Handles btngenerarpdf.Click

        'Dim myroot As Lego.Root = New Lego.Root(CInt(Request("idRoot")))

        'Dim fechaActual As DateTime = Date.Now
        'Dim fileName As String = "LibroDeTrabajo_" & myroot.id & ".pdf"
        'Dim objPDFroot As New Utilerias.PDFRoot
        'Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "\prontuarios\" & fileName


        'objPDFroot.Colocarpdf(pathfile, myroot.id)

        Response.Redirect("~/sec/workbook/DesplegarTodo.aspx?idRoot=" & Request("idRoot"))


    End Sub

    Protected Sub btnClonar_Click(sender As Object, e As EventArgs) Handles btnClonar.Click


        '###################################
        'DATOS GENERALES
        Dim myRootOriginal As New Lego.Root(CInt(Request("idRoot")))
        Dim myRoot As Lego.Root = New Lego.Root
        myRoot.titulo = "Copia de " & myRootOriginal.titulo
        myRoot.descripcion = myRootOriginal.descripcion
        myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        myRoot.Tags = myRootOriginal.Tags
        myRoot.fechaCreacion = Date.Now
        myRoot.Eliminado = False
        myRoot.Autor = myRootOriginal.Autor
        myRoot.Biblioteca = "Educación a distancia"
        myRoot.ParaInstructor = myRootOriginal.ParaInstructor
        myRoot.Convenios = myRootOriginal.Convenios
        myRoot.fechaUltimaActualizacion = Date.Now
        myRoot.CertificacionDoc = ""
        myRoot.idIdioma = myRootOriginal.idIdioma
        myRoot.Raiz = myRootOriginal.Raiz
        myRoot.Idioma = myRootOriginal.Idioma
        myRoot.idEmpresa = myRootOriginal.idEmpresa
        myRoot.Add()
        grabarRootEmpresa(myRoot.id)
        If Request("idUserProfile") <> "0" Then
            grabarPermisos(myRoot.id)
        End If
        'DATOS GENERALES
        '###################################

        '###################################
        'CLASIFICACIONES
        Dim myCOriginal As New Lego.Clasificacion
        Dim myC As Lego.Clasificacion
        Dim myCIOriginal As New Lego.ClasificacionItem
        Dim myCI As Lego.ClasificacionItem
        Dim dsCI As DataSet
        Dim dsC As DataSet = myCOriginal.GetDS(myRootOriginal.id, 0)

        Dim myo1 As Lego.Objetivo
        Dim myo2 As Lego.Objetivo

        For Each drC As DataRow In dsC.Tables(0).Rows
            myC = New Lego.Clasificacion
            myC.idRaiz = 0
            myC.idRoot = myRoot.id
            myC.titulo = drC("titulo")
            myC.status = CBool(drC("status"))
            myC.orden = CInt(drC("orden"))
            myC.texto = drC("texto")
            myC.diaDisplay = CInt(drC("diaDisplay"))
            If Not Convert.IsDBNull(drC("PlanteamientoBreve")) Then
                myC.PlanteamientoBreve = drC("PlanteamientoBreve")
            Else
                myC.PlanteamientoBreve = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen1")) Then
                myC.Imagen1 = drC("Imagen1")
            Else
                myC.Imagen1 = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen2")) Then
                myC.Imagen2 = drC("Imagen2")
            Else
                myC.Imagen2 = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen3")) Then
                myC.Imagen3 = drC("Imagen3")
            Else
                myC.Imagen3 = ""
            End If
            If Not Convert.IsDBNull(drC("idActividad")) Then
                myC.idActividad = CInt(drC("idActividad"))
            Else
                myC.idActividad = 0
            End If
            myC.Add()

            myo1 = New Lego.Objetivo
            Dim dsObj = myo1.GetDS(CInt(drC("idClasificacion")))
            For Each drObj In dsObj.Tables(0).Rows
                myo2 = New Lego.Objetivo
                myo2.idClasificacion = myC.id
                If Not Convert.IsDBNull(drObj("objetivo")) Then
                    myo2.objetivox = drObj("objetivo")
                Else
                    myo2.objetivox = ""
                End If

                If Not Convert.IsDBNull(drObj("habilidad")) Then
                    myo2.habilidad = drObj("habilidad")
                Else
                    myo2.habilidad = ""
                End If

                If Not Convert.IsDBNull(drObj("aptitud")) Then
                    myo2.aptitud = drObj("aptitud")
                Else
                    myo2.aptitud = ""
                End If
                myo2.Add()

            Next



            dsCI = myCIOriginal.GetDS(CInt(drC("idClasificacion")), "asc")
            For Each drCI As DataRow In dsCI.Tables(0).Rows
                myCI = New Lego.ClasificacionItem
                myCI.idClasificacion = myC.id
                myCI.idRoot = myRoot.id
                myCI.orden = CInt(drCI("orden"))

                Select Case drCI("procedencia")
                    Case "Contenido"
                        myCI.procedencia = tipoObjeto.Contenido
                        myCI.idProc = grabarContenido(CInt(drCI("idProc")))
                    Case "Foro"
                        myCI.procedencia = tipoObjeto.Foro
                        myCI.idProc = grabarForo(CInt(drCI("idProc")))
                    Case "Actividad"
                        myCI.procedencia = tipoObjeto.Actividad
                        myCI.idProc = grabarActividad(CInt(drCI("idProc")))
                End Select

                myCI.Add()
            Next
        Next


        Response.Redirect("~/sec/workbook/home.aspx?idRoot=" & myRoot.id)

    End Sub




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
        mynewactividad.TipoX = myactividad.TipoX
        mynewactividad.Objetivo = myactividad.Objetivo
        ' mynewactividad.idRubrica = myactividad.idr
        mynewactividad.Autoevaluacion = myactividad.Autoevaluacion
        mynewactividad.contestarSinAgenda = myactividad.contestarSinAgenda
        mynewactividad.activarBanco = myactividad.activarBanco
        mynewactividad.totalPreguntas = myactividad.totalPreguntas
        mynewactividad.presentacionAleatoria = myactividad.presentacionAleatoria
        mynewactividad.ParaInstructor = myactividad.ParaInstructor
        mynewactividad.Add()

        If myactividad.comoSeCalifica = Contenidos.EComoSeCalifica.RubricaA Then
            Dim myrubLoop As New Lego.Rubrica
            Dim drRub As SqlClient.SqlDataReader = myrubLoop.GetDR(claveActividad)
            Dim myrub As Lego.Rubrica
            Do While drRub.Read
                myrub = New Lego.Rubrica
                myrub.idActividad = mynewactividad.id
                myrub.Titulo = drRub("Titulo")
                myrub.Val1 = CInt(drRub("Val1"))
                myrub.Val1Descripcion = drRub("Val1Descripcion")
                myrub.Val2 = CInt(drRub("Val2"))
                myrub.Val2Descripcion = drRub("Val2Descripcion")
                myrub.Val3 = CInt(drRub("Val3"))
                myrub.Val3Descripcion = drRub("Val3Descripcion")
                myrub.Val4 = CInt(drRub("Val4"))
                myrub.Val4Descripcion = drRub("Val4Descripcion")
                myrub.Eliminado = False
                myrub.Add()
            Loop
            drRub.Close()
        End If



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
            Dim drPreguntas As System.Data.SqlClient.SqlDataReader = mypreg.GetDR(claveActividad, True)
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
        myCont.ParaInstructor = myContTemp.ParaInstructor
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
        myfnew.idUserProfile = myf.idUserProfile
        myfnew.Objetivo = myf.Objetivo
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
            myCont.ParaInstructor = myContTemp.ParaInstructor
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
        dr.Close()


        Return 1
    End Function

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/sec/workbook/home.aspx?idRoot=" & Request("idRoot"))
    End Sub
End Class