
Partial Class Sec_Workbook_Controles_showAdjuntosEdicion2Ligas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Public cadena As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual") & "sec/showFile.aspx?idCont="
    Sub colocarDatos()

        Dim myCI As Lego.ClasificacionItem = New Lego.ClasificacionItem(CInt(Request("idCI")))

        Dim myca As New Contenidos.ContenidoAdjunto
        gvAdjuntos.DataSource = myca.GetDRLigas(myCI.idProc, myCI.procedencia.ToString)
        gvAdjuntos.DataBind()



        If gvAdjuntos.Rows.Count > 0 Then
            btnBorrar22.Visible = True
        Else
            btnBorrar22.Visible = False
        End If


    End Sub

    Protected Function esVisible(claveTipo As Integer) As Boolean
        If claveTipo = 3 Then
            Return True
        Else
            Return False

        End If

    End Function

    Public Function getimagen(path As String, claveTipo As Integer, claveContenido As Integer) As String
        If claveTipo = 3 Then
            Return cadena & claveContenido
        Else
            Return "~/images/transp.gif"
        End If
    End Function

    Protected Function BytesToString(byteCount As Long) As String
        Dim suf As String() = {"B", "KB", "MB", "GB", "TB", "PB",
            "EB"}
        'Longs run out around EB
        If byteCount = 0 Then
            Return "0" + suf(0)
        End If
        Dim bytes As Long = Math.Abs(byteCount)
        Dim place As Integer = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)))
        Dim num As Double = Math.Round(bytes / Math.Pow(1024, place), 1)
        Return (Math.Sign(byteCount) * num).ToString() + suf(place)
    End Function



    Protected Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar22.Click
        Dim myca As Contenidos.ContenidoAdjunto
        Dim myc As Contenidos.Contenido

        For Each row As GridViewRow In gvAdjuntos.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chk As CheckBox = CType(row.FindControl("chkid"), CheckBox)
                Dim lbl As Label = CType(row.FindControl("lblid"), Label)

                If chk.Checked Then
                    myca = New Contenidos.ContenidoAdjunto(CInt(lbl.Text))
                    myc = New Contenidos.Contenido(myca.idContenido)

                    myca.Remove()
                    myc.Remove()

                End If

            End If
        Next


        Response.Redirect("~/sec/workbook/addcontenido.aspx?idRoot=" & Request("idRoot") & "&idClasificacion=" & Request("idClasificacion") & "&Proc=Texto&idCI=" & Request("idCI") & "&regreso=" & Request("regreso"))

    End Sub
End Class
