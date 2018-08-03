(function () {
    'use strict';
    angular.module('vitrinni_manager', ["ngRoute", 'ngImgCrop'])
        .directive("loader", function ($rootScope) {
            return function ($scope, element, attrs) {
                $scope.$on("loader_show", function () {
                    return element.show();
                });
                return $scope.$on("loader_hide", function () {
                    return element.hide();
                });
            };
        }).directive('ngCpfCnpj', function () {
            return {
                restrict: 'A',
                require: 'ngModel',
                link: function (scope, elm, attrs, ctrl) {
                    scope.$watch(attrs.ngModel, function (newVal, oldVal) {
                        ctrl.$setValidity('cpfcnpj', CPF.isValid(newVal) || CNPJ.isValid(newVal));
                    });
                }
            };
        })
})()