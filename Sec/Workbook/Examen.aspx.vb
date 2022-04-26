Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Examen
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            autorizacion()
            colocarDatos()
        Else



        End If

    End Sub

    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Private Sub colocarDatos()

        If Request("grabado") = "1" Then
            alertSuccess.Visible = True
        End If


        Dim idRoot As Integer = getIdRoot()
        Dim idClasificacion As Integer = getIdClasificacion()
        Dim idCI As Integer = getIdCI()
        Dim idActividad As Integer = getIdActividad()
        If idActividad <= 0 And getIdCI() > 0 Then
            Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
            idActividad = objClasificacionItem.idProc
        End If

        Dim objClasificacion As New Lego.Clasificacion
        drpUbicacion.DataSource = objClasificacion.ClasificacionesRoot(idRoot)
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

        If drpUbicacion.Items.Count < 0 Then
            Response.Redirect("Explorar.aspx?idRoot=" & idRoot)
        End If
        lnkSalirEdicion.NavigateUrl = "~/sec/Workbook/explorar.aspx?idRoot=" & idRoot

        drpUbicacion.SelectedValue = CInt(Request("idClasificacion"))


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo

        If idActividad > 0 Then

            Dim objActividad As New Contenidos.Actividad(idActividad)
            txtid.Text = objActividad.id
            txtTitulo.Text = objActividad.titulo
            If objActividad.puntosPorRespuesta = Contenidos.EPuntosPorRespuesta.Automatica Then
                rdbPuntosPorRespuesta.Items(0).Selected = True
                rdbPuntosPorRespuesta.Items(1).Selected = False
            Else
                rdbPuntosPorRespuesta.Items(0).Selected = False
                rdbPuntosPorRespuesta.Items(1).Selected = True
            End If


            drpUbicacion.SelectedValue = idClasificacion
            txtPuntosTotales.Text = objActividad.puntosTotales
            txttiempoenminutos.Text = objActividad.tiempoEnMinutos
            txtInstrucciones.Text = objActividad.instrucciones
            btnBorrar.Visible = True
            lnkVistaPrevia.Enabled = True
            lnkVistaPrevia.NavigateUrl = "verExamen.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & "&idCI=" & idCI & "&idSalonVirtual=" & Request("idSalonVirtual")

            chkcontestarSinAgenda.Checked = objActividad.contestarSinAgenda


            'seccion de lista de preguntas
            If objActividad.puntosPorRespuesta = Contenidos.EPuntosPorRespuesta.Personalizada Then
                btnGrabarListas.Visible = True
            End If
            llenarGrid()
            'fin seccion de lista de preguntas

            Dim myli As ListItem
            For i As Integer = 1 To dtgItem.Items.Count
                myli = New ListItem(i, i)
                drpTotalPreguntas.Items.Add(myli)
            Next

            chkAutoevaluacion.Checked = objActividad.Autoevaluacion
            chkpresentacionAleatoria.Checked = objActividad.presentacionAleatoria
            If objActividad.activarBanco Then

                If dtgItem.Items.Count > 0 Then
                    panelTotalPreguntas.Visible = True
                    chkActivarBanco.Checked = True
                    drpTotalPreguntas.SelectedValue = objActividad.totalPreguntas
                Else
                    lblPreguntasError.Visible = True
                End If


            Else
                panelTotalPreguntas.Visible = False
                chkActivarBanco.Checked = False
            End If





            If Request("idSalonVirtual") <> "" Then
                lnkSalirEdicion.NavigateUrl = "~/sec/salonvirtual/vercarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & idClasificacion & "&idCI=" & idCI
            End If


            hdc.Value = idActividad
            hdUs.Value = CInt(Session("gUserProfileSession").idUserProfile)


            If Request("tab") <> "" Then
                hidTAB.Value = Request("tab")
            Else
                hidTAB.Value = 1
            End If


            Dim cadena As New StringBuilder
            cadena.AppendLine("<script type=""text/javascript"" >")
            cadena.AppendLine("$(document).ready(function () {")
            cadena.AppendLine("$(""#fileuploader"").uploadFile({")
            cadena.AppendLine(" url: ""UploadA.ashx?idus="" + document.getElementById(""hdUs"").value + ""&idc="" + document.getElementById(""hdc"").value,")
            cadena.AppendLine("fileName: ""myfile"",")
            cadena.AppendLine("dragDrop: true,")
            cadena.AppendLine("afterUploadAll: function (obj) {")
            cadena.AppendLine("$('#btnRefrescar').click();")
            cadena.AppendLine("}")
            cadena.AppendLine("});")

            cadena.AppendLine("")
            cadena.AppendLine("")

            If Request("tab") <> "" Then
                cadena.AppendLine("$('.nav-tabs a[href=""#" & hidTAB.Value & """]').tab('show');")
                cadena.AppendLine("")
                cadena.AppendLine("")
                cadena.AppendLine("")


            End If

            cadena.AppendLine("")
            cadena.AppendLine("")


            cadena.AppendLine("});")
            cadena.AppendLine("</script>")





            litScript.Text = cadena.ToString


            rowAdjuntos.Visible = True
            lnkVistaPrevia.Visible = True
        Else
            rowAdjuntos.Visible = False
            lnkVistaPrevia.Visible = False

            ibExamenDirecta.Visible = False
            ibFalsoVerdadero.Visible = False
            ibOpcionMultiple.Visible = False
            ibRelacionColumnas.Visible = False

        End If


        hiddenIdActividad.Value = idActividad
    End Sub


    Sub llenarGrid()

        Dim myCI As New Lego.ClasificacionItem(CInt(Request("idCI")))
        Dim myA As New Contenidos.Actividad(myCI.idProc)

        Dim myP As Examenes.Pregunta = New Examenes.Pregunta
        dtgItem.DataSource = myP.GetDS(myA.id)
        dtgItem.DataBind()

        totalpreguntas.Text = Format(myP.GetSuma(myA.id), ".##")
        totalexamen.Text = myA.puntosTotales

    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
		Dim idClasificacion As Integer = getIdClasificacion()
		Dim idCI As Integer = getIdCI()

		If idCI > 0 Then
			Dim objClasificacionItem As New Lego.ClasificacionItem(idCI)
			objClasificacionItem.Remove()
			idClasificacion = objClasificacionItem.idClasificacion
		Else
			Dim idActividad As Integer = getIdActividad()
			If idActividad > 0 Then
				Dim objClasificacion As New Lego.Clasificacion(idClasificacion)
				objClasificacion.idActividad = 0
				objClasificacion.Update()
			End If
		End If

        Response.Redirect("Examen.aspx?idRoot=" & getIdRoot() & "&idClasificacion=" & idClasificacion & "&idSalonVirtual=" & Request("idSalonVirtual"))
	End Sub



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
		If Page.IsValid Then
			If tieneEspacio() Then
				If txtid.Text <> "" Then
					editar()
					If Request("idSalonVirtual") <> "" Then
						If getIdActividad() > 0 Then
                            Response.Redirect("../SalonVirtual/verExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI") & "&idA=" & getIdActividad() & "&idClasificacion=" & getIdClasificacion())
                        Else
                            Response.Redirect("../SalonVirtual/verExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & getIdCI() & "&idClasificacion=" & getIdClasificacion())
						End If
					Else
                        Response.Redirect("Examen.aspx?idRoot=" & getIdRoot() & "&idClasificacion=" & getIdClasificacion() & "&idCI=" & getIdCI() & "&idA=" & getIdActividad() & "&grabado=1&regreso=" & Request("regreso"))
                    End If

				Else
					grabar()
				End If
			Else
				lblMensajeEspacio.Visible = True
			End If

		End If
	End Sub

	Function tieneEspacio() As Boolean
		Dim tiene As Boolean = True
		'Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), True)

		'Dim espacioDeEstosArchivos As Integer = 0

		'If File1.PostedFile.FileName <> "" Then
		'    espacioDeEstosArchivos = File1.PostedFile.ContentLength
		'End If
		'If File2.PostedFile.FileName <> "" Then
		'    espacioDeEstosArchivos = espacioDeEstosArchivos + File2.PostedFile.ContentLength
		'End If

		'If espacioDeEstosArchivos > 0 Then
		'    espacioDeEstosArchivos = espacioDeEstosArchivos + myUser.espacioEnDiscoUsado
		'    If espacioDeEstosArchivos > myUser.espacioEnDisco Then
		'        tiene = False
		'    End If
		'End If

		Return tiene
	End Function

	Sub editar()
		Dim myActividades As Contenidos.Actividad = New Contenidos.Actividad(CInt(txtid.Text))
		myActividades.titulo = txtTitulo.Text.ToString
		myActividades.instrucciones = txtInstrucciones.Text
		myActividades.respuesta = 1
		myActividades.respuestaGrupal = 0
		myActividades.comoSeCalifica = 1
		myActividades.quienCalifica = 1
		myActividades.mostrarRespuestas = False
		myActividades.mostrarObservaciones = True
		myActividades.mostrarCalificacion = True
		myActividades.puntosPorRespuesta = CInt(rdbPuntosPorRespuesta.SelectedValue)
		myActividades.puntosTotales = CInt(txtPuntosTotales.Text)
		myActividades.tiempoEnMinutos = CInt(txttiempoenminutos.Text)
        myActividades.Autoevaluacion = chkAutoevaluacion.Checked
        myActividades.contestarSinAgenda = chkcontestarSinAgenda.Checked

        myActividades.presentacionAleatoria = chkpresentacionAleatoria.Checked
        If chkActivarBanco.Checked Then
            myActividades.activarBanco = chkActivarBanco.Checked
            myActividades.totalPreguntas = drpTotalPreguntas.SelectedValue
        Else
            myActividades.activarBanco = False
            myActividades.totalPreguntas = 0
        End If

        myActividades.Update()

		Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
		myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
		myCI.Update()


		subirArchivosyLigas(myActividades)


	End Sub

	Sub grabar()
		Dim myActividades As Contenidos.Actividad = New Contenidos.Actividad
		myActividades.tipodeActividad = Contenidos.ETipodeActividad.Examen
		myActividades.titulo = txtTitulo.Text.ToString
		myActividades.instrucciones = txtInstrucciones.Text
		myActividades.respuesta = 1
		myActividades.respuestaGrupal = 0
		myActividades.comoSeCalifica = 1
		myActividades.quienCalifica = 1
		myActividades.mostrarRespuestas = False
		myActividades.mostrarObservaciones = True
		myActividades.mostrarCalificacion = True
		myActividades.puntosPorRespuesta = CInt(rdbPuntosPorRespuesta.SelectedValue)
		myActividades.puntosTotales = CInt(txtPuntosTotales.Text)
		myActividades.tiempoEnMinutos = CInt(txttiempoenminutos.Text)
		myActividades.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
		myActividades.fechaCreacion = Date.Now
		myActividades.Tags = ""
        myActividades.Autoevaluacion = chkAutoevaluacion.Checked
        myActividades.contestarSinAgenda = chkcontestarSinAgenda.Checked
        myActividades.presentacionAleatoria = chkpresentacionAleatoria.Checked
        If chkActivarBanco.Checked Then
            myActividades.activarBanco = chkActivarBanco.Checked
            myActividades.totalPreguntas = drpTotalPreguntas.SelectedValue
        Else
            myActividades.activarBanco = False
            myActividades.totalPreguntas = 0
        End If
        myActividades.Add()


		Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
		myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
		myCI.idRoot = CInt(Request("idRoot"))
		myCI.idProc = myActividades.id
		myCI.procedencia = myActividades.tipo
		myCI.Add()


		subirArchivosyLigas(myActividades)
		If Request("next") = "evaluacion" Then
            Response.Redirect("../SalonVirtual/AddActividadesAItemEvaluacion.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & Request("idItemEvaluacion"))
		Else
            Response.Redirect("Examen.aspx?idRoot=" & getIdRoot() & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id & "&idA=" & getIdActividad() & "&grabado=1&regreso=" & Request("regreso"))
        End If


	End Sub

	Function subirArchivosyLigas(ByVal myActividades As Contenidos.Actividad) As Integer
		'seccion para subir archivos 
		Dim myCA As Contenidos.ContenidoAdjunto
		Dim myCont As Contenidos.Contenido


        If txtLigatitulo.Text <> "" And txtLigaurl.Text <> "" Then
			myCont = New Contenidos.Contenido
			myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
			myCont.idTipoContenido = Contenidos.TipoContenido.Liga
			myCont.titulo = txtLigatitulo.Text
			myCont.textoCorto = ""
			myCont.textoLargo = ""
			myCont.espacio = 0
			myCont.nombreOriginal = ""
			myCont.tipoArchivo = ""
			myCont.extension = ""
			myCont.url = txtLigaurl.Text
			myCont.fechaCreacion = Date.Now
			myCont.Add()

			myCA = New Contenidos.ContenidoAdjunto
			myCA.idProc = myActividades.id
			myCA.Procedencia = myActividades.tipo.ToString
			myCA.idContenido = myCont.id
			myCA.Add()

		End If

		Return 1

	End Function


	Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
		If IsNumeric(txtPuntosTotales.Text) Then
			args.IsValid = True
		Else
			args.IsValid = False
		End If
	End Sub

	Private Sub CustomValidator2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
		If IsNumeric(txttiempoenminutos.Text) Then
			args.IsValid = True
		Else
			args.IsValid = False
		End If
	End Sub

	Private Function getIdCI() As Integer
		Dim idCI As Integer
		Try
			idCI = CInt(Request("idCI"))
		Catch ex As Exception
			idCI = 0
		End Try

		If idCI < 0 Then idCI = 0

		Return idCI
	End Function

	Private Function getIdRoot() As Integer
		Dim idRoot As Integer
		Try
			idRoot = CInt(Request("idRoot"))
		Catch ex As Exception
			idRoot = 0
		End Try

		If idRoot < 0 Then idRoot = 0

		Return idRoot
	End Function

	Private Function getIdClasificacion() As Integer
		Dim idClasificacion As Integer
        Try

            Dim myci As New Lego.ClasificacionItem(CInt(Request("idCI")))
            idClasificacion = myci.idClasificacion




        Catch ex As Exception
            idClasificacion = 0
        End Try

		If idClasificacion < 0 Then idClasificacion = 0

		Return idClasificacion
	End Function

    Private Function getIdActividad() As Integer
        Dim idActividad As Integer
        Try
            idActividad = CInt(Request("idA"))
        Catch ex As Exception
            idActividad = 0
        End Try

        If idActividad < 0 Then idActividad = 0

        Return idActividad
    End Function


    Protected Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        editar()


        Response.Redirect("~/sec/workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Actividad&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1")

    End Sub


    Protected Sub btnGrabarLiga_Click(sender As Object, e As EventArgs) Handles btnGrabarLiga.Click
        editar()
        Response.Redirect("~/sec/workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Actividad&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1")
    End Sub


    'seccion de lista de preguntas

    Private Sub dtgItem_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgItem.ItemCommand
        Dim clave As Integer = dtgItem.DataKeys(e.Item.ItemIndex)
        Select Case e.CommandName.ToString
            Case "subir"
                subir(clave)
            Case "bajar"
                bajar(clave)
        End Select
        llenarGrid()
    End Sub

    Function subir(ByVal clave As Integer) As Integer
        Dim myExP As Examenes.Pregunta = New Examenes.Pregunta(clave)
        myExP.MoveArriba()

        Return 1
    End Function

    Public Function bajar(ByVal clave As Integer) As Integer
        Dim myExP As Examenes.Pregunta = New Examenes.Pregunta(clave)
        myExP.MoveAbajo()
        Return 1
    End Function

    Protected Function GetLiga(ByVal clavePregunta As Integer, ByVal claveTipoPregunta As Integer) As String
        Dim cadena As String = "?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idP=" & clavePregunta

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Directa
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.Desarrollo
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.FalsoVerdadero
                cadena = "AddFalsoVerdadero.aspx" & cadena
            Case Examenes.ETipoPregunta.OpcionMultiple
                cadena = "AddPOpcionMultiple.aspx" & cadena
            Case Examenes.ETipoPregunta.RelacionColumnas
                cadena = "AddPRelacionColumnas.aspx" & cadena
        End Select

        Return cadena

    End Function

    Protected Function GetEnunciado(ByVal claveEnunciado As String, ByVal claveTipoPregunta As Integer) As String

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Desarrollo
                claveEnunciado = lblpdesarrollo.Text
        End Select

        Return claveEnunciado
    End Function




    Protected Sub ibExamenDirecta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibExamenDirecta.Click
        Response.Redirect("AddPDirecta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&regreso=" & Request("regreso"))

    End Sub




    Protected Sub ibFalsoVerdadero_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibFalsoVerdadero.Click
        Response.Redirect("AddFalsoVerdadero.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&regreso=" & Request("regreso"))

    End Sub
    Protected Sub ibOpcionMultiple_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibOpcionMultiple.Click
        Response.Redirect("AddPOpcionMultiple.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&regreso=" & Request("regreso"))

    End Sub

    Protected Sub ibRelacionColumnas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRelacionColumnas.Click
        Response.Redirect("AddPRelacionColumnas.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&regreso=" & Request("regreso"))

    End Sub


    Protected Sub btnGrabarListas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabarListas.Click
        Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
        Dim txtConValor As System.Web.UI.WebControls.TextBox
        Dim myP As Examenes.Pregunta

        For Each myDataGridItem In dtgItem.Items
            txtConValor = myDataGridItem.FindControl("txtValor")
            If IsNumeric(txtConValor.Text) Then
                myP = New Examenes.Pregunta(dtgItem.DataKeys(myDataGridItem.ItemIndex))
                myP.valor = txtConValor.Text
                myP.Update()

            End If
        Next

        editar()
        Response.Redirect("~/sec/workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Actividad&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1&tab=3")
    End Sub

    Public Function getImagen(ByVal tipo As String) As String

        Select Case tipo
            Case "1"
                Return "miniiconpregDirecta.gif"
            Case "2"
                Return "miniiconpregDirecta.gif"
            Case "3"
                Return "MiniIconFoV.gif"
            Case "4"
                Return "MiniIconOpcMul.gif"
            Case "5"
                Return "miniiconRelCol.gif"
            Case Else
                Return ""
        End Select
    End Function


    Dim contador As Integer = 0

    Public Function getContador() As Integer

        contador = contador + 1

        Return contador

    End Function

    Private Sub chkActivarBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivarBanco.CheckedChanged
        If chkActivarBanco.Checked Then
            panelTotalPreguntas.Visible = True
        Else
            panelTotalPreguntas.Visible = False
            '     drpTotalPreguntas.SelectedValue = "0"
        End If


        hidTAB.Value = 2


    End Sub
End Class
