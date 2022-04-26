
Partial Class Sec_Administracion_Controles_MenuAdministracion
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub


    Sub colocarDatos()
        If Session("gUserProfileSession").emailGoogle = "jrsnchz@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "j.alvarado@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "catytrisca@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "lneria@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "Skolar@um.edu.mx" Then
            panelsalones.Visible = True
            panellibros.Visible = True
        End If

        'Session("gUserProfileSession").emailGoogle = "marosca22@hotmail.com" Or




    End Sub
End Class
