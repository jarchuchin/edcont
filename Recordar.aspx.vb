Imports System.Net.Mail
Imports System.Globalization
Imports System.Threading


Partial Class Recordar
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim myu As New MasUsuarios.UserProfile(txtlogin.Text)
        If myu.existe Then
            EnviarCorreo(myu)
        Else
            lblMensajeError.Visible = True

        End If
    End Sub



    Sub enviarMensaje(myu As MasUsuarios.UserProfile)
        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("Skolar@skolar.online")

        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = lblRecordar.Text
            .Body = lblHola.Text & " " & myu.nombre & "<br/><br/> " & lblTeenviamos.Text & "<br/><br/>" & lblNombre.Text & myu.nombre & " " & myu.apellidos & "<br/>" & lblUsuario.Text & " <b>" & myu.login & "</b><br/>" & lblPass.Text & " <b>" & myu.password & "</b> <br/><br/> <br/><br/> <br/><br/>" & lblMensajeFinal.Text & " <br/><br/> <br/><br/>"
            .IsBodyHtml = True
            .To.Add(txtlogin.Text)

        End With

        Dim numero As Integer = 0

        Dim f As New System.Net.Mail.SmtpClient("smtp.gmail.com")
        'f.Host = "127.0.0.1"
        f.Port = 587
        f.Credentials = New System.Net.NetworkCredential("Skolar@skolar.online", "alaskaSkolar")
        ' f.Credentials = New System.Net.NetworkCredential()
        f.EnableSsl = True

        Try
            f.Send(MailMsg)
            Session("correoEnviado") = True
            Response.Redirect("RecordarConfirmar.aspx")
        Catch ex As Exception

        End Try
        f.Send(MailMsg)
    End Sub


    Public Function GetMensaje(myu As MasUsuarios.UserProfile) As String


        Return lblHola.Text & " " & myu.nombre & "<br/><br/> " & lblTeenviamos.Text & "<br/><br/>" & lblNombre.Text & myu.nombre & " " & myu.apellidos & "<br/>" & lblUsuario.Text & " <b>" & myu.login & "</b><br/>" & lblPass.Text & " <b>" & myu.password & "</b> <br/><br/> <br/><br/> <br/><br/>" & lblMensajeFinal.Text & " <br/><br/> <br/><br/>"

    End Function

    Public Function EnviarCorreo(objUsuario As MasUsuarios.UserProfile) As Integer

        ' Dim myup As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim direcciones As MailAddressCollection = New MailAddressCollection
        'Dim direccionesreplayto As MailAddressCollection = New MailAddressCollection

        'direccionesreplayto.Add(txtmailfrom.Text)


        Dim i As Integer



        ' Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("info@skolar.online")
        MailMsg.To.Add(Trim(objUsuario.email))







        ' Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = lblRecordar.Text & " - " & objUsuario.nombre & " " & objUsuario.apellidos
            ' .ReplyToList.Add(txtmailfrom.Text)
            .Body = GetMensaje(objUsuario)
            .IsBodyHtml = True
            '.ReplyToList = direccionesreplayto
            '  .Headers.Add("X-SES-CONFIGURATION-SET", "ConfigSet")
        End With

        Dim numero As Integer = 0

        Dim f As New System.Net.Mail.SmtpClient("email-smtp.us-east-2.amazonaws.com")
        f.UseDefaultCredentials = False

        f.Port = 587


        ' f.Credentials = New System.Net.NetworkCredential()



        f.Credentials = New System.Net.NetworkCredential("AKIA4Q73D2ZEPWTSJE6K", "BDe+3nCDgRQ+h8HfccP1UyEb6G3DiqjSXUrX+x5PdpAF")
        f.EnableSsl = True
        f.DeliveryMethod = SmtpDeliveryMethod.Network
        'Try
        f.Send(MailMsg)
        '   Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
        'Catch ex As Exception

        'End Try
        ' f.Send(MailMsg)
        Session("correoEnviado") = True
        Response.Redirect("RecordarConfirmar.aspx")



        Return 1
    End Function


    Private Sub Recordar_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("correoEnviado") = True Then
            Response.Redirect("RecordarConfirmar.aspx")
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
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


        litscript.Text = cadena.ToString


    End Sub



    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

End Class
