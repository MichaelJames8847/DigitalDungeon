const apiUrl = "/api/platform"

export const getAllPlatforms = () => {
    return fetch(apiUrl).then((r) => r.json());
};

export const getPlatformById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
};