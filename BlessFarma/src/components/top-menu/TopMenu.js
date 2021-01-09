import React, { Component } from 'react';
import classNames from 'classnames';
import HashLink from '../common/HashLink';

import CodepenIcon from '../../assets/icons/ic_codepen.svg';
import DescriptionIcon from '../../assets/icons/ic_description.svg';
import CodeIcon from '../../assets/icons/ic_code.svg';
import MapIcon from '../../assets/icons/ic_map.svg';
import MoreIcon from '../../assets/icons/ic_more.svg';
import environmentVariables from '../../environmentVariables';
import Tooltip from '../common/Tooltip';

import { isMobile } from '../../utils';

class TopMenu extends Component {
    constructor(props) {
        super(props);

        this.navRef = React.createRef();
        this.moreButtonRef = React.createRef();

        this.state = {
            isHovered: false
        };
    }

    componentDidMount() {
        document.addEventListener('click', this.handleOutsideClick, false);
        window.addEventListener('blur', this.handleIframeClick, false);
    }

    componentWillUnmount() {
        document.removeEventListener('click', this.handleOutsideClick, false);
        window.removeEventListener('blur', this.handleIframeClick, false);
    }

    handleOutsideClick = (e) => {
        // ignore clicks on the component itself
        if (this.navRef.current.contains(e.target) ||
            this.moreButtonRef.current.contains(e.target) ||
            !this.props.isOptionsMenuVisible) {
            return;
        }
        this.props.toggleOptionsMenu();
    }

    handleIframeClick = (e) => {
        // same hack as in sideMenu.js
        if (e.target && e.target[0] && e.target[0].document.title === 'TTIframe' && this.props.isOptionsMenuVisible) {
            this.props.toggleOptionsMenu();
        }
    }

    toggleHover = (isHovered) => {
        this.setState({
            isHovered: isHovered
        });
    }

    render() {
        const {
            exampleFilename,
            category,
            exampleName,
            isSideMenuVisible,
            isOptionsMenuVisible,
            toggleCodePenModal,
            toggleSideMenu,
            toggleOptionsMenu,
            isAdvanced
        } = this.props;

        const { isHovered } = this.state;

        const hamburgerClassName = classNames('hamburger', {
            '-active': isSideMenuVisible || isHovered
        });

        const mapHash = `examples/map/${exampleFilename}`;
        const descriptionHash = `examples/description/${exampleFilename}`;
        const codeHash = `examples/code/${exampleFilename}`;

        return (
            <div className={`top-menu ${isMobile() ? '-is-mobile' : ''}`}>
                <header className="top-menu__header">
                    <div className="top-menu__headline">
                        <button
                            className={hamburgerClassName}
                            onClick={toggleSideMenu}
                            onMouseEnter={this.toggleHover.bind(this, true)}
                            onMouseLeave={this.toggleHover.bind(this, false)}>
                            <span className="hamburger__inner"></span>
                        </button>
                        <h3
                            className={isHovered || isSideMenuVisible ? '-hovered' : ''}
                            onClick={toggleSideMenu}
                            onMouseEnter={this.toggleHover.bind(this, true)}
                            onMouseLeave={this.toggleHover.bind(this, false)}>
                                Examples
                        </h3>
                    </div>
                    <div
                        className='top-menu__breadcrumbs'
                        onMouseEnter={this.toggleHover.bind(this, true)}
                        onMouseLeave={this.toggleHover.bind(this, false)}
                        onClick={toggleSideMenu}>
                        {category} / {exampleName}
                    </div>
                </header>
                <div
                    className={`top-menu__button -more-button -small-screen ${isOptionsMenuVisible ? '-active' : ''}`}
                    onClick={toggleOptionsMenu}
                    ref={this.moreButtonRef}
                >
                    <MoreIcon />
                </div>
                <nav
                    className={`top-menu__navbar ${isOptionsMenuVisible ? '-active' : ''}`}
                    onClick={toggleOptionsMenu}
                    ref={this.navRef}
                >
                    <HashLink
                        hash={mapHash}
                        className='top-menu__button'
                        routeActiveClass='-active'
                    >
                        <MapIcon />
                        Map
                    </HashLink>
                    <HashLink
                        hash={descriptionHash}
                        className='top-menu__button -description'
                        routeActiveClass='-active'
                    >
                        <DescriptionIcon />
                        Description
                    </HashLink>
                    <HashLink
                        hash={codeHash}
                        className='top-menu__button'
                        routeActiveClass='-active'
                    >
                        <CodeIcon />
                        Code
                    </HashLink>
                    {
                        environmentVariables.showCodePen &&
                        <Tooltip
                            text="Download the examples package in order to inspect or modify this example."
                            hidden={!isAdvanced}
                            className="top-menu__button-tooltip"
                        >
                            <div onClick={isAdvanced ? () => {} : toggleCodePenModal}
                                className={`top-menu__button ${isAdvanced ? '-disabled' : ''}`}
                            >
                                <CodepenIcon />
                                Open in CodePen
                            </div>
                        </Tooltip>
                    }
                </nav>
            </div>
        );
    }
}

export default TopMenu;

