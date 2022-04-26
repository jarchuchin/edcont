
Partial Class Sec_Workbook_Controles_DisplayVerFlash
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
            If myc.idTipoContenido = Contenidos.TipoContenido.Flash Then


                lblnombreoriginal2.Text = myc.titulo
                panelContenidos.Visible = True
                litdescripcion.Text = myc.textoCorto & " " & myc.textoLargo
                lnkDescargar.NavigateUrl = "../showfile.aspx?idCont=" & myc.id
                lblNombreOriginal.Text = myc.nombreOriginal
                Dim myconv As Utilerias.Conversiones = New Utilerias.Conversiones

                lblbites.Text = myconv.Numeric2Bytes((Convert.ToDouble(myc.espacio)))




                Dim cadenabase As String = txtbase.Text
                If myc.url <> "" Then
                    cadenabase = cadenabase.Replace("pelicula", myc.url)
                    lblbites.Visible = False
                    lnkDescargar.Visible = False
                Else
                    cadenabase = cadenabase.Replace("pelicula", "../showfile.aspx?idCont=" & myc.id)
                    lnkDescargar.NavigateUrl = "../showfile.aspx?idCont=" & myc.id & "&down=1"
                    lblNombreOriginal.Text = myc.nombreOriginal
                    lblbites.Visible = True
                    lnkDescargar.Visible = True
                    lblNombreOriginal.Visible = True
                End If

                cadenabase = cadenabase.Replace("cancho", myc.ancho.ToString)
                cadenabase = cadenabase.Replace("calto", myc.alto.ToString)

                litflas.Text = cadenabase
                litflas.Visible = True



            Else
                panelContenidos.Visible = False
            End If
        End If




    End Sub

End Class
