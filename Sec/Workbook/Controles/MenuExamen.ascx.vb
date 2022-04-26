
Partial Class Sec_Workbook_Controles_MenuExamen
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        If Request("idCI") <> "" Then
            Panel1.Visible = True
            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
            Dim myact As Contenidos.Actividad = New Contenidos.Actividad(myci.idProc)
            lnkExamen.Text = myact.titulo
            lnkExamen.NavigateUrl = "~/sec/Workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idCI=" & Request("idCI") & "&Proc=" & myci.procedencia.ToString & "&idClasificacion=" & Request("idClasificacion")
            lnkLista.NavigateUrl = "~/sec/Workbook/ListaDePreguntas.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI")
            If Request("idP") <> "" Then
                Dim myp As Examenes.Pregunta = New Examenes.Pregunta(CInt(Request("idP")))
                If myp.enunciado.Length > 40 Then
                    lblpreguntaactual.Text = myp.enunciado.Substring(1, 40) & "..."
                Else
                    lblpreguntaactual.Text = myp.enunciado
                End If
                label2.Visible = True
            End If
        Else
            Panel1.Visible = False
        End If
    End Sub
End Class
