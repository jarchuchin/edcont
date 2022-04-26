Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace MasUsuarios
    Public NotInheritable Class Permiso
        Inherits DBObject


        Private idPermiso As Integer
        Public permisoA As tipoObjeto
        Public recurso As tipoObjeto
        Public PRoots As Boolean = False
        Public PPermisosRoots As Boolean = False
        Public PCategorias As Boolean = False
        Public PRespuestas As Boolean = False
        Public PEvaluacion As Boolean = False
        Public PSalonVirtual As Boolean = False
        Public PContenidos As Boolean = False
        Public PInterfaceGrafica As Boolean = False
        Public PEstadisticas As Boolean = False
        Public PAdministracion As Boolean = False
        Public idPermisoA As Integer
        Public varPermisoA As String
        Public idRecurso As Integer
        Public varRecurso As String
        Public owner As Boolean = False

        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idPermiso
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Permiso
            End Get
        End Property


        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Permisos WHERE idPermiso = @idPermiso"

            Dim parameters As SqlParameter() = {New SqlParameter("@idPermiso", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idPermiso = clavePrincipal
                Me.idPermisoA = CType(dr("idPermisoA"), Integer)
                Me.varPermisoA = CType(dr("PermisoA"), String)
                Me.idRecurso = CType(dr("idrecurso"), Integer)
                Me.varRecurso = CType(dr("recurso"), String)
                Me.PRoots = CType(dr("PRoots"), Boolean)
                Me.PPermisosRoots = CType(dr("PPermisosRoots"), Boolean)
                Me.PCategorias = CType(dr("PCategorias"), Boolean)
                Me.PRespuestas = CType(dr("PRespuestas"), Boolean)
                Me.PEvaluacion = CType(dr("PEvaluacion"), Boolean)
                Me.PSalonVirtual = CType(dr("PSalonVirtual"), Boolean)
                Me.PContenidos = CType(dr("PContenidos"), Boolean)
                Me.PInterfaceGrafica = CType(dr("PInterfaceGrafica"), Boolean)
                Me.PEstadisticas = CType(dr("PEstadisticas"), Boolean)
                Me.PAdministracion = CType(dr("PAdministracion"), Boolean)
                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal objPermiso As DBObject, ByVal objRecurso As DBObject)
            Dim queryString As String = "SELECT * FROM Permisos WHERE idPermisoA = @idPermisoA " _
             & "AND PermisoA = @PermisoA AND idRecurso = @idRecurso  AND Recurso = @Recurso"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idPermisoA", objPermiso.id),
             New SqlParameter("@PermisoA", objPermiso.tipo.ToString),
             New SqlParameter("@idRecurso", objRecurso.id),
             New SqlParameter("@Recurso", objRecurso.tipo.ToString)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idPermiso = CType(dr("idPermiso"), Integer)
                Me.idPermisoA = CType(dr("idPermisoA"), Integer)
                Me.varPermisoA = CType(dr("PermisoA"), String)
                Me.idRecurso = CType(dr("idrecurso"), Integer)
                Me.varRecurso = CType(dr("recurso"), String)
                Me.PRoots = CType(dr("PRoots"), Boolean)
                Me.PPermisosRoots = CType(dr("PPermisosRoots"), Boolean)
                Me.PCategorias = CType(dr("PCategorias"), Boolean)
                Me.PRespuestas = CType(dr("PRespuestas"), Boolean)
                Me.PEvaluacion = CType(dr("PEvaluacion"), Boolean)
                Me.PSalonVirtual = CType(dr("PSalonVirtual"), Boolean)
                Me.PContenidos = CType(dr("PContenidos"), Boolean)
                Me.PInterfaceGrafica = CType(dr("PInterfaceGrafica"), Boolean)
                Me.PEstadisticas = CType(dr("PEstadisticas"), Boolean)
                Me.PAdministracion = CType(dr("PAdministracion"), Boolean)
                Me.varExiste = True
            Else
                Me.varExiste = Me.GenerarActivacion(objPermiso, objRecurso)
            End If
            dr.Close()
        End Sub

        Sub New(ByVal objPermiso As DBObject, ByVal objRecurso As DBObject, ByVal claveentrada As Boolean)
            Dim queryString As String = "SELECT * FROM Permisos WHERE idPermisoA = @idPermisoA " _
             & "AND PermisoA = @PermisoA AND idRecurso = @idRecurso  AND Recurso = @Recurso"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idPermisoA", objPermiso.id),
             New SqlParameter("@PermisoA", objPermiso.tipo.ToString),
             New SqlParameter("@idRecurso", objRecurso.id),
             New SqlParameter("@Recurso", objRecurso.tipo.ToString)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idPermiso = CType(dr("idPermiso"), Integer)
                Me.idPermisoA = CType(dr("idPermisoA"), Integer)
                Me.varPermisoA = CType(dr("PermisoA"), String)
                Me.idRecurso = CType(dr("idrecurso"), Integer)
                Me.varRecurso = CType(dr("recurso"), String)
                Me.PRoots = CType(dr("PRoots"), Boolean)
                Me.PPermisosRoots = CType(dr("PPermisosRoots"), Boolean)
                Me.PCategorias = CType(dr("PCategorias"), Boolean)
                Me.PRespuestas = CType(dr("PRespuestas"), Boolean)
                Me.PEvaluacion = CType(dr("PEvaluacion"), Boolean)
                Me.PSalonVirtual = CType(dr("PSalonVirtual"), Boolean)
                Me.PContenidos = CType(dr("PContenidos"), Boolean)
                Me.PInterfaceGrafica = CType(dr("PInterfaceGrafica"), Boolean)
                Me.PEstadisticas = CType(dr("PEstadisticas"), Boolean)
                Me.PAdministracion = CType(dr("PAdministracion"), Boolean)
                Me.varExiste = True

            End If
            dr.Close()
        End Sub



        Public Overrides Function Add() As Integer
            'Try
            Dim queryString As String = "INSERT INTO [Permisos] ([PRoots], [PPermisosRoots], [PCategorias], [PRespuestas], [PEvaluacion], " &
             "[PSalonVirtual], [PContenidos], [PInterfaceGrafica], [PEstadisticas], [PAdministracion], [idPermisoA], [PermisoA], [idRecurso], " &
             "[Recurso]) VALUES (@PRoots, @PPermisosRoots, @PCategorias, @PRespuestas, @PEvaluacion, @PSalonVirtual, @PContenidos, " &
             "@PInterfaceGrafica, @PEstadisticas, @PAdministracion, @idPermisoA, @PermisoA, @idRecurso, @Recurso)"

            Dim parametros As SqlParameter() = {
              New SqlParameter("@PRoots", Me.PRoots),
              New SqlParameter("@PPermisosRoots", Me.PPermisosRoots),
              New SqlParameter("@PCategorias", Me.PCategorias),
              New SqlParameter("@PRespuestas", Me.PRespuestas),
              New SqlParameter("@PEvaluacion", Me.PEvaluacion),
              New SqlParameter("@PSalonVirtual", Me.PSalonVirtual),
              New SqlParameter("@PContenidos", Me.PContenidos),
              New SqlParameter("@PInterfaceGrafica", Me.PInterfaceGrafica),
              New SqlParameter("@PEstadisticas", Me.PEstadisticas),
              New SqlParameter("@PAdministracion", Me.PAdministracion),
              New SqlParameter("@idPermisoA", Me.idPermisoA),
              New SqlParameter("@PermisoA", Me.permisoA.ToString),
              New SqlParameter("@idRecurso", Me.idRecurso),
              New SqlParameter("@Recurso", Me.recurso.ToString)}




            Me.idPermiso = Me.ExecuteNonQuery(queryString, parametros, True)

            'Catch ex As Exception
            '             Dim m As String = ex.Message
            '         End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer

            Dim queryString As String = "UPDATE [Permisos] SET [PRoots]=@PRoots, [PPermisosRoots]=@PPermisosRoots, " &
                "[PCategorias]=@PCategorias, [PRespuestas]=@PRespuestas, [PEvaluacion]=@PEvaluacion, [PSalonVirtual]=@PSalonVirtual, " &
                "[PContenidos]=@PContenidos, [PInterfaceGrafica]=@PInterfaceGrafica, [PEstadisticas]=@PEstadisticas, " &
                "[PAdministracion]=@PAdministracion, [idPermisoA]=@idPermisoA, [PermisoA]=@PermisoA, [idRecurso]=@idRecurso, " &
                "[Recurso]=@Recurso WHERE idPermiso = @idPermiso"

                Dim parametros As SqlParameter() = {
                  New SqlParameter("@idPermiso", Me.idPermiso),
                  New SqlParameter("@PRoots", Me.PRoots),
                  New SqlParameter("@PPermisosRoots", Me.PPermisosRoots),
                  New SqlParameter("@PCategorias", Me.PCategorias),
                  New SqlParameter("@PRespuestas", Me.PRespuestas),
                  New SqlParameter("@PEvaluacion", Me.PEvaluacion),
                  New SqlParameter("@PSalonVirtual", Me.PSalonVirtual),
                  New SqlParameter("@PContenidos", Me.PContenidos),
                  New SqlParameter("@PInterfaceGrafica", Me.PInterfaceGrafica),
                  New SqlParameter("@PEstadisticas", Me.PEstadisticas),
                  New SqlParameter("@PAdministracion", Me.PAdministracion),
                  New SqlParameter("@idPermisoA", Me.idPermisoA),
                  New SqlParameter("@PermisoA", Me.permisoA.ToString),
                  New SqlParameter("@idRecurso", Me.idRecurso),
                  New SqlParameter("@Recurso", Me.recurso.ToString)}

                Return Me.ExecuteNonQuery(queryString, parametros)


        End Function

        Public Overloads Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Permisos WHERE idPermiso = @idPermiso"

            Dim parametros As SqlParameter() = {New SqlParameter("@idPermiso", Me.idPermiso)}

            Dim rowsAffected As Integer

            Dim ejecutarBorrar As Boolean = True
            Select Case Me.varRecurso
                Case "Root"
                    Dim myroot As New Lego.Root(Me.idRecurso)
                    'If myroot.idUserProfile = Me.idPermisoA Then
                    '	ejecutarBorrar = False
                    'End If
                Case "SalonVirtual"
                    Dim mysalon As New Know.SalonVirtual(Me.idRecurso, False)
                    'If mysalon.idUserProfile = Me.idPermisoA Then
                    '	ejecutarBorrar = False
                    'End If

            End Select

            If ejecutarBorrar Then
                rowsAffected = Me.ExecuteNonQuery(queryString, parametros)
            End If

            Return rowsAffected
        End Function

        Public Overloads Function Remove(ByVal objRecurso As DBObject) As Integer
            Dim queryString As String = "DELETE FROM Permisos WHERE idRecurso = @idRecurso AND recurso = @recurso"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRecurso", objRecurso.id), New SqlParameter("@recurso", objRecurso.tipo.ToString)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Permisos"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal bandera As Boolean, Optional ByVal objPermiso As DBObject = Nothing, Optional ByVal objRecurso As DBObject = Nothing) As System.Data.IDataReader
            Dim entro As Boolean = False
            Dim queryString As String = "SELECT p.*, u.nombre + ' ' + u.apellidos as nombre, u.login, eu.claveAux1, eu.claveAux2, u.emailgoogle, u.email, u.imagen, u.idUserProfile FROM Permisos p, UserProfiles u, EmpresasUserProfiles eu "

            If Not IsNothing(objPermiso) Then
                queryString = queryString & "WHERE u.idUserProfile = p.idPermisoA AND eu.idUserProfile=p.idPermisoA AND p.idPermisoA = @idPermisoA AND p.PermisoA = @PermisoA "
                entro = True
            End If

            If Not IsNothing(objRecurso) And entro Then
                queryString = queryString & "AND p.idRecurso = @idRecurso AND p.Recurso = @Recurso "
            Else
                If Not entro Then
                    queryString = queryString & "WHERE u.idUserProfile = p.idPermisoA AND eu.idUserProfile=p.idPermisoA AND p.idRecurso = @idRecurso AND p.Recurso = @Recurso "
                End If
            End If

            queryString = queryString & "ORDER BY u.apellidos, u.nombre ASC"

            Dim parametros() As SqlParameter
            Dim elementos As Integer

            If Not IsNothing(objPermiso) Then
                ReDim parametros(2)
                parametros(0) = New SqlParameter("@idPermisoA", objPermiso.id)
                parametros(1) = New SqlParameter("@PermisoA", objPermiso.tipo.ToString)
                elementos = 2
            End If

            If Not IsNothing(objRecurso) Then
                If elementos > 0 Then
                    ReDim Preserve parametros(4)
                    parametros(2) = New SqlParameter("@idRecurso", objRecurso.id)
                    parametros(3) = New SqlParameter("@Recurso", objRecurso.tipo.ToString)
                Else
                    ReDim parametros(2)
                    parametros(0) = New SqlParameter("@idRecurso", objRecurso.id)
                    parametros(1) = New SqlParameter("@Recurso", objRecurso.tipo.ToString)
                    elementos = 2
                End If
            End If

            If elementos > 0 Then
                Return Me.ExecuteReader(queryString, parametros)
            Else
                Return Me.ExecuteReader(queryString, Nothing)
            End If
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Permisos"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal bandera As Boolean, Optional ByVal objPermiso As DBObject = Nothing, Optional ByVal objRecurso As DBObject = Nothing) As System.Data.DataSet
            Dim entro As Boolean = False
            Dim queryString As String = "SELECT p.*, u.apellidos + ' ' + u.nombre as nombre, u.login FROM Permisos p, UserProfiles u "

            If Not IsNothing(objPermiso) Then
                queryString = queryString & "WHERE u.idUserProfile = p.idPermisoA AND p.idPermisoA = @idPermisoA AND p.PermisoA = @PermisoA "
                entro = True
            End If

            If Not IsNothing(objRecurso) And entro Then
                queryString = queryString & "AND p.idRecurso = @idRecurso AND p.Recurso = @Recurso "
            Else
                If Not entro Then
                    queryString = queryString & "WHERE u.idUserProfile = p.idPermisoA AND p.idRecurso = @idRecurso AND p.Recurso = @Recurso "
                End If
            End If

            queryString = queryString & "ORDER BY u.apellidos, u.nombre ASC"

            Dim parametros() As SqlParameter
            Dim elementos As Integer

            If Not IsNothing(objPermiso) Then
                ReDim parametros(2)
                parametros(0) = New SqlParameter("@idPermisoA", objPermiso.id)
                parametros(1) = New SqlParameter("@PermisoA", objPermiso.tipo.ToString)
                elementos = 2
            End If

            If Not IsNothing(objRecurso) Then
                If elementos > 0 Then
                    ReDim Preserve parametros(4)
                    parametros(2) = New SqlParameter("@idRecurso", objRecurso.id)
                    parametros(3) = New SqlParameter("@Recurso", objRecurso.tipo.ToString)
                Else
                    ReDim parametros(2)
                    parametros(0) = New SqlParameter("@idRecurso", objRecurso.id)
                    parametros(1) = New SqlParameter("@Recurso", objRecurso.tipo.ToString)
                    elementos = 2
                End If
            End If

            If elementos > 0 Then
                Return Me.ExecuteDataSet(queryString, parametros)
            Else
                Return Me.ExecuteDataSet(queryString, Nothing)
            End If
        End Function

        Public Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overrides Function EnUso() As Boolean
            Return True
        End Function

        '++++++++REVISAR++++++++++++
        Function GenerarActivacion(ByVal objPermiso As DBObject, ByVal objRecurso As DBObject) As Boolean
            Dim entro As Boolean = False
            Select Case objRecurso.tipo
                Case tipoObjeto.Contenido
                    '  Dim myContenido As Contenidos.Contenidos = New Contenidos.Contenidos(objRecurso.Clave, False)
                    ' If myContenido.userProfile.idUserProfile = objpermiso.Clave Then
                    'ActivarBanderas()
                    'End If
                Case tipoObjeto.Root
                    'Dim objRoot As New Lego.Root(objRecurso.id)
                    'If objRoot.idUserProfile = objPermiso.id Then
                    '    ActivarBanderas(objPermiso, objRecurso)
                    '    entro = True
                    'End If
                Case tipoObjeto.SalonVirtual
                    'Dim objSalon As New Know.SalonVirtual(objRecurso.id, False)
                    'If objSalon.idUserProfile = objPermiso.id Then
                    '    ActivarBanderas(objPermiso, objRecurso)
                    '    entro = True
                    'End If
            End Select

            Return entro
        End Function

        Sub ActivarBanderas(ByVal objPermiso As DBObject, ByVal objRecurso As DBObject)
            Me.idPermiso = 0
            Me.idPermisoA = objPermiso.id
            Me.varPermisoA = objPermiso.tipo
            Me.idRecurso = objRecurso.id
            Me.varRecurso = objRecurso.tipo
            Me.PRoots = True
            Me.PPermisosRoots = True
            Me.PCategorias = True
            Me.PRespuestas = True
            Me.PEvaluacion = True
            Me.PSalonVirtual = True
            Me.PContenidos = True
            Me.PInterfaceGrafica = True
            Me.PEstadisticas = True
            Me.PAdministracion = True
            'activa owner
            Me.owner = True
        End Sub

        '++++++++REVISAR++++++++++++
        Function Autorizacion(ByVal objPermisoA As DBObject, ByVal objRecurso As DBObject) As Boolean
            Dim dr As SqlClient.SqlDataReader
            Dim myPermiso As New MasUsuarios.Permiso
            dr = myPermiso.GetDR(True, objPermisoA, objRecurso)

            Dim bandera As Boolean = False

            If dr.Read Then
                dr.Close()
                Return True
            End If

            Select Case objRecurso.tipo
                Case tipoObjeto.Contenido
                    ' Dim myContenido As Contenidos.Contenidos = New Contenidos.Contenidos(claveRecurso.Clave, False)
                    'If myContenido.userProfile.idUserProfile = clavePermisoA.Clave Then
                    'bandera = True
                    'Me.Owner = True
                    'End If
                Case tipoObjeto.Root
                    Dim myRoot As New Lego.Root(objRecurso.id)
                    If myRoot.idUserProfile = objPermisoA.id Then
                        Me.owner = True
                        Return True
                    End If
                Case tipoObjeto.SalonVirtual
                    Dim mysalon As New Know.SalonVirtual(objRecurso.id, False)
                    If mysalon.idUserProfile = objPermisoA.id Then
                        Me.owner = True
                        Return True
                    End If
            End Select

            Return False
        End Function

        '+++++++++++DEPRECATED: Utilizar el constructor y luego la propiedad existe++++++++++
        'Function Existe() As Boolean
        '	Dim dr As SqlClient.SqlDataReader = Me.GetDR(True, Me.permisoA, Me.recurso)
        '	Dim bandera = False
        '	If dr.Read Then
        '		bandera = True

        '	End If
        '	dr.Close()

        '	Return bandera
        'End Function


    End Class



End Namespace

