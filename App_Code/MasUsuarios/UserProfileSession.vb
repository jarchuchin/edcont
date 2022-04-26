Imports System.Configuration

Namespace MasUsuarios
    <Serializable()>
    Public Class UserProfileSession

#Region "declaración de variables"
        Public idUserProfile As Integer
        Public login As String
        Public nombre As String
        Public idioma As String
        Public estilo As String
        Public caja As String
        Public idEmpresaDefault As Integer
        Public header As String
        Public footer As String
        Public emailgoogle As String
        Public tipousuario As String

#End Region

        Public Sub New()
            Me.idUserProfile = 0
            Me.login = String.Empty
            Me.nombre = String.Empty
            Me.idioma = System.Configuration.ConfigurationManager.AppSettings("IdiomaDefault")

            Me.idEmpresaDefault = Convert.ToInt32(ConfigurationManager.AppSettings("EmpresaDefault"))
            Dim myEmpresa As New Empresa(Me.idEmpresaDefault)
            Me.header = myEmpresa.configuracion.htmlHeader
            Me.footer = myEmpresa.configuracion.htmlFooter
            Me.emailgoogle = String.Empty
            Me.tipoUsuario = "Alumno"
        End Sub
    End Class
End Namespace