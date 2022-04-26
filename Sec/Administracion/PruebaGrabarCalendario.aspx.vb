
Partial Class Sec_Administracion_PruebaGrabarCalendario
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mya As New Comm.Agenda


        Label1.Text = "numero de actividades " & mya.GrabarCalendario(62, 30024, Date.Now)
    End Sub
End Class
