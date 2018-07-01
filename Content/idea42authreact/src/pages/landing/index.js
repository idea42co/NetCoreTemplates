import React from 'react';
import { Link } from 'react-router-dom';
import logo from './logo.svg';
import AuthenticatedPage from '../../components/authenticatedPage';
import AuthManager from '../../managers/authManager';
import './style.css';

class LandingPage extends AuthenticatedPage {

    logOut() {
        AuthManager.getInstance().logOut();
    }

    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <h1 className="App-title">Welcome to React</h1>
                </header>
                <p className="App-intro">
                    You are not authenticated! To log out, <a onClick={this.logOut} href='javascript:void(0);'>click here!</a>
                    <br /><br />
                    To get started, edit <code>src/App.js</code> and save to reload.
                    <br /><br />
                    To test out React Router, <Link to="/newRoute">click here to go to a new route!</Link>
                </p>
            </div>
        );
    }
}

export default LandingPage;
