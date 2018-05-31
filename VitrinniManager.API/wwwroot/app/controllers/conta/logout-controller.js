(function () {
    'use strict';
    angular.module('vitrinni_manager').controller('LogoutController', LogoutController);

    LogoutController.$inject = ['$rootScope', '$location', 'SETTINGS'];

    function LogoutController($rootScope, $location, SETTINGS) {
        var vm = this;

        activate();

        function activate() {
            $rootScope.token = null;
            $rootScope.header = null;
            $rootScope.email = null;
            $rootScope.token_loja = null;

            localStorage.removeItem(SETTINGS.USER_NAME);
            localStorage.removeItem(SETTINGS.USER_ID);
            localStorage.removeItem(SETTINGS.AUTH_TOKEN);

            $location.path('/login');
        }
    }
})();