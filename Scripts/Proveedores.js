function Guardar() {
    $.ajax({
        type: 'POST',
        url: '/edumatica/proveedors/Edit/' + $("#id").val(),
        data: {
            'id': $("#id").val(),
            'razonSocial': $("#RazonSocial").val(),
            'rfc': $("#RFC").val(),
            'categoria_id': $("#CategoriaProveedor_Id").val(),
            'nacionalidad_id': $("#NacionalidadProveedor_Id").val(),
            'estado_id': $("#EstadoProveedor_Id").val()
        },
        success: function (response) {            
            switch (response) {
                case 'True':
                    $('#msg').html("<br /><div class='alert alert-success' role='alert'>Registro editado correctamente</div>");
                    $('#msg').show();
                    setTimeout(function () {
                        $('#msg').hide("blind", {}, 1000);
                    },5000);
                    break;
                case 'False':
                    $('#msg').html("<br /><div class='alert alert-danger' role='alert'>Ha ocurrido un error</div>");                    
                    break;
                default: console.log('predeterminado');
            }          
        },
        error: function () {
            alert("error");
        }
    });
}

function Cerrar()
{
    var url = window.location.href;
    window.location.href = url;
}

function filtrarProveedores() {
    $.ajax({
        type: 'GET',
        url: '/edumatica/proveedors/ListaProveedores',
        data: {
            'buscar': $("#buscar").val()
        },
        success: function (response) {
            $('#contenedor').html(response);
        },
        error: function () {
            alert("error");
        }
    });
}

function pdf(id) {
    window.open('/edumatica/proveedors/DownloadViewPDF?idProveedor=' + id, '_blank');
}


function editar(id) {
    var url = "/edumatica/proveedors/Edit/" + id;
    $.get(url).done(function (response) {
        $("#show-modal").modal({ show: true, backdrop: 'static', keyboard: false });
        $("#inner-show-modal").html(response);
    });
}

function detalles(id) {
    var url = "/edumatica/proveedors/Details/" + id;
    $.get(url).done(function (response) {
        $("#show-modal").modal({ show: true, backdrop: 'static', keyboard: false });
        $("#inner-show-modal").html(response);
    });
}