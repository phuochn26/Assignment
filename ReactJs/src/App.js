import React, { useState } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import PostPage from "./pages/PostPage";
import ProfilePage from "./pages/ProfilePage"
import PostDetailPage from "./pages/PostDetailPage"
import RegisterPage from "./pages/RegisterPage";

const App = () => {
  const [currentUser, setCurrentUser] = useState({
    token: null,
    userId: null
  })
  const handleOnClick = () => {
    setCurrentUser({
      token: null,
      userId: null
    })
  }
  return (
    <Router>
      {
        currentUser.token == null && currentUser.userId == null ?
          <div>
            <ul>
              <Link style={{ marginRight: '15px' }} to="/home">Home</Link>
              <Link style={{ marginRight: '15px' }} to="/post">Posts</Link>
              <Link style={{ marginRight: '15px' }} to="/login">Profile</Link>
              <Link style={{ marginRight: '15px' }} to="/login">Login</Link>
              <Link style={{ marginRight: '15px' }} to="/register">Register</Link>
            </ul>
          </div>
          :
          <div>
            <ul>
              <Link style={{ marginRight: '15px' }} to="/home">Home</Link>
              <Link style={{ marginRight: '15px' }} to="/post">Posts</Link>
              <Link style={{ marginRight: '15px' }} to="/profile">Profile</Link>
              <button onClick={handleOnClick}>Log out</button>
            </ul>
          </div>
      }

      <Switch>
        <Route path="/home">
          <HomePage />
        </Route>
        <Route path="/post" exact>
          <PostPage />
        </Route>
        <Route path="/post/:id">
          <PostDetailPage />
        </Route>
        <Route path="/profile">
          <ProfilePage
            currentUser={currentUser}
          />
        </Route>
        <Route path="/login" exact>
          <LoginPage
            currentUser={currentUser}
            setCurrentUser={setCurrentUser}
          />
        </Route>
        <Route path="/register">
          <RegisterPage />
        </Route>
        <Route exact path="/">
          <HomePage />
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
