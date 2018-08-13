using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{
    public class ProtutoServico : IProdutoService
    {
        private readonly ProdutoRepositorio _repositorio = null;

        public ProtutoServico()
        {
            _repositorio = new ProdutoRepositorio(new Infra.Data.AppDataContext());
        }

        public Produto bucarProdutoID(int id)
        {
            var produto = _repositorio.buscarProdutoID(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            return produto;
        }

        public IEnumerable<Produto> buscaProdutosIDLoja(int id)
        {
            IEnumerable<Produto> produtos = _repositorio.buscaProdutoPorIDLoja(id);
            if (produtos == null)
                throw new Exception("Não foi possível carregar os produtos da loja.");

            return produtos;
        }

        public int cadastrarProduto(Produto produto)
        {
            Produto p = new Produto(produto.descricaoProduto, produto.valorPublicoProduto, produto.valorCustoProduto, produto.idLoja, produto.idDepartamento,
                produto.codigoProdutoFornecedor, produto.especificacao, produto.ativo, 
                produto.Altura, produto.largura, produto.comprimento, produto.peso, produto.servico);

            p.ValidaProduto(p);

            int idProduto = _repositorio.cadastrarProduto(p);
            return idProduto;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
