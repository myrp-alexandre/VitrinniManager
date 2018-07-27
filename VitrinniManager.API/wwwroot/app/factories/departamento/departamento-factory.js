(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('DepartamentoFactory', DepartamentoFactory);

    DepartamentoFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function DepartamentoFactory($http, SETTINGS, $rootScope) {
        return {
            obterDepartamentos: obterDepartamentos
        };

        function obterDepartamentos() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/departamento/obterDepartamentos', $rootScope.header);
        }
    }
})();