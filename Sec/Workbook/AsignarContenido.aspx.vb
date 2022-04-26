Imports System.IO

Partial Class Sec_Workbook_AsignarContenido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenardrop()
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()

        lnkSalirEdicion.NavigateUrl = "javascript:history.go(-1)"


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo

        drpUbicacion.SelectedValue = Request("idClasificacion")

        Select Case Request("Procedencia")
            Case "Contenido"
                Dim myc As Contenidos.Contenido = New Contenidos.Contenido(CInt(Request("id")))
                lblTitulo.Text = myc.titulo
                lblFecha.Text = myc.fechaCreacion.ToLongDateString & " " & myc.fechaCreacion.ToShortTimeString

                lblDescripcion.Text = myc.textoCorto & "  " & myc.textoLargo
                lblTipo.Text = lblContenidoEtiqueta.Text
            Case "Actividad"

                Dim myc As Contenidos.Actividad = New Contenidos.Actividad(CInt(Request("id")))
                lblTitulo.Text = myc.titulo
                lblFecha.Text = myc.fechaCreacion.ToLongDateString & " " & myc.fechaCreacion.ToShortTimeString
                lblDescripcion.Text = myc.instrucciones
                If myc.tipodeActividad = Contenidos.ETipodeActividad.Actividad Then
                    lblTipo.Text = lblActividadEtiqueta.Text
                Else
                    lblTipo.Text = lblExamenEtiqueta.Text
                End If

            Case "Foro"
                Dim myc As Contenidos.Foro = New Contenidos.Foro(CInt(Request("id")))
                lblTitulo.Text = myc.titulo
                lblFecha.Text = myc.fechaCreacion.ToLongDateString & " " & myc.fechaCreacion.ToShortTimeString

                lblDescripcion.Text = myc.texto
                lblTipo.Text = lblForoEtiueta.Text

        End Select




    End Sub

    Sub llenardrop()
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        drpUbicacion.DataSource = myc.ClasificacionesRoot(CInt(Request("idRoot")))
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

    End Sub

    Protected Sub btnUbicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUbicar.Click
        If rdbTipo.SelectedValue = "M" Then
            UsarContenido()
        Else
            CopiarContenido()
        End If




    End Sub


    Sub UsarContenido()
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myci.idProc = CInt(Request("id"))
        Select Case Request("Procedencia")
            Case "Actividad"
                myci.procedencia = tipoObjeto.Actividad
            Case "Contenido"
                myci.procedencia = tipoObjeto.Contenido
            Case "Foro"
                myci.procedencia = tipoObjeto.Foro
        End Select
        myci.idRoot = CInt(Request("idRoot"))
        myci.Add()



        Select Case myci.procedencia.ToString
            Case "Actividad"
                Dim myactividad As New Contenidos.Actividad(myci.idProc)
                If myactividad.tipodeActividad = Contenidos.ETipodeActividad.Actividad Then
                    Response.Redirect("Actividad.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id & "&mensaje=1")
                Else
                    Response.Redirect("Examen.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id & "&mensaje=1")
                End If
            Case "Contenido"
                Response.Redirect("AddContenido.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id & "&mensaje=1")
            Case "Foro"
                Response.Redirect("Foro.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id & "&mensaje=1")
        End Select



    End Sub


    Sub CopiarContenido()
        Select Case Request("Procedencia")
            Case "Actividad"
                grabarActividad()
            Case "Contenido"
                grabarContenido()
            Case "Foro"
                grabarForo()
        End Select
    End Sub

    Sub grabarActividad()
        Dim myactividad As New Contenidos.Actividad(CInt(Request("id")))
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
        mynewactividad.Add()



        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Imagen")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Archivo")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Flash")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Liga")


        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myci.idProc = mynewactividad.id
        myci.procedencia = tipoObjeto.Actividad
        myci.idRoot = CInt(Request("idRoot"))
        myci.Add()


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

        If mynewactividad.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Response.Redirect("Examen.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id)
        Else
            Response.Redirect("Actividad.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id)
        End If


    End Sub
    Sub grabarContenido()

        Dim myCont As Contenidos.Contenido
        Dim myContTemp As New Contenidos.Contenido(CInt(Request("id")))


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
        myCont.fechaCreacion = myContTemp.fechaCreacion
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


        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myci.idProc = myCont.id
        myci.procedencia = tipoObjeto.Contenido
        myci.idRoot = CInt(Request("idRoot"))
        myci.Add()

        Response.Redirect("AddContenido.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id)


    End Sub
    Sub grabarForo()
        Dim myf As New Contenidos.Foro(CInt(Request("id")))
        Dim myfnew As New Contenidos.Foro
        myfnew.titulo = myf.titulo
        myfnew.texto = myf.texto
        myfnew.fechaCreacion = myf.texto
        myfnew.autor = myf.autor
        myfnew.Add()


        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myci.idProc = myfnew.id
        myci.procedencia = tipoObjeto.Foro
        myci.idRoot = CInt(Request("idRoot"))
        myci.Add()

        Response.Redirect("Foro.aspx?idRoot=" & myci.idRoot & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id)


    End Sub

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
            myCont.fechaCreacion = myContTemp.fechaCreacion
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


    End Function
End Class
