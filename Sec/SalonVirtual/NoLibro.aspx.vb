
Partial Class Sec_SalonVirtual_NoLibro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocardatos()
        If Request("display") = "2" Then

            Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

            lblmensaje.Text = mysv.nombre & " - será abierto a partir del " & mysv.fechaInicio.ToLongDateString

        Else

        End If
    End Sub
End Class
