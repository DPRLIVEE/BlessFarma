import axios from 'axios';
import environmentVariables from '../environmentVariables';
import ApiKeys from 'api-keys';

class CodeSnippetPrinter {

    constructor(text) {
        this.snippets = {
            start: /^\s*\/\/\s*tomtom-snippet-start\s*$/mi,
            end: /^\s*\/\/\s*tomtom-snippet-end\s*$/mi
        };
        this.text = text;
    }

    static concatenateIfNeeded(text) {
        return text.replace(/\/\/\s*tomtom-snippet-end\s*\/\/\s*tomtom-snippet-start/gmi, '');
    }

    static stripLeadingSpaces(text) {
        let leadingSpaceCount;
        let code = text.replace(/^\s*$[\n\r]{0,2}/gm, '');
        leadingSpaceCount = code.search(/\S|$/);
        code = code.replace(new RegExp('^\\s{' + leadingSpaceCount + '}', 'gm'), '');
        return code;
    }

    hasSnippets() {
        return this.snippets.start.test(this.text);
    }

    reduceSnippets(acc, line) {
        if (this.snippets.start.test(line)) {
            acc.snippet = true;
        } else if (this.snippets.end.test(line)) {
            acc.snippet = false;
            acc.code.push([]);
        } else if (acc.snippet) {
            acc.code[acc.code.length - 1].push(line);
        }
        return acc;
    }

    extractSnippets() {
        return CodeSnippetPrinter.stripLeadingSpaces(CodeSnippetPrinter.concatenateIfNeeded(this.text)
            .split('\n')
            .reduce(this.reduceSnippets.bind(this), {code: [[]], snippet: false})
            .code
            .filter(function(block) {
                return block.length;
            })
            .map(function(block) {
                return block.join('\n');
            })
            .join('\n// ...\n'));
    }

    getScriptCode() {
        const scriptRegExpGlobal = /<script>((?:.|\s)*?)<\/script>/gm;
        const scriptRegExp = /<script>((?:.|\s)*?)<\/script>/;
        const code =
            this.text.match(scriptRegExpGlobal).reduce(((acc, script) => acc + script.match(scriptRegExp)[1]), '');
        return CodeSnippetPrinter.stripLeadingSpaces(code);
    }

    getCommonScriptsUrls() {
        const scriptRegExpGlobal = /<script data-showable((?:.|\s)*?)<\/script>/g;
        let commonScripts = this.text.match(scriptRegExpGlobal) || [];
        commonScripts = commonScripts.map((commonScript) => {
            const scriptElem = new DOMParser().parseFromString(commonScript, "text/html");
            return environmentVariables.publicUrl + scriptElem.getElementsByTagName('html')[0].getElementsByTagName('script')[0].attributes.src.textContent.substr(2);
        });
        return commonScripts;
    }

    print() {
        if (this.hasSnippets()) {
            return this.extractSnippets();
        } else {
            return this.getScriptCode();
        }
    }
}

function replacePlaceholders(input) {
    return input.replace(new RegExp(ApiKeys.MAP, 'gm'), '<your-tomtom-API-key>')
        .replace(new RegExp(ApiKeys.TRAFFIC_INCIDENTS, 'gm'), '<your-tomtom-traffic-API-key>')
        .replace(new RegExp(ApiKeys.TRAFFIC_FLOW, 'gm'), '<your-tomtom-traffic-flow-API-key>')
        .replace(new RegExp(ApiKeys.SEARCH, 'gm'), '<your-tomtom-search-API-key>')
        .replace(new RegExp(ApiKeys.ROUTING, 'gm'), '<your-tomtom-routing-API-key>')
        .replace(new RegExp('basePath: \'/sdk', 'gm'), 'basePath: \'<your-tomtom-sdk-base-path>');
}

function removeDevData(data) {
    return data.replace(/\sdata-showable/g, '');
}

export function extractSnippets(pageUrl) {
    return axios.get(pageUrl)
        .then((response) => {
            const data = replacePlaceholders(response.data);
            const scriptSnippetPrinter = new CodeSnippetPrinter(data);
            const commonScriptsUrls = scriptSnippetPrinter.getCommonScriptsUrls();

            return Promise.all(commonScriptsUrls.map((url) => {

                return axios.get(url).then(commonScriptCode => {
                    return {
                        name: url.substring(url.lastIndexOf('/') + 1),
                        code: replacePlaceholders(commonScriptCode.data)
                    };
                });
            })).then((commonScriptsCode) => {
                return {
                    html: removeDevData(data),
                    code: scriptSnippetPrinter.getScriptCode(),
                    commonScriptsCode
                };
            });
        });
}

export default {
    extractSnippets
};
