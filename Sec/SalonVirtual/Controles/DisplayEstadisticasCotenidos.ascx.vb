Imports System.Data
Imports System.Globalization

Partial Class Sec_SalonVirtual_Controles_DisplayEstadisticasCotenidos
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As New Lego.ClasificacionItem(CInt(Request("idCI")))

        Dim mybc As New Know.BitacoraContenido
        Dim salon As Integer = CInt(Request("idSalonVirtual"))

        gvEstadisticas.DataSource = mybc.GetDS(myci.idProc, myci.procedencia.ToString, salon)
        gvEstadisticas.DataBind()

        Dim dv As DataView = mybc.GetTablaGrafica(myci.idProc, myci.procedencia.ToString, salon)



        Dim cadena As New StringBuilder
        cadena.AppendLine("<script>")
        cadena.AppendLine("$(document).ready(function() {")
        cadena.AppendLine("Morris.Area({")
        cadena.AppendLine("element: 'graficaContenidos-morris-area',")
        cadena.AppendLine("data: [")
        Dim entro As Boolean = False

        For Each rowview As DataRowView In dv
            Dim row As DataRow = rowview.Row
            If entro Then
                cadena.Append(", {")
                cadena.AppendLine("period: '" & CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(row("Mes"))) & "',")
                cadena.AppendLine("dl: " & row("Total"))
                cadena.AppendLine("}")
            Else
                cadena.Append("{")
                cadena.AppendLine("period: '" & CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(row("Mes"))) & "',")
                cadena.AppendLine("dl: " & row("Total"))
                cadena.AppendLine("}")
            End If
            entro = True
        Next

        cadena.AppendLine("],")
        cadena.AppendLine("gridEnabled: false,")
        cadena.AppendLine("gridLineColor: 'transparent',")
        cadena.AppendLine("xkey: 'period',")
        cadena.AppendLine("ykeys: ['dl'],")
        cadena.AppendLine("labels: ['Vistas'],")
        cadena.AppendLine("lineColors: ['#045d97'],")
        cadena.AppendLine("pointStrokeColors : ['#045d97'],")
        cadena.AppendLine("lineWidth: 0,")
        cadena.AppendLine("pointSize: 0,")

        cadena.AppendLine("resize: true,")
        cadena.AppendLine("hideHover: 'auto',")
        cadena.AppendLine("fillOpacity: 0.7,")
        cadena.AppendLine("parseTime: false")
        cadena.AppendLine("")
        cadena.AppendLine("")



        cadena.AppendLine("});")






        cadena.AppendLine("});")



        cadena.AppendLine("</script>")

        'GridView1.DataSource = mybc.GetTablaGrafica(myci.idProc, myci.procedencia.ToString, salon)
        'GridView1.DataBind()



        litScript.Text = cadena.ToString()


    End Sub
End Class
