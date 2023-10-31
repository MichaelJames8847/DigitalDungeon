import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { denyGame, fetchPendingGames, updateGameDetails } from '../../managers/gameManager';
import { getGenres } from '../../managers/genreManager';
import { getCategories } from '../../managers/categoryManager';
import "./AdminGameApproval.css"
import { getAllPlatforms } from '../../managers/platformManager';

export default function AdminGameApproval() {
  const navigate = useNavigate();
  const [pendingGames, setPendingGames] = useState([]);
  const [genres, setGenres] = useState([]);
  const [categories, setCategories] = useState([]);
  const [platforms, setPlatforms] = useState([]);
  const [selectedGame, setSelectedGame] = useState(null);
  const [gameDetails, setGameDetails] = useState({
    background_image: '',
    description: '',
    released: '',
    developer: '',
    genreId: '',
    categoryId: '',
    platforms: []
  });

  useEffect(() => {
    fetchPendingGames().then(setPendingGames);
    getGenres().then(setGenres);
    getCategories().then(setCategories);
    getAllPlatforms().then(setPlatforms)
  }, []);

  const handlePlatformChange = (platformId) => {
    setGameDetails((prevDetails) => ({
      ...prevDetails,
      platforms: prevDetails.platforms.includes(platformId)
        ? prevDetails.platforms.filter((id) => id !== platformId)
        : [...prevDetails.platforms, platformId],
    }));
  };

  const handleSelectGame = (game) => {
    setSelectedGame(game);
    setGameDetails({
      background_image: game.background_image || '',
      description: game.description || '',
      released: game.released || '',
      developer: game.developer || '',
      genreId: game.genreId,
      categoryId: game.categoryId,
      platforms: game.platforms ? game.platforms.map((platform) => platform.id) : [], // Assuming 'platforms' is an array of platform objects
    });
  };

  const handleChange = (e) => {
    setGameDetails({
      ...gameDetails,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    updateGameDetails(selectedGame.id, gameDetails).then(() => {
      alert('Game details updated and approved!');
      setPendingGames(pendingGames.filter(game => game.id !== selectedGame.id));
      navigate('/games');
    });
  };

  const handleDeny = (gameId) => {
    denyGame(gameId).then(() => {
      alert('Game denied');
      setPendingGames(pendingGames.filter(game => game.id !== gameId));
    });
  };

  if (pendingGames.length === 0) return <div>Loading or no games to approve...</div>;

  return (
    <div className='admin-game-approval'>
      <h1>Admin Game Approval</h1>
      {pendingGames.map((game) => (
        <div key={game.id}>
          <h2>{game.name}</h2>
          <Button color="success" onClick={() => handleSelectGame(game)}>Select</Button>
          <Button color="danger" onClick={() => handleDeny(game.id)}>Deny</Button>
        </div>
      ))}

      {selectedGame && (
        <Form onSubmit={handleSubmit}>
          <FormGroup>
            <Label for="background_image">Cover Image URL</Label>
            <Input
              type="text"
              name="background_image"
              id="background_image"
              value={gameDetails.background_image}
              onChange={handleChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="description">Description</Label>
            <Input
              type="textarea"
              name="description"
              id="description"
              value={gameDetails.description}
              onChange={handleChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="released">Release Date</Label>
            <Input
              type="date"
              name="released"
              id="released"
              value={gameDetails.released}
              onChange={handleChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="developer">Developer</Label>
            <Input
              type="text"
              name="developer"
              id="developer"
              value={gameDetails.developer}
              onChange={handleChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="genreId">Genre</Label>
            <Input type="select" name="genreId" id='genreId' value={gameDetails.genreId} onChange={handleChange}>
              <option value="">Select a Genre</option>
              {genres.map((genre) => (
                <option key={genre.id} value={genre.id}>
                  {genre.genreName}
                </option>
              ))}
            </Input>
          </FormGroup>
          <FormGroup>
            <Label for='categoryId'>Category</Label>
            <Input type='select' name='categoryId' id='categoryId' value={gameDetails.categoryId} onChange={handleChange}>
              <option value="">Select a Category</option>
              {categories.map((category) => (
                <option key={category.id} value={category.id}>
                  {category.categoryName}
                </option>
              ))}
            </Input>
          </FormGroup>
          <FormGroup>
            <Label>Platforms</Label>
            <div>
              {platforms.map((platform) => (
                <FormGroup check key={platform.id}>
                  <Label check>
                    <Input
                      type='checkbox'
                      id={`platform-${platform.id}`}
                      value={platform.id}
                      checked={gameDetails.platforms.includes(platform.id)}
                      onChange={() => handlePlatformChange(platform.id)}
                    />
                    {platform.name}
                  </Label>
                </FormGroup>
              ))}
            </div>
          </FormGroup>
          <Button type="submit" color="primary">Update Details & Approve</Button>
        </Form>
      )}
      </div>
  );
  };

