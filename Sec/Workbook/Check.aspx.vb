Imports System.Globalization
Imports System.Threading

Partial Class Sec_Workbook_Check
    Inherits System.Web.UI.Page


    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()
        End If
    End Sub




    Sub iniciarControles()
        Dim myr As New Lego.Root(CInt(Request("idRoot")))



        lnkTitulo.Text = myr.titulo
        lnkTitulo.ToolTip = myr.titulo
        '  lblTitulo.Text = myr.titulo
        lnkTitulo.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & myr.id






        Dim myci As New Lego.ClasificacionItem()
        Dim myc As New Lego.Clasificacion

        Dim contenidos As Integer = myci.countContenidos(myr.id)
        Dim actividades As Integer = myci.countActividadas(myr.id)
        Dim examenes As Integer = myci.countExamenes(myr.id)
        Dim foros As Integer = myci.countForos(myr.id)
        Dim carpetas As Integer = myc.GetDS(myr.id).Tables(0).Rows.Count

        lnkCarpetas.Text = carpetas & "/" & lblCarpetas.Text & " " & lnkCarpetas.Text
        lnkCarpetas.NavigateUrl = "AddCarpeta.aspx?idRoot=" & myr.id & "&regreso=ex"
        If carpetas >= CInt(lblCarpetas.Text) Then
            imgCarpetas.ImageUrl = "~/images/t-mini_icon_dx_ok.fw.png"
        Else
            imgCarpetas.ImageUrl = "~/images/t-mini_icon_dx_del.fw.png"
        End If



        lnkActividades.Text = actividades & "/" & lblActividades.Text & " " & lnkActividades.Text
        lnkActividades.NavigateUrl = "Actividad.aspx?idRoot=" & myr.id & "&regreso=carpeta"
        If actividades >= CInt(lblActividades.Text) Then
            imgActividades.ImageUrl = "~/images/t-mini_icon_dx_ok.fw.png"
        Else
            imgActividades.ImageUrl = "~/images/t-mini_icon_dx_del.fw.png"
        End If

        lnkExamenes.Text = examenes & "/" & lblExamenes.Text & " " & lnkExamenes.Text
        lnkExamenes.NavigateUrl = "Examen.aspx?idRoot=" & myr.id & "&regreso=carpeta"
        If examenes >= CInt(lblExamenes.Text) Then
            imgExamenes.ImageUrl = "~/images/t-mini_icon_dx_ok.fw.png"
        Else
            imgExamenes.ImageUrl = "~/images/t-mini_icon_dx_del.fw.png"
        End If


        lnkContenidos.Text = contenidos & "/" & lblContenidos.Text & " " & lnkContenidos.Text
        lnkContenidos.NavigateUrl = "AddContenido.aspx?idRoot=" & myr.id & "&proc=Contenido&regreso=carpeta"
        If contenidos >= CInt(lblContenidos.Text) Then
            imgContenidos.ImageUrl = "~/images/t-mini_icon_dx_ok.fw.png"
        Else
            imgContenidos.ImageUrl = "~/images/t-mini_icon_dx_del.fw.png"
        End If

        lnkForos.Text = foros & "/" & lblForos.Text & " " & lnkForos.Text
        lnkForos.NavigateUrl = "Foro.aspx?idRoot=" & myr.id & "&proc=Contenido&regreso=carpeta"

        If foros >= CInt(lblForos.Text) Then
            imgForos.ImageUrl = "~/images/t-mini_icon_dx_ok.fw.png"
        Else
            imgForos.ImageUrl = "~/images/t-mini_icon_dx_del.fw.png"
        End If





    End Sub



End Class
