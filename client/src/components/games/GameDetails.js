import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getGameById } from "../../managers/gameManager";
import { Card, CardBody, CardImg, CardTitle, CardSubtitle, CardText, ListGroup, ListGroupItem } from "reactstrap";
import "./GameDetails.css"

export default function GameDetails() {
    const [game, setGame] = useState({});
    const { id } = useParams();

    useEffect(() => {
        getGameById(id).then(setGame)
    }, [id])

    return (
        <>
        <div className="game-details">
        <h2 className="text-light">Game Details</h2>
        <Card className="bg-dark text-light mb-3">
            <CardBody>
                <CardTitle tag="h4">{game.name}</CardTitle>
                <CardImg top width="100%" src={game.background_image} alt={game.name} />
                <CardText className="mt-3">Description: {game.description}</CardText>
                <CardSubtitle tag="h6" className="mb-2 text-muted">Details</CardSubtitle>
                <ListGroup flush className="text-light">
                    <ListGroupItem className="bg-dark">Genre: {game.genre?.genreName}</ListGroupItem>
                    <ListGroupItem className="bg-dark">Category: {game.category?.categoryName}</ListGroupItem>
                    <ListGroupItem className="bg-dark">Release Date: {game.released}</ListGroupItem>
                    <ListGroupItem className="bg-dark">Developer: {game.developer}</ListGroupItem>
                </ListGroup>
                <CardSubtitle tag="h6" className="mt-3 mb-2 text-muted">Platforms</CardSubtitle>
                <ListGroup flush className="text-light">
                    Available On:
                    {game.platformGames?.map((p) => (
                        <ListGroupItem className="bg-dark" key={p.id}>
                            {p.platform.name}
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardBody>
        </Card>
        </div>
        </>
    )
}
