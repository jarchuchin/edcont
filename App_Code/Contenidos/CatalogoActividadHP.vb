

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
    Public NotInheritable Class CatalogoActividadHP
        Inherits DBObject


        Private idCatalogoActividadHP As Integer
        Public TipoHP As String
        Public TipoC As String
        Public Nombre As String
        Public TiempoRealizacion As Integer ' tiempo en minutos
        Public FileFormato As String
        Public FileEjemplo As String
        Public Eliminado As Boolean = False


        Private varExiste As Boolean = False





        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idCatalogoActividadHP
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.CatalogoActividadesHP
            End Get
        End Property



        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "select * from CatalogoActividadesHP where idCatalogoActividadHP=@idCatalogoActividadHP"

            Dim parameters As SqlParameter() = {New SqlParameter("@idCatalogoActividadHP", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idCatalogoActividadHP = CType(dr("idCatalogoActividadHP"), Integer)
                Me.TipoHP = CType(dr("TipoHP"), String)
                Me.TipoC = CType(dr("TipoC"), String)
                Me.Nombre = CType(dr("Nombre"), String)
                Me.TiempoRealizacion = CType(dr("TiempoRealizacion"), Integer)
                Me.FileFormato = CType(dr("FileFormato"), String)
                Me.FileEjemplo = CType(dr("FileEjemplo"), String)
                Me.Eliminado = CType(dr("Eliminado"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer

            Dim queryString As String = "insert into CatalogoActividadesHP (TipoHP, TipoC, Nombre, TiempoRealizacion, FileFormato, FileEjemplo, Eliminado) Values (@TipoHP, @TipoC, @Nombre, @TiempoRealizacion, @FileFormato, @FileEjemplo, @Eliminado)"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@TipoHP", Me.TipoHP),
                 New SqlParameter("@TipoC", Me.TipoC),
                  New SqlParameter("@Nombre", Me.Nombre),
                  New SqlParameter("@TiempoRealizacion", Me.TiempoRealizacion),
                  New SqlParameter("@FileFormato", Me.FileFormato),
                  New SqlParameter("@FileEjemplo", Me.FileEjemplo),
                  New SqlParameter("@Eliminado", Me.Eliminado)}

            Me.idCatalogoActividadHP = Me.ExecuteNonQuery(queryString, parametros, True)



            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE    CatalogoActividadesHP SET TipoHP=@TipoHP, TipoC=@TipoC, Nombre=@Nombre, TiempoRealizacion=@TiempoRealizacion, FileFormato=@FileFormato, FileEjemplo=@FileEjemplo, Eliminado=@Eliminado  WHERE ([CatalogoActividadesHP].[idCatalogoActividadHP] = @idCatalogoActividadHP)"

            Dim parametros As SqlParameter() = {
                  New SqlParameter("@TipoHP", Me.TipoHP),
                 New SqlParameter("@TipoC", Me.TipoC),
                  New SqlParameter("@TiempoRealizacion", Me.TiempoRealizacion),
                  New SqlParameter("@FileFormato", Me.FileFormato),
                  New SqlParameter("@FileEjemplo", Me.FileEjemplo),
                  New SqlParameter("@Eliminado", Me.Eliminado),
                              New SqlParameter("@idCatalogoActividadHP", Me.idCatalogoActividadHP)}


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

        Public Overloads Function GetDSTipoC(claveTipoC As String) As System.Data.DataSet
            Dim sql As String = "select * from CatalogoActividadesHP where TipoC=@TipoC  order by Nombre"
            Dim parametros As SqlParameter() = {
                  New SqlParameter("@TipoC", claveTipoC)}

            Return Me.ExecuteDataSet(sql, parametros)
        End Function


        Public Overloads Function GetDSTipoHP(claveTipoHP As String) As System.Data.DataSet
            Dim sql As String = "select * from CatalogoActividadesHP where TipoHP=@TipoHP  order by Nombre"
            Dim parametros As SqlParameter() = {
                  New SqlParameter("@TipoHP", claveTipoHP)}

            Return Me.ExecuteDataSet(sql, parametros)
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function





    End Class
End Namespace

