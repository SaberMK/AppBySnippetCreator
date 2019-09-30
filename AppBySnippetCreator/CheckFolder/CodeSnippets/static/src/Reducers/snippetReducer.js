import { VIEW_SNIPPET, FLUSH_SHIPPET, VIEW_SNIPPET_ERROR } from "../Actions/snippetActions.js"

const initState = {
    name : '',
    description : '',
    code : '',
    language : '',
    tags : [],
    author : {},
    isLoaded : false,
    error : ''
}

const snippetReducer = (state = initState, action) => {
    switch(action.type) {
        case VIEW_SNIPPET : {
            return { ...action.payload,
                isLoaded : true,
                error : ''
            }
        }
        case FLUSH_SHIPPET : {
            return initState
        }
        case VIEW_SNIPPET_ERROR : {
            return {...initState,
                isLoaded : true,
                error : action.payload
            }
        }
        default:
            return state
    }
}

export default snippetReducer;