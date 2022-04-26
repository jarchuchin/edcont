Imports System.Xml
Imports System.Xml.Serialization

Imports System.Data
Imports System.IO

Partial Class Sec_SalonVirtual_AddSalonVirtual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()
        End If

       
      
    End Sub

   
    Sub iniciarControles()


        If CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
            Response.Redirect("~/logout.aspx")
        End If

        Dim myRoot As Lego.Root = New Lego.Root
        drpLibros.DataSource = myRoot.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True)
        drpLibros.DataTextField = "titulo"
        drpLibros.DataValueField = "idRoot"
        drpLibros.DataBind()
        drpLibros.Visible = True
        ValidadorLibro.Visible = True


        Dim mye As New MasUsuarios.Empresa

        drpEmpresas.DataSource = mye.GetDR()
        drpEmpresas.DataTextField = "Nombre"
        drpEmpresas.DataValueField = "idEmpresa"
        drpEmpresas.DataBind()

        drpEmpresas.SelectedValue = CInt(Session("idEmpresa"))

        If Request("idSalonVirtual") <> "" Then
            colocarDatos()

            Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            lnkCurso.Text = mysv.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

            If mysv.idRoot > 0 Then
                lnkQuitarLibro.NavigateUrl = "~/sec/salonvirtual/QuitarLibro.aspx?idSalonVirtual=" & Request("idSalonVirtual")
                lnkQuitarLibro.Visible = True
            End If





        Else



            Dim myitem As New System.Web.UI.WebControls.ListItem(lblcrearlibro.Text, "0")
            drpLibros.Items.Insert(0, myitem)


            Dim myitem2 As New System.Web.UI.WebControls.ListItem("---Crear libro nuevo basado en MODELO ESNM---", "9094")
            drpLibros.Items.Insert(1, myitem2)








        End If

        drpEmpresas.SelectedValue = CInt(Session("idEmpresa"))
        If CInt(Session("idEmpresa")) = 4 Then
            drpEmpresas.Enabled = True
        Else
            drpEmpresas.Enabled = False
        End If

        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        mye = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As New MasUsuarios.Permiso(myu, mye)

        If drpEmpresas.Enabled Then
            If myp.PAdministracion Then
                drpEmpresas.Enabled = True
            Else

                drpEmpresas.Enabled = False
            End If
        End If

        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")


        If Not esmaestro() Then

        End If


    End Sub
    Sub colocarDatos()
        Dim mySalonV As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), True)
        txtNombre.Text = mySalonV.nombre
        txtFechaInicio.Text = mySalonV.fechaInicio

        txtFechaFin.Text = mySalonV.fechaFin


        txtHorarioAtencion.Text = mySalonV.horarioAtencion
        '   txtCalificacionMaxima.Text = mySalonV.calificacionMaxima
        If mySalonV.status Then
            rdbStatus.Items(0).Selected = True
            rdbStatus.Items(1).Selected = False
        Else
            rdbStatus.Items(0).Selected = False
            rdbStatus.Items(1).Selected = True
        End If
        txtClaveID1.Text = mySalonV.claveAux1
        txtClaveID2.Text = mySalonV.claveAux2
        txtLigaSalonVirtual.Text = mySalonV.LigaSalonVirtual

        chkpermitirVerExamenes.Checked = mySalonV.permitirVerExamenes

        CustomValidator4.Visible = False
        CustomValidator4.Enabled = False

        ' btnBorrar.Visible = True
        drpEmpresas.SelectedValue = mySalonV.idEmpresa


        Dim mysvc As New Know.SalonVirtualCompartido
        If mysvc.estaCompartido(mySalonV.id) Then
            lnkCompartirRoom.Visible = False
        Else
            lnkCompartirRoom.Visible = False
            lnkCompartirRoom.NavigateUrl = "~/sec/salonvirtual/compartirroom.aspx?idSalonVirtual=" & mySalonV.id
        End If


        If mySalonV.idRoot = 0 Then
            '      lnkmensajebook.Visible = True
            '      lnkmensajebook.NavigateUrl = "~/Sec/Workbook/Default.aspx?idSalonVirtual=" & mySalonV.id
            Dim myitem As New System.Web.UI.WebControls.ListItem(lblcrearlibro.Text, "0")
            drpLibros.Items.Insert(0, myitem)

            drpLibros.Visible = True
            ValidadorLibro.Visible = True
        Else
            txtLibro.Visible = True
            txtLibro.Text = mySalonV.root.titulo
            drpLibros.Visible = False
            ValidadorLibro.Visible = False

            drpLibros.SelectedValue = mySalonV.idRoot

        End If



        txtEmpotrado.Text = mySalonV.embeddedDisplay


        If mySalonV.fileDisplay <> "" Then
            imgInicial.ImageUrl = "~/images/salonesVirtuales/" & mySalonV.fileDisplay
            imgInicial.Visible = True
        End If

        If mySalonV.videoDisplay <> "" Then
            litVideo.Text = "~/images/salonesVirtuales/" & mySalonV.videoDisplay
            litVideo.Visible = True
        End If



    End Sub
    Sub desabilitar(ByVal estado As Boolean)
        txtNombre.Enabled = estado
        txtFechaInicio.Enabled = estado
        txtFechaFin.Enabled = estado
        txtHorarioAtencion.Enabled = estado
        '    txtCalificacionMaxima.Enabled = estado
        rdbStatus.Enabled = estado
        txtClaveID1.Enabled = estado
        txtClaveID2.Enabled = estado

        '         btnBorrar.Visible = estado
        btnGrabar.Visible = estado
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




    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If IsDate(txtFechaInicio.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Private Sub Customvalidator2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles Customvalidator2.ServerValidate
        If IsDate(txtFechaFin.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Function editar() As Integer

        Dim mySalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), True)
        'mySalonVirtual.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile) And
        If drpLibros.SelectedValue = "0" And mySalonVirtual.idRoot = 0 Then
            Dim myRoot As Lego.Root = New Lego.Root
            myRoot.titulo = txtNombre.Text & " (Libro de trabajo)"
            myRoot.descripcion = ""
            myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
            myRoot.Tags = ""
            myRoot.fechaCreacion = Date.Now
            myRoot.Eliminado = False
            myRoot.idEmpresa = CInt(drpEmpresas.SelectedValue)
            myRoot.Add()
            grabarRootEmpresa(myRoot.id, CInt(drpEmpresas.SelectedValue))
            mySalonVirtual.idRoot = myRoot.id

            grabarPermisos(myRoot.id)


            Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion()
            myclasifica.titulo = "Unidad 1"
            myclasifica.idRaiz = 0
            myclasifica.idRoot = myRoot.id
            myclasifica.diaDisplay = 1
            myclasifica.texto = ""
            myclasifica.status = True
            myclasifica.Add()


            myclasifica.titulo = "Unidad 2"
            myclasifica.idRaiz = 0
            myclasifica.idRoot = myRoot.id
            myclasifica.diaDisplay = 1
            myclasifica.texto = ""
            myclasifica.status = True
            myclasifica.Add()

        Else



            If mySalonVirtual.idRoot = 0 And drpLibros.Visible = True Then
                mySalonVirtual.idRoot = Integer.Parse(drpLibros.SelectedItem.Value)
            End If



        End If

        mySalonVirtual.nombre = txtNombre.Text
        mySalonVirtual.fechaInicio = CDate(txtFechaInicio.Text)
        mySalonVirtual.fechaFin = CDate(txtFechaFin.Text)
        mySalonVirtual.horarioAtencion = txtHorarioAtencion.Text
        mySalonVirtual.LigaSalonVirtual = txtLigaSalonVirtual.Text
        '    mySalonVirtual.calificacionMaxima = Integer.Parse(txtCalificacionMaxima.Text)
        If rdbStatus.SelectedItem.Value = "1" Then
            mySalonVirtual.status = True
        Else
            mySalonVirtual.status = False
        End If
        mySalonVirtual.claveAux1 = txtClaveID1.Text
        mySalonVirtual.claveAux2 = txtClaveID2.Text
        mySalonVirtual.permitirVerExamenes = chkpermitirVerExamenes.Checked
        mySalonVirtual.idEmpresa = CInt(drpEmpresas.SelectedValue)

        Dim locInicio As String = getNameFile(fuInicial, "IMG")
        If locInicio <> "" Then
            mySalonVirtual.fileDisplay = locInicio
        End If
        Dim locVideo As String = getNameFile(fuVideo, "VIDEO")
        If locVideo <> "" Then
            mySalonVirtual.videoDisplay = locVideo
        End If
        mySalonVirtual.embeddedDisplay = txtEmpotrado.Text

        mySalonVirtual.Update()

        Return mySalonVirtual.id

    End Function

    Function grabar() As Integer

        Dim mySalonVirtual As Know.SalonVirtual = New Know.SalonVirtual
        If drpLibros.SelectedValue = "0" Then
            Dim myRoot As Lego.Root = New Lego.Root
            myRoot.titulo = txtNombre.Text & " (Libro de trabajo)"
            myRoot.descripcion = ""
            myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
            myRoot.Tags = ""
            myRoot.fechaCreacion = Date.Now
            myRoot.Eliminado = False
            myRoot.idEmpresa = CInt(drpEmpresas.SelectedValue)
            myRoot.Add()


            grabarRootEmpresa(myRoot.id, CInt(drpEmpresas.SelectedValue))
            mySalonVirtual.idRoot = myRoot.id

            grabarPermisos(myRoot.id)


            Dim myclasifica As Lego.Clasificacion = New Lego.Clasificacion()
            myclasifica.titulo = "Unidad 1"
            myclasifica.idRaiz = 0
            myclasifica.idRoot = myRoot.id
            myclasifica.diaDisplay = 1
            myclasifica.texto = ""
            myclasifica.status = True
            myclasifica.Add()


            myclasifica.titulo = "Unidad 2"
            myclasifica.idRaiz = 0
            myclasifica.idRoot = myRoot.id
            myclasifica.diaDisplay = 1
            myclasifica.texto = ""
            myclasifica.status = True
            myclasifica.Add()

        Else

            If drpLibros.SelectedValue = "9094" Then

                Dim rootCreado As Integer = clonar()
                mySalonVirtual.idRoot = rootCreado

            End If

            mySalonVirtual.idRoot = Integer.Parse(drpLibros.SelectedItem.Value)
        End If

        mySalonVirtual.nombre = txtNombre.Text
        mySalonVirtual.fechaInicio = CDate(txtFechaInicio.Text)
        mySalonVirtual.fechaFin = CDate(txtFechaFin.Text)
        mySalonVirtual.horarioAtencion = txtHorarioAtencion.Text
        mySalonVirtual.LigaSalonVirtual = txtLigaSalonVirtual.Text

        mySalonVirtual.calificacionMaxima = 100 ' Integer.Parse(txtCalificacionMaxima.Text)
        If rdbStatus.SelectedItem.Value = "1" Then
            mySalonVirtual.status = True
        Else
            mySalonVirtual.status = False
        End If
        mySalonVirtual.claveAux1 = txtClaveID1.Text
        mySalonVirtual.claveAux2 = txtClaveID2.Text
        mySalonVirtual.idEmpresa = CInt(drpEmpresas.SelectedValue)
        mySalonVirtual.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        mySalonVirtual.permitirVerExamenes = chkpermitirVerExamenes.Checked
        mySalonVirtual.embeddedDisplay = txtEmpotrado.Text
        mySalonVirtual.Add()

        Dim locInicio As String = getNameFile(fuInicial, "IMG")
        If locInicio <> "" Then
            mySalonVirtual.fileDisplay = locInicio
        End If
        Dim locVideo As String = getNameFile(fuVideo, "VIDEO")
        If locVideo <> "" Then
            mySalonVirtual.videoDisplay = locVideo
        End If
        mySalonVirtual.Update()


        Return mySalonVirtual.id
    End Function


    Sub grabarPermisos(ByVal claveroot As Integer)
        Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso
        Dim myUserP As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), False)
        Dim myr As Lego.Root = New Lego.Root(claveroot)

        myPermiso.permisoA = myUserP.tipo
        myPermiso.idPermisoA = myUserP.id
        myPermiso.recurso = myr.tipo
        myPermiso.idRecurso = myr.id

        myPermiso.PRoots = True
        myPermiso.PPermisosRoots = True
        myPermiso.PCategorias = True
        myPermiso.PRespuestas = True
        myPermiso.PEvaluacion = True
        myPermiso.PSalonVirtual = True
        myPermiso.PContenidos = True
        myPermiso.PInterfaceGrafica = True
        myPermiso.PEstadisticas = True
        myPermiso.PAdministracion = True
        myPermiso.Add()

    End Sub

    Sub grabarRootEmpresa(ByVal claveRoot As Integer, ByVal claveempresa As Integer)
        Dim myRootEmpresa As Lego.RootEmpresa = New Lego.RootEmpresa
        myRootEmpresa.idEmpresa = claveempresa
        myRootEmpresa.idRoot = claveRoot
        myRootEmpresa.Add()
    End Sub



    'Private Sub Customvalidator3_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles Customvalidator3.ServerValidate
    '    If IsNumeric(txtCalificacionMaxima.Text) Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If
    'End Sub


    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click


        If Page.IsValid Then

            Dim numero As Integer
            If Request("idSalonVirtual") <> "" Then
                Dim mySalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(Integer.Parse(Request("idSalonVirtual")), True)
                If mySalonVirtual.idRoot = 0 Then
                    If drpLibros.Items.Count > 0 Then
                        If CInt(drpLibros.SelectedValue) = "0" Then
                            numero = editar()
                            mySalonVirtual = New Know.SalonVirtual(numero, True)
                            Response.Redirect("~/sec/workbook/Default.aspx?idRoot=" & mySalonVirtual.idRoot)
                        Else
                            numero = editar()
                        End If
                    Else
                        numero = editar()
                    End If

                Else
                    numero = editar()
                End If

            Else
                numero = grabar()

            End If
            Response.Redirect("Default.aspx?idSalonVirtual=" & numero)
        End If
    End Sub


    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        System.Threading.Thread.Sleep(1500)

        Dim sepuedeborrar As Boolean = True
        Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
        Dim mySalonUsers As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        Dim dr As Data.SqlClient.SqlDataReader = myItemEvaluacion.GetDR(CInt(Request("idSalonVirtual")))
        If dr.HasRows Then
            sepuedeborrar = False
        End If
        dr.Close()

        If sepuedeborrar Then
            dr = mySalonUsers.GetDR(CInt(Request("idSalonVirtual")))
            If dr.HasRows Then
                sepuedeborrar = False
            End If
            dr.Close()
        End If

        If sepuedeborrar Then
            If mysalonVirtual.idUserProfile <> Integer.Parse(Session("gUserProfileSession").idUserProfile) Then
                sepuedeborrar = False
            End If
        End If

        If sepuedeborrar Then
            mysalonVirtual.Remove()

            Response.Redirect("../default.aspx")
        Else
            lblMensajeBorrar.Visible = True
        End If
    End Sub

    Protected Sub btnCrearVirtualRom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrearVirtualRom.Click

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim nombre1 As String = "name=" & mysalonVirtual.claveAux1 & "&meetingID=" & mysalonVirtual.claveAux1 & "&attendeePW=111222&moderatorPW=333444"
        Dim salt As String = "9d857467726e2a49fd2ff78272e68d89"


        Dim cadenarara As String = getSHA1Hash(nombre1 & salt)

        Dim cadena As String = getdatos("http://skolar.online/bigbluebutton/api/create?" & nombre1 & "&checksum=" & cadenarara)

        Label1.Text = cadena



        Dim cadenaelifo As String = "xxxxxxxxxxxxxxxxxxxxxxxx"




        Dim bbmeetingID As String = String.Empty
        Dim bbmoderatorPW As String = String.Empty
        Dim bbattendeePW As String = String.Empty


        Dim xmlDoc As New XmlDocument
        Dim productNodes As XmlNodeList
        Dim productNode As XmlNode
        Dim baseDataNodes As XmlNodeList
        Dim bFirstInRow As Boolean

        xmlDoc.LoadXml(cadena)

        productNodes = xmlDoc.GetElementsByTagName("response")
        For Each productNode In productNodes
            baseDataNodes = productNode.ChildNodes
            bFirstInRow = True
            For Each baseDataNode As XmlNode In baseDataNodes
                If baseDataNode.Name.ToLower = "meetingid" Then
                    bbmeetingID = baseDataNode.InnerText
                End If
                If baseDataNode.Name.ToLower = "attendeepw" Then
                    bbattendeePW = baseDataNode.InnerText
                End If
                If baseDataNode.Name.ToLower = "moderatorpw" Then
                    bbmoderatorPW = baseDataNode.InnerText
                End If


            Next
        Next




        mysalonVirtual.bbmeetingID = bbmeetingID
        mysalonVirtual.bbattendeePW = bbattendeePW
        mysalonVirtual.bbmoderatorPW = bbmoderatorPW
        mysalonVirtual.Update()



    End Sub








    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next



        Return strResult

    End Function

    Public Function getdatos(ByVal url As String) As String
        Dim result As String
        Try
            Dim objRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

            objRequest.Method = "GET"
            Dim objResponse As System.Net.HttpWebResponse = objRequest.GetResponse()
            Dim sr As System.IO.StreamReader
            sr = New System.IO.StreamReader(objResponse.GetResponseStream())
            result = sr.ReadToEnd()
            sr.Close()

            Return result
        Catch ex As Exception
            Return ex.Message.ToString
        End Try



    End Function

    Public Function clonar() As Integer

        '###################################
        'DATOS GENERALES
        Dim myRootOriginal As New Lego.Root(9094)
        Dim myRoot As Lego.Root = New Lego.Root
        myRoot.titulo = "LT " & txtNombre.Text  'myRootOriginal.titulo
        myRoot.descripcion = myRootOriginal.descripcion
        myRoot.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        myRoot.Tags = myRootOriginal.Tags
        myRoot.fechaCreacion = Date.Now
        myRoot.Eliminado = False
        myRoot.Autor = myRootOriginal.Autor
        myRoot.Biblioteca = myRootOriginal.Biblioteca
        myRoot.ParaInstructor = myRootOriginal.ParaInstructor
        myRoot.Convenios = myRootOriginal.Convenios
        myRoot.fechaUltimaActualizacion = Date.Now
        myRoot.CertificacionDoc = ""
        myRoot.idIdioma = myRootOriginal.idIdioma
        myRoot.Raiz = myRootOriginal.Raiz
        myRoot.Idioma = myRootOriginal.Idioma
        myRoot.Add()
        grabarRootEmpresa(myRoot.id)
        If Request("idUserProfile") <> "0" Then
            grabarPermisos(myRoot.id)
        End If
        'DATOS GENERALES
        '###################################

        '###################################
        'CLASIFICACIONES
        Dim myCOriginal As New Lego.Clasificacion
        Dim myC As Lego.Clasificacion
        Dim myCIOriginal As New Lego.ClasificacionItem
        Dim myCI As Lego.ClasificacionItem
        Dim dsCI As DataSet
        Dim dsC As DataSet = myCOriginal.GetDS(myRootOriginal.id, 0)

        Dim myo1 As Lego.Objetivo
        Dim myo2 As Lego.Objetivo

        For Each drC As DataRow In dsC.Tables(0).Rows
            myC = New Lego.Clasificacion
            myC.idRaiz = 0
            myC.idRoot = myRoot.id
            myC.titulo = drC("titulo")
            myC.status = CBool(drC("status"))
            myC.orden = CInt(drC("orden"))
            myC.texto = drC("texto")
            myC.diaDisplay = CInt(drC("diaDisplay"))
            If Not Convert.IsDBNull(drC("PlanteamientoBreve")) Then
                myC.PlanteamientoBreve = drC("PlanteamientoBreve")
            Else
                myC.PlanteamientoBreve = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen1")) Then
                myC.Imagen1 = drC("Imagen1")
            Else
                myC.Imagen1 = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen2")) Then
                myC.Imagen2 = drC("Imagen2")
            Else
                myC.Imagen2 = ""
            End If
            If Not Convert.IsDBNull(drC("Imagen3")) Then
                myC.Imagen3 = drC("Imagen3")
            Else
                myC.Imagen3 = ""
            End If
            If Not Convert.IsDBNull(drC("idActividad")) Then
                myC.idActividad = CInt(drC("idActividad"))
            Else
                myC.idActividad = 0
            End If
            myC.Add()

            myo1 = New Lego.Objetivo
            Dim dsObj = myo1.GetDS(CInt(drC("idClasificacion")))
            For Each drObj In dsObj.Tables(0).Rows
                myo2 = New Lego.Objetivo
                myo2.idClasificacion = myC.id
                If Not Convert.IsDBNull(drObj("objetivo")) Then
                    myo2.objetivox = drObj("objetivo")
                Else
                    myo2.objetivox = ""
                End If

                If Not Convert.IsDBNull(drObj("habilidad")) Then
                    myo2.habilidad = drObj("habilidad")
                Else
                    myo2.habilidad = ""
                End If

                If Not Convert.IsDBNull(drObj("aptitud")) Then
                    myo2.aptitud = drObj("aptitud")
                Else
                    myo2.aptitud = ""
                End If
                myo2.Add()

            Next



            dsCI = myCIOriginal.GetDS(CInt(drC("idClasificacion")), "asc")
            For Each drCI As DataRow In dsCI.Tables(0).Rows
                myCI = New Lego.ClasificacionItem
                myCI.idClasificacion = myC.id
                myCI.idRoot = myRoot.id
                myCI.orden = CInt(drCI("orden"))

                Select Case drCI("procedencia")
                    Case "Contenido"
                        myCI.procedencia = tipoObjeto.Contenido
                        myCI.idProc = grabarContenido(CInt(drCI("idProc")))
                    Case "Foro"
                        myCI.procedencia = tipoObjeto.Foro
                        myCI.idProc = grabarForo(CInt(drCI("idProc")))
                    Case "Actividad"
                        myCI.procedencia = tipoObjeto.Actividad
                        myCI.idProc = grabarActividad(CInt(drCI("idProc")))
                End Select

                myCI.Add()
            Next
        Next

        Return myRoot.id
        'Response.Redirect("~/sec/workbook/home.aspx?idRoot=" & myRoot.id)
    End Function


    Sub grabarRootEmpresa(ByVal claveRoot As Integer)
        Dim myRootEmpresa As Lego.RootEmpresa = New Lego.RootEmpresa
        myRootEmpresa.idEmpresa = 4
        myRootEmpresa.idRoot = claveRoot
        myRootEmpresa.Add()
    End Sub


    Function grabarActividad(claveActividad As Integer) As Integer
        Dim myactividad As New Contenidos.Actividad(claveActividad)
        Dim mynewactividad As New Contenidos.Actividad
        mynewactividad.titulo = myactividad.titulo
        mynewactividad.tipodeActividad = myactividad.tipodeActividad
        mynewactividad.instrucciones = myactividad.instrucciones
        mynewactividad.respuesta = myactividad.respuesta
        mynewactividad.respuestaGrupal = myactividad.respuestaGrupal
        mynewactividad.comoSeCalifica = myactividad.comoSeCalifica
        mynewactividad.quienCalifica = myactividad.quienCalifica
        mynewactividad.mostrarCalificacion = myactividad.mostrarCalificacion
        mynewactividad.mostrarRespuestas = myactividad.mostrarRespuestas
        mynewactividad.mostrarObservaciones = myactividad.mostrarObservaciones
        mynewactividad.puntosPorRespuesta = myactividad.puntosPorRespuesta
        mynewactividad.puntosTotales = myactividad.puntosTotales
        mynewactividad.tiempoEnMinutos = myactividad.tiempoEnMinutos
        mynewactividad.numeroSecciones = myactividad.numeroSecciones
        mynewactividad.status = myactividad.numeroSecciones
        mynewactividad.status = myactividad.status
        mynewactividad.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        mynewactividad.fechaCreacion = Date.Now
        mynewactividad.Tags = myactividad.Tags
        mynewactividad.TipoX = myactividad.TipoX
        mynewactividad.Objetivo = myactividad.Objetivo
        ' mynewactividad.idRubrica = myactividad.idr
        mynewactividad.Autoevaluacion = myactividad.Autoevaluacion
        mynewactividad.contestarSinAgenda = myactividad.contestarSinAgenda
        mynewactividad.activarBanco = myactividad.activarBanco
        mynewactividad.totalPreguntas = myactividad.totalPreguntas
        mynewactividad.presentacionAleatoria = myactividad.presentacionAleatoria
        mynewactividad.ParaInstructor = myactividad.ParaInstructor
        mynewactividad.Add()

        If myactividad.comoSeCalifica = Contenidos.EComoSeCalifica.RubricaA Then
            Dim myrubLoop As New Lego.Rubrica
            Dim drRub As SqlClient.SqlDataReader = myrubLoop.GetDR(claveActividad)
            Dim myrub As Lego.Rubrica
            Do While drRub.Read
                myrub = New Lego.Rubrica
                myrub.idActividad = mynewactividad.id
                myrub.Titulo = drRub("Titulo")
                myrub.Val1 = CInt(drRub("Val1"))
                myrub.Val1Descripcion = drRub("Val1Descripcion")
                myrub.Val2 = CInt(drRub("Val2"))
                myrub.Val2Descripcion = drRub("Val2Descripcion")
                myrub.Val3 = CInt(drRub("Val3"))
                myrub.Val3Descripcion = drRub("Val3Descripcion")
                myrub.Val4 = CInt(drRub("Val4"))
                myrub.Val4Descripcion = drRub("Val4Descripcion")
                myrub.Eliminado = False
                myrub.Add()
            Loop
            drRub.Close()
        End If



        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Imagen")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Archivo")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Flash")
        grabarAdjunto(mynewactividad.id, mynewactividad.tipo, "Liga")


        'Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        'myci.idClasificacion = claveClasificacion
        'myci.idProc = mynewactividad.id
        'myci.procedencia = tipoObjeto.Actividad
        'myci.idRoot = claveRoot
        'myci.Add()


        If mynewactividad.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
            Dim mypreg As New Examenes.Pregunta
            Dim drPreguntas As System.Data.SqlClient.SqlDataReader = mypreg.GetDR(claveActividad, True)
            Dim mypregunta As Examenes.Pregunta
            Dim idOr_Seleccionado As Integer = 0

            Do While drPreguntas.Read
                idOr_Seleccionado = 0

                mypregunta = New Examenes.Pregunta()
                mypregunta.idActividad = mynewactividad.id
                mypregunta.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
                mypregunta.idOR = CInt(drPreguntas("idOR")) 'mismo valor en caso de FyV
                idOr_Seleccionado = CInt(drPreguntas("idOR"))
                mypregunta.tipoPregunta = CInt(drPreguntas("tipoPregunta"))
                mypregunta.enunciado = drPreguntas("enunciado")
                mypregunta.archivo = CInt(drPreguntas("archivo"))
                mypregunta.valor = CDec(drPreguntas("valor"))
                mypregunta.orden = CInt(drPreguntas("orden"))
                mypregunta.respuesta = drPreguntas("respuesta")
                mypregunta.Eliminado = CBool(drPreguntas("eliminado"))
                mypregunta.fileName = ""
                mypregunta.Add()

                If Not Convert.IsDBNull(drPreguntas("fileName")) Then
                    If drPreguntas("fileName") <> "" Then
                        Dim nombreOriginal As String = drPreguntas("fileName")
                        mypregunta.fileName = mypregunta.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                        mypregunta.Update()

                        Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & nombreOriginal
                        Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenes\" & mypregunta.fileName
                        File.Copy(fileOriginal, fileCopia)
                    End If
                End If

                Dim myOR As Examenes.OpcionRespuesta = New Examenes.OpcionRespuesta
                Dim drOpcionesRespuesta As System.Data.SqlClient.SqlDataReader = myOR.GetDR(CInt(drPreguntas("idPregunta")))
                Dim myOP As Examenes.OpcionPregunta = New Examenes.OpcionPregunta

                Do While drOpcionesRespuesta.Read
                    myOR = New Examenes.OpcionRespuesta
                    myOR.idPregunta = mypregunta.id
                    myOR.enunciado = drOpcionesRespuesta("enunciado")
                    myOR.archivo = CInt(drOpcionesRespuesta("archivo"))
                    myOR.fileName = ""
                    myOR.Add()


                    If Not Convert.IsDBNull(drOpcionesRespuesta("fileName")) Then
                        If drOpcionesRespuesta("fileName") <> "" Then
                            Dim nombreOriginal As String = drOpcionesRespuesta("fileName")
                            myOR.fileName = myOR.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                            myOR.Update()

                            Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                            Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                            File.Copy(fileOriginal, fileCopia)
                        End If
                    End If

                    If idOr_Seleccionado = CInt(drOpcionesRespuesta("idOR")) Then
                        mypregunta.idOR = myOR.id
                        mypregunta.Update()
                    End If


                    Dim drOpcionPregunta As System.Data.SqlClient.SqlDataReader = myOP.GetDR(CInt(drPreguntas("idPregunta")), CInt(drOpcionesRespuesta("idOR")))
                    Do While drOpcionPregunta.Read
                        myOP = New Examenes.OpcionPregunta
                        myOP.idOR = myOR.id
                        myOP.idPregunta = mypregunta.id
                        myOP.enunciado = drOpcionPregunta("enunciado")
                        myOP.archivo = 0
                        myOP.Eliminado = CBool(drOpcionPregunta("Eliminado"))
                        myOP.fileName = ""
                        myOP.Add()

                        If Not Convert.IsDBNull(drOpcionPregunta("fileName")) Then
                            If drOpcionPregunta("fileName") <> "" Then
                                Dim nombreOriginal As String = drOpcionPregunta("fileName")
                                myOP.fileName = myOP.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                                myOP.Update()

                                Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                                Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                                File.Copy(fileOriginal, fileCopia)
                            End If
                        End If


                    Loop
                    drOpcionPregunta.Close()






                Loop
                drOpcionesRespuesta.Close()


                'seccion para colocar preguntas sin seleccion
                Dim drOpcionPregunta2 As System.Data.SqlClient.SqlDataReader = myOP.GetDR(CInt(drPreguntas("idPregunta")), 0)
                Do While drOpcionPregunta2.Read
                    myOP = New Examenes.OpcionPregunta
                    myOP.idOR = 0
                    myOP.idPregunta = mypregunta.id
                    myOP.enunciado = drOpcionPregunta2("enunciado")
                    myOP.archivo = 0
                    myOP.Eliminado = CBool(drOpcionPregunta2("Eliminado"))
                    myOP.fileName = ""
                    myOP.Add()

                    If Not Convert.IsDBNull(drOpcionPregunta2("fileName")) Then
                        If drOpcionPregunta2("fileName") <> "" Then
                            Dim nombreOriginal As String = drOpcionPregunta2("fileName")
                            myOP.fileName = myOP.id & "." & nombreOriginal.Substring(nombreOriginal.LastIndexOf(".") + 1)
                            myOP.Update()

                            Dim fileOriginal As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & nombreOriginal
                            Dim fileCopia As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "examenes\imagenesopcionerespuesta\" & myOR.fileName
                            File.Copy(fileOriginal, fileCopia)
                        End If
                    End If


                Loop
                drOpcionPregunta2.Close()


            Loop
            drPreguntas.Close()

        End If


        Return mynewactividad.id

    End Function
    Function grabarContenido(claveContenido As Integer) As Integer

        Dim myCont As Contenidos.Contenido
        Dim myContTemp As New Contenidos.Contenido(claveContenido)


        myCont = New Contenidos.Contenido
        myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
        myCont.idTipoContenido = myContTemp.idTipoContenido
        myCont.titulo = myContTemp.titulo
        myCont.textoCorto = myContTemp.textoCorto
        myCont.textoLargo = myContTemp.textoLargo
        myCont.espacio = myContTemp.espacio
        myCont.nombreOriginal = myContTemp.nombreOriginal
        myCont.tipoArchivo = myContTemp.tipoArchivo
        myCont.extension = myContTemp.extension
        myCont.url = myContTemp.url
        myCont.fechaCreacion = Date.Now
        myCont.ancho = myContTemp.ancho
        myCont.alto = myContTemp.alto
        myCont.Tags = myContTemp.Tags
        myCont.youtubeID = myContTemp.youtubeID
        myCont.ParaInstructor = myContTemp.ParaInstructor
        myCont.Add()

        Dim pathArchivos As String = ConfigurationManager.AppSettings("carpetaArchivos")
        If File.Exists(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension) Then
            File.Copy(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension, pathArchivos & "files\" & myCont.id & "." & myCont.extension)
        End If

        grabarAdjunto(myCont.id, myCont.tipo, "Imagen")
        grabarAdjunto(myCont.id, myCont.tipo, "Archivo")
        grabarAdjunto(myCont.id, myCont.tipo, "Flash")
        grabarAdjunto(myCont.id, myCont.tipo, "Liga")


        'Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
        'myci.idClasificacion = CInt(drpUbicacion.SelectedValue)
        'myci.idProc = myCont.id
        'myci.procedencia = tipoObjeto.Contenido
        'myci.idRoot = CInt(Request("idRoot"))
        'myci.Add()

        Return myCont.id

    End Function
    Function grabarForo(claveForo As Integer) As Integer
        Dim myf As New Contenidos.Foro(claveForo)
        Dim myfnew As New Contenidos.Foro
        myfnew.titulo = myf.titulo
        myfnew.texto = myf.texto
        myfnew.fechaCreacion = Date.Now
        myfnew.autor = myf.autor
        myfnew.idUserProfile = myf.idUserProfile
        myfnew.Objetivo = myf.Objetivo
        myfnew.Add()


        Return myfnew.id


    End Function

    Function grabarAdjunto(ByVal claveidproce As Integer, ByVal claveproce As String, ByVal clavetipo As String) As Integer
        Dim myAdjuntos As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto
        Dim dr As System.Data.SqlClient.SqlDataReader

        Select Case clavetipo
            Case "Imagen"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Imagen)
            Case "Archivo"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Archivo)
            Case "Flash"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Flash)
            Case "Liga"
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Liga)
            Case Else
                dr = myAdjuntos.GetDR(claveidproce, claveproce, Contenidos.TipoContenido.Archivo)
        End Select


        Dim pathArchivos As String = ConfigurationManager.AppSettings("carpetaArchivos")

        Do While dr.Read
            Dim myCA As Contenidos.ContenidoAdjunto
            Dim myCont As Contenidos.Contenido
            Dim myContTemp As New Contenidos.Contenido(CInt(dr("idContenido")))


            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myCont.idTipoContenido = myContTemp.idTipoContenido
            myCont.titulo = myContTemp.titulo
            myCont.textoCorto = myContTemp.textoCorto
            myCont.textoLargo = myContTemp.textoLargo
            myCont.espacio = myContTemp.espacio
            myCont.nombreOriginal = myContTemp.nombreOriginal
            myCont.tipoArchivo = myContTemp.tipoArchivo
            myCont.extension = myContTemp.extension
            myCont.url = myContTemp.url
            myCont.fechaCreacion = Date.Now
            myCont.ancho = myContTemp.ancho
            myCont.alto = myContTemp.alto
            myCont.Tags = myContTemp.Tags
            myCont.youtubeID = myContTemp.youtubeID
            myCont.ParaInstructor = myContTemp.ParaInstructor
            myCont.Add()


            If File.Exists(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension) Then
                File.Copy(pathArchivos & "files\" & myContTemp.id & "." & myCont.extension, pathArchivos & "files\" & myCont.id & "." & myCont.extension)
            End If

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = CInt(dr("idProc"))
            myCA.Procedencia = dr("procedencia")
            myCA.idContenido = myCont.id
            myCA.Add()


        Loop
        dr.Close()


        Return 1
    End Function


    Protected Sub lnkBorrarVideo_Click(sender As Object, e As EventArgs) Handles lnkBorrarVideo.Click
        Dim mye As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        mye.videoDisplay = ""
        mye.Update()

        Response.Redirect("AddSalonVirtual.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Function getNameFile(file1 As FileUpload, tipo As String) As String
        If file1.HasFile Then
            Dim fechaActual As DateTime = Date.Now

            Dim claveidexpediente As String = Guid.NewGuid.ToString()
            Dim namefile As String = tipo & "_" & claveidexpediente.Substring(0, 8) & "_" & fechaActual.Year & fechaActual.Month & fechaActual.Day & fechaActual.Hour & fechaActual.Minute & fechaActual.Second & "." & file1.PostedFile.FileName.Substring((file1.PostedFile.FileName.LastIndexOf(".") + 1))
            file1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaLocalFiles") & "images\salonesVirtuales\" & namefile)

            Return namefile

        Else
            Return ""

        End If
    End Function


End Class
