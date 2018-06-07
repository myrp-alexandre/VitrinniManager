(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('RecuperarSenhaFactory', RecuperarSenhaFactory);

    RecuperarSenhaFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function RecuperarSenhaFactory($http, SETTINGS, $rootScope) {
        return {
            recuperarSenha: recuperarSenha,
            gerarTokenSenha: gerarTokenSenha,
        };

        function gerarTokenSenha(email) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/conta/gerarTokenSenha?email=' + email);
        }

        function recuperarSenha(registro) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/conta/recuperarSenha', registro);
        }
    }
})();