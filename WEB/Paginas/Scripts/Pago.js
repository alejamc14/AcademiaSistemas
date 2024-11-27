jQuery(function () {
    $("#txtTotalCompra").val(0);
    $("#txtNumeroPago").val(0);
    $("#txtFechaCompra").val(FechaHoy());
    ConsultarUsuario();
    ListarCategoriaCurso();
});
async function GrabarCurso() {
    const detallePago = [new DetallePago(0, $("#txtNumeroPago").val(), $("#txtCodigoCurso").val(), $("#txtValorUnitario").val(), $("#txtCantidad").val())];
    const pago = new Pago($("#txtNumeroPago").val(), $("#txtTotalCompra").val(), $("#txtFechaCompra").val(), $("#txtidEstudiante").val(), detallePago);
    let NumeroFactura = await EjecutarComandoServicioRptaAuth("POST", "https://localhost:44387/api/Pago/GrabarPago", pago);
    $("#txtNumeroPago").val(NumeroFactura);
    LlenarDetallePago(NumeroFactura);
}
async function LlenarDetallePago(NumeroFactura) {
    LlenarTablaXServiciosAuth("https://localhost:44387/api/Pago/ListarCursos?NumeroFactura=" + NumeroFactura, "#tblPago")
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
async function ListarCategoriaCurso() {
    await LlenarComboXServiciosAuth("https://localhost:44387/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
    ListarCurso($("#cboCategoriaCurso").val());
}
async function ListarCurso(CategoriaCurso) {
    let idCategoriaCurso = CategoriaCurso == 0 ? $("#cboCategoriaCurso").val() : CategoriaCurso;
    await LlenarComboXServiciosAuth("https://localhost:44387/api/Cursos/listarCursosXCategoriaCursos?CategoriaCurso=" + idCategoriaCurso, "#cboCurso");
    CalcularSubtotal();
}
function CalcularSubtotal() {
    let DatosCombo = $("#cboCurso").val();
    $("#txtCodigoCurso").val(DatosCombo.split('|')[0]);
    let ValorUnitario = DatosCombo.split('|')[1];
    $("#txtValorUnitario").val(ValorUnitario);
    $("#txtValorUnitarioTexto").val(FormatoMiles(ValorUnitario));
    let Cantidad = $("#txtCantidad").val();
    if (Cantidad <= 0) {
        $("#txtCantidad").val(1);
        Cantidad = 1;
    }
    $("#txtSubtotal").val(FormatoMiles(Cantidad * ValorUnitario));
}
async function ConsultarUsuario() {
    let Usuario = getCookie("Usuario");
    const DatosEstudiante = await ConsultarServicioAuth("https://localhost:44387/api/Estudiantes/ConsultarUsuario?Usuario=" + Usuario);
    $("#txtidEstudiante").val(DatosEstudiante[0].IdEstudiante);
    $("#idTitulo").html("FACTURA DE COMPRA - ESTUDIANTE " + DatosEstudiante[0].Estudiante);
}
async function Consultar() {
    let Documento = $("#txtDocumento").val();
    const Estudiante = await ConsultarServicioAuth("https://localhost:44387/api/Estudiantes/ConsultarXDocumento?Documento=" + Documento);
    $("#txtNombreEstudiante").val(Estudiante.Nombre + " " + Estudiante.Apellido);
}   