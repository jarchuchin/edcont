Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Namespace UM

    Public Class CursosAlumno
        Inherits DBObjectLight



        Public idCursoAlumno As Integer
        Public idAlumno As Integer
        Public claveAlumno As String
        Public claveCurso As String
        Public grabado As Boolean
        Public Existe As Boolean = False


        '***********************************************************
        'Constructores
        '***********************************************************

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
  

            Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE idCursoAlumno=@idCursoAlumno"
            Dim parametros As SqlParameter() = {New SqlParameter("@idCursoAlumno", clavePrincipal)}
            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

            If dr.Read Then
                Me.idCursoAlumno = CInt(dr("idCursoAlumno"))
                Me.idAlumno = CInt(dr("idAlumno"))
                Me.claveAlumno = CType(dr("claveAlumno"), String)
                Me.claveCurso = CType(dr("claveCurso"), String)
                Me.grabado = CType(dr("grabado"), Boolean)
                Existe = True
            End If
            dr.Close()


        End Sub

        Sub New(ByVal claveAlumno As String, ByVal clavecursoCargaid As String)


            Dim queryString As String = "SELECT * FROM CursosAlumnos WHERE claveAlumno=@claveAlumno and claveCurso=@claveCurso"

            Dim parametros As SqlParameter() = {New SqlParameter("@claveAlumno", claveAlumno), New SqlParameter("@claveCurso", clavecursoCargaid)}
            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)

            If dr.Read Then
                Me.idCursoAlumno = CInt(dr("idCursoAlumno"))
                Me.idAlumno = CInt(dr("idAlumno"))
                Me.claveAlumno = CType(dr("claveAlumno"), String)
                Me.claveCurso = CType(dr("claveCurso"), String)
                Me.grabado = CType(dr("grabado"), Boolean)
                Existe = True
            End If
            dr.Close()


        End Sub
        


        Public Function Add() As Integer

            Dim queryString As String = "INSERT INTO [CursosAlumnos] (idAlumno, claveAlumno, claveCurso, grabado) VALUES " & _
            " (@idAlumno, @claveAlumno, @claveCurso, @grabado) "
            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idAlumno", Me.idAlumno), _
             New SqlParameter("@claveAlumno", Me.claveAlumno), _
             New SqlParameter("@claveCurso", Me.claveCurso), _
             New SqlParameter("@grabado", Me.grabado)}

            Dim myca As CursosAlumno = New CursosAlumno(Me.claveAlumno, Me.claveCurso)
            If Not myca.Existe Then
                Me.idCursoAlumno = Me.ExecuteNonQuery(queryString, parametros, True)
            End If


        End Function

        Public Function Update() As Integer

           

            Dim queryString As String = "UPDATE [CursosAlumnos] SET [grabado]=@grabado WHERE ([CursosAlumnos].[idCursoAlumno" & _
    "] = @idCursoAlumno)"
            Dim parametros As SqlParameter() = { _
          New SqlParameter("@idCursoAlumno", Me.idCursoAlumno), _
          New SqlParameter("@grabado", Me.grabado)}
            Return Me.ExecuteNonQuery(queryString, parametros)

        End Function

      

        Public Function GetDR(ByVal claveAlumno As String) As Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos] WHERE ([CursosAlumnos].[claveAlumno] = @claveAlumno)"
            Dim parametros As SqlParameter() = { _
        New SqlParameter("@claveAlumno", claveAlumno)}

            Return Me.ExecuteReader(queryString, parametros)

        End Function


        Public Function GetDS(ByVal claveAlumno As String) As DataSet
            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos] WHERE ([CursosAlumnos].[claveAlumno] = @claveAlumno)"
            Dim parametros As SqlParameter() = { _
        New SqlParameter("@claveAlumno", claveAlumno)}
            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GetDR(ByVal claveAlumno As String, ByVal claveGrabado As Boolean) As Data.SqlClient.SqlDataReader

            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos] WHERE ([CursosAlumnos].[claveAlumno] = @claveAlumno) and ([CursosAlumnos].grabado = @Grabado)"
            Dim parametros As SqlParameter() = { _
                New SqlParameter("@claveAlumno", claveAlumno), _
                New SqlParameter("@grabado", claveGrabado)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Function GetDS(ByVal claveAlumno As String, ByVal claveGrabado As Boolean) As DataSet
            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos] WHERE ([CursosAlumnos].[claveAlumno] = @claveAlumno) and ([CursosAlumnos].grabado = @Grabado)"
            Dim parametros As SqlParameter() = { _
                New SqlParameter("@claveAlumno", claveAlumno), _
                New SqlParameter("@grabado", claveGrabado)}

            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


        Public Function GetDR(ByVal claveGrabado As Boolean) As Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos]  where grabado=@Grabado " ' WHERE  ([CursosAlumnos].claveAlumno = '1090013')"
            Dim parametros As SqlParameter() = { _
           New SqlParameter("@Grabado", claveGrabado)}

            Return Me.ExecuteReader(queryString, parametros)

            ' Return Me.ExecuteReader(queryString, Nothing)

        End Function


        Public Function GetDS(ByVal claveGrabado As Boolean) As DataSet
            Dim queryString As String = "SELECT [CursosAlumnos].* FROM [CursosAlumnos] WHERE  ([CursosAlumnos].grabado = @Grabado)"
            Dim parametros As SqlParameter() = { _
           New SqlParameter("@Grabado", claveGrabado)}

            Return Me.ExecuteDataSet(queryString, parametros)

        End Function


      

    End Class

End Namespace
