<%@ WebHandler Language="VB" Class="UploadA" %>

Imports System
Imports System.Web
Imports System.IO


Public Class UploadA : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest


        'parametro 0 cotenido
        'parametros 1 userprofile


        context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        context.Response.Expires = -1
        Try
            Dim postedFile As HttpPostedFile = context.Request.Files(0)
            Dim savepath As String = ""
            Dim tempPath As String = ""
            tempPath = ""
            savepath = context.Server.MapPath(tempPath)
            Dim filename As String = postedFile.FileName

            Dim myCA As Contenidos.ContenidoAdjunto
            Dim myCont As Contenidos.Contenido
            Dim myActividad As New Contenidos.Actividad(CInt(context.Request.QueryString("idc")))

            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(context.Request.QueryString("idus"))
            myCont.postedFile = postedFile
            myCont.titulo = ""
            myCont.textoCorto = ""
            myCont.textoLargo = ""
            myCont.Tags = ""
            myCont.Add()

            myCA = New Contenidos.ContenidoAdjunto
            myCA.idProc = myActividad.id
            myCA.Procedencia = myActividad.tipo.ToString
            myCA.idContenido = myCont.id
            myCA.Add()


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