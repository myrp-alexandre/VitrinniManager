(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('ImagemFactory', ImagemFactory);

    ImagemFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];

    function ImagemFactory($http, SETTINGS, $rootScope) {
        return {
            Cadastrar: Cadastrar,
            obterEstoque: obterEstoque
        };

        function Cadastrar(imagem) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/imagem/cadastrarImagem', imagem, $rootScope.header);
        }

        function obterEstoque(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/imagem/obterImagem/' + id, $rootScope.header);
        }
    }
})();