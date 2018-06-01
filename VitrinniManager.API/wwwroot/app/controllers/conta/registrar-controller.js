((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('RegistrarController', RegistrarController);

    RegistrarController.$inject = ['$scope', 'LoginFactory', 'LojaFactory', 'RegistrarFactory', '$rootScope', 'SETTINGS', '$location'];

    function RegistrarController($scope, LoginFactory, LojaFactory, RegistrarFactory, $rootScope, SETTINGS, $location) {
        var vm = this;

        vm.registro = {
            CPFCNPJ: '',
            emailLoja: '',
            senhaLoja: '',
            confirma_senha: '',
        };

        vm.login = {
            email: '',
            senha: ''
        };

        vm.registrar = registrar;


        function registrar(registro) {
            RegistrarFactory.registrar(registro)
                .then(function (response) {

                    vm.login.email = response.data.emailLoja;
                    vm.login.senha = response.data.senhaLoja;

                    LoginFactory.autenticar(vm.login)
                        .then(function (response) {
                            obterLoja(response.data.access_token);
                        })
                        .catch(function (error) {
                            toastr.error(error.data.error_description, 'Erro');
                        });

                })
                .catch(function (error) {
                    toastr.warning(error.data, 'Atenção');
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