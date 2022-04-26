
Partial Class MPUsmart03
    Inherits System.Web.UI.MasterPage

    Public Function GetScripts() As String
        Dim path As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")
        Dim cadena As String = path & "App_Themes/Default/jquery-1.4.2.min.js"
        'Dim cadena2 As String = path & "App_Themes/Default/jquery.nivo.slider.pack.js"
        'Dim cadena3 As String = path & "App_Themes/Default/SpryAssets/SpryMenuBar.js"
        'Dim cadena4 As String = path & "App_Themes/Default/Scripts/swfobject_modified.js"
        'Dim cadena5 As String = path & "App_Themes/Default/jqDropDown.jquery.min.js"
        'Dim cadena6 As String = path & "App_Themes/Default/SpryAssets/SpryAccordion.js"

        Return "<script type=""text/javascript"" src=""" & cadena & """></script>" '<script type=""text/javascript"" src=""" & cadena2 & """></script><script type=""text/javascript"" src=""" & cadena3 & """></script><script type=""text/javascript"" src=""" & cadena4 & """></script><script type=""text/javascript"" src=""" & cadena5 & """></script><script type=""text/javascript"" src=""" & cadena6 & """></script>"

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        litScriptHeader.Text = GetScripts()
    End Sub
End Class

