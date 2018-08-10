using System.Collections.Generic;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{
    public class EstoqueServico : IEstoqueService
    {

        private readonly EstoqueRepositorio _repositorio = null;

        public EstoqueServico()
        {
            _repositorio = new EstoqueRepositorio(new Infra.Data.AppDataContext());
        }

        public IEnumerable<Estoque> buscaPorIDProduto(int idProduto)
        {
           return _repositorio.buscaEstoquePorIDProduto(idProduto);
        }

        public void cadastrarEstoque(Estoque estoque)
        {
            _repositorio.cadastrarEstoque(estoque);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
