(function () {
    'use strict';
    angular.module('vitrinni_manager').controller('LojaController', LojaController);

    LojaController.$inject = ['$scope', 'LojaFactory', 'EnderecoFactory', '$rootScope', 'SETTINGS', '$location', '$route'];
    function LojaController($scope, LojaFactory, EnderecoFactory, $rootScope, SETTINGS, $location, $route) {
        var vm = this;

        vm.loja = {};

        vm.lojaAtualizar = {};

        vm.endereco = [];

        vm.obterLoja = obterLoja;
        vm.atualizarLoja = atualizarLoja;
        vm.obterEnderecoPorCep = obterEnderecoPorCep;
        vm.FilterEndereco = FilterEndereco;
        vm.cadastrarEndereco = cadastrarEndereco;



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

        function atualizarLoja(loja) {
            LojaFactory.atualizarLoja(loja)
                .then(function (response) {
                    toastr.success("Cadastro Atualizado.", 'Sucesso');
                    $('#md_atualizar_cadastro').modal('toggle');
                    obterLoja($rootScope.token)
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

        function cadastrarEndereco(endereco) {
            EnderecoFactory.Cadastrar(endereco)
                .then(function (response) {
                    toastr.success("Endereço cadastrado.", 'Sucesso');
                    $('#md_atualizar_endereco').modal('toggle');
                    vm.endereco = [];
                    obterLoja($rootScope.token)
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }


        function obterEnderecoPorCep(cep) {
            EnderecoFactory.obterPorCEP(cep)
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Cep não encontrado.", 'Erro');
                    } else {
                        vm.endereco = [];
                        vm.endereco.push(response.data);
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