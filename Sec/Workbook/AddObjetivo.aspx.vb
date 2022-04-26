Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_AddObjetivo
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            autorizacion()
            colocarDatos()
        End If
    End Sub



    Private myp As MasUsuarios.Permiso

    Sub autorizacion()
        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        myp = New MasUsuarios.Permiso(myu, mye)

        If myp.PAdministracion Then

            myp.PRoots = True
            myp.PPermisosRoots = True
            myp.PContenidos = True

        Else

            If Request("idRoot") <> "" Then
                If IsNumeric(Request("idRoot")) Then
                    Dim myr As Lego.Root = New Lego.Root(CInt(Request("idRoot")))
                    myp = New MasUsuarios.Permiso(myu, myr)
                    If myp.PAdministracion Or myp.PRoots Then
                    Else
                        Response.Redirect("~/sec/workbook/nopermiso.aspx")
                    End If


                End If
            End If

        End If

    End Sub


    Sub colocarDatos()

        lnkSalirEdicion.NavigateUrl = "Carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual")

        If Request("idObjetivo") <> "" Then

            Dim myo As New Lego.Objetivo(CInt(Request("idObjetivo")))
            txtobjetivos.Text = myo.objetivox
            'txthabilidad.Text = myo.habilidad
            'txtaptitud.Text = myo.aptitud

        Else

            btnBorrar.Visible = False

        End If

    End Sub
    Protected Sub btnCancelarObjetivo_Click(sender As Object, e As EventArgs) Handles btnCancelarObjetivo.Click
        Response.Redirect("Carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
    Protected Sub btnGrabarObjetivo_Click(sender As Object, e As EventArgs) Handles btnGrabarObjetivo.Click
        If Request("idObjetivo") <> "" Then
            editar
        Else
            grabar()
        End If


        Response.Redirect("Carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub


    Sub grabar()
        Dim myo As New Lego.Objetivo()
        myo.idClasificacion = CInt(Request("idClasificacion"))
        myo.objetivox = txtobjetivos.Text
        myo.habilidad = ""
        myo.aptitud = "" ' txtaptitud.Text
        myo.Add()

    End Sub

    Sub editar()
        Dim myo As New Lego.Objetivo(CInt(Request("idObjetivo")))

        myo.objetivox = txtobjetivos.Text
        myo.habilidad = "" ' txthabilidad.Text
        myo.aptitud = "" ' txtaptitud.Text
        myo.Update()

    End Sub
    Protected Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim myo As New Lego.Objetivo(CInt(Request("idObjetivo")))
        myo.Remove()

        Response.Redirect("Carpeta.aspx?idClasificacion=" & Request("idClasificacion") & "&idRoot=" & Request("idRoot") & "&idSalonVirtual=" & Request("idSalonVirtual"))
    End Sub
End Class
