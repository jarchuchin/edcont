Imports System.Data.OracleClient
Imports System
Imports System.Diagnostics


Namespace UM

    Public Class Saldos_Estudiantes
        Inherits DBObjectOracleFinanciero

        Public matricula As String
        Public nombre As String
        Public saldo As Decimal
        Public importe_contratos As Decimal
        Public diferencia As Decimal
        Public saldoglobal As Decimal


        Public existedato As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavematricula As String)
            Try
                Dim sql As String = "SELECT * FROM " & Me.sch & ".SALDOS_ALUMNOS WHERE MATRICULA=:MATRICULA  "
                Dim param As OracleParameter() = {New OracleParameter("MATRICULA", clavematricula)}
                Dim dr As Data.OracleClient.OracleDataReader = Me.ExecuteReader(sql, param)
                If dr.Read Then

                    If Not Convert.IsDBNull(dr("MATRICULA")) Then
                        Me.matricula = dr("MATRICULA")
                    Else
                        Me.matricula = ""
                    End If

                    'If Not Convert.IsDBNull(dr("NOMBRE")) Then
                    '    Me.nombre = dr("NOMBRE")
                    'Else
                    '    Me.nombre = ""
                    'End If

                    If Not Convert.IsDBNull(dr("SALDO")) Then
                        Me.saldo = CDec(dr("SALDO"))
                    Else
                        Me.saldo = ""
                    End If


                    If Not Convert.IsDBNull(dr("IMPORTE_CONTRATOS")) Then
                        Me.importe_contratos = CDec(dr("IMPORTE_CONTRATOS"))
                    Else
                        Me.importe_contratos = ""
                    End If

                    If Not Convert.IsDBNull(dr("DIFERENCIA")) Then
                        Me.diferencia = CDec(dr("DIFERENCIA"))
                    Else
                        Me.diferencia = ""
                    End If


                    If Not Convert.IsDBNull(dr("SALDOGLOBAL")) Then
                        Me.saldoglobal = CDec(dr("SALDOGLOBAL"))
                    Else
                        Me.saldoglobal = 0
                    End If

                    existedato = True

                End If
                dr.Close()
            Catch ex As Exception



                Me.matricula = ""
                Me.nombre = ""
                Me.saldo = 0
                Me.importe_contratos = 0
                Me.diferencia = 0
                Me.saldoglobal = 0

            End Try





        End Sub


        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function

        Public Overrides ReadOnly Property existe() As Boolean
            Get

            End Get
        End Property

        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet

        End Function

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property

        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function
    End Class

End Namespace

