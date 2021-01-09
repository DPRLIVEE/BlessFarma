import React from 'react';
import PropTypes from 'prop-types';
import { isIFramed } from '../../iframeUtils';

const devPortalHost = 'https://developer.tomtom.com/maps-sdk-web-js/functional-examples';

class Link extends React.Component {

    static propTypes = {
        hash: PropTypes.string.isRequired,
        className: PropTypes.string,
        routeActiveClass: PropTypes.string,
        children: PropTypes.oneOfType([
            PropTypes.array,
            PropTypes.object,
            PropTypes.string
        ]).isRequired,
        onClick: PropTypes.func
    }

    _onLinkClick = (e, hash) => {
        e.preventDefault();
        window.location.hash = hash;

        if (this.props.onClick) {
            this.props.onClick(e);
        }
    }

    _getActiveRouteClass = hash => window.location.hash.includes(hash) && this.props.routeActiveClass ? this.props.routeActiveClass : '';

    render() {
        const { hash, className = '' } = this.props;

        const location = isIFramed() ? devPortalHost + '#' : '/#/';

        return (
            <a
                href={location + hash}
                className={`${className} ${this._getActiveRouteClass(hash)}`}
                onClick={e => this._onLinkClick(e, hash)}
            >
                {this.props.children}
            </a>
        );
    }
}

export default Link;
