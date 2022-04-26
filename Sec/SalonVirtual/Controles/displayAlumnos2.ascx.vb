
Partial Class Sec_SalonVirtual_Controles_displayAlumnos2
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos(8)
        End If
    End Sub

    Sub colocarDatos(claveCantidad As Integer)
        Dim mysv As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()

        gvAlumnos.DataSource = mysv.GetDRConFotos(CInt(Request("idSalonVirtual")), claveCantidad)
        gvAlumnos.DataBind()


    End Sub


    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveUsuario As Integer) As String


        If Not Convert.IsDBNull(claveFoto) Then
            If claveFoto = "default.jpg" Then
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            Else
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            End If
        Else
            Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
        End If
    End Function

    Protected Sub lnkVerTodos_Click(sender As Object, e As System.EventArgs) Handles lnkVerTodos.Click
        If lnkVerTodos.Text = "Ver Todos" Then
            lnkVerTodos.Text = "Ocultar"
            colocarDatos(0)
        Else
            lnkVerTodos.Text = "Ver Todos"
            colocarDatos(8)
        End If

    End Sub
End Class
