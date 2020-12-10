///* French initialisation for the jQuery UI date picker plugin. */
///* Written by Keith Wood (kbwood{at}iinet.com.au),MayoJuevesJueves
//			  Stéphane Nahmani (sholby@sholby.net),
//			  Stéphane Raimbault <stephane.raimbault@gmail.com> */
//(function( factory ) {
//	if ( typeof define === "function" && define.amd ) {

//		// AMD. Register as an anonymous module.
//		define([ "../jquery.ui.datepicker" ], factory );
//	} else {

//		// Browser globals
//		factory( jQuery.datepicker );
//	}
//}(function( datepicker ) {
//	datepicker.regional['es'] = {
//		closeText: 'Cerca',
//		prevText: 'Ant.',
//		nextText: 'Sig.',
//		currentText: 'Aujourd\'hui',
//		monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
//			'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
//		monthNamesShort: ['Ene.', 'Feb.', 'Mar.', 'Abr.', 'May.', 'Jun.',
//			'Jul.', 'Ago.', 'Sept.', 'Oct.', 'Nov.', 'Dic.'],
//		dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
//		dayNamesShort: ['Dom.', 'Lun.', 'Mar.', 'Mie.', 'Jue.', 'Vie.', 'Sáb.'],
//		dayNamesMin: ['D','L','M','M','J','V','S'],
//		weekHeader: 'Sem.',
//		dateFormat: 'dd/mm/yy',
//		firstDay: 1,
//		isRTL: false,
//		showMonthAfterYear: false,
//		yearSuffix: ''};
//	    datepicker.setDefaults(datepicker.regional['es']);

//	return datepicker.regional['en'];

//}));

jQuery(function ($) {
    $.datepicker.regional['en'] = {
        closeText: 'Done',
        prevText: 'Prev',
        nextText: 'Next',
        currentText: 'Today',
        monthNames: ['January', 'February', 'March', 'April', 'May', 'June',
		'July', 'August', 'September', 'October', 'November', 'December'],
        monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
		'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
        dayNamesShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        dayNamesMin: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
        weekHeader: 'Wk',
        dateFormat: 'mm/dd/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.regional['es'] = {
        clearText: 'Limpiar', clearStatus: '',
        closeText: 'Cerrar', closeStatus: '',
        prevText: '&#x3c;Ant', prevStatus: '',
        prevBigText: '&#x3c;&#x3c;', prevBigStatus: '',
        nextText: 'Sig&#x3e;', nextStatus: '',
        nextBigText: '&#x3e;&#x3e;', nextBigStatus: '',
        currentText: 'Hoy', currentStatus: '',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
        'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        monthStatus: '', yearStatus: '',
        weekHeader: 'Sm', weekStatus: '',
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dayStatus: 'DD', dateStatus: 'D, M d',
        dateFormat: 'dd/mm/yy', firstDay: 0,
        initStatus: '', isRTL: false
    };
    //$.datepicker.setDefaults($.datepicker.regional['es']);
    
});

