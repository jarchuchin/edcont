
Partial Class Sec_Workbook_Controles_MyWorkBooks
    Inherits System.Web.UI.UserControl

    Public idUserProfile As Integer = 0
    Public mostrarLigaNuevoRoot As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then



            'If Request("texto") <> "" Then
            '    txtBuscar.Text = Request("texto")
            'End If



            hdUsuario.Value = Me.idUserProfile
            Ordenar("Titulo", "asc")


            If Session("esAdministrador") Then
                lnknuevobook.Visible = True
            End If




        End If
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


    Protected Sub gvMisSalones_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvRoots.Sorting

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
        Dim myRoots As Lego.Root = New Lego.Root
        Dim ds As Data.DataSet
        If txtBuscar.Text.Trim <> "" Then
            ds = myRoots.GetDSBuscar(CInt(hdUsuario.Value), txtBuscar.Text.Trim)
        Else
            ds = myRoots.GetDS(CInt(hdUsuario.Value), True)
        End If




        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvRoots.DataSource = mydv
        gvRoots.DataBind()

        lnknuevobook.Visible = False ' mostrarLigaNuevoRoot




    End Function




    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Ordenar("Titulo", "asc")
    End Sub
    Protected Sub lnknuevobook_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnknuevobook.Click
        Response.Redirect("workbook/Default.aspx")
    End Sub
End Class
