
Partial Class Sec_SalonVirtual_CompartirRoom
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mysc As New Know.SalonVirtualCompartido
        gvDisponibles.DataSource = mysc.getDRSalonesDisponibles(CInt(Session("gUserProfileSession").idUserProfile), CInt(Request("idSalonVirtual")))
        gvDisponibles.DataBind()

        gvCompartidos.DataSource = mysc.getDRSalonesComparrtidos(CInt(Request("idSalonVirtual")))
        gvCompartidos.DataBind()


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim cadena As String = ""
        Dim salon As Integer = CInt(Request("idSalonVirtual"))


        For i = 0 To gvDisponibles.Rows.Count - 1
            Dim mychk As System.Web.UI.WebControls.CheckBox = CType(gvDisponibles.Rows(i).FindControl("chkSeleccion"), CheckBox)
            Dim myclave As System.Web.UI.WebControls.Label = CType(gvDisponibles.Rows(i).FindControl("lblClave"), Label)
            If mychk.Checked Then
                Dim mysvc As New Know.SalonVirtualCompartido()
                mysvc.idSalonVirtualPrincipal = salon
                mysvc.idSalonVirtualSecundario = CInt(myclave.Text)
                mysvc.Add()


            End If
        Next

        Response.Redirect("CompartirRoom.aspx?idSalonVirtual=" & salon)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim cadena As String = ""
        Dim salon As Integer = CInt(Request("idSalonVirtual"))


        For i = 0 To gvCompartidos.Rows.Count - 1
            Dim mychk As System.Web.UI.WebControls.CheckBox = CType(gvCompartidos.Rows(i).FindControl("chkSeleccion"), CheckBox)
            Dim myclave As System.Web.UI.WebControls.Label = CType(gvCompartidos.Rows(i).FindControl("lblClave"), Label)
            If mychk.Checked Then
                Dim mysvc As New Know.SalonVirtualCompartido(CInt(myclave.Text))
                mysvc.Remove()

            End If
        Next

        Response.Redirect("CompartirRoom.aspx?idSalonVirtual=" & salon)
    End Sub
End Class
