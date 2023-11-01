import React, { useEffect, useState } from 'react';
import { Button, Card, CardBody, CardDeck, CardImg, CardText, CardTitle, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { getGamesBasedOnPreferences, getPurchaseLinks, removeGameFromSuggestions } from '../../managers/userProfileManager';
import "./UserGamesList.css"

export default function UserGamesList() {
  const [suggestedGames, setSuggestedGames] = useState([]);
  const [purchaseLinks, setPurchaseLinks] = useState({});
  const [dropdownOpen, setDropdownOpen] = useState({});
  const [error, setError] = useState(null);

  useEffect(() => {
    getGamesBasedOnPreferences()
      .then(games => {
        const gamesWithRatings = games.map(game => ({
          ...game,
          rating: Math.floor(Math.random() * 5) + 1  // assigning random rating from 1 to 5
        }));
        setSuggestedGames(gamesWithRatings);
      })
      .catch((error) => {
        console.error("Error fetching games based on preferences", error);
        setError("An error occurred while fetching games based on preferences");
      });

    getPurchaseLinks()
      .then(setPurchaseLinks)
      .catch((error) => {
        console.error("Error fetching purchase links", error);
        setError("An error occurred while fetching purchase links");
      });
  }, []);

  const handleBuyNowClick = (platformUrl) => {
    window.open(platformUrl, '_blank');
  };

  const removeSuggestedGame = (gameId) => {
    removeGameFromSuggestions(gameId).then(() => {
      setSuggestedGames(suggestedGames.filter(game => game.id !== gameId));
    });
  };

  const toggleDropdown = (gameId) => {
    setDropdownOpen(prevState => ({
      ...prevState,
      [gameId]: !prevState[gameId]
    }));
  };

  const setGameRating = (gameId, rating) => {
    const updatedGames = suggestedGames.map(game => {
      if (game.id === gameId) {
        game.rating = rating;
      }
      return game;
    });
    setSuggestedGames(updatedGames);
  };



  return (
    <>
      <div className='user-games-list'>
        {error && <div className="error-message">{error}</div>}
        <CardDeck>
          {suggestedGames.map((game) => (
            <Card key={game.id}>
              <CardImg top width="100%" src={game.coverImage} alt={game.title} />
              <CardBody>
                <CardTitle tag="h5">{game.title}</CardTitle>
                <CardText>{game.description}</CardText>
                <div className="rating">
                  My Rating:
                  {Array(5).fill().map((_, index) => (
                    <span
                      key={index}
                      className={`controller ${game.rating > index ? 'selected' : ''}`}
                      onClick={() => setGameRating(game.id, index + 1)}
                    > 
                     🎮
                    </span>
                  ))}
                </div>
                {purchaseLinks && (
                  <Dropdown isOpen={dropdownOpen[game.id]} toggle={() => toggleDropdown(game.id)}>
                    <DropdownToggle caret color="primary">
                      Buy Now
                    </DropdownToggle>
                    <DropdownMenu>
                      {Object.entries(purchaseLinks).map(([platform, url]) => (
                        <DropdownItem key={platform} onClick={() => handleBuyNowClick(url)}>
                          {platform.replace(/([A-Z])/g, ' $1').trim()}
                        </DropdownItem>
                      ))}
                    </DropdownMenu>
                  </Dropdown>
                )}
                <Button color="secondary" onClick={() => removeSuggestedGame(game.id)}>
                  Remove From Suggestions
                </Button>
              </CardBody>
            </Card>
          ))}
        </CardDeck>
      </div>
    </>
  );
}
