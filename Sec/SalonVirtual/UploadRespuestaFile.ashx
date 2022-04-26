<%@ WebHandler Language="VB" Class="UploadRespuestaFile" %>

Imports System
Imports System.Web

Public Class UploadRespuestaFile : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        context.Response.Expires = -1


        Try
            Dim postedFile As HttpPostedFile = context.Request.Files(0)
            Dim savepath As String = ""
            Dim tempPath As String = ""
            tempPath = ""
            savepath = context.Server.MapPath(tempPath)
            Dim filename As String = postedFile.FileName


            'Dim myContenidos As New Contenidos.Contenido(CInt(context.Request.QueryString("idr")))

            Dim claveRespuesta As String = context.Request.QueryString("idr")

            If claveRespuesta = "" Then

            End If

            Dim myra As New Contenidos.RespuestaArchivo
            myra.idRespuesta = 0 ' myR.id
            myra.fechaCreacion = Date.Now

            Dim extension As String = filename.Substring(filename.LastIndexOf(".") + 1)
            Dim nombreoriginal As String = filename.Substring(filename.LastIndexOf("\") + 1)
            Dim nombreGUID As String = Guid.NewGuid.ToString

            myra.nombre = nombreGUID & "." & extension
            myra.nombreOriginal = nombreoriginal
            myra.espacio = postedFile.ContentLength
            myra.Add()






            ' postedFile.SaveAs(savepath & "nombrearhivo")
            context.Response.Write(filename)
            context.Response.StatusCode = 200
        Catch ex As Exception
            context.Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class