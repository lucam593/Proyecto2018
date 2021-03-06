﻿function MotrarPlatos() {
    var req = $.ajax({
        url: "http://necrotavo-001-site1.ftempurl.com/WSCLIENTE/WS_CLIENTE.svc/listaPlatos",
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {
        $.each(datos, function () {

            var newTR = document.createElement("tr");

            var nombreTD = document.createElement("td");
            nombreTD.textContent = this.Nombre;

            var precioTD = document.createElement("td");
            precioTD.textContent = this.Precio;

            var radioTD = document.createElement("td");
            var radio = document.createElement("input");
            var codigo = this.Codigo;
            radio.type = "button";
            radio.name = "seleccion";
            radio.value = "Detalles";
            radio.onclick = function () {
                MotrarPlato(codigo);
            };
            radioTD.appendChild(radio);

            newTR.appendChild(nombreTD);
            newTR.appendChild(precioTD);
            newTR.appendChild(radioTD);

            $('#Platos').append(newTR);
        });
    });
    req.fail(function () {
        alert("Error al conectar con el servicio platos");
    });
}

function MotrarPlato(ide) {
    $('#Plato').empty();
    var req = $.ajax({
        url: "http://necrotavo-001-site1.ftempurl.com/WSCLIENTE/WS_CLIENTE.svc/platoxCod?cod=" + ide,
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {
        $.each(datos, function () {
            var newTR = document.createElement("tr");

            var nombreTD = document.createElement("td");
            nombreTD.textContent = this.Nombre;

            var descriptionTD = document.createElement("td");
            descriptionTD.textContent = this.Descripcion;

            var precioTD = document.createElement("td");
            precioTD.textContent = "Precio $" + this.Precio;

            var fotoTD = document.createElement("td");
            var fotoIMG = document.createElement("img");
            fotoIMG.src = this.Fotografia;
            fotoIMG.height = 150;
            fotoIMG.width = 150;
            fotoTD.appendChild(fotoIMG);

            newTR.appendChild(nombreTD);
            newTR.appendChild(descriptionTD);
            newTR.appendChild(precioTD);
            newTR.appendChild(fotoTD);

            $('#Plato').append(newTR);
        });
    });
    req.fail(function () {
        alert("Error al conectar con el servicio plato");
    });
}