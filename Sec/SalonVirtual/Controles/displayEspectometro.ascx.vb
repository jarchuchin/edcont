Imports System.Data
Imports System.Data.Sql

Partial Class Sec_SalonVirtual_Controles_displayEspectometro
    Inherits System.Web.UI.UserControl

    Public claveUsuario As Integer
    Public claveSalon As Integer
    Public esmaestro As Boolean = False


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()

        hdclaveusuario.Value = claveUsuario
        hdclavesalon.Value = claveSalon
        Dim myact As Contenidos.ActividadSalonVirtual = New Contenidos.ActividadSalonVirtual()
        Dim totalActividades As Integer = myact.Count(CInt(hdclavesalon.Value))
        Dim myr As Contenidos.Respuesta = New Contenidos.Respuesta
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile


        If esmaestro Then


            PanelAlumno.Visible = False
            PanelMestro.Visible = True

            mysvu.idSalonVirtual = CInt(hdclavesalon.Value)
            Dim numeroAlumnos As Integer = mysvu.Count()
            Dim totalActividadesEnviadasAlMaestro As Integer = myr.CountActividadesSalon(mysvu.idSalonVirtual)
            If numeroAlumnos > 0 And totalActividades > 0 Then
                lblActividadesRevisadasMaestro.Text = CInt((totalActividadesEnviadasAlMaestro / (numeroAlumnos * totalActividades)) * 100)
            Else
                lblActividadesRevisadasMaestro.Text = "0"
            End If
            lblPromedioActividadesMestro.Text = Format(myr.GetPromedioActividad(CInt(hdclavesalon.Value)) / 10, "0.00")
            lblPromedioGeneralMaestro.Text = Format(mysvu.GetCalificacionGeneralTodos(CInt(hdclavesalon.Value)) / 10, "0.00")


            Dim mycc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion
            lblContenidosMaestro.Text = CInt((mycc.GetPromedio(CInt(hdclavesalon.Value)) * 100) / 5)




            Dim total As Integer = (CInt(lblActividadesRevisadasMaestro.Text) + (CInt(lblPromedioActividadesMestro.Text) * 10) + CInt(CInt(lblPromedioGeneralMaestro.Text) * 10) + CInt(lblContenidosMaestro.Text)) / 4
            Image1.ImageUrl = "~/images/espectometro/" & RegresarNumero(total) & ".gif"





        Else

            PanelAlumno.Visible = True
            PanelMestro.Visible = False

            Dim totalActividadesEnviadas As Integer = myr.Count(CInt(hdclavesalon.Value), CInt(hdclaveusuario.Value))
            If totalActividades > 0 Then
                lblActividadesAlumno.Text = CInt((totalActividadesEnviadas / totalActividades) * 100)
            Else
                lblActividadesAlumno.Text = "0"
            End If
            lblPromedioActividadesAlumno.Text = Format(myr.GetPromedioActividad(CInt(hdclavesalon.Value), CInt(hdclaveusuario.Value)) / 10, "0.00")
            lblPromedioGeneralAlumno.Text = Format(mysvu.GetCalificacionGeneral(CInt(hdclaveusuario.Value), CInt(hdclavesalon.Value)) / 10, "0.00")


            Dim mycc As Contenidos.ContenidoCalificacion = New Contenidos.ContenidoCalificacion
            Dim contenidosCalificados As Integer = mycc.Count(CInt(hdclavesalon.Value), CInt(hdclaveusuario.Value))
            If contenidosCalificados = "0" Then
                lblContenidosAlumno.Text = 0
            Else
                Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem
                Dim mysalon As Know.SalonVirtual = New Know.SalonVirtual(CInt(hdclavesalon.Value), False)
                myci.idRoot = mysalon.idRoot
                Dim numeroContenidos As Integer = myci.Count
                If numeroContenidos > 0 Then
                    lblContenidosAlumno.Text = CInt((contenidosCalificados / numeroContenidos) * 100)
                Else
                    lblContenidosAlumno.Text = 0
                End If
            End If


            Dim total As Integer = (CInt(lblActividadesAlumno.Text) + (CInt(lblPromedioActividadesAlumno.Text) * 10) + CInt(CInt(lblPromedioGeneralAlumno.Text)) * 10 + CInt(lblContenidosAlumno.Text)) / 4
            Image1.ImageUrl = "~/images/espectometro/" & RegresarNumero(total) & ".gif"

        End If


    End Sub


    Public Function RegresarNumero(ByVal total As Integer) As Integer
        Dim num As Integer = 0
        Select Case total
            Case 0 To 2
                num = 0
            Case 3 To 6
                num = 5
            Case 7 To 12
                num = 10
            Case 13 To 16
                num = 15
            Case 17 To 22
                num = 20
            Case 23 To 26
                num = 25
            Case 27 To 32
                num = 30
            Case 33 To 36
                num = 35
            Case 37 To 42
                num = 40
            Case 43 To 46
                num = 45
            Case 47 To 52
                num = 50
            Case 53 To 56
                num = 55
            Case 57 To 62
                num = 60
            Case 63 To 66
                num = 65
            Case 67 To 72
                num = 70
            Case 73 To 76
                num = 75
            Case 77 To 82
                num = 80
            Case 83 To 86
                num = 85
            Case 87 To 92
                num = 90
            Case 93 To 96
                num = 85
            Case 97 To 10000
                num = 100

        End Select


        Return num

    End Function

   

End Class
