Imports System.Data

Partial Class Sec_SalonVirtual_Controles_IndiceContenido
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property modoEdicion As Boolean
        Set(value As Boolean)
            hiddenModoEdicion.Value = value
        End Set
    End Property

    Public WriteOnly Property modoVistaPrevia As Boolean
        Set(value As Boolean)
            hiddenModoVistaPrevia.Value = value
        End Set
    End Property

    Public WriteOnly Property idRoot As Integer
        Set(value As Integer)
            hiddenIdRoot.Value = value
        End Set
    End Property

    Dim dsLoc As DataSet
    Public Property dsContenidos As DataSet
        Set(value As DataSet)
            dsLoc = value
        End Set
        Get
            Return dsLoc
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        llenado()
    End Sub

    Private Sub llenado()
        Dim idRoot As Integer = getIdRoot()

        If idRoot <= 0 Then
            Dim idCI As Integer = getIdCI()
            If idCI > 0 Then
                Dim objClasificacionItem As New Lego.ClasificacionItem(getIdCI)
                idRoot = objClasificacionItem.idRoot
            Else
                Dim idClasificacion As Integer = getIdClasificacion()
                If idClasificacion > 0 Then
                    Dim objClasificacion As New Lego.Clasificacion(idClasificacion)
                    idRoot = objClasificacion.idRoot
                End If
            End If
        End If



        lnkRegreso.NavigateUrl = "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & getIdSalonVirtual()

        'If getModoEdicion() Then
        '    ds = New Lego.Clasificacion().IndiceNested(idRoot, True)
        'Else
        '    ds = New Lego.Clasificacion().IndiceNested(idRoot, Not esMaestro())
        'End If

        '    repeaterClasificaciones.DataSource = ds
        '    repeaterClasificaciones.DataBind()

        If IsNothing(dsLoc) Then
            dsLoc = New Lego.Clasificacion().GetDSRaizRoot(0, idRoot, True)
        End If



        rptUnidades.DataSource = dsLoc
        rptUnidades.DataBind()



        hiddenIdRoot.Value = idRoot
    End Sub




    Dim rc As New Random
    Function getColorRandom() As String


        Select Case rc.Next(1, 7)
            Case 1
                Return "purple"
            Case 2
                Return "mint"
            Case 3
                Return "warning"
            Case 4
                Return "danger"
            Case 5
                Return "success"
            Case 6
                Return "dark"
            Case 7
                Return "pink"


        End Select

    End Function



    Private Function getIdRoot() As Integer
        Dim claveRoot As Integer
        Try
            claveRoot = CInt(Request("idRoot"))
        Catch ex As Exception
            claveRoot = 0
        End Try

        If claveRoot > 0 Then Return claveRoot

        Try
            claveRoot = CInt(hiddenIdRoot.Value)
        Catch ex As Exception
        End Try

        If claveRoot < 0 Then claveRoot = 0

        Return claveRoot
    End Function

    Public claveSalon As Integer = 0

    Private Function getIdSalonVirtual() As Integer
        Dim idSalonVirtual As Integer
        Try
            idSalonVirtual = CInt(Request("idSalonVirtual"))
            claveSalon = idSalonVirtual

        Catch ex As Exception
            idSalonVirtual = 0
        End Try

        If idSalonVirtual < 0 Then idSalonVirtual = 0

        Return idSalonVirtual
    End Function

    Private Function getIdCI() As Integer
        Dim idCI As Integer
        Try
            idCI = CInt(Request("idCI"))
        Catch ex As Exception
            idCI = 0
        End Try

        If idCI < 0 Then idCI = 0

        Return idCI
    End Function

    Private Function getIdClasificacion() As Integer
        Dim idClasificacion As Integer
        Try
            idClasificacion = CInt(Request("idClasificacion"))
        Catch ex As Exception
            idClasificacion = 0
        End Try

        If idClasificacion < 0 Then idClasificacion = 0

        Return idClasificacion
    End Function

    Private Function getIdActividad() As Integer
        Dim idActividad As Integer
        Try
            idActividad = CInt(Request("idA"))
        Catch ex As Exception
            idActividad = 0
        End Try

        If idActividad < 0 Then idActividad = 0

        Return idActividad
    End Function



    Private Function getModoEdicion() As Boolean
        Dim modoEdicion As Boolean
        Try
            modoEdicion = CBool(hiddenModoEdicion.Value)
        Catch ex As Exception
        End Try

        Return modoEdicion
    End Function

    Private Function getModoVistaPrevia() As Boolean
        Dim modoVistaPrevia As Boolean
        Try
            modoVistaPrevia = CBool(hiddenModoVistaPrevia.Value)
        Catch ex As Exception
        End Try

        Return modoVistaPrevia
    End Function

    Public Function esMaestro() As Boolean
        Dim objSalonVirtual As New Know.SalonVirtual(getIdSalonVirtual, False)
        Dim objUsuarios As New MasUsuarios.UserProfile(CInt(Session("gUserProfileSession").idUserProfile), False)

        Return New MasUsuarios.Permiso(objUsuarios, objSalonVirtual).existe
    End Function

    Protected Function getLinkClasificacion(idRoot As Integer, idClasificacion As Integer) As String
        Dim modoEdicion As Boolean = getModoEdicion()

        If getModoEdicion() Then

            If getModoVistaPrevia() Then
                Return "~/Sec/Workbook/VerCarpeta.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & "&idSalonVirtual=" & Request("idSalonVirtual")
            Else
                Return "~/Sec/Workbook/AddCarpeta.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion
            End If

        Else
            Return "~/Sec/SalonVirtual/VerCarpeta.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idClasificacion=" & idClasificacion
        End If
    End Function

    Protected Function getLinkAnexos(idRoot As Integer, idClasificacionItem As Integer, idClasificacion As Integer, tipoAnexo As String, idTipo As Integer) As String
        Dim modoEdicion As Boolean = getModoEdicion()

        Dim filePath, file, proc As String

        If modoEdicion Then
            filePath = "~/Sec/Workbook/"

            If getModoVistaPrevia() Then

                Select Case tipoAnexo
                    Case "Contenido"
                        file = "verTexto.aspx"
                        proc = "Contenido"

                    Case "Actividad"
                        file = "verActividad.aspx"
                        proc = "Actividad"

                    Case "Examen"
                        file = "verExamen.aspx"
                        proc = "Examen"

                    Case "Foro"
                        file = "verForo.aspx"
                        proc = "Foro"
                End Select

            Else
                Select Case tipoAnexo
                    Case "Contenido"
                        'file = "Texto.aspx"
                        file = "AddContenido.aspx"
                        Select Case idTipo
                            Case Contenidos.TipoContenido.Archivo
                                proc = "Archivo"
                            Case Contenidos.TipoContenido.Flash
                                proc = "Flash"
                            Case Contenidos.TipoContenido.Imagen
                                proc = "Imagen"
                            Case Contenidos.TipoContenido.Texto
                                proc = "Contenido"
                        End Select
                    Case "Actividad"
                        file = "Actividad.aspx"
                        proc = "Actividad"
                    Case "Examen"
                        file = "Examen.aspx"
                        proc = "Examen"
                    Case "Foro"
                        file = "Foro.aspx"
                        proc = "Foro"
                End Select
            End If

            Return filePath & file & "?idRoot=" & idRoot & "&idCI=" & idClasificacionItem & "&idClasificacion=" & idClasificacion & "&proc=" & proc

        Else

            filePath = "~/Sec/SalonVirtual/"
            Select Case tipoAnexo
                Case "Contenido"
                    file = "verTexto.aspx"
                Case "Actividad"
                    file = "verActividad.aspx"
                Case "Examen"
                    file = "verExamen.aspx"
                Case "Foro"
                    file = "verForo.aspx"
            End Select

            Return filePath & file & "?idSalonVirtual=" & getIdSalonVirtual() & "&idCI=" & idClasificacionItem & "&idClasificacion=" & idClasificacion

        End If

    End Function

    Protected Function getLinkDiagnostico(idRoot As Integer, idClasificacion As Integer, idActividad As Integer) As String
        If getModoEdicion() Then
            If getModoVistaPrevia() Then
                Return "~/Sec/Workbook/verExamen.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & "&idA=" & idActividad & "&idSalonVirtual=" & getIdSalonVirtual()
            Else
                Return "~/Sec/Workbook/Examen.aspx?idRoot=" & idRoot & "&idClasificacion=" & idClasificacion & "&idA=" & idActividad & "&idSalonVirtual=" & getIdSalonVirtual()
            End If
        Else
            Return "~/Sec/SalonVirtual/verExamen.aspx?idSalonVirtual=" & getIdSalonVirtual() & "&idClasificacion=" & idClasificacion & "&idA=" & idActividad
        End If
    End Function

    Protected Function getVisible(idActividad As Integer, senderLink As Boolean) As Boolean
        If idActividad > 0 Then
            Return senderLink
        Else
            Return Not senderLink
        End If
    End Function

    Protected Function getEstilo(idRoot As Integer, idClasificacion As Integer, idClasificacionItem As Integer, esAnexo As Boolean, Optional idActividad As Integer = 0) As String
        If esAnexo Then

            If idActividad > 0 Then
                If idActividad = getIdActividad() Then Return "vino12"
            Else
                If getIdCI() > 0 And idClasificacionItem = getIdCI() Then Return "vino12"
            End If

        Else
            Dim reqIdRoot As Integer = getIdRoot()
            If reqIdRoot = 0 Then
                Try
                    reqIdRoot = CInt(hiddenIdRoot.Value)
                Catch ex As Exception
                End Try
            End If

            If idClasificacion = getIdClasificacion() And idRoot = reqIdRoot Then Return "vino12"
        End If

        Return "linkMenu12"
    End Function

    Protected Function getEnabled(idRoot As Integer, idClasificacion As Integer, idClasificacionItem As Integer, esAnexo As Boolean, Optional idActividad As Integer = 0) As Boolean
        If getEstilo(idRoot, idClasificacion, idClasificacionItem, esAnexo, idActividad) = "vino12" Then Return False

        Return True
    End Function

    Protected Function getImagen(idRoot As Integer, idClasificacion As Integer, idClasificacionItem As Integer, esAnexo As Boolean, Optional idActividad As Integer = 0) As String
        If getEstilo(idRoot, idClasificacion, idClasificacionItem, esAnexo, idActividad) = "vino12" Then Return "flechaVino.png"

        Return "bull-arrow3.png"
    End Function

    'Protected Sub repeaterClasificaciones_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repeaterClasificaciones.ItemDataBound
    '	If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
    '		Dim dView As Data.DataView = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionContenido")
    '		CType(e.Item.FindControl("listViewContenidos"), ListView).DataSource = dView
    '		CType(e.Item.FindControl("listViewContenidos"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewActividades"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionActividad")
    '		CType(e.Item.FindControl("listViewActividades"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewExamenes"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionExamen")
    '		CType(e.Item.FindControl("listViewExamenes"), ListView).DataBind()

    '		CType(e.Item.FindControl("listViewForos"), ListView).DataSource = CType(e.Item.DataItem, DataRowView).CreateChildView("ClasificacionForo")
    '		CType(e.Item.FindControl("listViewForos"), ListView).DataBind()
    '	End If

    'End Sub


End Class
