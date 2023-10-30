import { useEffect, useState } from "react";
import { deleteUser, demoteUser, getUserProfilesWithRoles, promoteUser } from "../../managers/userProfileManager";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import "./UserProfileList.css"

export default function UserProfileList() {
    const [userProfiles, setUserProfiles] = useState([])

    useEffect(() => {
        getUserProfilesWithRoles().then(setUserProfiles)
    }, []);

    const removeUser = (userId) => {
        deleteUser(userId).then(() => {
            getUserProfilesWithRoles().then(setUserProfiles)
        });
    };

    const promote = (id) => {
        promoteUser(id).then(() => {
            getUserProfilesWithRoles().then(setUserProfiles);
        });
    };

    const demote = (id) => {
        demoteUser(id).then(() => {
            getUserProfilesWithRoles().then(setUserProfiles);
        });
    };

    return (
        <>
        <div className="user-profile-list">
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
                            <td>
                                {up.roles && up.roles.includes("Admin") ? (
                                    <Button
                                        color="danger"
                                        onClick={() => {
                                            demote(up.identityUserId);
                                        }}>
                                        Demote
                                    </Button>
                                ) : (
                                    <Button
                                        color="success"
                                        onClick={() => {
                                            promote(up.identityUserId);
                                        }}>
                                        Promote
                                    </Button>
                                )}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            </div>
        </>
    )
}