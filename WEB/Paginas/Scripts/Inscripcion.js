jQuery(function () {
    LlenarTabla();

    $("#dvMenu").load("../Paginas/Menu.html")

});

function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Inscripcion/LlenarTabla", "#tblInscripcion");
}
function EditarInscripcion(FechaInscripcion) {
    $("#txtFecha").val(FechaInscripcion);
}
async function Ejecutar(Metodo, Funcion) {
    const inscripcion = new Inscripcion($("#txtIdInscripcion").val(), $("#txtFecha").val(), $("#txtIdEstudiante").val(), $("#txtIdCurso").val());

    let URL = "https://localhost:44387/api/Inscripcion/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, inscripcion);
}
async function Consultar() {
    let Id = $("#txtIdInscripcion").val();
    let URL = "https://localhost:44387/api/Inscripcion/Consultar?id=" + Id;

    const inscripcion = await ConsultarServicioAuth(URL);

    if (inscripcion != null) {

        $("#txtFecha").val(inscripcion.FechaInscripcion.split("T")[0]);
        $("#txtIdEstudiante").val(inscripcion.IdEstudiante);
        $("#txtIdCurso").val(inscripcion.IdCurso);
    }
    else {
        $("#dvMensaje").html("No se encontró el horario en la base de datos.");
    }

}

class Inscripcion {
    constructor(Id, FechaInscripcion, IdEstudiante, IdCurso) {
        this.Id = Id;
        this.FechaInscripcion = FechaInscripcion;
        this.IdEstudiante = IdEstudiante;
        this.IdCurso = IdCurso;
    }

}