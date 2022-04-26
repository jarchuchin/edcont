


Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace Know

    Public Class BitacoraContenido
        Inherits DBObject

        Public idBitacoraContenido As Integer
        Public idProc As Integer
        Public Procedencia As String
        Public idSalonVirtual As Integer

        Public idUserProfile As Integer

        Public ip As String
        Public Browser As String
        Public Fecha As DateTime



        Public varexiste As Boolean = False
        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idBitacoraContenido
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varexiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.BitacoraContenido
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from BitacoraContenidos where idBitacoraContenido=@idBitacoraContenido"

            Dim param As SqlParameter() = {New SqlParameter("@idBitacoraContenido", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idBitacoraContenido = CInt(dr("idBitacoraContenido"))
                Me.idProc = CInt(dr("idProc"))
                Me.Procedencia = dr("Procedencia")
                Me.idSalonVirtual = CInt(dr("idSalonVirtual"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.ip = dr("ip")
                Me.Browser = dr("Browser")

                Me.Fecha = CType(dr("Fecha"), DateTime)



                Me.varexiste = True
            End If
            dr.Close()
        End Sub




        Public Overrides Function Add() As Integer
            Dim querystring As String = "INSERT INTO BitacoraContenidos (idProc, Procedencia, idSalonVirtual, idUserProfile, ip, Browser,  Fecha) VALUES (@idProc, @Procedencia, @idSalonVirtual, @idUserProfile, @ip, @Browser,  @Fecha)"

            Dim parameters As SqlParameter() = {
            New SqlParameter("@idProc", Me.idProc),
            New SqlParameter("@Procedencia", Me.Procedencia),
            New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
            New SqlParameter("@idUserProfile", Me.idUserProfile),
            New SqlParameter("@ip", Me.ip),
            New SqlParameter("@Browser", Me.Browser),
            New SqlParameter("@Fecha", Fecha)}
            Me.varexiste = True

            Me.idBitacoraContenido = Me.ExecuteNonQuery(querystring, parameters, True)
            Return 1

        End Function

        Public Overrides Function Update() As Integer
            Dim queryString As String = "UPDATE BitacoraContenidos SET id WHERE idBitacora= @idBitacora"

            Dim parameters As SqlParameter() = {
            New SqlParameter("@idProc", Me.idProc),
            New SqlParameter("@Procedencia", Me.Procedencia),
            New SqlParameter("@idSalonVirtual", Me.idSalonVirtual),
            New SqlParameter("@idUserProfile", Me.idUserProfile),
            New SqlParameter("@ip", Me.ip),
            New SqlParameter("@Browser", Me.Browser),
            New SqlParameter("@Fecha", Fecha),
            New SqlParameter("@idBitacoraContenido", idBitacoraContenido)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader

        End Function
        Public Overloads Overrides Function Count() As Integer


        End Function


        Public Overrides Function EnUso() As Boolean
            Return True
        End Function


        Public Overrides Function Remove() As Integer
            Dim queryString As String = "delete BitacoraContenidos  WHERE idBitacoraContenido= @idBitacoraContenido"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idBitacoraContenido", Me.idBitacoraContenido)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet

        End Function



        Public Overloads Function GetDS(claveidproc As Integer, claveprocedencia As String, claveidSalonVirtual As Integer) As DataSet

            Dim sql As String = "select up.apellidos + ' ' + up.nombre as Nombre, count(b.idBitacoraContenido) as Accesos  from BitacoraContenidos b left outer join UserProfiles up on up.idUserProfile = b.idUserProfile where   b.idproc=@idProc  and b.Procedencia=@Procedencia and b.idSalonVirtual=@idSalonVirtual and b.idUserProfile>0 group by b.idUserProfile, up.nombre, up.apellidos order by up.apellidos, up.nombre"

            Dim params As SqlParameter() = {New SqlParameter("@idProc", claveidproc), New SqlParameter("@Procedencia", claveprocedencia), New SqlParameter("@idSalonVirtual", claveidSalonVirtual)}

            Return Me.ExecuteDataSet(sql, params)
        End Function

        Public Function GetDSDatosGrafica(claveidproc As Integer, claveprocedencia As String, claveidSalonVirtual As Integer) As DataSet
            Dim sql As String = "select datepart(Year, b.Fecha) as  ano, datepart(Month, b.Fecha) as  Mes,   count(b.idBitacoraContenido) as Total  from BitacoraContenidos b where b.idproc=@idProc  and b.Procedencia=@Procedencia and b.idSalonVirtual=@idSalonVirtual and b.idUserProfile>0 group by datepart(Year, b.Fecha), datepart(Month, b.Fecha) order by ano, mes  "

            Dim params As SqlParameter() = {New SqlParameter("@idProc", claveidproc), New SqlParameter("@Procedencia", claveprocedencia), New SqlParameter("@idSalonVirtual", claveidSalonVirtual)}

            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetTablaGrafica(claveidproc As Integer, claveprocedencia As String, claveidSalonVirtual As Integer) As DataView

            Dim ds As DataSet = Me.GetDSDatosGrafica(claveidproc, claveprocedencia, claveidSalonVirtual)

            Dim mysv = New Know.SalonVirtual(claveidSalonVirtual, False)
            Dim dt As New DataTable

            dt.Columns.Add(New DataColumn("Ano", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Mes", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Total", GetType(Integer)))


            Dim dr As DataRow
            Dim dv As DataView


            Dim fecha As Date = mysv.fechaInicio
            Do While fecha <= mysv.fechaFin

                dr = dt.NewRow()
                dr(0) = fecha.Year
                dr(1) = fecha.Month

                dv = New DataView(ds.Tables(0), "Ano = " & fecha.Year & " AND Mes = " & fecha.Month, "", DataViewRowState.CurrentRows)
                dv.RowFilter = "Ano = " & fecha.Year & " AND Mes = " & fecha.Month

                If dv.Count > 0 Then
                    dr(2) = CInt(dv.Item(0).Item("Total"))
                Else
                    dr(2) = 0
                End If


                dt.Rows.Add(dr)

                fecha = fecha.AddMonths(1)
            Loop

            Return New DataView(dt)


        End Function





    End Class
End Namespace
