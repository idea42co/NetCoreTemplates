import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import './index.css';

import registerServiceWorker from './registerServiceWorker';

import LandingPage from './pages/landing';
import NewRoutePage from './pages/newRoute';
import LoginPage from './pages/login';

ReactDOM.render(
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={LandingPage} />
            <Route path="/newRoute" component={NewRoutePage} />
            <Route exact path="/login" component={LoginPage} />
        </Switch>
    </BrowserRouter>, document.getElementById('root'));
registerServiceWorker();
