Imports System.IO

Partial Class Sec_SalonVirtual_Controles_displayComentarios
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub




    Sub colocarDatos()

        If Request("idA") <> "" Then
            Dim myActividad As New Contenidos.Actividad(CInt(Request("idA")))
            lblactividadid.Text = myActividad.id

            Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myActividad.id, myActividad.tipo.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))


            Dim myrc As New Contenidos.RespuestaComentario

            Me.Repeater1.DataSource = myrc.GetDS(myr.id)
            Me.Repeater1.DataBind()

        End If

        If Request("idR") <> "" Then
            Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
            lblactividadid.Text = myr.idProc

            Dim myrc As New Contenidos.RespuestaComentario

            Me.Repeater1.DataSource = myrc.GetDS(myr.id)
            Me.Repeater1.DataBind()
        End If




    End Sub

    Public Function colocarTexto(claveObservacion As Object) As String

        If Not Convert.IsDBNull(claveObservacion) Then
            Dim regreso As String = CStr(claveObservacion).Replace(vbCr, "<br>")
            regreso = regreso.Replace(vbCrLf, "<br>")
            regreso = regreso.Replace(vbLf, "<br>")
            Return regreso

        Else
            Return ""
        End If

    End Function



    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If Me.Page.IsValid Then
            Dim myr As Contenidos.Respuesta

            Dim myactividad As New Contenidos.Actividad()
            If Request("idA") <> "" Then
                myactividad = New Contenidos.Actividad(CInt(Request("idA")))
                myr = New Contenidos.Respuesta(0, myactividad.id, myactividad.tipo.ToString, CInt(Request("idsalonvirtual")), CInt(Session("guserprofilesession").iduserprofile))
            End If
            If Request("idR") <> "" Then
                myr = New Contenidos.Respuesta(CInt(Request("idR")))
            End If


            Dim myrc As New Contenidos.RespuestaComentario
            myrc.idRespuesta = myr.id
            myrc.idUserProfile = CInt(Session("guserprofilesession").iduserprofile)
            myrc.Observacion = System.Web.HttpUtility.HtmlEncode(txtComentario.Text)
            myrc.fecha = Date.Now
            myrc.Add()




            Me.Repeater1.DataSource = myrc.GetDS(myr.id)
            Me.Repeater1.DataBind()


            txtComentario.Text = ""




        End If


    End Sub

    Public Function esvisible(ByVal claveusuario As Integer) As Boolean
        If claveusuario = CInt(Session("gUserProfileSession").idUserProfile) Then
            Return True
        Else
            Return False

        End If
    End Function
    Protected Sub CustomValidator1_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Dim myrc As New Contenidos.RespuestaComentario

        Dim myActividad As New Contenidos.Actividad(CInt(lblactividadid.Text))


        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myActividad.id, myActividad.tipo.ToString, CInt(Request("idSalonVirtual")), CInt(Session("gUserProfileSession").idUserProfile))


        If myrc.PuedeGrabar(myr.idUserProfile) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If


    End Sub
End Class
