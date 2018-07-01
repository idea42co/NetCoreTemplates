import React, { Component } from 'react';
import AuthManager from '../../managers/authManager';
import AuthService from '../../services/authService';

import './login.css';

class LoginPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            userName: "",
            password: ""
        }

        this.handleLogin = this.handleLogin.bind(this);
        this.handleFormChange = this.handleFormChange.bind(this);
    }

    handleLogin() {
        var auth = AuthManager.getInstance();
        var self = this;

        new AuthService().authenticate(this.state.userName, this.state.password).then(function (results) {
            auth.updateToken(results.access_token);
            self.props.history.push('/');

        }, function (error) {
            self.setState({ userName: "", password: "" });
            auth.logOut();
        });
    }

    handleFormChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        })
    }

    render() {
        return (
            <div className="loginContainer">
                <div className="child" >
                    Welcome to ReactJS! Please log in. <br />
                    (Default is admin, P@ssw0rd)<br />
                    <input type="text" name="userName" placeholder="User Name" onChange={this.handleFormChange} /><br />
                    <input type="password" name="password" placeholder="Password" onChange={this.handleFormChange} /><br />
                    <input type="button" value="Log In" onClick={this.handleLogin} />
                </div>
            </div>
        );
    }
}

export default LoginPage;