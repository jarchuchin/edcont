
Partial Class Sec_Workbook_Controles_DisplayVerArchivo
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
            Dim myc As Contenidos.Contenido = New Contenidos.Contenido(varContenido)
            If myc.idTipoContenido = Contenidos.TipoContenido.Archivo Then

                lblnombreoriginal2.Text = myc.titulo

                panelContenidos.Visible = True
                litdescripcion.Text = myc.textoCorto & " " & myc.textoLargo
                lnkDescargar.NavigateUrl = "~/sec/showfile.aspx?idCont=" & myc.id
                lblNombreOriginal.Text = myc.nombreOriginal
                Dim myconv As Utilerias.Conversiones = New Utilerias.Conversiones

                lblbites.Text = myconv.Numeric2Bytes((Convert.ToDouble(myc.espacio)))



            Else
                panelContenidos.Visible = False
            End If
        End If




    End Sub

   

End Class
