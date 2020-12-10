
import 'core-js/shim';
import React from 'react';
import ReactDOM from 'react-dom';
import 'iframe-resizer/js/iframeResizer.contentWindow';
import App from './App';
import './styles/critical.css';
import './styles/index.css';
import './pages/examples/styles/main.css';
import './pages/examples/styles/search-markers.css';

ReactDOM.render(<App />, document.getElementById('root'));
