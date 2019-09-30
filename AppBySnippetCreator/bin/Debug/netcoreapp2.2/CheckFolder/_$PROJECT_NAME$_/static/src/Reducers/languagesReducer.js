import { UPDATE_LANGUAGES } from "../Actions/languagesActions.js";

const initState = {
    languages : []
}

const languagesReducer = (state = initState, action) => {
    switch(action.type) {
        case UPDATE_LANGUAGES: {
            return {...state,
                languages: action.payload
            }
        }
        default:
            return state
    }
}

export default languagesReducer;