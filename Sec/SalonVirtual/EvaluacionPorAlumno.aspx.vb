Imports System.Data

Partial Class Sec_SalonVirtual_EvaluacionPorAlumno
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        displayEvaluacionAlumno1.idUserProfile = CInt(Request("idUserProfile"))


        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub
End Class
