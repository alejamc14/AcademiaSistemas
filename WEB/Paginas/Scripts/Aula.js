jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    LlenarTabla();

});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Aulas/LlenarTabla", "#tblAula");
}

async function EjecutarComando(Metodo, Funcion) {
    const aula = new Aula($("#txtId").val(), $("#txtNom").val(), $("#txtCap").val(), $("#txtDescrip").val());
    let URL = "https://localhost:44387/api/Aulas/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, aula);
    LlenarTabla();


}

async function Consultar() {
    let id = $("#txtId").val();
    URL = "https://localhost:44387/api/Aulas/ConsultarXId?id=" + id;
    //Invoco el servicio genérico
    const aula = await ConsultarServicio(URL);
    if (aula != null) {
        $("#dvMensaje").html("");
        $("#txtNom").val(aula.Nombre);
        $("#txtCap").val(aula.Capacidad);
        $("#txtDescrip").val(aula.Descripcion);    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El aula no existe en la base de datos");
        $("#txtNom").val("");
        $("#txtCap").val("");
        $("#txtDescrip").val("");
    }
}

class Aula {
    constructor(Id, Nombre, Capacidad, Descripcion) {
        this.Id = Id;
        this.Nombre = Nombre;
        this.Capacidad = Capacidad;
        this.Descripcion = Descripcion;
    }
   
}
