import React from 'react';
import HashLink from '../../common/HashLink';
import CategoryInfo from './CategoryInfo';
import ExamplesTree from '../../../ExamplesTree';
import {filterExamplesTree} from '../../../ExamplesTree';
import AdvancedIcon from '../../../assets/icons/ic_advanced.svg';

const onLinkClick = (props, title) => {
    props.toggleSideMenu();
    props.onExampleClick(title);
};

const renderLinks = (props, examples) => {
    return examples.map(([title, example]) => {
        return <HashLink
            key={title}
            className={'side-menu-details__example-link ' + (props.selectedExample === title ? '-active' : '')}
            hash={`examples/map/${example.page}`}
            onClick={() => onLinkClick(props, title)}
        >
            {title}
        </HashLink>;
    }
    );
};

export default function Examples(props) {
    let examples;
    if (props.search) {
        examples = filterExamplesTree(props.search.toLowerCase());
    } else {
        examples = ExamplesTree[props.category || props.selectedCategory];
    }

    examples = Object.entries(examples);
    const simpleExamples = examples.filter(([, example]) => !example.advanced);
    const advancedExamples = examples.filter(([, example]) => example.advanced === true);

    return (
        <div className={props.className || ''}>
            {!props.hideCategoryHeader &&
                <CategoryInfo showSearchingHeader={props.showSearchingHeader} selectedCategory={props.selectedCategory}/>
            }
            {renderLinks(props, simpleExamples)}
            {advancedExamples.length > 0 &&
                <div className='advanced-example-section'>
                    <div className="side-menu-category -subcategory-title">
                        <div className="side-menu-category__icon -gray"><AdvancedIcon /></div>
                        <div className="side-menu-category__text">Advanced</div>
                    </div>
                    {renderLinks(props, advancedExamples)}
                </div>
            }
        </div>
    );
}
