
Partial Class Sec_SalonVirtual_Controles_MisSalonesVirtuales
    Inherits System.Web.UI.UserControl

    Public Status As Boolean = True
    Public idUserProfile As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then





            hdStatus.Value = Me.Status
            hdUsuario.Value = Me.idUserProfile
            hdCantidad.Value = 20
            Ordenar("fechaInicio", "desc", 20)

            btnNuevo.Visible = Session("esAdministrador")

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


    Protected Sub gvMisSalones_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvMisSalones.Sorting

        Dim orden As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            Ordenar(orden, "desc", CInt(hdCantidad.Value))
        Else
            GridViewSortDirection = SortDirection.Ascending
            Ordenar(orden, "asc", CInt(hdCantidad.Value))
        End If
    End Sub


    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String, ByVal cantidadregistros As Integer) As Integer
        Dim mySalones As Know.SalonVirtual = New Know.SalonVirtual
        Dim ds As Data.DataSet


        If txtBuscar.Text.Trim <> "" Then
            ds = mySalones.GetDSBuscar(CInt(hdUsuario.Value), txtBuscar.Text.Trim)

        Else
            ds = mySalones.GetDS(CInt(hdUsuario.Value), CType(Me.Status, Boolean), cantidadregistros)
        End If

        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvMisSalones.DataSource = mydv
        gvMisSalones.DataBind()


    End Function





    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Response.Redirect("salonvirtual/AddSalonVirtual.aspx")
    End Sub

    Protected Sub lnkTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTodos.Click

        hdCantidad.Value = 1000
        Ordenar("FechaInicio", "desc", CInt(hdCantidad.Value))
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        hdCantidad.Value = 1000

        Ordenar("Nombre", "asc", CInt(hdCantidad.Value))
    End Sub

End Class
