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
    public class LojaRepositorio
    {
        private AppDataContext _context;

        public LojaRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public Loja BuscarPorEmail(string email)
        {
            var loja = _context.Lojas.Where(x => x.emailLoja == email).FirstOrDefault();
            return loja;
        }

    
        public Loja BuscarPorCPF_CNPJ(string cpf_cnpj)
        {
            var loja = _context.Lojas.Where(x => x.CPFCNPJ == cpf_cnpj).FirstOrDefault();
            return loja;
        }


        public Loja BuscarPorEmailComEndereco(string email)
        {
            var loja = _context.Lojas.Where(x => x.emailLoja == email).FirstOrDefault();
            if (loja != null)
                _context.Entry(loja).Collection(p => p.Enderecos).Load();

            return loja;
        }

        public Loja BuscarPorCPF_CNPJComEndereco(string cpf_cnpj)
        {
            var loja = _context.Lojas.Where(x => x.CPFCNPJ == cpf_cnpj).FirstOrDefault();
            if (loja != null)
                _context.Entry(loja).Collection(p => p.Enderecos).Load();

            return loja;
        }

        public Loja BuscarPorNome(string nome)
        {
            var loja = _context.Lojas.Where(x => x.urlLoja.Contains(nome)).FirstOrDefault();
            return loja;
        }

        public void atualizarLoja(Loja loja)
        { 
            _context.Entry(loja).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
