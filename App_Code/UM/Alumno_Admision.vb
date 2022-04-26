Imports System.Configuration
Imports System.Data

Namespace UM



    Public Class Alumno_Admision
        Inherits DBObjectOracle



        Sub New()

        End Sub



        Public Overrides Function Add() As Integer

        End Function

        Public Overrides Function Count() As Integer

        End Function

        Public Overrides Function EnUso() As Boolean

        End Function

        Public Overrides ReadOnly Property existe() As Boolean
            Get

            End Get
        End Property

        Public Overrides Function GetDR() As System.Data.OracleClient.OracleDataReader
            Dim querystring As String = "select alumno_admision.* from " & sch & ".alumno_admision "
            Return Me.ExecuteReader(querystring, Nothing)

        End Function

        Public Overrides Function GetDS() As System.Data.DataSet
            Return Nothing

        End Function

        Public Overrides ReadOnly Property id() As Integer
            Get

            End Get
        End Property

        Public Overrides Function Remove() As Integer

        End Function

        Public Overrides Function Update() As Integer

        End Function



        Public Function ColocarAlumnosProspectos() As Integer

            Dim dr As OracleClient.OracleDataReader = Me.GetDR()
            Dim numeroAlumnos As Integer = 0
            Dim myap As AlumnoProspecto
            Do While dr.Read

                myap = New AlumnoProspecto()
                If myap.EstaEnSistema(dr("CODIGO_PERSONAL")) = False Then
                    numeroAlumnos = numeroAlumnos + 1
                    myap.Nombre = dr("NOMBRE")
                    myap.ApellidoPaterno = dr("APELLIDO_PATERNO")
                    myap.ApellidoMaterno = dr("APELLIDO_MATERNO")
                    myap.NacimientoCiudad = ""
                    myap.NacimientoEstado = ""
                    myap.NacimientoidPais = 1
                    myap.NacimientoNacionalidad = 1
                    myap.NacimientoFecha = Date.Now
                    myap.EstadoCivil = "S"
                    myap.Sexo = "M"
                    myap.idReligion = 1
                    myap.BautizadoASD = True
                    myap.DomicilioCalle = ""
                    myap.DomicilioNumero = ""
                    myap.DomicilioColonia = ""
                    myap.DomicilioCiudad = ""
                    myap.DomicilioEstado = ""
                    myap.DomicilioidPais = 1
                    myap.DomicilioCP = ""
                    myap.DomicilioTelefono = ""
                    myap.DomicilioFax = ""
                    myap.Email = ""
                    myap.GradoDeseado = "Lic"
                    myap.UltimoEstudioGradoObtenido = ""
                    myap.UltimoEstudioNombreInstitucion = ""
                    myap.UltimoEstudioFechaInicio = Date.Now
                    myap.UltimoEstudioFechaFin = Date.Now
                    myap.UltimoEstudioCiudad = ""
                    myap.UltimoEstudioEstado = ""
                    myap.UltimoEstudioidPais = 1
                    myap.CarreraDeseada = dr("CARRERA")
                    myap.FechaInicioDeseada = Date.Now
                    myap.EnfermedadCronica = False
                    myap.EnfermedadCronicaExplicacion = ""
                    myap.ImpedimentoFisico = False
                    myap.ImpedimentoFisicoExplicacion = ""
                    myap.PadreNombre = ""
                    myap.PadreApellidos = ""
                    myap.PadreidReligion = 1
                    myap.PadreNacionalidad = 1
                    myap.PadreOcupacion = ""
                    myap.MadreNombre = ""
                    myap.MadreApellidos = ""
                    myap.MadreidReligion = 1
                    myap.MadreNacionalidad = 1
                    myap.MadreOcupacion = ""
                    myap.TutorTipo = ""
                    myap.TutorNombre = ""
                    myap.TutorApellidos = ""
                    myap.TutorCalle = ""
                    myap.TutorCalleNumero = ""
                    myap.TutorColonia = ""
                    myap.TutorEstado = ""
                    myap.TutorCiudad = ""
                    myap.TutorCP = ""
                    myap.TutorCiudad = ""
                    myap.TutoridPais = 1
                    myap.TutorTelefono = ""
                    myap.ObreroStatus = ""
                    myap.ObreroEsMi = ""
                    myap.ObreroTipo = ""
                    myap.ObreroUnion = ""
                    myap.ObreroAsociacion = ""
                    myap.Persona1Nombre = ""
                    myap.Persona1Direccion = ""
                    myap.Persona1Telefono = ""
                    myap.Persona2Nombre = ""
                    myap.Persona2Direccion = ""
                    myap.Persona2Telefono = ""
                    myap.Persona3Nombre = ""
                    myap.Persona3Direccion = ""
                    myap.Persona3Telefono = ""
                    myap.AceptaCompromiso = True
                    myap.ExternadoSolicitud = False
                    myap.ExternadoRazon = ""
                    myap.ExternadoCalle = ""
                    myap.ExternadoColonia = ""
                    myap.ExternadoNumero = ""
                    myap.ExternadoTelefono = ""
                    myap.Login = dr("CODIGO_PERSONAL")
                    myap.Password = dr("CODIGO_PERSONAL")
                    myap.Status = "Matriculado"
                    myap.StatusFecha = Date.Today
                    myap.DatosConfirmados = 1
                    myap.idCarreraAsignada = dr("CARRERA")
                    myap.CarreraAsignadaFecha = Date.Today
                    myap.Matricula = dr("CODIGO_PERSONAL")
                    myap.Add()
                End If


            Loop

            dr.Close()

            Return numeroAlumnos

        End Function


    End Class
End Namespace
