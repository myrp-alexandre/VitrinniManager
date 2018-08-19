﻿(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('ImagemFactory', ImagemFactory);

    ImagemFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];

    function ImagemFactory($http, SETTINGS, $rootScope) {
        return {
            Cadastrar: Cadastrar,
            obterImagens: obterImagens
        };

        function Cadastrar(imagem) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/imagem/cadastrarImagem', imagem, $rootScope.header);
        }

        function obterImagens(idProduto) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/imagem/obterImagensIDProduto/' + idProduto, $rootScope.header);
        }
    }
})();