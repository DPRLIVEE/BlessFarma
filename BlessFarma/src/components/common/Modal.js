import React from 'react';
import PropTypes from 'prop-types';

class Modal extends React.Component {

    static propTypes = {
        open: PropTypes.bool.isRequired,
        children: PropTypes.object.isRequired
    }

    render() {
        return (
            <div id="modal" className={`modal fade ${this.props.open ? 'in open' : ''}`}>
                <div className="modal-dialog">
                    <div className="modal-content">
                        {this.props.children}
                    </div>
                </div>
            </div>
        );
    }
}

export default Modal;
