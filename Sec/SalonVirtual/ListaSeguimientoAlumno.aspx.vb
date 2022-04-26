Imports System.Data


Partial Class Sec_SalonVirtual_ListaSeguimientoAlumno
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))
            Dim idUserProfile As Integer = CInt(Request("idUserProfile"))

            Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)
            Dim myu As New MasUsuarios.UserProfile(idUserProfile, False)



            lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual

            lnkCurso.Text = mysv.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual

            lblNombreTitulo.Text &= " " & myu.nombre & " " & myu.apellidos

            lnkCursoS.NavigateUrl = "~/sec/salonvirtual/ListaSeguimiento.aspx?idSalonVirtual=" & idSalonVirtual
            lblCursoBread.Text = myu.nombre & " " & myu.apellidos

        End If


    End Sub








End Class
