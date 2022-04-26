
Partial Class Sec_SalonVirtual_AddActividadesAItemEvaluacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iniciarVariables()
        If Not IsPostBack Then
            iniciarControles()
        End If
        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkEsquemaEvaluacion.NavigateUrl = "~/sec/salonvirtual/AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Sub

    Dim myItem As Know.ItemEvaluacion

    Sub iniciarVariables()
        myItem = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))

    End Sub
    Sub iniciarControles()

        lblItemEvaluacion.Text = myItem.titulo & " " & myItem.valor & " %"
        llenarDisponibles()
        llenarActividadesSV()


        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Try
            Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(mysv.claveAux1)
            If mycg.Estado > 2 Then
                lblMensajeSistema.Visible = True

            End If
        Catch ex As Exception

        End Try

      

    End Sub

    Sub llenarDisponibles()
        Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
        lblTotal.Text = myASV.GetSuma(CInt(Request("idItemEvaluacion"))) & "%"

        ibActividad.NavigateUrl = "~/sec/workbook/Actividad.aspx?idRoot=" & myItem.salonVirtual.idRoot & "&next=evaluacion" & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & Request("idItemEvaluacion")
        ibExamen.NavigateUrl = "~/sec/workbook/Examen.aspx?idRoot=" & myItem.salonVirtual.idRoot & "&next=evaluacion" & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & Request("idItemEvaluacion")

        lbxDisponibles.DataSource = myASV.GetDisponibles(myItem.salonVirtual.id, myItem.salonVirtual.idRoot)
        lbxDisponibles.DataTextField = "titulo"
        lbxDisponibles.DataValueField = "idActividad"
        lbxDisponibles.DataBind()

    End Sub

    Sub llenarActividadesSV()
        Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual

        dtgActividades.DataSource = myasv.GetDS(myItem.id)
        dtgActividades.DataBind()

    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click


        Dim i As Integer
        Dim myASV As Contenidos.ActividadSalonVirtual
        For i = 0 To lbxDisponibles.Items.Count - 1
            If lbxDisponibles.Items(i).Selected Then
                myASV = New Contenidos.ActividadSalonVirtual
                myASV.idActividad = CInt(lbxDisponibles.Items(i).Value)
                myASV.idSalonVirtual = myItem.salonVirtual.id
                myASV.idItemEvaluacion = myItem.id
                myASV.valor = 0
                myASV.Add()
            End If
        Next

        llenarDisponibles()
        llenarActividadesSV()

    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click


        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim txtConValor As System.Web.UI.WebControls.TextBox
        Dim myASV As Contenidos.ActividadSalonVirtual

        For Each myDataGridItem In dtgActividades.Items
            txtConValor = myDataGridItem.FindControl("txtValor")
            If IsNumeric(txtConValor.Text) Then
                myASV = New Contenidos.ActividadSalonVirtual(dtgActividades.DataKeys(myDataGridItem.ItemIndex))
                myASV.valor = txtConValor.Text
                myASV.Update()
            End If
        Next

        llenarDisponibles()
        llenarActividadesSV()

    End Sub

    Private Sub dtgActividades_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgActividades.ItemCommand
        Dim clave As Integer = dtgActividades.DataKeys(e.Item.ItemIndex)


        Select Case e.CommandName.ToString
            Case "Borrar"
                borrarOpcion(clave)
        End Select
    End Sub

    Function borrarOpcion(ByVal clave As Integer) As Integer


        Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual(clave)
        '   myASV.Remove()
        'If myASV.SePuedeBorrar(myASV.idActividad, "Actividad", myASV.idSalonVirtual) Then
        '    myASV.Remove()
        'Else
        '    lblMensaje.Visible = True
        'End If

        myASV.Remove()

        'lblMensaje.Text = myASV.CadenaRegreso
        'lblMensaje.Visible = True

        llenarDisponibles()
        llenarActividadesSV()

    End Function

  
    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub
End Class
