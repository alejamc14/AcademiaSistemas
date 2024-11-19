jQuery(function () {
    LlenarTabla();

    $("#dvMenu").load("../Paginas/Menu.html")
    
});
function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Horario/LlenarTabla", "#tblHorario");
}
async function Ejecutar(Metodo, Funcion) {
    const horario = new Horario($("#txtIdHorario").val(), $("#txtFecha").val(), $("#txtHoraInicio").val(), $("#txtHoraFin").val(), $("#txtIdCurso").val(), $("#txtIdAula").val());

    let URL = "https://localhost:44387/api/Horario/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, horario);
}
async function Consultar() {
    let Id = $("#txtIdHorario").val();
    let URL = "https://localhost:44387/api/Horario/Consultar?id=" + Id;

    const horario = await ConsultarServicio(URL);

    
    if (horario != null) {
        let diaSeleccionado = horario.DiaSemana.toUpperCase();
       
        $("#txtFecha").val(diaSeleccionado);
        $("#txtHoraInicio").val(horario.HoraInicio);
        $("#txtHoraFin").val(horario.HoraFin);
        $("#txtIdCurso").val(horario.IdCurso);
        $("#txtIdAula").val(horario.IdAula);

    }
    else {
        $("#dvMensaje").html("No se encontró el horario en la base de datos.");
    }

}
class Horario {
    constructor(Id, DiaSemana, HoraInicio, HoraFin, IdCurso, IdAula) {
        this.Id = Id;
        this.DiaSemana = DiaSemana;
        this.HoraInicio = HoraInicio;
        this.HoraFin = HoraFin;
        this.IdCurso = IdCurso;
        this.IdAula = IdAula;
    }

}

