(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('EnderecoFactory', EnderecoFactory);

    EnderecoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function EnderecoFactory($http, SETTINGS, $rootScope) {
        return {
            obterPorCEP: obterPorCEP
        };

        function obterPorCEP(cep) {
            return $http.get('https://viacep.com.br/ws/' + cep + '/json/');
        }

    }
})();