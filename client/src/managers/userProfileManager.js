const apiUrl = "/api/userprofile";

export const getUserProfiles = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getUserProfilesWithRoles = () => {
    return fetch(apiUrl + "/withroles").then((res) => res.json());
};

export const setUserPreferences = (genres, categories) => {
    return fetch(apiUrl + "/preferences", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ genres, categories }),
    }).then((res) => res.json())
};

export const deleteUser = (userId) => {
    return fetch(`${apiUrl}/${userId}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(userId)
    })
};

export const getGamesBasedOnPreferences = () => {
    return fetch(apiUrl + "/games").then((res) => res.json());
};

export const getUserById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};

export const promoteUser = (userId) => {
    return fetch(`${apiUrl}/promote/${userId}`, {
        method: "POST",
    });
};

export const demoteUser = (userId) => {
    return fetch(`${apiUrl}/demote/${userId}`, {
        method: "POST",
    });
};

export const removeGameFromSuggestions = (gameId) => {
    return fetch(`${apiUrl}/games/${gameId}/suggestions`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
    }).then((res) => res.json());
}

