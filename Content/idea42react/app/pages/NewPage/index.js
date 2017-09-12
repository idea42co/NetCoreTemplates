import React, { Component } from 'react';
import { Link } from 'react-router-dom';

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
        return (
            <div style={style.container}>
                <div style={style.child} >
                    Welcome to a new page! <br />
                    <Link to="/">Go back home!</Link>
                </div>
            </div>
        );
    }
}

export default NewPage;