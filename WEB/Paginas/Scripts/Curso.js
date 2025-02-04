jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    LlenarComboXServiciosAuth("https://localhost:44387/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
    LlenarTabla();
    LlenarProfesor();

});

function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Cursos/LlenarTabla", "#tblCursos");
}
function LlenarProfesor() {
    LlenarComboXServiciosAuth("https://localhost:44387/api/Profesor/LlenarProfesor", "#cboProfesor");
}


async function EjecutarComando(Metodo, Funcion) {
    const curso = new Curso($("#txtId").val(), $("#txtNombre").val(), $("#txtDescripcion").val(), $("#txtHora").val(),
        $("#txtPrecio").val(), $("#cboProfesor").val(), $("#cboCategoriaCurso").val());

    let URL = "https://localhost:44387/api/Cursos/" + Funcion;
    await EjecutarComandoServicioAuth(Metodo, URL, curso);
    LlenarTabla();


}
function updateCharacterCount() {
    const descripcion = document.getElementById("txtDescripcion");
    const charCount = document.getElementById("charCount");
    charCount.textContent = `${descripcion.value.length} / 50 caracteres`;
}

async function Consultar() {
    let Codigo = $("#txtId").val();
    URL = "https://localhost:44387/api/Cursos/ConsultarXCodigo?Codigo=" + Codigo;
    //Invoco el servicio genérico
    const curso = await ConsultarServicioAuth(URL);
    if (curso != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(curso.Nombre);
        $("#txtDescripcion").val(curso.Descripcion);
        $("#txtHora").val(curso.Hora);
        $("#txtPrecio").val(curso.Precio);
        $("#cboProfesor").val(curso.IdProfesor);
        $("#cboCategoriaCurso").val(curso.IdCategoria);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El curso no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
        $("#txtHora").val("");
        $("#txtPrecio").val("");
        $("#cboProfesor").val("");
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