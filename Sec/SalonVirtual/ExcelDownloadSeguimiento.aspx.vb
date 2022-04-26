Imports System.IO
Imports System.Data
Imports System.Data.SqlClient


Partial Class Sec_SalonVirtual_ExcelDownloadSeguimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ExportDatasetToExcel()
        End If
    End Sub


    Private Function ExportDatasetToExcel() As String
        Dim mysvup As New Know.SalonVirtualUserProfile
        Dim salon As Integer = CInt(Request("idSalonVirtual"))




        Dim mysv As New Know.SalonVirtual(salon, False)
        Dim dtx As DataTable





        Dim GridView1 As GridView = New GridView()



        If Request("idUserProfile") <> "" Then
            dtx = mysvup.GetTablaSeguimiento(salon, CInt(Request("idUserProfile")))
        Else
            dtx = mysvup.GetTablaSeguimiento(salon)
        End If

        AddColumnsToGridView(GridView1, dtx)


        GridView1.DataSource = dtx
        GridView1.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Seguimiento" & "_" & mysv.id & "_" & Format(Date.Now, "ddMMyyyyss") & ".xls")
        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        GridView1.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()



    End Function

    Public Function AddColumnsToGridView(gv As GridView, table As DataTable) As Integer
        gv.DataSource = table
        For Each column As DataColumn In table.Columns

            Dim field As BoundField = New BoundField()
            field.DataField = column.ColumnName
            field.HeaderText = column.ColumnName
            'If column.ColumnName = "Nombre" Or column.ColumnName = "imagen" Or column.ColumnName = "idUserProfile" Or column.ColumnName = "claveAux1" Or column.ColumnName = "idSalonVirtual" Then
            'Else
            gv.Columns.Add(field)
            'End If


        Next

        gv.DataBind()

        Return 0
    End Function


End Class
