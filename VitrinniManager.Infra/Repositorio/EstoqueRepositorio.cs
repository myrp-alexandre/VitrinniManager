using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class EstoqueRepositorio
    {
        private AppDataContext _context;

        public EstoqueRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public void cadastrarEstoque(Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
        }

        public IEnumerable<Estoque> buscaEstoquePorIDProduto(int idProduto)
        {
            return _context.Estoques.Where(x => x.idProduto == idProduto).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
