Imports System.IO

Namespace usmart

    Class pub_showFile
        Inherits System.Web.UI.Page

        Dim cadenaheader As String = ""

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            activarArchivo()
        End Sub


        Sub activarArchivo()




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
                            Response.Clear()
                            Response.ContentType = getTipoArchivo(myra.nombre.Substring(myra.nombre.LastIndexOf(".") + 1).ToLower, "")
                            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)
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

                            ' Response.HeaderEncoding = System.Text.Encoding.UTF8

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
                            '   Response.Buffer = True
                            '  Response.Charset = ""
                            '  Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Response.AppendHeader("Content-Length", File.ReadAllBytes(pathfile).Length)
                            Response.TransmitFile(pathfile)
                            ' Response.BinaryWrite(archivoforo)
                            ' Response.OutputStream.Write(archivoforo, 0, archivoforo.Length)
                            'Response.OutputStream.Flush()
                            'Response.OutputStream.Close()
                            ' Response.Flush()
                            Response.End()
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
