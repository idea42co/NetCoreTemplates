import AuthManager from '../managers/authManager';
import Config from '../config'

export default class BaseService {

    jsonRequest(url, method, data, baseUrl) {
        var self = this;

        self.baseApiUrl = baseUrl ? baseUrl : Config.api.baseUrl;
        return new Promise(function (resolve, reject) {
            var headers = {
                'Content-Type': 'application/json'
            }

            var auth = AuthManager.getInstance();
            var accessToken = auth.bearerToken;
            if (accessToken)
                headers['Authorization'] = 'Bearer ' + accessToken;

            fetch(self.baseApiUrl + url, {
                method: method.toUpperCase(),
                headers: headers,
                body: data ? JSON.stringify(data) : null
            }).then(function (success) {
                if (success.ok && success.ok === true) {
                    success.json().then(function (jsonSuccess) {
                        resolve(jsonSuccess);
                    }, function (jsonError) {
                        reject(jsonError);
                    });
                }
                else {
                    reject(success);
                }
            }, function (error) {
                reject(error);
            })


        });
    }

    formRequest(url, method, data, baseUrl) {
        var self = this;
        self.baseApiUrl = baseUrl ? baseUrl : Config.api.baseUrl;

        var formBody = [];
        for (var property in data) {
            var encodedKey = encodeURIComponent(property);
            var encodedValue = encodeURIComponent(data[property]);
            formBody.push(encodedKey + "=" + encodedValue);
        }

        return new Promise(function (resolve, reject) {
            var headers = {
                'Content-Type': 'application/json'
            }

            var auth = AuthManager.getInstance();
            var accessToken = auth.bearerToken;
            if (accessToken)
                headers['Authorization'] = 'Bearer ' + accessToken;

            fetch(self.baseApiUrl + url, {
                method: method.toUpperCase(),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: formBody ? formBody.join("&") : null
            }).then(function (success) {
                if (success.ok && success.ok === true) {
                    success.json().then(function (data) {
                        resolve(data);
                    });
                }
                else {
                    success.json().then(function (data) {
                        reject(data);
                    });
                }
            }, function (error) {
                reject(error);
            })
        });
    }
};