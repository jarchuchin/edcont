
Partial Class Sec_SalonVirtual_AsistenciaSalonVirtual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Ordenar("Fecha", "asc")

            txtfecha.Text = Date.Now.ToShortDateString


        End If

        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))


        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

        If EsMaestro() Then
            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
        Else
            lnkMisCursos.Text = labelCursosComoAlumno.Text
            lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

    End Sub



    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermisos.existe
    End Function


    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles gvAsistencias.ServerValidate
        If IsDate(txtfecha.Text) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        System.Threading.Thread.Sleep(1500)
        If Page.IsValid Then
      
            grabar()
        End If

        Ordenar("Fecha", "Asc")
        btnNuevo.Visible = True
        PanelFecha.Visible = False
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

    

    Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvAsistenciaFechas.Sorting

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
        Dim mye As Know.Asistencia = New Know.Asistencia()
        Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idSalonVirtual")))


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvAsistenciaFechas.DataSource = mydv
        gvAsistenciaFechas.DataBind()


    End Function


    Sub grabar()
        Dim myAsist As Know.Asistencia = New Know.Asistencia
        myAsist.idSalonVirtual = Integer.Parse(Request("idSalonVirtual"))
        myAsist.fecha = CDate(txtfecha.Text)
        myAsist.Add()
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        System.Threading.Thread.Sleep(1500)
        PanelFecha.Visible = True

    End Sub

    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAsistenciaFechas.RowDataBound


        Dim mycontrol As LinkButton = CType(e.Row.FindControl("lnkBorrar"), LinkButton)
        If Not IsNothing(mycontrol) Then
            mycontrol.Attributes.Add("onClick", "return confirm('Deseas borrar la fecha del registro de asistencias?');")
        End If

    End Sub

    Protected Sub gvAsistenciaFechas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAsistenciaFechas.RowDeleting

        Dim mya As Know.Asistencia = New Know.Asistencia(Convert.ToInt32(gvAsistenciaFechas.DataKeys(e.RowIndex).Value.ToString))
        mya.Remove()
        Ordenar("Fecha", "asc")
        PanelFecha.Visible = False
        btnNuevo.Visible = True



    End Sub


    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

    End Sub
End Class
