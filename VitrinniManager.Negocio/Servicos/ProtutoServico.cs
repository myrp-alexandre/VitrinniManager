using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return produto;
        }

        public int cadastrarProduto(Produto produto)
        {
            int idProduto = _repositorio.cadastrarProduto(produto);
            return idProduto;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
