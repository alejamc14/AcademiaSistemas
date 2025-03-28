//async function Ingresar() {
//    let URL = "http://localhost:44387/api/Login/Ingresar";
//    const login = new Login($("#txtUsuario").val(), $("#txtClave").val());
//    const Respuesta = await EjecutarComandoServicioRpta("POST", URL, login);
//    if (Respuesta == undefined) {
//        document.cookie = "token=0;path=/";
//        //Hubo un error al procesar el comando
//        $("#dvMensaje").removeClass("alert alert-success");
//        $("#dvMensaje").addClass("alert alert-danger");
//        $("#dvMensaje").html("El usuario no está registrado u olvidó la clave");
//    }
//    else {
//        const extdays = 5;
//        const d = new Date();
//        d.setTime(d.getTime() + (extdays * 24 * 60 * 60 * 1000));
//        let expires = ";expires=" + d.toUTCString();
//        document.cookie = "token=" + Respuesta[0].Token + expires + ";path=/";
//        //let token = getCookie("token");
//        $("#dvMensaje").removeClass("alert alert-danger");
//        $("#dvMensaje").addClass("alert alert-success");
//        $("#dvMensaje").html(Respuesta[0].Mensaje);
//        document.cookie = "Perfil=" + Respuesta[0].Perfil;
//        //alert(Respuesta[0].Perfil);
//        window.location.href = Respuesta[0].PaginaInicio;
//    }
//}
async function Ingresar() {
    let URL = "https://localhost:44387/api/Login/Ingresar";
    const login = new Login($("#txtUsuario").val(), $("#txtClave").val());

    try {
        const Respuesta = await EjecutarComandoServicioRptaInicioAuth("POST", URL, login);

        if (!Respuesta) {
            // Mostrar alerta si no hay respuesta
            document.cookie = "token=0;path=/";
            await Swal.fire({
                icon: 'error',
                title: 'Error al iniciar sesión',
                text: 'El usuario no está registrado o la clave es incorrecta.',
                confirmButtonText: 'Aceptar'
            });
        } else {
            // Establecer la cookie con el token
            const extdays = 5;
            const d = new Date();
            d.setTime(d.getTime() + (extdays * 24 * 60 * 60 * 1000));
            let expires = ";expires=" + d.toUTCString();
            document.cookie = "token=" + Respuesta[0].Token + expires + ";path=/";
            document.cookie = "Perfil=" + Respuesta[0].Perfil;
            document.cookie = "Usuario=" + Respuesta[0].Usuario;

            // Mostrar mensaje de éxito
            await Swal.fire({
                icon: 'success',
                title: 'Inicio de sesión exitoso',
                text: Respuesta[0].Mensaje,
                confirmButtonText: 'Continuar'
            });

            // Redirigir a la página de inicio
            window.location.href = Respuesta[0].PaginaInicio;
        }
    } catch (error) {
        // Manejo de errores inesperados
        await Swal.fire({
            icon: 'error',
            title: 'Error inesperado',
            text: 'Ocurrió un problema al intentar iniciar sesión. Intenta nuevamente más tarde.',
            confirmButtonText: 'Aceptar'
        });
        console.error(error);
    }
}

class Login {
    constructor(Usuario, Clave) {
        this.Usuario = Usuario;
        this.Clave = Clave;
    }
}