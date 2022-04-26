﻿
Partial Class Sec_Workbook_Controles_DisplayForosUnidad
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myci As New Lego.ClasificacionItem
        rptObjetos.DataSource = myci.getDRForos(CInt(Request("idClasificacion")))
        rptObjetos.DataBind()


        lnkObjetoAgregar.NavigateUrl = "~/sec/workbook/Foro.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion")

    End Sub

    Public Function getUrl(claveClasificacionItem As Integer, claveClasificacion As Integer, claveidProc As Integer, claveProcedencia As String, claveRoot As Integer) As String

        Return "~/sec/workbook/Foro.aspx?idRoot=" & claveRoot & "&idClasificacion=" & claveClasificacion & "&idCI=" & claveClasificacionItem

    End Function
End Class
