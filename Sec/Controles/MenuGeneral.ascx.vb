Imports System.Data

Partial Class Sec_Controles_MenuGeneral
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            colocar()
        End If

    End Sub




    Sub colocar()

        liAdministracion.Visible = Session("esAdministrador")
        '  liBuscarSalones.Visible = Session("esGerenciaSalones")


        Dim myr As New Lego.Root()
        Dim dsLibros As DataSet = myr.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True)
        Dim mysv As New Know.SalonVirtual
        Dim dsSalonesMestro As DataSet = mysv.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True, 1000)

        Dim haySalones As Boolean = False
        If dsSalonesMestro.Tables(0).Rows.Count > 0 Then
            haySalones = True
        End If
        Dim hayLibros As Boolean = False
        If dsLibros.Tables(0).Rows.Count > 0 Then
            hayLibros = True
        End If


        Dim url As String = HttpContext.Current.Request.Url.AbsolutePath.Substring(HttpContext.Current.Request.Url.AbsolutePath.LastIndexOf("/") + 1).ToLower
        Select Case url
            Case "home.aspx"
                If HttpContext.Current.Request.Url.AbsolutePath.ToLower.Contains("workbook") Then
                    liLibros.Attributes.Add("class", "active")
                Else
                    liInicio.Attributes.Add("class", "active")
                End If



            Case "default.aspx"
                liCursosAlumno.Attributes.Add("class", "active")
            Case "defaultDocente.aspx"
                liCursosDocente.Attributes.Add("class", "active")
            Case "libros.aspx"
                liLibros.Attributes.Add("class", "active")
            Case "biblioteca.aspx"
                libibliotecas.Attributes.Add("class", "active")

            Case Else
                If HttpContext.Current.Request.Url.AbsolutePath.ToLower.Contains("workbook") Then
                    liLibros.Attributes.Add("class", "active")
                End If
                If HttpContext.Current.Request.Url.AbsolutePath.ToLower.Contains("administracion") Then
                    liAdministracion.Attributes.Add("class", "active")
                End If
        End Select

        If liAdministracion.Visible Then
            liMensaje.Visible = True
        Else
            liMensaje.Visible = False
        End If


        liCursosDocente.Visible = haySalones
        liLibros.Visible = hayLibros

    End Sub


End Class
