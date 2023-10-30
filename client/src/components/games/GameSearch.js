import { useState } from "react";
import { searchGames } from "../../managers/gameManager";
import { FormGroup, Form, Label, Input, Button, ListGroup, ListGroupItem } from "reactstrap";
import { Link } from "react-router-dom";
import "./GameSearch.css"

export default function GameSearch() {
    const [query, setQuery] = useState('');
    const [games, setGames] = useState([]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const result = await searchGames(query);
        setGames(result);
    };

    return (
        <div className="game-search">
            <Form onSubmit={handleSubmit}>
                <FormGroup>
                    <Label>Search Games:</Label>
                    <Input
                        type="text"
                        value={query}
                        onChange={e => setQuery(e.target.value)}
                        placeholder="Enter game title..."
                        />
                </FormGroup>
                <Button color="primary" type="submit">Search</Button>
            </Form>

            <div>
                <ListGroup>
                    {games.map(game => (
                        <ListGroupItem key={game.id}>
                            <Link to={`/games/${game.id}`}>
                            <h4>{game.name}</h4>
                            </Link>
                            <img src={game.background_image} alt={game.name} width="200" />
                            <p>{game.description}</p>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </div>
        </div>
    )
}