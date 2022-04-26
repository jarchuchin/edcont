
Partial Class MPDiamante01
    Inherits System.Web.UI.MasterPage
    Public appName As String = ""
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        appName = """" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")
    End Sub
End Class

