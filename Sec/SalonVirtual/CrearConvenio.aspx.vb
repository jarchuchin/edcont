
Partial Class Sec_SalonVirtual_CrearConvenio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()

        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
        lbltitulo.Text = lbltitulo.Text & " " & myu.nombre & " " & myu.apellidos
        Dim myusersalon As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myu.id, CInt(Request("idSalonVirtual")), False)

        If myusersalon.calificacionDiferida Then
            txtFecha.Text = myusersalon.fechaConvenio.ToShortDateString
            btnBorrar.Visible = True
        End If

    End Sub




    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If Page.IsValid Then
            System.Threading.Thread.Sleep(1000)
            Dim myusersalon As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(Request("idUserProfile")), CInt(Request("idSalonVirtual")), False)
            myusersalon.fechaConvenio = CDate(txtFecha.Text)
            myusersalon.calificacionDiferida = True
            myusersalon.Update()

            Response.Redirect("EvaluacionPorAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & myusersalon.idUserProfile)

        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If IsDate(txtFecha.Text) Then

            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1000)
        Dim myusersalon As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(Request("idUserProfile")), CInt(Request("idSalonVirtual")), False)
        myusersalon.calificacionDiferida = False
        myusersalon.Update()


        Response.Redirect("EvaluacionPorAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & myusersalon.idUserProfile)

    End Sub
End Class
