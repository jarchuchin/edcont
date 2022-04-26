
Partial Class Sec_SalonVirtual_CalificarSubjetivoGrupo
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarDatos()
            Ordenar("Apellidos", "asc")
        End If


        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    End Sub
    Sub cargarDatos()
        Dim mye As Know.ItemEvaluacion = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))
        lbltitulo.Text = mye.titulo

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

    Public numero As Integer = 0

    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAsistenciaFechas.RowDataBound
        numero += 1
    End Sub



    Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvAsistenciaFechas.Sorting
        System.Threading.Thread.Sleep(1000)
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
        Dim mye As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()
        Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idSalonVirtual")))


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvAsistenciaFechas.DataSource = mydv
        gvAsistenciaFechas.DataBind()


    End Function

    Public Function GetCalificacion(ByVal claveusuario As Integer) As String
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, CInt(Request("idItemEvaluacion")), tipoObjeto.ItemEvaluacion.ToString, CInt(Request("idSalonVirtual")), claveusuario)
        If myr.existe Then
            Return Format(myr.calificacion / 10, "0.0")
        Else
            Return "0"
        End If
    End Function

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click

        Dim myie As Know.ItemEvaluacion = New Know.ItemEvaluacion(CInt(Request("idItemEvaluacion")))
        Dim clavesalon As Integer = CInt(Request("idSalonVirtual"))


        For Each row As GridViewRow In gvAsistenciaFechas.Rows

            Dim claveUsuario As Integer = CInt(CType(row.FindControl("txtClave"), TextBox).Text)
            Dim myControlCalificacion As TextBox = CType(row.FindControl("txtCalificacion"), TextBox)
            Dim calificacion As Decimal = 0
            If IsNumeric(myControlCalificacion.Text) Then
                calificacion = CDec(myControlCalificacion.Text)
            End If


            Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myie.id, tipoObjeto.ItemEvaluacion.ToString, clavesalon, claveUsuario)
            If myr.existe Then
                myr.calificacion = CInt(calificacion * 10)
                myr.Update()
            Else
                myr.idUserProfile = claveUsuario
                myr.idRaiz = 0
                myr.idProc = myie.id
                myr.procedencia = tipoObjeto.ItemEvaluacion.ToString
                myr.idSalonVirtual = clavesalon
                myr.titulo = myie.titulo
                myr.texto = ""
                myr.observaciones = ""
                myr.calificacion = CInt(calificacion * 10)
                myr.fechaEnvio = Date.Now
                myr.fechaRevision = Date.Now
                myr.repetir = False
                myr.status = Contenidos.StatusRespuesta.Calificada
                myr.Add()

            End If

            'actualizar calificacion general
            Dim mysvup As New Know.SalonVirtualUserProfile(myr.idUserProfile, myr.idSalonVirtual, False)
            mysvup.calificacionComputada = mysvup.GetCalificacionGeneral(myr.idUserProfile, myr.idSalonVirtual)
            mysvup.Update()

        Next


    End Sub
End Class
