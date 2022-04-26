
Partial Class Sec_SalonVirtual_Controles_displayBuscadores
    Inherits System.Web.UI.UserControl

    Public Tags As String = ""
    Public Titulo As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If

    End Sub

    Sub colocarDatos()

        Dim cadena As String = ""

        If Tags <> "" Then
            Dim arregloTags() As String = Tags.Split(",")
            Dim i As Integer

            For i = 0 To arregloTags.Length - 1
                If arregloTags(i).ToString <> "" Then
                    cadena &= arregloTags(i).ToString & "+"
                End If

            Next

            'If cadena = "" Then
            cadena &= Titulo
            'End If


        End If

        'EBSCO
        'lnkebsco001.NavigateUrl = "https://search.ebscohost.com/login.aspx?authtype=url"
        ' lnkebsco002.NavigateUrl = "https://search.ebscohost.com/login.aspx?authtype=url"
        'GOOGLE
        'lnkgoogle.NavigateUrl = "https://www.google.com.mx/search?&q=" & cadena
        ''MSN
        'lnkmsn.NavigateUrl = "https://www.bing.com/search?q=" & cadena
        ''YAHOO
        'lnkYahoo.NavigateUrl = "https://search.yahoo.com/search?p=" & cadena

        ' lnknoah.NavigateUrl = "https://www.noah-health.org/search/results.php?p=" & cadena


    End Sub
End Class
