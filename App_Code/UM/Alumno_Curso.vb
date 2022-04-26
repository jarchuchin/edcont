Imports System.Data.OracleClient
Imports System.Data

Namespace UM

    Public Class Alumno_Curso
        Inherits DBObjectOracle

        Sub New()

        End Sub

        Public Overrides ReadOnly Property existe() As Boolean
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property


        Public Overrides Function Add() As Integer

        End Function
        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function
        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function



        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal actualYear As Integer) As OracleDataReader
            Dim querystring As String = "select alumno_curso.* from " & sch & ".alumno_curso, " & sch & ".carga where alumno_curso.carga_id = carga.carga_id and alumno_curso.tipocal_id = 'I' and extract(year from carga.f_final) = " & actualYear

            Return Me.ExecuteReader(querystring, Nothing)

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function


        Public Function ColocarCursosAlumnos() As Integer

            Dim dr As OracleClient.OracleDataReader = Me.GetDR(Date.Now.Year)
            Dim i As Integer = 0
            Dim myca As UM.CursosAlumno
            Do While dr.Read

                myca = New UM.CursosAlumno
                myca.idAlumno = 0
                myca.claveCurso = dr("CURSO_CARGA_ID")
                myca.claveAlumno = dr("CODIGO_PERSONAL")
                myca.grabado = 0
                myca.Add()

                If myca.idCursoAlumno > 0 Then
                    i += 1
                End If

            Loop

            dr.Close()

            Return i

        End Function



    End Class

End Namespace
