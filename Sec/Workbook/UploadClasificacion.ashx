<%@ WebHandler Language="VB" Class="Upload" %>

Imports System
Imports System.Web
Imports System.IO


Public Class Upload : Implements IHttpHandler

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

            Dim myCont As Contenidos.Contenido

            myCont = New Contenidos.Contenido
            myCont.idUserProfile = CInt(context.Request.QueryString("idu"))
            myCont.postedFile = postedFile
            myCont.titulo = ""
            myCont.textoCorto = ""
            myCont.textoLargo = ""
            myCont.Tags = ""
            myCont.Add()



            Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem
            myCI.idClasificacion = CInt(context.Request.QueryString("idc"))
            myCI.idRoot = CInt(context.Request.QueryString("idr"))
            myCI.idProc = myCont.id
            myCI.procedencia = myCont.tipo
            myCI.Add()


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