(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('DepartamentoFactory', DepartamentoFactory);

    DepartamentoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function DepartamentoFactory($http, SETTINGS, $rootScope) {
        return {
            obterDepartamentos: obterDepartamentos,
            obterCategorias: obterCategorias,
            Cadastrar: Cadastrar
        };

        function obterDepartamentos() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/departamento/obterDepartamentos', $rootScope.header);
        }

        function obterCategorias() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/departamento/obterCategorias', $rootScope.header);
        }

        function Cadastrar(departamento) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/departamento/cadastrarDepartamento', departamento, $rootScope.header);
        }
    }
})();