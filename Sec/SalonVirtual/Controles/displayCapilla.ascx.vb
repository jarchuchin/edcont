
Partial Class Sec_SalonVirtual_Controles_displayCapilla
    Inherits System.Web.UI.UserControl
    Public esmaestro As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControl()
        End If

    End Sub

    Sub iniciarControl()

        If Request("idSalonVirtual") <> "" Then
            Dim myBoletin As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla
            DataList1.DataSource = myBoletin.GetDR(CInt(Request("idSalonVirtual")), 10)
            DataList1.DataBind()
        End If
        lnknuevo.NavigateUrl = "~/sec/SalonVirtual/Capilla.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkvertodos.NavigateUrl = "~/sec/SalonVirtual/Capilla.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub

    Public Function presentar(ByVal claveUsuario As Integer) As Boolean
        If esmaestro Then
            Return True
        Else
            If claveUsuario = CInt(Session("gUserProfileSession").idUserProfile) Then
                Return True
            Else
                Return False
            End If
        End If

    End Function


    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveUsuario As Integer) As String


        Return "~/sec/showfile.aspx?idUserProfile=" & claveUsuario
    End Function

End Class
