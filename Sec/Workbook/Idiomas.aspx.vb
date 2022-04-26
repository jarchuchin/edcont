Imports System.Globalization
Imports System.Threading
Partial Class Sec_Workbook_Idiomas
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("CultureID")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        MyBase.InitializeCulture()
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myi As New Utilerias.Idioma


        Dim objRoot As New Lego.Root(CInt(Request("idRoot")))


        lnkTitulo.Text = objRoot.titulo

        lnkTitulo.ToolTip = objRoot.titulo
        lnkTitulo.NavigateUrl = "~/sec/workbook/home.aspx?idRoot=" & objRoot.id

        DefaultIdioma = objRoot.idIdioma


        gvIdiomas.DataSource = myi.GetDR
        gvIdiomas.DataBind()


        If Request("mensaje") = "1" Then
            alertSuccess.Visible = True

        End If

    End Sub

    Public DefaultIdioma As Integer = 0
    Public Function getSeleccionado(claveIdioma As Integer) As Boolean

        Dim myri As New Lego.RootIdioma(claveIdioma, CInt(Request("idRoot")))
        If myri.existe Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function getEnabled(claveIdioma As Integer) As Boolean

        If DefaultIdioma = claveIdioma Then
            Return False
        Else
            Return True
        End If

    End Function
    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim myri As Lego.RootIdioma
        Dim claveRoot As Integer = CInt(Request("idRoot"))

        For Each row As GridViewRow In gvIdiomas.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chk As CheckBox = CType(row.FindControl("chkid"), CheckBox)
                Dim lbl As Label = CType(row.FindControl("lblid"), Label)

                myri = New Lego.RootIdioma(CInt(lbl.Text), claveRoot)

                If chk.Checked Then
                    If Not myri.existe Then
                        myri.idIdioma = CInt(lbl.Text)
                        myri.idRoot = claveRoot
                        myri.Add()
                    End If
                Else
                    If myri.existe Then
                        myri.Remove()
                    End If
                End If

            End If
        Next


        Response.Redirect("Idiomas.aspx?idRoot=" & claveRoot & "&mensaje=1")

    End Sub
End Class
