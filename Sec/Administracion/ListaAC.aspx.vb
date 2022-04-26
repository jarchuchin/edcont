
Partial Class Sec_Administracion_ListaAC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        Dim mycahp As New Contenidos.CatalogoActividadHP
        gvActivdiades.DataSource = mycahp.GetDSTipoC("Actividad")
        gvActivdiades.DataBind()


    End Sub

    Public Function existeFile(clave As Object) As Boolean
        If Not Convert.IsDBNull(clave) Then
            If CStr(clave) = "" Then
                Return False
            Else
                Return True
            End If

        Else
            Return False
        End If


    End Function
End Class
