import React from 'react';
import CategoryIcon from '../CategoryIcon';
import SearchIcon from '../../../assets/icons/ic_search_for.svg';

export default function CategoryInfo({ selectedCategory, showSearchingHeader }) {
    let icon, text;

    if (showSearchingHeader) {
        icon = <SearchIcon />;
        text = 'Search results';
    } else {
        icon = <CategoryIcon name={selectedCategory} />;
        text = selectedCategory;
    }

    return (
        <div className="side-menu-category -subcategory-title">
            <div className="side-menu-category__icon -gray">{icon}</div>
            <div className="side-menu-category__text">{text}</div>
        </div>
    );
}
