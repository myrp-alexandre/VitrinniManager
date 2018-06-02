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

        function recuperarSenha(user) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/conta/recuperarSenha', { headers: { 'password': user.password, 'token': user.token, 'idUser': user.idUser } });
        }
    }
})();