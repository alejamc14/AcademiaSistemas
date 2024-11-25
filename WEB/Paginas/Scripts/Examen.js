
jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    LlenarComboXServicios("https://localhost:44387/api/Cursos/LlenarCombo", "#cboCursito");
    LlenarTabla();

});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Examenes/LlenarTabla", "#tblExamen");
}

async function EjecutarComando(Metodo, Funcion) {
    const exa = new Examen($("#txtIdExamen").val(), $("#txtFecha").val(), $("#txtDuracion").val(), $("#txtNotaMax").val(),
        $("#cboCursito").val(), $("#txtDescripcion").val());
    let URL = "https://localhost:44387/api/Examenes/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, exa);
    LlenarTabla();


}

async function Consultar() {
    let id = $("#txtIdExamen").val();
    URL = "https://localhost:44387/api/Examenes/ConsultarXId?Id=" + id;
    //Invoco el servicio genérico
    const examen = await ConsultarServicio(URL);
    if (examen != null) {
        $("#dvMensaje").html("");
        $("#cboCursito").val(examen.IdCurso);
        $("#txtDescripcion").val(examen.Descripcion);
        $("#txtFecha").val(examen.FechaExamen.split('T')[0]);
        $("#txtDuracion").val(examen.Duracion);
        $("#txtNotaMax").val(examen.NotaMaxima);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El examen no existe en la base de datos");
        $("#cboCursito").val("");
        $("#txtDescripcion").val("");
        $("#txtFecha").val("");
        $("#txtDuracion").val("");
        $("#txtNotaMax").val("");
    }
}

class Examen {
    constructor(Id, FechaExamen, Duracion, NotaMaxima, IdCurso, Descripcion) {
        this.Id = Id;
        this.FechaExamen = FechaExamen;
        this.Duracion = Duracion;
        this.NotaMaxima = NotaMaxima;
        this.IdCurso = IdCurso;
        this.Descripcion = Descripcion;
    }
    
}
