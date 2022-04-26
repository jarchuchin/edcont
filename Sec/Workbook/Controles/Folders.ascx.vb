Imports System.Data
Imports System.Data.SqlClient

Partial Class Sec_Workbook_Controles_Folders
    Inherits System.Web.UI.UserControl

    Public idRoot As Integer = 0
    Public idRaiz As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clasificacion As Integer = 0
            If Request("idClasificacion") <> "" Then
                clasificacion = CInt(Request("idClasificacion"))
            End If
            llenarLista(CInt(Request("idRoot")), clasificacion)
        End If
    End Sub

    Sub llenarLista(ByVal claveroot As Integer, ByVal claveRaiz As Integer)
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        dtlFolders.DataSource = tablaBrowser(claveroot, claveRaiz)
        dtlFolders.DataBind()
        Mapa(claveroot, claveRaiz)

        If claveRaiz > 0 Then
            colocarDatosEdicion(claveRaiz)
            PanelIcons.Visible = True
        Else
            PanelIcons.Visible = False
            limpiar()
        End If

    End Sub

    Sub limpiar()
        txtTitulo.Text = ""
        hdClave.Value = ""
        PanelEdicion.Visible = False
    End Sub

    Sub colocarDatosEdicion(ByVal ClaveRaiz As Integer)
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion(ClaveRaiz)
        txtTitulo.Text = myc.titulo
        hdClave.Value = myc.id
        hdClasif.Value = myc.id
    End Sub

    Public Function Mapa(ByVal claveRoot As Integer, ByVal claveClasif As Integer) As Integer
        Dim myroot As Lego.Root = New Lego.Root(claveRoot)
        If claveClasif > 0 Then
            lnkMapa1.Text = myroot.titulo
            Dim myclas As Lego.Clasificacion = New Lego.Clasificacion(claveClasif)
            lblCarpetaActual.Text = myclas.titulo
            If myclas.idRaiz > 0 Then
                Dim myclas2 As Lego.Clasificacion = New Lego.Clasificacion(myclas.idRaiz)
                lnkMapa2.Text = myclas2.titulo
                lnkMapa2.Visible = True
                lblflecha.Visible = True
            Else
                lnkMapa2.Visible = False
                lblflecha.Visible = False
            End If

            lnkMapa1.Visible = True
            lblflecha0.Visible = True
            lblCarpetaActual.Visible = True
        Else
            lnkMapa1.Text = myroot.titulo
            lblCarpetaActual.Visible = False
            lnkMapa1.Visible = True
            lblflecha.Visible = False
            lblflecha0.Visible = False
            lnkMapa2.Visible = False
        End If
        Return 1
    End Function

    Public Function tablaBrowser(ByVal claveRoot As Integer, ByVal claveRaiz As Integer) As DataTable

        Dim dTable As New DataTable
        dTable.Columns.Add(New DataColumn("id", GetType(Integer)))
        dTable.Columns.Add(New DataColumn("tipo", GetType(String)))
        dTable.Columns.Add(New DataColumn("imagen", GetType(String)))
        dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
        dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
        Dim dRow As DataRow

        Dim myc As Lego.Clasificacion = New Lego.Clasificacion
        Dim dr As SqlDataReader = myc.GetDRRaizRoot(claveRaiz, claveRoot)

        Do While dr.Read
            dRow = dTable.NewRow()
            dRow(0) = CType(dr("idClasificacion"), Integer)
            dRow(1) = "Folder"
            myc = New Lego.Clasificacion(CType(dr("idClasificacion"), Integer))
            If Not myc.EnUso(True) Then
                dRow(2) = "FolderVacio.gif"
            Else
                dRow(2) = "Folderlleno.gif"
            End If
            dRow(3) = myc.titulo
            dRow(4) = CType(dr("idClasificacion"), Integer)
            dTable.Rows.Add(dRow)
        Loop

        If claveRaiz > 0 Then
            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem
            dr = myci.GetDR(claveRaiz, ordenamiento.ASC)

            Do While dr.Read
                dRow = dTable.NewRow()
                dRow(0) = CType(dr("idClasificacionItem"), Integer)
                Select Case CType([Enum].Parse(GetType(tipoObjeto), CStr(dr("procedencia"))), tipoObjeto)
                    Case tipoObjeto.Contenido
                        Dim myContenido As New Contenidos.Contenido(CType(dr("idProc"), Integer))
                        Select Case myContenido.idTipoContenido
                            Case Contenidos.TipoContenido.Archivo
                                dRow(2) = "FolderArchivo.gif"
                                dRow(1) = "Archivo"
                            Case Contenidos.TipoContenido.Imagen
                                dRow(2) = "FolderImagen.gif"
                                dRow(1) = "Imagen"
                            Case Contenidos.TipoContenido.Liga
                            Case Contenidos.TipoContenido.Texto
                                dRow(2) = "FolderTexto.gif"
                                dRow(1) = "Texto"
                            Case Contenidos.TipoContenido.Flash
                                dRow(2) = "FolderFlash.gif"
                                dRow(1) = "Flash"
                        End Select
                        dRow(3) = myContenido.titulo
                    Case tipoObjeto.Actividad

                        Dim myActividad As New Contenidos.Actividad(CType(dr("idProc"), Integer))
                        Select Case myActividad.tipodeActividad
                            Case Contenidos.ETipodeActividad.Actividad
                                dRow(1) = "Actividad"
                                dRow(2) = "FolderActividad.gif"
                            Case Contenidos.ETipodeActividad.Examen
                                dRow(1) = "Examen"
                                dRow(2) = "FolderExamen.gif"
                        End Select
                        dRow(3) = myActividad.titulo
                    Case tipoObjeto.Foro
                        dRow(1) = "Foro"
                        Dim myForo As New Contenidos.Foro(CType(dr("idProc"), Integer))
                        dRow(2) = "FolderForo.gif"
                        dRow(3) = myForo.titulo
                End Select
                dRow(4) = CType(dr("idClasificacion"), Integer)
                dTable.Rows.Add(dRow)
            Loop
        End If
        Return dTable

    End Function


    Protected Sub dtlFolders_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlFolders.ItemCommand
        Dim words As String = e.CommandArgument.ToString
        Dim split As String() = words.Split(",")

        Select Case split(1)
            Case "Folder"
                llenarLista(CInt(Request("idRoot")), CInt(split(0)))
            Case Else
                Dim direc As String = ""
                Select Case split(1)
                    Case "Texto"
                        direc = "Texto.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Archivo"
                        direc = "Archivo.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Imagen"
                        direc = "Imagen.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Flash"
                        direc = "Flash.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Actividad"
                        direc = "Actividad.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Examen"
                        direc = "Examen.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                    Case "Foro"
                        direc = "Foro.aspx?idRoot=" & Request("idRoot") & "&idCI=" & split(0).ToString & "&Proc=" & split(1).ToString & "&idClasificacion=" & split(2).ToString
                End Select

                Response.Redirect(direc)
        End Select
    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If hdClave.Value <> "" Then
            editar()
        Else
            grabar()
        End If

        PanelEdicion.Visible = False
    End Sub

    Sub editar()
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion(CInt(hdClave.Value))
        myc.titulo = txtTitulo.Text
        myc.Update()
        llenarLista(myc.idRoot, myc.id)
    End Sub
    Sub grabar()
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion()
        myc.titulo = txtTitulo.Text
        If CInt(hdClasif.Value) > 0 Then
            myc.idRaiz = CInt(hdClasif.Value)
        Else
            myc.idRaiz = 0
        End If
        myc.idRoot = CInt(Request("idRoot"))
        myc.status = True
        myc.Add()
        llenarLista(myc.idRoot, myc.id)
    End Sub

    Protected Sub btnborrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnborrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim myc As Lego.Clasificacion = New Lego.Clasificacion(CInt(hdClave.Value))
        If myc.SePuedeBorrar Then
            myc.Remove()
            llenarLista(myc.idRoot, myc.idRaiz)
        Else
            lblmensajeBorrar.Visible = False
        End If


    End Sub

    Protected Sub lnkMapa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMapa1.Click
        If hdClasif.Value <> "" Then
            Dim myc As Lego.Clasificacion = New Lego.Clasificacion(CInt(hdClasif.Value))
            llenarLista(myc.idRoot, 0)
        End If

    End Sub

    Protected Sub lnkMapa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMapa2.Click
        If hdClasif.Value <> "" Then
            Dim myc As Lego.Clasificacion = New Lego.Clasificacion(CInt(hdClasif.Value))
            llenarLista(myc.idRoot, myc.idRaiz)
        End If
    End Sub

    Protected Sub ibNuevoFolder_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibNuevoFolder.Click
        PanelEdicion.Visible = True
        txtTitulo.Text = ""
        hdClave.Value = ""
    End Sub

    Protected Sub ibEditarFolder_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibEditarFolder.Click
        colocarDatosEdicion(CInt(hdClasif.Value))
        PanelEdicion.Visible = True
    End Sub

    Protected Sub ibLectura_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibLectura.Click
        Dim direc As String = "Texto.aspx?idRoot=" & Request("idRoot") & "&Proc=Texto&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibArchivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibArchivo.Click
        Dim direc As String = "Archivo.aspx?idRoot=" & Request("idRoot") & "&Proc=Archivo&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibImagen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibImagen.Click
        Dim direc As String = "Imagen.aspx?idRoot=" & Request("idRoot") & "&Proc=Imagen&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibFlash_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibFlash.Click
        Dim direc As String = "Flash.aspx?idRoot=" & Request("idRoot") & "&Proc=Flash&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibActividad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActividad.Click
        Dim direc As String = "Actividad.aspx?idRoot=" & Request("idRoot") & "&Proc=Actividad&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibExamen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibExamen.Click
        Dim direc As String = "Examen.aspx?idRoot=" & Request("idRoot") & "&Proc=Examen&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub

    Protected Sub ibForo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibForo.Click
        Dim direc As String = "Foro.aspx?idRoot=" & Request("idRoot") & "&Proc=Foro&idClasificacion=" & hdClave.Value.ToString
        Response.Redirect(direc)
    End Sub
End Class
