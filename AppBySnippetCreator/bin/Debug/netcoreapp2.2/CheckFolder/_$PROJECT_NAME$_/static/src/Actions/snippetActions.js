export const VIEW_SNIPPET = 'VIEW_SNIPPET';
export const FLUSH_SHIPPET = 'FLUSH_SHIPPET';
export const VIEW_SNIPPET_ERROR = 'VIEW_SNIPPET_ERROR'

export const viewSnippet = (snippet) => {
    return {
        action : VIEW_SNIPPET,
        payload : { snippet
        }
    }
}

export const flushSnippet = () => {
    return {
        action : FLUSH_SHIPPET,
        payload : {}
    }
}

export const viewSnippetError = error => {
    return {
        action : VIEW_SNIPPET_ERROR,
        payload : error
    }
}