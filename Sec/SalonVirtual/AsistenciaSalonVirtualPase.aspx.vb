
Partial Class Sec_SalonVirtual_AsistenciaSalonVirtualPase
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            revisarLista()
            Ordenar("Apellidos", "asc")
            Dim mya As Know.Asistencia = New Know.Asistencia(CInt(Request("idAsistencia")))
            lblFechaActual.Text = mya.fecha.ToLongDateString

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


    Sub revisarLista()

        Dim mye As Know.AsistenciaLista = New Know.AsistenciaLista()
        Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idAsistencia")))

        Dim mysvu As New Know.SalonVirtualUserProfile
        Dim dsLista As Data.DataSet = mysvu.GetDS(CInt(Request("idSalonVirtual")))
        Dim dvLista As Data.DataView = dsLista.Tables(0).DefaultView

        Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        Dim dv As Data.DataView
        Dim cadena As String = ""

        For Each dr As Data.DataRowView In dvLista
            dv = ds.Tables(0).DefaultView
            dv.RowFilter = "idUserProfile=" & dr("idUserProfile")

            cadena = cadena & dr("idUserProfile") & "-" & dv.Count & "//"

            If dv.Count = 0 Then
                'mysvu = New Know.SalonVirtualUserProfile
                'mysvu.idSalonVirtual = CInt(Request("idSalonVirtual"))
                'mysvu.idUserProfile = CInt(dr("idUserProfile"))
                'mysvu.idUserProfileCalificador = 0
                'mysvu.status = "I"
                'mysvu.fechaInicio = mysv.fechaInicio
                'mysvu.fechaFin = mysv.fechaFin
                'mysvu.calificacion = 0
                'mysvu.calificacionComputada = 0
                'mysvu.puntosExtras = 0
                'mysvu.calificacionDiferida = False
                'mysvu.fechaConvenio = Date.Now
                'mysvu.Add()
                mye = New Know.AsistenciaLista
                mye.idAsistencia = CInt(Request("idAsistencia"))
                mye.idUserProfile = CInt(dr("idUserProfile"))
                mye.asistencia = False
                mye.retraso = False
                mye.inasistencia = False
                mye.Add()


                cadena = cadena & "--Entro--"
            End If
        Next


        ' lblActividad.Text = cadena
    End Sub


    Public Function EsMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim objUserProfile As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim objPermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(objUserProfile, objSalonVirtual)

        Return objPermisos.existe
    End Function
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
        Dim mye As Know.AsistenciaLista = New Know.AsistenciaLista()
        Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idAsistencia")))


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvAsistenciaFechas.DataSource = mydv
        gvAsistenciaFechas.DataBind()


    End Function



    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAsistenciaFechas.RowDataBound

        If e.Row.DataItemIndex >= 0 Then


            Dim mycontrol As RadioButtonList = CType(e.Row.FindControl("rdbList"), RadioButtonList)
            Dim claveUsuario As Integer = CInt(gvAsistenciaFechas.DataKeys(e.Row.DataItemIndex).Value)

            If Not IsNothing(mycontrol) Then
                Dim myaf As Know.AsistenciaLista = New Know.AsistenciaLista(CInt(Request("idAsistencia")), claveUsuario)
                mycontrol.Items(0).Selected = myaf.asistencia
                mycontrol.Items(1).Selected = myaf.retraso
                mycontrol.Items(2).Selected = myaf.inasistencia
            End If
        End If

    End Sub

    Protected Sub btngrabar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar1.Click
        grabar()
    End Sub

    Public Function grabar() As Integer
        System.Threading.Thread.Sleep(1500)
        Dim i As Integer = 0
        Dim myaf As Know.AsistenciaLista
        Dim mycontrol As RadioButtonList
        For i = 0 To gvAsistenciaFechas.Rows.Count - 1
            Dim claveUsuario As Integer = CInt(gvAsistenciaFechas.DataKeys(i).Value)
            mycontrol = CType(gvAsistenciaFechas.Rows(i).FindControl("rdbList"), RadioButtonList)
            myaf = New Know.AsistenciaLista(CInt(Request("idAsistencia")), claveUsuario)
            myaf.asistencia = mycontrol.Items(0).Selected
            myaf.retraso = mycontrol.Items(1).Selected
            myaf.inasistencia = mycontrol.Items(2).Selected
            myaf.Update()
        Next

    End Function

    Protected Sub btngrabar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar2.Click
        grabar()
    End Sub
End Class
