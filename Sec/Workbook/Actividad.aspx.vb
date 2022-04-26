Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Actividad
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Public TotalRubricaA As Decimal = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        If Not IsPostBack Then
            autorizacion()
            colocarDatos(myCI)
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






    Sub colocarDatos(ByRef myCI As Lego.ClasificacionItem)


        If Request("grabado") = "1" Then
            alertSuccess.Visible = True
        End If

        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        drpUbicacion.DataSource = myc.ClasificacionesRoot(CInt(Request("idRoot")))
        drpUbicacion.DataTextField = "titulo"
        drpUbicacion.DataValueField = "idClasificacion"
        drpUbicacion.DataBind()

        If drpUbicacion.Items.Count < 0 Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If


        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot")
        If Request("regreso") = "carpeta" Then
            lnkSalirEdicion.NavigateUrl = "~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&regreso=" & Request("regreso")
        End If


        drpUbicacion.SelectedValue = Request("idClasificacion")


        Dim myr As New Lego.Root(CInt(Request("idRoot")))
        lblLibro.Text = myr.titulo



        If Request("idCI") <> "" Then


            drpUbicacion.SelectedValue = myCI.idClasificacion

            Dim myAct As Contenidos.Actividad = New Contenidos.Actividad(myCI.idProc)
            txtid.Text = myAct.id
            txtTitulo.Text = myAct.titulo
            txttags.Text = myAct.Tags
            Page.Title = myAct.titulo

            txtObjetivoCompetencia.Text = myAct.Objetivo
            txtTipoX.Text = myAct.TipoX

            rdbComoSeCalifica.Items(0).Selected = False
            rdbComoSeCalifica.Items(1).Selected = False
            rdbComoSeCalifica.Items(2).Selected = False
            rdbComoSeCalifica.Items(3).Selected = False



            Select Case myAct.comoSeCalifica
                Case Contenidos.EComoSeCalifica.ValorNumerico
                    rdbComoSeCalifica.Items(0).Selected = True
                Case Contenidos.EComoSeCalifica.Ranking
                    rdbComoSeCalifica.Items(1).Selected = True
                Case Contenidos.EComoSeCalifica.Rubrica
                    rdbComoSeCalifica.Items(3).Selected = True
                    llenarRubricaTable(myAct.id)
                    panelRubricaB.Visible = True
                Case Contenidos.EComoSeCalifica.RubricaA
                    rdbComoSeCalifica.Items(2).Selected = True
                    llenarRubricaTableA(myAct.id)
                    panelRubricaA.Visible = True
            End Select


            If myAct.respuestaGrupal > 1 Then
                chkActivarRespuestaGrupal.Checked = True
                drpRespuestaGrupal.Visible = True
                drpRespuestaGrupal.SelectedValue = myAct.respuestaGrupal
            End If


            If myAct.quienCalifica = Contenidos.EQuienCalifica.Maestro Then
                rdbQuiencalifica.Items(0).Selected = True
                rdbQuiencalifica.Items(1).Selected = False
            Else
                rdbQuiencalifica.Items(0).Selected = False
                rdbQuiencalifica.Items(1).Selected = True
            End If

            chkmostrarRespuestas.Checked = myAct.mostrarRespuestas
            chkMostrarCalificacion.Checked = myAct.mostrarCalificacion
            chkMostrarObservaciones.Checked = myAct.mostrarObservaciones


            txtInstrucciones.Text = myAct.instrucciones
            txtparaInstructor.Text = myAct.ParaInstructor

            btnBorrar.Visible = True
			lnkVistaPrevia.Enabled = True
			lnkVistaPrevia.NavigateUrl = "verActividad.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id & "&idSalonVirtual=" & Request("idSalonVirtual")

         
            llenarRubricaTable(myAct.id)

            lnkVerRubrica.Visible = True


            If Request("idSalonVirtual") <> "" Then
                lnkSalirEdicion.NavigateUrl = "~/sec/salonvirtual/vercarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id
            End If

            lnkVistaPrevia.Enabled = True
            lnkVistaPrevia.NavigateUrl = "~/Sec/Workbook/verActividad.aspx?idRoot=" & myCI.idRoot & "&idClasificacion=" & myCI.idClasificacion & "&idCI=" & myCI.id & "&idSalonVirtual=" & Request("idSalonVirtual")


            hdc.Value = myAct.id
            hdUs.Value = CInt(Session("gUserProfileSession").idUserProfile)



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
            cadena.AppendLine("});")
            cadena.AppendLine("</script>")

            litScript.Text = cadena.ToString


            rowAdjuntos.Visible = True
            lnkVistaPrevia.Visible = True
        Else
            rowAdjuntos.Visible = False
            lnkVistaPrevia.Visible = False
            lnkVerRubrica.Visible = False
        End If


    End Sub



    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))


        'Dim myact As New Contenidos.Actividad(myCI.idProc)
        'Dim myr As New Contenidos.Respuesta
        'If myr.HayRespuestas(myact.id, "Actividad") Then
        '    lblMensajeBorrar.Visible = True
        'Else
        myCI.Remove()

        If Request("regreso") = "ex" Then
            Response.Redirect("Explorar.aspx?idRoot=" & Request("idRoot"))
        End If

        If Request("regreso") = "carpeta" Then
            Response.Redirect("Carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & myCI.idClasificacion)
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        Dim myci As Lego.ClasificacionItem
        If Page.IsValid Then
            If tieneEspacio() Then
                If txtid.Text <> "" Then
                    myci = editar()
                    Dim cadenaredirec As String = "Actividad.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Actividad&idClasificacion=" & myci.idClasificacion & "&grabado=1&regreso=" & Request("regreso")
                    If Request("idSalonVirtual") <> "" Then
                        Response.Redirect("../SalonVirtual/verActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id)
                    Else
                        Response.Redirect(cadenaredirec)
                    End If

                Else
                    myci = grabar()
                    If Request("next") = "evaluacion" Then
                        Response.Redirect("../SalonVirtual/AddActividadesAItemEvaluacion.aspx?idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&idItemEvaluacion=" & Request("idItemEvaluacion"))
                    Else

                        Response.Redirect("Actividad.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&idClasificacion=" & myci.idClasificacion & "&grabado=1&regreso=" & Request("regreso"))


                    End If

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

    Function editar() As Lego.ClasificacionItem
        Dim myActividades As Contenidos.Actividad = New Contenidos.Actividad(CInt(txtid.Text))
        myActividades.titulo = txtTitulo.Text.ToString
        myActividades.instrucciones = txtInstrucciones.Text
        myActividades.respuesta = 1
        If chkActivarRespuestaGrupal.Checked Then
            myActividades.respuestaGrupal = CInt(drpRespuestaGrupal.SelectedValue)
        Else
            myActividades.respuestaGrupal = 0
        End If

        myActividades.comoSeCalifica = CInt(rdbComoSeCalifica.SelectedValue.ToString)
        If myActividades.comoSeCalifica = Contenidos.EComoSeCalifica.Rubrica Then
            'If drpRubricas.Items.Count > 0 Then
            '    myActividades.idRubrica = CInt(drpRubricas.SelectedValue)
            'End If
        Else
            myActividades.idRubrica = 0
        End If

        myActividades.quienCalifica = CInt(rdbQuiencalifica.SelectedValue.ToString)
        myActividades.mostrarRespuestas = chkmostrarRespuestas.Checked
        myActividades.mostrarObservaciones = chkMostrarObservaciones.Checked
        myActividades.mostrarCalificacion = chkMostrarCalificacion.Checked
        myActividades.puntosPorRespuesta = 0
        myActividades.puntosTotales = 0
        myActividades.tiempoEnMinutos = 0
        myActividades.Tags = txttags.Text
        myActividades.fechaCreacion = Date.Now
        myActividades.TipoX = txtTipoX.Text
        myActividades.Objetivo = txtObjetivoCompetencia.Text
        myActividades.ParaInstructor = txtparaInstructor.Text

        myActividades.Update()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.Update()

        subirArchivosyLigas(myActividades)

        Return myCI

    End Function

    Function grabar() As Lego.ClasificacionItem
        Dim myActividades As Contenidos.Actividad = New Contenidos.Actividad
        myActividades.titulo = txtTitulo.Text.ToString
        myActividades.instrucciones = txtInstrucciones.Text
        myActividades.tipodeActividad = Contenidos.ETipodeActividad.Actividad
        myActividades.respuesta = 1


        If chkActivarRespuestaGrupal.Checked Then
            myActividades.respuestaGrupal = CInt(drpRespuestaGrupal.SelectedValue)
        Else
            myActividades.respuestaGrupal = 0
        End If

        myActividades.comoSeCalifica = CInt(rdbComoSeCalifica.SelectedValue.ToString)
        If myActividades.comoSeCalifica = Contenidos.EComoSeCalifica.Rubrica Then
            'If drpRubricas.Items.Count > 0 Then
            '    myActividades.idRubrica = CInt(drpRubricas.SelectedValue)
            'End If
        Else
            myActividades.idRubrica = 0
        End If

        myActividades.quienCalifica = CInt(rdbQuiencalifica.SelectedValue.ToString)

        myActividades.mostrarRespuestas = chkmostrarRespuestas.Checked
        myActividades.mostrarObservaciones = chkMostrarObservaciones.Checked
        myActividades.mostrarCalificacion = chkMostrarCalificacion.Checked
        myActividades.puntosPorRespuesta = 0
        myActividades.puntosTotales = 0
        myActividades.tiempoEnMinutos = 0
        myActividades.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myActividades.fechaCreacion = Date.Now
        myActividades.Tags = txttags.Text

        myActividades.TipoX = txtTipoX.Text
        myActividades.Objetivo = txtObjetivoCompetencia.Text
        myActividades.ParaInstructor = txtparaInstructor.Text

        myActividades.Add()


        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
        myCI.idClasificacion = CInt(drpUbicacion.SelectedValue)
        myCI.idRoot = CInt(Request("idRoot"))
        myCI.idProc = myActividades.id
        myCI.procedencia = myActividades.tipo
        myCI.Add()


        subirArchivosyLigas(myActividades)


        Return myCI

    End Function

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
            myCont.Tags = ""
            myCont.Add()

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = myActividades.id
            myCA.Procedencia = myActividades.tipo.ToString
            myCA.idContenido = myCont.id
            myCA.Add()

        End If


        Return 1
    End Function







    Protected Sub lnkVerRubrica_Click(sender As Object, e As System.EventArgs) Handles lnkVerRubrica.Click



        pnlRubrica.Visible = True

    End Sub

    Protected Sub lnkVerRubricaA_Click(sender As Object, e As System.EventArgs) Handles lnkVerRubricaA.Click



        pnlRubricaA.Visible = True

    End Sub

    Protected Sub btnGrabarRubrica_Click(sender As Object, e As System.EventArgs) Handles btnGrabarRubrica.Click

        hidTAB.Value = "2"

        Dim claveActividad As Integer = 0
        If txtid.Text <> "" Then
            editar()
            claveActividad = CInt(txtid.Text)
        Else
            claveActividad = grabar().idProc
        End If


        If txtRubricaID.Text <> "" Then
            editarRubrica(CInt(txtRubricaID.Text))
        Else
            grabarRubrica(claveActividad)
        End If


        llenarRubricaTable(claveActividad)
        resetRubrica()

    End Sub


    Protected Sub btnGrabarRubricaA_Click(sender As Object, e As System.EventArgs) Handles btnGrabarRubricaA.Click

        hidTAB.Value = "2"

        Dim claveActividad As Integer = 0
        If txtid.Text <> "" Then
            editar()
            claveActividad = CInt(txtid.Text)
        Else
            Dim myci As Lego.ClasificacionItem = grabar()
            claveActividad = myci.idProc

            grabarRubricaA(claveActividad)

            Response.Redirect("Actividad.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&idClasificacion=" & myci.idClasificacion & "&grabado=1&regreso=" & Request("regreso"))
        End If


        If txtRubricaAID.Text <> "" Then
            editarRubricaA(CInt(txtRubricaAID.Text))
        Else
            grabarRubricaA(claveActividad)
        End If





        llenarRubricaTableA(claveActividad)
        resetRubricaA()

    End Sub



    Sub llenarRubricaTable(claveActividad As Integer)


        Dim myrubrica As New Lego.Rubrica
        rptRubricas.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricas.DataBind()



    End Sub

    Sub llenarRubricaTableA(claveActividad As Integer)


        Dim myrubrica As New Lego.Rubrica
        rptRubricasA.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricasA.DataBind()


        lblTotalRubricaA.Text = myrubrica.GetTotalValorRubricaA(claveActividad)

    End Sub
    Sub resetRubrica()
        txtRubricaID.Text = ""
        txtRubricaTitulo.Text = ""
        txtRubricaVal1.Text = "1"
        txtRubricaVal1Descripcion.Text = "Malo"
        txtRubricaVal2.Text = "2"
        txtRubricaVal2Descripcion.Text = "Regular"
        txtRubricaVal3.Text = "3"
        txtRubricaVal3Descripcion.Text = "Bueno"
        txtRubricaVal4.Text = "4"
        txtRubricaVal4Descripcion.Text = "Excelente"

        pnlRubrica.Visible = False
    End Sub


    Sub resetRubricaA()
        txtRubricaAID.Text = ""
        txtRubricaATitulo.Text = ""
        txtRubricaAVal1.Text = ""


        pnlRubricaA.Visible = False
    End Sub

    Function editarRubrica(claveRubrica As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica(claveRubrica)
        myrubrica.Titulo = txtRubricaTitulo.Text
        myrubrica.Val4 = CInt(txtRubricaVal4.Text)
        myrubrica.Val4Descripcion = txtRubricaVal4Descripcion.Text
        myrubrica.Val3 = CInt(txtRubricaVal3.Text)
        myrubrica.Val3Descripcion = txtRubricaVal3Descripcion.Text
        myrubrica.Val2 = CInt(txtRubricaVal2.Text)
        myrubrica.Val2Descripcion = txtRubricaVal2Descripcion.Text
        myrubrica.Val1 = CInt(txtRubricaVal1.Text)
        myrubrica.Val1Descripcion = txtRubricaVal1Descripcion.Text
        ' myrubrica.idActividad = claveActividad
        myrubrica.Update()

        Return 0
    End Function

    Function editarRubricaA(claveRubrica As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica(claveRubrica)
        myrubrica.Titulo = txtRubricaATitulo.Text
        myrubrica.Val4 = 0
        myrubrica.Val4Descripcion = ""
        myrubrica.Val3 = 0
        myrubrica.Val3Descripcion = ""
        myrubrica.Val2 = 0
        myrubrica.Val2Descripcion = ""
        myrubrica.Val1 = CInt(txtRubricaAVal1.Text)
        myrubrica.Val1Descripcion = ""
        ' myrubrica.idActividad = claveActividad
        myrubrica.Update()

        Return 0
    End Function


    Function grabarRubrica(claveActividad As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica()
        myrubrica.Titulo = txtRubricaTitulo.Text
        myrubrica.Val4 = CInt(txtRubricaVal4.Text)
        myrubrica.Val4Descripcion = txtRubricaVal4Descripcion.Text
        myrubrica.Val3 = CInt(txtRubricaVal3.Text)
        myrubrica.Val3Descripcion = txtRubricaVal3Descripcion.Text
        myrubrica.Val2 = CInt(txtRubricaVal2.Text)
        myrubrica.Val2Descripcion = txtRubricaVal2Descripcion.Text
        myrubrica.Val1 = CInt(txtRubricaVal1.Text)
        myrubrica.Val1Descripcion = txtRubricaVal1Descripcion.Text
        myrubrica.idActividad = claveActividad
        myrubrica.Eliminado = False
        myrubrica.Add()

        Return 0
    End Function

    Function grabarRubricaA(claveActividad As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica()
        myrubrica.Titulo = txtRubricaATitulo.Text
        myrubrica.Val4 = 0
        myrubrica.Val4Descripcion = ""
        myrubrica.Val3 = 0
        myrubrica.Val3Descripcion = ""
        myrubrica.Val2 = 0
        myrubrica.Val2Descripcion = ""
        myrubrica.Val1 = CInt(txtRubricaAVal1.Text)
        myrubrica.Val1Descripcion = ""
        myrubrica.idActividad = claveActividad
        myrubrica.Eliminado = False
        myrubrica.Add()

        Return 0
    End Function


    Public Function ColocarDatosRubrica(claveRubrica As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        txtRubricaID.Text = myrubrica.id
        txtRubricaTitulo.Text = myrubrica.Titulo
        txtRubricaVal1.Text = myrubrica.Val1
        txtRubricaVal1Descripcion.Text = myrubrica.Val1Descripcion
        txtRubricaVal2.Text = myrubrica.Val2
        txtRubricaVal2Descripcion.Text = myrubrica.Val2Descripcion
        txtRubricaVal3.Text = myrubrica.Val3
        txtRubricaVal3Descripcion.Text = myrubrica.Val3Descripcion
        txtRubricaVal4.Text = myrubrica.Val4
        txtRubricaVal4Descripcion.Text = myrubrica.Val4Descripcion

        pnlRubrica.Visible = True

        btnBorrarRubrica.Visible = True


        Return 0
    End Function



    Public Function ColocarDatosRubricaA(claveRubrica As Integer) As Integer
        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        txtRubricaAID.Text = myrubrica.id
        txtRubricaATitulo.Text = myrubrica.Titulo
        txtRubricaAVal1.Text = myrubrica.Val1


        pnlRubricaA.Visible = True

        btnBorrarRubricaA.Visible = True


        Return 0
    End Function



    Protected Sub btnCancelarRubrica_Click(sender As Object, e As System.EventArgs) Handles btnCancelarRubrica.Click
        resetRubrica()
    End Sub

    Protected Sub btnCancelarRubricaA_Click(sender As Object, e As System.EventArgs) Handles btnCancelarRubricaA.Click
        resetRubricaA()
    End Sub

    Protected Sub btnBorrarRubrica_Click(sender As Object, e As System.EventArgs) Handles btnBorrarRubrica.Click
        Dim myrubrica As New Lego.Rubrica(CInt(txtRubricaID.Text))
        myrubrica.Remove()
        resetRubrica()

        llenarRubricaTable(myrubrica.idActividad)

    End Sub
    Protected Sub btnBorrarRubricaA_Click(sender As Object, e As System.EventArgs) Handles btnBorrarRubricaA.Click
        Dim myrubrica As New Lego.Rubrica(CInt(txtRubricaAID.Text))
        myrubrica.Remove()
        resetRubricaA()

        llenarRubricaTableA(myrubrica.idActividad)

    End Sub

    Protected Sub rptRubricas_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptRubricas.ItemCommand

        Dim comando As String = "EditarRubrica"

        Select Case e.CommandName
            Case "EditarRubrica"
                ColocarDatosRubrica(CInt(e.CommandArgument))

        End Select

    End Sub

    Protected Sub rptRubricasA_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptRubricasA.ItemCommand

        Dim comando As String = "EditarRubricaA"

        Select Case e.CommandName
            Case "EditarRubricaA"
                ColocarDatosRubricaA(CInt(e.CommandArgument))

        End Select

    End Sub


    Protected Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        If Request("regreso") = "carpeta" Then
            Response.Redirect("~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion"))
        End If

        Response.Redirect("~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot"))
    End Sub

    Private Sub chkActivarRespuestaGrupal_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivarRespuestaGrupal.CheckedChanged
        If chkActivarRespuestaGrupal.Checked Then
            drpRespuestaGrupal.Visible = True
        Else
            drpRespuestaGrupal.Visible = False
        End If
    End Sub



    Protected Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        editar()

        '    Dim cadenaredirec As String = "~/sec/workbook/AddContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & myci.id & "&Proc=Texto&idClasificacion=" & myci.idClasificacion

        Response.Redirect("~/sec/workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Actividad&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1")

    End Sub

    Protected Sub btnGrabarLiga_Click(sender As Object, e As EventArgs) Handles btnGrabarLiga.Click
        editar()
        Response.Redirect("~/sec/workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Actividad&idCI=" & Request("idCI") & "&regreso=" & Request("regreso") & "&grabado=1")
    End Sub

    Private Sub rdbComoSeCalifica_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbComoSeCalifica.SelectedIndexChanged

        hidTAB.Value = 2

        pnlRubrica.Visible = False
        panelRubricaB.Visible = False
        panelRubricaA.Visible = False

        Select Case rdbComoSeCalifica.SelectedValue
            Case "1"
            Case "2"
            Case "4"
                pnlRubrica.Visible = True
                panelRubricaB.Visible = True
            Case "5"
                pnlRubricaA.Visible = True
                panelRubricaA.Visible = True
        End Select
    End Sub
End Class
