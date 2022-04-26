
Partial Class Sec_SalonVirtual_Controles_displayForos
    Inherits System.Web.UI.UserControl

    Public claveSalon As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        claveSalon = CInt(Request("idSalonVirtual"))

        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()



        Dim mys As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myf As Contenidos.Foro = New Contenidos.Foro

        If Request("idClasificacion") <> "" Then
            gvFors.DataSource = myf.GetDR(mys.idRoot, mys.id, CInt(Request("idClasificacion")))
            gvFors.DataBind()
        Else
            gvFors.DataSource = myf.GetDR(mys.idRoot, mys.id)
            gvFors.DataBind()
        End If



    End Sub

End Class

