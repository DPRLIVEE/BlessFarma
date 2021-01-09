import React from 'react';
import CategoryIcon from '../CategoryIcon';

export default function Category(props) {
    return (
        <div className={"side-menu-category -hoverable -lineOver " + (props.selectedCategory === props.title ? '-active' : '')}
            onClick={props.onClick}>
            <div className="side-menu-category__icon -white">
                <CategoryIcon name={props.title} />
            </div>

            <div className="side-menu-category__text">
                <span>{props.title}</span>
            </div>
        </div>
    );
}
