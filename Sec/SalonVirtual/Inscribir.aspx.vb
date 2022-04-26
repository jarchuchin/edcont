
Partial Class Sec_SalonVirtual_Inscribir
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos
        End If
    End Sub


    Sub colocardatos()
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Page.Title = mysv.nombre
        lblCursoBread.Text = mysv.nombre

        '    lblNombredelcurso.Text = mysv.nombre
        '  lblNombreTitulo.Text = mysv.nombre


        Dim myup As New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)
        Dim myeup As New MasUsuarios.EmpresaUserProfile(myup.id, 4)

        lblNombre.Text = myup.nombre & " " & myup.apellidos
        lblmatricula.Text = myeup.claveAux1

        Dim mysvup As New Know.SalonVirtualUserProfile(myup.id, mysv.id, False)
        If mysvup.existe Then
            If mysvup.status = "B" Then
                divMensajeBaja.Visible = True
                btnInscribir.Visible = True
                btnInscribir.Text = "Reinscribir Alumno"
            End If
            If mysvup.status = "I" Then
                divMensaje.Visible = True
                btnInscribir.Visible = False
            End If


        End If


    End Sub

    Protected Sub btnInscribir_Click(sender As Object, e As EventArgs) Handles btnInscribir.Click
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myup As New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)


        Dim mysvup As New Know.SalonVirtualUserProfile(myup.id, mysv.id, True)
        If Not mysvup.existe Then
            mysvup.idSalonVirtual = mysv.id
            mysvup.idUserProfile = myup.id
            mysvup.idUserProfileCalificador = 0
            mysvup.status = "I"
            mysvup.fechaInicio = mysv.fechaInicio
            mysvup.fechaFin = mysv.fechaFin
            mysvup.calificacion = 0
            mysvup.calificacionComputada = 0
            mysvup.puntosExtras = 0
            mysvup.calificacionDiferida = False
            mysvup.fechaConvenio = Date.Now
            mysvup.Add()

            Response.Redirect("ListaAlumnos.aspx?idSalonVirtual=" & mysvup.idSalonVirtual)

        Else
            If mysvup.status = "B" Or mysvup.status = "S" Then
                mysvup.status = "I"
                mysvup.fechaInicio = mysv.fechaInicio
                mysvup.fechaFin = mysv.fechaFin
                mysvup.calificacion = 0
                mysvup.calificacionComputada = 0
                mysvup.puntosExtras = 0
                mysvup.calificacionDiferida = False
                mysvup.fechaConvenio = Date.Now
                mysvup.Update()

                Response.Redirect("ListaAlumnos.aspx?idSalonVirtual=" & mysvup.idSalonVirtual)

            Else
                divMensaje.Visible = True
            End If




        End If



    End Sub
End Class
