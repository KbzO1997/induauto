function insertarVehiculo() {
    const value = {
        id: $("#id").val(),
        codigo: $("#codigo").val(),
        chasis: document.getElementById('chasis').value,
        marca: document.getElementById('marca').value,
        modelo: document.getElementById('modelo').value,
        anio_modelo: parseInt(document.getElementById('anio_modelo').value),
        color: document.getElementById('color').value,
        estado: document.getElementById('estado').value
    };

    $.ajax({
        cache: false,
        type: "POST",
        url: "/home/Insertar",
        data: JSON.stringify(value),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.exitoso) {
                alert('Vehículo insertado con éxito');
            } else {
                alert('Error: ' + data.Mensaje);
            }
        },
        error: function (jqXHR, exception) {
            console.log(jqXHR, exception);
        }
    });
}


function consultarVehiculo() {
    $.ajax({
        cache: false,
        type: "GET",
        url: "/home/consultarVehiculo",
        data: {id:0},
        datatype: 'html',
        success: function (data) {
            $("#divConsulta").empty().html(data);
        },
        error: function (jqXHR, exception) {
            console.log(jqXHR, exception);
        }
    });
}

function editar(id) {
    var value = { id: id };
    $.ajax({
        url: "/home/consultarIdVehiculo",
        type: "POST",
        data: JSON.stringify(value),
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#id").val(data.id);
            $("#codigo").val(data.codigo);
            document.getElementById('chasis').value = data.chasis;
            document.getElementById('marca').value = data.marca;
            document.getElementById('modelo').value = data.modelo;
            document.getElementById('anio_modelo').value = data.anio_modelo;
            document.getElementById('color').value = data.color;
            document.getElementById('estado').value = data.estado;
        },
        error: function (jqXHR, exception) {
            console.log(jqXHR, exception);
        }
    });
}