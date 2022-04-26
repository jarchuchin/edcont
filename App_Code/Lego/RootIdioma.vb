Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Lego
    Public Class RootIdioma
        Inherits DBObject

        Private idRootIdioma As Integer
        Public idRoot As Integer
        Public idIdioma As Integer

        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property existe As Boolean
            Get
                Return Me.varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property id As Integer
            Get
                Return Me.idRootIdioma
            End Get
        End Property

        Public Overrides ReadOnly Property tipo As tipoObjeto
            Get
                Return tipoObjeto.RootIdioma
            End Get
        End Property


        Sub New()

        End Sub


        Sub New(clavePrincipal As Integer)

            Dim sql As String = "select * from RootsIdiomas where idRootIdioma = @idRootIdioma"
            Dim param As SqlParameter() = {New SqlParameter("@idRoot", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)
            If dr.Read Then
                Me.idRootIdioma = CType(dr("idRootIdioma"), Integer)
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.idIdioma = CType(dr("idIdioma"), Integer)
                Me.varExiste = True
            End If
            dr.Close()

        End Sub


        Sub New(claveIdioma As Integer, claveRoot As Integer)

            Dim sql As String = "select * from RootsIdiomas where idIdioma = @idIdioma and idRoot=@idRoot"
            Dim param As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idRoot", claveRoot)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)
            If dr.Read Then
                Me.idRootIdioma = CType(dr("idRootIdioma"), Integer)
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.idIdioma = CType(dr("idIdioma"), Integer)
                Me.varExiste = True

            End If
            dr.Close()


        End Sub

        Public Overrides Function Add() As Integer
            Dim queryString As String = "INSERT INTO [RootsIdiomas] (idRoot, idIdioma) VALUES (@idRoot, @idIdioma)"

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRoot", Me.idRoot),
                  New SqlParameter("@idIdioma", Me.idIdioma)}

            Me.idRootIdioma = Me.ExecuteNonQuery(queryString, parametros, True)
        End Function

        Public Overrides Function Count() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overrides Function EnUso() As Boolean
            Throw New NotImplementedException()
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Throw New NotImplementedException()
        End Function


        Public Overloads Function GetDR(claveRoot As Integer) As SqlDataReader
            Dim sql As String = "select ri.*, i.nombre as IdiomaNombre, i.CultureID, r.Idioma from rootsidiomas ri left outer join idiomas i on i.idIdioma=ri.idIdioma left outer join roots r on r.idRoot=ri.idRoot where ri.idRoot=@idRoot and ri.idIdioma<>r.idIdioma"

            Dim parametros As SqlParameter() = {
               New SqlParameter("@idRoot", claveRoot)}

            Return Me.ExecuteReader(sql, parametros)
        End Function

        Public Overrides Function GetDS() As DataSet
            Throw New NotImplementedException()
        End Function

        Public Overrides Function Remove() As Integer
            Dim sql As String = "delete rootsidiomas where idRootIdioma=@idRootIdioma"
            Dim parametros As SqlParameter() = {
                New SqlParameter("@idRootIdioma", Me.idRootIdioma)}

            Return Me.ExecuteNonQuery(sql, parametros)


        End Function

        Public Overrides Function Update() As Integer
            Dim queryString As String = "UPDATE [RootsIdiomas] SET  [idRoot]=@idRoot, [idIdioma]=@idIdioma WHERE (idRootIdioma = @idRootIdioma) "

            Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRoot", Me.idRoot),
                  New SqlParameter("@idIdioma", Me.idIdioma),
                  New SqlParameter("@idRootIdioma", Me.idRootIdioma)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function
    End Class
End Namespace