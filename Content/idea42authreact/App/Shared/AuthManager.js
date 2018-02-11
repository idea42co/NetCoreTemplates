class AuthManager {
    static instance;
    static createInstance() {
        var object = new AuthManager();
        return object;
    }

    static getInstance() {
        if (!AuthManager.instance) {
            AuthManager.instance = AuthManager.createInstance();
        }
        return AuthManager.instance;
    }

    constructor() {
        this.isAuthenticated = true;
    }
}

export default AuthManager;