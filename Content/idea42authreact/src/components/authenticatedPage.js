import { Component } from 'react';
import AuthManager from '../managers/authManager';
import Config from '../config'

class AuthenticatedPage extends Component {

    constructor(props) {
        super(props);

        this.authSubscriptionHandler = this.authSubscriptionHandler.bind(this);

        this.auth = AuthManager.getInstance();
        this.authSubscriptionHandler();
    }

    componentDidMount() {
        this.auth.subscribe(this.authSubscriptionHandler)
    }

    componentWillUnmount() {
        this.auth.unsubscribe(this.authSubscriptionHandler)
    }

    authSubscriptionHandler() {
        if (!this.auth.isAuthenticated) {
            this.props.history.push(Config.loginRoute);
        }
    }
}

export default AuthenticatedPage;
