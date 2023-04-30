var oTabla = $("#tblUsuario").DataTable();
$(document).ready(function () {
    $('#tblUsuario tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });
    
    $("#bntInsertar").click(function () {
        EjecutarComando("Insertar");
    });
    $("#btnActualizar").click(function () {
        EjecutarComando("Actualizar");
    });

    //LlenarTablaUsuario();
    //LlenarComboUsuario();
    LlenarTablaAhorro();
    LlenarComboPermiso();
  
});
function EjecutarComando(Comando) {

    let Id = $("#txtId").val();
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let Telefono = $("#txtTelefono").val();
    let Fecha_Ingreso = $("#txtFechaIngreso").val();
    let Id_Estado = $("#txtId_Estado").val();
    let Id_Permiso = $("#cboPermiso").val();

    
    let DatosUsuario = {
        Id: 0,
        Documento: Documento,
        Nombre: Nombre,
        Telefono: Telefono,
        Fecha_Ingreso: Fecha_Ingreso,
        Id_Estado: Id_Estado,
        Id_Permiso: 0,
        Comando: Comando,
        Error: ""
    }
    //Invocar el controlador vía ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorUsuario.ashx",
        contentType: "json",
        data: JSON.stringify(DatosUsuario),
        success: function (rptaUsuario) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(rptaUsuario);
        },
        error: function (errUsuario) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errUsuario);
        }
    });
}

function EditarFila(DatosFila) {
    $("#txtId").val(DatosFila.find('td:eq(0)').text());
    $("#txtDocumento").val(DatosFila.find('td:eq(1)').text());
    $("#txtNombre").val(DatosFila.find('td:eq(2)').text());
    $("#txtTelefono").val(DatosFila.find('td:eq(3)').text());
    $("#txtFechaIngreso").val(DatosFila.find('td:eq(4)').text());
    $("#txtId_Estado").val(DatosFila.find('td:eq(5)').text());
    $("#cboPermiso").val(DatosFila.find('td:eq(6)').text());
}
function LlenarComboPermiso(){
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorLLenarCombo.ashx",
        contentType: "json",
        data: JSON.stringify("TipoPermiso"),
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosTipoAhorro = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboPermiso").append('<option value=' + DatosTipoPermiso[op].Id + '>' + DatosTipoPermiso[op].Documento + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });

}
function LlenarTablaUsuario() {
    let DatosUsuario = {
        Id: 0,
        Documento: Documento,
        Nombre: Nombre,
        Telefono: Telefono,
        Fecha_Ingreso: Fecha_Ingreso,
        Id_Estado: Id_Estado,
        Id_Permiso: 0,
        Comando: "LlenarGrid",
        Error: ""
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorUsuario.ashx",
        contentType: "json",
        data: JSON.stringify(DatosAhorro),
        success: function (rpta) {
            LlenarGrid_JSON(JSON.parse(rpta), "#tblUsuario");

        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}

