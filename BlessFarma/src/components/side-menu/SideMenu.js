import React, { Component } from 'react';
import Examples from './examples/Examples';
import Categories from './categories/Categories';

export default class SideMenu extends Component {
    constructor(props) {
        super(props);
        this.state = {
            search: '',
            isMobile: window.innerWidth <= 700
        };
    }

    onSearch = (value) => {
        this.setState({
            search: value
        });
    }

    componentDidMount() {
        document.addEventListener('click', this.handleOutsideClick, false);
        window.addEventListener('blur', this.handleIframeClick, false);
        window.addEventListener('resize',this.onResize);
    }

    componentWillUnmount() {
        document.removeEventListener('click', this.handleOutsideClick, false);
        window.removeEventListener('blur', this.handleIframeClick, false);
        window.removeEventListener('resize',this.onResize);
    }

    onResize = () => {
        this.setState({
            isMobile: window.innerWidth <= 700
        });
    }

    handleOutsideClick = (e) => {
        // ignore clicks on the component itself
        if (this.node.contains(e.target)) {
            return;
        }
        this.props.toggleSideMenu();
    }

    handleIframeClick = (e) => {
        //this could be done with document.activeDocument === document.getElementById('tt-iframe'), but
        //there is 10 years old bug in Firefox https://bugzilla.mozilla.org/show_bug.cgi?id=452307
        if (e.target && e.target[0] && e.target[0].document.title === 'Maps SDK for Web') {
            this.props.toggleSideMenu();
        }
    }

    onExampleClick = () => {
        this.setState({
            search: ''
        });
    }

    onCategoryClick = (category) => {
        this.setState({
            selectedCategory: category
        });
    }

    render() {
        const {isMobile, search} = this.state;
        const selectedCategory = this.state.selectedCategory || this.props.currentCategory;
        const isSearchActive = Boolean(search && search.length);

        return (
            this.props.isVisible &&
                <div className="side-menu" ref={node => { this.node = node; }}>
                    <Categories
                        search={search}
                        selectedCategory={selectedCategory}
                        onCategoryClick={this.onCategoryClick}
                        onSearch={this.onSearch}
                        selectedExample={this.props.selectedExample}
                        onExampleClick={this.onExampleClick}
                        toggleSideMenu={this.props.toggleSideMenu}
                        setSearchBoxFocus={this.setSearchBoxFocus}
                        isMobile={isMobile}
                    />
                    {((isMobile && isSearchActive) || !isMobile) && <Examples
                        className={`side-menu-panel examples ${!isMobile ? '-subcategories' : ''}`}
                        selectedCategory={selectedCategory}
                        selectedExample={this.props.selectedExample}
                        toggleSideMenu={this.props.toggleSideMenu}
                        onExampleClick={this.onExampleClick}
                        search={this.state.search}
                        showSearchingHeader={isSearchActive}
                    />
                    }
                </div>
        );
    }
}
