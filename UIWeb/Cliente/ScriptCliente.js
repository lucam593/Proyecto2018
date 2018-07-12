function MotrarPlatos() {
    var req = $.ajax({
        url: "http://localhost:37369/WSCLIENTE/WS_CLIENTE.svc/listaPlatos",
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
            radio.type = "button";
            radio.name = "seleccion";
            radio.value = "Detalles";
            radio.id = this.Codigo;
            var ide = this.Codigo;
            $('#' + ide).bind("click",function(){
                MotrarPlato();
            })
            radioTD.appendChild(radio);

            newTR.appendChild(nombreTD);
            newTR.appendChild(precioTD);
            newTR.appendChild(radioTD);

            $('#Platos').append(newTR);
        });
    });
    req.fail(function () {
        alert("Error al conectar con el servicio");
    });
}

function MotrarPlato() {
  
    var req = $.ajax({
        url: "http://localhost:37369/WSCLIENTE/WS_CLIENTE.svc/platoxCod?cod=1",
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {

            var newTR = document.createElement("tr");

            var nombreTD = document.createElement("td");
            nombreTD.textContent = this.Nombre;

            var descriptionTD = document.createElement("td");
            descriptionTD.textContent = this.Description;

            var precioTD = document.createElement("td");
            precioTD.textContent = this.Precio;

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
    req.fail(function () {
        alert("Error al conectar con el servicio");
    });
}