Imports System.IO


Partial Class Sec_Administracion_Prontuarios
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtfecha.Text = Date.Now.AddDays(-30).ToShortDateString


        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myc As New Contenidos.Contenido

        Dim dr As System.Data.SqlClient.SqlDataReader = myc.getProntuarios(CDate(txtfecha.Text))
        Dim pathArchivos As String = ConfigurationManager.AppSettings("carpetaArchivos")

        Dim archivo1 As String = ""
        Dim archivo2 As String = ""
        Dim cadena As String = ""

        Do While dr.Read

            Try
                archivo1 = pathArchivos & "files\" & dr("idContenido") & "." & dr("extension")
                archivo2 = pathArchivos & "prontuarios\" & dr("idContenido") & "_" & dr("nombreOriginal")
                FileCopy(archivo1, archivo2)
                cadena = cadena & "OK --- " & archivo1 & ", " & archivo2 & "<br>"

            Catch ex As Exception
                cadena = cadena & "Error --- " & archivo1 & ", " & archivo2 & "<br>"
            End Try
            
            archivo1 = ""
            archivo2 = ""

        Loop

        lblmensaje.Text = cadena


    End Sub
End Class
