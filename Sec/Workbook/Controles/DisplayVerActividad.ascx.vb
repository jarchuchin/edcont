
Partial Class Sec_Workbook_Controles_DisplayVerActividad
    Inherits System.Web.UI.UserControl
    Dim varContenido As Integer
    Dim varTipo As String

    Public Property claveContenido As Integer
        Set(value As Integer)
            varContenido = value
        End Set
        Get
            Return varContenido
        End Get
    End Property

    Public Property tipoContenido As String
        Set(value As String)
            varTipo = value
        End Set
        Get
            Return varTipo
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()










        If varTipo = tipoObjeto.Actividad.ToString Then




            Dim myAct As Contenidos.Actividad = New Contenidos.Actividad(varContenido)

            If myAct.tipodeActividad = Contenidos.ETipodeActividad.Actividad Then
                panelContenidos.Visible = True

                txtid.Text = myAct.id
                txtTitulo.Text = myAct.titulo
                txttags.Text = myAct.Tags
                Page.Title = myAct.titulo

                txtObjetivoCompetencia.Text = myAct.Objetivo.Replace(vbCrLf, "<br>")
                txtTipoX.Text = myAct.TipoX

                rdbComoSeCalifica.Items(0).Selected = False
                rdbComoSeCalifica.Items(1).Selected = False
                rdbComoSeCalifica.Items(2).Selected = False
                rdbComoSeCalifica.Items(3).Selected = False



                Select Case myAct.comoSeCalifica
                    Case Contenidos.EComoSeCalifica.ValorNumerico
                        rdbComoSeCalifica.Items(0).Selected = True
                    Case Contenidos.EComoSeCalifica.Ranking
                        rdbComoSeCalifica.Items(1).Selected = True
                    Case Contenidos.EComoSeCalifica.Rubrica
                        rdbComoSeCalifica.Items(3).Selected = True
                        llenarRubricaTable(myAct.id)
                        panelRubricaB.Visible = True
                    Case Contenidos.EComoSeCalifica.RubricaA
                        rdbComoSeCalifica.Items(2).Selected = True
                        llenarRubricaTableA(myAct.id)
                        panelRubricaA.Visible = True
                End Select


                If myAct.respuestaGrupal > 1 Then
                    chkActivarRespuestaGrupal.Checked = True
                    drpRespuestaGrupal.Visible = True
                    drpRespuestaGrupal.SelectedValue = myAct.respuestaGrupal
                End If


                If myAct.quienCalifica = Contenidos.EQuienCalifica.Maestro Then
                    rdbQuiencalifica.Items(0).Selected = True
                    rdbQuiencalifica.Items(1).Selected = False
                Else
                    rdbQuiencalifica.Items(0).Selected = False
                    rdbQuiencalifica.Items(1).Selected = True
                End If

                chkmostrarRespuestas.Checked = myAct.mostrarRespuestas
                chkMostrarCalificacion.Checked = myAct.mostrarCalificacion
                chkMostrarObservaciones.Checked = myAct.mostrarObservaciones


                txtInstrucciones.Text = myAct.instrucciones.Replace(vbCrLf, "<br>")
                txtparaInstructor.Text = myAct.ParaInstructor.Replace(vbCrLf, "<br>")



                llenarRubricaTable(myAct.id)

                lnkVerRubrica.Visible = True


                pasaDatosACajitas(myAct, showArchivosAdjuntos, Contenidos.TipoContenido.Archivo, myAct.id)
                pasaDatosACajitas(myAct, showImagenesAdjuntos, Contenidos.TipoContenido.Imagen, myAct.id)
                pasaDatosACajitas(myAct, showFlashes, Contenidos.TipoContenido.Flash, myAct.id)
                pasaDatosACajitas(myAct, showDirecciones, Contenidos.TipoContenido.Liga, myAct.id)

            Else
                panelContenidos.Visible = False
            End If




        End If


    End Sub


    Private Sub pasaDatosACajitas(ByRef objActividad As Contenidos.Actividad, control As Sec_Workbook_Controles_showadjuntos, _
             tipo As Contenidos.TipoContenido, Optional idActividad As Integer = 0)
        With control
            .idProc = objActividad.id
            .procedencia = objActividad.tipo.ToString
            .tipoAdjunto = tipo
        End With
    End Sub



    Sub llenarRubricaTable(claveActividad As Integer)


        Dim myrubrica As New Lego.Rubrica
        rptRubricas.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricas.DataBind()



    End Sub

    Sub llenarRubricaTableA(claveActividad As Integer)


        Dim myrubrica As New Lego.Rubrica
        rptRubricasA.DataSource = myrubrica.GetDS(claveActividad)
        rptRubricasA.DataBind()


        lblTotalRubricaA.Text = myrubrica.GetTotalValorRubricaA(claveActividad)

    End Sub

End Class
