Imports System.Data

Partial Class Sec_SalonVirtual_Controles_displayEstadisticasSalonAlumno
    Inherits System.Web.UI.UserControl



    Public IndiceActividadesEnviadas As Decimal
    Public PromedioActividades As Decimal
    Public PromedioComputada As Decimal


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As New Lego.ClasificacionItem(CInt(Request("idCI")))

        Dim mysvup As New Know.SalonVirtualUserProfile
        Dim salon As Integer = CInt(Request("idSalonVirtual"))
        Dim usuario As Integer = CInt(Request("idUserProfile"))



        Dim mysv As New Know.SalonVirtual(salon, False)
        Dim dtx As DataTable = mysvup.GetTablaSeguimiento(salon, usuario)

        AddColumnsToGridView(GridView1, dtx)

        Dim dv As DataView = dtx.DefaultView
        Dim mitup As Tuple(Of Decimal, Decimal, Decimal) = Sumar(dv)
        IndiceActividadesEnviadas = mitup.Item1
        PromedioActividades = mitup.Item2
        PromedioComputada = mitup.Item3

        '   divTotalIndice.Attributes.Add("data-percent", CInt(IndiceActividadesEnviadas).ToString)

        lnkDescargar.NavigateUrl = "~/sec/salonVirtual/ExcelDownloadSeguimiento.aspx?idSalonVirtual=" & mysv.id & "&idUserProfile=" & usuario

        Dim cadena As New StringBuilder
        cadena.AppendLine("<script>")
        cadena.AppendLine("$(document).ready(function() {")
        cadena.AppendLine("Morris.Bar({")
        cadena.AppendLine("element: 'graficaSeguimientoSalon-morris-area',")
        cadena.AppendLine("data: [")
        Dim entro As Boolean = False


        Dim fechaLoop As Date = mysv.fechaInicio
        Dim fechaSemana As Date = fechaLoop
        Dim semana As Integer = 1
        Dim actividad As Integer = 1
        Dim mituple As Tuple(Of Integer, Integer, Decimal)

        Do While fechaLoop <= mysv.fechaFin

            If fechaLoop.DayOfWeek = DayOfWeek.Saturday Then


                If entro Then
                    cadena.Append(",")
                    cadena.Append("{")
                    cadena.Append("periodo: 'S" & semana & "', ")
                    mituple = Me.sumarColumna("S" & semana, dv)
                    cadena.Append("dl: " & mituple.Item1 & ", ")
                    cadena.Append("up: " & mituple.Item2)
                    cadena.AppendLine(" }")
                Else
                    cadena.Append("{")
                    cadena.Append("periodo: 'S" & semana & "', ")
                    mituple = Me.sumarColumna("S" & semana, dv)
                    cadena.Append("dl: " & mituple.Item1 & ", ")
                    cadena.Append("up: " & mituple.Item2)
                    cadena.AppendLine(" }")
                End If
                entro = True

                semana = semana + 1
            End If


            fechaLoop = fechaLoop.AddDays(1)


        Loop


        cadena.AppendLine("],")

        cadena.AppendLine("xkey: 'periodo',")
        cadena.AppendLine("ykeys: ['dl', 'up' ],")
        cadena.AppendLine("labels: ['Activiades', 'Actividades enviadas'],")
        cadena.AppendLine("gridEnabled: false,")
        cadena.AppendLine("gridLineColor: 'transparent',")
        ' cadena.AppendLine("lineColors: ['#045d97'],")
        cadena.AppendLine("barColors: ['#177bbb', '#afd2f0'],")
        'cadena.AppendLine("pointSize: 0,")
        'cadena.AppendLine("pointStrokeColors : ['#045d97'],")
        'cadena.AppendLine("lineWidth: 0,")
        cadena.AppendLine("resize: true,")
        cadena.AppendLine("hideHover: 'auto',")
        'cadena.AppendLine("fillOpacity: 0.7,")
        'cadena.AppendLine("parseTime: false")
        cadena.AppendLine("")
        cadena.AppendLine("")



        cadena.AppendLine("});")




        'avance de curso
        cadena.AppendLine("")
        cadena.AppendLine("")
        cadena.AppendLine("$('#demo-pie-1').easyPieChart({")
        cadena.AppendLine("barColor :'#68b828',")
        cadena.AppendLine("scaleColor: false,")
        cadena.AppendLine("trackColor : '#eee',")
        cadena.AppendLine("lineCap : 'round',")
        cadena.AppendLine("lineWidth :8,")
        cadena.AppendLine("onStep: function(from, to, percent) {")
        cadena.AppendLine("   $(this.el).find('.pie-value').text(Math.round(percent) + '%');")
        cadena.AppendLine("}")
        cadena.AppendLine("});")
        cadena.AppendLine("")
        cadena.AppendLine("")



        'avance de curso
        cadena.AppendLine("")
        cadena.AppendLine("")
        cadena.AppendLine("$('#demo-pie-2').easyPieChart({")
        cadena.AppendLine("barColor :'#8465d4',")
        cadena.AppendLine("scaleColor: false,")
        cadena.AppendLine("trackColor : '#eee',")
        cadena.AppendLine("lineCap : 'round',")
        cadena.AppendLine("lineWidth :8,")
        cadena.AppendLine("onStep: function(from, to, percent) {")
        cadena.AppendLine("   $(this.el).find('.pie-value').text(Math.round(percent) + '%');")
        cadena.AppendLine("}")
        cadena.AppendLine("});")
        cadena.AppendLine("")
        cadena.AppendLine("")




        'avance de curso
        cadena.AppendLine("")
        cadena.AppendLine("")
        cadena.AppendLine("$('#demo-pie-3').easyPieChart({")
        cadena.AppendLine("barColor :'#683328',")
        cadena.AppendLine("scaleColor: false,")
        cadena.AppendLine("trackColor : '#eee',")
        cadena.AppendLine("lineCap : 'round',")
        cadena.AppendLine("lineWidth :8,")
        cadena.AppendLine("onStep: function(from, to, percent) {")
        cadena.AppendLine("   $(this.el).find('.pie-value').text(Math.round(percent) + '%');")
        cadena.AppendLine("}")
        cadena.AppendLine("});")
        cadena.AppendLine("")
        cadena.AppendLine("")


        cadena.AppendLine("});")



        cadena.AppendLine("</script>")

        'GridView1.DataSource = mybc.GetTablaGrafica(myci.idProc, myci.procedencia.ToString, salon)
        'GridView1.DataBind()



        litScript.Text = cadena.ToString()


    End Sub


    Public numero As Integer = 0

    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        numero += 1



    End Sub

    Public Function sumarColumna(nombreColumna As String, ByRef dv As DataView) As Tuple(Of Integer, Integer, Decimal)


        Dim totalActividades As Integer = 0
        Dim totalActividadesEnviadas As Integer = 0
        Dim totalIndice As Decimal = 0

        For Each dr As DataRow In dv.Table.Rows

            totalActividades = totalActividades + CInt(dr(nombreColumna & "-Actividades"))
            totalActividadesEnviadas = totalActividadesEnviadas + CInt(dr(nombreColumna & "-ActividadesEnviadas"))
            totalIndice = totalIndice + CDec(dr(nombreColumna & "-IndiceCompletado"))
        Next


        Return New Tuple(Of Integer, Integer, Decimal)(totalActividades, totalActividadesEnviadas, totalIndice)


    End Function

    Public Function Sumar(ByRef dv As DataView) As Tuple(Of Decimal, Decimal, Decimal)

        Dim totalActividades As Integer = 0
        Dim totalActividadesEnviadas As Integer = 0
        Dim totalIndice As Decimal = 0

        Dim totalcalificacionComputada As Decimal = 0
        Dim totalPromedio As Decimal = 0

        Dim totalrows As Integer = dv.Table.Rows.Count

        For Each dr As DataRow In dv.Table.Rows

            totalActividades = totalActividades + CInt(dr("TotalActividades"))
            totalActividadesEnviadas = totalActividadesEnviadas + CInt(dr("TotalActividadesEnviadas"))


            totalPromedio = totalPromedio + dr("PromedioActividades")
            totalcalificacionComputada = totalcalificacionComputada + dr("CalificacionComputada")

        Next

        If totalActividades > 0 And totalrows > 0 Then
            Return New Tuple(Of Decimal, Decimal, Decimal)((CDec(totalActividadesEnviadas) / CDec(totalActividades)) * 100, (totalPromedio / totalrows), (totalcalificacionComputada / totalrows))
        Else
            Return New Tuple(Of Decimal, Decimal, Decimal)(0, 0, 0)
        End If

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


    Public Function getImagen(objClaveAux As Object, claveUsuario As Integer) As String

        Return "~/sec/showfile.aspx?idUserProfile=" & claveUsuario


    End Function

End Class
