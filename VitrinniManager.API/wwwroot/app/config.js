(function () {
    //DEV
    //mssql914.umbler.com, 5003
    //brf
    //brf10000
    //Produção
    //mssql914.umbler.com
    //http://vitrinniwebmanager-com.umbler.net/
    //http://localhost:57934/


    'use strict';
    angular.module('vitrinni_manager').constant('SETTINGS', {
        'SERVICE_URL': 'http://localhost:57934/',
        'AUTH_TOKEN': 'token',
        'USER_NAME': 'email',
        'USER_ID': 'token_loja',
    });

    angular.module('vitrinni_manager').run(function (SETTINGS,$location, $rootScope) {
        var token = localStorage.getItem(SETTINGS.AUTH_TOKEN);
        var email = localStorage.getItem(SETTINGS.USER_NAME);
        var token_loja = localStorage.getItem(SETTINGS.USER_ID);

        $rootScope.token = null;
        $rootScope.header = null;
        $rootScope.email = null;
        $rootScope.token_loja = null;

        if (token) {
            $rootScope.token = token;
            $rootScope.email = email;
            $rootScope.token_loja = token_loja;

            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            };
        }
     
        $rootScope.$on("$routeChangeStart", function (event, next, current) { 
            if (next.chave === "valor") {
                return;
            }
            else if ($rootScope.token === null) {
                $location.path('/login');
            }
        });
    });



    angular.module('vitrinni_manager').config(function ($httpProvider) {
        $httpProvider.interceptors.push("ErrorInterceptor");
        $httpProvider.interceptors.push('SpinnerInterceptor');
    });


})();