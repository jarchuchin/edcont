
Partial Class Logout
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim varempresa As Integer = Session("idEmpresa")

        Dim myUserSession As MasUsuarios.UserProfileSession = New MasUsuarios.UserProfileSession
        Session("gUserProfileSession") = myUserSession
        System.Web.Security.FormsAuthentication.SignOut()

        Session("correoEnviado") = Nothing

        Session("ingresoAdmin") = Nothing


        Session.Abandon()
        Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))


        Dim err As String = ""
        If Request("error") <> "" Then
            err = "&error=" & Request("error")
        End If




        Dim redireccion As String
        If Request("idEmp") <> "" Then
            redireccion = "default.aspx?idEmp=" & Request("idEmp")
        Else
            redireccion = "default.aspx?idEmpresa=" & varempresa & err
        End If



        Response.Redirect(redireccion)
    End Sub
End Class
