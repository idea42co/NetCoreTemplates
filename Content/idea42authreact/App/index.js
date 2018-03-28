import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';

import './index.css';

import HomePage from './Pages/Home';
import LoginPage from './Pages/Login';

ReactDOM.render(
    <BrowserRouter>
        <Switch>
            <Route exact path="/Login" component={LoginPage} />
            <Route exact path="/" component={HomePage} />
        </Switch>
    </BrowserRouter>,
    document.getElementById('root')
);