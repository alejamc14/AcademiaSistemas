jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    /*LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/LlenarCombo", "#cboCurso");*/
    LlenarTabla();

});

function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Certificados/LlenarTabla", "#tblCertificados");
}

async function ConsultarEstudiante() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44387/api/Estudiantes/ConsultarEstudiante2?Documento=" + Documento;
    //Invoco el servicio genérico
    const estudiante = await ConsultarServicioAuth(URL);
    if (estudiante != null && estudiante.length > 0) {
        $("#txtNombre").val(estudiante[0].Estudiante);
        $("#txtidEstudiante").val(estudiante[0].IdEstudiante);
        $("#dvMensaje").html("");

    }
    else {
        $("#txtNombre").val("");
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'El estudiante no existe, por favor valide la información'
        });
    }

    ListarCurso($("#txtidEstudiante").val());

}


async function EjecutarComando(Metodo, Funcion) {
    const curso = new Certificado($("#txtId").val(),$("#txtNombreCer").val(), $("#txtFecha").val(), $("#txtidEstudiante").val(),
        $("#cboCurso").val());

    let URL = "https://localhost:44387/api/Certificados/" + Funcion;
    await EjecutarComandoServicioAuth(Metodo, URL, curso);
    LlenarTabla();


}

async function Consultar() {
    let Id = $("#txtId").val();
    URL = "https://localhost:44387/api/Certificados/ConsultarXId?id=" + Id;
    //Invoco el servicio genérico
    const certificado = await ConsultarServicioAuth(URL);
    if (certificado != null) {
        $("#dvMensaje").html("");
        $("#txtNombreCer").val(certificado.NombreCertificado);
        $("#txtFecha").val(certificado.FechaCertificacion.split('T')[0]);
        $("#cboEstudiante").val(certificado.IdEstudiante);
        $("#cboCurso").val(certificado.IdCurso);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El curso no existe en la base de datos");
        $("#txtNombreCer").val("");
        $("#txtFecha").val("");
        $("#cboEstudiante").val("");
        $("#cboCurso").val("");
    }
}

async function ConsultarUsuario() {
    let Usuario = getCookie("Usuario");
    const DatosEstudiante = await ConsultarServicioAuth("https://localhost:44387/api/Estudiantes/ConsultarUsuario?Usuario=" + Usuario);
    $("#txtidEstudiante").val(DatosEstudiante[0].IdEstudiante);
    /*$("#idTitulo").html("CERTIFICADOS - ESTUDIANTE " + DatosEstudiante[0].Estudiante);*/
    ConsultarEstudiante();
}


async function ListarCurso(idEstudiante) {
    /*let idCategoriaCurso = CategoriaCurso == 0 ? $("#cboCategoriaCurso").val() : CategoriaCurso;*/
    await LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/ListarCurso?id=" + idEstudiante, "#cboCurso");
    
}
class Certificado {
    constructor(Id, NombreCertificado, FechaCertificacion,IdEstudiante, IdCurso) {
        this.Id = Id;
        this.NombreCertificado = NombreCertificado;
        this.FechaCertificacion = FechaCertificacion;
        this.IdEstudiante = IdEstudiante;
        this.IdCurso = IdCurso;
      

    }
}