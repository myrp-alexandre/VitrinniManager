((function () {
    'use strict';
    angular.module('vitrinni_manager').controller('ProdutoController', ProdutoController);
    ProdutoController.$inject = ['$scope', '$rootScope', 'ProdutoFactory', 'EstoqueFactory', 'DepartamentoFactory', 'ImagemFactory' ,'SETTINGS', '$location'];

    function ProdutoController($scope, $rootScope, ProdutoFactory, EstoqueFactory, DepartamentoFactory, ImagemFactory, SETTINGS, $location) {
        var vm = this;

        init();

        function init() {
            obterDepartamentos();
            obterCategorias();
        }

        vm.imagem = '';
        vm.imagemCortada = '';

        vm.departamento = {
            departamento: null,
            idCategoria: null
        };

        vm.categorias = [];

        vm.produtos = [];

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
            ativo: false,
            Altura: '',
            largura: '',
            comprimento: '',
            peso: '',
            servico: 0,
            estoque: [{
               
            }]
        };

        vm.estoque = {
            idProduto: 0,
            qtde: '',
            opcao: '',
            mostraMesmoZerado: false
        };

        vm.obterCategorias = obterCategorias;
        vm.obterDepartamentos = obterDepartamentos;
        vm.obterEstoque = obterEstoque;
        vm.obterProdutos = obterProdutos;
       
        vm.cadastrarDepartamento = cadastrarDepartamento;
        vm.cadastrarProduto = cadastrarProduto;
        vm.cadastrarEstoque = cadastrarEstoque;
        vm.cadastrarImagem = cadastrarImagem;

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

        function obterEstoque(idProduto) {
            EstoqueFactory.obterEstoque(idProduto)
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Estoque não encontrado.", 'Erro');
                    } else {
                        vm.produto.estoque = response.data;
                    }
                })
        }

        function obterProdutos() {
            ProdutoFactory.obterProdutos()
                .then(function (response) {
                    if (response.data.erro === true) {
                        toastr.warning("Não foi possível carregar os produtos da loja.", 'Erro');
                    } else {
                        vm.produtos = response.data;
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

        function cadastrarProduto(produto) {
            ProdutoFactory.Cadastrar(produto)
                .then(function (response) {
                    vm.produto.idProduto = response.data;
                    toastr.success("Produto cadastrado.", 'Sucesso');
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

        function cadastrarEstoque(estoque) {

            vm.estoque.idProduto = vm.produto.idProduto;

            EstoqueFactory.Cadastrar(estoque)
                .then(function (response) {
                    toastr.success("Estoque cadastrado", 'Sucesso');
                    $('#md_cadastrar_estoque').modal('toggle');
                    vm.estoque = {};
                    obterEstoque(vm.produto.idProduto);
                })
                .catch(function (error) {
                    toastr.error(error.data.Message, 'Erro');
                });
        }

        function cadastrarImagem(imagem) {


            var content = imagem.substr(imagem.indexOf("base64,") + "base64,".length);
            var imagem = {
                idProduto: vm.produto.idProduto,
                nome: imagem.replace(/^data:image\/(png|jpg);base64,/, ""),
                principal: 1,
                ativa: true
            };

            ImagemFactory.Cadastrar(imagem)
                .then(function (response) {
                    toastr.success("Imagem cadastrada", 'Sucesso');
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