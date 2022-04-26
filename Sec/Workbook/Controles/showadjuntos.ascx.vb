Imports System.Data

Partial Class Sec_Workbook_Controles_showadjuntos
	Inherits System.Web.UI.UserControl

	Public tipoAdjunto As Contenidos.TipoContenido
	Public idProc As Integer
	Public procedencia As String
	Public idRoot As Integer
	Public idClasificacion As Integer
    Private cadena As String
    Private cadenaLink As String

    Public idClasificacionItem As String = ""
    Public idContenidoCadena As String = ""

    Public idSalon As String = ""
    Public claveSalon As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadena = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/showfile.aspx?idCont="
        ' cadena = HttpContext.Current.Request.ApplicationPath & "/sec/showfile.aspx?idCont="


        cadenaLink = "~/sec/SalonVirtual/"

        If Request("idCI") <> "" Then
            idClasificacionItem = "&idCI=" & Request("idCI")
        End If
        If Request("idSalonVirtual") <> "" Then
            idSalon = "&idSalonVirtual=" & Request("idSalonVirtual")

        End If
        If Request("idClasificacion") <> "" Then
            idClasificacion = Request("idClasificacion")
        End If
        If Request("idRoot") <> "" Then
            idRoot = Request("idRoot")
        End If


        Select Case tipoAdjunto
            Case Contenidos.TipoContenido.Archivo
                lblTitulo.Text = "Archivos adjuntos"
            Case Contenidos.TipoContenido.Articulate
                lblTitulo.Text = "Articulate"
            Case Contenidos.TipoContenido.Flash
                lblTitulo.Text = "Archivos flash"
            Case Contenidos.TipoContenido.Imagen
                lblTitulo.Text = "Imágenes"
            Case Contenidos.TipoContenido.Liga
                lblTitulo.Text = "Sitios sugeridos"
            Case Contenidos.TipoContenido.Texto
                lblTitulo.Text = "Contenidos adjuntos"
            Case Contenidos.TipoContenido.Video
                lblTitulo.Text = "Videos sugeridos"

        End Select
        If Not IsPostBack Then
			llenarDatos()
		End If
	End Sub

	Sub llenarDatos()
		Dim objContenidoAdjunto As New Contenidos.ContenidoAdjunto
		Dim ds As Data.DataSet

        If Not IsNothing(procedencia) Then
            Select Case procedencia
                Case "Clasificacion"
                    ds = objContenidoAdjunto.GetDSClasificacion(idRoot, idClasificacion, tipoAdjunto)
                    '  lblprueba.Text &= "-" & idRoot & "-" & idClasificacion & "-" & tipoAdjunto
                    ' lblprueba.Visible = True
                Case Else
                    ds = objContenidoAdjunto.GetDS(idProc, procedencia, tipoAdjunto)
                    Dim mycix As New Lego.ClasificacionItem(CInt(Request("idCI")))
                    idRoot = mycix.idRoot
                    idClasificacion = mycix.idClasificacion


            End Select

            'Select Case tipoAdjunto
            '    Case Contenidos.TipoContenido.Archivo
            '        lblTitulo.Text = "ARCHIVOS ADJUNTOS"
            '    Case Contenidos.TipoContenido.Liga
            '        lblTitulo.Text = "SITIOS SUGERIDOS"
            '    Case Contenidos.TipoContenido.Imagen
            '        lblTitulo.Text = "IMÁGENES"
            '    Case Contenidos.TipoContenido.Flash
            '        lblTitulo.Text = "PELÍCULAS FLASH"
            '    Case Else
            '        lblTitulo.Text = tipoAdjunto.ToString
            'End Select
            Dim dv As DataView = ds.Tables(0).DefaultView
            dv.Sort = "Titulo asc"

            listViewAdjuntos.DataSource = dv
            listViewAdjuntos.DataBind()

            If ds.Tables(0).Rows.Count > 0 Then
                panelbox.visible = True
            Else
                panelbox.visible = False
            End If
        End If
		

		'DtlAdjuntos.DataSource = ds
		'DtlAdjuntos.DataBind()

		'Try
		'	If DtlAdjuntos.Items.Count > 0 Then
		'		DtlAdjuntos.Visible = True
		'		lblNoData.Visible = False
		'	Else
		'		DtlAdjuntos.Visible = False
		'		lblNoData.Visible = True
		'	End If
		'Catch ex As Exception
		'End Try
	End Sub

    'Private Sub DtlAdjuntos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DtlAdjuntos.ItemDataBound

    '	Dim objItemType As ListItemType = CType(e.Item.ItemType, ListItemType)
    '	If objItemType = ListItemType.Item Or objItemType = ListItemType.AlternatingItem Then
    '		Dim objRowValores As DataRowView = CType(e.Item.DataItem, DataRowView)
    '		Dim idContenido As Integer = CType(objRowValores("idContenido"), Integer)
    '		Dim titulo As String = CType(objRowValores("titulo"), String)
    '		Dim myLink As New HyperLink
    '		myLink.Text = titulo
    '		myLink.NavigateUrl = cadena & idContenido

    '		Select Case tipoAdjunto
    '			Case Contenidos.TipoContenido.Imagen
    '				Dim myImagen As New System.Web.UI.WebControls.Image
    '				myImagen.Width = System.Web.UI.WebControls.Unit.Pixel(100)
    '				myImagen.ImageUrl = cadena & idContenido

    '				Dim myLit As New Literal
    '				myLit.Text = "<br>"

    '				e.Item.Controls.Add(myLink)
    '				e.Item.Controls.Add(myLit)
    '				e.Item.Controls.Add(myImagen)

    '			Case Contenidos.TipoContenido.Archivo
    '				e.Item.Controls.Add(myLink)

    '			Case Contenidos.TipoContenido.Flash
    '				e.Item.Controls.Add(myLink)

    '			Case Contenidos.TipoContenido.Liga
    '				myLink.NavigateUrl = CType(objRowValores("url"), String)
    '				myLink.Target = "_blank"
    '				e.Item.Controls.Add(myLink)
    '		End Select

    '	End If
    'End Sub

    Protected Sub listViewAdjuntos_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles listViewAdjuntos.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim objRowValores As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim idContenido As Integer = CType(objRowValores("idContenido"), Integer)
            Dim titulo As String = CType(objRowValores("titulo"), String)
            Dim myLink As New HyperLink
            myLink.Text = titulo
            myLink.NavigateUrl = cadena & idContenido
            myLink.CssClass = "btn-link"

            Dim mylnkFlechita As New Image
            mylnkFlechita.ImageUrl = "~/images/bull-arrow3.png"



            Try
                idContenidoCadena = "&idContenido=" & objRowValores("idContenido")
            Catch ex As Exception

            End Try

            Try
                idClasificacionItem = "&idCI=" & objRowValores("idClasificacionItem")
            Catch ex As Exception
                If Request("idCI") <> "" Then
                    idClasificacionItem = "&idCI=" & Request("idCI")
                End If
            End Try

            Try
                If idClasificacion = 0 Then
                    idClasificacion = objRowValores("idClasificacion")
                End If
            Catch ex As Exception
                idClasificacion = 0
            End Try


            Try
                If idRoot = 0 Then
                    idRoot = CInt(objRowValores("idRoot"))
                End If
            Catch ex As Exception
                idRoot = 0
            End Try


            Dim holder As PlaceHolder = CType(e.Item.FindControl("holder"), PlaceHolder)
            Dim myLit As New Literal
            myLit.Text = "<br>"

            Select Case tipoAdjunto
                Case Contenidos.TipoContenido.Imagen
                    Dim myImagen As New System.Web.UI.WebControls.Image
                    myLink.ImageWidth = System.Web.UI.WebControls.Unit.Pixel(100)
                    myLink.ImageUrl = cadena & idContenido
                    myLink.NavigateUrl = cadenaLink & "verImagen.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & idClasificacionItem & idSalon & idContenidoCadena

                    ' holder.Controls.Add(myLink)
                    holder.Controls.Add(New LiteralControl("<div style=""text-align:center; margin-bottom:6px;"">"))
                    holder.Controls.Add(myLink)
                    holder.Controls.Add(New LiteralControl("</div>"))

                Case Contenidos.TipoContenido.Archivo


                    Dim imagenparaMostrar As String = getImagen(1, objRowValores("Extension"), "Contenido")
                    mylnkFlechita.ImageUrl = imagenparaMostrar
                    mylnkFlechita.Height = System.Web.UI.WebControls.Unit.Pixel(25)


                    myLink.NavigateUrl = cadenaLink & "verArchivo.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & idClasificacionItem & idSalon & idContenidoCadena
                    If procedencia = "Contenido" Then
                        If imagenparaMostrar = "~/images/iconsDiamante/iconPDF.jpg" Then
                            myLink.NavigateUrl = "~/sec/salonVirtual/windows/pdf.aspx?idCont=" & idContenido
                            myLink.CssClass = "ventanaSuper"
                        Else
                            myLink.NavigateUrl = cadena & idContenido
                        End If

                    End If

                    holder.Controls.Add(mylnkFlechita)
                    holder.Controls.Add(myLink)
                    holder.Controls.Add(myLit)
                    holder.Controls.Add(New LiteralControl("<div style=""height:4px;""></div>"))

                Case Contenidos.TipoContenido.Flash
                    holder.Controls.Add(mylnkFlechita)

                    holder.Controls.Add(myLink)
                    holder.Controls.Add(myLit)
                    holder.Controls.Add(New LiteralControl("<div style=""height:4px;""></div>"))

                Case Contenidos.TipoContenido.Liga
                    myLink.NavigateUrl = CType(objRowValores("url"), String)
                    myLink.Target = "_blank"
                    holder.Controls.Add(mylnkFlechita)
                    holder.Controls.Add(myLink)
                    holder.Controls.Add(myLit)
                    holder.Controls.Add(New LiteralControl("<div style=""height:4px;""></div>"))


                Case Contenidos.TipoContenido.Articulate
                    Dim imagenparaMostrar As String = getImagen(1, objRowValores("Extension"), "Articulate")
                    mylnkFlechita.ImageUrl = imagenparaMostrar
                    mylnkFlechita.Height = System.Web.UI.WebControls.Unit.Pixel(25)

                    myLink.NavigateUrl = cadenaLink & "VerTexto.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & idClasificacionItem & idSalon & idContenidoCadena


                    holder.Controls.Add(mylnkFlechita)
                    holder.Controls.Add(myLink)
                    holder.Controls.Add(myLit)
                    holder.Controls.Add(New LiteralControl("<div style=""height:4px;""></div>"))

                Case Contenidos.TipoContenido.Texto


                    Dim imagenparaMostrar As String = getImagen(1, objRowValores("Extension"), "Contenido")
                    mylnkFlechita.ImageUrl = imagenparaMostrar
                    mylnkFlechita.Height = System.Web.UI.WebControls.Unit.Pixel(25)

                    myLink.NavigateUrl = cadenaLink & "VerTexto.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & idClasificacionItem & idSalon & idContenidoCadena


                    holder.Controls.Add(mylnkFlechita)
                    holder.Controls.Add(myLink)
                    holder.Controls.Add(myLit)
                    holder.Controls.Add(New LiteralControl("<div style=""height:4px;""></div>"))
            End Select


        End If

    End Sub


    Protected Function getImagen(claveTipo As Integer, claveExtension As String, clavetipoAnexo As String) As String

        Dim imagen As String = "~/images/iconsDiamante/iconTexto.jpg"
        Select Case clavetipoAnexo
            Case "Articulate"
                imagen = "~/images/iconsDiamante/iconArticulate.jpg"
            Case "Contenido"

                Select Case claveExtension
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

            Case "Actividad"
                imagen = "~/images/iconsDiamante/iconActividad.jpg"
            Case "Examen"
                imagen = "~/images/iconsDiamante/iconExamen.jpg"
            Case "Foro"
                imagen = "~/images/iconsDiamante/iconForos.jpg"
        End Select




        Return imagen

    End Function


    Protected Function getVentana(claveTipo As Integer, claveExtension As String, clavetipoAnexo As String) As String

        Dim css As String = ""
        Select Case clavetipoAnexo
            Case "Articulate"
                css = ""
            Case "Contenido"

                Select Case claveExtension
                    Case "swf"
                        css = ""
                    Case "ppt", "pptx"
                        css = "~/images/iconsDiamante/iconPresentacion.jpg"
                    Case "bmp", "gif", "jpeg", "jpg"
                        css = ""
                    Case "xls", "xlsx"
                        css = "~/images/iconsDiamante/iconExcel.jpg"
                    Case "doc", "docx"
                        css = "~/images/iconsDiamante/iconWord.jpg"
                    Case "mdb", "mdbx"
                        css = ""
                    Case "mp3"
                        css = ""
                    Case "rar"
                        css = ""
                    Case "zip"
                        css = ""
                    Case "txt"
                        css = "~/images/iconsDiamante/iconTexto.jpg"
                    Case "pdf"
                        css = "~/images/iconsDiamante/iconPDF.jpg"
                    Case ""
                        css = ""
                    Case Else
                        css = ""
                End Select

            Case "Actividad"
                css = ""
            Case "Examen"
                css = ""
            Case "Foro"
                css = ""
        End Select




        Return css

    End Function

End Class
