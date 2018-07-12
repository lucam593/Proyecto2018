function logIn() {
    var req = $.ajax({
        url:"http://localhost:12346/WSRest/WSVehiculosRest.svc/listarVehiculos",
        timeout: 10000,
        dataType: "jsonp"	
    });

    req.done(function (datos))