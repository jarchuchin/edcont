
Partial Class Sec_Workbook_Controles_DisplayObjetosAprendizaje
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As New Lego.ClasificacionItem
        rptObjetos.DataSource = myci.getDRObjetosAprendizaje(CInt(Request("idClasificacion")))
        rptObjetos.DataBind()

		If rptObjetos.Items.Count > 0 Then
			rptObjetos.Visible = True
			lblNoData.Visible = False
		Else
			rptObjetos.Visible = False
			lblNoData.Visible = True
		End If
	End Sub

    Public Function getUrl(claveClasificacionItem As Integer, claveClasificacion As Integer, claveidProc As Integer, claveProcedencia As String, claveRoot As Integer) As String
		Return "~/sec/workbook/AddContenido.aspx?idRoot=" & claveRoot & "&idClasificacion=" & claveClasificacion & "&idCI=" & claveClasificacionItem
	End Function
End Class
