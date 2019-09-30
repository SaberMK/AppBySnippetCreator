export const AUTH_USER = 'AUTH_USER';
export const LOGOUT_USER = 'LOGOUT_USER';


export const authUser = (token, username) => {
    return {
        action : AUTH_USER,
        payload : {
            token,
            username
        }
    }
}

export const logoutUser = () => {
    return {
        action : LOGOUT_USER,
        payload : {
            token : '',
            username : ''
        }
    }
}