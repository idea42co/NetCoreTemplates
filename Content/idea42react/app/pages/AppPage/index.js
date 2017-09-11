import React, { Component } from 'react';
import { Route } from 'react-router-dom';

class AppPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            AuthenticatedUser: null
        };

        this.UpdateAuthorizedUser = this.UpdateAuthorizedUser.bind(this);
    }

    UpdateAuthorizedUser(user) {
        this.setState({ AuthenticatedUser: user });
    }

    render() {
        return (
            <div>
                Welcome to ReactJS!
            </div>
        );
    }
}

export default AppPage;