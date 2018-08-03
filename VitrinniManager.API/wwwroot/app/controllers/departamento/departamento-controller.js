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
        vm.alterarDepartamento = alterarDepartamento;
        vm.FilterDepartamento = FilterDepartamento;
        vm.LimparForm = LimparForm;


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
                    obterDepartamentos();
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

        function alterarDepartamento(departamento) {
            DepartamentoFactory.Alterar(departamento)
                .then(function (response) {
                    toastr.success("Departamento Alterado.", 'Sucesso');
                    $('#md_alterar_departamento').modal('toggle');
                    obterDepartamentos();
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }
        function FilterDepartamento(id) {
            angular.forEach(vm.departamentos, function (values, key) {
                if (values.idDepartamento === id) {
                    vm.departamento.idDepartamento = values.idDepartamento;
                    vm.departamento.departamento = values.departamento;
                    vm.departamento.idCategoria = String(values.idCategoria);
                }
            });
        }

        function LimparForm() {
            vm.departamento = {
                departamento: null,
                idCategoria: null
            };
        }
    };
}))();