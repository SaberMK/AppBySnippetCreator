import { composeWithDevTools } from 'redux-devtools-extension'
import { createStore, applyMiddleware } from 'redux'
import thunk from 'redux-thunk';

import rootReducer from '../Reducers/rootReducer.js';

export default function configureStore(initialState) {
    const store = createStore(rootReducer, initialState, composeWithDevTools(applyMiddleware(thunk)));

    if(module.hot){
        module.hot.accept('../Reducers/rootReducer.js', () => {
            const nextRootReducer = require('../Reducers/rootReducer.js');
            store.replaceReducer(nextRootReducer);
        })
    }

    return store;
}