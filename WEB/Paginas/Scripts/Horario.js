jQuery(function () {
    LlenarTabla();

    $("#dvMenu").load("../Paginas/Menu.html")
    
});
function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Horario/LlenarTabla", "#tblHorario");
}
async function Ejecutar(Metodo, Funcion) {
    const horario = new Horario($("#txtIdHorario").val(), $("#txtFecha").val(), $("#txtHoraInicio").val(), $("#txtHoraFin").val(), $("#txtIdCurso").val(), $("#txtIdAula").val());

    let URL = "https://localhost:44387/api/Horario/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, horario);
}
async function Consultar() {
    let Id = $("#txtIdHorario").val();
    let URL = "https://localhost:44387/api/Horario/Consultar?id=" + Id;

    const horario = await ConsultarServicioAuth(URL);

    
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
function EditarHorario(Semana, Horainicio, Horafin) {
    $("#txtFecha").val(Semana);
    let horaInicioFormateada = Horainicio.split(":").slice(0, 2).join(":");
    let horaFinFormateada = Horafin.split(":").slice(0, 2).join(":")
    $("#txtHoraInicio").val(horaInicioFormateada);
    $("#txtHoraFin").val(horaFinFormateada);
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

