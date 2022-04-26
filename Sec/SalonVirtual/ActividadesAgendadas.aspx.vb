
Partial Class Sec_SalonVirtual_ActividadesAgendadas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Ordenar("Fecha", "asc")
        End If

        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))

        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)


        lnkMisCursos.Text = labelCursosComoDocente.Text
        lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual

        lnkCalendario.NavigateUrl = "~/sec/salonVirtual.aspx?idSalonVirtual=" & idSalonVirtual


        lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

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

    Protected Sub gvAsistenciaFechas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListaAlumnos.RowDataBound
        numero += 1
    End Sub



    Protected Sub gvSalidas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvListaAlumnos.Sorting

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
        Dim mye As Comm.Agenda = New Comm.Agenda()
        Dim ds As Data.DataSet = mye.GetDSLista(CInt(Request("idSalonVirtual")))


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvListaAlumnos.DataSource = mydv
        gvListaAlumnos.DataBind()


    End Function

    'Protected Sub lnkEnviarCorreo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviarCorreo1.Click
    '    Response.Redirect("EnviarCorreo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correos=" & enviar())

    'End Sub



    Public Function GetCalificacion(ByVal claveusuario As Integer) As String
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
        Return Format(CDec(mysvu.GetCalificacionGeneral(claveusuario, CInt(Request("idSalonVirtual")))) / CDec(10.0), "0.00")

    End Function

    Public Function getImagen(objClaveAux As Object, claveUsuario As Integer) As String



        Return "http://Skolar.online/sec/showfile.aspx?idUserProfile=" & claveUsuario
    End Function


    Public Function getliga(claveCI As Object, claveSalon As Integer, claveproc As Integer, claveprocedencia As String) As String

        Select Case claveprocedencia
            Case "SalonVirtual"
                Return "~/sec/salonvirtual/home.aspx?idSalonVirtual=" & claveSalon
            Case "Actividad"
                Dim myci As New Lego.ClasificacionItem(CInt(claveCI))
                Dim mya As New Contenidos.Actividad(myci.idProc)
                If mya.tipodeActividad = 1 Then
                    Return "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI
                Else
                    Return "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI
                End If

            Case "Contenido"

                Dim myci As New Lego.ClasificacionItem(CInt(claveCI))
                Dim mya As New Contenidos.Contenido(myci.idProc)

                Select Case mya.idTipoContenido
                    Case 1 'liga
                        Return "~/sec/salonvirtual/home.aspx?idSalonVirtual=" & claveSalon
                    Case 2 'archivo
                        Return "~/sec/salonvirtual/verArchivo.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI
                    Case 3 'imagen
                        Return "~/sec/salonvirtual/verImagen.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI
                    Case 4 'texto
                        Return "~/sec/salonvirtual/verTexto.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI
                    Case Else
                        Return "~/sec/salonvirtual/home.aspx?idSalonVirtual=" & claveSalon
                End Select

                Return "~/sec/salonvirtual/verActividad.aspx?idSalonVirtual=" & claveSalon & "&idCI=" & claveCI

            Case "Foro"
        End Select


    End Function




End Class
