
Partial Class Sec_Workbook_Controles_DisplayVerForo
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
        If varTipo = tipoObjeto.Foro.ToString Then
            Dim objForo As Contenidos.Foro = New Contenidos.Foro(varContenido)


            panelContenidos.Visible = True
            littexto.Text = objForo.texto
            lblObjetivo.Text = objForo.Objetivo
            lblFecha.Text = Format(objForo.fechaCreacion, "f")
            lblnombreoriginal2.Text = objForo.titulo



        Else
            panelContenidos.Visible = False

        End If




    End Sub


End Class
