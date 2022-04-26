Imports System.Net.Mail
Imports System.Net
Imports System.Configuration

Partial Class Sec_SalonVirtual_EnviarCorreo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        txtPara.Text = Request("correos")

        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        If myuser.email.Trim = "" Then
            lblMensaje.Visible = True
            btnEnviarCorreoNuevo.Visible = False
        Else
            txtmailfrom.Text = myuser.email.Trim
        End If

        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

    End Sub

    'Protected Sub btnEnviarCorreo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviarCorreo.Click

    '    Dim direcciones As MailAddressCollection = New MailAddressCollection
    '    Dim para As String() = txtPara.Text.Split(",")
    '    Dim i As Integer



    '    Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
    '    Dim MailMsg As New MailMessage()
    '    MailMsg.From = New MailAddress(txtmailfrom.Text)



    '    For i = 0 To para.Length - 1
    '        'direcciones.Add(Trim(para(i)))
    '        If Trim(para(i)).Count > 0 Then
    '            MailMsg.To.Add(Trim(para(i)))
    '        End If

    '    Next


    '    Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


    '    With MailMsg
    '        '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
    '        .Subject = txtAsunto.Text & " - " & mysalon.nombre
    '        .ReplyToList.Add(txtmailfrom.Text)
    '        .Body = "Correo enviado por:  " & myuser.nombre & " " & myuser.apellidos & "<br/>email: " & myuser.email & ", " & myuser.emailGoogle & " <br/><br/>" & txtMensaje.Html
    '        .IsBodyHtml = True


    '    End With

    '    Dim numero As Integer = 0

    '    Dim f As New System.Net.Mail.SmtpClient("smtp.gmail.com")
    '    'f.Host = "127.0.0.1"
    '    f.Port = 587
    '    f.Credentials = New System.Net.NetworkCredential("Skolar@um.edu.mx", "alaskaSkolar")
    '    ' f.Credentials = New System.Net.NetworkCredential()
    '    f.EnableSsl = True

    '    Try
    '        f.Send(MailMsg)
    '        Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
    '    Catch ex As Exception

    '    End Try
    '    f.Send(MailMsg)




    'End Sub

    Protected Sub btnEnviarCorreoNuevo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreoNuevo.Click
        Dim direcciones As MailAddressCollection = New MailAddressCollection
        'Dim direccionesreplayto As MailAddressCollection = New MailAddressCollection

        'direccionesreplayto.Add(txtmailfrom.Text)

        Dim para As String() = txtPara.Text.Split(",")
        Dim i As Integer



        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("info@skolar.online")



        For i = 0 To para.Length - 1
            'direcciones.Add(Trim(para(i)))
            If Trim(para(i)).Count > 0 Then
                MailMsg.To.Add(Trim(para(i)))
            End If

        Next




        Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)


        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = txtAsunto.Text & " - " & mysalon.nombre
            .ReplyToList.Add(txtmailfrom.Text)
            .Body = "Correo enviado por:  " & myuser.nombre & " " & myuser.apellidos & "<br/>email: " & myuser.email & ", " & myuser.emailGoogle & " <br/><br/>" & txtmensaje.Text
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
        Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
        'Catch ex As Exception

        'End Try
        ' f.Send(MailMsg)


    End Sub
End Class
