
Partial Class Sec_Workbook_Controles_DisplayVerTexto
    Inherits System.Web.UI.UserControl

    Dim varContenido As Integer
    Dim varTipo As String

    Public Property claveContenido As Integer
        Set(value As Integer)
            varContenido = value
        End Set
        Get
            Return varContenido
        End Get
    End Property

    Public Property tipoContenido As String
        Set(value As String)
            varTipo = value
        End Set
        Get
            Return varTipo
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        If varTipo = tipoObjeto.Contenido.ToString Then
            Dim objContenido As Contenidos.Contenido = New Contenidos.Contenido(varContenido)
            If objContenido.idTipoContenido = Contenidos.TipoContenido.Texto Then

                panelContenidos.Visible = True
                literalTextoLargo.Text = objContenido.textoLargo
                literalDescripcion.Text = objContenido.textoCorto.Replace(vbCrLf, "<br>")
                txtTitulo.Text = objContenido.titulo

                txtparaInstructor.Text = objContenido.ParaInstructor
                txttags.Text = objContenido.Tags

                pasaDatosACajitas(objContenido, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo)
                pasaDatosACajitas(objContenido, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen)
                pasaDatosACajitas(objContenido, showFlashes, Contenidos.TipoContenido.Flash)
                pasaDatosACajitas(objContenido, showDirecciones, Contenidos.TipoContenido.Liga)
            Else
                panelContenidos.Visible = False
            End If

        End If

    End Sub

    Private Sub pasaDatosACajitas(ByRef objContenido As Contenidos.Contenido, control As Sec_Workbook_Controles_showadjuntos, tipo As Contenidos.TipoContenido)
        With control
            .idproc = objContenido.id
            .procedencia = objContenido.tipo.ToString
            .tipoAdjunto = tipo
        End With
    End Sub

End Class
