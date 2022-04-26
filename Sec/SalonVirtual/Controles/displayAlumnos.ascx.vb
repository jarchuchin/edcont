
Partial Class Sec_SalonVirtual_Controles_displayAlumnos
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mysv As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()

        gvAlumnos.DataSource = mysv.GetDR(CInt(Request("idSalonVirtual")))
        gvAlumnos.DataBind()


    End Sub


   
End Class
