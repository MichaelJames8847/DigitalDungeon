// manager to handle fetch calls for games 
const apiUrl = "/api/game"

export const getGames = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getGameById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
};

export const searchGames = (query) => {
    return fetch(`${apiUrl}/search/${query}`).then((r) => r.json());
};

export const suggestGame = (title) => {
    return fetch(apiUrl + "/suggest", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ name: title }),
    }).then((res) => res.json());
};


