﻿Imports System.Globalization
Imports System.Threading

Partial Class Sec_Workbook_AddContenido
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            autorizacion()
            colocarDatos()
        End If
    End Sub



    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Sub colocarDatos()
        If Request("idRoot") <> "" Then
            lnkSalirEdicion.NavigateUrl = "~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot")

            If Request("regreso") = "carpeta" Then
                lnkSalirEdicion.NavigateUrl = "~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&regreso=" & Request("regreso")
            End If

            resetControles()

            If Request("idCI") <> "" Then
                Dim myci As New Lego.ClasificacionItem(CInt(Request("idCI")))
                Dim myc As New Contenidos.Contenido(myci.idProc)

                resetControles()

                Select Case myc.idTipoContenido
                  
                    Case Contenidos.TipoContenido.Texto
                        DisplayLectura1.Visible = True
                    Case Else
                        Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idCI=" & Request("idCI") & "&idClasificacion=" & Request("idClasificacion"))

                End Select





                If Request("idSalonVirtual") <> "" Then
                    lnkSalirEdicion.NavigateUrl = "~/sec/salonvirtual/vercarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id
                End If
            Else
                DisplayLectura1.Visible = True
            End If


			'lnkAgregar.NavigateUrl = "~/sec/workbook/addContenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion")

        End If
    End Sub

    


    Sub resetControles()
        '    DisplayArchivo1.Visible = False
        DisplayLectura1.Visible = False
        '  DisplayImagen1.Visible = False
        '     DisplayFlash1.Visible = False


    End Sub
End Class
