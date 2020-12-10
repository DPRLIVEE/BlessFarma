import React from 'react';
import PropTypes from 'prop-types';

class Button extends React.Component {

    static propTypes = {
        name: PropTypes.string.isRequired,
        onClick: PropTypes.func.isRequired,
        selected: PropTypes.bool
    }

    render() {
        return (
            <div className='ely-button-container' onClick={this.props.onClick}>
                <div className={`ely-button ${this.props.selected ? 'selected' : ''}`}>
                    <div className='text'>{this.props.name}</div>
                </div>
            </div>
        );
    }
}

export default Button;
