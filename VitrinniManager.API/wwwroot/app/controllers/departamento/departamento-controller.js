((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('DepartamentoController', DepartamentoController);
    DepartamentoController.$inject = ['$scope', '$rootScope', 'DepartamentoFactory', 'SETTINGS', '$location'];

    function DepartamentoController($scope, $rootScope, DepartamentoFactory, SETTINGS, $location) {
        var vm = this;

        vm.departamentos = [];

        vm.obterDepartamentos = obterDepartamentos;


        init();

        function init() {
            obterDepartamentos();
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

    };
}))();