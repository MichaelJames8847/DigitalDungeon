import { useEffect, useState } from "react";
import { Link, NavLink as RRNavLink } from "react-router-dom";
import {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import { fetchPendingGames } from "../managers/gameManager";


export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [open, setOpen] = useState(false);
    const [pendingGames, setPendingGames] = useState([]);

    useEffect(() => {
        if (loggedInUser && loggedInUser.roles.includes("Admin")) {
            fetchPendingGames().then(setPendingGames);
        }
    }, [loggedInUser])

    const toggleNavbar = () => setOpen(!open);

    return (
        <div>
            <Navbar color="light" light fixed="true" expand="lg">
                <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
                    {`\u{1F3AE}`} DigitalDungeon {`\u{1F3AE}`}
                </NavbarBrand>
                {loggedInUser ? (
                    <>
                        <NavbarToggler onClick={toggleNavbar} />
                        <Collapse isOpen={open} navbar>
                            <Nav navbar>
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/games">
                                        Game Catalog
                                    </NavLink>
                                </NavItem>
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/games/search">
                                        Game Search
                                    </NavLink>
                                </NavItem>
                                <NavItem onClick={() => setOpen(false)} />
                                <NavLink tag={RRNavLink} to="/platforms">
                                    Platforms
                                </NavLink>
                                <NavItem onClick={() => setOpen(false)} />
                                <NavLink tag={RRNavLink} to="/userprofile/suggestions">
                                    My Games
                                </NavLink>
                                <NavItem onClick={() => setOpen(false)} />
                                <NavLink tag={RRNavLink} to="/userprofile/preferences">
                                    Edit Preferences
                                </NavLink>
                                <NavItem onClick={() => setOpen(false)} />
                                <NavLink tag={RRNavLink} to="/games/submit-game-request">
                                    Submit Game Request
                                </NavLink>
                                {loggedInUser.roles.includes("Admin") && (
                                    <NavItem onClick={() => setOpen(false)}>
                                        <NavLink tag={RRNavLink} to="/games/approve">
                                            Approve Games
                                        </NavLink>
                                    </NavItem>
                                )}
                                {loggedInUser.roles.includes("Admin") && (
                                    <NavItem onClick={() => setOpen(false)}>
                                        <NavLink tag={RRNavLink} to="/userprofile">
                                            Users
                                        </NavLink>
                                    </NavItem>
                                )}
                            </Nav>
                        </Collapse>
                        <Button
                            color="primary"
                            onClick={(e) => {
                                e.preventDefault();
                                setOpen(false);
                                logout().then(() => {
                                    setLoggedInUser(null);
                                    setOpen(false);
                                });
                            }}
                        >
                            Logout
                        </Button>
                    </>
                ) : (
                    <Nav navbar>
                        <NavItem>
                            <NavLink tag={RRNavLink} to="/login">
                                <Button color="primary">Login</Button>
                            </NavLink>
                        </NavItem>
                    </Nav>
                )}
            </Navbar>
        </div>
    );
}