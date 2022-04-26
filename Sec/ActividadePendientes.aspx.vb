Imports System.Data


Partial Class Sec_ActividadePendientes
    Inherits System.Web.UI.Page

    Public appName As String = ""


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        appName = """" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")



        If Not IsPostBack Then
            Dim myr As New Lego.Root()
            Dim ds As DataSet = myr.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True)

            litlibros.Text = ds.Tables(0).Rows.Count
            If ds.Tables(0).Rows.Count > 0 Then
                divLibrosDeTrabajo.Visible = True
            Else
                divLibrosDeTrabajo.Visible = False
            End If

            Dim mysvup As New Know.SalonVirtualUserProfile
            litCursosA.Text = mysvup.Count(CInt(Session("gUserProfileSession").idUserProfile))

            Dim mysv As New Know.SalonVirtual
            ds = mysv.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True, 1000)

            litCursosD.Text = ds.Tables(0).Rows.Count
            If ds.Tables(0).Rows.Count > 0 Then
                divCursosComoDocente.Visible = True
            Else
                divCursosComoDocente.Visible = False
            End If

            Dim myasv As New Contenidos.ActividadSalonVirtual
            litActividadesPendientes.Text = myasv.countActividadesSinResponder(CInt(Session("gUserProfileSession").idUserProfile))


            Dim mya As New Comm.Agenda()



            Dim dv As DataView = mya.GetItemsAgendaTodos(CInt(Session("gUserProfileSession").idUserProfile))

            Dim DomainName As String = HttpContext.Current.Request.Url.Host
            If DomainName = "localhost" Then
                DomainName = HttpContext.Current.Request.Url.Authority

            End If

            Dim portnumber As String = HttpContext.Current.Request.Url.Port
            If portnumber <> 80 Then
                DomainName = DomainName & ":" & portnumber
            End If

            DomainName = HttpContext.Current.Request.Url.Scheme & "://" & DomainName & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/salonvirtual/"


            llenarGrid("Fecha", "asc")


        End If






    End Sub


    Public Function llenarGrid(columna As String, orden As String) As Integer

        Dim myasv As New Contenidos.ActividadSalonVirtual
        Dim ds As DataSet = myasv.GetActiviadesPendientesDS(CInt(Session("gUserProfileSession").idUserProfile))

        Dim dv As DataView = ds.Tables(0).DefaultView

        dv.Sort = columna & " " & orden


        gvListaAlumnos.DataSource = dv
        gvListaAlumnos.DataBind()

        Return 0
    End Function


    Private Sub gvListaAlumnos_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvListaAlumnos.Sorting

        llenarGrid(e.SortExpression, e.SortDirection)
    End Sub


    Public numero As Integer = 0

    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListaAlumnos.RowDataBound
        numero += 1

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim mylbl As Label = CType(e.Row.FindControl("lblFechaA"), Label)
            Dim fecha As Date = CDate(mylbl.Text)
            If fecha <= Date.Now Then
                  e.Row.Style.Add("background-color", "#ffeeba")
            End If
        End If
    End Sub


    Public Function getLiga(claveClasificacionitem As Object, claveSalon As Object, claveTipoDeActividad As Object) As String

        If CInt(claveTipoDeActividad) = 1 Then
            Return "~/sec/salonvirtual/verExamen.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveClasificacionitem
        Else
            Return "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveClasificacionitem
        End If

    End Function


End Class
