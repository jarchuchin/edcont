
Partial Class Sec_SalonVirtual_Controles_displayExamenes
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Public salon As Integer = 0
    Sub colocarDatos()

        salon = CInt(Request("idSalonVirtual"))
        Dim myci As New Lego.ClasificacionItem
        rptObjetos.DataSource = myci.getDRExamenes(CInt(Request("idClasificacion")))
        rptObjetos.DataBind()

        If rptObjetos.Items.Count > 0 Then
            rptObjetos.Visible = True
        Else
            rptObjetos.Visible = False
        End If

    End Sub

    Public Function getUrl(claveClasificacionItem As Integer, claveClasificacion As Integer, claveidProc As Integer, claveProcedencia As String, claveRoot As Integer) As String
        Return "~/sec/salonVirtual/VerExamen.aspx?idRoot=" & claveRoot & "&idClasificacion=" & claveClasificacion & "&idCI=" & claveClasificacionItem & "&idSalonVirtual=" & salon
    End Function
End Class
