((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('ProdutoController', ProdutoController);
    ProdutoController.$inject = ['$scope', '$rootScope', 'ProdutoFactory', 'DepartamentoFactory', 'SETTINGS', '$location'];

    function ProdutoController($scope, $rootScope, ProdutoFactory, DepartamentoFactory, SETTINGS, $location) {
        var vm = this;

        init();

        function init() {
            obterDepartamentos();
            obterCategorias();
            
        }

        vm.imagem = '';
        vm.imagemCortada = '';

        vm.produto = {
            idProduto: 0,
            descricaoProduto: '',
            valorPublicoProduto: '',
            valorCustoProduto: '',
            idLoja: 0,
            idDepartamento: '',
            codigoProdutoFornecedor: '',
            tokenProduto: '',
            especificacao: '',
            ativo: '',
            Altura: '',
            largura: '',
            comprimento: '',
            peso: '',
            estoque: {
                quantidade: 0,
                opcao: '',
                mesmoZerado: false
            }

        };
  
        vm.categorias = [];

        vm.obterCategorias = obterCategorias;
        vm.obterDepartamentos = obterDepartamentos;
        vm.cadastrarDepartamento = cadastrarDepartamento;

        function obterDepartamentos() {
            DepartamentoFactory.obterDepartamentos()
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Depatamentos não encontrados.", 'Erro');
                    } else {
                        vm.departamentos = response.data;
                    }
                })
        }

        function obterCategorias() {
            DepartamentoFactory.obterCategorias()
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Categorias não encontradas.", 'Erro');
                    } else {
                        vm.categorias = response.data;
                    }
                })
        }

        function cadastrarDepartamento(departamento) {
            DepartamentoFactory.Cadastrar(departamento)
                .then(function (response) {
                    toastr.success("Departamento cadastrado.", 'Sucesso');
                    $('#md_cadastrar_departamento').modal('toggle');
                    obterDepartamentos();
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }


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