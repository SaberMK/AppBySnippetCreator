import React from 'react';
import { connect } from 'react-redux';
import axios from 'axios';
import toastr from 'toastr';
import AddSnippetForm from '../ReduxForms/AddSnippetForm.js';
import cookies from 'js-cookie'
import { UPDATE_LANGUAGES } from '../../Actions/languagesActions';
import { UPDATE_LANGUAGES_API_PATH } from '../../Api';

const AddSnippetPage = (props) => {
    let { token, languages, updateLanguages } = props
    return ( 
        token!==""? <div>
            {getLanguages(token, languages, updateLanguages)}
            <AddSnippetForm />
        </div> : // if not authorized
         <div>
             <p>U need to authorize first!</p>
         </div>
    );
}

const getLanguages = (token, languages, updateLanguages) => {
    if(languages.length>0) return;
      
    axios.post(UPDATE_LANGUAGES_API_PATH,{
        token
    })
    .then(res => {
        if(res.data.error === 0) {
            let result = res.data.response;
            updateLanguages([
                ...result
            ])
        } else {
            console.log('Showing toast...', res.data.response);
            toastr.error(res.data.response, 'Error')
        }

    })
}

const mapStateToProps = ( {global, languages} ) => {
    return {
        token : global.token,
        languages : languages.languages
    }
}

const mapDispatchToProps = dispatch => {
    return {
        updateLanguages : values => {
            dispatch({
                type: UPDATE_LANGUAGES,
                payload : values
            })
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AddSnippetPage);