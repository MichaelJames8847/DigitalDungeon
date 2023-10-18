// manager to handle fetch calls for categories
const apiUrl = "/api/category";

export const getCategories = () => {
    return fetch(apiUrl).then((res) => res.json());
};