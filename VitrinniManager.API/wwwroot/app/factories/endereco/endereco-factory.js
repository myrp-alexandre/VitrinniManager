(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('EnderecoFactory', EnderecoFactory);

    EnderecoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function EnderecoFactory($http, SETTINGS, $rootScope) {
        return {
            obterPorCEP: obterPorCEP,
            Cadastrar: Cadastrar
        };

        function obterPorCEP(cep) {
            return $http.get('https://viacep.com.br/ws/' + cep + '/json/');
        }

        function Cadastrar(endereco) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/loja/cadastrarEndereco', endereco, $rootScope.header);
        }
    }
})();