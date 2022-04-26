
Partial Class Sec_SalonVirtual_Accesos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()

        Dim myse As Know.SalonVirtualEntrada = New Know.SalonVirtualEntrada

        If Request("idUserProfile") <> "" Then
            gvAccesos.DataSource = myse.GetDS(CInt(Request("idSalonVirtual")), CInt(Request("idUserProfile")))
            gvAccesos.DataBind()


        Else
            gvAccesos.DataSource = myse.GetDS(CInt(Request("idSalonVirtual")))
            gvAccesos.DataBind()
        End If

        drpUsuariosAccesos.DataSource = myse.GetDSUsuarios(CInt(Request("idSalonVirtual")))
        drpUsuariosAccesos.DataBind()


    End Sub

    Protected Sub drpUsuariosAccesos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpUsuariosAccesos.SelectedIndexChanged
        System.Threading.Thread.Sleep(1500)
        Dim myse As Know.SalonVirtualEntrada = New Know.SalonVirtualEntrada
        gvAccesos.DataSource = myse.GetDS(CInt(Request("idSalonVirtual")), CInt(drpUsuariosAccesos.SelectedValue))
        gvAccesos.DataBind()


    End Sub
End Class
