import { useEffect, useState } from "react";
import { getAllPlatforms } from "../../managers/platformManager";
import { Link } from "react-router-dom";

export default function PlatformList() {
    const [platforms, setPlatforms] = useState([]);

    useEffect(() => {
        getAllPlatforms().then(setPlatforms);
    }, []);

    return (
        <>
        <h2>Platforms</h2>
        <article className="platforms">
            {platforms.map((p) => (
                <div key={`platform-${p.id}`}>
                    <img src={p.image} alt={p.image} />
                    <Link to={`${p.id}`}>
                    <h3>{p.name}</h3>
                    </Link>
                </div>
            ))}
        </article>
        </>
    )
}