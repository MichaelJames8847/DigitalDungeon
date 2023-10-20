import { useEffect, useState } from "react";
import { getGames } from "../../managers/gameManager";
import { Link } from "react-router-dom";

export default function GameCatalog() {
    const [games, setGames] = useState([]);

    useEffect(() => {
        getGames().then(setGames);
    }, []);

    return (
        <>
        <h2>Game Catalog</h2>
        <article className="games">
            {games.map((g) => (
                <div key={`game-${g.id}`}>
                    <img src={g.background_image} alt={g.background_image} />
                    <Link to={`${g.id}`}>
                    <h3>{g.name}</h3>
                    </Link>
                </div>
            ))}
        </article>
        </>
    )
}