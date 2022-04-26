Imports System.Globalization
Imports System.Threading
Partial Class _Default
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub







    Sub colocarDatos()
        litnum.Text = GetRandom(1, 7)

        Dim imagenInicial As String = "images/diamantebaners/ban8.jpg"
        Dim video As String = ""
        If Request("idEmpresa") <> "" Then
            Dim mye As New MasUsuarios.Empresa(CInt(Request("idEmpresa")))
            If mye.ImagenInicio <> "" Then
                imagenInicial = "images/empresas/" & mye.ImagenInicio
            End If
            If mye.Video <> "" Then
                video = "/images/empresas/" & mye.Video
            End If
        End If

        Dim cadena As New StringBuilder()
        cadena.AppendLine("<style>")
        cadena.AppendLine(" .demo-my-bg{")
        ' cadena.AppendLine(" background-image : url(""images/diamantebaners/ban" & litnum.Text & ".jpg"");")
        cadena.AppendLine(" background-image : url(""" & imagenInicial & """);")
        cadena.AppendLine("}")
        cadena.AppendLine(" </style>")
        cadena.AppendLine("")
        cadena.AppendLine("")


        If video <> "" Then
            cadena.AppendLine("<video muted autoplay loop class=""video""")
            cadena.AppendLine("<source src=""" & video & """ type="""">")
            cadena.AppendLine("</video>")
        End If



        litscript.Text = cadena.ToString


    End Sub


    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function



End Class
