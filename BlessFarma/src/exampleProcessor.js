import 'core-js/shim';
import axios from 'axios';

import environmentVariables from './environmentVariables';

const getParams = (query) => {
    if (!query) {
        return { };
    }

    return (/^[?#]/.test(query) ? query.slice(1) : query)
        .split('&')
        .reduce((params, param) => {
            let [ key, value ] = param.split('=');
            params[key] = value ? decodeURIComponent(value.replace(/\+/g, ' ')) : '';
            return params;
        }, { });
};

const queryParams = getParams(window.location.search);

if (!queryParams.pageUrl) {
    throw new Error('Missing "pageUrl" query parameter');
}

function copyScript(scriptElement, dst) {
    return new Promise((resolve) => {
        const srcAttribute = scriptElement.getAttribute('src');
        if (!srcAttribute) {
            const newScriptElement = document.createElement('script');
            newScriptElement.innerHTML = scriptElement.innerHTML;
            dst.appendChild(newScriptElement);
            resolve();
        } else {
            const newScriptElement = document.createElement('script');
            newScriptElement.addEventListener('load', resolve);
            newScriptElement.setAttribute('src', srcAttribute);
            dst.appendChild(newScriptElement);
        }
    });
}

function copyScripts(scripts, dst) {
    if (!scripts || !scripts.length) {
        return Promise.resolve();
    }
    const script = scripts.shift();
    return copyScript(script, dst)
        .then(() => {
            return copyScripts(scripts, dst);
        });
}

function copyElements(src, dst) {
    const scripts = [];
    const links = [];

    Array.from(src.children)
        .forEach(childElement => {
            if (childElement.tagName.toLocaleLowerCase() === 'script') {
                scripts.push(childElement);
            } else if (childElement.tagName.toLocaleLowerCase() === 'link') {
                links.push(childElement);
            } else {
                dst.appendChild(childElement);
            }
        });

    return Promise.all([copyScripts(scripts, dst), copyLinks(links, dst)]);
}

function getBasePath() {
    return environmentVariables.basePath;
}

function replacePlaceholders(input) {
    return input.replace(new RegExp('basePath: \'/sdk', 'gm'), 'basePath: \'' + getBasePath());
}

function copyLinks(links, dst) {
    const promises = [];
    const copyLink = (element) => {
        return new Promise((resolve) => {
            const newLinkElement = document.createElement('link');
            newLinkElement.onload = resolve;
            newLinkElement.onerror = resolve;

            if (element.type) {
                newLinkElement.type = element.type;
            }
            if (element.rel) {
                newLinkElement.rel = element.rel;

            }
            if (element.href) {
                newLinkElement.href = element.href;
            }

            dst.appendChild(newLinkElement);
        });
    };

    links.forEach((link) => promises.push(copyLink(link)));
    return Promise.all(promises);
}

axios.get(queryParams.pageUrl)
    .then(response => {
        const data = response.data;
        const page = document.createElement('html');

        page.innerHTML = replacePlaceholders(data);

        const srcHead = page.getElementsByTagName('head')[0];
        const dstHead = document.getElementsByTagName('head')[0];
        const srcBody = page.getElementsByTagName('body')[0];
        const dstBody = document.getElementsByTagName('body')[0];

        return copyElements(srcHead, dstHead)
            .then(() => copyElements(srcBody, dstBody));
    });
