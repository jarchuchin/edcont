
Partial Class Sec_SalonVirtual_Preguntas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")


        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)


        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myuser.id, mysv.id, False)
        If Not mysvu.existe Then
            Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysv)
            esmaestro = mypermisos.existe

            If Not esmaestro Then
                Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
                mypermisos = New MasUsuarios.Permiso(myuser, mye)
                esmaestro = mypermisos.existe

                lnkMisCursos.Text = labelCursosComoAlumno.Text
                lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & mysv.id
            Else

                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & mysv.id
            End If


        End If


        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta()
        'DataList1.DataSource = mysvp.GetDR(CInt(Request("idSalonVirtual")))
        'DataList1.DataBind()

        DataList2.DataSource = mysvp.GetDR(CInt(Request("idSalonVirtual")))
        DataList2.DataBind()


    End Sub

    Protected Sub btnNueva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNueva.Click
        Response.Redirect("PreguntasNueva.aspx?idSalonVirtual=" & Request("idSalonVirtual"))

    End Sub

    Public Function esvisible(ByVal clave As Integer) As Boolean
        Dim mysvp As Know.SalonVirtualPregunta = New Know.SalonVirtualPregunta(clave)
        If mysvp.Respuesta <> "" Then
            Return True
        Else
            Return False
        End If
    End Function


    Public esmaestro As Boolean = False

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


    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveClaveAux2 As String, claveUsuario As Integer) As String

        Return "~/sec/showfile.aspx?idUserProfile=" & claveUsuario

    End Function


    Public Function esVisible(respuesta As String) As Boolean
        If respuesta <> "" Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
