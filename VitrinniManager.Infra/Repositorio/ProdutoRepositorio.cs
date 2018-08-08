using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class ProdutoRepositorio
    {
        private AppDataContext _context;

        public ProdutoRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public void cadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
