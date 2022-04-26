Imports System.Data.SqlClient


Partial Class Sec_SalonVirtual_Controles_DisplayExploradorContenidos
    Inherits System.Web.UI.UserControl
    Dim root As Integer = 0
    Dim expandirNodo As TreeNode


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        root = mysalon.idRoot

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


        Dim dsFolders As System.Data.DataSet = myclasificacion.GetDSRaizRoot(0, root, True)
        Dim dt As System.Data.DataTable = dsFolders.Tables(0)

        populateNodes(dt, tvFolders.Nodes)

        Return 1
    End Function

    Public Function populateNodes(ByVal dt As System.Data.DataTable, ByVal nodes As TreeNodeCollection) As Integer

        For Each dr As Data.DataRow In dt.Rows
            Dim nodocarpeta As TreeNode = New TreeNode
            nodocarpeta.Text = dr("Titulo")
            nodocarpeta.Value = dr("idClasificacion")
			nodocarpeta.ImageUrl = "~/images/MiniIconFolder.jpg"
            nodocarpeta.NavigateUrl = "~/sec/salonvirtual/verCarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & dr("idClasificacion")




            nodes.Add(nodocarpeta)



            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem()
            Dim myc As New Lego.Clasificacion(CInt(dr("idClasificacion")))

            nodocarpeta.PopulateOnDemand = (myci.Count(CInt(dr("idClasificacion"))) > 0) Or (myc.Count() > 0)
        Next



        Return 1
    End Function

    Public Function PopulateSubLevel(ByVal parentid As Integer, ByVal parentnode As TreeNode) As Integer

        Dim myclasificacion As Lego.Clasificacion = New Lego.Clasificacion()
        Dim dsFolders As System.Data.DataSet = myclasificacion.GetDSRaizRoot(parentid, root, True)
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
                            url = "~/sec/salonvirtual/verArchivo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")
                        Case Contenidos.TipoContenido.Flash
                            url = "~/sec/salonvirtual/verFlash.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")
                        Case Contenidos.TipoContenido.Imagen
                            url = "~/sec/salonvirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")
                        Case Contenidos.TipoContenido.Texto
                            url = "~/sec/salonvirtual/verTexto.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")

                    End Select


                    Select Case mycont.extension.ToLower
                        Case "swf"
							imagen = "~/images/miniiconflash.gif"
						Case "ppt", "pptx"
							imagen = "~/images/miniiconpower.jpg"
						Case "bmp", "gif", "jpg", "jpeg"
							imagen = "~/images/miniIconImagenes.gif"
						Case "xls", "xlsx"
							imagen = "~/images/miniiconExcel.jpg"
						Case "doc", "docx"
							imagen = "~/images/miniiconword.jpg"
						Case "mdb", "mdbx"
							imagen = "~/images/miniIconAccess.jpg"
						Case "mp3"
							imagen = "~/images/MiniIconMP3.jpg"
						Case "rar"
							imagen = "~/images/miniIconRAR.jpg"
						Case "zip"
							imagen = "~/images/miniIconZIP.jpg"
						Case "txt"
							imagen = "~/images/miniIconTexto.gif"
						Case "pdf"
							imagen = "~/images/MiniIconAcrobatReader.jpg"
						Case Else
							imagen = "~/images/MiniIconTexto.gif"
					End Select
				Case tipoObjeto.Actividad.ToString
					Dim myact As Contenidos.Actividad = New Contenidos.Actividad(CInt(drHijos("idProc")))
					nombre = myact.titulo
					Select Case myact.tipodeActividad
						Case Contenidos.ETipodeActividad.Actividad
							url = "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")
						Case Contenidos.ETipodeActividad.Examen
							url = "~/sec/salonvirtual/verExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")
					End Select
					Select Case myact.tipodeActividad
						Case Contenidos.ETipodeActividad.Actividad
							imagen = "~/images/miniIconActvs.gif"
						Case Contenidos.ETipodeActividad.Examen
							imagen = "~/images/miniIconExam.gif"
					End Select

				Case tipoObjeto.Foro.ToString
					Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(drHijos("idProc")))
					nombre = myf.titulo
					imagen = "~/images/miniIconForo.gif"
                    url = "~/sec/salonvirtual/verForo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & drHijos("idClasificacionItem")

            End Select
            Dim nodocontenido As TreeNode = New TreeNode(nombre, drHijos("idClasificacion"), imagen, url, "")
            parentnode.ChildNodes.Add(nodocontenido)




        Loop
        drHijos.Close()




        Return 1
    End Function


    Protected Sub tvFolders_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles tvFolders.TreeNodePopulate
        PopulateSubLevel(CInt(e.Node.Value), e.Node)
    End Sub
End Class
