
Partial Class Sec_SalonVirtual_TareasRecibidas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not esmaestro() Then
            Response.Redirect("~/logout.aspx")
        End If
        If Not IsPostBack Then
            Ordenar("FechaEnvio", "desc")
        End If



        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & Request("idSalonVirtual")




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



    Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvActividades.Sorting

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
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta()
        Dim ds As Data.DataSet = myr.GetEnviadasParaMeaestroDS(CInt(Request("idSalonVirtual")))


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvActividades.DataSource = mydv
        gvActividades.DataBind()


    End Function

    Public Function getFecha(fechaEnvioTarea As DateTime) As String

        If fechaEnvioTarea.Day = Date.Now.Day And fechaEnvioTarea.Month = Date.Now.Month And fechaEnvioTarea.Year = Date.Now.Year Then
            Return Format(fechaEnvioTarea, "dd/MM/yyyy hh:mm tt")
        Else
            Return Format(fechaEnvioTarea, "dd/MM/yyyy hh:mm tt")
        End If

    End Function



    Function esmaestro() As Boolean
        Dim mysalonVirtual As Know.SalonVirtual
        Dim myuser As MasUsuarios.UserProfile
        mysalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)

        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        If mypermisos.existe Then
            Return True
        Else

            If Session("esAdministrador") Or Session("esGerenciaSalones") Then
                Return True
            End If

            Return False

        End If
    End Function

End Class
