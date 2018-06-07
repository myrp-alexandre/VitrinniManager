using System;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IContaService : IDisposable
    {
        Conta Autenticar(string email, string senha);
        void Registrar(Conta registro);
        void RecuperarSenha(Conta registro);
        string GerarTokenSenha(string email);
        void EnviarEmail(string destinatario, string assunto, string mensagem);
        void EnviarEmailRecuperarSenha(string usuario);
    }
}
