Imports System.IO

Partial Class Sec_SalonVirtual_verRespuestaCompa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)

        If mya.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Response.Redirect("CalificarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & myr.id & "&pag=" & Request("pag"))
        End If

        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

        Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myu.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        imgAlumno.ImageUrl = getFoto(myeu.claveAux1, myeu.claveAux2)

        estudiante.Text = myu.nombre & " " & myu.apellidos
        fechaenvio.Text = myr.fechaEnvio.ToLongDateString & " " & myr.fechaEnvio.ToLongTimeString
        actividad.Text = mya.titulo
        lbltextoinstrucciones.Text = mya.instrucciones
        txtcalificacion.Text = myr.calificacion
        txtcalificacion.Visible = mya.mostrarCalificacion
        txtMensaje.Text = myr.observaciones
        txtMensaje.Visible = mya.mostrarObservaciones

        littexto.Text = myr.texto




        'Colocar adjuntos
        displayRespuestaArchivos1.idRespuesta = myr.id




        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))



        ' ColocarBread
        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)




        Dim objClasificacion As New Lego.Clasificacion(myci.idClasificacion)


        If EsMaestro() Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

        lnkUnidad.Text = objClasificacion.titulo
        lnkUnidad.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id


        lnkActividad.Text = mya.titulo
        lblActividad.Text = mya.titulo

        lnkActividad.NavigateUrl = "~/sec/salonvirtual/VerActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idRoot=" & myci.idRoot & "&idClasificacion=" & objClasificacion.id & "&idCI=" & myci.id




    End Sub




    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function


    Function getFoto(ByVal claveAlumno As String, ByVal claveMaestro As String) As String


        If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveAlumno & ".jpg") Then
            Return "~/sec/Usuarios/Fotos/" & claveAlumno & ".jpg"
        Else
            If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveMaestro & ".jpg") Then
                Return "~/sec/Usuarios/Fotos/" & claveMaestro & ".jpg"
            Else
                Return "~/images/pagina/IconAlumno.jpg"
            End If

        End If

    End Function

End Class
