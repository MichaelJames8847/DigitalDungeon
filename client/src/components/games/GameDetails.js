import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getGameById } from "../../managers/gameManager";
import { Card, CardBody, CardImg, CardTitle } from "reactstrap";

export default function GameDetails() {
    const [game, setGame] = useState({});
    const { id } = useParams();

    useEffect(() => {
        getGameById(id).then(setGame)
    }, [id])

    return (
        <>
        <h2>Game Details</h2>
        <Card>
            <CardBody>
                <CardTitle tag="h4">{game.name}</CardTitle>
                <CardImg src={game.background_image} />
                <p>Description: {game.description}</p>
                <p>Genre: {game.genre?.genreName}</p>
                <p>Category: {game.category?.categoryName}</p>
                <p>Release Date: {game.released}</p>
                <p>Developer: {game.developer}</p>
                <p>Platforms: {game.platformGames?.map((p) => (
                    <div key={p.id}>
                        <h3>{p.platform.name}</h3>
                    </div>
                ))}</p>
            </CardBody>
        </Card>
        </>
    )
}