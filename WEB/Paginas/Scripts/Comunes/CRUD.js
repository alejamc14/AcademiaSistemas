//async function EjecutarComandoServicio(Metodo, URLServicio, Objeto) {
//    //Se crea un objeto de la clase cliente con los datos de la interfaz
//    try {
//        const Respuesta = await fetch(URLServicio,
//            {
//                method: Metodo,
//                mode: "cors",
//                headers: { "Content-Type": "application/json" },
//                body: JSON.stringify(Objeto)
//            });
//        //Leer la respuesta
//        const Resultado = await Respuesta.json();
//        $("#dvMensaje").html(Resultado);
//    }
//    catch (error) {
//        //Se presenta el error en un div de Mensaje
//        $("#dvMensaje").html(error);
//    }
//}
async function EjecutarComandoServicio(Metodo, URLServicio, Objeto) {
    // Se crea un objeto de la clase cliente con los datos de la interfaz
    try {
        let result;


        // Confirmación para Eliminar (DELETE)
        if (Metodo === 'DELETE') {
            result = await Swal.fire({
                title: '¿Estás seguro?',
                text: "¡Esta acción eliminará los datos permanentemente!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, eliminar',
                cancelButtonText: 'Cancelar'
            });

            // Si el usuario confirma la eliminación
            if (!result.isConfirmed) {
                return; // Si el usuario cancela, no se realiza la eliminación
            }
        }

        // Realizar la solicitud a la API (para Insertar, Actualizar, Eliminar)
        const Respuesta = await fetch(URLServicio, {
            method: Metodo,
            mode: "cors",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(Objeto)
        });

        // Leer la respuesta
        const Resultado = await Respuesta.json();

        // Mostrar mensaje en el div de mensaje
        $("#dvMensaje").html(Resultado);

        // Mostrar SweetAlert según el tipo de acción
        if (Metodo === 'POST') {
            // Para insertar
            await Swal.fire(
                '¡Registro creado!',
                'El registro se ha creado con éxito.',
                'success'
            );
        } else if (Metodo === 'PUT') {
            // Para actualizar
            await Swal.fire(
                '¡Actualizado!',
                'Los datos fueron actualizados correctamente.',
                'success'
            );
        } else if (Metodo === 'DELETE') {
            // Para eliminar
            await Swal.fire(
                'Eliminado',
                'Los datos fueron eliminados correctamente.',
                'success'
            );
        }
    } catch (error) {
        // Manejo de errores
        $("#dvMensaje").html(error);
        await Swal.fire(
            'Error',
            'Ocurrió un error en la operación.',
            'error'
        );
    }
}

async function ConsultarServicio(URLServicio) {
    //Para invocar el servicio, vamos a utilizar el método fetch de javascript, el cual me permite invocar una función en un servidor
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        //Se traduce la respuesta a un objeto
        const Resultado = await Respuesta.json();

        return Resultado;
    }
    catch (error) {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html(error);
    }
}

//Llenar un combo desde un servicio
async function LlenarComboXServicios(URLServicio, ComboLlenar) {
    //Debe ir a la base de datos y llenar la información del combo de tipo producto
    //Invocamos el servicio a través del fetch, usando el método fetch de javascript
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        
        //Se debe limpiar el combo
        $(ComboLlenar).empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Codigo + '>' + Rpta[i].Nombre + '</option>');
        }

    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaXServicios(URLServicio, TablaLlenar) {
    //Invocamos el servicio a través del fetch, usando el método fetch de javascript
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se recorre en un ciclo para llenar la tabla, con encabezados y los campos
        //Llena el encabezado
        var Columnas = [];
        NombreColumnas = Object.keys(Rpta[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }
        //Llena los datos
        $(TablaLlenar).DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}