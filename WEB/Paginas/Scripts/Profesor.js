jQuery(function () {
    LlenarTabla();
});

async function Ejecutar(Metodo, Funcion) {

    const profesor = new Profesor($("#txtId").val(),$("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtEspecialidad").val(),
        $("#txtTelefono").val(), $("#txtCorreo").val());

    let URL = "https://localhost:44387/api/Profesor/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, profesor);
}

async function Consultar() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44387/api/Profesor/ConsultarXDocumento?Documento=" + Documento;

    const profesor = await ConsultarServicioAuth(URL);

    if (profesor != null) {
        $("#txtId").val(profesor.Id);
        $("#txtNombre").val(profesor.Nombre);
        $("#txtApellido").val(profesor.Apellido);
        $("#txtEspecialidad").val(profesor.Especialidad);
        $("#txtTelefono").val(profesor.Telefono);
        $("#txtCorreo").val(profesor.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró el estudiante en la base de datos.");
    }

}
async function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Profesor/LlenarTabla", "#tblProfesor");
}

function EditarProfesor(Documento, Nombre, Apellido, Especialidad, Telefono, Correo) {
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtApellido").val(Apellido);
    $("#txtEspecialidad").val(Especialidad);
    $("#txtTelefono").val(Telefono);
    $("#txtCorreo").val(Correo);
}

class Profesor {
    constructor(Id, Documento, Nombre, Apellido, Especialidad, Telefono, Correo) {
        this.Id = Id;
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Especialidad = Especialidad;
        this.Telefono = Telefono;
        this.Correo = Correo;
    }
}

