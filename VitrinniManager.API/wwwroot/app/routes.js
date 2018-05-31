(function () {
    'use strict'
    angular.module('vitrinni_manager').config(function ($routeProvider) {

        $routeProvider.when('/', {
            controller: 'HomeController',
            controllerAs: 'vm',
            templateUrl: 'wwwroot/pages/home/home.html'
        }).when('/login', {
            controller: 'LoginController',
            controllerAs: 'vm',
            templateUrl: 'wwwroot/pages/conta/login.html',
        }).when('/logout', {
            controller: 'LogoutController',
            controllerAs: 'vm',
            templateUrl: 'wwwroot/pages/conta/login.html'
        }).when('/loja/minha-loja', {
            controller: 'LojaController',
            controllerAs: 'vm',
            templateUrl: 'wwwroot/pages/loja/minha-loja.html'
        })
    });
})()