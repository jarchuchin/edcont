Imports System.Data


Partial Class Sec_SalonVirtual_ListaSeguimiento
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Ordenar("Apellidos", "asc")
        End If

        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))

        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)


        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual

        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

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





    'Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvListaAlumnos.Sorting
    '    System.Threading.Thread.Sleep(1000)
    '    Dim orden As String = e.SortExpression

    '    If GridViewSortDirection = SortDirection.Ascending Then
    '        GridViewSortDirection = SortDirection.Descending
    '        Ordenar(orden, "desc")
    '    Else
    '        GridViewSortDirection = SortDirection.Ascending
    '        Ordenar(orden, "asc")
    '    End If
    'End Sub


    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String) As Integer
        Dim mye As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()
        'Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idSalonVirtual")))




        'Dim mydt As System.Data.DataTable = ds.Tables(0)
        'Dim mydv As Data.DataView = New Data.DataView(mydt)
        'mydv.Sort = expresion + " " + direccion
        'gvListaAlumnos.DataSource = mydv
        'gvListaAlumnos.DataBind()



        '  GridView1.DataSource = mye.GetTablaSeguimiento(CInt(Request("idSalonVirtual")))
        ' GridView1.DataBind()




        'Dim col As Integer = 0
        'For col = 0 To GridView1.Columns.Count - 1
        '    If GridView1.Columns(col).HeaderText.Contains("Periodo") Then
        '        GridView1.Columns(col).Visible = False
        '    End If
        'Next

        ' GridView1.Columns.I


    End Function

    Public Function AddColumnsToGridView(gv As GridView, table As DataTable) As Integer
        gv.DataSource = table
        For Each column As DataColumn In table.Columns

            Dim field As BoundField = New BoundField()
            field.DataField = column.ColumnName
            field.HeaderText = column.ColumnName
            If column.ColumnName = "Nombre" Or column.ColumnName = "imagen" Or column.ColumnName = "idUserProfile" Or column.ColumnName = "claveAux1" Or column.ColumnName = "idSalonVirtual" Then
            Else
                gv.Columns.Add(field)
            End If


        Next

        gv.DataBind()

    End Function




    'Protected Sub lnkEnviarCorreo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviarCorreo1.Click
    '    Response.Redirect("EnviarCorreo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correos=" & enviar())

    'End Sub



    Public Function GetCalificacion(ByVal claveusuario As Integer) As String
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
        Return Format(CDec(mysvu.GetCalificacionGeneral(claveusuario, CInt(Request("idSalonVirtual")))) / CDec(10.0), "0.00")

    End Function




End Class
