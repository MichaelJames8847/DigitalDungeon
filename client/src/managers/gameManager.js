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

export const fetchPendingGames = () => {
    return fetch(`${apiUrl}/pending-suggestions`).then((res) => res.json());
};

export const approveGame = (gameId) => {
    return fetch(`${apiUrl}/approve/${gameId}`, {
        method: "POST",
    }).then((res) => res.json());
};

export const denyGame = (gameId) => {
    return fetch(`${apiUrl}/deny/${gameId}`, {
        method: "POST",
    }).then((res) => res.json());
};

export const updateGameDetails = (id, gameDetails) => {
    return fetch(`${apiUrl}/update/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(gameDetails),
    }).then((res) => res.json());
};

export const deleteGame = (gameId) => {
    return fetch(`${apiUrl}/${gameId}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(gameId)
    })
};

