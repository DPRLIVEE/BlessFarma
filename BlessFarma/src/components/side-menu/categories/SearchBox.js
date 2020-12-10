import React from 'react';
import SearchIcon from '../../../assets/icons/ic_search_for.svg';

export default function SearchBox(props) {
    return (
        <div className="side-menu-searchBox">
            <input
                className="side-menu-searchBox__input"
                onChange={(event) => props.onSearch(event.target.value)}
                value={props.search}
                placeholder="Search for an example"
            />
            <div className="side-menu-searchBox__icon">
                <SearchIcon />
            </div>
        </div>
    );
}
