
Partial Class Sec_AddPOpcionMultiple
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
                llenarGrid()
                Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
                txtPregunta.Text = myPregunta.enunciado
                txtid.Text = myPregunta.id
                btnBorrar.Visible = True
                validaOpcion.Visible = False


                If myPregunta.fileName <> "" Then
                    imgPregunta.Visible = True
                    imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id

                    imgPreguntalink.Visible = True
                    imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id & "&display=x"

                End If

                colocarOR()


            End If


        Else
            ValidaCorrecta.Visible = False
            lblRespuesta.Visible = False
            btnGrabar.Visible = False
        End If


    End Sub

    Sub llenarGrid()
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        dtgItem.DataSource = myOR.GetDS(CInt(Request("idP")))
        dtgItem.DataBind()

        llenarRDB()
    End Sub
    Sub llenarRDB()
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
        rdbOpcionesDisponibles.DataSource = myOR.GetDR(CInt(Request("idP")))
        rdbOpcionesDisponibles.DataTextField = "enunciado"
        rdbOpcionesDisponibles.DataValueField = "idOR"
        rdbOpcionesDisponibles.DataBind()

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
        myPregunta.idOR = CInt(rdbOpcionesDisponibles.SelectedValue)
        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
        End If

        myPregunta.Update()
        Return myPregunta.id
    End Function

    Function grabar() As Integer
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myPregunta.idActividad = myci.idProc
        myPregunta.tipoPregunta = Examenes.ETipoPregunta.OpcionMultiple
        myPregunta.enunciado = txtPregunta.Text
        myPregunta.archivo = 0
        myPregunta.valor = 0
        myPregunta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myPregunta.idOR = 0
        myPregunta.Add()

        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
            myPregunta.Update()
        End If

        txtid.Text = myPregunta.id
        Return myPregunta.id
    End Function


    Function grabarOpcion(ByVal clavePregunta As Integer) As Integer
        If txtOR.Text <> "" Then
            Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
            myOR.idPregunta = clavePregunta
            myOR.enunciado = txtOR.Text
            myOR.archivo = 0
            myOR.Add()

            If FileUpload2.HasFile Then
                myOR.fileName = colocarArchivo2(myOR.id)
                myOR.Update()
            End If

            txtOR.Text = ""
            Return myOR.id

        End If

    End Function

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))

        myP.Remove()
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
        llenarGrid()
        colocarOR()
    End Sub

    Function editarOpcion(ByVal clave As Integer, ByVal texto As String) As Integer
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(clave)
        myOR.enunciado = texto


        If FileUpload2.HasFile Then
            myOR.fileName = colocarArchivo2(myOR.id)
        End If


        myOR.Update()

        Return 1

    End Function

    Function borrarOpcion(ByVal clave As Integer) As Integer
        Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta(clave)
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta(myOR.idPregunta)

        myOR.Remove()

        Return 1
    End Function

    Private Sub btnAgregarOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarOpcion.Click
        If Page.IsValid Then
            If txtid.Text <> "" Then
                grabarOpcion(editar())
                llenarGrid()
                colocarOR()

            Else
                Dim numero As Integer = grabarOpcion(grabar())
                Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))
                myPregunta.idOR = numero
                myPregunta.Update()
                Dim cadena As String = "AddPOpcionMultiple.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idP=" & txtid.Text
                Response.Redirect(cadena)
            End If
        End If


    End Sub

    Sub colocarOR()
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))
        Dim i As Integer
        For i = 0 To rdbOpcionesDisponibles.Items.Count - 1
            rdbOpcionesDisponibles.Items(i).Selected = False
            If rdbOpcionesDisponibles.Items(i).Value.ToString = myPregunta.idOR.ToString Then
                rdbOpcionesDisponibles.Items(i).Selected = True
            End If
        Next
    End Sub

    Private Sub dtgItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItem.ItemDataBound
        Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
        If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then
            Dim myControl As ImageButton = CType(e.Item.FindControl("Imagebutton2"), ImageButton)
            '            myControl.Attributes.Add("onclick", "return confirm('" & mensajeBorrar & "');")

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


    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        If FileUpload2.HasFile Then
            If System.Text.RegularExpressions.Regex.IsMatch(FileUpload2.PostedFile.ContentType, "image/\S+") Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub

    Private Function colocarArchivo2(ByVal clave As String) As String

        Dim namefile As String = clave & "." & FileUpload2.PostedFile.FileName.Substring((FileUpload2.PostedFile.FileName.LastIndexOf(".") + 1))
        FileUpload2.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & namefile)
        Return namefile

    End Function

    Private Function colocarArchivo(ByVal clave As String) As String

        Dim namefile As String = clave & "." & FileUpload1.PostedFile.FileName.Substring((FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1))
        FileUpload1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & namefile)
        Return namefile

    End Function

    Public Function getImagenOpcion(ByVal nombre As String, ByVal clave As String) As String
        Return "~/sec/showfile.aspx?idOpcionRespuesta=" & clave & "&display=x"
    End Function

    Public Function esvisbleOpcion(ByVal nombre As String) As Boolean
        If nombre <> "" Then
            Return True
        Else
            Return False
        End If

    End Function
End Class
