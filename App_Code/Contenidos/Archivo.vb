Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class Archivo
		Inherits DBObject

#Region "Variables"
		Public idContenido As Integer
		Public ArchivoSize As Integer
		Public Archivo() As Byte
		Public ArchivoStream As Stream
		Public varbandera As Boolean = False
		Public Extension As String

		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idContenido
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Archivo
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer, ByVal claveExtension As String)
			Me.idContenido = clavePrincipal
			Me.Extension = claveExtension

            If File.Exists(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & Me.idContenido & "." & Me.Extension) Then
                Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & Me.idContenido & "." & Me.Extension, _
                 FileMode.OpenOrCreate, FileAccess.Read)
                ReDim Me.Archivo(fs.Length)
                fs.Read(Archivo, 0, fs.Length)
                fs.Close()
                varExiste = True
            End If
		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			'colocar archivo
			ReDim Me.Archivo(Me.ArchivoSize)
			ArchivoStream.Read(Me.Archivo, 0, Me.ArchivoSize)

			Dim K As Long
			K = UBound(Archivo)
            Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & Me.idContenido & "." & Me.Extension, _
    FileMode.OpenOrCreate, FileAccess.Write)
			fs.Write(Archivo, 0, K)
			fs.Close()
			fs = Nothing

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Return 0
		End Function

		Public Overrides Function Remove() As Integer
            If File.Exists(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & Me.idContenido & "." & Me.Extension) Then
                File.Delete(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & Me.idContenido & "." & Me.Extension)
            End If
		End Function

		Public Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function

		Public Function AddUserPicture(ByVal nombre As String) As Integer
			'colocar archivo
			ReDim Me.Archivo(Me.ArchivoSize)
			ArchivoStream.Read(Me.Archivo, 0, Me.ArchivoSize)

			Dim K As Long
			K = UBound(Archivo)
            Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("carpetaArchivos") & "userPictures\" & nombre, FileMode.OpenOrCreate, FileAccess.Write)
			fs.Write(Archivo, 0, K)
			fs.Close()
			fs = Nothing
		End Function

		Public Function ArchivosAlDisco() As Integer
			Dim queryString As String = "SELECT * FROM Archivo"

			Dim ds As DataSet = Me.ExecuteDataSet(queryString, Nothing)
			Dim i As Integer
			Dim objCont As Contenido

			For i = 0 To ds.Tables(0).Rows.Count - 1
				Me.idContenido = ds.Tables(0).Rows(i)("idContenido")
				Me.Archivo = ds.Tables(0).Rows(i)("Archivo")

				objCont = New Contenido(Me.idContenido)

				Dim K As Long
				K = UBound(Archivo)
                Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & objCont.id & "." & objCont.extension, _
     FileMode.OpenOrCreate, FileAccess.Write)
				fs.Write(Archivo, 0, K)
				fs.Close()
				fs = Nothing
				K = Nothing
			Next

			Return i
		End Function

		Public Function ArchivosAlDiscoDR() As Integer
			Dim queryString As String = "SELECT * FROM Archivo"

			Dim dr As IDataReader = Me.ExecuteReader(queryString, Nothing)
			Dim i As Integer
			Dim objCont As Contenido

			Do While dr.Read
				Me.idContenido = CInt(dr("idContenido"))
				Me.Archivo = dr("Archivo")
				objCont = New Contenido(Me.idContenido)

				Dim K As Long
				K = UBound(Archivo)
                Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("carpetaArchivos") & "files\" & objCont.id & "." & objCont.extension, _
     FileMode.OpenOrCreate, FileAccess.Write)
				fs.Write(Archivo, 0, K)
				fs.Close()
				fs = Nothing
				K = Nothing

				i += 1
			Loop
			dr.Close()

			Return i
		End Function
#End Region
	End Class
End Namespace
