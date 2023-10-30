import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getPlatformById } from "../../managers/platformManager";
import { Card, CardBody, CardImg, CardTitle } from "reactstrap";
import "./PlatformDetails.css"

export default function PlatformDetails() {
    const [platform, setPlatform] = useState({});
    const { id } = useParams();

    useEffect(() => {
        getPlatformById(id).then(setPlatform)
    }, [id])

    return (
        <>
        <div className="platform-details">
        <h2>Platform Details</h2>
        <Card>
            <CardBody>
                <CardTitle tag="h4">{platform.name}</CardTitle>
                <CardImg src={platform.image} />
                <p>Description: {platform.description}</p>
                <p>Year Released: {new Date(platform.releaseYear).toLocaleDateString()}</p>
                <p>Number of Games in Catalog: {platform.gamesInCatalog}</p>
                {platform.endYear && <p>Year Taken Off Market: 
                    {new Date(platform.endYear).toLocaleDateString()}</p>}
            </CardBody>
        </Card>
        </div>
        </>
    )
}