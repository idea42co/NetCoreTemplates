import React, { Component } from 'react';
import AuthenticatedPage from '../../Components/AuthenticatedPage';
import { Link } from 'react-router-dom';
import AuthManager from '../../Managers/AuthManager';

import './Home.scss';

class HomePage extends AuthenticatedPage {
    constructor(props) {
        super(props);
    }

    render() {
        var auth = AuthManager.getInstance();

        return (
            <div className="homeContainer">
                <div className="child">
                    Authenticated? {auth.isAuthenticated ? "Yes" : "No"} <br />
                    Welcome to a new page! <br />
                    <Link to="/">Go back home!</Link>
                </div>
            </div>
        );
    }
}

export default HomePage;