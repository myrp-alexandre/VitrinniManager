(function () {
    'use strict';
    angular.module('vitrinni_manager').controller('LojaController', LojaController);

    LojaController.$inject = ['$scope', 'LojaFactory', 'EnderecoFactory', '$rootScope', 'SETTINGS', '$location'];
    function LojaController($scope, LojaFactory, EnderecoFactory, $rootScope, SETTINGS, $location) {
        var vm = this;

        vm.loja = {};
        vm.lojaAtualizar = {};

        vm.endereco = {};

        vm.obeterLoja = obeterLoja;
        vm.obterEnderecoPorCep = obterEnderecoPorCep;



        init();

        function init() {
            obeterLoja($rootScope.token);
        }

        function obterLoja(token) {
            LojaFactory.obterLoja(token)
                .then(function (response) {
                    vm.loja = response.data;
                    vm.lojaAtualizar = angular.copy(vm.loja);
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

        function obeterEnderecoPorCep() {
            EnderecoFactory.obterPorCEP(vm.endereco.cep)
                .then(function (response) {
                    if (response.data.erro == true) {
                        toastr.warning("Cep não encontrado.", 'Erro');
                    } else {
                        vm.endereco = response.data;
                    }
                })
        }
    };

})();