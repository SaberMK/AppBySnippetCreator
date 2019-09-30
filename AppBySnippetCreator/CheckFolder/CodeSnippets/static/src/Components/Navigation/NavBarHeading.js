import React from 'react';
import {
    Container,
    Menu,
    Segment,
  } from 'semantic-ui-react'
import { withRouter } from 'react-router-dom';
import Favicon from '../../icons/favicon.bmp';
import NavBarUserPanel from "./NavBarUserPanel.js";

import { connect } from 'react-redux';

const NavBarHeading = (props) => {
  let { hasToken } = props;
    return ( 
          <Segment
            textAlign='center'
            vertical
          >
            <Menu
              fixed='top'
              inverted
              size='large'
            >
              <Container>
                <img src={Favicon} alt="logo" style={{ marginTop: '0.4em', marginLeft: '0.1em',width: '30px', height: '30px' }}/>
                <Menu.Item as='a' onClick={()=>{props.history.push('/')}}>Some snippets</Menu.Item>
                <Menu.Item as='a' onClick={()=>{props.history.push('/snippet/add')}}>Add Snippet</Menu.Item>
                <NavBarUserPanel isAuth={hasToken} />
              </Container>
            </Menu>
          </Segment>);
}
 
const mapStateToProps = ( {global} ) => {
  return {
    hasToken : global.token !== '' ? true : false
  }
}

export default withRouter(connect(mapStateToProps)(NavBarHeading));