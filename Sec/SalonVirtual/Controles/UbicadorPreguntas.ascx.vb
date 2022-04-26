
Partial Class Sec_SalonVirtual_Controles_UbicadorPreguntas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarDatos()
        End If
    End Sub

 


    Sub iniciarDatos()
        Dim myp As Examenes.Pregunta = New Examenes.Pregunta
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))


        Dim mya As New Contenidos.Actividad(myci.idProc)
        Dim ordenPreguntas As String = ""
        Dim cantidadPreguntas As Integer = 0
        Dim myexo As New Examenes.ExOrden(mya.id, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))
        If myexo.existe Then
            ordenPreguntas = myexo.Orden
            DataList1.DataSource = getTablaPreguntas(myexo.Orden)
            DataList1.DataBind()
        Else
            ' caso default
            DataList1.DataSource = myp.GetDS(myci.idProc)
            DataList1.DataBind()

        End If





        Dim cadena As String = "?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual")
        lnkLista.NavigateUrl = "~/Sec/SalonVirtual/ContestarExamenListaPreguntas.aspx" & cadena
        lnkInicio.NavigateUrl = "~/Sec/SalonVirtual/ContestarExamen.aspx" & cadena
        lnkFin.NavigateUrl = "~/Sec/SalonVirtual/TerminarExamen.aspx" & cadena

    End Sub
    Private Function getTablaPreguntas(cadenaPreguntas As String) As System.Data.DataTable
        Dim mydt As New System.Data.DataTable
        Dim cadena() As String = cadenaPreguntas.Split(",")
        Dim dr As System.Data.DataRow
        mydt.Columns.Add("idPregunta")
        mydt.Columns.Add("tipoPregunta")
        Dim myp As Examenes.Pregunta

        For i As Integer = 0 To cadena.Length - 1
            myp = New Examenes.Pregunta(CInt(cadena(i)))

            dr = mydt.NewRow
            dr("idPregunta") = myp.id
            dr("tipoPregunta") = myp.tipoPregunta

            mydt.Rows.Add(dr)

        Next

        Return mydt


    End Function
    Private Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then
            Dim myobj As System.Web.UI.WebControls.HyperLink = New System.Web.UI.WebControls.HyperLink

            Dim myidpregunta As Label = CType(e.Item.FindControl("lblidPregunta"), Label)
            Dim myIdTipo As Label = CType(e.Item.FindControl("lblIdTipo"), Label)
            Dim tipo As Integer = CInt(myIdTipo.Text)

            Select Case tipo
                Case Examenes.ETipoPregunta.Directa
                    myobj.NavigateUrl = "~/Sec/SalonVirtual/ContestarDirecta.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myidpregunta.Text
                Case Examenes.ETipoPregunta.Desarrollo
                    myobj.NavigateUrl = "~/Sec/SalonVirtual/ContestarDirecta.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myidpregunta.Text
                Case Examenes.ETipoPregunta.FalsoVerdadero
                    myobj.NavigateUrl = "~/Sec/SalonVirtual/ContestarFalsoVerdadero.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myidpregunta.Text
                Case Examenes.ETipoPregunta.OpcionMultiple
                    myobj.NavigateUrl = "~/Sec/SalonVirtual/ContestarOpcionMultiple.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myidpregunta.Text
                Case Examenes.ETipoPregunta.RelacionColumnas
                    myobj.NavigateUrl = "~/Sec/SalonVirtual/ContestarRelacionColumnas.aspx?idCI=" & Request("idCI") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idP=" & myidpregunta.Text

            End Select

            myobj.ImageUrl = "~/images/exa0.gif"

            If Request("idP") = myidpregunta.Text.ToString Then
                myobj.ImageUrl = "~/images/exa1.gif"
            End If


            e.Item.Controls.Add(myobj)

        End If
    End Sub

End Class
