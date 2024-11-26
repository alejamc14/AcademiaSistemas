jQuery(function () {
    LlenarTabla();
});

async function Ejecutar(Metodo, Funcion) {

    const estudiante = new Estudiante($("#txtID").val(), $("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtFechaNacimiento").val(),
        $("#txtTelefono").val(), $("#txtDireccion").val(), $("#txtCorreo").val());

    let URL = "https://localhost:44387/api/Estudiantes/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, estudiante);

    $("#txtID").val("");
    $("#txtDocumento").val("");
    $("#txtNombre").val("");
    $("#txtApellido").val("");
    $("#txtFechaNacimiento").val("");
    $("#txtTelefono").val("");
    $("#txtDireccion").val("");
    $("#txtCorreo").val("");
}

async function Consultar() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarXID?Id=" + ID;

    const estudiante = await ConsultarServicio(URL);

    if (estudiante != null) {
        $("#txtDocumento").val(estudiante.Documento);
        $("#txtNombre").val(estudiante.Nombre);
        $("#txtApellido").val(estudiante.Apellido);
        $("#txtFechaNacimiento").val(estudiante.FechaNacimiento.split('T')[0]);
        $("#txtTelefono").val(estudiante.Telefono);
        $("#txtDireccion").val(estudiante.Direccion);
        $("#txtCorreo").val(estudiante.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró el estudiante en la base de datos.");
    }

}

function Editar(Id, Documento, Nombre, Apellido, FechaNacimiento, Telefono, Direccion, Correo) {
    $("#txtID").val(Id);
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtApellido").val(Apellido);
    $("#txtFechaNacimiento").val(FechaNacimiento);
    $("#txtTelefono").val(Telefono);
    $("#txtDireccion").val(Direccion);
    $("#txtCorreo").val(Correo);
}

async function BuscarEstudiante() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarXID?Id=" + ID;

    const estudiante = await ConsultarServicio(URL);

    if (estudiante != null) {
        $("#txtDocumento").val(estudiante.Documento);
        $("#txtNombre").val(estudiante.Nombre);
        $("#txtApellido").val(estudiante.Apellido);
        $("#txtFechaNacimiento").val(estudiante.FechaNacimiento.split('T')[0]);
        $("#txtTelefono").val(estudiante.Telefono);
        $("#txtDireccion").val(estudiante.Direccion);
        $("#txtCorreo").val(estudiante.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró el estudiante en la base de datos.");
        $("#txtDocumento").val("");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtFechaNacimiento").val("");
        $("#txtTelefono").val("");
        $("#txtDireccion").val("");
        $("#txtCorreo").val("");
    }
}

class Estudiante {
    constructor(ID, Documento, Nombre, Apellido, FechaNacimiento, Telefono, Direccion, Correo) {
        this.ID = ID;
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.FechaNacimiento = FechaNacimiento;
        this.Telefono = Telefono;
        this.Direccion = Direccion;
        this.Correo = Correo;
    }
}

async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Estudiantes/LlenarTabla", "#tblEstudiantes");
}