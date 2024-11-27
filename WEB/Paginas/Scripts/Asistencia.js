jQuery(function () {
    LlenarTabla();

    $("#dvMenu").load("../Paginas/Menu.html")

});
function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Asistencia/LlenarTabla", "#tblAsistencia");
}
async function Ejecutar(Metodo, Funcion) {
    const asistencia = new Asistencia($("#txtIdAsistencia").val(), $("#txtFecha").val(), $("#txtIdEstudiante").val(), $("#txtIdCurso").val());

    let URL = "https://localhost:44387/api/Asistencia/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, asistencia);
}
async function Consultar() {
    let Id = $("#txtIdAsistencia").val();
    let URL = "https://localhost:44387/api/Asistencia/Consultar?id=" + Id;

    const asistencia = await ConsultarServicioAuth(URL);

    if (asistencia != null) {

        $("#txtFecha").val(asistencia.FechaAsistencia.split("T")[0]);
        $("#txtIdEstudiante").val(asistencia.IdEstudiante);
        $("#txtIdCurso").val(asistencia.IdCurso);
    }
    else {
        $("#dvMensaje").html("No se encontró el horario en la base de datos.");
    }

}
function EditarAsistencia(FechaAsistencia) {
    $("#txtFecha").val(FechaAsistencia);
}

class Asistencia {
    constructor(Id, FechaAsistencia, IdEstudiante, IdCurso) {
        this.Id = Id;
        this.FechaAsistencia = FechaAsistencia;
        this.IdEstudiante = IdEstudiante;
        this.IdCurso = IdCurso;
    }

}