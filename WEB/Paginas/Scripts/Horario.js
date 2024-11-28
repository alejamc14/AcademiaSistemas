jQuery(function () {
    LlenarTabla();
    ListarCurso();
    ListarAula();

    $("#dvMenu").load("../Paginas/Menu.html")
    
});
function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Horario/LlenarTabla", "#tblHorario");
}
async function ListarCurso() {
    LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/listarCursos", "#cboCurso");
}
async function ListarAula() {
    LlenarComboXServiciosAuth("https://localhost:44387/api/Aulas/listarAulas", "#cboAula");
}
async function Ejecutar(Metodo, Funcion) {
    const horario = new Horario($("#txtIdHorario").val(), $("#txtFecha").val(), $("#txtHoraInicio").val(), $("#txtHoraFin").val(), $("#cboCurso").val(), $("#cboAula").val());

    let URL = "https://localhost:44387/api/Horario/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, horario);
    LlenarTabla();
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
        $("#cboCurso").val(horario.IdCurso);
        $("#cboAula").val(horario.IdAula);

    }
    else {
        $("#dvMensaje").html("No se encontró el horario en la base de datos.");
    }

}
function EditarHorario(id, Semana, Horainicio, Horafin, Curso, Aula) {
    $("#txtIdHorario").val(id);
    $("#txtFecha").val(Semana);
    let horaInicioFormateada = Horainicio.split(":").slice(0, 2).join(":");
    let horaFinFormateada = Horafin.split(":").slice(0, 2).join(":")
    $("#txtHoraInicio").val(horaInicioFormateada);
    $("#txtHoraFin").val(horaFinFormateada);
    $("#cboCurso").val(Curso);
    $("#cboAula").val(Aula);


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

