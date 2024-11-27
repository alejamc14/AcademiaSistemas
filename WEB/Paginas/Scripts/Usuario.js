jQuery(function () {
    LlenarComboXServiciosAuth("https://localhost:44387/api/Perfil/LlenarCombo", "#cboPerfil");
    LlenarTabla();
});
async function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Usuario/ListarUsuarios", "#tblUsuarios");
}
function EditarUsuario(Id , Documento, Nombre, Usuario, Perfil, UsuarioPerfil) {
    $("#txtIdUsuario").val(Id);
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtUsuario").val(Usuario);
    $("#cboPerfil").val(Perfil);
    $("#txtIdUsuarioPerfil").val(UsuarioPerfil);
}
async function Ejecutar(Metodo, Funcion) {
    let Clave = $("#txtClave").val();
    let RepitaClave = $("#txtConfirmaClave").val();
    let idPerfil = $("#cboPerfil").val();
    let tipoConsulta = $("#tipoConsulta").val();
    if (Clave != RepitaClave) {
        $("#dvMensaje").html("Las claves no coinciden, por favor valide la información");
        return;
    }
    let Documento = $("#txtDocumento").val();
    let URL2;
    let IdEstudiante = null;
    let IdProfesor = null;

    // Determinar el tipo de consulta
    if (tipoConsulta === "estudiante") {
        URL2 = "https://localhost:44387/api/Estudiantes/ConsultarXDocumento?Documento=" + Documento;
    } else if (tipoConsulta === "profesor") {
        URL2 = "https://localhost:44387/api/Profesor/ConsultarXDocumento?Documento=" + Documento;
    }

    // Consultar el ID correspondiente
    const resultado = await ConsultarServicioAuth(URL2);
    if (resultado) {
        if (tipoConsulta === "estudiante") {
            IdEstudiante = resultado.Id;
        } else if (tipoConsulta === "profesor") {
            IdProfesor = resultado.Id;
        }
    } else {
        Swal.fire({
            icon: "error",
            title: "Error",
            text: `No se encontró el ${tipoConsulta} en la base de datos.`
        });
        return;
    }
    let idUsuario = Metodo == 'PUT' ? $("#txtIdUsuario").val() : 0
    let idUsuarioPerfil = Metodo == 'PUT' ? $("#txtIdUsuarioPerfil").val() : 0;
    const usuario = new Usuario(idUsuario, $("#txtUsuario").val(), Clave, IdEstudiante, IdProfesor);
    let URL = "https://localhost:44387/api/Usuario/" + Funcion + "?IdPerfil=" + idPerfil + "&IdUsuarioPerfil=" + idUsuarioPerfil;
    await EjecutarComandoServicioAuth(Metodo, URL, usuario);
    LlenarTabla();
}
async function Consultar() {
    let tipoConsulta = $("#tipoConsulta").val(); // Obtienes el valor del tipo de consulta (Estudiante o Profesor)

    if (tipoConsulta === "estudiante") {
        await ConsultarEstudiante(); // Llama a ConsultarEstudiante si se seleccionó Estudiante
    } else if (tipoConsulta === "profesor") {
        await ConsultarProfesor(); // Llama a ConsultarProfesor si se seleccionó Profesor
    }
}
async function ConsultarEstudiante() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarEstudiante?Documento=" + Documento;
    //Invoco el servicio genérico
    const estudiante = await ConsultarServicioAuth(URL);
    if (estudiante != null && estudiante.length > 0) {
        $("#txtNombre").val(estudiante[0].Estudiante);
        $("#dvMensaje").html("");
    }
    else {
        $("#txtNombre").val("");
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'El estudiante no existe, por favor valide la información'
        });
    }
}
async function ConsultarProfesor() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44387/api/Profesor/ConsultarProfesor?Documento=" + Documento;
    //Invoco el servicio genérico
    const profesor = await ConsultarServicioAuth(URL);
    if (profesor != null && profesor.length > 0) {
        $("#txtNombre").val(profesor[0].Profesor);
        $("#dvMensaje").html("");
    }
    else {
        $("#txtNombre").val("");
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'El profesor no existe, por favor valide la información'
        });
    }
}
async function Activar(IdUsuarioPerfil, Activo) {
    // Convertir el valor de Activo a booleano
    Activo = (Activo === "true");

    Swal.fire({
        title: '¿Estás seguro?',
        text: `¿Quieres ${Activo ? 'activar' : 'desactivar'} este usuario?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, continuar',
        cancelButtonText: 'No, cancelar',
    }).then(async (result) => {
        if (result.isConfirmed) {
            let URL = "https://localhost:44387/api/Usuario/Activar?IdUsuarioPerfil=" + IdUsuarioPerfil + "&Activo=" + Activo;
            try {
                await EjecutarComandoServicioAuth('PUT', URL, null);
                Swal.fire({
                    title: '¡Hecho!',
                    text: `El usuario ha sido ${Activo ? 'activado' : 'desactivado'} exitosamente.`,
                    icon: 'success',
                });
                LlenarTabla();
            } catch (error) {
                Swal.fire({
                    title: 'Error',
                    text: 'No se pudo procesar la solicitud. Intenta nuevamente.',
                    icon: 'error',
                });
            }
        } else {
            Swal.fire({
                title: 'Cancelado',
                text: 'La operación fue cancelada.',
                icon: 'info',
            });
        }
    });
}


class Usuario {
    constructor(Id, NombreUsuario, Clave, IdEstudiante, IdProfesor) {
        this.Id = Id;
        this.NombreUsuario = NombreUsuario;
        this.Clave = Clave;
        this.IdEstudiante = IdEstudiante;
        this.IdProfesor = IdProfesor;
    }
}