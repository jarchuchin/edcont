
Partial Class Sec_ListaDePreguntas
    Inherits System.Web.UI.Page

    Public myCI As Lego.ClasificacionItem
    Public myA As Contenidos.Actividad


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iniciarLabels()
        If Not IsPostBack Then
            iniciarControles()
        End If

    End Sub

    Sub iniciarLabels()

        myCI = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myA = New Contenidos.Actividad(myCI.idProc)

    End Sub


    Sub iniciarControles()

        If myA.puntosPorRespuesta = Contenidos.EPuntosPorRespuesta.Personalizada Then
            btnGrabar.Visible = True
        End If

        Page.Title = myA.titulo


        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI")

        llenarGrid()


    End Sub

    Sub llenarGrid()
        Dim myP As Examenes.Pregunta = New Examenes.Pregunta
        dtgItem.DataSource = myP.GetDS(myA.id)
        dtgItem.DataBind()

        totalpreguntas.Text = Format(myP.GetSuma(myA.id), ".##")
        totalexamen.Text = myA.puntosTotales

    End Sub

    Private Sub dtgItem_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgItem.ItemCommand
        Dim clave As Integer = dtgItem.DataKeys(e.Item.ItemIndex)
        Select Case e.CommandName.ToString
            Case "subir"
                subir(clave)
            Case "bajar"
                bajar(clave)
        End Select
        llenarGrid()
    End Sub

    Function subir(ByVal clave As Integer) As Integer
        Dim myExP As Examenes.Pregunta = New Examenes.Pregunta(clave)
        myExP.MoveArriba()

        Return 1
    End Function

    Public Function bajar(ByVal clave As Integer) As Integer
        Dim myExP As Examenes.Pregunta = New Examenes.Pregunta(clave)
        myExP.MoveAbajo()
        Return 1
    End Function

    Protected Function GetLiga(ByVal clavePregunta As Integer, ByVal claveTipoPregunta As Integer) As String
        Dim cadena As String = "?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idP=" & clavePregunta

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Directa
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.Desarrollo
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.FalsoVerdadero
                cadena = "AddFalsoVerdadero.aspx" & cadena
            Case Examenes.ETipoPregunta.OpcionMultiple
                cadena = "AddPOpcionMultiple.aspx" & cadena
            Case Examenes.ETipoPregunta.RelacionColumnas
                cadena = "AddPRelacionColumnas.aspx" & cadena
        End Select

        Return cadena

    End Function

    Protected Function GetEnunciado(ByVal claveEnunciado As String, ByVal claveTipoPregunta As Integer) As String

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Desarrollo
                claveEnunciado = lblpdesarrollo.Text
        End Select

        Return claveEnunciado
    End Function




    Protected Sub ibExamenDirecta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibExamenDirecta.Click
        Response.Redirect("AddPDirecta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI"))

    End Sub




    Protected Sub ibFalsoVerdadero_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibFalsoVerdadero.Click
        Response.Redirect("AddFalsoVerdadero.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI"))

    End Sub
    Protected Sub ibOpcionMultiple_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibOpcionMultiple.Click
        Response.Redirect("AddPOpcionMultiple.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI"))

    End Sub

    Protected Sub ibRelacionColumnas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRelacionColumnas.Click
        Response.Redirect("AddPRelacionColumnas.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI"))

    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim txtConValor As System.Web.UI.WebControls.TextBox
        Dim myP As Examenes.Pregunta

        For Each myDataGridItem In dtgItem.Items
            txtConValor = myDataGridItem.FindControl("txtValor")
            If IsNumeric(txtConValor.Text) Then
                myP = New Examenes.Pregunta(dtgItem.DataKeys(myDataGridItem.ItemIndex))
                myP.valor = txtConValor.Text
                myP.Update()

            End If
        Next

        llenarGrid()
    End Sub

    Public Function getImagen(ByVal tipo As String) As String

        Select Case tipo
            Case "1"
                Return "miniiconpregDirecta.gif"
            Case "2"
                Return "miniiconpregDirecta.gif"
            Case "3"
                Return "MiniIconFoV.gif"
            Case "4"
                Return "MiniIconOpcMul.gif"
            Case "5"
                Return "miniiconRelCol.gif"
            Case Else
                Return ""
        End Select
    End Function


    Dim contador As Integer = 0

    Public Function getContador() As Integer

        contador = contador + 1

        Return contador

    End Function



End Class
