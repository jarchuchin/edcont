Imports System.Data
Imports System.Globalization



Partial Class Sec_SalonVirtual_Calendario
    Inherits System.Web.UI.Page


    Const horaInicial As Integer = 8
    Dim dataTablaMes As DataTable
    Dim cuentaMes As Integer = 0


    Dim mysalonVirtual As Know.SalonVirtual
    Dim myuser As MasUsuarios.UserProfile
    Dim esmaestro As Boolean


    Public appName As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        appName = """" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")

        cargarDatosIniciales()

        If Not Page.IsPostBack Then
            'inicio()
            'masterBuilderInicial()



            Dim mya As New Comm.Agenda()
            Dim dv As DataView = mya.GetItemsAgenda(CInt(Request("idSalonVirtual")))
            Dim DomainName As String = HttpContext.Current.Request.Url.Host
            'If DomainName = "localhost" Then
            '    DomainName = HttpContext.Current.Request.Url.Authority

            'End If

            Dim portnumber As String = HttpContext.Current.Request.Url.Port
            If portnumber <> 80 Then
                DomainName = DomainName & ":" & portnumber
            End If

            DomainName = HttpContext.Current.Request.Url.Scheme & "://" & DomainName & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/salonvirtual/"


            Dim cadena As New StringBuilder
            cadena.AppendLine(" <script type=""text/javascript"">")
            cadena.AppendLine("$(document).ready(function () {")

            cadena.AppendLine("$('#Skolar-calendar').fullCalendar({")

            If esmaestro Then
                cadena.AppendLine("dayClick: function(date, jsEvent, view) {")
                cadena.AppendLine("var d = date;")

                cadena.AppendLine("var cadena = """ & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&year=" & """ + date.format('YYYY') + ""&dia=" & """ + date.format('DD') + ""&mes=" & """ + date.format('MM')" & ";")
                '  cadena.AppendLine("var cadena = """ & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & """;")
                ' cadena.AppendLine("alert(cadena);")
                cadena.AppendLine("window.location.href = cadena;")


                cadena.AppendLine("")
                cadena.AppendLine("}, ")

                'Colocar menu
                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & mysalonVirtual.id
            Else

                lnkMisCursos.Text = labelCursosComoAlumno.Text
                lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & mysalonVirtual.id

            End If

            cadena.AppendLine("lang: 'es',")
            cadena.AppendLine("header: {")
            cadena.AppendLine("left: 'prev,next today',")
            cadena.AppendLine("center: 'title',")
            cadena.AppendLine("right: 'month,agendaWeek,agendaDay'")
            cadena.AppendLine("},")
            cadena.AppendLine("editable: true,")
            cadena.AppendLine("droppable: true, // this allows things to be dropped onto the calendar")
            cadena.AppendLine("drop: function () {")
            cadena.AppendLine("// is the ""remove after drop"" checkbox checked?")
            cadena.AppendLine(" if ($('#drop-remove').is(':checked')) {")
            cadena.AppendLine(" // if so, remove the element from the ""Draggable Events"" list")
            cadena.AppendLine(" $(this).remove();")
            cadena.AppendLine("}")
            cadena.AppendLine("},")
            cadena.AppendLine("defaultDate: '" & Format(Date.Now, "yyyy-MM-dd") & "',")
            cadena.AppendLine("eventLimit: true,")
            cadena.AppendLine("events: [")

            Dim entro As Boolean = False

            Dim cadenaTitulo As String = ""

            For Each rv As DataRowView In dv

                If Not entro Then
                    cadena.AppendLine("{")
                Else
                    cadena.Append(",")
                    cadena.AppendLine("{")
                End If

                cadena.AppendLine("title: '" & limpiarTitulo(rv.Row.Item("titulo")) & "',")
                If esmaestro Then
                    cadena.AppendLine("url: '" & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&year=" & Format(rv.Row.Item("fecha"), "yyyy") & "&dia=" & Format(rv.Row.Item("fecha"), "dd") & "&mes=" & Format(rv.Row.Item("fecha"), "MM") & "',")
                Else
                    cadena.AppendLine("url: '" & rv.Row.Item("url") & "',")
                End If

                cadena.AppendLine("start: '" & Format(rv.Row.Item("fecha"), "yyyy-MM-ddThh:mm:ss") & "',")
                cadena.AppendLine("end: '" & Format(rv.Row.Item("fecha"), "yyyy-MM-ddThh:mm:ss") & "',")
                cadena.AppendLine(getColorRandom)
                cadena.AppendLine("}")

                entro = True
                cadenaTitulo = ""
            Next

            cadena.AppendLine("]")
            cadena.AppendLine("")
            cadena.AppendLine("")
            cadena.AppendLine("")
            cadena.AppendLine("")
            cadena.AppendLine("});")

            cadena.AppendLine("});")

            cadena.AppendLine(" </script>")


            litScript.Text = cadena.ToString


            'Else
            '    masterBuilder()
        End If






    End Sub

    Private Function limpiarTitulo(mititulo As String) As String
        mititulo = Replace(mititulo, "'", "")
        mititulo = Replace(mititulo, """", "")
        mititulo = Replace(mititulo, ",", "")

        mititulo = mititulo.Trim
        Return mititulo
    End Function


    Dim rc As New Random
    Function getColorRandom() As String


        Select Case rc.Next(1, 7)
            Case 1
                Return "className: 'purple'"
            Case 2
                Return "className: 'mint'"
            Case 3
                Return "className: 'warning'"
            Case 4
                Return "className: 'danger'"
            Case 5
                Return "className: 'success'"
            Case 6
                Return "className: 'dark'"
            Case 7
                Return "className: 'pink'"


        End Select

    End Function

    'Sub cargarDatosIniciales()
    '    mysalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
    '    myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
    '    Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
    '    esmaestro = mypermisos.existe
    '    If mypermisos.PPermisosRoots Then
    '        esmaestro = True
    '    Else
    '        esmaestro = False
    '    End If

    '    lnkCurso.Text = mysalonVirtual.nombre
    '    lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")



    '    lnkActividades.NavigateUrl = "~/sec/salonvirtual/ActividadesAgendadas.aspx?idSalonVirtual=" & Request("idSalonVirtual")
    'End Sub



    Public Function EsAlumno() As Boolean
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(myuser.id, mysalonVirtual.id, False)

        If mysvu.existe Then

            Return True
        Else
            Return False
        End If


    End Function

    Sub cargarDatosIniciales()
        mysalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        myuser = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)


        Label6.Text = Session("entraAlumno")

        If EsAlumno() Then

            esmaestro = False

        Else


            Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)
            esmaestro = mypermisos.existe
            If mypermisos.PPermisosRoots Then
                esmaestro = True
            Else
                esmaestro = False
            End If

            If CBool(Session("esGerenciaSalones")) Then
                esmaestro = True
            End If



            lnkCurso.Text = mysalonVirtual.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Request("idSalonVirtual")



            lnkActividades.NavigateUrl = "~/sec/salonvirtual/ActividadesAgendadas.aspx?idSalonVirtual=" & Request("idSalonVirtual")
        End If


    End Sub



    'Private Sub inicio()
    '    Dim fecha As Date
    '    Try
    '        fecha = CDate(Request("fecha"))
    '        Tabs.ActiveTabIndex = tabPanelDia.TabIndex
    '        If Request("mes") = "1" Then
    '            Tabs.ActiveTabIndex = tabPanelMes.TabIndex
    '        End If
    '    Catch ex As Exception
    '        fecha = Today
    '    End Try

    '    hidCurrentDate.Value = fecha.ToShortDateString
    'End Sub

    'Private Sub masterBuilderInicial()
    '    Dim fecha As Date = CDate(hidCurrentDate.Value)

    '    buildDia(fecha)
    '    buildSemanaBody(fecha)
    'End Sub

    'Private Sub masterBuilder()
    '    Dim fecha As Date = CDate(hidCurrentDate.Value)

    '    Select Case Tabs.ActiveTabIndex
    '        Case tabPanelDia.TabIndex
    '            buildDia(fecha)
    '        Case tabPanelSemana.TabIndex
    '            buildSemanaBody(fecha)
    '        Case tabPanelMes.TabIndex
    '            If Page.IsPostBack Then Calendar1.VisibleDate = fecha
    '    End Select
    'End Sub

    'Private Sub buildSemanaBody(ByVal diaInicial As Date)

    '    diaInicial = diaInicial.AddDays(-diaInicial.DayOfWeek)
    '    Dim fechaBase As New DateTime(diaInicial.Year, diaInicial.Month, diaInicial.Day, 0, 0, 0)
    '    Dim cadena As String = ""



    '    Dim diaCero As Date = fechaBase

    '    lnkPreWeek.CommandArgument = fechaBase.AddDays(-7)
    '    lnkNextWeek.CommandArgument = fechaBase.AddDays(7)



    '    Dim cell As TableCell
    '    Dim btnLink As New LinkButton
    '    Dim link As HyperLink
    '    Dim myci As Lego.ClasificacionItem

    '    Dim counter As Integer = 0

    '    For Each cell In rowHeader.Cells
    '        If counter > 0 Then
    '            cell.FindControl("lnkBtn" & counter)
    '            btnLink = CType(cell.FindControl("lnkBtn" & (counter - 1)), LinkButton)
    '            btnLink.CommandArgument = diaCero.ToShortDateString
    '            btnLink.Text = diaCero.ToString("ddd d")
    '            diaCero = diaCero.AddDays(1)
    '        End If
    '        counter = counter + 1
    '    Next

    '    diaCero = fechaBase


    '    For i As Integer = 1 To 7

    '        Dim myagenda As Comm.Agenda = New Comm.Agenda
    '        Dim tablaDatos As DataTable = myagenda.GetDS(CInt(Request("idSalonVirtual")), diaCero).Tables(0)


    '        For j As Integer = 1 To 11



    '            cell = tablaSemana.Rows(j).Cells(i)

    '            If esmaestro Then
    '                cell.Attributes.Add("onDblClick", "evento(""" & diaCero.ToShortDateString & """, """ & Request("idSalonVirtual") & """ ,""" & diaCero.AddHours(2).ToString("HH") & """)")
    '                cell.ToolTip = lbldetallesdobleclic.Text
    '            End If

    '            Dim dRows() As DataRow

    '            If j > 1 Then
    '                dRows = tablaDatos.Select("fecha >= '" & diaCero & "'  and fecha <= '" & diaCero.AddHours(2) & "'")
    '            Else
    '                dRows = tablaDatos.Select("fecha >= '" & diaCero & "'  and fecha <= '" & diaCero.AddHours(4) & "'")
    '            End If

    '            Dim hayRegistro As Boolean = False

    '            For Each dRow In dRows

    '                link = New HyperLink

    '                Select Case CStr(dRow("procedencia"))
    '                    Case "Actividad"
    '                        Dim mya As Contenidos.Actividad = New Contenidos.Actividad(CInt(dRow("idProc")))
    '                        cadena = mya.titulo
    '                        myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, mya.id, mya.tipo.ToString)
    '                        Select Case mya.tipodeActividad
    '                            Case Contenidos.ETipodeActividad.Actividad
    '                                link.NavigateUrl = "verActividad.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                            Case Contenidos.ETipodeActividad.Examen
    '                                link.NavigateUrl = "verExamen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        End Select

    '                    Case "Contenido"
    '                        Dim myc As Contenidos.Contenido = New Contenidos.Contenido(CInt(dRow("idProc")))
    '                        cadena = myc.titulo
    '                        myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, myc.id, myc.tipo.ToString)
    '                        Select Case myc.idTipoContenido
    '                            Case Contenidos.TipoContenido.Texto
    '                                link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                            Case Contenidos.TipoContenido.Articulate
    '                                link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                            Case Contenidos.TipoContenido.Imagen
    '                                link.NavigateUrl = "verImagen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                            Case Contenidos.TipoContenido.Flash
    '                                link.NavigateUrl = "verFlash.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                            Case Contenidos.TipoContenido.Archivo
    '                                link.NavigateUrl = "verArchivo.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        End Select

    '                    Case "Foro"
    '                        Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(dRow("idProc")))
    '                        cadena = myf.titulo
    '                    Case "SalonVirtual"
    '                        cadena = dRow("titulo") & "<br>" & dRow("nota")


    '                End Select

    '                If esmaestro Then
    '                    link.NavigateUrl = "EditAgenda.aspx?&idSalonVirtual=" & Request("idSalonVirtual") & "&fecha=" & diaCero.ToShortDateString
    '                End If

    '                link.Text = cadena



    '                link.Text = cadena
    '                link.ToolTip = "Inicia el " & dRow("fechaInicio") & " y terminar el " & dRow("fecha") & "." & lblDetalles.Text
    '                link.CssClass = "mini-link"

    '                cell.Width = System.Web.UI.WebControls.Unit.Pixel(80)
    '                cell.Controls.Add(link)
    '                cell.Controls.Add(New LiteralControl("<br />"))
    '                hayRegistro = True


    '            Next


    '            If Not hayRegistro Then
    '                cell.Controls.Add(New LiteralControl("&nbsp;"))
    '            End If

    '            If j > 1 Then
    '                diaCero = diaCero.AddHours(2)
    '            Else
    '                diaCero = diaCero.AddHours(4)
    '            End If

    '        Next

    '        diaCero = fechaBase.AddDays(i)
    '    Next



    'End Sub

    'Private Sub buildDia(ByVal nuevaFecha As Date)
    '    lnkPreDay.CommandArgument = nuevaFecha.AddDays(-1).ToShortDateString
    '    lnkNextDay.CommandArgument = nuevaFecha.AddDays(1).ToShortDateString

    '    Dim diaCero As New DateTime(nuevaFecha.Year, nuevaFecha.Month, nuevaFecha.Day, 0, 0, 0)
    '    Dim myagenda As Comm.Agenda = New Comm.Agenda

    '    Dim tablaDatos As DataTable = myagenda.GetDS(CInt(Request("idSalonVirtual")), diaCero).Tables(0)

    '    Dim cell As TableCell
    '    Dim link As HyperLink

    '    lblHeaderDia.Text = diaCero.ToLongDateString

    '    For i As Integer = 1 To 11

    '        cell = tablaDia.Rows(i).Cells(1)



    '        Dim dRows() As DataRow

    '        If i > 1 Then
    '            dRows = tablaDatos.Select("fecha >= '" & diaCero & "'  and fecha <= '" & diaCero.AddHours(2) & "'")
    '            If esmaestro Then
    '                If diaCero.AddHours(2).ToString("HH") = "00" Then
    '                    cell.Attributes.Add("onDblClick", "evento(""" & diaCero.ToShortDateString & """, """ & Request("idSalonVirtual") & """ ,""24"")")
    '                    Dim miliguita As New System.Web.UI.WebControls.HyperLink
    '                    miliguita.NavigateUrl = "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & nuevaFecha.ToShortDateString & "&hora=24"
    '                    miliguita.Text = lblagendaraqui.Text
    '                    cell.Controls.Add(miliguita)
    '                    cell.Controls.Add(New LiteralControl("<br />"))
    '                Else
    '                    cell.Attributes.Add("onDblClick", "evento(""" & diaCero.ToShortDateString & """, """ & Request("idSalonVirtual") & """ ,""" & diaCero.AddHours(2).ToString("HH") & """)")
    '                    Dim miliguita As New System.Web.UI.WebControls.HyperLink
    '                    miliguita.NavigateUrl = "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & nuevaFecha.ToShortDateString & "&hora=" & diaCero.AddHours(4).ToString("HH")
    '                    miliguita.Text = lblagendaraqui.Text
    '                    cell.Controls.Add(miliguita)
    '                    cell.Controls.Add(New LiteralControl("<br />"))
    '                End If

    '                cell.ToolTip = lbldetallesdobleclic.Text
    '            End If
    '        Else
    '            dRows = tablaDatos.Select("fecha >= '" & diaCero & "'  and fecha <= '" & diaCero.AddHours(4) & "'")
    '            If esmaestro Then
    '                cell.Attributes.Add("onDblClick", "evento(""" & diaCero.ToShortDateString & """, """ & Request("idSalonVirtual") & """ ,""" & diaCero.AddHours(4).ToString("HH") & """)")
    '                cell.ToolTip = lbldetallesdobleclic.Text

    '                Dim miliguita As New System.Web.UI.WebControls.HyperLink
    '                miliguita.NavigateUrl = "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & nuevaFecha.ToShortDateString & "&hora=" & diaCero.AddHours(4).ToString("HH")
    '                miliguita.Text = lblagendaraqui.Text
    '                cell.Controls.Add(miliguita)
    '                cell.Controls.Add(New LiteralControl("<br />"))
    '            End If
    '        End If





    '        Dim myci As Lego.ClasificacionItem

    '        Dim hayRegistro As Boolean = False
    '        For Each dRow In dRows


    '            link = New HyperLink
    '            Dim cadena As String = ""


    '            Select Case CStr(dRow("procedencia"))
    '                Case "Actividad"
    '                    Dim mya As Contenidos.Actividad = New Contenidos.Actividad(CInt(dRow("idProc")))
    '                    cadena = mya.titulo
    '                    myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, mya.id, mya.tipo.ToString)
    '                    Select Case mya.tipodeActividad
    '                        Case Contenidos.ETipodeActividad.Actividad
    '                            link.NavigateUrl = "verActividad.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        Case Contenidos.ETipodeActividad.Examen
    '                            link.NavigateUrl = "verExamen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    End Select

    '                Case "Contenido"
    '                    Dim myc As Contenidos.Contenido = New Contenidos.Contenido(CInt(dRow("idProc")))
    '                    cadena = myc.titulo
    '                    myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, myc.id, myc.tipo.ToString)
    '                    Select Case myc.idTipoContenido
    '                        Case Contenidos.TipoContenido.Texto
    '                            link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        Case Contenidos.TipoContenido.Articulate
    '                            link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        Case Contenidos.TipoContenido.Imagen
    '                            link.NavigateUrl = "verImagen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        Case Contenidos.TipoContenido.Flash
    '                            link.NavigateUrl = "verFlash.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                        Case Contenidos.TipoContenido.Archivo
    '                            link.NavigateUrl = "verArchivo.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    End Select

    '                Case "Foro"
    '                    Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(dRow("idProc")))
    '                    cadena = myf.titulo
    '                Case "SalonVirtual"
    '                    cadena = dRow("titulo") & "<br>" & dRow("nota")


    '            End Select

    '            If esmaestro Then
    '                link.NavigateUrl = "EditAgenda.aspx?&idSalonVirtual=" & Request("idSalonVirtual") & "&fecha=" & diaCero.ToShortDateString

    '            End If

    '            link.Text = cadena
    '            link.ToolTip = "Inicia el " & dRow("fechaInicio") & " y terminar el " & _
    '              dRow("fecha") & ". " & lblDetalles.Text
    '            link.CssClass = "mini-link"


    '            cell.Controls.Add(link)
    '            cell.Controls.Add(New LiteralControl("<br />"))

    '            hayRegistro = True

    '        Next

    '        If Not hayRegistro Then
    '            cell.Controls.Add(New LiteralControl("&nbsp;"))
    '        End If

    '        If i > 1 Then
    '            diaCero = diaCero.AddHours(2)
    '        Else
    '            diaCero = diaCero.AddHours(4)
    '        End If

    '    Next
    'End Sub




    'Protected Function eventoCopiable(ByVal claveCreadorEvento As Integer) As Boolean
    '    Return claveCreadorEvento = CInt(Session("idUsuario"))
    'End Function

    'Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
    '    If cuentaMes = 0 Then
    '        Dim myagenda As Comm.Agenda = New Comm.Agenda

    '        dataTablaMes = myagenda.GetDS(CInt(Request("idSalonVirtual")), "asc").Tables(0)
    '        dataTablaMes.Locale = CultureInfo.CurrentCulture
    '        cuentaMes = cuentaMes + 1
    '    Else
    '        If cuentaMes < 42 Then
    '            cuentaMes = cuentaMes + 1
    '        Else
    '            cuentaMes = 0
    '            dataTablaMes = Nothing
    '        End If
    '    End If

    '    Dim dRows() As DataRow
    '    Dim dRow As DataRow

    '    Dim cadenaInicio As DateTime = DateTime.Parse(e.Day.Date.ToShortDateString & " 12:00:00 am")
    '    Dim cadenafin As DateTime = DateTime.Parse(e.Day.Date.ToShortDateString & " 11:59:59 pm")

    '    dRows = dataTablaMes.Select("fecha >= '" & cadenaInicio & "'  and fecha <= '" & cadenafin & "'")
    '    Dim counter As Integer = 0
    '    Dim cadena As String = ""
    '    Dim link As HyperLink
    '    Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem


    '    For Each dRow In dRows


    '        link = New HyperLink
    '        If counter > 2 Then
    '            link.Text = lblvermas.Text
    '            link.NavigateUrl = "Calendario.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&fecha=" & e.Day.Date.ToShortDateString
    '            link.CssClass = "LigaGris"
    '            e.Cell.Controls.Add(link)
    '            Exit For
    '        End If


    '        Select Case CStr(dRow("procedencia"))
    '            Case "Actividad"
    '                Dim mya As Contenidos.Actividad = New Contenidos.Actividad(CInt(dRow("idProc")))
    '                cadena = mya.titulo
    '                myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, mya.id, mya.tipo.ToString)
    '                Select Case mya.tipodeActividad
    '                    Case Contenidos.ETipodeActividad.Actividad
    '                        link.NavigateUrl = "verActividad.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    Case Contenidos.ETipodeActividad.Examen
    '                        link.NavigateUrl = "verExamen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                End Select

    '            Case "Contenido"
    '                Dim myc As Contenidos.Contenido = New Contenidos.Contenido(CInt(dRow("idProc")))
    '                cadena = myc.titulo
    '                myci = New Lego.ClasificacionItem(mysalonVirtual.idRoot, myc.id, myc.tipo.ToString)
    '                Select Case myc.idTipoContenido
    '                    Case Contenidos.TipoContenido.Texto
    '                        link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    Case Contenidos.TipoContenido.Articulate
    '                        link.NavigateUrl = "verTexto.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    Case Contenidos.TipoContenido.Imagen
    '                        link.NavigateUrl = "verImagen.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    Case Contenidos.TipoContenido.Flash
    '                        link.NavigateUrl = "verFlash.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                    Case Contenidos.TipoContenido.Archivo
    '                        link.NavigateUrl = "verArchivo.aspx?idSalonVirtual=" & mysalonVirtual.id & "&idCI=" & myci.id
    '                End Select

    '            Case "Foro"
    '                Dim myf As Contenidos.Foro = New Contenidos.Foro(CInt(dRow("idProc")))
    '                cadena = myf.titulo

    '            Case "SalonVirtual"
    '                cadena = dRow("titulo")

    '        End Select


    '        If esmaestro Then
    '            link.NavigateUrl = "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & e.Day.Date.ToShortDateString
    '            e.Cell.Attributes.Add("onDblClick", "evento(""" & e.Day.Date.ToShortDateString & """, """ & Request("idSalonVirtual") & """ ,""24"")")

    '        End If




    '        If cadena.Length > 15 Then
    '            link.Text = cadena.Substring(0, 15) & "..."
    '        Else
    '            link.Text = cadena
    '        End If



    '        link.ToolTip = cadena & ". inicia el " & dRow("fechainicio") & _
    '         " y termina el " & dRow("fecha") & ". " & lblDetalles.Text
    '        link.CssClass = "mini-link"



    '        e.Cell.Controls.Add(New LiteralControl("<div align='left' >"))
    '        e.Cell.Controls.Add(link)
    '        e.Cell.Controls.Add(New LiteralControl("</div>"))

    '        counter = counter + 1
    '    Next




    'End Sub

    'Protected Sub Calendar1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.PreRender
    '    If Not Page.IsPostBack Then
    '        Calendar1.VisibleDate = CDate(hidCurrentDate.Value)
    '    End If
    'End Sub

    'Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
    '    Response.Redirect("Calendario.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & Calendar1.SelectedDate.ToShortDateString)
    '    If esmaestro Then
    '        Response.Redirect("EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&fecha=" & Calendar1.SelectedDate.ToShortDateString)
    '    Else

    '    End If

    'End Sub

    'Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
    '    hidCurrentDate.Value = e.NewDate.ToShortDateString
    'End Sub

    'Protected Sub LinkBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnLink As LinkButton = CType(sender, LinkButton)
    '    hidCurrentDate.Value = CDate(btnLink.CommandArgument)
    '    Tabs.ActiveTabIndex = tabPanelDia.TabIndex
    '    masterBuilder()
    'End Sub



    'Protected Sub LinkBtnDisplay_Command(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnLink As LinkButton = CType(sender, LinkButton)
    '    Dim idEvento As Integer = CInt(btnLink.CommandArgument)
    '    Response.Redirect("displayEvento.aspx?idEvento=" & idEvento)
    'End Sub

    'Protected Sub LinkBtnCopiar_Command(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnLink As LinkButton = CType(sender, LinkButton)
    '    Dim idEvento As Integer = CInt(btnLink.CommandArgument)
    '    Response.Redirect("editEventos.aspx?idEvento=" & idEvento & "&action=copy")
    'End Sub

    'Protected Sub lnkPreWeek_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPreWeek.Command
    '    Dim currentDate As Date = CDate(hidCurrentDate.Value)
    '    hidCurrentDate.Value = currentDate.AddDays(-7)
    '    masterBuilder()
    'End Sub

    'Protected Sub lnkNextWeek_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNextWeek.Command
    '    Dim currentDate As Date = CDate(hidCurrentDate.Value)
    '    hidCurrentDate.Value = currentDate.AddDays(7)
    '    masterBuilder()
    'End Sub

    'Protected Sub lnkPreDay_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPreDay.Command
    '    Dim currentDate As Date = CDate(hidCurrentDate.Value)
    '    hidCurrentDate.Value = currentDate.AddDays(-1)
    '    masterBuilder()
    'End Sub

    'Protected Sub lnkNextDay_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNextDay.Command
    '    Dim currentDate As Date = CDate(hidCurrentDate.Value)
    '    hidCurrentDate.Value = currentDate.AddDays(1)
    '    masterBuilder()
    'End Sub


End Class
