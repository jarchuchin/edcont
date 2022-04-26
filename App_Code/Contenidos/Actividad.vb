Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Namespace Contenidos
	Public NotInheritable Class Actividad
		Inherits DBObject


        Private idActividad As Integer
		Public titulo As String
		Public tipodeActividad As ETipodeActividad
		Public instrucciones As String
		Public respuesta As ERespuesta
		Public respuestaGrupal As Integer
		Public comoSeCalifica As EComoSeCalifica
		Public quienCalifica As EQuienCalifica
		Public mostrarRespuestas As Boolean
		Public mostrarCalificacion As Boolean
		Public mostrarObservaciones As Boolean
		Public puntosPorRespuesta As EPuntosPorRespuesta
		Public puntosTotales As Integer
		Public tiempoEnMinutos As Integer
		Public numeroSecciones As Integer = 0
        Public status As Boolean = True
        Public idUserProfile As Integer = 0
        Public fechaCreacion As DateTime
        Public Tags As String
        Public TipoX As String = ""
        Public Objetivo As String = ""
        Public idRubrica As Integer = 0
        Public Autoevaluacion As Boolean = False
        Public contestarSinAgenda As Boolean = False

        Public activarBanco As Boolean = False
        Public totalPreguntas As Integer = 0
        Public presentacionAleatoria As Boolean = False

        Public ParaInstructor As String = ""

        Private varExiste As Boolean = False


#Region "Propiedades implementadas de DBOBject"
        Public Overrides ReadOnly Property id() As Integer
			Get
				Return idActividad
			End Get
		End Property

		Public Overrides ReadOnly Property existe() As Boolean
			Get
				Return varExiste
			End Get
		End Property

		Public Overrides ReadOnly Property tipo() As tipoObjeto
			Get
				Return tipoObjeto.Actividad
			End Get
		End Property
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Public Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT * FROM Actividades WHERE idActividad = @idActividad"

			Dim parameters As SqlParameter() = {New SqlParameter("@idActividad", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parameters)
			If dr.Read Then
				Me.idActividad = clavePrincipal
				Me.titulo = CType(dr("titulo"), String)
				Me.tipodeActividad = CByte(dr("tipodeActividad"))
				Me.instrucciones = CType(dr("instrucciones"), String)
				Me.respuesta = CByte(dr("respuesta"))
				Me.respuestaGrupal = CType(dr("respuestaGrupal"), Integer)
				Me.comoSeCalifica = CByte(dr("comoSeCalifica"))
				Me.quienCalifica = CByte(dr("quienCalifica"))
				Me.mostrarRespuestas = CType(dr("mostrarRespuestas"), Boolean)
				Me.mostrarCalificacion = CType(dr("mostrarCalificacion"), Boolean)
				Me.mostrarObservaciones = CType(dr("mostrarObservaciones"), Boolean)
				Me.puntosPorRespuesta = CByte(dr("puntosPorRespuesta"))
				Me.puntosTotales = CType(dr("puntosTotales"), Integer)
				Me.tiempoEnMinutos = CType(dr("tiempoEnMinutos"), Integer)
				Me.numeroSecciones = CType(dr("numeroSecciones"), Integer)
                Me.status = CType(dr("numeroSecciones"), Boolean)

                If Not Convert.IsDBNull(dr("idUserProfile")) Then
                    Me.idUserProfile = CInt(dr("idUserProfile"))
                End If


                If Not Convert.IsDBNull(dr("fechaCreacion")) Then
                    Me.fechaCreacion = CType(dr("fechaCreacion"), DateTime)
                End If

                If Not Convert.IsDBNull(dr("Tags")) Then
                    Me.Tags = dr("Tags")
                Else
                    Me.Tags = ""
                End If

                If Not Convert.IsDBNull(dr("TipoX")) Then
                    Me.TipoX = dr("TipoX")
                Else
                    Me.TipoX = ""
                End If

                If Not Convert.IsDBNull(dr("Objetivo")) Then
                    Me.Objetivo = dr("Objetivo")
                Else
                    Me.Objetivo = ""
                End If

                If Not Convert.IsDBNull(dr("idRubrica")) Then
                    Me.idRubrica = CInt(dr("idRubrica"))
                Else
                    Me.idRubrica = 0
                End If


                If Not Convert.IsDBNull(dr("Autoevaluacion")) Then
                    Me.Autoevaluacion = CBool(dr("Autoevaluacion"))
                Else
                    Me.Autoevaluacion = False
                End If

                If Not Convert.IsDBNull(dr("contestarSinAgenda")) Then
                    Me.contestarSinAgenda = CBool(dr("contestarSinAgenda"))
                End If

                If Not Convert.IsDBNull(dr("activarBanco")) Then
                    Me.activarBanco = CBool(dr("activarBanco"))
                End If

                If Not Convert.IsDBNull(dr("totalPreguntas")) Then
                    Me.totalPreguntas = CInt(dr("totalPreguntas"))
                End If

                If Not Convert.IsDBNull(dr("presentacionAleatoria")) Then
                    Me.presentacionAleatoria = CBool(dr("presentacionAleatoria"))
                End If
                If Not Convert.IsDBNull(dr("ParaInstructor")) Then
                    Me.ParaInstructor = dr("ParaInstructor")
                End If

                Me.varExiste = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso a datos"
		Public Overrides Function Add() As Integer
			Try
                Dim queryString As String = "INSERT INTO [Actividades] ([titulo], [tipodeActividad], [instrucciones], [respues" &
                 "ta], [respuestaGrupal], [comoSeCalifica], [quienCalifica], [mostrarRespuestas], " &
                 "[mostrarCalificacion], [mostrarObservaciones], [puntosPorRespuesta], [puntosTota" &
                 "les], [tiempoEnMinutos], [numeroSecciones], [status], idUserProfile, fechaCreacion, tags, TipoX, Objetivo, idRubrica, Autoevaluacion, contestarSinAgenda, activarBanco, totalPreguntas, presentacionAleatoria, ParaInstructor) VALUES (@titulo, @tipodeActividad, @instrucciones, @res" &
                 "puesta, @respuestaGrupal, @comoSeCalifica, @quienCalifica, @mostrarRespuestas, @" &
                 "mostrarCalificacion, @mostrarObservaciones, @puntosPorRespuesta, @puntosTotales," &
                 " @tiempoEnMinutos,  @numeroSecciones, @status, @idUserProfile, @fechaCreacion, @tags, @TipoX, @Objetivo, @idRubrica, @Autoevaluacion, @contestarSinAgenda, @activarBanco, @totalPreguntas, @presentacionAleatoria, @ParaInstructor)"

                Dim parametros As SqlParameter() = {
                 New SqlParameter("@titulo", Me.titulo),
                  New SqlParameter("@tipodeActividad", Me.tipodeActividad),
                  New SqlParameter("@instrucciones", Me.instrucciones),
                  New SqlParameter("@respuesta", Me.respuesta),
                  New SqlParameter("@respuestaGrupal", Me.respuestaGrupal),
                  New SqlParameter("@comoSeCalifica", Me.comoSeCalifica),
                  New SqlParameter("@quienCalifica", Me.quienCalifica),
                  New SqlParameter("@mostrarRespuestas", Me.mostrarRespuestas),
                  New SqlParameter("@mostrarCalificacion", Me.mostrarCalificacion),
                  New SqlParameter("@mostrarObservaciones", Me.mostrarObservaciones),
                  New SqlParameter("@puntosPorRespuesta", Me.puntosPorRespuesta),
                  New SqlParameter("@puntosTotales", Me.puntosTotales),
                  New SqlParameter("@tiempoEnMinutos", Me.tiempoEnMinutos),
                  New SqlParameter("@numeroSecciones", Me.numeroSecciones),
                  New SqlParameter("@status", Me.status),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion),
                  New SqlParameter("@tags", Me.Tags),
                  New SqlParameter("@TipoX", Me.TipoX),
                  New SqlParameter("@Objetivo", Me.Objetivo),
                  New SqlParameter("@idRubrica", Me.idRubrica),
                 New SqlParameter("@Autoevaluacion", Me.Autoevaluacion),
                 New SqlParameter("@contestarSinAgenda", Me.contestarSinAgenda),
                  New SqlParameter("@activarBanco", Me.activarBanco),
                 New SqlParameter("@totalPreguntas", Me.totalPreguntas),
                 New SqlParameter("@presentacionAleatoria", Me.presentacionAleatoria),
                New SqlParameter("@ParaInstructor", Me.ParaInstructor)}


                Me.idActividad = Me.ExecuteNonQuery(queryString, parametros, True)

			Catch ex As Exception
				Dim m As String = ex.Message
			End Try

			Return 0
		End Function

		Public Overrides Function Update() As Integer
			Try
                Dim queryString As String = "UPDATE [Actividades] SET [titulo]=@titulo, [tipodeActividad]=@tipodeActividad, " &
                 "[instrucciones]=@instrucciones, [respuesta]=@respuesta, [respuestaGrupal]=@respuestaGrupal, " &
                 "[comoSeCalifica]=@comoSeCalifica, [quienCalifica]=@quienCalifica, [mostrarRespuestas]=@mostrarRespuestas, " &
                  "[mostrarCalificacion]=@mostrarCalificacion, [mostrarObservaciones]=@mostrarObservaciones, " &
                  "[puntosPorRespuesta]=@puntosPorRespuesta, [puntosTotales]=@puntosTotales, [tiempoEnMinutos]=@tiempoEnMinutos, " &
                  "[numeroSecciones]=@numeroSecciones, [status]=@status, idUserProfile=@idUserProfile, fechaCreacion=@fechaCreacion, tags=@tags, TipoX=@TipoX, Objetivo=@Objetivo, idRubrica=@idRubrica, Autoevaluacion=@Autoevaluacion, contestarSinAgenda=@contestarSinAgenda, activarBanco=@activarBanco, totalPreguntas=@totalPreguntas, presentacionAleatoria=@presentacionAleatoria, ParaInstructor=@ParaInstructor WHERE ([Actividades].[idActividad] = @idActividad)"

                Dim parametros As SqlParameter() = {
                  New SqlParameter("@titulo", Me.titulo),
                  New SqlParameter("@tipodeActividad", Me.tipodeActividad),
                  New SqlParameter("@instrucciones", Me.instrucciones),
                  New SqlParameter("@respuesta", Me.respuesta),
                  New SqlParameter("@respuestaGrupal", Me.respuestaGrupal),
                  New SqlParameter("@comoSeCalifica", Me.comoSeCalifica),
                  New SqlParameter("@quienCalifica", Me.quienCalifica),
                  New SqlParameter("@mostrarRespuestas", Me.mostrarRespuestas),
                  New SqlParameter("@mostrarCalificacion", Me.mostrarCalificacion),
                  New SqlParameter("@mostrarObservaciones", Me.mostrarObservaciones),
                  New SqlParameter("@puntosPorRespuesta", Me.puntosPorRespuesta),
                  New SqlParameter("@puntosTotales", Me.puntosTotales),
                  New SqlParameter("@tiempoEnMinutos", Me.tiempoEnMinutos),
                  New SqlParameter("@numeroSecciones", Me.numeroSecciones),
                  New SqlParameter("@status", Me.status),
                  New SqlParameter("@idActividad", Me.idActividad),
                  New SqlParameter("@idUserProfile", Me.idUserProfile),
                  New SqlParameter("@fechaCreacion", Me.fechaCreacion),
                  New SqlParameter("@tags", Me.Tags),
                  New SqlParameter("@TipoX", Me.TipoX),
                  New SqlParameter("@Objetivo", Me.Objetivo),
                  New SqlParameter("@idRubrica", Me.idRubrica),
                 New SqlParameter("@Autoevaluacion", Me.Autoevaluacion),
                 New SqlParameter("@contestarSinAgenda", Me.contestarSinAgenda),
                  New SqlParameter("@activarBanco", Me.activarBanco),
                 New SqlParameter("@totalPreguntas", Me.totalPreguntas),
                 New SqlParameter("@presentacionAleatoria", Me.presentacionAleatoria),
                New SqlParameter("@ParaInstructor", Me.ParaInstructor)}

                Return Me.ExecuteNonQuery(queryString, parametros)
			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Overrides Function Remove() As Integer
			Dim queryString As String = "DELETE FROM [Actividades] WHERE ([Actividades].[idActividad] = @idActividad)"

			Dim parametros As SqlParameter() = {New SqlParameter("@idActividad", Me.idActividad)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Overrides Function GetDR() As SqlDataReader
            Dim sql As String = "select * from Actividades"
            Return Me.ExecuteReader(sql, Nothing)
		End Function

		Public Overrides Function GetDS() As System.Data.DataSet
			Return Nothing
		End Function

		Public Overrides Function Count() As Integer
			Return 0
		End Function

		Public Overrides Function EnUso() As Boolean
			Return True
		End Function
#End Region
	End Class

#Region "Enumeraciones de la clase"
	Public Enum ETipodeActividad As Byte
		Examen = 1
		Actividad = 2
	End Enum

	Public Enum ERespuesta As Byte
		Individual = 1
		Grupal = 2
	End Enum

	Public Enum EComoSeCalifica As Byte
		ValorNumerico = 1
        Ranking = 2
        Letras = 3
        Rubrica = 4
        RubricaA = 5
    End Enum

	Public Enum EQuienCalifica As Byte
		Maestro = 1
		Alumnos = 2
		AutoCalificacion = 3
	End Enum

	Public Enum EPuntosPorRespuesta As Byte
		Automatica = 1
		Personalizada = 2
	End Enum
#End Region
End Namespace
