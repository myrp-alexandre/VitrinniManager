((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('DepartamentoController', DepartamentoController);
    DepartamentoController.$inject = ['$scope', '$rootScope', 'DepartamentoFactory', 'SETTINGS', '$location'];

    function DepartamentoController($scope, $rootScope, DepartamentoFactory, SETTINGS, $location) {
        var vm = this;

        vm.departamentos = [];
        vm.categorias = [];

        vm.departamento = {
            departamento: null,
            idCategoria: null
        };

        vm.obterDepartamentos = obterDepartamentos;
        vm.obterCategorias = obterCategorias;
        vm.cadastrarDepartamento = cadastrarDepartamento;


        init();

        function init() {
            obterDepartamentos();
            obterCategorias();
        }

        function obterDepartamentos() {
            DepartamentoFactory.obterDepartamentos()
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Depatamentos não encontrados.", 'Erro');
                    } else {
                        vm.departamentos = response.data;
                    }
                })
        }

        function obterCategorias() {
            DepartamentoFactory.obterCategorias()
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Categorias não encontradas.", 'Erro');
                    } else {
                        vm.categorias = response.data;
                    }
                })
        }

        function cadastrarDepartamento(departamento) {
            DepartamentoFactory.Cadastrar(departamento)
                .then(function (response) {
                    toastr.success("Departamento cadastrado.", 'Sucesso');
                    $('#md_cadastrar_departamento').modal('toggle');
                    vm.departamento = {};
                    obterDepartamentos();
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }
    };
}))();