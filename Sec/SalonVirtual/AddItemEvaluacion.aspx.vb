
Partial Class Sec_SalonVirtual_AddItemEvaluacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If

        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Sub


    Sub colocarDatos()
        If Request("msg") = 1 Then
            lblMensajeSubjetivo.Visible = True
        End If

        'Dim myes As Know.Estrategia = New Know.Estrategia
        'drpEstrategias.DataSource = myes.GetDR
        'drpEstrategias.DataValueField = "claveEstrategia"
        'drpEstrategias.DataTextField = "Nombre_Estrategia"
        'drpEstrategias.DataBind()

        'drpEstrategias.SelectedValue = "00 "

        colocarDatosItem()

        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        Try
            Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(mysv.claveAux1)
            If mycg.Estado > 2 Then
                lblMensajeSistema.Visible = True
            End If
        Catch ex As Exception

        End Try


    End Sub


    Sub colocarDatosItem()

        If Request("idItemEvaluacion") <> "" Then
            Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))
            '   drpEstrategias.SelectedValue = myItemEvaluacion.claveEstrategia
            txtid.Text = myItemEvaluacion.id
            txtTitulo.Text = myItemEvaluacion.titulo
            txtValor.Text = myItemEvaluacion.valor


            'If myItemEvaluacion.fecha = Date.MinValue Then
            '    txtFecha.Text = ""
            'Else
            '    txtFecha.Text = myItemEvaluacion.fecha.ToShortDateString
            'End If

            rdbTipo.Items(0).Selected = False
            rdbTipo.Items(1).Selected = False


            Select Case myItemEvaluacion.tipoItem
                Case 1
                    rdbTipo.Items(0).Selected = True
                    rdbTipo.Items(1).Selected = False
                Case 3
                    rdbTipo.Items(0).Selected = False
                    rdbTipo.Items(1).Selected = True
            End Select

            rdbTipo.Enabled = False
            btnCancelar.Visible = True
            btnBorrar.Visible = True

        End If
    End Sub



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Page.IsValid Then
            Dim numero As Integer
            If Request("idItemEvaluacion") <> "" Then
                numero = editar()
            Else
                numero = grabar()
            End If
        End If




    End Sub

    Function grabar() As Integer
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        myItemEvaluacion.salonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), False)
        myItemEvaluacion.claveEstrategia = ""
        myItemEvaluacion.Titulo = txtTitulo.Text
        myItemEvaluacion.tipoItem = CByte(rdbTipo.SelectedItem.Value)
        myItemEvaluacion.valor = Integer.Parse(txtValor.Text)
        myItemEvaluacion.fecha = Date.Now
        myItemEvaluacion.Add()

        If myItemEvaluacion.tipoItem = Know.TipoItemEvaluacion.Computo Then
            Response.Redirect("AddActividadesAItemEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & myItemEvaluacion.id)
        Else
            Response.Redirect("AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
        End If



    End Function
    Function editar() As Integer
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion(Integer.Parse(Request("idItemEvaluacion")))
        myItemEvaluacion.claveEstrategia = ""
        myItemEvaluacion.titulo = txtTitulo.Text
        myItemEvaluacion.valor = Integer.Parse(txtValor.Text)
        myItemEvaluacion.fecha = Date.Now
        myItemEvaluacion.Update()

        If myItemEvaluacion.tipoItem = Know.TipoItemEvaluacion.Computo Then
            Response.Redirect("AddActividadesAItemEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & myItemEvaluacion.id)
        Else
            Response.Redirect("AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
        End If

    End Function



    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Response.Redirect("AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion(Integer.Parse(Request("idItemEvaluacion")))

        If myItemEvaluacion.SePuedeBorrar Then
            myItemEvaluacion.Remove()
            Response.Redirect("AddEsquemadeEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
        Else
            lblMensajeBorrar.Visible = True
        End If

    End Sub

    'Protected Sub CustomValidator1_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
    '    If IsDate(txtFecha.Text) Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If
    'End Sub
End Class
