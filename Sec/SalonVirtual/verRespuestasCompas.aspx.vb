
Partial Class Sec_SalonVirtual_verRespuestasCompas
    Inherits System.Web.UI.Page

    Dim myasv As Contenidos.ActividadSalonVirtual

    Public esmaestrovar As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        esmaestrovar = EsMaestro()
        Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

        myasv = New Contenidos.ActividadSalonVirtual(myci.idProc, CInt(Request("idSalonVirtual")))
        If Not IsPostBack Then
            Ordenar("Apellidos", "asc")
            Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta()
            lblpromedio.Text = myae.GetPromedioActividad(0, myci.idProc, myci.procedencia, CInt(Request("idSalonVirtual")))
            Dim myac As Contenidos.Actividad = New Contenidos.Actividad(myci.idProc)
            lblActividad.Text = myac.titulo


            Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))



            ' ColocarBread
            Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)




            Dim objClasificacion As New Lego.Clasificacion(myci.idClasificacion)


            If esmaestrovar Then
                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
            Else
                lnkMisCursos.Text = labelCursosComoAlumno.Text
                lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
            End If
            lnkCurso.Text = mysv.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

            lnkUnidad.Text = objClasificacion.titulo
            lnkUnidad.NavigateUrl = "~/sec/salonvirtual/VerCarpeta.aspx?idSalonVirtual=" & idSalonVirtual & "&idClasificacion=" & objClasificacion.id


            lnkActividad.Text = myac.titulo

            lnkActividad.NavigateUrl = "~/sec/salonvirtual/VerActividad.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idRoot=" & myci.idRoot & "&idClasificacion=" & objClasificacion.id & "&idCI=" & myci.id



        End If


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
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return "ok.gif"
        Else
            Return "cancel.gif"
        End If
    End Function

    Public Function getFecha(ByVal claveUsuario As Integer) As String
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return myae.fechaEnvio.ToShortDateString
        Else
            Return "-"
        End If
    End Function

    Public Function getCalificacion(ByVal claveUsuario As Integer) As String
        Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        If myae.existe Then
            Return myae.calificacion
        Else
            Return "-"
        End If
    End Function



    Public Function getRespuesta(ByVal usuario As Integer) As String
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, usuario)
        Dim cadena As String = ""

        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myasv.idActividad)

        Select Case mya.tipodeActividad
            Case Contenidos.ETipodeActividad.Actividad
                cadena = ""
                If myr.existe Then
                    If mya.mostrarObservaciones Then
                        cadena = "~/Sec/SalonVirtual/verRespuestaCompa.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idR=" & myr.id & "&idCI=" & Request("idCI")
                    Else
                        cadena = ""
                    End If

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
