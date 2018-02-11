import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import AuthManager from '../../Shared/AuthManager';

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

class NewPage extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        var auth = AuthManager.getInstance();
        
        return (
            <div style={style.container}>
                <div style={style.child} >
                    Authenticated? {auth.isAuthenticated ? "Yes":"No"} <br />
                    Welcome to a new page! <br />
                    <Link to="/">Go back home!</Link>
                </div>
            </div>
        );
    }
}

export default NewPage;