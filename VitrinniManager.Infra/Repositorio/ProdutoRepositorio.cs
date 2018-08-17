using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public int cadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto.idProduto;
        }

        public void cadastrarImagem(Imagem imagem)
        {
            _context.Imagens.Add(imagem);
            _context.SaveChanges();
        }

        public Produto buscarProdutoID(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.idProduto == id);
        }

        public IEnumerable<Produto> buscaProdutoPorIDLoja(int id)
        {
            var produtos = _context.Produtos
                            .Where(x => x.idLoja == id)
                            .Include(x => x.Estoques)
                            .Include(x => x.Departamento)
                            .Include(x => x.Loja)
                            .ToList();
            return produtos;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
