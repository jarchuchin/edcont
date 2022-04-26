
Partial Class Sec_Workbook_Controles_DisplayActividadesUnidad
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As New Lego.ClasificacionItem
        rptObjetos.DataSource = myci.getDRActvidades(CInt(Request("idClasificacion")))
        rptObjetos.DataBind()

        If rptObjetos.Items.Count > 0 Then
            rptObjetos.Visible = True
        Else
            rptObjetos.Visible = False
        End If

    End Sub

    Public Function getUrl(claveClasificacionItem As Integer, claveClasificacion As Integer, claveidProc As Integer, claveProcedencia As String, claveRoot As Integer) As String
		Return "~/sec/workbook/Actividad.aspx?idRoot=" & claveRoot & "&idClasificacion=" & claveClasificacion & "&idCI=" & claveClasificacionItem
	End Function
End Class
