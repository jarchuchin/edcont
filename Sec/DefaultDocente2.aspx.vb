
Partial Class Sec_DefaultDocente2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargardatos()
        End If
    End Sub

    Sub cargardatos()

        If CInt(Session("gUserProfileSession").idUserProfile) = 0 Then
            Response.Redirect("../logout.aspx")
        End If

        Dim myu As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mye As MasUsuarios.Empresa = New MasUsuarios.Empresa(CInt(Session("gUserProfileSession").idEmpresaDefault))
        Dim myp As MasUsuarios.Permiso = New MasUsuarios.Permiso(myu, mye)





        ' MisSalonesVirtualesInstructor1.idUserProfile = Session("gUserProfileSession").idUserProfile

        ' DatosUserProfile1.idUserProfile = Session("gUserProfileSession").idUserProfile



        Ordenar("FechaInicio", "desc", 50)





    End Sub

    Private Function Ordenar(ByVal expresion As String, ByVal direccion As String, ByVal cantidadregistros As Integer) As Integer
        Dim mySalones As Know.SalonVirtual = New Know.SalonVirtual
        Dim ds As Data.DataSet


        ' ds = mySalones.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True, cantidadregistros)

        If txtBuscar.Text.Trim <> "" Then
            ds = mySalones.GetDSBuscar(CInt(Session("gUserProfileSession").idUserProfile), txtBuscar.Text.Trim)

        Else
            ds = mySalones.GetDS(CInt(Session("gUserProfileSession").idUserProfile), True, cantidadregistros)
        End If

        Dim mydt As System.Data.DataTable = ds.Tables(0)
        Dim mydv As Data.DataView = New Data.DataView(mydt)
        mydv.Sort = expresion + " " + direccion
        rptSalnes.DataSource = mydv
        rptSalnes.DataBind()


    End Function

    Public Function getFoto(claveFoto As Object, claveVideo As Object, claveEbedded As Object, claveidSalon As Integer) As String

        If Convert.IsDBNull(claveFoto) And Convert.IsDBNull(claveFoto) And Convert.IsDBNull(claveEbedded) Then
            Return "<a href=""/sec/salonvirtual/default.aspx?idSalonVirtual=" & claveidSalon & """> <img  src=""/images/salonesvirtuales/default.jpg"" width=""95%""></a>"
        Else
            If claveEbedded = "" And claveVideo = "" And claveFoto = "" Then
                Return "<a href=""/sec/salonvirtual/default.aspx?idSalonVirtual=" & claveidSalon & """><img  src=""/images/salonesvirtuales/default.jpg"" width=""95%""></a>"
            Else
                Dim regreso = "<a href=""/sec/salonvirtual/default.aspx?idSalonVirtual=" & claveidSalon & """><img  src=""/images/salonesvirtuales/" & claveFoto & """ width=""95%""></a>"
                If claveVideo <> "" Then
                    Dim path As String = "/images/salonesvirtuales/" & claveVideo
                    Dim cadena As New StringBuilder
                    cadena.AppendLine("<video muted autoplay loop class=""video""")
                    cadena.AppendLine("<source src=""" & path & """ type="""">")
                    cadena.AppendLine("</video>")

                    regreso = cadena.ToString

                End If
                If claveEbedded <> "" Then
                    regreso = claveEbedded
                End If

                Return regreso
            End If
        End If




    End Function


    Protected Sub drpOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpOrden.SelectedIndexChanged

        Ordenar(drpOrden.SelectedValue, "asc", 50)



    End Sub


    Protected Sub lnkTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTodos.Click
        txtBuscar.Text = ""
        ' hdCantidad.Value = 1000
        Ordenar("FechaInicio", "desc", 1000)
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click


        Ordenar("Nombre", "asc", 1000)
    End Sub

End Class
