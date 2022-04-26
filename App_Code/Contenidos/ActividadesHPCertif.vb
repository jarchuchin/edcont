



Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class ActividadesHPCertif
        Inherits DBObject


        Private idActividadHPCertif As Integer
        Public idActividad As Integer
        Public idCatalogoActividadHPCertif As Integer
        Public Cumple As Boolean
        Public Fecha As DateTime
        Public Certificador As Integer
        Public Observacion As String

        Public Eliminado As Boolean = False


        Private varExiste As Boolean = False



        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idActividadHPCertif
            End Get
        End Property



        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.ActividadesHPCertif
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "select * from ActividadesHPCertif where idActividdesHPCertif=@idActividdesHPCertif"

            Dim parameters As SqlParameter() = {New SqlParameter("@idActividdesHPCertif", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idActividadHPCertif = CType(dr("idActividadHPCertif"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idCatalogoActividadHPCertif = CType(dr("idCatalogoActividadHPCertif"), Integer)
                Me.Cumple = CType(dr("Cumple"), Boolean)
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.Certificador = CType(dr("Certificador"), Integer)
                Me.Observacion = CType(dr("Observacion"), String)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "insert into ActividadesHPCertif (idActividad, idCatalogoActividadHPCertif, Cumple, Fecha, Certificador, Observacion, Eliminado) Values (@idActividad, @idCatalogoActividadHPCertif, @Cumple, @Fecha, @Certificador, @Observacion, @Eliminado)"

            Dim parametros As SqlParameter() = {
                  New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idCatalogoActividadHPCertif", Me.idCatalogoActividadHPCertif),
                  New SqlParameter("@Cumple", Me.Cumple),
                      New SqlParameter("@Fecha", Me.Fecha),
                  New SqlParameter("@Certificador", Me.Certificador),
                  New SqlParameter("@Observacion", Me.Observacion),
                  New SqlParameter("@Eliminado", Me.Eliminado)}

            Me.idActividadHPCertif = Me.ExecuteNonQuery(queryString, parametros, True)



            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE    ActividadesHPCertif SET idActividad=@idActividad, idCatalogoActividadHPCertif=@idCatalogoActividadHPCertif, Cumple=@Cumple, Fecha=@Fecha, Certificador=@Certificador, Observacion=@Observacion, Eliminado=@Eliminado  WHERE idActividadHPCertif = @idActividadHPCertif"

            Dim parametros As SqlParameter() = {
                  New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idCatalogoActividadHPCertif", Me.idCatalogoActividadHPCertif),
                  New SqlParameter("@Cumple", Me.Cumple),
                      New SqlParameter("@Fecha", Me.Fecha),
                  New SqlParameter("@Certificador", Me.Certificador),
                  New SqlParameter("@Observacion", Me.Observacion),
                  New SqlParameter("@Eliminado", Me.Eliminado),
                              New SqlParameter("@idActividadHPCertif", Me.idActividadHPCertif)}


            Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

        Public Overrides Function Remove() As Integer
            Me.Eliminado = True
            Return Me.Update()

        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function





        Public Overrides Function GetDS() As System.Data.DataSet
            Dim sql As String = "select * from CatalogoActividadesHP order by Nombre"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Overloads Function GetDS(claveidActividad As Integer) As System.Data.DataSet
            Dim sql As String = "select ac.* from ActividaesHPCertif ac left outer join CatalogoActividadesHPCertif where ac.idActividad=@idActividad"

            Dim params As SqlParameter() = {New SqlParameter("@idActividad", Me.idActividad)}


            Return Me.ExecuteDataSet(sql, params)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function





    End Class
End Namespace


