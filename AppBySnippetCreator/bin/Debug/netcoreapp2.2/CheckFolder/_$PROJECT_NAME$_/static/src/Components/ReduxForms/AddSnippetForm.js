import React from 'react';
import { Form, Button, FormTextArea } from 'semantic-ui-react'
import { reduxForm, Field, formValueSelector, FieldArray  } from 'redux-form'
import { CustomInput, RenderAndAddTags } from './Helpers';
import axios from 'axios';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom'
import toastr from "toastr";

import { InputField, SelectField, TextAreaField } from 'react-semantic-redux-form' 
import { ADD_SNIPPET_API_PATH } from '../../Api';

const AddSnippetForm = props => {
    let { token, values, languages, history } = props;

    let modifiedLanguages=[]

    if(languages.length!==0){
        modifiedLanguages = languages.map(value=>({
            key: value,
            text: value,
            value
        }));
    }
    
    return ( <Form onSubmit={()=> handleAddSnippet(token, values, history)}>
        <Form.Group inline>
            <Form.Field>
                <label>Name</label>
                <Field name="name" placeholder="Snippet Name" id="name" component={InputField} />
            </Form.Field>
            <Form.Field>
                <label>Language</label>
                <Field name="language" 
                    style={{minWidth:'200px'}}
                    id="language"
                    placeholder='Choose language'
                    options={modifiedLanguages}
                    min={5}
                    onChange={(e, value) => {console.log(e,value)}}
                    component={SelectField} />
            </Form.Field>
        </Form.Group>
        <Form.Field>
            <label>Description</label>
            <Field name="description" placeholder="Snippet Description" id="description" width={8} component={InputField} />
        </Form.Field>
        <Form.Field>
            <label>Code</label>
            <Field name="code" placeholder="Past your code here" id="code" width={8} height={20} component={TextAreaField} />
        </Form.Field>
        <Form.Field>
            <FieldArray name="tags" id="tags" component={RenderAndAddTags} />
        </Form.Field>
        <Button type='submit'>Add snippet</Button>
    </Form> );
}

const handleAddSnippet = ( token, values, history ) => {
    axios.post(ADD_SNIPPET_API_PATH, {
        token,
        ...values
    })
    .then(res => {
        console.log(res);
        if(res.data.error===0) {
            console.log(res.data);
            let result = res.data.response;
            history.push('/');
        } else {
            console.log('Showing toast...', res.data.response);
            toastr.error(res.data.response, 'Error')
        }
    });
}

const selector = formValueSelector('addSnippetForm');

const mapStateToProps = state => ({
    values : selector(state, 'name', 'description', 'code', 'language', 'tags'),
    languages : state.languages.languages,
    token : state.global.token
})

export default withRouter(reduxForm({
    form : 'addSnippetForm',
    onSubmit : handleAddSnippet
})(connect(mapStateToProps)(AddSnippetForm)));