import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserRegisterPreferences from "./users/UserRegisterPreferences";
import GameCatalog from "./games/GameCatalog";
import PlatformList from "./platforns/PlatformList";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <p>Digital Dungeon</p>
            </AuthorizedRoute>
          }
        />
        <Route path="games">
          <Route index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GameCatalog />
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
          path="initialpreferences"
          element={
          <UserRegisterPreferences setLoggedInUser={setLoggedInUser}/>}
          />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
