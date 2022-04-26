
Partial Class Sec_SalonVirtual_CalendarioMovil
    Inherits System.Web.UI.Page

    Protected Sub btnCrearCalendario_Click(sender As Object, e As EventArgs) Handles btnCrearCalendario.Click
        Dim mysrCal As srCalendar.CalendarPortTypeClient = New srCalendar.CalendarPortTypeClient("CalendarHttpSoap11Endpoint")
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        ' mysrCal.createCalendarACL(txtemail.Text, txtpass.Text, mysv.calendarID)
        mysrCal.createCalendarACL(mysv.calendarID, txtemail.Text)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        If mysv.calendarID = "" Then
            btnCrearCalendario.Visible = False

        End If
    End Sub
End Class
