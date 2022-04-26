
Partial Class Sec_Workbook_AddPDirecta
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
                Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
                txtPregunta.Text = myPregunta.enunciado
                txtid.Text = myPregunta.id
                txtRespuesta.Text = myPregunta.respuesta
                btnBorrar.Visible = True
                If myPregunta.fileName <> "" Then
                    imgPregunta.Visible = True
                    imgPregunta.ImageUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id

                    imgPreguntalink.Visible = True
                    imgPreguntalink.NavigateUrl = "~/sec/showfile.aspx?idPregunta=" & myPregunta.id & "&display=x"
                End If
            End If
        End If
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtid.Text <> "" Then
            editar()
        Else
            grabar()
        End If
    End Sub

    Sub editar()
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))
        myPregunta.enunciado = txtPregunta.Text
        myPregunta.respuesta = txtRespuesta.Text

        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
        End If

        myPregunta.Update()

        Dim cadena As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3&grabado=1&regreso=" & Request("regreso")
        Response.Redirect(cadena)
    End Sub

    Sub grabar()
        Dim myPregunta As Examenes.Pregunta = New Examenes.Pregunta
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myPregunta.idActividad = myci.idProc
        myPregunta.tipoPregunta = Examenes.ETipoPregunta.Directa
        myPregunta.enunciado = txtPregunta.Text
        myPregunta.respuesta = txtRespuesta.Text
        myPregunta.archivo = 0
        myPregunta.valor = 0
        myPregunta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myPregunta.idOR = 0
        myPregunta.Add()

        If FileUpload1.HasFile Then
            myPregunta.fileName = colocarArchivo(myPregunta.id)
            myPregunta.Update()
        End If

        Dim cadena As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3&grabado=1&regreso=" & Request("regreso")
        Response.Redirect(cadena)
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta(CInt(txtid.Text))
        myP.Remove()
        Dim cadena As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&tab=3&grabado=1&regreso=" & Request("regreso")
        Response.Redirect(cadena)

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
