<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        'Dim myidioma As Utilerias.Idioma = New Utilerias.Idioma
        'Application("gIdiomas") = myidioma.GetDS().Tables(0).DefaultView

        Application("usuariosconectados") = 0
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Dim myUserSession As MasUsuarios.UserProfileSession = New MasUsuarios.UserProfileSession
        Session("gUserProfileSession") = myUserSession
        Session("CultureID") = "es-MX"

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        If Application("usuariosconectados") > 0 Then
            Application("usuariosconectados") = Application("usuariosconectados") - 1
        End If

    End Sub



    Protected Sub Application_BeginRequest(sender As [Object], e As EventArgs)
        'If HttpContext.Current.Request.IsSecureConnection.Equals(False) AndAlso HttpContext.Current.Request.IsLocal.Equals(False) Then
        '    Response.Redirect("https://" + Request.ServerVariables("HTTP_HOST") + HttpContext.Current.Request.RawUrl)
        'End If
    End Sub


    Protected Sub Application_AcquireRequestState(sender As Object, e As System.EventArgs)
        If Not IsNothing(HttpContext.Current.Session) Then
            If Not IsNothing(Session) And Session.IsNewSession Then

                If Not IsNothing(Request.Headers("Cookie")) Then

                    Dim szCookieHeader As String = Request.Headers("Cookie")
                    If Not IsNothing(szCookieHeader) And (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0) Then
                        If User.Identity.IsAuthenticated Then
                            FormsAuthentication.SignOut()
                            Response.Redirect(Request.RawUrl)

                        End If
                    End If

                End If

            End If
        End If


    End Sub



</script>