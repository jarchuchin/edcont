Imports System.Globalization
Imports System.Threading
Imports System.Data

Partial Class Sec_Home
    Inherits System.Web.UI.Page

    Const horaInicial As Integer = 8
    Dim dataTablaMes As DataTable
    Dim cuentaMes As Integer = 0


    Dim mysalonVirtual As Know.SalonVirtual
    Dim myuser As MasUsuarios.UserProfile
    Dim esmaestro As Boolean


    Public appName As String = ""

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        appName = """" & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")



        If Not IsPostBack Then
            lblmensajeFinanzas.Text = Session("finanzas")
            'If lblmensajeFinanzas.Text.Length > 0 Then
            '    lblmensajeFinanzas.Text = Session("finanzas") & "<br>" & "Tu cuenta presenta un saldo vencido. Te animamos a que pases a caja a pagarlo, evitando así se cierre tu portal así como obtener el pase a exámenes que inician el 8 de octubre. Si no estás de acuerdo con el saldo vencido,  pasa a Finanzas Estudiantiles a aclararlo."
            '    lblmensajeFinanzas.ForeColor = Drawing.Color.Red
            'End If


            If CStr(Session("bloqueadoMensaje")) <> "" Then

                lblMensajeDirecto.Text = Session("bloqueadoMensaje")

                divmensajeDirecto.Visible = True
            End If

            Dim myem As New MasUsuarios.Empresa(CInt(Session("idEmpresa")))
            If myem.mensajeUM <> "" Then
                Dim mensajex As String = myem.mensajeUM.Replace(vbCr, "<br>")
                mensajex = myem.mensajeUM.Replace(vbLf, "<br>")
                mensajex = myem.mensajeUM.Replace(vbCrLf, "<br>")
                lblMensajeUM.Text = mensajex
            End If
            If myem.ImagenInicio <> "" Then
                If myem.Empotrado <> "" Then
                    imgEmrpesa.Visible = False
                    litEmpresa.Text = myem.Empotrado
                Else
                    imgEmrpesa.ImageUrl = "~/images/empresas/" & myem.ImagenInicio
                End If


            End If



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
            Dim dv As DataView = mya.GetItemsAgendaTodos(CInt(Session("gUserProfileSession").idUserProfile)) 'mya.GetItemsAgenda(CInt(Request("idSalonVirtual")))

            ' myAgenda.getDSTotal(Date.Now, CInt(Session("gUserProfileSession").idUserProfile))

            Dim DomainName As String = HttpContext.Current.Request.Url.Host
            If DomainName = "localhost" Then
                DomainName = HttpContext.Current.Request.Url.Authority

            End If

            Dim portnumber As String = HttpContext.Current.Request.Url.Port
            If portnumber <> 80 Then
                DomainName = DomainName & ":" & portnumber
            End If

            DomainName = HttpContext.Current.Request.Url.Scheme & "://" & DomainName & System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/salonvirtual/"


            Dim cadena As New StringBuilder
            cadena.AppendLine(" <script type=""text/javascript"">")
            cadena.AppendLine("$(document).ready(function () {")

            cadena.AppendLine("$('#Skolar-calendar').fullCalendar({")

            'If esmaestro Then
            '    cadena.AppendLine("dayClick: function(date, jsEvent, view) {")
            '    cadena.AppendLine("var d = date;")

            '    cadena.AppendLine("var cadena = """ & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&year=" & """ + date.format('YYYY') + ""&dia=" & """ + date.format('DD') + ""&mes=" & """ + date.format('MM')" & ";")
            '    '  cadena.AppendLine("var cadena = """ & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & """;")
            '    ' cadena.AppendLine("alert(cadena);")
            '    cadena.AppendLine("window.location.href = cadena;")


            '    cadena.AppendLine("")
            '    cadena.AppendLine("}, ")

            '    'Colocar menu
            '    '    lnkMisCursos.Text = labelCursosComoDocente.Text
            '    '    lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & mysalonVirtual.id
            '    'Else

            '    '    lnkMisCursos.Text = labelCursosComoAlumno.Text
            '    '    lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & mysalonVirtual.id

            'End If

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


            For Each rv As DataRowView In dv

                If Not entro Then
                    cadena.AppendLine("{")
                Else
                    cadena.Append(",")
                    cadena.AppendLine("{")
                End If

                cadena.AppendLine("title: '" & rv.Row.Item("titulo") & "',")
                'If esmaestro Then
                '    cadena.AppendLine("url: '" & DomainName & "EditAgenda.aspx?idSalonVirtual=" & mysalonVirtual.id & "&year=" & Format(rv.Row.Item("fecha"), "yyyy") & "&dia=" & Format(rv.Row.Item("fecha"), "dd") & "&mes=" & Format(rv.Row.Item("fecha"), "MM") & "',")
                'Else
                cadena.AppendLine("url: '" & DomainName & rv.Row.Item("url") & "',")
                'End If
                ' 

                cadena.AppendLine("start: '" & Format(rv.Row.Item("fecha"), "yyyy-MM-ddThh:mm:ss") & "',")
                cadena.AppendLine("end: '" & Format(rv.Row.Item("fecha"), "yyyy-MM-ddThh:mm:ss") & "',")
                cadena.AppendLine("description: '" & rv.Row.Item("nombreSalon") & "',")
                cadena.AppendLine(getColorRandom)

                cadena.AppendLine("}")

                entro = True

            Next

            cadena.AppendLine("]")
            cadena.AppendLine(",")
            cadena.AppendLine("eventRender: function(event, element) {")
            cadena.AppendLine("element.qtip({")
            cadena.AppendLine("content: event.description")
            cadena.AppendLine("});")
            cadena.AppendLine("}")
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


End Class
