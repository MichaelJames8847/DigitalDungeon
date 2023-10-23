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
        </Route>
        <Route path="games">
          <Route index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GameCatalog />
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
