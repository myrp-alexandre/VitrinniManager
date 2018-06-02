((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('RecuperarSenhaController', RecuperarSenhaController);

    RecuperarSenhaController.$inject = ['$location', '$rootScope', '$routeParams', 'RecuperarSenhaFactory'];

    function RecuperarSenhaController($location, $rootScope, $routeParams, RecuperarSenhaFactory) {
        var vm = this;
        vm.recovery = {
            password: ''
        }

        function recoveryPassword() {
            RecuperarSenhaFactory.recuperarSenha(vm.recovery)
                .then(function (response) {
                    toastr.success('Senha alterada com sucesso', 'Senha alterada!');
                    $location.path('/login');
                })
                .catch(function (error) {
                    if (error.status == 404)
                        toastr.error('Usuário não encontrado', 'Erro');
                    else
                        toastr.error(error.data.Message, 'Erro');
                });
        }
    };
}))();