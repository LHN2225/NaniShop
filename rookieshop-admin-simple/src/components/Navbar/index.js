import React, { Component } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../index";
import "./Navbar.css";

export default class Navbar extends Component {
  state = {
    username: "Tuan",
  };

  render() {
    return (
      <UserContext.Consumer>
        {(value) => (
          <nav id="navbar">
            <ul>
              <Link to="/">
                <li>Home</li>
              </Link>
              <Link to="/category">
                <li>Category</li>
              </Link>
            </ul>

            {/*<input type="text" onChange={(e) => this.props.onSearchKey(e)} />*/}
          </nav>
        )}
      </UserContext.Consumer>
    );
  }
}
