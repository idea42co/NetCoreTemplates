import Base from './baseService';
import Config from '../config'

class AuthService extends Base {
    constructor() {
        super();
    }

    authenticate(username, password) {
        return this.formRequest('', 'POST', {
            username: username,
            password: password,
            grant_type: 'password'
        }, Config.api.baseUrl.replace('/api/', '/token'));
    }
};

export default AuthService;