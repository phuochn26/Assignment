import React from "react";
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

function App() {
  return (
    <Router>
      <div>
        <ul>
            <Link style= { { marginRight: '15px' } } to="/home">Home</Link>
            <Link style= { { marginRight: '15px' } } to="/post">Posts</Link>
            <Link style= { { marginRight: '15px' } } to="/profile">Profile</Link>
            <Link style= { { marginRight: '15px' } } to="/login">Login</Link>
        </ul>
      </div>
      <Switch>
          <Route path="/home">
            <HomePage/>
          </Route>
          <Route path="/post" exact>
            <PostPage />
          </Route>
          <Route path="/post/:id">
            <PostDetailPage />
          </Route>
          <Route path="/profile">
            <ProfilePage />
          </Route>
          <Route path="/login">
            <LoginPage/>
          </Route>
          <Route exact path="/">
            <HomePage />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
