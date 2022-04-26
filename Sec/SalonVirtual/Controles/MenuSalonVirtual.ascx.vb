Imports System.IO

Partial Class Sec_SalonVirtual_Controles_MenuSalonVirtual
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()



        If Request("idSalonVirtual") <> "" Then

            panelGenerales.Visible = True

			Dim mycurso As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

			Dim idClasificacion As Integer = getIdClasificacion()
			If idClasificacion = 0 Then
				Dim objClasificacion As New Lego.Clasificacion(mycurso.id, True)
				idClasificacion = objClasificacion.id
			End If

			If mycurso.nombre.Length > 40 Then
                '     lblNombresalon.Text = mycurso.nombre.Substring(0, 37) & "..."
				'     lblNombresalon.ToolTip = mycurso.nombre
			Else
				'    lblNombresalon.Text = mycurso.nombre
            End If
            '   lblnombremateria.Text = mycurso.nombre

            lnkSalon2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            ' lnkSalon3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")



            lnkVerContenido2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & idClasificacion
            '   lnkVerContenido3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

            lnkCalendario2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '   lnkCalendario3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            lnkPreguntas2.NavigateUrl = "~/sec/salonvirtual/preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual")

            ' lnkbb2.NavigateUrl = "~/sec/salonvirtual/createBBB.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&bbb=1"
            If mycurso.LigaSalonVirtual = "" Then
                lnkbb2.NavigateUrl = "~/sec/salonvirtual/SalaVirtualNA.aspx?idSalonVirtual=" & Request("idSalonVirtual")
            Else
                lnkbb2.NavigateUrl = mycurso.LigaSalonVirtual
                lnkbb2.Target = "_blank"
            End If
            '  lnkbb2.NavigateUrl = mysalonVirtual.LigaSalonVirtual

            mysalonVirtual = mycurso ' New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)


            Dim varesalumno As Boolean = EsAlumno()

            If varesalumno And (mysalonVirtual.fechaInicio > Date.Now.Date.AddDays(2)) Then
                Response.Redirect("~/sec/salonvirtual/NoLibro.aspx?display=2&idSalonVirtual=" & mysalonVirtual.id)
            End If


            Dim varesmaestro As Boolean
			If varesalumno Then
				varesmaestro = False
			Else
				varesmaestro = EsMaestro()
			End If



			panelMaestro.Visible = varesmaestro

            lnkdatosgenerales2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '   lnkdatosgenerales3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

            lnkActividadeEnviadas2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            ' lnkActividadeEnviadas3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

            lnkEsquemaEvaluacionMaestro2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '  lnkEsquemaEvaluacionMaestro3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            lnkAsistencia2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '   lnkAsistencia3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

            lnkListaAlumnos2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '   lnkListaAlumnos3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            lnkListaSeguimiento.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            lnkPermisos2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '    lnkPermisos3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            panelAlumno.Visible = varesalumno
            If panelAlumno.Visible Then
                lnkAvance.NavigateUrl = "~/sec/salonVirtual/ListaSeguimientoAlumno.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & Session("gUserProfileSession").idUserProfile
            End If


            lnkEvalAlumnos1.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '    lnkEvalAlumnos3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            lnkAsistenciaAlumno2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '  lnkAsistenciaAlumno3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

            '  lnkSincronizacion2.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
            '  lnkSincronizacion3.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")


            validarEntradaAPaginas(varesmaestro, varesalumno)

            If mycurso.idRoot = 0 Then
                panelActividadesEnviadas.Visible = False
                panelAsistencia.Visible = False
                panelPermisos.Visible = False
                panelListaAlumnos.Visible = False
                panelEsquemaEvaluacion.Visible = False
                '  panelSincronizacion.Visible = False
                panelAlumno.Visible = False

                panelGenerales.Visible = False


            End If

        Else
			'panelMiportal.Visible = True

		End If



		'lnkdatos.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
		'lnkesquema.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
		'lnkeditagenda.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
		'lnkasistencia.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
		'lnklistaalumnos.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")
		'lnkActividadesEnviadas.NavigateUrl &= "?idSalonVirtual=" & Request("idSalonVirtual")

	End Sub


    Public mysalonVirtual As Know.SalonVirtual
    Public myuser As MasUsuarios.UserProfile


    Public Function EsMaestro() As Boolean

        panelActividadesEnviadas.Visible = False
        panelAsistencia.Visible = False
        panelPermisos.Visible = False
        panelListaAlumnos.Visible = False
        panelEsquemaEvaluacion.Visible = False
        '     panelSincronizacion.Visible = False

        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta

        litActividades.Text &= " (" & myr.CountEnviadasParaMeaestro(mysalonVirtual.id) & ")"

        Dim regreso As Boolean = False
        If mypermisos.existe Then
            regreso = True



            panelActividadesEnviadas.Visible = mypermisos.PRespuestas
            panelAsistencia.Visible = mypermisos.PContenidos
            panelPermisos.Visible = mypermisos.PPermisosRoots
            panelListaAlumnos.Visible = mypermisos.PEvaluacion
            panelEsquemaEvaluacion.Visible = mypermisos.PEvaluacion
            '  panelSincronizacion.Visible = mypermisos.PEvaluacion

        Else
            If EsAdministrador() Then
                regreso = True

                panelActividadesEnviadas.Visible = True
                panelAsistencia.Visible = True
                panelPermisos.Visible = True
                panelListaAlumnos.Visible = True
                panelEsquemaEvaluacion.Visible = True

            End If
        End If


        Return regreso

    End Function

	Private Function getIdClasificacion() As Integer
		Dim idClasificacion As Integer
		Try
			idClasificacion = CInt(Request("idClasificacion"))
		Catch ex As Exception
			idClasificacion = 0
		End Try

		If idClasificacion < 0 Then idClasificacion = 0

		Return idClasificacion
	End Function


    Public Function EsAlumno() As Boolean
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myuser.id, mysalonVirtual.id, False)
        Return mysvu.existe

    End Function


    Public Function EsAdministrador() As Boolean
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mye)
        Return mypermisos.PAdministracion

    End Function


    Sub validarEntradaAPaginas(ByVal localesmaestro As Boolean, ByVal localesalumno As Boolean)
        Dim paginaActual As String = Path.GetFileName(My.Request.CurrentExecutionFilePath.ToLower())

        If localesalumno = False And localesmaestro = False Then
            Response.Redirect("~/sec/default.aspx")
        End If

        Select Case paginaActual
            '"actividadesporcalificar.aspx",
            Case "addactividadesaitemevaluacion.aspx", "addesquemadeevaluacion.aspx", "additemevaluacion.aspx", "addsalonvirtual.aspx", _
            "asistenciasalonvirtual.aspx", "asistenciasalonvirtualpase.aspx", "calificarexamen.aspx", "calificarrespuesta.aspx", "calificarsubjetivo.aspx", "calificarsubjetivogrupo.aspx", _
            "crearconvenio.aspx", "editagenda.aspx", "evaluacionporalumno.aspx", "listaalumnos.asxp", "tareasrecibidas.aspx", "permisos.aspx", "sincronizacion.aspx", "addsalonvirtual.aspx"
                If localesalumno Then
                    Response.Redirect("~/sec/default.aspx")
                End If

        End Select

    End Sub
End Class
