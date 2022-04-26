Imports System.IO

Namespace usmart

    Class showFile
        Inherits System.Web.UI.Page

        Dim cadenaheader As String = ""

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            activarArchivo()
        End Sub


        Sub activarArchivo()



            If Request("idCont") <> "" Then

                Dim myCont As Contenidos.Contenido = New Contenidos.Contenido(CInt(Request("idCont")))
                Dim myArchivo As Contenidos.Archivo = New Contenidos.Archivo(CInt(Request("idCont")), myCont.extension)


                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & myCont.id & "." & myCont.extension


                If myArchivo.existe Then
                    Dim filename As String
                    filename = HttpUtility.UrlEncode(myCont.nombreOriginal, System.Text.Encoding.UTF8)
                    filename = filename.Replace("+", "%20")

                    Dim esImagen As Boolean = System.Text.RegularExpressions.Regex.IsMatch(myCont.tipoArchivo, "image/\S+")
                    If esImagen Then
                        Response.Clear()
                        Response.ContentType = myCont.tipoArchivo
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                        Response.BinaryWrite(myArchivo.Archivo)
                    Else
                        Response.Clear()
                        Response.ContentType = getTipoArchivo(myCont.extension, myCont.tipoArchivo)
                        Response.HeaderEncoding = System.Text.Encoding.UTF8
                        If Request("down") = "1" Then
                            Response.AppendHeader("Content-Disposition", "inline; filename=" & filename)
                        Else
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                        End If


                        Response.Buffer = True
                        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)

                        Response.TransmitFile(pathfile)
                        ' Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                        Response.Flush()
                        Response.End()

                        ' Response.TransmitFile(pathfile)

                        ' Response.OutputStream.Write(myArchivo.Archivo, 0, myArchivo.Archivo.Length)
                    End If

                End If
            End If

            If Request("idClasificacion") <> "" Then
                Dim numero As String = Request("num")
                Dim myc As New Lego.Clasificacion(CInt(Request("idClasificacion")))

                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Clasificaciones\"
                Dim fileName As String = ""
                Select Case numero
                    Case "1"
                        fileName = myc.Imagen1
                    Case "2"
                        fileName = myc.Imagen2
                    Case "3"
                        fileName = myc.Imagen3

                End Select

                pathfile = pathfile & fileName

                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()


                    Response.ContentType = "image/png"
                    Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)



                End If

            End If


            If Request("idPregunta") <> "" Then
                Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idPregunta")))

                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & myPregunta.fileName
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    'Dim file As System.IO.File = file.GetAttributes(pathfile).get

                    If Request("display") <> "" Then
                        Response.ContentType = "image/png"
                        Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                    Else
                        If myPregunta.fileName.ToString.Contains(" ") Then
                            Response.AppendHeader("Content-Disposition", "attachment; filename='" & myPregunta.fileName & "'")
                        Else
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & myPregunta.fileName)
                        End If

                        'Response.BinaryWrite(archivoforo)

                        Response.TransmitFile(pathfile)


                    End If


                End If

            End If


            If Request("idOpcionRespuesta") <> "" Then
                Dim myOpcionR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(CInt(Request("idOpcionRespuesta")))

                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOpcionR.fileName
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    If Request("display") <> "" Then
                        Response.ContentType = "image/png"
                        Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                    Else
                        If myOpcionR.fileName.ToString.Contains(" ") Then
                            Response.AppendHeader("Content-Disposition", "attachment; filename='" & myOpcionR.fileName & "'")
                        Else
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & myOpcionR.fileName)
                        End If

                        ' Response.BinaryWrite(archivoforo)
                        Response.TransmitFile(pathfile)

                    End If

                End If

            End If

            If Request("idForoSalonVirtual") <> "" Then

                Dim myforosv As Contenidos.ForoSalonVirtual = New Contenidos.ForoSalonVirtual(CInt(Request("idForoSalonVirtual")))
                Dim filename As String
                filename = HttpUtility.UrlEncode(myforosv.nombreOriginal, System.Text.Encoding.UTF8)
                filename = filename.Replace("+", "%20")


                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "foros\" & myforosv.nombre
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    Select Case myforosv.nombre.Substring(myforosv.nombre.LastIndexOf(".") + 1).ToLower
                        Case "jpg", "bmp", "gif", "png", "jpeg"
                            Response.ContentType = "image/" & myforosv.nombre.Substring(myforosv.nombre.LastIndexOf(".") + 1).ToLower
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                            Response.BinaryWrite(archivoforo)
                        Case Else
                            Response.Clear()
                            Response.ContentType = getTipoArchivo(myforosv.nombre.Substring(myforosv.nombre.LastIndexOf(".") + 1).ToLower, "")
                            ' Response.HeaderEncoding = System.Text.Encoding.UTF8

                            If filename.Contains(" ") Then
                                Response.AppendHeader("Content-Disposition", "attachment; filename='" & filename & "'")
                            Else
                                Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                            End If



                            Response.TransmitFile(pathfile)
                            ' Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                    End Select

                End If

            End If

            If Request("idRespuestaArchivo") <> "" Then

                Dim myra As Contenidos.RespuestaArchivo = New Contenidos.RespuestaArchivo(CInt(Request("idRespuestaArchivo")))
                Dim filename As String
                filename = HttpUtility.UrlEncode(myra.nombreOriginal, System.Text.Encoding.UTF8)
                filename = filename.Replace("+", "%20")


                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & myra.nombre
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then


                    Response.Clear()





                    Select Case myra.nombre.Substring(myra.nombre.LastIndexOf(".") + 1).ToLower
                        Case "jpg", "bmp", "gif", "png"
                            Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                            ReDim archivoforo(fs.Length)
                            fs.Read(archivoforo, 0, fs.Length)
                            fs.Close()
                            Response.ContentType = getTipoArchivo(myra.nombre.Substring(myra.nombre.LastIndexOf(".") + 1).ToLower, "")
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                            Response.BinaryWrite(archivoforo)
                        Case Else

                            Response.Clear()

                            Dim ctprueba As String = ""
                            If filename.Substring(filename.LastIndexOf(".") + 1).ToLower = "xlsx" Or filename.Substring(filename.LastIndexOf(".") + 1).ToLower = "xls" Then
                                ctprueba = MimeMapping.GetMimeMapping(pathfile)
                                'ctprueba = getTipoArchivo(myra.nombre.Substring(myra.nombre.LastIndexOf(".") + 1).ToLower, "")
                            Else
                                ctprueba = getTipoArchivo(myra.nombre.Substring(myra.nombre.LastIndexOf(".") + 1).ToLower, "")
                            End If


                            'Response.AddHeader("Content-Length", filename.Length.ToString())
                            ' Response.ContentType = ctprueba
                            Response.ContentType = ctprueba

                            Response.HeaderEncoding = System.Text.Encoding.UTF8

                            If filename.Contains(" ") Then
                                If Request("down") = "1" Then
                                    Response.AppendHeader("Content-Disposition", "inline; filename='" & filename & "'")
                                Else
                                    Response.AppendHeader("Content-Disposition", "attachment; filename='" & filename & "'")
                                End If

                            Else
                                If Request("down") = "1" Then
                                    Response.AppendHeader("Content-Disposition", "inline; filename=" & filename)
                                Else
                                    Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                                End If

                            End If
                            Response.AppendHeader("Content-Length", File.ReadAllBytes(pathfile).Length)
                            Response.TransmitFile(pathfile)
                            'Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                            'Response.OutputStream.Flush()
                            'Response.OutputStream.Close()
                            ' Response.Flush()
                            Response.End()
                    End Select

                End If
            End If



            If Request("idUserProfile") <> "" Then
                Dim myup As New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)

                Dim filename As String = myup.imagen

                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "fotousuarios\mini\" & myup.imagen
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    Response.Clear()
                    Response.ContentType = getTipoArchivo(myup.imagen.Substring(myup.imagen.LastIndexOf(".") + 1).ToLower, "")
                    Response.HeaderEncoding = System.Text.Encoding.UTF8
                    If filename.Contains(" ") Then
                        Response.AppendHeader("Content-Disposition", "attachment; filename='" & filename & "'")
                    Else
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                    End If
                    Response.BinaryWrite(archivoforo)



                End If
            End If


            If Request("idRoot") <> "" Then
                Dim myroot As New Lego.Root(CInt(Request("idRoot")))

                Dim filename As String = "LibroDeTrabajo_" & myroot.id & ".pdf"

                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "prontuarios\" & filename
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    Response.Clear()
                    Response.ClearContent()
                    Response.ContentType = "Application/pdf"
                    Response.HeaderEncoding = System.Text.Encoding.UTF8
                    If filename.Contains(" ") Then
                        Response.AppendHeader("Content-Disposition", "attachment; filename='" & filename & "'")
                    Else
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                    End If
                    Response.BinaryWrite(archivoforo)



                End If
            End If



            If Request("idCatalogoActividadHP") <> "" Then
                Dim mycahp As New Contenidos.CatalogoActividadHP(CInt(Request("idCatalogoActividadHP")))

                Dim filename As String
                If Request("tipoarchivo") = "formato" Then
                    filename = mycahp.FileFormato
                Else
                    filename = mycahp.FileEjemplo

                End If




                Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & filename
                Dim archivoforo() As Byte
                If File.Exists(pathfile) Then
                    Dim fs As FileStream = New FileStream(pathfile, FileMode.OpenOrCreate, FileAccess.Read)
                    ReDim archivoforo(fs.Length)
                    fs.Read(archivoforo, 0, fs.Length)
                    fs.Close()

                    Select Case filename.Substring(filename.LastIndexOf(".") + 1).ToLower
                        Case "jpg", "bmp", "gif", "png"
                            Response.ContentType = getTipoArchivo(filename.Substring(filename.LastIndexOf(".") + 1).ToLower, "")
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                            Response.BinaryWrite(archivoforo)
                        Case Else
                            Response.Clear()

                            Response.ContentType = getTipoArchivo(filename.Substring(filename.LastIndexOf(".") + 1).ToLower, "")
                            Response.HeaderEncoding = System.Text.Encoding.UTF8

                            If filename.Contains(" ") Then
                                Response.AppendHeader("Content-Disposition", "attachment; filename='" & filename & "'")
                            Else
                                Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename)
                            End If

                            Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                    End Select

                End If
            End If

        End Sub


        Public Function getTipoArchivo(ByVal extensionFile As String, localContentType As String) As String
            Dim regreso As String = ""
            Select Case extensionFile.ToLower
                Case "doc", "dot"
                    regreso = "Application/msword"
                Case "docx"
                    regreso = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                Case "dotx"
                    regreso = "application/vnd.openxmlformats-officedocument.wordprocessingml.template"
                Case "docm", "dotm"
                    regreso = "application/vnd.ms-word.document.macroEnabled.12"
                Case "ppt", "pot", "pps", "ppa"
                    regreso = "application/vnd.ms-powerpoint"
                Case "pptx"
                    regreso = "application/vnd.openxmlformats-officedocument.presentationml.presentation"
                Case "potx"
                    regreso = "application/vnd.openxmlformats-officedocument.presentationml.template"
                Case "ppsx"
                    regreso = "application/vnd.openxmlformats-officedocument.presentationml.slideshow"
                Case "ppam"
                    regreso = "application/vnd.ms-powerpoint.addin.macroEnabled.12"
                Case "pptm"
                    regreso = "application/vnd.ms-powerpoint.presentation.macroEnabled.12"
                Case "potm"
                    regreso = "application/vnd.ms-powerpoint.template.macroEnabled.12"
                Case "ppsm"
                    regreso = "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"
                Case "mdb"
                    regreso = "application/vnd.ms-access"
                Case "xls", "xlc", "xlt", "xla"
                    regreso = "application/vnd.ms-excel"
                Case "xlsx"
                    ' regreso = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    regreso = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Case "xltx"
                    regreso = "application/vnd.openxmlformats-officedocument.spreadsheetml.template"
                Case "xlsm"
                    regreso = "application/vnd.ms-excel.sheet.macroEnabled.12"
                Case "xltm"
                    regreso = "application/vnd.ms-excel.template.macroEnabled.12"
                Case "xlam"
                    regreso = "application/vnd.ms-excel.addin.macroEnabled.12"
                Case "xlsb"
                    regreso = "application/vnd.ms-excel.sheet.binary.macroEnabled.12"
                Case "txt"
                    regreso = "text/plain"
                Case "pdf"
                    regreso = "Application/pdf"
                Case "zip"
                    regreso = "application/zip"
                Case "rar"
                    regreso = "application/rar"
                Case "jpg", "bmp", "gif", "png", "jpeg"
                    regreso = "image/" & extensionFile.ToLower
                Case Else
                    If localContentType <> "" Then
                        regreso = localContentType
                    Else
                        regreso = "application/" & extensionFile.ToLower
                    End If


                    Return regreso

            End Select

            Return regreso

        End Function


    End Class

End Namespace
