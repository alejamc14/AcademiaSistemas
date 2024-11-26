jQuery(function () {
    LlenarTabla();
    ObtenerEstudiantes();
    ObtenerCurso();
});

async function Ejecutar(Metodo, Funcion) {

    var nota = parseFloat($("#txtNota").val());

    const calificacion = new Calificacion($("#txtID").val(), $("#txtNota").val(), $("#txtFechaCalificacion").val(), $("#txtIdEstudiante").val(), $("#txtIdCurso").val());

    let URL = "https://localhost:44387/api/Calificacions/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, calificacion);

    $("#txtID").val("");
    $("#txtNota").val("");
    $("#txtFechaCalificacion").val("");
    $("#txtIdEstudiante").val("");
    $("#txtIdCurso").val("");
}

async function Consultar() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Calificacions/ConsultarXID?Id=" + ID;

    const calificacion = await ConsultarServicio(URL);

    if (calificacion != null) {
        $("#txtNota").val(calificacion.Nota);
        $("#txtFechaCalificacion").val(calificacion.FechaCalificacion.split('T')[0]);
        $("#txtIdEstudiante").val(calificacion.IdEstudiante);
        $("#txtIdCurso").val(calificacion.IdCurso);
    }
    else {
        $("#dvMensaje").html("No se encontró la calificación en la base de datos.");
    }
}

function Editar(Id, IdEstudiante, IdCurso, Nota, FechaCalificacion) {
    $("#txtID").val(Id);
    $("#txtIdEstudiante").val(IdEstudiante);
    $("#txtIdCurso").val(IdCurso);
    $("#txtNota").val(Nota);
    $("#txtFechaCalificacion").val(FechaCalificacion);
}

async function BuscarEstudiante() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Calificacions/ConsultarXID?Id=" + ID;

    const calificacion = await ConsultarServicio(URL);

    if (calificacion != null) {
        $("#txtNota").val(calificacion.Nota);
        $("#txtFechaCalificacion").val(calificacion.FechaCalificacion.split('T')[0]);
        $("#txtIdEstudiante").val(calificacion.IdEstudiante);
        $("#txtIdCurso").val(calificacion.IdCurso);
    }
    else {
        $("#dvMensaje").html("No se encontró la calificación en la base de datos.");
        $("#txtNota").val("");
        $("#txtFechaCalificacion").val("");
        $("#txtIdEstudiante").val("");
        $("#txtIdCurso").val("");
    }
}

class Calificacion {
    constructor(ID, Nota, FechaCalificacion, IdEstudiante, IdCurso) {
        this.ID = ID;
        this.Nota = Nota;
        this.FechaCalificacion = FechaCalificacion;
        this.IdEstudiante = IdEstudiante;
        this.IdCurso = IdCurso;
    }
}

async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Calificacions/LlenarTabla", "#tblCalificaciones");
}

async function ObtenerEstudiantes() {
    LlenarComboXServicios("https://localhost:44387/api/Calificacions/ObtenerEstudiantes", "txtIdEstudiante");
}

async function ObtenerCurso() {
    LlenarComboXServicios("https://localhost:44387/api/Calificacions/ObtenerCurso", "txtIdCurso");
}