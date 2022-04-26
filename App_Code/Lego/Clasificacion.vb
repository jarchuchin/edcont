Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Namespace Lego
    Public NotInheritable Class Clasificacion
        Inherits DBObject

        Private idClasificacion As Integer
        Public idRaiz As Integer
        Public idRoot As Integer
        Public titulo As String
        Public status As Boolean
        Public orden As Integer
        Public texto As String
        Public diaDisplay As Integer
        'Public objXMLIdiomas As New Utilerias.XMLIdioma(ConfigurationSettings.AppSettings("IdiomaDefault"))
        Public PlanteamientoBreve As String = ""
        Public Imagen1 As String = ""
        Public Imagen2 As String = ""
        Public Imagen3 As String = ""
        Public idActividad As Integer = 0

        Private varExiste As Boolean = False

        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idClasificacion
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Clasificacion
            End Get
        End Property

        Public Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idClasificacion = @idClasificacion"

            Dim parameters As SqlParameter() = {New SqlParameter("@idClasificacion", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idClasificacion = CType(dr("idClasificacion"), Integer)
                Me.idRaiz = CType(dr("idraiz"), Integer)
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.titulo = CType(dr("Titulo"), String)
                Me.status = CType(dr("status"), Boolean)
                Me.orden = CType(dr("orden"), Integer)
                Me.texto = CType(dr("texto"), String)
                Me.diaDisplay = CType(dr("diaDisplay"), Integer)

                If Convert.IsDBNull(dr("PlanteamientoBreve")) Then
                    Me.PlanteamientoBreve = ""
                Else
                    Me.PlanteamientoBreve = dr("PlanteamientoBreve")
                End If

                If Convert.IsDBNull(dr("Imagen1")) Then
                    Me.Imagen1 = ""
                Else
                    Me.Imagen1 = dr("Imagen1")
                End If

                If Convert.IsDBNull(dr("Imagen2")) Then
                    Me.Imagen2 = ""
                Else
                    Me.Imagen2 = dr("Imagen2")
                End If

                If Convert.IsDBNull(dr("Imagen3")) Then
                    Me.Imagen3 = ""
                Else
                    Me.Imagen3 = dr("Imagen3")
                End If

                If Not Convert.IsDBNull(dr("idActividad")) Then
                    Me.idActividad = dr("idActividad")
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveRoot As Integer, ByVal claveRaiz As Integer, ByVal claveOrden As Integer)
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRoot = @idRoot AND idRaiz = @idRaiz AND orden = @orden"

            Dim parameters As SqlParameter() = {
             New SqlParameter("@idRoot", claveRoot),
             New SqlParameter("@idRaiz", claveRaiz),
             New SqlParameter("@orden", claveOrden)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idClasificacion = CType(dr("idClasificacion"), Integer)
                Me.idRaiz = CType(dr("idraiz"), Integer)
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.titulo = CType(dr("Titulo"), String)
                Me.status = CType(dr("status"), Boolean)
                Me.orden = CType(dr("orden"), Integer)
                Me.texto = CType(dr("texto"), String)
                Me.diaDisplay = CType(dr("diaDisplay"), Integer)


                If Convert.IsDBNull(dr("PlanteamientoBreve")) Then
                    Me.PlanteamientoBreve = ""
                Else
                    Me.PlanteamientoBreve = dr("PlanteamientoBreve")
                End If

                If Convert.IsDBNull(dr("Imagen1")) Then
                    Me.Imagen1 = ""
                Else
                    Me.Imagen1 = dr("Imagen1")
                End If

                If Convert.IsDBNull(dr("Imagen2")) Then
                    Me.Imagen2 = ""
                Else
                    Me.Imagen2 = dr("Imagen2")
                End If

                If Convert.IsDBNull(dr("Imagen3")) Then
                    Me.Imagen3 = ""
                Else
                    Me.Imagen3 = dr("Imagen3")
                End If


                If Not Convert.IsDBNull(dr("idActividad")) Then
                    Me.idActividad = dr("idActividad")
                End If

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal idSalonVirtual As Integer, status As Boolean)
            Dim queryString As String = "SELECT TOP (1) cl.* FROM Clasificaciones AS cl INNER JOIN SalonesVirtuales AS sv " _
             & "ON cl.idRoot = sv.idRoot AND sv.idSalonVirtual = @idSalonVirtual WHERE (cl.idRaiz = 0) AND (cl.status = @status) ORDER BY cl.titulo"

            Dim parameters As SqlParameter() = {New SqlParameter("@idSalonVirtual", idSalonVirtual), New SqlParameter("@status", status)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idClasificacion = dr("idClasificacion")
                Me.idRaiz = dr("idraiz")
                Me.idRoot = dr("idRoot")
                Me.titulo = dr("Titulo")
                Me.status = dr("status")
                Me.orden = dr("orden")
                Me.texto = dr("texto")
                Me.diaDisplay = dr("diaDisplay")
                Me.PlanteamientoBreve = ""
                Me.Imagen1 = ""
                Me.Imagen2 = ""
                Me.Imagen3 = ""

                If Not Convert.IsDBNull(dr("PlanteamientoBreve")) Then Me.PlanteamientoBreve = dr("PlanteamientoBreve")
                If Not Convert.IsDBNull(dr("Imagen1")) Then Me.Imagen1 = dr("Imagen1")
                If Not Convert.IsDBNull(dr("Imagen2")) Then Me.Imagen2 = dr("Imagen2")
                If Not Convert.IsDBNull(dr("Imagen3")) Then Me.Imagen3 = dr("Imagen3")
                If Not Convert.IsDBNull(dr("idActividad")) Then Me.idActividad = dr("idActividad")

                Me.varExiste = True
            End If
            dr.Close()
        End Sub

        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [Clasificaciones] ([idRaiz], [idRoot], [titulo], [status], " &
                 "[orden], texto, diadisplay, PlanteamientoBreve, Imagen1, Imagen2, Imagen3) VALUES (@idRaiz, @idRoot, @titulo, @status, @orden, @texto, @diadisplay, @PlanteamientoBreve, @Imagen1, @Imagen2, @Imagen3)"

                Dim numero As Integer = GetNumeroOrden()

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRaiz", Me.idRaiz),
                 New SqlParameter("@idRoot", Me.idRoot),
                 New SqlParameter("@titulo", Me.titulo),
                 New SqlParameter("@status", Me.status),
                  New SqlParameter("@texto", Me.texto),
                  New SqlParameter("@orden", GetNumeroOrden()),
                  New SqlParameter("@diadisplay", Me.diaDisplay),
                  New SqlParameter("@PlanteamientoBreve", Me.PlanteamientoBreve),
                  New SqlParameter("@Imagen1", Me.Imagen1),
                  New SqlParameter("@Imagen2", Me.Imagen2),
                  New SqlParameter("@Imagen3", Me.Imagen3)}

                Me.idClasificacion = Me.ExecuteNonQuery(queryString, parametros, True)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Clasificaciones] SET [idRaiz]=@idRaiz, [idRoot]=@idRoot, " &
                 "[titulo]=@titulo, [status]=@status, [orden]=@orden, texto=@texto, diadisplay=@diadisplay, PlanteamientoBreve=@PlanteamientoBreve, Imagen1=@Imagen1, Imagen2=@Imagen2, Imagen3=@Imagen3 WHERE idClasificacion = @idClasificacion"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idClasificacion", Me.idClasificacion),
                 New SqlParameter("@idRaiz", Me.idRaiz),
                 New SqlParameter("@idRoot", Me.idRoot),
                 New SqlParameter("@titulo", Me.titulo),
                 New SqlParameter("@status", Me.status),
                  New SqlParameter("@orden", Me.orden),
                  New SqlParameter("@texto", Me.texto),
                  New SqlParameter("@diadisplay", Me.diaDisplay),
                  New SqlParameter("@PlanteamientoBreve", Me.PlanteamientoBreve),
                  New SqlParameter("@Imagen1", Me.Imagen1),
                  New SqlParameter("@Imagen2", Me.Imagen2),
                  New SqlParameter("@Imagen3", Me.Imagen3)}

                Return Me.ExecuteNonQuery(queryString, parametros)

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE FROM Clasificaciones WHERE idClasificacion = @idClasificacion"

            Dim parametros As SqlParameter() = {New SqlParameter("@idClasificacion", Me.idClasificacion)}

            Dim rowsAffected As Integer
            If Not EnUso() Then
                rowsAffected = Me.ExecuteNonQuery(queryString, parametros)
            End If

            Return rowsAffected
        End Function

        Public Overrides Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT * FROM Clasificaciones"

            Return Me.ExecuteReader(queryString, Nothing)
        End Function

        Public Overloads Function GetDR(ByVal myidRoot As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRoot = @idRoot order by titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", myidRoot)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Clasificaciones"

            Return Me.ExecuteDataSet(queryString, Nothing)
        End Function

        Public Overloads Function GetDS(ByVal myidRoot As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRoot = @idRoot"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", myidRoot)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDS(ByVal myidRoot As Integer, ByVal myidRaiz As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRoot = @idRoot AND idRaiz = @idRaiz order by Orden"


            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", SqlDbType.Int), New SqlParameter("@idRaiz", SqlDbType.Int)}

            parametros(0).Value = myidRoot
            parametros(1).Value = myidRaiz

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Overrides Function Count() As Integer
            Dim queryString As String = "SELECT COUNT(idClasificacion) as num FROM Clasificaciones where idClasificacion=" & Me.idClasificacion

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, Nothing)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If

            End If
            dr.Close()

            Return numero
        End Function

        Public Overloads Function Count(ByVal myidRoot As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(idClasificacion) as num FROM Clasificaciones where idRoot =@idRoot"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", myidRoot)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If

            End If
            dr.Close()

            Return numero
        End Function

        Public Overloads Overrides Function EnUso() As Boolean
            Dim dr As Data.SqlClient.SqlDataReader = GetDRRaizRoot(Me.idClasificacion, Me.idRoot)
            Dim retorno As Boolean
            retorno = dr.HasRows
            dr.Close()

            Return retorno
        End Function

        Public Overloads Function EnUso(ByVal tratandoDeBorrar As Boolean) As Boolean
            Dim retorno As Boolean = EnUso
            If Not retorno Then
                Dim dr As SqlClient.SqlDataReader = New ClasificacionItem().GetDR(Me.idClasificacion, ordenamiento.DESC)
                retorno = dr.HasRows
                dr.Close()
            End If

            Return retorno
        End Function

        Public Overloads Function EnUso(ByVal claveRoot As Integer) As Boolean
            Dim ds As DataSet = GetDS(claveRoot)

            Return ds.Tables(0).Rows.Count > 0
        End Function

        Public Function GetDSRaizRoot(ByVal claveRaiz As Integer, ByVal claveRoot As Integer, Optional ByVal ocultar As Boolean = False) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz =@idRaiz AND idRoot=@idRoot "

            If ocultar Then
                queryString = queryString & "AND status = 1 "
            End If
            queryString = queryString & "ORDER BY titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idRaiz", claveRaiz)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function GetDRRaizRoot(ByVal claveRaiz As Integer, ByVal claveRoot As Integer, Optional ByVal ocultar As Boolean = False) As System.Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz =@idRaiz AND idRoot=@idRoot "

            If ocultar Then
                queryString = queryString & "AND status = 1 "
            End If
            queryString = queryString & "ORDER BY titulo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idRaiz", claveRaiz)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetDRRaizRootStatus(ByVal claveRaiz As Integer, ByVal claveRoot As Integer, ByVal claveStatus As Boolean) As System.Data.SqlClient.SqlDataReader
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz = @idRaiz AND idRoot = @idRoot " &
             "AND status = @status ORDER BY titulo"

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idRoot", claveRoot),
             New SqlParameter("@idRaiz", claveRaiz),
             New SqlParameter("@status", claveStatus)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        '+++++DEPRECATED: Utilizar EnUso() +++++++++++++++
        Public Function ExistenElementos(ByVal claveRoot As Integer) As Boolean
            Return EnUso(claveRoot)
        End Function

        Public Function ExistenElementos() As Boolean
            Return EnUso()
        End Function

        '+++++DEPRECATED: Utilizar EnUso() +++++++++++++++
        Public Function SePuedeBorrar() As Boolean
            Return Not EnUso(True)
        End Function

        Public Function GetNumeroOrden() As Integer
            Dim queryString As String = "SELECT orden FROM Clasificaciones WHERE idRoot = @idRoot AND idRaiz = @idRaiz " &
             "ORDER BY orden DESC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", Me.idRoot), New SqlParameter("@idRaiz", Me.idRaiz)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim num As Integer = 0

            If dr.Read Then
                If Not Convert.IsDBNull(dr("orden")) Then
                    num = CType(dr("orden"), Integer) + 1
                End If
            End If

            dr.Close()

            Return num
        End Function

        Public Function MoveArriba() As Integer
            Dim resultado As Integer
            If Me.orden > 0 Then
                Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz = @idRaiz AND " &
                 "idRoot = @idRoot AND orden < @orden ORDER BY orden DESC"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@idRaiz", Me.idRaiz),
                 New SqlParameter("@idRoot", Me.idRoot),
                 New SqlParameter("@orden", Me.orden)}

                Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
                If dr.Read Then
                    Dim claveTemp, ordenTemp As Integer
                    claveTemp = CType(dr("idClasificacion"), Integer)
                    ordenTemp = Me.orden
                    Me.orden = CType(dr("orden"), Integer)
                    resultado = Update()
                    Me.idClasificacion = claveTemp
                    Me.idRaiz = CType(dr("idRaiz"), Integer)
                    Me.idRoot = CType(dr("idRoot"), Integer)
                    Me.titulo = CType(dr("Titulo"), String)
                    Me.status = CType(dr("Status"), Boolean)
                    Me.orden = ordenTemp
                    resultado = resultado + Update()
                End If
                dr.Close()
            End If

            Return resultado
        End Function

        Public Function MoveAbajo() As Integer
            Dim resultado As Integer

            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz = @idRaiz AND " &
              "idRoot = @idRoot AND orden > @orden ORDER BY orden ASC"

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idRaiz", Me.idRaiz),
             New SqlParameter("@idRoot", Me.idRoot),
             New SqlParameter("@orden", Me.orden)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Dim claveTemp, ordenTemp As Integer
                claveTemp = CType(dr("idClasificacion"), Integer)
                ordenTemp = Me.orden
                Me.orden = CType(dr("orden"), Integer)
                resultado = Update()
                Me.idClasificacion = claveTemp
                Me.idRaiz = CType(dr("idRaiz"), Integer)
                Me.idRoot = CType(dr("idRoot"), Integer)
                Me.titulo = CType(dr("Titulo"), String)
                Me.status = CType(dr("Status"), Boolean)
                Me.orden = ordenTemp
                resultado = resultado + Update()
            End If
            dr.Close()

            Return resultado
        End Function

        Public Function MoveDerecha() As Integer
            Dim queryString As String = "SELECT * FROM Clasificaciones WHERE idRaiz = @idRaiz AND " &
             "idRoot = @idRoot AND orden < @orden ORDER BY orden DESC"

            Dim parametros As SqlParameter() = {
             New SqlParameter("@idRaiz", Me.idRaiz),
             New SqlParameter("@idRoot", Me.idRoot),
             New SqlParameter("@orden", Me.orden)}

            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim resultado As Integer
            If dr.Read Then
                Me.idRaiz = CType(dr("idClasificacion"), Integer)
                Me.orden = GetNumeroOrden()
                resultado = Update()
            End If
            dr.Close()

            Return resultado
        End Function

        Public Function MoveIzquierda() As Integer
            Dim resultado As Integer

            If Me.idRaiz > 0 Then
                Dim myClasificacion As New Clasificacion(Me.idRaiz)
                Me.idRaiz = myClasificacion.idRaiz
                Me.orden = GetNumeroOrden()
                resultado = Update()
            End If

            Return resultado
        End Function

        ''++++++++REVISAR++++++++++++
        'Public Function GetStringMapRecursive(ByVal pagina As String, ByVal claveroot As Integer, ByVal raiz As Integer, Optional ByVal ocultar As Boolean = False) As String
        '	Dim dr As System.Data.SqlClient.SqlDataReader = GetDRRaizRoot(raiz, claveroot, ocultar)
        '	Dim superString As String = String.Empty
        '	Do While dr.Read
        '		superString = superString & "<ul>"
        '		superString = superString & "<li>"
        '		superString = superString & CType(dr("titulo"), String)
        '		If CType(dr("status"), Boolean) Then
        '			superString = superString & " <i>" & objXMLIdiomas.GetString("E021") & "</i>"
        '		Else
        '			superString = superString & " <i>" & objXMLIdiomas.GetString("E022") & "</i>"
        '		End If
        '		superString = superString & "  <a href='" & pagina & "?idRoot=" & CType(dr("idRoot"), String) & "&idClasificacion=" & CType(dr("idClasificacion"), String) & "' ><img src='" & ConfigurationManager.AppSettings("carpetaVirtual") & "images/editar.gif' border='0' title='" & objXMLIdiomas.GetString("E015") & "'> </a> &nbsp;"
        '		superString = superString & "  <a href='" & pagina & "?idRoot=" & CType(dr("idRoot"), String) & "&idR=" & CType(dr("idClasificacion"), String) & "' ><img src='" & ConfigurationManager.AppSettings("carpetaVirtual") & "images/agregar.gif' border='0' title='" & objXMLIdiomas.GetString("E100") & "'></a> &nbsp;"
        '		superString = superString & "  <a href='../anexador.aspx?idRoot=" & CType(dr("idRoot"), String) & "&idB=" & CType(dr("idClasificacion"), String) & "&tB=Clasificacion" & "&idClasificacion=" & CType(dr("idClasificacion"), String) & "' ><img src='" & ConfigurationManager.AppSettings("carpetaVirtual") & "images/masq.gif' border='0' title='" & objXMLIdiomas.GetString("E101") & "'></a> "
        '		superString = superString & "</li>"
        '		superString = superString & GetStringMapRecursive(pagina, claveroot, CType(dr("idClasificacion"), Integer), ocultar)
        '		superString = superString & "</ul>"
        '	Loop
        '	dr.Close()

        '	Return superString
        'End Function

        '++++++++REVISAR++++++++++++
        Public Function GetStringMapRecursiveJavaScript(ByVal nombreFuncion As String, ByVal claveroot As Integer, ByVal raiz As Integer, Optional ByVal ocultar As Boolean = False) As String
            Dim dr As System.Data.SqlClient.SqlDataReader = GetDRRaizRoot(raiz, claveroot, ocultar)
            Dim superString As String = String.Empty
            Do While dr.Read
                superString = superString & "<ul>"
                superString = superString & "<li>"
                superString = superString & "  <a href='javascript:" & nombreFuncion & "(" & CType(dr("idRoot"), String) & ", " & CType(dr("idClasificacion"), String) & ");' >" & CType(dr("Titulo"), String) & "</a>"
                superString = superString & "</li>"
                superString = superString & GetStringMapRecursiveJavaScript(nombreFuncion, claveroot, CType(dr("idClasificacion"), Integer), ocultar)
                superString = superString & "</ul>"
            Loop
            dr.Close()

            Return superString
        End Function

        ''++++++++REVISAR++++++++++++
        'Private Function GetRowsRecursive(ByRef tablilla As DataTable, ByVal cadena As String, ByVal claveroot As Integer, ByVal raiz As Integer, _
        ' ByVal tabulacion As Integer, ByVal incrementoTabulacion As Integer, ByRef dropC As String, ByVal dropA As String, Optional ByVal ocultar As Boolean = False) As DataView

        '	Dim dr As System.Data.SqlClient.SqlDataReader = GetDRRaizRoot(raiz, claveroot, ocultar)
        '	Dim dRow As DataRow

        '	Dim myCi As New ClasificacionItem

        '	Do While dr.Read()
        '		dRow = tablilla.NewRow()
        '		dRow(0) = CType(dr("idClasificacion"), Integer)
        '		dRow(1) = CType(dr("idRaiz"), Integer)
        '		dRow(2) = CType(dr("idRoot"), Integer)
        '		dRow(3) = CType(dr("titulo"), String)
        '		dRow(4) = CType(dr("status"), Boolean)
        '		dRow(5) = CType(dr("orden"), Integer)
        '		dRow(6) = tabulacion
        '		dRow(7) = cadena
        '		If dRow(4) Then
        '			dRow(8) = "[" & objXMLIdiomas.GetString("E021") & "]"
        '		Else
        '			dRow(8) = "[" & objXMLIdiomas.GetString("E022") & "]"
        '		End If
        '		dRow(9) = dropC
        '		dRow(10) = dropA

        '		Dim drContent As SqlClient.SqlDataReader = myCi.GetDR(CInt(dr("idClasificacion")), "")
        '		If drContent.HasRows Then
        '			dRow(11) = True
        '		Else
        '			dRow(11) = False
        '		End If
        '		drContent.Close()

        '		tablilla.Rows.Add(dRow)
        '		Me.GetRowsRecursive(tablilla, cadena, claveroot, CType(dr("idClasificacion"), Integer), tabulacion + incrementoTabulacion, incrementoTabulacion, dropC, dropA, False)
        '	Loop
        '	dr.Close()

        '	Return tablilla.DefaultView
        'End Function

        'Public Function GetTableTabulation(ByVal cadena As String, ByVal claveroot As Integer, ByVal raiz As Integer, _
        ' ByVal tabulacion As Integer, ByVal incrementoTabulacion As Integer, ByVal idioma As String, Optional ByVal ocultar As Boolean = False) As DataView

        '	Dim dTable As New DataTable
        '	dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
        '	dTable.Columns.Add(New DataColumn("idRaiz", GetType(Integer)))
        '	dTable.Columns.Add(New DataColumn("idRoot", GetType(Integer)))
        '	dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
        '	dTable.Columns.Add(New DataColumn("status", GetType(Boolean)))
        '	dTable.Columns.Add(New DataColumn("orden", GetType(Integer)))
        '	dTable.Columns.Add(New DataColumn("tabulacion", GetType(Integer)))
        '	dTable.Columns.Add(New DataColumn("cadena", GetType(String)))
        '	dTable.Columns.Add(New DataColumn("enlinea", GetType(String)))
        '	dTable.Columns.Add(New DataColumn("dropC", GetType(String)))
        '	dTable.Columns.Add(New DataColumn("dropA", GetType(String)))
        '	dTable.Columns.Add(New DataColumn("HayElementos", GetType(Boolean)))

        '	Dim dropC As String = String.Empty
        '	Dim dropA As String = String.Empty

        '	Me.GetRowsRecursive(dTable, cadena, claveroot, raiz, tabulacion, incrementoTabulacion, dropC, dropA, ocultar)

        '	Dim dView As New DataView(dTable)

        '	Return dView
        'End Function

        '++++++++REVISAR++++++++++++
        Public Function MenuItem(ByVal objElement As XmlElement, ByVal objNewDoc As XmlDocument,
         ByVal claveroot As Integer, ByVal raiz As Integer, ByVal pagina As String) As XmlElement

            Dim mySecciones As New Clasificacion
            Dim dr As System.Data.SqlClient.SqlDataReader = mySecciones.GetDRRaizRootStatus(raiz, claveroot, True)
            Dim objElementNuevo As XmlElement
            Dim contador As Integer = 0

            objElementNuevo = objNewDoc.CreateElement("MenuGroup")
            objElement.AppendChild(objElementNuevo)

            Do While dr.Read
                Dim objElementDatos As XmlElement
                objElementDatos = objNewDoc.CreateElement("MenuItem")
                objElementDatos.SetAttribute("Label", CType(dr("titulo"), String))

                Dim mySecEx As New Clasificacion(CType(dr("idClasificacion"), String))
                If mySecEx.ExistenElementos() Then
                    objElementNuevo.AppendChild(objElementDatos)
                    objElementDatos.AppendChild(Me.MenuItem(objElementDatos, objNewDoc, claveroot, CType(dr("idClasificacion"), String), pagina))
                    objElementDatos.SetAttribute("RightIcon", "arrow.gif")
                Else
                    Dim urlString As String
                    urlString = pagina & "?idSec=" & CType(dr("idSeccion"), String)
                    objElementDatos.SetAttribute("URL", urlString)
                    objElementNuevo.AppendChild(objElementDatos)
                End If

            Loop
            dr.Close()

            Return objElementNuevo
        End Function


        Public Function ClasificacionesRoot(ByVal claveRoot As Integer, Optional ByVal esconderClasificacion As Integer = 0) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("Titulo", GetType(String)))

            ClasificacionesRootTitulo(claveRoot, 0, dTable, "", esconderClasificacion)

            Dim dView As New DataView(dTable)
            Return dView

        End Function

        Private Function ClasificacionesRootTitulo(ByVal claveRoot As Integer, ByVal claveRaiz As Integer, ByRef dtable As DataTable, ByVal loctitulo As String, Optional ByVal esconderClasificacion As Integer = 0) As Integer

            Dim dr As System.Data.SqlClient.SqlDataReader = GetDRRaizRoot(claveRaiz, claveRoot)
            Dim dRow As DataRow
            Dim titulolocal As String = loctitulo
            While dr.Read
                dRow = dtable.NewRow
                Dim clave As Integer = CInt(dr("idClasificacion"))
                dRow(0) = clave
                If loctitulo <> "" Then
                    titulolocal = loctitulo & " >> " & dr("titulo")
                Else
                    titulolocal = dr("titulo")
                End If
                dRow(1) = titulolocal


                If esconderClasificacion > 0 Then
                    If Not clave = esconderClasificacion Then
                        dtable.Rows.Add(dRow)
                        ClasificacionesRootTitulo(claveRoot, CInt(dr("idClasificacion")), dtable, titulolocal)
                        titulolocal = ""
                    End If
                Else
                    dtable.Rows.Add(dRow)
                    ClasificacionesRootTitulo(claveRoot, CInt(dr("idClasificacion")), dtable, titulolocal)
                    titulolocal = ""
                End If


            End While

            dr.Close()

            Return 1

        End Function

        Public Function GetValuePath(ByVal clave As Integer, ByVal path As String) As String

            Dim myc As Clasificacion = New Clasificacion(clave)

            If myc.idRaiz > 0 Then
                path = Me.GetValuePath(myc.idRaiz, myc.id) '& "\" & path
            Else
                If path <> "" Then
                    path = myc.id & "/" & path
                Else
                    path = myc.id
                End If


            End If

            Return path
        End Function

        Public Function GetClasificacionDisplay(ByVal claveSalon As Integer, ByVal claveRoot As Integer, ByVal fechaActual As Date) As Integer

            Dim mys As Know.SalonVirtual = New Know.SalonVirtual(claveSalon, False)

            Dim diasTranscurridos As Integer = DateDiff(DateInterval.Day, mys.fechaInicio, fechaActual)
            If mys.fechaInicio.Date = fechaActual.Date Then
                diasTranscurridos = 1
            End If
            Dim mysql As String = "select * from clasificaciones where idRoot=@idRoot and diadisplay <= @diastranscurridos order by diadisplay desc"
            Dim parameters As SqlParameter() = {
             New SqlParameter("@idRoot", claveRoot),
             New SqlParameter("@diastranscurridos", diasTranscurridos)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, parameters)
            Dim regreso As Integer = 0
            If dr.Read Then
                regreso = CInt(dr("idClasificacion"))

            End If
            dr.Close()

            Return regreso
        End Function

        Public Function IndiceClasificaciones(ByVal claveRoot As Integer, Optional ByVal soloActivos As Boolean = False) As DataView
            Dim dTable As New DataTable("Clasificaciones")
            dTable.Columns.Add(New DataColumn("idClasificacion", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("titulo", GetType(String)))
            dTable.Columns.Add(New DataColumn("idRoot", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idRaiz", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("numero", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("idActividad", GetType(Integer)))

            BuildIndiceClasificaciones(claveRoot, 0, dTable, "", soloActivos)

            Return New DataView(dTable)
        End Function

        Private Function BuildIndiceClasificaciones(ByVal claveRoot As Integer, ByVal claveRaiz As Integer, ByRef tabla As DataTable, tituloPrevio As String, Optional ByVal soloActivos As Boolean = False, Optional numeroAnterior As Integer = 0) As Integer
            Dim dRow As DataRow
            Dim dr As SqlDataReader = GetDRRaizRoot(claveRaiz, claveRoot, soloActivos)
            Dim contador As Integer = numeroAnterior + 1

            Do While dr.Read
                dRow = tabla.NewRow

                Dim clave As Integer = CInt(dr("idClasificacion"))
                Dim titulo As String = tituloPrevio & dr("titulo")
                Dim idActividad As Integer
                If Not IsDBNull(dr("idActividad")) Then idActividad = CInt(dr("idActividad"))

                dRow(0) = clave
                dRow(1) = titulo
                dRow(2) = claveRoot
                dRow(3) = claveRaiz
                dRow(4) = contador
                dRow(5) = idActividad
                tabla.Rows.Add(dRow)

                contador = BuildIndiceClasificaciones(claveRoot, CInt(dr("idClasificacion")), tabla, tituloPrevio & "&nbsp;&nbsp;::", soloActivos, contador) + 1
            Loop
            dr.Close()

            Return contador - 1
        End Function

        Public Function IndiceNested(claveRoot As Integer, Optional ByVal soloActivos As Boolean = True) As DataSet
            Dim ds As New DataSet("ClasificacionesContenidos")

            ds.Tables.Add(IndiceClasificaciones(claveRoot, soloActivos).Table)

            Dim queryString = "SELECT ci.idClasificacionItem, ci.idRoot, ci.idClasificacion, c.idContenido, c.titulo, ci.orden, ci.procedencia, c.idTipoContenido AS idTipo " _
            & "FROM ClasificacionesItems AS ci INNER JOIN Contenidos AS c ON ci.idProc = c.idContenido " _
            & "AND ci.procedencia = 'Contenido' WHERE (ci.idRoot = " & claveRoot & ") AND (c.idTipoContenido = 4 or c.idTipoContenido = 7) ORDER BY  c.titulo" 'ci.idRoot, ci.idClasificacion, ci.orden"
            Dim dataAdapterCon As New SqlDataAdapter(queryString, ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
            dataAdapterCon.Fill(ds, "Contenidos")

            queryString = "SELECT ci.idClasificacionItem, ci.idRoot, ci.idClasificacion, a.idActividad, a.titulo, ci.orden, ci.procedencia, 2 as idTipo " _
             & "FROM ClasificacionesItems AS ci INNER JOIN Actividades AS a ON ci.idProc = a.idActividad AND ci.procedencia = 'Actividad' AND a.tipodeActividad = 2 " _
             & "WHERE (ci.idRoot = " & claveRoot & ") ORDER BY a.titulo" 'ci.idRoot, ci.idClasificacion, ci.orden"
            Dim dataAdapterAct As New SqlDataAdapter(queryString, ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
            dataAdapterAct.Fill(ds, "Actividades")

            queryString = "SELECT ci.idClasificacionItem, ci.idRoot, ci.idClasificacion, a.idActividad, a.titulo, ci.orden, ci.procedencia, 1 as idTipo " _
             & "FROM ClasificacionesItems AS ci INNER JOIN Actividades AS a ON ci.idProc = a.idActividad AND ci.procedencia = 'Actividad' AND a.tipodeActividad = 1 " _
             & "WHERE (ci.idRoot = " & claveRoot & ") ORDER BY a.titulo" 'ci.idRoot, ci.idClasificacion, ci.orden"
            Dim dataAdapterExa As New SqlDataAdapter(queryString, ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
            dataAdapterExa.Fill(ds, "Examenes")

            queryString = "SELECT ci.idClasificacionItem, ci.idRoot, ci.idClasificacion, f.idForo, f.titulo, ci.orden, ci.procedencia, 0 as idTipo " _
            & "FROM ClasificacionesItems AS ci INNER JOIN Foros AS f ON ci.idProc = f.idForo AND ci.procedencia = 'Foro' WHERE idRoot = " & claveRoot _
            & " ORDER BY f.titulo" ' ci.idRoot, ci.idClasificacion, ci.orden"
            Dim dataAdapterForo As New SqlDataAdapter(queryString, ConfigurationManager.ConnectionStrings("SkolarConnectionString").ConnectionString)
            dataAdapterForo.Fill(ds, "Foros")


            Dim parentColumns() As DataColumn = {ds.Tables("Clasificaciones").Columns("idRoot"), ds.Tables("Clasificaciones").Columns("idClasificacion")}
            Dim contenidoColumns() As DataColumn = {ds.Tables("Contenidos").Columns("idRoot"), ds.Tables("Contenidos").Columns("idClasificacion")}
            Dim actividadColumns() As DataColumn = {ds.Tables("Actividades").Columns("idRoot"), ds.Tables("Actividades").Columns("idClasificacion")}
            Dim examenColumns() As DataColumn = {ds.Tables("Examenes").Columns("idRoot"), ds.Tables("Examenes").Columns("idClasificacion")}
            Dim foroColumns() As DataColumn = {ds.Tables("Foros").Columns("idRoot"), ds.Tables("Foros").Columns("idClasificacion")}

            Dim columnsNames() As String = {"idRoot", "idClasificacion"}
            Dim relCont As New DataRelation("ClasificacionContenido", parentColumns, contenidoColumns, False)
            Dim relAct As New DataRelation("ClasificacionActividad", parentColumns, actividadColumns, False)
            Dim relExa As New DataRelation("ClasificacionExamen", parentColumns, examenColumns, False)
            Dim relForo As New DataRelation("ClasificacionForo", parentColumns, foroColumns, False)

            ds.Relations.Add(relCont)
            ds.Relations.Add(relAct)
            ds.Relations.Add(relExa)
            ds.Relations.Add(relForo)

            Return ds
        End Function

        Public Function getAnexosDeClasificacion(claveRoot As Integer, claveClasificacion As Integer) As DataSet
            'AND ((c.idTipoContenido = 4) or (c.idTipoContenido = 7)  or (c.idTipoContenido = 2))
            Dim queryString As String = "SELECT ci.idRoot, ci.idClasificacionItem, 'Contenido' AS tipoAnexo, c.idTipoContenido AS idTipo, c.titulo, c.extension as extension," _
             & "ci.orden, 1 AS ordenAnexo, textoCorto, 1 as quienCalifica, 0 as mostrarRespuestas, 0 as mostrarCalificacion, 0 as mostrarObservaciones, 0 as puntosTotales, 0 as tiempoEnMinutos, '' as texto FROM ClasificacionesItems AS ci INNER JOIN Contenidos AS c ON ci.idProc = c.idContenido " _
             & "AND ci.procedencia = 'Contenido' WHERE (ci.idRoot = @idRoot) AND (ci.idClasificacion = @idClasificacion)  " _
             & "UNION " _
             & "SELECT ci.idRoot, ci.idClasificacionItem, 'Actividad' AS tipoAnexo, 2 AS idTipo, a.titulo, '' as extension, ci.orden, 2 AS ordenAnexo, '' as textoCorto, a.quienCalifica, a.mostrarRespuestas, a.mostrarCalificacion, a.mostrarObservaciones, a.puntosTotales, a.tiempoEnMinutos, '' as texto " _
             & "FROM ClasificacionesItems AS ci INNER JOIN Actividades AS a ON ci.idProc = a.idActividad AND ci.procedencia = 'Actividad' " _
             & "AND a.tipodeActividad = 2 WHERE (ci.idRoot = @idRoot) AND (ci.idClasificacion = @idClasificacion) " _
             & "UNION " _
             & "SELECT ci.idRoot, ci.idClasificacionItem, 'Examen' AS tipoAnexo, 1 AS idTipo, a.titulo, '' as extension, ci.orden, 3 AS ordenAnexo, '' as textoCorto, a.quienCalifica, a.mostrarRespuestas, a.mostrarCalificacion, a.mostrarObservaciones, a.puntosTotales, a.tiempoEnMinutos, '' as texto " _
             & "FROM ClasificacionesItems AS ci INNER JOIN Actividades AS a ON ci.idProc = a.idActividad AND ci.procedencia = 'Actividad' " _
             & "AND a.tipodeActividad = 1 WHERE (ci.idRoot = @idRoot) AND (ci.idClasificacion = @idClasificacion) " _
             & "UNION " _
             & "SELECT ci.idRoot, ci.idClasificacionItem, 'Foro' AS tipoAnexo, 0 AS idTipo, f.titulo, '' as extension, ci.orden, 4 AS ordenAnexo, '' as textoCorto, 1 as quienCalifica, 0 as mostrarRespuestas, 0 as mostrarCalificacion, 0 as mostrarObservaciones, 0 as puntosTotales, 0 as tiempoEnMinutos, f.texto " _
             & "FROM ClasificacionesItems AS ci INNER JOIN Foros AS f ON ci.idProc = f.idForo AND ci.procedencia = 'Foro' " _
             & "WHERE (ci.idRoot = @idRoot) AND (ci.idClasificacion = @idClasificacion) ORDER BY ordenAnexo, ci.orden"

            Dim parametros As SqlParameter() = {New SqlParameter("@idRoot", claveRoot), New SqlParameter("@idClasificacion", claveClasificacion)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function getTotalAnexos(claveClasificacion As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(*) AS totalAnexos FROM ClasificacionesItems AS ci INNER JOIN Contenidos AS c " _
             & "ON ci.idProc = c.idContenido AND ci.Procedencia = 'Contenido' AND c.idTipoContenido <> 4 WHERE (ci.idClasificacion = @idClasificacion)"

            Dim parametros As SqlParameter() = {New SqlParameter("idClasificacion", claveClasificacion)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim total As Integer
            If dr.Read Then
                total = CInt(dr("totalAnexos"))
            End If
            dr.Close()

            Return total
        End Function

        Public Function getTotalObjetivos(claveClasificacion As Integer) As Integer
            Dim queryString As String = "SELECT COUNT(*) AS totalObjetivos FROM Objetivos WHERE (idClasificacion = @idClasificacion)"

            Dim parametros As SqlParameter() = {New SqlParameter("idClasificacion", claveClasificacion)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim total As Integer
            If dr.Read Then
                total = CInt(dr("totalObjetivos"))
            End If
            dr.Close()

            Return total
        End Function

    End Class
End Namespace

