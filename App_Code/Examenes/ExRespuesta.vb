Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Namespace Examenes
	Public NotInheritable Class ExRespuesta
		Inherits DBObject

#Region "Variables"
		Private idExRespuesta As Integer
		Public idPregunta As Integer
		Public idSalonVirtual As Integer
		Public idUserProfile As Integer
		Public respuesta As String = String.Empty
		Public idORSeleccionada As Integer
		Public valorObtenido As Decimal
        Public fecha As Date = Date.Now


		Private varExiste As Boolean = False
#End Region

#Region "Propiedades implementadas de DBOBject"
		Public Overrides ReadOnly Property id() As Integer
			Get
				Return Me.idExRespuesta
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.ExRespuesta
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT [ExRespuestas].* FROM [ExRespuestas] WHERE ([ExRespuestas].[idExRespuesta] = @idExRespuesta)"

			Dim parameters As SqlParameter() = {New SqlParameter("@idExRespuesta", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idExRespuesta = CType(dr("idExRespuesta"), Integer)
				Me.idPregunta = CType(dr("idPregunta"), Integer)
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.respuesta = CType(dr("Respuesta"), String)
				Me.idORSeleccionada = CType(dr("idORSeleccionada"), Integer)
				Me.fecha = CType(dr("Fecha"), Date)
				Me.valorObtenido = CType(dr("valorObtenido"), Decimal)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub

		Sub New(ByVal clavePregunta As Integer, ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer)
			Dim queryString As String = "SELECT [ExRespuestas].* FROM [ExRespuestas] WHERE (([ExRespuestas].[idPregunta] =@idPregunta) " & _
			 " AND ([ExRespuestas].[idSalonVirtual] = @idSalonVirtual) AND ([ExRespuestas].[idUserProfile] = @idUserProfile))"

			Dim parameters As SqlParameter() = { _
			 New SqlParameter("@idPregunta", clavePregunta), _
			 New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
			 New SqlParameter("@idUserProfile", claveUserProfile)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idExRespuesta = CType(dr("idExRespuesta"), Integer)
				Me.idPregunta = CType(dr("idPregunta"), Integer)
				Me.idSalonVirtual = CType(dr("idSalonVirtual"), Integer)
				Me.idUserProfile = CType(dr("idUserProfile"), Integer)
				Me.respuesta = CType(dr("Respuesta"), String)
				Me.idORSeleccionada = CType(dr("idORSeleccionada"), Integer)
				Me.fecha = CType(dr("Fecha"), Date)
				Me.valorObtenido = CType(dr("valorObtenido"), Decimal)
				Me.varExiste = True
			End If
			dr.Close()
		End Sub
#End Region

        Public Overrides Function Add() As Integer
			Try
				Dim queryString As String = "INSERT INTO [ExRespuestas] ([idPregunta], [idSalonVirtual], [idUserProfile], [respuesta], " & _
				 "[idORSeleccionada], [valorObtenido], [fecha]) VALUES (@idPregunta, @idSalonVirtual, @idUserProfile, " & _
				 "@Respuesta, @idORSeleccionada, @valorObtenido, @fecha)"

				Dim parametros As SqlParameter() = { _
				 New SqlParameter("@idPregunta", Me.idPregunta), _
				  New SqlParameter("@idSalonVirtual", Me.idSalonVirtual), _
				  New SqlParameter("@idUserProfile", Me.idUserProfile), _
				  New SqlParameter("@respuesta", Me.respuesta), _
				  New SqlParameter("@idORSeleccionada", Me.idORSeleccionada), _
				  New SqlParameter("@valorObtenido", Me.valorObtenido), _
				  New SqlParameter("@fecha", Me.fecha)}

				If New ExRespuesta(idPregunta, idSalonVirtual, idUserProfile).existe Then
					Me.Update()
				Else
					Me.idExRespuesta = Me.ExecuteNonQuery(queryString, parametros, True)
				End If

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
				Dim queryString As String = "UPDATE [ExRespuestas] SET [respuesta]=@respuesta, [idORSeleccionada]=@idORSeleccionada, " & _
				 "[valorObtenido]=@valorObtenido, [fecha]=@fecha WHERE ([idExRespuesta] = @idExRespuesta)"

                Dim parametros As SqlParameter() = { _
                 New SqlParameter("@idExRespuesta", Me.idExRespuesta), _
                  New SqlParameter("@respuesta", Me.respuesta), _
                  New SqlParameter("@idORSeleccionada", Me.idORSeleccionada), _
                  New SqlParameter("@valorObtenido", Me.valorObtenido), _
                  New SqlParameter("@fecha", Me.fecha)}

                If Me.idExRespuesta > 0 Then
                    Return Me.ExecuteNonQuery(queryString, parametros)
                Else
                    Return 0
                End If


			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
            Dim queryString As String = "DELETE ExRespuestas WHERE idExRespuesta = @idExRespuesta"
            Dim parametros As SqlParameter() = {New SqlParameter("@idExRespuesta", Me.idExRespuesta)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function


        Public Overloads Function Remove(ByVal clavePregunta As Integer) As Integer
            Dim queryString As String = "DELETE ExRespuestas WHERE idPregunta = @idPregunta"
            Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function


		Public Overloads Overrides Function GetDR() As SqlDataReader
			Return Nothing
		End Function

		Public Overloads Function GetDR(ByVal clavePregunta As Integer) As System.Data.IDataReader
			Dim queryString As String = "SELECT idPregunta, idExRespuesta FROM ExRespuestas WHERE idPregunta = @idPregunta"

			Dim parametros As SqlParameter() = {New SqlParameter("@idPregunta", clavePregunta)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overloads Function GetDR(ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer, ByVal claveActividad As Integer, ByVal FormaOrden As String) As Data.SqlClient.SqlDataReader
            Dim queryString As String = "select ex.* from exrespuestas ex, preguntas p, actividades a " & _
   " where p.idPregunta = ex.idPregunta And p.idActividad = a.idactividad and a.idactividad = @idActividad and " & _
   " ex.idsalonVirtual = @idSalonVirtual and ex.idUserProfile = @idUserProfile  order by ex.fecha " & FormaOrden

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
			 New SqlParameter("@idUserProfile", claveUserProfile), _
			 New SqlParameter("@idActividad", claveActividad)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overloads Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overloads Function Count(ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer, ByVal claveActividad As Integer) As Integer
            Dim queryString As String = "select count(ex.idExRespuesta) as num from exrespuestas ex, preguntas p, actividades a " & _
    "where p.idPregunta = ex.idPregunta And p.idActividad = a.idactividad and a.idactividad = @idActividad and ex.idsalonVirtual = @idSalonVirtual " & _
    "and ex.idUserProfile = @idUserProfile "

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
			 New SqlParameter("@idUserProfile", claveUserProfile), _
			 New SqlParameter("@idActividad", claveActividad)}

			Dim dr As System.Data.IDataReader = Me.ExecuteReader(queryString, parametros)
			Dim numero As Integer = 0

			If dr.Read Then
				If Not Convert.IsDBNull(dr("num")) Then
                    numero = CType(dr("num"), Decimal)
                End If
			End If
			dr.Close()

			Return numero
		End Function

		Public Overrides Function EnUso() As Boolean
			Dim dr As SqlClient.SqlDataReader = Me.GetDR(Me.idPregunta)
			Dim regresar As Boolean = dr.HasRows
			dr.Close()

			Return regresar
		End Function

		Public Function AutoCalificarRespuesta() As Integer
			Dim objPregunta As New Pregunta(Me.idPregunta)

			Select Case objPregunta.tipoPregunta
                Case Examenes.ETipoPregunta.Directa

                Case Examenes.ETipoPregunta.Desarrollo

                Case Examenes.ETipoPregunta.FalsoVerdadero
                    If Me.idORSeleccionada = objPregunta.idOR Then
                        Me.valorObtenido = objPregunta.valor
                    Else
                        Me.valorObtenido = 0
                    End If

                Case Examenes.ETipoPregunta.OpcionMultiple
                    If Me.idORSeleccionada = objPregunta.idOR Then
                        Me.valorObtenido = objPregunta.valor
                    Else
                        Me.valorObtenido = 0
                    End If

                Case Examenes.ETipoPregunta.RelacionColumnas
                    Dim myexrop As New ExRespuestaOP
                    Dim myop As New OpcionPregunta
                    Dim numAciertos As Integer = myexrop.GetAciertos(objPregunta.id, Me.idExRespuesta)
                    Try
                        Me.valorObtenido = (numAciertos * objPregunta.valor) / myop.Count(objPregunta.id)
                    Finally
                    End Try

            End Select

            Me.Update()
        End Function

        Function GetSumaValorObtenido(ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer, ByVal claveActividad As Integer) As Decimal
            Dim queryString As String = "select sum(ex.valorObtenido) as num from exrespuestas ex, preguntas p, actividades a " & _
   "where p.idPregunta = ex.idPregunta And p.idActividad = a.idactividad and a.idactividad = @idActividad " & _
   "and ex.idsalonVirtual = @idSalonVirtual and ex.idUserProfile = @idUserProfile "

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idSalonVirtual", claveSalonVirtual), _
             New SqlParameter("@idUserProfile", claveUserProfile), _
             New SqlParameter("@idActividad", claveActividad)}

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

        Function GetPrimeraRespuesta(ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer, ByVal claveActividad As Integer) As Date
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveSalonVirtual, claveUserProfile, claveActividad, "asc")
            Dim myfecha As Date = Date.Now
            If dr.Read Then
                myfecha = CType(dr("fecha"), Date)
            End If
            dr.Close()

            Return myfecha
        End Function

        Function GetUltimaRespuesta(ByVal claveSalonVirtual As Integer, ByVal claveUserProfile As Integer, ByVal claveActividad As Integer) As Date
            Dim dr As SqlClient.SqlDataReader = Me.GetDR(claveSalonVirtual, claveUserProfile, claveActividad, "desc")
            Dim myfecha As Date = Date.Now
            If dr.Read Then
                myfecha = CType(dr("fecha"), Date)
            End If
            dr.Close()

            Return myfecha
        End Function

        Public Function GetElementosSeleccionados(ByVal claveRespuesta As Integer) As SqlClient.SqlDataReader
            Dim queryString As String = "select op.enunciado as enunciadoop, exor.enunciado as enunciadoor, op.idor as idcorrecta, rop.* " & _
              " from exrespuestasop rop, opcionespregunta op, opcionesrespuesta exor " & _
              " where rop.idOP = op.idOP and exor.idor = rop.idorseleccionada and rop.idExrespuesta = @idExrespuesta "

            Dim parametros As SqlParameter() = {New SqlParameter("@idExrespuesta", claveRespuesta)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        '+++++++++ MODIFICADA: Regresaba una cadena y ahora devuelve un webcontrol.table +++++++++++++++
        Function GetTablaRelacionColumnas(ByVal clavePregunta As Integer, ByVal claveRespuesta As Integer, ByVal estiloCeldaIzq As String, ByVal estiloCeldaDer As String) As Table
            Dim dr As SqlClient.SqlDataReader = Me.GetElementosSeleccionados(claveRespuesta)
            Dim respuesta As Examenes.OpcionRespuesta
            Dim tabla As New Table
            Dim tr As TableRow
            Dim tdL As TableCell
            Dim tdR As TableCell

            tabla.CellPadding = 1 : tabla.CellSpacing = 1 : tabla.Width = New Unit("100%") : tabla.BorderWidth = 0
            If claveRespuesta > 0 Then

                Do While dr.Read
                    tr = New TableRow
                    tdL = New TableCell
                    tdR = New TableCell

                    Dim lblEnunciadoOP As New Label
                    Dim lblEnunciadoOR As New Label
                    Dim lblEnunciado As New Label

                    respuesta = New OpcionRespuesta(CInt(dr("idCorrecta")))
                    lblEnunciadoOP.Text = CStr(dr("enunciadoop"))
                    lblEnunciadoOR.Text = CStr(dr("enunciadoor")) & "<br>"
                    lblEnunciado.Text = respuesta.enunciado : lblEnunciado.ForeColor = System.Drawing.Color.Red

                    tdL.Width = New Unit("50%")
                    tdL.VerticalAlign = VerticalAlign.Top
                    tdL.CssClass = estiloCeldaIzq 'textoSmallObscuro
                    tdL.Controls.Add(lblEnunciadoOP)

                    tdR.Width = New Unit("50%")
                    tdR.VerticalAlign = VerticalAlign.Top
                    tdR.CssClass = estiloCeldaDer 'textoSmall

                    tdR.Controls.Add(lblEnunciadoOR)
                    tdR.Controls.Add(lblEnunciado)

                    tr.Cells.Add(tdL)
                    tr.Cells.Add(tdR)
                    tabla.Rows.Add(tr)
                Loop
                dr.Close()

            End If
            Return tabla
        End Function

        Function GetTablaRelacionColumnas(ByVal claveRespuesta As Integer, ByVal esmaestro As Boolean) As String
            Dim dr As SqlClient.SqlDataReader = Me.GetElementosSeleccionados(claveRespuesta)

            Dim supercadena As String = "<TABLE  cellSpacing='1' cellPadding='1' width='100%' border='0'>"
            Dim respuesta As Examenes.OpcionRespuesta
            Do While dr.Read
                supercadena = supercadena & "<tr>"
                supercadena = supercadena & "<td with='50%' valign='top' class='textoSmallObscuro'>" & Convert.ToString(dr("enunciadoop")) & "</td>"
                respuesta = New Examenes.OpcionRespuesta(CType(dr("idcorrecta"), Integer))
                If esmaestro Then
                    supercadena = supercadena & "<td with='50%' valign='top' class='textoSmall'>" & Convert.ToString(dr("enunciadoor")) & "<br><font color='red'>" & respuesta.enunciado & "</font></td>"
                Else
                    supercadena = supercadena & "<td with='50%' valign='top' class='textoSmall'>" & Convert.ToString(dr("enunciadoor")) & "</td>"
                End If
                supercadena = supercadena & "</tr>"
            Loop
            supercadena = supercadena & "</Table>"
            dr.Close()
            Return supercadena
        End Function

		'++++++++++++  DEPRECATED: usar EnUso() +++++++++++++++
		Public Function HayRespuestas(ByVal clavePregunta As Integer) As Boolean
			Dim dr As SqlClient.SqlDataReader = Me.GetDR(clavePregunta)
			Dim regresar As Boolean = dr.HasRows
			dr.Close()

			Return regresar
		End Function

    End Class
End Namespace

