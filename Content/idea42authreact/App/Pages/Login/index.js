import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import AuthManager from '../../Managers/AuthManager';

const style = {
    container: {
        height: '100vh',
        width: '100%',
        position: 'relative'
    },
    child: {
        position: 'absolute',
        top: '50%',
        left: '44%'
    }
}

class HomePage extends Component {
    constructor(props) {
        super(props);

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        var auth = AuthManager.getInstance();

        auth.isAuthenticated = true;
        auth.notifySubscribers();

        this.props.history.push("/");
    }

    render() {
        return (
            <div style={style.container}>
                <div style={style.child} >
                    Welcome to ReactJS!<br />
                    <input type="button" value="Log In" onClick={this.handleClick} />
                </div>
            </div>
        );
    }
}

export default HomePage;