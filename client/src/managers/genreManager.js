// manager to handle fetch calls for genres
const apiUrl = "/api/genre";

export const getGenres = () => {
    return fetch(apiUrl).then((res) => res.json());
};