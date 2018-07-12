function ActualizarDatos(userName, newUserName, newDireccion, newPassword) {
    var req = $.ajax({
        url: "http://localhost:37369/WSCLIENTE/WS_CLIENTE.svc/modificarDireccionCliente?nombreUsuario=" + userName + "&newNombre=" + newUserName + "&newDireccion=" + newDireccion + "&newContrasenha=" + newPassword,
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {
        $.each(datos, function () {
            alert("Error al actualizar los datos");
        });
    });
    req.fail(function () {
        alert("Error al conectar con el usuario");
    });
}
