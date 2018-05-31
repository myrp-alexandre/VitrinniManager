using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class ContaRepositorio
    {
        private AppDataContext _context;

        public ContaRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public Conta Autenticar(string email, string senha)
        {
            string query = @"SELECT emailLoja, tokenLoja FROM vitrinni.tbLoja where emailLoja = @email and senhaLoja = @senha";
            return _context.Database.SqlQuery<Conta>(query, 
                new SqlParameter("@email", email),
                new SqlParameter("@senha", senha)).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
