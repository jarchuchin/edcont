Imports System.IO


Partial Class Sec_SalonVirtual_Boletin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
            iniciarControl()
        End If
    End Sub

    Sub colocardatos()
        If Request("idBoletinSalonVirtual") <> "" Then
            Dim mybsv As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual(CInt(Request("idBoletinSalonVirtual")))
            txtmensaje.Text = mybsv.texto
            btnborrar.Visible = True

        End If


        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkMuro.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMuro.Text = mysv.nombre
        lbltitulo.Text = mysv.nombre


    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click

        If Request("idBoletinSalonVirtual") <> "" Then
            editar()
        Else
            grabar()
        End If
        Response.Redirect("Default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Sub editar()

        Dim mybsv As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual(CInt(Request("idBoletinSalonVirtual")))
        mybsv.texto = txtmensaje.Text
        mybsv.Update()

    End Sub


    Sub grabar()

        Dim mybsv As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual()
        mybsv.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        mybsv.idSalonVirtual = Integer.Parse(Request("idSalonVirtual"))
        mybsv.fecha = Date.Now
        mybsv.texto = txtmensaje.Text
        mybsv.Add()

    End Sub

    Protected Sub btnborrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnborrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim mybsv As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual(CInt(Request("idBoletinSalonVirtual")))
        mybsv.Remove()
        Response.Redirect("Default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Public esmaestro As Boolean = False

    Sub iniciarControl()

        If Request("idSalonVirtual") <> "" Then
            Dim myBoletin As Know.BoletinSalonVirtual = New Know.BoletinSalonVirtual
            DataList1.DataSource = myBoletin.GetDR(CInt(Request("idSalonVirtual")), 0)
            DataList1.DataBind()
        End If


    End Sub

    Public Function presentar(ByVal claveUsuario As Integer) As Boolean
        If esmaestro Then
            Return True
        Else
            If claveUsuario = CInt(Session("gUserProfileSession").idUserProfile) Then
                Return True
            Else
                Return False
            End If
        End If

    End Function


    Public Function getImagen(claveFoto As Object, claveClaveAux1 As String, claveUsuario As Integer) As String




        Return "http://Skolar.online/sec/showfile.aspx?idUserProfile=" & claveUsuario
    End Function



    Function getFoto(ByVal claveAlumno As String, ByVal claveMaestro As String) As String


        If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveAlumno & ".jpg") Then
            Return "~/sec/Usuarios/Fotos/" & claveAlumno & ".jpg"
        Else
            If File.Exists(ConfigurationManager.AppSettings("carpetaPrincipal") & "\sec\Usuarios\Fotos\" & claveMaestro & ".jpg") Then
                Return "~/sec/Usuarios/Fotos/" & claveMaestro & ".jpg"
            Else
                Return "~/images/pagina/IconAlumno.jpg"
            End If

        End If

    End Function

End Class
