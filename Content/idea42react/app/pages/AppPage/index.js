﻿import React, { Component } from 'react';
import { Route } from 'react-router-dom';

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

class AppPage extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div style={style.container}>
                <div style={style.child} >
                    Welcome to ReactJS!
                </div>
            </div>
        );
    }
}

export default AppPage;