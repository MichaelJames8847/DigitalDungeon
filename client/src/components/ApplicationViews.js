import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserRegisterPreferences from "./users/UserRegisterPreferences";
import GameCatalog from "./games/GameCatalog";
import PlatformList from "./platforns/PlatformList";
import GameDetails from "./games/GameDetails";
import PlatformDetails from "./platforns/PlatformDetails";
import UserProfileList from "./users/UserProfileList";
import Home from "./Home";
import UserGamesList from "./users/UserGamesList";
import UserProfileDetails from "./users/UserProfileDetails";
import UserEditPreferences from "./users/UserEditPreferences";
import GameSearch from "./games/GameSearch";
import GameSuggestion from "./games/GameSuggestion";
import AdminGameForm from "./games/AdminGameForm";
import UserNotifications from "./users/UserNotifications";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home />
            </AuthorizedRoute>
          }
        />
        <Route path="userprofile">
          <Route index
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <UserProfileList />
            </AuthorizedRoute>
          }
          />
          <Route path="suggestions"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <UserGamesList />
            </AuthorizedRoute>
          }
          />
          <Route path=":id"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <UserProfileDetails />
            </AuthorizedRoute>
          }
          />
          <Route path="preferences"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <UserEditPreferences />
            </AuthorizedRoute>
          }
          />
          <Route path="notifications"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <UserNotifications />
            </AuthorizedRoute>
          }
          />
        </Route>
        <Route path="games">
          <Route index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GameCatalog />
            </AuthorizedRoute>
          }
          />
              <Route path="submit-game-request"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <GameSuggestion />
                </AuthorizedRoute>
              }
              />
          <Route path=":id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GameDetails />
            </AuthorizedRoute>
          }
          />
          <Route path="search"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GameSearch />
            </AuthorizedRoute>
          }
          />
        </Route>
        <Route path="platforms">
          <Route index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PlatformList />
            </AuthorizedRoute>
          }
          />
          <Route path=":id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PlatformDetails />
            </AuthorizedRoute>
          }
          />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route 
          path="initialPreferences"
          element={
          <UserRegisterPreferences setLoggedInUser={setLoggedInUser}/>}
          />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
