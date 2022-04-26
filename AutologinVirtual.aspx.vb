
Partial Class AutologinVirtual
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("param") <> "" Then
            setlogin(Request("session"))
        Else
            Response.Redirect("logout.aspx")
        End If
    End Sub


    Sub setlogin(ByVal claveChurro As String)


        Dim param As String = Request("param")

        If param <> String.Empty Then
            Dim coleccionObjetos As Collection = getParametros(param)
            Dim email As String = ""
            Dim recuperaFecha As DateTime
            Dim salonVirtual As Integer

            ' Try
            salonVirtual = CInt(coleccionObjetos.Item(1).ToString)
            email = coleccionObjetos.Item(2).ToString
            recuperaFecha = CDate(coleccionObjetos.Item(3).ToString)

            'lblprueba.Text = salonVirtual & "----" & email & "----" & recuperaFecha.ToShortDateString


            Dim myu As New MasUsuarios.UserProfile(email, False)
            If Not myu.existe Then
                Dim myuserum As UM.UsuariosUM = New UM.UsuariosUM(email)
                Dim clave As Integer = 0

                If myuserum.existe Then
                    Dim myeu As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(myuserum.codigo_personal, 4, tipoObjeto.Alumno)
                    If Not myeu.existe Then
                        myeu = New MasUsuarios.EmpresaUserProfile(myuserum.codigo_personal, 4, tipoObjeto.Maestro)
                        If myeu.existe Then
                            clave = myeu.idUserProfile
                        End If
                    Else
                        clave = myeu.idUserProfile
                    End If
                End If

                If clave > 0 Then
                    myu = New MasUsuarios.UserProfile(clave, False)
                End If

            End If



            Session("gUserProfileSession") = myu.GetUserProfilesSession()
            FormsAuthentication.SetAuthCookie(myu.login, False)
            Response.Redirect("~/sec/SalonVirtual/default.aspx?idSalonVirtual=" & salonVirtual)


            '  Catch ex As Exception

            ' lblprueba.Text = coleccionObjetos.Item(1).ToString & "----" & coleccionObjetos.Item(2).ToString & "----" & coleccionObjetos.Item(3).ToString

            '   Response.Redirect("logout.aspx?error=Existe un error en los parametros")
            'End Try
        Else
            ' lblprueba.Text = " no viene ni un pinche dato"

            Response.Redirect("logout.aspx")
        End If





    End Sub




    Public Shared Function getParametros(cadena As String) As Collection
        Dim encoding As New System.Text.UTF8Encoding()
        Dim coleccionObjetos As New Collection
        Dim cadenaOriginal As String = desencriptar(cadena)
        Dim parametros As String() = cadenaOriginal.Split("&")
        For i As Integer = 0 To parametros.Length - 1
            coleccionObjetos.Add(parametros(i))
        Next

        If coleccionObjetos.Count > 0 Then
            Return coleccionObjetos
        End If

        Return Nothing
    End Function

    Public Shared Function desencriptar(ByVal cadena As String) As String
        Dim subcadenaBytes As String() = cadena.Split("-")
        Dim recoveredBytes(subcadenaBytes.Length - 1) As Byte
        Dim cadenaOriginal As String = ""

        For k As Integer = 0 To subcadenaBytes.Length - 1
            recoveredBytes(k) = cadenaHexToByte(subcadenaBytes(k))
        Next

        Try
            cadenaOriginal = desencriptar(recoveredBytes)
        Catch ex As Exception
            Dim m As String = ex.Message
        End Try

        Return cadenaOriginal
    End Function

    Public Shared Function desencriptar(ByVal entradaBytes() As Byte) As String
        Return New Utilerias.TripleDES().Decrypt(entradaBytes)
    End Function

    Private Shared Function cadenaHexToByte(cadena As String) As Byte
        Dim numeroByte As Byte = 0
        Dim caracteres() As Char = cadena.ToCharArray
        Array.Reverse(caracteres)

        Dim suma As Integer = 0
        For i As Integer = 0 To caracteres.Length - 1

            Dim numero As Integer
            Try
                numero = CInt(caracteres(i).ToString)
                suma += (numero * (16 ^ i))

            Catch ex As Exception

                Select Case caracteres(i).ToString.ToLower
                    Case "a"
                        suma += (10 * (16 ^ i))
                    Case "b"
                        suma += (11 * (16 ^ i))
                    Case "c"
                        suma += (12 * (16 ^ i))
                    Case "d"
                        suma += (13 * (16 ^ i))
                    Case "e"
                        suma += (14 * (16 ^ i))
                    Case "f"
                        suma += (15 * (16 ^ i))
                    Case Else
                        Return 0
                End Select

            End Try

        Next

        Try
            numeroByte = CByte(suma)
        Catch ex As Exception
        End Try

        Return numeroByte
    End Function



End Class
