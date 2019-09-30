import React from 'react';
import { Form, Button } from 'semantic-ui-react'
import { reduxForm, Field, formValueSelector } from "redux-form";
import { FormInput } from './Helpers';
import axios from "axios";
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import toastr from "toastr";

import { AUTH_USER } from '../../Actions/globalActions';
import { REGISTER_USER_API_PATH } from '../../Api';

import { InputField } from 'react-semantic-redux-form' 

const RegistrationForm = props => {
    let { authUser, values, history, hasToken } = props;
    return (
        !hasToken ?
        <Form onSubmit={() => handleUserRegister(values, authUser, history)}>
            <Form.Field>
                <label>Login</label>
                <Field name="username" placeholder="Your login" id='username' width='6' component={InputField} />
            </Form.Field>
            <Form.Field>
                <label>Password</label>
                <Field name="password" placeholder="Your password" id='password' width='6' hasPassword={true} component={FormInput} />
            </Form.Field>
            <Form.Field>
                <label>Password Confirmation</label>
                <Field name="passwordConfirmation" placeholder="Your password confirmation" id='passwordConfirmation' width='6' hasPassword={true} component={FormInput} />
            </Form.Field>
            <Button type='submit' >Submit</Button>
        </Form> : //if already has token
        <div>You are already authorized!</div>
    )
}

const handleUserRegister = ( values, authUser, history ) => {
    let { username, password, passwordConfirmation } = values;
    
    if(password !== passwordConfirmation) {
        toastr.error('Password doesn\'t match confirmation!', 'Error')
        return;
    }

    axios.post(REGISTER_USER_API_PATH, {
            username,
            password,
            passwordConfirmation
        })
        .then(res => {
            if(res.data.error === 0) {
                let result = res.data.response;
                authUser({
                    ...result
                });
                history.push('/');
            } else {
                console.log('Showing toast...', res.data.response);
                toastr.error(res.data.response, 'Error');
            }
        })


}

const selector = formValueSelector('registrationForm');

const mapStateToProps = state => ({
    values : selector(state, 'username', 'password', 'passwordConfirmation'),
    hasToken : state.global.token ? true : false
})


const mapDispatchToProps = dispatch => {
    return {
        authUser : values => {
            dispatch({
                type: AUTH_USER,
                payload : values
            })
        }
    }
}

const onSubmit = values => {
    console.log('Values', values);
}

export default withRouter(reduxForm({
    form: 'registrationForm',
    onSubmit
})(connect(mapStateToProps, mapDispatchToProps)(RegistrationForm)));