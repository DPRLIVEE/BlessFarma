var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
var SpeechGrammarList = SpeechGrammarList || webkitSpeechGrammarList;
var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent;

var campoNom = document.querySelector('#texto');
var escuchaNom = document.querySelector('#micro');

escuchaNom.addEventListener('click', inicioNom);

function inicioNom() {

    const speech = new SpeechSynthesisUtterance();
    var reconocimiento = new SpeechRecognition();

    reconocimiento.lang = 'es-ES';
    reconocimiento.interimResults = false;
    reconocimiento.maxAlternatives = 1;

    reconocimiento.start();

    reconocimiento.onresult = function (event) {

        var resultadoEscucha = event.results[0][0].transcript;

        if (resultadoEscucha != '') {
            console.log('correcto');
            speech.text = '';
            campoNom.value = resultadoEscucha;
        }
        if (resultadoEscucha.includes('inicio')) {
            console.log('correcto');
            speech.text = 'Inicio';
            window.location = "../Principal/Principal.aspx";
        }


        if (resultadoEscucha.includes('lista de compras')) {
            console.log('correcto');
            speech.text = 'Lista de compras';
            window.location = "../ListaCompras/ListaCompras.aspx";
        }

        if (resultadoEscucha.includes('gestionar pedido')) {
            console.log('correcto');
            speech.text = 'Lista de compras';
            window.location = "../GestionarPedido/GestionarPedido.aspx";
        }
        if (resultadoEscucha.includes('gestionar merma')) {
            console.log('correcto');
            speech.text = 'Lista de compras';
            window.location = "../GestionarMerma/GestionarMerma.aspx";
        }

        if (resultadoEscucha.includes('salir')) {
            console.log('correcto');
            speech.text = 'Seleccione salir si desea terminar su sesión';
            $("#logoutModal").modal();
        }

        speech.volume = 1;
        speech.rate = 1;
        speech.pitch = 1;
        window.speechSynthesis.speak(speech);
        console.log('Confidencial: ' + event.results[0][0].confidence);
    }

}




