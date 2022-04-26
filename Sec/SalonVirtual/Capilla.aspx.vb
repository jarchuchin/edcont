
Partial Class Sec_SalonVirtual_Capilla
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
            iniciarControl()
        End If
    End Sub

    Sub colocardatos()
        If Request("idSalonVirtualCapilla") <> "" Then
            Dim mybsv As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla(CInt(Request("idSalonVirtualCapilla")))
            txtmensaje.Text = mybsv.Texto
            drpopcion.SelectedValue = mybsv.TipoCapilla.ToString
            btnborrar.Visible = True

        End If
    End Sub


    Sub iniciarControl()

        If Request("idSalonVirtual") <> "" Then
            Dim mysvCapilla As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla
            DataList1.DataSource = mysvCapilla.GetDR(CInt(Request("idSalonVirtual")), 0)
            DataList1.DataBind()


            Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

            lnkMuro.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
            lnkMuro.Text = mysv.nombre
            lbltitulo.Text = mysv.nombre


        End If


    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Request("idSalonVirtualCapilla") <> "" Then
            editar()
        Else
            grabar()
        End If
        Response.Redirect("Default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Sub editar()

        Dim mybsv As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla(CInt(Request("idSalonVirtualCapilla")))
        mybsv.Texto = txtmensaje.Text
        mybsv.TipoCapilla = drpopcion.SelectedValue
        mybsv.Update()

    End Sub


    Sub grabar()

        Dim mybsv As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla()
        mybsv.idUserProfile = Integer.Parse(Session("gUserProfileSession").idUserProfile)
        mybsv.idSalonVirtual = Integer.Parse(Request("idSalonVirtual"))
        mybsv.TipoCapilla = drpopcion.SelectedValue
        mybsv.Fecha = Date.Now
        mybsv.texto = txtmensaje.Text
        mybsv.Add()

    End Sub

    Protected Sub btnborrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnborrar.Click
        System.Threading.Thread.Sleep(1500)
        Dim mybsv As Know.SalonVirtualCapilla = New Know.SalonVirtualCapilla(CInt(Request("idSalonVirtualCapilla")))
        mybsv.Remove()
        Response.Redirect("Default.aspx?idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub

    Public esmaestro As Boolean = False

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


        Return "~/sec/showfile.aspx?idUserProfile=" & claveUsuario
    End Function
End Class
