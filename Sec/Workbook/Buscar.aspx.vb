Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Buscar
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub


    Public claveClasificacion As Integer = 0
    Public root As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        root = CInt(Request("idRoot"))
        If Not IsPostBack Then


            Dim myr As New Lego.Root(CInt(Request("idRoot")))
            lblLibro.Text = myr.titulo


            txtBuscar.Focus()
        End If
        lnkSalirEdicion.NavigateUrl = "~/sec/workbook/explorar.aspx?idRoot=" & Request("idRoot")
    End Sub




    Public Property GridViewSortDirection() As SortDirection
        Get
            If IsNothing(ViewState("sortDirection")) Then
                ViewState("sortDirection") = SortDirection.Ascending
            End If
            Return CType(ViewState("sortDirection"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("sortDirection") = value
        End Set
    End Property


    Public numeroRegistro As Integer


    Protected Sub gvMisSalones_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvContenidos.Sorting
        System.Threading.Thread.Sleep(1500)
        Dim orden As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            Ordenar(orden, "desc")
        Else
            GridViewSortDirection = SortDirection.Ascending
            Ordenar(orden, "asc")
        End If
    End Sub


    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String) As Integer



        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As MasUsuarios.Permiso
        myp = New MasUsuarios.Permiso(myu, mye)

        Dim esAdministrador As Boolean = myp.PAdministracion




        Dim mycont As Contenidos.Contenido = New Contenidos.Contenido()


        Dim ds As Data.DataSet

        claveClasificacion = CInt(Request("idClasificacion"))

        If esAdministrador Then
            ds = mycont.GetDSBuscarTodos(txtBuscar.Text.ToString)
        Else
            ds = mycont.GetDS(Integer.Parse(Session("gUserProfileSession").idUserProfile), txtBuscar.Text.ToString)
        End If



        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvContenidos.DataSource = mydv
        gvContenidos.DataBind()


        Return 1

    End Function



    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Ordenar("Titulo", "asc")
    End Sub

    Public Function getTipo(ByVal clave As Integer, ByVal claveProc As String) As String

        Select Case claveProc
            Case "Actividad"
                Dim tipo As Contenidos.ETipodeActividad = CType(clave, Contenidos.ETipodeActividad)
                Return tipo.ToString
            Case "Contenido"
                Dim tipo As Contenidos.TipoContenido = CType(clave, Contenidos.TipoContenido)
                Return tipo.ToString
            Case "Foro"
                Return "Foro"
        End Select

        Return "n/a"

    End Function



End Class
