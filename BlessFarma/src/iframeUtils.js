
function sendMessageToParent(msg) {
    // The global parentIFrame is created by the iframeResizer lib.
    // Method documented at https://github.com/davidjbradshaw/iframe-resizer#sendmessagemessagetargetorigin
    window.parentIFrame.sendMessage(msg, '*');
}

function isIFramed() {
    try {
        return window.self !== window.top;
    } catch (e) {
        return true;
    }
}

export {
    sendMessageToParent,
    isIFramed
};
