function sumar() {
    var subtotal = $('#Subtotal').val();
    var descuento = $('#Descuento').val();
    var retencion = $('#Retencion').val();
    var ivaValor = 1.16;

    var iva = 0;
    var total = 0;
    var totalRetencion = 0;
    var totalDescuento = 0;

    total = subtotal * ivaValor;
    totalRetencion = total - retencion;
    totalDescuento = totalRetencion - descuento;

    $('#Iva').val((total - subtotal).toFixed(3));
    $('#Total').val(totalDescuento.toFixed(3));
}  

function fechaVencimiento() {
    //Obtener el valor de la caja y se parse a fecha
    var fechaSello = new Date($("#FechaSelloString").val());
    fechaSello.toLocaleDateString();

    var dd = fechaSello.getDate();
    var mm = fechaSello.getUTCMonth() + 1; //January is 0!
    var yyyy = fechaSello.getUTCFullYear();

    //Se le asigna un cero a los dias y meses para que el ususario reconozca la fecha
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    //Se almacena la fecha en una variable y la variable se envia al textbox
    var sello = dd + '/' + mm + '/' + yyyy;

    var dateVencimiento = new Date(yyyy, mm, dd);
    dateVencimiento.toLocaleDateString();

    var ddv = dateVencimiento.getDate();
    //Se agrega un mes a la fecha de sello establecida anteriormente
    var mmv = dateVencimiento.getUTCMonth() + 1;
    var yyyyv = dateVencimiento.getUTCFullYear();

    if (ddv < 10) {
        ddv = '0' + ddv;
    }
    if (mmv < 10) {
        mmv = '0' + mmv;
    }
    var vencimiento = ddv + '/' + mmv + '/' + yyyyv;


    $("#FechaVencimientoString").val(vencimiento);
    //Se vuelve a imprimir la fecha en la caja ya que de la funcion solo recibe yy/mm/dd y se pinta como dd/mm/yy
    $("#FechaSelloString").val(sello);
}

function editar(id) {
    var url = "/facturas/Edit/" + id;
    $.get(url).done(function (response) {
        $("#show-modal").modal({ show: true, backdrop: 'static', keyboard: false });
        $("#inner-show-modal").html(response);
    });
}

function detalles(id) {
    var url = "/facturas/Details/" + id;
    $.get(url).done(function (response) {
        $("#show-modal").modal({ show: true, backdrop: 'static', keyboard: false });
        $("#inner-show-modal").html(response);
    });
}

$(function () {
    $("#FechaFacturaString").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#FechaSelloString").datepicker({
        dateFormat: 'yy/mm/dd',
        changeMonth: true,
        changeYear: true
    });
    $("#FechaVencimientoString").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaPagoInicio").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaPagoFin").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaFacturaInicio").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaFacturaFin").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaVencimientoInicio").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
    $("#fechaVencimientoFin").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
});



