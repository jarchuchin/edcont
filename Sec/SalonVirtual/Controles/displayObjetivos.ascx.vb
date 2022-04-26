
Partial Class Sec_SalonVirtual_Controles_displayObjetivos
    Inherits System.Web.UI.UserControl

    Private Sub Sec_SalonVirtual_Controles_displayObjetivos_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenardatos()
        End If
    End Sub


    Sub llenarDatos()
        Dim objObjetivo As New Lego.Objetivo
        rptObjetivos.DataSource = objObjetivo.GetDR(CInt(Request("idClasificacion")))
        rptObjetivos.DataBind()

    End Sub

    Public Function esvisible(objetivo As Object) As Boolean
        If Not Convert.IsDBNull(objetivo) Then
            If CStr(objetivo) = "" Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function


    Public Function setcontenido(objetivo As Object) As String
        If Not Convert.IsDBNull(objetivo) Then
            If CStr(objetivo) = "" Then
                Return ""
            Else
                Return Replace(objetivo, vbCr, "<br/>")
            End If
        Else
            Return ""
        End If

    End Function

End Class
