(function () {
    'use strict';
    angular.module('vitrinni_manager').factory('LojaFactory', LojaFactory);

    LojaFactory.$inject = ['$http', 'SETTINGS', '$rootScope'];


    function LojaFactory($http, SETTINGS, $rootScope) {
        return {
            obterLoja: obterLoja,
        };

        function obterLoja(token) {
            var header = {
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }
            return $http.get(SETTINGS.SERVICE_URL + 'api/loja/obterLojaComEndereco', header);
        }
    }
})();