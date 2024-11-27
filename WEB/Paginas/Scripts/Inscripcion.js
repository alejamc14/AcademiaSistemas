jQuery(function () {
    LlenarTabla();
    ListarCategoriaCursoInscripcion();
    $("#dvMenu").load("../Paginas/Menu.html")

});

function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Inscripcion/LlenarTabla", "#tblInscripcion");
}
async function EditarInscripcion(id, FechaInscripcion, idEstudiante, NombreEstudiante, CategoriaCurso, Curso) {
    $("#txtIdInscripcion").val(id);
    $("#txtFecha").val(FechaInscripcion);
    $("#txtIdEstudiante").val(idEstudiante);
    $("#txtNombreEstudiante").val(NombreEstudiante);
    $("#cboCategoriaCurso").val(CategoriaCurso);
    await ListarCursoInscripcion(CategoriaCurso);
    const cursoId = Curso;
    let cursoSeleccionado = null;

    $("#cboCurso option").each(function () {
        if ($(this).val().startsWith(cursoId + "|")) {
            cursoSeleccionado = $(this).val();
            return false;
        }
    });
}
async function Ejecutar(Metodo, Funcion) {
    let idInscripcion = 0; // Valor predeterminado

    if (Metodo === 'PUT' || Metodo === 'DELETE') {
        idInscripcion = $("#txtIdInscripcion").val();
    }
    const inscripcion = new Inscripcion(idInscripcion, $("#txtFecha").val(), $("#txtIdEstudiante").val(), $("#cboCurso").val().split("|")[0]);

    let URL = "https://localhost:44387/api/Inscripcion/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, inscripcion);
}
async function ListarCategoriaCursoInscripcion() {
    await LlenarComboXServiciosAuth("https://localhost:44387/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
    ListarCursoInscripcion($("#cboCategoriaCurso").val());
}
async function ListarCursoInscripcion(CategoriaCurso) {
    let idCategoriaCurso = CategoriaCurso == 0 ? $("#cboCategoriaCurso").val() : CategoriaCurso;
    await LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/listarCursosXCategoriaCursos?CategoriaCurso=" + idCategoriaCurso, "#cboCurso");
}
async function ConsultarEstudiante() {
    let Documento = $("#txtDocumentoEstudiante").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarXDocumento?Documento=" + Documento;
    const estudiante = await ConsultarServicioAuth(URL);

    if (estudiante != null) {
        $("#txtIdEstudiante").val(estudiante.Id);
        $("#txtNombreEstudiante").val(estudiante.Nombre + " " +estudiante.Apellido);
    }
    else {
        $("#dvMensaje").html("No se encontró el estudiante en la base de datos.");
    }

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