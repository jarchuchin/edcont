Imports System.Data
Imports System.IO


Partial Class Sec_SalonVirtual_Controles_displayEvaluacionAlumno
    Inherits System.Web.UI.UserControl

    Public idUserProfile As Integer
	Public totalActividades As Decimal = 0
    Public salon As Integer = 0
    Public totalPorItem As Decimal = 0
    Public totalItem As Decimal = 0
    Public totalGeneral As Decimal = 0
    Public sumaValorItem As Decimal = 0
	Public esmaestroVar As Boolean
	Dim mySV As Know.SalonVirtual

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mySV = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        esmaestroVar = EsMaestro()


        If Not IsPostBack Then
            iniciarControles()
        End If

    End Sub

	Sub iniciarControles()

		hdid.Value = Me.idUserProfile


		Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
		lbltot.Text = myItemEvaluacion.GetPorcentajePonderado(Integer.Parse(Request("idSalonVirtual"))) & "%"

		Dim myUser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Me.idUserProfile, False)
		lblNombre.Text = myUser.nombre & " " & myUser.apellidos
		Page.Title = lblNombre.Text

		'        lnkCalificarAlumno.Visible = esmaestroVar

		Dim myuemp As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myUser.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        '        imgAlumno.ImageUrl = getFoto(myuemp.claveAux1, myuemp.claveAux2)
        imgAlumno.ImageUrl = getFoto(myuemp.claveAux1, myuemp.claveAux2)

        Dim myuserSalon As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myUser.id, CInt(Request("idSalonVirtual")), False)
		Select Case myuserSalon.status
			Case "I"
				lblStatusI.Visible = True
			Case "C"
				lblCalificacionAlumno.Visible = True
				lblCalificacionAlumno.Text = myuserSalon.calificacionComputada
				lblStatusC.Visible = True
			Case "R"
				lblStatusR.Visible = True
			Case "S"
                lblStatusS.Visible = True
            Case "B"
                lblStatusB.visible = True
                btnAltaAlumno.Visible = True
                btnDarDeBajaAlumno.Visible = False
        End Select

		iniciarLista()

		lblTotalAlcanzado.Text = Format(totalGeneral, "0.00")
        lblTotalCalificacion.Text = Format(CDec(totalGeneral / CDec(10.0)), "0.00") '& "--" & totalGeneral

        lblPuntosSalon.Text = CInt(mySV.calificacionMaxima / CDec(10.0))
        lblPuntosObtenidos.Text = Format(((totalGeneral / CDec(100.0)) * mySV.calificacionMaxima) / CDec(10.0), "0.00") ' & "--" & totalGeneral
		If myuserSalon.calificacionDiferida Then
			lblfechaconvenio.Visible = True
			fechaConvenio.Text = myuserSalon.fechaConvenio
		Else
			lblfechaconvenio.Visible = False
		End If

		If esmaestroVar Then
			btnCrearConvenio.Visible = True
		End If



        'If Session("gUserProfileSession").emailGoogle = "jrsnchz@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "j.alvarado@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "lherreradec@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "jgarcia@um.edu.mx" Then
        '    btnDarDeBajaAlumno.Visible = True

        'End If


        btnDarDeBajaAlumno.Visible = Session("esAdministrador")


    End Sub

    Sub iniciarLista()
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        DataList1.DataSource = myItemEvaluacion.GetDS(Integer.Parse(Request("idSalonVirtual")))
        Datalist1.DataBind()

    End Sub

	Protected Function GetActivas(ByVal claveItem As Integer, ByVal claveSalon As Integer, ByVal claveTipo As Integer, ByVal valorItem As Integer) As DataView
		Dim myASV As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
		Return myASV.GetActividadesRespuestas(claveItem, claveSalon, Me.idUserProfile, claveTipo, valorItem)
	End Function

    Protected Function GetTotalActividades(ByVal clave As Integer) As Integer
        Dim myItem As Know.ItemEvaluacion = New Know.ItemEvaluacion(clave)
        Select Case myItem.Tipo
            Case 3
                Return 100
            Case 1
                Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
                Return myasv.GetSuma(clave)
        End Select

    End Function

    Protected Function GetLigaRespuesta(ByVal claveRespuesta As Integer, ByVal claveActividad As Integer, ByVal valorgeneral As Decimal, ByVal valorActividad As Decimal, ByVal valortipo As String, ByVal valor As Decimal) As String
        'seccion para colocar valor general
        totalItem = totalItem + valorActividad
        totalPorItem = totalPorItem + valorgeneral
        sumaValorItem = sumaValorItem + valor

        'seccion para colocar la liga
        Dim cadenaRegreso As String = ""


        Select Case valortipo
            Case 3
                If esmaestroVar Then
                    cadenaRegreso = "~/sec/SalonVirtual/CalificarSubjetivo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & claveActividad & "&idUserProfile=" & Request("idUserProfile")
                Else
                    cadenaRegreso = ""
                End If
            Case 1
                Dim myact As Contenidos.Actividad = New Contenidos.Actividad(claveActividad)
                If claveRespuesta <> 0 Then
                    If esmaestroVar Then
                        If myact.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
                            cadenaRegreso = "~/sec/SalonVirtual/CalificarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & claveRespuesta
                        Else
                            cadenaRegreso = "~/sec/SalonVirtual/CalificarRespuesta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & claveRespuesta
                        End If
                    Else
                        If myact.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
                            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(mySV.idRoot, claveActividad, tipoObjeto.Actividad.ToString)
                            cadenaRegreso = "~/sec/SalonVirtual/ContestarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idA=" & claveActividad & "&idCI=" & myci.id
                        Else
                            cadenaRegreso = "~/sec/SalonVirtual/ResponderActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idA=" & claveActividad
                        End If

                    End If
                Else
                    If Not esmaestroVar Then
                        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(mySV.idRoot, claveActividad, tipoObjeto.Actividad.ToString)
                        If myact.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
                            cadenaRegreso = "~/sec/SalonVirtual/verExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                        Else
                            cadenaRegreso = "~/sec/SalonVirtual/verActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                        End If
                    End If
                End If
        End Select

        Return cadenaRegreso
    End Function

    Protected Function getImagenRepetir(ByVal repetir As Boolean) As String
        If repetir Then
            Return "~/images/cancel.gif"
        Else
            Return "~/images/transp.gif"
        End If
    End Function




    Protected Sub Datalist1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Datalist1.ItemDataBound
        totalItem = 0
        totalGeneral = totalGeneral + totalPorItem
        totalPorItem = 0
        sumaValorItem = 0
    End Sub

    Private Sub lnkCalificarAlumno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCalificarAlumno.Click
        If Page.IsValid Then
            Dim mysalonUser As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(hdid.Value), CInt(Request("idSalonVirtual")), True)

            mysalonUser.idUserProfileCalificador = CInt(Session("gUserProfileSession").idUserProfile)
            mysalonUser.fechaFin = Date.Now
            'mysalonUser.fechaConvenio = CDate(txtfachaconvenio.Text)
            'mysalonUser.calificacionDiferida = True
            mysalonUser.status = "C"
            mysalonUser.Update()
            Response.Redirect("EsquemaEvaluacion.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & hdid.Value)
        End If

    End Sub

    Public Function EsMaestro() As Boolean


        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mySV)
        Return mypermisos.existe
    End Function




    Protected Sub btnCrearConvenio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrearConvenio.Click
        Response.Redirect("CrearConvenio.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idUserProfile=" & hdid.Value)
    End Sub

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

    Protected Sub btnDarDeBajaAlumno_Click(sender As Object, e As EventArgs) Handles btnDarDeBajaAlumno.Click
        Dim mysalonUser As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(hdid.Value), CInt(Request("idSalonVirtual")), True)
        mysalonUser.status = "B"
        mysalonUser.Update()

        Response.Redirect("~/sec/SalonVirtual/ListaAlumnos.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub

    Protected Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click

        Dim myu As New MasUsuarios.UserProfile(CInt(Request("idUserProfile")), False)

        Response.Redirect("~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correos=" & myu.email)

    End Sub
    Protected Sub btnAltaAlumno_Click(sender As Object, e As EventArgs) Handles btnAltaAlumno.Click
        Dim mysalonUser As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(CInt(hdid.Value), CInt(Request("idSalonVirtual")), True)
        mysalonUser.status = "I"
        mysalonUser.Update()

        Response.Redirect("~/sec/SalonVirtual/ListaAlumnos.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
End Class
