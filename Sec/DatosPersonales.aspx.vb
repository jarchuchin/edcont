Imports System.Globalization
Imports System.Threading
Partial Class Sec_DatosPersonales
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenardrops()
            IniciarPagina()
        End If
    End Sub
    Sub llenardrops()
        Dim myPaises As Utilerias.Pais = New Utilerias.Pais
        DropPais.DataSource = myPaises.GetDR
        DropPais.DataTextField = Session("gUserProfileSession").idioma
        DropPais.DataValueField = "idPais"
        DropPais.DataBind()


        Dim myEmpresasUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile
        rdbEmpresas.DataSource = myEmpresasUser.GetDR(Session("gUserProfileSession").idUserProfile)
        rdbEmpresas.DataTextField = "nombreempresa"
        rdbEmpresas.DataValueField = "idEmpresa"
        rdbEmpresas.DataBind()

    End Sub

    Sub IniciarPagina()






        'colocar los datos del usuario
        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), False)


        txtNombre.Text = myUsuarios.nombre
        txtApellidos.Text = myUsuarios.apellidos
        If myUsuarios.sexo = "F" Then
            DropSexo.Items(0).Selected = True
            DropSexo.Items(1).Selected = False
        Else

            DropSexo.Items(0).Selected = False
            DropSexo.Items(1).Selected = True
        End If
        txtFechaNacimiento.Text = myUsuarios.fechaNacimiento.ToShortDateString
        txtTelefono.Text = myUsuarios.telefono
        txtDireccion.Text = myUsuarios.direccion
        txtCiudad.Text = myUsuarios.ciudad
        txtEstado.Text = myUsuarios.estado
        txtemailgoogle.Text = myUsuarios.email
        '   txtemailgooglepassword.Attributes.Add("Value", myUsuarios.emailGooglePassword)

        DropSexo.SelectedValue = myUsuarios.sexo


        Dim i As Integer
        For i = 0 To DropPais.Items.Count - 1
            DropPais.Items(i).Selected = False
            If DropPais.Items(i).Value.ToString = myUsuarios.pais.ToString Then
                DropPais.Items(i).Selected = True
            End If
        Next

        ' txtEmail.Text = myUsuarios.email
        txtwebpage.Text = myUsuarios.webpage


        Dim myEmpresasUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myUsuarios.id, 4, False)


        For i = 0 To rdbEmpresas.Items.Count - 1
            rdbEmpresas.Items(i).Selected = False
            myEmpresasUser = New MasUsuarios.EmpresaUserProfile(myUsuarios.id, Integer.Parse(rdbEmpresas.Items(i).Value))
            If myEmpresasUser.DefaultSession Then
                rdbEmpresas.Items(i).Selected = True
            End If
        Next

        Image2.ImageUrl = "~/sec/showfile.aspx?idUserprofile=" & myEmpresasUser.idUserProfile



        If myUsuarios.login.Contains("@") Then
            txtemailgoogle.Enabled = False
        End If

    End Sub


    Sub grabarUserProfile()





        Dim myUsuarios As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(Integer.Parse(Session("gUserProfileSession").idUserProfile), True)
        'myUsuarios.nombre = txtNombre.Text.ToString
        'myUsuarios.apellidos = txtApellidos.Text.ToString
        'myUsuarios.sexo = DropSexo.SelectedItem.Value.ToString
        'myUsuarios.fechaNacimiento = CType(txtFechaNacimiento.Text, Date)
        myUsuarios.telefono = txtTelefono.Text.ToString
        myUsuarios.direccion = txtDireccion.Text.ToString
        myUsuarios.ciudad = txtCiudad.Text.ToString
        myUsuarios.estado = txtEstado.Text.ToString
        myUsuarios.pais = CType(DropPais.SelectedItem.Value, Integer)
        myUsuarios.email = txtemailgoogle.Text
        myUsuarios.webpage = txtwebpage.Text.ToString
        'myUsuarios.emailGoogle = txtemailgoogle.Text
        ' myUsuarios.emailGooglePassword = "" 'txtemailgooglepassword.Text

        If FileUpload1.HasFile Then
            myUsuarios.imagen = getNameFile(myUsuarios.id, FileUpload1)
        End If

        myUsuarios.Update()
        Session("gUserProfileSession") = myUsuarios.GetUserProfilesSession()

        Session("fotoUsuario") = myUsuarios.imagen

        '    Dim myEmpresasUser As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile
        '    myEmpresasUser.UpdateStatusTo0(myUsuarios.idioma, Integer.Parse(rdbEmpresas.SelectedItem.Value))



    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Page.IsValid Then
            grabarUserProfile()
            '    Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If IsDate(txtFechaNacimiento.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub




    Protected Sub CustomValidator3_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator3.ServerValidate
        Dim namefile As String = FileUpload1.PostedFile.FileName.Substring((FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1))
        If namefile.ToLower = "bmp" Or namefile.ToLower = "gif" Or namefile.ToLower = "jpg" Or namefile.ToLower = "jpeg" Or namefile.ToLower = "png" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If

        If FileUpload1.PostedFile.ContentLength < 800000 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub





    Public maxmin As Integer = 200

    Public Function CrearMinImage(ByVal nombre As String) As Integer
        Dim cadenaPathFile As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "fotousuarios\orig\" & nombre

        Dim cadenaPath As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "fotousuarios\mini\" & nombre
        Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(cadenaPathFile)

        Dim proporcion As Double = getProporcion(image.Width, image.Height, maxmin)
        If proporcion <> 1 And proporcion > 0 Then

            Dim newImage As System.Drawing.Image = image.GetThumbnailImage(image.Width * proporcion, image.Height * proporcion, AddressOf thumbnailCallback, New System.IntPtr)
            newImage.Save(cadenaPath)

            newImage = Nothing

        Else
            image.Save(cadenaPath)
        End If

        image.Dispose()

        cadenaPath = Nothing
        proporcion = Nothing
        cadenaPathFile = Nothing
        image = Nothing

        Return 1

    End Function
    Private Function thumbnailCallback() As Boolean
        Return False
    End Function

    Private Function getProporcion(ByVal width As Integer, ByVal height As Integer, ByVal max As Integer) As Double
        Dim proporcion As Double = 1

        If (width > height Or width = height) And width <> 0 Then
            proporcion = max / width
        Else
            If height > width Then
                proporcion = max / height
            End If
        End If

        Return proporcion
    End Function


    Public Function getNameFile(ByVal clave As Integer, ByVal filex As FileUpload) As String
        If filex.HasFile Then
            Dim namefile As String = clave & "_" & Date.Now.Second & "." & filex.PostedFile.FileName.Substring((filex.PostedFile.FileName.LastIndexOf(".") + 1))
            filex.SaveAs(System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "fotousuarios\orig\" & namefile)
            CrearMinImage(namefile)
            Return namefile

        Else
            Return "default.jpg"
        End If


    End Function



End Class
