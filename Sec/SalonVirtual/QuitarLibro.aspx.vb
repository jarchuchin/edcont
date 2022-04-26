
Partial Class Sec_SalonVirtual_QuitarLibro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub
    Sub colocarDatos()

        Dim maestro As Boolean = esmaestro()

        If Request("idSalonVirtual") <> "" Then
            If esmaestro() Then


                Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

                lblSalon.Text = mysalonVirtual.nombre
                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")

                lnkCurso.Text = mysalonVirtual.nombre
                lnkCurso.NavigateUrl = "default.aspx?idSalonVirtual=" & Request("idSalonVirtual")




                btnBorrar.Visible = True
            Else
                Response.Redirect("default.aspx")
            End If
        End If




    End Sub





    Function esmaestro() As Boolean
        Dim mysalonVirtual As Know.SalonVirtual
        Dim myuser As MasUsuarios.UserProfile
        mysalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)

        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        If mypermisos.existe Then
            Return True
        Else

            If Session("esAdministrador") Or Session("esGerenciaSalones") Then
                Return True
            End If

            Return False

        End If
    End Function




    Protected Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        Dim myie As New Know.ItemEvaluacion()
        Dim drIE As System.Data.SqlClient.SqlDataReader = myie.GetDR(mysalonVirtual.id)
        Dim myieLoop As Know.ItemEvaluacion
        Dim myasv As New Contenidos.ActividadSalonVirtual
        Dim myasvLoop As Contenidos.ActividadSalonVirtual

        Do While drIE.Read
            myieLoop = New Know.ItemEvaluacion(CInt(drIE("idItemEvaluacion")), False)
            Dim drasv As System.Data.SqlClient.SqlDataReader = myasv.GetDR(myie.id)
            Do While drasv.Read
                myasvLoop = New Contenidos.ActividadSalonVirtual(CInt(drasv("idActividadSalonVirtual")))
                myasvLoop.Remove()

            Loop
            drasv.Close()

            myie.Remove()
        Loop
        drIE.Close()

        Dim myagenda As New Comm.Agenda
        Dim drAgenda As System.Data.SqlClient.SqlDataReader = myagenda.GetDR(mysalonVirtual.id, "asc")
        Dim myagendaLoop As Comm.Agenda

        Do While drAgenda.Read
            myagendaLoop = New Comm.Agenda(CInt(drAgenda("idAgenda")))
            myagendaLoop.Remove()

        Loop
        drAgenda.Close()




        mysalonVirtual.idRoot = 0
        mysalonVirtual.Update()

        Response.Redirect("AddSalonVirtual.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
End Class
