Imports System.Data

Partial Class Sec_SalonVirtual_AddEsquemadeEvaluacion
    Inherits System.Web.UI.Page


    Public totalActividades As Integer = 0
    Public totalTexto As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            iniciarControles()
        End If
        totalTexto = lbltotalrelativo.Text

        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub


    
    Sub iniciarControles()


        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        lbltot.Text = myItemEvaluacion.GetPorcentajePonderado(CInt(Request("idSalonVirtual"))) & "%"


        iniciarLista()

    End Sub



    Sub iniciarLista()
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        Datalist1.DataSource = myItemEvaluacion.GetDS(Integer.Parse(Request("idSalonVirtual")))
        Datalist1.DataBind()

    End Sub



    'Private Sub DataList1_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist1.ItemCommand
    '    System.Threading.Thread.Sleep(1500)


    '    Response.Redirect("AddItemEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & Datalist1.DataKeys(e.Item.ItemIndex))

    'End Sub

    Protected Function GetActivas(ByVal clave As Integer) As DataSet
        Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
        Return myASV.GetDS(clave)
    End Function

    Protected Function GetTotalActividades(ByVal clave As Integer) As Integer
        Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
        Return myasv.GetSuma(clave)
    End Function

    Protected Function GetLigaAItems(ByVal claveSalon As String, ByVal claveItem As String, ByVal claveTipo As Integer) As String
        Dim cadenaRegreso As String = ""
        Select Case claveTipo
            Case 1
                cadenaRegreso = "AddActividadesAItemEvaluacion.aspx?idSalonVirtual=" & claveSalon & "&idItemEvaluacion=" & claveItem
            Case 3
                cadenaRegreso = "CalificarSubjetivoGrupo.aspx?idSalonVirtual=" & claveSalon & "&idItemEvaluacion=" & claveItem
        End Select
      
        Return cadenaRegreso
    End Function

   


   
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Response.Redirect("AddItemEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub
End Class
