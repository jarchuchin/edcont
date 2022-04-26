
Partial Class Sec_SalonVirtual_Controles_displayAgenda7dias
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            pintarAgenda(Date.Today)
        End If

    End Sub
    Sub pintarAgenda(ByVal fecha As Date)
      
        Dim myAgenda As Comm.Agenda = New Comm.Agenda
        dtgAgenda.DataSource = myAgenda.GetTablaSemanaActividades(CInt(Request("idSalonVirtual")), fecha, CInt(Session("gUserProfileSession").idUserProfile))
        Dim mes As String = Format(fecha, "MMMM")

        dtgAgenda.Columns(0).HeaderText = mes.Substring(0, 1).ToUpper() & mes.Substring(1).ToLower()
        dtgAgenda.Columns(1).HeaderText = Format(fecha, "dd MMMM yyyy")
        dtgAgenda.DataBind()

        lblFechaActual.Text = fecha.ToShortDateString

    End Sub

    Protected Sub lnkAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAnterior.Click
        System.Threading.Thread.Sleep(700)
        Dim fechaActual As Date = CDate(lblFechaActual.Text)
        pintarAgenda(fechaActual.AddDays(-6))



    End Sub

    Protected Sub lnkSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSiguiente.Click
        System.Threading.Thread.Sleep(700)
        Dim fechaActual As Date = CDate(lblFechaActual.Text)
        pintarAgenda(fechaActual.AddDays(6))

    End Sub
End Class
