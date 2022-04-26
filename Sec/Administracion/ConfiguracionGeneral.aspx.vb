
Partial Class Sec_Administracion_ConfiguracionGeneral
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim mye As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))

            txtmensaje.Text = mye.mensajeUM
            txtBibiotecas.Text = mye.Bibliotecas
            txtEmpotrado.Text = mye.Empotrado


            If mye.ImagenInicio <> "" Then
                imgInicial.ImageUrl = "~/images/empresas/" & mye.ImagenInicio
                imgInicial.Visible = True
            End If

            If mye.ImagenLogo <> "" Then
                imgLogo.ImageUrl = "~/images/empresas/" & mye.ImagenLogo
                imgLogo.Visible = True
            End If


            If mye.Video <> "" Then
                'imgLogo.ImageUrl = "~/images/empresas/" & mye.Video
                'imgLogo.Visible = True
            End If
        End If

    End Sub

    Function getNameFile(file1 As FileUpload, tipo As String) As String
        If file1.HasFile Then
            Dim fechaActual As DateTime = Date.Now

            Dim claveidexpediente As String = Guid.NewGuid.ToString()
            Dim namefile As String = tipo & "_" & claveidexpediente.Substring(0, 8) & "_" & fechaActual.Year & fechaActual.Month & fechaActual.Day & fechaActual.Hour & fechaActual.Minute & fechaActual.Second & "." & file1.PostedFile.FileName.Substring((file1.PostedFile.FileName.LastIndexOf(".") + 1))
            file1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaLocalFiles") & "images\empresas\" & namefile)

            Return namefile

        Else
            Return ""

        End If
    End Function





    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim mye As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))
        mye.mensajeUM = txtmensaje.Text
        mye.Bibliotecas = txtBibiotecas.Text
        Dim locLogo As String = getNameFile(fuLogo, "LOGO")
        If locLogo <> "" Then
            mye.ImagenLogo = locLogo
        End If
        Dim locInicio As String = getNameFile(fuInicial, "INI")
        If locInicio <> "" Then
            mye.ImagenInicio = locInicio
        End If
        Dim locVideo As String = getNameFile(fuVideo, "VIDEO")
        If locVideo <> "" Then
            mye.Video = locVideo
        End If
        mye.Empotrado = txtEmpotrado.Text
        mye.Update()

        Response.Redirect("ConfiguracionGeneral.aspx")


    End Sub
    Protected Sub lnkBorrarVideo_Click(sender As Object, e As EventArgs) Handles lnkBorrarVideo.Click
        Dim mye As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))
        mye.Video = ""
        mye.Update()

        Response.Redirect("ConfiguracionGeneral.aspx")
    End Sub
End Class
