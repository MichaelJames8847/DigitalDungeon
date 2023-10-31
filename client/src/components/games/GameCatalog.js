import { useEffect, useState } from "react";
import { deleteGame, getGames } from "../../managers/gameManager";
import { Link } from "react-router-dom";
import { Container, Row, Col, Button, Card, CardImg, CardBody, CardTitle } from 'reactstrap';
import "./GameCatalog.css"

export default function GameCatalog({ loggedInUser }) {
    const [games, setGames] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [isLoading, setIsLoading] = useState(true);
    const gamesPerPage = 10;

    useEffect(() => {
        setIsLoading(true);
        getGames()
            .then(setGames)
            .catch(error => {
                console.error("Error fetching games:", error)
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, [currentPage])

    const indexOfLastGame = currentPage * gamesPerPage;
    const indexOfFirstGame = indexOfLastGame - gamesPerPage;
    const currentGames = games.slice(indexOfFirstGame, indexOfLastGame);

    const totalPages = Math.ceil(games.length / gamesPerPage);

    const handleNextPage = () => {
        if (currentPage < totalPages) {
            setCurrentPage(prevPage => prevPage + 1);
        }
    };

    const handlePrevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(prevPage => prevPage - 1);
        }
    }

    const removeGame = (gameId) => {
        deleteGame(gameId).then(() => {
            getGames().then(setGames)
        })
    }

    return (
        <div className="game-catalog">
            <Container className="mt-4">
                <h2 className="text-center text-success">Game Catalog</h2>
                <div className="d-flex justify-content-center mt-4">
                    <Button onClick={handlePrevPage} disabled={currentPage === 1} className="me-3">Previous</Button>
                    <span className="align-self-center">Page {currentPage} of {totalPages}</span>
                    <Button onClick={handleNextPage} disabled={currentPage === totalPages} className="ms-3">Next</Button>
                </div>
                {isLoading ? (
                    <div className="text-center">Loading...</div>
                ) : (
                    <>
                        <Row>
                            {currentGames.map((g) => (
                                <Col key={`game-${g.id}`} sm={6} md={4} lg={5} className="mb-4">
                                    <Card>
                                        <CardImg top className="custom-card-img" src={g.background_image} alt={g.name} />
                                        <CardBody>
                                            <CardTitle tag="h5">
                                                <Link to={`${g.id}`} className="text-success">
                                                    {g.name}
                                                </Link>
                                                {loggedInUser.roles.includes("Admin") ? (
                                                    <td>
                                                        <Button onClick={() => removeGame(g.id)}
                                                            color="danger">
                                                            Remove Game
                                                        </Button>
                                                    </td>
                                                ) : null}
                                            </CardTitle>
                                        </CardBody>
                                    </Card>
                                </Col>
                            ))}
                        </Row>
                        <div className="d-flex justify-content-center mt-4">
                            <Button onClick={handlePrevPage} disabled={currentPage === 1} className="me-3">Previous</Button>
                            <span className="align-self-center">Page {currentPage} of {totalPages}</span>
                            <Button onClick={handleNextPage} disabled={currentPage === totalPages} className="ms-3">Next</Button>
                        </div>
                    </>
                )}
            </Container>
        </div>
    );
}
