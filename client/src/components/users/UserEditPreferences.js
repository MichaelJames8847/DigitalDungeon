import { useEffect, useState } from "react";
import { getGenres } from "../../managers/genreManager";
import { getCategories } from "../../managers/categoryManager";
import { getGamesBasedOnPreferences, getUserPreferences, updateUserPreferences } from "../../managers/userProfileManager";
import { useNavigate } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";

export default function UserEditPreferences() {
    const [genres, setGenres] = useState([]);
    const [categories, setCategories] = useState([]);
    const [selectedGenres, setSelectedGenres] = useState([]);
    const [selectedCategories, setSelectedCategories] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getUserPreferences().then((data) => {
            const genreIds = data.genres.map((g) => g.id);
            const categoryIds = data.categories.map((c) => c.id);
            setSelectedGenres(genreIds);
            setSelectedCategories(categoryIds);
        });
        getGenres().then(setGenres);
        getCategories().then(setCategories);
    }, []);

    const handleGenreChange = (genreId) => {
        setSelectedGenres((prevSelectedGenres) => 
        prevSelectedGenres.includes(genreId)
        ? prevSelectedGenres.filter((id) => id !== genreId)
        : [...prevSelectedGenres, genreId]
        );
    };

   const handleCategoryChange = (categoryId) => {
    setSelectedCategories((prevSelectedCategories) => 
    prevSelectedCategories.includes(categoryId)
    ? prevSelectedCategories.filter((id) => id !== categoryId)
    : [...prevSelectedCategories, categoryId]
    );
   };

    const handleSubmit = (e) => {
        e.preventDefault();
        const submitGenres = genres.filter((g) => selectedGenres.includes(g.id));
        const submitCategories = categories.filter((c) => selectedCategories.includes(c.id));

        updateUserPreferences(submitGenres, submitCategories).then(() => {
            getGamesBasedOnPreferences()
            .then(() => {
                navigate("/");
            });
        });
    };

    return (
        <>
            <FormGroup>
                <Label>Genres</Label>
                {genres.map((genre) => (
                    <FormGroup key={genre.id}>
                        <Label>
                            <Input
                                type="checkbox"
                                onChange={() => handleGenreChange(genre.id)}
                                checked={selectedGenres.includes(genre.id)}
                            />
                            {genre.genreName}
                        </Label>
                    </FormGroup>
                ))}
            </FormGroup>
            <FormGroup>
                <Label>Categories</Label>
                {categories.map((category) => (
                    <FormGroup key={category.id}>
                        <Label>
                            <Input
                                type="checkbox"
                                onChange={() => handleCategoryChange(category.id)}
                                checked={selectedCategories.includes(category.id)}
                            />
                            {category.categoryName}
                        </Label>
                    </FormGroup>
                ))}
            </FormGroup>
            <Button color="primary" onClick={handleSubmit}>
                Save Preferences
            </Button>
        </>
    );
}
