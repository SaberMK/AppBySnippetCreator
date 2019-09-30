import cookie from 'js-cookie';

import { AUTH_USER, LOGOUT_USER } from "../Actions/globalActions.js";

const initState = {
    token : '',
    username : '',
}

const globalReducer = (state = initState, action) => {
    switch (action.type) {
        case AUTH_USER: {
            cookie.set('AUTH', action.payload,  { expires: 7 })
            return {...state, 
                ...action.payload
            }
        }
        case LOGOUT_USER: {
            return {...state,
                ...action.payload
            }
        }
        default:
            return state;
    }
}

export default globalReducer;