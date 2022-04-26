Public Enum Status As Byte
	Creándose
	Editable
	Terminado
	Publicado
End Enum

Public Enum tipoObjeto As Byte
    Actividad
    ActividadesHPCertif
    ActividadSalonVirtual
	Agenda
    Alumno
    Anexos
	Archivo
	Asistencia
	AsistenciaLista
    Bitacora
    BitacoraContenido
    BoletinSalonVirtual
    CatalogoActividadesHP
    CatalogoActividadesHPCertif
    Clasificacion
    ClasificacionItem
	Configuracion
	ConfiguracionVisual
	Contenido
    ContenidoAdjunto
    ContenidoCalificacion
	Curso
	CursoAlumno
	Empresa
    EmpresaUserProfile
    ExOrden
    ExRespuesta
	ExRespuestasOP
	Foro
    ForoSalonVirtual
    GrupoActividad
    GrupoActividadUsuario
    Idioma
	ItemEvaluacion
	Maestro
	Mensaje
	Objetivo
	OpcionPregunta
	OpcionRespuesta
	Pais
	Permiso
	Pregunta
    Respuesta
    RespuestaArchivo
    RespuestaComentario
    RespuestaRubrica
    Root
    RootIdioma
    RootEmpresa
    Rubrica
    Rubro
    SalonVirtual
    SalonVirtualApunte
    SalonVritualEntrada
    SalonVirtualCapilla
    SalonVirtualCompartido
    SalonVirtualPregunta
	SalonVirtualUserProfile
	TipoPermiso
    UserProfile

End Enum

Public Enum Roles
	Administrador = 1
End Enum

Public Enum ordenamiento As Byte
	ASC = 0
	DESC = 1
End Enum