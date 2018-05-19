import React, { Component } from 'react';
import AuthManager from '../Managers/AuthManager';

class AuthenticatedPage extends Component {
    constructor(props) {
        super(props);

        var auth = AuthManager.getInstance();
        if (!auth.isAuthenticated) {
            this.props.history.push("/Login");
        }
    }
}

export default AuthenticatedPage;