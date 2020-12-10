$(function () {
    $('.popUpMensaje').on('hide.bs.modal', function () {
        //window.location.href = 'AprobarSolicitud';
        window.location.href = $('#hdnurl').val();
    });

    $('.popUpLogOut').on('hide.bs.modal', function () {
        //window.location.href = 'AprobarSolicitud';
        window.location.href = "login";
    });
});

function verMensaje(msj) {
    $('.lblMensaje').html(msj);
    $('.popUpMensaje').modal('show');
}

function verAlertaLogOut(msj) {
    $('.popUpLogOut').modal('show');
}

function verAlerta(msj) {
    $('.lblMensajeAlerta').html(msj);
    $('.popAlerta').modal('show');
}

function IrAlBoton(btn) {
    var btnName = $('#' + btn).attr("name");
    __doPostBack(btnName, "");
}

function showTooltip() {
    $('.tooltip-show').tooltip();
}

//Validaciones de caracteres
function SoloNumeroDec(ev) {    
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0 || tecla==46) return true;
    //var regEx = /((\d+)+(\.\d+))|(^[0-9]+)$/i;
    //var regEx = /^\d+(\.\d{1,2})?$/i;//solo int
    var regEx = /^[0-9]+$/i;
    return regEx.test(String.fromCharCode(ev.which));    //tecla
}

function SoloNumeroInt(ev) {
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0) return true;
    if (tecla >= 8226 && tecla <= 10175) { return false; }
    var regEx = /^[0-9]+$/i;
    return regEx.test(String.fromCharCode(tecla));
}

function LetrasInt(ev) {
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0) return true;
    var regEx = /^[a-zA-Z]+$/;
    return regEx.test(String.fromCharCode(tecla));
}

function InvalidSimbols(str) {
    var iChars = "~`!#$%^&*+=[]\\\´'{}|\"<>?"; //var iChars = "~`!#$%^&*+=-[]\\\';,/{}|\":<>?";
    for (var i = 0; i < str.length; i++) {
        if (iChars.indexOf(str.charAt(i)) != -1) {
            alert("Estos caracteres no están permitidos ~`!#$%^&*+=-[]\\\';/{}|\":<>? \n");
            return false;
        }
    }
    return true;
}

function CorreoInt(str) {
    //var regEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/;
    var regEx = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*/;
    if (!regEx.test(str)) {
        alert("Formato incorrecto de correo.");
        return false;
    }
}

function BlockChars(ev) {
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0) return true;
    if (tecla >= 8226 && tecla <= 10175) { return false; } //BlockAltCtrl
    var regEx = /[\~`!#$%^&§¥£│øƒ×®¿¬¡©¢┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▬¦▬▀­­­±­¶@_*\+\=\\[\]\\\´'\{}|\":<>?()]/;
    return !regEx.test(String.fromCharCode(tecla));
}

function BlockSomeChars(ev) {
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0) return true;
    if (tecla >= 8226 && tecla <= 10175) { return false; } //BlockAltCtrl
    var regEx = /[\~`!#$%^&§¥£│øƒ×®¿¬¡©¢┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▬¦▬▀­­­±­¶@_*\+\=\\[\]\\\´'\{}|\":<>?]/;//()
    return !regEx.test(String.fromCharCode(tecla));
}

function BlockIntChar(ev) {
    var tecla = (document.all) ? ev.keyCode : ev.which;
    if (tecla == 8 || tecla == 13 || tecla == 0) return true;
    if (tecla >= 8226 && tecla <= 10175) { return false; }
    if (tecla >= 48 && tecla <= 57) { return false; }
    var regEx = /[\~`!#$%^&§¥£│øƒ×®¿¬¡©¢┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▬¦▬▀­­­±­¶@_*\+\=\\[\]\\\´'\{}|\"<>?()]/;
    return !regEx.test(String.fromCharCode(tecla));
}
(function ($) {
    function MenuDropdown(object, options) {
        $menudropdown = this;
        this.$element = $(object);
        this.$ulPrincipal = $(this.$element.children("ul"));
        this.$subMenus = $(this.$ulPrincipal.find("ul.sub-menu"));
        this.$selectsToSubMenus = $(this.$subMenus.siblings("a"));
        this.$selectsToMenus = this.$ulPrincipal.find("li > a").not(this.$selectsToSubMenus);
        this.$select = $(null);
        this.$previousActive = null;
        this._defaults = {
            activeMenuSelector: "a.active",
            iconSubMenuPat: "fa-angle-down",
            typeDeploy: "Default",  // Default | HiddenSiblings
            ViewDefaultSubMenus: "Visible" // Visible | Hidden 
        }
        this.$ulPrincipal.addClass("ep-menu-dropdown");
        $.extend(this._defaults, options);
        this.$selectsToSubMenus.css("position", "relative")
                               .append("<i class='icon-submenu'>\n\
                                        <i class='fa " + this._defaults.iconSubMenuPat + "'></i>\n\
                                        </span>");

        //SubMenus por Defecto
        switch (this._defaults.ViewDefaultSubMenus) {
            case "Hidden": this.$subMenus.hide(); break;
            default: this.$subMenus.show(); break; //Visible
        }

        this.$selectsToSubMenus.on('click', this.deployMenuSelect);
        this.assignActive();
    }

    MenuDropdown.prototype.deployMenuSelect = function (select) {
        $menudropdown.$select = $(select.currentTarget || select || null);
        var $selectLi = $menudropdown.$select.parent("li");

        switch ($menudropdown._defaults.typeDeploy) {
            case "HiddenSiblings": $selectLi.siblings("li").removeClass("in")
                                   .children("ul.sub-menu")
                                   .slideUp(); break;
        }

        $menudropdown.$select.siblings("ul.sub-menu")
                             .stop()
                             .slideToggle(400, function () {
                                 if ($(this).is(":visible"))
                                     $selectLi.addClass("in");
                                 else
                                     $selectLi.removeClass("in");
                             });
    }

    MenuDropdown.prototype.setOptions = function (options) {
        $.extend(this._defaults, options || {});
        return this;
    }

    MenuDropdown.prototype.assignActive = function () {
        var pathname = $(location).attr("pathname");
        try {
            this.$ulPrincipal.find("a").each(function () {
                if (pathname == $(this)[0].pathname)
                {
                    $menudropdown._defaults.activeMenuSelector = this;
                    return false;
                }
            });
        }
        catch (e) {
        };

        var $active = $(this._defaults.activeMenuSelector);
        this.$ulPrincipal.find("li").removeClass("li-active")
                         .find("a.active").removeClass("active");

        $active.addClass("active").parentsUntil(this.$ulPrincipal, "li")
                                  .addClass("li-active")
                                  .parent("ul.sub-menu").show();
        this.$previousActive = $active.hasClass("active") ? $active : null;
    }

    function Plugin(options) {
        return this.each(function () {
            var $this = $(this)
            var data = $this.data('menu')
            if (!data) $this.data('menu', (data = new MenuDropdown(this, options)))
        })
    }
    var old = $.fn.MenuDropdown
    $.fn.MenuDropdown = Plugin
    $.fn.MenuDropdown.noConflict = function () {
        $.fn.MenuDropdown = old
        return this
    }
})(jQuery);
