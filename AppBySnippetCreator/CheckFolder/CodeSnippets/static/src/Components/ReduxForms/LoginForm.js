import React from 'react';
import { Form, Button } from 'semantic-ui-react'
import { reduxForm, Field, formValueSelector } from "redux-form";
import { FormInput } from './Helpers';
import axios from "axios";
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import toastr from "toastr";

import { AUTH_USER } from '../../Actions/globalActions';
import { AUTH_USER_API_PATH } from '../../Api';

import { InputField } from 'react-semantic-redux-form' 

const LoginForm = props => {
    let { authUser, values, history, hasToken } = props;
    return (
        !hasToken ?
        <Form onSubmit={() => handleAuthUser(values, authUser, history)}>
            <Form.Field>
                <label>Login</label>
                <Field name="username" placeholder="Your login" id='username' width='6' component={InputField} />
            </Form.Field>
            <Form.Field>
                <label>Password</label>
                <Field name="password" placeholder="Your password" id='password' width='6' hasPassword={true} component={FormInput} />
            </Form.Field>
            <Button type='submit' >Submit</Button>
        </Form> : //if has token
        <div>You are already authorized!</div>
    )
}

const handleAuthUser = ( values, authUser, history ) => {
    let { username, password } = values;

    axios.post(AUTH_USER_API_PATH, {
            username,
            password
        })
        .then(res => {
            if(res.data.error === 0) { // if err != nil lol just kiddin'
                console.log(res.data);
                let result = res.data.response;
                authUser({
                    ...result
                });
                history.push('/');
            } else {
                console.log('Showing toast...', res.data.response);
                toastr.error(res.data.response, 'Error')
            }
        });
}

const selector = formValueSelector('loginForm');

const mapStateToProps = state => ({
    values : selector(state, 'username', 'password'),
    hasToken : state.global.token ? true : false
})

const mapDispatchToProps = dispatch => {
    return {
        authUser : values => {
            dispatch({
                type: AUTH_USER,
                payload: values
            })
        }
    }
}

export default withRouter(reduxForm({
    form: 'loginForm',
    onSubmit : handleAuthUser
})(connect(mapStateToProps, mapDispatchToProps)(LoginForm)));