import React, {Component} from 'react';
import { Button, Menu, Dropdown } from "semantic-ui-react";
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { AUTH_USER, LOGOUT_USER } from '../../Actions/globalActions.js';
import cookie from 'js-cookie';

class NavBarUserPanel extends Component {
  componentWillMount() {
    let authCookie = cookie.getJSON('AUTH');
    if(authCookie!==undefined)
      this.props.authUser(authCookie);
  }
  
  render() { 
    let logoutUser = this.props.logoutUser;
    let isAuth = this.props.isAuth;
    let username = this.props.username;
    let greetingsText = `Здарова, ${username}!`;
    let history = this.props.history;
    return ( 
        !isAuth ? (

          <Menu.Item position='right'>
            <Button as='a' inverted={true} onClick={()=>history.push('/login')}>
              Log In
            </Button>
            <Button as='a' inverted={true} onClick={()=>history.push('/registration')} style={{ marginLeft: '0.5em' }}>
              Sign Up
            </Button>
          </Menu.Item>) : (

          <Menu.Item position='right'>
              <Dropdown text={greetingsText} >
                <Dropdown.Menu>
                  <Dropdown.Item text='Profile' />
                  <Dropdown.Item text='Log out' onClick={()=>logOut(logoutUser, history)}/>
                </Dropdown.Menu>
              </Dropdown>
          </Menu.Item>));
  }
}

const logOut = (logoutUser, history) => {
  cookie.remove('AUTH');
  logoutUser();
  document.location.reload(true);
}


const mapStateToProps = ({global}) => {
  return {
    username : global.username
  }
};

const mapDispatchToProps = dispatch => {
  return {
    authUser : values => {
      dispatch({
        type: AUTH_USER,
        payload: values
      })
    },
    logoutUser : () => {
      dispatch({
        type: LOGOUT_USER
      })
    }
  }
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(NavBarUserPanel));