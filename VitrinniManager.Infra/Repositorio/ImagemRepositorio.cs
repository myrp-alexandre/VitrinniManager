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
    public class ImagemRepositorio
    {
        private AppDataContext _context;

        public ImagemRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public Imagem buscarPorID(int id)
        {
            var imagem = _context.Imagens.Where(x => x.IdProdutoImagem == id).FirstOrDefault();
            return imagem;
        }

        public IEnumerable<Imagem> buscarPorIDProduto(int idProduto)
        {
            var imagens = _context.Imagens.Where(x => x.idProduto == idProduto && x.ativa == true).ToList();
            return imagens;
        }

        public void Inserir(Imagem img)
        {
            _context.Imagens.Add(img);
            _context.SaveChanges();
        }

        public void Deletar(Imagem img)
        {
            _context.Entry(img).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
