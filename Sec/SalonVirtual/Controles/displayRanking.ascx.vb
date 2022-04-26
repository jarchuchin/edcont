
Partial Class Sec_SalonVirtual_Controles_DisplayRanking
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub

    Sub iniciarControles()

        Dim myR As Contenidos.Respuesta = New Contenidos.Respuesta

        Image1.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 1))
        Image2.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 2))
        Image3.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 3))
        Image4.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 4))
        Image5.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 5))
        Image6.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 6))
        Image7.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 7))
        Image8.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 8))
        Image9.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 9))
        Image10.Height = Unit.Pixel(myR.CountRaiz(CInt(Request("idR")), 10))

        lblNumeroPersonas.Text = myR.Count(CInt(Request("idR")))

    End Sub

End Class
