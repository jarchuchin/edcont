Imports System.Data

Partial Class Sec_Workbook_AddPRelacionColumnas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


  



    Sub colocarDatos()

        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3"
        lnkSalirEdicion2.NavigateUrl = "~/sec/workbook/examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3"

        Dim myci As New Lego.ClasificacionItem(CInt(Request("idCI")))
        Dim myA As New Contenidos.Actividad(myci.idProc)
        lblexamen.Text = myA.titulo

        If Request("idP") <> "" Then
            If IsNumeric(Request("idP")) Then
                llenarGrids()
                Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
                txtPregunta.Text = myPregunta.enunciado
                txtid.Text = myPregunta.id
                btnBorrar.Visible = True


                If myPregunta.fileName <> "" Then
                    imgPregunta.Visible = True
                    imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id

                    imgPreguntalink.Visible = True
                    imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id & "&display=x"

                End If

            End If
        Else
            '  lblRespuesta.Visible = False
            btnGrabar.Visible = False
        End If


    End Sub

    Sub llenarGrids()
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        dtgItem.DataSource = myOR.GetDS(CInt(Request("idP")))
        dtgItem.DataBind()

        Dim myOP As Examenes.OpcionPregunta = New Examenes.OpcionPregunta
        dtgItem0.DataSource = myOP.GetDS(CInt(Request("idP")))
        dtgItem0.DataBind()


        dtgSeleccion.DataSource = myOP.GetDS(CInt(Request("idP")))
        dtgSeleccion.DataBind()

    End Sub



    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtid.Text <> "" Then
            editar()
            Dim cadena As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3&grabado=1&regreso=" & Request("regreso")
            Response.Redirect(cadena)
        End If
    End Sub

    Function editar() As Integer
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))
        myPregunta.enunciado = txtPregunta.Text
        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
        End If
        myPregunta.Update()

        EditarSeleccionados()

        Return myPregunta.id
    End Function

    Function EditarSeleccionados() As Integer

        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim drpSelected As System.Web.UI.WebControls.DropDownList
        Dim myOP As Examenes.OpcionPregunta
        For Each myDataGridItem In dtgSeleccion.Items
            drpSelected = myDataGridItem.FindControl("drpChido")
            myOP = New Examenes.OpcionPregunta(dtgSeleccion.DataKeys(myDataGridItem.ItemIndex))
            myOP.idOR = Convert.ToInt32(drpSelected.SelectedValue.ToString)
            myOP.Update()
        Next
    End Function

    Function grabar() As Integer
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myPregunta.idActividad = myci.idProc
        myPregunta.tipoPregunta = Examenes.ETipoPregunta.RelacionColumnas
        myPregunta.enunciado = txtPregunta.Text
        myPregunta.archivo = 0
        myPregunta.valor = 0
        myPregunta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myPregunta.idOR = 0
        myPregunta.Add()
        txtid.Text = myPregunta.id

        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
            myPregunta.Update()
        End If

        Return myPregunta.id
    End Function

    '**********************************OPCIONES**************************************
    Function grabarOpcion(ByVal clavePregunta As Integer) As Integer
        If txtOR.Text <> "" Then
            Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
            myOR.idPregunta = clavePregunta
            myOR.enunciado = txtOR.Text
            myOR.archivo = 0
            myOR.Add()
            txtOR.Text = ""
            Return myOR.id
        End If
    End Function
    Function editarOpcion(ByVal clave As Integer, ByVal texto As String) As Integer
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(clave)
        myOR.enunciado = texto
        myOR.Update()
        Return 1
    End Function
    Function borrarOpcion(ByVal clave As Integer) As Integer
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(clave)
        myOR.Remove()

    End Function
    '**********************************PREGUNTAS**************************************
    Function grabarPregunta(ByVal clavePregunta As Integer) As Integer
        If txtOP.Text <> "" Then
            Dim myOp As Examenes.OpcionPregunta = New Examenes.OpcionPregunta
            myOp.idPregunta = clavePregunta
            myOp.enunciado = txtOP.Text
            myOp.archivo = 0
            myOp.idOR = 0
            myOp.Add()
            txtOP.Text = ""
            Return myOp.idOR
        End If
    End Function
    Function editarPregunta(ByVal clave As Integer, ByVal texto As String) As Integer
        Dim myOp As Examenes.OpcionPregunta = New Examenes.OpcionPregunta(clave)
        myOp.enunciado = texto
        myOp.Update()
        Return 1
    End Function
    Function borrarPregunta(ByVal clave As Integer) As Integer
        Dim myOp As Examenes.OpcionPregunta = New Examenes.OpcionPregunta(clave)

        myOp.Remove()


        Return 1
    End Function



    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))

        myP.Remove()
        'Dim cadena As String = "ListaDePreguntas.aspx?idRoot=" & Request("idRoot") & "&idC=" & Request("idC") & "&idCI=" & Request("idCI")

        Dim cadena As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3&grabado=1&regreso=" & Request("regreso")
        Response.Redirect(cadena)

    End Sub

    Private Sub dtgItem_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgItem.ItemCommand
        Dim clave As Integer = dtgItem.DataKeys(e.Item.ItemIndex)

        Select Case e.CommandName.ToString
            Case "Editar"
                Dim txtenun As System.Web.UI.WebControls.TextBox
                txtenun = e.Item.FindControl("txtpreg")
                editarOpcion(clave, txtenun.Text.ToString)
            Case "Borrar"
                borrarOpcion(clave)
        End Select
        llenarGrids()

    End Sub


    Private Sub dtgItem0_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgItem0.ItemCommand
        Dim clave As Integer = dtgItem0.DataKeys(e.Item.ItemIndex)

        Select Case e.CommandName.ToString
            Case "Editar"
                Dim txtenun As System.Web.UI.WebControls.TextBox
                txtenun = e.Item.FindControl("txtpreg0")
                editarPregunta(clave, txtenun.Text.ToString)
            Case "Borrar"
                borrarPregunta(clave)
        End Select
        llenarGrids()
    End Sub

    '*********************************Botones Agregar >>> ****************************************
    Private Sub btnAgregarOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarOpcion.Click
        grabarOPCIONES()
    End Sub


    Private Sub btnAgregarOpcion0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarOpcion0.Click
        grabarOPCIONES()
    End Sub

    Function grabarOPCIONES() As Integer
        Dim clavePregunta As Integer
        If txtid.Text <> "" Then
            clavePregunta = editar()
            grabarOpcion(clavePregunta)
            grabarPregunta(clavePregunta)
            llenarGrids()
        Else
            If txtOR.Text <> "" And txtOP.Text <> "" Then
                clavePregunta = grabar()
                grabarOpcion(clavePregunta)
                grabarPregunta(clavePregunta)
                'agragar


                Dim cadena As String = "AddPRelacionColumnas.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idP=" & txtid.Text
                Response.Redirect(cadena)
            Else
                lblmensajeElementos.Visible = True
            End If

            Return 1
        End If
    End Function

    Protected Function GetOpciones() As DataSet
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        Return myOR.GetDS(CInt(Request("idP")))
    End Function


    Private Sub dtgSeleccion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgSeleccion.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then

            Dim myControl As DropDownList = CType(e.Item.FindControl("drpChido"), DropDownList)
            Dim myop As Examenes.OpcionPregunta = New Examenes.OpcionPregunta(dtgSeleccion.DataKeys(e.Item.ItemIndex))
            Dim i As Integer
            For i = 0 To myControl.Items.Count - 1
                myControl.Items(i).Selected = False
                If myop.idOR.ToString = myControl.Items(i).Value.ToString Then
                    myControl.Items(i).Selected = True
                End If
            Next

        End If

    End Sub

    Private Sub dtgItem0_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem0.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then
            Dim myControl As ImageButton = CType(e.Item.FindControl("Imagebutton2"), ImageButton)
            myControl.Attributes.Add("onclick", "return confirm('" & lblParaBorrar.Text & "');")
        End If

    End Sub


    Private Sub dtgItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then
            Dim myControl As ImageButton = CType(e.Item.FindControl("Imagebutton21"), ImageButton)
            myControl.Attributes.Add("onclick", "return confirm('" & lblParaBorrar.Text & "');")

        End If
    End Sub


    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If FileUpload1.HasFile Then
            If System.Text.RegularExpressions.Regex.IsMatch(FileUpload1.PostedFile.ContentType, "image/\S+") Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub

    Private Function colocarArchivo(ByVal clave As String) As String

        Dim namefile As String = clave & "." & FileUpload1.PostedFile.FileName.Substring((FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1))
        FileUpload1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & namefile)
        Return namefile

    End Function

End Class
