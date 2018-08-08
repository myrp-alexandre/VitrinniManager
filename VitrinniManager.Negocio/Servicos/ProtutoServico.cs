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

        public void cadastrarProduto(Produto produto)
        {
            _repositorio.cadastrarProduto(produto);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
