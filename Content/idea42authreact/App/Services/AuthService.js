import Base from './BaseService';

class AuthService extends Base {
    constructor() {
        super();
    }

    authenticate(username, password) {
        return this.formRequest('', 'POST', {
            username: username,
            password: password,
            grant_type: 'password'
        }, reactAppSettings.BaseApiUrl.replace('/api/', '/token'));
    }
};

export default AuthService;