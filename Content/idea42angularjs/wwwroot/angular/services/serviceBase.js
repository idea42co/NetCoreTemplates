(function(){
    'use strict';

    angular.module('angularSPA').controller('serviceBase', ServiceBase);

    ServiceBase.$inject = [];

    function ServiceBase($http, $rootScope){

        var service = {};

        service.jsonRequest = jsonRequest;
        service.formRequest = formRequest;
        service.multiPartRequest = multiPartRequest;

        return service; 

        ////////////

        function jsonRequest(url, requestType, data, baseUrl) {
            if (!baseUrl)
                baseUrl = angularAppConfig.BaseApiUrl;

            return $http({
                method: requestType,
                url: baseUrl + url,
                headers: {
                    'content-type': "application/json"
                },
                data: data
            });
        }

        function formRequest(url, requestType, data, baseUrl) {
            if (!baseUrl)
                baseUrl = angularAppConfig.BaseApiUrl;

            return $http({
                method: requestType,
                url: baseUrl + url,
                headers: {
                    'Content-Type': "application/x-www-form-urlencoded"
                },
                data: data
            });
        }

        function multiPartRequest(url, data, baseUrl) {
            if (!baseUrl)
                baseUrl = angularAppConfig.BaseApiUrl;
                
            var fd = new FormData();
            fd.append("file", data);
            return $http.post(baseUrl + url, fd, {
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined,
                    'X-Requested-With': "XMLHttpRequest"
                }
            });
        }
    }
})();