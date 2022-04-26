Imports System.Data

Partial Class Sec_Workbook_Controles_DisplayContenidoTipo
    Inherits System.Web.UI.UserControl


    Public Property Tipo As String
        Set(value As String)
            HiddenTipo.Value = value
        End Set
        Get
            Return HiddenTipo.Value
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim objClasificacion As New Lego.Clasificacion
        Dim idRoot As Integer = getIdRoot()

        Dim ds As DataSet = objClasificacion.getAnexosDeClasificacion(idRoot, getIdClasificacion)
        Dim dView As DataView = ds.Tables(0).DefaultView

        dView.RowFilter = "tipoAnexo = '" & HiddenTipo.Value & "'"
        dView.Sort = "titulo asc"
        rptDatos.DataSource = dView
        rptDatos.DataBind()

        Select Case HiddenTipo.Value
            Case "Contenido"
                lbltitulogrupo.Text = Label1.Text
            Case "Actividad"
                lbltitulogrupo.Text = Label2.Text
            Case "Examen"
                lbltitulogrupo.Text = Label3.Text
            Case "Foro"
                lbltitulogrupo.Text = Label4.Text
        End Select

    End Sub

    Private Function getIdSalonVirtual() As Integer
        Dim idSalonVirtual As Integer
        Try
            idSalonVirtual = CInt(Request("idSalonVirtual"))
        Catch ex As Exception
            idSalonVirtual = 0
        End Try

        If idSalonVirtual < 0 Then idSalonVirtual = 0

        Return idSalonVirtual
    End Function

    Private Function getIdCI() As Integer
        Dim idCI As Integer
        Try
            idCI = CInt(Request("idCI"))
        Catch ex As Exception
            idCI = 0
        End Try

        If idCI < 0 Then idCI = 0

        Return idCI
    End Function

    Private Function getIdClasificacion() As Integer
        Dim idClasificacion As Integer
        Try
            idClasificacion = CInt(Request("idClasificacion"))
        Catch ex As Exception
            idClasificacion = 0
        End Try

        If idClasificacion < 0 Then Return idClasificacion

        Try
            idClasificacion = CInt(hiddenIdClasificacion.Value)
        Catch ex As Exception
        End Try

        If idClasificacion < 0 Then idClasificacion = 0

        Return idClasificacion
    End Function

    Private Function getIdRoot() As Integer
        Dim idRoot As Integer
        Try
            idRoot = CInt(Request("idRoot"))
        Catch ex As Exception
        End Try

        If idRoot < 0 Then Return idRoot

        Try
            idRoot = CInt(HiddenidRoot.Value)
        Catch ex As Exception
        End Try

        If idRoot < 0 Then idRoot = 0

        Return idRoot
    End Function

    Protected Function getImagen(claveTipo As Integer, claveExtension As String, clavetipoAnexo As String) As String

        Dim imagen As String = "~/images/iconsDiamante/iconTexto.jpg"
        Select Case clavetipoAnexo
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

    Protected Function getLinkAnexos(idRoot As Integer, idClasificacionItem As Integer, tipoAnexo As String, idTipo As Integer) As String

        Dim filePath, file, proc As String
        file = ""
        proc = ""


        filePath = "~/Sec/Workbook/"



        Select Case tipoAnexo
            Case "Contenido"
                file = "AddAnexos.aspx"
                Select Case idTipo
                    Case Contenidos.TipoContenido.Archivo
                        proc = "Archivo"
                    Case Contenidos.TipoContenido.Flash
                        proc = "Flash"
                    Case Contenidos.TipoContenido.Imagen
                        proc = "Imagen"
                    Case Contenidos.TipoContenido.Texto
                        proc = "Contenido"
                        file = "AddContenido.aspx"
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
        End Select



        Return filePath & file & "?idRoot=" & idRoot & "&idCI=" & idClasificacionItem & "&idClasificacion=" & getIdClasificacion() & "&proc=" & proc & "&regreso=carpeta"



    End Function
End Class
