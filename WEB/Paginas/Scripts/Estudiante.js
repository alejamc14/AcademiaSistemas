jQuery(function () {
    LlenarTabla();
});

async function Ejecutar(Metodo, Funcion) {

    const estudiante = new Estudiante($("#txtId").val(),$("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtFechaNacimiento").val(),
        $("#txtTelefono").val(), $("#txtDireccion").val(), $("#txtCorreo").val());

    let URL = "https://localhost:44387/api/Estudiantes/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, estudiante);
}

async function Consultar() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarXDocumento?Documento=" + Documento;

    const estudiante = await ConsultarServicio(URL);

    if (estudiante != null) {
        $("#txtId").val(estudiante.Id);
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
async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Estudiantes/LlenarTabla", "#tblEstudiantes");
}
function EditarEstudiante(Documento, Nombre, Apellido, FechaNacimiento, Telefono, Direccion, Correo) {
    $("#txtDocumento").val(Documento);
    $("#txtNombre").val(Nombre);
    $("#txtApellido").val(Apellido);
    $("#txtFechaNacimiento").val(FechaNacimiento);
    $("#txtTelefono").val(Telefono);
    $("#txtDireccion").val(Direccion);
    $("#txtCorreo").val(Correo);
}

class Estudiante {
    constructor(Id, Documento, Nombre, Apellido, FechaNacimiento, Telefono, Direccion, Correo) {
        this.Id = Id;
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.FechaNacimiento = FechaNacimiento;
        this.Telefono = Telefono;
        this.Direccion = Direccion;
        this.Correo = Correo;
    }
}

