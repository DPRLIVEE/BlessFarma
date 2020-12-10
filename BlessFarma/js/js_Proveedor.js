function validAdd() {
    var rs = $('#txtRazonSocialAdd').val();
    var RUC = $('#txtRUCAdd').val();
    var Correo = $('#txtCorreoAdd').val();
    var Contacto = $('#txtContactoAdd').val();
    var Telefono = $('#txtTelefonoAdd').val();
    var msj = '';

    if ($.trim(rs) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar una razón social válida.';
    }
    if ($.trim(RUC) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un RUC válido.';
    }
    if ($.trim(RUC).length != 11 && $.trim(RUC).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *El RUC debe tener 11 dígitos.';
    }
    if (($.trim(RUC).substring(0, 2) != '20' && $.trim(RUC).substring(0, 2) != '10') && $.trim(RUC).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *El RUC debe empezar con 20 o 10.';
    }
    if ($.trim(Correo) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un correo válido.';
    }
    if ($.trim(Contacto) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un contacto válido.';
    }
    if ($.trim(Telefono) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono válido.';
    }
    if ($.trim(Telefono).length != 9 && $.trim(Telefono).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono de 9 dígitos.';
    }
    if ($.trim(Telefono).length == 9 && $.trim(Telefono)[0] != '9') {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono válido.';
    }

    if (msj.length > 0) {
        verAlerta('No puede continuar por el(los) siguiente(s) motivo(s):<br><br>' + msj);
        return false;
    } else {
        return true;
    }
}

function validEdit() {
    var rs = $('#txtRazonSocialEdit').val();
    var RUC = $('#txtRUCEdit').val();
    var Correo = $('#txtCorreoEdit').val();
    var Contacto = $('#txtContactoEdit').val();
    var Telefono = $('#txtTelefonoEdit').val();
    var msj = '';

    if ($.trim(rs) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar una razón social válida.';
    }
    if ($.trim(RUC) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un RUC válido.';
    }
    if ($.trim(RUC).length != 11 && $.trim(RUC).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *El RUC debe tener 11 dígitos.';
    }
    if (($.trim(RUC).substring(0, 2) != '20' && $.trim(RUC).substring(0, 2) != '10') && $.trim(RUC).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *El RUC debe empezar con 20 o 10.';
    }
    if ($.trim(Correo) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un correo válido.';
    }
    if ($.trim(Contacto) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un contacto válido.';
    }
    if ($.trim(Telefono) == "") {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono válido.';
    }
    if ($.trim(Telefono).length != 9 && $.trim(Telefono).length > 0) {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono de 9 dígitos.';
    }
    if ($.trim(Telefono).length == 9 && $.trim(Telefono)[0] != '9') {
        msj += msj.length > 0 ? '<br>' : '';
        msj += '   *Debe ingresar un teléfono válido.';
    }

    if (msj.length > 0) {
        verAlerta('No puede continuar por el(los) siguiente(s) motivo(s):<br><br>' + msj);
        return false;
    } else {
        return true;
    }
}

function RUCFooter() {
    if ($('#txtRUCAdd').val().length == 11) {
        Preloader();
        $('#txtRazonSocialAdd').prop('readonly', true);
        $('#txtCorreoAdd').prop('readonly', true);
        $('#txtContactoAdd').prop('readonly', true);
        $('#txtTelefonoAdd').prop('readonly', true);
        $.ajax({
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: '/Paginas/Otros/Metodos.aspx/GetInfoRUC',
            data: '{"ruc":"' + $('#txtRUCAdd').val() + '" }',
            success: function (response) {
                if (response.d != '') {
                    var result = jQuery.parseJSON(response.d);
                    if (result.ruc == null) {
                        verAlerta('El proveedor no existe.');
                        NoPrealoader();
                    }
                    else {
                        document.getElementById('lblresult_RUC').innerHTML = result.ruc;
                        document.getElementById('lblresult_RazonSocial').innerHTML = result.razon_social;
                        document.getElementById('lblresult_NombreComercial').innerHTML = result.nombre_comercial;
                        document.getElementById('lblresult_DireccionFiscal').innerHTML = result.domicilio_fiscal;
                        document.getElementById('lblresult_Estado').innerHTML = result.contribuyente_estado;
                        document.getElementById('lblresult_Condicion').innerHTML = result.contribuyente_condicion;
                        document.getElementById('lblresult_TipoContribuyente').innerHTML = result.contribuyente_tipo;
                        document.getElementById('lblresult_EmisionElectronica').innerHTML = result.sistema_emision;
                        NoPrealoader();
                        $('#myModalSunat').modal('show');
                    }
                }
                else {
                    NoPrealoader();
                }
                $('#txtRazonSocialAdd').prop('readonly', false);
                $('#txtCorreoAdd').prop('readonly', false);
                $('#txtContactoAdd').prop('readonly', false);
                $('#txtTelefonoAdd').prop('readonly', false);
            }
        });
    }
}

function GetRUCValue() {
    $('#txtRazonSocialAdd').val(document.getElementById('lblresult_RazonSocial').innerHTML);
    $('#myModalSunat').modal('hide');
}