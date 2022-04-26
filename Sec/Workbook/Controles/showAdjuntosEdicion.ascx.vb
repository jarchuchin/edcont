Namespace usmart

    Class showAdjuntosEdicion
        Inherits System.Web.UI.UserControl


#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        '*********************************************************************
        'seccion para implementar las propiedades obligatorias
        '*********************************************************************


        Dim varpagina As String
        Dim varclavefiltro1 As String
        Dim varclavefiltro2 As String
        Dim varclavefiltro3 As String
        Dim varusuario As String
        Dim varstatus As Boolean
        Dim varnumero As Integer

       

        Public Property ClaveFiltro1() As String
            Get
                ClaveFiltro1 = varclavefiltro1
            End Get
            Set(ByVal Value As String)
                varclavefiltro1 = Value
            End Set
        End Property

        Public Property ClaveFiltro2() As String
            Get
                ClaveFiltro2 = varclavefiltro2
            End Get
            Set(ByVal Value As String)
                varclavefiltro2 = Value
            End Set
        End Property

        Public Property ClaveFiltro3() As String
            Get
                ClaveFiltro3 = varclavefiltro3
            End Get
            Set(ByVal Value As String)
                varclavefiltro3 = Value
            End Set
        End Property



        '******************************************************************
        'FIn 
        '******************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  Me.Load
            'Introducir aquí el código de usuario para inicializar la página
            If Not IsPostBack Then
                hd1.Value = Me.ClaveFiltro1
                Hd2.Value = Me.ClaveFiltro2
                Hd3.Value = Me.ClaveFiltro3
                llenarDatos()
            End If
        End Sub


        Sub llenarDatos()
            Dim myAdjuntos As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto
            Dim cadena As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/showFile.aspx?idCont="
            Dim i As Integer = 0
            chkAdjuntos.Items.Clear()

            Select Case Me.hd1.Value
                Case "Imagen"
                    chkAdjuntos.DataSource = myAdjuntos.GetDR(CInt(Me.Hd2.Value), Me.Hd3.Value, Contenidos.TipoContenido.Imagen)
                    chkAdjuntos.DataValueField = "idContenidoAdjunto"
                    chkAdjuntos.DataTextField = "idContenido"
                    chkAdjuntos.DataBind()
                    For i = 0 To chkAdjuntos.Items.Count - 1
                        chkAdjuntos.Items(i).Text = "<a href='" & cadena & chkAdjuntos.Items(i).Text & "' title='" & lblvistaprevia.Text & "' class='LigaVerde' ><img border='0' src='" & cadena & chkAdjuntos.Items(i).Text & "' width='80' ></a>"
                    Next
                Case "Archivo"
                    chkAdjuntos.DataSource = myAdjuntos.GetDR(CInt(Me.Hd2.Value), Me.Hd3.Value, Contenidos.TipoContenido.Archivo)
                    chkAdjuntos.DataValueField = "idContenidoAdjunto"
                    chkAdjuntos.DataTextField = "idContenido"
                    chkAdjuntos.DataBind()
                    Dim mycont As Contenidos.Contenido
                    For i = 0 To chkAdjuntos.Items.Count - 1
                        mycont = New Contenidos.Contenido(CInt(chkAdjuntos.Items(i).Text))
                        chkAdjuntos.Items(i).Text = "<a href='" & cadena & chkAdjuntos.Items(i).Text & "' class='LigaVerde'  > " & mycont.titulo & "</a>"
                    Next
                Case "Flash"
                    chkAdjuntos.DataSource = myAdjuntos.GetDR(CInt(Me.Hd2.Value), Me.Hd3.Value, Contenidos.TipoContenido.Flash)
                    chkAdjuntos.DataValueField = "idContenidoAdjunto"
                    chkAdjuntos.DataTextField = "idContenido"
                    chkAdjuntos.DataBind()
                    Dim mycont As Contenidos.Contenido
                    For i = 0 To chkAdjuntos.Items.Count - 1
                        mycont = New Contenidos.Contenido(CInt(chkAdjuntos.Items(i).Text))
                        chkAdjuntos.Items(i).Text = "<a href='" & cadena & chkAdjuntos.Items(i).Text & "' class='LigaVerde'  > " & mycont.titulo & "</a>"
                    Next
                Case "Liga"
                    chkAdjuntos.DataSource = myAdjuntos.GetDR(CInt(Me.Hd2.Value), Me.Hd3.Value, Contenidos.TipoContenido.Liga)
                    chkAdjuntos.DataValueField = "idContenidoAdjunto"
                    chkAdjuntos.DataTextField = "idContenido"
                    chkAdjuntos.DataBind()
                    Dim mycont As Contenidos.Contenido
                    For i = 0 To chkAdjuntos.Items.Count - 1
                        mycont = New Contenidos.Contenido(CInt(chkAdjuntos.Items(i).Text))
                        chkAdjuntos.Items(i).Text = "<a href='" & mycont.url & "'  target='_blank' class='LigaVerde'> " & mycont.titulo & "</a>"
                    Next
            End Select

            If chkAdjuntos.Items.Count >= 1 Then
                chkAdjuntos.Visible = True
                lnkBorrar.Visible = True
            Else
                chkAdjuntos.Visible = False
                lnkBorrar.Visible = False
            End If

        End Sub


        Protected Sub lnkBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBorrar.Click
            System.Threading.Thread.Sleep(1500)
            Dim i As Integer

            For i = 0 To chkAdjuntos.Items.Count - 1
                If chkAdjuntos.Items(i).Selected Then
                    Dim myCA As Contenidos.ContenidoAdjunto = New Contenidos.ContenidoAdjunto(CInt(chkAdjuntos.Items(i).Value))
                    myCA.Remove()
                End If
            Next

            llenarDatos()
        End Sub
    End Class

End Namespace
