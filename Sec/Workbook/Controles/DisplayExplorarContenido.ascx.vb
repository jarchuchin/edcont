Imports System.Data.SqlClient

Partial Class Sec_Workbook_Controles_DisplayExplorarContenido
    Inherits System.Web.UI.UserControl
    Dim expandirNodo As TreeNode
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateRootLevel(tvFolders.Nodes)
        End If


        If Request("idClasificacion") <> "" Then
            Dim myclasif As Lego.Clasificacion = New Lego.Clasificacion()

            Dim cadena As String = myclasif.GetValuePath(CInt(Request("idClasificacion")), "")
            Dim arreglo As String() = cadena.Split("/")
            Dim i As Integer = 0
            cadena = ""
            For Each s As String In arreglo
                If cadena <> "" Then
                    cadena = cadena & "/" & s
                Else
                    cadena = s
                End If

                expandirNodo = tvFolders.FindNode(cadena)
                expandirNodo.Expand()
                tvFolders.DataBind()

            Next


        End If
    End Sub




    Function PopulateRootLevel(ByVal nodes As TreeNodeCollection) As Integer
        Dim myclasificacion As Lego.Clasificacion = New Lego.Clasificacion()

        Dim dsFolders As System.Data.DataSet = myclasificacion.GetDSRaizRoot(0, CInt(Request("idRoot")))
        Dim dt As System.Data.DataTable = dsFolders.Tables(0)

        populateNodes(dt, tvFolders.Nodes)

        Return 1
    End Function

    Public Function populateNodes(ByVal dt As System.Data.DataTable, ByVal nodes As TreeNodeCollection) As Integer

        For Each dr As Data.DataRow In dt.Rows
            Dim nodocarpeta As TreeNode = New TreeNode
            nodocarpeta.Text = dr("Titulo")
            nodocarpeta.Value = dr("idClasificacion")
            nodocarpeta.ImageUrl = "~/images/iconsDiamante/iconFolder.jpg"

            nodocarpeta.NavigateUrl = "~/sec/workbook/Carpeta.aspx?idRoot=" & dr("idRoot") & "&idClasificacion=" & dr("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"

            nodes.Add(nodocarpeta)

            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
            Dim myc As New Lego.Clasificacion(CInt(dr("idClasificacion")))

            nodocarpeta.PopulateOnDemand = (myci.Count(CInt(dr("idClasificacion"))) > 0) Or (myc.Count() > 0)
        Next



        Return 1
    End Function

    Public Function PopulateSubLevel(ByVal parentid As Integer, ByVal parentnode As TreeNode) As Integer

        Dim myclasificacion As Lego.Clasificacion = New Lego.Clasificacion()
        Dim dsFolders As System.Data.DataSet = myclasificacion.GetDSRaizRoot(parentid, CInt(Request("idRoot")))
        Dim dt As System.Data.DataTable = dsFolders.Tables(0)
        populateNodes(dt, parentnode.ChildNodes)

        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem
        Dim drHijos As SqlDataReader = myci.GetDR(parentid, ordenamiento.ASC)
        Dim nombre As String = ""
        Dim url As String = ""
        Dim imagen As String = ""


        Do While drHijos.Read

            Dim nodohijos As TreeNode = New TreeNode()
            nodohijos.Value = drHijos("idClasificacion")

            Select Case CType(drHijos("procedencia"), String)
                Case tipoObjeto.Contenido.ToString
                    Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(CInt(drHijos("idProc")))
                    nombre = mycont.titulo
                    Select Case mycont.idTipoContenido
                        Case Contenidos.TipoContenido.Archivo
                            url = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Archivo&idClasificacion=" & drHijos("idClasificacion") & "&display=file" & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                        Case Contenidos.TipoContenido.Flash
                            url = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Flash&idClasificacion=" & drHijos("idClasificacion") & "&display=file" & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                        Case Contenidos.TipoContenido.Imagen
                            url = "~/sec/workbook/AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Imagen&idClasificacion=" & drHijos("idClasificacion") & "&display=image" & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                        Case Contenidos.TipoContenido.Texto
                            url = "~/sec/workbook/addContenido.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Texto&idClasificacion=" & drHijos("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                        Case Else
                            url = mycont.idTipoContenido
                    End Select

                    Select Case mycont.extension.ToLower
                        Case "swf"
                            imagen = "~/images/iconsDiamante/iconVideo.jpg"
                        Case "ppt", "pptx"
                            imagen = "~/images/iconsDiamante/iconPresentacion.jpg"
                        Case "bmp", "gif", "jpeg", "jpg"
                            imagen = "~/images/iconsDiamante/iconImagen.jpg"
                        Case "xls", "xlsx"
                            imagen = "~/images/iconsDiamante/iconExcel.jpg"
                        Case "doc", "docx"
                            imagen = "~/images/iconsDiamante/iconWord.jpg"
                        Case "mdb", "mdbx"
                            imagen = "~/images/miniIconAccess.jpg"
                        Case "mp3"
                            imagen = "~/images/iconsDiamante/iconAudio.jpg"
                        Case "rar"
                            imagen = "~/images/iconsDiamante/iconZip.jpg"
                        Case "zip"
                            imagen = "~/images/iconsDiamante/iconZip.jpg"
                        Case "txt"
                            imagen = "~/images/iconsDiamante/iconTexto.jpg"
                        Case "pdf"
                            imagen = "~/images/iconsDiamante/iconPDF.jpg"
                        Case ""
                            imagen = "~/images/iconsDiamante/iconEditarTexto.jpg"
                        Case Else
                            imagen = "~/images/iconsDiamante/iconTexto.jpg"
                    End Select


                Case tipoObjeto.Actividad.ToString
                    Dim myact As Contenidos.Actividad = New Contenidos.Actividad(CInt(drHijos("idProc")))
                    nombre = myact.titulo
                    Select Case myact.tipodeActividad
                        Case Contenidos.ETipodeActividad.Actividad
                            url = "~/sec/workbook/Actividad.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Actividad&idClasificacion=" & drHijos("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                            imagen = "~/images/iconsDiamante/iconActividad.jpg"
                        Case Contenidos.ETipodeActividad.Examen
                            url = "~/sec/workbook/Examen.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Examen&idClasificacion=" & drHijos("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"
                            imagen = "~/images/iconsDiamante/iconExamen.jpg"
                    End Select


                Case tipoObjeto.Foro.ToString
                    Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(drHijos("idProc")))
                    nombre = myf.titulo
                    imagen = "~/images/iconsDiamante/iconForos.jpg"
                    url = "~/sec/workbook/Foro.aspx?idRoot=" & Request("idRoot") & "&idCI=" & drHijos("idClasificacionItem") & "&Proc=Texto&idClasificacion=" & drHijos("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&regreso=ex"

            End Select

            Dim nodocontenido As TreeNode = New TreeNode(nombre, drHijos("idClasificacion"), imagen, url, "")
            parentnode.ChildNodes.Add(nodocontenido)


            nombre = ""
            imagen = ""
            url = ""


        Loop
        drHijos.Close()




        Return 1
    End Function

    Public Function getURL(ByVal tipo As Contenidos.TipoContenido) As String



        Return ""
    End Function

    Protected Sub tvFolders_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles tvFolders.TreeNodePopulate
        PopulateSubLevel(CInt(e.Node.Value), e.Node)
    End Sub
End Class
