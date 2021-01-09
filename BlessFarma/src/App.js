import React, { Component } from 'react';
import { HashRouter as Router, Route } from 'react-router-dom';

import RouteableApp from './RouteableApp';

class App extends Component {

    render() {
        return (
            <Router>
                <Route component={RouteableApp} />
            </Router>
        );
    }
}

export default App;
