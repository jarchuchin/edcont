
Partial Class Sec_SalonVirtual_Controles_displayCuadritos
    Inherits System.Web.UI.UserControl


    Dim urlAnterior As String = "#"
    Dim urlSiguiente As String = "#"


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocardatos()
       

        lnkAnterior.NavigateUrl = ""
        lnkSiguiente.NavigateUrl = ""

        Dim myci As New Lego.ClasificacionItem
        Dim myc As New Lego.Clasificacion


        Dim claveClasificacion As Integer
        If Request("idClasificacion") <> "" Then
            claveClasificacion = CInt(Request("idClasificacion"))
        Else
            myci = New Lego.ClasificacionItem(CInt(Request("idCI")))
            myc = New Lego.Clasificacion(myci.idClasificacion)
            claveClasificacion = myc.id
        End If


        dtlContenidos.DataSource = myci.GetDR(claveClasificacion, ordenamiento.ASC)
        dtlContenidos.DataBind()


    End Sub

    Public Nombre As String
    Public Numero As Integer = 0
    Public MostrarBold As Boolean = False

    Public Function GetLiga(claveClasificacionItem As Integer) As String
        MostrarBold = False

        Dim myci As New Lego.ClasificacionItem(claveClasificacionItem)
        Dim url As String = ""
        Dim imagen As String = ""
        Nombre = ""

        If claveClasificacionItem.ToString = Request("idCI") Then
            MostrarBold = True
        End If

        Select Case myci.procedencia.ToString
            Case tipoObjeto.Contenido.ToString
                Dim mycont As Contenidos.Contenido = New Contenidos.Contenido(myci.idProc)
                Nombre = mycont.titulo
                Select Case mycont.idTipoContenido
                    Case Contenidos.TipoContenido.Archivo
                        url = "~/sec/salonvirtual/verArchivo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                    Case Contenidos.TipoContenido.Flash
                        url = "~/sec/salonvirtual/verFlash.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                    Case Contenidos.TipoContenido.Imagen
                        url = "~/sec/salonvirtual/verImagen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                    Case Contenidos.TipoContenido.Texto
                        url = "~/sec/salonvirtual/verTexto.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id

                End Select


                Select Case mycont.extension.ToLower
                    Case "swf"
                        imagen = "~/images/pagina/miniiconflash.gif"
                    Case "ppt", "pptx"
                        imagen = "~/images/pagina/miniiconpower.jpg"
                    Case "bmp", "gif", "jpg", "jpeg"
                        imagen = "~/images/pagina/miniIconImagenes.gif"
                    Case "xls", "xlsx"
                        imagen = "~/images/pagina/miniiconExcel.jpg"
                    Case "doc", "docx"
                        imagen = "~/images/pagina/miniiconword.jpg"
                    Case "mdb", "mdbx"
                        imagen = "~/images/pagina/miniIconAccess.jpg"
                    Case "mp3"
                        imagen = "~/images/pagina/MiniIconMP3.jpg"
                    Case "rar"
                        imagen = "~/images/pagina/miniIconRAR.jpg"
                    Case "zip"
                        imagen = "~/images/pagina/miniIconZIP.jpg"
                    Case "txt"
                        imagen = "~/images/pagina/miniIconTexto.gif"
                    Case "pdf"
                        imagen = "~/images/pagina/MiniIconAcrobatReader.jpg"
                    Case Else
                        imagen = "~/images//pagina/MiniIconTexto.gif"
                End Select
            Case tipoObjeto.Actividad.ToString
                Dim myact As Contenidos.Actividad = New Contenidos.Actividad(myci.idProc)
                Nombre = myact.titulo
                Select Case myact.tipodeActividad
                    Case Contenidos.ETipodeActividad.Actividad
                        url = "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                    Case Contenidos.ETipodeActividad.Examen
                        url = "~/sec/salonvirtual/verExamen.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id
                End Select
                Select Case myact.tipodeActividad
                    Case Contenidos.ETipodeActividad.Actividad
                        imagen = "~/images/pagina/miniIconActvs.gif"
                    Case Contenidos.ETipodeActividad.Examen
                        imagen = "~/images/pagina/miniIconExam.gif"
                End Select

            Case tipoObjeto.Foro.ToString
                Dim myf As Contenidos.Foro = New Contenidos.Foro(myci.id)
                Nombre = myf.titulo
                imagen = "~/images/pagina/miniIconForo.gif"
                url = "~/sec/salonvirtual/verForo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & myci.id

        End Select

        Numero = Numero + 1

        'Activar siguiente anterior en los cuadritos
        If activarSiguiente Then
            lnkSiguiente.NavigateUrl = url
            activarSiguiente = False
        End If


        If claveClasificacionItem.ToString = Request("idCI") Then
            If Numero > 1 Then
                lnkAnterior.NavigateUrl = urlAnterior
                activarSiguiente = True
            Else
                activarSiguiente = True
            End If

        End If


        If lnkSiguiente.Text <> "" And Request("idClasificacion") <> "" And Numero = 1 Then
            lnkSiguiente.NavigateUrl = url
            activarSiguiente = False
        End If


        urlAnterior = url
        Return url



    End Function

    Dim activarSiguiente As Boolean = False


    Public Function getClase(claveClasificacionItem As Integer) As String
        If claveClasificacionItem.ToString = Request("idCI") Then
            Return "CuadritoContenido2"
        Else
            Return "CuadritoContenido"
        End If
    End Function
End Class
