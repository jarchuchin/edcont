
Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports System.IO


Partial Class Sec_SalonVirtual_VistaPreviaRespuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If



        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    End Sub

    Sub colocarDatos()
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)




        Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myu.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        '   imgAlumno.ImageUrl = getFoto(myeu.claveAux1, myeu.claveAux2)









        claveSalon = myr.idSalonVirtual
        claveUsuario = myr.idUserProfile
        claveRespuesta = myr.id







        Dim myra As New Contenidos.RespuestaArchivo(CInt(Request("idRespuestaArchivo")))
        actividad.Text = myra.nombreOriginal
        Page.Title = myra.nombreOriginal

        Select Case Request("visor")
            Case "google"

                If myra.nombre.ToLower.Contains(".xls") Or myra.nombre.ToLower.Contains(".xlsx") Or myra.nombre.ToLower.Contains(".csv") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".doc") Or myra.nombre.ToLower.Contains(".docx") Or myra.nombre.ToLower.Contains(".txt") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".ppt") Or myra.nombre.ToLower.Contains(".pptx") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If

            Case "ms"

                If myra.nombre.ToLower.Contains(".xls") Or myra.nombre.ToLower.Contains(".xlsx") Or myra.nombre.ToLower.Contains(".csv") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://view.officeapps.live.com/op/embed.aspx?src=" & x1 & """ width=""100%"" height=""700px"" frameborder='0'>This is an embedded <a target='_blank' href='http://office.com'>Microsoft Office</a> document, powered by <a target='_blank' href='http://office.com/webapps'>Office Online</a>.</iframe>")

                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".doc") Or myra.nombre.ToLower.Contains(".docx") Or myra.nombre.ToLower.Contains(".docx") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://view.officeapps.live.com/op/embed.aspx?src=" & x1 & """ width=""100%"" height=""700px"" frameborder='0'>This is an embedded <a target='_blank' href='http://office.com'>Microsoft Office</a> document, powered by <a target='_blank' href='http://office.com/webapps'>Office Online</a>.</iframe>")

                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".ppt") Or myra.nombre.ToLower.Contains(".pptx") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://view.officeapps.live.com/op/embed.aspx?src=" & x1 & """ width=""100%"" height=""700px"" frameborder='0'>This is an embedded <a target='_blank' href='http://office.com'>Microsoft Office</a> document, powered by <a target='_blank' href='http://office.com/webapps'>Office Online</a>.</iframe>")

                    litArchivo.Text = cadena.ToString
                End If

            Case Else
                If myra.nombre.ToLower.Contains(".xls") Or myra.nombre.ToLower.Contains(".xlsx") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".doc") Or myra.nombre.ToLower.Contains(".docx") Or myra.nombre.ToLower.Contains(".txt") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If
                If myra.nombre.ToLower.Contains(".ppt") Or myra.nombre.ToLower.Contains(".pptx") Then
                    Dim cadena As New StringBuilder
                    Dim x1 As String = ""
                    x1 = "https://" + Request.ServerVariables("HTTP_HOST") & "/pub/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1&embedded=true"
                    cadena.AppendLine("<iframe src=""https://docs.google.com/gview?url=" & x1 & """ width=""100%"" height=""700px"" >")
                    cadena.AppendLine("</iframe>")
                    litArchivo.Text = cadena.ToString
                End If
        End Select

        If myra.nombre.ToLower.Contains(".pdf") Then
            Dim cadena As New StringBuilder
            cadena.AppendLine("<iframe src=""" & "/sec/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1"" width=""90%"" height=""500px"" >")
            cadena.AppendLine("</iframe>")
            litArchivo.Text = cadena.ToString
        End If


        If myra.nombre.ToLower.Contains(".jpg") Or myra.nombre.ToLower.Contains(".jpeg") Or myra.nombre.ToLower.Contains(".bmp") Or myra.nombre.ToLower.Contains(".gif") Or myra.nombre.ToLower.Contains(".png") Or myra.nombre.ToLower.Contains(".tif") Then
            Dim cadena As New StringBuilder
            cadena.AppendLine("<img src=""" & "/sec/showfile.aspx?idRespuestaArchivo=" & myra.id & "&down=1"" width=""90%"" / >")

            litArchivo.Text = cadena.ToString
        End If

    End Sub








    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function


    Function getFoto(ByVal claveAlumno As String, ByVal claveMaestro As String) As String


        If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveAlumno & ".jpg") Then
            Return "~/sec/Usuarios/Fotos/" & claveAlumno & ".jpg"
        Else
            If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveMaestro & ".jpg") Then
                Return "~/sec/Usuarios/Fotos/" & claveMaestro & ".jpg"
            Else
                Return "~/images/pagina/IconAlumno.jpg"
            End If

        End If

    End Function


    Dim claveSalon As Integer
    Dim claveUsuario As Integer
    Dim claveRespuesta As Integer





End Class
