(function () {
    'use strict';
    angular.module('vitrinni_manager').controller('LojaController', LojaController);

    LojaController.$inject = ['$scope', 'LojaFactory', 'EnderecoFactory', '$rootScope', 'SETTINGS', '$location'];
    function LojaController($scope, LojaFactory, EnderecoFactory, $rootScope, SETTINGS, $location) {
        var vm = this;

        vm.loja = {};

        vm.lojaAtualizar = {};

        vm.endereco = [];

        vm.obterLoja = obterLoja;
        vm.obterEnderecoPorCep = obterEnderecoPorCep;
        vm.FilterEndereco = FilterEndereco;



        init();

        function init() {
            obterLoja($rootScope.token);
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

        function obterEnderecoPorCep() {
            EnderecoFactory.obterPorCEP(vm.endereco.cep)
                .then(function (response) {
                    if (response.data.erro == true) {
                        toastr.warning("Cep não encontrado.", 'Erro');
                    } else {
                        vm.endereco = response.data;
                    }
                })
        }

        function FilterEndereco(id) {
            angular.forEach(vm.loja.enderecos, function (values, key) {
                if (values.idEndereco === id) {
                    vm.endereco = [];
                    vm.endereco.push(values);
                }
            });
        }
    };

})();