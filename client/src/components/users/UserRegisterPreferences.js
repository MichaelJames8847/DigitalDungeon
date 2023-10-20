// form component to handle initial user gaming preferences

import { useEffect, useState } from "react";
import { getGenres } from "../../managers/genreManager";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { useNavigate } from "react-router-dom";
import { getCategories } from "../../managers/categoryManager";

// upon registration
export default function UserRegisterPreferences() {
    const [genres, setGenres] = useState([]);
    const [categories, setCategories] = useState([]);
    const [selectedGenres, setSelectedGenres] = useState([]);
    const [selectedCategories, setSelectedCategories] = useState([]);
    const navigate = useNavigate();
    
    useEffect(() => {
        getGenres().then(setGenres);
        getCategories().then(setCategories);
    }, [])

   const handleGenreChange = (genreId) => {
    setSelectedGenres((prevGenres) => 
    prevGenres.includes(genreId)
    ? prevGenres.filter((id) => id !== genreId)
    : [...prevGenres, genreId]
    );
   };

   const handleCategoryChange = (categoryId) => {
    setSelectedCategories((prevCategories) => 
    prevCategories.includes(categoryId)
    ? prevCategories.filter((id) => id !== categoryId)
    : [...prevCategories, categoryId]
    );
   };

   const handleSubmit = () => {
        console.log("Selected Genres:", selectedGenres);
        console.log("Selected Categories:", selectedCategories);
        navigate("/")
   };

   return (
    <div className="container" style={{ maxWidth: "500px"}}>
        <h2>Set Your Prefences!</h2>
        <FormGroup>
            <h3>Select Genres</h3>
            {genres.map((g) => (
                <FormGroup key={g.id}>
                    <Label>
                        <Input
                            type="checkbox"
                            id={`genre-${g.id}`}
                            value={g.id}
                            checked={selectedGenres.includes(g.id)}
                            onChange={() => handleGenreChange(g.id)}
                            />
                            {g.genreName}
                    </Label>
                    </FormGroup>
            ))}
        </FormGroup>
        <FormGroup>
            <h3>Select Categories</h3>
            {categories.map((c) => (
                <FormGroup key={c.id}>
                    <Label>
                        <Input
                            type="checkbox"
                            id={`category-${c.id}`}
                            value={c.id}
                            checked={selectedCategories.includes(c.id)}
                            onChange={() => handleCategoryChange(c.id)}
                            />
                            {c.categoryName}
                    </Label>
                    </FormGroup>
            ))}
        </FormGroup>
        <Button color="primary" onClick={handleSubmit}>
            Save Preferences
        </Button>
    </div>
   )
}