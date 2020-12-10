import React from 'react';
import Snippets from './Snippets';
import { Route, Switch } from 'react-router-dom';
import environmentVariables from '../../environmentVariables';

class Defered extends React.Component {
    constructor() {
        super();

        this.state = {
            shouldRender: false
        };

    }

    componentDidMount() {
        this.timeout = window.setTimeout(this.shouldRender, this.props.timeout);
    }

    componentWillUnmount() {
        window.clearTimeout(this.timeout);
    }

    shouldRender = () => {
        this.setState({
            shouldRender: true
        });
    }


    render() {
        if (this.state.shouldRender) {
            return this.props.children;
        }

        return null;
    }
}

export default class Example extends React.Component {
    constructor() {
        super();

        this.iframeRef = React.createRef();
    }

    componentDidUpdate(prevProps) {
        if (this.props.match.params.example !== prevProps.match.params.example) {
            this.setIframeSrc();
        }
    }

    getExamplesUrl = (match) => {
        return `${environmentVariables.publicUrl}/pages/index.html?pageUrl=examples/html/${encodeURIComponent(match.params.example)}`;
    };

    setIframeSrc = () => {
        if (this.iframeRef.current) {
            const url = this.getExamplesUrl(this.props.match);
            this.iframeRef.current.contentWindow.location.replace(url);
        }
    };
    render() {
        if (!this.props.snippets) {
            return <Defered timeout={200}><div>Loading...</div></Defered>;
        }

        return (
            <Switch>
                <Route exact path="/examples/map/:example" render={
                    ({match}) => {
                        const srcProp = {
                            src: this.iframeRef.current ? this.iframeRef.current.getAttribute('src') : this.getExamplesUrl(match)
                        };

                        return (
                            <iframe
                                {...srcProp}
                                ref={this.iframeRef}
                                className="map-iframe"
                                title="map"
                                sandbox="allow-same-origin allow-scripts allow-popups allow-forms"
                                allowFullScreen="true">
                            </iframe>
                        );
                    }
                }/>

                <Route exact path="/examples/description/:example" render={
                    () => <div className="description">{this.props.description}</div>
                }/>

                <Route exact path="/examples/code/:example" render={
                    () => <Snippets snippets={this.props.snippets}/>
                }/>
            </Switch>
        );
    }
}
