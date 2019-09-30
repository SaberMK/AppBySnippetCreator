import React, { Component } from 'react';
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import { VIEW_SNIPPET, FLUSH_SHIPPET, VIEW_SNIPPET_ERROR } from '../../Actions/snippetActions.js'
import { VIEW_SNIPPET_API_PATH } from '../../Api/index.js';
import axios from 'axios'
import toastr from 'toastr'


class ViewSnippetPage extends Component {
    constructor(props) {
        super(props);
    }

    componentWillUnmount() {
        this.props.flushSnippet();
    }

    render() {
        let id = this.props.match.params.id;
        let viewSnippet = this.props.viewSnippet;
        let viewSnippetError = this.props.viewSnippetError;
        let snippet = this.props.snippet;

        if(snippet.isLoaded === false) {
            loadSnippet(id, viewSnippet, viewSnippetError)
        }

        return ( <div> { snippet.error!=='' ? snippet.error : JSON.stringify(snippet) }

            </div>
            );
    }   
}

const loadSnippet = (id, viewSnippet, viewSnippetError) => {
    id = Number.parseInt(id, 10)
    if(Number.isNaN(id))  {
        viewSnippetError("Bad snippet id")
        return;
    }
        
    axios.get(VIEW_SNIPPET_API_PATH,{params: { "id" : id }})
    .then(res => {
        if(res.data.error === 0) {
            let result = res.data.response;
            viewSnippet(result);
        } else {
            console.log('Showing toast...', res.data.response);
            viewSnippetError(res.data.response);
        }
    })
}

const mapStateToProps = ( { snippet } ) => {
    return {
        snippet
    }
}

const mapDispatchToProps = dispatch => {
    return {
        viewSnippet : snippet => {
            dispatch({
                type : VIEW_SNIPPET,
                payload : snippet
            })
        },
        flushSnippet : () => {
            dispatch({
                type : FLUSH_SHIPPET,
                payload : {}
            })
        },
        viewSnippetError : error => {
            dispatch({
                type : VIEW_SNIPPET_ERROR,
                payload : error
            })
        }
    }
}

export default withRouter(
    connect(mapStateToProps, mapDispatchToProps)
    (ViewSnippetPage));