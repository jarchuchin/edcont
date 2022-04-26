Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Examenes
    Public NotInheritable Class OpcionPregunta
        Inherits DBObject

#Region "Variables"
        Private idOP As Integer
        Public idOR As Integer
        Public idPregunta As Integer
        Public enunciado As String
        Public archivo As Integer
        Public Eliminado As Boolean
        Public fileName As String = ""


        Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idOP
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.OpcionPregunta
            End Get
        End Property
#End Region

#Region "Constructores"
        Public Sub New()
        End Sub

        Public Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM OpcionesPregunta WHERE idOP = @idOP"

            Dim parameters As SqlParameter() = {New SqlParameter("@idOP", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idOP = CType(dr("idOP"), Integer)
                Me.idOR = CType(dr("idOR"), Integer)
                Me.enunciado = CType(dr("enunciado"), String)
                Me.archivo = CType(dr("archivo"), Integer)
                Me.idPregunta = CType(dr("idPregunta"), Integer)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                If Not Convert.IsDBNull(dr("fileName")) Then
                    Me.fileName = dr("fileName")
                Else
                    Me.fileName = ""
                End If
                Me.varExiste = True
            End If
            dr.Close()

        End Sub
#End Region

#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [OpcionesPregunta] ([idOR], [idPregunta], [enunciado], [archivo], eliminado, fileName) " & _
                 "VALUES (@idOR, @idPregunta, @enunciado, @archivo, @eliminado, @fileName)"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idOR", Me.idOR), _
                  New SqlParameter("@idPregunta", Me.idPregunta), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                  New SqlParameter("@eliminado", Me.Eliminado), _
                  New SqlParameter("@fileName", Me.fileName)}

                Me.idOP = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [OpcionesPregunta] SET [enunciado]=@enunciado, [archivo]=@archivo, " & _
                 "[idOR]=@idOR, eliminado=@eliminado, fileName=@fileName WHERE idOP = @idOP"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idOP", Me.idOP), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                  New SqlParameter("@idOR", Me.idOR), _
                  New SqlParameter("@eliminado", Me.Eliminado), _
                  New SqlParameter("@fileName", Me.fileName)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overloads Overrides Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()

        End Function

        Public Overloads Function Remove(ByVal clavePregunta As Integer) As Integer
            Try
                Dim queryString As String = "DELETE FROM [OpcionesPregunta] WHERE idPregunta = @idPregunta"

                Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

                Return Me.ExecuteNonQuery(queryString, parametros)
            Catch ex As Exception
                Return 0
            End Try
        End Function

    

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal clavePregunta As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM OpcionesPregunta  WHERE idPregunta = @idPregunta and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal clavePregunta As Integer, ByVal claveOR As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM OpcionesPregunta WHERE idPregunta = @idPregunta AND idOR = @idOR  and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta), New SqlParameter("@idOR", claveOR)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal clavePregunta As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM OpcionesPregunta WHERE idPregunta = @idPregunta and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function


        Public Overloads Overrides Function GetDS() As DataSet
            Dim queryString As String = "SELECT * FROM OpcionesPregunta and eliminado=0"
            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(ByVal clavePregunta As Integer) As Integer
            Dim queryString As String = "SELECT count(idOP) as num FROM OpcionesPregunta WHERE idPregunta = @idPregunta and eliminado=0"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Integer = 0

            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Overrides Function EnUso() As Boolean
            Return Me.Count(Me.idPregunta) > 1
        End Function

        '++++++++++DEPRECATED: Utilizar EnUso() +++++++++++
        Public Function SePuedeBorrarOP() As Boolean
            If Me.Count(Me.idPregunta) > 1 Then
                Return True
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace
