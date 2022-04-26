
Partial Class Sec_Workbook_Controles_DisplayProgress
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub


    Sub colocardatos()
        Dim myr As New Lego.Root(CInt(Request("idRoot")))

        Dim myci As New Lego.ClasificacionItem()
        Dim myc As New Lego.Clasificacion

        Dim contenidos As Integer = myci.countContenidos(myr.id)
        Dim actividades As Integer = myci.countActividadas(myr.id)
        Dim examenes As Integer = myci.countExamenes(myr.id)
        Dim foros As Integer = myci.countForos(myr.id)
        Dim carpetas As Integer = myc.GetDS(myr.id).Tables(0).Rows.Count

        Dim total As Integer = 0

        If carpetas >= CInt(lblCarpetas.Text) Then
            total = total + 20
        Else
            If carpetas > 0 Then
                total = total + (((carpetas * 100) / CInt(lblCarpetas.Text)) / 100) * 20
            End If
        End If

        If actividades >= CInt(lblActividades.Text) Then
            total = total + 20
        Else
            If actividades > 0 Then
                total = total + (((actividades * 100) / CInt(lblActividades.Text)) / 100) * 20
            End If
        End If

        If examenes >= CInt(lblExamenes.Text) Then
            total = total + 20
        Else
            If examenes > 0 Then
                total = total + (((examenes * 100) / CInt(lblExamenes.Text)) / 100) * 20
            End If
        End If

        If contenidos >= CInt(lblContenidos.Text) Then
            total = total + 20
        Else
            If contenidos > 0 Then
                total = total + (((contenidos * 100) / CInt(lblContenidos.Text)) / 100) * 20
            End If
        End If


        If foros >= CInt(lblForos.Text) Then
            total = total + 20
        Else
            If foros > 0 Then
                total = total + (((foros * 100) / CInt(lblForos.Text)) / 100) * 20
            End If
        End If



        litProgreso.Text = "<div class=""progress""><div style=""width: " & total & "%;"" class=""progress-bar progress-bar-warning"">" & total & "%</div></div>"

        lnkverdetalle.NavigateUrl = "~/sec/workbook/check.aspx?idRoot=" & Request("idRoot")

    End Sub
End Class
