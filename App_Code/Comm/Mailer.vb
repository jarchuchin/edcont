Imports System.Net.Mail
Imports System.Configuration
Imports System.ComponentModel

Namespace Comm
	Public Class Mailer

		Public Sub New()
		End Sub

		Public Sub SendMail(ByVal from As MailAddress, ByVal [to] As MailAddress, ByVal subject As String, ByVal body As String)
			Dim MailMsg As New MailMessage(from, [to])
			With MailMsg
				.Subject = subject
				.Body = body
				.IsBodyHtml = False
			End With

			Dim emailClient As New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("cSMTPServer"))
			AddHandler emailClient.SendCompleted, New SendCompletedEventHandler(AddressOf SendCompletedCallback)
			emailClient.SendAsync(MailMsg, "testing")
		End Sub

		Private Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
		End Sub
	End Class
End Namespace