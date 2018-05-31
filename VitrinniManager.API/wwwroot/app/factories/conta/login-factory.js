(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('LoginFactory', LoginFactory);

    LoginFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function LoginFactory($http, SETTINGS, $rootScope) {
        return {
            autenticar: autenticar,
            obterUsuario: obterUsuario
        };
        function autenticar(login) {
            var dt = "grant_type=password&username=" + login.email + "&password=" + login.senha;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return $http.post(url, dt, header);
        }
        function obterUsuario(token) {
            var header = {
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }
            return $http.get(SETTINGS.SERVICE_URL + 'api/home', header);
        }
    }
})();