Imports Microsoft.VisualBasic
Imports System.Configuration


Namespace UM
    Public Class AlumnoProspecto

        Public idAlumnoProspecto As Integer
        Public Nombre As String
        Public ApellidoPaterno As String
        Public ApellidoMaterno As String
        Public NacimientoCiudad As String
        Public NacimientoEstado As String
        Public NacimientoidPais As Integer
        Public NacimientoNacionalidad As Integer
        Public NacimientoFecha As Date
        Public EstadoCivil As String
        Public Sexo As String
        Public idReligion As Integer
        Public BautizadoASD As Boolean
        Public DomicilioCalle As String
        Public DomicilioNumero As String
        Public DomicilioColonia As String
        Public DomicilioCiudad As String
        Public DomicilioEstado As String
        Public DomicilioidPais As Integer
        Public DomicilioCP As String
        Public DomicilioTelefono As String
        Public DomicilioFax As String
        Public Email As String
        Public GradoDeseado As String
        Public UltimoEstudioGradoObtenido As String
        Public UltimoEstudioNombreInstitucion As String
        Public UltimoEstudioFechaInicio As Date
        Public UltimoEstudioCiudad As String
        Public UltimoEstudioEstado As String
        Public UltimoEstudioidPais As Integer
        Public UltimoEstudioFechaFin As Date
        Public CarreraDeseada As String
        Public FechaInicioDeseada As Date
        Public EnfermedadCronica As Boolean
        Public EnfermedadCronicaExplicacion As String
        Public ImpedimentoFisico As Boolean
        Public ImpedimentoFisicoExplicacion As String
        Public PadreNombre As String
        Public PadreApellidos As String
        Public PadreidReligion As Integer
        Public PadreNacionalidad As Integer
        Public PadreOcupacion As String
        Public MadreNombre As String
        Public MadreApellidos As String
        Public MadreidReligion As Integer
        Public MadreNacionalidad As Integer
        Public MadreOcupacion As String
        Public TutorTipo As String
        Public TutorNombre As String
        Public TutorApellidos As String
        Public TutorCalle As String
        Public TutorCalleNumero As String
        Public TutorColonia As String
        Public TutorCP As String
        Public TutorCiudad As String
        Public TutorEstado As String
        Public TutoridPais As Integer
        Public TutorTelefono As String
        Public ObreroStatus As String
        Public ObreroEsMi As String
        Public ObreroTipo As String
        Public ObreroUnion As String
        Public ObreroAsociacion As String
        Public Persona1Nombre As String
        Public Persona1Direccion As String
        Public Persona1Telefono As String
        Public Persona2Nombre As String
        Public Persona2Direccion As String
        Public Persona2Telefono As String
        Public Persona3Nombre As String
        Public Persona3Direccion As String
        Public Persona3Telefono As String
        Public AceptaCompromiso As Boolean
        Public ExternadoSolicitud As Boolean
        Public ExternadoRazon As String
        Public ExternadoCalle As String
        Public ExternadoColonia As String
        Public ExternadoNumero As String
        Public ExternadoTelefono As String
        Public ActaNacimiento As String = String.Empty
        Public ActaNacimientoFecha As Date = Date.Today
        Public CertificadoSecundaria As String = String.Empty
        Public CertificadoSecundariaFecha As Date = Date.Today
        Public CertificadoBachillerato As String = String.Empty
        Public CertificadoBachilleratoFecha As Date = Date.Today
        Public BuenaConducta As String = String.Empty
        Public BuenaConductaFecha As Date = Date.Today
        Public Recomendacion1 As String = String.Empty
        Public Recomendacion1Fecha As Date = Date.Today
        Public Recomendacion2 As String = String.Empty
        Public Recomendacion2Fecha As Date = Date.Today
        Public Recomendacion3 As String = String.Empty
        Public Recomendacion3Fecha As Date = Date.Today
        Public Fotografias As String = String.Empty
        Public FotografiasFecha As Date = Date.Today
        Public ExamenMedico As String = String.Empty
        Public ExamenMedicoFecha As Date = Date.Today
        Public Status As String
        Public StatusFecha As Date
        Public FechaRegistro As Date = Date.Today
        Public DatosConfirmados As Boolean
        Public idCarreraAsignada As String = String.Empty
        Public CarreraAsignadaFecha As Date = Date.Today
        Public Matricula As String = String.Empty
        Public Folio As String = String.Empty
        Public CuotaAdmision As String = String.Empty
        Public CuotaAdmisionFecha As Date = Date.Today
        Public CartaAdmision As String = String.Empty
        Public CartaAdmisionFecha As Date = Date.Today
        Public Login As String = String.Empty
        Public Password As String = String.Empty

        Public bandera As Boolean = False

        Sub New()

        End Sub



        Sub New(ByVal clave As Integer)

            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionStringAdmision").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

            Dim queryString As String = "SELECT [AlumnoProspecto].* FROM [AlumnoProspecto] WHERE ([AlumnoProspecto].[idAlu" & _
                "mnoProspecto] = @idAlumnoProspecto)"
            Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
            dbCommand.CommandText = queryString
            dbCommand.Connection = dbConnection

            Dim dbParam_idAlumnoProspecto As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idAlumnoProspecto.ParameterName = "@idAlumnoProspecto"
            dbParam_idAlumnoProspecto.Value = clave
            dbParam_idAlumnoProspecto.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_idAlumnoProspecto)

            dbConnection.Open()
            Dim dr As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            If dr.Read Then
                Me.idAlumnoProspecto = CInt(dr("idAlumnoProspecto"))
                Me.Nombre = dr("Nombre")
                Me.ApellidoPaterno = dr("ApellidoPaterno")
                Me.ApellidoMaterno = dr("ApellidoMaterno")
                Me.NacimientoCiudad = dr("NacimientoCiudad")
                Me.NacimientoEstado = dr("NacimientoEstado")
                Me.NacimientoidPais = CInt(dr("NacimientoidPais"))
                Me.NacimientoNacionalidad = CInt(dr("NacimientoNacionalidad"))
                Me.NacimientoFecha = CDate(dr("NacimientoFecha"))
                Me.EstadoCivil = dr("EstadoCivil")
                Me.Sexo = dr("Sexo")
                Me.idReligion = CInt(dr("idReligion"))
                Me.BautizadoASD = CBool(dr("BautizadoASD"))
                Me.DomicilioCalle = dr("DomicilioCalle")
                Me.DomicilioNumero = dr("DomicilioNumero")
                Me.DomicilioColonia = dr("DomicilioColonia")
                Me.DomicilioCiudad = dr("DomicilioCiudad")
                Me.DomicilioEstado = dr("DomicilioEstado")
                Me.DomicilioidPais = CInt(dr("DomicilioidPais"))
                Me.DomicilioCP = dr("DomicilioCP")
                Me.DomicilioTelefono = dr("DomicilioTelefono")
                Me.DomicilioFax = dr("DomicilioFax")
                Me.Email = dr("Email")
                Me.GradoDeseado = dr("GradoDeseado")
                Me.UltimoEstudioGradoObtenido = dr("UltimoEstudioGradoObtenido")
                Me.UltimoEstudioNombreInstitucion = dr("UltimoEstudioNombreInstitucion")
                Me.UltimoEstudioFechaInicio = CDate(dr("UltimoEstudioFechaInicio"))
                Me.UltimoEstudioCiudad = dr("UltimoEstudioCiudad")
                Me.UltimoEstudioEstado = dr("UltimoEstudioEstado")
                Me.UltimoEstudioidPais = CInt(dr("UltimoEstudioidPais"))
                Me.UltimoEstudioFechaFin = CDate(dr("UltimoEstudioFechaFin"))
                Me.CarreraDeseada = dr("CarreraDeseada")
                Me.FechaInicioDeseada = CDate(dr("FechaInicioDeseada"))
                Me.EnfermedadCronica = CBool(dr("EnfermedadCronica"))
                Me.EnfermedadCronicaExplicacion = dr("EnfermedadCronicaExplicacion")
                Me.ImpedimentoFisico = CBool(dr("ImpedimentoFisico"))
                Me.ImpedimentoFisicoExplicacion = dr("ImpedimentoFisicoExplicacion")
                Me.PadreNombre = dr("PadreNombre")
                Me.PadreApellidos = dr("PadreApellidos")
                Me.PadreidReligion = CInt(dr("PadreidReligion"))
                Me.PadreNacionalidad = CInt(dr("PadreNacionalidad"))
                Me.PadreOcupacion = dr("PadreOcupacion")
                Me.MadreNombre = dr("MadreNombre")
                Me.MadreApellidos = dr("MadreApellidos")
                Me.MadreidReligion = CInt(dr("MadreidReligion"))
                Me.MadreNacionalidad = CInt(dr("MadreNacionalidad"))
                Me.MadreOcupacion = dr("MadreOcupacion")
                Me.TutorTipo = dr("TutorTipo")
                Me.TutorNombre = dr("TutorNombre")
                Me.TutorApellidos = dr("TutorApellidos")
                Me.TutorCalle = dr("TutorCalle")
                Me.TutorCalleNumero = dr("TutorCalleNumero")
                Me.TutorColonia = dr("TutorColonia")
                Me.TutorCP = dr("TutorCP")
                Me.TutorCiudad = dr("TutorCiudad")
                Me.TutorEstado = dr("TutorEstado")
                Me.TutoridPais = CInt(dr("TutoridPais"))
                Me.TutorTelefono = dr("TutorTelefono")
                Me.ObreroStatus = dr("ObreroStatus")
                Me.ObreroEsMi = dr("ObreroEsMi")
                Me.ObreroTipo = dr("ObreroTipo")
                Me.ObreroUnion = dr("ObreroUnion")
                Me.ObreroAsociacion = dr("ObreroAsociacion")
                Me.Persona1Nombre = dr("Persona1Nombre")
                Me.Persona1Direccion = dr("Persona1Direccion")
                Me.Persona1Telefono = dr("Persona1Telefono")
                Me.Persona2Nombre = dr("Persona2Nombre")
                Me.Persona2Direccion = dr("Persona2Direccion")
                Me.Persona2Telefono = dr("Persona2Telefono")
                Me.Persona3Nombre = dr("Persona3Nombre")
                Me.Persona3Direccion = dr("Persona3Direccion")
                Me.Persona3Telefono = dr("Persona3Telefono")
                Me.AceptaCompromiso = dr("AceptaCompromiso")
                Me.ExternadoSolicitud = dr("ExternadoSolicitud")
                Me.ExternadoRazon = dr("ExternadoRazon")
                Me.ExternadoCalle = dr("ExternadoCalle")
                Me.ExternadoColonia = dr("ExternadoColonia")
                Me.ExternadoNumero = dr("ExternadoNumero")
                Me.ExternadoTelefono = dr("ExternadoTelefono")
                Me.ActaNacimiento = dr("ActaNacimiento")
                Me.ActaNacimientoFecha = CDate(dr("ActaNacimientoFecha"))
                Me.CertificadoSecundaria = dr("CertificadoSecundaria")
                Me.CertificadoSecundariaFecha = CDate(dr("CertificadoSecundariaFecha"))
                Me.CertificadoBachillerato = dr("CertificadoBachillerato")
                Me.CertificadoBachilleratoFecha = CDate(dr("CertificadoBachilleratoFecha"))
                Me.BuenaConducta = dr("BuenaConducta")
                Me.BuenaConductaFecha = CDate(dr("BuenaConductaFecha"))
                Me.Recomendacion1 = dr("Recomendacion1")
                Me.Recomendacion1Fecha = CDate(dr("Recomendacion1Fecha"))
                Me.Recomendacion2 = dr("Recomendacion2")
                Me.Recomendacion2Fecha = CDate(dr("Recomendacion2Fecha"))
                Me.Recomendacion3 = dr("Recomendacion3")
                Me.Recomendacion3Fecha = CDate(dr("Recomendacion3Fecha"))
                Me.Fotografias = dr("Fotografias")
                Me.FotografiasFecha = CDate(dr("FotografiasFecha"))
                Me.ExamenMedico = dr("ExamenMedico")
                Me.ExamenMedicoFecha = CDate(dr("ExamenMedicoFecha"))
                Me.Status = dr("Status")
                Me.StatusFecha = CDate(dr("StatusFecha"))
                Me.FechaRegistro = CDate(dr("FechaRegistro"))
                Me.DatosConfirmados = dr("DatosConfirmados")
                Me.idCarreraAsignada = dr("idCarreraAsignada")
                Me.CarreraAsignadaFecha = dr("CarreraAsignadaFecha")
                Me.Matricula = dr("Matricula")
                Me.Folio = dr("Folio")
                Me.CuotaAdmision = dr("CuotaAdmision")
                Me.CuotaAdmisionFecha = CDate(dr("CuotaAdmisionFecha"))
                Me.CartaAdmision = dr("CartaAdmision")
                Me.CartaAdmisionFecha = CDate(dr("CartaAdmisionFecha"))
                Me.Login = dr("Login")
                Me.Password = dr("Password")
            Else
                bandera = True
            End If

            dr.Close()

        End Sub

        Sub New(ByVal clave As String)

            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionStringAdmision").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

            Dim queryString As String = "SELECT [AlumnoProspecto].* FROM [AlumnoProspecto] WHERE ([AlumnoProspecto].[" & _
                "email] = @Email)"
            Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
            dbCommand.CommandText = queryString
            dbCommand.Connection = dbConnection

            Dim dbParam_email As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_email.ParameterName = "@Email"
            dbParam_email.Value = clave
            dbParam_email.DbType = System.Data.DbType.String
            dbCommand.Parameters.Add(dbParam_email)

            dbConnection.Open()
            Dim dr As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            If dr.Read Then
                Me.idAlumnoProspecto = CInt(dr("idAlumnoProspecto"))
                Me.Nombre = dr("Nombre")
                Me.ApellidoPaterno = dr("ApellidoPaterno")
                Me.ApellidoMaterno = dr("ApellidoMaterno")
                Me.NacimientoCiudad = dr("NacimientoCiudad")
                Me.NacimientoEstado = dr("NacimientoEstado")
                Me.NacimientoidPais = CInt(dr("NacimientoidPais"))
                Me.NacimientoNacionalidad = CInt(dr("NacimientoNacionalidad"))
                Me.NacimientoFecha = CDate(dr("NacimientoFecha"))
                Me.EstadoCivil = dr("EstadoCivil")
                Me.Sexo = dr("Sexo")
                Me.idReligion = CInt(dr("idReligion"))
                Me.BautizadoASD = CBool(dr("BautizadoASD"))
                Me.DomicilioCalle = dr("DomicilioCalle")
                Me.DomicilioNumero = dr("DomicilioNumero")
                Me.DomicilioColonia = dr("DomicilioColonia")
                Me.DomicilioCiudad = dr("DomicilioCiudad")
                Me.DomicilioEstado = dr("DomicilioEstado")
                Me.DomicilioidPais = CInt(dr("DomicilioidPais"))
                Me.DomicilioCP = dr("DomicilioCP")
                Me.DomicilioTelefono = dr("DomicilioTelefono")
                Me.DomicilioFax = dr("DomicilioFax")
                Me.Email = dr("Email")
                Me.GradoDeseado = dr("GradoDeseado")
                Me.UltimoEstudioGradoObtenido = dr("UltimoEstudioGradoObtenido")
                Me.UltimoEstudioNombreInstitucion = dr("UltimoEstudioNombreInstitucion")
                Me.UltimoEstudioFechaInicio = CDate(dr("UltimoEstudioFechaInicio"))
                Me.UltimoEstudioCiudad = dr("UltimoEstudioCiudad")
                Me.UltimoEstudioEstado = dr("UltimoEstudioEstado")
                Me.UltimoEstudioidPais = CInt(dr("UltimoEstudioidPais"))
                Me.UltimoEstudioFechaFin = CDate(dr("UltimoEstudioFechaFin"))
                Me.CarreraDeseada = dr("CarreraDeseada")
                Me.FechaInicioDeseada = CDate(dr("FechaInicioDeseada"))
                Me.EnfermedadCronica = CBool(dr("EnfermedadCronica"))
                Me.EnfermedadCronicaExplicacion = dr("EnfermedadCronicaExplicacion")
                Me.ImpedimentoFisico = CBool(dr("ImpedimentoFisico"))
                Me.ImpedimentoFisicoExplicacion = dr("ImpedimentoFisicoExplicacion")
                Me.PadreNombre = dr("PadreNombre")
                Me.PadreApellidos = dr("PadreApellidos")
                Me.PadreidReligion = CInt(dr("PadreidReligion"))
                Me.PadreNacionalidad = CInt(dr("PadreNacionalidad"))
                Me.PadreOcupacion = dr("PadreOcupacion")
                Me.MadreNombre = dr("MadreNombre")
                Me.MadreApellidos = dr("MadreApellidos")
                Me.MadreidReligion = CInt(dr("MadreidReligion"))
                Me.MadreNacionalidad = CInt(dr("MadreNacionalidad"))
                Me.MadreOcupacion = dr("MadreOcupacion")
                Me.TutorTipo = dr("TutorTipo")
                Me.TutorNombre = dr("TutorNombre")
                Me.TutorApellidos = dr("TutorApellidos")
                Me.TutorCalle = dr("TutorCalle")
                Me.TutorCalleNumero = dr("TutorCalleNumero")
                Me.TutorColonia = dr("TutorColonia")
                Me.TutorCP = dr("TutorCP")
                Me.TutorCiudad = dr("TutorCiudad")
                Me.TutorEstado = dr("TutorEstado")
                Me.TutoridPais = CInt(dr("TutoridPais"))
                Me.TutorTelefono = dr("TutorTelefono")
                Me.ObreroStatus = dr("ObreroStatus")
                Me.ObreroEsMi = dr("ObreroEsMi")
                Me.ObreroTipo = dr("ObreroTipo")
                Me.ObreroUnion = dr("ObreroUnion")
                Me.ObreroAsociacion = dr("ObreroAsociacion")
                Me.Persona1Nombre = dr("Persona1Nombre")
                Me.Persona1Direccion = dr("Persona1Direccion")
                Me.Persona1Telefono = dr("Persona1Telefono")
                Me.Persona2Nombre = dr("Persona2Nombre")
                Me.Persona2Direccion = dr("Persona2Direccion")
                Me.Persona2Telefono = dr("Persona2Telefono")
                Me.Persona3Nombre = dr("Persona3Nombre")
                Me.Persona3Direccion = dr("Persona3Direccion")
                Me.Persona3Telefono = dr("Persona3Telefono")
                Me.AceptaCompromiso = dr("AceptaCompromiso")
                Me.ExternadoSolicitud = dr("ExternadoSolicitud")
                Me.ExternadoRazon = dr("ExternadoRazon")
                Me.ExternadoCalle = dr("ExternadoCalle")
                Me.ExternadoColonia = dr("ExternadoColonia")
                Me.ExternadoNumero = dr("ExternadoNumero")
                Me.ExternadoTelefono = dr("ExternadoTelefono")
                Me.ActaNacimiento = dr("ActaNacimiento")
                Me.ActaNacimientoFecha = CDate(dr("ActaNacimientoFecha"))
                Me.CertificadoSecundaria = dr("CertificadoSecundaria")
                Me.CertificadoSecundariaFecha = CDate(dr("CertificadoSecundariaFecha"))
                Me.CertificadoBachillerato = dr("CertificadoBachillerato")
                Me.CertificadoBachilleratoFecha = CDate(dr("CertificadoBachilleratoFecha"))
                Me.BuenaConducta = dr("BuenaConducta")
                Me.BuenaConductaFecha = CDate(dr("BuenaConductaFecha"))
                Me.Recomendacion1 = dr("Recomendacion1")
                Me.Recomendacion1Fecha = CDate(dr("Recomendacion1Fecha"))
                Me.Recomendacion2 = dr("Recomendacion2")
                Me.Recomendacion2Fecha = CDate(dr("Recomendacion2Fecha"))
                Me.Recomendacion3 = dr("Recomendacion3")
                Me.Recomendacion3Fecha = CDate(dr("Recomendacion3Fecha"))
                Me.Fotografias = dr("Fotografias")
                Me.FotografiasFecha = CDate(dr("FotografiasFecha"))
                Me.ExamenMedico = dr("ExamenMedico")
                Me.ExamenMedicoFecha = CDate(dr("ExamenMedicoFecha"))
                Me.Status = dr("Status")
                Me.StatusFecha = CDate(dr("StatusFecha"))
                Me.FechaRegistro = CDate(dr("FechaRegistro"))
                Me.DatosConfirmados = dr("DatosConfirmados")
                Me.idCarreraAsignada = dr("idCarreraAsignada")
                Me.CarreraAsignadaFecha = dr("CarreraAsignadaFecha")
                Me.Matricula = dr("Matricula")
                Me.Folio = dr("Folio")
                Me.CuotaAdmision = dr("CuotaAdmision")
                Me.CuotaAdmisionFecha = CDate(dr("CuotaAdmisionFecha"))
                Me.CartaAdmision = dr("CartaAdmision")
                Me.CartaAdmisionFecha = CDate(dr("CartaAdmisionFecha"))
                Me.Login = dr("Login")
                Me.Password = dr("Password")
            Else
                bandera = True
            End If

            dr.Close()

        End Sub

        Function Add() As Integer
            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionStringAdmision").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

            Dim queryString As String = "INSERT INTO [AlumnoProspecto] ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [N" & _
                "acimientoCiudad], [NacimientoEstado], [NacimientoidPais], [NacimientoNacionalida" & _
                "d], [NacimientoFecha], [EstadoCivil], [Sexo], [idReligion], [BautizadoASD], [Dom" & _
                "icilioCalle], [DomicilioNumero], [DomicilioColonia], [DomicilioCiudad], [Domicil" & _
                "ioEstado], [DomicilioidPais], [DomicilioCP], [DomicilioTelefono], [DomicilioFax]" & _
                ", [Email], [GradoDeseado], [UltimoEstudioGradoObtenido], [UltimoEstudioNombreIns" & _
                "titucion], [UltimoEstudioFechaInicio], [UltimoEstudioCiudad], [UltimoEstudioEsta" & _
                "do], [UltimoEstudioidPais], [UltimoEstudioFechaFin], [CarreraDeseada], [FechaIni" & _
                "cioDeseada], [EnfermedadCronica], [EnfermedadCronicaExplicacion], [ImpedimentoFi" & _
                "sico], [ImpedimentoFisicoExplicacion], [PadreNombre], [PadreApellidos], [Padreid" & _
                "Religion], [PadreNacionalidad], [PadreOcupacion], [MadreNombre], [MadreApellidos" & _
                "], [MadreidReligion], [MadreNacionalidad], [MadreOcupacion], [TutorTipo], [Tutor" & _
                "Nombre], [TutorApellidos], [TutorCalle], [TutorCalleNumero], [TutorColonia], [Tu" & _
                "torCP], [TutorCiudad], [TutorEstado], [TutoridPais], [TutorTelefono], [ObreroSta" & _
                "tus], [ObreroEsMi], [ObreroTipo], [ObreroUnion], [ObreroAsociacion], [Persona1No" & _
                "mbre], [Persona1Direccion], [Persona1Telefono], [Persona2Nombre], [Persona2Direc" & _
                "cion], [Persona2Telefono], [Persona3Nombre], [Persona3Direccion], [Persona3Telef" & _
                "ono], [AceptaCompromiso], [ExternadoSolicitud], [ExternadoRazon], [ExternadoCall" & _
                "e], [ExternadoColonia], [ExternadoNumero], [ExternadoTelefono], [ActaNacimiento]," & _
                " [ActaNacimientoFecha], [CertificadoSecundaria], [CertificadoSecundariaFecha], [" & _
                "CertificadoBachillerato], [CertificadoBachilleratoFecha], [BuenaConducta], [Buen" & _
                "aConductaFecha], [Recomendacion1], [Recomendacion1Fecha], [Recomendacion2], [Rec" & _
                "omendacion2Fecha], [Recomendacion3], [Recomendacion3Fecha], [Fotografias], [Foto" & _
                "grafiasFecha], [ExamenMedico], [ExamenMedicoFecha], [Status], [StatusFecha], [Fe" & _
                "chaRegistro], [DatosConfirmados], [idCarreraAsignada], [CarreraAsignadaFecha], [" & _
                "Matricula], [Folio], [CuotaAdmision], [CuotaAdmisionFecha], [CartaAdmision], [CartaAdmisionFecha], login, password ) " & _
                " VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Nacim" & _
                "ientoCiudad, @NacimientoEstado, @NacimientoidPais, @NacimientoNacionalidad, @Nac" & _
                "imientoFecha, @EstadoCivil, @Sexo, @idReligion, @BautizadoASD, @DomicilioCalle, " & _
                "@DomicilioNumero, @DomicilioColonia, @DomicilioCiudad, @DomicilioEstado, @Domici" & _
                "lioidPais, @DomicilioCP, @DomicilioTelefono, @DomicilioFax, @Email, @GradoDesead" & _
                "o, @UltimoEstudioGradoObtenido, @UltimoEstudioNombreInstitucion, @UltimoEstudioF" & _
                "echaInicio, @UltimoEstudioCiudad, @UltimoEstudioEstado, @UltimoEstudioidPais, @U" & _
                "ltimoEstudioFechaFin, @CarreraDeseada, @FechaInicioDeseada, @EnfermedadCronica, " & _
                "@EnfermedadCronicaExplicacion, @ImpedimentoFisico, @ImpedimentoFisicoExplicacion" & _
                ", @PadreNombre, @PadreApellidos, @PadreidReligion, @PadreNacionalidad, @PadreOcu" & _
                "pacion, @MadreNombre, @MadreApellidos, @MadreidReligion, @MadreNacionalidad, @Ma" & _
                "dreOcupacion, @TutorTipo, @TutorNombre, @TutorApellidos, @TutorCalle, @TutorCall" & _
                "eNumero, @TutorColonia, @TutorCP, @TutorCiudad, @TutorEstado, @TutoridPais, @Tut" & _
                "orTelefono, @ObreroStatus, @ObreroEsMi, @ObreroTipo, @ObreroUnion, @ObreroAsocia" & _
                "cion, @Persona1Nombre, @Persona1Direccion, @Persona1Telefono, @Persona2Nombre, @" & _
                "Persona2Direccion, @Persona2Telefono, @Persona3Nombre, @Persona3Direccion, @Pers" & _
                "ona3Telefono, @AceptaCompromiso, @ExternadoSolicitud, @ExternadoRazon, @Externad" & _
                "oCalle, @ExternadoColonia, @ExternadoNumero, @ExternadoTelefono, @ActaNacimiento," & _
                " @ActaNacimientoFecha, @CertificadoSecundaria, @CertificadoSecundariaFecha, @Cer" & _
                "tificadoBachillerato, @CertificadoBachilleratoFecha, @BuenaConducta, @BuenaCondu" & _
                "ctaFecha, @Recomendacion1, @Recomendacion1Fecha, @Recomendacion2, @Recomendacion" & _
                "2Fecha, @Recomendacion3, @Recomendacion3Fecha, @Fotografias, @FotografiasFecha, " & _
                "@ExamenMedico, @ExamenMedicoFecha, @Status, @StatusFecha, @FechaRegistro, @Datos" & _
                "Confirmados, @idCarreraAsignada, @CarreraAsignadaFecha, @Matricula, @Folio, @CuotaAdmision, @CuotaAdmisionFecha, @CartaAdmision, @CartaAdmisionFecha, @Login, @Password)"
            Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
            dbCommand.CommandText = queryString
            dbCommand.Connection = dbConnection

            Dim dbParam_nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nombre.ParameterName = "@Nombre"
            dbParam_nombre.Value = Nombre
            dbParam_nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nombre)
            Dim dbParam_apellidoPaterno As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_apellidoPaterno.ParameterName = "@ApellidoPaterno"
            dbParam_apellidoPaterno.Value = ApellidoPaterno
            dbParam_apellidoPaterno.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_apellidoPaterno)
            Dim dbParam_apellidoMaterno As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_apellidoMaterno.ParameterName = "@ApellidoMaterno"
            dbParam_apellidoMaterno.Value = ApellidoMaterno
            dbParam_apellidoMaterno.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_apellidoMaterno)
            Dim dbParam_nacimientoCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoCiudad.ParameterName = "@NacimientoCiudad"
            dbParam_nacimientoCiudad.Value = NacimientoCiudad
            dbParam_nacimientoCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nacimientoCiudad)
            Dim dbParam_nacimientoEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoEstado.ParameterName = "@NacimientoEstado"
            dbParam_nacimientoEstado.Value = NacimientoEstado
            dbParam_nacimientoEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nacimientoEstado)
            Dim dbParam_nacimientoidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoidPais.ParameterName = "@NacimientoidPais"
            dbParam_nacimientoidPais.Value = NacimientoidPais
            dbParam_nacimientoidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_nacimientoidPais)
            Dim dbParam_nacimientoNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoNacionalidad.ParameterName = "@NacimientoNacionalidad"
            dbParam_nacimientoNacionalidad.Value = NacimientoNacionalidad
            dbParam_nacimientoNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_nacimientoNacionalidad)
            Dim dbParam_nacimientoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoFecha.ParameterName = "@NacimientoFecha"
            dbParam_nacimientoFecha.Value = NacimientoFecha
            dbParam_nacimientoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_nacimientoFecha)
            Dim dbParam_estadoCivil As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_estadoCivil.ParameterName = "@EstadoCivil"
            dbParam_estadoCivil.Value = EstadoCivil
            dbParam_estadoCivil.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_estadoCivil)
            Dim dbParam_sexo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_sexo.ParameterName = "@Sexo"
            dbParam_sexo.Value = Sexo
            dbParam_sexo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_sexo)
            Dim dbParam_idReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idReligion.ParameterName = "@idReligion"
            dbParam_idReligion.Value = idReligion
            dbParam_idReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_idReligion)
            Dim dbParam_bautizadoASD As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_bautizadoASD.ParameterName = "@BautizadoASD"
            dbParam_bautizadoASD.Value = BautizadoASD
            dbParam_bautizadoASD.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_bautizadoASD)
            Dim dbParam_domicilioCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCalle.ParameterName = "@DomicilioCalle"
            dbParam_domicilioCalle.Value = DomicilioCalle
            dbParam_domicilioCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCalle)
            Dim dbParam_domicilioNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioNumero.ParameterName = "@DomicilioNumero"
            dbParam_domicilioNumero.Value = DomicilioNumero
            dbParam_domicilioNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioNumero)
            Dim dbParam_domicilioColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioColonia.ParameterName = "@DomicilioColonia"
            dbParam_domicilioColonia.Value = DomicilioColonia
            dbParam_domicilioColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioColonia)
            Dim dbParam_domicilioCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCiudad.ParameterName = "@DomicilioCiudad"
            dbParam_domicilioCiudad.Value = DomicilioCiudad
            dbParam_domicilioCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCiudad)
            Dim dbParam_domicilioEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioEstado.ParameterName = "@DomicilioEstado"
            dbParam_domicilioEstado.Value = DomicilioEstado
            dbParam_domicilioEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioEstado)
            Dim dbParam_domicilioidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioidPais.ParameterName = "@DomicilioidPais"
            dbParam_domicilioidPais.Value = DomicilioidPais
            dbParam_domicilioidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_domicilioidPais)
            Dim dbParam_domicilioCP As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCP.ParameterName = "@DomicilioCP"
            dbParam_domicilioCP.Value = DomicilioCP
            dbParam_domicilioCP.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCP)
            Dim dbParam_domicilioTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioTelefono.ParameterName = "@DomicilioTelefono"
            dbParam_domicilioTelefono.Value = DomicilioTelefono
            dbParam_domicilioTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioTelefono)
            Dim dbParam_domicilioFax As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioFax.ParameterName = "@DomicilioFax"
            dbParam_domicilioFax.Value = DomicilioFax
            dbParam_domicilioFax.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioFax)
            Dim dbParam_email As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_email.ParameterName = "@Email"
            dbParam_email.Value = Email
            dbParam_email.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_email)
            Dim dbParam_gradoDeseado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_gradoDeseado.ParameterName = "@GradoDeseado"
            dbParam_gradoDeseado.Value = GradoDeseado
            dbParam_gradoDeseado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_gradoDeseado)
            Dim dbParam_ultimoEstudioGradoObtenido As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioGradoObtenido.ParameterName = "@UltimoEstudioGradoObtenido"
            dbParam_ultimoEstudioGradoObtenido.Value = UltimoEstudioGradoObtenido
            dbParam_ultimoEstudioGradoObtenido.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioGradoObtenido)
            Dim dbParam_ultimoEstudioNombreInstitucion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioNombreInstitucion.ParameterName = "@UltimoEstudioNombreInstitucion"
            dbParam_ultimoEstudioNombreInstitucion.Value = UltimoEstudioNombreInstitucion
            dbParam_ultimoEstudioNombreInstitucion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioNombreInstitucion)
            Dim dbParam_ultimoEstudioFechaInicio As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioFechaInicio.ParameterName = "@UltimoEstudioFechaInicio"
            dbParam_ultimoEstudioFechaInicio.Value = UltimoEstudioFechaInicio
            dbParam_ultimoEstudioFechaInicio.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_ultimoEstudioFechaInicio)
            Dim dbParam_ultimoEstudioCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioCiudad.ParameterName = "@UltimoEstudioCiudad"
            dbParam_ultimoEstudioCiudad.Value = UltimoEstudioCiudad
            dbParam_ultimoEstudioCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioCiudad)
            Dim dbParam_ultimoEstudioEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioEstado.ParameterName = "@UltimoEstudioEstado"
            dbParam_ultimoEstudioEstado.Value = UltimoEstudioEstado
            dbParam_ultimoEstudioEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioEstado)
            Dim dbParam_ultimoEstudioidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioidPais.ParameterName = "@UltimoEstudioidPais"
            dbParam_ultimoEstudioidPais.Value = UltimoEstudioidPais
            dbParam_ultimoEstudioidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_ultimoEstudioidPais)
            Dim dbParam_ultimoEstudioFechaFin As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioFechaFin.ParameterName = "@UltimoEstudioFechaFin"
            dbParam_ultimoEstudioFechaFin.Value = UltimoEstudioFechaFin
            dbParam_ultimoEstudioFechaFin.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_ultimoEstudioFechaFin)
            Dim dbParam_carreraDeseada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_carreraDeseada.ParameterName = "@CarreraDeseada"
            dbParam_carreraDeseada.Value = CarreraDeseada
            dbParam_carreraDeseada.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_carreraDeseada)
            Dim dbParam_fechaInicioDeseada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fechaInicioDeseada.ParameterName = "@FechaInicioDeseada"
            dbParam_fechaInicioDeseada.Value = FechaInicioDeseada
            dbParam_fechaInicioDeseada.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fechaInicioDeseada)
            Dim dbParam_enfermedadCronica As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_enfermedadCronica.ParameterName = "@EnfermedadCronica"
            dbParam_enfermedadCronica.Value = EnfermedadCronica
            dbParam_enfermedadCronica.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_enfermedadCronica)
            Dim dbParam_enfermedadCronicaExplicacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_enfermedadCronicaExplicacion.ParameterName = "@EnfermedadCronicaExplicacion"
            dbParam_enfermedadCronicaExplicacion.Value = EnfermedadCronicaExplicacion
            dbParam_enfermedadCronicaExplicacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_enfermedadCronicaExplicacion)
            Dim dbParam_impedimentoFisico As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_impedimentoFisico.ParameterName = "@ImpedimentoFisico"
            dbParam_impedimentoFisico.Value = ImpedimentoFisico
            dbParam_impedimentoFisico.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_impedimentoFisico)
            Dim dbParam_impedimentoFisicoExplicacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_impedimentoFisicoExplicacion.ParameterName = "@ImpedimentoFisicoExplicacion"
            dbParam_impedimentoFisicoExplicacion.Value = ImpedimentoFisicoExplicacion
            dbParam_impedimentoFisicoExplicacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_impedimentoFisicoExplicacion)
            Dim dbParam_padreNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreNombre.ParameterName = "@PadreNombre"
            dbParam_padreNombre.Value = PadreNombre
            dbParam_padreNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreNombre)
            Dim dbParam_padreApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreApellidos.ParameterName = "@PadreApellidos"
            dbParam_padreApellidos.Value = PadreApellidos
            dbParam_padreApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreApellidos)
            Dim dbParam_padreidReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreidReligion.ParameterName = "@PadreidReligion"
            dbParam_padreidReligion.Value = PadreidReligion
            dbParam_padreidReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_padreidReligion)
            Dim dbParam_padreNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreNacionalidad.ParameterName = "@PadreNacionalidad"
            dbParam_padreNacionalidad.Value = PadreNacionalidad
            dbParam_padreNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_padreNacionalidad)
            Dim dbParam_padreOcupacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreOcupacion.ParameterName = "@PadreOcupacion"
            dbParam_padreOcupacion.Value = PadreOcupacion
            dbParam_padreOcupacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreOcupacion)
            Dim dbParam_madreNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreNombre.ParameterName = "@MadreNombre"
            dbParam_madreNombre.Value = MadreNombre
            dbParam_madreNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreNombre)
            Dim dbParam_madreApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreApellidos.ParameterName = "@MadreApellidos"
            dbParam_madreApellidos.Value = MadreApellidos
            dbParam_madreApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreApellidos)
            Dim dbParam_madreidReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreidReligion.ParameterName = "@MadreidReligion"
            dbParam_madreidReligion.Value = MadreidReligion
            dbParam_madreidReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_madreidReligion)
            Dim dbParam_madreNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreNacionalidad.ParameterName = "@MadreNacionalidad"
            dbParam_madreNacionalidad.Value = MadreNacionalidad
            dbParam_madreNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_madreNacionalidad)
            Dim dbParam_madreOcupacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreOcupacion.ParameterName = "@MadreOcupacion"
            dbParam_madreOcupacion.Value = MadreOcupacion
            dbParam_madreOcupacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreOcupacion)
            Dim dbParam_tutorTipo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorTipo.ParameterName = "@TutorTipo"
            dbParam_tutorTipo.Value = TutorTipo
            dbParam_tutorTipo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorTipo)
            Dim dbParam_tutorNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorNombre.ParameterName = "@TutorNombre"
            dbParam_tutorNombre.Value = TutorNombre
            dbParam_tutorNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorNombre)
            Dim dbParam_tutorApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorApellidos.ParameterName = "@TutorApellidos"
            dbParam_tutorApellidos.Value = TutorApellidos
            dbParam_tutorApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorApellidos)
            Dim dbParam_tutorCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCalle.ParameterName = "@TutorCalle"
            dbParam_tutorCalle.Value = TutorCalle
            dbParam_tutorCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCalle)
            Dim dbParam_tutorCalleNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCalleNumero.ParameterName = "@TutorCalleNumero"
            dbParam_tutorCalleNumero.Value = TutorCalleNumero
            dbParam_tutorCalleNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCalleNumero)
            Dim dbParam_tutorColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorColonia.ParameterName = "@TutorColonia"
            dbParam_tutorColonia.Value = TutorColonia
            dbParam_tutorColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorColonia)
            Dim dbParam_tutorCP As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCP.ParameterName = "@TutorCP"
            dbParam_tutorCP.Value = TutorCP
            dbParam_tutorCP.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCP)
            Dim dbParam_tutorCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCiudad.ParameterName = "@TutorCiudad"
            dbParam_tutorCiudad.Value = TutorCiudad
            dbParam_tutorCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCiudad)
            Dim dbParam_tutorEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorEstado.ParameterName = "@TutorEstado"
            dbParam_tutorEstado.Value = TutorEstado
            dbParam_tutorEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorEstado)
            Dim dbParam_tutoridPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutoridPais.ParameterName = "@TutoridPais"
            dbParam_tutoridPais.Value = TutoridPais
            dbParam_tutoridPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_tutoridPais)
            Dim dbParam_tutorTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorTelefono.ParameterName = "@TutorTelefono"
            dbParam_tutorTelefono.Value = TutorTelefono
            dbParam_tutorTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorTelefono)
            Dim dbParam_obreroStatus As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroStatus.ParameterName = "@ObreroStatus"
            dbParam_obreroStatus.Value = ObreroStatus
            dbParam_obreroStatus.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroStatus)
            Dim dbParam_obreroEsMi As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroEsMi.ParameterName = "@ObreroEsMi"
            dbParam_obreroEsMi.Value = ObreroEsMi
            dbParam_obreroEsMi.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroEsMi)
            Dim dbParam_obreroTipo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroTipo.ParameterName = "@ObreroTipo"
            dbParam_obreroTipo.Value = ObreroTipo
            dbParam_obreroTipo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroTipo)
            Dim dbParam_obreroUnion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroUnion.ParameterName = "@ObreroUnion"
            dbParam_obreroUnion.Value = ObreroUnion
            dbParam_obreroUnion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroUnion)
            Dim dbParam_obreroAsociacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroAsociacion.ParameterName = "@ObreroAsociacion"
            dbParam_obreroAsociacion.Value = ObreroAsociacion
            dbParam_obreroAsociacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroAsociacion)
            Dim dbParam_persona1Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Nombre.ParameterName = "@Persona1Nombre"
            dbParam_persona1Nombre.Value = Persona1Nombre
            dbParam_persona1Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Nombre)
            Dim dbParam_persona1Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Direccion.ParameterName = "@Persona1Direccion"
            dbParam_persona1Direccion.Value = Persona1Direccion
            dbParam_persona1Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Direccion)
            Dim dbParam_persona1Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Telefono.ParameterName = "@Persona1Telefono"
            dbParam_persona1Telefono.Value = Persona1Telefono
            dbParam_persona1Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Telefono)
            Dim dbParam_persona2Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Nombre.ParameterName = "@Persona2Nombre"
            dbParam_persona2Nombre.Value = Persona2Nombre
            dbParam_persona2Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Nombre)
            Dim dbParam_persona2Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Direccion.ParameterName = "@Persona2Direccion"
            dbParam_persona2Direccion.Value = Persona2Direccion
            dbParam_persona2Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Direccion)
            Dim dbParam_persona2Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Telefono.ParameterName = "@Persona2Telefono"
            dbParam_persona2Telefono.Value = Persona2Telefono
            dbParam_persona2Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Telefono)
            Dim dbParam_persona3Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Nombre.ParameterName = "@Persona3Nombre"
            dbParam_persona3Nombre.Value = Persona3Nombre
            dbParam_persona3Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Nombre)
            Dim dbParam_persona3Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Direccion.ParameterName = "@Persona3Direccion"
            dbParam_persona3Direccion.Value = Persona3Direccion
            dbParam_persona3Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Direccion)
            Dim dbParam_persona3Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Telefono.ParameterName = "@Persona3Telefono"
            dbParam_persona3Telefono.Value = Persona3Telefono
            dbParam_persona3Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Telefono)
            Dim dbParam_aceptaCompromiso As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_aceptaCompromiso.ParameterName = "@AceptaCompromiso"
            dbParam_aceptaCompromiso.Value = AceptaCompromiso
            dbParam_aceptaCompromiso.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_aceptaCompromiso)
            Dim dbParam_externadoSolicitud As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoSolicitud.ParameterName = "@ExternadoSolicitud"
            dbParam_externadoSolicitud.Value = ExternadoSolicitud
            dbParam_externadoSolicitud.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_externadoSolicitud)
            Dim dbParam_externadoRazon As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoRazon.ParameterName = "@ExternadoRazon"
            dbParam_externadoRazon.Value = ExternadoRazon
            dbParam_externadoRazon.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoRazon)
            Dim dbParam_externadoCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoCalle.ParameterName = "@ExternadoCalle"
            dbParam_externadoCalle.Value = ExternadoCalle
            dbParam_externadoCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoCalle)
            Dim dbParam_externadoColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoColonia.ParameterName = "@ExternadoColonia"
            dbParam_externadoColonia.Value = ExternadoColonia
            dbParam_externadoColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoColonia)
            Dim dbParam_externadoNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoNumero.ParameterName = "@ExternadoNumero"
            dbParam_externadoNumero.Value = ExternadoNumero
            dbParam_externadoNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoNumero)
            Dim dbParam_externadoTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoTelefono.ParameterName = "@ExternadoTelefono"
            dbParam_externadoTelefono.Value = ExternadoTelefono
            dbParam_externadoTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoTelefono)
            Dim dbParam_actaNacimieto As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_actaNacimieto.ParameterName = "@ActaNacimiento"
            dbParam_actaNacimieto.Value = ActaNacimiento
            dbParam_actaNacimieto.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_actaNacimieto)
            Dim dbParam_actaNacimientoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_actaNacimientoFecha.ParameterName = "@ActaNacimientoFecha"
            dbParam_actaNacimientoFecha.Value = ActaNacimientoFecha
            dbParam_actaNacimientoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_actaNacimientoFecha)
            Dim dbParam_certificadoSecundaria As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoSecundaria.ParameterName = "@CertificadoSecundaria"
            dbParam_certificadoSecundaria.Value = CertificadoSecundaria
            dbParam_certificadoSecundaria.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_certificadoSecundaria)
            Dim dbParam_certificadoSecundariaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoSecundariaFecha.ParameterName = "@CertificadoSecundariaFecha"
            dbParam_certificadoSecundariaFecha.Value = CertificadoSecundariaFecha
            dbParam_certificadoSecundariaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_certificadoSecundariaFecha)
            Dim dbParam_certificadoBachillerato As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoBachillerato.ParameterName = "@CertificadoBachillerato"
            dbParam_certificadoBachillerato.Value = CertificadoBachillerato
            dbParam_certificadoBachillerato.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_certificadoBachillerato)
            Dim dbParam_certificadoBachilleratoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoBachilleratoFecha.ParameterName = "@CertificadoBachilleratoFecha"
            dbParam_certificadoBachilleratoFecha.Value = CertificadoBachilleratoFecha
            dbParam_certificadoBachilleratoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_certificadoBachilleratoFecha)
            Dim dbParam_buenaConducta As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_buenaConducta.ParameterName = "@BuenaConducta"
            dbParam_buenaConducta.Value = BuenaConducta
            dbParam_buenaConducta.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_buenaConducta)
            Dim dbParam_buenaConductaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_buenaConductaFecha.ParameterName = "@BuenaConductaFecha"
            dbParam_buenaConductaFecha.Value = BuenaConductaFecha
            dbParam_buenaConductaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_buenaConductaFecha)
            Dim dbParam_recomendacion1 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion1.ParameterName = "@Recomendacion1"
            dbParam_recomendacion1.Value = Recomendacion1
            dbParam_recomendacion1.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion1)
            Dim dbParam_recomendacion1Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion1Fecha.ParameterName = "@Recomendacion1Fecha"
            dbParam_recomendacion1Fecha.Value = Recomendacion1Fecha
            dbParam_recomendacion1Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion1Fecha)
            Dim dbParam_recomendacion2 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion2.ParameterName = "@Recomendacion2"
            dbParam_recomendacion2.Value = Recomendacion2
            dbParam_recomendacion2.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion2)
            Dim dbParam_recomendacion2Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion2Fecha.ParameterName = "@Recomendacion2Fecha"
            dbParam_recomendacion2Fecha.Value = Recomendacion2Fecha
            dbParam_recomendacion2Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion2Fecha)
            Dim dbParam_recomendacion3 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion3.ParameterName = "@Recomendacion3"
            dbParam_recomendacion3.Value = Recomendacion3
            dbParam_recomendacion3.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion3)
            Dim dbParam_recomendacion3Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion3Fecha.ParameterName = "@Recomendacion3Fecha"
            dbParam_recomendacion3Fecha.Value = Recomendacion3Fecha
            dbParam_recomendacion3Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion3Fecha)
            Dim dbParam_fotografias As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fotografias.ParameterName = "@Fotografias"
            dbParam_fotografias.Value = Fotografias
            dbParam_fotografias.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_fotografias)
            Dim dbParam_fotografiasFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fotografiasFecha.ParameterName = "@FotografiasFecha"
            dbParam_fotografiasFecha.Value = FotografiasFecha
            dbParam_fotografiasFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fotografiasFecha)
            Dim dbParam_examenMedico As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_examenMedico.ParameterName = "@ExamenMedico"
            dbParam_examenMedico.Value = ExamenMedico
            dbParam_examenMedico.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_examenMedico)
            Dim dbParam_examenMedicoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_examenMedicoFecha.ParameterName = "@ExamenMedicoFecha"
            dbParam_examenMedicoFecha.Value = ExamenMedicoFecha
            dbParam_examenMedicoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_examenMedicoFecha)
            Dim dbParam_status As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_status.ParameterName = "@Status"
            dbParam_status.Value = Status
            dbParam_status.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_status)
            Dim dbParam_statusFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_statusFecha.ParameterName = "@StatusFecha"
            dbParam_statusFecha.Value = StatusFecha
            dbParam_statusFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_statusFecha)
            Dim dbParam_fechaRegistro As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fechaRegistro.ParameterName = "@FechaRegistro"
            dbParam_fechaRegistro.Value = FechaRegistro
            dbParam_fechaRegistro.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fechaRegistro)
            Dim dbParam_datosConfirmados As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_datosConfirmados.ParameterName = "@DatosConfirmados"
            dbParam_datosConfirmados.Value = DatosConfirmados
            dbParam_datosConfirmados.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_datosConfirmados)
            Dim dbParam_idCarreraAsignada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idCarreraAsignada.ParameterName = "@idCarreraAsignada"
            dbParam_idCarreraAsignada.Value = idCarreraAsignada
            dbParam_idCarreraAsignada.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_idCarreraAsignada)
            Dim dbParam_carreraAsignadaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_carreraAsignadaFecha.ParameterName = "@CarreraAsignadaFecha"
            dbParam_carreraAsignadaFecha.Value = CarreraAsignadaFecha
            dbParam_carreraAsignadaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_carreraAsignadaFecha)
            Dim dbParam_matricula As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_matricula.ParameterName = "@Matricula"
            dbParam_matricula.Value = Matricula
            dbParam_matricula.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_matricula)
            Dim dbParam_folio As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_folio.ParameterName = "@Folio"
            dbParam_folio.Value = Folio
            dbParam_folio.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_folio)
            Dim dbParam_cuotaadmision As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cuotaadmision.ParameterName = "@CuotaAdmision"
            dbParam_cuotaadmision.Value = CuotaAdmision
            dbParam_cuotaadmision.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_cuotaadmision)
            Dim dbParam_cuotaadmisionFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cuotaadmisionFecha.ParameterName = "@CuotaAdmisionFecha"
            dbParam_cuotaadmisionFecha.Value = CuotaAdmisionFecha
            dbParam_cuotaadmisionFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_cuotaadmisionFecha)
            Dim dbParam_cartaadmision As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cartaadmision.ParameterName = "@CartaAdmision"
            dbParam_cartaadmision.Value = CartaAdmision
            dbParam_cartaadmision.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_cartaadmision)
            Dim dbParam_cartaadmisionFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cartaadmisionFecha.ParameterName = "@CartaAdmisionFecha"
            dbParam_cartaadmisionFecha.Value = CartaAdmisionFecha
            dbParam_cartaadmisionFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_cartaadmisionFecha)
            Dim dbParam_login As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_login.ParameterName = "@Login"
            dbParam_login.Value = Login
            dbParam_login.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_login)
            Dim dbParam_password As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_password.ParameterName = "@Password"
            dbParam_password.Value = Password
            dbParam_password.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_password)

            Dim rowsAffected As Integer = 0
            dbConnection.Open()
            Try
                rowsAffected = dbCommand.ExecuteNonQuery
                queryString = "SELECT @@IDENTITY as lastId"
                Dim sqlCommand2 As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(queryString, dbConnection)
                Dim dataReader As System.Data.SqlClient.SqlDataReader = sqlCommand2.ExecuteReader()
                dataReader.Read()
                If Not Convert.IsDBNull(dataReader("lastId")) Then
                    Me.idAlumnoProspecto = CType(dataReader("lastId"), Integer)
                    Me.Folio = String.Format("{0: 0#########}", Me.idAlumnoProspecto)
                    Me.Update()
                End If
            Finally
                dbConnection.Close()
            End Try

            Return rowsAffected
        End Function


        Function Update() As Integer
            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionStringAdmision").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

            Dim queryString As String = "UPDATE [AlumnoProspecto] SET [idReligion]=@idReligion, [Recomendacion1]=@Recomend" & _
                "acion1, [Recomendacion2]=@Recomendacion2, [Recomendacion3]=@Recomendacion3, [Enf" & _
                "ermedadCronica]=@EnfermedadCronica, [ObreroUnion]=@ObreroUnion, [PadreidReligion" & _
                "]=@PadreidReligion, [TutorApellidos]=@TutorApellidos, [DomicilioCiudad]=@Domicil" & _
                "ioCiudad, [UltimoEstudioFechaFin]=@UltimoEstudioFechaFin, [CarreraDeseada]=@Carr" & _
                "eraDeseada, [NacimientoFecha]=@NacimientoFecha, [ObreroTipo]=@ObreroTipo, [Padre" & _
                "Nacionalidad]=@PadreNacionalidad, [CertificadoBachillerato]=@CertificadoBachille" & _
                "rato, [UltimoEstudioEstado]=@UltimoEstudioEstado, [UltimoEstudioNombreInstitucio" & _
                "n]=@UltimoEstudioNombreInstitucion, [DomicilioTelefono]=@DomicilioTelefono, [Exa" & _
                "menMedico]=@ExamenMedico, [PadreOcupacion]=@PadreOcupacion, [NacimientoidPais]=@" & _
                "NacimientoidPais, [ExamenMedicoFecha]=@ExamenMedicoFecha, [TutorCP]=@TutorCP, [E" & _
                "stadoCivil]=@EstadoCivil, [DomicilioNumero]=@DomicilioNumero, [Recomendacion3Fec" & _
                "ha]=@Recomendacion3Fecha, [Persona2Nombre]=@Persona2Nombre, [Persona2Direccion]=" & _
                "@Persona2Direccion, [MadreOcupacion]=@MadreOcupacion, [Sexo]=@Sexo, [Recomendaci" & _
                "on1Fecha]=@Recomendacion1Fecha, [ActaNacimientoFecha]=@ActaNacimientoFecha, [Mad" & _
                "reidReligion]=@MadreidReligion, [DomicilioCP]=@DomicilioCP, [CarreraAsignadaFech" & _
                "a]=@CarreraAsignadaFecha, [UltimoEstudioFechaInicio]=@UltimoEstudioFechaInicio, " & _
                "[DatosConfirmados]=@DatosConfirmados, [BuenaConducta]=@BuenaConducta, [TutorCall" & _
                "e]=@TutorCalle, [Persona1Direccion]=@Persona1Direccion, [MadreNombre]=@MadreNomb" & _
                "re, [UltimoEstudioidPais]=@UltimoEstudioidPais, [UltimoEstudioCiudad]=@UltimoEst" & _
                "udioCiudad, [PadreNombre]=@PadreNombre, [ExternadoRazon]=@ExternadoRazon, [Tutor" & _
                "Ciudad]=@TutorCiudad, [AceptaCompromiso]=@AceptaCompromiso, [NacimientoEstado]=@" & _
                "NacimientoEstado, [Folio]=@Folio, [TutorCalleNumero]=@TutorCalleNumero, [Persona" & _
                "1Nombre]=@Persona1Nombre, [DomicilioFax]=@DomicilioFax, [DomicilioidPais]=@Domic" & _
                "ilioidPais, [FechaRegistro]=@FechaRegistro, [ApellidoPaterno]=@ApellidoPaterno, " & _
                "[ActaNacimiento]=@ActaNacimiento, [MadreNacionalidad]=@MadreNacionalidad, [Domicil" & _
                "ioEstado]=@DomicilioEstado, [ImpedimentoFisicoExplicacion]=@ImpedimentoFisicoExp" & _
                "licacion, [ImpedimentoFisico]=@ImpedimentoFisico, [StatusFecha]=@StatusFecha, [F" & _
                "otografiasFecha]=@FotografiasFecha, [Fotografias]=@Fotografias, [Status]=@Status" & _
                ", [MadreApellidos]=@MadreApellidos, [DomicilioColonia]=@DomicilioColonia, [Enfer" & _
                "medadCronicaExplicacion]=@EnfermedadCronicaExplicacion, [Persona3Nombre]=@Person" & _
                "a3Nombre, [TutorColonia]=@TutorColonia, [ObreroStatus]=@ObreroStatus, [Externado" & _
                "Telefono]=@ExternadoTelefono, [TutoridPais]=@TutoridPais, [ApellidoMaterno]=@Ape" & _
                "llidoMaterno, [GradoDeseado]=@GradoDeseado, [UltimoEstudioGradoObtenido]=@Ultimo" & _
                "EstudioGradoObtenido, [ObreroAsociacion]=@ObreroAsociacion, [BautizadoASD]=@Baut" & _
                "izadoASD, [Persona2Telefono]=@Persona2Telefono, [TutorNombre]=@TutorNombre, [Pad" & _
                "reApellidos]=@PadreApellidos, [CertificadoBachilleratoFecha]=@CertificadoBachill" & _
                "eratoFecha, [ExternadoNumero]=@ExternadoNumero, [ExternadoColonia]=@ExternadoCol" & _
                "onia, [NacimientoNacionalidad]=@NacimientoNacionalidad, [idCarreraAsignada]=@idC" & _
                "arreraAsignada, [CertificadoSecundariaFecha]=@CertificadoSecundariaFecha, [Email" & _
                "]=@Email, [TutorTelefono]=@TutorTelefono, [DomicilioCalle]=@DomicilioCalle, [Obr" & _
                "eroEsMi]=@ObreroEsMi, [Persona1Telefono]=@Persona1Telefono, [TutorTipo]=@TutorTi" & _
                "po, [CertificadoSecundaria]=@CertificadoSecundaria, [Persona3Telefono]=@Persona3" & _
                "Telefono, [TutorEstado]=@TutorEstado, [ExternadoSolicitud]=@ExternadoSolicitud, " & _
                "[Persona3Direccion]=@Persona3Direccion, [Nombre]=@Nombre, [Matricula]=@Matricula" & _
                ", [Recomendacion2Fecha]=@Recomendacion2Fecha, [FechaInicioDeseada]=@FechaInicioD" & _
                "eseada, [NacimientoCiudad]=@NacimientoCiudad, [ExternadoCalle]=@ExternadoCalle, " & _
                "[BuenaConductaFecha]=@BuenaConductaFecha, CuotaAdmision=@CuotaAdmision,  " & _
                " CuotaAdmisionFecha=@CuotaAdmisionFecha, CartaAdmision=@CartaAdmision, " & _
                " CartaAdmisionFecha=@CartaAdmisionFecha, login=@Login, Password=@Password WHERE ([AlumnoProspecto].[idAlumnoProsp" & _
                "ecto] = @idAlumnoProspecto)"
            Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
            dbCommand.CommandText = queryString
            dbCommand.Connection = dbConnection

            Dim dbParam_idAlumnoProspecto As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idAlumnoProspecto.ParameterName = "@idAlumnoProspecto"
            dbParam_idAlumnoProspecto.Value = idAlumnoProspecto
            dbParam_idAlumnoProspecto.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_idAlumnoProspecto)
            Dim dbParam_nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nombre.ParameterName = "@Nombre"
            dbParam_nombre.Value = Nombre
            dbParam_nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nombre)
            Dim dbParam_apellidoPaterno As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_apellidoPaterno.ParameterName = "@ApellidoPaterno"
            dbParam_apellidoPaterno.Value = ApellidoPaterno
            dbParam_apellidoPaterno.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_apellidoPaterno)
            Dim dbParam_apellidoMaterno As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_apellidoMaterno.ParameterName = "@ApellidoMaterno"
            dbParam_apellidoMaterno.Value = ApellidoMaterno
            dbParam_apellidoMaterno.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_apellidoMaterno)
            Dim dbParam_nacimientoCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoCiudad.ParameterName = "@NacimientoCiudad"
            dbParam_nacimientoCiudad.Value = NacimientoCiudad
            dbParam_nacimientoCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nacimientoCiudad)
            Dim dbParam_nacimientoEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoEstado.ParameterName = "@NacimientoEstado"
            dbParam_nacimientoEstado.Value = NacimientoEstado
            dbParam_nacimientoEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_nacimientoEstado)
            Dim dbParam_nacimientoidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoidPais.ParameterName = "@NacimientoidPais"
            dbParam_nacimientoidPais.Value = NacimientoidPais
            dbParam_nacimientoidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_nacimientoidPais)
            Dim dbParam_nacimientoNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoNacionalidad.ParameterName = "@NacimientoNacionalidad"
            dbParam_nacimientoNacionalidad.Value = NacimientoNacionalidad
            dbParam_nacimientoNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_nacimientoNacionalidad)
            Dim dbParam_nacimientoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_nacimientoFecha.ParameterName = "@NacimientoFecha"
            dbParam_nacimientoFecha.Value = NacimientoFecha
            dbParam_nacimientoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_nacimientoFecha)
            Dim dbParam_estadoCivil As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_estadoCivil.ParameterName = "@EstadoCivil"
            dbParam_estadoCivil.Value = EstadoCivil
            dbParam_estadoCivil.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_estadoCivil)
            Dim dbParam_sexo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_sexo.ParameterName = "@Sexo"
            dbParam_sexo.Value = Sexo
            dbParam_sexo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_sexo)
            Dim dbParam_idReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idReligion.ParameterName = "@idReligion"
            dbParam_idReligion.Value = idReligion
            dbParam_idReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_idReligion)
            Dim dbParam_bautizadoASD As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_bautizadoASD.ParameterName = "@BautizadoASD"
            dbParam_bautizadoASD.Value = BautizadoASD
            dbParam_bautizadoASD.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_bautizadoASD)
            Dim dbParam_domicilioCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCalle.ParameterName = "@DomicilioCalle"
            dbParam_domicilioCalle.Value = DomicilioCalle
            dbParam_domicilioCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCalle)
            Dim dbParam_domicilioNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioNumero.ParameterName = "@DomicilioNumero"
            dbParam_domicilioNumero.Value = DomicilioNumero
            dbParam_domicilioNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioNumero)
            Dim dbParam_domicilioColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioColonia.ParameterName = "@DomicilioColonia"
            dbParam_domicilioColonia.Value = DomicilioColonia
            dbParam_domicilioColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioColonia)
            Dim dbParam_domicilioCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCiudad.ParameterName = "@DomicilioCiudad"
            dbParam_domicilioCiudad.Value = DomicilioCiudad
            dbParam_domicilioCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCiudad)
            Dim dbParam_domicilioEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioEstado.ParameterName = "@DomicilioEstado"
            dbParam_domicilioEstado.Value = DomicilioEstado
            dbParam_domicilioEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioEstado)
            Dim dbParam_domicilioidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioidPais.ParameterName = "@DomicilioidPais"
            dbParam_domicilioidPais.Value = DomicilioidPais
            dbParam_domicilioidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_domicilioidPais)
            Dim dbParam_domicilioCP As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioCP.ParameterName = "@DomicilioCP"
            dbParam_domicilioCP.Value = DomicilioCP
            dbParam_domicilioCP.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioCP)
            Dim dbParam_domicilioTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioTelefono.ParameterName = "@DomicilioTelefono"
            dbParam_domicilioTelefono.Value = DomicilioTelefono
            dbParam_domicilioTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioTelefono)
            Dim dbParam_domicilioFax As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_domicilioFax.ParameterName = "@DomicilioFax"
            dbParam_domicilioFax.Value = DomicilioFax
            dbParam_domicilioFax.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_domicilioFax)
            Dim dbParam_email As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_email.ParameterName = "@Email"
            dbParam_email.Value = Email
            dbParam_email.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_email)
            Dim dbParam_gradoDeseado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_gradoDeseado.ParameterName = "@GradoDeseado"
            dbParam_gradoDeseado.Value = GradoDeseado
            dbParam_gradoDeseado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_gradoDeseado)
            Dim dbParam_ultimoEstudioGradoObtenido As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioGradoObtenido.ParameterName = "@UltimoEstudioGradoObtenido"
            dbParam_ultimoEstudioGradoObtenido.Value = UltimoEstudioGradoObtenido
            dbParam_ultimoEstudioGradoObtenido.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioGradoObtenido)
            Dim dbParam_ultimoEstudioNombreInstitucion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioNombreInstitucion.ParameterName = "@UltimoEstudioNombreInstitucion"
            dbParam_ultimoEstudioNombreInstitucion.Value = UltimoEstudioNombreInstitucion
            dbParam_ultimoEstudioNombreInstitucion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioNombreInstitucion)
            Dim dbParam_ultimoEstudioFechaInicio As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioFechaInicio.ParameterName = "@UltimoEstudioFechaInicio"
            dbParam_ultimoEstudioFechaInicio.Value = UltimoEstudioFechaInicio
            dbParam_ultimoEstudioFechaInicio.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_ultimoEstudioFechaInicio)
            Dim dbParam_ultimoEstudioCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioCiudad.ParameterName = "@UltimoEstudioCiudad"
            dbParam_ultimoEstudioCiudad.Value = UltimoEstudioCiudad
            dbParam_ultimoEstudioCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioCiudad)
            Dim dbParam_ultimoEstudioEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioEstado.ParameterName = "@UltimoEstudioEstado"
            dbParam_ultimoEstudioEstado.Value = UltimoEstudioEstado
            dbParam_ultimoEstudioEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_ultimoEstudioEstado)
            Dim dbParam_ultimoEstudioidPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioidPais.ParameterName = "@UltimoEstudioidPais"
            dbParam_ultimoEstudioidPais.Value = UltimoEstudioidPais
            dbParam_ultimoEstudioidPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_ultimoEstudioidPais)
            Dim dbParam_ultimoEstudioFechaFin As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_ultimoEstudioFechaFin.ParameterName = "@UltimoEstudioFechaFin"
            dbParam_ultimoEstudioFechaFin.Value = UltimoEstudioFechaFin
            dbParam_ultimoEstudioFechaFin.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_ultimoEstudioFechaFin)
            Dim dbParam_carreraDeseada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_carreraDeseada.ParameterName = "@CarreraDeseada"
            dbParam_carreraDeseada.Value = CarreraDeseada
            dbParam_carreraDeseada.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_carreraDeseada)
            Dim dbParam_fechaInicioDeseada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fechaInicioDeseada.ParameterName = "@FechaInicioDeseada"
            dbParam_fechaInicioDeseada.Value = FechaInicioDeseada
            dbParam_fechaInicioDeseada.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fechaInicioDeseada)
            Dim dbParam_enfermedadCronica As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_enfermedadCronica.ParameterName = "@EnfermedadCronica"
            dbParam_enfermedadCronica.Value = EnfermedadCronica
            dbParam_enfermedadCronica.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_enfermedadCronica)
            Dim dbParam_enfermedadCronicaExplicacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_enfermedadCronicaExplicacion.ParameterName = "@EnfermedadCronicaExplicacion"
            dbParam_enfermedadCronicaExplicacion.Value = EnfermedadCronicaExplicacion
            dbParam_enfermedadCronicaExplicacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_enfermedadCronicaExplicacion)
            Dim dbParam_impedimentoFisico As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_impedimentoFisico.ParameterName = "@ImpedimentoFisico"
            dbParam_impedimentoFisico.Value = ImpedimentoFisico
            dbParam_impedimentoFisico.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_impedimentoFisico)
            Dim dbParam_impedimentoFisicoExplicacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_impedimentoFisicoExplicacion.ParameterName = "@ImpedimentoFisicoExplicacion"
            dbParam_impedimentoFisicoExplicacion.Value = ImpedimentoFisicoExplicacion
            dbParam_impedimentoFisicoExplicacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_impedimentoFisicoExplicacion)
            Dim dbParam_padreNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreNombre.ParameterName = "@PadreNombre"
            dbParam_padreNombre.Value = PadreNombre
            dbParam_padreNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreNombre)
            Dim dbParam_padreApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreApellidos.ParameterName = "@PadreApellidos"
            dbParam_padreApellidos.Value = PadreApellidos
            dbParam_padreApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreApellidos)
            Dim dbParam_padreidReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreidReligion.ParameterName = "@PadreidReligion"
            dbParam_padreidReligion.Value = PadreidReligion
            dbParam_padreidReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_padreidReligion)
            Dim dbParam_padreNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreNacionalidad.ParameterName = "@PadreNacionalidad"
            dbParam_padreNacionalidad.Value = PadreNacionalidad
            dbParam_padreNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_padreNacionalidad)
            Dim dbParam_padreOcupacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_padreOcupacion.ParameterName = "@PadreOcupacion"
            dbParam_padreOcupacion.Value = PadreOcupacion
            dbParam_padreOcupacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_padreOcupacion)
            Dim dbParam_madreNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreNombre.ParameterName = "@MadreNombre"
            dbParam_madreNombre.Value = MadreNombre
            dbParam_madreNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreNombre)
            Dim dbParam_madreApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreApellidos.ParameterName = "@MadreApellidos"
            dbParam_madreApellidos.Value = MadreApellidos
            dbParam_madreApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreApellidos)
            Dim dbParam_madreidReligion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreidReligion.ParameterName = "@MadreidReligion"
            dbParam_madreidReligion.Value = MadreidReligion
            dbParam_madreidReligion.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_madreidReligion)
            Dim dbParam_madreNacionalidad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreNacionalidad.ParameterName = "@MadreNacionalidad"
            dbParam_madreNacionalidad.Value = MadreNacionalidad
            dbParam_madreNacionalidad.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_madreNacionalidad)
            Dim dbParam_madreOcupacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_madreOcupacion.ParameterName = "@MadreOcupacion"
            dbParam_madreOcupacion.Value = MadreOcupacion
            dbParam_madreOcupacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_madreOcupacion)
            Dim dbParam_tutorTipo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorTipo.ParameterName = "@TutorTipo"
            dbParam_tutorTipo.Value = TutorTipo
            dbParam_tutorTipo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorTipo)
            Dim dbParam_tutorNombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorNombre.ParameterName = "@TutorNombre"
            dbParam_tutorNombre.Value = TutorNombre
            dbParam_tutorNombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorNombre)
            Dim dbParam_tutorApellidos As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorApellidos.ParameterName = "@TutorApellidos"
            dbParam_tutorApellidos.Value = TutorApellidos
            dbParam_tutorApellidos.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorApellidos)
            Dim dbParam_tutorCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCalle.ParameterName = "@TutorCalle"
            dbParam_tutorCalle.Value = TutorCalle
            dbParam_tutorCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCalle)
            Dim dbParam_tutorCalleNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCalleNumero.ParameterName = "@TutorCalleNumero"
            dbParam_tutorCalleNumero.Value = TutorCalleNumero
            dbParam_tutorCalleNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCalleNumero)
            Dim dbParam_tutorColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorColonia.ParameterName = "@TutorColonia"
            dbParam_tutorColonia.Value = TutorColonia
            dbParam_tutorColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorColonia)
            Dim dbParam_tutorCP As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCP.ParameterName = "@TutorCP"
            dbParam_tutorCP.Value = TutorCP
            dbParam_tutorCP.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCP)
            Dim dbParam_tutorCiudad As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorCiudad.ParameterName = "@TutorCiudad"
            dbParam_tutorCiudad.Value = TutorCiudad
            dbParam_tutorCiudad.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorCiudad)
            Dim dbParam_tutorEstado As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorEstado.ParameterName = "@TutorEstado"
            dbParam_tutorEstado.Value = TutorEstado
            dbParam_tutorEstado.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorEstado)
            Dim dbParam_tutoridPais As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutoridPais.ParameterName = "@TutoridPais"
            dbParam_tutoridPais.Value = TutoridPais
            dbParam_tutoridPais.DbType = System.Data.DbType.Int32
            dbCommand.Parameters.Add(dbParam_tutoridPais)
            Dim dbParam_tutorTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_tutorTelefono.ParameterName = "@TutorTelefono"
            dbParam_tutorTelefono.Value = TutorTelefono
            dbParam_tutorTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_tutorTelefono)
            Dim dbParam_obreroStatus As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroStatus.ParameterName = "@ObreroStatus"
            dbParam_obreroStatus.Value = ObreroStatus
            dbParam_obreroStatus.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroStatus)
            Dim dbParam_obreroEsMi As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroEsMi.ParameterName = "@ObreroEsMi"
            dbParam_obreroEsMi.Value = ObreroEsMi
            dbParam_obreroEsMi.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroEsMi)
            Dim dbParam_obreroTipo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroTipo.ParameterName = "@ObreroTipo"
            dbParam_obreroTipo.Value = ObreroTipo
            dbParam_obreroTipo.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroTipo)
            Dim dbParam_obreroUnion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroUnion.ParameterName = "@ObreroUnion"
            dbParam_obreroUnion.Value = ObreroUnion
            dbParam_obreroUnion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroUnion)
            Dim dbParam_obreroAsociacion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_obreroAsociacion.ParameterName = "@ObreroAsociacion"
            dbParam_obreroAsociacion.Value = ObreroAsociacion
            dbParam_obreroAsociacion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_obreroAsociacion)
            Dim dbParam_persona1Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Nombre.ParameterName = "@Persona1Nombre"
            dbParam_persona1Nombre.Value = Persona1Nombre
            dbParam_persona1Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Nombre)
            Dim dbParam_persona1Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Direccion.ParameterName = "@Persona1Direccion"
            dbParam_persona1Direccion.Value = Persona1Direccion
            dbParam_persona1Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Direccion)
            Dim dbParam_persona1Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona1Telefono.ParameterName = "@Persona1Telefono"
            dbParam_persona1Telefono.Value = Persona1Telefono
            dbParam_persona1Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona1Telefono)
            Dim dbParam_persona2Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Nombre.ParameterName = "@Persona2Nombre"
            dbParam_persona2Nombre.Value = Persona2Nombre
            dbParam_persona2Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Nombre)
            Dim dbParam_persona2Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Direccion.ParameterName = "@Persona2Direccion"
            dbParam_persona2Direccion.Value = Persona2Direccion
            dbParam_persona2Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Direccion)
            Dim dbParam_persona2Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona2Telefono.ParameterName = "@Persona2Telefono"
            dbParam_persona2Telefono.Value = Persona2Telefono
            dbParam_persona2Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona2Telefono)
            Dim dbParam_persona3Nombre As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Nombre.ParameterName = "@Persona3Nombre"
            dbParam_persona3Nombre.Value = Persona3Nombre
            dbParam_persona3Nombre.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Nombre)
            Dim dbParam_persona3Direccion As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Direccion.ParameterName = "@Persona3Direccion"
            dbParam_persona3Direccion.Value = Persona3Direccion
            dbParam_persona3Direccion.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Direccion)
            Dim dbParam_persona3Telefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_persona3Telefono.ParameterName = "@Persona3Telefono"
            dbParam_persona3Telefono.Value = Persona3Telefono
            dbParam_persona3Telefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_persona3Telefono)
            Dim dbParam_aceptaCompromiso As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_aceptaCompromiso.ParameterName = "@AceptaCompromiso"
            dbParam_aceptaCompromiso.Value = AceptaCompromiso
            dbParam_aceptaCompromiso.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_aceptaCompromiso)
            Dim dbParam_externadoSolicitud As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoSolicitud.ParameterName = "@ExternadoSolicitud"
            dbParam_externadoSolicitud.Value = ExternadoSolicitud
            dbParam_externadoSolicitud.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_externadoSolicitud)
            Dim dbParam_externadoRazon As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoRazon.ParameterName = "@ExternadoRazon"
            dbParam_externadoRazon.Value = ExternadoRazon
            dbParam_externadoRazon.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoRazon)
            Dim dbParam_externadoCalle As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoCalle.ParameterName = "@ExternadoCalle"
            dbParam_externadoCalle.Value = ExternadoCalle
            dbParam_externadoCalle.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoCalle)
            Dim dbParam_externadoColonia As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoColonia.ParameterName = "@ExternadoColonia"
            dbParam_externadoColonia.Value = ExternadoColonia
            dbParam_externadoColonia.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoColonia)
            Dim dbParam_externadoNumero As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoNumero.ParameterName = "@ExternadoNumero"
            dbParam_externadoNumero.Value = ExternadoNumero
            dbParam_externadoNumero.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoNumero)
            Dim dbParam_externadoTelefono As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_externadoTelefono.ParameterName = "@ExternadoTelefono"
            dbParam_externadoTelefono.Value = ExternadoTelefono
            dbParam_externadoTelefono.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_externadoTelefono)
            Dim dbParam_actaNacimieto As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_actaNacimieto.ParameterName = "@ActaNacimiento"
            dbParam_actaNacimieto.Value = ActaNacimiento
            dbParam_actaNacimieto.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_actaNacimieto)
            Dim dbParam_actaNacimientoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_actaNacimientoFecha.ParameterName = "@ActaNacimientoFecha"
            dbParam_actaNacimientoFecha.Value = ActaNacimientoFecha
            dbParam_actaNacimientoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_actaNacimientoFecha)
            Dim dbParam_certificadoSecundaria As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoSecundaria.ParameterName = "@CertificadoSecundaria"
            dbParam_certificadoSecundaria.Value = CertificadoSecundaria
            dbParam_certificadoSecundaria.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_certificadoSecundaria)
            Dim dbParam_certificadoSecundariaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoSecundariaFecha.ParameterName = "@CertificadoSecundariaFecha"
            dbParam_certificadoSecundariaFecha.Value = CertificadoSecundariaFecha
            dbParam_certificadoSecundariaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_certificadoSecundariaFecha)
            Dim dbParam_certificadoBachillerato As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoBachillerato.ParameterName = "@CertificadoBachillerato"
            dbParam_certificadoBachillerato.Value = CertificadoBachillerato
            dbParam_certificadoBachillerato.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_certificadoBachillerato)
            Dim dbParam_certificadoBachilleratoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_certificadoBachilleratoFecha.ParameterName = "@CertificadoBachilleratoFecha"
            dbParam_certificadoBachilleratoFecha.Value = CertificadoBachilleratoFecha
            dbParam_certificadoBachilleratoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_certificadoBachilleratoFecha)
            Dim dbParam_buenaConducta As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_buenaConducta.ParameterName = "@BuenaConducta"
            dbParam_buenaConducta.Value = BuenaConducta
            dbParam_buenaConducta.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_buenaConducta)
            Dim dbParam_buenaConductaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_buenaConductaFecha.ParameterName = "@BuenaConductaFecha"
            dbParam_buenaConductaFecha.Value = BuenaConductaFecha
            dbParam_buenaConductaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_buenaConductaFecha)
            Dim dbParam_recomendacion1 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion1.ParameterName = "@Recomendacion1"
            dbParam_recomendacion1.Value = Recomendacion1
            dbParam_recomendacion1.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion1)
            Dim dbParam_recomendacion1Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion1Fecha.ParameterName = "@Recomendacion1Fecha"
            dbParam_recomendacion1Fecha.Value = Recomendacion1Fecha
            dbParam_recomendacion1Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion1Fecha)
            Dim dbParam_recomendacion2 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion2.ParameterName = "@Recomendacion2"
            dbParam_recomendacion2.Value = Recomendacion2
            dbParam_recomendacion2.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion2)
            Dim dbParam_recomendacion2Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion2Fecha.ParameterName = "@Recomendacion2Fecha"
            dbParam_recomendacion2Fecha.Value = Recomendacion2Fecha
            dbParam_recomendacion2Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion2Fecha)
            Dim dbParam_recomendacion3 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion3.ParameterName = "@Recomendacion3"
            dbParam_recomendacion3.Value = Recomendacion3
            dbParam_recomendacion3.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_recomendacion3)
            Dim dbParam_recomendacion3Fecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_recomendacion3Fecha.ParameterName = "@Recomendacion3Fecha"
            dbParam_recomendacion3Fecha.Value = Recomendacion3Fecha
            dbParam_recomendacion3Fecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_recomendacion3Fecha)
            Dim dbParam_fotografias As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fotografias.ParameterName = "@Fotografias"
            dbParam_fotografias.Value = Fotografias
            dbParam_fotografias.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_fotografias)
            Dim dbParam_fotografiasFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fotografiasFecha.ParameterName = "@FotografiasFecha"
            dbParam_fotografiasFecha.Value = FotografiasFecha
            dbParam_fotografiasFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fotografiasFecha)
            Dim dbParam_examenMedico As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_examenMedico.ParameterName = "@ExamenMedico"
            dbParam_examenMedico.Value = ExamenMedico
            dbParam_examenMedico.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_examenMedico)
            Dim dbParam_examenMedicoFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_examenMedicoFecha.ParameterName = "@ExamenMedicoFecha"
            dbParam_examenMedicoFecha.Value = ExamenMedicoFecha
            dbParam_examenMedicoFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_examenMedicoFecha)
            Dim dbParam_status As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_status.ParameterName = "@Status"
            dbParam_status.Value = Status
            dbParam_status.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_status)
            Dim dbParam_statusFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_statusFecha.ParameterName = "@StatusFecha"
            dbParam_statusFecha.Value = StatusFecha
            dbParam_statusFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_statusFecha)
            Dim dbParam_fechaRegistro As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_fechaRegistro.ParameterName = "@FechaRegistro"
            dbParam_fechaRegistro.Value = FechaRegistro
            dbParam_fechaRegistro.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_fechaRegistro)
            Dim dbParam_datosConfirmados As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_datosConfirmados.ParameterName = "@DatosConfirmados"
            dbParam_datosConfirmados.Value = DatosConfirmados
            dbParam_datosConfirmados.DbType = System.Data.DbType.[Boolean]
            dbCommand.Parameters.Add(dbParam_datosConfirmados)
            Dim dbParam_idCarreraAsignada As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_idCarreraAsignada.ParameterName = "@idCarreraAsignada"
            dbParam_idCarreraAsignada.Value = idCarreraAsignada
            dbParam_idCarreraAsignada.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_idCarreraAsignada)
            Dim dbParam_carreraAsignadaFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_carreraAsignadaFecha.ParameterName = "@CarreraAsignadaFecha"
            dbParam_carreraAsignadaFecha.Value = CarreraAsignadaFecha
            dbParam_carreraAsignadaFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_carreraAsignadaFecha)
            Dim dbParam_matricula As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_matricula.ParameterName = "@Matricula"
            dbParam_matricula.Value = Matricula
            dbParam_matricula.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_matricula)
            Dim dbParam_folio As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_folio.ParameterName = "@Folio"
            dbParam_folio.Value = Folio
            dbParam_folio.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_folio)
            Dim dbParam_cuotaadmision As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cuotaadmision.ParameterName = "@CuotaAdmision"
            dbParam_cuotaadmision.Value = CuotaAdmision
            dbParam_cuotaadmision.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_cuotaadmision)
            Dim dbParam_cuotaadmisionFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cuotaadmisionFecha.ParameterName = "@CuotaAdmisionFecha"
            dbParam_cuotaadmisionFecha.Value = CuotaAdmisionFecha
            dbParam_cuotaadmisionFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_cuotaadmisionFecha)
            Dim dbParam_cartaadmision As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cartaadmision.ParameterName = "@CartaAdmision"
            dbParam_cartaadmision.Value = CartaAdmision
            dbParam_cartaadmision.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_cartaadmision)
            Dim dbParam_cartaadmisionFecha As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_cartaadmisionFecha.ParameterName = "@CartaAdmisionFecha"
            dbParam_cartaadmisionFecha.Value = CartaAdmisionFecha
            dbParam_cartaadmisionFecha.DbType = System.Data.DbType.DateTime
            dbCommand.Parameters.Add(dbParam_cartaadmisionFecha)
            Dim dbParam_login As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_login.ParameterName = "@Login"
            dbParam_login.Value = Login
            dbParam_login.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_login)
            Dim dbParam_password As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_password.ParameterName = "@Password"
            dbParam_password.Value = Password
            dbParam_password.DbType = System.Data.DbType.[String]
            dbCommand.Parameters.Add(dbParam_password)

            Dim rowsAffected As Integer = 0
            dbConnection.Open()
            Try
                rowsAffected = dbCommand.ExecuteNonQuery
            Finally
                dbConnection.Close()
            End Try

            Return rowsAffected
        End Function

        Public Function EstaEnSistema(ByVal clave As String) As Boolean

            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionStringAdmision").ConnectionString
            Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

            Dim queryString As String = "SELECT [AlumnoProspecto].* FROM [AlumnoProspecto] WHERE ([AlumnoProspecto].[" & _
                "matricula] = @matricula)"
            Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
            dbCommand.CommandText = queryString
            dbCommand.Connection = dbConnection

            Dim dbParam_email As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
            dbParam_email.ParameterName = "@matricula"
            dbParam_email.Value = clave
            dbParam_email.DbType = System.Data.DbType.String
            dbCommand.Parameters.Add(dbParam_email)

            dbConnection.Open()
            Dim dr As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            Dim regreso As Boolean = False

            If dr.Read Then
                regreso = True
            End If

            dr.Close()
            Return regreso
        End Function


    End Class



End Namespace