// manager to handle fetch calls for games 
const apiUrl = "/api/game"

export const getGames = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getGameById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
};



