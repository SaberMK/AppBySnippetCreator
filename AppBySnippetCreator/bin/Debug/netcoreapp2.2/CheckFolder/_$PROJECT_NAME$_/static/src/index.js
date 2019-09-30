import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as serviceWorker from './serviceWorker';
import 'fomantic-ui/dist/semantic.min.css';
import 'toastr/build/toastr.min.css'
import './css/react-highlightsjs.css'
import axios from 'axios';

import { Provider } from 'react-redux';

import configureStore from './Store/configureStore.js';

const store = configureStore();
axios.defaults.headers.common['Accept'] = 'application/json'
ReactDOM.render(<Provider store={store}>
        <App />
    </Provider>, 
    document.getElementById('root'));
    

serviceWorker.unregister();
