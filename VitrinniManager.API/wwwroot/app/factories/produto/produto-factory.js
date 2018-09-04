(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('ProdutoFactory', ProdutoFactory);

    ProdutoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];

    function ProdutoFactory($http, SETTINGS, $rootScope) {
        return {
            Cadastrar: Cadastrar,
            obterProdutos: obterProdutos, 
        };

        function Cadastrar(produto) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/produto/cadastrarProduto', produto, $rootScope.header);
        }

        function obterProdutos() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/produto/obterProdutos', $rootScope.header);
        }
    }
})();