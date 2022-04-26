
Partial Class Sec_SalonVirtual_BuscaAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            Page.Title = mysv.nombre
            lblCursoBread.Text = mysv.nombre
            lnkCurso.Text = mysv.nombre

            '    lblNombredelcurso.Text = mysv.nombre
            ' lblNombreTitulo.Text = mysv.nombre



        End If
    End Sub



    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String) As Integer
        Dim myUsuario As MasUsuarios.UserProfile = New MasUsuarios.UserProfile
        Dim ds As Data.DataSet = myUsuario.GetDSBuscar(Integer.Parse(Session("gUserProfileSession").idEmpresaDefault), txtBuscar.Text.ToString)


        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvAlumnos.DataSource = mydv
        gvAlumnos.DataBind()


        If ds.Tables(0).Rows.Count > 0 Then
            divespacio.Visible = False
        Else
            divespacio.Visible = True
        End If

    End Function


    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Ordenar("Apellidos", "asc")
    End Sub
End Class
