
Partial Class Sec_SalonVirtual_RespuestaActividadesSalonVirutal
    Inherits System.Web.UI.Page

    Dim myasv As Contenidos.ActividadSalonVirtual
    Public esExamen As Boolean = False


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myasv = New Contenidos.ActividadSalonVirtual(CInt(Request("idActividadSalonVirtual")))
        If Not IsPostBack Then

            lblFechaActual.Text = Date.Now.ToLongDateString
            Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta()
            lblpromedio.Text = Format(myae.GetPromedioActividad(0, myasv.idActividad, tipoObjeto.Actividad, myasv.idSalonVirtual) / 10, "0.0")
            Dim myac As Contenidos.Actividad = New Contenidos.Actividad(myasv.idActividad)
            lblActividad.Text = myac.titulo
            If myac.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
                btngrabar.Visible = False
                esExamen = True
            End If


            Ordenar("Apellidos", "asc")

        End If

        Dim mysalonVirtual As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        lnkCurso.Text = mysalonVirtual.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")

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
        gvAsistenciaFechas.DataSource = mydv
        gvAsistenciaFechas.DataBind()
    End Function

    Public Function getEnviada(ByVal claveUsuario As Integer) As String
        'Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        'If myae.existe Then
        '    Return "ok.gif"
        'Else
        '    Return "cancel.gif"
        'End If

        Return varEnviada
    End Function

    Public Function getFecha(ByVal claveUsuario As Integer) As String
        'Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        'If myae.existe Then
        '    Return myae.fechaEnvio.ToShortDateString
        'Else
        '    Return "-"
        'End If

        Return varfecha
    End Function

    Public Function getCalificacion(ByVal claveUsuario As Integer) As String
        'Dim myae As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, claveUsuario)
        'If myae.existe Then
        '    Return myae.calificacion
        'Else
        '    Return "0"
        'End If
        Return varCalificacion
    End Function


    Dim varEnviada As String
    Dim varCalificacion As String
    Dim varfecha As String

    Public Function getRespuesta(ByVal usuario As Integer) As String
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myasv.idActividad, tipoObjeto.Actividad.ToString, myasv.idSalonVirtual, usuario)
        Dim cadena As String = ""

        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(myasv.idActividad)
        varEnviada = "no.png"
        varfecha = "-"
        varCalificacion = "0.0"

        Select Case mya.tipodeActividad
            Case Contenidos.ETipodeActividad.Actividad
                cadena = "RespuestaActividadesSalonVirtual.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idActividadSalonVirtual=" & Request("idActividadSalonVirtual") & "#"
                If myr.existe Then
                    cadena = "~/Sec/SalonVirtual/CalificarRespuesta.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idR=" & myr.id
                    varEnviada = "si.png"
                    varfecha = myr.fechaEnvio.ToShortDateString
                    varCalificacion = Format(myr.calificacion / 10, ".0")
                End If

               ' cadena = "dafsda"

            Case Contenidos.ETipodeActividad.Examen
                cadena = "RespuestaActividadesSalonVirtual.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idActividadSalonVirtual=" & Request("idActividadSalonVirtual") & "#"
                If myr.existe Then
                    cadena = "~/Sec/SalonVirtual/CalificarExamen.aspx?idSalonVirtual=" & myasv.idSalonVirtual & "&idR=" & myr.id
                    varEnviada = "si.png"
                    varfecha = myr.fechaEnvio.ToShortDateString
                    varCalificacion = Format(myr.calificacion / 10, ".0")
                End If
        End Select




        Return cadena
    End Function



    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        System.Threading.Thread.Sleep(1000)

        Dim myactividadSalon As New Contenidos.ActividadSalonVirtual(CInt(Request("idActividadSalonVirtual")))
        Dim myie As Know.ItemEvaluacion = New Know.ItemEvaluacion(myactividadSalon.idItemEvaluacion)

        Dim myactividad As New Contenidos.Actividad(myactividadSalon.idActividad)


        For Each row As GridViewRow In gvAsistenciaFechas.Rows

            Dim claveUsuario As Integer = CInt(CType(row.FindControl("txtClave"), TextBox).Text)
            Dim calificacion As Decimal = CDec(CType(row.FindControl("txtCalificacion"), TextBox).Text)

            Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myactividad.id, tipoObjeto.Actividad.ToString, myactividadSalon.idSalonVirtual, claveUsuario)
            If myr.existe Then
                myr.calificacion = calificacion * 10
                myr.observaciones = myr.observaciones & " Auto-generated: " & Date.Now
                myr.Update()
            Else
                myr.idUserProfile = claveUsuario
                myr.idRaiz = 0
                myr.idProc = myactividad.id
                myr.procedencia = tipoObjeto.Actividad.ToString
                myr.idSalonVirtual = myactividadSalon.idSalonVirtual
                myr.titulo = myie.titulo
                myr.texto = ""
                myr.observaciones = myr.observaciones & " Auto-generated: " & Date.Now
                myr.calificacion = calificacion * 10
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

        Response.Redirect("RespuestaActividadesSalonVirtual.aspx?idSalonVirtual=" & myactividadSalon.idSalonVirtual & "&idActividadSalonVirtual=" & myactividadSalon.id)
    End Sub

    Protected Sub imgAsignarCalificacion_Click(sender As Object, e As ImageClickEventArgs)
        Dim mybtn As ImageButton = CType(sender, ImageButton)
        Dim clave As Integer = CInt(mybtn.CommandArgument)


        Dim calificacion As Decimal = 0

        For Each row As GridViewRow In gvAsistenciaFechas.Rows

            Dim claveUsuario As Integer = CInt(CType(row.FindControl("txtClave"), TextBox).Text)
            If claveUsuario = clave Then
                calificacion = CDec(CType(row.FindControl("txtCalificacion"), TextBox).Text)
                Exit For
            End If

        Next

        Dim myactividadSalon As New Contenidos.ActividadSalonVirtual(CInt(Request("idActividadSalonVirtual")))
        Dim myie As Know.ItemEvaluacion = New Know.ItemEvaluacion(myactividadSalon.idItemEvaluacion)

        Dim myactividad As New Contenidos.Actividad(myactividadSalon.idActividad)

        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta(0, myactividad.id, tipoObjeto.Actividad.ToString, myactividadSalon.idSalonVirtual, clave)
        If myr.existe Then
            myr.calificacion = calificacion * 10
            myr.observaciones = myr.observaciones & " Auto-generated: " & Date.Now
            myr.Update()
        Else
            myr.idUserProfile = clave
            myr.idRaiz = 0
            myr.idProc = myactividad.id
            myr.procedencia = myactividad.tipo.ToString
            myr.idSalonVirtual = myactividadSalon.idSalonVirtual
            myr.titulo = myactividad.titulo
            myr.texto = 1
            myr.observaciones = myr.observaciones & " Auto-generated: " & Date.Now
            myr.calificacion = calificacion * 10
            myr.fechaEnvio = Date.Now
            myr.fechaRevision = Date.Now
            myr.repetir = False
            myr.status = Contenidos.StatusRespuesta.Calificada
            myr.Add()
            myr.Update()

        End If

        Response.Redirect("RespuestaActividadesSalonVirtual.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idActividadSalonVirtual=" & Request("idActividadSalonVirtual") & "&myr=" & myr.existe)

    End Sub
End Class
