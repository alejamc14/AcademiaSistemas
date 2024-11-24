jQuery(function () {
 /*   LlenarTabla();*/
});
//async function LlenarTabla() {
//    LlenarTablaXServicios("https://localhost:44387/api/Usuario/ListarUsuarios", "#tblUsuarios");
//}
function Editar(idUsuario, DocumentoEmpleado, Empleado, Cargo, Usuario, Perfil) {
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Empleado);
    $("#txtCargo").val(Cargo);
    $("#txtUsuario").val(Usuario);
    $("#cboPerfil").val(Perfil);
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
    const resultado = await ConsultarServicio(URL2);
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
    const usuario = new Usuario(0, $("#txtUsuario").val(), Clave, IdEstudiante, IdProfesor);
    let URL = "https://localhost:44387/api/Usuario/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, usuario);
    /*LlenarTabla();*/
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
    URL = "https://localhost:44387/api/Estudiantes/ConsultarEstudiante?Documento=" + Documento;
    //Invoco el servicio genérico
    const estudiante = await ConsultarServicio(URL);
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
    URL = "https://localhost:44387/api/Profesor/ConsultarProfesor?Documento=" + Documento;
    //Invoco el servicio genérico
    const profesor = await ConsultarServicio(URL);
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
class Usuario {
    constructor(Id, NombreUsuario, Clave, IdEstudiante, IdProfesor) {
        this.Id = Id;
        this.NombreUsuario = NombreUsuario;
        this.Clave = Clave;
        this.IdEstudiante = IdEstudiante;
        this.IdProfesor = IdProfesor;
    }
}