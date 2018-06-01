using System;
using System.Collections.Generic;
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
            if (loja != null)
                _context.Entry(loja).Collection(p => p.Enderecos).Load();

            return loja;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
