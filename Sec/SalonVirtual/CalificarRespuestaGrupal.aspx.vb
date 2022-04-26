Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports System.IO


Partial Class Sec_SalonVirtual_CalificarRespuestaGrupal
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    End Sub

    Sub colocarDatos()
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)

        If mya.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Response.Redirect("CalificarExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & myr.id & "&pag=" & Request("pag"))
        End If


        Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myu.id, CInt(Session("gUserProfileSession").idEmpresaDefault), False)
        '  imgAlumno.ImageUrl = getFoto(myeu.claveAux1, myeu.claveAux2)
        imgAlumno.ImageUrl = "~/sec/showfile.aspx?idUserProfile=" & myeu.idUserProfile



        estudiante.Text = myu.nombre & " " & myu.apellidos
        fechaenvio.Text = myr.fechaEnvio.ToLongDateString & " " & myr.fechaEnvio.ToLongTimeString
        actividad.Text = mya.titulo
        lbltextoinstrucciones.Text = mya.instrucciones

        Dim myrtemp As New Contenidos.Respuesta(myr.id, myr.idProc, myr.procedencia.ToString, myr.idSalonVirtual, Session("gUserProfileSession").idUserProfile)
        If myrtemp.existe Then
            txtCalificacion.Text = Format(myrtemp.calificacion / 10, "0.0")
        Else
            txtCalificacion.Text = "0.0"
        End If

        txtMensaje.Text = myr.observaciones
        littexto.Text = myr.texto
        chkPermitir.Checked = myr.repetir

        If mya.quienCalifica = Contenidos.EQuienCalifica.Alumnos Then
            lnkCalificaciones.Visible = True
            lnkCalificaciones.NavigateUrl &= "?idSalonVirtual=" & myr.idSalonVirtual & "&idR=" & myr.id
        Else
            lnkCalificaciones.Visible = False
        End If

        'Colocar adjuntos
        displayRespuestaArchivos1.idRespuesta = myr.id


        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.Ranking Then
            PanelRanking.Visible = True
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.ValorNumerico Then
            PanelCalifica.Visible = True
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.Rubrica Then
            PanelRubrica.Visible = True

            llenarRubricaTable(mya.id)
            SetCalificacionRubrica(myr.id)
        End If

        If mya.comoSeCalifica = Contenidos.EComoSeCalifica.RubricaA Then
            panelRubricaA.Visible = True

            llenarRubricaTablea(mya.id)
            SetCalificacionRubricaA(myr)
        End If

        claveSalon = myr.idSalonVirtual
        claveUsuario = myr.idUserProfile
        claveRespuesta = myr.id



    End Sub


    Dim claveSalon As Integer
    Dim claveUsuario As Integer
    Dim claveRespuesta As Integer


    Public Function SetCalificacionRubrica(claveRespuestaAlumno As Integer) As Integer
        Dim myRRubrica As New Contenidos.RespuestaRubrica()

        For i = 0 To rptRubricas.Items.Count - 1
            Dim myControlCalificacion As DropDownList = CType(rptRubricas.Items(i).FindControl("drpRubricaRow"), DropDownList)
            Dim myControlRubro As Label = CType(rptRubricas.Items(i).FindControl("lblRubricaID"), Label)
            myRRubrica = New Contenidos.RespuestaRubrica(claveRespuestaAlumno, CInt(myControlRubro.Text))
            myControlCalificacion.SelectedValue = myRRubrica.calificacion1

        Next
        Return 0
    End Function


    Public Function SetCalificacionRubricaA(claveRespuestaAlumno As Contenidos.Respuesta) As Integer
        If claveRespuestaAlumno.existe Then
            Dim myRRubrica As New Contenidos.RespuestaRubrica()

            For i = 0 To rptRubricaA.Items.Count - 1
                Dim myControlCalificacion As DropDownList = CType(rptRubricaA.Items(i).FindControl("drpRubricaRow"), DropDownList)
                Dim myControlRubro As Label = CType(rptRubricaA.Items(i).FindControl("lblRubricaID"), Label)
                myRRubrica = New Contenidos.RespuestaRubrica(claveRespuestaAlumno.id, CInt(myControlRubro.Text))
                myControlCalificacion.SelectedValue = myRRubrica.calificacion1

            Next

            lblTotalRA.Text = CInt(claveRespuestaAlumno.calificacion)
        End If

        Return 0
    End Function


    Sub llenarRubricaTable(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricas.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricas.DataBind()

    End Sub


    Sub llenarRubricaTablea(claveActividad As Integer)

        Dim myrubrica As New Lego.Rubrica
        rptRubricaA.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricaA.DataBind()

    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        calificar()
    End Sub


    Sub calificar()

        Dim respuesta As Boolean = False
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
        If myr.existe Then
            respuesta = calificanAlumnos()

        End If








        If respuesta Then



            Response.Redirect("ActividadesPorCalificar.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))



        End If



    End Sub

    Function calificanAlumnos() As Boolean
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)

        Dim myrnueva As Contenidos.Respuesta = New Contenidos.Respuesta()
        myrnueva.idProc = myr.idProc
        myrnueva.procedencia = myr.procedencia
        myrnueva.idRaiz = myr.id
        If Request("idUserProfile") <> "" Then
            myrnueva.idUserProfile = CInt(Request("idUserProfile"))
        Else
            myrnueva.idUserProfile = Session("gUserProfileSession").idUserProfile
        End If

        myrnueva.titulo = myr.titulo
        myrnueva.texto = ""
        myrnueva.observaciones = txtMensaje.Text
        myrnueva.idSalonVirtual = CInt(Request("idSalonVirtual"))
        myrnueva.fechaEnvio = myr.fechaEnvio
        myrnueva.fechaRevision = Date.Now

        Select Case mya.comoSeCalifica
            Case Contenidos.EComoSeCalifica.ValorNumerico
                myrnueva.calificacion = CInt(CDec(txtCalificacion.Text) * 10)
            Case Contenidos.EComoSeCalifica.Ranking
                myrnueva.calificacion = regresarValorSeleccionado() * 10
        End Select

        myrnueva.repetir = False
        myrnueva.status = Contenidos.StatusRespuesta.Calificada

        myrnueva.Add()


        myr.calificacion = myrnueva.GetPromedioRaiz(myr.id)
        myr.repetir = chkPermitir.Checked
        myr.status = Contenidos.StatusRespuesta.Calificada
        myr.Update()
        subirArchivosyLigas(myr)



        'actualizar calificacion general
        Dim mysvup As New Know.SalonVirtualUserProfile(myr.idUserProfile, myr.idSalonVirtual, False)
        mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myr.idUserProfile, myr.idSalonVirtual)
        mysvup.Update()



        Return True


    End Function


    Public Function getRubricasDrop(claveRubrica As Integer) As DataView

        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        Dim dTable As New DataTable("Rubrica")
        dTable.Columns.Add(New DataColumn("valor", GetType(Integer)))

        Dim dRow As DataRow = dTable.NewRow()
        dRow(0) = myrubrica.Val4
        dTable.Rows.Add(dRow)

        Dim dRow2 As DataRow = dTable.NewRow()
        dRow2(0) = myrubrica.Val3
        dTable.Rows.Add(dRow2)

        Dim dRow3 As DataRow = dTable.NewRow()
        dRow3(0) = myrubrica.Val2
        dTable.Rows.Add(dRow3)

        Dim dRow4 As DataRow = dTable.NewRow()
        dRow4(0) = myrubrica.Val1
        dTable.Rows.Add(dRow4)

        Return dTable.DefaultView

    End Function

    Public Function getRubricasDropA(claveRubrica As Integer) As DataView

        Dim myrubrica As New Lego.Rubrica(claveRubrica)

        Dim dTable As New DataTable("Rubrica")
        dTable.Columns.Add(New DataColumn("valor", GetType(Integer)))

        Dim i As Integer = 0
        For i = myrubrica.Val1 To 0 Step -1
            Dim dRow4 As DataRow = dTable.NewRow()
            dRow4(0) = i
            dTable.Rows.Add(dRow4)
        Next

        'Dim dRow As DataRow = dTable.NewRow()
        'dRow(0) = myrubrica.Val4
        'dTable.Rows.Add(dRow)

        'Dim dRow2 As DataRow = dTable.NewRow()
        'dRow2(0) = myrubrica.Val3
        'dTable.Rows.Add(dRow2)

        'Dim dRow3 As DataRow = dTable.NewRow()
        'dRow3(0) = myrubrica.Val2
        'dTable.Rows.Add(dRow3)

        'Dim dRow4 As DataRow = dTable.NewRow()
        'dRow4(0) = myrubrica.Val1
        'dTable.Rows.Add(dRow4)

        Return dTable.DefaultView

    End Function

    Function regresarValorSeleccionado() As Integer
        Dim cal As Integer = 0
        If Rate1.Checked Then
            cal = 1
        End If
        If Rate2.Checked Then
            cal = 2
        End If
        If Rate3.Checked Then
            cal = 3
        End If
        If Rate4.Checked Then
            cal = 4
        End If
        If Rate5.Checked Then
            cal = 5
        End If
        If Rate6.Checked Then
            cal = 6
        End If
        If Rate7.Checked Then
            cal = 7
        End If
        If Rate8.Checked Then
            cal = 8
        End If
        If Rate9.Checked Then
            cal = 9
        End If
        If Rate10.Checked Then
            cal = 10
        End If
        Return cal
    End Function




    Function subirArchivosyLigas(ByVal myR As Contenidos.Respuesta) As Integer
        'seccion para subir archivos 
        Dim myra As Contenidos.RespuestaArchivo


        If File1.PostedFile.FileName <> "" Then
            myra = New Contenidos.RespuestaArchivo
            myra.idRespuesta = myR.id
            myra.fechaCreacion = Date.Now

            Dim extension As String = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(".") + 1)
            Dim nombreoriginal As String = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\") + 1)
            myra.nombre = ""
            myra.nombreOriginal = nombreoriginal
            myra.espacio = File1.PostedFile.ContentLength
            myra.Add()

            Dim nombre As String = myra.id & "." & extension
            myra.nombre = nombre
            File1.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & myra.nombre)
            myra.Update()

        End If
        If File2.PostedFile.FileName <> "" Then
            myra = New Contenidos.RespuestaArchivo
            myra.idRespuesta = myR.id
            myra.fechaCreacion = Date.Now

            Dim extension As String = File2.PostedFile.FileName.Substring(File2.PostedFile.FileName.LastIndexOf(".") + 1)
            Dim nombreoriginal As String = File2.PostedFile.FileName.Substring(File2.PostedFile.FileName.LastIndexOf("\") + 1)
            myra.nombre = ""
            myra.nombreOriginal = nombreoriginal
            myra.espacio = File2.PostedFile.ContentLength
            myra.Add()

            Dim nombre As String = myra.id & "." & extension
            myra.nombre = nombre
            File2.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\" & myra.nombre)
            myra.Update()
        End If



        Return 1

    End Function


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
