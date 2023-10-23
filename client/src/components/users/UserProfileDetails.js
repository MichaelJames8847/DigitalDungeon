import { useEffect, useState } from "react";
import { getUserById } from "../../managers/userProfileManager";
import { Card, CardBody, CardTitle } from "reactstrap";
import { useParams } from "react-router-dom";

export default function UserProfileDetails() {
    const [userProfile, setUserProfile] = useState([]);
    const { id } = useParams();

    useEffect(() => {
        getUserById(id).then(setUserProfile)
    }, [id])

    return (
        <>
        <h2>User Details</h2>
        <Card>
            <CardBody>
                <CardTitle tag="h4">{userProfile.firstName} {userProfile.lastName}</CardTitle>
                <p>Address: {userProfile.address}</p>
                <p>Email: {userProfile.identityUser?.email}</p>
                <p>Username: {userProfile.identityUser?.userName}</p>
            </CardBody>
        </Card>
        </>
    )
}