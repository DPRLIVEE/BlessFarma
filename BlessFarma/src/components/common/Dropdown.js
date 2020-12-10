import React from 'react';
import PropTypes from 'prop-types';

class Dropdown extends React.Component {

    static propTypes = {
        name: PropTypes.string.isRequired,
        selected: PropTypes.bool,
        children: PropTypes.oneOfType([
            PropTypes.array,
            PropTypes.object
        ]).isRequired
    }

    render() {
        return (
            <div className='ely-dropdown-container'>
                <div className={`ely-dropdown ${this.props.selected ? 'selected' : ''}`}>
                    <div className='text'>{this.props.name}</div>
                    <ul>
                        {this.props.children}
                    </ul>
                </div>
            </div>
        );
    }
}

export class DropdownItem extends React.Component {

    static propTypes = {
        name: PropTypes.string.isRequired,
        onClick: PropTypes.func.isRequired
    }

    render() {
        return (
            <li onClick={this.props.onClick}>{this.props.name}</li>
        );
    }
}

export default Dropdown;
