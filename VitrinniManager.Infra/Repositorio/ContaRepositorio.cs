using System.Data.SqlClient;
using System.Linq;
using VitrinniManager.Compartilhado.Common.Email;
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

        public void Create(Conta registro)
        {
            string query = @"INSERT INTO vitrinni.tbLoja (emailLoja, CPFCNPJ, senhaLoja) VALUES(@emailLoja ,@CPFCNPJ , @senhaLoja)";
            _context.Database.ExecuteSqlCommand(query,
                new SqlParameter("@emailLoja", registro.emailLoja),
                new SqlParameter("@CPFCNPJ", registro.CPFCNPJ),
                new SqlParameter("@senhaLoja", registro.senhaLoja));
        }

        public void InsereTokenSenha(string token, int idLoja)
        {
            string query = @"UPDATE vitrinni.tbLoja SET tokenSenha = @tokenSenha WHERE idLoja = @idLoja";
            _context.Database.ExecuteSqlCommand(query,
                new SqlParameter("@tokenSenha", token),
                new SqlParameter("@idLoja", idLoja));
        }


        public void RecuperarSenha(Conta registro)
        {
            string query = @"UPDATE vitrinni.tbLoja SET senhaLoja = @senhaLoja WHERE CPFCNPJ = @cpf_cnpj AND tokenSenha = @tokenSenha";
            _context.Database.ExecuteSqlCommand(query,
                new SqlParameter("@senhaLoja", registro.senhaLoja),
                new SqlParameter("@cpf_cnpj", registro.CPFCNPJ),
                new SqlParameter("@tokenSenha", registro.tokenSenha));
        }



        public void LimpaTokenSenha(int idLoja)
        {
            string query = @"UPDATE vitrinni.tbLoja SET tokenSenha = '' WHERE idLoja = @idLoja";
            _context.Database.ExecuteSqlCommand(query,
                new SqlParameter("@idLoja", idLoja));
        }

        public void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            new EmailUtil().EnviarEmailAsync(destinatario, assunto, mensagem);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
