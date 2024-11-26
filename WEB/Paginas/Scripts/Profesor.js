jQuery(function () {
    LlenarTabla();
});

async function Ejecutar(Metodo, Funcion) {

    const profesor = new Profesor($("#txtID").val(), $("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtEspecialidad").val(),
        $("#txtTelefono").val(), $("#txtCorreo").val());

    let URL = "https://localhost:44387/api/Profesors/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, profesor);

    $("#txtID").val("");
    $("#txtDocumento").val("");
    $("#txtNombre").val("");
    $("#txtApellido").val("");
    $("#txtEspecialidad").val("");
    $("#txtTelefono").val("");
    $("#txtCorreo").val("");
}

async function Consultar() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Profesors/ConsultarXID?Id=" + ID;

    const profesor = await ConsultarServicio(URL);

    if (profesor != null) {
        $("#txtDocumento").val(profesor.Documento);
        $("#txtNombre").val(profesor.Nombre);
        $("#txtApellido").val(profesor.Apellido);
        $("#txtEspecialidad").val(profesor.Especialidad);
        $("#txtTelefono").val(profesor.Telefono);
        $("#txtCorreo").val(profesor.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró al profesor en la base de datos.");
    }
}

function Editar(Id, Documento, Nombre, Apellido, Especialidad, Telefono, Correo) {
    $("#txtID").val(Id);
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtApellido").val(Apellido);
    $("#txtEspecialidad").val(Especialidad);
    $("#txtTelefono").val(Telefono);
    $("#txtCorreo").val(Correo);
}

async function BuscarProfesor() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Profesors/ConsultarXID?Id=" + ID;

    const profesor = await ConsultarServicio(URL);

    if (profesor != null) {
        $("#txtDocumento").val(profesor.Documento);
        $("#txtNombre").val(profesor.Nombre);
        $("#txtApellido").val(profesor.Apellido);
        $("#txtEspecialidad").val(profesor.Especialidad);
        $("#txtTelefono").val(profesor.Telefono);
        $("#txtCorreo").val(profesor.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró al profesor en la base de datos.");
        $("#txtDocumento").val("");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtEspecialidad").val("");
        $("#txtTelefono").val("");
        $("#txtCorreo").val("");
    }
}

class Profesor {
    constructor(ID, Documento, Nombre, Apellido, Especialidad, Telefono, Correo) {
        this.ID = ID;
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Especialidad = Especialidad;
        this.Telefono = Telefono;
        this.Correo = Correo;
    }
}

async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Profesors/LlenarTabla", "#tblProfesores");
}