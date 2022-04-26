Imports System.Data.OracleClient

Namespace UM

    Public Class UsuariosUM
        Inherits DBObjectOracle



        Public codigo_personal As String
        Public Usuario As String
        Public Clave As String

        Private varExiste As Boolean = False


#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property


        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property


#End Region

        Sub New()

        End Sub

        Sub New(ByVal claveUsuario As String)


            Dim queryString As String = "SELECT * FROM " & Me.sch & ".Usuarios where usuario = :usuario"

            Dim params As OracleParameter() = {New OracleParameter("usuario", claveUsuario)}

            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.codigo_personal = dr("CODIGO_PERSONAL")
                Else
                    Me.codigo_personal = ""
                End If

                If Not Convert.IsDBNull(dr("USUARIO")) Then
                    Me.Usuario = dr("USUARIO")
                Else
                    Me.Usuario = ""
                End If

                If Not Convert.IsDBNull(dr("CLAVE")) Then
                    Me.Clave = dr("CLAVE")
                Else
                    Me.Clave = ""
                End If
                Me.varExiste = True
            End If
            dr.Close()

        End Sub


        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function



        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader

            Return Nothing
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function


        Public Overrides Function Remove() As Integer

        End Function



        Public Overrides Function Update() As Integer

        End Function



        

       


        Public Function validarUsuario(ByVal pass As String) As Boolean
            Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bs As Byte() = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass))
            Dim result As String = Convert.ToBase64String(bs)
            If result = Me.Clave Then
                Return True
            Else
                Return False
            End If
        End Function


    End Class

End Namespace
