function logIn(nombreUsuario, contrasenha, rol, direccion, nombreCompleto, correo, habilitado) {

    var req = $.ajax({
        url: "http://localhost:37369/WSCLIENTE/WS_CLIENTE.svc/registrarCliente?nombreUsuario=" + nombreUsuario + "&contrasenha=" + contrasenha + "&rol=" + rol + "&direccion=" + direccion + "&nombreCompleto=" + nombreCompleto + "&correo=" + correo + "&habilitado=" + habilitado,
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function(datos){
        alert("Listo");
    })

    req.fail(function () {
        alert("Error al conectar con el servicio");
    })




}