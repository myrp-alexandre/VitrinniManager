((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', 'LoginFactory','LojaFactory', '$rootScope', 'SETTINGS', '$location'];

    function LoginController($scope, LoginFactory, LojaFactory, $rootScope, SETTINGS, $location) {
        var vm = this;

        vm.login = {
            email: '',
            senha: ''
        };

        vm.autenticar = autenticar;
        vm.obterLoja = obterLoja;

        function autenticar() {
            LoginFactory.autenticar(vm.login)
                .then(function (response) {
                    obterLoja(response.data.access_token);
                })
                .catch(function (error) {
                    toastr.error(error.data.error_description, 'Erro');
                });
        }

        function obterLoja(token) {
            LojaFactory.obterLoja(token)
                .then(function (response) {
                    $rootScope.token = token;
                    $rootScope.token_loja = response.data.tokenLoja;

                    localStorage.setItem(SETTINGS.AUTH_TOKEN, token);
                    localStorage.setItem(SETTINGS.USER_NAME, response.data.emailLoja);
                    localStorage.setItem(SETTINGS.USER_ID, response.data.tokenLoja);
                    $location.path('/');
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

    };
}))();