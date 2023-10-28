import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner, Container, Row, Col } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // Spinner styling
  const spinnerStyle = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    height: "100vh",
    color: "#66ff66"  // Xbox green
  };

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return (
      <div style={spinnerStyle}>
        <Spinner />
      </div>
    );
  }

  return (
    <Container fluid className="bg-dark text-white" style={{ minHeight: '100vh' }}>
      <Row>
        <Col>
          <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
        </Col>
      </Row>
      <Row>
        <Col>
          <ApplicationViews
            loggedInUser={loggedInUser}
            setLoggedInUser={setLoggedInUser}
          />
        </Col>
      </Row>
    </Container>
  );
}

export default App;
