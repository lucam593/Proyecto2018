function MotrarPlatos() {
    var req = $.ajax({
        url: "",
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {
        $.each(datos, function () {

            var newTR = document.createElement("tr");

            var nombreTD = document.createElement("td");
            nombreTD.textContent = this.NombrePlato;

            var precioTD = document.createElement("td");
            precioTD.textContent = this.precio;

            var radioTD = document.createElement("td");
            var radio = document.createElement("input");
            radio.type = "radio";
            radio.name = "seleccion";
            radio.id = this.NombrePlato;
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
    var idPlato = fromcombobox;
    var req = $.ajax({
        url: "" + fromcombobox,
        timeout: 10000,
        dataType: "jsonp"
    });

    req.done(function (datos) {

            var newTR = document.createElement("tr");

            var nombreTD = document.createElement("td");
            nombreTD.textContent = this.NombrePlato;

            var descriptionTD = document.createElement("td");
            descriptionTD.textContent = this.Description;

            var precioTD = document.createElement("td");
            precioTD.textContent = this.precio;

            var fotoTD = document.createElement("td");
            fotoTD = this.foto;

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