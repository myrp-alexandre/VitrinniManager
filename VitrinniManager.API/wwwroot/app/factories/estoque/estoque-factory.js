(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('EstoqueFactory', EstoqueFactory);

    EstoqueFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];

    function EstoqueFactory($http, SETTINGS, $rootScope) {
        return {
            Cadastrar: Cadastrar,
            obterEstoque: obterEstoque
        };

        function Cadastrar(estoque) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/estoque/cadastrarEstoque', estoque, $rootScope.header);
        }

        function obterEstoque(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/estoque/obterEstoque/' + id, $rootScope.header);
        }
    }
})();