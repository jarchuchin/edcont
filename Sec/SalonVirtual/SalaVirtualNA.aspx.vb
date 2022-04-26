
Partial Class Sec_SalonVirtual_SalaVirtualNA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))

        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)


        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual

        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual
    End Sub
End Class
