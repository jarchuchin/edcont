Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Examenes
	Public NotInheritable Class Pregunta
		Inherits DBObject

        Private idPregunta As Integer
        Public idActividad As Integer
        Public idUserProfile As Integer
        Public idOR As Integer
        Public tipoPregunta As Integer
        Public enunciado As String
        Public archivo As Integer
        Public valor As Decimal
        Public orden As Integer
        Public respuesta As String = String.Empty
        Public Eliminado As Boolean = False
        Public fileName As String = ""

        Private varExiste As Boolean = False


        Public Overrides ReadOnly Property id() As Integer
            Get
                Return Me.idPregunta
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Public Overrides ReadOnly Property tipo() As tipoObjeto
            Get
                Return tipoObjeto.Pregunta
            End Get
        End Property



        Public Sub New()
        End Sub

        Public Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Preguntas WHERE idPregunta = @idPregunta"

            Dim parameters As SqlParameter() = {New SqlParameter("@idPregunta", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
            If dr.Read Then
                Me.idPregunta = CType(dr("idPregunta"), Integer)
                Me.idActividad = CType(dr("idActividad"), Integer)
                Me.idUserProfile = CType(dr("idUserProfile"), Integer)
                Me.idOR = CType(dr("idOR"), Integer)
                Me.tipoPregunta = CType(dr("tipoPregunta"), Integer)
                Me.enunciado = CType(dr("enunciado"), String)
                Me.archivo = CType(dr("archivo"), Integer)
                Me.valor = CType(dr("valor"), Decimal)
                Me.orden = CType(dr("orden"), Integer)
                Me.varExiste = True
                If Not IsDBNull(dr("respuesta")) Then
                    Me.respuesta = CType(dr("respuesta"), String)
                End If
                Me.Eliminado = CType(dr("Eliminado"), Boolean)

                If Not Convert.IsDBNull(dr("fileName")) Then
                    Me.fileName = dr("fileName")
                Else
                    Me.fileName = ""
                End If

            End If
            dr.Close()

        End Sub


#Region "Acceso a datos"
        Public Overrides Function Add() As Integer
            Try
                Dim queryString As String = "INSERT INTO [Preguntas] ([idActividad], [idUserProfile], [idOR], [tipoPregunta], " & _
                 "[enunciado], [archivo], [valor], [orden], respuesta, eliminado, fileName) VALUES (@idActividad, @idUserProfile, @idOR, @tipoPregunta, " & _
                 "@enunciado, @archivo, @valor, @orden, @respuesta, @eliminado, @fileName)"
                Me.orden = Me.GetOrden
                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idActividad", Me.idActividad), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@idOR", Me.idOR), _
                  New SqlParameter("@tipoPregunta", Me.tipoPregunta), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                  New SqlParameter("@valor", Me.valor), _
                  New SqlParameter("@orden", Me.orden), _
                  New SqlParameter("@respuesta", Me.respuesta), _
                New SqlParameter("@eliminado", Me.Eliminado), _
                              New SqlParameter("@fileName", Me.fileName)}

                Me.idPregunta = Me.ExecuteNonQuery(queryString, parametros, True)

                Me.UpdateValores(Me.idActividad)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

            Return 0
        End Function

        Public Overrides Function Update() As Integer
            Try
                Dim queryString As String = "UPDATE [Preguntas] SET [idUserProfile]=@idUserProfile, [idOR]=@idOR, [enunciado]=@enunciado, " & _
                 "[archivo]=@archivo, [valor]=@valor, [orden]=@orden, respuesta=@respuesta, eliminado=@eliminado, fileName=@fileName WHERE idPregunta = @idPregunta"

                Dim parametros As SqlParameter() = { _
                  New SqlParameter("@idPregunta", Me.idPregunta), _
                  New SqlParameter("@idUserProfile", Me.idUserProfile), _
                  New SqlParameter("@idOR", Me.idOR), _
                  New SqlParameter("@enunciado", Me.enunciado), _
                  New SqlParameter("@archivo", Me.archivo), _
                  New SqlParameter("@valor", Me.valor), _
                  New SqlParameter("@orden", Me.orden), _
                  New SqlParameter("@respuesta", Me.respuesta), _
                New SqlParameter("@eliminado", Me.Eliminado), _
                              New SqlParameter("@fileName", Me.fileName)}

                Dim numero As Integer = Me.ExecuteNonQuery(queryString, parametros)
                Me.UpdateValores(Me.idActividad)

                Return numero

            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overrides Function Remove() As Integer

            Me.Eliminado = True
            Me.Update()

            Dim myexr As New Examenes.ExRespuesta
            myexr.Remove(Me.idPregunta)

            'Dim queryString As String = "DELETE FROM [Preguntas] WHERE ([Preguntas].[idPregunta] = @idPregunta)"

            'Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", Me.idPregunta)}

            'Try
            '    Dim resultado As Integer = Me.ExecuteNonQuery(queryString, parametros)
            '    UpdateValores(Me.idActividad)

            '    Select Case Me.tipoPregunta
            '        Case Examenes.ETipoPregunta.OpcionMultiple
            '            Dim myOR As New Examenes.OpcionRespuesta
            '            myOR.Remove(Me.idPregunta)
            '        Case Examenes.ETipoPregunta.RelacionColumnas
            '            Dim myOR As New Examenes.OpcionRespuesta
            '            myOR.Remove(Me.idPregunta)
            '            Dim myOP As New Examenes.OpcionPregunta
            '            myOP.Remove(Me.idPregunta)
            '    End Select

            '    Return resultado
            'Catch ex As Exception

            'End Try

            Return 0
        End Function

        Public Overloads Overrides Function GetDR() As SqlDataReader
            Return Nothing
        End Function

        Public Overloads Function GetDR(ByVal claveActividad As Integer) As System.Data.IDataReader
            Dim queryString As String = "SELECT* FROM Preguntas WHERE idActividad = @idActividad and eliminado=0 ORDER BY orden ASC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetDRAleatorio(ByVal claveActividad As Integer) As String
            Dim queryString As String = "SELECT   * FROM Preguntas WHERE idActividad = @idActividad and eliminado=0 ORDER BY newid()"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim cadena As String = ""
            Do While dr.Read
                If cadena = "" Then
                    cadena = dr("idPregunta")
                Else
                    cadena = cadena & "," & dr("idPregunta")
                End If
            Loop
            dr.Close()

            Return cadena
        End Function

        Public Function GetDRAleatorioNumPreguntas(ByVal claveActividad As Integer, totalPreguntas As Integer) As String
            Dim queryString As String = "SELECT  top " & totalPreguntas & " * FROM Preguntas WHERE idActividad = @idActividad and eliminado=0 ORDER BY  newid()"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim cadena As String = ""
            Do While dr.Read
                If cadena = "" Then
                    cadena = dr("idPregunta")
                Else
                    cadena = cadena & "," & dr("idPregunta")
                End If
            Loop
            dr.Close()

            Return cadena
        End Function

        Public Overloads Function GetDR(ByVal claveActividad As Integer, ByVal ordenASC As Boolean) As System.Data.IDataReader
            Dim queryString As String = "SELECT * FROM Preguntas WHERE idActividad = @idActividad and eliminado=0  "
            If ordenASC Then
                queryString = queryString & " ORDER BY orden ASC"
            Else
                queryString = queryString & " ORDER BY orden DESC"
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveClassificacionItem As Integer, ByVal claveOrden As Integer, ByVal signoOrden As SignoOrden, Optional ByVal ordenASC As Boolean = True) As System.Data.IDataReader
            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(claveClassificacionItem)
            Dim queryString As String = "SELECT * FROM Preguntas  WHERE  eliminado=0 and idActividad = @idActividad "
            Select Case signoOrden
                Case Examenes.SignoOrden.mayorque
                    queryString = queryString & " AND orden > @orden "
                Case Examenes.SignoOrden.menorque
                    queryString = queryString & " AND orden < @orden "
                Case Examenes.SignoOrden.igualque
                    queryString = queryString & " AND orden = @orden "
            End Select

            If ordenASC Then
                queryString = queryString & " ORDER BY orden ASC"
            Else
                queryString = queryString & " ORDER BY orden DESC"
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", myci.idProc), New SqlParameter("@orden", claveOrden)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overloads Function GetDRActividad(ByVal claveActividad As Integer, ByVal claveOrden As Integer, ByVal signoOrden As SignoOrden, Optional ByVal ordenASC As Boolean = True) As System.Data.IDataReader
            ' Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(claveClassificacionItem)
            Dim queryString As String = "SELECT * FROM Preguntas  WHERE  eliminado=0 and idActividad = @idActividad "
            Select Case signoOrden
                Case Examenes.SignoOrden.mayorque
                    queryString = queryString & " AND orden > @orden "
                Case Examenes.SignoOrden.menorque
                    queryString = queryString & " AND orden < @orden "
                Case Examenes.SignoOrden.igualque
                    queryString = queryString & " AND orden = @orden "
            End Select

            If ordenASC Then
                queryString = queryString & " ORDER BY orden ASC"
            Else
                queryString = queryString & " ORDER BY orden DESC"
            End If

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad), New SqlParameter("@orden", claveOrden)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Overrides Function GetDS() As System.Data.DataSet
            Return Nothing
        End Function

        Public Overloads Function GetDS(ByVal claveActividad As Integer) As System.Data.DataSet
            Dim queryString As String = "SELECT * FROM Preguntas WHERE idActividad = @idActividad and eliminado=0 ORDER BY orden ASC"

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Overrides Function Count() As Integer
            Return 0
        End Function

        Public Overloads Function Count(ByVal claveActividad As Integer) As Integer
            Dim queryString As String = "SELECT count(valor) as num FROM Preguntas WHERE idActividad = @idActividad  and eliminado=0 "

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Integer = 0

            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Integer)
                End If
            End If
            dr.Close()

            Return numero
        End Function

        Public Overrides Function EnUso() As Boolean
            'Dim objExRespuestas As New ExRespuesta
            'objExRespuestas.idPregunta = Me.idPregunta

            Return False
        End Function

        Public Function GetOrden() As Integer
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(Me.idActividad, False)
            Dim numero As Integer = 0
            If dr.Read Then
                numero = CType(dr("Orden"), Integer) + 1
            Else
                numero = 1
            End If
            dr.Close()
            Return numero
        End Function

        Public Function MoveArriba() As Integer
            If Me.orden > 0 Then
                Dim dr As System.Data.IDataReader = Me.GetDRActividad(Me.idActividad, Me.orden, SignoOrden.menorque, False)
                If dr.Read Then
                    Dim claveTemp, ordenTemp As Integer
                    claveTemp = CType(dr("idPregunta"), Integer)
                    ordenTemp = Me.orden

                    Dim objPregunta As New Pregunta(claveTemp)
                    objPregunta.orden = ordenTemp
                    objPregunta.Update()

                    Me.orden = CType(dr("orden"), Integer)
                    Me.Update()
                End If
                dr.Close()

            End If
        End Function

        Public Function MoveAbajo() As Integer
            Dim dr As System.Data.IDataReader = Me.GetDRActividad(Me.idActividad, Me.orden, SignoOrden.mayorque)
            If dr.Read Then
                Dim claveTemp, ordenTemp As Integer
                claveTemp = CType(dr("idPregunta"), Integer)
                ordenTemp = Me.orden

                Dim objPregunta As New Pregunta(claveTemp)
                objPregunta.orden = ordenTemp
                objPregunta.Update()

                Me.orden = CType(dr("orden"), Integer)
                Me.Update()
            End If
            dr.Close()

        End Function

        Function GetSuma(ByVal claveActividad As Integer) As Decimal
            Dim queryString As String = "SELECT sum(valor) as num FROM Preguntas  WHERE idActividad = @idActividad  and eliminado=0 "

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim numero As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Decimal)
                End If
            End If
            dr.Close()

            Return numero
        End Function


        Public Function GetSiguiente(ByVal claveCI As Integer, ByVal claveSalon As Integer, claveUsuario As Integer) As String
            Dim myci As New Lego.ClasificacionItem(claveCI)
            Dim mya As New Contenidos.Actividad(myci.idProc)
            Dim myoe As New Examenes.ExOrden(mya.id, claveSalon, claveUsuario)


            Dim cadena As String = "?idCI=" & claveCI & "&idSalonVirtual=" & claveSalon


            If myoe.existe Then
                Dim cad() As String = myoe.Orden.Split(",")
                Dim clavePregunta As String = ""

                For i As Integer = 0 To cad.Length - 1
                    If Me.idPregunta = CInt(cad(i)) Then

                        If i = (cad.Length - 1) Then
                            cadena = "TerminarExamen.aspx" & cadena
                        Else
                            Dim myptemp As New Pregunta(CInt(cad(i + 1)))
                            cadena = cadena & "&idP=" & myptemp.id

                            Select Case myptemp.tipoPregunta
                                Case Examenes.ETipoPregunta.Directa
                                    cadena = "contestarDirecta.aspx" & cadena

                                Case Examenes.ETipoPregunta.Desarrollo
                                    cadena = "contestarDirecta.aspx" & cadena

                                Case Examenes.ETipoPregunta.FalsoVerdadero
                                    cadena = "contestarFalsoVerdadero.aspx" & cadena

                                Case Examenes.ETipoPregunta.OpcionMultiple
                                    cadena = "contestarOpcionMultiple.aspx" & cadena

                                Case Examenes.ETipoPregunta.RelacionColumnas
                                    cadena = "contestarRelacionColumnas.aspx" & cadena

                            End Select


                        End If

                        Exit For
                    End If


                Next



            Else
                Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveCI, Me.orden, SignoOrden.mayorque)

                If dr.Read Then
                    Dim objPregunta As New Pregunta(CType(dr("idPregunta"), Integer))
                    cadena = cadena & "&idP=" & objPregunta.idPregunta

                    Select Case objPregunta.tipoPregunta
                        Case Examenes.ETipoPregunta.Directa
                            cadena = "contestarDirecta.aspx" & cadena

                        Case Examenes.ETipoPregunta.Desarrollo
                            cadena = "contestarDirecta.aspx" & cadena

                        Case Examenes.ETipoPregunta.FalsoVerdadero
                            cadena = "contestarFalsoVerdadero.aspx" & cadena

                        Case Examenes.ETipoPregunta.OpcionMultiple
                            cadena = "contestarOpcionMultiple.aspx" & cadena

                        Case Examenes.ETipoPregunta.RelacionColumnas
                            cadena = "contestarRelacionColumnas.aspx" & cadena

                    End Select

                Else
                    cadena = "TerminarExamen.aspx" & cadena
                End If
                dr.Close()
            End If




            Return cadena
        End Function

        '++++++++++++REVISAR++++++++++++++
        Public Function GetAnterior(ByVal claveCI As Integer, ByVal claveSalon As Integer, claveUsuario As Integer) As String
            Dim myci As Lego.ClasificacionItem = New Lego.ClasificacionItem(claveCI)
            Dim mya As New Contenidos.Actividad(myci.idProc)
            Dim myoe As New Examenes.ExOrden(mya.id, claveSalon, claveUsuario)
            Dim cadena As String = "?idCI=" & claveCI & "&idSalonVirtual=" & claveSalon


            If myoe.existe Then

                Dim cad() As String = myoe.Orden.Split(",")
                Dim clavePregunta As String = ""

                For i As Integer = 0 To cad.Length - 1
                    If Me.idPregunta = CInt(cad(i)) Then

                        If i = 0 Then
                            cadena = "ListaDePreguntasParaContestar.aspx" & cadena
                        Else
                            Dim myptemp As New Pregunta(CInt(cad(i - 1)))
                            cadena = cadena & "&idP=" & myptemp.id

                            Select Case myptemp.tipoPregunta
                                Case Examenes.ETipoPregunta.Directa
                                    cadena = "contestarDirecta.aspx" & cadena

                                Case Examenes.ETipoPregunta.Desarrollo
                                    cadena = "contestarDirecta.aspx" & cadena

                                Case Examenes.ETipoPregunta.FalsoVerdadero
                                    cadena = "contestarFalsoVerdadero.aspx" & cadena

                                Case Examenes.ETipoPregunta.OpcionMultiple
                                    cadena = "contestarOpcionMultiple.aspx" & cadena

                                Case Examenes.ETipoPregunta.RelacionColumnas
                                    cadena = "contestarRelacionColumnas.aspx" & cadena

                            End Select


                        End If

                        Exit For
                    End If


                Next

            Else


                Dim dr As SqlClient.SqlDataReader = Me.GetDR(myci.idProc, Me.orden, SignoOrden.menorque, False)


                If dr.Read Then
                    Dim objPregunta As New Pregunta(CType(dr("idPregunta"), Integer))
                    cadena = cadena & "&idP=" & objPregunta.idPregunta

                    Select Case objPregunta.tipoPregunta
                        Case Examenes.ETipoPregunta.Directa
                            cadena = "contestarDirecta.aspx" & cadena

                        Case Examenes.ETipoPregunta.Desarrollo
                            cadena = "contestarDesarrollo.aspx" & cadena

                        Case Examenes.ETipoPregunta.FalsoVerdadero
                            cadena = "contestarFalsoVerdadero.aspx" & cadena

                        Case Examenes.ETipoPregunta.OpcionMultiple
                            cadena = "contestarOpcionMultiple.aspx" & cadena

                        Case Examenes.ETipoPregunta.RelacionColumnas
                            cadena = "contestarRelacionColumnas.aspx" & cadena

                    End Select

                Else
                    cadena = "ListaDePreguntasParaContestar.aspx" & cadena
                End If
                dr.Close()

            End If



            Return cadena
        End Function

        '++++++++++++ DEPRECATED: Utilizar EnUso() ++++++++++++++++++
        Public Function SePuedeBorrar() As Boolean
            Dim objExRespuestas As New ExRespuesta
            objExRespuestas.idPregunta = Me.idPregunta

            Return Not objExRespuestas.EnUso
        End Function


        '++++++++++++REVISAR: FALTA PARÁMETRO!!!++++++++++++++
        Public Function HayPreguntasDirectasODesarrollo(ByVal claveActividad As Integer) As Boolean
            Dim queryString As String = "SELECT * FROM Preguntas WHERE idActividad = @idActividad and eliminado=0 " & _
             " AND (tipoPregunta = @tipoPregunta OR tipoPregunta = @tipoPregunta2) "

            Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad), _
                                                                                 New SqlParameter("@tipoPregunta", Examenes.ETipoPregunta.Directa), _
                                                                                 New SqlParameter("@tipoPregunta2", Examenes.ETipoPregunta.Desarrollo)}

            Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
            Dim regresas As Boolean = False

            If dr.Read Then
                regresas = True
            End If
            dr.Close()

            Return regresas
        End Function

        Public Function UpdateValores(ByVal claveActividad As Integer) As Integer
            Dim objActividad As New Contenidos.Actividad(claveActividad)

            'solo si la respuesta es automatica
            If objActividad.puntosPorRespuesta = Contenidos.EPuntosPorRespuesta.Automatica Then
                Dim valorPorPregunta As Decimal = objActividad.puntosTotales / Me.Count(claveActividad)

                Dim queryString As String = "UPDATE [Preguntas] SET [valor]=@valor WHERE idActividad = @idActividad  and eliminado=0"

                Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", claveActividad), New SqlParameter("@valor", valorPorPregunta)}

                Return Me.ExecuteNonQuery(queryString, parametros)
            End If
        End Function
#End Region
    End Class

#Region "Enumeraciones de la clase"
	Public Enum EFalsoVerdadero As Integer
		falso = -1
		verdadero = -2
	End Enum

	Public Enum ETipoPregunta As Byte
		Directa = 1
		Desarrollo = 2
		FalsoVerdadero = 3
		OpcionMultiple = 4
		RelacionColumnas = 5
	End Enum

	Public Enum SignoOrden As Byte
		mayorque
		menorque
		igualque
	End Enum
#End Region
End Namespace
