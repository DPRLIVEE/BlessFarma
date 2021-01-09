import React, { Component } from 'react';
import { Route, Redirect, Switch } from 'react-router-dom';

import ExampleView from './components/example-view/ExampleView';
import { sendMessageToParent, isIFramed } from './iframeUtils';

const defaultExample = 'vector-map.html';

export default class RouteableApp extends Component {
    constructor(props) {
        super(props);
    }

    componentDidUpdate = (prevProps) => {
        if (this.props.location.pathname !== prevProps.location.pathname && isIFramed()) {
            sendMessageToParent({
                type: 'hashChanged',
                hash: this.props.location.pathname
            });
        }
    };

    render = () => {
        return (
            <Switch>
                <Route
                    path="/examples/:viewType/:example"
                    render={(props) =>
                        <ExampleView {...props} />}/>
                <Redirect
                    exact from='/' to={`/examples/map/${defaultExample}`}/>
            </Switch>
        );
    }
}
