(function () {
    angular.module("vitrinni_manager").factory("ErrorInterceptor", function ($q, $location, $rootScope) {
        return {
            // optional method
            'request': function (config) {
                // do something on success
                return config;
            },

            // optional method
            'requestError': function (rejection) {
                // do something on error
                if (canRecover(rejection)) {
                    return responseOrNewPromise
                }
                return $q.reject(rejection);
            },

            // optional method
            'response': function (response) {
                return response;
            },

            // optional method
            'responseError': function (rejection) {
                // do something on error
                if (rejection.status === 401) {
                    $location.path('/logout');
                }
                return $q.reject(rejection);
            }
        };
    });
})();

