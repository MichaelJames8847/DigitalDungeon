import { useEffect, useState } from "react";
import { getAllPlatforms } from "../../managers/platformController";

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
                    <h3>{p.name}</h3>
                </div>
            ))}
        </article>
        </>
    )
}