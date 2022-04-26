Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Partial Class Sec_SalonVirtual_createBBB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub


    Sub cargardatos()


        Dim servername As String = "http://bbb.um.edu.mx/"


        Dim mysvc As New Know.SalonVirtualCompartido
        Dim salonPrincipal As Integer = mysvc.getSalonPrincipal(CInt(Request("idSalonVirtual")))

        If salonPrincipal = 0 Then
            salonPrincipal = CInt(Request("idSalonVirtual"))
        End If
        Dim mysv As New Know.SalonVirtual(salonPrincipal, False)
        Dim varesAlumno As Boolean = EsAlumno(Session("gUserProfileSession").idUserProfile, CInt(Request("idSalonVirtual")))

        Dim claveBridge As String

        If mysv.bbmeetingID <> "" Then
            claveBridge = generarRoom()
        Else
            claveBridge = generarRoom()
        End If


        Dim mysv2 As New Know.SalonVirtual(salonPrincipal, False)
        Dim nombre1 As String = String.Empty
        Dim salt As String = "9d857467726e2a49fd2ff78272e68d89"
        Dim cadenarara As String = String.Empty
        Dim nombreusuario As String = quitaMugres(Session("gUserProfileSession").nombre)
        Dim callName As String = "join"
        If varesAlumno Then
            nombre1 = "fullName=" & nombreusuario & "&meetingID=" & mysv2.bbmeetingID & "&password=" & mysv2.bbattendeePW & "&voiceBridge=" & claveBridge
            cadenarara = getSHA1Hash(callName & nombre1 & salt)
            Response.Redirect(servername & "bigbluebutton/api/join?fullName=" & nombreusuario & "&meetingID=" & mysv2.bbmeetingID & "&password=" & mysv2.bbattendeePW & "&voiceBridge=" & claveBridge & "&checksum=" & cadenarara)
        Else
            nombre1 = "fullName=" & nombreusuario & "&meetingID=" & mysv2.bbmeetingID & "&password=" & mysv2.bbmoderatorPW & "&voiceBridge=" & claveBridge
            cadenarara = getSHA1Hash(callName & nombre1 & salt)
            Response.Redirect(servername & "bigbluebutton/api/join?fullName=" & nombreusuario & "&meetingID=" & mysv2.bbmeetingID & "&password=" & mysv2.bbmoderatorPW & "&voiceBridge=" & claveBridge & "&checksum=" & cadenarara)
        End If


    End Sub



    Function quitaMugres(ByVal cadena As String) As String
        Dim reg As RegularExpressions.Regex



        Dim textoNormalizado As String = cadena.Normalize(NormalizationForm.FormD)

        'coincide todo lo que no sean letras y números ascii o espacio
        'y lo reemplazamos por una cadena vacía.

        reg = New RegularExpressions.Regex("[^a-zA-Z0-9 ]")
        Dim textoSinAcentos As String = reg.Replace(textoNormalizado, "")
        Return textoSinAcentos.Replace(" ", "")


    End Function

    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next



        Return strResult

    End Function

    Public Function EsAlumno(ByVal claveusuario As Integer, ByVal clavesalon As Integer) As Boolean
        Dim mysvu As Know.SalonVirtualUserProfile = New Know.SalonVirtualUserProfile(claveusuario, clavesalon, False)
        Return mysvu.existe

    End Function


    Function generarRoom() As String

        Dim servername As String = "http://bbb.um.edu.mx/"

        Dim mysvc As New Know.SalonVirtualCompartido
        Dim salonPrincipal As Integer = mysvc.getSalonPrincipal(CInt(Request("idSalonVirtual")))
        If salonPrincipal = 0 Then
            salonPrincipal = CInt(Request("idSalonVirtual"))
        End If
        Dim mysalonVirtual As Know.SalonVirtual = New Know.SalonVirtual(salonPrincipal, False)

        Dim claveBridge As String = FiveDigitRand()

        Dim nombre1 As String = "name=" & mysalonVirtual.claveAux1 & "&meetingID=" & mysalonVirtual.claveAux1 & "&attendeePW=111222&moderatorPW=333444" & "&voiceBridge=" & claveBridge
        Dim salt As String = "9d857467726e2a49fd2ff78272e68d89"
        Dim callName As String = "create"

        Dim cadenarara As String = getSHA1Hash(callName & nombre1 & salt)

        Dim cadena As String = getdatos(servername & "bigbluebutton/api/create?" & nombre1 & "&checksum=" & cadenarara)
        '  Dim cadena As String = getdatos("http://ec2-75-101-178-85.compute-1.amazonaws.com/bigbluebutton/api/")

        lblMensaje.Text = cadena




        Dim cadenaelifo As String = "xxxxxxxxxxxxxxxxxxxxxxxx"




        Dim bbmeetingID As String = String.Empty
        Dim bbmoderatorPW As String = String.Empty
        Dim bbattendeePW As String = String.Empty


        Dim xmlDoc As New XmlDocument
        Dim productNodes As XmlNodeList
        Dim productNode As XmlNode
        Dim baseDataNodes As XmlNodeList
        Dim bFirstInRow As Boolean

        xmlDoc.LoadXml(cadena)

        productNodes = xmlDoc.GetElementsByTagName("response")
        For Each productNode In productNodes
            baseDataNodes = productNode.ChildNodes
            bFirstInRow = True
            For Each baseDataNode As XmlNode In baseDataNodes
                If baseDataNode.Name.ToLower = "meetingid" Then
                    bbmeetingID = baseDataNode.InnerText
                End If
                If baseDataNode.Name.ToLower = "attendeepw" Then
                    bbattendeePW = baseDataNode.InnerText
                End If
                If baseDataNode.Name.ToLower = "moderatorpw" Then
                    bbmoderatorPW = baseDataNode.InnerText
                End If


            Next
        Next


        If bbmeetingID <> "" And bbattendeePW <> "" And bbmoderatorPW <> "" Then
            mysalonVirtual.bbmeetingID = bbmeetingID
            mysalonVirtual.bbattendeePW = bbattendeePW
            mysalonVirtual.bbmoderatorPW = bbmoderatorPW
            mysalonVirtual.Update()
        End If

        Return claveBridge

    End Function

    Dim myRand As New Random
    Private Function FiveDigitRand() As String
        'return a numeric string between 000000001 and 999999999 inclusive
        'Return myRand.Next(1, 100000).ToString("d5")
        Return 70000 + myRand.Next(1, 9999)
    End Function


    Public Function getdatos(ByVal url As String) As String
        Dim result As String
        Try
            Dim objRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

            objRequest.Method = "GET"
            Dim objResponse As System.Net.HttpWebResponse = objRequest.GetResponse()
            Dim sr As System.IO.StreamReader
            sr = New System.IO.StreamReader(objResponse.GetResponseStream())
            result = sr.ReadToEnd()
            sr.Close()

            Return result
        Catch ex As Exception
            Return ex.Message.ToString
        End Try



    End Function

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        cargardatos()
    End Sub


End Class
