import React, { Component } from 'react';
import { findExample } from '../../ExamplesTree';
import CodePenModal from './CodePenModal';
import TopMenu from '../top-menu/TopMenu';
import SideMenu from '../side-menu/SideMenu';
import environmentVariables from '../../environmentVariables';
import Example from './Example';
import environmentalVariables from '../../environmentVariables';

import { extractSnippets as snippetExtractor } from '../../code-extractor/SnippetExtractor';

class ExampleView extends Component {
    constructor(props) {
        super(props);

        this.state = {
            codePenModalOpen: false,
            snippets: undefined,
            isSideMenuVisible: false,
            optionsMenuOpen: false
        };
    }

    componentDidMount() {
        this.fetchSnippets();
    }

    componentDidUpdate(prevProps) {
        if (this.props.match.params.example !== prevProps.match.params.example) {
            this.fetchSnippets();
        }
    }

    toggleSideMenu = () => {
        this.setState({
            isSideMenuVisible: !this.state.isSideMenuVisible
        });
    };

    showExample = () => {
        this.setState({
            isSideMenuVisible: false
        });
    };

    fetchSnippets = () => {
        const pageUrl = `${environmentVariables.publicUrl}/pages/examples/html/${this.props.match.params.example}`;

        snippetExtractor(pageUrl).then((snippets) => {
            this.setState({snippets});
        });
    }

    toggleCodePenModal = () => {
        this.setState({
            codePenModalOpen: !this.state.codePenModalOpen
        });
    }

    toggleOptionsMenu = () => {
        this.setState({
            optionsMenuOpen: !this.state.optionsMenuOpen
        });
    }

    render() {
        const exampleFilename = this.props.match.params.example;
        const {
            name: exampleName,
            category: exampleCategory,
            description: exampleDescription,
            advanced: isAdvanced
        } = findExample(exampleFilename);
        let sideMenu = '';
        if (this.state.isSideMenuVisible) {
            sideMenu = <SideMenu
                isVisible={this.state.isSideMenuVisible}
                toggleSideMenu={this.toggleSideMenu}
                showExample={this.showExample}
                selectedExample={exampleName}
                currentCategory={exampleCategory}
            />;
        }

        return (
            <div className="example-view">
                <TopMenu
                    exampleFilename={exampleFilename}
                    exampleName ={exampleName}
                    category={exampleCategory}
                    isSideMenuVisible={this.state.isSideMenuVisible}
                    isOptionsMenuVisible={this.state.optionsMenuOpen}
                    toggleSideMenu={this.toggleSideMenu}
                    toggleCodePenModal={this.toggleCodePenModal}
                    isAdvanced={isAdvanced}
                    toggleOptionsMenu={this.toggleOptionsMenu}
                />
                <div className="example-view__content">
                    {sideMenu}
                    <Example
                        description={exampleDescription}
                        match={this.props.match}
                        snippets={this.state.snippets} />
                </div>

                {this.state.snippets && environmentalVariables.showCodePen &&
                    <CodePenModal
                        open={this.state.codePenModalOpen}
                        close={this.toggleCodePenModal}
                        snippets={this.state.snippets}
                        exampleName={exampleName}
                    />
                }
            </div>

        );
    }
}

export default ExampleView;
