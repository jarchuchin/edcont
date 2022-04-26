Imports System.Configuration
Imports System.Xml
Imports System
Imports System.Data


Namespace Utilerias
    'Public Class XMLIdioma
    '	Protected Idioma As String = "es"
    '	Protected dw As DataView
    '	Protected NumeroIdiomas As Integer

    '	Public Sub New(ByVal claveIdioma As String, Optional ByRef dataw As DataView = Nothing)
    '		If IsNothing(dataw) Then
    '			Dim myIdiomas As New Utilerias.Idioma
    '               dw = myIdiomas.GetDS().Tables(0).DefaultView
    '		Else
    '			dw = dataw
    '		End If


    '		Idioma = claveIdioma
    '		Select Case claveIdioma
    '			Case "es"
    '				NumeroIdiomas = 2
    '			Case "en"
    '				NumeroIdiomas = 1
    '			Case "fr"
    '				NumeroIdiomas = 3
    '			Case "ps"
    '				NumeroIdiomas = 4
    '			Case Else
    '				NumeroIdiomas = 2
    '		End Select
    '	End Sub

    '	Public Function GetString(ByVal claveid As String, Optional ByVal cadenaNARetorno As String = "N.D.") As String
    '		Dim i As Integer
    '		Dim vals(0) As Object
    '		dw.Sort = "Clave"
    '		vals(0) = claveid

    '		i = dw.Find(vals)

    '		If i >= 0 Then
    '			Return dw.Item(i).Item(NumeroIdiomas)
    '		Else
    '			Return cadenaNARetorno 'antes N/A
    '		End If
    '	End Function
    '   End Class


End Namespace