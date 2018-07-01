import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import './index.css';

import registerServiceWorker from './registerServiceWorker';

import LandingPage from './pages/landing';
import NewRoutePage from './pages/newRoute';

ReactDOM.render(
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={LandingPage} />
            <Route path="/newRoute" component={NewRoutePage} />
        </Switch>
    </BrowserRouter>, document.getElementById('root'));
registerServiceWorker();
