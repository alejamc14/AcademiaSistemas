var TotalPago;
jQuery(function () {
    TotalPago = 0;
    $("#txtTotalCompra").val(TotalPago);
    $("#txtNumeroPago").val(0);
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

    const cursoSeleccionado = $("#cboCurso option")
        .filter(function () {
            return $(this).val().startsWith(cursoId + "|");
        })
        .val();
    if (cursoSeleccionado) {
        $("#cboCurso").val(cursoSeleccionado);
        console.log("Curso asignado correctamente:", cursoSeleccionado);
    } else {
        console.error("No se encontró una opción coincidente para el curso:", cursoId);
    }
}
async function Ejecutar(Metodo, Funcion) {
    let idInscripcion = 0; // Valor predeterminado

    if (Metodo === 'PUT' || Metodo === 'DELETE') {
        idInscripcion = $("#txtIdInscripcion").val();
    }
    const inscripcion = new Inscripcion(idInscripcion, $("#txtFecha").val(), $("#txtIdEstudiante").val(), $("#cboCurso").val().split("|")[0]);

    let URL = "https://localhost:44387/api/Inscripcion/" + Funcion;
    EjecutarComandoServicioAuth(Metodo, URL, inscripcion);
    if (Metodo !== 'DELETE' || Metodo !== 'PUT') {
        GrabarCurso();
    }
    LlenarTabla();
}
function PagoModal() {
    $('#miModal').modal('show');
}
async function LlenarPago(NumeroPago) {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Pago/ListarCursos?NumeroPago=" + NumeroPago, "#tblPago")
}
async function ListarCategoriaCursoInscripcion() {
    await LlenarComboXServiciosAuth("https://localhost:44387/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
    ListarCursoInscripcion($("#cboCategoriaCurso").val());
}
async function ListarCursoInscripcion(CategoriaCurso) {
    let idCategoriaCurso = CategoriaCurso == 0 ? $("#cboCategoriaCurso").val() : CategoriaCurso;
    await LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/listarCursosXCategoriaCursos?CategoriaCurso=" + idCategoriaCurso, "#cboCurso");
    CalcularSubtotal();
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
async function GrabarCurso() {
    CalcularTotal(1, $("#cboCurso").val().split("|")[1], "Suma");
    const detallePago = [new DetallePago(0, $("#txtNumeroPago").val(), $("#cboCurso").val().split("|")[0], $("#cboCurso").val().split("|")[1], 1)];
    const pago = new Pago($("#txtNumeroPago").val(), $("#txtTotalCompra").val(), $("#txtFecha").val(), $("#txtIdEstudiante").val(), detallePago);
    let NumeroPago = await EjecutarComandoServicioRptaAuth("POST", "https://localhost:44387/api/Pago/GrabarPago", pago);
    $("#txtNumeroPago").val(NumeroPago);
    LlenarPago(NumeroPago);
}
function CalcularTotal(Cantidad, ValorUnitario, Operacion) {
    TotalPago = Operacion == "Suma" ? TotalPago + (Cantidad * ValorUnitario) : TotalPago - (Cantidad * ValorUnitario);
    $("#txtTotalCompra").val(TotalPago);
}
function TerminarCurso() {
    // Obtén el total pagado antes de reiniciar
    let totalPagado = TotalPago;

    // Reinicia los valores
    TotalPago = 0;
    $("#txtTotalCompra").val(TotalPago);
    $("#txtNumeroPago").val(0);
    $("#txtFechaCompra").val("");
    $("#txtidEstudiante").val("");
    $("#txtNombreEstudiante").val("");
    var table = new DataTable('#tblPago');
    table.clear().draw();

    // Mostrar el SweetAlert2 con el total pagado
    Swal.fire({
        title: 'Pago realizado con éxito',
        text: `El total pagado es: $${totalPagado}`,
        icon: 'success',
        confirmButtonText: 'Aceptar'
    });
}
function CalcularSubtotal() {
    let DatosCombo = $("#cboCurso").val();
    $("#txtCodigoCurso").val(DatosCombo.split('|')[0]);
    let ValorUnitario = DatosCombo.split('|')[1];
    $("#txtValorUnitario").val(ValorUnitario);
    console.log("valor unitario:", ValorUnitario);
    let Cantidad = 1;
    if (Cantidad <= 0) {
        $("#txtCantidad").val(1);
        Cantidad = 1;
    }
    $("#txtSubtotal").val(Cantidad * ValorUnitario);
}
async function Eliminar(idPago, cantidad, valorunidad) {
    const detallePago = [new DetallePago(0, $("#txtNumeroPago").val(), $("#txtCodigoCurso").val(), $("#txtValorUnitario").val(), $("#txtCantidad").val())];
    const pago = new Pago($("#txtNumeroPago").val(), $("#txtTotalCompra").val(), $("#txtFechaCompra").val(), $("#txtidEstudiante").val(), detallePago);
    await EjecutarComandoServicioAuth('DELETE', "https://localhost:44387/api/Pago/Eliminar?NumeroDetalle=" + idPago, pago);
    LlenarDetallePago($("#txtNumeroPago").val());
    CalcularTotal(cantidad, valorunidad, "Resta");
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
class Pago {
    constructor(Id, Total, FechaPago, IdEstudiante, DetallePagoes) {
        this.Id = Id;
        this.Total = Total;
        this.FechaPago = FechaPago;
        this.IdEstudiante = IdEstudiante;
        this.DetallePagoes = DetallePagoes;
    }
}
    class DetallePago {
        constructor(Id, IdPago, IdCurso, ValorUnitario, Cantidad) {
            this.Id = Id;
            this.IdPago = IdPago;
            this.IdCurso = IdCurso;
            this.ValorUnitario = ValorUnitario;
            this.Cantidad = Cantidad;
        }
    }