import React, {Component} from 'react';
import './App.css';

import { Navbar, Button } from 'react-bootstrap';
import './App.css';

class App extends Component {
    goTo(route) {
        this.props.history.replace(`/${route}`)
    }

    login() {
        this.props.auth.login();
    }

    logout() {
        this.props.auth.logout();
    }

    async checkIfLoggedIn() {
        const token = this.props.auth.getToken();
        console.info(`checkIfLoggedIn using token ${token}`);
        await fetch('http://localhost:3010/api/private', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            }
        })
            .catch(reason => console.error(reason))
            .then(value => console.info(value));
    }

    async getUserInfo() {
        const response = await this.props.auth.userinfo();
        console.log(response);
    }

    render() {
        const {isAuthenticated} = this.props.auth;

        return (
            <div>
                <Navbar fluid>
                    <Navbar.Header>
                        <Navbar.Brand>
                            <a href="#">Auth0 - React</a>
                        </Navbar.Brand>
                        <Button
                            bsStyle="primary"
                            className="btn-margin"
                            onClick={this.goTo.bind(this, 'home')}
                        >
                            Home
                        </Button>
                        {
                            !isAuthenticated() && (
                                <Button
                                    bsStyle="primary"
                                    className="btn-margin"
                                    onClick={this.login.bind(this)}
                                >
                                    Log In
                                </Button>
                            )
                        }
                        {
                            isAuthenticated() && (
                                <div>
                                    <Button
                                        bsStyle="primary"
                                        className="btn-margin"
                                        onClick={this.checkIfLoggedIn.bind(this)}
                                    >
                                        Check if logged in
                                    </Button>
                                    <Button
                                        bsStyle="primary"
                                        className="btn-margin"
                                        onClick={this.getUserInfo.bind(this)}
                                    >
                                        Get user info
                                    </Button>
                                    <Button
                                        bsStyle="primary"
                                        className="btn-margin"
                                        onClick={this.logout.bind(this)}
                                    >
                                        Log Out
                                    </Button>
                                </div>
                            )
                        }
                    </Navbar.Header>
                </Navbar>
            </div>
        );
    }

}

export default App;
