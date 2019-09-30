import React from 'react';
import Highlight from 'react-highlight'

const CodePresentator = ({language, code}) => {
    return ( <Highlight language='javascript'>
        {code}
    </Highlight> );
}
 
export default CodePresentator;