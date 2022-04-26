Imports System.IO

Partial Class Sec_SalonVirtual_Controles_displayComentarios
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Public claveidProc As Integer
    Public claveProcedencia As String
    Public claveci As Integer
    Public paginaregreso As String


    Sub colocarDatos()
        hdidCI.Value = Request("idCI")
        hdpag.Value = Path.GetFileName(My.Request.CurrentExecutionFilePath.ToLower())


        hdidproc.Value = claveidProc
        hdProcedencia.Value = claveProcedencia

        Dim myc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion
        Me.Repeater1.DataSource = myc.GetDS(CInt(hdidproc.Value), hdProcedencia.Value, CInt(Request("idSalonVirtual")))
        Me.Repeater1.DataBind()

        imgrating.ImageUrl = "~/images/userrating" & myc.GetPromedio(CInt(hdidproc.Value), hdProcedencia.Value, CInt(Request("idSalonVirtual"))) & ".jpg"

    End Sub

    Protected Sub lnkComentario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkComentario.Click

        Panel1.Visible = True
        lnkComentario.Visible = False

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Panel1.Visible = False
        lnkComentario.Visible = True

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        If txtComentario.Text <> "" And Me.rbdCalificacion.SelectedValue <> "" Then
            Dim myc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion
            myc.idProc = CInt(hdidproc.Value)
            myc.Procedencia = hdProcedencia.Value
            myc.idSalonVirtual = CInt(Request("idSalonVirtual"))
            myc.idUserProfile = CInt(Session("gUserProfileSession").idUserProfile)
            myc.Calificacion = CInt(Me.rbdCalificacion.SelectedValue)
            myc.fecha = Date.Now
            myc.Observacion = txtComentario.Text
            myc.Add()

            lnkComentario.Visible = True
            txtComentario.Text = ""

            Me.Repeater1.DataSource = myc.GetDS(CInt(hdidproc.Value), hdProcedencia.Value, CInt(Request("idSalonVirtual")))
            Me.Repeater1.DataBind()

            Panel1.Visible = False
        Else
            lblMensaje.Visible = True

        End If


    End Sub

    Public Function esvisible(ByVal claveusuario As Integer) As Boolean
        If claveusuario = CInt(Session("gUserProfileSession").idUserProfile) Then
            Return True
        Else
            Return False

        End If
    End Function
End Class
