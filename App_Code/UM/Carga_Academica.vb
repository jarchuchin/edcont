Imports System.Data.OracleClient
Imports System.Data


Namespace UM
    Public Class Carga_Academica
        Inherits DBObjectOracle

        Public Curso_Carga_Id As String
        Public Carga_Id As String
        Public Bloque_id As Integer
        Public Codigo_Personal As String
        Public Nombre As String
        Public Carrera_id As String
        Public Grupo As String
        Public Modalidad_id As Integer
        Public Estado As Integer
        Public F_Inicio As Date
        Public F_Final As Date
        Public F_Entrega As Date
        Public Origen As String
        Public Plan_Id As String
        Public Curso_Id As String
        Public Nombre_Curso As String
        Public Ciclo As Integer
        Public Creditos As Integer
        Public HT As Integer
        Public HP As Integer
        Public Nota_Aprobatoria As Integer
        Public Horario As String
        Public Valeucas As String
        Public Num_Alum As Integer
        Public Semanas As Integer
        Public varExiste As Boolean = False

        Public Overrides ReadOnly Property id() As Integer
            Get
            End Get
        End Property

        Public Overrides ReadOnly Property existe() As Boolean
            Get
                Return varExiste
            End Get
        End Property

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As String)
            Dim sql As String = "select * from " & Me.sch & ".carga_academica where curso_carga_id=:curso_carga_id"
            Dim params As OracleParameter() = {New OracleParameter("curso_carga_id", clavePrincipal)}
            Dim dr As OracleDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then

                If Not Convert.IsDBNull(dr("CURSO_CARGA_ID")) Then
                    Me.Curso_Carga_Id = dr("CURSO_CARGA_ID")
                Else
                    Me.Curso_Carga_Id = ""
                End If

                If Not Convert.IsDBNull(dr("CARGA_ID")) Then
                    Me.Carga_Id = dr("CARGA_ID")
                Else
                    Me.Carga_Id = ""
                End If

                If Not Convert.IsDBNull(dr("BLOQUE_ID")) Then
                    Me.Bloque_id = CInt(dr("BLOQUE_ID"))
                Else
                    Me.Bloque_id = 0
                End If

                If Not Convert.IsDBNull(dr("Codigo_Personal")) Then
                    Me.Codigo_Personal = dr("Codigo_Personal")
                Else
                    Me.Codigo_Personal = ""
                End If

                If Not Convert.IsDBNull(dr("Nombre")) Then
                    Me.Nombre = dr("Nombre")
                Else
                    Me.Nombre = ""
                End If

                If Not Convert.IsDBNull(dr("Carrera_id")) Then
                    Me.Carrera_id = dr("Carrera_id")
                Else
                    Me.Carrera_id = ""
                End If

                If Not Convert.IsDBNull(dr("Grupo")) Then
                    Me.Grupo = dr("Grupo")
                Else
                    Me.Grupo = ""
                End If

                If Not Convert.IsDBNull(dr("Modalidad_id")) Then
                    Me.Modalidad_id = CInt(dr("Modalidad_id"))
                Else
                    Me.Modalidad_id = 0
                End If

                If Not Convert.IsDBNull(dr("Estado")) Then
                    Me.Estado = CInt(dr("Estado"))
                Else
                    Me.Estado = 0
                End If

                If Not Convert.IsDBNull(dr("F_Inicio")) Then
                    Me.F_Inicio = CDate(dr("F_Inicio"))
                Else
                    Me.F_Inicio = Date.Today
                End If

                If Not Convert.IsDBNull(dr("F_Final")) Then
                    Me.F_Final = CDate(dr("F_Final"))
                Else
                    Me.F_Final = Date.Today
                End If

                If Not Convert.IsDBNull(dr("F_Entrega")) Then
                    Me.F_Entrega = CDate(dr("F_Entrega"))
                Else
                    Me.F_Entrega = Date.Today
                End If

                If Not Convert.IsDBNull(dr("Origen")) Then
                    Me.Origen = dr("Origen")
                Else
                    Me.Origen = ""
                End If

                If Not Convert.IsDBNull(dr("Plan_Id")) Then
                    Me.Plan_Id = dr("Plan_Id")
                Else
                    Me.Plan_Id = ""
                End If

                If Not Convert.IsDBNull(dr("Curso_Id")) Then
                    Me.Curso_Id = dr("Curso_Id")
                Else
                    Me.Curso_Id = ""
                End If

                If Not Convert.IsDBNull(dr("Nombre_Curso")) Then
                    Me.Nombre_Curso = dr("Nombre_Curso")
                Else
                    Me.Nombre_Curso = ""
                End If

                If Not Convert.IsDBNull(dr("Ciclo")) Then
                    Me.Ciclo = CInt(dr("Ciclo"))
                Else
                    Me.Ciclo = 0
                End If

                If Not Convert.IsDBNull(dr("Creditos")) Then
                    Me.Creditos = CInt(dr("Creditos"))
                Else
                    Me.Creditos = 0
                End If

                If Not Convert.IsDBNull(dr("HT")) Then
                    Me.HT = CInt(dr("HT"))
                Else
                    Me.HT = 0
                End If

                If Not Convert.IsDBNull(dr("HP")) Then
                    Me.HP = CInt(dr("HP"))
                Else
                    Me.HP = 0
                End If


                If Not Convert.IsDBNull(dr("HP")) Then
                    Me.HP = CInt(dr("HP"))
                Else
                    Me.HP = 0
                End If


                If Not Convert.IsDBNull(dr("Nota_Aprobatoria")) Then
                    Me.Nota_Aprobatoria = CInt(dr("Nota_Aprobatoria"))
                Else
                    Me.Nota_Aprobatoria = 0
                End If

                If Not Convert.IsDBNull(dr("Horario")) Then
                    Me.Horario = dr("Horario")
                Else
                    Me.Horario = ""
                End If

                If Not Convert.IsDBNull(dr("Valeucas")) Then
                    Me.Valeucas = dr("Valeucas")
                Else
                    Me.Valeucas = ""
                End If


                If Not Convert.IsDBNull(dr("Num_Alum")) Then
                    Me.Num_Alum = CInt(dr("Num_Alum"))
                Else
                    Me.Num_Alum = 0
                End If


                If Not Convert.IsDBNull(dr("Semanas")) Then
                    Me.Semanas = CInt(dr("Semanas"))
                Else
                    Me.Semanas = 0
                End If

                varExiste = True


            End If

            dr.Close()

        End Sub

        Public Overloads Function GetDR(ByVal actualYear As Integer) As Data.OracleClient.OracleDataReader
            
            Dim queryString As String = "select * from " & Me.sch & ".carga_academica where origen = 'O' and f_inicio is not null and extract(year from f_inicio) = " & actualYear & "  order by f_inicio desc"
            Return Me.ExecuteReader(queryString, Nothing)

        End Function


        Public Function ColocarCursos(ByVal claveEmpresa As Integer) As Integer

            Dim dr As OracleClient.OracleDataReader = Me.GetDR(Date.Now.Year)
            Dim num As Integer = 0
            Dim myc As UM.Curso
            Do While dr.Read
                Dim cadenaCodigoPersonal As String = dr("CODIGO_PERSONAL")

                If cadenaCodigoPersonal.Trim <> "" Then
                    myc = New UM.Curso(dr("CURSO_CARGA_ID"))
                    myc.idEmpresa = claveEmpresa
                    myc.clave = dr("CURSO_CARGA_ID")
                    myc.claveAux = dr("CODIGO_PERSONAL")
                    If CType(dr("MODALIDAD_ID"), Integer) = 5 Then
                        myc.Nombre = dr("NOMBRE_CURSO") & " (En línea)"
                    Else
                        myc.Nombre = dr("NOMBRE_CURSO")
                    End If

                    myc.FechaInicio = CType(dr("F_INICIO"), Date)
                    myc.FechaFin = CType(dr("F_FINAL"), Date)
                    myc.HoraAtencion = "N/A"

                    If myc.Existe Then
                        myc.Update()
                    Else
                        myc.grabado = 0
                        myc.Add()
                    End If
                    num = num + 1
                End If


            Loop
            dr.Close()

            Return num

        End Function


        Public Function ActualizarCursos(ByVal claveEmpresa As Integer) As Integer

            Dim dr As OracleClient.OracleDataReader = Me.GetDR(Date.Now.Year)
            Dim num As Integer = 0
            Dim myc As UM.Curso
            Do While dr.Read

                Dim cadenaCodigoPersonal As String = dr("CODIGO_PERSONAL")

                If cadenaCodigoPersonal.Trim.Length > 0 Then
                    myc = New UM.Curso(dr("CURSO_CARGA_ID"))
                    myc.claveAux = cadenaCodigoPersonal



                    Dim myupMaestroNuevoEmp As MasUsuarios.EmpresaUserProfile = New MasUsuarios.EmpresaUserProfile(cadenaCodigoPersonal, claveEmpresa, tipoObjeto.Maestro)
                    Dim myupMaestroNuevo As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(myupMaestroNuevoEmp.idUserProfile, False)

                    If myc.Existe And myupMaestroNuevo.existe Then

                        'myc.idEmpresa = claveEmpresa


                        Dim mysv As Know.SalonVirtual = New Know.SalonVirtual(myc.clave, False)
                        If mysv.existe Then
                            Dim myupMaestroActual As MasUsuarios.UserProfile = New MasUsuarios.UserProfile(mysv.idUserProfile, True)
                            If myupMaestroActual.existe Then

                                If myupMaestroNuevo.id <> myupMaestroActual.id Then

                                    'actualiza tabla cursos
                                    myc.Update()

                                    'actualiza user profile
                                    mysv.idUserProfile = myupMaestroNuevo.id
                                    mysv.Update()

                                    'arregla permisos
                                    Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(myupMaestroActual, mysv)
                                    If myPermiso.existe Then
                                        myPermiso.Remove()
                                    End If
                                    myPermiso = New MasUsuarios.Permiso

                                    myPermiso.permisoA = myupMaestroNuevo.tipo
                                    myPermiso.idPermisoA = myupMaestroNuevo.id
                                    myPermiso.recurso = mysv.tipo
                                    myPermiso.idRecurso = mysv.id


                                    myPermiso.PRoots = True
                                    myPermiso.PPermisosRoots = True
                                    myPermiso.PCategorias = True
                                    myPermiso.PRespuestas = True
                                    myPermiso.PEvaluacion = True
                                    myPermiso.PSalonVirtual = True
                                    myPermiso.PContenidos = True
                                    myPermiso.PInterfaceGrafica = True
                                    myPermiso.PEstadisticas = True
                                    myPermiso.PAdministracion = True
                                    myPermiso.Add()

                                    num = num + 1
                                Else
                                    'revisa que esten bien colocados los permisos
                                    Dim myPermiso As MasUsuarios.Permiso = New MasUsuarios.Permiso(myupMaestroNuevo, mysv, False)
                                    If Not myPermiso.existe Then
                                        myPermiso = New MasUsuarios.Permiso

                                        myPermiso.permisoA = myupMaestroNuevo.tipo
                                        myPermiso.idPermisoA = myupMaestroNuevo.id
                                        myPermiso.recurso = mysv.tipo
                                        myPermiso.idRecurso = mysv.id


                                        myPermiso.PRoots = True
                                        myPermiso.PPermisosRoots = True
                                        myPermiso.PCategorias = True
                                        myPermiso.PRespuestas = True
                                        myPermiso.PEvaluacion = True
                                        myPermiso.PSalonVirtual = True
                                        myPermiso.PContenidos = True
                                        myPermiso.PInterfaceGrafica = True
                                        myPermiso.PEstadisticas = True
                                        myPermiso.PAdministracion = True
                                        myPermiso.Add()
                                        num = num + 1
                                    End If

                                    'termina revisar que esten bien colocados los permisos
                                End If

                            End If
                        End If




                    End If

                End If


            Loop
            dr.Close()

            Return num

        End Function


      

        

        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function


        Public Overloads Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Dim sql As String = "select * from " & Me.sch & ".carga_academica "
            Return Me.ExecuteReader(sql, Nothing)
        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Dim sql As String = "select * from " & Me.sch & ".carga_academica "
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function


        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function
    End Class

End Namespace
