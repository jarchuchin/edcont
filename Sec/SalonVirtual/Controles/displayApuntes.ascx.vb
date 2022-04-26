
Partial Class Sec_SalonVirtual_Controles_displayApuntes
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim myse As Know.SalonVirtualApunte = New Know.SalonVirtualApunte
        gvApuntes.DataSource = myse.GetDR(CInt(Request("idSalonVirtual")), Session("gUserProfileSession").idUserProfile)
        gvApuntes.DataBind()


        lnkSalon2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


    End Sub

End Class
