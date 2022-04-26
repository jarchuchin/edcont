Imports System.Math

Partial Class autologin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("session") <> "" Then
            setlogin(Request("session"))
        Else
            Response.Redirect("logout.aspx")
        End If
    End Sub


    Sub setlogin(ByVal clavesession As String)
        Dim myms As New UM.Modulo_Sesion(clavesession)
        If myms.existe Then
            If myms.finalizo = "N" Then
                If myms.f_inicio.AddHours(1) > Date.Now Then
                    Dim myU As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myms.codigo_personal, 4, "x")
                    'cada empresa tendra decidira si consume una validacion personalizada o no
                    Dim clave As Integer = myU.id
                    myU = New MasUsuarios.UserProfile(clave, True)
                    Dim myEmpresaUserProfile As New MasUsuarios.EmpresaUserProfile(clave, 4)

                    Dim mysaldoestudiante As New UM.Saldos_Estudiantes(myEmpresaUserProfile.claveAux1)


                    If mysaldoestudiante.saldoglobal > 150 Then
                        Session("finanzas") = "Tu saldo vencido es de " & Format(Abs(mysaldoestudiante.saldoglobal), "c") & " y deberá ser pagado antes  del 8 de abril evitando así se cierre tu portal o tu Skolar. Cualquier duda con tu saldo, pasa a Finanzas Estudiantiles para aclararlo. <br><br>CP. Raúl randeles<br>Dir. Finanzas Estudiantiles"
                    Else
                        Session("finanzas") = ""
                    End If

                    Session("gUserProfileSession") = myU.GetUserProfilesSession()

                    FormsAuthentication.SetAuthCookie(myms.codigo_personal, False)

                    If Request("curso_carga_id") <> "" Then
                        'sec/SalonVirtual/default.aspx?idSalonVirtual
                        Dim mysv As New Know.SalonVirtual(Request("curso_carga_id"), False)
                        Response.Redirect("~/sec/SalonVirtual/default.aspx?idSalonVirtual=" & mysv.id)
                    Else
                        Response.Redirect("~/sec/default.aspx")
                    End If

                End If
            Else
                Response.Redirect("logout.aspx?error=la session finalizo")
            End If
        Else
            Response.Redirect("logout.aspx?error=No existe registro")
        End If
    End Sub
End Class
