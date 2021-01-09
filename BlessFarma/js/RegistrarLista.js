var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
var SpeechGrammarList = SpeechGrammarList || webkitSpeechGrammarList;
var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent;

var btnRegistrarLista = document.querySelector('#RegistrarLista');

var listas = $('#ContentPlaceHolder1_ddlProducto option').map((index, option) => option.text);

btnRegistrarLista.addEventListener('click', registrarListaCompra);

function registrarListaCompra() {

    const speech = new SpeechSynthesisUtterance();
    var reconocimiento = new SpeechRecognition();

    reconocimiento.lang = 'es-PE';
    reconocimiento.interimResults = false;
    reconocimiento.maxAlternatives = 1;

    reconocimiento.start();

    reconocimiento.onresult = function (event) {

        var resultadoEscucha = event.results[0][0].transcript;

        if (resultadoEscucha != '') {
            console.log('correcto');
            console.log(resultadoEscucha);

            speech.text = '';

            for (var i = 0; i < listas.length; i++) {
                if ((listas[i].toLowerCase()).includes(resultadoEscucha.toLowerCase())) {
                    $('#ContentPlaceHolder1_ddlProducto').val(i);
                    $('#ContentPlaceHolder1_btnAgregarProducto').click();
                    return;
                }
                else {
                    speech.text = 'No se encuentra el Producto indicado.';
                }
            }

            if (resultadoEscucha.includes('registrar')) {
                $('#ContentPlaceHolder1_btnRegistrar').click();
            }

            speech.volume = 1;
            speech.rate = 1;
            speech.pitch = 1;
            window.speechSynthesis.speak(speech);
            console.log('Confidencial: ' + event.results[0][0].confidence);
        }
    }
}