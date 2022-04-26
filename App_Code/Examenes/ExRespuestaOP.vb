Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Examenes
	Public NotInheritable Class ExRespuestaOP
		Inherits DBObject


        Private idExRespuestaOP As Integer
        Public idOP As Integer
        Public idExRespuesta As Integer
        Public idORSeleccionada As Integer

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idExRespuestaOP
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ExRespuestasOP
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM ExRespuestasOP WHERE idExRespuestaOP = @idExRespuestaOP"

            Dim parameters As SqlParameter() = {New SqlParameter("@idExRespuestaOP", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idExRespuestaOP = CType(dr("idExRespuestaOP"), Integer)
                Me.idOP = CType(dr("idOP"), Integer)
                Me.idExRespuesta = CType(dr("idExRespuesta"), Integer)
                Me.idORSeleccionada = CType(dr("idORSeleccionada"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveOP As Integer, ByVal claveExRespuesta As Integer)
            Dim queryString As String = "SELECT * FROM ExRespuestasOP WHERE idOP = @idOP AND idExRespuesta = @idExRespuesta"

            Dim parameters As SqlParameter() = {New SqlParameter("@idOP", claveOP), New SqlParameter("@idExRespuesta", claveExRespuesta)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idExRespuestaOP = CType(dr("idExRespuestaOP"), Integer)
                Me.idOP = CType(dr("idOP"), Integer)
                Me.idExRespuesta = CType(dr("idExRespuesta"), Integer)
                Me.idORSeleccionada = CType(dr("idORSeleccionada"), Integer)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [ExRespuestasOP] ([idOP], [idExRespuesta], [idORSeleccionada]) " & _
                 "VALUES (@idOP, @idExRespuesta, @idORSeleccionada)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idOP", Me.idOP), _
                  New SqlParameter("@idExRespuesta", Me.idExRespuesta), _
                  New SqlParameter("@idORSeleccionada", Me.idORSeleccionada)}

                Me.idExRespuestaOP = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [ExRespuestasOP] SET [idORSeleccionada]=@idORSeleccionada WHERE idExRespuestaOP = @idExRespuestaOP"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idExRespuestaOP", Me.idExRespuestaOP), _
                 New SqlParameter("@idORSeleccionada", Me.idORSeleccionada)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Return 0
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

        Public Function GetAciertos(ByVal clavePregunta As Integer, ByVal claveExRespuesta As Integer) As Integer
            Dim myOP As New OpcionPregunta
            Dim numero As Integer = 0
            Dim dr As SqlClient.SqlDataReader = myOP.GetDR(clavePregunta)
            Dim myExrOP As ExRespuestaOP

            Do While dr.Read
                myExrOP = New ExRespuestaOP(CType(dr("idOP"), Integer), claveExRespuesta)
                If myExrOP.idORSeleccionada = CType(dr("idOR"), Integer) Then
                    numero = numero + 1
                End If
            Loop
            dr.Close()

            Return numero
        End Function



    End Class
End Namespace

