
Partial Class Sec_Workbook_Controles_DisplayVerExamen
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
        If varTipo = tipoObjeto.Actividad.ToString Then


            Dim objActividad As New Contenidos.Actividad(varContenido)


            If objActividad.tipodeActividad = Contenidos.ETipodeActividad.Examen Then

                txtTitulo.Text = objActividad.titulo
                panelContenidos.Visible = True

                litInstrucciones.Text = objActividad.instrucciones


                Dim myP As Examenes.Pregunta = New Examenes.Pregunta
                dtgItem.DataSource = myP.GetDS(objActividad.id)
                dtgItem.DataBind()



                pasaDatosACajitas(objActividad, showarchivosAdjuntos, Contenidos.TipoContenido.Archivo, objActividad.id)
                pasaDatosACajitas(objActividad, showimagenesAdjuntos, Contenidos.TipoContenido.Imagen, objActividad.id)
                pasaDatosACajitas(objActividad, Showflashes, Contenidos.TipoContenido.Flash, objActividad.id)
                pasaDatosACajitas(objActividad, showdirecciones, Contenidos.TipoContenido.Liga, objActividad.id)


            End If

        Else
            panelContenidos.Visible = False

        End If





    End Sub

    Private Sub pasaDatosACajitas(ByRef objActividad As Contenidos.Actividad, control As Sec_Workbook_Controles_showadjuntos, _
             tipo As Contenidos.TipoContenido, Optional idActividad As Integer = 0)
        With control
            .idProc = objActividad.id
            .procedencia = objActividad.tipo.ToString
            .tipoAdjunto = tipo
        End With
    End Sub
    Protected Function GetLiga(ByVal clavePregunta As Integer, ByVal claveTipoPregunta As Integer) As String
        Dim cadena As String = "?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idCI=" & Request("idCI") & "&idP=" & clavePregunta

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Directa
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.Desarrollo
                cadena = "AddPDirecta.aspx" & cadena
            Case Examenes.ETipoPregunta.FalsoVerdadero
                cadena = "AddFalsoVerdadero.aspx" & cadena
            Case Examenes.ETipoPregunta.OpcionMultiple
                cadena = "AddPOpcionMultiple.aspx" & cadena
            Case Examenes.ETipoPregunta.RelacionColumnas
                cadena = "AddPRelacionColumnas.aspx" & cadena
        End Select

        Return cadena

    End Function

    Protected Function GetEnunciado(ByVal claveEnunciado As String, ByVal claveTipoPregunta As Integer) As String

        Select Case claveTipoPregunta
            Case Examenes.ETipoPregunta.Desarrollo
                claveEnunciado = lblpdesarrollo.Text
            Case Examenes.ETipoPregunta.Directa
                claveEnunciado = "Pregunta directa ..."
            Case Examenes.ETipoPregunta.OpcionMultiple
                claveEnunciado = "Pregunta opción múltiple..."
            Case Examenes.ETipoPregunta.FalsoVerdadero
                claveEnunciado = "Pregunta falso o verdadero..."
            Case Examenes.ETipoPregunta.RelacionColumnas
                claveEnunciado = "Relacionar columnas"
        End Select

        Return claveEnunciado
    End Function

    Public Function getImagen(ByVal tipo As String) As String

        Select Case tipo
            Case "1"
                Return "miniiconpregDirecta.gif"
            Case "2"
                Return "miniiconpregDirecta.gif"
            Case "3"
                Return "MiniIconFoV.gif"
            Case "4"
                Return "MiniIconOpcMul.gif"
            Case "5"
                Return "miniiconRelCol.gif"
            Case Else
                Return ""
        End Select
    End Function
 
End Class
