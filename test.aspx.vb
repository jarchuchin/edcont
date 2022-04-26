
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myuser As New MasUsuarios.UserProfile(62, False)
        myuser.passwordUM = myuser.convertirpass("alaska")
        myuser.usuarioUM = "jrsnchz"

        myuser.Update()




    End Sub
End Class
