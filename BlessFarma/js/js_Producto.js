function ValidMaterialAdd() {
    if ($('#ddlMaterialAdd').val() == '') {
        Swal.fire({
            title: 'Hubo un Problema',
            html: 'Seleccione un material',
            icon: 'warning',
            showConfirmButton: false,
            showCloseButton: true
        });
        return false;
    }
}

function ValFotoPrincipal(index) {
    var row = $(index).closest("tr").index() + 1;
    if (document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + row + '_chkPrincipal').checked) {
        for (var i = 2; i < 6; i++) {
            if (row != i) {
                document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_chkPrincipal').disabled = true;
            }
        }
    }
    else {
        for (var i = 2; i < 6; i++) {
            if (row != i) {
                document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_chkPrincipal').disabled = false;
            }
        }
    }
}

function NombreArchivo(index) {
    var row = $(index).closest("tr").index() + 1;
    var file = document.getElementsByName('ctl00$ContentPlaceHolder1$gvFotos$ctl0' + row + '$fluFoto')[0];
    document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + row + '_lblNombreFoto').innerHTML = file.files[0].name;
    if (file.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ctl00_ContentPlaceHolder1_gvFotos_ctl0' + row + '_imgProducto').attr('src', e.target.result);
        }
        reader.readAsDataURL(file.files[0]);
    }
}

function ValidacionesGeneral(e) {
    var FP = false;
    var Imagenes = false;
    var checkI = true;
    var msj = '';
    if (document.getElementById('txtNombre').value == '' || document.getElementById('txtNombre').value.length < 5) {
        msj += '*Ingrese un nombre válido. <br>'
    }
    if (document.getElementById('txtSKU').value == '' || document.getElementById('txtSKU').value.length != 9) {
        msj += '*Ingrese un SKU válido. <br>'
    }
    if (document.getElementById('ddlCategoria').value == '') {
        msj += '*Seleccione una categoria. <br>'
    }
    if (document.getElementById('ddlModelo').value == '') {
        msj += '*Seleccione un modelo. <br>'
    }
    if (document.getElementById('ddlMadera').value == '') {
        msj += '*Seleccione un tipo de madera. <br>'
    }
    if (document.getElementById('ddlColor').value == '') {
        msj += '*Seleccione un color. <br>'
    }
    if (document.getElementById('ddlTela').value == '') {
        msj += '*Seleccione una tela. <br>'
    }
    if (document.getElementById('txtCosto').value == '' || document.getElementById('txtCosto').value.length < 3 || document.getElementById('txtCosto').value == '0' || document.getElementById('txtCosto').value == '0.00') {
        msj += '*Ingrese un costo válido. <br>'
    }
    if (document.getElementById('txtPV').value == '' || document.getElementById('txtPV').value.length < 3 || document.getElementById('txtPV').value == '0' || document.getElementById('txtPV').value == '0.00') {
        msj += '*Ingrese un precio de venta válido. <br>'
    }
    if (parseFloat(document.getElementById('txtCosto').value) > parseFloat(document.getElementById('txtPV').value)) {
        msj += '*El precio de venta debe ser mayor al de costo. <br>'
    }
    if (document.getElementById('txtDimensiones').value == '' || document.getElementById('txtDimensiones').value.length < 8) {
        msj += '*Ingrese unas dimensiones válidas. <br>'
    }
    if (document.getElementById('txtPeso').value == '' || document.getElementById('txtPeso').value.length < 2 || document.getElementById('txtPeso').value.length == '0' || document.getElementById('txtPeso').value.length == '0.00') {
        msj += '*Ingrese un peso válido. <br>'
    }
    if (document.getElementById('txtDescripcion').value == '' || document.getElementById('txtDescripcion').value.length < 10) {
        msj += '*Ingrese una descripción válida. <br>'
    }
    if (document.getElementById('txtCaracteristicas').value == '' || document.getElementById('txtCaracteristicas').value.length < 10) {
        msj += '*Ingrese unas caracteristicas válidas. <br>'
    }
    if (document.getElementById('hdnRowsMaterial').value == '0') {
        msj += '*No ha ingresado ningun material. <br>'
    }
    for (var i = 2; i < 6; i++) {
        if (document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_chkPrincipal').checked) {
            FP = true;
        }
        if (document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_lblNombreFoto').innerHTML != '') {
            Imagenes = true;
        }
        if (document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_lblNombreFoto').innerHTML == '' && document.getElementById('ctl00_ContentPlaceHolder1_gvFotos_ctl0' + i + '_chkPrincipal').checked) {
            checkI = false;
        }
    }
    msj += Imagenes ? '' : '*No ha seleccionado ninguna foto. <br>';
    msj += FP ? '' : '*Ninguna foto la tiene como principal. <br>';
    msj += Imagenes ? (checkI ? '' : '*Ha seleccionado incorrectamente la foto principal. <br>') : '';
    if (msj != '') {
        Swal.fire({
            title: 'Hubo un Problema',
            html: msj,
            icon: 'warning',
            showConfirmButton: false,
            showCloseButton: true
        });
        e.preventDefault();
    }
    $.ajax({
        type: "post",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: '/Paginas/Metodos.aspx/ValidarProducto',
        data: '{"nombre":"' + document.getElementById('txtNombre').value + '", "categoria":"' + document.getElementById('ddlCategoria').value + '", "modelo":"' + document.getElementById('ddlModelo').value + '", "color":"' + document.getElementById('ddlColor').value + '" }',
        success: function (response) {
            if (response.d == "1") {
                Swal.fire({
                    title: 'Hubo un Problema',
                    html: '*Ya existe un producto con esos datos. <br>',
                    icon: 'warning',
                    showConfirmButton: false,
                    showCloseButton: true
                });
                e.preventDefault();
            }
        }
    });
}

function EliminarSesion() {
    $.ajax({
        type: "post",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: '/Paginas/Metodos.aspx/EliminarSesionProducto',
        success: function (response) {
            window.location.href = 'AdministrarProductos'
        }
    });
}

function UpdateCatalogo(idProducto, IB_Catalogo) {
    $.ajax({
        type: "post",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: '/Paginas/Metodos.aspx/UpdateCatalogo',
        data: '{"idproducto":"' + idProducto + '", "catalogo":"' + IB_Catalogo + '" }',
        success: function (response) {
            Swal.fire({
                title: response.d.includes('error') ? 'Hubo un problema' : 'Exito',
                showConfirmButton: false,
                showCloseButton: false,
                allowOutsideClick: false,
                allowEscapeKey: false,
                icon: response.d.includes('error') ? 'warning' : 'success',
                html: response.d + " <br> <a onclick='Redirect();' style='margin-top: 15px; cursor: pointer' class='btn btn-success'>OK</a>"
            });
        }
    });
}

function Redirect() {
    window.location.href = 'AdministrarProductos';
}