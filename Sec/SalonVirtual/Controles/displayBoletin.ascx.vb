
Partial Class Sec_SalonVirtual_Controles_displayBoletin
    Inherits System.Web.UI.UserControl

    Public esmaestro As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControl()
        End If

    End Sub

    Sub iniciarControl()

        If Request("idSalonVirtual") <> "" Then
            Dim myBoletin As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual
            DataList1.DataSource = myBoletin.GetDR(CInt(Request("idSalonVirtual")), 5)
            DataList1.DataBind()
        End If


        lnknuevo.NavigateUrl = "~/sec/SalonVirtual/Boletin.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkvertodos.NavigateUrl = "~/sec/SalonVirtual/Boletin.aspx?idSalonVirtual=" & Request("idSalonVirtual")
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
