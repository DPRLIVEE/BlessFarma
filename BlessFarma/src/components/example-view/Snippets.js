import React from 'react';
import Clipboard from 'clipboard';
import Prism from 'prismjs';
import 'prismjs/plugins/normalize-whitespace/prism-normalize-whitespace';
import 'prismjs/plugins/line-numbers/prism-line-numbers';
import Dropdown, {DropdownItem} from '../common/Dropdown';
import Button from '../common/Button';

export default class Snippets extends React.Component {

    constructor() {
        super();
        this.state = {
            selected: 'html'
        };
    }

    componentDidUpdate(prevProps) {
        const nextProps = this.props;

        if (prevProps.snippets && nextProps.snippets && prevProps.snippets.code !== nextProps.snippets.code) {
            Prism.highlightAll();
            new Clipboard('.clipboard-btn');
        }
    }

    componentDidMount() {
        Prism.highlightAll();
        new Clipboard('.clipboard-btn');
    }

    _getCustomScript = () => {
        const script = this.props.snippets.commonScriptsCode.find(script => script.name === this.state.selected);
        return script.code;
    }

    _onClick = (selectedScript) => {
        this.setState({
            selected: selectedScript
        }, () => Prism.highlightAll());
    }

    _renderScriptMenuItem = () => {
        const { selected } = this.state;
        const { commonScriptsCode } = this.props.snippets;

        if (commonScriptsCode.length) {
            return <Dropdown
                name={selected === 'js' || selected === 'html' ? 'Javascript' : this.state.selected}
                selected={selected !== 'html'}
            >
                <DropdownItem name='Javascript' onClick={() => this._onClick('js')} />
                {commonScriptsCode.map(jsScript =>
                    <DropdownItem key={jsScript.name} name={jsScript.name} onClick={() => this._onClick(jsScript.name)} />
                )}
            </Dropdown>;
        }

        return <Button
            name='Javascript'
            onClick={() => this._onClick('js')}
            selected={selected !== 'html'}
        />;
    }

    _renderScript = () => {
        const { selected } = this.state;
        const { snippets } = this.props;

        if (selected === 'html') {
            return <pre className='prettyprint lang-html line-numbers'>
                <code id='snippet-selected' className='language-html'>{snippets.html}</code>
            </pre>;
        }

        return <pre className='prettyprint lang-js line-numbers'>
            <code id='snippet-selected' className='language-js'>
                {selected === 'js' ? snippets.code : this._getCustomScript()}
            </code>
        </pre>;
    }

    render() {
        return (
            <div className='snippets'>
                <div className='code-menu'>
                    <Button
                        name='HTML + Javascript'
                        onClick={() => this._onClick('html')}
                        selected={this.state.selected === 'html'}
                    />
                    {this._renderScriptMenuItem()}
                </div>

                <div className='snippet'>
                    <div className='snippet__content'>
                        {this._renderScript()}
                    </div>
                    <button className='clipboard-btn button' data-clipboard-target='#snippet-selected'>
                        Copy to clipboard
                    </button>
                </div>
            </div>
        );
    }
}
