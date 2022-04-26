
Partial Class Sec_SalonVirtual_ListaAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Ordenar("Apellidos", "asc")
        End If

        Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))

        Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)
        lnkNuevoAlumno.NavigateUrl = "BuscaAlumno.aspx?idSalonVirtual=" & idSalonVirtual


        lnkMisCursos.Text = labelCursosComoDocente.Text
            lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual

            lnkCurso.Text = mysv.nombre
        lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual


        If Session("gUserProfileSession").emailGoogle = "jrsnchz@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "j.alvarado@um.edu.mx" Or Session("gUserProfileSession").emailGoogle = "lherreradec@um.edu.mx" Then
            lnkVerTodos.Visible = True
            lnkVerTodos.NavigateUrl = "ListaAlumnos.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&display=t"
        Else
            lnkVerTodos.Visible = False
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
        Dim mye As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile()
        Dim ds As Data.DataSet
        If Request("display") = "t" Then

            ds = mye.GetDSTodos(CInt(Request("idSalonVirtual")))
        Else
            ds = mye.GetDS(CInt(Request("idSalonVirtual")))
        End If

        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        gvListaAlumnos.DataSource = mydv
        gvListaAlumnos.DataBind()


    End Function

    'Protected Sub lnkEnviarCorreo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviarCorreo1.Click
    '    Response.Redirect("EnviarCorreo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correos=" & enviar())

    'End Sub


    Protected Sub lnkEnviarCorreo2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviarCorreo2.Click
        Response.Redirect("EnviarCorreo.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&correos=" & enviar())

    End Sub

    Public Function GetCalificacion(ByVal claveusuario As Integer) As String
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile
        Return Format(CDec(mysvu.GetCalificacionGeneral(claveusuario, CInt(Request("idSalonVirtual")))) / CDec(10.0), "0.00")

    End Function



    Public Function getImagen(objClaveAux As Object, claveUsuario As Integer) As String

        If Not Convert.IsDBNull(objClaveAux) Then
            If CStr(objClaveAux) = "" Then
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario

            Else
                Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario
            End If
        Else
            Return "~/sec/showfile.aspx?idUserprofile=" & claveUsuario

        End If


    End Function


    Private Function enviar() As String


        Dim i As Integer
        Dim cadena As String = ""

        For i = 0 To gvListaAlumnos.Rows.Count - 1
            Dim mychk As System.Web.UI.WebControls.CheckBox = CType(gvListaAlumnos.Rows(i).FindControl("chkSeleccion"), CheckBox)
            Dim myclave As System.Web.UI.WebControls.Label = CType(gvListaAlumnos.Rows(i).FindControl("lblClave"), Label)
            If mychk.Checked Then
                Dim myusuario As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(myclave.Text), False)
                If cadena = "" Then
                    If myusuario.email <> "" Then
                        cadena = myusuario.email.Trim
                    End If
                    'If myusuario.emailGoogle <> "" Then
                    '    If cadena <> "" Then
                    '        cadena = cadena & "," & myusuario.emailGoogle
                    '    Else
                    '        cadena = myusuario.emailGoogle
                    '    End If
                    'End If
                Else

                    If myusuario.email <> "" Then
                        cadena = cadena & "," & myusuario.email.Trim
                    End If
                    'If myusuario.emailGoogle <> "" Then
                    '    cadena = cadena & "," & myusuario.emailGoogle
                    'End If

                End If
            End If
        Next


        Return Server.HtmlEncode(cadena)
    End Function



  

End Class
