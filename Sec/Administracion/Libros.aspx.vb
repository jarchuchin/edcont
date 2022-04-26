
Partial Class Sec_Administracion_Libros
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

        End If
        OrdenarDefault("Titulo", "asc")
    End Sub


    Public Property GridViewSortDirection() As SortDirection
        Get
            If IsNothing(ViewState("sortDirection")) Then
                ViewState("sortDirection") = SortDirection.Ascending
            End If
            Return CType(ViewState("sortDirection"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("sortDirection") = value
        End Set
    End Property


    Public numeroRegistro As Integer


    Protected Sub gvMisSalones_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvSalones.Sorting
        System.Threading.Thread.Sleep(1500)
        Dim orden As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            Ordenar(orden, "desc")
        Else
            GridViewSortDirection = SortDirection.Ascending
            Ordenar(orden, "asc")
        End If
    End Sub


    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String) As Integer
        Dim mylibros As Lego.Root = New Lego.Root

        Dim ds As Data.DataSet
        If txtBuscar.Text = "" Then
            ds = mylibros.GetDS2()
        Else
            ds = mylibros.GetDS(txtBuscar.Text)
        End If



        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.RowFilter = "idEmpresa=" & CInt(Session("idEmpresa"))


        mydv.Sort = expresion + " " + direccion
        gvSalones.DataSource = mydv
        gvSalones.DataBind()


    End Function

    Private Function OrdenarDefault(ByVal expresion As String, ByVal direccion As String) As Integer
        Dim mylibros As Lego.Root = New Lego.Root
        Dim ds As Data.DataSet = mylibros.GetDSUnid


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.RowFilter = "idEmpresa=" & CInt(Session("idEmpresa"))

        mydv.Sort = expresion + " " + direccion
        gvSalones.DataSource = mydv
        gvSalones.DataBind()


    End Function

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Ordenar("Titulo", "asc")
    End Sub

    Protected Sub btnCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrear.Click
        Response.Redirect("~/sec/Workbook/default.aspx?idUserProfile=0")
    End Sub
End Class
