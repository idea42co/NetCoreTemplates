(function () {
    'use strict';

    angular.module('angularSPA').controller('homeController', HomeController);

    HomeController.$inject = [];

    function HomeController() {
        var vm = this;

        vm.welcomeMessage = "";

        init();

        ////////////

        function init() {
            vm.welcomeMessage = "Welcome to AngularJS!";
        }
    }
})();