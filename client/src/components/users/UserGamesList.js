import { useEffect, useState } from "react";
import { getGamesBasedOnPreferences } from "../../managers/userProfileManager";
import { Button, Card, CardBody, CardDeck, CardImg, CardText, CardTitle } from "reactstrap";

export default function UserGamesList() {
    const [suggestedGames, setSuggestedGames] = useState([]);
    const [error, setError] = useState(null)

  useEffect(() => {
    getGamesBasedOnPreferences()
    .then((data) => {
        console.log("Games based on preferences:", data);
        setSuggestedGames(data);
    })
    .catch((error) => {
        console.error("Error fetching games based on preferences", error);
        setError("An error occured while fetching games based on preferences")
    });
  }, []);

    return (
        <>
        {error ? (
            <div className="error-message">{error}</div>
        ) : (
        <CardDeck>
            {suggestedGames.map((game) => (
                <Card key={game.id}>
                    <CardImg top width="50%" src={game.coverImage} alt={game.coverImage} />
                    <CardBody>
                        <CardTitle>{game.title}</CardTitle>
                        <CardText>{game.description}</CardText>
                        <Button color="primary">Buy Now</Button>
                    </CardBody>
                </Card>
            ))}
        </CardDeck>
        )}
        </>
    )
}