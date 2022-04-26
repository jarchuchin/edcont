
Partial Class Sec_SalonVirtual_verForoRespuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocarDatos()
        End If


    End Sub


    Sub colocarDatos()

        Dim myfsv As Contenidos.ForoSalonVirtual = New Contenidos.ForoSalonVirtual(CInt(Request("idRaiz")))

        If myfsv.existe Then
            txtTitulo.Text = "RV: " & myfsv.titulo
        Else
            If Request("idForo") <> "" Then
                Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(Request("idForo")))
                txtTitulo.Text = "RV: " & myf.titulo
            End If

        End If

    End Sub



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Page.IsValid Then
            Dim myfsv As Contenidos.ForoSalonVirtual = New Contenidos.ForoSalonVirtual
            myfsv.idForo = CInt(Request("idForo"))
            myfsv.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myfsv.idRaiz = CInt(Request("idRaiz"))
            myfsv.iduserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myfsv.titulo = txtTitulo.Text
            myfsv.texto = txtMensaje.Text
            myfsv.fechaCreacion = Date.Now
            myfsv.nombre = ""
            myfsv.nombreOriginal = ""
            myfsv.espacio = 0
            myfsv.Add()

            If FileUpload1.HasFile Then
                Dim extension As String = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1)
                Dim nombreoriginal As String = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\") + 1)
                Dim nombre As String = myfsv.id & "." & extension
                myfsv.nombre = nombre
                myfsv.nombreOriginal = nombreoriginal
                myfsv.espacio = FileUpload1.PostedFile.ContentLength
                FileUpload1.PostedFile.SaveAs(ConfigurationManager.AppSettings("carpetaArchivos") & "foros\" & myfsv.nombre)
                myfsv.Update()

            End If

            Response.Redirect("verForo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idCI=" & Request("idCI"))
        End If
    End Sub

    

End Class

