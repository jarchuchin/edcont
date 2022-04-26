
Partial Class Sec_SalonVirtual_CalificacionesActividad
    Inherits System.Web.UI.Page


    Dim myasv As Contenidos.ActividadSalonVirtual

    Public esmaestrovar As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")))
        myasv = New Contenidos.ActividadSalonVirtual(myr.idproc, myr.idsalonvirtual)
        esmaestrovar = EsMaestro()

        If Not IsPostBack Then
            Ordenar("Apellidos", "asc")

            lblpromedio.Text = Format(myr.GetPromedioRaiz(CInt(Request("idR"))) / 10, "0.0")
            Dim myac As Contenidos.Actividad = New Contenidos.Actividad(myr.idProc)
            Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myr.idUserProfile, False)
            lblActividad.Text = myac.titulo
            lblNombre.Text = myu.nombre & " " & myu.apellidos
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



    Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCalificaciones.Sorting
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
        Dim mye As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()
        Dim ds As Data.DataSet = mye.GetDS(CInt(Request("idSalonVirtual")))
        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvCalificaciones.DataSource = mydv
        gvCalificaciones.DataBind()
    End Function

    Public Function getEnviada(ByVal claveUsuario As Integer) As String
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")), myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return "t-mini_icon_dx_ok.fw.png"
        Else
            Return "t-mini_icon_dx_del.fw.png"
        End If
    End Function

    Public Function getFecha(ByVal claveUsuario As Integer) As String
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")), myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return myae.fechaEnvio.ToShortDateString
        Else
            Return "-"
        End If
    End Function

    Public Function getCalificacion(ByVal claveUsuario As Integer) As String
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return Format(myae.calificacion / 10, "0.0")
        Else
            Return "-"
        End If
    End Function



    Public Function getRespuesta(ByVal usuario As Integer) As String
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(CInt(Request("idR")), myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, usuario)
        Dim cadena As String = ""

        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myasv.idActividad)

        Select Case mya.tipodeActividad
            Case Contenidos.ETipodeActividad.Actividad

                If myr.existe And esmaestrovar Then
                    cadena = "~/Sec/SalonVirtual/CalificarRespuesta.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idR=" & Request("idR") & "&idUserProfile=" & myr.idUserProfile & "&pag=calificacionesactividad"
                End If

        End Select



        Return cadena
    End Function


    Public Function EsMaestro() As Boolean

        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
        Return mypermisos.existe
    End Function

End Class
