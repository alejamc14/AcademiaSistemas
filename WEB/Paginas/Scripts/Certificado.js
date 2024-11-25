jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")

    LlenarComboXServicios("https://localhost:44387/api/Cursos/LlenarCombo", "#cboCurso");
    LlenarTabla();

});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44387/api/Certificados/LlenarTabla", "#tblCertificados");
}


async function EjecutarComando(Metodo, Funcion) {
    const curso = new Certificado($("#txtId").val(), $("#txtNombre").val(), $("#txtFecha").val(), $("#cboEstudiante").val(),
        $("#cboCurso").val());

    let URL = "https://localhost:44387/api/Certificados/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, curso);
    LlenarTabla();


}

async function Consultar() {
    let Id = $("#txtId").val();
    URL = "https://localhost:44387/api/Certificados/ConsultarXId?id=" + Id;
    //Invoco el servicio genérico
    const certificado = await ConsultarServicio(URL);
    if (certificado != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(certificado.NombreCertificado);
        $("#txtFecha").val(certificado.FechaCertificacion.split('T')[0]);
        $("#cboEstudiante").val(certificado.IdEstudiante);
        $("#cboCurso").val(certificado.IdCurso);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El curso no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtFecha").val("");
        $("#cboEstudiante").val("");
        $("#cboCurso").val("");
    }
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