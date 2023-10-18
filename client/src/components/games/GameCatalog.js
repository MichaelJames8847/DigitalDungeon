import { useEffect, useState } from "react";
import { getGames } from "../../managers/gameManager";

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
                    <h3>{g.name}</h3>
                </div>
            ))}
        </article>
        </>
    )
}