
Partial Class Sec_Controles_DisplayAgenda
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            pintarAgenda(Date.Today)
        End If

    End Sub
    Sub pintarAgenda(ByVal fecha As Date)

        Dim myAgenda As Comm.Agenda = New Comm.Agenda
        dtgAgenda.DataSource = myAgenda.getDSTotal(Date.Now, CInt(Session("gUserProfileSession").idUserProfile))
        'dtgAgenda.DataSource = myAgenda.GetTablaSemanaActividades(CInt(Request("idSalonVirtual")), fecha)
        Dim mes As String = Format(fecha, "MMMM")

        dtgAgenda.Columns(0).HeaderText = mes.Substring(0, 1).ToUpper() & mes.Substring(1).ToLower()
        dtgAgenda.Columns(1).HeaderText = Format(fecha, "dd MMMM yyyy")
        dtgAgenda.DataBind()

        lblFechaActual.Text = fecha.ToShortDateString

    End Sub

 

    Protected Sub dtgAgenda_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dtgAgenda.PageIndexChanging
        System.Threading.Thread.Sleep(700)
        dtgAgenda.PageIndex = e.NewPageIndex
        pintarAgenda(Date.Now)


    End Sub

    
End Class
