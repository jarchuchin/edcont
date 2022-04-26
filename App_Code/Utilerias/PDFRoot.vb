Imports System
Imports System.Data.SqlClient
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports MigraDoc.Rendering
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports System.Data

Namespace Utilerias
    Public Class PDFRoot



        Private document As Document
        Private addressFrame As TextFrame
        Private table As Table
        Private tableDatos As Table
        Private TableBorder As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(0, 0, 0)
        Private TableHeader As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(252, 241, 177)
        Private TableColumnaTotal As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)
        Private idIdioma As Integer = 1

        Dim doqui As New PdfDocument
        Dim paginilla As PdfPage = doqui.AddPage()



        Public Sub New()
        End Sub

        Public Sub New(ByVal claveIdioma As Integer)
            Me.idIdioma = claveIdioma
        End Sub


        'Create a new MigraDoc document
        Public Function CreateDocument(ByVal claveLibroDeTrabajo As Integer) As Document
            Dim mylt As New Lego.Root(claveLibroDeTrabajo)

            Me.document = New Document()
            Me.document.Info.Title = mylt.titulo
            Me.document.Info.Subject = mylt.descripcion
            Me.document.Info.Author = "Autor | " & mylt.Autor


            Return Me.document
        End Function




       

        Private Function getFooter(ByVal clavelibrodetrabajo As Integer, ByVal tablitax As MigraDoc.DocumentObjectModel.Tables.Table) As MigraDoc.DocumentObjectModel.Tables.Table
            Dim objOrden As New Lego.Root(clavelibrodetrabajo)



            'Before you can add a row, you must define the columns
            Dim column As Column
            column = tablitax.AddColumn("17.5cm")      'Observaciones
            column.Format.Alignment = ParagraphAlignment.Center

            Dim row As Row = tablitax.AddRow()
            Dim paralabel1 As Paragraph = row.Cells(0).AddParagraph("Skolar- - Montemorelos, N.L., México.")
            paralabel1.Format.Font.Size = 8
            paralabel1.Format.Font.Bold = True
            row = tablitax.AddRow()

            Dim pvendedor As String = "contacto@skolar.online"
            Dim phonevendedor As String = "tel. 01 826 8888888"

            Dim paralabel2 As Paragraph = row.Cells(0).AddParagraph(phonevendedor & " - email: " & pvendedor)
            paralabel2.Format.Font.Size = 7




            Return tablitax

        End Function




        Private Function FillData(ByVal claveLibroDeTrabajo As Integer, ByVal tablita As MigraDoc.DocumentObjectModel.Tables.Table) As MigraDoc.DocumentObjectModel.Tables.Table

            Dim objOrden As New Lego.Root(claveLibroDeTrabajo)


            'Dim myTablita As New MigraDoc.DocumentObjectModel.Tables.Table
            Dim mycolum As Column

            mycolum = tablita.AddColumn("4cm")
            mycolum.Format.Alignment = ParagraphAlignment.Right

            mycolum = tablita.AddColumn("9cm")
            mycolum.Format.Alignment = ParagraphAlignment.Right

            'mycolum = tablita.AddColumn("3cm")
            'mycolum.Format.Alignment = ParagraphAlignment.Right

            'mycolum = tablita.AddColumn("6cm")
            'mycolum.Format.Alignment = ParagraphAlignment.Right




            Dim datRow1 As Row = tablita.AddRow()
            datRow1.VerticalAlignment = VerticalAlignment.Top
            datRow1.Format.Alignment = ParagraphAlignment.Left

            Dim lblContacto As Paragraph = datRow1.Cells(0).AddParagraph("Nombre del libro:")
            lblContacto.Format.Font.Size = 8
            lblContacto.Format.Font.Bold = False

            Dim lblContacto2 As Paragraph = datRow1.Cells(1).AddParagraph(objOrden.titulo)
            lblContacto2.Format.Font.Bold = True
            lblContacto2.Format.Font.Size = 8

            Dim lblnombreempresa As Paragraph = datRow1.Cells(0).AddParagraph("Biblioteca:")
            lblnombreempresa.Format.Font.Size = 8
            lblnombreempresa.Format.Font.Bold = False

            Dim lblnombreempresa2 As Paragraph = datRow1.Cells(1).AddParagraph(objOrden.Biblioteca)
            lblnombreempresa2.Format.Font.Bold = True
            lblnombreempresa2.Format.Font.Size = 8






            Dim datRow2 As Row = tablita.AddRow()
            datRow2.VerticalAlignment = VerticalAlignment.Top
            datRow2.Format.Alignment = ParagraphAlignment.Left
            Dim lblEmpresa As Paragraph = datRow2.Cells(0).AddParagraph("Autor:")
            lblEmpresa.Format.Font.Size = 8
            lblEmpresa.Format.Font.Bold = False

            Dim autor As String = objOrden.Autor
            If objOrden.Autor = "" Then
                Dim myuautor As New MasUsuarios.UserProfile(objOrden.idUserProfile, False)
                autor = myuautor.nombre & " " & myuautor.apellidos
            End If

            Dim lblEmpresa2 As Paragraph = datRow2.Cells(1).AddParagraph("Skolar | " & autor)
            lblEmpresa2.Format.Font.Bold = True
            lblEmpresa2.Format.Font.Size = 8

            Dim lblRFC As Paragraph = datRow2.Cells(0).AddParagraph("Fecha de creación:")
            lblRFC.Format.Font.Size = 8
            lblRFC.Format.Font.Bold = False

            Dim lblRFC2 As Paragraph = datRow2.Cells(1).AddParagraph(objOrden.fechaCreacion)
            lblRFC2.Format.Font.Bold = True
            lblRFC2.Format.Font.Size = 8






            Dim datRow3 As Row = tablita.AddRow()
            datRow3.VerticalAlignment = VerticalAlignment.Top
            datRow3.Format.Alignment = ParagraphAlignment.Left
            Dim lblEmail As Paragraph = datRow3.Cells(0).AddParagraph("Etiquetas de búsqueda:")
            lblEmail.Format.Font.Size = 8
            lblEmail.Format.Font.Bold = False

            Dim lblEmail2 As Paragraph = datRow3.Cells(1).AddParagraph(objOrden.Tags)
            lblEmail2.Format.Font.Bold = True
            lblEmail2.Format.Font.Size = 8

            Dim lblDireccionF As Paragraph = datRow3.Cells(0).AddParagraph("Descripcion general:")
            lblDireccionF.Format.Font.Size = 8
            lblDireccionF.Format.Font.Bold = False



            Dim lblDireccionF2 As Paragraph = datRow3.Cells(1).AddParagraph(objOrden.descripcion)
            lblDireccionF2.Format.Font.Bold = True
            lblDireccionF2.Format.Font.Size = 8







            Return tablita


        End Function

      



        Public Function GenerarTabla(ByVal tablita As MigraDoc.DocumentObjectModel.Tables.Table, ByVal claveLibrodetrabajo As Integer, ByVal numeroInicio As Integer, ByVal numeroFin As Integer) As MigraDoc.DocumentObjectModel.Tables.Table
            'Create the item table

            Dim numero As Integer = 0

            Dim myclasif As New Lego.Clasificacion
            Dim dsfolders As DataSet = myclasif.GetDSRaizRoot(0, claveLibrodetrabajo)


            Dim myci As New Lego.ClasificacionItem
            Dim drHijos As SqlDataReader

            For Each drsf As DataRow In dsfolders.Tables(0).Rows
                numero = numero + 1
                drHijos = myci.GetDR(drsf("idClasificacion"), ordenamiento.ASC)

                If numero >= numeroInicio And numero < numeroFin Then
                    Dim datRow As Row = tablita.AddRow()
                    datRow.TopPadding = 1.5
                    datRow.VerticalAlignment = VerticalAlignment.Top

                    datRow.Cells(0).AddParagraph(drsf("Titulo").ToString.ToUpper)
                    datRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
                    datRow.Cells(0).Format.Font.Size = 8
                    datRow.Cells(0).Format.Font.Bold = True


                    Do While drHijos.Read

                        Dim datRow2 As Row = tablita.AddRow()
                        datRow2.TopPadding = 1.5
                        datRow2.VerticalAlignment = VerticalAlignment.Top

                        datRow2.Cells(0).AddParagraph(drHijos("Titulo"))
                        datRow2.Cells(0).Format.Alignment = ParagraphAlignment.Left
                        datRow2.Cells(0).Format.Font.Size = 7
                        datRow2.Cells(0).Format.Font.Bold = True


                        datRow2.Cells(0).AddParagraph("")

                        Select Case drHijos("Procedencia")

                            Case "Contenido"
                                Dim myc As New Contenidos.Contenido(CInt(drHijos("idProc")))
                                Dim para1 As Paragraph = datRow2.Cells(0).AddParagraph(myc.textoLargo)
                                para1.Format.Font.Size = 6
                            Case "Actividad"
                                Dim mya As New Contenidos.Actividad(CInt(drHijos("idProc")))
                                Dim para1 As Paragraph = datRow2.Cells(0).AddParagraph("Tipo de actvidad:")
                                para1.Format.Font.Bold = True
                                para1.Format.Font.Size = 6
                                Dim para2 As Paragraph = datRow2.Cells(0).AddParagraph(mya.tipodeActividad)
                                para2.Format.Font.Size = 6
                                datRow2.Cells(0).AddParagraph("")
                                Dim para3 As Paragraph = datRow2.Cells(0).AddParagraph("Competencia:")
                                para3.Format.Font.Size = 6
                                Dim para4 As Paragraph = datRow2.Cells(0).AddParagraph(mya.Objetivo)
                                para4.Format.Font.Size = 6
                                Dim para5 As Paragraph = datRow2.Cells(0).AddParagraph("Tags:")
                                para5.Format.Font.Size = 6
                                Dim para6 As Paragraph = datRow2.Cells(0).AddParagraph(mya.Tags)
                                para6.Format.Font.Size = 6
                                Dim para7 As Paragraph = datRow2.Cells(0).AddParagraph("Instrucciones generales de esta actividad:")
                                para7.Format.Font.Size = 6
                                Dim para8 As Paragraph = datRow2.Cells(0).AddParagraph(mya.instrucciones)
                                para8.Format.Font.Size = 6

                            Case "Foro"

                        End Select

                       



                        numero = numero + 1

                    Loop
                    drHijos.Close()

                    tablita.SetEdge(0, tablita.Rows.Count - 1, 1, 1, Edge.Box, BorderStyle.Single, 0.25)
                Else
                    Do While drHijos.Read
                        numero = numero + 1
                        If numero = numeroFin Then
                            Exit Do
                        End If
                    Loop
                    drHijos.Close()
                End If

                If numero = numeroFin Then
                    Exit For
                End If

            Next


           





            Return tablita



        End Function





        Public Function Colocarpdf(ByVal nombreArchivo As String, ByVal claveLibrodetrabajo As Integer) As Integer

            'Create a new PDF document 
            Dim mylt As New Lego.Root(claveLibrodetrabajo)

            Dim document As PdfDocument = New PdfDocument()
            document.Info.Title = mylt.titulo
            document.Info.Author = "Skolar | " & mylt.Autor
            document.Info.Creator = "Skolar Pdf generator"




            'CreateDocument(claveOrden)
            Dim doc As Document = New Document
            Dim sec As Section = doc.AddSection()





            Dim renglones As Integer = 0


            Dim myclasif As New Lego.Clasificacion
            Dim dsfolders As DataSet = myclasif.GetDSRaizRoot(0, claveLibrodetrabajo)
            renglones = dsfolders.Tables(0).Rows.Count

            Dim myci As New Lego.ClasificacionItem
            Dim drHijos As SqlDataReader
            Dim numeroHijos As Integer = 0
            For Each drsf As DataRow In dsfolders.Tables(0).Rows
                drHijos = myci.GetDR(drsf("idClasificacion"), ordenamiento.ASC)
                Do While drHijos.Read
                    numeroHijos = numeroHijos + 1
                Loop
                drHijos.Close()
            Next


            Dim cantidadRenglones As Integer = renglones + numeroHijos
            Dim cantidadPaginas As Integer = (cantidadRenglones - (cantidadRenglones Mod 30)) / 30




            If (cantidadRenglones Mod 30) > 0 Then
                cantidadPaginas += 1
            End If







            Dim tablas As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()


            Dim i As Integer = 0
            Dim numeroInicio As Integer = 0
            Dim numeroFin As Integer = 30
            Dim entrePrimero As Boolean = False

            For i = 1 To cantidadPaginas

                '     Dim txf As TextFrame = sec.AddTextFrame

                Dim tablita As MigraDoc.DocumentObjectModel.Tables.Table = sec.AddTable
                tablita.Style = "Table"
                tablita.Borders.Color = TableBorder
                tablita.Borders.Width = 0.15
                tablita.Borders.Left.Width = 0.25
                tablita.Borders.Right.Width = 0.25
                tablita.Rows.LeftIndent = 0


                'Before you can add a row, you must define the columns
                Dim column As Column
                column = tablita.AddColumn("17.5cm")      'Nombre
                column.Format.Alignment = ParagraphAlignment.Right
               

                'Create the header of the table
                Dim row As Row = tablita.AddRow()
                row.HeadingFormat = True
                row.VerticalAlignment = VerticalAlignment.Bottom
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
                row.Format.Font.Name = "Arial"
                row.Format.Font.Size = 10
                row.Shading.Color = TableHeader



                '  Dim paraHeader As Paragraph
                Dim paraHeader1 As Paragraph = row.Cells(0).AddParagraph("ORGANIZACIÓN DE CONTENIDOS")
                paraHeader1.Format.Font.Size = 9
                paraHeader1.Format.Alignment = ParagraphAlignment.Left

               

                tablita.SetEdge(0, 0, 1, 1, Edge.Box, BorderStyle.Single, 0.25)
                If entrePrimero = False Then
                    entrePrimero = True
                    tablas.Add(GenerarTabla(tablita, mylt.id, 0, 30))
                    numeroInicio = 30
                    numeroFin = 60
                Else
                    tablas.Add(GenerarTabla(tablita, mylt.id, numeroInicio, numeroFin))
                    numeroInicio = numeroInicio + 30
                    numeroFin = numeroFin + 30

                End If



            Next



            Dim tablita01 As MigraDoc.DocumentObjectModel.Tables.Table = sec.AddTable
            Dim column01 As Column
            column01 = tablita01.AddColumn("12.5cm")      'todo
            column01 = tablita01.AddColumn("5cm")      'fecha
            Dim row01 As Row = tablita01.AddRow()
            row01.Cells(0).AddImage(ConfigurationManager.AppSettings("carpetaPrincipal") & "\images\logoumredondo.gif")
            row01.Cells(1).Format.Alignment = ParagraphAlignment.Center
            row01.Cells(1).AddParagraph(Format(Date.Now, "d \de MMMM \de yyyy"))
            Dim row03 As Row = tablita01.AddRow()
            row03.Cells(0).AddParagraph("  ")
            Dim row04 As Row = tablita01.AddRow()
            row04.Cells(0).AddParagraph("  ")

            Dim row02 As Row = tablita01.AddRow()
            'row02.Cells(0).Format.Font.Size = 13
            row02.Height = MigraDoc.DocumentObjectModel.Unit.FromPoint(50)
            row02.Cells(0).Format.Font.Bold = True

            Dim cadenaCotizacion As String = mylt.titulo
           
            Dim cotizacionNumero As Paragraph = row02.Cells(0).AddParagraph(cadenaCotizacion)
            cotizacionNumero.Format.Font.Size = 13

            tablita01.SetEdge(0, 0, 0, 0, Edge.Box, BorderStyle.Single, 0.25)

            Dim tablas01 As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
            tablas01.Add(tablita01)
            Dim tablas02 As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
            tablas02.Add(FillData(mylt.id, sec.AddTable))
           
            Dim tablas05 As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
            tablas05.Add(getFooter(mylt.id, sec.AddTable))
           

            Dim docRenderer As DocumentRenderer = New DocumentRenderer(doc)
            docRenderer.PrepareDocument()


            entrePrimero = False



            ' Create an empty page 
            Dim page As PdfPage

            ' Get an XGraphics object for drawing 
            Dim gfx As XGraphics

            Dim numeroTablas As Integer = 0
            Dim ultimaAltura As Integer = 0
            For Each tabla As MigraDoc.DocumentObjectModel.Tables.Table In tablas
                numeroTablas += 1
                page = document.AddPage()
                page.Size = PdfSharp.PageSize.Letter
                page.Orientation = PdfSharp.PageOrientation.Portrait

                ' Get an XGraphics object for drawing 
                gfx = XGraphics.FromPdfPage(page)


                For Each tabla01 As MigraDoc.DocumentObjectModel.Tables.Table In tablas01
                    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(35), XUnit.FromPoint(780), tabla01)
                Next
                For Each tabla05 As MigraDoc.DocumentObjectModel.Tables.Table In tablas05
                    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(750), XUnit.FromPoint(780), tabla05)
                Next


                ultimaAltura = 0
                If entrePrimero = False Then
                    entrePrimero = True
                    ' datos generales, datos de facturacion, datos de contacto
                    For Each tabla02 As MigraDoc.DocumentObjectModel.Tables.Table In tablas02
                        docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(180), XUnit.FromPoint(780), tabla02)
                    Next
                    'tabla de productos y servicios
                    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(320), XUnit.FromPoint(780), tabla)

                    ultimaAltura = tabla.Rows.Count
                Else
                    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(150), XUnit.FromPoint(780), tabla)
                    ultimaAltura = tabla.Rows.Count
                End If

              

            Next

           

            '   If myo.Observaciones <> "" Then
            'page = document.AddPage()
            'page.Size = PdfSharp.PageSize.Letter
            'page.Orientation = PdfSharp.PageOrientation.Portrait

            '' Get an XGraphics object for drawing 
            'gfx = XGraphics.FromPdfPage(page)

            'For Each tabla01 As MigraDoc.DocumentObjectModel.Tables.Table In tablas01
            '    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(35), XUnit.FromPoint(780), tabla01)
            'Next
            'For Each tabla05 As MigraDoc.DocumentObjectModel.Tables.Table In tablas05
            '    docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(750), XUnit.FromPoint(780), tabla05)
            'Next

         
            '     End If


            ' Save the document... 
            Dim pdffilename As String = nombreArchivo
            document.Save(pdffilename)

        End Function

    End Class
End Namespace
