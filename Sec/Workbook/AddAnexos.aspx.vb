
Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Controles_AddAnexos
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
                    Case Contenidos.TipoContenido.Archivo
                        DisplayArchivo1.Visible = True
                  
                    Case Contenidos.TipoContenido.Imagen
                        DisplayImagen1.Visible = True
                    Case Contenidos.TipoContenido.Flash
                        DisplayFlash1.Visible = True
                    Case Contenidos.TipoContenido.Articulate
                        DisplayArticulate1.Visible = True



                End Select




                If Request("regreso") = "carpeta" Then
                    lnkSalirEdicion.NavigateUrl = "~/sec/workbook/carpeta.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion")
                End If

                If Request("idSalonVirtual") <> "" Then
                    lnkSalirEdicion.NavigateUrl = "~/sec/salonvirtual/vercarpeta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idClasificacion=" & myci.idClasificacion & "&idCI=" & myci.id
                End If



            Else
                resetControles()

                If Request("display") <> "" Then
                    Select Case Request("display")
                        Case "image"
                            DisplayImagen1.Visible = True
                        Case "file"
                            DisplayArchivo1.Visible = True
                        Case "flash"
                            DisplayFlash1.Visible = True
                        Case "articulate"
                            DisplayArticulate1.Visible = True
                        Case "mfiles"
                            DisplayMFiles1.Visible = True
                    End Select
                End If
            End If


            'lnkAgregar.NavigateUrl = "~/sec/workbook/addContenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion")

        End If
    End Sub

    'Protected Sub drpSeleccionTipo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpSeleccionTipo.SelectedIndexChanged

    '    resetControles()


    '    Select Case drpSeleccionTipo.SelectedValue

    '        Case "Archivo"
    '            DisplayArchivo1.Visible = True
    '        Case "Imagen"
    '            DisplayImagen1.Visible = True
    '        Case "Flash"
    '            DisplayFlash1.Visible = True
    '        Case "Articulate"
    '            DisplayArticulate1.Visible = True
    '    End Select
    'End Sub


    Sub resetControles()
        DisplayArchivo1.Visible = False
        DisplayImagen1.Visible = False
        DisplayFlash1.Visible = False
        DisplayArticulate1.Visible = False
        DisplayMFiles1.Visible = False
    End Sub

    'Protected Sub imgAnexoImagen_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoImagen.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=image")
    'End Sub

    'Protected Sub imgAnexoFiles_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFiles.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file")
    'End Sub

    'Protected Sub imgAnexoFiles2_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFiles2.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file")
    'End Sub
    'Protected Sub imgAnexoFiles3_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFiles3.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file")
    'End Sub

    'Protected Sub imgAnexoFiles4_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFiles4.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file")
    'End Sub
    'Protected Sub imgAnexoFiles7_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFiles7.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=file")
    'End Sub

    'Protected Sub imgAnexoFlash_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoFlash.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=flash")
    'End Sub

    'Protected Sub imgAnexoArticulate_Click(sender As Object, e As ImageClickEventArgs) Handles imgAnexoArticulate.Click
    '    Response.Redirect("AddAnexos.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") & "&display=articulate")
    'End Sub




End Class
