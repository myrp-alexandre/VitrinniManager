((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('HomeController', HomeController);
    HomeController.$inject = ['$scope', '$rootScope', 'SETTINGS', '$location'];

    function HomeController($scope, $rootScope, SETTINGS, $location) {
        var vm = this;
    };
}))();