(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('ProdutoFactory', ProdutoFactory);

    ProdutoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];

    function ProdutoFactory($http, SETTINGS, $rootScope) {
        return {
            obterDepartamentos: obterDepartamentos,
            obterCategorias: obterCategorias,
            Cadastrar: Cadastrar,
            Alterar: Alterar
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

        function Alterar(departamento) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/departamento/alterarDepartamento', departamento, $rootScope.header);
        }
    }
})();