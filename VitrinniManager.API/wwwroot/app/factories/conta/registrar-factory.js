(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('RegistrarFactory', RegistrarFactory);

    RegistrarFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function RegistrarFactory($http, SETTINGS, $rootScope) {
        return {
            registrar: registrar,
        };

        function registrar(registro) {

            return $http.post(SETTINGS.SERVICE_URL + 'api/conta/registrar', registro );
        }
    }
})();