
Partial Class Sec_SalonVirtual_Controles_displayIntructores
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim mySalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso

        gvInstructores.Visible = True
        gvInstructores.DataSource = myPermisos.GetDR(True, , mySalon)
        gvInstructores.DataBind()

    End Sub

    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveUsuario As Integer) As String


        Return "~/sec/showfile.aspx?idUserProfile=" & claveUsuario
    End Function



End Class
