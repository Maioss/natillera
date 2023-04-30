
var oTabla = $("#tblAhorro").DataTable();
$(document).ready(function () {
    $('#tblAhorro tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });
    $("#btnIngresar").click(function () {
        EjecutarComando("Insertar");
    });
    $("#btnEliminar").click(function () {
        EjecutarComando("Eliminar");
    });
    LlenarComboTipo();
    LlenarComboUsuario();
    LlenarTablaAhorro();
});

function EjecutarComando(Comando) {
   
    let Id = $("#txtId").val();
    let Id_Tipo = $("#cboTipoAhorro").val();
    let Ahorro_Parcial = $("#txtAhorroParcial").val();
    if ($("#txtAhorroParcialEdit").val() != "") {
        Ahorro_Parcial = $("#txtAhorroParcialEdit").val();
    }
    debugger;
    let DatosAhorro = {
        Id: parseiNT(Id),
        Id_Tipo: Id_Tipo,
        Ahorro_Parcial: Ahorro_Parcial,
        Ahorro_Total: 0,
        Total_Ganancias: 0,
        Id_Estado: 0,
        Comando: Comando,
        Error: ""
    }

    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorAhorro.ashx",
        contentType: "json",
        data: JSON.stringify(DatosAhorro),
        success: function (rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(rpta);
            LlenarTablaAhorro();
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}


function EditarFila(DatosFila) {
    $("#txtId").val(DatosFila.find('td:eq(0)').text());
    $("#cboTipoAhorro").val(DatosFila.find('td:eq(1)').text());
    $("#txtAhorroParcialEdit").val(DatosFila.find('td:eq(2)').text());
    $("#txtAhorroTotal").val(DatosFila.find('td:eq(3)').text());
    $("#txtTotalGanancias").val(DatosFila.find('td:eq(4)').text());
    $("#txtIdEstado").val(DatosFila.find('td:eq(5)').text());
}

function LlenarComboTipo() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorLLenarCombo.ashx",
        contentType: "json",
        data: JSON.stringify("TipoAhorro"),
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosTipoAhorro = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboTipoAhorro").append('<option value=' + DatosTipoAhorro[op].Id + '>' + DatosTipoAhorro[op].Nombre + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}

function LlenarComboUsuario() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorLLenarCombo.ashx",
        contentType: "json",
        data: JSON.stringify("Usuario"),
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosTipoAhorro = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboUsuarios").append('<option value=' + DatosTipoAhorro[op].Id + '>' + DatosTipoAhorro[op].Nombre + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}


function LlenarTablaAhorro() {
    let DatosAhorro = {
        Id: 0,
        Id_Tipo: 0,
        Ahorro_Parcial: 0,
        Ahorro_Total: 0,
        Total_Ganancias: 0,
        Id_Estado: 0,
        Comando: "LlenarGrid",
        Error: ""
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorAhorro.ashx",
        contentType: "json",
        data: JSON.stringify(DatosAhorro),
        success: function (rpta) {
            LlenarGrid_JSON(JSON.parse(rpta), "#tblAhorro");

        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}