const apiUrl = "/api/platform"

export const getAllPlatforms = () => {
    return fetch(apiUrl).then((r) => r.json());
};