import React from 'react';
import PropTypes from 'prop-types';
import isEqual from 'lodash.isequal';

import Modal from '../common/Modal';
import { API_KEYS, API_KEY_LOCALSTORAGE } from '../../config';
import environmentVariables from '../../environmentVariables';

import { getJavascriptCodeForCodepen, extractCodePenSnippets } from '../../code-extractor/codePenExtractor';

const detectRequiredApiKeys = (code) => {
    return API_KEYS.filter(function(item) {
        return code.includes(item.placeholder);
    });
};

class CodePenModal extends React.Component {

    static propTypes = {
        open: PropTypes.bool.isRequired,
        close: PropTypes.func.isRequired,
        snippets: PropTypes.object.isRequired,
        exampleName: PropTypes.string.isRequired
    };

    constructor(props) {
        super(props);

        this.state = this._getInitialOptions();
    }

    componentDidUpdate(prevProps) {
        if (!isEqual(this.props, prevProps)) {
            this.setState(this._getInitialOptions);
        }
    }

    _getInitialOptions = () => {
        const codePenOptions = {
            title: `Example: ${this.props.exampleName}`,
            layout: 'left'
        };

        let storedKeys = localStorage[API_KEY_LOCALSTORAGE];
        storedKeys = storedKeys ? JSON.parse(storedKeys) : {};
        const codePenSnippets = extractCodePenSnippets(this.props.snippets.html, this.props.snippets.code, storedKeys);

        return {
            requiredApiKeys: detectRequiredApiKeys(this.props.snippets.code),
            codePenOptions: Object.assign({}, codePenOptions, codePenSnippets),
            userKeys: storedKeys
        };
    }

    _updateJs = (e) => {
        const newKey = {};
        newKey[e.target.name] = e.target.value.replace(/[^\w\s]/gi, ''); //removes all special characters
        const userKeys = Object.assign({}, this.state.userKeys, newKey);
        const js = getJavascriptCodeForCodepen(this.props.snippets.code, userKeys);
        const codePenOptions = Object.assign({}, this.state.codePenOptions, { js });

        this.setState({
            codePenOptions,
            userKeys
        });
    }

    _onSubmitForm = () => {
        localStorage.setItem(API_KEY_LOCALSTORAGE, JSON.stringify(this.state.userKeys));
        this.props.close();
    }

    _renderApiKeyInputs = () => {
        return this.state.requiredApiKeys.map((keyObj) => {

            return (
                <div className="modal-row" id="api-key" key={keyObj.name}>
                    <input
                        name={keyObj.name}
                        onChange={this._updateJs}
                        value={this.state.userKeys[keyObj.name] || ''}
                    />
                    <label>{keyObj.label}</label>
                </div>
            );
        });
    }

    render() {
        //Do not render CodePen button when not needed
        if(environmentVariables.hideCodePen) {
            return null;
        }

        return (
            <Modal open={this.props.open}>
                <form
                    className="form-horizontal"
                    action="https://codepen.io/pen/define"
                    method="POST"
                    target="_blank"
                    onSubmit={this._onSubmitForm}
                >
                    <div className="modal-header">
                        <strong>Please provide API keys.</strong>
                    </div>
                    <div className="modal-body">
                        <span>If you don't have them yet follow this steps:</span>
                        <ul>
                            <li>
                                <a
                                    href="https://developer.tomtom.com/user/register">
                                    Register
                                </a>
                                &nbsp;/&nbsp;
                                <a
                                    href="https://developer.tomtom.com/user/login">
                                    Sign in
                                </a>
                                &nbsp;to TomTom Developer Portal.
                            </li>
                            <li>
                                <a target='blank' href="https://developer.tomtom.com/user/me/apps">
                                    Request an evaluation API key
                                </a>&nbsp;to access the service you want to use the SDK with.
                            </li>
                        </ul>
                        <span>
                            If you added all services to one application use the same api key in every input field.
                        </span>
                        {this._renderApiKeyInputs()}
                        <input type="hidden" name="data" value={JSON.stringify(this.state.codePenOptions)} />
                    </div>

                    <div className="modal-footer">
                        <small>
                            Clicking the "Open in CodePen" button will cause an external editor (CodePen) to be opened with your API key(s).
                            TomTom is not responsible for this 3rd party site.
                        </small>
                        <button
                            type="button"
                            className="button -secondary"
                            onClick={this.props.close}
                        >
                            Close
                        </button>
                        <button
                            type="submit"
                            className="button"
                        >
                            Open in CodePen
                        </button>
                    </div>
                </form>
            </Modal>
        );
    }
}

export default CodePenModal;
