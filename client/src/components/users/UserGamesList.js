import React, { useEffect, useState } from 'react';
import { Button, Card, CardBody, CardDeck, CardImg, CardText, CardTitle, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { getGamesBasedOnPreferences, getPurchaseLinks, removeGameFromSuggestions } from '../../managers/userProfileManager';

export default function UserGamesList() {
  const [suggestedGames, setSuggestedGames] = useState([]);
  const [purchaseLinks, setPurchaseLinks] = useState({});
  const [dropdownOpen, setDropdownOpen] = useState({});
  const [error, setError] = useState(null);

  useEffect(() => {
    getGamesBasedOnPreferences()
      .then(setSuggestedGames)
      .catch((error) => {
        console.error("Error fetching games based on preferences", error);
        setError("An error occurred while fetching games based on preferences");
      });

    // Fetch purchase links once when the component mounts
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

  return (
    <>
      {error && <div className="error-message">{error}</div>}
      <CardDeck>
        {suggestedGames.map((game) => (
          <Card key={game.id}>
            <CardImg top width="100%" src={game.coverImage} alt={game.title} />
            <CardBody>
              <CardTitle tag="h5">{game.title}</CardTitle>
              <CardText>{game.description}</CardText>
              {purchaseLinks && (
                <Dropdown isOpen={dropdownOpen[game.id]} toggle={() => toggleDropdown(game.id)}>
                  <DropdownToggle caret color="primary">
                    Buy Now
                  </DropdownToggle>
                  <DropdownMenu>
                    {Object.entries(purchaseLinks).map(([platform, url]) => (
                      <DropdownItem key={platform} onClick={() => handleBuyNowClick(url)}>
                        {platform.replace(/([A-Z])/g, ' $1').trim()} {/* Adds space before capital letters */}
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
    </>
  );
}
