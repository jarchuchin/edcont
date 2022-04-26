
Partial Class Sec_PagoEnLinea02
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()

        If Session("gUserProfileSession").nombre <> "" Then

            Dim myu As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.existe Then
                Dim myue As New MasUsuarios.EmpresaUserProfile(myu.id, 4, "")
                If myue.existe Then
                    lblAlumno.Text = myue.claveAux1 & " - " & Session("gUserProfileSession").nombre


                    If Session("pagoAlumno") <> "" Then

                        lblAlumno.Text = Session("pagoMatricula") & " - " & Session("pagoAlumno")

                        txtpago.Text = FormatCurrency(Session("pagoCantidad"))

                        txtNumeroCuenta.Text = "**** **** **** " & CStr(Session("pagoNumero")).Substring(12, 4)
                        txtNombre.Text = Session("pagoNombreTarjeta")
                        drpTipoTarjeta.Text = Session("pagoTipo")
                        drpMes.Text = Session("pagoMes")
                        drpAno.Text = Session("pagoAno")
                        txtNumeroExtra.Text = Session("pagoCodigo")

                        'Session("pagoCP") = txtCP.Text
                    Else
                        Response.Redirect("PagoEnLinea.aspx")
                    End If
                Else
                    btnPagar.Visible = False
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If
        Else
            Response.Redirect("~/logout.aspx")
        End If




    End Sub
    Protected Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click


        If Page.IsValid Then



            Dim myu As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)
            If myu.existe Then
                Dim myue As New MasUsuarios.EmpresaUserProfile(myu.id, 4, "")
                If myue.existe Then
                    If Session("pagoAlumno") <> "" Then

                        'procesar pago

                        pagoEnLinea(myu)

                    Else
                        Response.Redirect("PagoEnLinea.aspx")
                    End If

                Else
                    Response.Redirect("~/logout.aspx")
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If



    End Sub


    Private Sub pagoEnLinea(myu As MasUsuarios.UserProfile)


        '  Dim objStoreBeanClient As New ServiceReference1.PagoEnLineaPortClient 'umpay.StoreBeanClient




        Dim clerk As String = "SkolarPay"
        Dim comment As String = "SkolarPay." & Session("pagoMatricula") & "." & Session("pagoAlumno")
        Dim claveTransaccion As String = String.Empty

        Dim vigenciaTarjeta As String = CStr(Session("pagoAno")).Substring(2)
        If CInt(Session("pagoMes")) > 9 Then
            vigenciaTarjeta = Session("pagoMes") & vigenciaTarjeta
        Else
            vigenciaTarjeta = "0" & Session("pagoMes") & vigenciaTarjeta
        End If
        'Dim transaccionRealizada As Boolean = False
        Dim total As String = totalToString(CDec(Session("pagoCantidad")))


        'Try

        '···············  objPagoDan = New ServiceReference2.PagoEnLineaPortClient
        ' objPagoDan.comentario
        'objPagoDan.

        ' Dim objpagx As New ServiceReference2.PagoEnLineaPortClient(objpagx)
        Dim objPagoS2 As New ServiceReference1.getPagoRequest
        objPagoS2.comentario = comment
        objPagoS2.cvv = Session("pagoCodigo")
        objPagoS2.fechaVencimiento = vigenciaTarjeta
        objPagoS2.tarjeta = Session("pagoNumero")
        objPagoS2.monto = total
        If CStr(Session("pagoTipo")) = "3" Then
            objPagoS2.tarjetaTipo = "VISA"
        End If
        If CStr(Session("pagoTipo")) = "2" Then
            objPagoS2.tarjetaTipo = "MC"
        End If

        Dim service As New ServiceReference1.PagoEnLineaPortClient


        Dim objResponseS2 As ServiceReference1.getPagoResponse = service.getPago(objPagoS2)

        If objResponseS2.respuesta.returnCodeId = "2" Then
            'objPago.status = UMOnline.statusPago.aprobado

            Dim myb As New Know.Bitacora
            myb.idUserProfile = myu.id
            myb.idSalonVirtual = 0
            myb.ip = Request.UserHostAddress
            myb.Modulo = "SkolarPay"
            myb.Bitacora = "Pago ACEPTADO: " & total & " - " & Session("pagoMatricula") & "." & Session("pagoAlumno") & " - Confirmación: " & objResponseS2.respuesta.confirmationNumber & " - Codigo Autorizacion - " & objResponseS2.respuesta.authorizationCode
            myb.Fecha = Date.Now
            myb.Add()


            'limpiar session 
            Session("pagoMatricula") = Nothing
            Session("pagoAlumno") = Nothing
            Session("pagoCantidad") = Nothing
            Session("pagoNumero") = Nothing
            Session("pagoNombreTarjeta") = Nothing
            Session("pagoTipo") = Nothing
            Session("pagoMes") = Nothing
            Session("pagoAno") = Nothing
            Session("pagoCodigo") = Nothing

            Session("pagoCP") = Nothing


            Session("objPago") = objResponseS2
            Response.Redirect("PagoEnLineaConfirmacion.aspx?codigo=" & objResponseS2.respuesta.authorizationCode)



        Else
            Dim myb As New Know.Bitacora
            myb.idUserProfile = myu.id
            myb.idSalonVirtual = 0
            myb.ip = Request.UserHostAddress
            myb.Modulo = "SkolarPay"
            myb.Bitacora = "Pago RECHAZADO: " & total & " - " & Session("pagoMatricula") & "." & Session("pagoAlumno") & " - Codigo de error: " & objResponseS2.respuesta.returnCodeId
            myb.Fecha = Date.Now
            myb.Add()

            lblErrorTarjeta.Visible = True
            lblTerminacionTarjeta.Text = CStr(Session("pagoNumero")).Substring(12, 4)
            lblRazonRechazo.Text = objResponseS2.respuesta.returnCodeId
            panelPagoPrevio.Visible = True


        End If

        'claveTransaccion = objStoreBeanClient.sell(clerk, comment, objPago.numeroTarjeta, vigenciaTarjeta, total, objPago.cp, objPago.direccion, objPago.numeroSeguridadTarjeta)

        'If claveTransaccion.Substring(1, 1) = "Y" Then
        '    objPago.status = UMOnline.statusPago.aprobado
        '    'transaccionRealizada = True
        'Else
        '    objPago.status = UMOnline.statusPago.rechazo_bancario
        'End If

        '  objPago.claveTransaccion = objResponseS2.respuesta.confirmationNumber
        'Catch ex As Exception
        'objPago.status = UMOnline.statusPago.no_definido
        'End Try



    End Sub


    Private Function totalToString(total As Decimal) As String
        Dim amount As String = String.Format("{0:#.00}", total)

        If amount.Contains(",") Then
            If amount.Contains(".") Then

                If amount.IndexOf(",") < amount.IndexOf(".") Then
                    Return amount.Replace(",", "")      ' si la coma está primero, simplemente la elimino y queda el punto, que está después
                Else
                    amount = amount.Replace(".", "")                    ' si el punto va primero, lo elimino; luego cambio la coma por punto porque es el separador de decimales
                    Return amount.Replace(",", ".")
                End If

            Else
                Return amount.Replace(",", ".")         ' solo cambiamos la coma por punto porque no hay punto previo
            End If
        End If

        Return amount       'devolvemos la conversión tal cual porque no tiene coma
    End Function

End Class
