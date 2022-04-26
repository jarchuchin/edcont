Imports System.IO

Partial Class Sec_SalonVirtual_Controles_displayRespuestaArchivos
    Inherits System.Web.UI.UserControl

    Public idRespuesta As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
            hdid.Value = idRespuesta
            llenarDatos()
        End If
    End Sub


    Sub llenarDatos()
        Dim myra As Contenidos.RespuestaArchivo = New Contenidos.RespuestaArchivo
        Dim cadena As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/showFile.aspx?idRespuestaArchivo="
        Dim i As Integer = 0
        ' chkAdjuntos.Items.Clear()


        If hdid.Value <> "" Then
            If CInt(hdid.Value) > 0 Then
                'chkAdjuntos.DataSource = myra.GetDR(CInt(hdid.Value))
                'chkAdjuntos.DataValueField = "idRespuestaArchivo"
                'chkAdjuntos.DataTextField = "NombreOriginal"
                'chkAdjuntos.DataBind()
                'For i = 0 To chkAdjuntos.Items.Count - 1
                '    myra = New Contenidos.RespuestaArchivo(CInt(chkAdjuntos.Items(i).Value))
                '    chkAdjuntos.Items(i).Text = "<a href='" & cadena & chkAdjuntos.Items(i).Value & "'  class=""btn-link"" >&nbsp;&nbsp;" & myra.nombreOriginal & "</a>"
                'Next



                gvRA.DataSource = myra.GetDR(CInt(hdid.Value))
                gvRA.DataBind()



            End If

        End If

        If gvRA.Rows.Count > 0 Then
            ' chkAdjuntos.Visible = True

            lnkBorrar.Visible = EsMaestro()

            Dim myr As New Contenidos.Respuesta(myra.idRespuesta)
            If myr.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile) Then
                lnkBorrar.Visible = True
            End If

        Else
            '  chkAdjuntos.Visible = False
            lnkBorrar.Visible = False
        End If




    End Sub


    Protected Sub lnkBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBorrar.Click



        'Dim i As Integer
        Dim pathfile As String = ConfigurationManager.AppSettings("carpetaArchivos") & "Respuestas\"
        'For i = 0 To chkAdjuntos.Items.Count - 1
        '    If chkAdjuntos.Items(i).Selected Then
        '        Dim myra As Contenidos.RespuestaArchivo = New Contenidos.RespuestaArchivo(CInt(chkAdjuntos.Items(i).Value))
        '        If myra.Remove > 0 Then
        '            Dim cadena As String = pathfile & myra.nombre
        '            If File.Exists(cadena) Then
        '                File.Delete(cadena)
        '            End If

        '        End If



        '    End If
        'Next




        For Each gv As GridViewRow In gvRA.Rows
            Dim chk1 As CheckBox = CType(gv.FindControl("chkAdj"), CheckBox)
            Dim hd1 As HiddenField = CType(gv.FindControl("hdidgv"), HiddenField)

            If chk1.Checked Then
                Dim myra As New Contenidos.RespuestaArchivo(CInt(hd1.Value))
                If myra.Remove > 0 Then
                    Dim cadena As String = pathfile & myra.nombre
                    If File.Exists(cadena) Then
                        File.Delete(cadena)
                    End If
                    cadena = Nothing
                End If
                myra = Nothing
            End If

        Next

        llenarDatos()
    End Sub


    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function


End Class