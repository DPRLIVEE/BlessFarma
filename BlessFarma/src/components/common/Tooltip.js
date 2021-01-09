import React from 'react';
import PropTypes from 'prop-types';

class Tooltip extends React.Component {

    static defaultProps = {
        position: 'bottom',
        className: ''
    };

    static propTypes = {
        text: PropTypes.string.isRequired,
        position: PropTypes.oneOf(['bottom', 'top', 'left', 'right']).isRequired,
        hidden: PropTypes.bool,
        children: PropTypes.object.isRequired,
        className: PropTypes.string
    }

    render() {
        return (
            <div
                className={`${!this.props.hidden ? `tooltip tooltip-${this.props.position}` : ''} ${this.props.className}`}
                data-tooltip={this.props.text}
            >
                {this.props.children}
            </div>
        );
    }
}

export default Tooltip;
