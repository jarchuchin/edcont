Imports System.Data.SqlClient
Imports System.Data

Partial Class Sec_SalonVirtual_Sincronizacion
    Inherits System.Web.UI.Page



    Protected Sub btnSincronizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSincronizar.Click
        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)

        Dim mycg As UM.Carga_Grupo = New UM.Carga_Grupo(mysv.claveAux1)
        If EsMaestro() Then

            lblMensajeinicio.Visible = True


            If mycg.existe Then
                If mycg.Estado = 1 Or mycg.Estado = 2 Then
                    Dim i As Integer = 0


                    Dim myItemEvaluacion As Know.ItemEvaluacion = New Know.ItemEvaluacion
                    Dim dseval As DataSet = myItemEvaluacion.GetDS(mysv.id)

                    Dim myie As Know.ItemEvaluacion
                    Dim pruebita As String = ""
                    For i = 0 To dseval.Tables(0).Rows.Count - 1
                        pruebita = pruebita & "-" & dseval.Tables(0).Rows(i).Item("idItemEvaluacion")
                        myie = New Know.ItemEvaluacion(CInt(dseval.Tables(0).Rows(i).Item("idItemEvaluacion")))
                        If myie.existe Then
                            ' Response.Redirect("sinc.aspx?param=" & myie.id)

                            myie.Update()

                            'actividades para esta evaluacion

                            Dim myasv As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual
                            Dim drActividades As SqlDataReader = myasv.GetDR(myie.id)
                            Do While drActividades.Read
                                myasv = New Contenidos.ActividadSalonVirtual(CInt(drActividades("idActividadSalonVirtual")))
                                myasv.Update()
                            Loop
                            drActividades.Close()





                        End If
                    Next

                    'Response.Redirect("cambiar.asp?cadena=" & pruebita)

                    Dim cadenaRegreso As String = ""
                    Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta
                    Dim myExR As Examenes.ExRespuesta
                    Dim mya As Contenidos.Actividad
                    Dim dr As DataSet = myr.GetDS(mysv.id)
                    i = 0
                    Dim numero As Integer = 0
                    For i = 0 To dr.Tables(0).Rows.Count - 1
                        myr = New Contenidos.Respuesta(CInt(dr.Tables(0).Rows(i).Item("idRespuesta")))

                        If myr.existe Then

                            mya = New Contenidos.Actividad(myr.idProc)

                            If mya.tipodeActividad = Contenidos.ETipodeActividad.Examen Then
                                myExR = New Examenes.ExRespuesta
                                Dim calif As Integer = 0
                                calif = myExR.GetSumaValorObtenido(mysv.id, myr.idUserProfile, mya.id)
                                If myr.calificacion = 0 And calif > 0 Then
                                    calif = (calif / mya.puntosTotales) * 100
                                    If calif > 100 Then
                                        calif = 100
                                    End If
                                    myr.calificacion = calif
                                End If

                            End If


                            cadenaRegreso &= myr.Update() & "-"
                            numero = numero + 1


                        End If
                    Next

                    lblsincronizacion.Text &= " --- " & Date.Now & " -- r=" & numero & "  return=" & cadenaRegreso
                    lblsincronizacion.Visible = True






                Else
                    lblmensaje.Visible = True

                End If
            End If ' termina if carga_grupo existe

        Else
            lblmensaje2.Text = "hola"
            lblmensaje2.Visible = True

        End If ' termina es maestro






    End Sub


    Public Function EsMaestro() As Boolean


        If Session("esAdministrador") Or Session("esGerenciaSalones") Then
            Return True
        End If


        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
        Dim myuser As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
        Dim mypermisos As MasUsuarios.Permiso = New MasUsuarios.Permiso(myuser, mysalonVirtual)




        Return mypermisos.existe
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim idSalonVirtual As Integer = CInt(Request("idSalonVirtual"))


            Dim mysv As New Know.SalonVirtual(idSalonVirtual, False)

            If EsMaestro() Then
                lnkMisCursos.Text = labelCursosComoDocente.Text
                lnkMisCursos.NavigateUrl = "~/sec/defaultDocente.aspx?idSalonVirtual=" & idSalonVirtual
            Else
                lnkMisCursos.Text = labelCursosComoAlumno.Text
                lnkMisCursos.NavigateUrl = "~/sec/default.aspx?idSalonVirtual=" & idSalonVirtual
            End If
            lnkCurso.Text = mysv.nombre
            lnkCurso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & idSalonVirtual
        End If
    End Sub
End Class
