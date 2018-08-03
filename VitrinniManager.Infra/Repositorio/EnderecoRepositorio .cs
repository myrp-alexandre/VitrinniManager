using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class EnderecoRepositorio
    {
        private AppDataContext _context;

        public EnderecoRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public Endereco buscarPorID(int id) {
            var endereco = _context.Enderecos.Where(x => x.idEndereco == id).FirstOrDefault();
            return endereco;
        }

        public IEnumerable<Endereco> buscarPorIDLoja(int idLoja)
        {
            var enderecos = _context.Enderecos.Where(x => x.idLoja == idLoja).ToList();
            return enderecos;
        }

        public void cadastrarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void atualizarEndereco(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void excluirEndereco(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
