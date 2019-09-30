export const UPDATE_LANGUAGES = 'UPDATE_LANGUAGES';

export const updateLanguages = (languages) => {
    return {
        action : UPDATE_LANGUAGES,
        payload : {
            languages
        }
    }
}