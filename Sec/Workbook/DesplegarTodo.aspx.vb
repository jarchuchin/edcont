Imports System.Data
Imports HiQPdf

Imports System.Configuration
Imports System.Collections
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls


Partial Class Sec_Workbook_DesplegarTodo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myr As New Lego.Root(Request("idRoot"))


        lblNombreDelLibro.Text = myr.titulo
        lblNombredelLibro2.Text = myr.titulo
        lblTitulobox.Text = myr.titulo


        lblautor.Text = myr.Autor
        '    lbldescripcion.Text = myr.descripcion.Replace(vbCrLf, "xxxxxxxxxxxxxxxx")
        lbldescripcion.Text = myr.descripcion.Replace(vbLf, "<br/>")
        lblbiblioteca.Text = myr.Biblioteca
        lbltags.Text = myr.Tags
        lblUltimaActualizacion.Text = myr.fechaUltimaActualizacion.ToShortDateString
        lblparainstructor.Text = myr.ParaInstructor.Replace(vbLf, "<br/>")
        lblConvenios.Text = myr.Convenios.Replace(vbLf, "<br/>")

        Dim myi As New Utilerias.Idioma(myr.idIdioma)
        lblIdioma.Text = myi.Nombre

        If myr.CertificacionDoc <> "" Then
            lnkcertificacion.Visible = True
            lnkcertificacion.NavigateUrl = myr.CertificacionDoc
            lnkcertificacion.Text = myr.CertificacionDoc

        Else
            lnkcertificacion.Visible = False
        End If


        Dim myclasif As New Lego.Clasificacion
        Dim dsfolders As DataSet = myclasif.GetDSRaizRoot(0, myr.id)

        dtlCapitulos.DataSource = dsfolders
        dtlCapitulos.DataBind()


        Dim ds As System.Data.DataSet = New Lego.Clasificacion().IndiceNested(CInt(Request("idRoot")), False)
        
        repeaterClasificaciones.DataSource = ds
        repeaterClasificaciones.DataBind()

    End Sub


    Public Function getObjetivos(claveClasificacion As Integer) As DataSet
        Dim myl As New Lego.Objetivo()
        Return myl.GetDS(claveClasificacion)
    End Function


    Public Function getObjetivo(claveobjetivo As Object) As String
        Dim cadena As String = ""

        If Not Convert.IsDBNull(claveobjetivo) Then
            Return Replace(claveobjetivo, vbCr, "<br/>")
        Else
            Return ""
        End If

        Return cadena
    End Function

    Protected Function getLinkAnexos(idRoot As Integer, idClasificacionItem As Integer, idClasificacion As Integer, tipoAnexo As String, idTipo As Integer) As String
        Dim filePath, file, proc As String

        filePath = "~/Sec/Workbook/"

        Select Case tipoAnexo
            Case "Contenido"
                'file = "Texto.aspx"
                file = "AddContenido.aspx"
                Select Case idTipo
                    Case Contenidos.TipoContenido.Archivo
                        proc = "Archivo"
                    Case Contenidos.TipoContenido.Flash
                        proc = "Flash"
                    Case Contenidos.TipoContenido.Imagen
                        proc = "Imagen"
                    Case Contenidos.TipoContenido.Texto
                        proc = "Contenido"
                End Select
            Case "Actividad"
                file = "Actividad.aspx"
                proc = "Actividad"
            Case "Examen"
                file = "Examen.aspx"
                proc = "Examen"
            Case "Foro"
                file = "Foro.aspx"
                proc = "Foro"
            Case Else
                file = "AddContenido.aspx"
                proc = "Contenido"
        End Select

        Return filePath & file & "?idRoot=" & idRoot & "&idCI=" & idClasificacionItem & "&idClasificacion=" & idClasificacion & "&proc=" & proc
    End Function

    Public Function getContenidos(claveClasificacion As Integer) As System.Data.SqlClient.SqlDataReader

        Dim myci As New Lego.ClasificacionItem
        Return myci.GetDR(claveClasificacion, ordenamiento.ASC)

    End Function

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    '    If Not IsPostBack Then
    '        dropDownListPageSizes.SelectedValue = "A4"
    '        dropDownListPageOrientations.SelectedValue = "Portrait"

    '        dropDownListTriggeringMode.SelectedValue = "WaitTime"
    '        panelWaitTime.Visible = True

    '        Master.SelectNode("htmlToPdf")
    '    End If
    'End Sub

    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        ' create the HTML to PDF converter
        Dim htmlToPdfConverter As New HtmlToPdf()

        ' set a demo serial number
        htmlToPdfConverter.SerialNumber = "i8Pi2tvv-7cfi6fnq-+fKzpbur-uqu6q7y4-vqu4uqW6-uaWysrKy" '"YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ=="

        ' set browser width
        htmlToPdfConverter.BrowserWidth = 1100

        ' set HTML Load timeout
        htmlToPdfConverter.HtmlLoadedTimeout = 340

        ' set PDF page size and orientation
        htmlToPdfConverter.Document.PageSize = PdfPageSize.Letter
        htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait

        ' set the PDF standard used by the document
       
            htmlToPdfConverter.Document.PdfStandard = PdfStandard.Pdf


        ' set PDF page margins
        htmlToPdfConverter.Document.Margins = New PdfMargins(5)

        ' set whether to embed the true type font in PDF
        htmlToPdfConverter.Document.FontEmbedding = True

        ' set triggering mode; for WaitTime mode set the wait time before convert
 
                htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto
           
        ' set header and footer
        SetHeader(htmlToPdfConverter.Document)
        SetFooter(htmlToPdfConverter.Document)

        ' set the document security
        htmlToPdfConverter.Document.Security.OpenPassword = ""
        htmlToPdfConverter.Document.Security.AllowPrinting = True

        ' set the permissions password too if an open password was set
        If htmlToPdfConverter.Document.Security.OpenPassword IsNot Nothing And htmlToPdfConverter.Document.Security.OpenPassword.Length > 0 Then
            htmlToPdfConverter.Document.Security.PermissionsPassword = htmlToPdfConverter.Document.Security.OpenPassword + "_admin"
        End If

        ' convert HTML to PDF
        Dim pdfBuffer() As Byte = Nothing


        ' convert URL to a PDF memory buffer

        Dim url As String = Request.Url.AbsoluteUri ' System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/workbook/DesplegarTodo.aspx?idRoot=" & Request("idRoot")

        pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url)
      

        ' inform the browser about the binary data format
        HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf")

        ' let the browser know how to open the PDF document, attachment or inline, and the file name
        Dim openMode As String = "attachment"
        'If (checkBoxOpenInline.Checked) Then
        '    openMode = "inline"
        'End If
        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=LibroDeTrabajoPdf_" & Request("idRoot") & ".pdf; size={1}", openMode, pdfBuffer.Length.ToString()))

        ' write the PDF buffer to HTTP response
        HttpContext.Current.Response.BinaryWrite(pdfBuffer)

        ' call End() method of HTTP response to stop ASP.NET page processing
        HttpContext.Current.Response.End()
    End Sub

    Private Sub SetHeader(ByVal htmlToPdfDocument As PdfDocumentControl)
        ' enable header display
        htmlToPdfDocument.Header.Enabled = True

        If Not htmlToPdfDocument.Header.Enabled Then
            Return
        End If

        ' set header height
        htmlToPdfDocument.Header.Height = 40

        Dim pdfPageWidth As Single = htmlToPdfDocument.PageSize.Width
        If (htmlToPdfDocument.PageOrientation = PdfPageOrientation.Landscape) Then
            pdfPageWidth = htmlToPdfDocument.PageSize.Height
        End If

        Dim headerWidth As Single = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right
        Dim headerHeight As Single = htmlToPdfDocument.Header.Height

        ' set header background color
        htmlToPdfDocument.Header.BackgroundColor = Drawing.Color.WhiteSmoke

        'Dim headerImageFile As String = Server.MapPath("~") & "Images\logo-Skolar.png"
        'Dim logoHeaderImage As New PdfImage(5, 5, 59, System.Drawing.Image.FromFile(headerImageFile))
        'htmlToPdfDocument.Header.Layout(logoHeaderImage)



        ' create a border for header

        'Dim borderRectangle As New PdfRectangle(1, 1, headerWidth - 2, headerHeight - 2)
        'borderRectangle.LineStyle.LineWidth = 0.5F
        'borderRectangle.ForeColor = Drawing.Color.Navy
        'htmlToPdfDocument.Header.Layout(borderRectangle)
    End Sub

    Private Sub SetFooter(ByVal htmlToPdfDocument As PdfDocumentControl)
        ' enable footer display
        htmlToPdfDocument.Footer.Enabled = True

        If Not htmlToPdfDocument.Footer.Enabled Then
            Return
        End If

        ' set footer height
        htmlToPdfDocument.Footer.Height = 30

        ' set footer background color
        htmlToPdfDocument.Footer.BackgroundColor = Drawing.Color.WhiteSmoke

        Dim pdfPageWidth As Single = htmlToPdfDocument.PageSize.Width
        If (htmlToPdfDocument.PageOrientation = PdfPageOrientation.Landscape) Then
            pdfPageWidth = htmlToPdfDocument.PageSize.Height
        End If

        Dim footerWidth As Single = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right
        Dim footerHeight As Single = htmlToPdfDocument.Footer.Height



        ' add page numbering
        Dim pageNumberingFont As New System.Drawing.Font(New System.Drawing.FontFamily("Arial"), 7, Drawing.FontStyle.Regular)
        Dim pageNumberingText As New PdfText(5, footerHeight - 25, "Página {CrtPage} de {PageCount}", pageNumberingFont)
        pageNumberingText.HorizontalAlign = PdfTextHAlign.Center
        pageNumberingText.EmbedSystemFont = True
        pageNumberingText.ForeColor = Drawing.Color.Black
        htmlToPdfDocument.Footer.Layout(pageNumberingText)

        'Dim footerImageFile As String = Server.MapPath("~") & "\DemoFiles\Images\HiQPdfLogo.png"
        'Dim logoFooterImage As New PdfImage(footerWidth - 40 - 5, 5, 40, System.Drawing.Image.FromFile(footerImageFile))
        'htmlToPdfDocument.Footer.Layout(logoFooterImage)

        ' create a border for footer
        'Dim borderRectangle As New PdfRectangle(1, 1, footerWidth - 2, footerHeight - 2)
        'borderRectangle.LineStyle.LineWidth = 0.5F
        'borderRectangle.ForeColor = System.Drawing.Color.DarkGreen
        'htmlToPdfDocument.Footer.Layout(borderRectangle)
    End Sub

    

    Protected Sub repeaterClasificaciones_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repeaterClasificaciones.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim dView As Data.DataView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionContenido")
            CType(e.Item.FindControl("listViewContenidos"), ListView).DataSource = dView
            CType(e.Item.FindControl("listViewContenidos"), ListView).DataBind()

            CType(e.Item.FindControl("listViewActividades"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionActividad")
            CType(e.Item.FindControl("listViewActividades"), ListView).DataBind()

            CType(e.Item.FindControl("listViewExamenes"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionExamen")
            CType(e.Item.FindControl("listViewExamenes"), ListView).DataBind()

            CType(e.Item.FindControl("listViewForos"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionForo")
            CType(e.Item.FindControl("listViewForos"), ListView).DataBind()
        End If

    End Sub
   
End Class

