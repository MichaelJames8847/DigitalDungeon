const apiUrl = "/api/userprofile";

export const getUserProfiles = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getUserProfilesWithRoles = () => {
    return fetch(apiUrl + "/withroles").then((res) => res.json());
};

export const setUserPreferences = (games) => {
    return fetch(apiUrl + "/preferences", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(games),
    });
};
