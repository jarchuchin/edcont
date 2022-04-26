
Partial Class Sec_SalonVirtual_windows_pdf
    Inherits System.Web.UI.Page

    Private Sub Sec_SalonVirtual_windows_pdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos
        End If
    End Sub

    Sub colocarDatos()
        Dim myc As New Contenidos.Contenido(CInt(Request("idCont")))


        litFile.Text = "<object type=""application/pdf""  width=""100%"" height=""550px"" data=""../../showfile.aspx?idCont=" & myc.id & "&down=1""><embed src=""../../showfile.aspx?idCont=" & myc.id & "&down=1"" type=""application/pdf"" /></object>"
    End Sub
End Class
