Imports System.Data.OracleClient
Imports System.Data

Namespace UM

    Public Class Alum_Personal
        Inherits DBObjectOracle



        Public Codigo_Personal As String
        Public Nombre As String
        Public Apellido_Paterno As String
        Public Apellido_Materno As String
        Public Nombre_Legal As String
        Public F_Nacimiento As Date
        Public Sexo As String
        Public Email As String
        Public Curp As String
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

        Sub New(ByVal clavePrincipal As String)

        
            Dim queryString As String = "SELECT * FROM " & Me.sch & ".UsuarioSkolar where usuario = :usuario"

            Dim params As OracleParameter() = {New OracleParameter("usuario", clavePrincipal)}
            
            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, params)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("CODIGO_PERSONAL")) Then
                    Me.Codigo_Personal = dr("CODIGO_PERSONAL")
                Else
                    Me.Codigo_Personal = ""
                End If
                If Not Convert.IsDBNull(dr("NOMBRE")) Then
                    Me.Nombre = dr("NOMBRE")
                Else
                    Me.Nombre = ""
                End If
                If Not Convert.IsDBNull(dr("APELLIDO_PATERNO")) Then
                    Me.Apellido_Paterno = dr("APELLIDO_PATERNO")
                Else
                    Me.Apellido_Paterno = ""
                End If
                If Not Convert.IsDBNull(dr("APELLIDO_MATERNO")) Then
                    Me.Apellido_Materno = dr("APELLIDO_MATERNO")
                Else
                    Me.Apellido_Materno = ""
                End If
                If Not Convert.IsDBNull(dr("NOMBRE_LEGAL")) Then
                    Me.Nombre_Legal = dr("NOMBRE_LEGAL")
                Else
                    Me.Nombre_Legal = ""
                End If

                Me.F_Nacimiento = CType(dr("F_NACIMIENTO"), Date)

                If Not Convert.IsDBNull(dr("SEXO")) Then
                    Me.Sexo = dr("SEXO")
                Else
                    Me.Sexo = ""
                End If
                If Not Convert.IsDBNull(dr("EMAIL")) Then
                    Me.Email = dr("EMAIL")
                Else
                    Me.Email = ""
                End If
                If Not Convert.IsDBNull(dr("CURP")) Then
                    Me.Curp = dr("CURP")
                Else
                    Me.Curp = ""
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



        Public Function GetDRAlumnos() As Data.OracleClient.OracleDataReader
          
            Dim queryString As String = "SELECT * FROM " & Me.sch & ".UsuarioSkolar where (codigo_personal like '1%')"

            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, Nothing)

            Return dr

        End Function

        Public Function GetDRMaestros() As Data.OracleClient.OracleDataReader
          
            Dim queryString As String = "select * from " & Me.sch & ".UsuarioSkolar where (codigo_personal like '98%' or codigo_personal like '97%') and usuario is not null"

            Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(queryString, Nothing)

            Return dr

        End Function

        Public Function ColocarAlumnosASkolar(ByVal claveEmpresa As Integer) As Integer
            Dim dr As System.Data.OracleClient.OracleDataReader = Me.GetDRAlumnos()
            Dim mya As UM.Alumno
            Do While dr.Read
                mya = New UM.Alumno()
                mya.idEmpresa = claveEmpresa
                mya.clave = dr("CODIGO_PERSONAL")
                If Convert.IsDBNull(dr("USUARIO")) Then
                    mya.login = dr("CODIGO_PERSONAL")
                Else
                    mya.login = dr("USUARIO")
                End If
                mya.nombre = dr("NOMBRE")
                mya.apellidos = dr("APELLIDO_PATERNO") & " " & dr("APELLIDO_MATERNO")
                Dim fecha As Date = CType(dr("F_NACIMIENTO"), Date)
                mya.fechaNac = fecha.Day & "/" & fecha.Month & "/" & fecha.Year
                mya.sexo = dr("SEXO")
                mya.grabado = 0

                mya.Add()
            Loop
            dr.Close()

        End Function

        Public Function ColocarMaestrosASkolar(ByVal claveEmpresa As Integer) As Integer
            Dim dr As System.Data.OracleClient.OracleDataReader = Me.GetDRMaestros()
            Dim mym As UM.Maestro
            Do While dr.Read
                mym = New UM.Maestro
                mym.idEmpresa = claveEmpresa
                mym.clave = dr("CODIGO_PERSONAL")
                If Convert.IsDBNull(dr("USUARIO")) Then
                    mym.login = dr("CODIGO_PERSONAL")
                Else
                    mym.login = dr("USUARIO")
                End If
                mym.nombre = dr("NOMBRE")
                mym.apellidos = dr("APELLIDO_PATERNO") & " " & dr("APELLIDO_MATERNO")
                Dim fecha As Date = CType(dr("F_NACIMIENTO"), Date)
                mym.fechaNac = fecha.Day & "/" & fecha.Month & "/" & fecha.Year
                mym.sexo = dr("SEXO")
                mym.grabado = 0
                mym.Add()
            Loop
            dr.Close()

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
