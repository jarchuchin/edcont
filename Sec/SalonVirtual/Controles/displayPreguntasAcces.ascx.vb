
Partial Class Sec_SalonVirtual_Controles_displayPreguntasAcces
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
       
        lnkSalon1.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
        lnkSalon2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


    End Sub
End Class
