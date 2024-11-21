jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    LlenarComboXServicios("https://localhost:44387/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
    LlenarTabla();

});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Cursos/LlenarTabla", "#tblCursos");
}


async function EjecutarComando(Metodo, Funcion) {
    const curso = new Curso($("#txtId").val(), $("#txtNombre").val(), $("#txtDescripcion").val(), $("#txtHora").val(),
        $("#txtPrecio").val(), $("#txtIdProfesor").val(), $("#cboCategoriaCurso").val());

    let URL = "https://localhost:44387/api/Cursos/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, curso);
    LlenarTabla();


}

async function Consultar() {
    let Codigo = $("#txtId").val();
    URL = "https://localhost:44387/api/Cursos/ConsultarXCodigo?codigo=" + Codigo;
    //Invoco el servicio genérico
    const curso = await ConsultarServicio(URL);
    if (curso != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(curso.Nombre);
        $("#txtDescripcion").val(curso.Descripcion);
        $("#txtHora").val(curso.Hora);
        $("#txtPrecio").val(curso.Precio);
        $("#txtIdProfesor").val(curso.IdProfesor);
        $("#cboCategoriaCurso").val(curso.IdCategoria);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El curso no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
        $("#txtHora").val("");
        $("#txtPrecio").val("");
        $("#txtIdProfesor").val("");
        $("#cboCategoriaCurso").val("");
    }
}

class Curso {
    constructor(Id, Nombre, Descripcion, Hora, Precio, IdProfesor, IdCategoria) {
        this.Id = Id;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Hora = Hora;
        this.Precio = Precio;
        this.IdProfesor = IdProfesor;
        this.IdCategoria = IdCategoria;

    }
}