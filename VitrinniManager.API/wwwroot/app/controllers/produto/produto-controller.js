((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('ProdutoController', ProdutoController);
    ProdutoController.$inject = ['$scope', '$rootScope', 'DepartamentoFactory', 'SETTINGS', '$location'];

    function ProdutoController($scope, $rootScope, ProdutoFactory, SETTINGS, $location) {
        var vm = this;

        init();

        function init() {
        }

        vm.imagem = '';
        vm.imagemCortada = '';
  
        var handleFileSelect = function (evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function (evt) {
                $scope.$apply(function ($scope) {
                    vm.imagem = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#fileInput')).on('change', handleFileSelect);
    };
}))();