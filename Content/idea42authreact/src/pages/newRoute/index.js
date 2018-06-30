import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import logo from './logo.svg';
import './style.css';

class LandingPage extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          NEW ROUTE!!! 
          <br /><br />
          <Link to="/">Click here to go back!</Link>
        </p>
      </div>
    );
  }
}

export default LandingPage;
