angular.module('angularSPA', ['ngRoute']);

angular.module('angularSPA').config(AngularAppConfiguration);

AngularAppConfiguration.$inject = ['$routeProvider', '$locationProvider'];

function AngularAppConfiguration($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/angular/views/home.html',
            controller: 'homeController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/'
        });

    //Remove the need for the '#' in the URL.
    $locationProvider.html5Mode(true);
}
