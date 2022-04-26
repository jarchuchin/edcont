Imports System.Net.Mail


Partial Class Sec_PagoEnLineaConfirmacion
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()

        If Session("gUserProfileSession").nombre <> "" Then

            Dim myu As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.existe Then
                Dim myue As New MasUsuarios.EmpresaUserProfile(myu.id, 4, "")
                If myue.existe Then
                    lblAlumno.Text = myue.claveAux1 & " - " & Session("gUserProfileSession").nombre


                    If Request("codigo") <> "" Then



                        txtpago.Text = Request("codigo")
                        txtcantidad.Text = CType(Session("objPago"), ServiceReference1.getPagoResponse).respuesta.totalAmount
                        txtFecha.Text = CType(Session("objPago"), ServiceReference1.getPagoResponse).respuesta.settlementSubmissionDate


                        enviarMail(myue.claveAux1, Session("gUserProfileSession").nombre, Request("codigo"))
                    Else
                        Response.Redirect("PagoEnLinea.aspx")
                    End If
                Else
                    Response.Redirect("PagoEnLinea.aspx")
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If
        Else
            Response.Redirect("~/logout.aspx")
        End If




    End Sub


    Function enviarMail(matricula As String, nombre As String, codigo As String) As Integer


        Dim MailMsg As New MailMessage()
        MailMsg.From = New MailAddress("Skolar@um.edu.mx")
        MailMsg.To.Add("umvirtual@um.edu.mx")
        'MailMsg.To.Add("")


        Dim monto As String = CType(Session("objPago"), ServiceReference1.getPagoResponse).respuesta.totalAmount

        With MailMsg
            '.From = New MailAddress(myuser.emailGoogle, myuser.nombre & " " & myuser.apellidos)
            .Subject = "Pago del alumno: " & matricula & " - " & nombre
            .ReplyToList.Add("Skolar@um.edu.mx")
            .Body = "Hola:<br/><br/>Se ha enviado el pago a traves de SkolarPay del alumno" & nombre & "<br/>Con el número de matricula: <b>" & matricula & "</b/><br/>Código de recepción de pago: " & codigo & "<br/><br/>Monto: " & monto & "<br/><br/> Favor de confirmar la recepción del pago con los datos del banco<br/><br/><br/><br/><br/><br/>Correo enviado de forma automática por el Skolar"
            .IsBodyHtml = True


        End With

        Dim numero As Integer = 0

        Dim f As New System.Net.Mail.SmtpClient("smtp.gmail.com")
        'f.Host = "127.0.0.1"
        f.Port = 587
        f.Credentials = New System.Net.NetworkCredential("Skolar@um.edu.mx", "alaskaSkolar")
        ' f.Credentials = New System.Net.NetworkCredential()
        f.EnableSsl = True

        Try
            f.Send(MailMsg)
            'Response.Redirect("EnviarCorreoConfirmacion.aspx?idSalonVirtual=" & mysalon.id)
        Catch ex As Exception

        End Try
        ' f.Send(MailMsg)

        Return 0

    End Function


End Class
