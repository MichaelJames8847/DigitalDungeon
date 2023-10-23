import { useEffect, useState } from "react";
import { deleteUser, getUserProfilesWithRoles } from "../../managers/userProfileManager";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";

export default function UserProfileList() {
    const [userProfiles, setUserProfiles] = useState([])

    useEffect(() => {
        getUserProfilesWithRoles().then(setUserProfiles)
    }, []);

    const removeUser = (userId) => {
        deleteUser(userId).then(() => {
            getUserProfilesWithRoles().then(setUserProfiles)
        })
    }

    return (
        <>
            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Address</th>
                        <th>UserName</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    {userProfiles.map((up) => (
                        <tr key={up.id}>
                            <th scope="row">{`${up.firstName} ${up.lastName}`}</th>
                            <td>{up.address}</td>
                            <td>{up.userName}</td>
                            <td>{up.email}</td>
                            <td>
                                <Link to={`${up.id}`}>Details</Link>
                            </td>
                            <td>
                                <Button
                                    onClick={() => removeUser(up.id)}
                                    color="danger">
                                    Remove User
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </>
    )
}