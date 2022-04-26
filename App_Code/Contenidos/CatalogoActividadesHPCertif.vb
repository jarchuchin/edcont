Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class CatalogoActividadesHPCertif
        Inherits DBObject


        Private idCatalogoActividadHPCertif As Integer
        Private idCatalogoActividadHP As Integer
        Public Descripcion As String
        Public Valor As Integer
        Public Eliminado As Boolean = False


        Private varExiste As Boolean = False





        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idCatalogoActividadHPCertif
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.CatalogoActividadesHPCertif
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "select * from CatalogoActividadesHPCertif where idCatalogoActividadHPCertif=@idCatalogoActividadHPCertif"

            Dim parameters As SqlParameter() = {New SqlParameter("@idCatalogoActividadHPCertif", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idCatalogoActividadHPCertif = CType(dr("idCatalogoActividadHPCertif"), Integer)
                Me.idCatalogoActividadHP = CType(dr("idCatalogoActividadHP"), String)
                Me.Descripcion = CType(dr("Descripcion"), String)
                Me.Valor = CType(dr("Valor"), Integer)

                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "insert into CatalogoActividadesHPCertif (idCatalogoActividadHP, Descripcion, Valor, Eliminado) Values (@idCatalogoActividadHP, @Descripcion, @Valor, @Eliminado)"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idCatalogoActividadHP", Me.idCatalogoActividadHP),
                  New SqlParameter("@Descripcion", Me.Descripcion),
                  New SqlParameter("@Valor", Me.Valor),
                  New SqlParameter("@Eliminado", Me.Eliminado)}

            Me.idCatalogoActividadHPCertif = Me.ExecuteNonQuery(queryString, parametros, True)



            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE    CatalogoActividadesHPCertif SET idCatalogoActividadHP=@idCatalogoActividadHP, Descripcion=@Descripcion, Valor=@Valor, Eliminado=@Eliminado  WHERE [idCatalogoActividadHPCertif] = @idCatalogoActividadHPCertif"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idCatalogoActividadHP", Me.idCatalogoActividadHP),
                  New SqlParameter("@Descripcion", Me.Descripcion),
                  New SqlParameter("@Valor", Me.Valor),
                  New SqlParameter("@Eliminado", Me.Eliminado),
                   New SqlParameter("@idCatalogoActividadHPCertif", Me.idCatalogoActividadHPCertif)}


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
            Dim sql As String = "select * from CatalogoActividadesHPCertif order by Nombre"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Overloads Function GetDS(claveCatalogoActividadHP As Integer) As System.Data.DataSet
            Dim sql As String = "select * from CatalogoActividadesHPCertif where idCatalogoActividadHP=@idCatalogoActividadHP order by Nombre"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function





    End Class
End Namespace

