jQuery(function () {
    LlenarTabla();
    ObtenerEstudiantes();
});

async function Ejecutar(Metodo, Funcion) {

    const sancion = new Sancion($("#txtID").val(), $("#txtMotivo").val(), $("#txtFechaSancion").val(), $("#txtDuracion").val(), $("#txtIdEstudiante").val());

    let URL = "https://localhost:44387/api/Sancions/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, sancion);

    $("#txtID").val("");
    $("#txtMotivo").val("");
    $("#txtFechaSancion").val("");
    $("#txtDuracion").val("");
    $("#txtIdEstudiante").val("");
}

async function Consultar() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Sancions/ConsultarXID?Id=" + ID;

    const sancion = await ConsultarServicio(URL);

    if (sancion != null) {
        $("#txtMotivo").val(sancion.Motivo);
        $("#txtFechaSancion").val(sancion.FechaSancion.split('T')[0]);
        $("#txtDuracion").val(sancion.Duracion);
        $("#txtIdEstudiante").val(sancion.IdEstudiante);
    }
    else {
        $("#dvMensaje").html("No se encontró la calificación en la base de datos.");
    }
}

function Editar(Id, IdEstudiante, Motivo, Duracion, FechaSancion) {
    $("#txtID").val(Id);
    $("#txtIdEstudiante").val(IdEstudiante);
    $("#txtMotivo").val(Motivo);
    $("#txtDuracion").val(Duracion);
    $("#txtFechaSancion").val(FechaSancion);
}

async function BuscarSancion() {
    let ID = $("#txtID").val();
    let URL = "https://localhost:44387/api/Sancions/ConsultarXID?Id=" + ID;

    const sancion = await ConsultarServicio(URL);

    if (sancion != null) {
        $("#txtMotivo").val(sancion.Motivo);
        $("#txtFechaSancion").val(sancion.FechaSancion.split('T')[0]);
        $("#txtDuracion").val(sancion.Duracion);
        $("#txtIdEstudiante").val(sancion.IdEstudiante);
    }
    else {
        $("#dvMensaje").html("No se encontró la calificación en la base de datos.");
        $("#txtMotivo").val("");
        $("#txtFechaSancion").val("");
        $("#txtDuracion").val("");
        $("#txtIdEstudiante").val("");
    }
}

class Sancion {
    constructor(ID, Motivo, FechaSancion, Duracion, IdEstudiante) {
        this.ID = ID;
        this.Motivo = Motivo;
        this.FechaSancion = FechaSancion;
        this.Duracion = Duracion;
        this.IdEstudiante = IdEstudiante;
    }
}

async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Sancions/LlenarTabla", "#tblSanciones");
}

async function ObtenerEstudiantes() {
    LlenarComboXServicios("https://localhost:44387/api/Sancions/ObtenerEstudiantes", "txtIdEstudiante");
}