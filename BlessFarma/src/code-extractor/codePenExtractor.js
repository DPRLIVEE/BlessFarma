import environmentVariables from '../environmentVariables';

function getBodyHTML(html) {
    const bodyReg = /<body.*>((?:.|\s)*?)<\/body>/gm;
    //extract everything from body tag
    let bodyMatch = html.match(bodyReg)[0];
    //remove plain scripts except template scripts
    bodyMatch = bodyMatch.replace(/<script.*?>(.|\s)*?<\/script>/gm, '');
    return bodyMatch;
}

const isLocalhost = window.location.hostname === 'localhost';

export function getJavascriptCodeForCodepen(code, keys) {
    function getKey(key) {
        return keys[key] || '';
    }

    const generatedCode = code
        .replace(/<your-tomtom-API-key>/g, getKey('api.key'))
        .replace(/<your-tomtom-traffic-API-key>/g, getKey('api.key.traffic'))
        .replace(/<your-tomtom-traffic-flow-API-key>/g, getKey('api.key.trafficFlow'))
        .replace(/<your-tomtom-search-API-key>/g, getKey('api.key.search'))
        .replace(/<your-tomtom-routing-API-key>/g, getKey('api.key.routing'))
        .replace(/<your-product-version>/g, '${analytics.productVersion}')
        .replace(/<your-product-name>/g, 'Codepen Examples')
        .replace(/<your-tomtom-sdk-base-path>/g, isLocalhost ? `${window.location.origin}/sdk` :
            `${environmentVariables.sdkPath}/${environmentVariables.sdkVersion}/examples/sdk`);
    return generatedCode;
}

function extractStyle(parsedDOM) {
    const styleElems = Array.from(parsedDOM.getElementsByTagName('style'));

    const style = styleElems.reduce((styles, elem) => {
        return styles + elem.innerHTML;
    }, '');

    return `
        ${style}
        html {
            height:100%;
        }`;
}

const catalogUpRegex = /^\.\.\//;

function getExternalJsForCodepen(parsedDOM) {
    const scriptElems = Array.from(parsedDOM.querySelectorAll('script[src]'));

    return scriptElems.map((elem) => {
        if (!isLocalhost) {
            elem.setAttribute('src', elem.getAttribute('src').replace(catalogUpRegex, ''));
        }

        return elem.src;
    }).join(';');
}

function getExternalCssForCodepen(parsedDOM) {
    const cssElems = Array.from(parsedDOM.querySelectorAll('link[rel=\'stylesheet\']'));

    return cssElems.map((elem) => {
        const href = elem.getAttribute('href');
        if (!isLocalhost && href.startsWith('../')) {
            elem.setAttribute('href', href.replace(catalogUpRegex, ''));

            return elem.href;
        } else if (!href.startsWith('../')) {
            const url = document.createElement('a');
            url.setAttribute('href', `pages/${elem.getAttribute('href')}`);

            return url.href;
        }

        return elem.href;
    }).join(';');
}

export function extractCodePenSnippets(html, scriptCode, keys) {
    const parser = new DOMParser();
    const parsedDOM = parser.parseFromString(html, 'text/html');

    return {
        html: getBodyHTML(html),
        js: getJavascriptCodeForCodepen(scriptCode, keys),
        css: extractStyle(parsedDOM),
        js_external: getExternalJsForCodepen(parsedDOM),  //eslint-disable-line
        css_external: getExternalCssForCodepen(parsedDOM) //eslint-disable-line
    };
}
