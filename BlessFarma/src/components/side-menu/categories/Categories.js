import React, { Component } from 'react';
import SearchBox from './SearchBox';
import ExamplesTree from '../../../ExamplesTree';
import Category from './Category';
import Examples from '../examples/Examples';

export default class Categories extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: ExamplesTree
        };
    }

    renderExamplesForMobile = (category) => {
        if ((this.props.isMobile && (category !== this.props.selectedCategory)) || !this.props.isMobile) {
            return;
        }
        return <Examples
            className='examples-in-menu'
            hideCategoryHeader={true}
            selectedExample={this.props.selectedExample}
            toggleSideMenu={this.props.toggleSideMenu}
            onExampleClick={this.props.onExampleClick}
            category={category}
            selectedCategory={this.props.selectedCategory}
        />;
    }

    renderCategories = () => {
        return Object
            .keys(this.state.categories)
            .map(category => <div key={category}>
                <Category
                    selectedCategory={this.props.selectedCategory}
                    title={category}
                    onClick={() => this.props.onCategoryClick(category)}
                />
                {this.renderExamplesForMobile(category)}
            </div>);
    }

    render() {
        const {isMobile, onSearch, search} = this.props;

        return (
            <div className='side-menu-panel -categories'>
                <SearchBox
                    onSearch={onSearch}
                    search={search}
                />
                {((isMobile && !search) || !isMobile) && <div className='side-menu-categories'>
                    {this.renderCategories()}
                </div>}
            </div>

        );
    }
}
